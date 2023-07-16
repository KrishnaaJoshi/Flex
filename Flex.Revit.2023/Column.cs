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
    public partial class Column : System.Windows.Forms.Form
    {
        Document Doc;
        private IList<PolyLine> pLines = new List<PolyLine>();
        public Column(Document doc)
        {
            InitializeComponent();
            Doc = doc;
        }

        private void Column_Load(object sender, EventArgs e)
        {
            var cadImports = (IList<ElementId>) new FilteredElementCollector(Doc)
                .OfClass(typeof(ImportInstance)).WhereElementIsNotElementType().ToElementIds();

            var layerNames = new List<string>();

            if (cadImports.Count > 0)
            {
                ImportInstance import = Doc.GetElement(cadImports.First()) as ImportInstance;
                GeometryElement geoEle = import.get_Geometry(new Options());

                foreach (GeometryObject geoObj in geoEle)
                {
                    if (geoObj is GeometryInstance)
                    {
                        GeometryInstance geoInst = geoObj as GeometryInstance;
                        GeometryElement geoElement = geoInst.GetInstanceGeometry();

                        if (geoElement != null)
                        {
                            foreach (GeometryObject obj in geoElement)
                            {
                                if (obj is PolyLine)
                                {
                                    GraphicsStyle gStyle = Doc.GetElement(obj.GraphicsStyleId) as GraphicsStyle;
                                    string Layer = gStyle.GraphicsStyleCategory.Name;

                                    layerNames.Add(Layer);
                                    pLines.Add(obj as PolyLine);
                                }
                            }
                        }
                    }
                }
                combo_layer.DataSource = layerNames.Distinct().ToList();

                IList<Element> columns = new FilteredElementCollector(Doc)
                    .OfCategory(BuiltInCategory.OST_StructuralColumns).WhereElementIsElementType().ToElements();

                IList<string> columnTypes = new List<string>();

                foreach (Element ele in columns)
                {
                    columnTypes.Add(ele.Name);
                }
                combo_ColumnType.DataSource = columnTypes;
            }
            else
            {
                TaskDialog.Show("Import Error", "Can't find CAD imports");
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            string selectedLayer = this.combo_layer?.SelectedItem.ToString();

            foreach (PolyLine polyline in pLines)
            {
                GraphicsStyle gStyle = Doc.GetElement(polyline.GraphicsStyleId) as GraphicsStyle;
                string Layer = gStyle.GraphicsStyleCategory.Name;

                if (Layer == selectedLayer)
                {
                    Outline pOutline = polyline.GetOutline();

                    XYZ firstP = pOutline.MaximumPoint;
                    XYZ secondP = pOutline.MinimumPoint;
                    XYZ lineMid = MidPoint(firstP.X, secondP.X, firstP.Y, secondP.Y, firstP.Z, secondP.Z);

                    IList<Element> columns = new FilteredElementCollector(Doc)
                        .OfCategory(BuiltInCategory.OST_StructuralColumns).WhereElementIsElementType().ToElements();

                    IList<Level> levels = new FilteredElementCollector(Doc)
                        .OfClass(typeof(Level)).Cast<Level>().ToList();

                    Level colLevel = null;
                    foreach (Level level in levels)
                    {
                        if (level.Name == "Level 0")
                        {
                            colLevel = level;
                        }
                    }
                    FamilySymbol fs = null;
                    string selectedColumnType = this.combo_ColumnType.SelectedItem.ToString();

                    foreach (Element ele in columns)
                    {
                        if (ele.Name == selectedColumnType)
                        {
                               fs = ele as FamilySymbol;
                        }
                    }
                    using (Transaction t = new Transaction(Doc, "Create columns"))
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
                            TaskDialog.Show(ex.Message, ex.ToString());
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