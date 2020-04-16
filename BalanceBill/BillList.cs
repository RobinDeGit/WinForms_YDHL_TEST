using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using UtilLibrary;

namespace BalanceBill
{
    public partial class BillList : Form
    {
        private OracleCommandBuilder builder;
        private OracleDataAdapter oda;
        private OracleConnection connection;

        private DataSet dataset;

        private String patient_id;
        private String visit_id;

        private DataTable billDt;

        private static List<List<DataRow>> rows2Opt = new List<List<DataRow>>();
        private static List<DataRow> rows2remove = new List<DataRow>();

        public BillList()
        {
            InitializeComponent();
            dataset = new DataSet();
        }

        private void loadToDataTable()
        {
            string sql = @"select * from inp_bill_detail ibd where ibd.patient_id = " +
                   "'" + patient_id + "'" + " and " + "ibd.visit_id = " + visit_id
                   + "order by ibd.item_code";
            oda = new OracleDataAdapter(sql, UtilLibrary.DbConnection.ConnString1);
            connection = oda.SelectCommand.Connection;
            builder = new OracleCommandBuilder(oda);
            oda.Fill(dataset, "inp_bill_detail");
            billDt = dataset.Tables["inp_bill_detail"];
        }

        private void PatIdBox_Leave(object sender, EventArgs e)
        {
            if (PatIdBox.Text.Equals(String.Empty))
            {
                MessageBox.Show("请输入Patient_id");
                return;
            }
        }

        private void PatIdBox_Enter(object sender, EventArgs e)
        {
            PatIdBox.Text = String.Empty;
//            vid_box.Text = String.Empty;
        }

        private void vid_box_Leave(object sender, EventArgs e)
        {
            if (vid_box.Text.Equals(String.Empty))
            {
                MessageBox.Show("请输入Visit_id");
                return;
            } 
            
        }

        private void vid_box_Enter(object sender, EventArgs e)
        {
//            PatIdBox.Text = String.Empty;
            vid_box.Text = String.Empty;
        }

        private void query_button_MouseClick(object sender, MouseEventArgs e)
        {
            if (PatIdBox.Text.Trim().ToString().Equals("请输入PATIENT_ID") ||
                vid_box.Text.Trim().ToString().Equals("请输入VISIT_ID"))
            {
                MessageBox.Show("Patient_id 和 Visit_id 不能为空");
                return;
            }

            patient_id = PatIdBox.Text.Trim().ToString();
            visit_id = vid_box.Text.Trim().ToString();

            try
            {
                //                billDt = DbConnection.ExecSql(sql);
                loadToDataTable();
                this.inpBilldataGridView.DataSource = billDt;
            }
            catch
            {
                MessageBox.Show("无法加载数据源");
            }
         }

        private void loadRemovingRows(List<DataRow> rows)
        {
            int n = rows.Count;
            double param = 0.0;
            //            List<DataRow> result_rows = UtilLibrary.findMaxSubSet.findSubArray(rows, 0);
            List<DataRow> result_rows = UtilLibrary.findMaxSubSet.findSubSet(rows, n, param);

            String it_name = rows[0]["item_name"].ToString();
            if (result_rows.Count == 0)
            {
                MessageBox.Show(it_name + "无法平衡账目");
                return;
            }

            for (int j = 0; j < result_rows.Count; ++j)
            {
                rows2remove.Add(result_rows[j]);
            }
        }

        private void operateButton_Click(object sender, EventArgs e)
        {
            //根据项目名称分组，并存入二维列表
            List<DataRow> itemRows2Opt = new List<DataRow>();
            DataRow prev_row = billDt.Rows[0];
            itemRows2Opt.Add(prev_row);
            for (int i = 1; i < billDt.Rows.Count; ++i)
            {
                DataRow current_row = billDt.Rows[i];
                String tmp_name = prev_row["item_code"].ToString();
                String cut_name = current_row["item_code"].ToString();
                if (tmp_name.Equals(current_row["item_code"].ToString()))
                {
                    itemRows2Opt.Add(current_row);
                    prev_row = current_row;
                 
                }
                else if ((i < billDt.Rows.Count - 1) && (current_row["item_code"].ToString().Equals(billDt.Rows[i + 1]["item_code"])))
                {
                    List<DataRow> cloned = new List<DataRow>(itemRows2Opt);
                    rows2Opt.Add(cloned);
                    itemRows2Opt.Clear();
                    itemRows2Opt.Add(current_row);
                    prev_row = current_row;
                }
                else 
                {
                    List<DataRow> cloned = new List<DataRow>(itemRows2Opt);
                    rows2Opt.Add(cloned);
                    itemRows2Opt.Clear();
                    itemRows2Opt.Add(current_row);
                    prev_row = current_row;
                }

            }

            rows2Opt.Add(itemRows2Opt);

//            itemRows2Opt.Clear();

            MessageBox.Show("完成加载数据");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < rows2Opt.Count; ++i)
            {
                loadRemovingRows(rows2Opt[i]);
            }

            foreach (DataRow dr in rows2remove)
            {
                String item_name = dr["item_name"].ToString();
                Int32 dr_index = dr.Table.Rows.IndexOf(dr);
                billDt.Rows[dr_index].Delete();
//                billDt.Rows.Remove(dr);
//                dr.Delete();
            }

//            billDt.AcceptChanges();

            oda.Update(dataset.Tables["inp_bill_detail"]);

            connection.Close();

            MessageBox.Show("账目平衡完毕");
        }
    }
}
