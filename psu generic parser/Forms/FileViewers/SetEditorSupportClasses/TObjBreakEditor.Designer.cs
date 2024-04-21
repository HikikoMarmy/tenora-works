namespace psu_generic_parser.Forms.FileViewers.SetEditorSupportClasses
{
	partial class TObjBreakEditor
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
			this.numModelTier = new System.Windows.Forms.NumericUpDown();
			this.DisableFlagGroup = new System.Windows.Forms.GroupBox();
			this.ReqFlagGroup = new System.Windows.Forms.GroupBox();
			this.SetFlagGroup = new System.Windows.Forms.GroupBox();
			this.numModel = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.numScale = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.numHits = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.numDropIdx = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.numDropList = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numModelTier)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numModel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numScale)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numHits)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numDropIdx)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numDropList)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.numModelTier);
			this.groupBox1.Controls.Add(this.DisableFlagGroup);
			this.groupBox1.Controls.Add(this.ReqFlagGroup);
			this.groupBox1.Controls.Add(this.SetFlagGroup);
			this.groupBox1.Controls.Add(this.numModel);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.numScale);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.numHits);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.numDropIdx);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.numDropList);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(806, 355);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Break Object Editor";
			// 
			// numModelTier
			// 
			this.numModelTier.Location = new System.Drawing.Point(141, 31);
			this.numModelTier.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numModelTier.Name = "numModelTier";
			this.numModelTier.Size = new System.Drawing.Size(53, 20);
			this.numModelTier.TabIndex = 15;
			this.numModelTier.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numModelTier.ValueChanged += new System.EventHandler(this.numModelTier_ValueChanged);
			// 
			// DisableFlagGroup
			// 
			this.DisableFlagGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DisableFlagGroup.Location = new System.Drawing.Point(636, 19);
			this.DisableFlagGroup.Name = "DisableFlagGroup";
			this.DisableFlagGroup.Size = new System.Drawing.Size(159, 330);
			this.DisableFlagGroup.TabIndex = 14;
			this.DisableFlagGroup.TabStop = false;
			this.DisableFlagGroup.Text = "Disable Flag";
			// 
			// ReqFlagGroup
			// 
			this.ReqFlagGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ReqFlagGroup.Location = new System.Drawing.Point(306, 19);
			this.ReqFlagGroup.Name = "ReqFlagGroup";
			this.ReqFlagGroup.Size = new System.Drawing.Size(159, 330);
			this.ReqFlagGroup.TabIndex = 14;
			this.ReqFlagGroup.TabStop = false;
			this.ReqFlagGroup.Text = "Req Flag";
			// 
			// SetFlagGroup
			// 
			this.SetFlagGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SetFlagGroup.Location = new System.Drawing.Point(471, 19);
			this.SetFlagGroup.Name = "SetFlagGroup";
			this.SetFlagGroup.Size = new System.Drawing.Size(159, 330);
			this.SetFlagGroup.TabIndex = 13;
			this.SetFlagGroup.TabStop = false;
			this.SetFlagGroup.Text = "Set Flag";
			// 
			// numModel
			// 
			this.numModel.Location = new System.Drawing.Point(82, 31);
			this.numModel.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numModel.Name = "numModel";
			this.numModel.Size = new System.Drawing.Size(53, 20);
			this.numModel.TabIndex = 11;
			this.numModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numModel.ValueChanged += new System.EventHandler(this.numModel_ValueChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(17, 33);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(50, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Model ID";
			// 
			// numScale
			// 
			this.numScale.DecimalPlaces = 2;
			this.numScale.Location = new System.Drawing.Point(83, 150);
			this.numScale.Name = "numScale";
			this.numScale.Size = new System.Drawing.Size(53, 20);
			this.numScale.TabIndex = 9;
			this.numScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numScale.ValueChanged += new System.EventHandler(this.numScale_ValueChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(18, 152);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(34, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Scale";
			// 
			// numHits
			// 
			this.numHits.Location = new System.Drawing.Point(83, 127);
			this.numHits.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numHits.Name = "numHits";
			this.numHits.Size = new System.Drawing.Size(53, 20);
			this.numHits.TabIndex = 7;
			this.numHits.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numHits.ValueChanged += new System.EventHandler(this.numHits_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(18, 129);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(22, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "HP";
			// 
			// numDropIdx
			// 
			this.numDropIdx.Location = new System.Drawing.Point(83, 90);
			this.numDropIdx.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numDropIdx.Name = "numDropIdx";
			this.numDropIdx.Size = new System.Drawing.Size(53, 20);
			this.numDropIdx.TabIndex = 5;
			this.numDropIdx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numDropIdx.ValueChanged += new System.EventHandler(this.numDropIdx_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 92);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Drop Index";
			// 
			// numDropList
			// 
			this.numDropList.Location = new System.Drawing.Point(83, 65);
			this.numDropList.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.numDropList.Name = "numDropList";
			this.numDropList.Size = new System.Drawing.Size(53, 20);
			this.numDropList.TabIndex = 3;
			this.numDropList.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numDropList.ValueChanged += new System.EventHandler(this.numDropList_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 67);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Drop List";
			// 
			// TObjBreakEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.Name = "TObjBreakEditor";
			this.Size = new System.Drawing.Size(806, 355);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numModelTier)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numModel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numScale)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numHits)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numDropIdx)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numDropList)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numDropList;
		private System.Windows.Forms.NumericUpDown numDropIdx;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown numModel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown numScale;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numHits;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox SetFlagGroup;
		private System.Windows.Forms.GroupBox DisableFlagGroup;
		private System.Windows.Forms.GroupBox ReqFlagGroup;
		private System.Windows.Forms.NumericUpDown numModelTier;
	}
}
