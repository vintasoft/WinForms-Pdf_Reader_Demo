namespace DemosCommonCode.Pdf
{
    partial class ImageViewerResolutionToolStrip
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
            this.resolutionValueToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.SuspendLayout();
            // 
            // resolutionValueToolStripComboBox
            // 
            this.resolutionValueToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resolutionValueToolStripComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.resolutionValueToolStripComboBox.Name = "resolutionValueToolStripComboBox";
            this.resolutionValueToolStripComboBox.Size = new System.Drawing.Size(121, 23);
            this.resolutionValueToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.resolutionValueToolStripComboBox_SelectedIndexChanged);
            // 
            // ImageViewerResolutionToolStrip
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resolutionValueToolStripComboBox});
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripComboBox resolutionValueToolStripComboBox;
    }
}
