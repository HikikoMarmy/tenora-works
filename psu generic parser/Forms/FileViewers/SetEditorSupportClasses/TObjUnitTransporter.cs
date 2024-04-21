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
	public partial class TObjUnitTransporter : UserControl
	{
		SetFile.ObjectEntry ParentObject = null;

		private bool recalculate = false;

		public TObjUnitTransporter(SetFile.ObjectEntry obj)
		{
			ParentObject = obj;
			InitializeComponent();

			numModel.Value = obj.metadata[0];
			checkBoxReqActionKey.Checked = (obj.metadata[1] > 0);

			numActivationRange.Value = (decimal)BitConverter.ToSingle(obj.metadata, 4);

			numPositionOffsetX.Value = (decimal)BitConverter.ToSingle(obj.metadata, 12);
			numPositionOffsetZ.Value = (decimal)BitConverter.ToSingle(obj.metadata, 16);
			numPositionOffsetY.Value = (decimal)BitConverter.ToSingle(obj.metadata, 20);

			numPositionAbsX.Value = (decimal)obj.objX + numPositionOffsetX.Value;
			numPositionAbsZ.Value = (decimal)obj.objZ + numPositionOffsetZ.Value;
			numPositionAbsY.Value = (decimal)obj.objY + numPositionOffsetY.Value;

			numAngleOffset.Value = (decimal)BitConverter.ToSingle(obj.metadata, 24);

			SpawnFlagGroup.Controls.Add(new ObjectFlagEditor(ref obj, 28, 8, "Spawn Flags"));
			DisabeFlagGroup.Controls.Add(new ObjectFlagEditor(ref obj, 44, 8, "Disable Flags"));
			EnableFlagGroup.Controls.Add(new ObjectFlagEditor(ref obj, 60, 8, "Enable Flags"));
			SetFlagGroup.Controls.Add(new ObjectFlagEditor(ref obj, 76, 1, "Set Flags"));
		}

		private void numModel_ValueChanged(object sender, EventArgs e)
		{
			ParentObject.metadata[0] = (byte)numModel.Value;
		}

		private void checkBoxReqActionKey_CheckedChanged(object sender, EventArgs e)
		{
			ParentObject.metadata[1] = Convert.ToByte(checkBoxReqActionKey.Checked);
		}

		private void numActivationRange_ValueChanged(object sender, EventArgs e)
		{
			byte[] b = BitConverter.GetBytes(Single.Parse(numActivationRange.Value.ToString()));
			Array.Copy(b, 0, ParentObject.metadata, 4, 4);
		}

		private void numPositionOffsetX_ValueChanged(object sender, EventArgs e)
		{
			if (recalculate)
			{
				return;
			}

			recalculate = true;
			numPositionAbsX.Value = (decimal)ParentObject.objX + numPositionOffsetX.Value;
			recalculate = false;
		}

		private void numPositionAbsX_ValueChanged(object sender, EventArgs e)
		{
			if (recalculate)
			{
				return;
			}

			recalculate = true;
			numPositionOffsetX.Value = numPositionAbsX.Value - (decimal)ParentObject.objX;
			recalculate = false;
		}

		private void numPositionOffsetZ_ValueChanged(object sender, EventArgs e)
		{
			if (recalculate)
			{
				return;
			}

			recalculate = true;
			numPositionAbsZ.Value = (decimal)ParentObject.objZ + numPositionOffsetZ.Value;
			recalculate = false;
		}

		private void numPositionAbsZ_ValueChanged(object sender, EventArgs e)
		{
			if (recalculate)
			{
				return;
			}

			recalculate = true;
			numPositionOffsetZ.Value = numPositionAbsZ.Value - (decimal)ParentObject.objZ;
			recalculate = false;
		}

		private void numPositionOffsetY_ValueChanged(object sender, EventArgs e)
		{
			if (recalculate)
			{
				return;
			}

			recalculate = true;
			numPositionAbsY.Value = (decimal)ParentObject.objY + numPositionOffsetY.Value;
			recalculate = false;
		}

		private void numPositionAbsY_ValueChanged(object sender, EventArgs e)
		{
			if (recalculate)
			{
				return;
			}

			recalculate = true;
			numPositionOffsetY.Value = numPositionAbsY.Value - (decimal)ParentObject.objY;
			recalculate = false;
		}

		private void numAngleOffset_ValueChanged(object sender, EventArgs e)
		{
			if (recalculate)
			{
				return;
			}

			var value = numAngleOffset.Value;

			//if (value < -180)
			//	value += 360;
			//else if (value > 180)
			//	value -= 360;

			recalculate = true;
			numAngleOffset.Value = value;
			numAngleAbs.Value = (decimal)ParentObject.objRotY + value;
			recalculate = false;
		}

		private void numAngleAbs_ValueChanged(object sender, EventArgs e)
		{
			if (recalculate)
			{
				return;
			}

			var value = numAngleAbs.Value - (decimal)ParentObject.objRotY;

			//if (value <= -180)
			//	value += 360;
			//else if (value > 180)
			//	value -= 360;

			recalculate = true;
			numAngleOffset.Value = value;
			recalculate = false;
		}
	}
}
