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
	public partial class TObjBreakEditor : UserControl
	{
		SetFile.ObjectEntry ParentObject = null;

		public TObjBreakEditor(SetFile.ObjectEntry obj)
		{
			InitializeComponent();

			ParentObject = obj;

			ReqFlagGroup.Controls.Add(new ObjectFlagEditor(ref obj, 0x10, 8));
			SetFlagGroup.Controls.Add(new ObjectFlagEditor(ref obj, 0x20, 8));
			DisableFlagGroup.Controls.Add(new ObjectFlagEditor(ref obj, 0x30, 8));

			numModel.Value = obj.metadata[0];
			numModelTier.Value = obj.metadata[1];
			numDropList.Value = obj.metadata[2];
			numDropIdx.Value = obj.metadata[3];
			numHits.Value = (decimal)BitConverter.ToInt32( obj.metadata, 4 );
			numScale.Value = (decimal)BitConverter.ToSingle( obj.metadata, 8 );
		}

		private void numModel_ValueChanged(object sender, EventArgs e)
		{
			ParentObject.metadata[0] = (byte)numModel.Value;
		}

		private void numModelTier_ValueChanged(object sender, EventArgs e)
		{
			ParentObject.metadata[1] = (byte)numModelTier.Value;
		}

		private void numDropList_ValueChanged(object sender, EventArgs e)
		{
			ParentObject.metadata[2] = (byte)numDropList.Value;
		}

		private void numDropIdx_ValueChanged(object sender, EventArgs e)
		{
			ParentObject.metadata[3] = (byte)numDropIdx.Value;
		}

		private void numHits_ValueChanged(object sender, EventArgs e)
		{
			byte[] b = BitConverter.GetBytes((int)numHits.Value);
			Array.Copy(b, 0, ParentObject.metadata, 4, 4);
		}

		private void numScale_ValueChanged(object sender, EventArgs e)
		{
			byte[] b = BitConverter.GetBytes( Single.Parse( numScale.Value.ToString() ) );
			Array.Copy(b, 0, ParentObject.metadata, 8, 4);
		}

		
	}
}
