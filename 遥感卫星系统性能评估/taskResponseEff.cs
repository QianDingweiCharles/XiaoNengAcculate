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
    public partial class taskResponseEff : Form
    {
        public taskResponseEff()
        {
            InitializeComponent();
            dataInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            performanceEvaluation p = (performanceEvaluation)this.Owner;
            p.targetCoverTimeEff_averageRevisitEff = Convert.ToDouble(observerAbilitydataGrid.Rows[0].Cells[0].Value.ToString());
            p.targetCoverTimeEff_coverNumEff = Convert.ToDouble(observerAbilitydataGrid.Rows[0].Cells[1].Value.ToString());
            p.targetCoverTimeEff_coverRatioEff = Convert.ToDouble(observerAbilitydataGrid.Rows[0].Cells[2].Value.ToString());
            p.averageRevisitEff_coverNumEff = Convert.ToDouble(observerAbilitydataGrid.Rows[0].Cells[3].Value.ToString());
            p.averageRevisitEff_coverRatioEff = Convert.ToDouble(observerAbilitydataGrid.Rows[0].Cells[4].Value.ToString());
            p.coverNumEff_coverRatioEff = Convert.ToDouble(observerAbilitydataGrid.Rows[0].Cells[5].Value.ToString());
            this.Close();
        }
        private void dataInit()
        {
            observerAbilitydataGrid.Rows[0].Cells[0].Value = "2";//
            observerAbilitydataGrid.Rows[0].Cells[1].Value = "3";
            observerAbilitydataGrid.Rows[0].Cells[2].Value = "5";
            observerAbilitydataGrid.Rows[0].Cells[3].Value = "1";
            observerAbilitydataGrid.Rows[0].Cells[4].Value = "4";
            observerAbilitydataGrid.Rows[0].Cells[5].Value = "3";//

        }
    }
}
