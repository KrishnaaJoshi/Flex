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
    internal class SecondButtonCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uiApp = commandData.Application;
            var doc = uiApp.ActiveUIDocument.Document;

            using (System.Windows.Forms.Form form = new Footing(doc))
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
                    "Footings",
                    assembly.Location,
                    MethodBase.GetCurrentMethod().DeclaringType?.FullName)
                {
                    ToolTip = "Create a footings",
                    LargeImage = ImageUtils.LoadImage(assembly, "32x32.footing.png")
                });
        }
    }
}
