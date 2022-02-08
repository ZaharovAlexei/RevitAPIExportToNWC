﻿using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPIExportToNWC
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;

            using (var ts = new Transaction(doc, "export nwc"))
            {
                ts.Start();

                var nwcOption = new NavisworksExportOptions();
                doc.Export(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "export.nwc", nwcOption);

                ts.Commit();
            }
            return Result.Succeeded;
        }
    }
}
