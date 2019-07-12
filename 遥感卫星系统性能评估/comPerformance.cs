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
    public partial class comPerformance : Form
    {
        public comPerformance()
        {
            InitializeComponent();
            dataInit();//重要性比例默认值
        }

        private void button1_Click(object sender, EventArgs e)
        {
            performanceEvaluation p = (performanceEvaluation)this.Owner;
            p.base_cover =Convert.ToDouble (compose.Rows[0].Cells[0].Value.ToString());
            p.base_info= Convert.ToDouble(compose.Rows[0].Cells[1].Value.ToString());
            p.cover_info= Convert.ToDouble(compose.Rows[0].Cells[2].Value.ToString());
            this.Close();
        }
        //界面初始化
        private void dataInit() {
            compose.Rows[0].Cells[0].Value = "1";//基础比覆盖
            compose.Rows[0].Cells[1].Value = "2";//基础比信息
            compose.Rows[0].Cells[2].Value = "2";//覆盖比信息
        }

        private void comPerformance_Load(object sender, EventArgs e)
        {

        }

        private void compose_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
