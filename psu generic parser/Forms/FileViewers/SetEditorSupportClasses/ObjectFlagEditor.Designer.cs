namespace psu_generic_parser.Forms.FileViewers.SetEditorSupportClasses
{
	partial class ObjectFlagEditor
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
			this.flagGroupBox = new System.Windows.Forms.GroupBox();
			this.dataFlagView = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.flagGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataFlagView)).BeginInit();
			this.SuspendLayout();
			// 
			// flagGroupBox
			// 
			this.flagGroupBox.Controls.Add(this.dataFlagView);
			this.flagGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flagGroupBox.Location = new System.Drawing.Point(0, 0);
			this.flagGroupBox.Name = "flagGroupBox";
			this.flagGroupBox.Size = new System.Drawing.Size(110, 266);
			this.flagGroupBox.TabIndex = 14;
			this.flagGroupBox.TabStop = false;
			this.flagGroupBox.Text = "Flag";
			// 
			// dataFlagView
			// 
			this.dataFlagView.AllowUserToAddRows = false;
			this.dataFlagView.AllowUserToDeleteRows = false;
			this.dataFlagView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataFlagView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
			this.dataFlagView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataFlagView.Location = new System.Drawing.Point(3, 16);
			this.dataFlagView.MultiSelect = false;
			this.dataFlagView.Name = "dataFlagView";
			this.dataFlagView.RowHeadersVisible = false;
			this.dataFlagView.Size = new System.Drawing.Size(104, 247);
			this.dataFlagView.TabIndex = 1;
			this.dataFlagView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataEventFlag_EndEdit);
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.Frozen = true;
			this.dataGridViewTextBoxColumn1.HeaderText = "Flag ID";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.Width = 50;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.Frozen = true;
			this.dataGridViewTextBoxColumn2.HeaderText = "Type";
			this.dataGridViewTextBoxColumn2.Items.AddRange(new object[] {
            "Set",
            "Unset",
            "Toggle"});
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn2.Width = 50;
			// 
			// ObjectFlagEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.flagGroupBox);
			this.Name = "ObjectFlagEditor";
			this.Size = new System.Drawing.Size(110, 266);
			this.flagGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataFlagView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox flagGroupBox;
		private System.Windows.Forms.DataGridView dataFlagView;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn2;
	}
}
