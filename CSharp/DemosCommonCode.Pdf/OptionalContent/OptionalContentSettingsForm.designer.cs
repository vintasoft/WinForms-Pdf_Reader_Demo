namespace DemosCommonCode.Pdf
{
    partial class OptionalContentSettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.ocGroupsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.configurationsComboBox = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.showAllLayersCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configuration";
            // 
            // ocGroupsCheckedListBox
            // 
            this.ocGroupsCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ocGroupsCheckedListBox.CheckOnClick = true;
            this.ocGroupsCheckedListBox.FormattingEnabled = true;
            this.ocGroupsCheckedListBox.Location = new System.Drawing.Point(12, 60);
            this.ocGroupsCheckedListBox.Name = "ocGroupsCheckedListBox";
            this.ocGroupsCheckedListBox.Size = new System.Drawing.Size(275, 154);
            this.ocGroupsCheckedListBox.TabIndex = 1;
            // 
            // configurationsComboBox
            // 
            this.configurationsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.configurationsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.configurationsComboBox.FormattingEnabled = true;
            this.configurationsComboBox.Location = new System.Drawing.Point(117, 13);
            this.configurationsComboBox.Name = "configurationsComboBox";
            this.configurationsComboBox.Size = new System.Drawing.Size(170, 21);
            this.configurationsComboBox.TabIndex = 2;
            this.configurationsComboBox.SelectedIndexChanged += new System.EventHandler(this.configurationsComboBox_SelectedIndexChanged);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(212, 223);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Visible layers";
            // 
            // showAllLayersCheckBox
            // 
            this.showAllLayersCheckBox.AutoSize = true;
            this.showAllLayersCheckBox.Location = new System.Drawing.Point(117, 39);
            this.showAllLayersCheckBox.Name = "showAllLayersCheckBox";
            this.showAllLayersCheckBox.Size = new System.Drawing.Size(101, 17);
            this.showAllLayersCheckBox.TabIndex = 7;
            this.showAllLayersCheckBox.Text = "Show All Layers";
            this.showAllLayersCheckBox.UseVisualStyleBackColor = true;
            this.showAllLayersCheckBox.CheckedChanged += new System.EventHandler(this.showAllLayersCheckBox_CheckedChanged);
            // 
            // OptionalContentSettingsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 258);
            this.Controls.Add(this.showAllLayersCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.configurationsComboBox);
            this.Controls.Add(this.ocGroupsCheckedListBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 210);
            this.Name = "OptionalContentSettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Layers (Optional Content) Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox ocGroupsCheckedListBox;
        private System.Windows.Forms.ComboBox configurationsComboBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox showAllLayersCheckBox;
    }
}