using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
	public partial class DLCommandInfo: DAAccess
	{
        public IDataReader GetCommandInfos(string sTerritoryID)
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                sSQL = SQL.MakeSQL("SELECT * FROM [CommandInfo] WHERE TerritoryID = %s and IsExcute = %n", sTerritoryID, 0);
                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }

        public DataTable GetCommand(string sTerritoryID, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                sSQL = SQL.MakeSQL("SELECT * FROM [CommandInfo] WHERE TerritoryID = %s and IsExcute = %n", sTerritoryID, 0);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public DataTable GetCommand(int nID, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                sSQL = SQL.MakeSQL("SELECT * FROM [CommandInfo] WHERE CommandID=%n", nID); 
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public bool IsPVPTimeExtend(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sTerritoryID, string sPVPEndDate)
        {

            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [CommandInfo] WHERE TerritoryID=%s", sTerritoryID);
                sSQL = sSQL + " AND Description like '%" + sPVPEndDate + "%'";
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object oCount = cmd.ExecuteScalar();

                //if (o == DBNull.Value)
                //{
                //    nCount = 0;
                //}
                //else
                //{
                //    nCount = Convert.ToInt32(o);
                //}

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

        public string GetPVPEndDate(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sTerritoryID)
        {
            string sPVPEndDate = "";
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SELECT Top 1 [Description] FROM [CommandInfo] WHERE TableName='PVPTimeExtend' and TerritoryID=%s Order By CommandID DESC", sTerritoryID);
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();
                string sQuery = Convert.ToString(o);

                if (sQuery != "")
                {
                    sPVPEndDate = sQuery.Substring(sQuery.Length - 12, 11);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return sPVPEndDate;
        }

        public int GetDCREntryHours(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sTerritoryID)
        {
            int nDCREntryHours;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SELECT Top 1 [Description] FROM [CommandInfo] WHERE TableName='DCRTimeExtend' and TerritoryID=%s Order By CommandID DESC", sTerritoryID);
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();
                string sQuery = Convert.ToString(o);

                if (sQuery == "")
                {
                    nDCREntryHours = 0;
                }
                else
                {
                    //sDCREntryHours = sDCREntryHours.Substring(sDCREntryHours.Length - 2);
                    string[] sDCREntryHours = sQuery.Split('=');
                    nDCREntryHours = Convert.ToInt32(sDCREntryHours[1]);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nDCREntryHours;
        }

        public int InsertCommandInfo(string sTerritoryID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nResult = 0;

            try
            {
                SqlCommand oSqlCommand = new SqlCommand("spInsertCommmandInfo", oSqlConnection, oSqlTransaction);
                oSqlCommand.CommandType = CommandType.StoredProcedure;
                oSqlCommand.Parameters.Add("@sTerritoryID", SqlDbType.VarChar, 50).Value = sTerritoryID;
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
        
		//public bool IsDuplicate(string sCommandInfoName)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [CommandInfo] WHERE CommandInfoName=%s ", sCommandInfoName);
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
		//public bool IsDuplicate(string sCommandInfoName, int nID)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [CommandInfo] WHERE CommandInfoName=%s AND CommandID!= %n ", sCommandInfoName, nID);
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
		//public IDataReader GetCommandInfo(string sCommandInfoName)
		//{
			//string sSQL = "";
			//IDataReader oReader;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT * FROM [CommandInfo] WHERE [CommandInfoName]=%s ", sCommandInfoName);
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
