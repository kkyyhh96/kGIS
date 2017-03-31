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

namespace kGIS_App
{
    public partial class EditFeatureForm : Form
    {
        AxMapControl mainMapControl;
        public int layerIndex { set; get; }
        public int editMethod { set; get; }
        public EditFeatureForm(AxMapControl mapControl)
        {
            InitializeComponent();
            mainMapControl = mapControl;
            for (int i = 0; i < mapControl.LayerCount; i++)
            {
                cmbLayer.Items.Add(mapControl.get_Layer(i).Name);
            }
        }

        private void cmbLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            layerIndex = cmbLayer.SelectedIndex;
        }

        private void cmbEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            editMethod = this.cmbEdit.SelectedIndex;
        }
    }
}
