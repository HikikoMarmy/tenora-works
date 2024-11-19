
namespace psu_generic_parser.Forms.FileViewers
{
    partial class ObjParamViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.objectListBox = new System.Windows.Forms.ListBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.dataGridView3 = new System.Windows.Forms.DataGridView();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.group4Sub1Datagrid = new System.Windows.Forms.DataGridView();
			this.group4Sub2Datagrid = new System.Windows.Forms.DataGridView();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.dataGridView5 = new System.Windows.Forms.DataGridView();
			this.btn_obj_add = new System.Windows.Forms.Button();
			this.btn_obj_delete = new System.Windows.Forms.Button();
			this.btn_param_delete = new System.Windows.Forms.Button();
			this.btn_param_add = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
			this.tabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.group4Sub1Datagrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.group4Sub2Datagrid)).BeginInit();
			this.tabPage5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.btn_obj_delete);
			this.splitContainer1.Panel1.Controls.Add(this.btn_obj_add);
			this.splitContainer1.Panel1.Controls.Add(this.objectListBox);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
			this.splitContainer1.Size = new System.Drawing.Size(499, 325);
			this.splitContainer1.SplitterDistance = 166;
			this.splitContainer1.TabIndex = 1;
			// 
			// objectListBox
			// 
			this.objectListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.objectListBox.FormattingEnabled = true;
			this.objectListBox.Location = new System.Drawing.Point(0, 0);
			this.objectListBox.Name = "objectListBox";
			this.objectListBox.Size = new System.Drawing.Size(166, 290);
			this.objectListBox.TabIndex = 0;
			this.objectListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(329, 325);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.btn_param_delete);
			this.tabPage1.Controls.Add(this.btn_param_add);
			this.tabPage1.Controls.Add(this.dataGridView1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(321, 299);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Group 1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(3, 3);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(315, 265);
			this.dataGridView1.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.propertyGrid1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(321, 299);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Hitbox Data";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyGrid1.Location = new System.Drawing.Point(3, 3);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(315, 293);
			this.propertyGrid1.TabIndex = 0;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.dataGridView3);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(321, 299);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Animations";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// dataGridView3
			// 
			this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView3.Location = new System.Drawing.Point(0, 0);
			this.dataGridView3.Name = "dataGridView3";
			this.dataGridView3.Size = new System.Drawing.Size(321, 299);
			this.dataGridView3.TabIndex = 0;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.splitContainer2);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(321, 299);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Particles/Sounds";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.group4Sub1Datagrid);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.group4Sub2Datagrid);
			this.splitContainer2.Size = new System.Drawing.Size(321, 299);
			this.splitContainer2.SplitterDistance = 149;
			this.splitContainer2.TabIndex = 1;
			// 
			// group4Sub1Datagrid
			// 
			this.group4Sub1Datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.group4Sub1Datagrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.group4Sub1Datagrid.Location = new System.Drawing.Point(0, 0);
			this.group4Sub1Datagrid.Name = "group4Sub1Datagrid";
			this.group4Sub1Datagrid.Size = new System.Drawing.Size(321, 149);
			this.group4Sub1Datagrid.TabIndex = 0;
			// 
			// group4Sub2Datagrid
			// 
			this.group4Sub2Datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.group4Sub2Datagrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.group4Sub2Datagrid.Location = new System.Drawing.Point(0, 0);
			this.group4Sub2Datagrid.Name = "group4Sub2Datagrid";
			this.group4Sub2Datagrid.Size = new System.Drawing.Size(321, 146);
			this.group4Sub2Datagrid.TabIndex = 0;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.dataGridView5);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(321, 299);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Models";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// dataGridView5
			// 
			this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView5.Location = new System.Drawing.Point(0, 0);
			this.dataGridView5.Name = "dataGridView5";
			this.dataGridView5.Size = new System.Drawing.Size(321, 299);
			this.dataGridView5.TabIndex = 0;
			// 
			// btn_obj_add
			// 
			this.btn_obj_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btn_obj_add.Location = new System.Drawing.Point(3, 296);
			this.btn_obj_add.Name = "btn_obj_add";
			this.btn_obj_add.Size = new System.Drawing.Size(76, 23);
			this.btn_obj_add.TabIndex = 1;
			this.btn_obj_add.Text = "Add";
			this.btn_obj_add.UseVisualStyleBackColor = true;
			this.btn_obj_add.Click += new System.EventHandler(this.btn_obj_add_Click);
			// 
			// btn_obj_delete
			// 
			this.btn_obj_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btn_obj_delete.Location = new System.Drawing.Point(85, 296);
			this.btn_obj_delete.Name = "btn_obj_delete";
			this.btn_obj_delete.Size = new System.Drawing.Size(76, 23);
			this.btn_obj_delete.TabIndex = 2;
			this.btn_obj_delete.Text = "Delete";
			this.btn_obj_delete.UseVisualStyleBackColor = true;
			this.btn_obj_delete.Click += new System.EventHandler(this.btn_obj_delete_Click);
			// 
			// btn_param_delete
			// 
			this.btn_param_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btn_param_delete.Location = new System.Drawing.Point(240, 273);
			this.btn_param_delete.Name = "btn_param_delete";
			this.btn_param_delete.Size = new System.Drawing.Size(76, 23);
			this.btn_param_delete.TabIndex = 4;
			this.btn_param_delete.Text = "Delete";
			this.btn_param_delete.UseVisualStyleBackColor = true;
			// 
			// btn_param_add
			// 
			this.btn_param_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btn_param_add.Location = new System.Drawing.Point(158, 273);
			this.btn_param_add.Name = "btn_param_add";
			this.btn_param_add.Size = new System.Drawing.Size(76, 23);
			this.btn_param_add.TabIndex = 3;
			this.btn_param_add.Text = "Add";
			this.btn_param_add.UseVisualStyleBackColor = true;
			// 
			// ObjParamViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer1);
			this.Name = "ObjParamViewer";
			this.Size = new System.Drawing.Size(499, 325);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
			this.tabPage4.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.group4Sub1Datagrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.group4Sub2Datagrid)).EndInit();
			this.tabPage5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox objectListBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView group4Sub1Datagrid;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView group4Sub2Datagrid;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
		private System.Windows.Forms.Button btn_obj_add;
		private System.Windows.Forms.Button btn_obj_delete;
		private System.Windows.Forms.Button btn_param_delete;
		private System.Windows.Forms.Button btn_param_add;
	}
}
