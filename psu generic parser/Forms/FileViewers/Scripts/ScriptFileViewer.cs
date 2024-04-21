using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using psu_generic_parser.Forms.FileViewers.Scripts;
using PSULib.FileClasses.General;
using static PSULib.FileClasses.General.ScriptFile;
using System.Diagnostics;

namespace psu_generic_parser
{
	public partial class ScriptFileViewer : UserControl
	{
		readonly ScriptFile internalFile;
		bool changing = true;
		private int prevSubIndex = -1;
		private int curSubRoutineIndex = -1;

		private int copyIndexStart = -1;
		private int copyIndexEnd = -1;
		private string highlightLabel = "";

		bool forceChange = false;
		BindingSource binder = new BindingSource();
		private List<ReferenceFindDialog> children = new List<ReferenceFindDialog>();

		private Dictionary<int, int> ScriptRoutineLookup = new Dictionary<int, int>();
		private Dictionary<int, int> ScriptVariableLookup = new Dictionary<int, int>();

		public ScriptFileViewer(ScriptFile toImport)
		{
			InitializeComponent();

			internalFile = toImport;

			buildLookupDictionary();

			List<string> opcodeNames = new List<string>();
			foreach (string opcode in ScriptFile.opcodes)
			{
				if (opcode != "")
				{
					opcodeNames.Add(opcode);
				}
			}

			OpcodeColumn.Items.AddRange(opcodeNames.ToArray());
			LabelColumn.DataPropertyName = "Label";
			ArgColumn.DataPropertyName = "OperandText";
			OpcodeColumn.DataPropertyName = "OpCodeName";
			if (subroutineListBox.Items.Count > 0)
				subroutineListBox.SelectedIndex = 0;
		}

		// I'm sure there is a better way to do this,
		// but it works for now.
		private void buildLabelHighlights()
		{
			if (dataGridScriptOpEditor.RowCount == 0) return;
			
			foreach( DataGridViewRow row in dataGridScriptOpEditor.Rows )
			{
				if (row.Cells[0].Value != null )
				{
					var label = row.Cells[0].Value.ToString();

					if( label.Contains( highlightLabel ) && highlightLabel.Length > 1 )
						row.Cells[0].Style.BackColor = Color.GreenYellow;
					else if(label.Contains( "label_" ))
						row.Cells[0].Style.BackColor = Color.PowderBlue;
					else
						row.Cells[0].Style.BackColor = Color.White;
				}

				if (row.Cells[2].Value != null)
				{
					var label = row.Cells[2].Value.ToString();

					if (label.Contains(highlightLabel) && highlightLabel.Length > 1 )
						row.Cells[2].Style.BackColor = Color.GreenYellow;
					else if (label.Contains("label_"))
						row.Cells[2].Style.BackColor = Color.PowderBlue;
					else
						row.Cells[2].Style.BackColor = Color.White;
				}
			}
		}

		private void buildLookupDictionary()
		{
			ScriptRoutineLookup.Clear();
			ScriptVariableLookup.Clear();

			for (int i = 0; i < internalFile.Subroutines.Count; i++)
			{
				switch (internalFile.Subroutines[i].SubType)
				{
					case SubRoutineTypes.Function:
						{
							ScriptRoutineLookup.Add(subroutineListBox.Items.Count, i);
							subroutineListBox.Items.Add(internalFile.Subroutines[i].SubroutineName);
						}
						break;

					case SubRoutineTypes.Numeric:
						{
							ScriptVariableLookup.Add(dataGridScriptVariables.Rows.Count, i);
							dataGridScriptVariables.Rows.Add("Numeric", internalFile.Subroutines[i].SubroutineName, internalFile.Subroutines[i].BufferLength);
						}
						break;

					case SubRoutineTypes.String:
						{
							ScriptVariableLookup.Add(dataGridScriptVariables.Rows.Count, i);
							dataGridScriptVariables.Rows.Add("String", internalFile.Subroutines[i].SubroutineName, internalFile.Subroutines[i].BufferLength);
						}
						break;
				}
			}
		}

