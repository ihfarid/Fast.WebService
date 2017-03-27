using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using System.Data.SqlClient;

namespace FAST.BusinessLogic
{
	public partial class BLUserInfo
	{
        private UserInfo ReaderToObject(IDataReader oReader)
        {
            UserInfo oItem = new UserInfo();
            oItem.ID.SetID(oReader["UserID"]);
            oItem.GDDBID = oReader["GDDBID"].ToString();
            oItem.Version = Convert.ToInt32(oReader["Version"]);
            oItem.CommandVersion = Convert.ToInt32(oReader["CommandVersion"]);
            oItem.AppConfigVersion = Convert.ToInt32(oReader["AppConfigVersion"]);
            oItem.DoctorVersion = Convert.ToInt32(oReader["DoctorVersion"]);
            oItem.DoctorReqVersion = Convert.ToInt32(oReader["DoctorReqVersion"]);
            oItem.DoctorLogVersion = Convert.ToInt32(oReader["DoctorLogVersion"]);
            oItem.RouteVersion = Convert.ToInt32(oReader["RouteVersion"]);
            oItem.DegreeVersion = Convert.ToInt32(oReader["DegreeVersion"]);
            oItem.SpecialtyVersion = Convert.ToInt32(oReader["SpecialtyVersion"]);
            oItem.SalutationVersion = Convert.ToInt32(oReader["SalutationVersion"]);
            oItem.DistrictVersion = Convert.ToInt32(oReader["DistrictVersion"]);
            oItem.UpazillaVersion = Convert.ToInt32(oReader["UpazillaVersion"]);
            oItem.LineSpeProductVersion = Convert.ToInt32(oReader["LineSpeProductVersion"]);
            oItem.GimmickVersion = Convert.ToInt32(oReader["GimmickVersion"]);
            oItem.SampleVersion = Convert.ToInt32(oReader["SampleVersion"]);
            oItem.HolidayVersion = Convert.ToInt32(oReader["HolidayVersion"]);
            oItem.BrandVersion = Convert.ToInt32(oReader["BrandVersion"]);
            oItem.ReasonVersion = Convert.ToInt32(oReader["ReasonVersion"]);
            oItem.PVPVersion = Convert.ToInt32(oReader["PVPVersion"]);
            oItem.PVPWorkingDayVersion = Convert.ToInt32(oReader["PVPWorkingDayVersion"]);
            oItem.DCRVersion = Convert.ToInt32(oReader["DCRVersion"]);
            oItem.AppVersion = Convert.ToInt32(oReader["AppVersion"]);
            oItem.NoOfTargetDoctor = Convert.ToInt32(oReader["NoOfTargetDoctor"]);
            oItem.EntryDate = Convert.ToDateTime(oReader["EntryDate"]);
            oItem.LastUpdateDate = Convert.ToDateTime(oReader["LastUpdateDate"]);
            oItem.UserType = Convert.ToInt32(oReader["UserType"]);
            oItem.IsActive = Convert.ToBoolean(oReader["IsActive"]);
            return oItem;
        }
		
		private UserInfos ReaderToObjects(IDataReader oReader)
		{
			UserInfos oItems;
			UserInfo oItem;
			oItems = new UserInfos();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
			return oItems;
		}
		public UserInfos GetUserInfos()
		{
			UserInfos oUserInfos;
			DLUserInfo oDL = new DLUserInfo();
			try
			{
				oUserInfos = ReaderToObjects(oDL.GetUserInfos());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oUserInfos;
		}
		public UserInfo GetUserInfo(int nID)
		{
			UserInfo oUserInfo = new UserInfo();
			DLUserInfo oDL = new DLUserInfo();
			IDataReader oReader;
			try
			{
				oReader = oDL.GetUserInfo(nID);
				if (oReader.Read())
				{
					oUserInfo = ReaderToObject(oReader);
				}
				oReader.Close();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oUserInfo;
		}

        public int GetUserID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sGDDBID)
        {
            int nUserID;
            DLUserInfo oDL = new DLUserInfo();
            try
            {
                nUserID = oDL.GetUserID(oSqlConnection, oSqlTransaction, sGDDBID);
                return nUserID;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public int GetActiveUserIDBYGDDBID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sGDDBID)
        {
            int nUserID;
            DLUserInfo oDL = new DLUserInfo();
            try
            {
                nUserID = oDL.GetActiveUserIDBYGDDBID(oSqlConnection, oSqlTransaction, sGDDBID);
                return nUserID;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public UserInfo GetUserInfo(string sGDDBID, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            UserInfo oItem = new UserInfo();
            try
            {
                oTable = GetUserInfoByGDDBID(sGDDBID, sConnectionString);

                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem.ID.SetID(oRow["UserID"]);
                    oItem.GDDBID = oRow["GDDBID"].ToString();
                    oItem.Version = Convert.ToInt32(oRow["Version"]);
                    oItem.CommandVersion = Convert.ToInt32(oRow["CommandVersion"]);
                    oItem.AppConfigVersion = Convert.ToInt32(oRow["AppConfigVersion"]);
                    oItem.DoctorVersion = Convert.ToInt32(oRow["DoctorVersion"]);
                    oItem.DoctorReqVersion = Convert.ToInt32(oRow["DoctorReqVersion"]);
                    oItem.DoctorLogVersion = Convert.ToInt32(oRow["DoctorLogVersion"]);
                    oItem.RouteVersion = Convert.ToInt32(oRow["RouteVersion"]);
                    oItem.DegreeVersion = Convert.ToInt32(oRow["DegreeVersion"]);
                    oItem.SpecialtyVersion = Convert.ToInt32(oRow["SpecialtyVersion"]);
                    oItem.SalutationVersion = Convert.ToInt32(oRow["SalutationVersion"]);
                    oItem.DistrictVersion = Convert.ToInt32(oRow["DistrictVersion"]);
                    oItem.UpazillaVersion = Convert.ToInt32(oRow["UpazillaVersion"]);
                    oItem.LineSpeProductVersion = Convert.ToInt32(oRow["LineSpeProductVersion"]);
                    oItem.GimmickVersion = Convert.ToInt32(oRow["GimmickVersion"]);
                    oItem.SampleVersion = Convert.ToInt32(oRow["SampleVersion"]);
                    oItem.HolidayVersion = Convert.ToInt32(oRow["HolidayVersion"]);
                    oItem.BrandVersion = Convert.ToInt32(oRow["BrandVersion"]);
                    oItem.ReasonVersion = Convert.ToInt32(oRow["ReasonVersion"]);
                    oItem.PVPVersion = Convert.ToInt32(oRow["PVPVersion"]);
                    oItem.PVPWorkingDayVersion = Convert.ToInt32(oRow["PVPWorkingDayVersion"]);
                    oItem.DCRVersion = Convert.ToInt32(oRow["DCRVersion"]);
                    oItem.AppVersion = Convert.ToInt32(oRow["AppVersion"]);
                    oItem.NoOfTargetDoctor = Convert.ToInt32(oRow["NoOfTargetDoctor"]);
                    oItem.EntryDate = Convert.ToDateTime(oRow["EntryDate"]);
                    oItem.LastUpdateDate = Convert.ToDateTime(oRow["LastUpdateDate"]);
                    oItem.UserType = Convert.ToInt32(oRow["UserType"]);
                    oItem.IsActive = Convert.ToBoolean(oRow["IsActive"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }       
	}
}
