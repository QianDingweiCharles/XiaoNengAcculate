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
    public partial class appPerform : Form
    {
        public appPerform()
        {
            InitializeComponent();
            dataInit();
        }
        private void dataInit()
        {
            appPerfomdataGrid.Rows[0].Cells[0].Value = "0.5";//
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            performanceEvaluation p = (performanceEvaluation)this.Owner;
            p.radiaImageAbility_geoImageAbility = Convert.ToDouble(appPerfomdataGrid.Rows[0].Cells[0].Value.ToString());
            this.Close();
        }
    }
}
