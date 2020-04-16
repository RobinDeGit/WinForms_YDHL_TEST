using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_YDHL_TEST
{
    class OperateData
    {
        public static DataTable Operate1(DataTable dt, string id)
        {
            int row_count = dt.Rows.Count;

            for (int i = 1; i < row_count; ++i)
            {
                string[] one_str_strs_i = dt.Rows[i]["patient_id"].ToString().Trim().Split('_');
                int strs_i_length = one_str_strs_i.Length;
                for (int j = 0; j < i; ++j)
                {
                    string[] one_str_strs_j = dt.Rows[j]["patient_id"].ToString().Trim().Split('_');
                    if (one_str_strs_i[0].Equals(one_str_strs_j[0]) && strs_i_length >= 1)
                    {
                        //将第i行放入第j行前面
                        DataRow drTemp = dt.NewRow();
                        drTemp.ItemArray = dt.Rows[i].ItemArray;
                        dt.Rows.RemoveAt(i);
                        dt.Rows.InsertAt(drTemp, j + 1);
                        j++;
                    }
                    else
                        continue;
                }
            }

            for (int i = 0; i < row_count - 1; ++i)
            {
                string[] strs_1 = dt.Rows[i]["patient_id"].ToString().Trim().Split('_');
                string[] strs_2 = dt.Rows[i + 1]["patient_id"].ToString().Trim().Split('_');

                if (!strs_1[0].Equals(strs_2[0]))
                    continue;

                if (strs_1.Length > strs_2.Length)
                {
                    DataRow dr_new = dt.NewRow();
                    dr_new.ItemArray = dt.Rows[i].ItemArray;
                    dt.Rows[i].ItemArray = dt.Rows[i + 1].ItemArray;
                    dt.Rows[i + 1].ItemArray = dr_new.ItemArray;
                }
                    
            }

            return dt;
        }

        public static void AddBracketsOnMummAnKids(DataTable dt_opt, string[] brackets, int n)
        {
            int cols_num = dt_opt.Columns.Count;
            string prcd_bracket = brackets[0];
            string single_bracket = brackets[1];
            string decd_bracket = brackets[2];
            string middle_bracket = brackets[3];
            
            dt_opt.Columns.Add("组号",typeof(string));
            //dt_opt.Columns["组号"].SetOrdinal(n);
            for (int i = 1; i < dt_opt.Rows.Count - 1; ++i)
            {
                string[] strs_header = dt_opt.Rows[i-1]["patient_id"].ToString().Trim().Split('_');
                string[] strs_ = dt_opt.Rows[i]["patient_id"].ToString().Trim().Split('_');
                string[] strs_tail = dt_opt.Rows[i+1]["patient_id"].ToString().Trim().Split('_');

                if (strs_header[0].Equals(strs_[0]))
                {
                    if (i == 1)
                    {
                        dt_opt.Rows[i - 1]["组号"] = prcd_bracket;
                    }
                    if (strs_[0].Equals(strs_tail[0]))
                    {
                        dt_opt.Rows[i]["组号"] = middle_bracket;

                    }
                    else
                        dt_opt.Rows[i]["组号"] = decd_bracket;
                }
                else if (strs_[0].Equals(strs_tail[0]))
                {
                    if (i == 1)
                    {
                        dt_opt.Rows[i - 1]["组号"] = single_bracket;
                    }
                    dt_opt.Rows[i]["组号"] = prcd_bracket;
                }
                else
                {
                    if (i == 1)
                    {
                        dt_opt.Rows[i - 1]["组号"] = single_bracket;
                    }
                    dt_opt.Rows[i]["组号"] = single_bracket;
                }
                                    
            }
        }
    }
}
