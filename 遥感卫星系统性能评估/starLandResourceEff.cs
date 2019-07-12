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
    public partial class starLandResourceEff : Form
    {
        public starLandResourceEff()
        {
            InitializeComponent();
            dataInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            performanceEvaluation p = (performanceEvaluation)this.Owner;
            p.shuChuanEff_ceKongEff = Convert.ToDouble(starLanddataGrid.Rows[0].Cells[0].Value.ToString());
            p.shuChuanEff_storeEff = Convert.ToDouble(starLanddataGrid.Rows[0].Cells[1].Value.ToString());
            p.ceKongEff_storeEff = Convert.ToDouble(starLanddataGrid.Rows[0].Cells[2].Value.ToString());
            this.Close();
        }
        private void dataInit()
        {
            starLanddataGrid.Rows[0].Cells[0].Value = "2";//
            starLanddataGrid.Rows[0].Cells[1].Value = "5";
            starLanddataGrid.Rows[0].Cells[2].Value = "4";
         
        }
    }
}
