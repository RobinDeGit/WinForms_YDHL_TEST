using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_YDHL_TEST
{
    public partial class Form1 : Form
    {
        private string pat_info_sql;
        public DataTable pat_info_dt;
        public Form1()
        {
            InitializeComponent();
            pat_info_sql = @"SELECT vp.patient_id,vp.visit_id,vp.patient_name,vp.dept_name,vp.admission_date,vp.depted_time
                    FROM v_his_pats_in_hospital vp WHERE vp.admission_date > SYSDATE - 7/24";

            pat_info_dt = DbConnection.ExecSql(pat_info_sql);
            this.dataGridView1.DataSource = pat_info_dt;
            this.dataGridView1.Hide();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string str = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            MessageBox.Show(str);
        }

        private void dataGridView1_ColumnNameChanged(object sender, DataGridViewColumnEventArgs e)
        {

        }
    }
}
