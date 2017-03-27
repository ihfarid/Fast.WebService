using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.IO;
using System.Data;
using System.Collections.Specialized;
using System.Configuration;

namespace FAST.Core
{
    public class Global
    {
        public enum Sex
        {
            Male = 1,
            Female
        }

        public static string GetApplicationName()
        {
            NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appParams");
            return oValues["ApplicationName"];
        }
        public static bool IsNumeric(string numberString)
        {
            char[] ca = numberString.ToCharArray();
            for (int i = 0; i < ca.Length; i++)
            {
                if (!char.IsNumber(ca[i]))
                    return false;
            }
            return true;
        }

        public static DateTime MinimunDateTimeValue
        {
            get { return System.Data.SqlTypes.SqlDateTime.MinValue.Value; }
        }

        private static string _sDesitinationFolder;
        private static string _sSourceFolder;
        private static string _sEmail;
        private static string _sPassword;
        private static long _nFileCounter;
        public static string DestinatonFolder
        {
            get
            {
                return _sDesitinationFolder;
            }
            set
            {
                _sDesitinationFolder = value;
            }
        }
        public static string SourceFolder
        {
            get
            {
                return _sSourceFolder;
            }
            set
            {
                _sSourceFolder = value;
            }
        }
        public static string Email
        {
            get
            {
                return _sEmail;
            }
            set
            {
                _sEmail = value;
            }
        }
        public static string Password
        {
            get
            {
                return _sPassword;
            }
            set
            {
                _sPassword = value;
            }
        }
        public static long FileCounter
        {
            get
            {
                return _nFileCounter;
            }
            set
            {
                _nFileCounter = value;
            }
        }
        private static CultureInfo _oCultureInfo;
        public static CultureInfo CurrentCultureInfo
        {
            get
            {
                _oCultureInfo = new CultureInfo("en-US", false);
                int[] sGroupGormat = { 3, 2 };
                NumberFormatInfo oNumberFormatInfo = new NumberFormatInfo();
                oNumberFormatInfo.NumberGroupSizes = sGroupGormat;
                _oCultureInfo.NumberFormat = oNumberFormatInfo;
                return _oCultureInfo;
            }
        }

        public static string GetExportFolder
        {
            get
            {
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appParams");
                return oValues["ExportDataFolder"];
            }
        }

        #region Date Related functuion
        #region First date of month/year
        /// <summary>
        /// This function return the first date of month of param date
        /// </summary>
        /// <param name="forDate">A valid date</param>
        /// <returns>Return the date of month</returns>
        public static DateTime FirstDateOfMonth(DateTime forDate)
        {
            DateTime dFDOfMonth = new DateTime(forDate.Year, forDate.Month, 1);
            return dFDOfMonth;
        }
        public static DateTime FirstDateOfMonth(int year, int month)
        {
            DateTime dFDOfMonth = new DateTime(year, month, 1);
            return dFDOfMonth;
        }

        public static DateTime FirstDateOfYear(DateTime forDate)
        {
            DateTime dFDOfYear = new DateTime(forDate.Year, 1, 1);
            return dFDOfYear;
        }
        public static DateTime FirstDateOfYear(int year)
        {
            DateTime dFDOfYear = new DateTime(year, 1, 1);
            return dFDOfYear;
        }
        #endregion
        #region Last date of month/year
        public static DateTime LastDateOfYear(DateTime forDate)
        {
            DateTime dFDOfYear = new DateTime(forDate.Year, 12, 31);
            return dFDOfYear;
        }

        public static DateTime LastDateOfYear(int year)
        {
            DateTime dFDOfYear = new DateTime(year, 12, 31);
            return dFDOfYear;
        }

        public static DateTime LastDateOfMonth(DateTime forDate)
        {
            DateTime dLDOfMonth = new DateTime(forDate.Year, forDate.Month, 1);
            dLDOfMonth = dLDOfMonth.AddMonths(1);
            dLDOfMonth = dLDOfMonth.AddDays(-1);
            return dLDOfMonth;
        }
        public static DateTime LastDateOfMonth(int year, int month)
        {
            DateTime dLDOfMonth = new DateTime(year, month, 1);
            dLDOfMonth = dLDOfMonth.AddMonths(1);
            dLDOfMonth = dLDOfMonth.AddDays(-1);
            return dLDOfMonth;
        }
        #endregion
        #endregion

