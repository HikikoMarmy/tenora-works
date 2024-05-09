namespace psu_generic_parser.Forms.FileViewers.SetEditorSupportClasses
{
    partial class HexMetadataEditor
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
			this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
			this.metadataHexEditor = new WpfHexaEditor.HexEditor();
			this.metadataLengthUD = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.metadataLengthLabel = new System.Windows.Forms.Label();
			this.InspectorView = new System.Windows.Forms.DataGridView();
			this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPageEditor = new System.Windows.Forms.TabPage();
			this.tabPageInspector = new System.Windows.Forms.TabPage();
			((System.ComponentModel.ISupportInitialize)(this.metadataLengthUD)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.InspectorView)).BeginInit();
			this.tabControl.SuspendLayout();
			this.tabPageInspector.SuspendLayout();
			this.SuspendLayout();
			// 
			// elementHost1
			// 
			this.elementHost1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.elementHost1.Location = new System.Drawing.Point(0, 0);
			this.elementHost1.Name = "elementHost1";
			this.elementHost1.Size = new System.Drawing.Size(630, 334);
			this.elementHost1.TabIndex = 32;
			this.elementHost1.Text = "elementHost1";
			this.elementHost1.Child = this.metadataHexEditor;
			// 
			// metadataLengthUD
			// 
			this.metadataLengthUD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.metadataLengthUD.Location = new System.Drawing.Point(779, 257);
			this.metadataLengthUD.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
			this.metadataLengthUD.Name = "metadataLengthUD";
			this.metadataLengthUD.Size = new System.Drawing.Size(91, 20);
			this.metadataLengthUD.TabIndex = 35;
			this.metadataLengthUD.ValueChanged += new System.EventHandler(this.metadataLengthUD_ValueChanged);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(633, 259);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(131, 13);
			this.label1.TabIndex = 33;
			this.label1.Text = "Current Metadata Length: ";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(634, 283);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(139, 13);
			this.label2.TabIndex = 34;
			this.label2.Text = "Expected Metadata Length:";
			// 
			// metadataLengthLabel
			// 
			this.metadataLengthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.metadataLengthLabel.AutoSize = true;
			this.metadataLengthLabel.Location = new System.Drawing.Point(776, 283);
			this.metadataLengthLabel.Name = "metadataLengthLabel";
			this.metadataLengthLabel.Size = new System.Drawing.Size(35, 13);
			this.metadataLengthLabel.TabIndex = 36;
			this.metadataLengthLabel.Text = "label3";
			// 
			// InspectorView
			// 
			this.InspectorView.AllowUserToAddRows = false;
			this.InspectorView.AllowUserToDeleteRows = false;
			this.InspectorView.AllowUserToResizeColumns = false;
			this.InspectorView.AllowUserToResizeRows = false;
			this.InspectorView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.InspectorView.BackgroundColor = System.Drawing.SystemColors.ControlDark;
			this.InspectorView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.InspectorView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.Value});
			this.InspectorView.Location = new System.Drawing.Point(636, 6);
			this.InspectorView.MultiSelect = false;
			this.InspectorView.Name = "InspectorView";
			this.InspectorView.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.InspectorView.RowHeadersVisible = false;
			this.InspectorView.Size = new System.Drawing.Size(240, 250);
			this.InspectorView.TabIndex = 37;
			// 
			// Type
			// 
			this.Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Type.Frozen = true;
			this.Type.HeaderText = "Type";
			this.Type.Name = "Type";
			this.Type.ReadOnly = true;
			this.Type.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// Value
			// 
			this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			this.Value.Frozen = true;
			this.Value.HeaderText = "Value";
			this.Value.Name = "Value";
			this.Value.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.Value.Width = 150;
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabPageEditor);
			this.tabControl.Controls.Add(this.tabPageInspector);
			this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl.Location = new System.Drawing.Point(0, 0);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(890, 360);
			this.tabControl.TabIndex = 38;
			// 
			// tabPageEditor
			// 
			this.tabPageEditor.Location = new System.Drawing.Point(4, 22);
			this.tabPageEditor.Name = "tabPageEditor";
			this.tabPageEditor.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageEditor.Size = new System.Drawing.Size(882, 484);
			this.tabPageEditor.TabIndex = 0;
			this.tabPageEditor.Text = "Object Editor";
			this.tabPageEditor.UseVisualStyleBackColor = true;
			// 
			// tabPageInspector
			// 
			this.tabPageInspector.BackColor = System.Drawing.Color.Transparent;
			this.tabPageInspector.Controls.Add(this.label2);
			this.tabPageInspector.Controls.Add(this.InspectorView);
			this.tabPageInspector.Controls.Add(this.elementHost1);
			this.tabPageInspector.Controls.Add(this.metadataLengthLabel);
			this.tabPageInspector.Controls.Add(this.metadataLengthUD);
			this.tabPageInspector.Controls.Add(this.label1);
			this.tabPageInspector.Location = new System.Drawing.Point(4, 22);
			this.tabPageInspector.Name = "tabPageInspector";
			this.tabPageInspector.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageInspector.Size = new System.Drawing.Size(882, 334);
			this.tabPageInspector.TabIndex = 1;
			this.tabPageInspector.Text = "🔍 Hex Inspector";
			// 
			// HexMetadataEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.Controls.Add(this.tabControl);
			this.Name = "HexMetadataEditor";
			this.Size = new System.Drawing.Size(890, 360);
			((System.ComponentModel.ISupportInitialize)(this.metadataLengthUD)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.InspectorView)).EndInit();
			this.tabControl.ResumeLayout(false);
			this.tabPageInspector.ResumeLayout(false);
			this.tabPageInspector.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private WpfHexaEditor.HexEditor metadataHexEditor;
        private System.Windows.Forms.NumericUpDown metadataLengthUD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label metadataLengthLabel;
		private System.Windows.Forms.DataGridView InspectorView;
		private System.Windows.Forms.DataGridViewTextBoxColumn Type;
		private System.Windows.Forms.DataGridViewTextBoxColumn Value;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageEditor;
		private System.Windows.Forms.TabPage tabPageInspector;
	}
}
