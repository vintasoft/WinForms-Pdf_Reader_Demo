namespace DemosCommonCode.Pdf
{
    partial class PdfContentXObjectControl
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

        #region Windows Form Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contentXObjectsListBox = new System.Windows.Forms.ListBox();
            this.ContentXObjectContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewContentXObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveContentXObjectAsBinaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveContentXObjectAsImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.removeConentXObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewContentXObjectButton = new System.Windows.Forms.Button();
            this.editGroupBox = new System.Windows.Forms.GroupBox();
            this.rotationAngleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.rotateXObjectButton = new System.Windows.Forms.Button();
            this.translateYNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.translateXObjectButton = new System.Windows.Forms.Button();
            this.translateXNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.replaceXObjectButton = new System.Windows.Forms.Button();
            this.removeContentXObjectButton = new System.Windows.Forms.Button();
            this.saveGroupBox = new System.Windows.Forms.GroupBox();
            this.saveAsImageButton = new System.Windows.Forms.Button();
            this.saveAsBinaryDataButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.regionGroupBox = new System.Windows.Forms.GroupBox();
            this.rightBottomPointLabel = new System.Windows.Forms.Label();
            this.leftBottomPointLabel = new System.Windows.Forms.Label();
            this.rightTopPointLabel = new System.Windows.Forms.Label();
            this.leftTopPointLabel = new System.Windows.Forms.Label();
            this.ContentXObjectContextMenuStrip.SuspendLayout();
            this.editGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rotationAngleNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.translateYNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.translateXNumericUpDown)).BeginInit();
            this.saveGroupBox.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.regionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentXObjectsListBox
            // 
            this.contentXObjectsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentXObjectsListBox.ContextMenuStrip = this.ContentXObjectContextMenuStrip;
            this.contentXObjectsListBox.FormattingEnabled = true;
            this.contentXObjectsListBox.HorizontalScrollbar = true;
            this.contentXObjectsListBox.Location = new System.Drawing.Point(9, 3);
            this.contentXObjectsListBox.Name = "contentXObjectsListBox";
            this.contentXObjectsListBox.Size = new System.Drawing.Size(232, 69);
            this.contentXObjectsListBox.TabIndex = 0;
            this.contentXObjectsListBox.SelectedIndexChanged += new System.EventHandler(this.contentXObjectsListBox_SelectedIndexChanged);
            this.contentXObjectsListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.contentXObjectsListBox_MouseDoubleClick);
            // 
            // ContentXObjectContextMenuStrip
            // 
            this.ContentXObjectContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewContentXObjectToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveContentXObjectAsBinaryToolStripMenuItem,
            this.saveContentXObjectAsImageToolStripMenuItem,
            this.toolStripSeparator2,
            this.removeConentXObjectToolStripMenuItem});
            this.ContentXObjectContextMenuStrip.Name = "ContentXObjectContextMenuStrip";
            this.ContentXObjectContextMenuStrip.Size = new System.Drawing.Size(200, 104);
            this.ContentXObjectContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.ContentXObjectContextMenuStrip_Opening);
            // 
            // viewContentXObjectToolStripMenuItem
            // 
            this.viewContentXObjectToolStripMenuItem.Name = "viewContentXObjectToolStripMenuItem";
            this.viewContentXObjectToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.viewContentXObjectToolStripMenuItem.Text = "View Content XObject...";
            this.viewContentXObjectToolStripMenuItem.Click += new System.EventHandler(this.viewContentXObjectToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // saveContentXObjectAsBinaryToolStripMenuItem
            // 
            this.saveContentXObjectAsBinaryToolStripMenuItem.Name = "saveContentXObjectAsBinaryToolStripMenuItem";
            this.saveContentXObjectAsBinaryToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.saveContentXObjectAsBinaryToolStripMenuItem.Text = "Save As Binary Data...";
            this.saveContentXObjectAsBinaryToolStripMenuItem.Click += new System.EventHandler(this.saveContentXObjectAsBinaryDataToolStripMenuItem_Click);
            // 
            // saveContentXObjectAsImageToolStripMenuItem
            // 
            this.saveContentXObjectAsImageToolStripMenuItem.Name = "saveContentXObjectAsImageToolStripMenuItem";
            this.saveContentXObjectAsImageToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.saveContentXObjectAsImageToolStripMenuItem.Text = "Save As Image...";
            this.saveContentXObjectAsImageToolStripMenuItem.Click += new System.EventHandler(this.saveContentXObjectAsImageToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(196, 6);
            // 
            // removeConentXObjectToolStripMenuItem
            // 
            this.removeConentXObjectToolStripMenuItem.Name = "removeConentXObjectToolStripMenuItem";
            this.removeConentXObjectToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.removeConentXObjectToolStripMenuItem.Text = "Remove";
            this.removeConentXObjectToolStripMenuItem.Click += new System.EventHandler(this.removeConentXObjectToolStripMenuItem_Click);
            // 
            // viewContentXObjectButton
            // 
            this.viewContentXObjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewContentXObjectButton.Location = new System.Drawing.Point(9, 179);
            this.viewContentXObjectButton.Name = "viewContentXObjectButton";
            this.viewContentXObjectButton.Size = new System.Drawing.Size(232, 23);
            this.viewContentXObjectButton.TabIndex = 1;
            this.viewContentXObjectButton.Text = "View Content XObject...";
            this.viewContentXObjectButton.UseVisualStyleBackColor = true;
            this.viewContentXObjectButton.Click += new System.EventHandler(this.viewContentXObjectButton_Click);
            // 
            // editGroupBox
            // 
            this.editGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editGroupBox.Controls.Add(this.rotationAngleNumericUpDown);
            this.editGroupBox.Controls.Add(this.rotateXObjectButton);
            this.editGroupBox.Controls.Add(this.translateYNumericUpDown);
            this.editGroupBox.Controls.Add(this.translateXObjectButton);
            this.editGroupBox.Controls.Add(this.translateXNumericUpDown);
            this.editGroupBox.Controls.Add(this.replaceXObjectButton);
            this.editGroupBox.Controls.Add(this.removeContentXObjectButton);
            this.editGroupBox.Location = new System.Drawing.Point(6, 299);
            this.editGroupBox.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.editGroupBox.Name = "editGroupBox";
            this.editGroupBox.Size = new System.Drawing.Size(244, 128);
            this.editGroupBox.TabIndex = 3;
            this.editGroupBox.TabStop = false;
            this.editGroupBox.Text = "Edit";
            // 
            // rotationAngleNumericUpDown
            // 
            this.rotationAngleNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rotationAngleNumericUpDown.Location = new System.Drawing.Point(129, 100);
            this.rotationAngleNumericUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.rotationAngleNumericUpDown.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.rotationAngleNumericUpDown.Name = "rotationAngleNumericUpDown";
            this.rotationAngleNumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.rotationAngleNumericUpDown.TabIndex = 6;
            this.rotationAngleNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            // 
            // rotateXObjectButton
            // 
            this.rotateXObjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rotateXObjectButton.Location = new System.Drawing.Point(6, 99);
            this.rotateXObjectButton.Name = "rotateXObjectButton";
            this.rotateXObjectButton.Size = new System.Drawing.Size(112, 23);
            this.rotateXObjectButton.TabIndex = 5;
            this.rotateXObjectButton.Text = "Rotate";
            this.rotateXObjectButton.UseVisualStyleBackColor = true;
            this.rotateXObjectButton.Click += new System.EventHandler(this.rotateXObjectButton_Click);
            // 
            // translateYNumericUpDown
            // 
            this.translateYNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.translateYNumericUpDown.Location = new System.Drawing.Point(186, 74);
            this.translateYNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.translateYNumericUpDown.Name = "translateYNumericUpDown";
            this.translateYNumericUpDown.Size = new System.Drawing.Size(52, 20);
            this.translateYNumericUpDown.TabIndex = 4;
            this.translateYNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // translateXObjectButton
            // 
            this.translateXObjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.translateXObjectButton.Location = new System.Drawing.Point(6, 72);
            this.translateXObjectButton.Name = "translateXObjectButton";
            this.translateXObjectButton.Size = new System.Drawing.Size(112, 23);
            this.translateXObjectButton.TabIndex = 3;
            this.translateXObjectButton.Text = "Translate";
            this.translateXObjectButton.UseVisualStyleBackColor = true;
            this.translateXObjectButton.Click += new System.EventHandler(this.translateXObjectButton_Click);
            // 
            // translateXNumericUpDown
            // 
            this.translateXNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.translateXNumericUpDown.Location = new System.Drawing.Point(129, 74);
            this.translateXNumericUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.translateXNumericUpDown.Name = "translateXNumericUpDown";
            this.translateXNumericUpDown.Size = new System.Drawing.Size(50, 20);
            this.translateXNumericUpDown.TabIndex = 2;
            this.translateXNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // replaceXObjectButton
            // 
            this.replaceXObjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.replaceXObjectButton.Location = new System.Drawing.Point(6, 45);
            this.replaceXObjectButton.Name = "replaceXObjectButton";
            this.replaceXObjectButton.Size = new System.Drawing.Size(232, 23);
            this.replaceXObjectButton.TabIndex = 1;
            this.replaceXObjectButton.Text = "Replace...";
            this.replaceXObjectButton.UseVisualStyleBackColor = true;
            this.replaceXObjectButton.Click += new System.EventHandler(this.replaceXObjectButton_Click);
            // 
            // removeContentXObjectButton
            // 
            this.removeContentXObjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.removeContentXObjectButton.Location = new System.Drawing.Point(6, 18);
            this.removeContentXObjectButton.Name = "removeContentXObjectButton";
            this.removeContentXObjectButton.Size = new System.Drawing.Size(232, 23);
            this.removeContentXObjectButton.TabIndex = 0;
            this.removeContentXObjectButton.Text = "Remove";
            this.removeContentXObjectButton.UseVisualStyleBackColor = true;
            this.removeContentXObjectButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // saveGroupBox
            // 
            this.saveGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveGroupBox.Controls.Add(this.saveAsImageButton);
            this.saveGroupBox.Controls.Add(this.saveAsBinaryDataButton);
            this.saveGroupBox.Location = new System.Drawing.Point(3, 208);
            this.saveGroupBox.Name = "saveGroupBox";
            this.saveGroupBox.Size = new System.Drawing.Size(244, 79);
            this.saveGroupBox.TabIndex = 2;
            this.saveGroupBox.TabStop = false;
            this.saveGroupBox.Text = "Save";
            // 
            // saveAsImageButton
            // 
            this.saveAsImageButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveAsImageButton.Location = new System.Drawing.Point(6, 48);
            this.saveAsImageButton.Name = "saveAsImageButton";
            this.saveAsImageButton.Size = new System.Drawing.Size(232, 23);
            this.saveAsImageButton.TabIndex = 1;
            this.saveAsImageButton.Text = "Save As Image...";
            this.saveAsImageButton.UseVisualStyleBackColor = true;
            this.saveAsImageButton.Click += new System.EventHandler(this.saveContentXObjectAsImageButton_Click);
            // 
            // saveAsBinaryDataButton
            // 
            this.saveAsBinaryDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveAsBinaryDataButton.Location = new System.Drawing.Point(6, 19);
            this.saveAsBinaryDataButton.Name = "saveAsBinaryDataButton";
            this.saveAsBinaryDataButton.Size = new System.Drawing.Size(232, 23);
            this.saveAsBinaryDataButton.TabIndex = 0;
            this.saveAsBinaryDataButton.Text = "Save As Binary Data...";
            this.saveAsBinaryDataButton.UseVisualStyleBackColor = true;
            this.saveAsBinaryDataButton.Click += new System.EventHandler(this.saveContentXObjectAsBinaryDataButton_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.ColumnCount = 1;
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.Controls.Add(this.editGroupBox, 0, 1);
            this.mainPanel.Controls.Add(this.panel1, 0, 0);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.RowCount = 2;
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.mainPanel.Size = new System.Drawing.Size(256, 430);
            this.mainPanel.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.regionGroupBox);
            this.panel1.Controls.Add(this.contentXObjectsListBox);
            this.panel1.Controls.Add(this.viewContentXObjectButton);
            this.panel1.Controls.Add(this.saveGroupBox);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 290);
            this.panel1.TabIndex = 0;
            // 
            // regionGroupBox
            // 
            this.regionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.regionGroupBox.Controls.Add(this.rightBottomPointLabel);
            this.regionGroupBox.Controls.Add(this.leftBottomPointLabel);
            this.regionGroupBox.Controls.Add(this.rightTopPointLabel);
            this.regionGroupBox.Controls.Add(this.leftTopPointLabel);
            this.regionGroupBox.Location = new System.Drawing.Point(9, 110);
            this.regionGroupBox.Name = "regionGroupBox";
            this.regionGroupBox.Size = new System.Drawing.Size(232, 63);
            this.regionGroupBox.TabIndex = 3;
            this.regionGroupBox.TabStop = false;
            this.regionGroupBox.Text = "Region in page content:";
            // 
            // rightBottomPointLabel
            // 
            this.rightBottomPointLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rightBottomPointLabel.AutoSize = true;
            this.rightBottomPointLabel.Location = new System.Drawing.Point(120, 38);
            this.rightBottomPointLabel.Name = "rightBottomPointLabel";
            this.rightBottomPointLabel.Size = new System.Drawing.Size(106, 13);
            this.rightBottomPointLabel.TabIndex = 3;
            this.rightBottomPointLabel.Text = "(0000.000;0000.000)";
            // 
            // leftBottomPointLabel
            // 
            this.leftBottomPointLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.leftBottomPointLabel.AutoSize = true;
            this.leftBottomPointLabel.Location = new System.Drawing.Point(6, 38);
            this.leftBottomPointLabel.Name = "leftBottomPointLabel";
            this.leftBottomPointLabel.Size = new System.Drawing.Size(106, 13);
            this.leftBottomPointLabel.TabIndex = 2;
            this.leftBottomPointLabel.Text = "(0000.000;0000.000)";
            // 
            // rightTopPointLabel
            // 
            this.rightTopPointLabel.AutoSize = true;
            this.rightTopPointLabel.Location = new System.Drawing.Point(120, 16);
            this.rightTopPointLabel.Name = "rightTopPointLabel";
            this.rightTopPointLabel.Size = new System.Drawing.Size(106, 13);
            this.rightTopPointLabel.TabIndex = 1;
            this.rightTopPointLabel.Text = "(0000.000;0000.000)";
            // 
            // leftTopPointLabel
            // 
            this.leftTopPointLabel.AutoSize = true;
            this.leftTopPointLabel.Location = new System.Drawing.Point(6, 16);
            this.leftTopPointLabel.Name = "leftTopPointLabel";
            this.leftTopPointLabel.Size = new System.Drawing.Size(106, 13);
            this.leftTopPointLabel.TabIndex = 0;
            this.leftTopPointLabel.Text = "(0000.000;0000.000)";
            // 
            // PdfContentXObjectControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(171, 90);
            this.Name = "PdfContentXObjectControl";
            this.Size = new System.Drawing.Size(256, 430);
            this.ContentXObjectContextMenuStrip.ResumeLayout(false);
            this.editGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rotationAngleNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.translateYNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.translateXNumericUpDown)).EndInit();
            this.saveGroupBox.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.regionGroupBox.ResumeLayout(false);
            this.regionGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox contentXObjectsListBox;
        private System.Windows.Forms.Button viewContentXObjectButton;
        private System.Windows.Forms.ContextMenuStrip ContentXObjectContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem viewContentXObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox saveGroupBox;
        private System.Windows.Forms.Button saveAsImageButton;
        private System.Windows.Forms.Button saveAsBinaryDataButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem saveContentXObjectAsBinaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveContentXObjectAsImageToolStripMenuItem;
        private System.Windows.Forms.GroupBox editGroupBox;
        private System.Windows.Forms.Button removeContentXObjectButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem removeConentXObjectToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel mainPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox regionGroupBox;
        private System.Windows.Forms.Label rightBottomPointLabel;
        private System.Windows.Forms.Label leftBottomPointLabel;
        private System.Windows.Forms.Label rightTopPointLabel;
        private System.Windows.Forms.Label leftTopPointLabel;
        private System.Windows.Forms.Button replaceXObjectButton;
        private System.Windows.Forms.NumericUpDown translateYNumericUpDown;
        private System.Windows.Forms.Button translateXObjectButton;
        private System.Windows.Forms.NumericUpDown translateXNumericUpDown;
        private System.Windows.Forms.NumericUpDown rotationAngleNumericUpDown;
        private System.Windows.Forms.Button rotateXObjectButton;
    }
}