        #region Date Difference function
        /// <summary>
        /// This function return the integer value in accordance with stringformat
        /// </summary>
        /// <param name="Date1">Subtract from this value and must be datetime</param>
        /// <param name="Date2">Subtract this value and must be datetime</param>
        /// <param name="Interval">There are three types of format 1=d/D return difference in days, 2="m/M return difference in month, 3=y/Y return difference in years//   </param>
        /// <returns></returns>
        public static int DateDiff(string Interval, DateTime Date1, DateTime Date2)
        {
            int diffVale = 0;
            DateTime fromDate, toDate;

            if (Date1 > Date2)
            {
                toDate = Date1; fromDate = Date2;
            }
            else
            {
                fromDate = Date1; toDate = Date2;
            }

            switch (Interval)
            {
                case "D":
                case "d":
                    for (int curYear = fromDate.Year; curYear < toDate.Year; curYear++)
                    {
                        diffVale += new DateTime(curYear, 12, 31).DayOfYear;
                    }
                    diffVale += toDate.DayOfYear - fromDate.DayOfYear;
                    break;

                case "M":
                case "m":
                    diffVale = toDate.Year - fromDate.Year;
                    diffVale = diffVale * 12;
                    diffVale += toDate.Month - fromDate.Month;
                    break;

                case "Y":
                case "y":
                    diffVale = toDate.Year - fromDate.Year;
                    break;
            }
            if (Date1 > Date2)
            {
                diffVale = -diffVale;
            }

            return diffVale;
        }
        #endregion

        #region Date Add function
        /// <summary>
        /// This function add number with date in accordance with interval
        /// </summary>
        /// <param name="Interval">There are three types of interval 1:= d/D add day(s), 2:= m/M add month(s), 3: =y/Y add year(s) with input date</param>
        /// <param name="Number">Value to be added</param>
        /// <param name="Date">Input date add with this value</param>
        /// <returns>Return datatime after operation</returns>
        public static DateTime DateAdd(string Interval, int Number, DateTime Date)
        {
            DateTime retValue = Date;
            switch (Interval)
            {
                case "D":
                case "d":
                    retValue = retValue.AddDays(Number);
                    break;

                case "M":
                case "m":
                    retValue = retValue.AddMonths(Number);
                    break;

                case "Y":
                case "y":
                    retValue = retValue.AddYears(Number);
                    break;
            }

            return retValue;
        }
        #endregion

        #region Convert to Date Time
        public static DateTime ConvertToDateTime(int nDay, int nMonth, int nYear)
        {
            string sMonth = "";
            switch (nMonth)
            {
                case 1:
                    sMonth = "Jan";
                    break;
                case 2:
                    sMonth = "Feb";
                    break;
                case 3:
                    sMonth = "Mar";
                    break;
                case 4:
                    sMonth = "Apr";
                    break;
                case 5:
                    sMonth = "May";
                    break;
                case 6:
                    sMonth = "Jun";
                    break;
                case 7:
                    sMonth = "Jul";
                    break;
                case 8:
                    sMonth = "Aug";
                    break;
                case 9:
                    sMonth = "Sep";
                    break;
                case 10:
                    sMonth = "Oct";
                    break;
                case 11:
                    sMonth = "Nov";
                    break;
                case 12:
                    sMonth = "Dec";
                    break;
            };
            return Convert.ToDateTime(nDay.ToString() + " " + sMonth + " " + nYear.ToString());
        }
        #endregion

        #region Left/Right/Mid  function
        public static string Left(string intputString, int Length)
        {
            string retStr = "";
            if (Length < intputString.Length)
            {
                retStr = intputString.Substring(0, Length);
            }
            else
            {
                retStr = intputString;
            }
            return retStr;
        }

        public static string Right(string intputString, int Length)
        {
            string retStr = "";
            if (Length < intputString.Length && Length > 0)
            {
                retStr = intputString.Substring((intputString.Length - Length), Length);
            }
            else
            {
                retStr = intputString;
            }
            return retStr;
        }
        public static string Mid(string intputString, int Start, int Length)
        {
            string retStr = "";

            if ((Start + Length) < intputString.Length)
            {
                retStr = intputString.Substring(Start, Length);
            }
            else if (Start < intputString.Length)
            {
                retStr = intputString.Substring(Start);
            }
            else
            {
                retStr = intputString;
            }
            return retStr;
        }
        public static string Mid(string intputString, int Start)
        {
            string retStr = "";

            if (Start < intputString.Length)
            {
                retStr = intputString.Substring(Start);
            }
            else
            {
                retStr = intputString;
            }
            return retStr;
        }
        #endregion

