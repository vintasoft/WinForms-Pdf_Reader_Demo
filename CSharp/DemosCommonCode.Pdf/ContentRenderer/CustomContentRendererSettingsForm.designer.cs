namespace DemosCommonCode.Pdf
{
    partial class CustomContentRendererSettingsForm
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
            this.fillPathsCheckBox = new System.Windows.Forms.CheckBox();
            this.useTilingPatternsCheckBox = new System.Windows.Forms.CheckBox();
            this.useShadingPatternsCheckBox = new System.Windows.Forms.CheckBox();
            this.drawPathsCheckBox = new System.Windows.Forms.CheckBox();
            this.linesWeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fillAreaUseShadigPatternsCheckBox = new System.Windows.Forms.CheckBox();
            this.useClipPathsCheckBox = new System.Windows.Forms.CheckBox();
            this.imagesGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.autoContrastCheckBox = new System.Windows.Forms.CheckBox();
            this.autoLevelsCheckBox = new System.Windows.Forms.CheckBox();
            this.autoColorsCheckBox = new System.Windows.Forms.CheckBox();
            this.convertToGrayscaleCheckBox = new System.Windows.Forms.CheckBox();
            this.drawInlineImagesCheckBox = new System.Windows.Forms.CheckBox();
            this.drawImageResourcesCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.drawAnnotationsCheckBox = new System.Windows.Forms.CheckBox();
            this.drawFormsCheckBox = new System.Windows.Forms.CheckBox();
            this.okButton = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.drawInvisibleTextCheckBox = new System.Windows.Forms.CheckBox();
            this.drawTextCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.linesWeightNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.imagesGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // fillPathsCheckBox
            // 
            this.fillPathsCheckBox.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.fillPathsCheckBox, 2);
            this.fillPathsCheckBox.Location = new System.Drawing.Point(3, 26);
            this.fillPathsCheckBox.Name = "fillPathsCheckBox";
            this.fillPathsCheckBox.Size = new System.Drawing.Size(68, 17);
            this.fillPathsCheckBox.TabIndex = 0;
            this.fillPathsCheckBox.Text = "Fill Paths";
            this.fillPathsCheckBox.UseVisualStyleBackColor = true;
            // 
            // useTilingPatternsCheckBox
            // 
            this.useTilingPatternsCheckBox.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.useTilingPatternsCheckBox, 2);
            this.useTilingPatternsCheckBox.Location = new System.Drawing.Point(3, 49);
            this.useTilingPatternsCheckBox.Name = "useTilingPatternsCheckBox";
            this.useTilingPatternsCheckBox.Size = new System.Drawing.Size(166, 17);
            this.useTilingPatternsCheckBox.TabIndex = 1;
            this.useTilingPatternsCheckBox.Text = "Fill Paths using Tiling Patterns";
            this.useTilingPatternsCheckBox.UseVisualStyleBackColor = true;
            // 
            // useShadingPatternsCheckBox
            // 
            this.useShadingPatternsCheckBox.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.useShadingPatternsCheckBox, 2);
            this.useShadingPatternsCheckBox.Location = new System.Drawing.Point(3, 72);
            this.useShadingPatternsCheckBox.Name = "useShadingPatternsCheckBox";
            this.useShadingPatternsCheckBox.Size = new System.Drawing.Size(180, 17);
            this.useShadingPatternsCheckBox.TabIndex = 10;
            this.useShadingPatternsCheckBox.Text = "Fill Paths using Shading Patterns";
            this.useShadingPatternsCheckBox.UseVisualStyleBackColor = true;
            // 
            // drawPathsCheckBox
            // 
            this.drawPathsCheckBox.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.drawPathsCheckBox, 2);
            this.drawPathsCheckBox.Location = new System.Drawing.Point(3, 3);
            this.drawPathsCheckBox.Name = "drawPathsCheckBox";
            this.drawPathsCheckBox.Size = new System.Drawing.Size(81, 17);
            this.drawPathsCheckBox.TabIndex = 11;
            this.drawPathsCheckBox.Text = "Draw Paths";
            this.drawPathsCheckBox.UseVisualStyleBackColor = true;
            // 
            // linesWeightNumericUpDown
            // 
            this.linesWeightNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.linesWeightNumericUpDown.Location = new System.Drawing.Point(95, 142);
            this.linesWeightNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.linesWeightNumericUpDown.MinimumSize = new System.Drawing.Size(60, 0);
            this.linesWeightNumericUpDown.Name = "linesWeightNumericUpDown";
            this.linesWeightNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.linesWeightNumericUpDown.TabIndex = 12;
            this.linesWeightNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Lines Weight (%)";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(226, 183);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paths && Lines";
            // 
            // fillAreaUseShadigPatternsCheckBox
            // 
            this.fillAreaUseShadigPatternsCheckBox.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.fillAreaUseShadigPatternsCheckBox, 2);
            this.fillAreaUseShadigPatternsCheckBox.Location = new System.Drawing.Point(3, 95);
            this.fillAreaUseShadigPatternsCheckBox.Name = "fillAreaUseShadigPatternsCheckBox";
            this.fillAreaUseShadigPatternsCheckBox.Size = new System.Drawing.Size(175, 17);
            this.fillAreaUseShadigPatternsCheckBox.TabIndex = 15;
            this.fillAreaUseShadigPatternsCheckBox.Text = "Fill Area using Shading Patterns";
            this.fillAreaUseShadigPatternsCheckBox.UseVisualStyleBackColor = true;
            // 
            // useClipPathsCheckBox
            // 
            this.useClipPathsCheckBox.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.useClipPathsCheckBox, 2);
            this.useClipPathsCheckBox.Location = new System.Drawing.Point(3, 118);
            this.useClipPathsCheckBox.Name = "useClipPathsCheckBox";
            this.useClipPathsCheckBox.Size = new System.Drawing.Size(95, 17);
            this.useClipPathsCheckBox.TabIndex = 14;
            this.useClipPathsCheckBox.Text = "Use Clip Paths";
            this.useClipPathsCheckBox.UseVisualStyleBackColor = true;
            // 
            // imagesGroupBox
            // 
            this.imagesGroupBox.AutoSize = true;
            this.imagesGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.imagesGroupBox.Controls.Add(this.tableLayoutPanel3);
            this.imagesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imagesGroupBox.Location = new System.Drawing.Point(235, 3);
            this.imagesGroupBox.Name = "imagesGroupBox";
            this.imagesGroupBox.Size = new System.Drawing.Size(226, 183);
            this.imagesGroupBox.TabIndex = 15;
            this.imagesGroupBox.TabStop = false;
            this.imagesGroupBox.Text = "Images";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.tableLayoutPanel4);
            this.groupBox2.Location = new System.Drawing.Point(3, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(214, 112);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Processing";
            // 
            // autoContrastCheckBox
            // 
            this.autoContrastCheckBox.AutoSize = true;
            this.autoContrastCheckBox.Location = new System.Drawing.Point(3, 72);
            this.autoContrastCheckBox.Name = "autoContrastCheckBox";
            this.autoContrastCheckBox.Size = new System.Drawing.Size(90, 17);
            this.autoContrastCheckBox.TabIndex = 4;
            this.autoContrastCheckBox.Text = "Auto Contrast";
            this.autoContrastCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoLevelsCheckBox
            // 
            this.autoLevelsCheckBox.AutoSize = true;
            this.autoLevelsCheckBox.Location = new System.Drawing.Point(3, 49);
            this.autoLevelsCheckBox.Name = "autoLevelsCheckBox";
            this.autoLevelsCheckBox.Size = new System.Drawing.Size(82, 17);
            this.autoLevelsCheckBox.TabIndex = 3;
            this.autoLevelsCheckBox.Text = "Auto Levels";
            this.autoLevelsCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoColorsCheckBox
            // 
            this.autoColorsCheckBox.AutoSize = true;
            this.autoColorsCheckBox.Location = new System.Drawing.Point(3, 26);
            this.autoColorsCheckBox.Name = "autoColorsCheckBox";
            this.autoColorsCheckBox.Size = new System.Drawing.Size(80, 17);
            this.autoColorsCheckBox.TabIndex = 2;
            this.autoColorsCheckBox.Text = "Auto Colors";
            this.autoColorsCheckBox.UseVisualStyleBackColor = true;
            // 
            // convertToGrayscaleCheckBox
            // 
            this.convertToGrayscaleCheckBox.AutoSize = true;
            this.convertToGrayscaleCheckBox.Location = new System.Drawing.Point(3, 3);
            this.convertToGrayscaleCheckBox.Name = "convertToGrayscaleCheckBox";
            this.convertToGrayscaleCheckBox.Size = new System.Drawing.Size(125, 17);
            this.convertToGrayscaleCheckBox.TabIndex = 0;
            this.convertToGrayscaleCheckBox.Text = "Convert to Grayscale";
            this.convertToGrayscaleCheckBox.UseVisualStyleBackColor = true;
            // 
            // drawInlineImagesCheckBox
            // 
            this.drawInlineImagesCheckBox.AutoSize = true;
            this.drawInlineImagesCheckBox.Location = new System.Drawing.Point(3, 26);
            this.drawInlineImagesCheckBox.Name = "drawInlineImagesCheckBox";
            this.drawInlineImagesCheckBox.Size = new System.Drawing.Size(116, 17);
            this.drawInlineImagesCheckBox.TabIndex = 1;
            this.drawInlineImagesCheckBox.Text = "Draw Inline Images";
            this.drawInlineImagesCheckBox.UseVisualStyleBackColor = true;
            // 
            // drawImageResourcesCheckBox
            // 
            this.drawImageResourcesCheckBox.AutoSize = true;
            this.drawImageResourcesCheckBox.Location = new System.Drawing.Point(3, 3);
            this.drawImageResourcesCheckBox.Name = "drawImageResourcesCheckBox";
            this.drawImageResourcesCheckBox.Size = new System.Drawing.Size(88, 17);
            this.drawImageResourcesCheckBox.TabIndex = 0;
            this.drawImageResourcesCheckBox.Text = "Draw Images";
            this.drawImageResourcesCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.tableLayoutPanel6);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(235, 192);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(226, 65);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Forms && Annotations";
            // 
            // drawAnnotationsCheckBox
            // 
            this.drawAnnotationsCheckBox.AutoSize = true;
            this.drawAnnotationsCheckBox.Location = new System.Drawing.Point(3, 26);
            this.drawAnnotationsCheckBox.Name = "drawAnnotationsCheckBox";
            this.drawAnnotationsCheckBox.Size = new System.Drawing.Size(110, 17);
            this.drawAnnotationsCheckBox.TabIndex = 6;
            this.drawAnnotationsCheckBox.Text = "Draw Annotations";
            this.drawAnnotationsCheckBox.UseVisualStyleBackColor = true;
            // 
            // drawFormsCheckBox
            // 
            this.drawFormsCheckBox.AutoSize = true;
            this.drawFormsCheckBox.Location = new System.Drawing.Point(3, 3);
            this.drawFormsCheckBox.Name = "drawFormsCheckBox";
            this.drawFormsCheckBox.Size = new System.Drawing.Size(82, 17);
            this.drawFormsCheckBox.TabIndex = 5;
            this.drawFormsCheckBox.Text = "Draw Forms";
            this.drawFormsCheckBox.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(154, 263);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 17;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(235, 263);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 18;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox4.Controls.Add(this.tableLayoutPanel5);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 192);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(226, 65);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Text";
            // 
            // drawInvisibleTextCheckBox
            // 
            this.drawInvisibleTextCheckBox.AutoSize = true;
            this.drawInvisibleTextCheckBox.Location = new System.Drawing.Point(3, 26);
            this.drawInvisibleTextCheckBox.Name = "drawInvisibleTextCheckBox";
            this.drawInvisibleTextCheckBox.Size = new System.Drawing.Size(116, 17);
            this.drawInvisibleTextCheckBox.TabIndex = 6;
            this.drawInvisibleTextCheckBox.Text = "Draw Invisible Text";
            this.drawInvisibleTextCheckBox.UseVisualStyleBackColor = true;
            // 
            // drawTextCheckBox
            // 
            this.drawTextCheckBox.AutoSize = true;
            this.drawTextCheckBox.Location = new System.Drawing.Point(3, 3);
            this.drawTextCheckBox.Name = "drawTextCheckBox";
            this.drawTextCheckBox.Size = new System.Drawing.Size(75, 17);
            this.drawTextCheckBox.TabIndex = 5;
            this.drawTextCheckBox.Text = "Draw Text";
            this.drawTextCheckBox.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonCancel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.okButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.imagesGroupBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(464, 289);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.useClipPathsCheckBox, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.fillAreaUseShadigPatternsCheckBox, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.linesWeightNumericUpDown, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.drawPathsCheckBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.useShadingPatternsCheckBox, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.useTilingPatternsCheckBox, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.fillPathsCheckBox, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(220, 164);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.drawImageResourcesCheckBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.drawInlineImagesCheckBox, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(220, 164);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.convertToGrayscaleCheckBox, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.autoContrastCheckBox, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.autoColorsCheckBox, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.autoLevelsCheckBox, 0, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(208, 93);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.drawTextCheckBox, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.drawInvisibleTextCheckBox, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(220, 46);
            this.tableLayoutPanel5.TabIndex = 7;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.drawFormsCheckBox, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.drawAnnotationsCheckBox, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(220, 46);
            this.tableLayoutPanel6.TabIndex = 7;
            // 
            // CustomContentRendererSettingsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(464, 288);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomContentRendererSettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Content Renderer Settings";
            ((System.ComponentModel.ISupportInitialize)(this.linesWeightNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.imagesGroupBox.ResumeLayout(false);
            this.imagesGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox fillPathsCheckBox;
        private System.Windows.Forms.CheckBox useTilingPatternsCheckBox;
        private System.Windows.Forms.CheckBox useShadingPatternsCheckBox;
        private System.Windows.Forms.CheckBox drawPathsCheckBox;
        private System.Windows.Forms.NumericUpDown linesWeightNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox useClipPathsCheckBox;
        private System.Windows.Forms.GroupBox imagesGroupBox;
        private System.Windows.Forms.CheckBox drawInlineImagesCheckBox;
        private System.Windows.Forms.CheckBox drawImageResourcesCheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox convertToGrayscaleCheckBox;
        private System.Windows.Forms.CheckBox autoContrastCheckBox;
        private System.Windows.Forms.CheckBox autoLevelsCheckBox;
        private System.Windows.Forms.CheckBox autoColorsCheckBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox drawFormsCheckBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox fillAreaUseShadigPatternsCheckBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox drawInvisibleTextCheckBox;
        private System.Windows.Forms.CheckBox drawTextCheckBox;
        private System.Windows.Forms.CheckBox drawAnnotationsCheckBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
    }
}