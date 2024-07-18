using System.Windows.Forms;
using System;

namespace psu_generic_parser
{
    partial class ScriptFileViewer
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.deleteRowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.subroutineListBox = new System.Windows.Forms.ListBox();
			this.subroutineListContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ctxMenuSubNewRoutine = new System.Windows.Forms.ToolStripMenuItem();
			this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.ctxMenuSubFindReference = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.ctxMenuSubDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.operationsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.insertRowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxMenuOpCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxMenuOpPaste = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.goToReferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.goToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.peekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.scriptGroupBox = new System.Windows.Forms.GroupBox();
			this.dataGridScriptOpEditor = new System.Windows.Forms.DataGridView();
			this.LabelColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.OpcodeColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.ArgColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.btn_ExportSubRoutine = new System.Windows.Forms.Button();
			this.btn_ImportSubRoutine = new System.Windows.Forms.Button();
			this.dataGridScriptVariables = new System.Windows.Forms.DataGridView();
			this.subroutineSearchBox = new System.Windows.Forms.TextBox();
			this.variableListBoxContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ctxMenuVarNewInt = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxMenuVarNewString = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ctxMenuVarFindReference = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.ctxMenuVarDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.VariableType = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.VariableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.VariableLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.subroutineListContextMenuStrip.SuspendLayout();
			this.operationsContextMenuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.scriptGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridScriptOpEditor)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
			this.splitContainer3.Panel1.SuspendLayout();
			this.splitContainer3.Panel2.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridScriptVariables)).BeginInit();
			this.variableListBoxContextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// deleteRowMenuItem
			// 
			this.deleteRowMenuItem.Name = "deleteRowMenuItem";
			this.deleteRowMenuItem.Size = new System.Drawing.Size(144, 22);
			this.deleteRowMenuItem.Text = "Delete";
			this.deleteRowMenuItem.Click += new System.EventHandler(this.deleteRowMenuItem_Click);
			// 
			// subroutineListBox
			// 
			this.subroutineListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.subroutineListBox.BackColor = System.Drawing.SystemColors.Window;
			this.subroutineListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.subroutineListBox.ContextMenuStrip = this.subroutineListContextMenuStrip;
			this.subroutineListBox.FormattingEnabled = true;
			this.subroutineListBox.Location = new System.Drawing.Point(6, 32);
			this.subroutineListBox.Name = "subroutineListBox";
			this.subroutineListBox.Size = new System.Drawing.Size(397, 325);
			this.subroutineListBox.TabIndex = 8;
			this.subroutineListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.subroutineListBox_DrawItem);
			this.subroutineListBox.SelectedIndexChanged += new System.EventHandler(this.subroutineListBox_SelectedIndexChanged);
			this.subroutineListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.subroutineListBox_MouseDown);
			// 
			// subroutineListContextMenuStrip
			// 
			this.subroutineListContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMenuSubNewRoutine,
            this.renameToolStripMenuItem,
            this.toolStripSeparator3,
            this.ctxMenuSubFindReference,
            this.toolStripSeparator5,
            this.ctxMenuSubDelete});
			this.subroutineListContextMenuStrip.Name = "subroutineListContextMenuStrip";
			this.subroutineListContextMenuStrip.Size = new System.Drawing.Size(215, 104);
			// 
			// ctxMenuSubNewRoutine
			// 
			this.ctxMenuSubNewRoutine.Name = "ctxMenuSubNewRoutine";
			this.ctxMenuSubNewRoutine.Size = new System.Drawing.Size(214, 22);
			this.ctxMenuSubNewRoutine.Text = "New Routine";
			this.ctxMenuSubNewRoutine.Click += new System.EventHandler(this.ctxMenuSubNewRoutine_Click);
			// 
			// renameToolStripMenuItem
			// 
			this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
			this.renameToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
			this.renameToolStripMenuItem.Text = "Rename";
			this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(211, 6);
			// 
			// ctxMenuSubFindReference
			// 
			this.ctxMenuSubFindReference.Name = "ctxMenuSubFindReference";
			this.ctxMenuSubFindReference.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
			this.ctxMenuSubFindReference.Size = new System.Drawing.Size(214, 22);
			this.ctxMenuSubFindReference.Text = "Find All References";
			this.ctxMenuSubFindReference.Click += new System.EventHandler(this.findReferencesToolStripMenuItem_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(211, 6);
			// 
			// ctxMenuSubDelete
			// 
			this.ctxMenuSubDelete.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.ctxMenuSubDelete.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ctxMenuSubDelete.Name = "ctxMenuSubDelete";
			this.ctxMenuSubDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
			this.ctxMenuSubDelete.Size = new System.Drawing.Size(214, 22);
			this.ctxMenuSubDelete.Text = "Delete";
			this.ctxMenuSubDelete.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
			this.ctxMenuSubDelete.Click += new System.EventHandler(this.ctxMenuSubDelete_Click);
			// 
			// operationsContextMenuStrip
			// 
			this.operationsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertRowMenuItem,
            this.ctxMenuOpCopy,
            this.ctxMenuOpPaste,
            this.toolStripSeparator4,
            this.goToReferenceToolStripMenuItem,
            this.toolStripSeparator6,
            this.deleteRowMenuItem});
			this.operationsContextMenuStrip.Name = "contextMenuStrip1";
			this.operationsContextMenuStrip.Size = new System.Drawing.Size(145, 126);
			this.operationsContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.operationsContextMenuStrip_Opening);
			// 
			// insertRowMenuItem
			// 
			this.insertRowMenuItem.Name = "insertRowMenuItem";
			this.insertRowMenuItem.Size = new System.Drawing.Size(144, 22);
			this.insertRowMenuItem.Text = "New";
			this.insertRowMenuItem.Click += new System.EventHandler(this.insertRowMenuItem_Click);
			// 
			// ctxMenuOpCopy
			// 
			this.ctxMenuOpCopy.Name = "ctxMenuOpCopy";
			this.ctxMenuOpCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.ctxMenuOpCopy.Size = new System.Drawing.Size(144, 22);
			this.ctxMenuOpCopy.Text = "Copy";
			this.ctxMenuOpCopy.Click += new System.EventHandler(this.ctxMenuOpCopy_Click);
			// 
			// ctxMenuOpPaste
			// 
			this.ctxMenuOpPaste.Name = "ctxMenuOpPaste";
			this.ctxMenuOpPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.ctxMenuOpPaste.Size = new System.Drawing.Size(144, 22);
			this.ctxMenuOpPaste.Text = "Paste";
			this.ctxMenuOpPaste.Click += new System.EventHandler(this.ctxMenuOpPaste_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
			// 
			// goToReferenceToolStripMenuItem
			// 
			this.goToReferenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToolStripMenuItem,
            this.peekToolStripMenuItem});
			this.goToReferenceToolStripMenuItem.Name = "goToReferenceToolStripMenuItem";
			this.goToReferenceToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.goToReferenceToolStripMenuItem.Text = "Reference";
			// 
			// goToolStripMenuItem
			// 
			this.goToolStripMenuItem.Name = "goToolStripMenuItem";
			this.goToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
			this.goToolStripMenuItem.Text = "Go";
			this.goToolStripMenuItem.Click += new System.EventHandler(this.goToolStripMenuItem_Click);
			// 
			// peekToolStripMenuItem
			// 
			this.peekToolStripMenuItem.Name = "peekToolStripMenuItem";
			this.peekToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
			this.peekToolStripMenuItem.Text = "Peek";
			this.peekToolStripMenuItem.Click += new System.EventHandler(this.peekToolStripMenuItem_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(141, 6);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.scriptGroupBox);
			this.splitContainer1.Panel1MinSize = 100;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.label3);
			this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
			this.splitContainer1.Panel2.Controls.Add(this.subroutineSearchBox);
			this.splitContainer1.Panel2MinSize = 410;
			this.splitContainer1.Size = new System.Drawing.Size(1060, 750);
			this.splitContainer1.SplitterDistance = 635;
			this.splitContainer1.TabIndex = 9;
			// 
			// scriptGroupBox
			// 
			this.scriptGroupBox.Controls.Add(this.dataGridScriptOpEditor);
			this.scriptGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scriptGroupBox.Location = new System.Drawing.Point(0, 0);
			this.scriptGroupBox.MinimumSize = new System.Drawing.Size(510, 0);
			this.scriptGroupBox.Name = "scriptGroupBox";
			this.scriptGroupBox.Size = new System.Drawing.Size(635, 750);
			this.scriptGroupBox.TabIndex = 16;
			this.scriptGroupBox.TabStop = false;
			this.scriptGroupBox.Text = "Subroutine Editor";
			// 
			// dataGridScriptOpEditor
			// 
			this.dataGridScriptOpEditor.AllowUserToResizeRows = false;
			this.dataGridScriptOpEditor.BackgroundColor = System.Drawing.SystemColors.WindowFrame;
			this.dataGridScriptOpEditor.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGridScriptOpEditor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridScriptOpEditor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridScriptOpEditor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridScriptOpEditor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LabelColumn,
            this.OpcodeColumn,
            this.ArgColumn});
			this.dataGridScriptOpEditor.ContextMenuStrip = this.operationsContextMenuStrip;
			this.dataGridScriptOpEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridScriptOpEditor.Location = new System.Drawing.Point(3, 16);
			this.dataGridScriptOpEditor.MinimumSize = new System.Drawing.Size(500, 0);
			this.dataGridScriptOpEditor.Name = "dataGridScriptOpEditor";
			this.dataGridScriptOpEditor.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.dataGridScriptOpEditor.Size = new System.Drawing.Size(629, 731);
			this.dataGridScriptOpEditor.TabIndex = 10;
			this.dataGridScriptOpEditor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridScriptOpEditor_CellContentClick);
			this.dataGridScriptOpEditor.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView2_DataBindingComplete);
			this.dataGridScriptOpEditor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView2_MouseDown);
			// 
			// LabelColumn
			// 
			this.LabelColumn.HeaderText = "Label";
			this.LabelColumn.Name = "LabelColumn";
			this.LabelColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// OpcodeColumn
			// 
			this.OpcodeColumn.FillWeight = 180F;
			this.OpcodeColumn.HeaderText = "Opcode";
			this.OpcodeColumn.Name = "OpcodeColumn";
			this.OpcodeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.OpcodeColumn.Width = 180;
			// 
			// ArgColumn
			// 
			this.ArgColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.ArgColumn.FillWeight = 150F;
			this.ArgColumn.HeaderText = "Argument";
			this.ArgColumn.Name = "ArgColumn";
			this.ArgColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(30, 13);
			this.label3.TabIndex = 16;
			this.label3.Text = "Find:";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.splitContainer3);
			this.groupBox1.Location = new System.Drawing.Point(3, 32);
			this.groupBox1.MinimumSize = new System.Drawing.Size(400, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(415, 718);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			// 
			// splitContainer3
			// 
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer3.Location = new System.Drawing.Point(3, 16);
			this.splitContainer3.MinimumSize = new System.Drawing.Size(400, 0);
			this.splitContainer3.Name = "splitContainer3";
			this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.Controls.Add(this.subroutineListBox);
			this.splitContainer3.Panel1.Controls.Add(this.splitContainer2);
			// 
			// splitContainer3.Panel2
			// 
			this.splitContainer3.Panel2.Controls.Add(this.dataGridScriptVariables);
			this.splitContainer3.Size = new System.Drawing.Size(409, 699);
			this.splitContainer3.SplitterDistance = 366;
			this.splitContainer3.TabIndex = 10;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer2.Location = new System.Drawing.Point(3, 3);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.btn_ExportSubRoutine);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.btn_ImportSubRoutine);
			this.splitContainer2.Size = new System.Drawing.Size(403, 25);
			this.splitContainer2.SplitterDistance = 184;
			this.splitContainer2.TabIndex = 12;
			// 
			// btn_ExportSubRoutine
			// 
			this.btn_ExportSubRoutine.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btn_ExportSubRoutine.Location = new System.Drawing.Point(0, 0);
			this.btn_ExportSubRoutine.Name = "btn_ExportSubRoutine";
			this.btn_ExportSubRoutine.Size = new System.Drawing.Size(184, 25);
			this.btn_ExportSubRoutine.TabIndex = 10;
			this.btn_ExportSubRoutine.Text = "Export";
			this.btn_ExportSubRoutine.UseVisualStyleBackColor = true;
			this.btn_ExportSubRoutine.Click += new System.EventHandler(this.button3_Click);
			// 
			// btn_ImportSubRoutine
			// 
			this.btn_ImportSubRoutine.Dock = System.Windows.Forms.DockStyle.Fill;
			this.btn_ImportSubRoutine.Location = new System.Drawing.Point(0, 0);
			this.btn_ImportSubRoutine.Name = "btn_ImportSubRoutine";
			this.btn_ImportSubRoutine.Size = new System.Drawing.Size(215, 25);
			this.btn_ImportSubRoutine.TabIndex = 11;
			this.btn_ImportSubRoutine.Text = "Import";
			this.btn_ImportSubRoutine.UseVisualStyleBackColor = true;
			this.btn_ImportSubRoutine.Click += new System.EventHandler(this.button4_Click);
			// 
			// dataGridScriptVariables
			// 
			this.dataGridScriptVariables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridScriptVariables.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGridScriptVariables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridScriptVariables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VariableType,
            this.VariableName,
            this.VariableLength});
			this.dataGridScriptVariables.Location = new System.Drawing.Point(6, 3);
			this.dataGridScriptVariables.Name = "dataGridScriptVariables";
			this.dataGridScriptVariables.Size = new System.Drawing.Size(397, 342);
			this.dataGridScriptVariables.TabIndex = 15;
			this.dataGridScriptVariables.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridScriptVariables_CellBeginEdit);
			this.dataGridScriptVariables.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridScriptVariables_CellEndEdit);
			this.dataGridScriptVariables.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridScriptVariables_DeleteRow);
			// 
			// subroutineSearchBox
			// 
			this.subroutineSearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.subroutineSearchBox.Location = new System.Drawing.Point(61, 6);
			this.subroutineSearchBox.Name = "subroutineSearchBox";
			this.subroutineSearchBox.Size = new System.Drawing.Size(348, 20);
			this.subroutineSearchBox.TabIndex = 15;
			this.subroutineSearchBox.TextChanged += new System.EventHandler(this.subroutineSearch_TextChanged);
			// 
			// variableListBoxContextMenu
			// 
			this.variableListBoxContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMenuVarNewInt,
            this.ctxMenuVarNewString,
            this.toolStripSeparator1,
            this.ctxMenuVarFindReference,
            this.toolStripSeparator2,
            this.ctxMenuVarDelete});
			this.variableListBoxContextMenu.Name = "subroutineListContextMenuStrip";
			this.variableListBoxContextMenu.Size = new System.Drawing.Size(175, 104);
			// 
			// ctxMenuVarNewInt
			// 
			this.ctxMenuVarNewInt.Name = "ctxMenuVarNewInt";
			this.ctxMenuVarNewInt.Size = new System.Drawing.Size(174, 22);
			this.ctxMenuVarNewInt.Text = "New Numeric";
			// 
			// ctxMenuVarNewString
			// 
			this.ctxMenuVarNewString.Name = "ctxMenuVarNewString";
			this.ctxMenuVarNewString.Size = new System.Drawing.Size(174, 22);
			this.ctxMenuVarNewString.Text = "New String";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(171, 6);
			// 
			// ctxMenuVarFindReference
			// 
			this.ctxMenuVarFindReference.Name = "ctxMenuVarFindReference";
			this.ctxMenuVarFindReference.Size = new System.Drawing.Size(174, 22);
			this.ctxMenuVarFindReference.Text = "Find All References";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(171, 6);
			// 
			// ctxMenuVarDelete
			// 
			this.ctxMenuVarDelete.Name = "ctxMenuVarDelete";
			this.ctxMenuVarDelete.Size = new System.Drawing.Size(174, 22);
			this.ctxMenuVarDelete.Text = "Delete";
			// 
			// VariableType
			// 
			this.VariableType.Frozen = true;
			this.VariableType.HeaderText = "Type";
			this.VariableType.Items.AddRange(new object[] {
            "Numeric",
            "String"});
			this.VariableType.Name = "VariableType";
			this.VariableType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			// 
			// VariableName
			// 
			this.VariableName.Frozen = true;
			this.VariableName.HeaderText = "Name";
			this.VariableName.Name = "VariableName";
			this.VariableName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// VariableLength
			// 
			this.VariableLength.Frozen = true;
			this.VariableLength.HeaderText = "Length";
			this.VariableLength.Name = "VariableLength";
			this.VariableLength.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// ScriptFileViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer1);
			this.Name = "ScriptFileViewer";
			this.Size = new System.Drawing.Size(1060, 750);
			this.ParentChanged += new System.EventHandler(this.ScriptFileViewer_ParentChanged);
			this.subroutineListContextMenuStrip.ResumeLayout(false);
			this.operationsContextMenuStrip.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.scriptGroupBox.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridScriptOpEditor)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
			this.splitContainer3.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGridScriptVariables)).EndInit();
			this.variableListBoxContextMenu.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox subroutineListBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridScriptOpEditor;
        private System.Windows.Forms.Button btn_ImportSubRoutine;
        private System.Windows.Forms.Button btn_ExportSubRoutine;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ContextMenuStrip operationsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem insertRowMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox subroutineSearchBox;
        private System.Windows.Forms.ToolStripMenuItem goToReferenceToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip subroutineListContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteRowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuSubFindReference;
		private System.Windows.Forms.GroupBox scriptGroupBox;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGridViewTextBoxColumn LabelColumn;
		private System.Windows.Forms.DataGridViewComboBoxColumn OpcodeColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn ArgColumn;
		private System.Windows.Forms.ContextMenuStrip variableListBoxContextMenu;
		private System.Windows.Forms.ToolStripMenuItem ctxMenuVarNewInt;
		private System.Windows.Forms.ToolStripMenuItem ctxMenuVarNewString;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem ctxMenuVarFindReference;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem ctxMenuVarDelete;
		private System.Windows.Forms.ToolStripMenuItem ctxMenuSubNewRoutine;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem ctxMenuSubDelete;
		private System.Windows.Forms.DataGridView dataGridScriptVariables;
		private ToolStripSeparator toolStripSeparator5;
		private ToolStripMenuItem ctxMenuOpCopy;
		private ToolStripMenuItem ctxMenuOpPaste;
		private ToolStripSeparator toolStripSeparator4;
		private ToolStripSeparator toolStripSeparator6;
		private ToolStripMenuItem peekToolStripMenuItem;
		private ToolStripMenuItem goToolStripMenuItem;
		private ToolStripMenuItem renameToolStripMenuItem;
		private DataGridViewComboBoxColumn VariableType;
		private DataGridViewTextBoxColumn VariableName;
		private DataGridViewTextBoxColumn VariableLength;
	}
}
