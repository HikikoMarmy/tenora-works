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
	public partial class TObjKey : UserControl
	{
		readonly List<string> keyTemplateNames = new List<string>
		{
			"Single Key (01)",
			"Single Key (02)",
			"Single Key (03)",
			"Single Key (04)",
			"Single Key (05)",
			"Double Key (01)",
			"Double Key (02)",
			"Double Key (03)",
			"Double Key (04)",
			"Quad Key (01)",
			"Quad Key (02)",
			"Quad Key (03)",
			"Quad Key (04)"
		};
		SetFile.ObjectEntry ParentObject = null;

		public TObjKey(SetFile.ObjectEntry obj)
		{
			InitializeComponent();

			ParentObject = obj;

			KeyUIFlagGroup.Controls.Add(new ObjectFlagEditor(ref obj, 0x06, 1, "Key UI Flag"));
			SetFlagGroup.Controls.Add(new ObjectFlagEditor(ref obj, 0x08, 8, "Required Flag"));

			comboKeyTemplate.SelectedText = keyTemplateNames.ElementAt(obj.metadata[0]);
			numKeyIndex.Value = obj.metadata[1];
			checkReqAllFlag.Checked = ( obj.metadata[2] > 0 );
			numKeySet.Value = obj.metadata[3];
		}

		private void comboKeyTemplate_SelectedIndexChanged(object sender, EventArgs e)
		{
			ParentObject.metadata[0] = (byte)comboKeyTemplate.SelectedIndex;
		}

		private void numKeySet_ValueChanged(object sender, EventArgs e)
		{
			ParentObject.metadata[3] = (byte)numKeySet.Value;
		}

		private void numKeyIndex_ValueChanged(object sender, EventArgs e)
		{
			ParentObject.metadata[1] = (byte)numKeyIndex.Value;
		}

		private void checkReqAllFlag_CheckedChanged(object sender, EventArgs e)
		{
			ParentObject.metadata[2] = Convert.ToByte(checkReqAllFlag.Checked);
		}
	}
}
