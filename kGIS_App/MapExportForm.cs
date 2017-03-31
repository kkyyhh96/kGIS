using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.Display;

namespace kGIS_App
{
    public partial class MapExportForm : Form
    {
        AxMapControl mainMapControl;

        public MapExportForm(AxMapControl mainMapControl)
        {
            InitializeComponent();
            this.mainMapControl = mainMapControl;
            this.cmbFormat.Items.Add("JPG");
            this.cmbFormat.Items.Add("PNG");
            this.cmbFormat.Items.Add("TIF");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            IExport export = null;
            switch (this.cmbFormat.SelectedIndex)
            {
                case 0: export = new ExportJPEGClass(); break;
                case 1: export = new ExportPNGClass(); break;
                case 2: export = new ExportTIFFClass(); break;
            }
            export.ExportFileName = tbxPath.Text;

            IEnvelope envelope = new EnvelopeClass();

            // Microsoft Windows default DPI resolution
            export.Resolution = Convert.ToDouble(tbxDPI.Text);
            ESRI.ArcGIS.esriSystem.tagRECT exportRECT = mainMapControl.ActiveView.ExportFrame;
            envelope.PutCoords(exportRECT.left, exportRECT.top, exportRECT.right, exportRECT.bottom);
            export.PixelBounds = envelope;
            System.Int32 hDC = export.StartExporting();
            mainMapControl.ActiveView.Output(hDC, (System.Int16)export.Resolution, ref exportRECT, null, null);

            // Finish writing the export file and cleanup any intermediate files
            export.FinishExporting();
            export.Cleanup();
        }
    }
}
