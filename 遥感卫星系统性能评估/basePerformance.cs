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
    public partial class basePerformance : Form
    {
        public basePerformance()
        {
            InitializeComponent();
            dataInit();//重要性比例初始化
        }

        private void button1_Click(object sender, EventArgs e)
        {
            performanceEvaluation p = (performanceEvaluation)this.Owner;
            p.space_time = Convert.ToDouble(baseDataGridView.Rows[0].Cells[0].Value.ToString());
            p.space_spectrum= Convert.ToDouble(baseDataGridView.Rows[0].Cells[1].Value.ToString());
            p.space_radiation = Convert.ToDouble(baseDataGridView.Rows[0].Cells[2].Value.ToString());
            p.space_accuracy= Convert.ToDouble(baseDataGridView.Rows[0].Cells[3].Value.ToString());
            p.time_spectrum= Convert.ToDouble(baseDataGridView.Rows[0].Cells[4].Value.ToString());
            p.time_radiation= Convert.ToDouble(baseDataGridView.Rows[0].Cells[5].Value.ToString());
            p.time_accuracy= Convert.ToDouble(baseDataGridView.Rows[0].Cells[6].Value.ToString());
            p.spectrum_radiation=Convert.ToDouble(baseDataGridView.Rows[0].Cells[7].Value.ToString());
            p.spectrum_accuracy= Convert.ToDouble(baseDataGridView.Rows[0].Cells[8].Value.ToString());
            p.radiation_accuracy= Convert.ToDouble(baseDataGridView.Rows[0].Cells[9].Value.ToString());
            this.Close();
        }
        private void dataInit()
        {
            baseDataGridView.Rows[0].Cells[0].Value = "2";//空间比时间
            baseDataGridView.Rows[0].Cells[1].Value = "3";//空间比光谱
            baseDataGridView.Rows[0].Cells[2].Value = "3";//空间比辐射
            baseDataGridView.Rows[0].Cells[3].Value = "5";//空间比精度评定
            baseDataGridView.Rows[0].Cells[4].Value = "2";//时间比光谱
            baseDataGridView.Rows[0].Cells[5].Value = "2";//时间比辐射
            baseDataGridView.Rows[0].Cells[6].Value = "3";//时间比精度评定
            baseDataGridView.Rows[0].Cells[7].Value = "5";//光谱比辐射
            baseDataGridView.Rows[0].Cells[8].Value = "2";//光谱比精度评定
            baseDataGridView.Rows[0].Cells[9].Value = "2";//辐射比精度评定
        }
    }
}
