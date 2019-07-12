using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 遥感卫星系统性能评估
{
    public partial class systemContriRate : Form
    {
        public systemContriRate()
        {
            InitializeComponent();
            dataInit();
        }
        private void dataInit()
        {
            systemContriDataGrid.Rows[0].Cells[0].Value = "2";//
            systemContriDataGrid.Rows[0].Cells[1].Value = "3";
            systemContriDataGrid.Rows[0].Cells[2].Value = "4";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            performanceEvaluation p = (performanceEvaluation)this.Owner;
            p.equipmentPerfom_appPerform = Convert.ToDouble(systemContriDataGrid.Rows[0].Cells[0].Value.ToString());
            p.equipmentPerfom_taskPerfom = Convert.ToDouble(systemContriDataGrid.Rows[0].Cells[1].Value.ToString());
            p.appPerform_taskPerfom = Convert.ToDouble(systemContriDataGrid.Rows[0].Cells[2].Value.ToString());
            this.Close();
        }
    }
}
