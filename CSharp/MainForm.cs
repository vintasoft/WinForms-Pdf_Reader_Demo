using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Text;
using Vintasoft.Imaging.Spelling;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;
using Vintasoft.Imaging.UIActions;

using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.JavaScript;
using Vintasoft.Imaging.Pdf.Processing.Analyzers;
using Vintasoft.Imaging.Pdf.Processing.PdfA;
using Vintasoft.Imaging.Pdf.Security;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.Tree.FileAttachments;
using Vintasoft.Imaging.Pdf.Tree.Fonts;
using Vintasoft.Imaging.Pdf.Tree.InteractiveForms;
using Vintasoft.Imaging.Pdf.UI;
using Vintasoft.Imaging.Pdf.UI.Annotations;
using Vintasoft.Imaging.Pdf.Tree.Annotations;

using DemosCommonCode;
using DemosCommonCode.Imaging;
using DemosCommonCode.Imaging.Codecs;
using DemosCommonCode.Imaging.Codecs.Dialogs;
using DemosCommonCode.Imaging.ColorManagement;
using DemosCommonCode.Pdf;
using DemosCommonCode.Pdf.JavaScript;
using DemosCommonCode.Pdf.Security;
using DemosCommonCode.Spelling;
using Vintasoft.Imaging.Codecs.Decoders;
using Vintasoft.Imaging.Fonts;

namespace PdfReaderDemo
{
    /// <summary>
    /// Main form of PDF Reader Demo.
    /// </summary>
    public partial class MainForm : Form
    {

        #region Fields

        /// <summary>
        /// Template of the application's title.
        /// </summary>
        string _titlePrefix = "VintaSoft PDF Reader Demo v" + ImagingGlobalSettings.ProductVersion + " {0}";

        /// <summary>
        /// Default image viewer display mode.
        /// </summary>
        ImageViewerDisplayMode _defaultImageViewerDisplayMode;

        /// <summary>
        /// Selected "View - Image scale mode" menu item.
        /// </summary>
        ToolStripMenuItem _imageScaleSelectedMenuItem;

        /// <summary>
        /// Opened PDF document.
        /// </summary>
        PdfDocument _document;

        /// <summary>
        /// The stream, which stores a PDF document.
        /// </summary>
        FileStream _pdfFileStream = null;

        /// <summary>
        /// A value indicating whether application must clear a list of runtime messages of PDF document.
        /// </summary>
        bool _clearPdfDocumentRuntimeMessages = false;

        /// <summary>
        /// ThumbnailViewer print manager.
        /// </summary>
        ImageViewerPrintManager _thumbnailViewerPrintManager;

        /// <summary>
        /// Action name.
        /// </summary>
        string _actionName;

        /// <summary>
        /// The start time of action.
        /// </summary>
        DateTime _actionStartTime;

        /// <summary>
        /// The PDF content custom renderer.
        /// </summary>
        CustomContentRenderer _pdfCustomContentRenderer = new CustomContentRenderer();

        /// <summary>
        /// The JavaScript debugger form.
        /// </summary>
        PdfJavaScriptDebuggerForm _javaScriptDebuggerForm;

        /// <summary>
        /// A value indicating whether demo must show error message with information about missing CJK font.
        /// </summary>
        bool _showCJKFontMissingErrorMessage = false;

        /// <summary>
        /// A value indicating whether focused image should be changed when image viewer is scrolled.
        /// </summary>
        bool _changeFocusedImageWhenImageViewerScrolled = false;


        #region Visual Tools

        /// <summary>
        /// The visual tool for text searching and selection on PDF page.
        /// </summary>
        TextSelectionTool _textSelectionTool;

        /// <summary>
        /// The visual tool action for selecting and extracting of images or forms on PDF page.
        /// </summary>
        PdfContentXObjectToolAction _contentXObjectToolAction;

        /// <summary>
        /// The visual tool for scrolling pages in image viewer.
        /// </summary>
        ScrollPages _scrollPages;

        /// <summary>
        /// The visual tool for viewing, filling and editing PDF annotations and PDF interactive fields.
        /// </summary>
        PdfAnnotationTool _annotationTool;

        /// <summary>
        /// The composite visual tool that combines functionality of annotation tool and text selection tool.
        /// </summary>
        CompositeVisualTool _annotationAndTextSelectionTool = null;

        #endregion

        #endregion



        #region Constructors

        /// <summary> 
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // register the evaluation license for VintaSoft Imaging .NET SDK
            Vintasoft.Imaging.ImagingGlobalSettings.Register("REG_USER", "REG_EMAIL", "EXPIRATION_DATE", "REG_CODE");

            InitializeComponent();

            if (DesignMode)
                return;

            Jbig2AssemblyLoader.Load();
            Jpeg2000AssemblyLoader.Load();

            resolutionToolStrip1.ImageViewer = imageViewer1;

            // init "View => Image Display Mode" menu
            singlePageToolStripMenuItem.Tag = ImageViewerDisplayMode.SinglePage;
            twoColumnsToolStripMenuItem.Tag = ImageViewerDisplayMode.TwoColumns;
            singleContinuousRowToolStripMenuItem.Tag = ImageViewerDisplayMode.SingleContinuousRow;
            singleContinuousColumnToolStripMenuItem.Tag = ImageViewerDisplayMode.SingleContinuousColumn;
            twoContinuousRowsToolStripMenuItem.Tag = ImageViewerDisplayMode.TwoContinuousRows;
            twoContinuousColumnsToolStripMenuItem.Tag = ImageViewerDisplayMode.TwoContinuousColumns;

            // init "View => Image Scale Mode" menu
            normalImageToolStripMenuItem.Tag = ImageSizeMode.Normal;
            bestFitToolStripMenuItem.Tag = ImageSizeMode.BestFit;
            fitToWidthToolStripMenuItem.Tag = ImageSizeMode.FitToWidth;
            fitToHeightToolStripMenuItem.Tag = ImageSizeMode.FitToHeight;
            pixelToPixelToolStripMenuItem.Tag = ImageSizeMode.PixelToPixel;
            scaleToolStripMenuItem.Tag = ImageSizeMode.Zoom;
            scale25ToolStripMenuItem.Tag = 25;
            scale50ToolStripMenuItem.Tag = 50;
            scale100ToolStripMenuItem.Tag = 100;
            scale200ToolStripMenuItem.Tag = 200;
            scale400ToolStripMenuItem.Tag = 400;
            _imageScaleSelectedMenuItem = bestFitToolStripMenuItem;
            _imageScaleSelectedMenuItem.Checked = true;

            // specify that exceptions of visual tools must be catched
            DemosTools.CatchVisualToolExceptions(imageViewer1);

            // enable PDF Password Dialog
            PdfAuthenticateTools.EnableAuthenticateRequest = true;

            // set CustomFontProgramsController for all opened documents
            CustomFontProgramsController.SetDefaultFontProgramsController();

            // generate interactive form fields appearance if need
            PdfDemosTools.NeedGenerateInteractiveFormFieldsAppearance = true;

            // init dialogs
            InitDialogs();

            // init visual tools
            InitVisualTools();

            // init PDF action executors
            InitPdfActionExecutors();

            MeasurementVisualToolActionFactory.CreateActions(visualToolsToolStrip1);
            ZoomVisualToolActionFactory.CreateActions(visualToolsToolStrip1);

            // initialize visual tool actions
            InitializeVisualToolActions();

            // create the print manager
            _thumbnailViewerPrintManager = new ImageViewerPrintManager(
                thumbnailViewer1, imagePrintDocument1, printDialog1);

            tabControl_SelectedIndexChanged(this, EventArgs.Empty);

            resolutionToolStrip1.UseDynamicRendering = true;

            imageViewer1.SizeMode = ImageSizeMode.BestFit;
            _defaultImageViewerDisplayMode = imageViewer1.DisplayMode;

            // create PDF rendering settings
            PdfRenderingSettings renderingSettings = new PdfRenderingSettings();
            // show all annotations
            renderingSettings.DrawPdfAnnotations = true;
            renderingSettings.DrawVintasoftAnnotations = true;
            // set PDF rendering settings as image viewer settings
            imageViewer1.ImageRenderingSettings = renderingSettings;

