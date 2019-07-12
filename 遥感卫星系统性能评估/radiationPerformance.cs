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
    public partial class radiationPerformance : Form
    {
        public radiationPerformance()
        {
            InitializeComponent();
            dataInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            performanceEvaluation p = (performanceEvaluation)this.Owner;
            p.radiationReso_grayLevel = Convert.ToDouble(radiationDataGridView.Rows[0].Cells[0].Value.ToString());
            this.Close();
        }
        private void dataInit()
        {
            radiationDataGridView.Rows[0].Cells[0].Value = "2";//辐射分辨率比灰度级数
            
        }
    }
}
