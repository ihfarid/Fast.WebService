using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
	public partial class DLDoctorLog: DAAccess
	{
		public void Insert(DoctorLog oItem)
		{
			string sSQL = "";
			try
			{
				oItem.ID.SetID(GeneratePrimaryKey("[DoctorLog]", "DoctorLogID"));
                sSQL = SQL.MakeSQL("INSERT INTO [DoctorLog](DoctorLogID, DoctorUpdateReqID, DoctorTerritoryMappingID, DocID, TerritoryID, TransferReason, Status, Type, CreationDate, CreatedBy, ModifiedDateRM, ModifiedByRM, ModifiedDateSFE, ModifiedBySFE, Action, Version) "
                + " VALUES(%n, %n, %n, %n, %s, %s, %n, %n, %D, %n, %D, %n, %D, %n, %n, %n) "
                , oItem.ID.ToInt32, oItem.DoctorUpdateReqID, oItem.DoctorTerritoryMappingID, oItem.DocID, oItem.TerritoryID, oItem.TransferReason, oItem.Status, oItem.Type, oItem.CreationDate, oItem.CreatedBy, oItem.ModifiedDateRM, oItem.ModifiedByRM, oItem.ModifiedDateSFE, oItem.ModifiedBySFE, oItem.Action, oItem.Version);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(DoctorLog oItem)
		{
			string sSQL = "";
			try
			{
                sSQL = SQL.MakeSQL("UPDATE [DoctorLog] SET DoctorUpdateReqID = %n, DoctorTerritoryMappingID = %n, DocID = %n, TerritoryID = %s, TransferReason = %s, Status = %n, Type = %n, CreationDate = %D, CreatedBy = %n, ModifiedDateRM = %D, ModifiedByRM = %n, ModifiedDateSFE = %D, ModifiedBySFE = %n, Action = %n, Version = %n WHERE [DoctorLogID]=%n"
                , oItem.DoctorUpdateReqID, oItem.DoctorTerritoryMappingID, oItem.DocID, oItem.TerritoryID, oItem.TransferReason, oItem.Status, oItem.Type, oItem.CreationDate, oItem.CreatedBy, oItem.ModifiedDateRM, oItem.ModifiedByRM, oItem.ModifiedDateSFE, oItem.ModifiedBySFE, oItem.Action, oItem.Version, oItem.ID.ToInt32);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nDoctorLogID)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("DELETE FROM [DoctorLog] WHERE [DoctorLogID]=%n"
				, nDoctorLogID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetDoctorLog(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [DoctorLog] WHERE DoctorLogID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetDoctorLogs()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [DoctorLog] ");
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}

        public int GetDoctorLogID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nID = 0;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SElECT MAX(DoctorLogID)+ 1 PvpID FROM DoctorLog");
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

        public int Insert(DoctorLog oItem, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                int nDoctorLogID = GetDoctorLogID(oSqlConnection, oSqlTransaction);
                //oItem.ID.SetID(nDoctorLogID);
                sSQL = SQL.MakeSQL("INSERT INTO [DoctorLog](DoctorLogID, DoctorUpdateReqID, DoctorTerritoryMappingID, DocID, TerritoryID, TransferReason, Status, Type, CreationDate, CreatedBy, ModifiedDateRM, ModifiedByRM, ModifiedDateSFE, ModifiedBySFE, Action, Version) "
                + " VALUES(%n, %n, %n, %n, %s, %s, %n, %n, %D, %n, %D, %n, %D, %n, %n, %n) "
                , oItem.ID.ToInt32, oItem.DoctorUpdateReqID, oItem.DoctorTerritoryMappingID, oItem.DocID, oItem.TerritoryID, oItem.TransferReason, oItem.Status, oItem.Type, oItem.CreationDate, oItem.CreatedBy, oItem.ModifiedDateRM, oItem.ModifiedByRM, oItem.ModifiedDateSFE, oItem.ModifiedBySFE, oItem.Action, oItem.Version);
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

        public int Update(DoctorLog oItem, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL("UPDATE [DoctorLog] SET DoctorUpdateReqID = %n, DoctorTerritoryMappingID = %n, DocID = %n, TerritoryID = %s, TransferReason = %s, Status = %n, Type = %n, CreationDate = %D, CreatedBy = %n, ModifiedDateRM = %D, ModifiedByRM = %n, ModifiedDateSFE = %D, ModifiedBySFE = %n, Action = %n, Version = %n WHERE [DoctorLogID]=%n"
                , oItem.DoctorUpdateReqID, oItem.DoctorTerritoryMappingID, oItem.DocID, oItem.TerritoryID, oItem.TransferReason, oItem.Status, oItem.Type, oItem.CreationDate, oItem.CreatedBy, oItem.ModifiedDateRM, oItem.ModifiedByRM, oItem.ModifiedDateSFE, oItem.ModifiedBySFE, oItem.Action, oItem.Version, oItem.ID.ToInt32);
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
