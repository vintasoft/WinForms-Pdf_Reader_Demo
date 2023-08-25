using System.Drawing;

using Vintasoft.Imaging.Pdf.UI;


namespace DemosCommonCode.Imaging
{
    /// <summary>
    /// Stores information about a <see cref="PdfContentXObjectTool"/> action.
    /// </summary>
    public class PdfContentXObjectToolAction : VisualToolAction
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfContentXObjectToolAction"/> class.
        /// </summary>
        /// <param name="visualTool">The visual tool.</param>
        /// <param name="text">The action text.</param>
        /// <param name="toolTip">The action tool tip.</param>
        /// <param name="icon">The action icon.</param>
        /// <param name="subactions">The sub actions of the action.</param>
        public PdfContentXObjectToolAction(
            PdfContentXObjectTool visualTool,
            string text,
            string toolTip,
            Image icon,
            params VisualToolAction[] subactions)
            : base(visualTool, text, toolTip, icon, subactions)
        {
            visualTool.SelectionImagesBrush = new SolidBrush(Color.FromArgb(32, Color.Blue));
            visualTool.SelectionImagesPen = Pens.Red;
            visualTool.SelectionFormsBrush = new SolidBrush(Color.FromArgb(32, Color.Lime));
            visualTool.SelectionFormsPen = Pens.Blue;
        }

        #endregion

    }
}
