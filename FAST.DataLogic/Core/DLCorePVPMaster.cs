using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
	public partial class DLPVPMaster: DAAccess
	{
		public void Insert(PVPMaster oItem)
		{
			string sSQL = "";
			try
			{
				oItem.ID.SetID(GeneratePrimaryKey("[PVPMaster]", "PvpID"));
				sSQL = SQL.MakeSQL("INSERT INTO [PVPMaster](PvpID, TerritoryID, Month, Year, Status, SubmitDate, ApprovedDate, SubmittedBy, ApprovedBy, NoOfPlannedDay, Version, Action) "
				+ " VALUES(%n, %s, %n, %n, %n, %D, %D, %s, %s, %n, %n, %n) "
				, oItem.ID.ToInt32, oItem.TerritoryID,oItem.Month,oItem.Year,oItem.Status,oItem.SubmitDate,oItem.ApprovedDate,oItem.SubmittedBy,oItem.ApprovedBy,oItem.NoOfPlannedDay,oItem.Version,oItem.Action);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(PVPMaster oItem)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("UPDATE [PVPMaster] SET TerritoryID = %s, Month = %n, Year = %n, Status = %n, SubmitDate = %D, ApprovedDate = %D, SubmittedBy = %s, ApprovedBy = %s, NoOfPlannedDay = %n, Version = %n, Action = %n WHERE [PvpID]=%n"
				,oItem.TerritoryID,oItem.Month,oItem.Year,oItem.Status,oItem.SubmitDate,oItem.ApprovedDate,oItem.SubmittedBy,oItem.ApprovedBy,oItem.NoOfPlannedDay,oItem.Version,oItem.Action, oItem.ID.ToInt32);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nPVPMasterID)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("DELETE FROM [PVPMaster] WHERE [PvpID]=%n"
				, nPVPMasterID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetPVPMaster(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [PVPMaster] WHERE PvpID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetPVPMasters()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [PVPMaster] ");
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}

        public int GetPvpID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nID = 0;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SElECT MAX(PvpID)+ 1 PvpID FROM PVPMaster");
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

        public int Insert(PVPMaster oItem, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                int nPvpID = GetPvpID(oSqlConnection, oSqlTransaction);
                oItem.ID.SetID(nPvpID);
                sSQL = SQL.MakeSQL("INSERT INTO [PVPMaster](PvpID, TerritoryID, Month, Year, Status, SubmitDate, ApprovedDate, SubmittedBy, ApprovedBy, NoOfPlannedDay, Version, Action) "
                + " VALUES(%n, %s, %n, %n, %n, %D, %D, %s, %s, %n, %n, %n) "
                , oItem.ID.ToInt32, oItem.TerritoryID, oItem.Month, oItem.Year, oItem.Status, oItem.SubmitDate, oItem.ApprovedDate, oItem.SubmittedBy, oItem.ApprovedBy, oItem.NoOfPlannedDay, oItem.Version, oItem.Action);			
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

        public int Update(PVPMaster oItem, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL("UPDATE [PVPMaster] SET TerritoryID = %s, Month = %n, Year = %n, Status = %n, SubmitDate = %D, ApprovedDate = %D, SubmittedBy = %s, ApprovedBy = %s, NoOfPlannedDay = %n, Version = %n, Action = %n WHERE [PvpID]=%n"
                , oItem.TerritoryID, oItem.Month, oItem.Year, oItem.Status, oItem.SubmitDate, oItem.ApprovedDate, oItem.SubmittedBy, oItem.ApprovedBy, oItem.NoOfPlannedDay, oItem.Version, oItem.Action, oItem.ID.ToInt32);				
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
