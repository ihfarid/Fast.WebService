using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;
using System.Threading;

namespace FAST.DataLogic
{
	public partial class DLUserInfo: DAAccess
	{

        public bool IsUserExist(string sGDDBID)
        {
            string sSQL = "";
            object oCount;
            try
            {
                sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [UserInfo] WHERE GDDBID=%s and IsActive=%n", sGDDBID,1);
                oCount = ExecuteScalar(sSQL);
                if (Convert.ToInt32(oCount) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IDataReader GetActiveUserInfoByGDDBID(string sGDDBID)
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                sSQL = SQL.MakeSQL("SELECT * FROM [UserInfo] WHERE [GDDBID]=%s and IsActive=%n", sGDDBID, 1);
                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }

        public IDataReader GetActiveUserInfoByTerritoryID(string sTerritoryID)
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                sSQL = SQL.MakeSQL(@"SELECT * FROM [UserInfo] WHERE [GDDBID] in (SELECT GDDBID FROM [OrderCollectionSystem].[dbo].[SFRegiInfo] a INNER JOIN [OrderCollectionSystem].[dbo].[Territory] b ON a.TerritoryID=b.TerritoryID WHERE b.TerritoryCode=%s) and IsActive=%n ", sTerritoryID, 1);
                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }

        public int GetNoOfTargetDoctor(string sTerritoryID)
        {
            string sQuery;
            object oNoOfTargetDoctor;
            int nNoOfTargetDoctor;
            try
            {
                sQuery = SQL.MakeSQL("SELECT TargetDoctor FROM [TerrWiseTargetDoc] WHERE Territory=%s", sTerritoryID);
                oNoOfTargetDoctor = ExecuteScalar(sQuery);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return nNoOfTargetDoctor = Convert.ToInt32(oNoOfTargetDoctor);
        }

        public DataTable GetUserInfoByGDDBID(string sGDDBID, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                //sSQL = SQL.MakeSQL(@"SELECT * FROM [UserInfo] WHERE GDDBID = %s",
                //               sGDDBID);
                sSQL = SQL.MakeSQL(@"SELECT * FROM [UserInfo] WHERE [GDDBID]=%s", sGDDBID);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);              
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public int UpdateRMUserInfo(string sGDDBID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nResult = 0;

            try
            {
                SqlCommand oSqlCommand = new SqlCommand("spUpdateUserInfo", oSqlConnection, oSqlTransaction);
                oSqlCommand.CommandType = CommandType.StoredProcedure;
                oSqlCommand.Parameters.Add("@GDDBID", SqlDbType.VarChar, 50).Value = sGDDBID;
                oSqlCommand.Parameters.Add("@result", SqlDbType.Int, 50).Direction = ParameterDirection.Output;
                oSqlCommand.ExecuteNonQuery();
                nResult = Convert.ToInt32(oSqlCommand.Parameters["@result"].Value);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nResult;
        }

        public DataTable GetDCRInfo(int nDay, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            DataTable dt = new DataTable();

            try
            {
                SqlCommand oSqlCommand = new SqlCommand("spGetDCRInfo", oSqlConnection, oSqlTransaction);
                oSqlCommand.CommandType = CommandType.StoredProcedure;
                oSqlCommand.Parameters.Add("@nDay", SqlDbType.VarChar, 50).Value = nDay;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = oSqlCommand;
                dt = new DataTable();
                adapter.Fill(dt);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dt;
        }

        public int GetNoOfTargetDoctor(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sTerritoryID)
        {
            int nNoOfTargetDoctor;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SELECT MinTargetDoctor FROM [TerrWiseTargetDoc] WHERE Territory=%s", sTerritoryID);
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nNoOfTargetDoctor = 0;
                }
                else
                {
                    nNoOfTargetDoctor = Convert.ToInt32(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nNoOfTargetDoctor;
        }

		//public bool IsDuplicate(string sUserInfoName)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [UserInfo] WHERE UserInfoName=%s ", sUserInfoName);
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
		//public bool IsDuplicate(string sUserInfoName, int nID)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [UserInfo] WHERE UserInfoName=%s AND UserID!= %n ", sUserInfoName, nID);
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
		//public IDataReader GetUserInfo(string sUserInfoName)
		//{
			//string sSQL = "";
			//IDataReader oReader;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT * FROM [UserInfo] WHERE [UserInfoName]=%s ", sUserInfoName);
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