		private void subroutineListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (subroutineListBox.SelectedIndex != -1 && (subroutineListBox.SelectedIndex != prevSubIndex || forceChange))
			{
				forceChange = false;
				prevSubIndex = subroutineListBox.SelectedIndex;
				curSubRoutineIndex = ScriptRoutineLookup.ElementAt(subroutineListBox.SelectedIndex).Value;

				changing = true;
				{
					highlightLabel = "";
					Subroutine currentSub = internalFile.Subroutines[curSubRoutineIndex];
					UpdateUIElements();
					dataGridScriptOpEditor.AutoGenerateColumns = false;
					binder.DataSource = currentSub.Operations;
					dataGridScriptOpEditor.DataSource = binder;
				}
				changing = false;
			}

			buildLabelHighlights();
		}

		private void subroutineListBox_DrawItem(object sender, DrawItemEventArgs e)
		{
			Graphics g = e.Graphics;

			ScriptFile.Subroutine currentSub = internalFile.Subroutines[e.Index];

			SolidBrush backgroundBrush = new SolidBrush(e.BackColor);
			SolidBrush foregroundBrush = new SolidBrush(Color.Green);// e.ForeColor);

			Font textFont = e.Font;
			string text = currentSub.SubroutineName;

			RectangleF rectangle = new RectangleF(new PointF(e.Bounds.X, e.Bounds.Y), new SizeF(e.Bounds.Width, g.MeasureString(text, textFont).Height));

			g.FillRectangle(backgroundBrush, rectangle);
			g.DrawString(text, textFont, foregroundBrush, rectangle);

			backgroundBrush.Dispose();
			foregroundBrush.Dispose();
			g.Dispose();
		}

		private void UpdateUIElements()
		{
			ScriptFile.Subroutine currentSub = internalFile.Subroutines[curSubRoutineIndex];

			if (currentSub.SubType == SubRoutineTypes.Function)
			{
				dataGridScriptOpEditor.Enabled = true;
			}
			else if (currentSub.SubType == SubRoutineTypes.String)
			{
				dataGridScriptOpEditor.Enabled = false;
			}
			else if (currentSub.SubType == SubRoutineTypes.Numeric)
			{
				dataGridScriptOpEditor.Enabled = false;
			}
			else
			{
				throw new Exception("Received unexpected subroutine type: " + currentSub.SubType.ToString("X2"));
			}
		}

		private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			DataGridView gridView = sender as DataGridView;
			foreach (DataGridViewRow r in gridView.Rows)
				gridView.Rows[r.Index].HeaderCell.Value = (r.Index).ToString();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			bool accept = false;
			Form prompt = new Form();
			prompt.Width = 500;
			prompt.Height = 350;
			prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
			prompt.MinimizeBox = false;
			prompt.MaximizeBox = false;
			prompt.ShowInTaskbar = false;
			prompt.Text = "Select subroutines";
			Label textLabel = new Label() { Left = 50, Top = 20, Text = "Select subroutines to export." };
			textLabel.AutoSize = true;
			CheckedListBox checkList = new CheckedListBox() { Left = 50, Top = 50, Width = 400, Height = 200 };
			checkList.Items.AddRange(subroutineListBox.Items.Cast<string>().ToArray());
			Button confirmation = new Button() { Text = "OK", Left = 125, Width = 100, Top = 260 };
			confirmation.Click += (a, b) => { prompt.Close(); accept = true; };
			Button cancel = new Button() { Text = "Cancel", Left = 250, Width = 100, Top = 260 };
			cancel.Click += (a, b) => { prompt.Close(); };
			prompt.Controls.Add(confirmation);
			prompt.Controls.Add(textLabel);
			prompt.Controls.Add(checkList);
			prompt.Controls.Add(cancel);
			prompt.ShowDialog();
			if (accept && checkList.CheckedItems.Count > 0)
			{
				string[] selectedFuncs = new string[checkList.CheckedItems.Count];
				for (int i = 0; i < selectedFuncs.Length; i++)
				{
					selectedFuncs[i] = (string)checkList.CheckedItems[i];
				}
				SaveFileDialog tempDialog = new SaveFileDialog();
				if (tempDialog.ShowDialog() == DialogResult.OK)
				{
					byte[] scriptOut = internalFile.dumpSubroutine(selectedFuncs);
					System.IO.File.WriteAllBytes(tempDialog.FileName, scriptOut);
				}
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			OpenFileDialog tempDia = new OpenFileDialog();
			if (tempDia.ShowDialog() == DialogResult.OK)
			{
				byte[] impScript = System.IO.File.ReadAllBytes(tempDia.FileName);
				ScriptFile tempScript = new ScriptFile("dummy.bin", impScript);
				internalFile.importScript(tempScript);
				foreach (ScriptFile.Subroutine sub in tempScript.Subroutines)
				{
					if (!subroutineListBox.Items.Contains(sub.SubroutineName))
						subroutineListBox.Items.Add(sub.SubroutineName);
				}
			}
		}

