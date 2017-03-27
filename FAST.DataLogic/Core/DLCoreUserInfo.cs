using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core.DataAccess;
using System.Data.SqlClient;
namespace FAST.DataLogic
{
	public partial class DLUserInfo: DAAccess
	{
        public void Insert(UserInfo oItem)
        {
            string sSQL = "";
            try
            {
                oItem.ID.SetID(GeneratePrimaryKey("[UserInfo]", "UserID"));
                sSQL = SQL.MakeSQL("INSERT INTO [UserInfo](UserID, GDDBID, Version, CommandVersion, AppConfigVersion, DoctorVersion, DoctorReqVersion, DoctorLogVersion, RouteVersion, DegreeVersion, SpecialtyVersion, SalutationVersion, DistrictVersion, UpazillaVersion, LineSpeProductVersion, GimmickVersion, SampleVersion, HolidayVersion, BrandVersion, ReasonVersion, PVPVersion, PVPWorkingDayVersion, DCRVersion, AppVersion, NoOfTargetDoctor, EntryDate, LastUpdateDate, UserType, IsActive) "
                + " VALUES(%n, %s, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %d, %d, %n, %b) "
                , oItem.ID.ToInt32, oItem.GDDBID, oItem.Version, oItem.CommandVersion, oItem.AppConfigVersion, oItem.DoctorVersion, oItem.DoctorReqVersion, oItem.DoctorLogVersion, oItem.RouteVersion, oItem.DegreeVersion, oItem.SpecialtyVersion, oItem.SalutationVersion, oItem.DistrictVersion, oItem.UpazillaVersion, oItem.LineSpeProductVersion, oItem.GimmickVersion, oItem.SampleVersion, oItem.HolidayVersion, oItem.BrandVersion, oItem.ReasonVersion, oItem.PVPVersion, oItem.PVPWorkingDayVersion, oItem.DCRVersion, oItem.AppVersion, oItem.NoOfTargetDoctor, oItem.EntryDate, oItem.LastUpdateDate, oItem.UserType, oItem.IsActive);
                ExecuteNonQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Update(UserInfo oItem)
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL("UPDATE [UserInfo] SET GDDBID = %s, Version = %n, CommandVersion = %n, AppConfigVersion = %n, DoctorVersion = %n, DoctorReqVersion = %n, DoctorLogVersion = %n, RouteVersion = %n, DegreeVersion = %n, SpecialtyVersion = %n, SalutationVersion = %n, DistrictVersion = %n, UpazillaVersion = %n, LineSpeProductVersion = %n, GimmickVersion = %n, SampleVersion = %n, HolidayVersion = %n, BrandVersion = %n, ReasonVersion = %n, PVPVersion = %n, PVPWorkingDayVersion = %n, DCRVersion = %n, AppVersion = %n, NoOfTargetDoctor = %n, EntryDate = %d, LastUpdateDate = %d, UserType = %n, IsActive = %b WHERE [UserID]=%n"
                , oItem.GDDBID, oItem.Version, oItem.CommandVersion, oItem.AppConfigVersion, oItem.DoctorVersion, oItem.DoctorReqVersion, oItem.DoctorLogVersion, oItem.RouteVersion, oItem.DegreeVersion, oItem.SpecialtyVersion, oItem.SalutationVersion, oItem.DistrictVersion, oItem.UpazillaVersion, oItem.LineSpeProductVersion, oItem.GimmickVersion, oItem.SampleVersion, oItem.HolidayVersion, oItem.BrandVersion, oItem.ReasonVersion, oItem.PVPVersion, oItem.PVPWorkingDayVersion, oItem.DCRVersion, oItem.AppVersion, oItem.NoOfTargetDoctor, oItem.EntryDate, oItem.LastUpdateDate, oItem.UserType, oItem.IsActive, oItem.ID.ToInt32);
                ExecuteNonQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
		public void Delete(int nUserInfoID)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("DELETE FROM [UserInfo] WHERE [UserID]=%n"
				, nUserInfoID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetUserInfo(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [UserInfo] WHERE UserID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetUserInfos()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [UserInfo] ");
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}

        public int GetUserID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sGDDBID)
        {
            int nID = 0;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SElECT UserID FROM [UserInfo] WHERE [GDDBID]=%s", sGDDBID);
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

        public int GetActiveUserIDBYGDDBID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sGDDBID)
        {
            int nID = 0;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SElECT [UserID] FROM [UserInfo] WHERE [GDDBID]= %s AND IsActive = 1", sGDDBID);
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

        public int Insert(UserInfo oItem, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                int nUserID = GetUserID(oSqlConnection, oSqlTransaction);
                oItem.ID.SetID(nUserID);
                sSQL = SQL.MakeSQL(@"INSERT INTO [UserInfo](UserID, GDDBID, Version, CommandVersion, AppConfigVersion, DoctorVersion, DoctorReqVersion, DoctorLogVersion, RouteVersion, DegreeVersion, SpecialtyVersion, SalutationVersion, DistrictVersion, UpazillaVersion, LineSpeProductVersion, GimmickVersion, SampleVersion, HolidayVersion, BrandVersion, ReasonVersion, PVPVersion, PVPWorkingDayVersion, DCRVersion, AppVersion, NoOfTargetDoctor, EntryDate, LastUpdateDate, UserType, IsActive) "
                + " VALUES(%n, %s, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %D, %D, %n, %b) "
                , oItem.ID.ToInt32, oItem.GDDBID, oItem.Version, oItem.CommandVersion, oItem.AppConfigVersion, oItem.DoctorVersion, oItem.DoctorReqVersion, oItem.DoctorLogVersion, oItem.RouteVersion, oItem.DegreeVersion, oItem.SpecialtyVersion, oItem.SalutationVersion, oItem.DistrictVersion, oItem.UpazillaVersion, oItem.LineSpeProductVersion, oItem.GimmickVersion, oItem.SampleVersion, oItem.HolidayVersion, oItem.BrandVersion, oItem.ReasonVersion, oItem.PVPVersion, oItem.PVPWorkingDayVersion, oItem.DCRVersion, oItem.AppVersion, oItem.NoOfTargetDoctor, oItem.EntryDate, oItem.LastUpdateDate, oItem.UserType, oItem.IsActive);
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

        public int Update(UserInfo oItem, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL(@"UPDATE [UserInfo] SET GDDBID = %s, Version = %n, CommandVersion = %n, AppConfigVersion = %n, DoctorVersion = %n, DoctorReqVersion = %n, DoctorLogVersion = %n, RouteVersion = %n, DegreeVersion = %n, SpecialtyVersion = %n, SalutationVersion = %n, DistrictVersion = %n, UpazillaVersion = %n, LineSpeProductVersion = %n, GimmickVersion = %n, SampleVersion = %n, HolidayVersion = %n, BrandVersion = %n, ReasonVersion = %n, PVPVersion = %n, PVPWorkingDayVersion = %n, DCRVersion = %n, AppVersion = %n, NoOfTargetDoctor = %n, EntryDate = %D, LastUpdateDate = %D, UserType = %n, IsActive = %b WHERE [UserID]=%n"
                , oItem.GDDBID, oItem.Version, oItem.CommandVersion, oItem.AppConfigVersion, oItem.DoctorVersion, oItem.DoctorReqVersion, oItem.DoctorLogVersion, oItem.RouteVersion, oItem.DegreeVersion, oItem.SpecialtyVersion, oItem.SalutationVersion, oItem.DistrictVersion, oItem.UpazillaVersion, oItem.LineSpeProductVersion, oItem.GimmickVersion, oItem.SampleVersion, oItem.HolidayVersion, oItem.BrandVersion, oItem.ReasonVersion, oItem.PVPVersion, oItem.PVPWorkingDayVersion, oItem.DCRVersion, oItem.AppVersion, oItem.NoOfTargetDoctor, oItem.EntryDate, oItem.LastUpdateDate, oItem.UserType, oItem.IsActive, oItem.ID.ToInt32);
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

        public int GetUserID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nID = 0;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SElECT MAX(UserID)+ 1 AS UserID FROM UserInfo");
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
	}
}
