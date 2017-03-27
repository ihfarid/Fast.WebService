using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
	public partial class DLPVPExceptionLog: DAAccess
	{
		public void Insert(PVPExceptionLog oItem)
		{
			string sSQL = "";
			try
			{
				oItem.ID.SetID(GeneratePrimaryKey("[PVPExceptionLog]", "ExceptionID"));
				sSQL = SQL.MakeSQL("INSERT INTO [PVPExceptionLog](ExceptionID, TerritoryID, GDDBID, PVPDetail, NoOfPlannedDay, ExceptionDetail, ExceptionDateTime) "
				+ " VALUES(%n, %s, %s, %s, %n, %s, %D) "
				, oItem.ID.ToInt32, oItem.TerritoryID,oItem.GDDBID,oItem.PVPDetail,oItem.NoOfPlannedDay,oItem.ExceptionDetail,oItem.ExceptionDateTime);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(PVPExceptionLog oItem)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("UPDATE [PVPExceptionLog] SET TerritoryID = %s, GDDBID = %s, PVPDetail = %s, NoOfPlannedDay = %n, ExceptionDetail = %s, ExceptionDateTime = %d WHERE [ExceptionID]=%n"
				,oItem.TerritoryID,oItem.GDDBID,oItem.PVPDetail,oItem.NoOfPlannedDay,oItem.ExceptionDetail,oItem.ExceptionDateTime, oItem.ID.ToInt32);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nPVPExceptionLogID)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("DELETE FROM [PVPExceptionLog] WHERE [ExceptionID]=%n"
				, nPVPExceptionLogID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetPVPExceptionLog(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [PVPExceptionLog] WHERE ExceptionID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetPVPExceptionLogs()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [PVPExceptionLog] ");
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}

        public int GetExceptionID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nID = 0;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SElECT MAX(ExceptionID)+ 1 ExceptionID FROM PVPExceptionLog");
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

        public int Insert(PVPExceptionLog oItem, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                int nExceptionID = GetExceptionID(oSqlConnection, oSqlTransaction);
                oItem.ID.SetID(nExceptionID);
                sSQL = SQL.MakeSQL("INSERT INTO [PVPExceptionLog](ExceptionID, TerritoryID, GDDBID, PVPDetail, NoOfPlannedDay, ExceptionDetail, ExceptionDateTime) "
                 + " VALUES(%n, %s, %s, %s, %n, %s, %D) "
                 , oItem.ID.ToInt32, oItem.TerritoryID, oItem.GDDBID, oItem.PVPDetail, oItem.NoOfPlannedDay, oItem.ExceptionDetail, oItem.ExceptionDateTime);
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

        public int Update(PVPExceptionLog oItem, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL("UPDATE [PVPExceptionLog] SET TerritoryID = %s, GDDBID = %s, PVPDetail = %s, NoOfPlannedDay = %n, ExceptionDetail = %s, ExceptionDateTime = %D WHERE [ExceptionID]=%n"
                , oItem.TerritoryID, oItem.GDDBID, oItem.PVPDetail, oItem.NoOfPlannedDay, oItem.ExceptionDetail, oItem.ExceptionDateTime, oItem.ID.ToInt32);
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
