using PSULib.FileClasses.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PSULib.FileClasses.General.ScriptFile;

namespace psu_generic_parser.Forms.FileViewers.Scripts
{
	public partial class ScriptPeek : Form
	{
		public ScriptPeek(Subroutine sub)
		{
			InitializeComponent();

			this.Text = "Peek: " + sub.SubroutineName;

			List<string> opcodeNames = new List<string>();
			foreach (string opcode in ScriptFile.opcodes)
			{
				if (opcode != "")
				{
					OpcodeColumn.Items.Add(opcode);
				}
			}

			foreach (var i in sub.Operations)
			{
				this.dataGridView2.Rows.Add(i.Label, i.OpCodeName, i.OperandText);
			}
		}
	}
}
