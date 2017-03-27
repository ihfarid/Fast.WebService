using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;
namespace FAST.BusinessLogic
{
	public partial class BLUserInfo
	{
		//public bool Validate(UserInfo oItem)
		//{
			//DLUserInfo oDL = new DLUserInfo();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.UserInfoName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.UserInfoName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
        public int SaveSFRegInfo(SFRegiInfo oSFInfoItem, UserInfo oItem)
        {
            int nAuthenticket = 0;
            DLUserInfo oDL = new DLUserInfo();
            DLSFRegiInfo oDLSFRegiInfo = new DLSFRegiInfo();
            //if (!Validate(oItem))
            //{
            //throw new Exception("UserInfo with the same Name already exist");
            //}
            try
            {
                DAAccess.BeginTran();
                if (oItem.IsNew)
                {
                    DataTable oTable = oDLSFRegiInfo.SaveSFInfoForReg(oSFInfoItem);
                    if (oTable.Rows.Count>0)
                    {
                        oDL.Insert(oItem);
                        nAuthenticket = 1;
                    }                    
                }
                else
                {
                    oDL.Update(oItem);
                }
                DAAccess.CommitTran();
            }
            catch (Exception e)
            {
                DAAccess.RollBackTran();
                throw new Exception(e.Message);
            }
            return nAuthenticket;
        }
		public void Save(UserInfo oItem)
		{
			DLUserInfo oDL = new DLUserInfo();
			//if (!Validate(oItem))
			//{
				//throw new Exception("UserInfo with the same Name already exist");
			//}
			try
			{
				DAAccess.BeginTran();
				if (oItem.IsNew)
				{
					oDL.Insert(oItem);
				}
				else
				{
					oDL.Update(oItem);
				}
				DAAccess.CommitTran();
			}
			catch (Exception e)
			{
				DAAccess.RollBackTran();
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nID)
		{
			DLUserInfo oDL = new DLUserInfo();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public bool IsUserExist(string sGDDBID)
        {
            DLUserInfo oDL = new DLUserInfo();
            try
            {
                return oDL.IsUserExist(sGDDBID);
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public UserInfo GetActiveUserInfoByGDDBID(string sGDDBID)
        {
            UserInfo oUserInfo = new UserInfo();
            DLUserInfo oDL = new DLUserInfo();
            IDataReader oReader;
            try
            {
                oReader = oDL.GetActiveUserInfoByGDDBID(sGDDBID);
                try
                {
                    if (oReader.Read())
                    {
                        oUserInfo = ReaderToObject(oReader);
                    }
                    oReader.Close();
                }
                catch (Exception ex)
                {
                    oReader.Close();
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oUserInfo;
        }

        public UserInfo GetActiveUserInfoByTerritoryID(string sTerritoryID)
        {
            UserInfo oUserInfo = new UserInfo();
            DLUserInfo oDL = new DLUserInfo();
            IDataReader oReader;
            try
            {
                oReader = oDL.GetActiveUserInfoByTerritoryID(sTerritoryID);
                try
                {
                    if (oReader.Read())
                    {
                        oUserInfo = ReaderToObject(oReader);
                    }
                    oReader.Close();
                }
                catch (Exception ex)
                {
                    oReader.Close();
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oUserInfo;
        }

        public int GetNoOfTargetDoctor(string sTerritoryID)
        {
            Int32 nNoOfTargetDoctor;
            DLUserInfo oDL = new DLUserInfo();
            try
            {
                nNoOfTargetDoctor = oDL.GetNoOfTargetDoctor(sTerritoryID);
                return nNoOfTargetDoctor;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public int GetNoOfTargetDoctor(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sTerritoryID)
        {
            int NoOfTargetDoctor;
            DLUserInfo oDL = new DLUserInfo();
            try
            {
                NoOfTargetDoctor = oDL.GetNoOfTargetDoctor(oSqlConnection, oSqlTransaction, sTerritoryID);
                return NoOfTargetDoctor;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public DataTable GetUserInfoByGDDBID(string sGDDBID, string sConnectionString)
        {
            DLUserInfo oDL = new DLUserInfo();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetUserInfoByGDDBID(sGDDBID, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public int UpdateRMUserInfo(string sGDDBID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nResult;
            DLUserInfo oDL = new DLUserInfo();
            try
            {
                nResult = oDL.UpdateRMUserInfo(sGDDBID, oSqlConnection, oSqlTransaction);
                return nResult;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public DataTable GetDCRInfo(int nDay, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            DataTable dt = new DataTable();
            DLUserInfo oDL = new DLUserInfo();
            try
            {
                dt = oDL.GetDCRInfo(nDay, oSqlConnection, oSqlTransaction);
                return dt;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public int Save(UserInfo oItem, SqlConnection myConnection, SqlTransaction myTransaction)
        {
            DLUserInfo oDL = new DLUserInfo();
            int i = 0;
            try
            {
                if (oItem.IsNew)
                {
                    i =  oDL.Insert(oItem, myConnection, myTransaction);
                }
                else
                {
                    i =  oDL.Update(oItem, myConnection, myTransaction);
                }
            }
            catch (Exception e)
            {
                i = 0;
                throw new Exception(e.Message);
            }
            return i;
        }

		//public bool IsDuplicate(string sUserInfoName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sUserInfoName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sUserInfoName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sUserInfoName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
