using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PSULib.FileClasses.Maps;

namespace psu_generic_parser.Forms.FileViewers
{
    public partial class ObjParamViewer : UserControl
    {
        ObjectParamFile internalFile;

        public ObjParamViewer(ObjectParamFile paramFile)
        {
            internalFile = paramFile;
            InitializeComponent();

			AddFromFile( paramFile );
		}

        private void AddFromFile( ObjectParamFile objectParamFile )
		{
			objectListBox.Items.Clear();
			foreach( var key in internalFile.ObjectDefinitions.Keys.OrderBy( x => x ) )
			{
				objectListBox.Items.Add( key );
			}
			objectListBox.SelectedIndex = 0;
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var objDefinition = internalFile.ObjectDefinitions[(int)objectListBox.Items[objectListBox.SelectedIndex]];
            dataGridView1.DataSource = objDefinition.group1Entries;
            propertyGrid1.SelectedObject = objDefinition.group2Entry;
            dataGridView3.DataSource = objDefinition.group3Entries;
            if (objDefinition.group4Entry != null)
            {
                group4Sub1Datagrid.DataSource = objDefinition.group4Entry.particleBindings;
                group4Sub2Datagrid.DataSource = objDefinition.group4Entry.soundBindings;
                group4Sub2Datagrid.Enabled = true;
                group4Sub1Datagrid.Enabled = true;
            }
            else
            {
                group4Sub1Datagrid.DataSource = null;
                group4Sub2Datagrid.DataSource = null;
                group4Sub2Datagrid.Enabled = false;
                group4Sub1Datagrid.Enabled = false;
            }
            dataGridView5.DataSource = objDefinition.group5Entries;
        }

		private void btn_obj_add_Click( object sender, EventArgs e )
		{
            // Make form with one input box for object ID
            Form input = new Form();
			input.Text = "Add Object";
			Label lbl = new Label();
			lbl.Text = "Object ID:";
			lbl.Location = new Point( 10, 20 );
			input.Controls.Add( lbl );
			TextBox txt = new TextBox();
			txt.Location = new Point( 10, 50 );
			input.Controls.Add( txt );
			Button ok = new Button();
			ok.Text = "OK";
			ok.DialogResult = DialogResult.OK;
			ok.Location = new Point( 10, 80 );
			input.Controls.Add( ok );
			Button cancel = new Button();
			cancel.Text = "Cancel";
			cancel.DialogResult = DialogResult.Cancel;
			cancel.Location = new Point( 60, 80 );
			input.Controls.Add( cancel );
			input.AcceptButton = ok;
			input.CancelButton = cancel;
			DialogResult result = input.ShowDialog();

			if( result == DialogResult.OK )
			{
				// Add a new entry
                int newID = int.Parse( txt.Text );

                if( internalFile.ObjectDefinitions.ContainsKey( newID ) )
				{
					MessageBox.Show( "Object ID already exists." );
					return;
				}

				internalFile.ObjectDefinitions.Add( int.Parse( txt.Text ), new ObjectParamFile.ObjectEntry() );
				objectListBox.Items.Add( int.Parse( txt.Text ) );
			}
		}

		private void btn_obj_delete_Click( object sender, EventArgs e )
		{

		}
	}
}