		private void dataGridView2_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				var hti = dataGridScriptOpEditor.HitTest(e.X, e.Y);
				if (hti.RowIndex > -1 && hti.RowIndex < dataGridScriptOpEditor.Rows.Count)
				{
					dataGridScriptOpEditor.ClearSelection();
					dataGridScriptOpEditor.Rows[hti.RowIndex].Selected = true;
				}
			}
		}

		private void insertRowMenuItem_Click(object sender, EventArgs e)
		{
			ScriptFile.Subroutine currentSub = internalFile.Subroutines[curSubRoutineIndex];
			int rowToInsert = dataGridScriptOpEditor.Rows.GetFirstRow(DataGridViewElementStates.Selected);
			dataGridScriptOpEditor.ClearSelection();
			ScriptFile.Operation newOp = new ScriptFile.Operation();
			newOp.OpCode = 1;
			currentSub.Operations.Insert(rowToInsert, newOp);
			binder.ResetBindings(false);
			dataGridScriptOpEditor.Refresh();
		}

		private void deleteRowMenuItem_Click(object sender, EventArgs e)
		{
			int rowToDelete = dataGridScriptOpEditor.Rows.GetFirstRow(DataGridViewElementStates.Selected);
			ScriptFile.Subroutine currentSub = internalFile.Subroutines[curSubRoutineIndex];
			dataGridScriptOpEditor.ClearSelection();
			currentSub.Operations.RemoveAt(rowToDelete);
			binder.ResetBindings(false);
			dataGridScriptOpEditor.Refresh();
		}

		private void subroutineSearch_TextChanged(object sender, EventArgs e)
		{
			int result = subroutineListBox.FindString(subroutineSearchBox.Text);
			if (result != -1)
			{
				subroutineListBox.SelectedIndex = result;
				subroutineSearchBox.ForeColor = SystemColors.WindowText;
			}
			else
			{
				subroutineSearchBox.ForeColor = Color.Red;
			}
		}

		private void operationsContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (dataGridScriptOpEditor.SelectedRows.Count == 0)
			{
				e.Cancel = true;
			}
			else
			{
				int rowToRead = dataGridScriptOpEditor.Rows.GetFirstRow(DataGridViewElementStates.Selected);
				var rowArg = dataGridScriptOpEditor.Rows[rowToRead].Cells[2].Value.ToString();
				ScriptFile.Subroutine currentSub = internalFile.Subroutines[curSubRoutineIndex];

				if (rowToRead < currentSub.Operations.Count)
				{
					ScriptFile.Operation currentOp = currentSub.Operations[rowToRead];
					goToReferenceToolStripMenuItem.Visible = true;
					
					bool checkExists = hasDestination(currentOp.OpCodeType, rowArg);
					deleteRowMenuItem.Enabled = checkExists;
					peekToolStripMenuItem.Enabled = ( checkExists && currentOp.OpCodeType == OpCodeOperandTypes.FunctionName );
					goToolStripMenuItem.Enabled = checkExists;
					goToReferenceToolStripMenuItem.Enabled = checkExists;
				}
				else
				{
					deleteRowMenuItem.Enabled = false;
					peekToolStripMenuItem.Enabled = false;
					goToolStripMenuItem.Enabled = false;
					goToReferenceToolStripMenuItem.Enabled = false;
				}
			}
		}

		private bool hasDestination(ScriptFile.OpCodeOperandTypes testType, string arg)
		{
			switch (testType)
			{
				case ScriptFile.OpCodeOperandTypes.FunctionName:
					{
						return subroutineListBox.Items.Contains(arg);
					} break;

				case ScriptFile.OpCodeOperandTypes.BranchTarget:
					return true;

				case ScriptFile.OpCodeOperandTypes.NumericVariableName:
				case ScriptFile.OpCodeOperandTypes.StringVariableName:
					{
						foreach (DataGridViewRow row in dataGridScriptVariables.Rows)
						{
							if (row.Cells[1].Value == null) continue;
							if (row.Cells[1].Value.ToString().Equals(arg))
							{
								return true;
							}
						}
					} break;
			}
			return false;
		}

		private bool hasSubroutineDestination(ScriptFile.OpCodeOperandTypes testType)
		{
			return testType == ScriptFile.OpCodeOperandTypes.FunctionName
				|| testType == ScriptFile.OpCodeOperandTypes.NumericVariableName
				|| testType == ScriptFile.OpCodeOperandTypes.StringVariableName;
		}

		public void SelectOperation(string subroutineName, int lineNumber)
		{
			int functionIndex = subroutineListBox.Items.IndexOf(subroutineName);
			if (functionIndex == -1)
			{
				return;
			}

			subroutineListBox.SelectedIndex = functionIndex;

			if( lineNumber >= dataGridScriptOpEditor.RowCount )
			{
				dataGridScriptOpEditor.CurrentCell = dataGridScriptOpEditor.Rows[lineNumber].Cells[0];
			}
			else
			{
				dataGridScriptOpEditor.CurrentCell = dataGridScriptOpEditor.Rows[lineNumber].Cells[2];
			}
		}

		private void findReferencesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string subroutineName = (string)subroutineListBox.SelectedItem;
			var findResults = new List<Tuple<string, int>>();
			foreach (var subroutine in internalFile.Subroutines)
			{
				for (int i = 0; i < subroutine.Operations.Count; i++)
				{
					if (hasSubroutineDestination(subroutine.Operations[i].OpCodeType) && subroutine.Operations[i].OperandText == subroutineName)
					{
						findResults.Add(new Tuple<string, int>(subroutine.SubroutineName, i));
					}
				}
			}

			if (findResults.Count > 0)
			{
				ReferenceFindDialog dlg = new ReferenceFindDialog(this, subroutineName, findResults);
				children.Add(dlg);
				dlg.Show();
			}
			else
			{
				MessageBox.Show("No references found to subroutine/variable " + subroutineName, "No Results Found");
			}
		}

		private void subroutineListBox_MouseDown(object sender, MouseEventArgs e)
		{
			subroutineListBox.SelectedIndex = subroutineListBox.IndexFromPoint(e.Location);
		}

		private void ScriptFileViewer_ParentChanged(object sender, EventArgs e)
		{
			if (this.Parent != null)
			{
				return;
			}

			foreach (var child in children)
			{
				child.Hide();
			}
		}

		private void ctxMenuSubNewRoutine_Click(object sender, EventArgs e)
		{
			bool accept = false;
			Form prompt = new Form();
			prompt.Width = 500;
			prompt.Height = 150;
			prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
			prompt.MinimizeBox = false;
			prompt.MaximizeBox = false;
			prompt.ShowInTaskbar = false;
			prompt.Text = "Select location";
			Label textLabel = new Label() { Left = 50, Top = 20, Text = "Select where to insert subroutine." };
			textLabel.AutoSize = true;
			ComboBox comboBox = new ComboBox() { Left = 50, Top = 50, Width = 400 };
			comboBox.Items.AddRange(subroutineListBox.Items.Cast<string>().ToArray());
			comboBox.Items.Add("End of file");
			comboBox.SelectedIndex = 0;

			NumericUpDown inputBox = new NumericUpDown() { Left = 50, Top = 50, Width = 400 };
			Button confirmation = new Button() { Text = "OK", Left = 125, Width = 100, Top = 85 };
			confirmation.Click += (a, b) => { prompt.Close(); accept = true; };
			Button cancel = new Button() { Text = "Cancel", Left = 250, Width = 100, Top = 85 };
			cancel.Click += (a, b) => { prompt.Close(); };
			prompt.Controls.Add(confirmation);
			prompt.Controls.Add(textLabel);
			prompt.Controls.Add(comboBox);
			prompt.Controls.Add(cancel);
			prompt.ShowDialog();

			if (accept && comboBox.SelectedIndex != -1)
			{
				ScriptFile.Subroutine sub = new ScriptFile.Subroutine();
				sub.SubType = SubRoutineTypes.Function;
				internalFile.Subroutines.Insert(comboBox.SelectedIndex, sub);
				subroutineListBox.Items.Insert(comboBox.SelectedIndex, internalFile.Subroutines[comboBox.SelectedIndex].SubroutineName);

				buildLookupDictionary();

				forceChange = true;
				subroutineListBox.SelectedIndex = comboBox.SelectedIndex;

			}
		}

		private void ctxMenuSubDelete_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to delete " + internalFile.Subroutines[curSubRoutineIndex].SubroutineName + "?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				int oldIndex = subroutineListBox.SelectedIndex;
				subroutineListBox.Items.RemoveAt(oldIndex);
				internalFile.Subroutines.RemoveAt(oldIndex);

				buildLookupDictionary();

				forceChange = true;
				subroutineListBox.SelectedIndex = Math.Min(oldIndex, subroutineListBox.Items.Count - 1);
			}
		}

		private void dataGridScriptVariables_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			var SelectedRow = e.RowIndex;

			if (SelectedRow < ScriptVariableLookup.Count)
			{
				return;
			}

			Subroutine newSubroutine = new Subroutine();
			var newIndex = ScriptVariableLookup.Count;

			newSubroutine.SubroutineName = "new_" + newIndex;
			newSubroutine.SubType = SubRoutineTypes.Numeric;
			newSubroutine.BufferLength = 0;
			internalFile.Subroutines.Add(newSubroutine);

			ScriptVariableLookup.Add(ScriptVariableLookup.Count + 1, internalFile.Subroutines.Count - 1);
		}

		private void dataGridScriptVariables_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			var SelectedRow = e.RowIndex;
			var SelectedCol = e.ColumnIndex;
			var CurRoutineIndex = ScriptVariableLookup.ElementAt(SelectedRow).Value;

			switch (SelectedCol)
			{
				// Type
				case 0:
					{
						if (dataGridScriptVariables.Rows[e.RowIndex].Cells[SelectedCol].Value.ToString() == "Numeric")
						{
							internalFile.Subroutines[CurRoutineIndex].SubType = SubRoutineTypes.Numeric;
						}
						else if (dataGridScriptVariables.Rows[e.RowIndex].Cells[SelectedCol].Value.ToString() == "String")
						{
							internalFile.Subroutines[CurRoutineIndex].SubType = SubRoutineTypes.String;
						}
					}
					break;

				// Name
				case 1:
					{
						internalFile.Subroutines[CurRoutineIndex].SubroutineName = dataGridScriptVariables.Rows[e.RowIndex].Cells[SelectedCol].Value.ToString();
					}
					break;

				// Length
				case 2:
					{
						internalFile.Subroutines[CurRoutineIndex].BufferLength = Int32.Parse(dataGridScriptVariables.Rows[e.RowIndex].Cells[SelectedCol].Value.ToString());
					}
					break;
			}
		}

		private void dataGridScriptVariables_DeleteRow(object sender, DataGridViewRowCancelEventArgs e)
		{
			int SelectedRow = e.Row.Index;
			curSubRoutineIndex = ScriptVariableLookup.ElementAt(SelectedRow).Value;

			if (MessageBox.Show("Are you sure you want to delete " + internalFile.Subroutines[curSubRoutineIndex].SubroutineName + "?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.No)
			{
				e.Cancel = true;
				return;
			}

			dataGridScriptVariables.Rows.RemoveAt(SelectedRow);
			internalFile.Subroutines.RemoveAt(curSubRoutineIndex);

			buildLookupDictionary();

			forceChange = true;
		}

		private void ctxMenuOpCopy_Click(object sender, EventArgs e)
		{
			if (this.dataGridScriptOpEditor.SelectedRows.Count <= 0)
				return;

			this.copyIndexStart = this.copyIndexEnd = this.dataGridScriptOpEditor.SelectedRows[0].Index;
			foreach (DataGridViewBand selectedRow in (BaseCollection)this.dataGridScriptOpEditor.SelectedRows)
			{
				int index = selectedRow.Index;
				if (index < this.copyIndexStart)
					this.copyIndexStart = index;
				if (index > this.copyIndexEnd)
					this.copyIndexEnd = index;
			}
		}

		private void ctxMenuOpPaste_Click(object sender, EventArgs e)
		{
			if (this.copyIndexStart == -1 || this.copyIndexEnd == -1 || this.dataGridScriptOpEditor.SelectedRows.Count == 0)
				return;
			ScriptFile.Subroutine subroutine = this.internalFile.Subroutines[this.subroutineListBox.SelectedIndex];
			int index1 = this.dataGridScriptOpEditor.SelectedRows[0].Index;
			List<ScriptFile.Operation> operationList = new List<ScriptFile.Operation>(subroutine.Operations.Skip<ScriptFile.Operation>(this.copyIndexStart).Take<ScriptFile.Operation>(this.copyIndexEnd + 1 - this.copyIndexStart));
			for (int index2 = 0; index2 <= this.copyIndexEnd - this.copyIndexStart; ++index2)
			{
				int copyIndexStart = this.copyIndexStart;
				ScriptFile.Operation operation1 = operationList[index2];
				ScriptFile.Operation operation2 = new ScriptFile.Operation()
				{
					Label = operation1.Label,
					OperandText = operation1.OperandText,
					OpCode = operation1.OpCode
				};
				operation2.OperandText = operation1.OperandText;
				subroutine.Operations.Insert(index1 + index2, operation2);
			}
			this.binder.ResetBindings(false);
			this.dataGridScriptOpEditor.Refresh();
			this.copyIndexStart = this.copyIndexEnd = -1;
		}

		private void peekToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int rowToRead = dataGridScriptOpEditor.Rows.GetFirstRow(DataGridViewElementStates.Selected);
			var currentSub = internalFile.Subroutines[curSubRoutineIndex];
			var currentOp = currentSub.Operations[rowToRead];

			if (currentOp.OpCodeType != OpCodeOperandTypes.FunctionName)
			{
				return;
			}

			int selectedIndex = subroutineListBox.Items.IndexOf(currentOp.OperandText);
			if (selectedIndex == -1)
			{
				return;
			}

			int peekSubIndex = ScriptRoutineLookup.ElementAt(selectedIndex).Value;

			ScriptPeek peekForm = new ScriptPeek(internalFile.Subroutines[peekSubIndex]);
			peekForm.Show();
		}

		private void goToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int rowToRead = dataGridScriptOpEditor.Rows.GetFirstRow(DataGridViewElementStates.Selected);
			var currentSub = internalFile.Subroutines[curSubRoutineIndex];
			var currentOp = currentSub.Operations[rowToRead];

			switch (currentOp.OpCodeType)
			{
				case OpCodeOperandTypes.BranchTarget:
					{
						int selectedIndex = currentSub.Operations.FindIndex(op => op.Label == currentOp.OperandText);
						if (selectedIndex == -1)
						{
							MessageBox.Show("Could not find label: " + currentOp.OperandText);
							return;
						}

						dataGridScriptOpEditor.ClearSelection();
						dataGridScriptOpEditor.CurrentCell = dataGridScriptOpEditor.Rows[selectedIndex].Cells[0];
					}
					break;

				case OpCodeOperandTypes.FunctionName:
					{
						int selectedIndex = subroutineListBox.Items.IndexOf(currentOp.OperandText);
						if (selectedIndex == -1)
						{
							MessageBox.Show("Could not find function: " + currentOp.OperandText);
							return;
						}

						subroutineListBox.SelectedIndex = selectedIndex;
					}
					break;

				case OpCodeOperandTypes.NumericVariableName:
				case OpCodeOperandTypes.StringVariableName:
					{
						foreach (DataGridViewRow row in dataGridScriptVariables.Rows)
						{
							if (row.Cells[1].Value.ToString().Equals(currentOp.OperandText))
							{
								row.Selected = true;
								dataGridScriptVariables.FirstDisplayedScrollingRowIndex = row.Index;
								break;
							}
						}
					}
					break;

			}
		}

		private void dataGridScriptOpEditor_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			var currentSub = internalFile.Subroutines[curSubRoutineIndex];
			var currentOp = currentSub.Operations[e.RowIndex];

			if (e.ColumnIndex == 0 && currentOp.Label.Contains("label_"))
			{
				highlightLabel = currentOp.Label;
			}
			else if( e.ColumnIndex == 2 && currentOp.OperandText.Contains("label_"))
			{
				highlightLabel = currentOp.OperandText;
			}

			buildLabelHighlights();

			highlightLabel = "";
		}
	}
}
