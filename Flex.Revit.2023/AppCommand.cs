using Autodesk.Revit.UI;
using Flex.Revit.FirstButton;
using Masterclass.Revit.FirstButton;
using System;
using System.Linq;

namespace Flex.Revit
{
    internal class AppCommand : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication app)
        {
            try
            {
                app.CreateRibbonTab("Flex");
            }
            catch (Exception)
            {
                // Ingored
            }

            var ribbonPanel = app.GetRibbonPanels("Flex").FirstOrDefault(x => x.Name == "Flex") ??
                app.CreateRibbonPanel("Flex", "Create Column and Footing");

            ThirdButtonCommand.CreateButton(ribbonPanel);
            ribbonPanel.AddSeparator();
            SecondButtonCommand.CreateButton(ribbonPanel);
            ribbonPanel.AddSeparator();
            FirstButtonCommand.CreateButton(ribbonPanel);

            return Result.Succeeded;
        }
        public Result OnShutdown(UIControlledApplication app)
        {
            return Result.Succeeded;
        }
    }
}
