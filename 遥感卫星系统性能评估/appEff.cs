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
    public partial class appEff : Form
    {
        public appEff()
        {
            InitializeComponent();
            dataInit();
        }
        private void dataInit()
        {
            comPerformancedataGrid1.Rows[0].Cells[0].Value = "1";//
            comPerformancedataGrid1.Rows[0].Cells[1].Value = "2";
            comPerformancedataGrid1.Rows[0].Cells[2].Value = "3";
            comPerformancedataGrid1.Rows[0].Cells[3].Value = "2";
            comPerformancedataGrid1.Rows[0].Cells[4].Value = "3";

            comPerformancedataGrid2.Rows[0].Cells[0].Value = "5";
            comPerformancedataGrid2.Rows[0].Cells[1].Value = "2";
            comPerformancedataGrid2.Rows[0].Cells[2].Value = "3";
            comPerformancedataGrid2.Rows[0].Cells[3].Value = "5";
            comPerformancedataGrid2.Rows[0].Cells[4].Value = "3";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            performanceEvaluation p = (performanceEvaluation)this.Owner;
            p.starResouEff_appSatisEff = Convert.ToDouble(comPerformancedataGrid1.Rows[0].Cells[0].Value.ToString());
            p.starResouEff_coverRangeEff = Convert.ToDouble(comPerformancedataGrid1.Rows[0].Cells[1].Value.ToString());
            p.starResouEff_obserAbilityEff = Convert.ToDouble(comPerformancedataGrid1.Rows[0].Cells[2].Value.ToString());
            p.starResouEff_taskResponEff = Convert.ToDouble(comPerformancedataGrid1.Rows[0].Cells[3].Value.ToString());
            p.appSatisEff_coverRangeEff = Convert.ToDouble(comPerformancedataGrid1.Rows[0].Cells[4].Value.ToString());

            p.appSatisEff_obserAbilityEff = Convert.ToDouble(comPerformancedataGrid2.Rows[0].Cells[0].Value.ToString());
            p.appSatisEff_taskResponEff = Convert.ToDouble(comPerformancedataGrid2.Rows[0].Cells[1].Value.ToString());
            p.coverRangeEff_obserAbilityEff = Convert.ToDouble(comPerformancedataGrid2.Rows[0].Cells[2].Value.ToString());
            p.coverRangeEff_taskResponEff = Convert.ToDouble(comPerformancedataGrid2.Rows[0].Cells[3].Value.ToString());
            p.obserAbilityEff_taskResponEff = Convert.ToDouble(comPerformancedataGrid2.Rows[0].Cells[4].Value.ToString());
            this.Close();
        }
    }
}
