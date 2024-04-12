using System;
using System.ComponentModel;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.UI;

namespace DemosCommonCode.Pdf.JavaScript
{
    /// <summary>
    /// A form that allows to debug PDF JavaScript interperter.
    /// </summary>
    public partial class PdfJavaScriptDebuggerForm : Form
    {

        #region Fields

        /// <summary>
        /// The image viewer.
        /// </summary>
        ImageViewer _imageViewer;

        /// <summary>
        /// The JavaScript action executor.
        /// </summary>
        WinFormsPdfJavaScriptActionExecutor _javaScriptActionExecutor;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfJavaScriptDebuggerForm"/> class.
        /// </summary>
        public PdfJavaScriptDebuggerForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfJavaScriptDebuggerForm"/> class.
        /// </summary>
        /// <param name="javaScriptActionExecutor">The java script action executor.</param>
        /// <param name="imageViewer">The image viewer.</param>
        public PdfJavaScriptDebuggerForm(
            WinFormsPdfJavaScriptActionExecutor javaScriptActionExecutor,
            ImageViewer imageViewer)
            : this()
        {
            _javaScriptActionExecutor = javaScriptActionExecutor;
            _javaScriptActionExecutor.ConsoleTextBox = consoleTextBox;
            _javaScriptActionExecutor.LogTextBox = logTextBox;
            _imageViewer = imageViewer;
        }

        #endregion



        #region Methods

        #region PROTECTED

        /// <summary>
        /// Raizes event <see cref="E:System.Windows.Forms.Form.Closing" />.
        /// </summary>
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
            base.OnClosing(e);
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the KeyDown event of watchTextBox object.
        /// </summary>
        private void watchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // if 'Enter' key is pressed
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.Handled = true;
                // evaluate the expression
                EvaluateExpression();
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of debugModecheckBox object.
        /// </summary>
        private void debugModecheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // if debug mode is enabled
            if (debugModecheckBox.Checked)
                PdfJavaScriptManager.JavaScriptActionExecutor.DebugMode = true;
            else
                PdfJavaScriptManager.JavaScriptActionExecutor.DebugMode = false;
        }

        /// <summary>
        /// Handles the CheckedChanged event of topMostCheckBox object.
        /// </summary>
        private void topMostCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // if this form must be shown on top
            if (topMostCheckBox.Checked)
                this.TopMost = true;
            else
                this.TopMost = false;
        }

        /// <summary>
        /// Handles the Click event of clearConsoleButton object.
        /// </summary>
        private void clearConsoleButton_Click(object sender, EventArgs e)
        {
            // clear the console
            consoleTextBox.Text = "";
        }

        /// <summary>
        /// Handles the Click event of clearEngineLog object.
        /// </summary>
        private void clearEngineLog_Click(object sender, EventArgs e)
        {
            // clear the interpreter log
            logTextBox.Text = "";
        }

        /// <summary>
        /// Handles the Click event of evaluateButton object.
        /// </summary>
        private void evaluateButton_Click(object sender, EventArgs e)
        {
            // evaluate expression
            EvaluateExpression();
        }

        /// <summary>
        /// Handles the Click event of deleteButton object.
        /// </summary>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            // clear evaluate result
            evaluateResultTextBox.Text = "";
            // clear JavaScript evaluate result
            watchResultPropertyGrid.SelectedObject = null;
            // clear expression text box
            expressionTextBox.Text = "";
        }

        #endregion


        /// <summary>
        /// Evaluates the expression.
        /// </summary>
        private void EvaluateExpression()
        {
            // disable evaluate button
            evaluateButton.Enabled = false;
            evaluateButton.Refresh();
            try
            {
                PdfPage page = null;
                if (_imageViewer.Image != null)
                    // get PDF page
                    page = PdfDocumentController.GetPageAssociatedWithImage(_imageViewer.Image);


                PdfDocument document = null;
                if (page != null)
                    // get PDF document
                    document = page.Document;

                Object result = null;
                // disable edit expression text box
                expressionTextBox.ReadOnly = true;
                // execute JavaScript expression
                result = _javaScriptActionExecutor.ExecuteScript(
                    document,
                    expressionTextBox.Text,
                    true);
                // enable edit expression text box
                expressionTextBox.ReadOnly = false;


                // update evaluate result

                evaluateResultTextBox.Clear();
                if (result == null || result.ToString() == null)
                    evaluateResultTextBox.AppendText("null");
                else
                    evaluateResultTextBox.AppendText(result.ToString());

                watchResultPropertyGrid.SelectedObject = result;
            }
            finally
            {
                // enable evaluate button
                evaluateButton.Enabled = true;
            }
        }

        #endregion

        #endregion

    }
}
