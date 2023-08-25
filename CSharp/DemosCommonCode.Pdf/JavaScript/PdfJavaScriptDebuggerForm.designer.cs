namespace DemosCommonCode.Pdf.JavaScript
{
    partial class PdfJavaScriptDebuggerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfJavaScriptDebuggerForm));
            this.consoleTextBox = new System.Windows.Forms.TextBox();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.watchResultPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.expressionTextBox = new System.Windows.Forms.TextBox();
            this.evaluateResultTextBox = new System.Windows.Forms.TextBox();
            this.topMostCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.evaluateButton = new System.Windows.Forms.Button();
            this.clearConsoleButton = new System.Windows.Forms.Button();
            this.clearEngineLogButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.debugModecheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // consoleTextBox
            // 
            this.consoleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.consoleTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.consoleTextBox.Location = new System.Drawing.Point(6, 19);
            this.consoleTextBox.Multiline = true;
            this.consoleTextBox.Name = "consoleTextBox";
            this.consoleTextBox.ReadOnly = true;
            this.consoleTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.consoleTextBox.Size = new System.Drawing.Size(364, 130);
            this.consoleTextBox.TabIndex = 1;
            this.consoleTextBox.WordWrap = false;
            // 
            // logTextBox
            // 
            this.logTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logTextBox.Location = new System.Drawing.Point(6, 19);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logTextBox.Size = new System.Drawing.Size(364, 101);
            this.logTextBox.TabIndex = 2;
            this.logTextBox.WordWrap = false;
            // 
            // watchResultPropertyGrid
            // 
            this.watchResultPropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.watchResultPropertyGrid.HelpVisible = false;
            this.watchResultPropertyGrid.Location = new System.Drawing.Point(6, 45);
            this.watchResultPropertyGrid.Name = "watchResultPropertyGrid";
            this.watchResultPropertyGrid.Size = new System.Drawing.Size(349, 90);
            this.watchResultPropertyGrid.TabIndex = 7;
            this.watchResultPropertyGrid.ToolbarVisible = false;
            // 
            // expressionTextBox
            // 
            this.expressionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expressionTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.expressionTextBox.Location = new System.Drawing.Point(11, 19);
            this.expressionTextBox.Multiline = true;
            this.expressionTextBox.Name = "expressionTextBox";
            this.expressionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.expressionTextBox.Size = new System.Drawing.Size(325, 69);
            this.expressionTextBox.TabIndex = 0;
            this.expressionTextBox.WordWrap = false;
            this.expressionTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.watchTextBox_KeyDown);
            // 
            // evaluateResultTextBox
            // 
            this.evaluateResultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.evaluateResultTextBox.Location = new System.Drawing.Point(6, 19);
            this.evaluateResultTextBox.Multiline = true;
            this.evaluateResultTextBox.Name = "evaluateResultTextBox";
            this.evaluateResultTextBox.ReadOnly = true;
            this.evaluateResultTextBox.Size = new System.Drawing.Size(350, 20);
            this.evaluateResultTextBox.TabIndex = 5;
            // 
            // topMostCheckBox
            // 
            this.topMostCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.topMostCheckBox.AutoSize = true;
            this.topMostCheckBox.Location = new System.Drawing.Point(311, 10);
            this.topMostCheckBox.Name = "topMostCheckBox";
            this.topMostCheckBox.Size = new System.Drawing.Size(68, 17);
            this.topMostCheckBox.TabIndex = 6;
            this.topMostCheckBox.Text = "TopMost";
            this.topMostCheckBox.UseVisualStyleBackColor = true;
            this.topMostCheckBox.CheckedChanged += new System.EventHandler(this.topMostCheckBox_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.watchResultPropertyGrid);
            this.groupBox1.Controls.Add(this.evaluateResultTextBox);
            this.groupBox1.Location = new System.Drawing.Point(5, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 141);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Result";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.deleteButton);
            this.groupBox2.Controls.Add(this.evaluateButton);
            this.groupBox2.Controls.Add(this.expressionTextBox);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Location = new System.Drawing.Point(3, 319);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(372, 240);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Evaluate Expression";
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.Location = new System.Drawing.Point(342, 61);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(24, 26);
            this.deleteButton.TabIndex = 10;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // evaluateButton
            // 
            this.evaluateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.evaluateButton.Image = ((System.Drawing.Image)(resources.GetObject("evaluateButton.Image")));
            this.evaluateButton.Location = new System.Drawing.Point(342, 19);
            this.evaluateButton.Name = "evaluateButton";
            this.evaluateButton.Size = new System.Drawing.Size(24, 37);
            this.evaluateButton.TabIndex = 9;
            this.evaluateButton.UseVisualStyleBackColor = true;
            this.evaluateButton.Click += new System.EventHandler(this.evaluateButton_Click);
            // 
            // clearConsoleButton
            // 
            this.clearConsoleButton.Location = new System.Drawing.Point(3, 6);
            this.clearConsoleButton.Name = "clearConsoleButton";
            this.clearConsoleButton.Size = new System.Drawing.Size(89, 23);
            this.clearConsoleButton.TabIndex = 10;
            this.clearConsoleButton.Text = "Clear Console";
            this.clearConsoleButton.UseVisualStyleBackColor = true;
            this.clearConsoleButton.Click += new System.EventHandler(this.clearConsoleButton_Click);
            // 
            // clearEngineLogButton
            // 
            this.clearEngineLogButton.Location = new System.Drawing.Point(98, 6);
            this.clearEngineLogButton.Name = "clearEngineLogButton";
            this.clearEngineLogButton.Size = new System.Drawing.Size(89, 23);
            this.clearEngineLogButton.TabIndex = 11;
            this.clearEngineLogButton.Text = "Clear Engine Log";
            this.clearEngineLogButton.UseVisualStyleBackColor = true;
            this.clearEngineLogButton.Click += new System.EventHandler(this.clearEngineLog_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.consoleTextBox);
            this.groupBox3.Location = new System.Drawing.Point(3, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(376, 155);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Console Output";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.logTextBox);
            this.groupBox4.Location = new System.Drawing.Point(3, 193);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(376, 126);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "JavaScript Engine Log";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // debugModecheckBox
            // 
            this.debugModecheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.debugModecheckBox.AutoSize = true;
            this.debugModecheckBox.Location = new System.Drawing.Point(217, 9);
            this.debugModecheckBox.Name = "debugModecheckBox";
            this.debugModecheckBox.Size = new System.Drawing.Size(88, 17);
            this.debugModecheckBox.TabIndex = 14;
            this.debugModecheckBox.Text = "Debug Mode";
            this.debugModecheckBox.UseVisualStyleBackColor = true;
            this.debugModecheckBox.CheckedChanged += new System.EventHandler(this.debugModecheckBox_CheckedChanged);
            // 
            // PdfJavaScriptDebuggerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 562);
            this.Controls.Add(this.debugModecheckBox);
            this.Controls.Add(this.clearEngineLogButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.clearConsoleButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.topMostCheckBox);
            this.Name = "PdfJavaScriptDebuggerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PDF JavaScript Interpreter Debugger";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox consoleTextBox;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.PropertyGrid watchResultPropertyGrid;
        private System.Windows.Forms.TextBox expressionTextBox;
        private System.Windows.Forms.TextBox evaluateResultTextBox;
        private System.Windows.Forms.CheckBox topMostCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button clearConsoleButton;
        private System.Windows.Forms.Button clearEngineLogButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button evaluateButton;
        private System.Windows.Forms.CheckBox debugModecheckBox;
        private System.Windows.Forms.Button deleteButton;
    }
}