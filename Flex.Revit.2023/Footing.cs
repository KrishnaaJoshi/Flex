using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace Flex.Revit
{
    public partial class Footing : System.Windows.Forms.Form
    {
        Document Doc;
        private IList<PolyLine> pLines = new List<PolyLine>();

        public Footing(Document doc)
        {
            InitializeComponent();
            Doc = doc;
        }

        private void Footing_Load(object sender, EventArgs e)
        {
            var cadImports = (List<ElementId>)new FilteredElementCollector(Doc)
                .OfClass(typeof(ImportInstance)).WhereElementIsNotElementType().ToElementIds();

            var layerNames = new List<string>();

            if (cadImports.Count > 0)
            {
                var import = Doc.GetElement(cadImports.First()) as ImportInstance;
                var geoEle = import.get_Geometry(new Options());

                foreach (GeometryObject geoObj in geoEle)
                {
                    if (geoObj is GeometryInstance)
                    {
                        var geoInst = geoObj as GeometryInstance;
                        var geoElement = geoInst.GetInstanceGeometry();

                        if (geoElement != null)
                        {
                            foreach (GeometryObject obj in geoElement)
                            {
                                if (obj is PolyLine)
                                {
                                    var gStyle = Doc.GetElement(obj.GraphicsStyleId) as GraphicsStyle;
                                    var Layer = gStyle.GraphicsStyleCategory.Name;

                                    layerNames.Add(Layer);
                                    pLines.Add(obj as PolyLine);
                                    
                                }
                            }
                        }
                    }
                }
                combo_layer.DataSource = layerNames.Distinct().ToList();

                var footings = new FilteredElementCollector(Doc)
                    .OfCategory(BuiltInCategory.OST_StructuralFoundation).WhereElementIsElementType().ToElements();

                var footingTypes = new List<string>();

                foreach (Element ele in footings)
                {
                    footingTypes.Add(ele.Name);
                }
                combo_FootingType.DataSource = footingTypes;
            }
            else
            {
                TaskDialog.Show("Import error", "Can't find CAD import");
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            var selectedLayer = combo_layer.SelectedItem as string;

            foreach (PolyLine polyLine in pLines)
            {
                var gStyle = Doc.GetElement(polyLine.GraphicsStyleId) as GraphicsStyle;
                var layer = gStyle.GraphicsStyleCategory.Name;

                if (layer == selectedLayer)
                {
                    var pOutline = polyLine.GetOutline();

                    var firstP = pOutline.MaximumPoint;
                    var secondP = pOutline.MinimumPoint;
                    var lineMid = MidPoint(firstP.X, secondP.X, firstP.Y, secondP.Y, firstP.Z, secondP.Z);

                    var footings = new FilteredElementCollector(Doc)
                        .OfCategory(BuiltInCategory.OST_StructuralFoundation)
                        .WhereElementIsElementType()
                        .ToElements();

                    var levels = new FilteredElementCollector(Doc)
                        .OfClass(typeof(Level))
                        .Cast<Level>()
                        .ToList();

                    Level colLevel = levels.FirstOrDefault(level => level.Name == "Level 0");

                    if (colLevel == null)
                    {
                        TaskDialog.Show("Level error", "Can't find Level 0");
                        continue; // Skip creating the footing if Level 0 is not found
                    }

                    FamilySymbol fs = footings.FirstOrDefault(ele => ele.Name == combo_FootingType.SelectedItem.ToString()) as FamilySymbol;

                    if (fs == null)
                    {
                        TaskDialog.Show("Footing type error", "Can't find the selected footing type");
                        continue; // Skip creating the footing if the selected footing type is not found
                    }

                    using (Transaction t = new Transaction(Doc, "Create footings"))
                    {
                        t.Start();

                        try
                        {
                            if (!fs.IsActive)
                            {
                                fs.Activate();
                            }
                            Doc.Create.NewFamilyInstance(lineMid, fs, colLevel, StructuralType.NonStructural);
                        }
                        catch (Exception ex)
                        {
                            TaskDialog.Show("Error", ex.Message);
                        }

                        t.Commit();
                    }
                }
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        private static XYZ MidPoint(double x1, double x2, double y1, double y2, double z1, double z2)
        {
            XYZ midPoint = new XYZ((x1 + x2) / 2, (y1 + y2) / 2, (z1 + z2) / 2);
            return midPoint;
        }
    }
}
