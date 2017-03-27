using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
	public partial class DLPVPDetail: DAAccess
	{
		public void Insert(PVPDetail oItem)
		{
			string sSQL = "";
			try
			{
				oItem.ID.SetID(GeneratePrimaryKey("[PVPDetail]", "DetailID"));
                sSQL = SQL.MakeSQL("INSERT INTO [PVPDetail](DetailID, PvpID, DoctorID, TerritoryID, Day, Month, Year, Brand1, Brand2, Brand3, Brand4, Brand5, Brand6,Brand7, Brand8, Session, IsHoliday, DoctorProfile, CreatedBy, CreationDate) "
                + " VALUES(%n, %n, %n, %s, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %s, %b, %s, %s, %D) "
                , oItem.ID.ToInt32, oItem.PvpID, oItem.DoctorID, oItem.TerritoryID, oItem.Day, oItem.Month, oItem.Year, oItem.Brand1, oItem.Brand2, oItem.Brand3, oItem.Brand4, oItem.Brand5, oItem.Brand6, oItem.Brand7, oItem.Brand8, oItem.Session, oItem.IsHoliday, oItem.DoctorProfile, oItem.CreatedBy, oItem.CreationDate);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(PVPDetail oItem)
		{
			string sSQL = "";
			try
			{
                sSQL = SQL.MakeSQL("UPDATE [PVPDetail] SET PvpID = %n, DoctorID = %n, TerritoryID = %s, Day = %n, Month = %n, Year = %n, Brand1 = %n, Brand2 = %n, Brand3 = %n, Brand4 = %n, Brand5 = %n, Brand6 = %n,Brand7 = %n,Brand8 = %n, Session = %s, IsHoliday = %b, DoctorProfile = %s, CreatedBy = %s, CreationDate = %D WHERE [DetailID]=%n"
                , oItem.PvpID, oItem.DoctorID, oItem.TerritoryID, oItem.Day, oItem.Month, oItem.Year, oItem.Brand1, oItem.Brand2, oItem.Brand3, oItem.Brand4, oItem.Brand5, oItem.Brand6, oItem.Brand7, oItem.Brand8, oItem.Session, oItem.IsHoliday, oItem.DoctorProfile, oItem.CreatedBy, oItem.CreationDate, oItem.ID.ToInt32);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nPVPDetailID)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("DELETE FROM [PVPDetail] WHERE [DetailID]=%n"
				, nPVPDetailID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetPVPDetail(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [PVPDetail] WHERE DetailID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetPVPDetails()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [PVPDetail] ");
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}

        public int GetPvpDetailID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nID = 0;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SElECT MAX(DetailID)+ 1 DetailID FROM PVPDetail");
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

        public int Insert(PVPDetail oItem, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                int nPvpID = GetPvpDetailID(oSqlConnection, oSqlTransaction);
                oItem.ID.SetID(nPvpID);
                sSQL = SQL.MakeSQL("INSERT INTO [PVPDetail](DetailID, PvpID, DoctorID, TerritoryID, Day, Month, Year, Brand1, Brand2, Brand3, Brand4, Brand5, Brand6,Brand7, Brand8, Session, IsHoliday, DoctorProfile, CreatedBy, CreationDate) "
                 + " VALUES(%n, %n, %n, %s, %n, %n, %n, %n, %n, %n, %n,%n, %n, %n, %n, %s, %b, %s, %s, %D) "
                 , oItem.ID.ToInt32, oItem.PvpID, oItem.DoctorID, oItem.TerritoryID, oItem.Day, oItem.Month, oItem.Year, oItem.Brand1, oItem.Brand2, oItem.Brand3, oItem.Brand4, oItem.Brand5, oItem.Brand6, oItem.Brand7, oItem.Brand8, oItem.Session, oItem.IsHoliday, oItem.DoctorProfile, oItem.CreatedBy, oItem.CreationDate);
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

        public int Update(PVPDetail oItem, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL("UPDATE [PVPDetail] SET PvpID = %n, DoctorID = %n, TerritoryID = %s, Day = %n, Month = %n, Year = %n, Brand1 = %n, Brand2 = %n, Brand3 = %n, Brand4 = %n, Brand5 = %n, Brand6 = %n,Brand7 = %n,Brand8 = %n, Session = %s, IsHoliday = %b, DoctorProfile = %s, CreatedBy = %s, CreationDate = %D WHERE [DetailID]=%n"
                , oItem.PvpID, oItem.DoctorID, oItem.TerritoryID, oItem.Day, oItem.Month, oItem.Year, oItem.Brand1, oItem.Brand2, oItem.Brand3, oItem.Brand4, oItem.Brand5, oItem.Brand6, oItem.Brand7, oItem.Brand8, oItem.Session, oItem.IsHoliday, oItem.DoctorProfile, oItem.CreatedBy, oItem.CreationDate, oItem.ID.ToInt32);
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

        public int Delete(int nPVPID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL("DELETE FROM [PVPDetail] WHERE [PvpID]=%n", nPVPID);
                SqlDataAdapter InvAdapter = new SqlDataAdapter();
                SqlCommand InvCommand = new SqlCommand();
                InvCommand = new SqlCommand(sSQL, oSqlConnection);
                InvCommand.Transaction = oSqlTransaction;
                InvAdapter.DeleteCommand = InvCommand;
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
