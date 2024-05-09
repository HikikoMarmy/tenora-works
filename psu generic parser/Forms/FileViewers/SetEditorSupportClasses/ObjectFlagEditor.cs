using PSULib.FileClasses.Missions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace psu_generic_parser.Forms.FileViewers.SetEditorSupportClasses
{
	public partial class ObjectFlagEditor : UserControl
	{
		private readonly List<string> FlagSetType = new List<string>
		{
			"Set",
			"Unset",
			"Toggle"
		};

		struct FlagEntry
		{
			public byte flag;
			public byte type;
		}

		private SetFile.ObjectEntry ParentObject = null;
		private int FlagOffset = 0;
		private int NumberOfFlag = 0;
		private List<FlagEntry> FlagSet = new List<FlagEntry>();

		public ObjectFlagEditor(ref SetFile.ObjectEntry setObject, int flagOffset, int flagCount, string name = "Flag" )
		{
			InitializeComponent();

			Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

			//nameLabel.Text = name;
			ParentObject = setObject;
			FlagOffset = flagOffset;
			NumberOfFlag = flagCount;

			for (int i = 0; i < NumberOfFlag; i++)
			{
				FlagEntry entry;
				entry.flag = setObject.metadata[flagOffset + (i * 2)];
				entry.type = setObject.metadata[flagOffset + (i * 2) + 1];

				FlagSet.Add(entry);

				if( entry.type > 2 ) {
					entry.type = 0;
				}
				dataFlagView.Rows.Add(entry.flag, FlagSetType[entry.type] );
			}
		}

		private void dataEventFlag_EndEdit(object sender, DataGridViewCellEventArgs e)
		{
			int columnIndex = dataFlagView.CurrentCell.ColumnIndex;
			int rowIndex = dataFlagView.CurrentCell.RowIndex;

			if ( rowIndex < 0 || rowIndex >= NumberOfFlag )
			{
				return;
			}

			byte value;
			byte[] buffer = ParentObject.metadata;
			
			if ( columnIndex > 0 )
			{
				// Flag Type
				switch(dataFlagView.CurrentCell.Value)
				{
					case "Set":		value = 0; break;
					case "Unset":	value = 1; break;
					case "Toggle":	value = 2; break;
					default:		value = 0; break;
				}
			}
			else
			{
				// Flag ID
				value = Byte.Parse(dataFlagView.CurrentCell.Value.ToString() );
			}

			buffer[FlagOffset + (rowIndex * 2) + (columnIndex)] = value;
			ParentObject.metadata = buffer;
		}

		public byte GetCurrentFlagValue()
		{
			return 1;
		}
	}
}
