using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Content;
using Vintasoft.Imaging.Pdf.Tree;
using Vintasoft.Imaging.Pdf.UI;
using Vintasoft.Imaging.UI;
using Vintasoft.Imaging.UI.VisualTools;

using DemosCommonCode.Imaging;

namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A control that allows to extract image-resources or form-resources from PDF page.
    /// </summary>
    public partial class PdfContentXObjectControl : UserControl
    {

        #region Fields

        /// <summary>
        /// Determines that <see cref="ContentXObjectTool"/> is activated.
        /// </summary>
        bool _isVisualToolActivated = false;

        /// <summary>
        /// Determines that XObject is selected in image viewer.
        /// </summary>
        bool _isXObjectSelected = false;

        /// <summary>
        /// Determines that XObject, which is selected in visual tool, is changing.
        /// </summary>
        bool _isSelectedXObjectChanging = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfContentXObjectControl"/> class.
        /// </summary>
        public PdfContentXObjectControl()
        {
            InitializeComponent();

            UpdateUI();
        }

        #endregion



        #region Properties

        PdfContentXObjectTool _contentXObjectTool = null;
        /// <summary>
        /// Gets or sets the PDF XObject tool.
        /// </summary>
        /// <value>
        /// Default value is <b>null</b>.
        /// </value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PdfContentXObjectTool ContentXObjectTool
        {
            get
            {
                return _contentXObjectTool;
            }
            set
            {
                if (_contentXObjectTool == value)
                    return;

                if (_contentXObjectTool != null)
                    UnsubscribeFromVisualToolEvents(_contentXObjectTool);

                _contentXObjectTool = value;
                _isVisualToolActivated = false;

                if (_contentXObjectTool != null)
                    SubscribeToVisualToolEvents(_contentXObjectTool);

                UpdateXObjectsListBox();
                UpdateUI();
            }
        }

        bool _canEdit = true;
        /// <summary>
        /// Gets or sets a value indicating whether the control allows to remove XObjects.
        /// </summary>
        /// <value>
        /// <b>True</b> - the control allows to remove XObjects; otherwise, <b>false</b>.
        /// </value>
        [Description("Indicates that the control allows to remove XObjects.")]
        [DefaultValue(true)]
        public bool CanEdit
        {
            get
            {
                return _canEdit;
            }
            set
            {
                _canEdit = value;
                editGroupBox.Visible = _canEdit;
                removeConentXObjectToolStripMenuItem.Enabled = _canEdit;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Updates the user interface of this control.
        /// </summary>
        private void UpdateUI()
        {
            mainPanel.Enabled =
                _contentXObjectTool != null &&
                _contentXObjectTool.ImageViewer != null &&
                _contentXObjectTool.ImageViewer.Image != null &&
                PdfDocumentController.GetPageAssociatedWithImage(_contentXObjectTool.ImageViewer.Image) != null;

            if (mainPanel.Enabled)
            {
                PdfContentXObject xObject = GetSelectedContentXObject();
                bool xObjectIsSelected = false;
                if (xObject != null)
                    xObjectIsSelected = true;

                viewContentXObjectButton.Enabled = xObjectIsSelected;
                saveGroupBox.Enabled = xObjectIsSelected;

                if (xObjectIsSelected)
                    saveAsImageButton.Enabled = xObject.XObjectResource is PdfImageResource;
                else
                    saveAsImageButton.Enabled = true;

                removeContentXObjectButton.Enabled = xObjectIsSelected;
                replaceXObjectButton.Enabled = xObjectIsSelected;
                translateXObjectButton.Enabled = xObjectIsSelected;
                rotateXObjectButton.Enabled = xObjectIsSelected;
            }
        }

        /// <summary>
        /// Returns the description of content XObject.
        /// </summary>
        /// <param name="xObject">The content XObject.</param>
        /// <returns>The description of content XObject.</returns>
        private string GetXObjectDescription(PdfContentXObject xObject)
        {
            string result = string.Empty;

            PdfResource xObjectResource = xObject.XObjectResource;

            // if resource is image-resource
            if (xObjectResource is PdfImageResource)
            {
                PdfImageResource resource = (PdfImageResource)xObjectResource;
                // if resource is inline
                if (resource.IsInline)
                    result = "Inline, ";
                else
                {
                    result = string.Format(CultureInfo.InvariantCulture, "Image Resource {0,3}, ",
                       resource.ObjectNumber.ToString());
                }

                // size of resource
                result += string.Format(CultureInfo.InvariantCulture, "{0}x{1} px, ",
                    resource.Width, resource.Height);
                // resolution of resource
                result += string.Format(CultureInfo.InvariantCulture, "resolution={0:F0}x{1:F0} ",
                    xObject.RenderingResolution.Horizontal,
                    xObject.RenderingResolution.Vertical);
                // compression of resource
                result += string.Format(CultureInfo.InvariantCulture, "compression={0}, ", resource.Compression);
                // compressed size of resource
                result += string.Format(CultureInfo.InvariantCulture, "{0} bytes", resource.Length);
            }
            // if resource is Form XObject resource
            else if (xObjectResource is PdfFormXObjectResource)
            {
                PdfFormXObjectResource resource = (PdfFormXObjectResource)xObjectResource;
                result = string.Format(CultureInfo.InvariantCulture, "Form Resource {0,3}, ",
                    resource.ObjectNumber.ToString());

                // size of resource
                result += string.Format(CultureInfo.InvariantCulture, "{0}x{1} u, ",
                    resource.BoundingBox.Width, resource.BoundingBox.Height);
                // compression of resource
                result += string.Format(CultureInfo.InvariantCulture, "compression={0}, ", resource.Compression);
                // compressed size of resource
                result += string.Format(CultureInfo.InvariantCulture, "{0} bytes", resource.Length);
            }

            return result;
        }

        /// <summary>
        /// Returns the selected content XObject.
        /// </summary>
        /// <returns>The selected content XObject.</returns>
        private PdfContentXObject GetSelectedContentXObject()
        {
            if (_contentXObjectTool != null)
                return GetSelectedContentXObject(_contentXObjectTool.SelectedXObjects);

            return null;
        }

        /// <summary>
        /// Returns the last selected content XObject from the list.
        /// </summary>
        /// <param name="selectedXObjects">The list of XObjects.</param>
        /// <returns>The last selected content XObject from the list.</returns>
        private PdfContentXObject GetSelectedContentXObject(IList<PdfContentXObject> selectedXObjects)
        {
            if (selectedXObjects == null || selectedXObjects.Count == 0)
                return null;

            IList<PdfContentXObject> xObjects = _contentXObjectTool.XObjects;
            for (int i = 0; i < selectedXObjects.Count; i++)
            {
                if (xObjects.Contains(selectedXObjects[i]))
                    return selectedXObjects[i];
            }

            return null;
        }

        /// <summary>
        /// Sets the selected content XObject.
        /// </summary>
        /// <param name="obj">The XObjects.</param>
        private void SetSelectedContentXObject(params PdfContentXObject[] xObjects)
        {
            _contentXObjectTool.SelectedXObjects.Clear();

            if (xObjects != null && xObjects.Length > 0)
            {
                foreach (PdfContentXObject xObject in xObjects)
                    _contentXObjectTool.SelectedXObjects.Add(xObject);
            }
        }

        /// <summary>
        /// Updates the region information about XObject.
        /// </summary>
        /// <param name="xObject">The XObject.</param>
        private void UpdateRegionInfo(PdfContentXObject xObject)
        {
            string leftTopText = ConvertToString(System.Drawing.PointF.Empty);
            string leftBottomText = ConvertToString(System.Drawing.PointF.Empty);
            string rightTopText = ConvertToString(System.Drawing.PointF.Empty);
            string rightBottomText = ConvertToString(System.Drawing.PointF.Empty);

            if (xObject != null)
            {
                RegionF region = xObject.Region;
                leftTopText = ConvertToString(region.LeftTop);
                leftBottomText = ConvertToString(region.LeftBottom);
                rightTopText = ConvertToString(region.RightTop);
                rightBottomText = ConvertToString(region.RightBottom);
            }

            leftTopPointLabel.Text = leftTopText;
            leftBottomPointLabel.Text = leftBottomText;
            rightTopPointLabel.Text = rightTopText;
            rightBottomPointLabel.Text = rightBottomText;
        }

        /// <summary>
        /// Converts <see cref="System.Drawing.PointF"/> to string.
        /// </summary>
        /// <param name="point">The point.</param>
        private string ConvertToString(System.Drawing.PointF point)
        {
            string format = "0.000";
            return string.Format("({0};{1})",
                point.X.ToString(format, CultureInfo.InvariantCulture),
                point.Y.ToString(format, CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Determines that the <see cref="PdfFormXObjectResource"/> contains 
        /// the specified <see cref="PdfImageResource"/>.
        /// </summary>
        /// <param name="form">The <see cref="PdfFormXObjectResource"/>.</param>
        /// <param name="image">The <see cref="PdfImageResource"/>.</param>
        private bool FormContainsImageResource(PdfFormXObjectResource form, PdfImageResource image)
        {
            if (form.Resources != null && form.Resources.XObjectResources != null)
            {
                foreach (PdfResource resource in form.Resources.XObjectResources.Values)
                {
                    if (resource is PdfFormXObjectResource)
                    {
                        if (FormContainsImageResource((PdfFormXObjectResource)resource, image))
                            return true;
                    }

                    if (resource == image)
                        return true;
                }
            }

            return false;
        }


        #region ContentXObjectsListBox

        /// <summary>
        /// XObject is changed in list box.
        /// </summary>
        private void contentXObjectsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isSelectedXObjectChanging)
                return;

            _isSelectedXObjectChanging = true;

            PdfContentXObject selectedXObject = null;
            int index = contentXObjectsListBox.SelectedIndex;
            if (index != -1)
                selectedXObject = _contentXObjectTool.XObjects[index];
            SetSelectedContentXObject(selectedXObject);
            UpdateRegionInfo(selectedXObject);

            _isXObjectSelected = selectedXObject != null;
            _isSelectedXObjectChanging = false;

            UpdateUI();
        }

        /// <summary>
        /// XObject resource is clicked.
        /// </summary>
        private void contentXObjectsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PdfContentXObject contentXObject = GetSelectedContentXObject();
            if (contentXObject != null)
                ShowContentXObject(contentXObject);
        }

        /// <summary>
        /// Updates the XObjects in list box.
        /// </summary>
        private void UpdateXObjectsListBox()
        {
            if (_isSelectedXObjectChanging)
                return;

            contentXObjectsListBox.BeginUpdate();
            _isSelectedXObjectChanging = true;
            try
            {
                // clear items
                contentXObjectsListBox.Items.Clear();
                // if visual tool is activated
                if (_contentXObjectTool != null && _isVisualToolActivated)
                {
                    // get content XObjects of current PDF page
                    IList<PdfContentXObject> xObjects = _contentXObjectTool.XObjects;
                    // add all content XObjects
                    foreach (PdfContentXObject xObject in xObjects)
                        contentXObjectsListBox.Items.Add(GetXObjectDescription(xObject));

                    PdfContentXObject selectedObject = GetSelectedContentXObject();
                    contentXObjectsListBox.SelectedIndex = xObjects.IndexOf(selectedObject);
                    UpdateRegionInfo(selectedObject);
                }
            }
            finally
            {
                _isSelectedXObjectChanging = false;
                contentXObjectsListBox.EndUpdate();
            }
        }

        /// <summary>
        /// Updates the description of focused XObject.
        /// </summary>
        private void UpdateFocusedXObjectDescription()
        {
            int selectedIndex = contentXObjectsListBox.SelectedIndex;

            if (selectedIndex != -1)
            {
                PdfContentXObject selectedObject = GetSelectedContentXObject();
                contentXObjectsListBox.Items[selectedIndex] =
                    GetXObjectDescription(selectedObject);
            }
        }

        #endregion


        #region Buttons

        /// <summary>
        /// "View Content XObject" button is clicked.
        /// </summary>
        private void viewContentXObjectButton_Click(object sender, EventArgs e)
        {
            PdfContentXObject selectedObject = GetSelectedContentXObject();
            ShowContentXObject(selectedObject);
        }

        /// <summary>
        /// Shows the content XObject.
        /// </summary>
        /// <param name="xObject">The XObject.</param>
        private void ShowContentXObject(PdfContentXObject xObject)
        {
            PdfResource resource = xObject.XObjectResource;

            using (PdfResourcesViewerForm form = new PdfResourcesViewerForm(resource.Document, resource))
            {
                form.StartPosition = FormStartPosition.CenterParent;
                form.Owner = this.ParentForm;

                form.ShowDialog();

                if (form.PropertyValueChanged)
                {
                    UpdateFocusedXObjectDescription();

                    if (resource is PdfImageResource)
                        _contentXObjectTool.ImageViewer.ReloadImage();
                }
            }
        }

        /// <summary>
        /// "Save As Binary Data" button is clicked.
        /// </summary>
        private void saveContentXObjectAsBinaryDataButton_Click(object sender, EventArgs e)
        {
            PdfContentXObject xObject = GetSelectedContentXObject();

            SaveContentXObjectAsBinary(xObject);
        }

        /// <summary>
        /// Saves the content XObject as binary.
        /// </summary>
        /// <param name="xObject">The XObject for saving.</param>
        private void SaveContentXObjectAsBinary(PdfContentXObject xObject)
        {
            saveFileDialog1.Filter = "Binary Files|*.bin";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PdfResource resource = xObject.XObjectResource;
                byte[] resourceBytes = resource.GetBytes();

                File.WriteAllBytes(saveFileDialog1.FileName, resourceBytes);
            }
        }

        /// <summary>
        /// "Save As Binary" button is clicked.
        /// </summary>
        private void saveContentXObjectAsImageButton_Click(object sender, EventArgs e)
        {
            PdfContentXObject xObject = GetSelectedContentXObject();

            SaveContentXObjectAsImage(xObject);
        }

        /// <summary>
        /// Saves the content XObject as image.
        /// </summary>
        /// <param name="xObject">The XObject for saving.</param>
        private void SaveContentXObjectAsImage(PdfContentXObject xObject)
        {
            PdfImageResource resourceStream = (PdfImageResource)xObject.XObjectResource;

            using (VintasoftImage image = resourceStream.GetImage())
            {
                SaveImageFileForm.SaveImageToFile(
                    image, 
                    DemosCommonCode.Imaging.Codecs.PluginsEncoderFactory.Default);
            }
        }

        /// <summary>
        /// "Remove" button is clicked.
        /// </summary>
        private void removeButton_Click(object sender, EventArgs e)
        {
            PdfContentXObject xObject = GetSelectedContentXObject();
            RemoveXObject(xObject);
        }

        /// <summary>
        /// Select resource from document and replaces XObject to selected resource.
        /// </summary>
        private void replaceXObjectButton_Click(object sender, EventArgs e)
        {
            PdfContentXObject xObject = GetSelectedContentXObject();

            using (PdfResourcesViewerForm resourcesViewerDialog = new PdfResourcesViewerForm(xObject.XObjectResource.Document, true))
            {
                resourcesViewerDialog.StartPosition = FormStartPosition.CenterParent;
                resourcesViewerDialog.Owner = this.ParentForm;

                if (resourcesViewerDialog.ShowDialog() == DialogResult.OK)
                {
                    PdfResource resource = resourcesViewerDialog.SelectedResource;
                    if (resource != null)
                    {
                        try
                        {
                            _contentXObjectTool.SetXObjectResource(xObject, resource);
                            _contentXObjectTool.ImageViewer.ReloadImage();
                        }
                        catch (Exception ex)
                        {
                            DemosTools.ShowErrorMessage(ex);
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Translates focused XObject.
        /// </summary>
        private void translateXObjectButton_Click(object sender, EventArgs e)
        {
            PdfContentXObject xObject = GetSelectedContentXObject();
            PointF translateVector = new PointF((float)translateXNumericUpDown.Value, (float)translateYNumericUpDown.Value);
            translateVector = PointFAffineTransform.TransformVector(AffineMatrix.Invert(xObject.CTM), translateVector);
            TransformXObject(xObject, AffineMatrix.CreateTranslation(translateVector.X, translateVector.Y));
        }

        /// <summary>
        /// Rotates focused XObject.
        /// </summary>
        private void rotateXObjectButton_Click(object sender, EventArgs e)
        {
            PdfContentXObject xObject = GetSelectedContentXObject();
            AffineMatrix transform = new AffineMatrix();
            double centerX = 0;
            double centerY = 0;
            if (xObject.XObjectResource is PdfImageResource)
            {
                centerX = 0.5;
                centerY = 0.5;
            }
            else if (xObject.XObjectResource is PdfFormXObjectResource)
            {
                RectangleF formBBox = ((PdfFormXObjectResource)xObject.XObjectResource).BoundingBox;
                centerX = formBBox.X + formBBox.Width / 2;
                centerY = formBBox.Y + formBBox.Height / 2;
            }
            transform.RotateAt((double)rotationAngleNumericUpDown.Value, centerX, centerY);
            TransformXObject(xObject, transform);
        }

        /// <summary>
        /// Transforms the XObject use secified transform.
        /// </summary>
        /// <param name="xObject">The XObject.</param>
        /// <param name="transform">The transform.</param>
        private void TransformXObject(PdfContentXObject xObject, AffineMatrix transform)
        {
            _contentXObjectTool.TransformXObject(xObject, transform);
            _contentXObjectTool.ImageViewer.ReloadImage();
        }

        /// <summary>
        /// Removes the XObject.
        /// </summary>
        /// <param name="xObject">The XObject.</param>
        private void RemoveXObject(PdfContentXObject xObject)
        {
            contentXObjectsListBox.BeginUpdate();
            _isSelectedXObjectChanging = true;
            int selectedIndex = contentXObjectsListBox.SelectedIndex;

            _contentXObjectTool.RemoveXObject(xObject);
            _contentXObjectTool.SelectedXObjects.Clear();
            _contentXObjectTool.ImageViewer.ReloadImage();

            contentXObjectsListBox.Items.RemoveAt(selectedIndex);
            if (selectedIndex >= contentXObjectsListBox.Items.Count)
                selectedIndex = contentXObjectsListBox.Items.Count - 1;
            contentXObjectsListBox.SelectedIndex = selectedIndex;
            PdfContentXObject selectedXObject = null;
            if (selectedIndex != -1)
                selectedXObject = _contentXObjectTool.XObjects[selectedIndex];
            UpdateRegionInfo(selectedXObject);
            SetSelectedContentXObject(selectedXObject);
            _isSelectedXObjectChanging = false;
            contentXObjectsListBox.EndUpdate();

            UpdateUI();
        }

        #endregion


        #region Visual tool

        /// <summary>
        /// Subscribes to the events of visual tool.
        /// </summary>
        /// <param name="visualTool">The visual tool.</param>
        private void SubscribeToVisualToolEvents(PdfContentXObjectTool visualTool)
        {
            visualTool.Activated += new EventHandler(VisualTool_Activated);
            visualTool.Deactivated += new EventHandler(VisualTool_Deactivated);
            visualTool.MouseMove += new VisualToolMouseEventHandler(VisualTool_MouseMove);
            visualTool.MouseDown += new VisualToolMouseEventHandler(VisualTool_MouseDown);
            visualTool.MouseDoubleClick += new VisualToolMouseEventHandler(VisualTool_MouseDoubleClick);
            visualTool.SelectedXObjectsChanged += new EventHandler(VisualTool_SelectedXObjectsChanged);
            visualTool.XObjectsChanged += new EventHandler(VisualTool_XObjectsChanged);

            if (visualTool.ImageViewer != null)
            {
                SubscribeToImageViewerEvents(visualTool.ImageViewer);
                _isVisualToolActivated = true;
            }
        }

        /// <summary>
        /// Unsubscribes from the events of visual tool.
        /// </summary>
        /// <param name="visualTool">The visual tool.</param>
        private void UnsubscribeFromVisualToolEvents(PdfContentXObjectTool visualTool)
        {
            visualTool.Activated -= VisualTool_Activated;
            visualTool.Deactivated -= VisualTool_Deactivated;
            visualTool.MouseMove -= VisualTool_MouseMove;
            visualTool.MouseDown -= VisualTool_MouseDown;
            visualTool.MouseDoubleClick -= VisualTool_MouseDoubleClick;
            visualTool.SelectedXObjectsChanged -= VisualTool_SelectedXObjectsChanged;
            visualTool.XObjectsChanged -= VisualTool_XObjectsChanged;

            if (visualTool.ImageViewer != null)
            {
                UnsubscribeFromImageViewerEvents(visualTool.ImageViewer);
                _isVisualToolActivated = false;
            }
        }

        /// <summary>
        /// Visual tool is activated.
        /// </summary>
        private void VisualTool_Activated(object sender, EventArgs e)
        {
            PdfVisualTool visualTool = (PdfVisualTool)sender;

            _isXObjectSelected = false;
            SubscribeToImageViewerEvents(visualTool.ImageViewer);
            _isVisualToolActivated = true;
            UpdateXObjectsListBox();
            UpdateUI();
        }

        /// <summary>
        /// Visual tool is deactivated.
        /// </summary>
        private void VisualTool_Deactivated(object sender, EventArgs e)
        {
            PdfVisualTool visualTool = (PdfVisualTool)sender;

            UnsubscribeFromImageViewerEvents(visualTool.ImageViewer);
            _isVisualToolActivated = false;
            UpdateXObjectsListBox();
            mainPanel.Enabled = false;
        }

        /// <summary>
        /// Mouse is moved on image on PDF page.
        /// </summary>
        private void VisualTool_MouseMove(object sender, VisualToolMouseEventArgs e)
        {
            if (!Enabled || !mainPanel.Enabled || _isXObjectSelected)
                return;

            _isSelectedXObjectChanging = true;

            PdfContentXObject[] xObjects = _contentXObjectTool.FindXObjectsInViewerSpace(e.Location);

            if (xObjects.Length == 0)
            {
                _contentXObjectTool.SelectedXObjects.Clear();
                UpdateRegionInfo(null);
            }
            else
            {
                PdfContentXObject imageResource = null;
                PdfContentXObject formResource = null;

                foreach (PdfContentXObject xObject in xObjects)
                {
                    if (imageResource == null &&
                        xObject.XObjectResource is PdfImageResource)
                        imageResource = xObject;
                    else if (formResource == null &&
                             xObject.XObjectResource is PdfFormXObjectResource)
                        formResource = xObject;

                    if (imageResource != null && formResource != null)
                        break;
                }

                PdfContentXObject selectedXObject = GetSelectedContentXObject(xObjects);
                if (imageResource != null && formResource != null &&
                    FormContainsImageResource(
                    (PdfFormXObjectResource)formResource.XObjectResource,
                    (PdfImageResource)imageResource.XObjectResource))
                {
                    SetSelectedContentXObject(formResource, imageResource);
                }
                else
                {
                    SetSelectedContentXObject(selectedXObject);
                }
                contentXObjectsListBox.SelectedIndex = _contentXObjectTool.XObjects.IndexOf(selectedXObject);
                UpdateRegionInfo(selectedXObject);
            }

            _isSelectedXObjectChanging = false;
        }

        /// <summary>
        /// Mouse is down on image on PDF page.
        /// </summary>
        private void VisualTool_MouseDown(object sender, VisualToolMouseEventArgs e)
        {
            if (!Enabled || !mainPanel.Enabled)
                return;

            // if left or right mouse button is clicked
            if (e.Button == MouseButtons.Left ||
                e.Button == MouseButtons.Right)
            {
                PdfContentXObject[] xObjects = _contentXObjectTool.FindXObjectsInViewerSpace(e.Location);
                PdfContentXObject selectedXObject = GetSelectedContentXObject(xObjects);
                SetSelectedContentXObject(selectedXObject);

                _isXObjectSelected = selectedXObject != null;

                UpdateUI();

                // if right mouse button is clicked
                if (selectedXObject != null && e.Button == MouseButtons.Right)
                    // show context menu
                    ContentXObjectContextMenuStrip.Show(_contentXObjectTool.ImageViewer, e.Location);
            }
        }

        /// <summary>
        /// Mouse is double clicked on image on PDF page.
        /// </summary>
        private void VisualTool_MouseDoubleClick(object sender, VisualToolMouseEventArgs e)
        {
            if (!Enabled || !mainPanel.Enabled)
                return;

            // get selected XObject
            PdfContentXObject selectedXObject = GetSelectedContentXObject();

            if (selectedXObject != null && e.Button == MouseButtons.Left)
                ShowContentXObject(selectedXObject);
        }

        /// <summary>
        /// Selected image is changed in visual tool.
        /// </summary>
        private void VisualTool_SelectedXObjectsChanged(object sender, EventArgs e)
        {
            if (!Enabled || !mainPanel.Enabled || _isSelectedXObjectChanging)
                return;

            _isSelectedXObjectChanging = true;
            contentXObjectsListBox.BeginUpdate();
            try
            {
                PdfContentXObject selectedXObject = GetSelectedContentXObject();
                UpdateRegionInfo(selectedXObject);
                int index = _contentXObjectTool.XObjects.IndexOf(selectedXObject);
                contentXObjectsListBox.SelectedIndex = index;
            }
            finally
            {
                contentXObjectsListBox.EndUpdate();
                _isSelectedXObjectChanging = false;
            }
        }

        /// <summary>
        /// The XObjects of visual tool is changed.
        /// </summary>
        private void VisualTool_XObjectsChanged(object sender, EventArgs e)
        {
            int prevCount = contentXObjectsListBox.Items.Count;

            UpdateXObjectsListBox();

            if (contentXObjectsListBox.Items.Count != prevCount)
            {
                _contentXObjectTool.ImageViewer.ReloadImage();

                UpdateUI();
            }
        }

        #endregion


        #region Image viewer

        /// <summary>
        /// Subscribes to the events of image viewer.
        /// </summary>
        /// <param name="imageViewer">The image viewer.</param>
        private void SubscribeToImageViewerEvents(ImageViewer imageViewer)
        {
            imageViewer.FocusedIndexChanged +=
                new EventHandler<FocusedIndexChangedEventArgs>(ImageViewer_FocusedIndexChanged);
        }

        /// <summary>
        /// Unsubscribes from the events of image viewer.
        /// </summary>
        /// <param name="imageViewer">The image viewer.</param>
        private void UnsubscribeFromImageViewerEvents(ImageViewer imageViewer)
        {
            imageViewer.FocusedIndexChanged -= ImageViewer_FocusedIndexChanged;
        }

        /// <summary>
        /// Focused image in image viewer is changed.
        /// </summary>
        private void ImageViewer_FocusedIndexChanged(object sender, FocusedIndexChangedEventArgs e)
        {
            _isSelectedXObjectChanging = false;
            _isXObjectSelected = false;
            _contentXObjectTool.SelectedXObjects.Clear();

            UpdateXObjectsListBox();
            UpdateUI();
        }

        #endregion


        #region ContentXObjectContextMenuStrip

        /// <summary>
        /// Context menu strip is opening.
        /// </summary>
        private void ContentXObjectContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            PdfContentXObject xObject = GetSelectedContentXObject();

            if (xObject == null)
            {
                e.Cancel = true;
            }
            else
            {
                bool isImageResource = false;

                if (xObject.XObjectResource is PdfImageResource)
                    isImageResource = true;

                saveContentXObjectAsImageToolStripMenuItem.Enabled = isImageResource;
            }
        }

        /// <summary>
        /// "View Content XObject" button is clicked.
        /// </summary>
        private void viewContentXObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfContentXObject xObject = GetSelectedContentXObject();
            ShowContentXObject(xObject);
        }

        /// <summary>
        /// "Save As Binary" button is clicked.
        /// </summary>
        private void saveContentXObjectAsBinaryDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfContentXObject xObject = GetSelectedContentXObject();
            SaveContentXObjectAsBinary(xObject);
        }

        /// <summary>
        /// "Save As Image" button is clicked.
        /// </summary>
        private void saveContentXObjectAsImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfContentXObject xObject = GetSelectedContentXObject();
            SaveContentXObjectAsImage(xObject);
        }

        /// <summary>
        /// "Remove" button is clicked.
        /// </summary>
        private void removeConentXObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PdfContentXObject xObject = GetSelectedContentXObject();
            RemoveXObject(xObject);
        }




        #endregion

        #endregion
      
    }
}
