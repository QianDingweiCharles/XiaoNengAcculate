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
    public partial class accuracyPerformance : Form
    {
        public accuracyPerformance()
        {
            InitializeComponent();
            dataInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            performanceEvaluation p = (performanceEvaluation)this.Owner;
            p.dingZi_dingGui = Convert.ToDouble(accuracyDataGridView.Rows[0].Cells[0].Value.ToString());
            p.dingZi_dingWei = Convert.ToDouble(accuracyDataGridView.Rows[0].Cells[1].Value.ToString());
            p.dingGui_dingWei = Convert.ToDouble(accuracyDataGridView.Rows[0].Cells[2].Value.ToString());
            this.Close();
        }
        private void dataInit()
        {
            accuracyDataGridView.Rows[0].Cells[0].Value = "5";//定姿精度比定轨
            accuracyDataGridView.Rows[0].Cells[1].Value = "3";//定姿比定位
            accuracyDataGridView.Rows[0].Cells[2].Value = "0.5";//定轨比定位
            
        }
    }
}
