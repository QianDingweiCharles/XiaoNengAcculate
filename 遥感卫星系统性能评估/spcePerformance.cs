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
    public partial class spcePerformance : Form
    {
        public spcePerformance()
        {
            InitializeComponent();
            dataInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            performanceEvaluation p = (performanceEvaluation)this.Owner;
            p.spatialReso_fuWidth = Convert.ToDouble(spaceDataGridView.Rows[0].Cells[0].Value.ToString());
            p.spatialReso_Mssa = Convert.ToDouble(spaceDataGridView.Rows[0].Cells[1].Value.ToString());
            p.fuWidth_Mssa = Convert.ToDouble(spaceDataGridView.Rows[0].Cells[2].Value.ToString());
            this.Close();
        }
        private void dataInit()
        {
            spaceDataGridView.Rows[0].Cells[0].Value = "3";//空间分辨率比幅宽
            spaceDataGridView.Rows[0].Cells[1].Value = "4";//空间分辨率比最大侧摆角
            spaceDataGridView.Rows[0].Cells[2].Value = "1";//幅宽比最大侧摆角
           
        }
    }
}
