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
	public partial class TObjSwitchTerminal : UserControl
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

		public TObjSwitchTerminal(SetFile.ObjectEntry obj)
		{
			InitializeComponent();

			ParentObject = obj;

			KeyUIFlagGroup.Controls.Add(new ObjectFlagEditor(ref obj, 0x0C, 8, "Key UI Flag"));
			SetFlagGroup.Controls.Add(new ObjectFlagEditor(ref obj, 0x1C, 8, "Set Flag"));

			numModel.Value = obj.metadata[0];
			numModelTier.Value = obj.metadata[1];
			comboKeyTemplate.SelectedIndex = obj.metadata[2];

			numKeySet.Value = BitConverter.ToInt16(obj.metadata, 6);
			numActivationRange.Value = (decimal)BitConverter.ToSingle(obj.metadata, 8);
		}

		void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
		{

		}

		private void numModel_ValueChanged(object sender, EventArgs e)
		{
			ParentObject.metadata[0] = (byte)numModel.Value;
		}

		private void numModelTier_ValueChanged(object sender, EventArgs e)
		{
			ParentObject.metadata[1] = (byte)numModelTier.Value;
		}

		private void comboKeyTemplate_SelectedIndexChanged(object sender, EventArgs e)
		{
			ParentObject.metadata[2] = (byte)comboKeyTemplate.SelectedIndex;
		}

		private void numKeySet_ValueChanged(object sender, EventArgs e)
		{
			byte[] b = BitConverter.GetBytes((short)numKeySet.Value);
			Array.Copy(b, 0, ParentObject.metadata, 6, 2);
		}

		private void numActivationRange_ValueChanged(object sender, EventArgs e)
		{
			byte[] b = BitConverter.GetBytes(Single.Parse(numActivationRange.Value.ToString()));
			Array.Copy(b, 0, ParentObject.metadata, 8, 4);
		}
	}
}
