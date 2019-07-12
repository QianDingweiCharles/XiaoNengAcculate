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
    public partial class datatransportPerformance : Form
    {
        public datatransportPerformance()
        {
            InitializeComponent();
            dataInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            performanceEvaluation p = (performanceEvaluation)this.Owner;
            p.down_errate = Convert.ToDouble(datatransportDataGridView.Rows[0].Cells[0].Value.ToString());
            p.down_signalToNoiseRatio = Convert.ToDouble(datatransportDataGridView.Rows[0].Cells[1].Value.ToString());
            p.down_packetLossRate = Convert.ToDouble(datatransportDataGridView.Rows[0].Cells[2].Value.ToString());
            p.errate_signalToNoiseRatio = Convert.ToDouble(datatransportDataGridView.Rows[0].Cells[3].Value.ToString());
            p.errate_packetLossRate = Convert.ToDouble(datatransportDataGridView.Rows[0].Cells[4].Value.ToString());
            p.signalToNoiseRatio_packetLossRate= Convert.ToDouble(datatransportDataGridView.Rows[0].Cells[5].Value.ToString());
            this.Close();
        }
        private void dataInit()
        {
            datatransportDataGridView.Rows[0].Cells[0].Value = "2";//下传速率比误码率
            datatransportDataGridView.Rows[0].Cells[1].Value = "4";//下传速率比信噪比
            datatransportDataGridView.Rows[0].Cells[2].Value = "5";//下传速率比丢包率
            datatransportDataGridView.Rows[0].Cells[3].Value = "2";//误码率比信噪比
            datatransportDataGridView.Rows[0].Cells[4].Value = "2";//误码率比丢包率
            datatransportDataGridView.Rows[0].Cells[5].Value = "1";//信噪比比丢包率
            
        }
    }
}
