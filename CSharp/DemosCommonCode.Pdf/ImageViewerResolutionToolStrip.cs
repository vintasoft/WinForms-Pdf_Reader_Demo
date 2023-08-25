using System;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs.Decoders;
using Vintasoft.Imaging.ImageRendering;
using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.UI;

using DemosCommonCode.Imaging;
using System.ComponentModel;


namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// Tool strip that allows to changes rendering resolution of image viewer.
    /// </summary>
    public partial class ImageViewerResolutionToolStrip : ToolStrip
    {

        #region Constants

        const string DYNAMIC_RESOLUTION = "Dynamic DPI";

        const string CUSTOM_RESOLUTION = "Custom DPI...";

        #endregion



        #region Fields

        /// <summary>
        /// Deternines that image rendering settinsg is changing.
        /// </summary>
        bool _imageRenderingChanging = false;

        /// <summary>
        /// Previous image size when dynamic rendering was used.
        /// </summary>
        float _prevImageSize = 50f;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageViewerResolutionToolStrip"/> class.
        /// </summary>
        public ImageViewerResolutionToolStrip()
            : base()
        {
            InitializeComponent();

            // set of the default resolutions
            Resolutions = new int[] { 24, 48, 72, 96, 150, 192, 200, 300, 600 };
        }

        #endregion



        #region Properties

        ImageViewer _imageViewer = null;
        /// <summary>
        /// Gets or sets the image viewer.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>        
        public ImageViewer ImageViewer
        {
            get
            {
                return _imageViewer;
            }
            set
            {
                if (ImageViewer != null)
                {
                    ImageViewer.ImageRenderingSettingsChanging -= ImageViewer_ImageRenderingSettingsChanging;
                    ImageViewer.ImageRenderingSettingsChanged -= ImageViewer_ImageRenderingSettingsChanged;
                }

                _imageViewer = value;
                resolutionValueToolStripComboBox.Enabled = ImageViewer != null;

                if (ImageViewer != null)
                {
                    UpdateRenderingSettingsInImageViewer(ImageViewer);
                    ImageViewer.ImageRenderingSettingsChanging += new EventHandler(ImageViewer_ImageRenderingSettingsChanging);
                    ImageViewer.ImageRenderingSettingsChanged += new EventHandler(ImageViewer_ImageRenderingSettingsChanged);
                    if (ImageViewer.ImageRenderingSettings != null)
                        ImageViewer.ImageRenderingSettings.Changed += new EventHandler(ImageViewer_ImageRenderingSettings_Changed);
                }
            }
        }

        int[] _resolutions = null;
        /// <summary>
        /// Gets or sets the resolutions of tool strip.
        /// </summary>
        [Browsable(false)]
        [ReadOnly(true)]
        public int[] Resolutions
        {
            get
            {
                return _resolutions;
            }
            set
            {
                _resolutions = value;

                resolutionValueToolStripComboBox.BeginUpdate();
                try
                {
                    resolutionValueToolStripComboBox.Items.Clear();
                    // add resolutions
                    foreach (float resolution in _resolutions)
                        resolutionValueToolStripComboBox.Items.Add(string.Format("{0} DPI", resolution));

                    // add dynamic and custom resolution
                    resolutionValueToolStripComboBox.Items.Add(DYNAMIC_RESOLUTION);
                    resolutionValueToolStripComboBox.Items.Add(CUSTOM_RESOLUTION);

                    if (!_useDynamicRendering && ImageViewer != null)
                        UpdateRenderingSettingsInUI();
                }
                finally
                {
                    resolutionValueToolStripComboBox.EndUpdate();
                }
            }
        }

        bool _useDynamicRendering = false;
        /// <summary>
        /// Gets or sets a value indicating whether rendering is dynamic.
        /// </summary>
        /// <value>
        /// <b>True</b> if rendering is dynamic; otherwise, <b>false</b>.
        /// </value>
        [Browsable(false)]
        [ReadOnly(true)]
        public bool UseDynamicRendering
        {
            get
            {
                return _useDynamicRendering;
            }
            set
            {
                if (_useDynamicRendering != value)
                {
                    _useDynamicRendering = value;
                    if (_useDynamicRendering)
                    {
                        _imageRenderingChanging = true;
                        resolutionValueToolStripComboBox.SelectedItem = DYNAMIC_RESOLUTION;
                        _imageRenderingChanging = false;
                    }
                    else
                        UpdateRenderingSettingsInUI();

                    if (ImageViewer != null)
                        UpdateRenderingSettingsInImageViewer(ImageViewer);
                }
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Image viewer renderings settings is changing.
        /// </summary>
        private void ImageViewer_ImageRenderingSettingsChanging(object sender, EventArgs e)
        {
            if (ImageViewer.ImageRenderingSettings != null)
                ImageViewer.ImageRenderingSettings.Changed -= ImageViewer_ImageRenderingSettings_Changed;
        }

        /// <summary>
        /// Image viewer renderings settings are changed.
        /// </summary>
        private void ImageViewer_ImageRenderingSettingsChanged(object sender, EventArgs e)
        {
            if (ImageViewer.ImageRenderingSettings != null)
                ImageViewer.ImageRenderingSettings.Changed += new EventHandler(ImageViewer_ImageRenderingSettings_Changed);

            UpdateRenderingSettingsInUI();
        }

        /// <summary>
        /// Parameters of image rendering settings are changed.
        /// </summary>
        private void ImageViewer_ImageRenderingSettings_Changed(object sender, EventArgs e)
        {
            UpdateRenderingSettingsInUI();
        }

        /// <summary>
        /// PDF page resolution is changed.
        /// </summary>
        private void resolutionValueToolStripComboBox_SelectedIndexChanged(
            object sender,
            System.EventArgs e)
        {
            // if image rendering settings are changing
            if (_imageRenderingChanging)
                return;

            // specify that image rendering settings are changing
            _imageRenderingChanging = true;

            float resolution = 0;
            bool dynamicRendering = false;
            bool needSetResolution = true;

            // if dynamic rendering must be used
            if ((string)resolutionValueToolStripComboBox.SelectedItem == DYNAMIC_RESOLUTION)
            {
                dynamicRendering = true;
                needSetResolution = false;
            }
            // if custom resolution must be used
            else if ((string)resolutionValueToolStripComboBox.SelectedItem == CUSTOM_RESOLUTION)
            {
                RenderingSettings renderingSettings = (RenderingSettings)ImageViewer.ImageRenderingSettings.Clone();
                if (renderingSettings is PdfRenderingSettings)
                {
                    // Custom
                    using (PdfRenderingSettingsForm renderingSettingsDialog =
                        new PdfRenderingSettingsForm((PdfRenderingSettings)renderingSettings))
                    {
                        if (renderingSettingsDialog.ShowDialog() == DialogResult.OK)
                        {
                            ImageViewer.ImageRenderingSettings = renderingSettingsDialog.RenderingSettings;
                        }
                    }
                }
                else
                {
                    using (RenderingSettingsForm renderingSettingsDialog = new RenderingSettingsForm(renderingSettings))
                    {
                        if (renderingSettingsDialog.ShowDialog() == DialogResult.OK)
                        {
                            ImageViewer.ImageRenderingSettings = renderingSettingsDialog.RenderingSettings;
                        }
                    }
                }
                needSetResolution = false;
            }
            // if resolution form resolutions array must be used
            else
                // get resolution
                resolution = _resolutions[resolutionValueToolStripComboBox.SelectedIndex];

            UseDynamicRendering = dynamicRendering;
            // if image resolution must be updated
            if (needSetResolution)
            {
                // clone current rendering settings of image
                RenderingSettings settings = (RenderingSettings)ImageViewer.ImageRenderingSettings.Clone();
                // set resolution
                settings.Resolution = new Resolution(resolution, resolution);
                // set new rendering settings of image
                ImageViewer.ImageRenderingSettings = settings;
            }

            // specify that image rendering settings are changed
            _imageRenderingChanging = false;
        }


        /// <summary>
        /// Updates the rendering settings in image viewer.
        /// </summary>
        /// <param name="imageViewer">The image viewer.</param>
        private void UpdateRenderingSettingsInImageViewer(ImageViewer imageViewer)
        {
            float imageSize;
            if (_useDynamicRendering)
            {
                ImageRenderingRequirement renderingRequirements =
                     ImageViewer.RenderingRequirements.GetRequirement("Pdf");

                if (renderingRequirements != null &&
                    renderingRequirements is ImageSizeRenderingRequirement)
                    _prevImageSize = ((ImageSizeRenderingRequirement)renderingRequirements).ImageSize;

                imageSize = 0;
            }
            else
                imageSize = _prevImageSize;
            ImageViewer.RenderingRequirements.SetRequirement("Pdf", new ImageSizeRenderingRequirement(imageSize));
            ImageViewer.ReloadImage();
        }

        /// <summary>
        /// Updates the rendering settings in UI.
        /// </summary>
        private void UpdateRenderingSettingsInUI()
        {
            _imageRenderingChanging = true;

            // get current rendering settings from image viewer
            RenderingSettings renderingSettings = ImageViewer.ImageRenderingSettings;

            int selectedIndex = -1;

            if (renderingSettings != null)
            {
                // get resolution of rendering settings
                Resolution resolution = renderingSettings.Resolution;

                if (renderingSettings.IsEmpty)
                {
                    if (ImageViewer.Image != null)
                        resolution = ImageViewer.Image.Resolution;
                    else
                        resolution = new Resolution(96, 96);
                }

                if (resolution.Horizontal == resolution.Vertical)
                {
                    int res = (int)Math.Round(resolution.Horizontal);
                    // search index of resolution in resolutions array
                    selectedIndex = Array.IndexOf(_resolutions, res);
                }

                ImageRenderingRequirement renderingRequirements =
                     ImageViewer.RenderingRequirements.GetRequirement("Pdf");

                if (renderingRequirements != null &&
                    renderingRequirements is ImageSizeRenderingRequirement)
                {
                    float imageSize = ((ImageSizeRenderingRequirement)renderingRequirements).ImageSize;
                    if (imageSize == 0)
                        selectedIndex = resolutionValueToolStripComboBox.Items.IndexOf(DYNAMIC_RESOLUTION);
                }
            }

            // if resolution is not found in resolutions array
            if (selectedIndex == -1)
                resolutionValueToolStripComboBox.SelectedItem = CUSTOM_RESOLUTION;
            else
                resolutionValueToolStripComboBox.SelectedIndex = selectedIndex;

            _imageRenderingChanging = false;
        }

        #endregion

    }
}
