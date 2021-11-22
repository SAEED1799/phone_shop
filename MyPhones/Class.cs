using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MyPhones
{
    class Class
    {
        public static bool IsDigits(string st)
        //מתודה בודקת אם המחרוזת מורכבת מספרות
        {
            int l = st.Length;
            for (int i = 0; i <= l - 1; i++)
            {
                if (!char.IsDigit(st[i]))
                    return false;

            }
            return true;
        }

        public static bool IsEnglishLetters(string st)
        {
            //מתודה בודקת אם המחרוזת מורכבת מאותיות אנגלית -קטנות או גדולות או שניהם
            int l = st.Length;
            for (int i = 0; i <= l - 1; i++)
            {
                if (!char.IsLetter(st[i]))
                    return false;
            }
            return true;

        }

        public static bool IsHebrewLetters(string st)
        {
            //מתודה בודקת אם המחרוזת מורכבת מאותיות בעברית
            int l = st.Length;
            for (int i = 0; i <= l - 1; i++)
            {
                if (!((int)(st[i]) >= 1488) && ((int)(st[i]) <= 1514))
                    return false;
            }
            return true;

        }

        public static bool LengthIs9(string st)
        {
            return (st.Length == 9);
        }


        public static bool AgeMore10(DateTime dt)
        {
            DateTime dt1 = Convert.ToDateTime(DateTime.Now);
            TimeSpan ts = dt1 - dt;
            int numOfDays = Convert.ToInt32(ts.TotalDays);
            double numOfYears = numOfDays / 365.2524;

            return numOfYears >= 10;
        }


        public static bool emailIsValid(string email)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;

            }

        }
    

    }
}
