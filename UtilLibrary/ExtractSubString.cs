using System;
using System.Text.RegularExpressions;

namespace UtilLibrary
{
    public class ExtractSubString
    {
        public static string getChinese(string str)
        {
            string mystr = "", ResultString = "";
            for (int i = 0; i < str.Length - 1; i++)
            {
                mystr = str.Substring(i, 1);
                if (str != "")
                {
                    if (Regex.IsMatch(mystr, "[\u4e00-\u9fa5]"))
                        ResultString += mystr;
                }
            }
            return ResultString;
        }

    }
}
