using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Tree.OptionalContent;
using Vintasoft.Imaging.UI;

namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A form that allows to view and change settings of optional content (layers) of PDF document.
    /// </summary>
    public partial class OptionalContentSettingsForm : Form
    {

        #region Fields

        /// <summary>
        /// An image viewer.
        /// </summary>
        ImageViewer _viewer;

        /// <summary>
        /// A PDF document.
        /// </summary>
        PdfDocument _document;

        /// <summary>
        /// A list of optional content configurations of PDF document.
        /// </summary>
        List<PdfOptionalContentConfiguration> _configurations = new List<PdfOptionalContentConfiguration>();

        /// <summary>
        /// A value, which determines that all layers must be shown.
        /// </summary>
        bool _useLayersFromPresentationOrder = false;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OptionalContentSettingsForm"/> class.
        /// </summary>
        public OptionalContentSettingsForm()
        {
            InitializeComponent();

            _useLayersFromPresentationOrder = !showAllLayersCheckBox.Checked;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OptionalContentSettingsForm"/> class.
        /// </summary>
        /// <param name="document">A PDF document.</param>
        /// <param name="viewer">An image viewer.</param>
        public OptionalContentSettingsForm(PdfDocument document, ImageViewer viewer)
            : this()
        {
            // intialize PDF document
            _document = document;
            // initialize image viewer
            _viewer = viewer;

            // if default optional content configuration of PDF document if not empty
            if (_document.OptionalContentProperties.DefaultConfiguration != null)
            {
                // get name of default configuration
                string defaultName = string.Format("{0}(Default)", _document.OptionalContentProperties.DefaultConfiguration.Name);
                // add configuration to the cofiguration combo box
                AddConfiguration(defaultName, _document.OptionalContentProperties.DefaultConfiguration);
            }
            // get list of optional content configurations
            IList<PdfOptionalContentConfiguration> configurations = _document.OptionalContentProperties.Configurations;
            // if list of optional content configuration is not empty
            if (configurations != null)
            {
                // for each configuration
                for (int i = 0; i < configurations.Count; i++)
                {
                    // add configuration to the cofiguration combo box
                    AddConfiguration(configurations[i].Name, configurations[i]);
                }
            }

            // select configuration of current optional content
            configurationsComboBox.SelectedIndex = _configurations.IndexOf(_document.OptionalContentConfiguration);
        }

        #endregion



        #region Methods

        #region UI

        /// <summary>
        /// Handles the CheckedChanged event of showAllLayersCheckBox object.
        /// </summary>
        private void showAllLayersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // update current optional content configuration of PDF document
            UpdateCurrentConfiguration();
            // if all layers must be shown
            if (showAllLayersCheckBox.Checked)
                _useLayersFromPresentationOrder = false;
            else
                _useLayersFromPresentationOrder = true;
            // load optional content groups
            LoadGroupsList();
        }

        /// <summary>
        /// Handles the Click event of okButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            // update current optional content configuration of PDF document
            UpdateCurrentConfiguration();
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of configurationsComboBox object.
        /// </summary>
        private void configurationsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCurrentConfiguration();

            // set chosen configuration
            _document.OptionalContentConfiguration = _configurations[configurationsComboBox.SelectedIndex];

            // if auto states are empty
            if (GetIsAutoStateEmpty(_document.OptionalContentConfiguration))
            {
                // enable list box
                ocGroupsCheckedListBox.Enabled = true;
            }
            // if auto states are NOT empty
            else
            {
                // disable list box
                ocGroupsCheckedListBox.Enabled = false;
            }

            LoadGroupsList();
        }

        #endregion


        /// <summary>
        /// Returns a value, which indicates that auto states of optional content are empty.
        /// </summary>
        /// <param name="configuration">A configuration of optional content.</param>
        /// <returns>
        /// <b>True</b> - if auto states are empty;
        /// <b>False</b> - is auto states are NOT empty
        /// </returns>
        private bool GetIsAutoStateEmpty(PdfOptionalContentConfiguration configuration)
        {
            // indicates that auto states of optional content are empty
            bool isAutoStatesEmpty = true;
            // if auto states are NOT empty
            if (configuration.AutoStates != null)
            {
                // the message
                string message = "Optional content configuration has auto states. To change layers order, auto states should be deleted.\n" +
                    "Delete auto states?\nPress 'Yes' to delete auto states.";
                // if auto states must be deleted
                if (MessageBox.Show(message, "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // delete auto states
                    configuration.AutoStates = null;
                    // indicate that auto states are deleted
                    isAutoStatesEmpty = true;
                }
                else
                {
                    // indicate that auto states are NOT deleted
                    isAutoStatesEmpty = false;
                }
            }
            return isAutoStatesEmpty;
        }

        /// <summary>
        /// Adds optional content configuration to the cofiguration combo box.
        /// </summary>
        /// <param name="name">A name of configuration.</param>
        /// <param name="configuration">A configuration.</param>
        private void AddConfiguration(string name, PdfOptionalContentConfiguration configuration)
        {
            // if name of configuration is empty
            if (name == "")
            {
                // set predefined name for configuration
                name = "(no name)";
            }
            // add configuration to the cofiguration combo box
            configurationsComboBox.Items.Add(name);
            // add configuration to the list of optional content configurations
            _configurations.Add(configuration);
        }

        /// <summary>
        /// Loads list of optional content groups of PDF document.
        /// </summary>
        private void LoadGroupsList()
        {
            // clear list box
            ocGroupsCheckedListBox.Items.Clear();

            // get a new optional content configuration
            PdfOptionalContentConfiguration configuration = _document.OptionalContentConfiguration;
            // get a new list of optional content groups 
            IList<PdfOptionalContentGroup> groups = GetOptionalContentGroupList(configuration, _useLayersFromPresentationOrder);

            // if list of optional content groups is not empty
            if (groups != null)
            {
                // for each group in list
                foreach (PdfOptionalContentGroup group in groups)
                {
                    // add optional content group to the list box
                    ocGroupsCheckedListBox.Items.Add(group.Name, configuration.GetGroupVisibility(group));
                }
            }
        }

        /// <summary>
        /// Returns an optional content group list.
        /// </summary>
        /// <param name="configuration">A configuration.</param>
        /// <param name="usePresentationOrder">Use configuration.PresentationOrder as source.</param>
        /// <returns>An optional content group list.</returns>
        private IList<PdfOptionalContentGroup> GetOptionalContentGroupList(
            PdfOptionalContentConfiguration configuration,
            bool usePresentationOrder)
        {
            IList<PdfOptionalContentGroup> groups = null;

            // if all layers must be shown
            if (usePresentationOrder)
            {
                // if list of optional content groups is empty
                if (groups == null)
                {
                    // create new list
                    groups = new List<PdfOptionalContentGroup>();
                }

                if (configuration.PresentationOrder != null)
                {
                    if (configuration.PresentationOrder.OptionalContentGroup != null)
                        groups.Add(configuration.PresentationOrder.OptionalContentGroup);

                    // if list of presentation orders is not empty 
                    if (configuration.PresentationOrder.Items != null && configuration.PresentationOrder.Items.Length > 0)
                    {
                        // load list of optional content groups from presentation order
                        LoadGroupListFromPresentationOrder(groups, configuration.PresentationOrder);
                    }
                }
            }
            // if presebtation oreder is not empty
            else if (configuration.PresentationOrder != null)
            {
                // get a new list of optional content groups
                groups = configuration.Document.OptionalContentProperties.OptionalContentGroups;
            }
            return groups;
        }

        /// <summary>
        /// Loads list of optional content groups from presentation order.
        /// </summary>
        /// <param name="groups">List of optional content groups.</param>
        /// <param name="presentationOrder">Presentation order.</param>
        private void LoadGroupListFromPresentationOrder(
            IList<PdfOptionalContentGroup> groups,
            PdfOptionalContentPresentationOrder presentationOrder)
        {
            // for each sub presentation order
            foreach (PdfOptionalContentPresentationOrder subPresentationOrder in presentationOrder.Items)
            {
                // if optional content group is not empty
                if (subPresentationOrder.OptionalContentGroup != null)
                {
                    // add group to group list
                    groups.Add(subPresentationOrder.OptionalContentGroup);
                }

                // if list of sub presentation orders is not empty
                if (subPresentationOrder.Items != null)
                {
                    // load optional content gropus from sub presentation order
                    LoadGroupListFromPresentationOrder(groups, subPresentationOrder);
                }
            }
        }

        /// <summary>
        /// Updates current optional content configuration of PDF document.
        /// </summary>
        private void UpdateCurrentConfiguration()
        {
            // if list box is not empty
            if (ocGroupsCheckedListBox.Items.Count > 0)
            {
                // get current optional content configuration
                PdfOptionalContentConfiguration configuration = _document.OptionalContentConfiguration;
                // get current list of optional content groups 
                IList<PdfOptionalContentGroup> groups = GetOptionalContentGroupList(configuration, _useLayersFromPresentationOrder);

                // for each group in list
                for (int i = 0; i < groups.Count; i++)
                {
                    // update group visibility
                    configuration.SetGroupVisibility(groups[i], ocGroupsCheckedListBox.GetItemChecked(i));
                }
            }
        }

        #endregion

    }
}
