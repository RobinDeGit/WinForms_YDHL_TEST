using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace WinForms_YDHL_TEST
{
    public partial class deptForm : Form
    {
        private OracleCommand oca_cmd;
        private OracleDataAdapter oda;

        private Form1 pat_info;
        private string select_dept_name;
        private string select_dept_code;
        private DataTable dt_select_pats;

        enum rowColor { HEAD_COLOR, MID_COLOR, TAIL_COLOR};

        public deptForm()
        {
            InitializeComponent();
            pat_info = new Form1();
            dt_select_pats = new DataTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT vp.dept_code, vp.dept_name FROM Sys_Dept_In_Use vp ";

            DataTable dt = DbConnection.ExecSql(sql);

            this.dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            select_dept_name = dataGridView1.Rows[e.RowIndex].Cells["dept_name"].Value.ToString().Trim();
            select_dept_code = dataGridView1.Rows[e.RowIndex].Cells["dept_code"].Value.ToString().Trim();

            //MessageBox.Show("选择的科室名称为：" + select_dept_name);
            //object obj = dataGridView1.Rows[e.RowIndex].Cells["dept_code"].Value.GetType();
            //MessageBox.Show("科室id号的类型：" + obj);

            //DataTable之间的复制
            //DataRow[] rows = pat_info.pat_info_dt.Select("dept_name='" + select_dept_name.ToString() + "'");

            //foreach (DataRow dr in rows)
            //{
            //    dt_select_pats.ImportRow(dr);
            //}

            //MessageBox.Show("选定科室病人行数为：" + dt_select_pats.Rows.Count);

            //this.dataGridView2.DataSource = dt_select_pats;

            //if (this.dataGridView2.Rows.Count != 0)
            //    MessageBox.Show("表格不为空！");
            string single_string = "┏_┃_┗_┣";
            string  query_sql = @"SELECT vp.patient_id,vp.visit_id,vp.patient_name,vp.date_of_birth,vp.admission_date,vp.depted_time
                               FROM v_his_pats_in_hospital vp WHERE dept_name ='" + select_dept_name + "' or dept_code='" + select_dept_code + "'";

            dt_select_pats = DbConnection.ExecSql(query_sql);

            /**
             *将母子放在一起
             **/
            dt_select_pats = OperateData.Operate1(dt_select_pats, "patient_id");

            DataRow new_row = dt_select_pats.NewRow();
            new_row["visit_id"] = dt_select_pats.Compute("max(visit_id)", "1=1"); 
            //new_row["patient_id"] = dt_select_pats.Rows.Count;                         //这段代码不知是什么意思，因此注释了
            //new_row["patient_name"] = dt_select_pats.Rows.Count;
            dt_select_pats.Rows.Add(new_row);
            string[] strings_from_single = single_string.Trim().Split('_');

            int row_count = dt_select_pats.Rows.Count;
            DateTime[] dts = new DateTime[row_count];
            System.Int32[] pats_age = new System.Int32[row_count];
            
            for (int i = 0; i < row_count; ++i)
            {
                try
                {
                    object var_tmp = dt_select_pats.Rows[i]["date_of_birth"];
                    dts[i] = Convert.ToDateTime(var_tmp);
                    pats_age[i] = (System.DateTime.Now.Year - dts[i].Year);
                }
                catch
                {
                    continue;
                }

            }

            //if (!dt_select_pats.Columns.Contains("病人年龄"))
                dt_select_pats.Columns.Add("病人年龄").SetOrdinal(4);
            for (int i = 0; i < row_count; ++i)
            {
                string pat_age = Convert.ToString(pats_age[i]);
                dt_select_pats.Rows[i]["病人年龄"] = pat_age;
            }

            OperateData.AddBracketsOnMummAnKids(dt_select_pats, strings_from_single, 0);

            this.dataGridView2.DataSource = dt_select_pats;

            //if (!dataGridView2.Rows[row_count - 1].HeaderCell.Visible.Equals(false))
            //    dataGridView2.Rows[row_count - 1].HeaderCell.Value = "合计信息"; 

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };


            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void advancedDataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,

                LineAlignment = StringAlignment.Center
            };
            //get the size of the string
            Size textSize = TextRenderer.MeasureText(rowIdx, this.Font);
            //if header width lower then string width then resize
            if (grid.RowHeadersWidth < textSize.Width + 40)
            {
                grid.RowHeadersWidth = textSize.Width + 40;
            }
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);

            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int cols_num = dt_select_pats.Columns.Count;

            for (int i = 1; i < dt_select_pats.Rows.Count - 1; ++i)
            {
                string[] strs_header = dt_select_pats.Rows[i - 1]["patient_id"].ToString().Trim().Split('_');
                string[] strs_ = dt_select_pats.Rows[i]["patient_id"].ToString().Trim().Split('_');
                string[] strs_tail = dt_select_pats.Rows[i + 1]["patient_id"].ToString().Trim().Split('_');

                if (strs_header[0].Equals(strs_[0]))
                {
                    if (i == 1)
                        dataGridView2.Rows[i - 1].DefaultCellStyle.ForeColor = Color.Red;
                    if (strs_[0].Equals(strs_tail[0]))
                        dataGridView2.Rows[i].DefaultCellStyle.ForeColor = Color.Yellow;
                    else
                        dataGridView2.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                }
                else if (strs_[0].Equals(strs_tail[0]))
                {
                    if (i == 1)
                        dataGridView2.Rows[i - 1].DefaultCellStyle.ForeColor = Color.Green;
                    dataGridView2.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    if (i == 1)
                        dataGridView2.Rows[i - 1].DefaultCellStyle.ForeColor = Color.Green;
                    dataGridView2.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
                }

            }
        }
    }
}
