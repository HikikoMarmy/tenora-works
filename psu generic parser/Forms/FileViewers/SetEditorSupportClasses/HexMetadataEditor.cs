using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using PSULib.FileClasses.Missions;
using PSULib.FileClasses.Missions.Sets;

namespace psu_generic_parser.Forms.FileViewers.SetEditorSupportClasses
{
	public partial class HexMetadataEditor : UserControl
	{
		private SetFile.ObjectEntry objectEntry;
		MemoryStream metadataStream;

		public HexMetadataEditor(SetFile.ObjectEntry obj = null)
		{
			InitializeComponent();

			metadataHexEditor.StringDataVisibility = Visibility.Hidden;
			metadataHexEditor.BytesModified += metadataHexEditor_BytesModified;
			metadataHexEditor.SelectionStartChanged += metadataHexEditor_SelectionStart;

			metadataStream = new MemoryStream(100);

			InitializeInspector();

			if (null != obj)
			{
				objectEntry = obj;
				ReloadData();
				UpdateInspector();
			}
		}

		private void InitializeInspector()
		{
			InspectorView.CellEndEdit += InspectorView_CellEndEdit;
			InspectorView.Rows.Add("Signed Byte", 0);
			InspectorView.Rows.Add("Unsigned Byte", 0);
			InspectorView.Rows.Add("Signed Short", 0);
			InspectorView.Rows.Add("Unsigned Short", 0);
			InspectorView.Rows.Add("Signed Int", 0);
			InspectorView.Rows.Add("Unsigned Int", 0);
			InspectorView.Rows.Add("Float", 0);
		}

		private void UpdateInspector()
		{
			var SelectedPosition = metadataHexEditor.SelectionStart;

			if (SelectedPosition < 0 || SelectedPosition >= metadataStream.Length)
			{
				return;
			}

			InspectorView.Rows[0].Cells[1].Value = Convert.ToSByte((sbyte)objectEntry.metadata[SelectedPosition]);
			InspectorView.Rows[1].Cells[1].Value = Convert.ToByte((byte)objectEntry.metadata[SelectedPosition]);

			if (SelectedPosition + 1 < metadataStream.Length)
			{
				byte[] temp_buffer = new byte[2];
				Array.Copy(objectEntry.metadata, SelectedPosition, temp_buffer, 0, 2);
				InspectorView.Rows[2].Cells[1].Value = BitConverter.ToInt16(temp_buffer, 0);
				InspectorView.Rows[3].Cells[1].Value = BitConverter.ToUInt16(temp_buffer, 0);
			}
			else
			{
				InspectorView.Rows[2].Cells[1].Value = "NA";
				InspectorView.Rows[3].Cells[1].Value = "NA";
			}

			if (SelectedPosition + 3 < metadataStream.Length)
			{
				byte[] temp_buffer = new byte[4];
				Array.Copy(objectEntry.metadata, SelectedPosition, temp_buffer, 0, 4);
				InspectorView.Rows[4].Cells[1].Value = BitConverter.ToInt32(temp_buffer, 0);
				InspectorView.Rows[5].Cells[1].Value = BitConverter.ToUInt32(temp_buffer, 0);
				InspectorView.Rows[6].Cells[1].Value = BitConverter.ToSingle(temp_buffer, 0);
			}
			else
			{
				InspectorView.Rows[4].Cells[1].Value = "NA";
				InspectorView.Rows[5].Cells[1].Value = "NA";
				InspectorView.Rows[6].Cells[1].Value = "NA";
			}
		}

		private void InspectorView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex != 1) return;

			byte[] buffer = metadataHexEditor.GetAllBytes();
			var SelectedPosition = metadataHexEditor.SelectionStart;
			var value = InspectorView.Rows[e.RowIndex].Cells[1].Value.ToString();

