using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
	public partial class DLAppVersionInfo: DAAccess
	{
        public string GetAppUpdatedVersionURL()
        {
            string sQuery;
            object oAppURL;
            string sAppURL;
            try
            {
                sQuery = SQL.MakeSQL("SELECT AppURL FROM [AppVersionInfo] WHERE AppType=%s ORDER BY VersionNo DESC","SF");
                oAppURL = ExecuteScalar(sQuery);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return sAppURL = Convert.ToString(oAppURL);
        }

        public string GetAppUpdatedVersionURL(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sAppURL;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SELECT AppURL FROM [AppVersionInfo] WHERE AppType=%s ORDER BY VersionNo DESC", "SF");
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    sAppURL = "";
                }
                else
                {
                    sAppURL = Convert.ToString(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return sAppURL;
        }

        public string GetRMAppUpdatedVersionURL()
        {
            string sQuery;
            object oAppURL;
            string sAppURL;
            try
            {
                sQuery = SQL.MakeSQL("SELECT AppURL FROM [AppVersionInfo] WHERE AppType=%s ORDER BY VersionNo DESC", "RM");
                oAppURL = ExecuteScalar(sQuery);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return sAppURL = Convert.ToString(oAppURL);
        }

        public string GetAppUpdatedVersionURLForRM(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sAppURL;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SELECT AppURL FROM [AppVersionInfo] WHERE AppType=%s ORDER BY VersionNo DESC", "RM");
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    sAppURL = "";
                }
                else
                {
                    sAppURL = Convert.ToString(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return sAppURL;
        }
		//public bool IsDuplicate(string sAppVersionInfoName)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [AppVersionInfo] WHERE AppVersionInfoName=%s ", sAppVersionInfoName);
				//oCount = ExecuteScalar(sSQL);
				//if (Convert.ToInt32(oCount) > 0)
				//{
					//return true;
					//}
				//else
				//{
					//return false;
				//}
			//}
			//catch (Exception e)
				//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sAppVersionInfoName, int nID)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [AppVersionInfo] WHERE AppVersionInfoName=%s AND VersionNo!= %n ", sAppVersionInfoName, nID);
				//oCount = ExecuteScalar(sSQL);
				//if (Convert.ToInt32(oCount) > 0)
				//{
					//return true;
				//}
				//else
				//{
					//return false;
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public IDataReader GetAppVersionInfo(string sAppVersionInfoName)
		//{
			//string sSQL = "";
			//IDataReader oReader;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT * FROM [AppVersionInfo] WHERE [AppVersionInfoName]=%s ", sAppVersionInfoName);
				//oReader = ExecuteReader(sSQL);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
			//return oReader;
		//}
	}
}
