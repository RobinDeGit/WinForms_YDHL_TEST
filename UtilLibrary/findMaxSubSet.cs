using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.Windows.Forms;

namespace UtilLibrary
{
    public class findMaxSubSet
    {
        private static DataRow[] final_idx = new DataRow[] { };
        private static int tmp_len = 0;

        private class SumObj
        {
            private DataRow[] elements;
            private double sum;

            public SumObj(DataRow[] elements)
            {
                this.elements = elements;
                this.sum = computeSum();
            }

            public DataRow[] getElements()
            {
                return elements;
            }

            public double getSum()
            {
                return sum;
            }

            private double computeSum()
            {
                double tempSum = 0;
                for (int i = 0; i < elements.Length; i++)
                    tempSum += Double.Parse(elements[i]["amount"].ToString());

                return tempSum;
            }
        }

        private static void combination(SumObj prefixSumObj, SumObj remainingSumObj, double expectedSum)
        {
            if ((prefixSumObj.getSum() == expectedSum))
            {
                if (prefixSumObj.getElements().Length > tmp_len)
                {
                    tmp_len = prefixSumObj.getElements().Length;
                    final_idx = prefixSumObj.getElements();
                }
            }

            if (remainingSumObj.getElements().Length == 0) return;

            for (int i = 0; i < remainingSumObj.getElements().Length; ++i)
            {
                DataRow[] newPrefixSumInput = new DataRow[prefixSumObj.getElements().Length + 1];
                Array.Copy(prefixSumObj.getElements(), 0, newPrefixSumInput, 0, prefixSumObj.getElements().Length);
                newPrefixSumInput[prefixSumObj.getElements().Length] = remainingSumObj.getElements()[i];
                SumObj newPrefixSumObj = new SumObj(newPrefixSumInput);

                DataRow[] newRemainingSumInput = new DataRow[remainingSumObj.getElements().Length - i - 1];
                Array.Copy(remainingSumObj.getElements(), i + 1, newRemainingSumInput, 0, remainingSumObj.getElements().Length - i - 1);
                SumObj newRemainingSumObj = new SumObj(newRemainingSumInput);

                combination(newPrefixSumObj, newRemainingSumObj, expectedSum);
            }
        }
        public static List<DataRow> findSubArray(List<DataRow> numbers, Double target_sum)
        {
            DataRow[] whole_array = numbers.ToArray();
            if (whole_array.Length == 1) return new List<DataRow>();

            combination(new SumObj(new DataRow[0]), new SumObj(whole_array), target_sum);

            tmp_len = 0;

            List<DataRow> final_rows = new List<DataRow>(final_idx);

            final_idx = new DataRow[] { };

            return final_rows;

        }

        public static List<DataRow> findSubSet(List<DataRow> rows, int n, double sum)
        {
//            rows.Sort((a, b) => double.Parse(a["amount"].ToString()).CompareTo(double.Parse(b["amount"].ToString())));
            List<int> final_rows = new List<int>();
            DataRow[] whole_array = rows.ToArray();
            double[] whole_array_amount = new double[whole_array.Length];
            for (int i = 0; i < whole_array_amount.Length; ++i)
            {
                whole_array_amount[i] = double.Parse(whole_array[i]["amount"].ToString());
            }
            int totalSubSets = (1 << n);
            for (int i = 1; i < totalSubSets; ++i)
            {
                double curSum = 0;
                for (int j = n - 1; j >= 0; --j)
                {
                    if (((i >> j) & 1) > 0)
                        curSum += whole_array_amount[j];
                }
                if (curSum == sum)
                {
                    List<int> tmp_result = new List<int>();
                    for(int j = n - 1; j >= 0; --j)
                    {
                        if (((i >> j) & 1) > 0)
                        {
                            tmp_result.Add(j);
                        }
                    }
                    if (tmp_result.Count > final_rows.Count)
                    {
                        final_rows = tmp_result;
                        tmp_result = new List<int>();
                    }
                }
            }

            List<DataRow> final_result = new List<DataRow>();
            for (int i = 0; i < final_rows.Count; ++i)
            {
                final_result.Add(rows[final_rows[i]]);
            }

            return final_result ;
        }
    }
}
