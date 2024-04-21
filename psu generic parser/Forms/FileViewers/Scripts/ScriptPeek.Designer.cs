namespace psu_generic_parser.Forms.FileViewers.Scripts
{
	partial class ScriptPeek
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.LabelColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.OpcodeColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.ArgColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView2
			// 
			this.dataGridView2.AllowUserToAddRows = false;
			this.dataGridView2.AllowUserToDeleteRows = false;
			this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.WindowFrame;
			this.dataGridView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LabelColumn,
            this.OpcodeColumn,
            this.ArgColumn});
			this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView2.Location = new System.Drawing.Point(0, 0);
			this.dataGridView2.MinimumSize = new System.Drawing.Size(500, 0);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.ReadOnly = true;
			this.dataGridView2.Size = new System.Drawing.Size(546, 657);
			this.dataGridView2.TabIndex = 12;
			// 
			// LabelColumn
			// 
			this.LabelColumn.HeaderText = "Label";
			this.LabelColumn.Name = "LabelColumn";
			this.LabelColumn.ReadOnly = true;
			this.LabelColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// OpcodeColumn
			// 
			this.OpcodeColumn.FillWeight = 180F;
			this.OpcodeColumn.HeaderText = "Opcode";
			this.OpcodeColumn.Name = "OpcodeColumn";
			this.OpcodeColumn.ReadOnly = true;
			this.OpcodeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.OpcodeColumn.Width = 180;
			// 
			// ArgColumn
			// 
			this.ArgColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ArgColumn.FillWeight = 150F;
			this.ArgColumn.HeaderText = "Argument";
			this.ArgColumn.Name = "ArgColumn";
			this.ArgColumn.ReadOnly = true;
			this.ArgColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// ScriptPeek
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(546, 657);
			this.Controls.Add(this.dataGridView2);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "ScriptPeek";
			this.Text = "ScriptPeek";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.DataGridViewTextBoxColumn LabelColumn;
		private System.Windows.Forms.DataGridViewComboBoxColumn OpcodeColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn ArgColumn;
	}
}