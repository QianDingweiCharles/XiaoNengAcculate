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
    public partial class coverspacePerformance : Form
    {
        public coverspacePerformance()
        {
            InitializeComponent();
            dataInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            performanceEvaluation p = (performanceEvaluation)this.Owner;
            p.coverageOverlapRate_cumCoverageAreaRatio = Convert.ToDouble(coverspaceDataGridView.Rows[0].Cells[0].Value.ToString());
            this.Close();
        }
        private void dataInit()
        {
            coverspaceDataGridView.Rows[0].Cells[0].Value = "0.5";//覆盖重叠率比累计覆盖面积比率
        }
    }
}
