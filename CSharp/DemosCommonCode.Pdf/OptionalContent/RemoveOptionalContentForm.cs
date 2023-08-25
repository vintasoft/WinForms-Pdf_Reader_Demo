using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Vintasoft.Imaging.Pdf;
using Vintasoft.Imaging.Pdf.Tree.OptionalContent;

namespace DemosCommonCode.Pdf
{
    /// <summary>
    /// A form that allows to remove optional content from PDF document.
    /// </summary>
    public partial class RemoveOptionalContentForm : Form
    {

        #region Fields

        /// <summary>
        /// A PDF document.
        /// </summary>
        PdfDocument _document;

        #endregion



        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveOptionalContentForm"/> class.
        /// </summary>
        public RemoveOptionalContentForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveOptionalContentForm"/> class.
        /// </summary>
        /// <param name="document">The PDF document.</param>
        public RemoveOptionalContentForm(PdfDocument document)
            : this()
        {
            // intialize PDF document
            _document = document;

            // get a new list of optional content groups 
            IList<PdfOptionalContentGroup> groups = document.OptionalContentProperties.OptionalContentGroups;

            // if list of optional content groups is not empty
            if (groups != null)
            {
                // for each group in list
                foreach (PdfOptionalContentGroup group in groups)
                {
                    // add optional content group to the list box
                    optionalContentGroupsCheckedListBox.Items.Add(group.Name, false);
                }
            }
        }

        #endregion



        #region Properties

        List<PdfOptionalContentGroup> _selectedOptionalGroups = new List<PdfOptionalContentGroup>();
        /// <summary>
        /// A list of optional content, which should be removed from PDF document.
        /// </summary>
        public List<PdfOptionalContentGroup> SelectedOptionalGroups
        {
            get
            {
                return _selectedOptionalGroups;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Handles the Click event of OkButton object.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            // for each optional content in checked content groups
            foreach (int optionalContentIndex in optionalContentGroupsCheckedListBox.CheckedIndices)
                _selectedOptionalGroups.Add(_document.OptionalContentProperties.OptionalContentGroups[optionalContentIndex]);

            DialogResult = DialogResult.OK;
        }

        #endregion

    }
}
