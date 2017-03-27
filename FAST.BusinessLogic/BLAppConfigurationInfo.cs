using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;

namespace FAST.BusinessLogic
{
	public partial class BLAppConfigurationInfo
	{
		//public bool Validate(AppConfigurationInfo oItem)
		//{
			//DLAppConfigurationInfo oDL = new DLAppConfigurationInfo();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.AppConfigurationInfoName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.AppConfigurationInfoName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(AppConfigurationInfo oItem)
		{
			DLAppConfigurationInfo oDL = new DLAppConfigurationInfo();
			//if (!Validate(oItem))
			//{
				//throw new Exception("AppConfigurationInfo with the same Name already exist");
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
			DLAppConfigurationInfo oDL = new DLAppConfigurationInfo();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public DataTable GetAppConfigInfo()
        {
            DLAppConfigurationInfo oDL = new DLAppConfigurationInfo();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetAppConfigInfo();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public DataTable GetAppConfigInfo(string sConnectionString)
        {
            DLAppConfigurationInfo oDL = new DLAppConfigurationInfo();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetAppConfigInfo(sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public DataTable GetAppConfigInfoForRM(string sTerritoryID, string sConnectionString)
        {
            DLAppConfigurationInfo oDL = new DLAppConfigurationInfo();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetAppConfigInfoForRM(sTerritoryID, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }


        public DataTable GetAppConfigInfo(string sTerritoryID, string sConnectionString)
        {
            DLAppConfigurationInfo oDL = new DLAppConfigurationInfo();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetAppConfigInfo(sTerritoryID, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }


        public AppConfigurationInfo GetAppConfigurationInfo()
        {
            AppConfigurationInfo oAppConfigurationInfo = new AppConfigurationInfo();
            DLAppConfigurationInfo oDL = new DLAppConfigurationInfo();
            IDataReader oReader;
            try
            {
                oReader = oDL.GetAppConfigurationInfo();
                if (oReader.Read())
                {
                    oAppConfigurationInfo = ReaderToObject(oReader);
                }
                oReader.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oAppConfigurationInfo;
        }

        public DataTable GetAppConfiguration(string sTerritoryID, string sConnectionString)
        {
            DLAppConfigurationInfo oDL = new DLAppConfigurationInfo();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetAppConfigurationInfo(sTerritoryID, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }
		//public bool IsDuplicate(string sAppConfigurationInfoName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sAppConfigurationInfoName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sAppConfigurationInfoName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sAppConfigurationInfoName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
