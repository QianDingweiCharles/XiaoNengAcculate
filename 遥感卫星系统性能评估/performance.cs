using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace 遥感卫星系统性能评估
{
    public partial class performanceEvaluation : Form
    {
        public performanceEvaluation()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            //窗口放大缩小时，控件也放大缩小,窗口的最大化
            #region
            this.Resize += new EventHandler(Form1_Resize);
            X = this.Width;
            Y = this.Height;
            setTag(this);
            Form1_Resize(new object(), new EventArgs());//x,y可在实例化时赋值,最后这句是新加的，在MDI时有用
            #endregion

            dataGridNormalize();
            comboxInit();

        }

        //窗口最大化
        #region
        private float X;
        private float Y;
        public string str;
        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                    setTag(con);
            }
        }
        private void setControls(float newx, float newy, Control cons)
        {
            foreach (Control con in cons.Controls)
            {

                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });
                float a = Convert.ToSingle(mytag[0]) * newx;
                con.Width = (int)a;
                a = Convert.ToSingle(mytag[1]) * newy;
                con.Height = (int)(a);
                a = Convert.ToSingle(mytag[2]) * newx;
                con.Left = (int)(a);
                a = Convert.ToSingle(mytag[3]) * newy;
                con.Top = (int)(a);
                Single currentSize = Convert.ToSingle(mytag[4]) * Math.Min(newx, newy);
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    setControls(newx, newy, con);
                }
            }

        }
        void Form1_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / X;
            float newy = this.Height / Y;
            setControls(newx, newy, this);
            //this.Text = this.Width.ToString() + " " + this.Height.ToString();
            combox_ToFormResize();

        }
        #endregion

        //传感器类型CheckBox点击之后，title的text变化
        #region
        //存储checked的载荷或者卫星
        private ArrayList loads = new ArrayList();
        private void SAR_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);

        }

        private void microwaveAltimeter_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void microwaveRadiometer_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void microwaveScatterometer_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void panchromatic_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void visibleLight_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void shimmer_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void hyperspectral_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void infrared_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void ultraviolet_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void laser_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void electromagnetic_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        //卫星checked
        private void HY1C_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void HY2A_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void HY2B_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void GF3_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void ZY301_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void ZY302_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void GF7_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void FY3C_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void FY3D_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void FY4_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void xx101_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void xx102_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void xx103_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void xx2_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void xx3_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void start1_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void start201_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void start202_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void start203_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void start204_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void start205_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }

        private void start206_CheckedChanged(object sender, EventArgs e)
        {
            isCHeckedToTitle(sender, e);
        }
        //如果checked了就把text放进ArrayList，否则从队列删除
        private void isCHeckedToTitle(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.Checked)
            {
                loads.Add(cb.Text.ToString());
            }
            else
            {
                loads.Remove(cb.Text.ToString());
            }
            title.Text = "";
            for (int i = 0; i < loads.Count; i++)
            {
                if (i != loads.Count - 1)
                {
                    title.Text = title.Text + loads[i].ToString() + "&&";
                }
                else
                {
                    title.Text = title.Text + loads[i].ToString();
                }
            }
        }

        #endregion

        //AHP  AHP-FCE算法界面矩阵初始化
        #region
        //AHP 算法界面矩阵初始化
        //private void AHPdataGridView()
        //{
        //    AHPdataGridView1 基础性能指标矩阵
        //    AHdataGridView1.RowHeadersWidth = 110;
        //    int n1 = AHdataGridView1.Columns.Count;
        //    AHdataGridView1.Rows.Add(n1);  //添加3行
        //    AHdataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    for (int i = 0; i < n1; i++)
        //    {
        //        AHdataGridView1.Rows[i].HeaderCell.Value = AHdataGridView1.Columns[i].HeaderText;
        //    }
        //    AHdataGridView1.Rows[0].Cells[0].Value = "1";
        //    AHdataGridView1.Rows[0].Cells[1].Value = "2";
        //    AHdataGridView1.Rows[0].Cells[2].Value = "3";
        //    AHdataGridView1.Rows[1].Cells[0].Value = "0.50";
        //    AHdataGridView1.Rows[1].Cells[1].Value = "1";
        //    AHdataGridView1.Rows[1].Cells[2].Value = "2";
        //    AHdataGridView1.Rows[2].Cells[0].Value = "0.33";
        //    AHdataGridView1.Rows[2].Cells[1].Value = "0.50";
        //    AHdataGridView1.Rows[2].Cells[2].Value = "1";
        //    AHdataGridView1[0, 0].ReadOnly = true;
        //    AHdataGridView1[1, 1].ReadOnly = true;
        //    AHdataGridView1[2, 2].ReadOnly = true;
        //    AHPdataGridView2 空间性能指标矩阵
        //    AHdataGridView2.RowHeadersWidth = 110;
        //    int n2 = AHdataGridView2.Columns.Count;
        //    AHdataGridView2.Rows.Add(n2);  //添加3行
        //    AHdataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    for (int i = 0; i < n2; i++)
        //    {
        //        AHdataGridView2.Rows[i].HeaderCell.Value = AHdataGridView2.Columns[i].HeaderText;
        //    }
        //    AHdataGridView2.Rows[0].Cells[0].Value = "1";
        //    AHdataGridView2.Rows[0].Cells[1].Value = "3";
        //    AHdataGridView2.Rows[0].Cells[2].Value = "4";
        //    AHdataGridView2.Rows[1].Cells[0].Value = "0.33";
        //    AHdataGridView2.Rows[1].Cells[1].Value = "1";
        //    AHdataGridView2.Rows[1].Cells[2].Value = "1";
        //    AHdataGridView2.Rows[2].Cells[0].Value = "0.25";
        //    AHdataGridView2.Rows[2].Cells[1].Value = "1";
        //    AHdataGridView2.Rows[2].Cells[2].Value = "1";
        //    AHdataGridView2[0, 0].ReadOnly = true;
        //    AHdataGridView2[1, 1].ReadOnly = true;
        //    AHdataGridView2[2, 2].ReadOnly = true;
        //    AHPdataGridView3 时间性能指标矩阵
        //    AHdataGridView3.RowHeadersWidth = 110;
        //    int n3 = AHdataGridView3.Columns.Count;
        //    AHdataGridView3.Rows.Add(n3);  //添加3行
        //    AHdataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    for (int i = 0; i < n3; i++)
        //    {
        //        AHdataGridView3.Rows[i].HeaderCell.Value = AHdataGridView3.Columns[i].HeaderText;
        //    }
        //    AHdataGridView3.Rows[0].Cells[0].Value = "1";
        //    AHdataGridView3.Rows[0].Cells[1].Value = "1";
        //    AHdataGridView3.Rows[1].Cells[0].Value = "1";
        //    AHdataGridView3.Rows[1].Cells[1].Value = "1";
        //    AHdataGridView3[0, 0].ReadOnly = true;
        //    AHdataGridView3[1, 1].ReadOnly = true;
        //    AHPdataGridView4 光谱性能指标矩阵
        //    AHdataGridView4.RowHeadersWidth = 110;
        //    int n4 = AHdataGridView4.Columns.Count;
        //    AHdataGridView4.Rows.Add(n4);  //添加3行
        //    AHdataGridView4.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    for (int i = 0; i < n4; i++)
        //    {
        //        AHdataGridView4.Rows[i].HeaderCell.Value = AHdataGridView4.Columns[i].HeaderText;
        //    }
        //    AHdataGridView4.Rows[0].Cells[0].Value = "1";
        //    AHdataGridView4.Rows[0].Cells[1].Value = "2";
        //    AHdataGridView4.Rows[0].Cells[2].Value = "5";
        //    AHdataGridView4.Rows[1].Cells[0].Value = "0.5";
        //    AHdataGridView4.Rows[1].Cells[1].Value = "1";
        //    AHdataGridView4.Rows[1].Cells[2].Value = "2";
        //    AHdataGridView4.Rows[2].Cells[0].Value = "0.20";
        //    AHdataGridView4.Rows[2].Cells[1].Value = "0.5";
        //    AHdataGridView4.Rows[2].Cells[2].Value = "1";
        //    AHdataGridView4[0, 0].ReadOnly = true;
        //    AHdataGridView4[1, 1].ReadOnly = true;
        //    AHdataGridView4[2, 2].ReadOnly = true;
        //}
        ////AHP-FCE算法界面矩阵初始化
        //private void FCEdataGridView()
        //{
        //    //FCEdataGridView1 基础性能指标矩阵
        //    FCEdataGridView1.RowHeadersWidth = 110;
        //    int n1 = FCEdataGridView1.Columns.Count;
        //    FCEdataGridView1.Rows.Add(n1);  //添加3行
        //    FCEdataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    for (int i = 0; i < n1; i++)
        //    {
        //        FCEdataGridView1.Rows[i].HeaderCell.Value = FCEdataGridView1.Columns[i].HeaderText;
        //    }
        //    FCEdataGridView1.Rows[0].Cells[0].Value = "1";
        //    FCEdataGridView1.Rows[0].Cells[1].Value = "2";
        //    FCEdataGridView1.Rows[0].Cells[2].Value = "3";
        //    FCEdataGridView1.Rows[1].Cells[0].Value = "0.50";
        //    FCEdataGridView1.Rows[1].Cells[1].Value = "1";
        //    FCEdataGridView1.Rows[1].Cells[2].Value = "2";
        //    FCEdataGridView1.Rows[2].Cells[0].Value = "0.33";
        //    FCEdataGridView1.Rows[2].Cells[1].Value = "0.50";
        //    FCEdataGridView1.Rows[2].Cells[2].Value = "1";
        //    FCEdataGridView1[0, 0].ReadOnly = true;
        //    FCEdataGridView1[1, 1].ReadOnly = true;
        //    FCEdataGridView1[2, 2].ReadOnly = true;



        //    //FCEdataGridView2 空间性能指标矩阵
        //    FCEdataGridView2.RowHeadersWidth = 110;
        //    int n2 = FCEdataGridView2.Columns.Count;
        //    FCEdataGridView2.Rows.Add(n2);  //添加3行
        //    FCEdataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    for (int i = 0; i < n2; i++)
        //    {
        //        FCEdataGridView2.Rows[i].HeaderCell.Value = FCEdataGridView2.Columns[i].HeaderText;
        //    }
        //    FCEdataGridView2.Rows[0].Cells[0].Value = "1";
        //    FCEdataGridView2.Rows[0].Cells[1].Value = "3";
        //    FCEdataGridView2.Rows[0].Cells[2].Value = "4";
        //    FCEdataGridView2.Rows[1].Cells[0].Value = "0.33";
        //    FCEdataGridView2.Rows[1].Cells[1].Value = "1";
        //    FCEdataGridView2.Rows[1].Cells[2].Value = "1";
        //    FCEdataGridView2.Rows[2].Cells[0].Value = "0.25";
        //    FCEdataGridView2.Rows[2].Cells[1].Value = "1";
        //    FCEdataGridView2.Rows[2].Cells[2].Value = "1";
        //    FCEdataGridView2[0, 0].ReadOnly = true;
        //    FCEdataGridView2[1, 1].ReadOnly = true;
        //    FCEdataGridView2[2, 2].ReadOnly = true;



        //    //FCEdataGridView3 时间性能指标矩阵
        //    FCEdataGridView3.RowHeadersWidth = 110;
        //    int n3 = FCEdataGridView3.Columns.Count;
        //    FCEdataGridView3.Rows.Add(n3);  //添加3行
        //    FCEdataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    for (int i = 0; i < n3; i++)
        //    {
        //        FCEdataGridView3.Rows[i].HeaderCell.Value = FCEdataGridView3.Columns[i].HeaderText;
        //    }
        //    FCEdataGridView3.Rows[0].Cells[0].Value = "1";
        //    FCEdataGridView3.Rows[0].Cells[1].Value = "1";
        //    FCEdataGridView3.Rows[1].Cells[0].Value = "1";
        //    FCEdataGridView3.Rows[1].Cells[1].Value = "1";
        //    FCEdataGridView3[0, 0].ReadOnly = true;
        //    FCEdataGridView3[1, 1].ReadOnly = true;

        //    //FCEdataGridView4 光谱性能指标矩阵
        //    FCEdataGridView4.RowHeadersWidth = 110;
        //    int n4 = FCEdataGridView4.Columns.Count;
        //    FCEdataGridView4.Rows.Add(n4);  //添加3行
        //    FCEdataGridView4.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    for (int i = 0; i < n4; i++)
        //    {
        //        FCEdataGridView4.Rows[i].HeaderCell.Value = FCEdataGridView4.Columns[i].HeaderText;
        //    }
        //    FCEdataGridView4.Rows[0].Cells[0].Value = "1";
        //    FCEdataGridView4.Rows[0].Cells[1].Value = "2";
        //    FCEdataGridView4.Rows[0].Cells[2].Value = "5";
        //    FCEdataGridView4.Rows[1].Cells[0].Value = "0.5";
        //    FCEdataGridView4.Rows[1].Cells[1].Value = "1";
        //    FCEdataGridView4.Rows[1].Cells[2].Value = "2";
        //    FCEdataGridView4.Rows[2].Cells[0].Value = "0.20";
        //    FCEdataGridView4.Rows[2].Cells[1].Value = "0.5";
        //    FCEdataGridView4.Rows[2].Cells[2].Value = "1";
        //    FCEdataGridView4[0, 0].ReadOnly = true;
        //    FCEdataGridView4[1, 1].ReadOnly = true;
        //    FCEdataGridView4[2, 2].ReadOnly = true;
        //}
        #endregion

        //用户更改AHP权重矩阵
        #region
        //private void AHdataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    int row = e.RowIndex;
        //    int col = e.ColumnIndex;
        //    string s = AHdataGridView1.Rows[row].Cells[col].Value.ToString();//修改的值
        //    double change_num = 1.0 / Convert.ToDouble(s);
        //    AHdataGridView1.Rows[col].Cells[row].Value = change_num.ToString("f3");
        //}
        //private void AHdataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    int row = e.RowIndex;
        //    int col = e.ColumnIndex;
        //    string s = AHdataGridView2.Rows[row].Cells[col].Value.ToString();//修改的值
        //    double change_num = 1.0 / Convert.ToDouble(s);
        //    AHdataGridView2.Rows[col].Cells[row].Value = change_num.ToString("f3");
        //}
        //private void AHdataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    int row = e.RowIndex;
        //    int col = e.ColumnIndex;
        //    string s = AHdataGridView3.Rows[row].Cells[col].Value.ToString();//修改的值
        //    double change_num = 1.0 / Convert.ToDouble(s);
        //    AHdataGridView3.Rows[col].Cells[row].Value = change_num.ToString("f3");
        //}
        //private void AHdataGridView4_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    int row = e.RowIndex;
        //    int col = e.ColumnIndex;
        //    string s = AHdataGridView4.Rows[row].Cells[col].Value.ToString();//修改的值
        //    double change_num = 1.0 / Convert.ToDouble(s);
        //    AHdataGridView4.Rows[col].Cells[row].Value = change_num.ToString("f3");
        //}
        #endregion

        //用户更改FCE权重矩阵
        #region
        //private void FCEdataGridView1_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        //{
        //    int row = e.RowIndex;
        //    int col = e.ColumnIndex;
        //    string s = FCEdataGridView1.Rows[row].Cells[col].Value.ToString();//修改的值
        //    double change_num = 1.0 / Convert.ToDouble(s);
        //    FCEdataGridView1.Rows[col].Cells[row].Value = change_num.ToString("f3");
        //}

        //private void FCEdataGridView2_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        //{
        //    int row = e.RowIndex;
        //    int col = e.ColumnIndex;
        //    string s = FCEdataGridView2.Rows[row].Cells[col].Value.ToString();//修改的值
        //    double change_num = 1.0 / Convert.ToDouble(s);
        //    FCEdataGridView2.Rows[col].Cells[row].Value = change_num.ToString("f3");
        //}

        //private void FCEdataGridView3_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        //{
        //    int row = e.RowIndex;
        //    int col = e.ColumnIndex;
        //    string s = FCEdataGridView3.Rows[row].Cells[col].Value.ToString();//修改的值
        //    double change_num = 1.0 / Convert.ToDouble(s);
        //    FCEdataGridView3.Rows[col].Cells[row].Value = change_num.ToString("f3");
        //}

        //private void FCEdataGridView4_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        //{
        //    int row = e.RowIndex;
        //    int col = e.ColumnIndex;
        //    string s = FCEdataGridView4.Rows[row].Cells[col].Value.ToString();//修改的值
        //    double change_num = 1.0 / Convert.ToDouble(s);
        //    FCEdataGridView4.Rows[col].Cells[row].Value = change_num.ToString("f3");
        //}
        #endregion

        //修改参数设定方法
        #region
        //AHP页面选择不同的参数设定方法
        //private void AHPcomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (AHPcomboBox1.SelectedIndex == 0)
        //    {
        //        AHPpanel1.Visible = true;
        //        AHPpanel1.Location = new Point(8, 32);
        //        AHPpanel2.Visible = false;
        //        AHPpanel2.Location = new Point(-500, -500);
        //    }
        //    else
        //    {
        //        AHPpanel1.Visible = false;
        //        AHPpanel2.Visible = true;
        //        AHPpanel2.Location = new Point(8, 32);
        //        AHPpanel1.Location = new Point(-500, -500);
        //    }
        //}
        ////AHP-FCE页面选择不同的参数设定方法
        //private void FCEcomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (FCEcomboBox1.SelectedIndex == 0)
        //    {
        //        FCEpanel1.Visible = true;
        //        FCEpanel1.Location = new Point(8, 32);
        //        FCEpanel2.Visible = false;
        //        FCEpanel2.Location = new Point(-500, -500);
        //    }
        //    else
        //    {
        //        FCEpanel1.Visible = false;
        //        FCEpanel2.Visible = true;
        //        FCEpanel2.Location = new Point(8, 32);
        //        FCEpanel1.Location = new Point(-500, -500);
        //    }
        //}
        #endregion

        //选向卡横着的
        #region
        //private void analysistabControl_DrawItem(object sender, DrawItemEventArgs e)
        //{
        //    string text = ((TabControl)sender).TabPages[e.Index].Text;

        //    SolidBrush brush = new SolidBrush(Color.Black);

        //    StringFormat sf = new StringFormat(StringFormatFlags.DirectionRightToLeft);

        //    sf.LineAlignment = StringAlignment.Center;

        //    sf.Alignment = StringAlignment.Center;

        //    e.Graphics.DrawString(text, SystemInformation.MenuFont, brush, e.Bounds, sf);
        //}
        //动态修改表头第一个字段名称
        #endregion

        //统计分析的时候点击某个节点的变化
        #region
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            analysisdataGridView.Columns[0].HeaderText = e.Node.Text.ToString() + "指标";
        }
        #endregion

        //参数设置的时候，点击某个按钮，弹出对应的填参数的窗口
        #region


        public double base_cover = 1, base_info = 2, cover_info = 2;
        private void btnFirst_Click(object sender, EventArgs e)
        {
            comPerformance com = new comPerformance();
            com.ShowDialog(this);
        }


        public double space_time = 2, space_spectrum = 3, space_radiation = 3, space_accuracy = 5, time_spectrum = 2;
        public double time_radiation = 2, time_accuracy = 3, spectrum_radiation = 1, spectrum_accuracy = 2, radiation_accuracy = 2;
        private void btnSecondbase_Click(object sender, EventArgs e)
        {
            basePerformance baseP = new basePerformance();
            baseP.ShowDialog(this);
        }

        public double coverTime_coverSpace = 1;//覆盖时效性能比覆盖空间性能
        private void btnSecondcover_Click(object sender, EventArgs e)
        {
            coverPerformance coverP = new coverPerformance();
            coverP.ShowDialog(this);
        }
        //数据获取比数据传输，数据获取比数据处理，数据传输比数据处理
        public double dataGet_dataSend = 2, dataGet_dataSolve = 3, dataSend_dataSolve = 2;
        private void btnSecondinfo_Click(object sender, EventArgs e)
        {
            informationPerformance infoP = new informationPerformance();
            infoP.ShowDialog(this);
        }

        //空间分辨率、幅宽、最大侧摆角重要性比例
        public double spatialReso_fuWidth = 3, spatialReso_Mssa = 4, fuWidth_Mssa = 1;
        private void btnThirdspace_Click(object sender, EventArgs e)
        {
            spcePerformance spaceP = new spcePerformance();
            spaceP.ShowDialog(this);
        }

        //时间性能指标重要性比例
        public double orbitCycle_revisite = 1;
        private void btnThirdtime_Click(object sender, EventArgs e)
        {
            timePerformance timeP = new timePerformance();
            timeP.ShowDialog(this);
        }

        //光谱性能指标重要性比例
        public double spectrumReso_spectrumRange = 2, spectrumReso_spectrumNum = 5, spectrumRange_spectrumNum = 2;
        private void btnThirdspectrum_Click(object sender, EventArgs e)
        {
            spectrumPerformance spectrumP = new spectrumPerformance();
            spectrumP.ShowDialog(this);
        }
        //辐射性能指标重要性比例
        public double radiationReso_grayLevel = 2;
        private void btnThirdradiation_Click(object sender, EventArgs e)
        {
            radiationPerformance radiationP = new radiationPerformance();
            radiationP.ShowDialog(this);
        }
        //精度评定指标重要性比例
        public double dingZi_dingGui = 5, dingZi_dingWei = 3, dingGui_dingWei = 0.5;



        private void btnThirdacuracy_Click(object sender, EventArgs e)
        {
            accuracyPerformance accuracyP = new accuracyPerformance();
            accuracyP.ShowDialog(this);
        }
        //覆盖时效性能指标重要性比例
        public double coverTimeRatio_reCoverTime = 2, coverTimeRatio_avgResonseTime = 4, coverTimeRatio_agvGapTime = 5;
        public double reCoverTime_avgResonseTime = 2, reCoverTime_agvGapTime = 2;
        public double avgResonseTime_agvGapTime = 1;
        private void btnThirdcovertime_Click(object sender, EventArgs e)
        {
            coveragePerformance coverageP = new coveragePerformance();
            coverageP.ShowDialog(this);
        }
        //覆盖空间性能指标重要性比例
        public double coverageOverlapRate_cumCoverageAreaRatio = 0.5;
        private void btnThirdcoverspace_Click(object sender, EventArgs e)
        {
            coverspacePerformance coverspaceP = new coverspacePerformance();
            coverspaceP.ShowDialog(this);
        }
        //数据获取指标重要性比例
        public double perDateGetData_radiationDingBiaoAccuracy = 3;
        private void btnThirddataget_Click(object sender, EventArgs e)
        {
            datagetPerformance datagetP = new datagetPerformance();
            datagetP.ShowDialog(this);
        }
        //数据传输性能指标重要性比例
        public double down_errate = 2, down_signalToNoiseRatio = 4, down_packetLossRate = 5;
        public double errate_signalToNoiseRatio = 2, errate_packetLossRate = 2;
        public double signalToNoiseRatio_packetLossRate = 1;
        private void btnThirddatasend_Click(object sender, EventArgs e)
        {
            datatransportPerformance datatransportP = new datatransportPerformance();
            datatransportP.ShowDialog(this);
        }
        //数据处理重要性比例
        public double perDateSolveData_solveDelay = 3;
        private void btnThirddatasolve_Click(object sender, EventArgs e)
        {
            datasolvePerformance datasolveP = new datasolvePerformance();
            datasolveP.ShowDialog(this);
        }
        #endregion

        //确定按钮，要是用户不修改重要性，则各个矩阵用默认值，要是用户修改重要性比例，则取出修改后的值，放在矩阵里面
        //也就是这个按钮是必须的，只有点击了这个按钮，重要性比例才会存到对应的矩阵中
        #region
        //以下矩阵存重要性比例
        private double[,] comPerforMatrix;//第一层权重矩阵，基础性能，覆盖性能，信息性能
        private double[,] basePerforMatrix;//基础性能权重矩阵
        private double[,] coverPerforMatrix;//覆盖性能权重矩阵
        private double[,] infoPerforMatrix;//信息性能权重矩阵
        private double[,] spatialPerforMatrix;//空间性能权重矩阵
        private double[,] timePerforMatrix;//时间性能权重矩阵
        private double[,] spectrumPerforMatrix;//光谱性能权重矩阵
        private double[,] radiationPerforMatrix;//辐射性能权重矩阵
        private double[,] accuracyPerforMatrix;//精度评定权重矩阵
        private double[,] coverTimeMatrix;//覆盖时效性能权重矩阵



        private double[,] coverSpaceMatrix;//覆盖空间性能
        private double[,] dataGetMatrix;//数据获取权重矩阵
        private double[,] dataSendMatrix;//数据传输权重矩阵
        private double[,] dataSolveMatrix;//数据处理权重矩阵

        //以下一维向量存权重矩阵算出的权重或者用户直接设定的权重。
        private double[] comPerforVector;//基础性能，覆盖性能，信息性能对应的权重向量

        private double[] basePerforVector;//基础性能下的权重向量
        private double[] coverPerforVector;//覆盖性能下的权重向量
        private double[] infoPerforVector;//信息性能下的权重向量

        private double[] spatialPerforVector;//空间性能下的权重向量
        private double[] timePerforVector;//时间性能下的权重向量
        private double[] spectrumPerforVector;//光谱性能下的权重向量
        private double[] radiationPerforVector;//辐射性能下的权重向量
        private double[] accuracyPerforVector;//精度评定下的权重向量
        private double[] coverTimePerforVector;//覆盖时效性能下的权重向量
        private double[] coverSpacePerforVector;//覆盖空间性能下的权重向量
        private double[] dataGetPerforVector;//数据获取下的权重向量
        private double[] dataSendPerforVector;//数据传输下的权重向量
        private double[] dataSolvePerforVector;//数据处理下的权重向量
        //确定按钮，要是用户不修改重要性，则各个矩阵用默认值，要是用户修改重要性比例，则取出修改后的值，放在矩阵里面
        //也就是这个按钮是必须的，只有点击了这个按钮，重要性比例才会存到对应的矩阵中
        private void boxText2Vector()
        {
            if (parameterComboBox.SelectedIndex == 0)//如果选择的是第一个参数设置方法
            {
                //生成权重矩阵
                comPerforMatrix = new double[3, 3] { { 1.0, base_cover, base_info }, { 1.0 / base_cover, 1.0, cover_info }, { 1.0 / base_info, 1.0 / cover_info, 1.0 } };//第一层权重矩阵，基础性能，覆盖性能，信息性能
                basePerforMatrix = new double[5, 5] { { 1, space_time, space_spectrum, space_radiation, space_accuracy },
                    { 1.0/space_time,1,time_spectrum,time_radiation,time_accuracy},
                    { 1.0/space_spectrum,1.0/time_spectrum,1,spectrum_radiation,spectrum_accuracy},
                    { 1.0/space_radiation,1.0/time_radiation,1.0/spectrum_radiation,1,radiation_accuracy},
                    { 1.0/space_accuracy,1.0/time_accuracy,1.0/spectrum_accuracy,1.0/radiation_accuracy,1} };
                coverPerforMatrix = new double[2, 2] { { 1, coverTime_coverSpace }, { 1.0 / coverTime_coverSpace, 1 } };
                infoPerforMatrix = new double[3, 3] { { 1, dataGet_dataSend, dataGet_dataSolve }, { 1.0 / dataGet_dataSend, 1, dataSend_dataSolve }, { 1.0 / dataGet_dataSolve, 1.0 / dataSend_dataSolve, 1 } };
                spatialPerforMatrix = new double[3, 3] { { 1, spatialReso_fuWidth, spatialReso_Mssa }, { 1.0 / spatialReso_fuWidth, 1, fuWidth_Mssa }, { 1.0 / spatialReso_Mssa, 1.0 / fuWidth_Mssa, 1 } };
                timePerforMatrix = new double[2, 2] { { 1, orbitCycle_revisite }, { 1.0 / orbitCycle_revisite, 1 } };
                spectrumPerforMatrix = new double[3, 3] { { 1, spectrumReso_spectrumRange, spectrumReso_spectrumNum }, { 1.0 / spectrumReso_spectrumRange, 1, spectrumRange_spectrumNum }, { 1.0 / spectrumReso_spectrumNum, 1.0 / spectrumRange_spectrumNum, 1 } };
                radiationPerforMatrix = new double[2, 2] { { 1, radiationReso_grayLevel }, { 1.0 / radiationReso_grayLevel, 1 } };
                accuracyPerforMatrix = new double[3, 3] { { 1, dingZi_dingGui, dingZi_dingWei }, { 1.0 / dingZi_dingGui, 1, dingGui_dingWei }, { 1.0 / dingZi_dingWei, 1.0 / dingGui_dingWei, 1 } };
                coverTimeMatrix = new double[4, 4] { { 1, coverTimeRatio_reCoverTime ,coverTimeRatio_avgResonseTime,coverTimeRatio_agvGapTime},
                    { 1.0/coverTimeRatio_reCoverTime,1,reCoverTime_avgResonseTime,reCoverTime_agvGapTime},
                    { 1.0/coverTimeRatio_avgResonseTime,1.0/reCoverTime_avgResonseTime,1,avgResonseTime_agvGapTime},
                    { 1.0/coverTimeRatio_agvGapTime,1.0/reCoverTime_agvGapTime,1.0/avgResonseTime_agvGapTime,1} };
                coverSpaceMatrix = new double[2, 2] { { 1, coverageOverlapRate_cumCoverageAreaRatio }, { 1.0 / coverageOverlapRate_cumCoverageAreaRatio, 1 } };
                dataGetMatrix = new double[2, 2] { { 1, perDateGetData_radiationDingBiaoAccuracy }, { 1.0 / perDateGetData_radiationDingBiaoAccuracy, 1 } };
                dataSendMatrix = new double[4, 4] { { 1, down_errate, down_signalToNoiseRatio, down_packetLossRate }, { 1.0 / down_errate, 1, errate_signalToNoiseRatio, errate_packetLossRate }, { 1.0 / down_signalToNoiseRatio, 1.0 / errate_signalToNoiseRatio, 1, signalToNoiseRatio_packetLossRate }, { 1.0 / down_packetLossRate, 1.0 / errate_packetLossRate, 1.0 / signalToNoiseRatio_packetLossRate, 1 } };
                dataSolveMatrix = new double[2, 2] { { 1, perDateSolveData_solveDelay }, { 1.0 / perDateSolveData_solveDelay, 1 } };


                //生成权重向量
                comPerforVector = matrixTovector(comPerforMatrix);//基础性能，覆盖性能，信息性能权重矩阵对应的权重向量
                basePerforVector = matrixTovector(basePerforMatrix);//基础性能下的权重向量
                coverPerforVector = matrixTovector(coverPerforMatrix);//覆盖性能下的权重向量
                infoPerforVector = matrixTovector(infoPerforMatrix);//信息性能下
                spatialPerforVector = matrixTovector(spatialPerforMatrix);//空间性能下的
                timePerforVector = matrixTovector(timePerforMatrix);//时间性能下的
                spectrumPerforVector = matrixTovector(spectrumPerforMatrix);//光谱性能下的
                radiationPerforVector = matrixTovector(radiationPerforMatrix);//辐射性能下的
                accuracyPerforVector = matrixTovector(accuracyPerforMatrix);//精度评定下的
                coverTimePerforVector = matrixTovector(coverTimeMatrix);//覆盖时效性能下的
                coverSpacePerforVector = matrixTovector(coverSpaceMatrix);//覆盖空间性能下的
                dataGetPerforVector = matrixTovector(dataGetMatrix);//数据获取下的
                dataSendPerforVector = matrixTovector(dataSendMatrix);//数据处理下的
                dataSolvePerforVector = matrixTovector(dataSolveMatrix);//数据处理下的  
            }
            else {
                comPerforVector = new double[3] { Convert.ToDouble(baseTxtBox.Text.ToString()), Convert.ToDouble(coverTxtBox.Text.ToString()), Convert.ToDouble(infoTxtBox.Text.ToString()) };
                basePerforVector = new double[5] { Convert.ToDouble(spaceTxtBox.Text.ToString()), Convert.ToDouble(timeTxtBox.Text.ToString()), Convert.ToDouble(spectrumTxtBox.Text.ToString()), Convert.ToDouble(radiationTxtBox.Text.ToString()), Convert.ToDouble(accuracyTxtBox.Text.ToString()) };
                coverPerforVector = new double[2] { Convert.ToDouble(coverTimeTxtBox.Text.ToString()), Convert.ToDouble(coverSpaceTxtBox.Text.ToString()) };
                infoPerforVector = new double[3] { Convert.ToDouble(dataGetTxtBox.Text.ToString()), Convert.ToDouble(dataSendTxtBox.Text.ToString()), Convert.ToDouble(dataSolveTxtBox.Text.ToString()) };
                spatialPerforVector = new double[3] { Convert.ToDouble(spatialResoTxtBox.Text.ToString()), Convert.ToDouble(fuWidthTxtBox.Text.ToString()), Convert.ToDouble(MssaTxtBox.Text.ToString()) };
                timePerforVector = new double[2] { Convert.ToDouble(orbitCycleTxtBox.Text.ToString()), Convert.ToDouble(revisitCycleTxtBox.Text.ToString()) };
                spectrumPerforVector = new double[3] { Convert.ToDouble(spectrumResoTxtBox.Text.ToString()), Convert.ToDouble(spectrumRangeTxtBox.Text.ToString()), Convert.ToDouble(spectrumNumTxtBox.Text.ToString()) };
                radiationPerforVector = new double[2] { Convert.ToDouble(radiationResoTxtBox.Text.ToString()), Convert.ToDouble(grayLevelTxtBox.Text.ToString()) };
                accuracyPerforVector = new double[3] { Convert.ToDouble(dingZiTxtBox.Text.ToString()), Convert.ToDouble(dingGuiTxtBox.Text.ToString()), Convert.ToDouble(dingWeiTxtBox.Text.ToString()) };
                coverTimePerforVector = new double[4] { Convert.ToDouble(coverTimeRatioTxtBox.Text.ToString()), Convert.ToDouble(reCoverTimeRatioTxtBox.Text.ToString()), Convert.ToDouble(avgResponseTimeTxtBox.Text.ToString()), Convert.ToDouble(avgGapCycleTxtBox.Text.ToString()) };
                coverSpacePerforVector = new double[2] { Convert.ToDouble(coverageOverlapRateTxtBox.Text.ToString()), Convert.ToDouble(cumCoverageAreaRatioTxtBox.Text.ToString()) };
                dataGetPerforVector = new double[2] { Convert.ToDouble(dataNumTxtBox.Text.ToString()), Convert.ToDouble(dingBiaoTxtBox.Text.ToString()) };
                dataSendPerforVector = new double[4] { Convert.ToDouble(downRateTxtBox.Text.ToString()), Convert.ToDouble(errateTxtBox.Text.ToString()), Convert.ToDouble(sinalRatioTxtBox.Text.ToString()), Convert.ToDouble(pocketLossTxtBox.Text.ToString()) };
                dataSolvePerforVector = new double[2] { Convert.ToDouble(perDaySolveNumTxtBox.Text.ToString()), Convert.ToDouble(solveDelayTxtBox.Text.ToString()) };

            }
        }

        //函数weightsTovector输入一个权重矩阵（对称）返回该矩阵的特征向量
        static double[] matrixTovector(double[,] weights)
        {

            int row = weights.GetLength(0);
            int column = weights.GetLength(1);
            double[] product_col = new double[row];//存每一行的连乘积 
            double[] sqrt_col = new double[row];//寸每一行连乘开根号后
            double sum = 0.0;//归一化的和
            //计算每一行的乘积   
            for (int i = 0; i < row; i++)
            {
                product_col[i] = 1;
                for (int j = 0; j < column; j++)
                {
                    product_col[i] = product_col[i] * weights[i, j];
                }
            }
            //开n次根号
            for (int i = 0; i < row; i++)
            {
                sqrt_col[i] = Math.Pow(product_col[i], 1.0 / row);
                sum = sum + sqrt_col[i];
            }
            for (int i = 0; i < row; i++)
            {
                sqrt_col[i] = sqrt_col[i] / sum;
            }
            return sqrt_col;//返回计算的特征值
        }
        #endregion

        //第一个panel中树形图中画连接线
        #region
        private void AHPpanel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 1);
            double btn1x, btn1y, btn2x, btn2y, btn3x, btn3y, btn4x, btn4y, btn5x, btn5y, btn6x, btn6y, btn7x, btn7y, btn8x, btn8y, btn9x, btn9y, btn10x, btn10y, btn11x, btn11y, btn12x, btn12y, btn13x, btn13y, btn14x, btn14y, btn15x, btn15y, btn16x, btn16y, btn17x, btn17y, btn18x, btn18y;
            double x1, y1, x2, y2, x3, y3, x4, y4, x5, y5, x6, y6, x7, y7, x8, y8, x9, y9, x10, y10, x11, y11, x12, y12, x13, y13, x14, y14;
            //综合效能和覆盖性能之间的连线
            btn1x = btnFirst.Location.X + btnFirst.Width / 2.0;//btn1是综合效能按钮下面的中间按钮
            btn1y = btnFirst.Location.Y + btnFirst.Height;
            btn2x = btnSecondcover.Location.X + btnSecondcover.Width / 2.0;//btn2是
            btn2y = btnSecondcover.Location.Y;
            Point btnPoint1 = new Point(Convert.ToInt32(btn1x), Convert.ToInt32(btn1y - 0.5));//对应btn1
            Point btnPoint2 = new Point(Convert.ToInt32(btn2x), Convert.ToInt32(btn2y));//对应btn2
            g.DrawLine(pen, btnPoint1, btnPoint2);

            //综合效能和基础性能之间的连线
            btn3x = btnSecondcover.Location.X + btnSecondcover.Width / 2.0;//btn3对应覆盖性能下面中间的点
            btn3y = btnSecondcover.Location.Y + btnSecondcover.Height;
            x1 = btn1x;//(x1,y1)指综合效能和覆盖性能中间的点
            y1 = btn1y + (btn2y - btn1y) / 2;
            x2 = btnSecondbase.Location.X + btnSecondbase.Width / 2.0;
            y2 = y1;//(x2,y2)指基础性能上面的点
            Point btnPoint3 = new Point(Convert.ToInt32(x1), Convert.ToInt32(y1));//指综合效能和覆盖性能中间的点
            Point btnPoint4 = new Point(Convert.ToInt32(x2), Convert.ToInt32(y2));//基础性能上面的点
            g.DrawLine(pen, btnPoint3, btnPoint4);//连接综合效能和覆盖性能中间的点到基础性能上面的点

            //连接基础性能上面的点和基础性能上中点
            btn4x = btnSecondbase.Location.X + btnSecondbase.Width / 2.0;
            btn4y = btnSecondbase.Location.Y;
            Point btnPoint5 = new Point(Convert.ToInt32(btn4x), Convert.ToInt32(btn4y));//基础性能上中点
            g.DrawLine(pen, btnPoint4, btnPoint5);

            //连接信息性能上面的点和综合效能和覆盖性能中间的点
            x3 = btnSecondinfo.Location.X + btnSecondinfo.Width / 2.0;
            y3 = y1;
            Point btnPoint6 = new Point(Convert.ToInt32(x3), Convert.ToInt32(y3));//信息性能上面的点
            g.DrawLine(pen, btnPoint3, btnPoint6);

            //连接信息性能上面的点和信息性能上中点
            btn5x = x3;
            btn5y = btnSecondinfo.Location.Y;
            Point btnPoint7 = new Point(Convert.ToInt32(btn5x), Convert.ToInt32(btn5y));//信息性能上中点
            g.DrawLine(pen, btnPoint6, btnPoint7);

            //连接基础性能下面的点和光谱性能上中点
            btn6x = btn4x;
            btn6y = btnSecondbase.Location.Y + btnSecondbase.Height;
            Point btnPoint8 = new Point(Convert.ToInt32(btn6x), Convert.ToInt32(btn6y));//基础性能下中点
            btn7x = btnThirdspectrum.Location.X + btnThirdspectrum.Width / 2.0;
            btn7y = btnThirdspectrum.Location.Y;
            Point btnPoint9 = new Point(Convert.ToInt32(btn7x), Convert.ToInt32(btn7y));//光谱性能上中点
            g.DrawLine(pen, btnPoint8, btnPoint9);

            //(x4,y4)光谱性能和基础性能中间的点
            x4 = btn7x;
            y4 = btn6y + (btn7y - btn6y) / 2.0;
            Point btnPoint10 = new Point(Convert.ToInt32(x4), Convert.ToInt32(y4)); //光谱性能和基础性能中间的点

            //空间性能上面的点
            x5 = btnThirdspace.Location.X + btnThirdspace.Width / 2.0;
            y5 = y4;
            Point btnPoint11 = new Point(Convert.ToInt32(x5), Convert.ToInt32(y5));//空间性能上面的点
            //连接空间性能上面的点和光谱性能和基础性能中间的点
            g.DrawLine(pen, btnPoint10, btnPoint11);

            //空间性能上中点
            btn8x = x5;
            btn8y = btnThirdspace.Location.Y;
            Point btnPoint12 = new Point(Convert.ToInt32(btn8x), Convert.ToInt32(btn8y));//空间性能上中点

            //连接空间上中点和空间性能上面的点
            g.DrawLine(pen, btnPoint11, btnPoint12);

            //时间性能上面的点
            x6 = btnThirdtime.Location.X + btnThirdtime.Width / 2.0;
            y6 = y4;
            Point btnPoint13 = new Point(Convert.ToInt32(x6), Convert.ToInt32(y6));//时间性能上面的点

            //时间性能上中点
            btn9x = x6;
            btn9y = btnThirdtime.Location.Y;
            Point btnPoint14 = new Point(Convert.ToInt32(btn9x), Convert.ToInt32(btn9y)); //时间性能上中点
            g.DrawLine(pen, btnPoint13, btnPoint14);//连接时间性能上面的点和上中点

            //辐射性能上面的点
            x7 = btnThirdradiation.Location.X + btnThirdradiation.Width / 2.0;
            y7 = y4;
            Point btnPoint15 = new Point(Convert.ToInt32(x7), Convert.ToInt32(y7));//辐射性能上面的点
            g.DrawLine(pen, btnPoint10, btnPoint15);//连接辐射性能上面的点和光谱性能和基础性能中间的点

            //辐射性能上中点
            btn10x = x7;
            btn10y = btnThirdradiation.Location.Y;
            Point btnPoint16 = new Point(Convert.ToInt32(btn10x), Convert.ToInt32(btn10y)); //辐射性能上中点
            g.DrawLine(pen, btnPoint15, btnPoint16);//连接辐射性能上面的点和辐射性能上中点

            //精度评定上面的点
            x8 = btnThirdacuracy.Location.X + btnThirdacuracy.Width / 2.0;
            y8 = y4;
            Point btnPoint17 = new Point(Convert.ToInt32(x8), Convert.ToInt32(y8)); //精度评定上面的点
            g.DrawLine(pen, btnPoint15, btnPoint17);//连接精度评定上面的点和辐射性能上面的点
            //精度评定上中点
            btn11x = x8;
            btn11y = btnThirdacuracy.Location.Y;
            Point btnPoint18 = new Point(Convert.ToInt32(btn11x), Convert.ToInt32(btn11y));//精度评定上中点
            g.DrawLine(pen, btnPoint17, btnPoint18);//连接精度评定上面的点和上中点

            //覆盖性能下中点
            btn12x = btnSecondcover.Location.X + btnSecondcover.Width / 2.0;
            btn12y = btnSecondcover.Location.Y + btnSecondcover.Height;
            Point btnPoint19 = new Point(Convert.ToInt32(btn12x), Convert.ToInt32(btn12y));//覆盖性能下中点

            //覆盖性能下面和时效性和空间性的中点
            x9 = btn12x;
            y9 = y4;
            Point btnPoint20 = new Point(Convert.ToInt32(x9), Convert.ToInt32(y9));//覆盖性能下面和时效性和空间性的中点
            g.DrawLine(pen, btnPoint19, btnPoint20);//连接覆盖性能下中点和覆盖性能下面和时效性和空间性的中点

            //覆盖时效性能上面的点
            x10 = btnThirdcovertime.Location.X + btnThirdcovertime.Width / 2.0;
            y10 = y4;
            Point btnPoint21 = new Point(Convert.ToInt32(x10), Convert.ToInt32(y10));//覆盖时效性能上面的点
            g.DrawLine(pen, btnPoint20, btnPoint21);

            //覆盖时效性能上中点
            btn13x = x10;
            btn13y = btnThirdcovertime.Location.Y;
            Point btnPoint22 = new Point(Convert.ToInt32(btn13x), Convert.ToInt32(btn13y));//覆盖时效性能上中点
            g.DrawLine(pen, btnPoint21, btnPoint22);//连接覆盖时效性能上面的点和上中点

            //覆盖空间性能上面的点
            x11 = btnThirdcoverspace.Location.X + btnThirdcoverspace.Width / 2.0;
            y11 = y4;
            Point btnPoint23 = new Point(Convert.ToInt32(x11), Convert.ToInt32(y11));//覆盖空间性能上面的点
            g.DrawLine(pen, btnPoint20, btnPoint23);

            //覆盖空间性能上中点
            btn14x = x11;
            btn14y = btnThirdcoverspace.Location.Y;
            Point btnPoint24 = new Point(Convert.ToInt32(btn14x), Convert.ToInt32(btn14y));//覆盖空间性能上中点
            g.DrawLine(pen, btnPoint23, btnPoint24);//连接覆盖空间性能上面的点和上中点

            //信息性能下中点
            btn15x = btnSecondinfo.Location.X + btnSecondinfo.Width / 2.0;
            btn15y = btnSecondinfo.Location.Y + btnSecondinfo.Height;
            Point btnPoint25 = new Point(Convert.ToInt32(btn15x), Convert.ToInt32(btn15y));//信息性能下中点

            //数据传输上中点
            btn16x = btnThirddatasend.Location.X + btnThirddatasend.Width / 2.0;
            btn16y = btnThirddatasend.Location.Y;
            Point btnPoint26 = new Point(Convert.ToInt32(btn16x), Convert.ToInt32(btn16y)); //数据传输上中点
            g.DrawLine(pen, btnPoint25, btnPoint26);//连接信息性能下中点和数据传输上中点

            //数据传输上面的中点
            x12 = btn16x;
            y12 = y4;
            Point btnPoint27 = new Point(Convert.ToInt32(x12), Convert.ToInt32(y12));
            //数据获取上面中点
            x13 = btnThirddataget.Location.X + btnThirddataget.Width / 2.0;
            y13 = y4;
            Point btnPoint28 = new Point(Convert.ToInt32(x13), Convert.ToInt32(y13)); //数据获取上面中点
            g.DrawLine(pen, btnPoint27, btnPoint28);//连接数据传输上面的中点和数据获取上面中点

            //数据获取上中点
            btn17x = x13;
            btn17y = btnThirddataget.Location.Y;
            Point btnPoint29 = new Point(Convert.ToInt32(btn17x), Convert.ToInt32(btn17y)); //数据获取上中点
            g.DrawLine(pen, btnPoint28, btnPoint29);//连接数据获取上面的中点和数据获取上中点

            //数据处理上面中点
            x14 = btnThirddatasolve.Location.X + btnThirddatasolve.Width / 2.0;
            y14 = y4;
            Point btnPoint30 = new Point(Convert.ToInt32(x14), Convert.ToInt32(y14)); //数据处理上面中点
            g.DrawLine(pen, btnPoint27, btnPoint30);

            btn18x = x14;
            btn18y = btnThirddatasolve.Location.Y;
            Point btnPoint31 = new Point(Convert.ToInt32(btn18x), Convert.ToInt32(btn18y)); //数据处理上中点
            g.DrawLine(pen, btnPoint30, btnPoint31);
        }
        #endregion

        //选择不同的参数设置方法
        #region
        private void parameterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (parameterComboBox.SelectedIndex == 0)
            {
                AHPpanel1.Visible = true;
                AHPpanel1.Location = new Point(125, 44);
                AHPpanel2.Visible = false;

            }
            else
            {
                AHPpanel1.Visible = false;
                AHPpanel2.Visible = true;
                AHPpanel2.Location = new Point(55, 36);

            }
        }

        //窗体大小改变触发事件
        void combox_ToFormResize()
        {
            if (parameterComboBox.SelectedIndex == 0)
            {
                AHPpanel1.Visible = true;
                AHPpanel2.Visible = false;
                AHPpanel1.Location = new Point(125, 44);
            }
            else
            {
                AHPpanel1.Visible = false;
                AHPpanel2.Visible = true;
                AHPpanel2.Location = new Point(55, 36);
            }
        }

        //选择参数设置方法初始化
        void comboxInit()
        {
            //性能评估
            parameterComboBox.SelectedIndex = 0;
            AHPpanel1.Location = new Point(125, 44);
            AHPpanel1.Visible = true;
            AHPpanel2.Visible = false;
            //效能评估
            parameterEffComboBox.SelectedIndex = 0;
            panel1.Visible = true;
            panel2.Visible = false;
            panel1.Location = new Point(53, 58);

            //体系贡献度
            parameterComboBox2.SelectedIndex = 0;
            panel3.Visible = true;
            panel4.Visible = false;
            panel3.Location = new Point(145, 28);


        }
        #endregion

        //第二个panel中树形图中连接线
        private void AHPpanel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 1);
            double btn1x, btn1y, btn2x, btn2y, btn3x, btn3y, btn4x, btn4y, btn5x, btn5y, btn6x, btn6y, btn7x, btn7y, btn8x, btn8y, btn9x, btn9y, btn10x, btn10y, btn11x, btn11y, btn12x, btn12y, btn13x, btn13y, btn14x, btn14y, btn15x, btn15y, btn16x, btn16y, btn17x, btn17y, btn18x, btn18y;
            double x1, y1, x2, y2, x3, y3, x4, y4, x5, y5, x6, y6, x7, y7, x8, y8, x9, y9, x10, y10, x11, y11, x12, y12, x13, y13, x14, y14;
            //综合效能和覆盖性能之间的连线
            btn1x = btnFirst2.Location.X + btnFirst2.Width / 2.0;//btn1是综合效能按钮下面的中间按钮
            btn1y = btnFirst2.Location.Y + btnFirst2.Height;
            btn2x = btnSecondcover2.Location.X + btnSecondcover2.Width / 2.0;//btn2是
            btn2y = btnSecondcover2.Location.Y;
            Point btnPoint1 = new Point(Convert.ToInt32(btn1x), Convert.ToInt32(btn1y - 0.5));//对应btn1
            Point btnPoint2 = new Point(Convert.ToInt32(btn2x), Convert.ToInt32(btn2y));//对应btn2
            g.DrawLine(pen, btnPoint1, btnPoint2);

            //综合效能和基础性能之间的连线
            btn3x = btnSecondcover2.Location.X + btnSecondcover2.Width / 2.0;//btn3对应覆盖性能下面中间的点
            btn3y = btnSecondcover2.Location.Y + btnSecondcover2.Height;
            x1 = btn1x;//(x1,y1)指综合效能和覆盖性能中间的点
            y1 = btn1y + (btn2y - btn1y) / 2;
            x2 = btnSecondbase2.Location.X + btnSecondbase2.Width / 2.0;
            y2 = y1;//(x2,y2)指基础性能上面的点
            Point btnPoint3 = new Point(Convert.ToInt32(x1), Convert.ToInt32(y1));//指综合效能和覆盖性能中间的点
            Point btnPoint4 = new Point(Convert.ToInt32(x2), Convert.ToInt32(y2));//基础性能上面的点
            g.DrawLine(pen, btnPoint3, btnPoint4);//连接综合效能和覆盖性能中间的点到基础性能上面的点

            //连接基础性能上面的点和基础性能上中点
            btn4x = btnSecondbase2.Location.X + btnSecondbase2.Width / 2.0;
            btn4y = btnSecondbase2.Location.Y;
            Point btnPoint5 = new Point(Convert.ToInt32(btn4x), Convert.ToInt32(btn4y));//基础性能上中点
            g.DrawLine(pen, btnPoint4, btnPoint5);

            //连接信息性能上面的点和综合效能和覆盖性能中间的点
            x3 = btnSecondinfo2.Location.X + btnSecondinfo2.Width / 2.0;
            y3 = y1;
            Point btnPoint6 = new Point(Convert.ToInt32(x3), Convert.ToInt32(y3));//信息性能上面的点
            g.DrawLine(pen, btnPoint3, btnPoint6);

            //连接信息性能上面的点和信息性能上中点
            btn5x = x3;
            btn5y = btnSecondinfo2.Location.Y;
            Point btnPoint7 = new Point(Convert.ToInt32(btn5x), Convert.ToInt32(btn5y));//信息性能上中点
            g.DrawLine(pen, btnPoint6, btnPoint7);

            //连接基础性能下面的点和光谱性能上中点
            btn6x = btn4x;
            btn6y = btnSecondbase2.Location.Y + btnSecondbase2.Height;
            Point btnPoint8 = new Point(Convert.ToInt32(btn6x), Convert.ToInt32(btn6y));//基础性能下中点
            btn7x = btnThirdspectrum2.Location.X + btnThirdspectrum2.Width / 2.0;
            btn7y = btnThirdspectrum2.Location.Y;
            Point btnPoint9 = new Point(Convert.ToInt32(btn7x), Convert.ToInt32(btn7y));//光谱性能上中点
            g.DrawLine(pen, btnPoint8, btnPoint9);

            //(x4,y4)光谱性能和基础性能中间的点
            x4 = btn7x;
            y4 = btn6y + (btn7y - btn6y) / 2.0;
            Point btnPoint10 = new Point(Convert.ToInt32(x4), Convert.ToInt32(y4)); //光谱性能和基础性能中间的点

            //空间性能上面的点
            x5 = btnThirdspace2.Location.X + btnThirdspace2.Width / 2.0;
            y5 = y4;
            Point btnPoint11 = new Point(Convert.ToInt32(x5), Convert.ToInt32(y5));//空间性能上面的点
            //连接空间性能上面的点和光谱性能和基础性能中间的点
            g.DrawLine(pen, btnPoint10, btnPoint11);

            //空间性能上中点
            btn8x = x5;
            btn8y = btnThirdspace2.Location.Y;
            Point btnPoint12 = new Point(Convert.ToInt32(btn8x), Convert.ToInt32(btn8y));//空间性能上中点

            //连接空间上中点和空间性能上面的点
            g.DrawLine(pen, btnPoint11, btnPoint12);

            //时间性能上面的点
            x6 = btnThirdtime2.Location.X + btnThirdtime2.Width / 2.0;
            y6 = y4;
            Point btnPoint13 = new Point(Convert.ToInt32(x6), Convert.ToInt32(y6));//时间性能上面的点

            //时间性能上中点
            btn9x = x6;
            btn9y = btnThirdtime2.Location.Y;
            Point btnPoint14 = new Point(Convert.ToInt32(btn9x), Convert.ToInt32(btn9y)); //时间性能上中点
            g.DrawLine(pen, btnPoint13, btnPoint14);//连接时间性能上面的点和上中点

            //辐射性能上面的点
            x7 = btnThirdradiation2.Location.X + btnThirdradiation2.Width / 2.0;
            y7 = y4;
            Point btnPoint15 = new Point(Convert.ToInt32(x7), Convert.ToInt32(y7));//辐射性能上面的点
            g.DrawLine(pen, btnPoint10, btnPoint15);//连接辐射性能上面的点和光谱性能和基础性能中间的点

            //辐射性能上中点
            btn10x = x7;
            btn10y = btnThirdradiation2.Location.Y;
            Point btnPoint16 = new Point(Convert.ToInt32(btn10x), Convert.ToInt32(btn10y)); //辐射性能上中点
            g.DrawLine(pen, btnPoint15, btnPoint16);//连接辐射性能上面的点和辐射性能上中点

            //精度评定上面的点
            x8 = btnThirdacuracy2.Location.X + btnThirdacuracy2.Width / 2.0;
            y8 = y4;
            Point btnPoint17 = new Point(Convert.ToInt32(x8), Convert.ToInt32(y8)); //精度评定上面的点
            g.DrawLine(pen, btnPoint15, btnPoint17);//连接精度评定上面的点和辐射性能上面的点
            //精度评定上中点
            btn11x = x8;
            btn11y = btnThirdacuracy2.Location.Y;
            Point btnPoint18 = new Point(Convert.ToInt32(btn11x), Convert.ToInt32(btn11y));//精度评定上中点
            g.DrawLine(pen, btnPoint17, btnPoint18);//连接精度评定上面的点和上中点

            //覆盖性能下中点
            btn12x = btnSecondcover2.Location.X + btnSecondcover2.Width / 2.0;
            btn12y = btnSecondcover2.Location.Y + btnSecondcover2.Height;
            Point btnPoint19 = new Point(Convert.ToInt32(btn12x), Convert.ToInt32(btn12y));//覆盖性能下中点

            //覆盖性能下面和时效性和空间性的中点
            x9 = btn12x;
            y9 = y4;
            Point btnPoint20 = new Point(Convert.ToInt32(x9), Convert.ToInt32(y9));//覆盖性能下面和时效性和空间性的中点
            g.DrawLine(pen, btnPoint19, btnPoint20);//连接覆盖性能下中点和覆盖性能下面和时效性和空间性的中点

            //覆盖时效性能上面的点
            x10 = btnThirdcovertime2.Location.X + btnThirdcovertime2.Width / 2.0;
            y10 = y4;
            Point btnPoint21 = new Point(Convert.ToInt32(x10), Convert.ToInt32(y10));//覆盖时效性能上面的点
            g.DrawLine(pen, btnPoint20, btnPoint21);

            //覆盖时效性能上中点
            btn13x = x10;
            btn13y = btnThirdcovertime2.Location.Y;
            Point btnPoint22 = new Point(Convert.ToInt32(btn13x), Convert.ToInt32(btn13y));//覆盖时效性能上中点
            g.DrawLine(pen, btnPoint21, btnPoint22);//连接覆盖时效性能上面的点和上中点

            //覆盖空间性能上面的点
            x11 = btnThirdcoverspace2.Location.X + btnThirdcoverspace2.Width / 2.0;
            y11 = y4;
            Point btnPoint23 = new Point(Convert.ToInt32(x11), Convert.ToInt32(y11));//覆盖空间性能上面的点
            g.DrawLine(pen, btnPoint20, btnPoint23);

            //覆盖空间性能上中点
            btn14x = x11;
            btn14y = btnThirdcoverspace2.Location.Y;
            Point btnPoint24 = new Point(Convert.ToInt32(btn14x), Convert.ToInt32(btn14y));//覆盖空间性能上中点
            g.DrawLine(pen, btnPoint23, btnPoint24);//连接覆盖空间性能上面的点和上中点

            //信息性能下中点
            btn15x = btnSecondinfo2.Location.X + btnSecondinfo2.Width / 2.0;
            btn15y = btnSecondinfo2.Location.Y + btnSecondinfo2.Height;
            Point btnPoint25 = new Point(Convert.ToInt32(btn15x), Convert.ToInt32(btn15y));//信息性能下中点

            //数据传输上中点
            btn16x = btnThirddatasend2.Location.X + btnThirddatasend2.Width / 2.0;
            btn16y = btnThirddatasend2.Location.Y;
            Point btnPoint26 = new Point(Convert.ToInt32(btn16x), Convert.ToInt32(btn16y)); //数据传输上中点
            g.DrawLine(pen, btnPoint25, btnPoint26);//连接信息性能下中点和数据传输上中点

            //数据传输上面的中点
            x12 = btn16x;
            y12 = y4;
            Point btnPoint27 = new Point(Convert.ToInt32(x12), Convert.ToInt32(y12));
            //数据获取上面中点
            x13 = btnThirddataget2.Location.X + btnThirddataget2.Width / 2.0;
            y13 = y4;
            Point btnPoint28 = new Point(Convert.ToInt32(x13), Convert.ToInt32(y13)); //数据获取上面中点
            g.DrawLine(pen, btnPoint27, btnPoint28);//连接数据传输上面的中点和数据获取上面中点

            //数据获取上中点
            btn17x = x13;
            btn17y = btnThirddataget2.Location.Y;
            Point btnPoint29 = new Point(Convert.ToInt32(btn17x), Convert.ToInt32(btn17y)); //数据获取上中点
            g.DrawLine(pen, btnPoint28, btnPoint29);//连接数据获取上面的中点和数据获取上中点

            //数据处理上面中点
            x14 = btnThirddatasolve2.Location.X + btnThirddatasolve2.Width / 2.0;
            y14 = y4;
            Point btnPoint30 = new Point(Convert.ToInt32(x14), Convert.ToInt32(y14)); //数据处理上面中点
            g.DrawLine(pen, btnPoint27, btnPoint30);

            btn18x = x14;
            btn18y = btnThirddatasolve2.Location.Y;
            Point btnPoint31 = new Point(Convert.ToInt32(btn18x), Convert.ToInt32(btn18y)); //数据处理上中点
            g.DrawLine(pen, btnPoint30, btnPoint31);

            //第三层指标连接线
            double btn19x, btn19y, btn20x, btn20y, btn21x, btn21y, btn22x, btn22y, btn23x, btn23y, btn24x, btn24y, btn25x, btn25y, btn26x, btn26y, btn27x, btn27y;
            double mid3x, mid3y, x15, y15, x16, y16, x17, y17, x18, y18, x19, y19;
            //空间性能下中点
            btn19x = btnThirdspace2.Location.X + btnThirdspace2.Width / 2.0;
            btn19y = btnThirdspace2.Location.Y + btnThirdspace2.Height;
            Point btnPoint32 = new Point(Convert.ToInt32(btn19x), Convert.ToInt32(btn19y));//空间性能下中点
            //幅宽上中点
            btn20x = fuWidth.Location.X + fuWidth.Width / 2.0;
            btn20y = fuWidth.Location.Y;
            Point btnPoint33 = new Point(Convert.ToInt32(btn20x), Convert.ToInt32(btn20y));
            g.DrawLine(pen, btnPoint32, btnPoint33);
            mid3x = btn20x;
            mid3y = btn19y + (btn20y - btn19y) / 2.0;
            Point btnPoint34 = new Point(Convert.ToInt32(mid3x), Convert.ToInt32(mid3y));//空间性能下中点和幅宽上中点之间的中点

            //空间分辨率上面的点
            x15 = kongjianResolution.Location.X + kongjianResolution.Width / 2.0;
            y15 = mid3y;
            Point btnPoint35 = new Point(Convert.ToInt32(x15), Convert.ToInt32(y15));
            g.DrawLine(pen, btnPoint34, btnPoint35);

            //空间分辨率上中点
            btn21x = x15;
            btn21y = kongjianResolution.Location.Y;
            Point btnPoint36 = new Point(Convert.ToInt32(btn21x), Convert.ToInt32(btn21y));
            g.DrawLine(pen, btnPoint35, btnPoint36);

            //最大侧摆角上面的点
            x16 = Mssa.Location.X + Mssa.Width / 2.0;
            y16 = mid3y;
            Point btnPoint37 = new Point(Convert.ToInt32(x16), Convert.ToInt32(y16));
            g.DrawLine(pen, btnPoint34, btnPoint37);

            //最大侧摆角上中点
            btn22x = x16;
            btn22y = Mssa.Location.Y;
            Point btnPoint38 = new Point(Convert.ToInt32(btn22x), Convert.ToInt32(btn22y));
            g.DrawLine(pen, btnPoint37, btnPoint38);
            //时间性能下中点
            btn23x = btnThirdtime2.Location.X + btnThirdtime2.Width / 2.0;
            btn23y = btnThirdtime2.Location.Y + btnThirdtime2.Height;
            Point btnPoint39 = new Point(Convert.ToInt32(btn23x), Convert.ToInt32(btn23y)); //时间性能下中点
            Point btnPoint40 = new Point(Convert.ToInt32(btn23x), Convert.ToInt32(mid3y));//轨道周期和重访周期上面中间点
            g.DrawLine(pen, btnPoint39, btnPoint40);
            x17 = guiDaoCycle.Location.X + guiDaoCycle.Width / 2.0;
            y17 = mid3y;
            Point btnPoint41 = new Point(Convert.ToInt32(x17), Convert.ToInt32(y17));//轨道周期上面的点
            g.DrawLine(pen, btnPoint40, btnPoint41);

            btn23x = x17;
            btn23y = guiDaoCycle.Location.Y;
            Point btnPoint42 = new Point(Convert.ToInt32(btn23x), Convert.ToInt32(btn23y));//轨道周期上中点
            g.DrawLine(pen, btnPoint42, btnPoint41);

            x18 = revisiteCycle.Location.X + revisiteCycle.Width / 2.0;
            y18 = mid3y;
            Point btnPoint43 = new Point(Convert.ToInt32(x18), Convert.ToInt32(y18));//重访周期上面的点
            g.DrawLine(pen, btnPoint40, btnPoint43);

            btn24x = x18;
            btn24y = revisiteCycle.Location.Y;
            Point btnPoint44 = new Point(Convert.ToInt32(btn24x), Convert.ToInt32(btn24y));//重访周期上中点
            g.DrawLine(pen, btnPoint43, btnPoint44);

            //光谱性能下中点
            btn25x = btnThirdspectrum2.Location.X + btnThirdspectrum2.Width / 2.0;
            btn25y = btnThirdspectrum2.Location.Y + btnThirdspectrum2.Height;
            Point btnPoint45 = new Point(Convert.ToInt32(btn25x), Convert.ToInt32(btn25y));// 光谱性能下中点
            //光谱性能和光谱范围中间点
            x19 = btn25x;
            y19 = mid3y;
            Point btnPoint46 = new Point(Convert.ToInt32(x19), Convert.ToInt32(y19));//光谱性能和光谱范围中间点
            g.DrawLine(pen, btnPoint45, btnPoint46);
            double x19x, x19y;//光谱范围上面的点
            x19x = guanpuRange.Location.X + guanpuRange.Width / 2.0;
            x19y = mid3y;
            Point btnPointx19x = new Point(Convert.ToInt32(x19x), Convert.ToInt32(x19y));//光谱范围上面的点
            g.DrawLine(pen, btnPoint46, btnPointx19x);
            //光谱范围上中点
            btn26x = guanpuRange.Location.X + guanpuRange.Width / 2.0;
            btn26y = guanpuRange.Location.Y;
            Point btnPoint47 = new Point(Convert.ToInt32(btn26x), Convert.ToInt32(btn26y));
            g.DrawLine(pen, btnPointx19x, btnPoint47);//连接光谱性能和光谱范围

            //光谱分辨率上面的点
            double x20, y20, x21, y21, x22, y22, x23, y23, x24, y24, x25, y25;
            double btn28x, btn28y, btn29x, btn29y, btn30x, btn30y, btn31x, btn31y, btn32x, btn32y, btn33x, btn33y;
            x20 = guanpuResolution.Location.X + guanpuResolution.Width / 2.0;
            y20 = mid3y;
            Point btnPoint48 = new Point(Convert.ToInt32(x20), Convert.ToInt32(y20));//光谱分辨率上面的点
            g.DrawLine(pen, btnPoint46, btnPoint48);

            //光谱分辨率上中点
            btn27x = guanpuResolution.Location.X + guanpuResolution.Width / 2.0;
            btn27y = guanpuResolution.Location.Y;
            Point btnPoint49 = new Point(Convert.ToInt32(btn27x), Convert.ToInt32(btn27y));
            g.DrawLine(pen, btnPoint48, btnPoint49);//连接光谱分辨率上中点和光谱分辨率上面的点
            //光谱个数上面的点
            x21 = spectralNumber.Location.X + spectralNumber.Width / 2.0;
            y21 = mid3y;
            Point btnPoint50 = new Point(Convert.ToInt32(x21), Convert.ToInt32(y21));//光谱分辨率上面的点
            g.DrawLine(pen, btnPoint46, btnPoint50);

            //光谱个数上中点
            btn28x = x21;
            btn28y = spectralNumber.Location.Y;
            Point btnPoint51 = new Point(Convert.ToInt32(btn28x), Convert.ToInt32(btn28y));
            g.DrawLine(pen, btnPoint50, btnPoint51);//连接光谱分辨率上中点和光谱分辨率上面的点
            //------------------------------------------
            //辐射性能下中点
            btn29x = btnThirdradiation2.Location.X + btnThirdradiation2.Width / 2.0;
            btn29y = btnThirdradiation2.Location.Y + btnThirdradiation2.Height;
            Point btnPoint52 = new Point(Convert.ToInt32(btn29x), Convert.ToInt32(btn29y)); //辐射性能下中点
            Point btnPoint53 = new Point(Convert.ToInt32(btn29x), Convert.ToInt32(mid3y));//辐射分辨率和灰度级数上面中间点
            g.DrawLine(pen, btnPoint52, btnPoint53);
            x22 = radiationResolution.Location.X + radiationResolution.Width / 2.0;
            y22 = mid3y;
            Point btnPoint54 = new Point(Convert.ToInt32(x22), Convert.ToInt32(y22));//辐射分辨率上面的点
            g.DrawLine(pen, btnPoint54, btnPoint53);

            btn30x = x22;
            btn30y = radiationResolution.Location.Y;
            Point btnPoint55 = new Point(Convert.ToInt32(btn30x), Convert.ToInt32(btn30y));//辐射分辨率上中点
            g.DrawLine(pen, btnPoint54, btnPoint55);

            x23 = grayLavel.Location.X + grayLavel.Width / 2.0;
            y23 = mid3y;
            Point btnPoint56 = new Point(Convert.ToInt32(x23), Convert.ToInt32(y23));//灰度级数上面的点
            g.DrawLine(pen, btnPoint53, btnPoint56);

            btn31x = x23;
            btn31y = grayLavel.Location.Y;
            Point btnPoint57 = new Point(Convert.ToInt32(btn31x), Convert.ToInt32(btn31y));//灰度级数上中点
            g.DrawLine(pen, btnPoint57, btnPoint56);

            //-------------------------------------------------
            //精度评定下中点
            btn32x = btnThirdacuracy2.Location.X + btnThirdacuracy2.Width / 2.0;
            btn32y = btnThirdacuracy2.Location.Y + btnThirdacuracy2.Height;
            Point btnPoint58 = new Point(Convert.ToInt32(btn32x), Convert.ToInt32(btn32y));//精度评定下中点
            //定轨精度上中点
            btn33x = dingGuiaccuracy.Location.X + dingGuiaccuracy.Width / 2.0;
            btn33y = dingGuiaccuracy.Location.Y;
            Point btnPoint59 = new Point(Convert.ToInt32(btn33x), Convert.ToInt32(btn33y));

            Point btnPoint60 = new Point(Convert.ToInt32(btn32x), Convert.ToInt32(mid3y));//精度评定下面的中间点
            g.DrawLine(pen, btnPoint58, btnPoint60);
            double x33x, y33y;//定轨精度上面的点
            x33x = btn33x;
            y33y = mid3y;
            Point btnPointx33x = new Point(Convert.ToInt32(x33x), Convert.ToInt32(y33y));//定轨精度上面的点
            g.DrawLine(pen, btnPointx33x, btnPoint59);

            //定姿精度上面的点
            x24 = dingZiAccuracy.Location.X + dingZiAccuracy.Width / 2.0;
            y24 = mid3y;
            Point btnPoint61 = new Point(Convert.ToInt32(x24), Convert.ToInt32(y24));
            g.DrawLine(pen, btnPoint60, btnPoint61);


            double btn34x, btn34y, btn35x, btn35y;
            //定姿精度上中点
            btn34x = x24;
            btn34y = dingZiAccuracy.Location.Y;
            Point btnPoint62 = new Point(Convert.ToInt32(btn34x), Convert.ToInt32(btn34y));
            g.DrawLine(pen, btnPoint62, btnPoint61);

            //定位精度上面的点
            x25 = dingWeiaccuracy.Location.X + dingWeiaccuracy.Width / 2.0;
            y25 = mid3y;
            Point btnPoint63 = new Point(Convert.ToInt32(x25), Convert.ToInt32(y25));
            g.DrawLine(pen, btnPoint60, btnPoint63);

            //定位精度上中点
            btn35x = x25;
            btn35y = dingWeiaccuracy.Location.Y;
            Point btnPoint64 = new Point(Convert.ToInt32(btn35x), Convert.ToInt32(btn35y));
            g.DrawLine(pen, btnPoint63, btnPoint64);

            //覆盖时效性能下中点
            double btn36x, btn36y, btn37x, btn37y, btn38x, btn38y, btn39x, btn39y, btn40x, btn40y;
            double x26, y26, x27, y27, x28, y28, x29, y29, x30, y30;
            btn36x = btnThirdcovertime2.Location.X + btnThirdcovertime2.Width / 2.0;
            btn36y = btnThirdcovertime2.Location.Y + btnThirdcovertime2.Height;
            Point btnPoint65 = new Point(Convert.ToInt32(btn36x), Convert.ToInt32(btn36y));
            //覆盖时效性能下面的中间点
            x26 = btn36x;
            y26 = mid3y;
            Point btnPoint66 = new Point(Convert.ToInt32(x26), Convert.ToInt32(y26));
            g.DrawLine(pen, btnPoint65, btnPoint66);
            //覆盖时间百分比上面的点
            x27 = coverTimeRatio.Location.X + coverTimeRatio.Width / 2.0;
            y27 = mid3y;
            Point btnPoint67 = new Point(Convert.ToInt32(x27), Convert.ToInt32(y27));
            g.DrawLine(pen, btnPoint67, btnPoint66);

            //覆盖时间百分比上中点
            btn37x = x27;
            btn37y = coverTimeRatio.Location.Y;
            Point btnPoint68 = new Point(Convert.ToInt32(btn37x), Convert.ToInt32(btn37y));
            g.DrawLine(pen, btnPoint67, btnPoint68);

            //重复覆盖时间百分比上面的点
            x28 = reCoverTimeRatio.Location.X + reCoverTimeRatio.Width / 2.0;
            y28 = mid3y;
            Point btnPoint69 = new Point(Convert.ToInt32(x28), Convert.ToInt32(y28));

            //重复覆盖时间百分比上中点
            btn38x = x28;
            btn38y = reCoverTimeRatio.Location.Y;
            Point btnPoint70 = new Point(Convert.ToInt32(btn38x), Convert.ToInt32(btn38y));
            g.DrawLine(pen, btnPoint69, btnPoint70);
            //--------------------------------------
            //平均间隙周期上面的点
            x29 = avgGapCycle.Location.X + avgGapCycle.Width / 2.0;
            y29 = mid3y;
            Point btnPoint71 = new Point(Convert.ToInt32(x29), Convert.ToInt32(y29));
            g.DrawLine(pen, btnPoint71, btnPoint66);

            //平均间隙周期上中点
            btn39x = x29;
            btn39y = avgGapCycle.Location.Y;
            Point btnPoint72 = new Point(Convert.ToInt32(btn39x), Convert.ToInt32(btn39y));
            g.DrawLine(pen, btnPoint72, btnPoint71);

            //平均响应时间上面的点
            x30 = avgResponseTime.Location.X + avgResponseTime.Width / 2.0;
            y30 = mid3y;
            Point btnPoint73 = new Point(Convert.ToInt32(x30), Convert.ToInt32(y30));

            //平均响应时间上中点
            btn40x = x30;
            btn40y = avgResponseTime.Location.Y;
            Point btnPoint74 = new Point(Convert.ToInt32(btn40x), Convert.ToInt32(btn40y));
            g.DrawLine(pen, btnPoint73, btnPoint74);

            //---------------------------------------------
            //覆盖空间性能下中点
            double btn41x, btn41y, btn42x, btn42y, btn43x, btn43y;
            double x31, y31, x32, y32;
            btn41x = btnThirdcoverspace2.Location.X + btnThirdcoverspace2.Width / 2.0;
            btn41y = btnThirdcoverspace2.Location.Y + btnThirdcoverspace2.Height;
            Point btnPoint75 = new Point(Convert.ToInt32(btn41x), Convert.ToInt32(btn41y)); //覆盖空间性能下中点
            Point btnPoint76 = new Point(Convert.ToInt32(btn41x), Convert.ToInt32(mid3y));//中间点
            g.DrawLine(pen, btnPoint75, btnPoint76);
            x31 = coverageOverlapRate.Location.X + coverageOverlapRate.Width / 2.0;
            y31 = mid3y;
            Point btnPoint77 = new Point(Convert.ToInt32(x31), Convert.ToInt32(y31));//覆盖重叠率上面的点
            g.DrawLine(pen, btnPoint77, btnPoint76);

            btn42x = x31;
            btn42y = coverageOverlapRate.Location.Y;
            Point btnPoint78 = new Point(Convert.ToInt32(btn42x), Convert.ToInt32(btn42y));//覆盖重叠率上中点
            g.DrawLine(pen, btnPoint78, btnPoint77);

            x32 = cumCoverageAreaRatio.Location.X + cumCoverageAreaRatio.Width / 2.0;
            y32 = mid3y;
            Point btnPoint79 = new Point(Convert.ToInt32(x32), Convert.ToInt32(y32));//累计覆盖面积比率上面的点
            g.DrawLine(pen, btnPoint76, btnPoint79);

            btn43x = x32;
            btn43y = cumCoverageAreaRatio.Location.Y;
            Point btnPoint80 = new Point(Convert.ToInt32(btn43x), Convert.ToInt32(btn43y));//累计覆盖面积比率上中点
            g.DrawLine(pen, btnPoint79, btnPoint80);
            //----------------------------------------------------
            //数据获取下中点
            double btn44x, btn44y, btn45x, btn45y, btn46x, btn46y;
            double x33, y33, x34, y34;
            btn44x = btnThirddataget2.Location.X + btnThirddataget2.Width / 2.0;
            btn44y = btnThirddataget2.Location.Y + btnThirddataget2.Height;
            Point btnPoint81 = new Point(Convert.ToInt32(btn44x), Convert.ToInt32(btn44y)); //数据获取下中点
            Point btnPoint82 = new Point(Convert.ToInt32(btn44x), Convert.ToInt32(mid3y));//中间点
            g.DrawLine(pen, btnPoint81, btnPoint82);
            x33 = dataNumber.Location.X + dataNumber.Width / 2.0;
            y33 = mid3y;
            Point btnPoint83 = new Point(Convert.ToInt32(x33), Convert.ToInt32(y33));//数据量上面的点
            g.DrawLine(pen, btnPoint82, btnPoint83);

            btn45x = x33;
            btn45y = dataNumber.Location.Y;
            Point btnPoint84 = new Point(Convert.ToInt32(btn45x), Convert.ToInt32(btn45y));//数据量上中点
            g.DrawLine(pen, btnPoint83, btnPoint84);

            x34 = radiationDingBiao.Location.X + radiationDingBiao.Width / 2.0;
            y34 = mid3y;
            Point btnPoint85 = new Point(Convert.ToInt32(x34), Convert.ToInt32(y34));//辐射定标精度上面的点
            g.DrawLine(pen, btnPoint82, btnPoint85);

            btn46x = x34;
            btn46y = radiationDingBiao.Location.Y;
            Point btnPoint86 = new Point(Convert.ToInt32(btn46x), Convert.ToInt32(btn46y));//辐射定标精度上中点
            g.DrawLine(pen, btnPoint85, btnPoint86);
            //---------------------------------------
            //数据传输性能下中点
            double btn47x, btn47y, btn48x, btn48y, btn49x, btn49y, btn50x, btn50y, btn51x, btn51y;
            double x35, y35, x36, y36, x37, y37, x38, y38, x39, y39;
            btn47x = btnThirddatasend2.Location.X + btnThirddatasend2.Width / 2.0;
            btn47y = btnThirddatasend2.Location.Y + btnThirddatasend2.Height;
            Point btnPoint87 = new Point(Convert.ToInt32(btn47x), Convert.ToInt32(btn47y));
            //数据传输下面的中间点
            x35 = btn47x;
            y35 = mid3y;
            Point btnPoint88 = new Point(Convert.ToInt32(x35), Convert.ToInt32(y35));
            g.DrawLine(pen, btnPoint87, btnPoint88);
            //下传速率上面的点
            x36 = downRate.Location.X + downRate.Width / 2.0;
            y36 = mid3y;
            Point btnPoint89 = new Point(Convert.ToInt32(x36), Convert.ToInt32(y36));
            g.DrawLine(pen, btnPoint89, btnPoint88);

            //下传速率上中点
            btn48x = x36;
            btn48y = downRate.Location.Y;
            Point btnPoint90 = new Point(Convert.ToInt32(btn48x), Convert.ToInt32(btn48y));
            g.DrawLine(pen, btnPoint89, btnPoint90);

            //误码率上面的点
            x37 = errorRatio.Location.X + errorRatio.Width / 2.0;
            y37 = mid3y;
            Point btnPoint91 = new Point(Convert.ToInt32(x37), Convert.ToInt32(y37));

            //误码率上中点
            btn49x = x37;
            btn49y = errorRatio.Location.Y;
            Point btnPoint92 = new Point(Convert.ToInt32(btn49x), Convert.ToInt32(btn49y));
            g.DrawLine(pen, btnPoint91, btnPoint92);
            //--------------------------------------
            //丢包率上面的点
            x38 = packetLossRate.Location.X + packetLossRate.Width / 2.0;
            y38 = mid3y;
            Point btnPoint93 = new Point(Convert.ToInt32(x38), Convert.ToInt32(y38));
            g.DrawLine(pen, btnPoint88, btnPoint93);

            //丢包率上中点
            btn50x = x38;
            btn50y = packetLossRate.Location.Y;
            Point btnPoint94 = new Point(Convert.ToInt32(btn50x), Convert.ToInt32(btn50y));
            g.DrawLine(pen, btnPoint93, btnPoint94);

            //信噪比上面的点
            x39 = signalNoiseRatio.Location.X + signalNoiseRatio.Width / 2.0;
            y39 = mid3y;
            Point btnPoint95 = new Point(Convert.ToInt32(x39), Convert.ToInt32(y39));

            //信噪比上中点
            btn51x = x39;
            btn51y = signalNoiseRatio.Location.Y;
            Point btnPoint96 = new Point(Convert.ToInt32(btn51x), Convert.ToInt32(btn51y));
            g.DrawLine(pen, btnPoint96, btnPoint95);

            //-------------------------------------
            //数据处理下中点
            double btn52x, btn52y, btn53x, btn53y, btn54x, btn54y;
            double x40, y40, x41, y41, x42, y42;
            btn52x = btnThirddatasolve2.Location.X + btnThirddatasolve2.Width / 2.0;
            btn52y = btnThirddatasolve2.Location.Y + btnThirddatasolve2.Height;
            Point btnPoint97 = new Point(Convert.ToInt32(btn52x), Convert.ToInt32(btn52y)); //数据处理下中点
            Point btnPoint98 = new Point(Convert.ToInt32(btn52x), Convert.ToInt32(mid3y));//中间点
            g.DrawLine(pen, btnPoint97, btnPoint98);
            x40 = dataResolvePerDay.Location.X + dataResolvePerDay.Width / 2.0;
            y40 = mid3y;
            Point btnPoint99 = new Point(Convert.ToInt32(x40), Convert.ToInt32(y40));//日处理数据量上面的点
            g.DrawLine(pen, btnPoint98, btnPoint99);

            btn53x = x40;
            btn53y = dataResolvePerDay.Location.Y;
            Point btnPoint100 = new Point(Convert.ToInt32(btn53x), Convert.ToInt32(btn53y));//日处理数据量上中点
            g.DrawLine(pen, btnPoint99, btnPoint100);

            x41 = resolveDelay.Location.X + resolveDelay.Width / 2.0;
            y41 = mid3y;
            Point btnPoint101 = new Point(Convert.ToInt32(x41), Convert.ToInt32(y41));//处理延迟上面的点
            g.DrawLine(pen, btnPoint98, btnPoint101);

            btn54x = x41;
            btn54y = resolveDelay.Location.Y;
            Point btnPoint102 = new Point(Convert.ToInt32(btn54x), Convert.ToInt32(btn54y));//处理延迟上中点
            g.DrawLine(pen, btnPoint101, btnPoint102);
        }

        //指标归一化,每一个指标归一化后的值
        private double spatialResoNor;
        private double fuWidthNor;
        private double MssaNor;
        private double orbitCycleNor;
        private double revisiteNor;
        private double spectrumResoNor;
        private double spectrumRangeNor;
        private double spectrumNumNor;
        private double radiationResoNor;

        private double grayLevelNor;
        private double dingZiNor;

        private double dingGuiNor;

        private double dingWeiNor;
        private double coverTimeRatioNor;

        private double reCoverTimeRatioNor;
        private double avgResopnseTimeNor;

        private double avgGapTimeNor;
        private double coverOverlapRateNor;

        private double cumCoverRateNor;

        private double dataNumNor;
        private double ratiationDingBiaoNor;

        private double downRateNor;

        private double errateNor;
        private double sinalNoiseRateNor;

        private double pocketLossRateNor;
        private double perdateSolveDataNor;

        private double solveDelayNor;
        private void dataGridNormalize()
        {
            normalizedDatagrid1.Rows.Add(14);  //添加3行
            normalizedDatagrid2.Rows.Add(13);
            normalizedDatagrid1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            normalizedDatagrid1.Rows[0].Cells[0].Value = "空间分辨率";
            normalizedDatagrid1.Rows[1].Cells[0].Value = "幅宽";
            normalizedDatagrid1.Rows[2].Cells[0].Value = "最大侧摆角";
            normalizedDatagrid1.Rows[3].Cells[0].Value = "轨道周期";
            normalizedDatagrid1.Rows[4].Cells[0].Value = "重访周期";
            normalizedDatagrid1.Rows[5].Cells[0].Value = "光谱分辨率";
            normalizedDatagrid1.Rows[6].Cells[0].Value = "光谱范围";
            normalizedDatagrid1.Rows[7].Cells[0].Value = "光谱个数";
            normalizedDatagrid1.Rows[8].Cells[0].Value = "辐射分辨率";
            normalizedDatagrid1.Rows[9].Cells[0].Value = "灰度级数";
            normalizedDatagrid1.Rows[10].Cells[0].Value = "定姿精度";
            normalizedDatagrid1.Rows[11].Cells[0].Value = "定轨精度";
            normalizedDatagrid1.Rows[12].Cells[0].Value = "定位精度";
            normalizedDatagrid1.Rows[13].Cells[0].Value = "覆盖时间百分比";


            normalizedDatagrid1.Rows[0].Cells[1].Value = "1";
            //将datagridview里面归一化的值，赋给对应的变量
            spatialResoNor = Convert.ToDouble(normalizedDatagrid1.Rows[0].Cells[1].Value.ToString());
            normalizedDatagrid1.Rows[1].Cells[1].Value = "0.76";
            fuWidthNor = Convert.ToDouble(normalizedDatagrid1.Rows[1].Cells[1].Value.ToString());
            normalizedDatagrid1.Rows[2].Cells[1].Value = "1";
            MssaNor = Convert.ToDouble(normalizedDatagrid1.Rows[2].Cells[1].Value.ToString());
            normalizedDatagrid1.Rows[3].Cells[1].Value = "0.85";
            orbitCycleNor = Convert.ToDouble(normalizedDatagrid1.Rows[3].Cells[1].Value.ToString());
            normalizedDatagrid1.Rows[4].Cells[1].Value = "0.75";
            revisiteNor = Convert.ToDouble(normalizedDatagrid1.Rows[4].Cells[1].Value.ToString());
            normalizedDatagrid1.Rows[5].Cells[1].Value = "0.69";
            spectrumResoNor = Convert.ToDouble(normalizedDatagrid1.Rows[5].Cells[1].Value.ToString());
            normalizedDatagrid1.Rows[6].Cells[1].Value = "0.88";
            spectrumRangeNor = Convert.ToDouble(normalizedDatagrid1.Rows[6].Cells[1].Value.ToString());
            normalizedDatagrid1.Rows[7].Cells[1].Value = "1";
            spectrumNumNor = Convert.ToDouble(normalizedDatagrid1.Rows[7].Cells[1].Value.ToString());
            normalizedDatagrid1.Rows[8].Cells[1].Value = "0.95";
            radiationResoNor = Convert.ToDouble(normalizedDatagrid1.Rows[8].Cells[1].Value.ToString());
            normalizedDatagrid1.Rows[9].Cells[1].Value = "1";
            grayLevelNor = Convert.ToDouble(normalizedDatagrid1.Rows[9].Cells[1].Value.ToString());
            normalizedDatagrid1.Rows[10].Cells[1].Value = "0.9";
            dingZiNor = Convert.ToDouble(normalizedDatagrid1.Rows[10].Cells[1].Value.ToString());
            normalizedDatagrid1.Rows[11].Cells[1].Value = "0.85";
            dingGuiNor = Convert.ToDouble(normalizedDatagrid1.Rows[11].Cells[1].Value.ToString());
            normalizedDatagrid1.Rows[12].Cells[1].Value = "0.67";
            dingWeiNor = Convert.ToDouble(normalizedDatagrid1.Rows[12].Cells[1].Value.ToString());
            normalizedDatagrid1.Rows[13].Cells[1].Value = "1";
            coverTimeRatioNor = Convert.ToDouble(normalizedDatagrid1.Rows[13].Cells[1].Value.ToString());

            normalizedDatagrid2.Rows[0].Cells[0].Value = "重复覆盖时间百分比";
            normalizedDatagrid2.Rows[1].Cells[0].Value = "平均响应时间";
            normalizedDatagrid2.Rows[2].Cells[0].Value = "平均间隙周期";
            normalizedDatagrid2.Rows[3].Cells[0].Value = "覆盖重叠率";
            normalizedDatagrid2.Rows[4].Cells[0].Value = "累计覆盖面积比率";
            normalizedDatagrid2.Rows[5].Cells[0].Value = "数据量";
            normalizedDatagrid2.Rows[6].Cells[0].Value = "辐射定标精度";
            normalizedDatagrid2.Rows[7].Cells[0].Value = "下传速率";
            normalizedDatagrid2.Rows[8].Cells[0].Value = "误码率";
            normalizedDatagrid2.Rows[9].Cells[0].Value = "信噪比";
            normalizedDatagrid2.Rows[10].Cells[0].Value = "丢包率";
            normalizedDatagrid2.Rows[11].Cells[0].Value = "日处理数据量";
            normalizedDatagrid2.Rows[12].Cells[0].Value = "处理延迟";

            normalizedDatagrid2.Rows[0].Cells[1].Value = "0.85";
            reCoverTimeRatioNor = Convert.ToDouble(normalizedDatagrid2.Rows[0].Cells[1].Value.ToString());
            normalizedDatagrid2.Rows[1].Cells[1].Value = "0.86";
            avgResopnseTimeNor = Convert.ToDouble(normalizedDatagrid2.Rows[1].Cells[1].Value.ToString());
            normalizedDatagrid2.Rows[2].Cells[1].Value = "0.75";
            avgGapTimeNor = Convert.ToDouble(normalizedDatagrid2.Rows[2].Cells[1].Value.ToString());
            normalizedDatagrid2.Rows[3].Cells[1].Value = "0.89";
            coverOverlapRateNor = Convert.ToDouble(normalizedDatagrid2.Rows[3].Cells[1].Value.ToString());
            normalizedDatagrid2.Rows[4].Cells[1].Value = "1";
            cumCoverRateNor = Convert.ToDouble(normalizedDatagrid2.Rows[4].Cells[1].Value.ToString());
            normalizedDatagrid2.Rows[5].Cells[1].Value = "1";
            dataNumNor = Convert.ToDouble(normalizedDatagrid2.Rows[5].Cells[1].Value.ToString());
            normalizedDatagrid2.Rows[6].Cells[1].Value = "0.8";
            ratiationDingBiaoNor = Convert.ToDouble(normalizedDatagrid2.Rows[6].Cells[1].Value.ToString());
            normalizedDatagrid2.Rows[7].Cells[1].Value = "0.89";
            downRateNor = Convert.ToDouble(normalizedDatagrid2.Rows[7].Cells[1].Value.ToString());
            normalizedDatagrid2.Rows[8].Cells[1].Value = "0.9";
            errateNor = Convert.ToDouble(normalizedDatagrid2.Rows[8].Cells[1].Value.ToString());
            normalizedDatagrid2.Rows[9].Cells[1].Value = "0.59";
            sinalNoiseRateNor = Convert.ToDouble(normalizedDatagrid2.Rows[9].Cells[1].Value.ToString());
            normalizedDatagrid2.Rows[10].Cells[1].Value = "0.81";
            pocketLossRateNor = Convert.ToDouble(normalizedDatagrid2.Rows[10].Cells[1].Value.ToString());
            normalizedDatagrid2.Rows[11].Cells[1].Value = "1";
            perdateSolveDataNor = Convert.ToDouble(normalizedDatagrid2.Rows[11].Cells[1].Value.ToString());
            normalizedDatagrid2.Rows[12].Cells[1].Value = "0.91";
            solveDelayNor = Convert.ToDouble(normalizedDatagrid2.Rows[12].Cells[1].Value.ToString());
        }

        private void AHPFCEBtn_Click(object sender, EventArgs e)
        {
            boxText2Vector();
            double[] W = performAHPFCE();
            string[] Evaluation = new string[] { "差", "较差", "一般", "良", "优" };
            int index = 0;
            double Max = W[0];
            for (int i = 0; i < W.Length; i++)
            {
                if (W[i] > Max)
                {
                    Max = W[i];
                    index = i;
                }
            }
            MessageBox.Show(Evaluation[index].ToString());
            //double[,]W= AHPFCE();
            //string str = "";
            //for (int i = 0; i < W.GetLength(0); i++)
            //{
            //    for (int j = 0; j < W.GetLength(1); j++)
            //    {
            //        str = str + W[i, j]+"!";
            //    }
            //    str = str + "\n";
            //}
            //MessageBox.Show(str);
        }
        public double[] W11spce;
        public double[] W14radiation;
        double[] performAHPFCE()
        {
            //第三层归一化指标变一维数组
            //基础性能，
            double[] third_space = new double[3] { spatialResoNor, fuWidthNor, MssaNor };
            double[] third_time = new double[2] { orbitCycleNor, revisiteNor };
            double[] third_spectrum = new double[3] { spectrumResoNor, spectrumRangeNor, spectrumNumNor };
            double[] third_radiation = new double[2] { radiationResoNor, grayLevelNor };
            double[] third_accuracy = new double[3] { dingZiNor, dingGuiNor, dingWeiNor };
            //覆盖性能
            double[] third_coverTime = new double[4] { coverTimeRatioNor, reCoverTimeRatioNor, avgResopnseTimeNor, avgGapTimeNor };
            double[] third_coverSpace = new double[2] { coverOverlapRateNor, cumCoverRateNor };

            //信息性能
            double[] third_dataGet = new double[2] { dataNumNor, ratiationDingBiaoNor };
            double[] third_dataSend = new double[4] { downRateNor, errateNor, sinalNoiseRateNor, pocketLossRateNor };
            double[] third_dataSolve = new double[2] { perdateSolveDataNor, solveDelayNor };

            //第三层归一化指标的一维数组变模糊关系矩阵
            //基础性能
            double[,] third_spaceR = index2Matrix(third_space);//空间性能的模糊关系矩阵
            double[,] third_timeR = index2Matrix(third_time);//时间性能的模糊关系矩阵
            double[,] third_spectrumR = index2Matrix(third_spectrum);//光谱性能的模糊关系矩阵
            double[,] third_radiationR = index2Matrix(third_radiation);//辐射性能的模糊关系矩阵
            double[,] third_accuracyR = index2Matrix(third_accuracy);//精度评定的模糊关系矩阵

            //覆盖性能
            double[,] third_coverTimeR = index2Matrix(third_coverTime);//覆盖时效性能模糊关系矩阵
            double[,] third_coverSpaceR = index2Matrix(third_coverSpace);//覆盖空间性能模糊关系矩阵

            //信息性能
            double[,] third_dataGetR = index2Matrix(third_dataGet);//数据获取模糊关系矩阵
            double[,] third_dataSendR = index2Matrix(third_dataSend);//数据传输模糊关系矩阵
            double[,] third_dataSolveR = index2Matrix(third_dataSolve);//数据处理模糊关系矩阵

            //第三层模糊合成
            W11spce = fuzzySynthesis(spatialPerforVector, third_spaceR);//基础空间性能指标合成权向量，一个参数是权重矩阵算出的权向量，第二个参数是指标归一化后的模糊矩阵
            double[] W12time = fuzzySynthesis(timePerforVector, third_timeR);//基础空间性能指标项合成权权向量
            double[] W13spectrum = fuzzySynthesis(spectrumPerforVector, third_spectrumR);//基础光谱性能指标合成权向量

            W14radiation = fuzzySynthesis(radiationPerforVector, third_radiationR);//基础辐射性能合成权向量
            double[] W15accuracy = fuzzySynthesis(accuracyPerforVector, third_accuracyR);//精度评定合成权向量
            double[] W21coverTime = fuzzySynthesis(coverTimePerforVector, third_coverTimeR);//覆盖时效性能
            double[] W22coverSpace = fuzzySynthesis(coverSpacePerforVector, third_coverSpaceR);//覆盖空间性能
            double[] W31dataGet = fuzzySynthesis(dataGetPerforVector, third_dataGetR);//数据获取性能
            double[] W32dataSend = fuzzySynthesis(dataSendPerforVector, third_dataSendR);//数据传输
            double[] W33dataSolve = fuzzySynthesis(dataSolvePerforVector, third_dataSolveR);//数据处理

            //第二层模糊合成
            double[][] temp1 = new double[][] { W11spce, W12time, W13spectrum, W14radiation, W15accuracy };
            double[][] temp2 = new double[][] { W21coverTime, W22coverSpace };
            double[][] temp3 = new double[][] { W31dataGet, W32dataSend, W33dataSolve };
            double[,] W1 = mmToMatric(temp1);//基础性能指标项模糊关系矩阵
            double[,] W2 = mmToMatric(temp2);//覆盖性能指标项模糊关系矩阵
            double[,] W3 = mmToMatric(temp3);//信息性能指标项模糊关系矩阵
            double[] Q1base = fuzzySynthesis(basePerforVector, W1);//基础性能指标项合成权向量
            double[] Q2cover = fuzzySynthesis(coverPerforVector, W2);//覆盖性能指标项合成权向量
            double[] Q3info = fuzzySynthesis(infoPerforVector, W3);//覆盖性能指标项合成权向量

            double[][] temp4 = new double[][] { Q1base, Q2cover, Q3info };
            double[,] Q = mmToMatric(temp4);

            //第一层模糊合成
            double[] O = fuzzySynthesis(comPerforVector, Q);

            return O;
        }

        //传入归一化指标向量，返回模糊关系矩阵
        public double[,] index2Matrix(double[] x)
        {
            double m1 = Convert.ToDouble(m1box.Text);
            double m2 = Convert.ToDouble(m2box.Text);
            double m3 = Convert.ToDouble(m3box.Text);
            int n = x.Length;
            double[] m = { 0, m1, m2, m3, 1 };//存取隶属度
            double[,] R = new double[n, 5];//指标模糊关系矩阵
            //计算隶属度
            for (int i = 0; i < n; i++)//计算隶属度
            {
                double xx = x[i];
                if (xx >= 0 && xx < m[1])
                {
                    R[i, 0] = (m[1] - xx) / m[1];
                }
                else
                {
                    R[i, 0] = 0.0;
                }
                for (int j = 1; j <= 3; j++)
                {
                    if (xx >= 0 && xx < m[j - 1])
                    {
                        R[i, j] = 0.0;
                    }
                    else if (xx >= m[j - 1] && xx < m[j])
                    {
                        R[i, j] = (xx - m[j - 1]) / (m[j] - m[j - 1]);
                    }
                    else if (xx >= m[j] && xx < m[j + 1])
                    {
                        R[i, j] = (m[j + 1] - xx) / (m[j + 1] - m[j]);
                    }
                    else
                    {
                        R[i, j] = 0.0;

                    }
                }
                if (xx >= 0 && xx < m[3])
                {
                    R[i, 4] = 0.0;
                }
                else
                {
                    R[i, 4] = (xx - m[3]) / (m[4] - m[3]);

                }
            }
            return R;
        }

        //权重向量，与模糊矩阵合成，第一个参数权重向量，第二个参数归一化指标放在隶属度函数之后的模糊矩阵。
        static double[] fuzzySynthesis(double[] vector, double[,] R)//模糊合成
        {
            var M = Matrix<double>.Build;
            var V = Vector<double>.Build;
            Vector<double> vv = V.DenseOfArray(vector);
            Matrix<double> rr = M.DenseOfArray(R);
            double[] W = (vv * rr).ToArray();//将向量装换为一维数组
            return W;
        }

        //传入数组的数组，然后变为二维矩阵
        static double[,] mmToMatric(double[][] W123)//j将数组的数组转换为二维数组
        {
            int n = W123.GetLength(0);
            double[,] W = new double[n, 5];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    W[i, j] = W123[i][j];
                }
            }
            return W;
        }

        //以下效能评估

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 1);
            double btn1x, btn1y, btn2x, btn2y, btn3x, btn3y, btn4x, btn4y, btn5x, btn5y, btn6x, btn6y;
            double x1, y1, x2, y2, x3, y3, x4, y4, x5, y5, x6, y6;
            btn1x = appEffBtn.Location.X + appEffBtn.Width / 2.0;//btn1应用效能按钮的中下点
            btn1y = appEffBtn.Location.Y + appEffBtn.Height;
            Point btnPoint1 = new Point(Convert.ToInt32(btn1x), Convert.ToInt32(btn1y));//应用效能按钮的中下点

            btn2x = coverRangeEffBtn.Location.X + coverRangeEffBtn.Width / 2.0;//btn2是覆盖范围上中点
            btn2y = coverRangeEffBtn.Location.Y;
            Point btnPoint2 = new Point(Convert.ToInt32(btn2x), Convert.ToInt32(btn2y));//btn2是覆盖范围上中点

            x1 = btn1x;
            y1 = btn1y + (btn2y - btn1y) / 2;//应用效能按钮下面的中点，重点
            Point midPoint1 = new Point(Convert.ToInt32(x1), Convert.ToInt32(y1));

            x2 = btn2x;
            y2 = y1;//覆盖范围按钮上面的中点，重点
            Point midPoint2 = new Point(Convert.ToInt32(x2), Convert.ToInt32(y2));

            g.DrawLine(pen, btnPoint1, midPoint1);
            g.DrawLine(pen, midPoint1, midPoint2);
            g.DrawLine(pen, midPoint2, btnPoint2);

            btn3x = appSatisEffBtn.Location.X + appSatisEffBtn.Width / 2.0;//btn3应用满足度按钮的上中点
            btn3y = appSatisEffBtn.Location.Y;
            Point btnPoint3 = new Point(Convert.ToInt32(btn3x), Convert.ToInt32(btn3y));

            x3 = btn3x;
            y3 = y1;//应用性能上面的中点
            Point midPoint3 = new Point(Convert.ToInt32(x3), Convert.ToInt32(y3));

            g.DrawLine(pen, btnPoint3, midPoint3);
            g.DrawLine(pen, midPoint3, midPoint1);
            //--------------------------------------------
            btn4x = starResouEffBtn.Location.X + starResouEffBtn.Width / 2.0;//btn4星地资源可用性按钮的上中点
            btn4y = starResouEffBtn.Location.Y;
            Point btnPoint4 = new Point(Convert.ToInt32(btn4x), Convert.ToInt32(btn4y));

            x4 = btn4x;
            y4 = y1;//星地资源上面的中点
            Point midPoint4 = new Point(Convert.ToInt32(x4), Convert.ToInt32(y4));

            g.DrawLine(pen, btnPoint4, midPoint4);
            g.DrawLine(pen, midPoint4, midPoint1);

            //观测能力
            x5 = obserAbilityEffBtn.Location.X + obserAbilityEffBtn.Width / 2.0;
            y5 = y1;
            Point midPoint5 = new Point(Convert.ToInt32(x5), Convert.ToInt32(y5));//观测能力上面的中点

            //观测能力上中间点
            btn5x = obserAbilityEffBtn.Location.X + obserAbilityEffBtn.Width / 2.0;//btn5是观测能力上中点
            btn5y = obserAbilityEffBtn.Location.Y;
            Point btnPoint5 = new Point(Convert.ToInt32(btn5x), Convert.ToInt32(btn5y));
            g.DrawLine(pen, midPoint5, btnPoint5);
            g.DrawLine(pen, midPoint5, midPoint1);
            //任务响应时效性
            x6 = taskResponEffBtn.Location.X + taskResponEffBtn.Width / 2.0;
            y6 = y1;
            Point midPoint6 = new Point(Convert.ToInt32(x6), Convert.ToInt32(y6));
            g.DrawLine(pen, midPoint6, midPoint1);

            //任务响应时效性上中间点
            btn6x = taskResponEffBtn.Location.X + taskResponEffBtn.Width / 2.0;//btn6是星地资源利用上中点
            btn6y = taskResponEffBtn.Location.Y;
            Point btnPoint6 = new Point(Convert.ToInt32(btn6x), Convert.ToInt32(btn6y));
            g.DrawLine(pen, midPoint6, btnPoint6);

            //------------------------------------
            double btn7x, btn7y, btn8x, btn8y, btn9x, btn9y, btn10x, btn10y, btn11x, btn11y, btn12x, btn12y;
            double x7, y7, x8, y8, x9, y9, x10, y10, x11, y11, x12, y12;
            btn7x = starResouEffBtn.Location.X + starResouEffBtn.Width / 2.0;//btn7是星地资源可用性按钮的中下点
            btn7y = starResouEffBtn.Location.Y + starResouEffBtn.Height;
            Point btnPoint7 = new Point(Convert.ToInt32(btn7x), Convert.ToInt32(btn7y));//星地资源可用性按钮的中下点

            btn8x = ceKongEffBtn.Location.X + ceKongEffBtn.Width / 2.0;//btn8是测控资源平均利用率上中点
            btn8y = ceKongEffBtn.Location.Y;
            Point btnPoint8 = new Point(Convert.ToInt32(btn8x), Convert.ToInt32(btn8y));//btnPoint8是测控资源平均利用率上中点

            x7 = btn7x;
            y7 = btn7y + (btn8y - btn7y) / 2;//星地资源可用性下面的中点，重点
            Point midPoint7 = new Point(Convert.ToInt32(x7), Convert.ToInt32(y7));
            g.DrawLine(pen, btnPoint7, midPoint7);
            //测控资源平均利用率上面的中间点
            x8 = btn8x;
            y8 = y7;
            Point midPoint8 = new Point(Convert.ToInt32(x8), Convert.ToInt32(y8));
            g.DrawLine(pen, midPoint7, midPoint8);//
            g.DrawLine(pen, midPoint8, btnPoint8);//

            x9 = shuChuanEffBtn.Location.X + shuChuanEffBtn.Width / 2.0;//数传上面的中间点
            y9 = y7;
            Point midPoint9 = new Point(Convert.ToInt32(x9), Convert.ToInt32(y9));
            g.DrawLine(pen, midPoint9, midPoint7);

            //数传上中间点
            btn9x = shuChuanEffBtn.Location.X + shuChuanEffBtn.Width / 2.0;//btn9是数传上中点
            btn9y = shuChuanEffBtn.Location.Y;
            Point btnPoint9 = new Point(Convert.ToInt32(btn9x), Convert.ToInt32(btn9y));
            g.DrawLine(pen, midPoint9, btnPoint9);

            x10 = storeEffBtn.Location.X + storeEffBtn.Width / 2.0;
            y10 = y7;
            Point midPoint10 = new Point(Convert.ToInt32(x10), Convert.ToInt32(y10));
            g.DrawLine(pen, midPoint10, midPoint7);

            //多视角成像次数上中间点
            btn10x = storeEffBtn.Location.X + storeEffBtn.Width / 2.0;//btn9是覆盖区域次数上中点
            btn10y = storeEffBtn.Location.Y;
            Point btnPoint10 = new Point(Convert.ToInt32(btn10x), Convert.ToInt32(btn10y));
            g.DrawLine(pen, midPoint10, btnPoint10);
            //-----------------------------------------------------------------
            //---------------------------------------------------------------
            btn11x = appSatisEffBtn.Location.X + appSatisEffBtn.Width / 2.0;//btn11是应用满足度按钮的中下点
            btn11y = appSatisEffBtn.Location.Y + appSatisEffBtn.Height;
            Point btnPoint11 = new Point(Convert.ToInt32(btn11x), Convert.ToInt32(btn11y));

            btn12x = temperEffBtn.Location.X + temperEffBtn.Width / 2.0;//btn12温度湿度探测精度上中点
            btn12y = temperEffBtn.Location.Y;
            Point btnPoint12 = new Point(Convert.ToInt32(btn12x), Convert.ToInt32(btn12y));

            x11 = btn11x;
            y11 = btn11y + (btn12y - btn11y) / 2;//应用满足度下面的中点，重点
            Point midPoint12 = new Point(Convert.ToInt32(x11), Convert.ToInt32(y11));
            g.DrawLine(pen, btnPoint11, midPoint12);
            //温度湿度上面的中间点
            x12 = btn12x;
            y12 = y7;
            Point midPoint13 = new Point(Convert.ToInt32(x12), Convert.ToInt32(y12));
            g.DrawLine(pen, midPoint12, midPoint13);//
            g.DrawLine(pen, midPoint13, btnPoint12);//

            double btn13x, btn13y, btn14x, btn14y, btn15x, btn15y, btn16x, btn16y, btn17x, btn17y, btn18x, btn18y;
            double x13, y13, x14, y14, x15, y15, x16, y16, x17, y17, x18, y18;

            x13 = scaleEffBtn.Location.X + scaleEffBtn.Width / 2.0;//测图比例尺上面的中间点
            y13 = y7;
            Point midPoint14 = new Point(Convert.ToInt32(x13), Convert.ToInt32(y13));
            g.DrawLine(pen, midPoint14, midPoint12);

            //测度比例尺上中间点
            btn13x = scaleEffBtn.Location.X + scaleEffBtn.Width / 2.0;
            btn13y = scaleEffBtn.Location.Y;
            Point btnPoint13 = new Point(Convert.ToInt32(btn13x), Convert.ToInt32(btn13y));
            g.DrawLine(pen, midPoint14, btnPoint13);

            x14 = windEffBtn.Location.X + windEffBtn.Width / 2.0;//风向风速上面的中间点
            y14 = y7;
            Point midPoint15 = new Point(Convert.ToInt32(x14), Convert.ToInt32(y14));
            g.DrawLine(pen, midPoint15, midPoint12);

            //风向风速上中间点
            btn14x = windEffBtn.Location.X + windEffBtn.Width / 2.0;
            btn14y = windEffBtn.Location.Y;
            Point btnPoint14 = new Point(Convert.ToInt32(btn14x), Convert.ToInt32(btn14y));
            g.DrawLine(pen, midPoint15, btnPoint14);


            //-----------------------------------------------------------------
            //---------------------------------------------------------------
            btn15x = coverRangeEffBtn.Location.X + coverRangeEffBtn.Width / 2.0;//btn15是覆盖范围按钮的中下点
            btn15y = coverRangeEffBtn.Location.Y + coverRangeEffBtn.Height;
            Point btnPoint15 = new Point(Convert.ToInt32(btn15x), Convert.ToInt32(btn15y));

            btn16x = obserRangeEffBtn.Location.X + obserRangeEffBtn.Width / 2.0;//btn16观测范围上中点
            btn16y = obserRangeEffBtn.Location.Y;
            Point btnPoint16 = new Point(Convert.ToInt32(btn16x), Convert.ToInt32(btn16y));

            x15 = btn15x;
            y15 = btn15y + (btn16y - btn15y) / 2;//覆盖范围下面的中点，重点
            Point midPoint16 = new Point(Convert.ToInt32(x15), Convert.ToInt32(y15));
            g.DrawLine(pen, btnPoint15, midPoint16);
            //观测范围上面的中间点
            x16 = btn16x;
            y16 = y7;
            Point midPoint17 = new Point(Convert.ToInt32(x16), Convert.ToInt32(y16));

            g.DrawLine(pen, midPoint17, midPoint16);//
            g.DrawLine(pen, midPoint17, btnPoint16);//

            btn17x = neiborObserOverEffBtn.Location.X + neiborObserOverEffBtn.Width / 2.0;//btn17相邻观测重叠度上中点
            btn17y = neiborObserOverEffBtn.Location.Y;
            Point btnPoint17 = new Point(Convert.ToInt32(btn17x), Convert.ToInt32(btn17y));

            x17 = btn17x;
            y17 = y7;//相邻观测重叠度上面的中点，重点
            Point midPoint18 = new Point(Convert.ToInt32(x17), Convert.ToInt32(y17));

            g.DrawLine(pen, midPoint18, midPoint16);//
            g.DrawLine(pen, midPoint18, btnPoint17);//

            //-----------------------------------------------------------------
            //---------------------------------------------------------------
            double btn19x, btn19y, btn20x, btn20y, btn21x, btn21y, btn22x, btn22y, btn23x, btn23y, btn24x, btn24y;
            double x19, y19, x20, y20, x21, y21, x22, y22, x23, y23, x24, y24;
            btn18x = obserAbilityEffBtn.Location.X + obserAbilityEffBtn.Width / 2.0;//btn18是观测能力的中下点
            btn18y = obserAbilityEffBtn.Location.Y + obserAbilityEffBtn.Height;
            Point btnPoint18 = new Point(Convert.ToInt32(btn18x), Convert.ToInt32(btn18y));

            btn19x = landSamplingEffBtn.Location.X + landSamplingEffBtn.Width / 2.0;//btn19地面采样间隔上中点
            btn19y = landSamplingEffBtn.Location.Y;
            Point btnPoint19 = new Point(Convert.ToInt32(btn19x), Convert.ToInt32(btn19y));

            x18 = btn18x;
            y18 = y7;//观测能力下面的中点，重点
            Point midPoint19 = new Point(Convert.ToInt32(x18), Convert.ToInt32(y18));
            g.DrawLine(pen, btnPoint18, midPoint19);
            //地面采样间隔上面的中间点
            x19 = btn19x;
            y19 = y7;
            Point midPoint20 = new Point(Convert.ToInt32(x19), Convert.ToInt32(y19));

            g.DrawLine(pen, midPoint19, midPoint20);//
            g.DrawLine(pen, midPoint20, btnPoint19);//

            btn20x = hightAccuracyEffBtn.Location.X + hightAccuracyEffBtn.Width / 2.0;//btn20高程精度上中点
            btn20y = hightAccuracyEffBtn.Location.Y;
            Point btnPoint20 = new Point(Convert.ToInt32(btn20x), Convert.ToInt32(btn20y));

            x20 = btn20x;
            y20 = y7;//高程精度上面的中点，重点
            Point midPoint21 = new Point(Convert.ToInt32(x20), Convert.ToInt32(y20));

            g.DrawLine(pen, midPoint21, midPoint19);//
            g.DrawLine(pen, midPoint21, btnPoint20);//

            btn21x = geoAccuracyEffBtn.Location.X + geoAccuracyEffBtn.Width / 2.0;//btn21几何定位精度上中点
            btn21y = geoAccuracyEffBtn.Location.Y;
            Point btnPoint21 = new Point(Convert.ToInt32(btn21x), Convert.ToInt32(btn21y));

            x21 = btn21x;
            y21 = y7;//几何定位精度上面的中点，重点
            Point midPoint22 = new Point(Convert.ToInt32(x21), Convert.ToInt32(y21));

            g.DrawLine(pen, midPoint22, midPoint19);//
            g.DrawLine(pen, midPoint22, btnPoint21);//

            btn22x = radiationAccuraEffBtn.Location.X + radiationAccuraEffBtn.Width / 2.0;//btn22辐射测量精度精度上中点
            btn22y = radiationAccuraEffBtn.Location.Y;
            Point btnPoint22 = new Point(Convert.ToInt32(btn22x), Convert.ToInt32(btn22y));

            x22 = btn22x;
            y22 = y7;//辐射测量精度上面的中点，重点
            Point midPoint23 = new Point(Convert.ToInt32(x22), Convert.ToInt32(y22));

            g.DrawLine(pen, midPoint23, midPoint19);//
            g.DrawLine(pen, midPoint23, btnPoint22);//

            //--------------------------------------------------
            double btn25x, btn25y, btn26x, btn26y, btn27x, btn27y, btn28x, btn28y;
            double x25, y25, x26, y26, x27, y27, x28, y28, x29, y29;
            btn23x = taskResponEffBtn.Location.X + taskResponEffBtn.Width / 2.0;//btn23任务响应时效性的中下点
            btn23y = taskResponEffBtn.Location.Y + taskResponEffBtn.Height;
            Point btnPoint23 = new Point(Convert.ToInt32(btn23x), Convert.ToInt32(btn23y));

            btn24x = averageRevisitEffBtn.Location.X + averageRevisitEffBtn.Width / 2.0;//btn24平均重访时间上中点
            btn24y = averageRevisitEffBtn.Location.Y;
            Point btnPoint24 = new Point(Convert.ToInt32(btn24x), Convert.ToInt32(btn24y));

            x23 = btn23x;
            y23 = y7;//任务响应时效性下面的中点，重点
            Point midPoint25 = new Point(Convert.ToInt32(x23), Convert.ToInt32(y23));
            g.DrawLine(pen, btnPoint23, midPoint25);
            //平均重访时间上面的中间点
            x24 = btn24x;
            y24 = y7;
            Point midPoint26 = new Point(Convert.ToInt32(x24), Convert.ToInt32(y24));

            g.DrawLine(pen, midPoint25, midPoint26);//
            g.DrawLine(pen, midPoint26, btnPoint24);//

            btn25x = coverNumEffBtn.Location.X + coverNumEffBtn.Width / 2.0;//btn20高程精度上中点
            btn25y = coverNumEffBtn.Location.Y;
            Point btnPoint25 = new Point(Convert.ToInt32(btn25x), Convert.ToInt32(btn25y));

            x25 = btn25x;
            y25 = y7;//高程精度上面的中点，重点
            Point midPoint27 = new Point(Convert.ToInt32(x25), Convert.ToInt32(y25));

            g.DrawLine(pen, midPoint27, midPoint25);//
            g.DrawLine(pen, midPoint27, btnPoint25);//

            btn26x = targetCoverTimeEffBtn.Location.X + targetCoverTimeEffBtn.Width / 2.0;//btn26目标覆盖时长上中点
            btn26y = targetCoverTimeEffBtn.Location.Y;
            Point btnPoint27 = new Point(Convert.ToInt32(btn26x), Convert.ToInt32(btn26y));

            x26 = btn26x;
            y26 = y7;//目标覆盖时长上面的中点，重点
            Point midPoint28 = new Point(Convert.ToInt32(x26), Convert.ToInt32(y26));

            g.DrawLine(pen, midPoint28, midPoint25);//
            g.DrawLine(pen, midPoint28, btnPoint27);//

            btn27x = coverRatioEffBtn.Location.X + coverRatioEffBtn.Width / 2.0;//btn27覆盖百分比上中点
            btn27y = coverRatioEffBtn.Location.Y;
            Point btnPoint28 = new Point(Convert.ToInt32(btn27x), Convert.ToInt32(btn27y));

            x27 = btn27x;
            y27 = y7;//覆盖百分比上面的中点，重点
            Point midPoint29 = new Point(Convert.ToInt32(x27), Convert.ToInt32(y27));

            g.DrawLine(pen, midPoint29, midPoint25);//
            g.DrawLine(pen, midPoint29, btnPoint28);//

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 1);
            double btn1x, btn1y, btn2x, btn2y, btn3x, btn3y, btn4x, btn4y, btn5x, btn5y, btn6x, btn6y;
            double x1, y1, x2, y2, x3, y3, x4, y4, x5, y5, x6, y6;
            btn1x = appEffBtn2.Location.X + appEffBtn2.Width / 2.0;//btn1应用效能按钮的中下点
            btn1y = appEffBtn2.Location.Y + appEffBtn2.Height;
            Point btnPoint1 = new Point(Convert.ToInt32(btn1x), Convert.ToInt32(btn1y));//应用效能按钮的中下点

            btn2x = coverRangeEffBtn2.Location.X + coverRangeEffBtn2.Width / 2.0;//btn2是覆盖范围上中点
            btn2y = coverRangeEffBtn2.Location.Y;
            Point btnPoint2 = new Point(Convert.ToInt32(btn2x), Convert.ToInt32(btn2y));//btn2是覆盖范围上中点

            x1 = btn1x;
            y1 = btn1y + (btn2y - btn1y) / 2;//应用效能按钮下面的中点，重点
            Point midPoint1 = new Point(Convert.ToInt32(x1), Convert.ToInt32(y1));

            x2 = btn2x;
            y2 = y1;//覆盖范围按钮上面的中点，重点
            Point midPoint2 = new Point(Convert.ToInt32(x2), Convert.ToInt32(y2));

            g.DrawLine(pen, btnPoint1, midPoint1);
            g.DrawLine(pen, midPoint1, midPoint2);
            g.DrawLine(pen, midPoint2, btnPoint2);

            btn3x = appSatisEffBtn2.Location.X + appSatisEffBtn2.Width / 2.0;//btn3应用满足度按钮的上中点
            btn3y = appSatisEffBtn2.Location.Y;
            Point btnPoint3 = new Point(Convert.ToInt32(btn3x), Convert.ToInt32(btn3y));

            x3 = btn3x;
            y3 = y1;//应用性能上面的中点
            Point midPoint3 = new Point(Convert.ToInt32(x3), Convert.ToInt32(y3));

            g.DrawLine(pen, btnPoint3, midPoint3);
            g.DrawLine(pen, midPoint3, midPoint1);
            //--------------------------------------------
            btn4x = starResouEffBtn2.Location.X + starResouEffBtn2.Width / 2.0;//btn4星地资源可用性按钮的上中点
            btn4y = starResouEffBtn2.Location.Y;
            Point btnPoint4 = new Point(Convert.ToInt32(btn4x), Convert.ToInt32(btn4y));

            x4 = btn4x;
            y4 = y1;//星地资源上面的中点
            Point midPoint4 = new Point(Convert.ToInt32(x4), Convert.ToInt32(y4));

            g.DrawLine(pen, btnPoint4, midPoint4);
            g.DrawLine(pen, midPoint4, midPoint1);

            //观测能力
            x5 = obserAbilityEffBtn2.Location.X + obserAbilityEffBtn2.Width / 2.0;
            y5 = y1;
            Point midPoint5 = new Point(Convert.ToInt32(x5), Convert.ToInt32(y5));//观测能力上面的中点

            //观测能力上中间点
            btn5x = obserAbilityEffBtn2.Location.X + obserAbilityEffBtn2.Width / 2.0;//btn5是观测能力上中点
            btn5y = obserAbilityEffBtn2.Location.Y;
            Point btnPoint5 = new Point(Convert.ToInt32(btn5x), Convert.ToInt32(btn5y));
            g.DrawLine(pen, midPoint5, btnPoint5);
            g.DrawLine(pen, midPoint5, midPoint1);
            //任务响应时效性
            x6 = taskResponEffBtn2.Location.X + taskResponEffBtn2.Width / 2.0;
            y6 = y1;
            Point midPoint6 = new Point(Convert.ToInt32(x6), Convert.ToInt32(y6));
            g.DrawLine(pen, midPoint6, midPoint1);

            //任务响应时效性上中间点
            btn6x = taskResponEffBtn2.Location.X + taskResponEffBtn2.Width / 2.0;//btn6是星地资源利用上中点
            btn6y = taskResponEffBtn2.Location.Y;
            Point btnPoint6 = new Point(Convert.ToInt32(btn6x), Convert.ToInt32(btn6y));
            g.DrawLine(pen, midPoint6, btnPoint6);

            //------------------------------------
            double btn7x, btn7y, btn8x, btn8y, btn9x, btn9y, btn10x, btn10y, btn11x, btn11y, btn12x, btn12y;
            double x7, y7, x8, y8, x9, y9, x10, y10, x11, y11, x12, y12;
            btn7x = starResouEffBtn2.Location.X + starResouEffBtn2.Width / 2.0;//btn7是星地资源可用性按钮的中下点
            btn7y = starResouEffBtn2.Location.Y + starResouEffBtn2.Height;
            Point btnPoint7 = new Point(Convert.ToInt32(btn7x), Convert.ToInt32(btn7y));//星地资源可用性按钮的中下点

            btn8x = ceKongEffBtn2.Location.X + ceKongEffBtn2.Width / 2.0;//btn8是测控资源平均利用率上中点
            btn8y = ceKongEffBtn2.Location.Y;
            Point btnPoint8 = new Point(Convert.ToInt32(btn8x), Convert.ToInt32(btn8y));//btnPoint8是测控资源平均利用率上中点

            x7 = btn7x;
            y7 = btn7y + (btn8y - btn7y) / 2;//星地资源可用性下面的中点，重点
            Point midPoint7 = new Point(Convert.ToInt32(x7), Convert.ToInt32(y7));
            g.DrawLine(pen, btnPoint7, midPoint7);
            //测控资源平均利用率上面的中间点
            x8 = btn8x;
            y8 = y7;
            Point midPoint8 = new Point(Convert.ToInt32(x8), Convert.ToInt32(y8));
            g.DrawLine(pen, midPoint7, midPoint8);//
            g.DrawLine(pen, midPoint8, btnPoint8);//

            x9 = shuChuanEffBtn2.Location.X + shuChuanEffBtn2.Width / 2.0;//数传上面的中间点
            y9 = y7;
            Point midPoint9 = new Point(Convert.ToInt32(x9), Convert.ToInt32(y9));
            g.DrawLine(pen, midPoint9, midPoint7);

            //数传上中间点
            btn9x = shuChuanEffBtn2.Location.X + shuChuanEffBtn2.Width / 2.0;//btn9是数传上中点
            btn9y = shuChuanEffBtn2.Location.Y;
            Point btnPoint9 = new Point(Convert.ToInt32(btn9x), Convert.ToInt32(btn9y));
            g.DrawLine(pen, midPoint9, btnPoint9);

            x10 = storeEffBtn2.Location.X + storeEffBtn2.Width / 2.0;
            y10 = y7;
            Point midPoint10 = new Point(Convert.ToInt32(x10), Convert.ToInt32(y10));
            g.DrawLine(pen, midPoint10, midPoint7);

            //多视角成像次数上中间点
            btn10x = storeEffBtn2.Location.X + storeEffBtn2.Width / 2.0;//btn9是覆盖区域次数上中点
            btn10y = storeEffBtn2.Location.Y;
            Point btnPoint10 = new Point(Convert.ToInt32(btn10x), Convert.ToInt32(btn10y));
            g.DrawLine(pen, midPoint10, btnPoint10);
            //-----------------------------------------------------------------
            //---------------------------------------------------------------
            btn11x = appSatisEffBtn2.Location.X + appSatisEffBtn2.Width / 2.0;//btn11是应用满足度按钮的中下点
            btn11y = appSatisEffBtn2.Location.Y + appSatisEffBtn2.Height;
            Point btnPoint11 = new Point(Convert.ToInt32(btn11x), Convert.ToInt32(btn11y));

            btn12x = temperEffBtn2.Location.X + temperEffBtn2.Width / 2.0;//btn12温度湿度探测精度上中点
            btn12y = temperEffBtn2.Location.Y;
            Point btnPoint12 = new Point(Convert.ToInt32(btn12x), Convert.ToInt32(btn12y));

            x11 = btn11x;
            y11 = btn11y + (btn12y - btn11y) / 2;//应用满足度下面的中点，重点
            Point midPoint12 = new Point(Convert.ToInt32(x11), Convert.ToInt32(y11));
            g.DrawLine(pen, btnPoint11, midPoint12);
            //温度湿度上面的中间点
            x12 = btn12x;
            y12 = y7;
            Point midPoint13 = new Point(Convert.ToInt32(x12), Convert.ToInt32(y12));
            g.DrawLine(pen, midPoint12, midPoint13);//
            g.DrawLine(pen, midPoint13, btnPoint12);//

            double btn13x, btn13y, btn14x, btn14y, btn15x, btn15y, btn16x, btn16y, btn17x, btn17y, btn18x, btn18y;
            double x13, y13, x14, y14, x15, y15, x16, y16, x17, y17, x18, y18;

            x13 = scaleEffBtn2.Location.X + scaleEffBtn2.Width / 2.0;//测图比例尺上面的中间点
            y13 = y7;
            Point midPoint14 = new Point(Convert.ToInt32(x13), Convert.ToInt32(y13));
            g.DrawLine(pen, midPoint14, midPoint12);

            //测度比例尺上中间点
            btn13x = scaleEffBtn2.Location.X + scaleEffBtn2.Width / 2.0;
            btn13y = scaleEffBtn2.Location.Y;
            Point btnPoint13 = new Point(Convert.ToInt32(btn13x), Convert.ToInt32(btn13y));
            g.DrawLine(pen, midPoint14, btnPoint13);

            x14 = windEffBtn2.Location.X + windEffBtn2.Width / 2.0;//风向风速上面的中间点
            y14 = y7;
            Point midPoint15 = new Point(Convert.ToInt32(x14), Convert.ToInt32(y14));
            g.DrawLine(pen, midPoint15, midPoint12);

            //风向风速上中间点
            btn14x = windEffBtn2.Location.X + windEffBtn2.Width / 2.0;
            btn14y = windEffBtn2.Location.Y;
            Point btnPoint14 = new Point(Convert.ToInt32(btn14x), Convert.ToInt32(btn14y));
            g.DrawLine(pen, midPoint15, btnPoint14);


            //-----------------------------------------------------------------
            //---------------------------------------------------------------
            btn15x = coverRangeEffBtn2.Location.X + coverRangeEffBtn2.Width / 2.0;//btn15是覆盖范围按钮的中下点
            btn15y = coverRangeEffBtn2.Location.Y + coverRangeEffBtn2.Height;
            Point btnPoint15 = new Point(Convert.ToInt32(btn15x), Convert.ToInt32(btn15y));

            btn16x = obserRangeEffBtn2.Location.X + obserRangeEffBtn2.Width / 2.0;//btn16观测范围上中点
            btn16y = obserRangeEffBtn2.Location.Y;
            Point btnPoint16 = new Point(Convert.ToInt32(btn16x), Convert.ToInt32(btn16y));

            x15 = btn15x;
            y15 = btn15y + (btn16y - btn15y) / 2;//覆盖范围下面的中点，重点
            Point midPoint16 = new Point(Convert.ToInt32(x15), Convert.ToInt32(y15));
            g.DrawLine(pen, btnPoint15, midPoint16);
            //观测范围上面的中间点
            x16 = btn16x;
            y16 = y7;
            Point midPoint17 = new Point(Convert.ToInt32(x16), Convert.ToInt32(y16));

            g.DrawLine(pen, midPoint17, midPoint16);//
            g.DrawLine(pen, midPoint17, btnPoint16);//

            btn17x = neiborObserOverEffBtn2.Location.X + neiborObserOverEffBtn2.Width / 2.0;//btn17相邻观测重叠度上中点
            btn17y = neiborObserOverEffBtn2.Location.Y;
            Point btnPoint17 = new Point(Convert.ToInt32(btn17x), Convert.ToInt32(btn17y));

            x17 = btn17x;
            y17 = y7;//相邻观测重叠度上面的中点，重点
            Point midPoint18 = new Point(Convert.ToInt32(x17), Convert.ToInt32(y17));

            g.DrawLine(pen, midPoint18, midPoint16);//
            g.DrawLine(pen, midPoint18, btnPoint17);//

            //-----------------------------------------------------------------
            //---------------------------------------------------------------
            double btn19x, btn19y, btn20x, btn20y, btn21x, btn21y, btn22x, btn22y, btn23x, btn23y, btn24x, btn24y;
            double x19, y19, x20, y20, x21, y21, x22, y22, x23, y23, x24, y24;
            btn18x = obserAbilityEffBtn2.Location.X + obserAbilityEffBtn2.Width / 2.0;//btn18是观测能力的中下点
            btn18y = obserAbilityEffBtn2.Location.Y + obserAbilityEffBtn2.Height;
            Point btnPoint18 = new Point(Convert.ToInt32(btn18x), Convert.ToInt32(btn18y));

            btn19x = landSamplingEffBtn2.Location.X + landSamplingEffBtn2.Width / 2.0;//btn19地面采样间隔上中点
            btn19y = landSamplingEffBtn2.Location.Y;
            Point btnPoint19 = new Point(Convert.ToInt32(btn19x), Convert.ToInt32(btn19y));

            x18 = btn18x;
            y18 = y7;//观测能力下面的中点，重点
            Point midPoint19 = new Point(Convert.ToInt32(x18), Convert.ToInt32(y18));
            g.DrawLine(pen, btnPoint18, midPoint19);
            //地面采样间隔上面的中间点
            x19 = btn19x;
            y19 = y7;
            Point midPoint20 = new Point(Convert.ToInt32(x19), Convert.ToInt32(y19));

            g.DrawLine(pen, midPoint19, midPoint20);//
            g.DrawLine(pen, midPoint20, btnPoint19);//

            btn20x = hightAccuracyEffBtn2.Location.X + hightAccuracyEffBtn2.Width / 2.0;//btn20高程精度上中点
            btn20y = hightAccuracyEffBtn2.Location.Y;
            Point btnPoint20 = new Point(Convert.ToInt32(btn20x), Convert.ToInt32(btn20y));

            x20 = btn20x;
            y20 = y7;//高程精度上面的中点，重点
            Point midPoint21 = new Point(Convert.ToInt32(x20), Convert.ToInt32(y20));

            g.DrawLine(pen, midPoint21, midPoint19);//
            g.DrawLine(pen, midPoint21, btnPoint20);//

            btn21x = geoAccuracyEffBtn2.Location.X + geoAccuracyEffBtn2.Width / 2.0;//btn21几何定位精度上中点
            btn21y = geoAccuracyEffBtn2.Location.Y;
            Point btnPoint21 = new Point(Convert.ToInt32(btn21x), Convert.ToInt32(btn21y));

            x21 = btn21x;
            y21 = y7;//几何定位精度上面的中点，重点
            Point midPoint22 = new Point(Convert.ToInt32(x21), Convert.ToInt32(y21));

            g.DrawLine(pen, midPoint22, midPoint19);//
            g.DrawLine(pen, midPoint22, btnPoint21);//

            btn22x = radiationAccuraEffBtn2.Location.X + radiationAccuraEffBtn2.Width / 2.0;//btn22辐射测量精度精度上中点
            btn22y = radiationAccuraEffBtn2.Location.Y;
            Point btnPoint22 = new Point(Convert.ToInt32(btn22x), Convert.ToInt32(btn22y));

            x22 = btn22x;
            y22 = y7;//辐射测量精度上面的中点，重点
            Point midPoint23 = new Point(Convert.ToInt32(x22), Convert.ToInt32(y22));

            g.DrawLine(pen, midPoint23, midPoint19);//
            g.DrawLine(pen, midPoint23, btnPoint22);//

            //--------------------------------------------------
            double btn25x, btn25y, btn26x, btn26y, btn27x, btn27y, btn28x, btn28y;
            double x25, y25, x26, y26, x27, y27, x28, y28, x29, y29;
            btn23x = taskResponEffBtn2.Location.X + taskResponEffBtn2.Width / 2.0;//btn23任务响应时效性的中下点
            btn23y = taskResponEffBtn2.Location.Y + taskResponEffBtn2.Height;
            Point btnPoint23 = new Point(Convert.ToInt32(btn23x), Convert.ToInt32(btn23y));

            btn24x = averageRevisitEffBtn2.Location.X + averageRevisitEffBtn2.Width / 2.0;//btn24平均重访时间上中点
            btn24y = averageRevisitEffBtn2.Location.Y;
            Point btnPoint24 = new Point(Convert.ToInt32(btn24x), Convert.ToInt32(btn24y));

            x23 = btn23x;
            y23 = y7;//任务响应时效性下面的中点，重点
            Point midPoint25 = new Point(Convert.ToInt32(x23), Convert.ToInt32(y23));
            g.DrawLine(pen, btnPoint23, midPoint25);
            //平均重访时间上面的中间点
            x24 = btn24x;
            y24 = y7;
            Point midPoint26 = new Point(Convert.ToInt32(x24), Convert.ToInt32(y24));

            g.DrawLine(pen, midPoint25, midPoint26);//
            g.DrawLine(pen, midPoint26, btnPoint24);//

            btn25x = coverNumEffBtn2.Location.X + coverNumEffBtn2.Width / 2.0;//btn20高程精度上中点
            btn25y = coverNumEffBtn2.Location.Y;
            Point btnPoint25 = new Point(Convert.ToInt32(btn25x), Convert.ToInt32(btn25y));

            x25 = btn25x;
            y25 = y7;//高程精度上面的中点，重点
            Point midPoint27 = new Point(Convert.ToInt32(x25), Convert.ToInt32(y25));

            g.DrawLine(pen, midPoint27, midPoint25);//
            g.DrawLine(pen, midPoint27, btnPoint25);//

            btn26x = targetCoverTimeEffBtn2.Location.X + targetCoverTimeEffBtn2.Width / 2.0;//btn26目标覆盖时长上中点
            btn26y = targetCoverTimeEffBtn2.Location.Y;
            Point btnPoint27 = new Point(Convert.ToInt32(btn26x), Convert.ToInt32(btn26y));

            x26 = btn26x;
            y26 = y7;//目标覆盖时长上面的中点，重点
            Point midPoint28 = new Point(Convert.ToInt32(x26), Convert.ToInt32(y26));

            g.DrawLine(pen, midPoint28, midPoint25);//
            g.DrawLine(pen, midPoint28, btnPoint27);//

            btn27x = coverRatioEffBtn2.Location.X + coverRatioEffBtn2.Width / 2.0;//btn27覆盖百分比上中点
            btn27y = coverRatioEffBtn2.Location.Y;
            Point btnPoint28 = new Point(Convert.ToInt32(btn27x), Convert.ToInt32(btn27y));

            x27 = btn27x;
            y27 = y7;//覆盖百分比上面的中点，重点
            Point midPoint29 = new Point(Convert.ToInt32(x27), Convert.ToInt32(y27));

            g.DrawLine(pen, midPoint29, midPoint25);//
            g.DrawLine(pen, midPoint29, btnPoint28);//
        }

        //权重比重
        public double starResouEff_appSatisEff = 1,//星地资源可用性-应用满足度
            starResouEff_coverRangeEff = 2,//星地资源可用性-覆盖范围
             starResouEff_obserAbilityEff = 3,//星地资源可用性-观测能力
             starResouEff_taskResponEff = 2,//星地资源可用性-任务响应时效性
            appSatisEff_coverRangeEff = 3,//应用满足度-覆盖范围

            appSatisEff_obserAbilityEff = 5,//应用满足度-观测能力
             appSatisEff_taskResponEff = 2,//应用满足度-任务响应时效性
            coverRangeEff_obserAbilityEff = 3,//覆盖范围—观测能力
            coverRangeEff_taskResponEff = 5,//覆盖范围-任务响应时效性
            obserAbilityEff_taskResponEff = 3;//观测能力-任务响应时效性



        private void appEffBtn_Click(object sender, EventArgs e)
        {
            appEff com = new appEff();
            com.ShowDialog(this);
        }


        public double shuChuanEff_ceKongEff = 2,//数传—测控
            shuChuanEff_storeEff = 5, //数传-存储
            ceKongEff_storeEff = 4;//测控-存储
        private void starResouEffBtn_Click(object sender, EventArgs e)
        {
            starLandResourceEff com = new starLandResourceEff();
            com.ShowDialog(this);
        }

        public double scaleEff_temperEff = 2,//测图比例尺-温度湿度探测精度
            scaleEff_windEff = 3,//测图比例尺-风向风速探测精度
            temperEff_windEff = 4;//温度湿度探测精度-风向风速探测精度
        private void appSatisEffBtn_Click(object sender, EventArgs e)
        {
            appSatisfyEff com = new appSatisfyEff();
            com.ShowDialog(this);
        }

        public double obserRangeEff_neiborObserOverEff = 2;//观测范围-相邻观测重叠度
        private void coverRangeEffBtn_Click(object sender, EventArgs e)
        {
            coverRangeEff com = new coverRangeEff();
            com.ShowDialog(this);
        }

        public double geoAccuracyEff_landSamplingEff = 2,//几何定位-地面采样
            geoAccuracyEff_hightAccuracyEff = 3,//几何定位-高程精度
            geoAccuracyEff_radiationAccuraEff = 5,//几何定位-辐射测量

            landSamplingEff_hightAccuracyEff = 1,//地面采样-高程
            landSamplingEff_radiationAccuraEff = 4,//地面采样-辐射测量
            hightAccuracyEff_radiationAccuraEff = 3;//高程-辐射测量
        private void obserAbilityEffBtn_Click(object sender, EventArgs e)
        {
            observerAbility com = new observerAbility();
            com.ShowDialog(this);
        }

       
        public double targetCoverTimeEff_averageRevisitEff = 2,//目标覆盖时长-平均重访时间
            targetCoverTimeEff_coverNumEff = 3,//目标覆盖时长-覆盖重数
            targetCoverTimeEff_coverRatioEff = 5,//目标覆盖时长-覆盖百分比
            averageRevisitEff_coverNumEff = 1,//平均重访时间-覆盖重数
            averageRevisitEff_coverRatioEff = 4,//平均重访时间-覆盖百分比
            coverNumEff_coverRatioEff = 3;//覆盖重数-覆盖百分比
        private void taskResponEffBtn_Click(object sender, EventArgs e)
        {
            taskResponseEff com = new taskResponseEff();
            com.ShowDialog(this);
        }


        private void parameterEffComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (parameterEffComboBox.SelectedIndex == 0)
            {
                panel1.Visible = true;
                panel2.Visible = false;
                panel1.Location = new Point(53, 58);
            }
            else
            {
                panel1.Visible = false;
                panel2.Location = new Point(53, 58);
                panel2.Visible = true;
            }
        }

        //获取指标重要性比例算出权重向量或者直接获取权重向量
        private double[,] appEffMatrix;//第一层权重矩阵，星地资源可用性、应用满足度、覆盖范围、观测能力、任务响应时效性

        private double[,] starLandEffMatrix;//星地资源可用性权重矩阵
        private double[,] appSatisifyEffMatrix;//应用满足度权重矩阵

        private double[,] coverRangeEffMatrix;//覆盖范围权重矩阵
        private double[,] observerAbilityEffMatrix;//观测能力
        private double[,] taskResponseEffMatrix;//任务响应时效性

      

        private double[] appEffVector;

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }

        private void normalizedDatagrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void appEffBtn2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox18_Enter(object sender, EventArgs e)
        {

        }

        private double[] starLandEffVector;
        private double[] appSatisifyEffVector;
        private double[] coverRangeEffVector;
        private double[] observerAbilityEffVector;
        private double[] taskResponseEffVector;

        //得到权重向量
        private void boxTextEff2Vector() {
            if (parameterEffComboBox.SelectedIndex == 0)
            {
                appEffMatrix = new double[5, 5] {
                    {1,starResouEff_appSatisEff,starResouEff_coverRangeEff,starResouEff_obserAbilityEff,starResouEff_taskResponEff },
                    {1.0/starResouEff_appSatisEff,1,appSatisEff_coverRangeEff,appSatisEff_obserAbilityEff,appSatisEff_taskResponEff },
                    {1.0/starResouEff_coverRangeEff, 1.0/appSatisEff_coverRangeEff,1.0,coverRangeEff_obserAbilityEff,coverRangeEff_taskResponEff},
                    { 1.0/starResouEff_obserAbilityEff,1.0/appSatisEff_obserAbilityEff,1.0/coverRangeEff_obserAbilityEff,1,obserAbilityEff_taskResponEff},
                    {1.0/starResouEff_taskResponEff, 1.0/appSatisEff_taskResponEff,1.0/coverRangeEff_taskResponEff,1.0/obserAbilityEff_taskResponEff,1}
                };
                starLandEffMatrix = new double[3, 3] {
                    { 1,shuChuanEff_ceKongEff,shuChuanEff_storeEff},
                    { 1.0/shuChuanEff_ceKongEff,1,ceKongEff_storeEff},
                    {1.0/shuChuanEff_storeEff, 1.0/ceKongEff_storeEff,1}
                };
                appSatisifyEffMatrix = new double[3, 3] {
                    { 1,scaleEff_temperEff,scaleEff_windEff},
                    { 1.0/scaleEff_temperEff,1,temperEff_windEff},
                    { 1.0/scaleEff_windEff,1.0/temperEff_windEff,1}
                };
                coverRangeEffMatrix = new double[2, 2] {
                { 1,obserRangeEff_neiborObserOverEff},
                {1.0/obserRangeEff_neiborObserOverEff,1 }
                };
                observerAbilityEffMatrix = new double[4, 4] {
                    { 1,geoAccuracyEff_landSamplingEff,geoAccuracyEff_hightAccuracyEff,geoAccuracyEff_radiationAccuraEff},
                    { 1.0/geoAccuracyEff_landSamplingEff,1,landSamplingEff_hightAccuracyEff,landSamplingEff_radiationAccuraEff},
                    { 1.0/geoAccuracyEff_hightAccuracyEff,1.0/landSamplingEff_hightAccuracyEff,1,hightAccuracyEff_radiationAccuraEff},
                    { 1.0/geoAccuracyEff_radiationAccuraEff,1.0/landSamplingEff_radiationAccuraEff,1.0/hightAccuracyEff_radiationAccuraEff,1}
                };
                taskResponseEffMatrix = new double[4, 4] {
                    {1,targetCoverTimeEff_averageRevisitEff,targetCoverTimeEff_coverNumEff ,targetCoverTimeEff_coverRatioEff},
                    {1.0/targetCoverTimeEff_averageRevisitEff,1,averageRevisitEff_coverNumEff, averageRevisitEff_coverRatioEff},
                    {1.0/targetCoverTimeEff_coverNumEff,1.0/averageRevisitEff_coverNumEff,1,coverNumEff_coverRatioEff },
                    { 1.0/targetCoverTimeEff_coverRatioEff,1.0/averageRevisitEff_coverRatioEff,1.0/coverNumEff_coverRatioEff,1}
                };
                appEffVector = matrixTovector(appEffMatrix);
                starLandEffVector = matrixTovector(starLandEffMatrix);
                appSatisifyEffVector = matrixTovector(appSatisifyEffMatrix);
                coverRangeEffVector = matrixTovector(coverRangeEffMatrix);
                observerAbilityEffVector = matrixTovector(observerAbilityEffMatrix);
                taskResponseEffVector = matrixTovector(taskResponseEffMatrix);
            }
            else {
                appEffVector = new double[5] { Convert.ToDouble(starLandEffTxt.Text.ToString()),
                    Convert.ToDouble(appSatisifyEffTxt.Text.ToString()),
                    Convert.ToDouble(coverRangeEffTxt.Text.ToString()) ,
                    Convert.ToDouble(observerAbilityEffTxt.Text.ToString()),
                    Convert.ToDouble(taskResponseEffTxt.Text.ToString()) };

                starLandEffVector = new double[3] {
                     Convert.ToDouble(shuchuanEffTxt.Text.ToString()),
                    Convert.ToDouble(ceKongEffTxt.Text.ToString()) ,
                    Convert.ToDouble(storeEffTxt.Text.ToString())
                };

                appSatisifyEffVector = new double[3] {
                     Convert.ToDouble(scaleEffTxt.Text.ToString()),
                    Convert.ToDouble(temperEffTxt.Text.ToString()) ,
                    Convert.ToDouble(windEffTxt.Text.ToString()) ,
                };
                coverRangeEffVector = new double[] {
                    Convert.ToDouble(observerRangeEffTxt.Text.ToString()),
                    Convert.ToDouble(neiborObserEffTxt.Text.ToString()) ,

                };

                observerAbilityEffVector = new double[4] {
                    Convert.ToDouble(geoEffTxt.Text.ToString()),
                    Convert.ToDouble(sampleEffTxt.Text.ToString()) ,
                    Convert.ToDouble(higthEffTxt.Text.ToString()),
                    Convert.ToDouble(radiationAccuracyEffTxt.Text.ToString()) };
            };
            taskResponseEffVector = new double[4] {
                    Convert.ToDouble(targetCoverEffTxt.Text.ToString()),
                    Convert.ToDouble(averRevisitEffTxt.Text.ToString()) ,
                    Convert.ToDouble(coverNumEffTxt.Text.ToString()),
                    Convert.ToDouble(coverRatioEffTxt.Text.ToString()) };
        }

        //指标归一化值
        private double shuChuanEffNor=0.8;//数传
        private double ceKongEffNor=0.95;//测控
        private double storeEffNor=0.78;//存储

        private double scaleEffNor=0.88;//比例尺
        private double temperEffNor=0.79;//温度湿度
        private double windEffNor=0.86;//风向风速

        private double obserRangeEffNor=0.77;//观测范围
        private double neiborObserOverEffNor=0.69;//相邻观测重叠度

        private double geoAccuracyEffNor=0.65;//几何定位精度
        private double landSamplingEffNor=0.88;//地面采样间隔
        private double hightAccuracyEffNor=0.89;//高程精度
        private double radiationAccuraEffNor=0.78;//辐射测量精度

        private double targetCoverTimeEffNor=0.69;//目标覆盖
        private double averageRevisitEffNor=0.85;//平均重访
        private double coverNumEffNor=0.85;//覆盖充数
        private double coverRatioEffNor=0.72;//覆盖百分比


        public double[] W11starLandEff;
        public double[] W12appSatisifyEff;
        public double[] W13coverRangeEff;
        public double[] W14observerAbilityEff;
        public double[] W15taskResponseEff;
        double[] effAHPFCE()
        {
            //第三层归一化指标变一维数组
            //星地资源可用性，
            double[] third_starLandEff = new double[3] { shuChuanEffNor, ceKongEffNor, storeEffNor };
            //应用满足度
            double[] third_appSatisifyEff = new double[3] { scaleEffNor, temperEffNor, windEffNor };
            //覆盖范围
            double[] third_coverRangeEff = new double[2] { obserRangeEffNor, neiborObserOverEffNor};
            //观测能力
            double[] third_observerAbilityEff = new double[4] { geoAccuracyEffNor, landSamplingEffNor, hightAccuracyEffNor, radiationAccuraEffNor };
            //任务响应时效性
            double[] third_taskResponseEff = new double[4] { targetCoverTimeEffNor, averageRevisitEffNor, coverNumEffNor, coverRatioEffNor };


                 
            //第三层归一化指标的一维数组变模糊关系矩阵
            //星地资源可用性
            double[,] third_starLandEffR = index2Matrix(third_starLandEff);//星地资源可用性的模糊关系矩阵
            double[,] third_appSatisifyEffR = index2Matrix(third_appSatisifyEff);//应用满足度的模糊关系矩阵
            double[,] third_coverRangeEffR = index2Matrix(third_coverRangeEff);//覆盖范围的模糊关系矩阵
            double[,] third_observerAbilityEffR = index2Matrix(third_observerAbilityEff);//观测能力的模糊关系矩阵
            double[,] third_taskResponseEffR = index2Matrix(third_taskResponseEff);//任务响应时效性的模糊关系矩阵
        
            ////第三层模糊合成
            W11starLandEff = fuzzySynthesis(starLandEffVector, third_starLandEffR);//星地资源可用性指标合成权向量，一个参数是权重矩阵算出的权向量，第二个参数是指标归一化后的模糊矩阵
            W12appSatisifyEff = fuzzySynthesis(appSatisifyEffVector, third_appSatisifyEffR);//应用满足度合成权向量
            W13coverRangeEff = fuzzySynthesis(coverRangeEffVector, third_coverRangeEffR);//覆盖范围合成权向量
            W14observerAbilityEff = fuzzySynthesis(observerAbilityEffVector, third_observerAbilityEffR);//观测能力合成权向量
            W15taskResponseEff = fuzzySynthesis(taskResponseEffVector, third_taskResponseEffR);//任务响应时效性合成权向量        

            ////第二层模糊合成
            double[][] temp1 = new double[][] { W11starLandEff, W12appSatisifyEff, W13coverRangeEff, W14observerAbilityEff, W15taskResponseEff };
            double[,] W1 = mmToMatric(temp1);//应用效能模糊关系矩阵     
               
            double[] Q1base = fuzzySynthesis(appEffVector, W1);//应用效能合成权向量

            return Q1base;
        }

        private void AHPFCEEffBtn_Click(object sender, EventArgs e)
        {
            boxTextEff2Vector();//获取权重向量或者权重矩阵的函数
            double[] W = effAHPFCE();
            string[] Evaluation = new string[] { "差", "较差", "一般", "良", "优" };
            int index = 0;
            double Max = W[0];
            for (int i = 0; i < W.Length; i++)
            {
                if (W[i] > Max)
                {
                    Max = W[i];
                    index = i;
                }
            }
            MessageBox.Show(Evaluation[index].ToString());
        }


        //体系贡献率区域
        #region
        public double equipmentPerfom_appPerform = 2,//装备性能—应用性能
           equipmentPerfom_taskPerfom = 3,//装备-任务
           appPerform_taskPerfom = 4;//应用-任务
        //体系贡献率按钮
        private void contributionRateBtn_Click(object sender, EventArgs e)
        {
            systemContriRate com = new systemContriRate();
            com.ShowDialog(this);
        }

        public double taskRespon_obserCoverRange = 4,//任务响应时效性—观测覆盖范围
           taskRespon_starResouUse = 5,//任务响应时效性—星地资源利用
           obserCoverRange_starResouUse = 6;//观测覆盖范围—星地资源利用
        //装备性能按钮
        private void equipPerformBtn_Click(object sender, EventArgs e)
        {
            equipmentPerform com = new equipmentPerform();
            com.ShowDialog(this);
        }

        public double radiaImageAbility_geoImageAbility = 0.5;//辐射成像-几何成像
        //应用性能按钮
        private void appPerformBtn_Click(object sender, EventArgs e)
        {
            appPerform com = new appPerform();
            com.ShowDialog(this);
        }

        private void parameterComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (parameterComboBox2.SelectedIndex == 0)
            {
                panel3.Visible = true;
                panel4.Visible = false;
                panel3.Location = new Point(145, 28);
            }
            else
            {
                panel3.Visible = false;
                panel4.Location = new Point(145, 28);
                panel4.Visible = true;
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 1);
            double btn1x, btn1y, btn2x, btn2y, btn3x, btn3y, btn4x, btn4y, btn5x, btn5y, btn6x, btn6y;
            double x1, y1, x2, y2, x3, y3, x4, y4, x5, y5, x6, y6;
            btn1x = contributionRateBtn2.Location.X + contributionRateBtn2.Width / 2.0;//btn1体系贡献率按钮的中下点
            btn1y = contributionRateBtn2.Location.Y + contributionRateBtn2.Height;
            Point btnPoint1 = new Point(Convert.ToInt32(btn1x), Convert.ToInt32(btn1y));//体系贡献率按钮的中下点

            btn2x = appPerformBtn2.Location.X + appPerformBtn2.Width / 2.0;//btn2是应用性能上中点
            btn2y = appPerformBtn2.Location.Y;
            Point btnPoint2 = new Point(Convert.ToInt32(btn2x), Convert.ToInt32(btn2y));//btn2是应用性能上中点

            x1 = btn1x;
            y1 = btn1y + (btn2y - btn1y) / 2;//体系贡献率按钮下面的中点，重点
            Point midPoint1 = new Point(Convert.ToInt32(x1), Convert.ToInt32(y1));

            x2 = btn2x;
            y2 = y1;//应用性能按钮上面的中点，重点
            Point midPoint2 = new Point(Convert.ToInt32(x2), Convert.ToInt32(y2));

            g.DrawLine(pen, btnPoint1, midPoint1);
            g.DrawLine(pen, midPoint1, midPoint2);
            g.DrawLine(pen, midPoint2, btnPoint2);

            btn3x = equipPerformBtn2.Location.X + equipPerformBtn2.Width / 2.0;//btn3装备性能按钮的上中点
            btn3y = equipPerformBtn2.Location.Y;
            Point btnPoint3 = new Point(Convert.ToInt32(btn3x), Convert.ToInt32(btn3y));

            x3 = btn3x;
            y3 = y1;//装备性能上面的中点
            Point midPoint3 = new Point(Convert.ToInt32(x3), Convert.ToInt32(y3));

            g.DrawLine(pen, btnPoint3, midPoint3);
            g.DrawLine(pen, midPoint3, midPoint1);
            //--------------------------------------------
            btn4x = targetPerfomBtn2.Location.X + targetPerfomBtn2.Width / 2.0;//btn4任务性能按钮的上中点
            btn4y = targetPerfomBtn2.Location.Y;
            Point btnPoint4 = new Point(Convert.ToInt32(btn4x), Convert.ToInt32(btn4y));

            x4 = btn4x;
            y4 = y1;//任务性能上面的中点
            Point midPoint4 = new Point(Convert.ToInt32(x4), Convert.ToInt32(y4));

            g.DrawLine(pen, btnPoint4, midPoint4);
            g.DrawLine(pen, midPoint4, midPoint1);
            //-------------------------------------------
            //---------------------------------------------
            double btn7x, btn7y, btn8x, btn8y, btn9x, btn9y, btn10x, btn10y, btn11x, btn11y, btn12x, btn12y, btn13x, btn13y, btn14x, btn14y;
            double x7, y7, x8, y8, x9, y9, x10, y10, x11, y11, x12, y12;
            btn5x = equipPerformBtn2.Location.X + equipPerformBtn2.Width / 2.0;//btn5装备性能按钮的中下点
            btn5y = equipPerformBtn2.Location.Y + equipPerformBtn2.Height;
            Point btnPoint5 = new Point(Convert.ToInt32(btn5x), Convert.ToInt32(btn5y));//装备性能按钮的中下点

            btn6x = obserCoverageBtn2.Location.X + obserCoverageBtn2.Width / 2.0;//btn6观测覆盖范围上中点
            btn6y = obserCoverageBtn2.Location.Y;
            Point btnPoint6 = new Point(Convert.ToInt32(btn6x), Convert.ToInt32(btn6y));//btn6是观测覆盖范围上中点

            x5 = btn5x;
            y5 = btn5y + (btn6y - btn5y) / 2;//装备性能按钮下面的中点，重点
            Point midPoint5 = new Point(Convert.ToInt32(x5), Convert.ToInt32(y5));

            x6 = btn6x;
            y6 = y5;//观测覆盖范围上面的中点，重点
            Point midPoint6 = new Point(Convert.ToInt32(x6), Convert.ToInt32(y6));

            g.DrawLine(pen, btnPoint5, midPoint5);
            g.DrawLine(pen, midPoint5, midPoint6);
            g.DrawLine(pen, midPoint6, btnPoint6);

            btn7x = targetResponseBtn2.Location.X + targetResponseBtn2.Width / 2.0;//btn7任务响应时效性按钮的上中点
            btn7y = targetResponseBtn2.Location.Y;
            Point btnPoint7 = new Point(Convert.ToInt32(btn7x), Convert.ToInt32(btn7y));

            x7 = btn7x;
            y7 = y5;//任务响应时效性上面的中点
            Point midPoint7 = new Point(Convert.ToInt32(x7), Convert.ToInt32(y7));

            g.DrawLine(pen, btnPoint7, midPoint7);
            g.DrawLine(pen, midPoint7, midPoint5);
            //--------------------------------------------
            btn8x = starResouUseBtn2.Location.X + starResouUseBtn2.Width / 2.0;//btn8星地资源利用率按钮的上中点
            btn8y = starResouUseBtn2.Location.Y;
            Point btnPoint8 = new Point(Convert.ToInt32(btn8x), Convert.ToInt32(btn8y));

            x8 = btn8x;
            y8 = y5;//任务性能上面的中点
            Point midPoint8 = new Point(Convert.ToInt32(x8), Convert.ToInt32(y8));

            g.DrawLine(pen, btnPoint8, midPoint8);
            g.DrawLine(pen, midPoint8, midPoint5);
            //--------------------------------------
            btn9x = appPerformBtn2.Location.X + appPerformBtn2.Width / 2.0;//btn9应用性能按钮的下中点
            btn9y = appPerformBtn2.Location.Y;
            Point btnPoint9 = new Point(Convert.ToInt32(btn9x), Convert.ToInt32(btn9y));

            btn10x = radiaImageAbilityBtn2.Location.X + radiaImageAbilityBtn2.Width / 2.0;//btn10辐射成像能力按钮的上中点
            btn10y = radiaImageAbilityBtn2.Location.Y;
            Point btnPoint10 = new Point(Convert.ToInt32(btn10x), Convert.ToInt32(btn10y));

            //应用性能下面的中点
            x9 = btn9x;
            y9 = y5;
            Point midPoint9 = new Point(Convert.ToInt32(x9), Convert.ToInt32(y9));

            //辐射成像能力上面的中点
            x10 = btn10x;
            y10 = y5;
            Point midPoint10 = new Point(Convert.ToInt32(x10), Convert.ToInt32(y10));

            g.DrawLine(pen, btnPoint9, midPoint9);
            g.DrawLine(pen, midPoint10, midPoint9);
            g.DrawLine(pen, midPoint10, btnPoint10);

            btn11x = geoImageAbilityBtn2.Location.X + geoImageAbilityBtn2.Width / 2.0;//btn11几何成像能力按钮的上中点
            btn11y = geoImageAbilityBtn2.Location.Y;
            Point btnPoint11 = new Point(Convert.ToInt32(btn11x), Convert.ToInt32(btn11y));

            x11 = btn11x;
            y11 = y5;
            Point midPoint11 = new Point(Convert.ToInt32(x11), Convert.ToInt32(y11));
            g.DrawLine(pen, midPoint11, midPoint9);
            g.DrawLine(pen, midPoint11, btnPoint11);

            //--------------------------------------
            btn12x = targetPerfomBtn2.Location.X + targetPerfomBtn2.Width / 2.0;//btn11任务性能按钮的下中点
            btn12y = targetPerfomBtn2.Location.Y;
            Point btnPoint12 = new Point(Convert.ToInt32(btn12x), Convert.ToInt32(btn12y));

            btn13x = appSatisifyBtn2.Location.X + appSatisifyBtn2.Width / 2.0;//btn12应用满足度按钮的上中点
            btn13y = appSatisifyBtn2.Location.Y;
            Point btnPoint13 = new Point(Convert.ToInt32(btn13x), Convert.ToInt32(btn13y));
            g.DrawLine(pen, btnPoint13, btnPoint12);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 1);
            double btn1x, btn1y, btn2x, btn2y, btn3x, btn3y, btn4x, btn4y, btn5x, btn5y, btn6x, btn6y;
            double x1, y1, x2, y2, x3, y3, x4, y4, x5, y5, x6, y6;
            btn1x = contributionRateBtn.Location.X + contributionRateBtn.Width / 2.0;//btn1体系贡献率按钮的中下点
            btn1y = contributionRateBtn.Location.Y + contributionRateBtn.Height;
            Point btnPoint1 = new Point(Convert.ToInt32(btn1x), Convert.ToInt32(btn1y));//体系贡献率按钮的中下点

            btn2x = appPerformBtn.Location.X + appPerformBtn.Width / 2.0;//btn2是应用性能上中点
            btn2y = appPerformBtn.Location.Y;
            Point btnPoint2 = new Point(Convert.ToInt32(btn2x), Convert.ToInt32(btn2y));//btn2是应用性能上中点

            x1 = btn1x;
            y1 = btn1y + (btn2y - btn1y) / 2;//体系贡献率按钮下面的中点，重点
            Point midPoint1 = new Point(Convert.ToInt32(x1), Convert.ToInt32(y1));

            x2 = btn2x;
            y2 = y1;//应用性能按钮上面的中点，重点
            Point midPoint2 = new Point(Convert.ToInt32(x2), Convert.ToInt32(y2));

            g.DrawLine(pen, btnPoint1, midPoint1);
            g.DrawLine(pen, midPoint1, midPoint2);
            g.DrawLine(pen, midPoint2, btnPoint2);

            btn3x = equipPerformBtn.Location.X + equipPerformBtn.Width / 2.0;//btn3装备性能按钮的上中点
            btn3y = equipPerformBtn.Location.Y;
            Point btnPoint3 = new Point(Convert.ToInt32(btn3x), Convert.ToInt32(btn3y));

            x3 = btn3x;
            y3 = y1;//装备性能上面的中点
            Point midPoint3 = new Point(Convert.ToInt32(x3), Convert.ToInt32(y3));

            g.DrawLine(pen, btnPoint3, midPoint3);
            g.DrawLine(pen, midPoint3, midPoint1);
            //--------------------------------------------
            btn4x = targetPerfomBtn.Location.X + targetPerfomBtn.Width / 2.0;//btn4任务性能按钮的上中点
            btn4y = targetPerfomBtn.Location.Y;
            Point btnPoint4 = new Point(Convert.ToInt32(btn4x), Convert.ToInt32(btn4y));

            x4 = btn4x;
            y4 = y1;//任务性能上面的中点
            Point midPoint4 = new Point(Convert.ToInt32(x4), Convert.ToInt32(y4));

            g.DrawLine(pen, btnPoint4, midPoint4);
            g.DrawLine(pen, midPoint4, midPoint1);
            //-------------------------------------------
            //---------------------------------------------
            double btn7x, btn7y, btn8x, btn8y, btn9x, btn9y, btn10x, btn10y, btn11x, btn11y, btn12x, btn12y, btn13x, btn13y;
            double x7, y7, x8, y8, x9, y9, x10, y10, x11, y11;
            btn5x = equipPerformBtn.Location.X + equipPerformBtn.Width / 2.0;//btn5装备性能按钮的中下点
            btn5y = equipPerformBtn.Location.Y + equipPerformBtn.Height;
            Point btnPoint5 = new Point(Convert.ToInt32(btn5x), Convert.ToInt32(btn5y));//装备性能按钮的中下点

            btn6x = obserCoverageBtn.Location.X + obserCoverageBtn.Width / 2.0;//btn6观测覆盖范围上中点
            btn6y = obserCoverageBtn.Location.Y;
            Point btnPoint6 = new Point(Convert.ToInt32(btn6x), Convert.ToInt32(btn6y));//btn6是观测覆盖范围上中点

            x5 = btn5x;
            y5 = btn5y + (btn6y - btn5y) / 2;//装备性能按钮下面的中点，重点
            Point midPoint5 = new Point(Convert.ToInt32(x5), Convert.ToInt32(y5));

            x6 = btn6x;
            y6 = y5;//观测覆盖范围上面的中点，重点
            Point midPoint6 = new Point(Convert.ToInt32(x6), Convert.ToInt32(y6));

            g.DrawLine(pen, btnPoint5, midPoint5);
            g.DrawLine(pen, midPoint5, midPoint6);
            g.DrawLine(pen, midPoint6, btnPoint6);

            btn7x = targetResponseBtn.Location.X + targetResponseBtn.Width / 2.0;//btn7任务响应时效性按钮的上中点
            btn7y = targetResponseBtn.Location.Y;
            Point btnPoint7 = new Point(Convert.ToInt32(btn7x), Convert.ToInt32(btn7y));

            x7 = btn7x;
            y7 = y5;//任务响应时效性上面的中点
            Point midPoint7 = new Point(Convert.ToInt32(x7), Convert.ToInt32(y7));

            g.DrawLine(pen, btnPoint7, midPoint7);
            g.DrawLine(pen, midPoint7, midPoint5);
            //--------------------------------------------
            btn8x = starResouUseBtn.Location.X + starResouUseBtn.Width / 2.0;//btn8星地资源利用率按钮的上中点
            btn8y = starResouUseBtn.Location.Y;
            Point btnPoint8 = new Point(Convert.ToInt32(btn8x), Convert.ToInt32(btn8y));

            x8 = btn8x;
            y8 = y5;//任务性能上面的中点
            Point midPoint8 = new Point(Convert.ToInt32(x8), Convert.ToInt32(y8));

            g.DrawLine(pen, btnPoint8, midPoint8);
            g.DrawLine(pen, midPoint8, midPoint5);
            //--------------------------------------
            btn9x = appPerformBtn.Location.X + appPerformBtn.Width / 2.0;//btn9应用性能按钮的下中点
            btn9y = appPerformBtn.Location.Y;
            Point btnPoint9 = new Point(Convert.ToInt32(btn9x), Convert.ToInt32(btn9y));

            btn10x = radiaImageAbilityBtn.Location.X + radiaImageAbilityBtn.Width / 2.0;//btn10辐射成像能力按钮的上中点
            btn10y = radiaImageAbilityBtn.Location.Y;
            Point btnPoint10 = new Point(Convert.ToInt32(btn10x), Convert.ToInt32(btn10y));

            //应用性能下面的中点
            x9 = btn9x;
            y9 = y5;
            Point midPoint9 = new Point(Convert.ToInt32(x9), Convert.ToInt32(y9));

            //辐射成像能力上面的中点
            x10 = btn10x;
            y10 = y5;
            Point midPoint10 = new Point(Convert.ToInt32(x10), Convert.ToInt32(y10));

            g.DrawLine(pen, btnPoint9, midPoint9);
            g.DrawLine(pen, midPoint10, midPoint9);
            g.DrawLine(pen, midPoint10, btnPoint10);

            btn11x = geoImageAbilityBtn.Location.X + geoImageAbilityBtn.Width / 2.0;//btn11几何成像能力按钮的上中点
            btn11y = geoImageAbilityBtn.Location.Y;
            Point btnPoint11 = new Point(Convert.ToInt32(btn11x), Convert.ToInt32(btn11y));

            x11 = btn11x;
            y11 = y5;
            Point midPoint11 = new Point(Convert.ToInt32(x11), Convert.ToInt32(y11));
            g.DrawLine(pen, midPoint11, midPoint9);
            g.DrawLine(pen, midPoint11, btnPoint11);

            //--------------------------------------
            btn12x = targetPerfomBtn.Location.X + targetPerfomBtn.Width / 2.0;//btn11任务性能按钮的下中点
            btn12y = targetPerfomBtn.Location.Y;
            Point btnPoint12 = new Point(Convert.ToInt32(btn12x), Convert.ToInt32(btn12y));

            btn13x = appSatisifyBtn.Location.X + appSatisifyBtn.Width / 2.0;//btn12应用满足度按钮的上中点
            btn13y = appSatisifyBtn.Location.Y;
            Point btnPoint13 = new Point(Convert.ToInt32(btn13x), Convert.ToInt32(btn13y));
            g.DrawLine(pen, btnPoint13, btnPoint12);
        }


        private double[,] systemContriSysMatrix;//第一层装备性能、任务性能、应用性能

        private double[,] equipmentSysMatrix;//装备性能权重矩阵
        private double[,] appSysMatrix;//应用性能权重矩阵

        private double[] systemContriSysVector;
        private double[] equipmentSysVector;
        private double[] appSysVector;
        private void boxTextSystemContribute2Vector()
        {
            if (parameterEffComboBox.SelectedIndex == 0)
            {
                systemContriSysMatrix = new double[3, 3] {
                   {1,equipmentPerfom_appPerform,equipmentPerfom_taskPerfom },
                   {1.0/equipmentPerfom_appPerform,1,appPerform_taskPerfom },
                   {1.0/equipmentPerfom_taskPerfom,1.0/appPerform_taskPerfom,1 }
                };
                equipmentSysMatrix = new double[3, 3] {
                    {1,taskRespon_obserCoverRange,taskRespon_starResouUse },
                    { 1.0/taskRespon_obserCoverRange,1,obserCoverRange_starResouUse},
                    {1.0/taskRespon_starResouUse,1.0/obserCoverRange_starResouUse,1 }
                };
                appSysMatrix = new double[2, 2] {
                    { 1,radiaImageAbility_geoImageAbility},
                    {1.0/radiaImageAbility_geoImageAbility,1}
                };
                systemContriSysVector = matrixTovector(systemContriSysMatrix);
                equipmentSysVector = matrixTovector(equipmentSysMatrix);
                appSysVector = matrixTovector(appSysMatrix);
            }
            else {
                systemContriSysVector = new double[3] {
                    Convert.ToDouble(equipmentTxt.Text.ToString()),
                    Convert.ToDouble(appPerformTxt.Text.ToString()),
                    Convert.ToDouble(taskPerformTxt.Text.ToString()) ,
                    };

                equipmentSysVector = new double[3] {
                     Convert.ToDouble(taskResponseTxt.Text.ToString()),
                    Convert.ToDouble(obserCoverRangeTxt.Text.ToString()) ,
                    Convert.ToDouble(starResourUseTxt.Text.ToString())
                };

                appSysVector = new double[2] {
                     Convert.ToDouble(radiationImageTxt.Text.ToString()),
                    Convert.ToDouble(geoImageTxt.Text.ToString())           
                };
            }
         }

        double[] systemAHPFCE()
        {
            double[][] temp1 = new double[][] { W15taskResponseEff, W14observerAbilityEff, W11starLandEff};//任务，观测，星地
            double[,] W11 = mmToMatric(temp1);//装备性能模糊关系矩阵     
            double[] Q1equipment = fuzzySynthesis(equipmentSysVector, W11);//装备性能指标项合成权向量

            double[][] temp2 = new double[][] { W11spce , W14radiation };//应用性能是由前面的空间性能和辐射性能来得到的
            double[,]W12= mmToMatric(temp2);
            double[] Q1app = fuzzySynthesis(appSysVector, W12);//应用性能

            double[] Q1task = W12appSatisifyEff;//任务性能

            double[][] temp3 = new double[][] { Q1equipment , Q1app , Q1task };
            double[,] W21 = mmToMatric(temp3);
            double[] Qresult = fuzzySynthesis(systemContriSysVector,W21);

            return Qresult;

        }


        //要先点击性能评估、效能评估的按钮
        private void button1_Click(object sender, EventArgs e)
        {
            boxTextSystemContribute2Vector();
            double[] W = systemAHPFCE();
            double[] Evaluation = { 0.2, 0.4, 0.6, 0.8, 1 };
            int index = 0;
            double Max = W[0];
            double result=0;
            for (int i = 0; i < W.Length; i++)
            {
                if (W[i] > Max)
                {
                    Max = W[i];
                    index = i;
                }
                result = result = Evaluation[i] * W[i];
            }
            systemPerformResult.Text = result.ToString("f3");

        }
        #endregion

    }
}