			try
			{
				switch (e.RowIndex)
				{
					case 0: buffer[SelectedPosition] = (byte)SByte.Parse(value); break;
					case 1: buffer[SelectedPosition] = Byte.Parse(value); break;

					case 2: Array.Copy( BitConverter.GetBytes( Int16.Parse(value)), 0, buffer, SelectedPosition, 2); break;
					case 3: Array.Copy( BitConverter.GetBytes( UInt16.Parse(value)), 0, buffer, SelectedPosition, 2); break;

					case 4: Array.Copy( BitConverter.GetBytes( Int32.Parse(value)), 0, buffer, SelectedPosition, 4); break;
					case 5: Array.Copy( BitConverter.GetBytes( UInt32.Parse(value)), 0, buffer, SelectedPosition, 4); break;

					case 6: Array.Copy( BitConverter.GetBytes( Single.Parse(value)), 0, buffer, SelectedPosition, 4); break;
				}
			}
			catch (Exception ex)
			{
				System.Windows.MessageBox.Show(ex.ToString(), "Error");
			}

			metadataStream.SetLength(buffer.Length);
			metadataStream.Seek(0, SeekOrigin.Begin);
			metadataStream.Write(buffer, 0, buffer.Length);

			metadataHexEditor.Stream = metadataStream;
			metadataHexEditor.ClearAllChange();
			metadataHexEditor.RefreshView();

			objectEntry.metadata = metadataHexEditor.GetAllBytes();

			UpdateInspector();
		}

		public void SetObjectEntry(SetFile.ObjectEntry obj)
		{
			objectEntry = obj;
			ReloadData();

			UserControl Ctl;
			switch (obj.objectType)
			{
				case 12: Ctl = new TObjBreakEditor(obj); break;
				case 14: Ctl = new TObjUnitTransporter(obj); break;
				case 22: Ctl = new TObjSwitchTerminal(obj); break;
				case 31: Ctl = new TObjKey(obj); break;
				default:
					{
						return;
					}
					break;
			}

			Ctl.Dock = DockStyle.Fill;
			tabControl.TabPages[ 0 ].Controls.Clear();
			tabControl.TabPages[ 0 ].Controls.Add(Ctl);
		}

		public void ReloadData()
		{
			if (objectEntry == null)
			{
				return;
			}

			if (SetObjectDefinitions.definitions.ContainsKey(objectEntry.objectType))
			{
				SetObjectDefinition def = SetObjectDefinitions.definitions[objectEntry.objectType];
				metadataLengthLabel.Text = "AotI: " + def.metadataLengthAotI + " / " + "PSP2: " + def.metadataLengthPsp2;
			}
			else
			{
				metadataLengthLabel.Text = "INVALID OBJECT";
			}

			metadataLengthUD.Value = objectEntry.metadata.Length;
			metadataStream.SetLength(objectEntry.metadata.Length);
			metadataStream.Seek(0, SeekOrigin.Begin);
			metadataStream.Write(objectEntry.metadata, 0, objectEntry.metadata.Length);
			//For some reason, setting the stream from the constructor marks the stream unwritable, so it has to be set here.
			//If it's already been set, this won't do anything.
			metadataHexEditor.Stream = metadataStream;
			metadataHexEditor.ClearAllChange();
			metadataHexEditor.RefreshView();
		}

		private void metadataHexEditor_SelectionStart(object sender, System.EventArgs e)
		{
			UpdateInspector();
		}

		private void metadataHexEditor_BytesModified(object sender, System.EventArgs e)
		{
			objectEntry.metadata = metadataHexEditor.GetAllBytes();

			UpdateInspector();
		}

		private void metadataLengthUD_ValueChanged(object sender, System.EventArgs e)
		{
			updateLength();
		}

		private void updateLength()
		{
			lock (metadataHexEditor)
			{
				if (metadataLengthUD.Value != objectEntry.metadata.Length)
				{
					Array.Resize(ref objectEntry.metadata, Convert.ToInt32(metadataLengthUD.Value));
					metadataStream.SetLength(objectEntry.metadata.Length);
					metadataHexEditor.RefreshView();
				}
			}
		}
	}
}
