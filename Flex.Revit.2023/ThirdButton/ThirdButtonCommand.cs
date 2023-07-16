using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Masterclass.Revit.Utilities;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace Masterclass.Revit.FirstButton
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    [Journaling(JournalingMode.NoCommandData)]
    internal class ThirdButtonCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                MessageBox.Show("Vender: Krishna Joshi" + Environment.NewLine +
                    "Gmail: krishnajoshi898@gmail.com" + Environment.NewLine + Environment.NewLine +
                    "Unlocking the potential of BIM for the AEC industry..",
                    "BIM API", MessageBoxButtons.OK);

                return Result.Succeeded;
            }
            catch (Exception)
            {
                return Result.Failed;
            }
        }
        public static void CreateButton(RibbonPanel panel)
        {
            var assembly = Assembly.GetExecutingAssembly();

            panel.AddItem(
                new PushButtonData(
                MethodBase.GetCurrentMethod().DeclaringType?.Name,
                "Info",
                assembly.Location,
                MethodBase.GetCurrentMethod().DeclaringType?.FullName)
                {
                    ToolTip = "click for vender info",
                    LargeImage = ImageUtils.LoadImage(assembly, "_32x32.info.png")

                });
        }
    }
}
