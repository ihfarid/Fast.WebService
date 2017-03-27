using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAST.Core.DataAccess
{
    public class NullHandler
    {
        public static object GetNullValue(string value)
        {
            if (value != "")
            {
                return value;
            }
            else
            {
                return null;
            }
        }
        public static object GetNullValue(int value)
        {
            if (value != 0)
            {
                return value;
            }
            else
            {
                return null;
            }
        }
        public static string GetString(object o)
        {
            if (o == DBNull.Value)
            {
                return "";
            }
            else
            {
                return o.ToString();
            }
        }
        public static int GetInteger(object o)
        {
            if (o == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(o);
            }
        }
    }
}
