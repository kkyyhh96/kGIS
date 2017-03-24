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
    public partial class SpatialSelectForm : Form
    {
        MainForm mainForm;
        AxMapControl mapControl;
        public SpatialSelectForm(MainForm mainForm, AxMapControl mapControl)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.mapControl = mapControl;
        }

        private void rbnClick_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnClick.Checked == true)
            {
                mainForm.selectMethod = 1;
                mainForm.clickMode = 2;
            }
        }

        private void rbnRectangle_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnRectangle.Checked == true)
            {
                mainForm.selectMethod = 2;
                mainForm.clickMode = 2;
            }
        }

        private void rbnCircle_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnCircle.Checked == true)
            {
                mainForm.selectMethod = 3;
                mainForm.clickMode = 2;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        private void cmbLayer_MouseClick(object sender, MouseEventArgs e)
        {
            cmbLayer.Items.Clear();
            for (int i = 0; i < mapControl.Map.LayerCount; i++)
            {
                this.cmbLayer.Items.Add(mapControl.Map.get_Layer(i).Name);
            }
        }

        private void cmbLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            mainForm.selectLayer = mapControl.Map.get_Layer(this.cmbLayer.SelectedIndex);
        }

        private void rbnSetRadius_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnSetRadius.Checked == true)
            {
                mainForm.selectMethod = 4;
                mainForm.clickMode = 2;
            }
        }

        private void tbxRadius_TextChanged(object sender, EventArgs e)
        {
            mainForm.selectRadius = Convert.ToDouble(tbxRadius.Text);
        }
    }
}
