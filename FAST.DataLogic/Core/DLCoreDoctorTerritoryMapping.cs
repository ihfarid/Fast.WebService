using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
	public partial class DLDoctorTerritoryMapping: DAAccess
	{
		public void Insert(DoctorTerritoryMapping oItem)
		{
			string sSQL = "";
			try
			{
				oItem.ID.SetID(GeneratePrimaryKey("[DoctorTerritoryMapping]", "TerrWiseDocID"));
                sSQL = SQL.MakeSQL("INSERT INTO [DoctorTerritoryMapping](TerrWiseDocID, DoctorID, Code, TerritoryID, DocTypeID, Address, Speciality, Degree, SwajanStatus, ProfileID, Prod1, Prod2, Prod3, Prod4, Prod5, Prod6, Prod7, Prod8, CallFre, RouteID, SessionID, CreateDatetime, ModifyDatetime, Status, Version, Action) "
                + " VALUES(%n, %n, %s, %s, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %D, %D, %n, %n, %n) "
                , oItem.ID.ToInt32, oItem.DoctorID, oItem.Code, oItem.TerritoryID, oItem.DocTypeID, oItem.Address, oItem.Speciality, oItem.Degree, oItem.SwajanStatus, oItem.ProfileID, oItem.Prod1, oItem.Prod2, oItem.Prod3, oItem.Prod4, oItem.Prod5, oItem.Prod6, oItem.Prod7, oItem.Prod8, oItem.CallFre, oItem.RouteID, oItem.SessionID, oItem.CreateDatetime, oItem.ModifyDatetime, oItem.Status, oItem.Version, oItem.Action);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(DoctorTerritoryMapping oItem)
		{
			string sSQL = "";
			try
			{
                sSQL = SQL.MakeSQL("UPDATE [DoctorTerritoryMapping] SET DoctorID = %n, Code = %s, TerritoryID = %s, DocTypeID = %n, Address= %n, Speciality= %n, Degree= %n, SwajanStatus = %n, ProfileID = %n, Prod1 = %n, Prod2 = %n, Prod3 = %n, Prod4 = %n, Prod5 = %n, Prod6 = %n, Prod7 = %n, Prod8 = %n, CallFre = %n, RouteID = %n, SessionID = %n, CreateDatetime = %D, ModifyDatetime = %D, Status = %n, Version = %n, Action = %n WHERE [TerrWiseDocID]=%n"
                , oItem.DoctorID, oItem.Code, oItem.TerritoryID, oItem.DocTypeID, oItem.Address, oItem.Speciality, oItem.Degree, oItem.SwajanStatus, oItem.ProfileID, oItem.Prod1, oItem.Prod2, oItem.Prod3, oItem.Prod4, oItem.Prod5, oItem.Prod6, oItem.Prod7, oItem.Prod8, oItem.CallFre, oItem.RouteID, oItem.SessionID, oItem.CreateDatetime, oItem.ModifyDatetime, oItem.Status, oItem.Version, oItem.Action, oItem.ID.ToInt32);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nDoctorTerritoryMappingID)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("DELETE FROM [DoctorTerritoryMapping] WHERE [TerrWiseDocID]=%n"
				, nDoctorTerritoryMappingID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetDoctorTerritoryMapping(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [DoctorTerritoryMapping] WHERE TerrWiseDocID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetDoctorTerritoryMappings()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [DoctorTerritoryMapping] ");
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}

        public int GetTerrWiseDocID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nID = 0;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SElECT MAX(TerrWiseDocID)+ 1 PvpID FROM DoctorTerritoryMapping");
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

        public int Insert(DoctorTerritoryMapping oItem, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                int nTerrWiseDocID = GetTerrWiseDocID(oSqlConnection, oSqlTransaction);
                oItem.ID.SetID(nTerrWiseDocID);
                sSQL = SQL.MakeSQL("INSERT INTO [DoctorTerritoryMapping](TerrWiseDocID, DoctorID, Code, TerritoryID, DocTypeID, Address, Speciality, Degree, SwajanStatus, ProfileID, Prod1, Prod2, Prod3, Prod4, Prod5, Prod6, Prod7, Prod8, CallFre, RouteID, SessionID, CreateDatetime, ModifyDatetime, Status, Version, Action) "
                + " VALUES(%n, %n, %s, %s, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %D, %D, %n, %n, %n) "
                , oItem.ID.ToInt32, oItem.DoctorID, oItem.Code, oItem.TerritoryID, oItem.DocTypeID, oItem.Address, oItem.Speciality, oItem.Degree, oItem.SwajanStatus, oItem.ProfileID, oItem.Prod1, oItem.Prod2, oItem.Prod3, oItem.Prod4, oItem.Prod5, oItem.Prod6, oItem.Prod7, oItem.Prod8, oItem.CallFre, oItem.RouteID, oItem.SessionID, oItem.CreateDatetime, oItem.ModifyDatetime, oItem.Status, oItem.Version, oItem.Action);
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

        public int Update(DoctorTerritoryMapping oItem, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL("UPDATE [DoctorTerritoryMapping] SET DoctorID = %n, Code = %s, TerritoryID = %s, DocTypeID = %n, Address= %n, Speciality= %n, Degree= %n, SwajanStatus = %n, ProfileID = %n, Prod1 = %n, Prod2 = %n, Prod3 = %n, Prod4 = %n, Prod5 = %n, Prod6 = %n, Prod7 = %n, Prod8 = %n, CallFre = %n, RouteID = %n, SessionID = %n, CreateDatetime = %D, ModifyDatetime = %D, Status = %n, Version = %n, Action = %n WHERE [TerrWiseDocID]=%n"
                , oItem.DoctorID, oItem.Code, oItem.TerritoryID, oItem.DocTypeID, oItem.Address, oItem.Speciality, oItem.Degree, oItem.SwajanStatus, oItem.ProfileID, oItem.Prod1, oItem.Prod2, oItem.Prod3, oItem.Prod4, oItem.Prod5, oItem.Prod6, oItem.Prod7, oItem.Prod8, oItem.CallFre, oItem.RouteID, oItem.SessionID, oItem.CreateDatetime, oItem.ModifyDatetime, oItem.Status, oItem.Version, oItem.Action, oItem.ID.ToInt32);
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

        public int UpdateDoctorStatus(int DoctorID, SqlConnection myConnection, SqlTransaction myTransaction)
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL("UPDATE [Doctor] SET Status = %n WHERE [ID]=%n",2, DoctorID);
                SqlDataAdapter InvAdapter = new SqlDataAdapter();
                SqlCommand InvCommand = new SqlCommand();
                InvCommand = new SqlCommand(sSQL, myConnection);
                InvCommand.Transaction = myTransaction;
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
