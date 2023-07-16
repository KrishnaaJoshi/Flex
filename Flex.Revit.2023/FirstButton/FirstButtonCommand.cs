using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Masterclass.Revit.Utilities;
using System.Reflection;
using System.Windows.Forms;

namespace Flex.Revit.FirstButton
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    [Journaling(JournalingMode.NoCommandData)]
    internal class FirstButtonCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiApp = commandData.Application;
            var doc = uiApp.ActiveUIDocument.Document;

            using (System.Windows.Forms.Form form = new Column(doc))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    return Result.Succeeded;
                }
                else
                {
                    return Result.Cancelled;
                }
            }
        }

        public static void CreateButton(RibbonPanel panel)
        {
            var assembly = Assembly.GetExecutingAssembly();

            panel.AddItem(
                new PushButtonData(
                    MethodBase.GetCurrentMethod().DeclaringType?.Name,
                    "Columns",
                    assembly.Location,
                    MethodBase.GetCurrentMethod().DeclaringType?.FullName)
                {
                    ToolTip = "Create a column",
                    LargeImage = ImageUtils.LoadImage(assembly, "32x32.column.png")
                });
        }
    }
}
