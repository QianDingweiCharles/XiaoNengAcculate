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
    public partial class coverPerformance : Form
    {
        public coverPerformance()
        {
            InitializeComponent();
            dataInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            performanceEvaluation p = (performanceEvaluation)this.Owner;
            p.coverTime_coverSpace = Convert.ToDouble(coverDatagridview.Rows[0].Cells[0].Value.ToString());
            this.Close();
        }

        private void dataInit()
        {
            coverDatagridview.Rows[0].Cells[0].Value = "1";//覆盖时效性比覆盖空间性能
        }
     }
}
