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
    public partial class spectrumPerformance : Form
    {
        public spectrumPerformance()
        {
            InitializeComponent();
            dataInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            performanceEvaluation p = (performanceEvaluation)this.Owner;
            p.spectrumReso_spectrumRange= Convert.ToDouble(spectrumDataGridView.Rows[0].Cells[0].Value.ToString());
            p.spectrumReso_spectrumNum = Convert.ToDouble(spectrumDataGridView.Rows[0].Cells[1].Value.ToString());
            p.spectrumRange_spectrumNum = Convert.ToDouble(spectrumDataGridView.Rows[0].Cells[2].Value.ToString());
            this.Close();
        }
        private void dataInit()
        {
            spectrumDataGridView.Rows[0].Cells[0].Value = "2";//光谱分辨率比光谱范围
            spectrumDataGridView.Rows[0].Cells[1].Value = "5";//光谱分辨率比光谱个数
            spectrumDataGridView.Rows[0].Cells[2].Value = "2";//光谱范围比光谱个数
           
        }
    }
}