            // image viewer must use the image appearances in single-page and multi-page modes
            imageViewer1.UseImageAppearancesInSinglePageMode = true;

            // set ViewerBufferSize to 32 MPX
            imageViewer1.ViewerBufferSize = 32;

            thumbnailViewer1.GenerateOnlyVisibleThumbnails = true;

            // set ThumbnailSize
            thumbnailViewer1.ThumbnailSize = new Size(128, 128);

            // set ThumbnailCaption properties
            thumbnailViewer1.ThumbnailCaption.Anchor = AnchorType.Bottom;
            thumbnailViewer1.ThumbnailCaption.CaptionFormat = "{PageLabel}";
            thumbnailViewer1.ThumbnailCaption.IsVisible = true;            
            thumbnailViewer1.ThumbnailImagePadding = new PaddingF(0, 0, 0, 18);

            // initialize color management in viewer
            ColorManagementHelper.EnableColorManagement(imageViewer1);

            // update the UI
            UpdateUI();

            Text = string.Format(_titlePrefix, "");

            imageViewer1.Scroll += new ScrollEventHandler(imageViewer1_Scroll);

            imageViewer1.Focus();
        }

        #endregion



        #region Properties

        bool _isPdfFileOpening = false;
        /// <summary>
        /// Gets or sets a value indicating whether the PDF file is opened.
        /// </summary>
        private bool IsPdfFileOpening
        {
            get
            {
                return _isPdfFileOpening;
            }
            set
            {
                _isPdfFileOpening = value;
                UpdateUI();
            }
        }

        /// <summary>
        /// Gets the PDF page, which is associated with image loaded in image viewer.
        /// </summary>
        internal PdfPage FocusedPage
        {
            get
            {
                if (imageViewer1.Image == null)
                    return null;
                return PdfDocumentController.GetPageAssociatedWithImage(imageViewer1.Image);
            }
        }

        /// <summary>
        /// Gets or sets the current visual tool.
        /// </summary>
        internal VisualTool CurrentTool
        {
            get
            {
                return imageViewer1.VisualTool;
            }
            set
            {
                imageViewer1.VisualTool = value;
            }
        }

        bool _useEmbeddedThumbnails = false;
        /// <summary>
        /// Gets or sets a value indicating whether the PDF renderer should use thumbnails embedded into PDF document.
        /// </summary>
        private bool UseEmbeddedThumbnails
        {
            get
            {
                return _useEmbeddedThumbnails;
            }
            set
            {
                _useEmbeddedThumbnails = value;
                if (_document != null)
                {
                    _document.RenderingSettings.UseEmbeddedThumbnails = _useEmbeddedThumbnails;
                }
            }
        }

        #endregion



        #region Methods

        #region PROTECTED

        /// <summary>
        /// Processes a command key.
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message" />,
        /// passed by reference, that represents the window message to process.</param>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values
        /// that represents the key to process.</param>
        /// <returns>
        /// <b>true</b> if the character was processed by the control; otherwise, <b>false</b>.
        /// </returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (imageViewer1.Focused && imageViewer1.VisualTool != null)
            {
                if (keyData == Keys.Tab)
                {
                    if (imageViewer1.VisualTool.PerformNextItemSelection(true))
                        return true;
                }
                else if (keyData == (Keys.Shift | Keys.Tab))
                {
                    if (imageViewer1.VisualTool.PerformNextItemSelection(false))
                        return true;
                }
            }

            if (keyData == (Keys.Shift | Keys.Control | Keys.Add))
            {
                RotateViewClockwise();
                return true;
            }

            if (keyData == (Keys.Shift | Keys.Control | Keys.Subtract))
            {
                RotateViewCounterClockwise();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Main form is closed.
        /// </summary>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            if (_annotationTool.SpellChecker != null)
            {
                SpellCheckManager manager = _annotationTool.SpellChecker;
                _annotationTool.SpellChecker = null;
                SpellCheckTools.DisposeSpellCheckManagerAndEngines(manager);
            }
        }

        #endregion


        #region PRIVATE

        #region UI

        #region Main Form

        /// <summary>
        /// Handles the Shown event of MainForm object.
        /// </summary>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            // process command line of the application

