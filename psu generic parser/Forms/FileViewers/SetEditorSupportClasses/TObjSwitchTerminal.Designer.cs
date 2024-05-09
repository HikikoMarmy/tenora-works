namespace psu_generic_parser.Forms.FileViewers.SetEditorSupportClasses
{
	partial class TObjSwitchTerminal
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
			this.comboKeyTemplate = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.numModel = new System.Windows.Forms.NumericUpDown();
			this.numModelTier = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.numKeySet = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.numActivationRange = new System.Windows.Forms.NumericUpDown();
			this.SetFlagGroup = new System.Windows.Forms.GroupBox();
			this.KeyUIFlagGroup = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.numModel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numModelTier)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numKeySet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numActivationRange)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboKeyTemplate
			// 
			this.comboKeyTemplate.FormattingEnabled = true;
			this.comboKeyTemplate.Items.AddRange(new object[] {
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
            "Quad Key (04)"});
			this.comboKeyTemplate.Location = new System.Drawing.Point(71, 58);
			this.comboKeyTemplate.Name = "comboKeyTemplate";
			this.comboKeyTemplate.Size = new System.Drawing.Size(112, 21);
			this.comboKeyTemplate.TabIndex = 0;
			this.comboKeyTemplate.SelectedIndexChanged += new System.EventHandler(this.comboKeyTemplate_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(50, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Model ID";
			// 
			// numModel
			// 
			this.numModel.Location = new System.Drawing.Point(71, 14);
			this.numModel.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numModel.Name = "numModel";
			this.numModel.Size = new System.Drawing.Size(53, 20);
			this.numModel.TabIndex = 13;
			this.numModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numModel.ValueChanged += new System.EventHandler(this.numModel_ValueChanged);
			// 
			// numModelTier
			// 
			this.numModelTier.Location = new System.Drawing.Point(130, 14);
			this.numModelTier.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numModelTier.Name = "numModelTier";
			this.numModelTier.Size = new System.Drawing.Size(53, 20);
			this.numModelTier.TabIndex = 16;
			this.numModelTier.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numModelTier.ValueChanged += new System.EventHandler(this.numModelTier_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 61);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 13);
			this.label1.TabIndex = 17;
			this.label1.Text = "Template";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 85);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 13);
			this.label2.TabIndex = 18;
			this.label2.Text = "Key Set";
			// 
			// numKeySet
			// 
			this.numKeySet.Location = new System.Drawing.Point(71, 83);
			this.numKeySet.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numKeySet.Name = "numKeySet";
			this.numKeySet.Size = new System.Drawing.Size(53, 20);
			this.numKeySet.TabIndex = 19;
			this.numKeySet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numKeySet.ValueChanged += new System.EventHandler(this.numKeySet_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 109);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(61, 13);
			this.label3.TabIndex = 20;
			this.label3.Text = "Use Range";
			// 
			// numActivationRange
			// 
			this.numActivationRange.DecimalPlaces = 2;
			this.numActivationRange.Location = new System.Drawing.Point(71, 107);
			this.numActivationRange.Name = "numActivationRange";
			this.numActivationRange.Size = new System.Drawing.Size(112, 20);
			this.numActivationRange.TabIndex = 21;
			this.numActivationRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numActivationRange.ValueChanged += new System.EventHandler(this.numActivationRange_ValueChanged);
			// 
			// SetFlagGroup
			// 
			this.SetFlagGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SetFlagGroup.Location = new System.Drawing.Point(512, 8);
			this.SetFlagGroup.Name = "SetFlagGroup";
			this.SetFlagGroup.Size = new System.Drawing.Size(110, 331);
			this.SetFlagGroup.TabIndex = 22;
			this.SetFlagGroup.TabStop = false;
			this.SetFlagGroup.Text = "Set Flag";
			// 
			// KeyUIFlagGroup
			// 
			this.KeyUIFlagGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.KeyUIFlagGroup.Location = new System.Drawing.Point(396, 8);
			this.KeyUIFlagGroup.Name = "KeyUIFlagGroup";
			this.KeyUIFlagGroup.Size = new System.Drawing.Size(110, 331);
			this.KeyUIFlagGroup.TabIndex = 23;
			this.KeyUIFlagGroup.TabStop = false;
			this.KeyUIFlagGroup.Text = "Key UI Flag";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.KeyUIFlagGroup);
			this.groupBox1.Controls.Add(this.comboKeyTemplate);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.SetFlagGroup);
			this.groupBox1.Controls.Add(this.numKeySet);
			this.groupBox1.Controls.Add(this.numModel);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.numActivationRange);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.numModelTier);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(626, 345);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Switch Terminal Editor";
			// 
			// TObjSwitchTerminal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.Name = "TObjSwitchTerminal";
			this.Size = new System.Drawing.Size(626, 345);
			((System.ComponentModel.ISupportInitialize)(this.numModel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numModelTier)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numKeySet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numActivationRange)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox comboKeyTemplate;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown numModel;
		private System.Windows.Forms.NumericUpDown numModelTier;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numKeySet;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown numActivationRange;
		private System.Windows.Forms.GroupBox SetFlagGroup;
		private System.Windows.Forms.GroupBox KeyUIFlagGroup;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
