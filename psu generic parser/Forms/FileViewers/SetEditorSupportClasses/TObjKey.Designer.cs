namespace psu_generic_parser.Forms.FileViewers.SetEditorSupportClasses
{
	partial class TObjKey
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkReqAllFlag = new System.Windows.Forms.CheckBox();
			this.numKeyIndex = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.KeyUIFlagGroup = new System.Windows.Forms.GroupBox();
			this.SetFlagGroup = new System.Windows.Forms.GroupBox();
			this.numKeySet = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.comboKeyTemplate = new System.Windows.Forms.ComboBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numKeyIndex)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numKeySet)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.checkReqAllFlag);
			this.groupBox1.Controls.Add(this.numKeyIndex);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.KeyUIFlagGroup);
			this.groupBox1.Controls.Add(this.SetFlagGroup);
			this.groupBox1.Controls.Add(this.numKeySet);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.comboKeyTemplate);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(649, 356);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Terminal Key Editor";
			// 
			// checkReqAllFlag
			// 
			this.checkReqAllFlag.AutoSize = true;
			this.checkReqAllFlag.Location = new System.Drawing.Point(479, 33);
			this.checkReqAllFlag.Name = "checkReqAllFlag";
			this.checkReqAllFlag.Size = new System.Drawing.Size(100, 17);
			this.checkReqAllFlag.TabIndex = 26;
			this.checkReqAllFlag.Text = "Require All Flag";
			this.checkReqAllFlag.UseVisualStyleBackColor = true;
			this.checkReqAllFlag.CheckedChanged += new System.EventHandler(this.checkReqAllFlag_CheckedChanged);
			// 
			// numKeyIndex
			// 
			this.numKeyIndex.Location = new System.Drawing.Point(82, 93);
			this.numKeyIndex.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numKeyIndex.Name = "numKeyIndex";
			this.numKeyIndex.Size = new System.Drawing.Size(53, 20);
			this.numKeyIndex.TabIndex = 25;
			this.numKeyIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numKeyIndex.ValueChanged += new System.EventHandler(this.numKeyIndex_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(17, 95);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 13);
			this.label3.TabIndex = 24;
			this.label3.Text = "Key Index";
			// 
			// KeyUIFlagGroup
			// 
			this.KeyUIFlagGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.KeyUIFlagGroup.Location = new System.Drawing.Point(314, 55);
			this.KeyUIFlagGroup.Name = "KeyUIFlagGroup";
			this.KeyUIFlagGroup.Size = new System.Drawing.Size(159, 287);
			this.KeyUIFlagGroup.TabIndex = 23;
			this.KeyUIFlagGroup.TabStop = false;
			this.KeyUIFlagGroup.Text = "Key UI Flag";
			// 
			// SetFlagGroup
			// 
			this.SetFlagGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SetFlagGroup.Location = new System.Drawing.Point(479, 55);
			this.SetFlagGroup.Name = "SetFlagGroup";
			this.SetFlagGroup.Size = new System.Drawing.Size(159, 287);
			this.SetFlagGroup.TabIndex = 22;
			this.SetFlagGroup.TabStop = false;
			this.SetFlagGroup.Text = "Set Flag";
			// 
			// numKeySet
			// 
			this.numKeySet.Location = new System.Drawing.Point(82, 55);
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
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 13);
			this.label2.TabIndex = 18;
			this.label2.Text = "Key Set";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(17, 33);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 13);
			this.label1.TabIndex = 17;
			this.label1.Text = "Template";
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
			this.comboKeyTemplate.Location = new System.Drawing.Point(82, 30);
			this.comboKeyTemplate.Name = "comboKeyTemplate";
			this.comboKeyTemplate.Size = new System.Drawing.Size(112, 21);
			this.comboKeyTemplate.TabIndex = 0;
			this.comboKeyTemplate.SelectedIndexChanged += new System.EventHandler(this.comboKeyTemplate_SelectedIndexChanged);
			// 
			// TObjKey
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.Name = "TObjKey";
			this.Size = new System.Drawing.Size(656, 361);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numKeyIndex)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numKeySet)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox KeyUIFlagGroup;
		private System.Windows.Forms.GroupBox SetFlagGroup;
		private System.Windows.Forms.NumericUpDown numKeySet;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboKeyTemplate;
		private System.Windows.Forms.NumericUpDown numKeyIndex;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox checkReqAllFlag;
	}
}
