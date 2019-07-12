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
    public partial class datagetPerformance : Form
    {
        public datagetPerformance()
        {
            InitializeComponent();
            dataInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            performanceEvaluation p = (performanceEvaluation)this.Owner;
            p.perDateGetData_radiationDingBiaoAccuracy = Convert.ToDouble(datagetDataGridView.Rows[0].Cells[0].Value.ToString());
            this.Close();
        }
        private void dataInit()
        {
            datagetDataGridView.Rows[0].Cells[0].Value = "3";//日获取数据量比辐射定标精度
        }
    }
}
