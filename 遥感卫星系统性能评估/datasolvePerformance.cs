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
    public partial class datasolvePerformance : Form
    {
        public datasolvePerformance()
        {
            InitializeComponent();
            dataInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            performanceEvaluation p = (performanceEvaluation)this.Owner;
            p.perDateSolveData_solveDelay = Convert.ToDouble(datasolveDataGridView.Rows[0].Cells[0].Value.ToString());
            this.Close();
        }
        private void dataInit()
        {
            datasolveDataGridView.Rows[0].Cells[0].Value = "3";//空间比时间
        }
    }
}
