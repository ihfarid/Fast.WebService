using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.BusinessLogic
{
	public partial class BLAppVersionInfo
	{
		//public bool Validate(AppVersionInfo oItem)
		//{
			//DLAppVersionInfo oDL = new DLAppVersionInfo();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.AppVersionInfoName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.AppVersionInfoName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(AppVersionInfo oItem)
		{
			DLAppVersionInfo oDL = new DLAppVersionInfo();
			//if (!Validate(oItem))
			//{
				//throw new Exception("AppVersionInfo with the same Name already exist");
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
			DLAppVersionInfo oDL = new DLAppVersionInfo();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public string GetAppUpdatedVersionURL()
        {
            string sAppURL;
            DLAppVersionInfo oDL = new DLAppVersionInfo();
            try
            {
                sAppURL = oDL.GetAppUpdatedVersionURL();
                return sAppURL;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public string GetAppUpdatedVersionURL(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sAppURL;
            DLAppVersionInfo oDL = new DLAppVersionInfo();
            try
            {
                sAppURL = oDL.GetAppUpdatedVersionURL(oSqlConnection, oSqlTransaction);
                return sAppURL;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public string GetRMAppUpdatedVersionURL()
        {
            string sAppURL;
            DLAppVersionInfo oDL = new DLAppVersionInfo();
            try
            {
                sAppURL = oDL.GetRMAppUpdatedVersionURL();
                return sAppURL;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public string GetAppUpdatedVersionURLForRM(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sAppURL;
            DLAppVersionInfo oDL = new DLAppVersionInfo();
            try
            {
                sAppURL = oDL.GetAppUpdatedVersionURLForRM(oSqlConnection, oSqlTransaction);
                return sAppURL;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }
		//public bool IsDuplicate(string sAppVersionInfoName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sAppVersionInfoName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sAppVersionInfoName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sAppVersionInfoName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
