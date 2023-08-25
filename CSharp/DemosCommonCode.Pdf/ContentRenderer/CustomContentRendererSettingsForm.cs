using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Vintasoft.Imaging.ImageProcessing;
using Vintasoft.Imaging.ImageProcessing.Effects;

namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A form that allows to view and edit settings of custom content renderer.
    /// </summary>
    public partial class CustomContentRendererSettingsForm : Form
    {

        #region Fields

        /// <summary>
        /// The content renderer.
        /// </summary>
        CustomContentRenderer _contentRenderer;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomContentRendererSettingsForm"/> class.
        /// </summary>
        public CustomContentRendererSettingsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomContentRendererSettingsForm"/> class.
        /// </summary>
        /// <param name="contentRenderer">The content renderer.</param>
        public CustomContentRendererSettingsForm(CustomContentRenderer contentRenderer)
            : this()
        {
            _contentRenderer = contentRenderer;
            fillPathsCheckBox.Checked = contentRenderer.FillPaths;
            drawPathsCheckBox.Checked = contentRenderer.DrawPaths;
            useTilingPatternsCheckBox.Checked = contentRenderer.FillPathsUseTilingPatterns;
            useShadingPatternsCheckBox.Checked = contentRenderer.FillPathsUseShadingPatterns;
            useClipPathsCheckBox.Checked = contentRenderer.SetClipPaths;
            linesWeightNumericUpDown.Value = (int)(contentRenderer.LinesWeigth * 100);
            drawFormsCheckBox.Checked = contentRenderer.DrawForms;
            drawAnnotationsCheckBox.Checked = contentRenderer.DrawAnnotations;
            drawImageResourcesCheckBox.Checked = contentRenderer.DrawImages;
            drawInlineImagesCheckBox.Checked = contentRenderer.DrawInlineImages;
            fillAreaUseShadigPatternsCheckBox.Checked = contentRenderer.FillAreaUseShadingPatterns;
            drawTextCheckBox.Checked = contentRenderer.DrawText;
            drawInvisibleTextCheckBox.Checked = contentRenderer.DrawInvisibleText;
            if (contentRenderer.ImageProcessing != null)
            {
                ProcessingCommandBase[] commands;
                if (contentRenderer.ImageProcessing is CompositeCommand)
                    commands = ((CompositeCommand)contentRenderer.ImageProcessing).GetCommands();
                else
                    commands = new ProcessingCommandBase[] { contentRenderer.ImageProcessing };
                foreach (ProcessingCommandBase command in commands)
                {
                    if (command is ChangePixelFormatToGrayscaleCommand)
                        convertToGrayscaleCheckBox.Checked = true;
                    else if (command is AutoColorsCommand)
                        autoColorsCheckBox.Checked = true;
                    else if (command is AutoLevelsCommand)
                        autoLevelsCheckBox.Checked = true;
                    else if (command is AutoContrastCommand)
                        autoContrastCheckBox.Checked = true;
                }
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Handles the Click event of ButtonOk object.
        /// </summary>
        private void buttonOk_Click(object sender, EventArgs e)
        {
            // saves current setting to content renderer and closes form

            _contentRenderer.FillPaths = fillPathsCheckBox.Checked;
            _contentRenderer.DrawPaths = drawPathsCheckBox.Checked;
            _contentRenderer.FillPathsUseTilingPatterns = useTilingPatternsCheckBox.Checked;
            _contentRenderer.FillPathsUseShadingPatterns = useShadingPatternsCheckBox.Checked;
            _contentRenderer.SetClipPaths = useClipPathsCheckBox.Checked;
            _contentRenderer.LinesWeigth = (float)linesWeightNumericUpDown.Value / 100f;
            _contentRenderer.DrawForms = drawFormsCheckBox.Checked;
            _contentRenderer.DrawAnnotations = drawAnnotationsCheckBox.Checked;
            _contentRenderer.DrawImages = drawImageResourcesCheckBox.Checked;
            _contentRenderer.DrawInlineImages = drawInlineImagesCheckBox.Checked;
            _contentRenderer.FillAreaUseShadingPatterns = fillAreaUseShadigPatternsCheckBox.Checked;
            _contentRenderer.DrawText = drawTextCheckBox.Checked;
            _contentRenderer.DrawInvisibleText = drawInvisibleTextCheckBox.Checked;
            List<ProcessingCommandBase> processingCommands = new List<ProcessingCommandBase>();
            if (autoLevelsCheckBox.Checked)
                processingCommands.Add(new AutoLevelsCommand());
            if (autoColorsCheckBox.Checked)
                processingCommands.Add(new AutoColorsCommand());
            if (autoContrastCheckBox.Checked)
                processingCommands.Add(new AutoContrastCommand());
            if (convertToGrayscaleCheckBox.Checked)
                processingCommands.Add(new ChangePixelFormatToGrayscaleCommand());
            if (processingCommands.Count == 0)
                _contentRenderer.ImageProcessing = null;
            else if (processingCommands.Count == 1)
                _contentRenderer.ImageProcessing = processingCommands[0];
            else
                _contentRenderer.ImageProcessing = new CompositeCommand(processingCommands.ToArray());
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the Click event of ButtonCancel object.
        /// </summary>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion

    }
}
