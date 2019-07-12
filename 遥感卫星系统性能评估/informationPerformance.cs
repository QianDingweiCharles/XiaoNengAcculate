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
    public partial class informationPerformance : Form
    {
        public informationPerformance()
        {
            InitializeComponent();
            dataInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            performanceEvaluation p = (performanceEvaluation)this.Owner;
            p.dataGet_dataSend = Convert.ToDouble(infoDataGridView.Rows[0].Cells[0].Value.ToString());
            p.dataGet_dataSolve = Convert.ToDouble(infoDataGridView.Rows[0].Cells[1].Value.ToString());
            p.dataSend_dataSolve = Convert.ToDouble(infoDataGridView.Rows[0].Cells[2].Value.ToString());
            this.Close();
        }
        private void dataInit()
        {
            infoDataGridView.Rows[0].Cells[0].Value = "2";//数据获取比数据传输
            infoDataGridView.Rows[0].Cells[1].Value = "3";//数据获取比数据处理
            infoDataGridView.Rows[0].Cells[2].Value = "2";//数据传输比数据处理
           
        }
    }
}