        #region Taka/Amount in words
        private static string HundredWords(int inputValue)
        {
            string hundredWords = "", numStr = "", pos1 = "", pos2 = "", pos3 = "";
            string[] digits = new string[10] { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] teens = new string[10] { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] tens = new string[10] { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

            numStr = Right(inputValue.ToString("000"), 3);
            if (Left(numStr, 1) != "0")
            {
                pos1 = digits.GetValue(Convert.ToInt32(Left(numStr, 1))) + " hundred";
            }
            else
            {
                pos1 = "";
            }

            numStr = Right(numStr, 2);
            if (Left(numStr, 1) == "1")
            {
                pos2 = Convert.ToString(teens.GetValue(Convert.ToInt32(Right(numStr, 1))));
                pos3 = "";
            }
            else
            {
                pos2 = Convert.ToString(tens.GetValue(Convert.ToInt32(Left(numStr, 1))));
                pos3 = Convert.ToString(digits.GetValue(Convert.ToInt32(Right(numStr, 1))));
            }
            hundredWords = pos1;
            if (hundredWords != "")
            {
                if (pos2 != "")
                {
                    hundredWords = hundredWords + " ";
                }
            }
            hundredWords = hundredWords + pos2;

            if (hundredWords != "")
            {
                if (pos3 != "")
                {
                    hundredWords = hundredWords + " ";
                }
            }
            hundredWords = hundredWords + pos3;

            return hundredWords;
        }

        private static string InWords(double inputValue, string beforeDecimal, string afterDecimal)
        {
            int commaCount = 0, digitCount = 0;
            string sign = "", takaWords = "", numStr = "", taka = "", paisa = "", pow = "";
            string[] pows = new string[3] { "crore", "thousand", "lakh" };

            if (inputValue < 0)
            {
                sign = "Minus";
                inputValue = Math.Abs(inputValue);
            }

            numStr = inputValue.ToString("0.00");
            paisa = HundredWords(Convert.ToInt32(Right(numStr, 2)));

            if (paisa != "")
            {
                paisa = paisa.Substring(0, 1).ToUpper() + paisa.Substring(1);
                paisa = afterDecimal + " " + paisa;
            }

            numStr = Left(numStr, numStr.Length - 3);
            taka = HundredWords(Convert.ToInt32(Right(numStr, 3)));

            if (numStr.Length <= 3)
            {
                numStr = "";
            }
            else
            {
                numStr = Left(numStr, numStr.Length - 3);
            }

            commaCount = 1;
            if (numStr != "")
            {
                do
                {
                    if (commaCount % 3 == 0)
                    {
                        digitCount = 3;
                    }
                    else
                    {
                        digitCount = 2;
                    }

                    pow = HundredWords(Convert.ToInt32(Right(numStr, digitCount)));
                    if (pow != "")
                    {
                        if (Convert.ToString(inputValue).Length > 10)
                        {
                            pow = pow + " " + pows.GetValue(commaCount % 3) + " crore ";
                        }
                        else
                        {
                            pow = pow + " " + pows.GetValue(commaCount % 3);
                        }
                    }
                    if (taka != "")
                    {
                        if (pow != "")
                        {
                            pow = pow + " ";
                        }
                    }

                    taka = pow + taka;
                    if (numStr.Length <= digitCount)
                    {
                        numStr = "";
                    }
                    else
                    {
                        numStr = Left(numStr, numStr.Length - digitCount);
                    }
                    commaCount = commaCount + 1;

                }
                while (numStr != "");
            }

            if (taka != "")
            {
                taka = taka.Substring(0, 1).ToUpper() + taka.Substring(1);
                taka = beforeDecimal + " " + taka;
            }
            takaWords = taka;

            if (takaWords != "")
            {
                if (paisa != "")
                {
                    takaWords = takaWords + " and ";
                }
            }
            takaWords = takaWords + paisa;

            if (takaWords == "")
            {
                takaWords = beforeDecimal + " Zero";
            }
            takaWords = sign + takaWords + " Only";
            return takaWords;
        }

        public static string AmountInWords(decimal inputValue, string beforeDecimal, string afterDecimal)
        {
            return InWords(Convert.ToDouble(inputValue), beforeDecimal, afterDecimal);
        }

        public static string AmountInWords(float inputValue, string beforeDecimal, string afterDecimal)
        {
            return InWords(Convert.ToDouble(inputValue), beforeDecimal, afterDecimal);
        }

        public static string AmountInWords(double inputValue, string beforeDecimal, string afterDecimal)
        {
            return InWords(inputValue, beforeDecimal, afterDecimal);
        }

        public static string TakaWords(decimal inputValue)
        {
            return TakaWords(Convert.ToDouble(inputValue));
        }

        public static string TakaWords(float inputValue)
        {
            return TakaWords(Convert.ToDouble(inputValue));
        }

        public static string TakaWords(double inputValue)
        {
            return InWords(inputValue, "Taka", "Paisa");
        }
        #endregion

        #region RoundOff
        public static double RoundOff(decimal inputValue)
        {
            return Convert.ToDouble(Math.Round(inputValue));
        }
        public static double RoundOff(decimal inputValue, int digits)
        {
            return RoundOff(Convert.ToDouble(inputValue), digits);
        }

        public static double RoundOff(double inputValue, int digits)
        {
            double rmndr = 0.0, retVal = 0.0;
            if (digits < 0)
            {
                retVal = Math.Pow(10, Math.Abs(digits));
                rmndr = ((inputValue % retVal) / retVal);
                if (rmndr >= 0.5)
                {
                    rmndr = 1 * retVal;
                }
                else
                {
                    rmndr = 0;
                }
                retVal = (((inputValue - (inputValue % retVal)) / retVal) * retVal) + rmndr;
            }
            else
            {
                retVal = Math.Round(inputValue, digits);
            }
            return retVal;
        }
        public static double RoundOff(double inputValue)
        {
            return Math.Round(inputValue);
        }

        public static double RoundOff(float inputValue, int digits)
        {
            return RoundOff(Convert.ToDouble(inputValue), digits);
        }
        public static double RoundOff(float inputValue)
        {
            return Math.Round(inputValue);
        }
        #endregion

        #region Taka Format
        public static string TakaFormat(decimal inputValue, bool bShowDecimal)
        {
            return TakaFormat(Convert.ToDouble(inputValue), bShowDecimal);
        }
        public static string TakaFormat(float inputValue, bool bShowDecimal)
        {
            return TakaFormat(Convert.ToDouble(inputValue), bShowDecimal);
        }
        public static string TakaFormat(double inputValue, bool bShowDecimal)
        {
            int commaCount = 1, digitCount = 0;
            string sign = "", numStr = "", takaFormat = "";

            if (inputValue < 0)
            {
                sign = "-";
                inputValue = (-inputValue);
            }

            numStr = inputValue.ToString("0.00");

            takaFormat = Right(numStr, 6);
            if ((numStr.Length) <= 6)
            {
                numStr = "";
            }
            else
            {
                numStr = Left(numStr, numStr.Length - 6);
            }

            if (numStr == "")
            {
                takaFormat = takaFormat;
                return takaFormat;
            }

            do
            {
                if (commaCount % 3 == 0)
                {
                    digitCount = 3;
                }
                else
                {
                    digitCount = 2;
                }

                takaFormat = Right(numStr, digitCount) + "," + takaFormat;

                if (numStr.Length <= digitCount)
                {
                    numStr = "";
                }
                else
                {
                    numStr = Left(numStr, numStr.Length - digitCount);
                }

                commaCount = commaCount + 1;
            }
            while (numStr != "");

            takaFormat = sign + takaFormat;
            if (bShowDecimal)
            {
                return takaFormat;
            }
            else
            {
                return takaFormat.Substring(0, takaFormat.Length - 3);
            }
        }
        #endregion

        #region Million Format
        public static string MillionFormat(decimal inputValue, char sepChar, char decChar, bool bShowDecimal)
        {
            return MillionFormat(Convert.ToDouble(inputValue), sepChar, decChar, bShowDecimal);
        }
        public static string MillionFormat(decimal inputValue, bool bShowDecimal)
        {
            return MillionFormat(Convert.ToDouble(inputValue), bShowDecimal);
        }
        public static string MillionFormat(float inputValue, char sepChar, char decChar, bool bShowDecimal)
        {
            return MillionFormat(Convert.ToDouble(inputValue), sepChar, decChar, bShowDecimal);
        }
        public static string MillionFormat(float inputValue, bool bShowDecimal)
        {
            return MillionFormat(Convert.ToDouble(inputValue), bShowDecimal);
        }
        public static string MillionFormat(double inputValue, char sepChar, char decChar, bool bShowDecimal)
        {
            int commaCount = 1, digitCount = 3;
            string sign = "", numStr = "", milFormat = "";

            if (inputValue < 0)
            {
                sign = "-";
                inputValue = (-inputValue);
            }
            if (inputValue < 1000)
            {
                return inputValue.ToString();
            }
            numStr = inputValue.ToString("0.00");
            milFormat = Right(numStr, 6);
            if ((numStr.Length) <= 6)
            {
                numStr = "";
            }
            else
            {
                numStr = Left(numStr, numStr.Length - 6);
            }

            if (numStr == "")
            {
                milFormat = milFormat;
                return milFormat;
            }

            do
            {
                milFormat = Right(numStr, digitCount) + "," + milFormat;

                if (numStr.Length <= digitCount)
                {
                    numStr = "";
                }
                else
                {
                    numStr = Left(numStr, numStr.Length - digitCount);
                }
                commaCount = commaCount + 1;
            }
            while (numStr != "");
            milFormat = sign + milFormat;

            milFormat = milFormat.Replace('.', '|');
            milFormat = milFormat.Replace(',', sepChar);
            milFormat = milFormat.Replace('|', decChar);

            if (bShowDecimal)
            {
                return milFormat;
            }
            else
            {
                return milFormat.Substring(0, milFormat.Length - 3);
            }

        }
        public static string MillionFormat(double inputValue, bool bShowDecimal)
        {
            return MillionFormat(inputValue, ',', '.', bShowDecimal);
        }
        #endregion

        #region Create CSV File
        public static void CreateCSVFile(string FilePath, System.Data.DataTable oTable, string sDelimiter)
        {
            try
            {
                string sText = "";

                StreamWriter oWriter = new StreamWriter(FilePath);

                foreach (DataColumn oColumn in oTable.Columns)
                {
                    if (sText == "")
                    {
                        sText = oColumn.ColumnName;
                    }
                    else
                    {
                        sText = sText + sDelimiter + oColumn.ColumnName;
                    }
                }
                oWriter.WriteLine(sText);

                foreach (DataRow oRow in oTable.Rows)
                {
                    sText = "";
                    foreach (DataColumn oColumn in oTable.Columns)
                    {

                        if (sText == "")
                        {
                            sText = oRow[oColumn.ColumnName].ToString();
                        }
                        else
                        {
                            sText = sText + sDelimiter + oRow[oColumn.ColumnName].ToString();
                        }
                    }
                    oWriter.WriteLine(sText);
                }

                oWriter.Close();
                oWriter = null;
            }

            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
        #endregion

        #region Create CSV File
        public static void CreateERCCSVFile(string FilePath, System.Data.DataTable oTable, string sDelimiter)
        {
            try
            {
                string sText = "";

                StreamWriter oWriter = new StreamWriter(FilePath);

                foreach (DataColumn oColumn in oTable.Columns)
                {
                    if (sText == "")
                    {
                        sText = oColumn.ColumnName;
                    }
                    else
                    {
                        sText = sText + sDelimiter + oColumn.ColumnName;
                    }
                }
                oWriter.WriteLine(sText);

                foreach (DataRow oRow in oTable.Rows)
                {

                    sText = "";
                    string sRowValue = "";
                    foreach (DataColumn oColumn in oTable.Columns)
                    {
                        if (oRow[oColumn.ColumnName].ToString() == "")
                        {
                            sRowValue = null;
                        }
                        else
                        {
                            sRowValue = oRow[oColumn.ColumnName].ToString();
                        }

                        if (sText == "")
                        {

                            sText = sRowValue;
                            //if (oRow[oColumn.ColumnName].ToString() == "")
                            //{
                            //    sText = null;
                            //}
                            //else
                            //{
                            //    sText = oRow[oColumn.ColumnName].ToString();
                            //}

                        }
                        else
                        {
                            sText = sText + sDelimiter + sRowValue;
                            //sText = sText + sDelimiter + oRow[oColumn.ColumnName].ToString();

                        }

                    }

                    oWriter.WriteLine(sText);
                }

                oWriter.Close();
                oWriter = null;
            }

            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
        }
        #endregion

        public static DateTime SQLDateTimeMinValue
        {
            get
            {
                return System.Data.SqlTypes.SqlDateTime.MinValue.Value;
            }
        }



    }
}