            string[] appArgs = Environment.GetCommandLineArgs();
            if (appArgs.Length > 0)
            {
                Application.DoEvents();
                if (appArgs.Length == 2)
                {
                    try
                    {
                        OpenPdfDocument(appArgs[1]);
                    }
                    catch
                    {
                        ClosePdfDocument();
                    }
                }
            }
        }

        /// <summary>
        /// Handles the FormClosing event of MainForm object.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClosePdfDocument();
        }

        #endregion


        #region 'File' menu

        /// <summary>
        /// Handles the Click event of openToolStripMenuItem object.
        /// </summary>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                OpenPdfDocument(openFileDialog.FileName);
            }
        }

        /// <summary>
        /// Handles the Click event of pageSettingsToolStripMenuItem object.
        /// </summary>
        private void pageSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of printToolStripMenuItem object.
        /// </summary>
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintPdfDocument();
        }

        /// <summary>
        /// Handles the Click event of exitToolStripMenuItem object.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion


        #region 'Edit' menu

        /// <summary>
        /// Handles the DropDownOpened event of editToolStripMenuItem object.
        /// </summary>
        private void editToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            UpdateEditMenuItems();
        }

        /// <summary>
        /// Handles the DropDownClosed event of editToolStripMenuItem object.
        /// </summary>
        private void editToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            EnableEditMenuItems();
        }

        /// <summary>
        /// Handles the Click event of copyToolStripMenuItem object.
        /// </summary>
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CopyItemUIAction copyUIAction = PdfDemosTools.GetUIAction<CopyItemUIAction>(CurrentTool);
                if (copyUIAction != null)
                    copyUIAction.Execute();
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of selectAllToolStripMenuItem object.
        /// </summary>
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectAllItemsUIAction selectAllUIAction = PdfDemosTools.GetUIAction<SelectAllItemsUIAction>(CurrentTool);
            if (selectAllUIAction != null)
                selectAllUIAction.Execute();
        }

        /// <summary>
        /// Handles the Click event of findTextToolStripMenuItem object.
        /// </summary>
        private void findTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FindTextForm findTextDialog = new FindTextForm(_textSelectionTool))
            {
                TabPage selectedTab = tabControl.SelectedTab;
                tabControl.SelectedTab = textRegionTabPage;

                if (_textSelectionTool.HasSelectedText)
                    findTextDialog.FindWhat = _textSelectionTool.SelectedText;

                findTextDialog.ShowDialog();

                tabControl.SelectedTab = selectedTab;
            }
        }

        #endregion


        #region 'View' menu

        #region PDF actions execution

        /// <summary>
        /// Handles the CheckedChanged event of enableActionsExecutingToolStripMenuItem object.
        /// </summary>
        private void enableActionsExecutingToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            // toggle PDF actions execution
            PdfActionExecutorManager.ApplicationActionExecutor.IsEnabled =
                enableActionsExecutingToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Handles the CheckedChanged event of enableJavaScriptExecutingToolStripMenuItem object.
        /// </summary>
        private void enableJavaScriptExecutingToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            // toggle execution of JavaScript
            PdfJavaScriptManager.IsJavaScriptEnabled = enableJavaScriptExecutingToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Handles the Click event of debuggerToolStripMenuItem object.
        /// </summary>
        private void debuggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_javaScriptDebuggerForm == null)
                _javaScriptDebuggerForm = new PdfJavaScriptDebuggerForm(PdfJavaScriptManager.JavaScriptActionExecutor, imageViewer1);
            // show JavaScript debugger
            _javaScriptDebuggerForm.Show();
        }

        #endregion


        #region Thumbnail viewer

        /// <summary>
        /// Handles the Click event of thumbnailViewerSettingsToolStripMenuItem object.
        /// </summary>
        private void thumbnailViewerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ThumbnailViewerSettingsForm viewerSettingsDialog = new ThumbnailViewerSettingsForm(thumbnailViewer1))
            {
                viewerSettingsDialog.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of useEmbeddedThumbnailsToolStripMenuItem object.
        /// </summary>
        private void useEmbeddedThumbnailsToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            // toggle usage of embedded thumbnails of PDF pages by thumbnail viewer
            UseEmbeddedThumbnails = useEmbeddedThumbnailsToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Handles the Click event of changeThumbnailWhenImageViewerScrolledToolStripMenuItem object.
        /// </summary>
        private void changeThumbnailWhenImageViewerScrolledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool state = ((ToolStripMenuItem)sender).Checked;
            ((ToolStripMenuItem)sender).Checked = !state;
            // toggle focused thumbnail changing when image viewer is scrolled
            _changeFocusedImageWhenImageViewerScrolled = !state;
        }

        #endregion


        #region Image viewer

        /// <summary>
        /// Handles the Click event of ImageDisplayMode object.
        /// </summary>
        private void ImageDisplayMode_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem imageDisplayModeMenuItem = (ToolStripMenuItem)sender;
            imageViewer1.DisplayMode = (ImageViewerDisplayMode)imageDisplayModeMenuItem.Tag;
            _defaultImageViewerDisplayMode = imageViewer1.DisplayMode;

            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of ImageScale object.
        /// </summary>
        private void ImageScale_Click(object sender, EventArgs e)
        {
            _imageScaleSelectedMenuItem.Checked = false;
            _imageScaleSelectedMenuItem = (ToolStripMenuItem)sender;

            // if menu item is set to the ImageSizeMode
            if (_imageScaleSelectedMenuItem.Tag is ImageSizeMode)
            {
                // set size mode
                imageViewer1.SizeMode = (ImageSizeMode)_imageScaleSelectedMenuItem.Tag;
                _imageScaleSelectedMenuItem.Checked = true;
            }
            // if menu item is set to the Zoom
            else
            {
                // get zoom value
                int zoomValue = (int)_imageScaleSelectedMenuItem.Tag;
                // set ImageSizeMode as Zoom
                imageViewer1.SizeMode = ImageSizeMode.Zoom;
                // set zoom value
                imageViewer1.Zoom = zoomValue;
            }
        }

        /// <summary>
        /// Handles the ZoomChanged event of imageViewer1 object.
        /// </summary>
        private void imageViewer1_ZoomChanged(object sender, ZoomChangedEventArgs e)
        {
            _imageScaleSelectedMenuItem.Checked = false;
            switch (imageViewer1.SizeMode)
            {
                case ImageSizeMode.BestFit:
                    _imageScaleSelectedMenuItem = bestFitToolStripMenuItem;
                    break;
                case ImageSizeMode.FitToHeight:
                    _imageScaleSelectedMenuItem = fitToHeightToolStripMenuItem;
                    break;
                case ImageSizeMode.FitToWidth:
                    _imageScaleSelectedMenuItem = fitToWidthToolStripMenuItem;
                    break;
                case ImageSizeMode.Normal:
                    _imageScaleSelectedMenuItem = normalImageToolStripMenuItem;
                    break;
                case ImageSizeMode.PixelToPixel:
                    _imageScaleSelectedMenuItem = pixelToPixelToolStripMenuItem;
                    break;
                case ImageSizeMode.Zoom:
                    _imageScaleSelectedMenuItem = scaleToolStripMenuItem;
                    break;
            }
            _imageScaleSelectedMenuItem.Checked = true;
        }

        /// <summary>
        /// Handles the CheckedChanged event of centerImageToolStripMenuItem object.
        /// </summary>
        private void centerImageToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (centerImageToolStripMenuItem.Checked)
            {
                imageViewer1.FocusPointAnchor = AnchorType.None;
                imageViewer1.IsFocusPointFixed = true;
                imageViewer1.ScrollToCenter();
            }
            else
            {
                imageViewer1.FocusPointAnchor = AnchorType.Left | AnchorType.Top;
                imageViewer1.IsFocusPointFixed = true;
            }
        }

        /// <summary>
        /// Handles the Click event of rotateClockwiseToolStripMenuItem object.
        /// </summary>
        private void rotateClockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateViewClockwise();
        }

        /// <summary>
        /// Handles the Click event of rotateCounterclockwiseToolStripMenuItem object.
        /// </summary>
        private void rotateCounterclockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateViewCounterClockwise();
        }

        /// <summary>
        /// Handles the Click event of imageViewerSettingsToolStripMenuItem object.
        /// </summary>
        private void imageViewerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ImageViewerSettingsForm viewerSettingsDialog = new ImageViewerSettingsForm(imageViewer1))
            {
                // save current image viewer display mode
                ImageViewerDisplayMode displayMode = imageViewer1.DisplayMode;

                viewerSettingsDialog.ShowDialog();

                // if display mode is changed
                if (displayMode != imageViewer1.DisplayMode)
                    // update the default display mode
                    _defaultImageViewerDisplayMode = imageViewer1.DisplayMode;

                UpdateUI();
            }
        }

        /// <summary>
        /// Handles the Click event of magnifierSettingsToolStripMenuItem object.
        /// </summary>
        private void magnifierSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MagnifierToolAction magnifierToolAction = visualToolsToolStrip1.FindAction<MagnifierToolAction>();

            if (magnifierToolAction != null)
                magnifierToolAction.ShowVisualToolSettings();
        }

        /// <summary>
        /// Handles the Click event of renderingSettingsToolStripMenuItem object.
        /// </summary>
        private void renderingSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetRenderingSettings();
        }

        #endregion


        /// <summary>
        /// Handles the Click event of colorManagementToolStripMenuItem object.
        /// </summary>
        private void colorManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorManagementSettingsForm.EditColorManagement(imageViewer1);
        }


        #region Custom Renderer

        /// <summary>
        /// Handles the CheckedChanged event of useCustomRendererToolStripMenuItem object.
        /// </summary>
        private void useCustomRendererToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            // get rendering settings

            PdfRenderingSettings settings;
            if (imageViewer1.ImageRenderingSettings is PdfRenderingSettings)
            {
                settings = (PdfRenderingSettings)imageViewer1.ImageRenderingSettings.Clone();
            }
            else
            {
                settings = new PdfRenderingSettings();
                if (imageViewer1.ImageRenderingSettings != null)
                {
                    settings.InterpolationMode = imageViewer1.ImageRenderingSettings.InterpolationMode;
                    settings.SmoothingMode = imageViewer1.ImageRenderingSettings.SmoothingMode;
                    settings.Resolution = imageViewer1.ImageRenderingSettings.Resolution;
                }
            }

            // toggle custom content renderer

            if (useCustomRendererToolStripMenuItem.Checked)
            {
                settings.ContentRenderer = _pdfCustomContentRenderer;
                imageViewer1.ImageRenderingSettings = settings;
            }
            else
            {
                settings.ContentRenderer = null;
                imageViewer1.ImageRenderingSettings = settings;
            }
            UpdateUI();
            ReloadImagesAsync();
        }

        /// <summary>
        /// Handles the Click event of customRendererSettingsToolStripMenuItem object.
        /// </summary>
        private void customRendererSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomContentRendererSettingsForm dialog = new CustomContentRendererSettingsForm(_pdfCustomContentRenderer);
            if (dialog.ShowDialog() == DialogResult.OK)
                ReloadImagesAsync();
        }

        #endregion


        /// <summary>
        /// Handles the Click event of refreshPostScriptFontNamesToolStripMenuItem object.
        /// </summary>
        private void refreshPostScriptFontNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FontProgramsTools.RefreshPostScriptFontNamesOfProgramsController(this) == DialogResult.OK)
            {
                if (imageViewer1.Images.Count > 0)
                    DemosTools.ShowInfoMessage("Reopen the document for using new font names.");
            }
        }

        #endregion


        #region 'Document' menu

        /// <summary>
        /// Handles the Click event of documentInformationToolStripMenuItem object.
        /// </summary>
        private void documentInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // show information about PDF document
            PdfDemosTools.ShowDocumentInformation(_document, false, null);
        }


        #region Verification

        /// <summary>
        /// Handles the Click event of pdfA1bVerifierToolStripMenuItem object.
        /// </summary>
        private void pdfA1bVerifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // verify the PDF document for compatibility with PDF/A-1b format
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                new PdfA1bVerifier());
        }

        /// <summary>
        /// Handles the Click event of pdfA2bVerifierToolStripMenuItem object.
        /// </summary>
        private void pdfA2bVerifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // verify the PDF document for compatibility with PDF/A-2b format
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                new PdfA2bVerifier());
        }

        /// <summary>
        /// Handles the Click event of pdfA3bVerifierToolStripMenuItem object.
        /// </summary>
        private void pdfA3bVerifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // verify the PDF document for compatibility with PDF/A-3b format
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                new PdfA3bVerifier());
        }

        /// <summary>
        /// Handles the Click event of pdfA1aVerifierToolStripMenuItem object.
        /// </summary>
        private void pdfA1aVerifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // verify the PDF document for compatibility with PDF/A-1a format
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                new PdfA1aVerifier());
        }

        /// <summary>
        /// Handles the Click event of pdfA2aVerifierToolStripMenuItem object.
        /// </summary>
        private void pdfA2aVerifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // verify the PDF document for compatibility with PDF/A-2a format
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                new PdfA2aVerifier());
        }

        /// <summary>
        /// Handles the Click event of pdfA3aVerifierToolStripMenuItem object.
        /// </summary>
        private void pdfA3aVerifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // verify the PDF document for compatibility with PDF/A-3a format
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                new PdfA3aVerifier());
        }

        /// <summary>
        /// Handles the Click event of pdfA2uVerifierToolStripMenuItem object.
        /// </summary>
        private void pdfA2uVerifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // verify the PDF document for compatibility with PDF/A-2u format
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                new PdfA2uVerifier());
        }

        /// <summary>
        /// Handles the Click event of pdfA3uVerifierToolStripMenuItem object.
        /// </summary>
        private void pdfA3uVerifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // verify the PDF document for compatibility with PDF/A-3u format
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                new PdfA3uVerifier());
        }

        /// <summary>
        /// Handles the Click event of getConformanceUseMetadataToolStripMenuItem object.
        /// </summary>
        private void getConformanceUseMetadataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // show information about document conformance from PDF document metadata
            DocumentProcessingCommandForm.ExecuteDocumentProcessing(
                _document,
                PdfAnalyzers.DocumentConformance,
                false);
        }

        #endregion


        /// <summary>
        /// Handles the Click event of securityPropertToolStripMenuItem object.
        /// </summary>
        private void securityPropertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SecurityPropertiesForm securityProperties = new SecurityPropertiesForm(_document))
            {
                securityProperties.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of signaturesToolStripMenuItem object.
        /// </summary>
        private void signaturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (DocumentSignaturesForm dialog = new DocumentSignaturesForm(_document))
                {
                    dialog.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of attachmentsPortfolioToolStripMenuItem object.
        /// </summary>
        private void attachmentsPortfolioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // show a form that allows to view attachments (portfolio) of PDF document
            using (AttachmentsEditorForm attachments = new AttachmentsEditorForm(_document))
            {
                attachments.IsReadOnly = true;
                attachments.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of embeddedFilesToolStripMenuItem object.
        /// </summary>
        private void embeddedFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // show a form that allows to view embedded files of PDF document
            using (EmbeddedFilesForm dlg = new EmbeddedFilesForm())
            {
                dlg.Document = _document;
                dlg.CanEditEmbeddedFiles = false;
                dlg.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of documentImageResourcesToolStripMenuItem object.
        /// </summary>
        private void documentImageResourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfImageResource[] images = _document.GetImages();
            if (images.Length > 0)
            {
                // show a form that allows to view image-resources of PDF document
                using (PdfResourcesViewerForm resourcesViewer = new PdfResourcesViewerForm(_document))
                {
                    resourcesViewer.ShowFormResources = false;
                    resourcesViewer.StartPosition = FormStartPosition.CenterParent;
                    resourcesViewer.Owner = this;
                    resourcesViewer.ShowDialog();

                    if (resourcesViewer.PropertyValueChanged)
                        imageViewer1.ReloadImage();
                }
            }
            else
            {
                MessageBox.Show("This PDF document does not contain image resources.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Handles the Click event of fontsToolStripMenuItem object.
        /// </summary>
        private void fontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PdfFont[] fonts = _document.GetFonts();
                if (fonts.Length == 0)
                {
                    MessageBox.Show("This document does not contain fonts.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // show a form that allows to view information about fonts of PDF document
                    using (ViewDocumentFontsForm viewDocumentFontsDialog = new ViewDocumentFontsForm(fonts))
                    {
                        viewDocumentFontsDialog.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                DemosTools.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Handles the Click event of optionalContentToolStripMenuItem object.
        /// </summary>
        private void optionalContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // show a form that allows to view setting of layers (optional content) of PDF document
            using (OptionalContentSettingsForm dialog = new OptionalContentSettingsForm(_document, imageViewer1))
            {
                dialog.ShowDialog();
                imageViewer1.Image.Reload(false);
            }
        }

        #endregion


        #region 'Page' menu

        /// <summary>
        /// Handles the Click event of propertiesToolStripMenuItem object.
        /// </summary>
        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // show properties of PDF page
            using (PropertyGridForm propertyGridForm = new PropertyGridForm(FocusedPage, "Page properties"))
            {
                propertyGridForm.PropertyGrid.PropertyValueChanged += new PropertyValueChangedEventHandler(propertyGrid_PropertyValueChanged);
                propertyGridForm.ShowDialog();
                propertyGridForm.PropertyGrid.PropertyValueChanged -= propertyGrid_PropertyValueChanged;
            }
            UpdateUI();
        }

        /// <summary>
        /// Handles the Click event of pageImageResourcesToolStripMenuItem object.
        /// </summary>
        private void pageImageResourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfImageResource[] images = FocusedPage.GetImages();
            if (images.Length > 0)
            {
                // show a form that allows to view image-resources of PDF page
                using (PdfResourcesViewerForm resourcesViewer = new PdfResourcesViewerForm(FocusedPage))
                {
                    resourcesViewer.ShowFormResources = false;
                    resourcesViewer.StartPosition = FormStartPosition.CenterParent;
                    resourcesViewer.Owner = this;

                    resourcesViewer.ShowDialog();

                    if (resourcesViewer.PropertyValueChanged)
                        imageViewer1.ReloadImage();
                }
            }
            else
            {
                MessageBox.Show("This page does not contain image resources.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Handles the Click event of saveCurrentPageAsToolStripMenuItem object.
        /// </summary>
        private void saveCurrentPageAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (Path.GetExtension(saveFileDialog1.FileName).ToUpperInvariant() != ".PDF")
                {
                    // show a form with rendering settings
                    PdfRenderingSettingsForm renderingSettingsDialog = new PdfRenderingSettingsForm(new PdfRenderingSettings());
                    if (renderingSettingsDialog.ShowDialog() == DialogResult.OK)
                        imageViewer1.Image.RenderingSettings = renderingSettingsDialog.RenderingSettings;
                }
                try
                {
                    // render and save image to a file
                    imageViewer1.Image.Save(saveFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Image saving error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Handles the PropertyValueChanged event of propertyGrid object.
        /// </summary>
        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            // update UI when PDF page properties are changed
            imageViewer1.Image.Reload(true);
            _textSelectionTool.ClearSelection();
        }

        #endregion


        #region 'Help' menu

        /// <summary>
        /// Handles the Click event of aboutToolStripMenuItem object.
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBoxForm dlg = new AboutBoxForm())
            {
                dlg.ShowDialog();
            }
        }

        #endregion


        #region Left side-panel

        /// <summary>
        /// Handles the SelectedIndexChanged event of tabControl object.
        /// </summary>
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage selectedTab = tabControl.SelectedTab;
            VisualTool newTool = _annotationAndTextSelectionTool;

            if (selectedTab == bookmarksTabPage)
            {
                if (documentBookmarks.Document == null)
                    documentBookmarks.Document = _document;
            }
            else if (selectedTab == imageFormExtractionTabPage)
            {
                _contentXObjectToolAction.Activate();
                UpdateUI();
                return;
            }

            if (newTool.ImageViewer != imageViewer1)
                imageViewer1.VisualTool = newTool;

            // update the UI
            UpdateUI();
        }

        #endregion


        #region Bottom panel

        /// <summary>
        /// Handles the Click event of runtimeMessagesLabel object.
        /// </summary>
        private void runtimeMessagesLabel_Click(object sender, EventArgs e)
        {
            // show document runtime messages
            using (PdfDocumentMessagesForm dlg = new PdfDocumentMessagesForm(_document.GetAllRuntimeMessages()))
            {
                dlg.ShowDialog();
            }
        }

        #endregion


        #region Image viewer

        /// <summary>
        /// Handles the ImageLoading event of imageViewer1 object.
        /// </summary>
        private void imageViewer1_ImageLoading(object sender, ImageLoadingEventArgs e)
        {
            StartAction("Rendering", false);
        }

        /// <summary>
        /// Handles the ImageLoaded event of imageViewer1 object.
        /// </summary>
        private void imageViewer1_ImageLoaded(object sender, ImageLoadedEventArgs e)
        {
            EndAction();
            UpdatePdfPageInfo();
        }

        /// <summary>
        /// Handles the ImageLoadingException event of imageViewer1 object.
        /// </summary>
        private void imageViewer1_ImageLoadingException(object sender, ExceptionEventArgs e)
        {
            EndAction();
            UpdatePdfPageInfo();
            MessageBox.Show(e.Exception.Message, "Image loading exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Handles the FocusedIndexChanging event of imageViewer1 object.
        /// </summary>
        private void imageViewer1_FocusedIndexChanging(object sender, FocusedIndexChangedEventArgs e)
        {
            if (_clearPdfDocumentRuntimeMessages)
                _document.ClearRuntimeMessages();
        }

        /// <summary>
        /// Handles the FocusedIndexChanged event of imageViewer1 object.
        /// </summary>
        private void imageViewer1_FocusedIndexChanged(object sender, FocusedIndexChangedEventArgs e)
        {
            _clearPdfDocumentRuntimeMessages = true;
        }

        /// <summary>
        /// Handles the Scroll event of imageViewer1 object.
        /// </summary>
        private void imageViewer1_Scroll(object sender, ScrollEventArgs e)
        {
            // if thumbnail must be changed
            if (_changeFocusedImageWhenImageViewerScrolled)
            {
                // find nearest image to the image viewer center
                VintasoftImage newFocusedImage = imageViewer1.GetNearestImage(new Point(imageViewer1.Width / 2, imageViewer1.Height / 2));
                // if image is found
                if (newFocusedImage != null)
                {
                    // get image index
                    int newFocusedIndex = imageViewer1.Images.IndexOf(newFocusedImage);
                    if (newFocusedIndex != -1 && newFocusedIndex != imageViewer1.FocusedIndex)
                    {
                        // set new focused index
                        imageViewer1.AutoScroll = false;
                        imageViewer1.FocusedIndex = newFocusedIndex;
                        imageViewer1.AutoScroll = true;
                    }
                }
            }
        }

        #endregion


        #region Thumbnail viewer

        /// <summary>
        /// Handles the ThumbnailsLoadingProgress event of thumbnailViewer1 object.
        /// </summary>
        private void thumbnailViewer1_ThumbnailsLoadingProgress(object sender, ThumbnailsLoadingProgressEventArgs e)
        {
            SetProgressInfo("Adding thumbnails:", e.Progress);
        }

        #endregion


        #region Visual tools

        #region Text selection tool

        /// <summary>
        /// Handles the TextSearchingProgress event of TextSelectionTool object.
        /// </summary>
        private void TextSelectionTool_TextSearchingProgress(object sender, TextSearchingProgressEventArgs e)
        {
            // show search status
            statusLabel.Text = string.Format("Search on page {0}...", e.ImageIndex + 1);
            Application.DoEvents();
        }

        /// <summary>
        /// Handles the TextExtractionProgress event of TextSelectionTool object.
        /// </summary>
        private void TextSelectionTool_TextExtractionProgress(object sender, ProgressEventArgs e)
        {
            // show status
            if (e.Progress == 100)
            {
                statusLabel.Text = "";
            }
            else
            {
                statusLabel.Text = string.Format("Extracting text {0}%...", e.Progress);
                Application.DoEvents();
            }
        }

        /// <summary>
        /// Handles the TextSearched event of TextSelectionTool object.
        /// </summary>
        private void TextSelectionTool_TextSearched(object sender, TextSearchedEventArgs e)
        {
            statusLabel.Text = "";
        }

        #endregion


        #region Image extractor tool

        /// <summary>
        /// Handles the Activated event of imageExtractorTool object.
        /// </summary>
        private void imageExtractorTool_Activated(object sender, EventArgs e)
        {
            pdfContentXObjectControl1.ContentXObjectTool =
                (PdfContentXObjectTool)_contentXObjectToolAction.VisualTool;

            tabControl.SelectedTab = imageFormExtractionTabPage;
        }

        #endregion


        #region Annotation tool

        /// <summary>
        /// Handles the MouseDown event of AnnotationTool object.
        /// </summary>
        private void AnnotationTool_MouseDown(object sender, VisualToolMouseEventArgs e)
        {
            // if left mouse button is down
            if (!e.Handled && e.Button == MouseButtons.Left)
            {
                // if tool uses View or Markup mode
                if (_annotationTool.InteractionMode == PdfAnnotationInteractionMode.View ||
                    _annotationTool.InteractionMode == PdfAnnotationInteractionMode.Markup)
                {
                    // get focused annotation view
                    PdfAnnotationView focusedView = _annotationTool.FindAnnotationView(e.X, e.Y);
                    // if focused annotation view is Signature Field
                    if (focusedView is PdfSignatureWidgetAnnotationView)
                    {
                        PdfSignatureWidgetAnnotationView signatureView = (PdfSignatureWidgetAnnotationView)focusedView;
                        // verify signature
                        using (DocumentSignaturesForm dialog = new DocumentSignaturesForm(signatureView.Field.Document))
                        {
                            dialog.SelectedSignatureField = (PdfInteractiveFormSignatureField)signatureView.Field;
                            dialog.ShowDialog();
                        }
                        e.Handled = true;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the HoveredAnnotationChanged event of AnnotationTool object.
        /// </summary>
        private void AnnotationTool_HoveredAnnotationChanged(object sender, PdfAnnotationEventArgs e)
        {
            // update information about hovered annotation
            if (e.Annotation != null)
                statusLabel.Text = PdfActionsTools.GetActivateActionDescription(e.Annotation);
            else
                statusLabel.Text = "";
        }

        /// <summary>
        /// Handles the ActiveInteractionControllerChanged event of AnnotationTool object.
        /// </summary>
        private void AnnotationTool_ActiveInteractionControllerChanged(object sender, PropertyChangedEventArgs<IInteractionController> e)
        {
            _textSelectionTool.FocusedTextSymbol = null;

            // get text box transformer of old text object
            TextObjectTextBoxTransformer oldTextObjectTextBoxTransformer = GetTextObjectTextBoxTransformer(e.OldValue);
            if (oldTextObjectTextBoxTransformer != null)
            {
                // unsubscribe from text object transformer events

                oldTextObjectTextBoxTransformer.TextBoxShown -= TextObjectTextBoxTransformer_TextBoxShown;
                oldTextObjectTextBoxTransformer.TextBoxClosed -= TextObjectTextBoxTransformer_TextBoxClosed;
            }

            // get text box transformer of new text object
            TextObjectTextBoxTransformer newTextObjectTextBoxTransformer = GetTextObjectTextBoxTransformer(e.NewValue);
            if (newTextObjectTextBoxTransformer != null)
            {
                // subscribe to text object transformer events

                newTextObjectTextBoxTransformer.TextBoxShown +=
                    new EventHandler<TextObjectTextBoxTransformerEventArgs>(TextObjectTextBoxTransformer_TextBoxShown);
                newTextObjectTextBoxTransformer.TextBoxClosed +=
                    new EventHandler<TextObjectTextBoxTransformerEventArgs>(TextObjectTextBoxTransformer_TextBoxClosed);
            }
        }

        #endregion


        #region Annotation and text selection tool

        /// <summary>
        /// Handles the Activated event of annotationAndTextSelectionTool object.
        /// </summary>
        private void annotationAndTextSelectionTool_Activated(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == imageFormExtractionTabPage)
                tabControl.SelectedTab = textRegionTabPage;
        }

        #endregion

        #endregion

        #endregion


        #region UI state

        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            // get the current status of application

            bool isPdfFileOpening = IsPdfFileOpening;
            bool isPdfFileOpened = _document != null;
            bool isPdfFileEmpty = true;
            bool isFindText = findTextToolStrip1.IsTextSearching;
            bool isContainsOptionalContent = false;
            if (isPdfFileOpened)
            {
                isContainsOptionalContent = _document.OptionalContentProperties != null;
            }

            bool isContainsDigitalSignatures = false;
            if (isPdfFileOpened)
            {
                isPdfFileEmpty = _document.Pages.Count <= 0;
                try
                {
                    isContainsDigitalSignatures = _document.InteractiveForm != null &&
                        _document.InteractiveForm.GetTerminalFields().Length > 0;
                }
                catch
                {
                }
            }

            // "File" menu
            fileToolStripMenuItem.Enabled = !isPdfFileOpening;
            openToolStripMenuItem.Enabled = !isFindText;
            printToolStripMenuItem.Enabled = isPdfFileOpened && !isPdfFileEmpty;

            // "Edit" menu
            findTextToolStripMenuItem.Enabled = isPdfFileOpened && !isPdfFileOpening && !isFindText;

            // "View" menu
            customRendererSettingsToolStripMenuItem.Enabled = useCustomRendererToolStripMenuItem.Checked;

            // update "View => Image Display Mode" menu
            singlePageToolStripMenuItem.Checked = false;
            twoColumnsToolStripMenuItem.Checked = false;
            singleContinuousRowToolStripMenuItem.Checked = false;
            singleContinuousColumnToolStripMenuItem.Checked = false;
            twoContinuousRowsToolStripMenuItem.Checked = false;
            twoContinuousColumnsToolStripMenuItem.Checked = false;
            switch (imageViewer1.DisplayMode)
            {
                case ImageViewerDisplayMode.SinglePage:
                    singlePageToolStripMenuItem.Checked = true;
                    break;

                case ImageViewerDisplayMode.TwoColumns:
                    twoColumnsToolStripMenuItem.Checked = true;
                    break;

                case ImageViewerDisplayMode.SingleContinuousRow:
                    singleContinuousRowToolStripMenuItem.Checked = true;
                    break;

                case ImageViewerDisplayMode.SingleContinuousColumn:
                    singleContinuousColumnToolStripMenuItem.Checked = true;
                    break;

                case ImageViewerDisplayMode.TwoContinuousRows:
                    twoContinuousRowsToolStripMenuItem.Checked = true;
                    break;

                case ImageViewerDisplayMode.TwoContinuousColumns:
                    twoContinuousColumnsToolStripMenuItem.Checked = true;
                    break;
            }

            // "Document" menu
            documentToolStripMenuItem.Enabled = isPdfFileOpened && !isPdfFileOpening;
            embeddedFilesToolStripMenuItem.Enabled = !isPdfFileEmpty;
            imageResourcesToolStripMenuItem.Enabled = !isPdfFileEmpty;
            fontsToolStripMenuItem.Enabled = !isPdfFileEmpty;
            pageToolStripMenuItem.Enabled = !isPdfFileEmpty;
            optionalContentToolStripMenuItem.Enabled = isContainsOptionalContent;
            signaturesToolStripMenuItem.Enabled = isContainsDigitalSignatures;
            attachmentsPortfolioToolStripMenuItem.Enabled = isPdfFileOpened && _document.Attachments != null;


            // rendering DPI
            resolutionToolStrip1.Enabled = isPdfFileOpened && !isPdfFileOpening;

            // pages & bookmarks & text region
            tabControl.Enabled = isPdfFileOpened && !isPdfFileOpening;

            // viewer
            viewerToolStrip.Enabled = !isPdfFileOpening;
            viewerToolStrip.PrintButtonEnabled = isPdfFileOpened;
        }

        #endregion


        #region Init

        /// <summary>
        /// Initializes the dialogs.
        /// </summary>
        private void InitDialogs()
        {
            // set filters in save dialog
            CodecsFileFilters.SetSaveFileDialogFilter(saveFileDialog1, false, false);

            // set the initial directory in open file dialog
            DemosTools.SetTestFilesFolder(openFileDialog);
        }

        /// <summary>
        /// Initializes the visual tools.
        /// </summary>
        private void InitVisualTools()
        {
            // create PdfTextSelectionTool
            _textSelectionTool = new TextSelectionTool(new SolidBrush(Color.FromArgb(56, Color.Blue)));
            _textSelectionTool.IsMouseSelectionEnabled = true;
            _textSelectionTool.IsKeyboardSelectionEnabled = true;
            _textSelectionTool.TextSearchingProgress += new EventHandler<TextSearchingProgressEventArgs>(TextSelectionTool_TextSearchingProgress);
            _textSelectionTool.TextExtractionProgress += new EventHandler<ProgressEventArgs>(TextSelectionTool_TextExtractionProgress);
            _textSelectionTool.TextSearched += new EventHandler<TextSearchedEventArgs>(TextSelectionTool_TextSearched);
            findTextToolStrip1.TextSelectionTool = _textSelectionTool;
            pdfTextSelectionControl1.TextSelectionTool = _textSelectionTool;

            // create ScrollPages
            _scrollPages = new ScrollPages();
            _scrollPages.ScrollStep = 30;

            // create PdfAnnotationTool
            _annotationTool = new PdfAnnotationTool(PdfJavaScriptManager.JsApp, false);
            _annotationTool.ChangeFocusedItemBeforeInteraction = true;
            _annotationTool.InteractionMode = PdfAnnotationInteractionMode.View;
            _annotationTool.HoveredAnnotationChanged += new EventHandler<PdfAnnotationEventArgs>(AnnotationTool_HoveredAnnotationChanged);
            _annotationTool.ActiveInteractionControllerChanged += new PropertyChangedEventHandler<IInteractionController>(AnnotationTool_ActiveInteractionControllerChanged);
            _annotationTool.MouseDown += new VisualToolMouseEventHandler(AnnotationTool_MouseDown);

            // init spell checker for PdfAnnotationTool
            _annotationTool.SpellChecker = SpellCheckTools.CreateSpellCheckManager();

            // create composite tool: Annotation tool + Text Selection tool
            _annotationAndTextSelectionTool = new CompositeVisualTool(_annotationTool, _textSelectionTool, _scrollPages);
        }


        /// <summary>
        /// Initializes the visual tool actions.
        /// </summary>
        private void InitializeVisualToolActions()
        {
            visualToolsToolStrip1.AddAction(new SeparatorToolStripAction());

            VisualToolAction annotationAndTextSelectionToolAction = new VisualToolAction(
                _annotationAndTextSelectionTool,
                "Text selection / Navigation / Fill Forms / Scroll Pages",
                "Text selection, Navigation, Form Filling, Scroll Pages",
                DemosResourcesManager.GetResourceAsBitmap("TextSelectionFillForms.png"));
            annotationAndTextSelectionToolAction.Activated += new EventHandler(annotationAndTextSelectionTool_Activated);
            visualToolsToolStrip1.AddAction(annotationAndTextSelectionToolAction);

            _contentXObjectToolAction = new PdfContentXObjectToolAction(
                new PdfContentXObjectTool(),
                "Image or Form Extraction",
                "Extract Images or Forms from Pages",
                DemosResourcesManager.GetResourceAsBitmap("ImageExtraction.png"));
            _contentXObjectToolAction.Activated += new EventHandler(imageExtractorTool_Activated);
            visualToolsToolStrip1.AddAction(_contentXObjectToolAction);
        }

        /// <summary>
        /// Initializes the PDF action executors.
        /// </summary>
        private void InitPdfActionExecutors()
        {
            // enable JavaScript
            PdfJavaScriptManager.IsJavaScriptEnabled = true;
            enableJavaScriptExecutingToolStripMenuItem.Checked = PdfJavaScriptManager.IsJavaScriptEnabled;
            // register image viewer in JavaScript manager
            PdfJavaScriptManager.JsApp.RegisterImageViewer(imageViewer1);
            PdfJavaScriptManager.JavaScriptActionExecutor.StatusChanged +=
                new EventHandler<PdfJavaScriptActionStatusChangedEventArgs>(JavaScriptActionExecutor_StatusChanged);

            // initialize application action executor
            PdfActionExecutorManager.Initialize(
                imageViewer1,
                _annotationTool,
                new PdfViewerNamedAction("Print", PrintPdfDocument));

            // create document-level actions executor
            PdfDocumentLevelActionsExecutor documentLevelActionsExecutor =
                new PdfDocumentLevelActionsExecutor(PdfJavaScriptManager.JsApp);

            // set action executor for PdfDocumentLevelActionsExecutor to application action executor
            documentLevelActionsExecutor.ActionExecutor = PdfActionExecutorManager.ApplicationActionExecutor;

            // set action executor for PdfAnnotationTool to application action executor
            _annotationTool.ActionExecutor = PdfActionExecutorManager.ApplicationActionExecutor;

            // set action executor for BookmarkTreeView to application action executor
            documentBookmarks.ActionExecutor = PdfActionExecutorManager.ApplicationActionExecutor;
        }

        #endregion


        #region 'Edit' Menu

        /// <summary>
        /// Updates the "Edit" menu items.
        /// </summary>
        private void UpdateEditMenuItems()
        {
            UpdateEditMenuItem(copyToolStripMenuItem, PdfDemosTools.GetUIAction<CopyItemUIAction>(CurrentTool), "Copy");
            UpdateEditMenuItem(selectAllToolStripMenuItem, PdfDemosTools.GetUIAction<SelectAllItemsUIAction>(CurrentTool), "Select All");
        }

        /// <summary>
        /// Disables the "Edit" menu items.
        /// </summary>
        private void DisableEditMenuItems()
        {
            copyToolStripMenuItem.Enabled = false;
            selectAllToolStripMenuItem.Enabled = false;
        }

        /// <summary>
        /// Enables the "Edit" menu items.
        /// </summary>
        private void EnableEditMenuItems()
        {
            copyToolStripMenuItem.Enabled = true;
            selectAllToolStripMenuItem.Enabled = true;
        }

        /// <summary>
        /// Updates the "Edit" menu item.
        /// </summary>
        /// <param name="menuItem">The menu item.</param>
        /// <param name="action">The action.</param>
        /// <param name="defaultText">The default text of the menu item.</param>
        private void UpdateEditMenuItem(
            ToolStripMenuItem menuItem,
            UIAction action,
            string defaultText)
        {
            if (action != null && action.IsEnabled)
            {
                menuItem.Enabled = true;
                menuItem.Text = action.Name;
            }
            else
            {
                menuItem.Enabled = false;
                menuItem.Text = defaultText;
            }
        }

        #endregion


        #region PDF document manipulation

        /// <summary>
        /// Opens a PDF document.
        /// </summary>
        /// <param name="filename">Filename of the document.</param>
        private void OpenPdfDocument(string filename)
        {
            IsPdfFileOpening = true;

            try
            {
                ClosePdfDocument();
                try
                {
                    _pdfFileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);

                    // create PDF document
                    _document = PdfDocumentController.OpenDocument(_pdfFileStream);

                    // check authorization if document is encrypted
                    if (_document.IsEncrypted &&
                        _document.AuthorizationResult == AuthorizationResult.IncorrectPassword)
                    {
                        ClosePdfDocument();
                        return;
                    }

                    if (imageViewer1.ImageRenderingSettings is PdfRenderingSettings)
                    {
                        // set rendering settings
                        ((PdfRenderingSettings)imageViewer1.ImageRenderingSettings).UseEmbeddedThumbnails = UseEmbeddedThumbnails;
                        _document.RenderingSettings = (PdfRenderingSettings)imageViewer1.ImageRenderingSettings.Clone();
                    }

                    _document.RenderingSettings.DrawPdfAnnotations = true;
                    _document.RenderingSettings.DrawVintasoftAnnotations = true;
                    _document.RenderingSettings.UseEmbeddedThumbnails = UseEmbeddedThumbnails;
                    _pdfFileStream.Position = 0;
                    if (tabControl.SelectedTab == bookmarksTabPage)
                        documentBookmarks.Document = _document;
                    try
                    {
                        // add images to image viewer
                        imageViewer1.Images.Add(_pdfFileStream);
                    }
                    catch (Exception ex)
                    {
                        DemosTools.ShowErrorMessage(ex);
                        ClosePdfDocument();
                        IsPdfFileOpening = false;
                        return;
                    }
                    _clearPdfDocumentRuntimeMessages = false;

                    // change application's title
                    Text = string.Format(_titlePrefix, string.Format("- {0}", Path.GetFileName(openFileDialog.FileName)));
                    if (_document.IsEncrypted)
                        Text += " (SECURED)";
                    PdfDocumentConformance documentConformance = _document.GetDocumentConformance();
                    if (documentConformance != PdfDocumentConformance.Undefined)
                    {
                        Text += string.Format(" ({0})", PdfEncoderSettingsForm.ConvertToString(documentConformance));
                    }
                }
                catch (Exception ex)
                {
                    Text = string.Format(_titlePrefix, "");
                    if (_pdfFileStream != null)
                    {
                        _pdfFileStream.Close();
                        _pdfFileStream.Dispose();
                        _pdfFileStream = null;
                    }
                    _document = null;
                    DemosTools.ShowErrorMessage(ex);
                }
            }
            finally
            {
                IsPdfFileOpening = false;
            }

            if (_document != null)
            {
                // if document contains visible attachments
                if (_document.Attachments != null && _document.Attachments.View != AttachmentCollectionViewMode.Hidden)
                {
                    using (AttachmentsEditorForm dialog = new AttachmentsEditorForm(_document))
                    {
                        dialog.IsReadOnly = true;
                        dialog.ShowDialog();
                    }
                }

                // set the display mode of image viewer
                if (_document.ViewerPageLayout == PdfDocumentPageLayoutMode.Undefined)
                    imageViewer1.DisplayMode = _defaultImageViewerDisplayMode;
                else
                    imageViewer1.DisplayMode = PdfDemosTools.ConvertPageLayoutModeToImageViewerDisplayMode(_document.ViewerPageLayout);
                UpdateUI();

                imageViewer1.Focus();
            }
        }

        /// <summary>
        /// Prints a PDF document.
        /// </summary>
        private void PrintPdfDocument()
        {
            _thumbnailViewerPrintManager.Print();
        }

        /// <summary>
        /// Closes opened PDF document.
        /// </summary>
        private void ClosePdfDocument()
        {
            if (imageViewer1.Images.Count > 0)
            {
                imageViewer1.Images.ClearAndDisposeItems();
            }
            if (_document != null)
            {
                PdfDocumentController.CloseDocument(_document);
                _document = null;
                documentBookmarks.Document = null;
            }
            if (_pdfFileStream != null)
            {
                _pdfFileStream.Close();
                _pdfFileStream.Dispose();
                _pdfFileStream = null;
            }
            Text = string.Format(_titlePrefix, "");

            _showCJKFontMissingErrorMessage = false;
        }


        /// <summary>
        /// Shows information about focused PDF page.
        /// </summary>
        private void UpdatePdfPageInfo()
        {
            VintasoftImage vsImage = imageViewer1.Image;
            if (vsImage.IsBad)
            {
                imageInfoLabel.Text = "Bad image.";
            }
            else
            {
                imageInfoLabel.Text = string.Format("Width={0}; Height={1}; Resolution={2}", vsImage.Width, vsImage.Height, vsImage.Resolution);
                if (vsImage.LoadingError)
                {
                    imageInfoLabel.Text = string.Format("[Loading error: {0}] {1}", DemosTools.GetShortLoadingErrorString(vsImage), imageInfoLabel.Text);
                }
                if (_document != null)
                {
                    PdfRuntimeMessage[] runtimeMessages = _document.GetAllRuntimeMessages();
                    if (runtimeMessages.Length == 0)
                        runtimeMessagesLabel.Visible = false;
                    else
                    {
                        runtimeMessagesLabel.Visible = true;
                        runtimeMessagesLabel.Text = string.Format("Messages ({0})", runtimeMessages.Length);

                        // if font missing error is not shown
                        if (!_showCJKFontMissingErrorMessage)
                        {
                            // for each message
                            foreach (PdfRuntimeMessage runtimeMessage in runtimeMessages)
                            {
                                // if message is an error
                                if (runtimeMessage is PdfRuntimeError)
                                {
                                    // if message contains information about missing CJK font
                                    if (runtimeMessage.InnerException is CJKFontProgramNotFoundException)
                                    {
                                        // show error message
                                        DemosTools.ShowErrorMessage(runtimeMessage.Message);
                                        // specify that error message is shown
                                        _showCJKFontMissingErrorMessage = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion


        #region View Rotation

        /// <summary>
        /// Rotates images in both annotation viewer and thumbnail viewer by 90 degrees clockwise.
        /// </summary>
        private void RotateViewClockwise()
        {
            if (imageViewer1.ImageRotationAngle != 270)
            {
                imageViewer1.ImageRotationAngle += 90;
                thumbnailViewer1.ImageRotationAngle += 90;
            }
            else
            {
                imageViewer1.ImageRotationAngle = 0;
                thumbnailViewer1.ImageRotationAngle = 0;
            }
        }

        /// <summary>
        /// Rotates images in both annotation viewer and thumbnail viewer by 90 degrees counterclockwise.
        /// </summary>
        private void RotateViewCounterClockwise()
        {
            if (imageViewer1.ImageRotationAngle != 0)
            {
                imageViewer1.ImageRotationAngle -= 90;
                thumbnailViewer1.ImageRotationAngle -= 90;
            }
            else
            {
                imageViewer1.ImageRotationAngle = 270;
                thumbnailViewer1.ImageRotationAngle = 270;
            }
        }

        #endregion


        #region Image Viewer

        /// <summary>
        /// Shows rendering settings dialog.
        /// </summary>
        private void SetRenderingSettings()
        {
            if (imageViewer1.ImageRenderingSettings is PdfRenderingSettings)
            {
                using (PdfRenderingSettingsForm renderingSettingsDialog =
                    new PdfRenderingSettingsForm((PdfRenderingSettings)imageViewer1.ImageRenderingSettings.Clone()))
                {
                    if (renderingSettingsDialog.ShowDialog() == DialogResult.OK)
                    {
                        imageViewer1.ImageRenderingSettings = renderingSettingsDialog.RenderingSettings;
                    }
                }
            }
            else
            {
                using (RenderingSettingsForm renderingSettingsDialog = new RenderingSettingsForm(imageViewer1.ImageRenderingSettings))
                {
                    if (renderingSettingsDialog.ShowDialog() == DialogResult.OK)
                    {
                        imageViewer1.ImageRenderingSettings = renderingSettingsDialog.RenderingSettings;
                    }
                }
            }
        }

        /// <summary>
        /// Reloads the images asynchronously.
        /// </summary>
        private void ReloadImagesAsync()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(ReloadImages);
        }

        /// <summary>
        /// Reloads the images.
        /// </summary>
        private void ReloadImages(object state)
        {
            VintasoftImage currentImage = imageViewer1.Image;
            try
            {
                if (currentImage != null)
                    currentImage.Reload(true);
            }
            catch
            {
            }
            foreach (VintasoftImage image in imageViewer1.Images)
            {
                if (currentImage != image)
                {
                    try
                    {
                        image.Reload(true);
                    }
                    catch
                    {
                    }
                }
            }
        }

        #endregion


        #region Annotation

        /// <summary>
        /// Returns the <see cref="Vintasoft.Imaging.UI.VisualTools.UserInteraction.TextObjectTextBoxTransformer"/>
        /// from <see cref="IInteractionController"/>.
        /// </summary>
        /// <param name="controller">The controller.</param>
        private TextObjectTextBoxTransformer GetTextObjectTextBoxTransformer(
            IInteractionController controller)
        {
            if (controller is TextObjectTextBoxTransformer)
                return (TextObjectTextBoxTransformer)controller;

            if (controller is CompositeInteractionController)
            {
                CompositeInteractionController compositeInteractionController = (CompositeInteractionController)controller;

                foreach (IInteractionController item in compositeInteractionController.Items)
                {
                    TextObjectTextBoxTransformer transformer = GetTextObjectTextBoxTransformer(item);
                    if (transformer != null)
                        return transformer;
                }
            }

            return null;
        }

        /// <summary>
        /// Text box of focused annotation is shown.
        /// </summary>
        private void TextObjectTextBoxTransformer_TextBoxShown(object sender, TextObjectTextBoxTransformerEventArgs e)
        {
            DisableEditMenuItems();
        }

        /// <summary>
        /// Text box of focused annotation is closed.
        /// </summary>
        private void TextObjectTextBoxTransformer_TextBoxClosed(object sender, TextObjectTextBoxTransformerEventArgs e)
        {
            EnableEditMenuItems();
        }

        #endregion


        #region Utils

        /// <summary>
        /// Shows the progress information.
        /// </summary>
        /// <param name="action">Action name.</param>
        /// <param name="progress">Current progress of the action.</param>
        private void SetProgressInfo(string action, int progress)
        {
            statusLabel.Text = action;
            progressBar1.Value = progress;
            progressBar1.Visible = true;
            if (progress == 100)
            {
                progressBar1.Visible = false;
                statusLabel.Text = "";
            }
        }

        /// <summary>
        /// Handles the StatusChanged event of the JavaScriptActionExecutor.
        /// </summary>
        private void JavaScriptActionExecutor_StatusChanged(
            object sender,
            PdfJavaScriptActionStatusChangedEventArgs e)
        {
            SetStatusLabelTextSafe(e.Status);
        }

        /// <summary>
        /// Sets a text of the status label (thread-safe).
        /// </summary>
        /// <param name="text">Status label text.</param>
        private void SetStatusLabelTextSafe(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new SetStatusLabelTextDelegate(SetStatusLabelTextSafe), text);
            }
            else
            {
                statusLabel.Text = text;
                statusStrip1.Refresh();
            }
        }


        #region Action

        /// <summary>
        /// Starts the action.
        /// </summary>
        /// <param name="actionName">Action name.</param>
        /// <param name="progress">A value indicating whether to show the action progress.</param>
        private void StartAction(string actionName, bool progress)
        {
            _actionStartTime = DateTime.Now;
            _actionName = actionName;

            if (progress)
                actionName += ":";
            else
                actionName += "...";

            SetStatusLabelTextSafe(actionName);
        }

        /// <summary>
        /// Ends the action.
        /// </summary>
        private void EndAction()
        {
            if (_actionName != "")
            {
                double ms = (DateTime.Now - _actionStartTime).TotalMilliseconds;
                string msString;
                if (ms < 1)
                    msString = "<1";
                else
                    msString = ms.ToString();
                SetStatusLabelTextSafe(string.Format("{0}: {1} ms", _actionName, msString));
                _actionName = "";
            }
        }

        #endregion

        #endregion

        #endregion

        #endregion



        #region Delegates

        /// <summary>
        /// The delegate for <see cref="SetStatusLabelTextSafe"/> method.
        /// </summary>
        delegate void SetStatusLabelTextDelegate(string text);

        #endregion

    }
}
