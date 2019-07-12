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
    public partial class coveragePerformance : Form
    {
        public coveragePerformance()
        {
            InitializeComponent();
            dataInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            performanceEvaluation p = (performanceEvaluation)this.Owner;
            p.coverTimeRatio_reCoverTime = Convert.ToDouble(coverageDataGridView.Rows[0].Cells[0].Value.ToString());
            p.coverTimeRatio_avgResonseTime = Convert.ToDouble(coverageDataGridView.Rows[0].Cells[1].Value.ToString());
            p.coverTimeRatio_agvGapTime = Convert.ToDouble(coverageDataGridView.Rows[0].Cells[2].Value.ToString());
            p.reCoverTime_avgResonseTime = Convert.ToDouble(coverageDataGridView.Rows[0].Cells[3].Value.ToString());
            p.reCoverTime_agvGapTime = Convert.ToDouble(coverageDataGridView.Rows[0].Cells[4].Value.ToString());
            p.avgResonseTime_agvGapTime= Convert.ToDouble(coverageDataGridView.Rows[0].Cells[5].Value.ToString());
            this.Close();
        }
        private void dataInit()
        {
            coverageDataGridView.Rows[0].Cells[0].Value = "2";//覆盖时间比，比重复覆盖时间
            coverageDataGridView.Rows[0].Cells[1].Value = "4";//覆盖时间比，平均响应时间
            coverageDataGridView.Rows[0].Cells[2].Value = "5";//覆盖时间比，平均间隙周期
            coverageDataGridView.Rows[0].Cells[3].Value = "2";//重复覆盖时间比平均响应时间
            coverageDataGridView.Rows[0].Cells[4].Value = "2";//重复覆盖时间比平均间隙周期
            coverageDataGridView.Rows[0].Cells[5].Value = "1";//平均响应时间比平均间隙周期
           
        }
    }
}
