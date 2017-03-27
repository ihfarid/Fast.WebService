using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using System.Data.SqlClient;
using FAST.Core.DataAccess;

namespace FAST.DataLogic
{
	public partial class DLDCRLateApprovalLog: DAAccess
	{
		public void Insert(DCRLateApprovalLog oItem)
		{
			string sSQL = "";
			try
			{
				oItem.ID.SetID(GeneratePrimaryKey("[DCRLateApprovalLog]", "LogID"));
				sSQL = SQL.MakeSQL("INSERT INTO [DCRLateApprovalLog](LogID, RegionID, TerritoryID, DCRDetail, Day, Month, Year, ApprovedDateTime, ApprovedBy) "
				+ " VALUES(%n, %s, %s, %s, %n, %n, %n, %d, %s) "
				, oItem.ID.ToInt32, oItem.RegionID,oItem.TerritoryID,oItem.DCRDetail,oItem.Day,oItem.Month,oItem.Year,oItem.ApprovedDateTime,oItem.ApprovedBy);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(DCRLateApprovalLog oItem)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("UPDATE [DCRLateApprovalLog] SET RegionID = %s, TerritoryID = %s, DCRDetail = %s, Day = %n, Month = %n, Year = %n, ApprovedDateTime = %d, ApprovedBy = %s WHERE [LogID]=%n"
				,oItem.RegionID,oItem.TerritoryID,oItem.DCRDetail,oItem.Day,oItem.Month,oItem.Year,oItem.ApprovedDateTime,oItem.ApprovedBy, oItem.ID.ToInt32);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nDCRLateApprovalLogID)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("DELETE FROM [DCRLateApprovalLog] WHERE [LogID]=%n"
				, nDCRLateApprovalLogID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetDCRLateApprovalLog(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [DCRLateApprovalLog] WHERE LogID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetDCRLateApprovalLogs()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [DCRLateApprovalLog] ");
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}

        public int GetLogID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nID = 0;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SELECT MAX(LogID)+ 1 LogID FROM DCRLateApprovalLog");
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nID = 1;
                }
                else
                {
                    nID = Convert.ToInt32(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nID;
        }

        public int Insert(DCRLateApprovalLog oItem, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                int nLogID = GetLogID(oSqlConnection, oSqlTransaction);
                oItem.ID.SetID(nLogID);
                sSQL = SQL.MakeSQL("INSERT INTO [DCRLateApprovalLog](LogID, RegionID, TerritoryID, DCRDetail, Day, Month, Year, ApprovedDateTime, ApprovedBy) "
                + " VALUES(%n, %s, %s, %s, %n, %n, %n, %D, %s) "
                , oItem.ID.ToInt32, oItem.RegionID, oItem.TerritoryID, oItem.DCRDetail, oItem.Day, oItem.Month, oItem.Year, oItem.ApprovedDateTime, oItem.ApprovedBy);
                SqlDataAdapter InvAdapter = new SqlDataAdapter();
                SqlCommand InvCommand = new SqlCommand();
                InvCommand = new SqlCommand(sSQL, oSqlConnection);
                InvCommand.Transaction = oSqlTransaction;
                InvAdapter.InsertCommand = InvCommand;
                int i = InvCommand.ExecuteNonQuery();
                return i;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int Update(DCRLateApprovalLog oItem, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL("UPDATE [DCRLateApprovalLog] SET RegionID = %s, TerritoryID = %s, DCRDetail = %s, Day = %n, Month = %n, Year = %n, ApprovedDateTime = %D, ApprovedBy = %s WHERE [LogID]=%n"
                , oItem.RegionID, oItem.TerritoryID, oItem.DCRDetail, oItem.Day, oItem.Month, oItem.Year, oItem.ApprovedDateTime, oItem.ApprovedBy, oItem.ID.ToInt32);
                SqlDataAdapter InvAdapter = new SqlDataAdapter();
                SqlCommand InvCommand = new SqlCommand();
                InvCommand = new SqlCommand(sSQL, oSqlConnection);
                InvCommand.Transaction = oSqlTransaction;
                InvAdapter.UpdateCommand = InvCommand;
                int i = InvCommand.ExecuteNonQuery();
                return i;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
	}
}
