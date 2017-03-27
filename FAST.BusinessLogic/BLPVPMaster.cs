using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.BusinessLogic
{
	public partial class BLPVPMaster
	{
		//public bool Validate(PVPMaster oItem)
		//{
			//DLPVPMaster oDL = new DLPVPMaster();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.PVPMasterName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.PVPMasterName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(PVPMaster oItem)
		{
			DLPVPMaster oDL = new DLPVPMaster();
			//if (!Validate(oItem))
			//{
				//throw new Exception("PVPMaster with the same Name already exist");
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
			DLPVPMaster oDL = new DLPVPMaster();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public int GetTerritoryWiseMaxVersion(string sTerritoryID)
        {
            Int32 nMaxVersion;
            DLPVPMaster oDL = new DLPVPMaster();
            try
            {
                nMaxVersion = oDL.GetTerritoryWiseMaxVersion(sTerritoryID);
                return nMaxVersion;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public string GetRMGDDBID(string sTerritoryID)
        {
            string sRMGDDBID;
            DLPVPMaster oDL = new DLPVPMaster();
            try
            {
                sRMGDDBID = oDL.GetRMGDDBID(sTerritoryID);
                return sRMGDDBID;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public PVPMasters GetPVPMasterInfo(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nPreviousMonth, int nPreviousYear, int nNextMonth, int nNextYear,int nMaxVersion)
        {
            PVPMasters oPVPMasters;
            DLPVPMaster oDL = new DLPVPMaster();
            try
            {
                oPVPMasters = ReaderToObjects(oDL.GetPVPMasterInfo(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonth, nPreviousYear, nNextMonth, nNextYear, nMaxVersion));
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return oPVPMasters;
        }

        public DataTable GetPVPMasterInfo(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nPreviousMonth, int nPreviousYear, int nNextMonth, int nNextYear, int nMaxVersion, string sConnectionString)
        {
            DLPVPMaster oDL = new DLPVPMaster();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetPVPMasterInfo(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonth, nPreviousYear, nNextMonth, nNextYear, nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public PVPMasters GetPVPMasterInfoForRM(string sTerritoryID, int nMonth, int nYear, int nPreMonth, int nPreYear, int nMaxVersion)
        {
            PVPMasters oPVPMasters;
            DLPVPMaster oDL = new DLPVPMaster();
            try
            {
                oPVPMasters = ReaderToObjects(oDL.GetPVPMasterInfoForRM(sTerritoryID, nMonth, nYear, nPreMonth, nPreYear, nMaxVersion));
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return oPVPMasters;
        }

        public DataTable GetPVPMasterInfoForRM(string sTerritoryID, int nNextMonth, int nNextYear, int nCurrentMonth, int nCurrentYear, int nMaxVersion, string sConnectionString)
        {
            DLPVPMaster oDL = new DLPVPMaster();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetPVPMasterInfoForRM(sTerritoryID, nNextMonth, nNextYear, nCurrentMonth, nCurrentYear, nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public DataTable GetPVPMasterInfoByTerritoryID(string sTerritoryID, int nMonth, int nYear, string sConnectionString)
        {
            DLPVPMaster oDL = new DLPVPMaster();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetPVPMasterInfo(sTerritoryID, nMonth, nYear, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public int Save(PVPMaster oItem, SqlConnection myConnection, SqlTransaction myTransaction)
        {
            DLPVPMaster oDL = new DLPVPMaster();
            int i = 0;
            try
            {
                if (oItem.IsNew)
                {
                    i = oDL.Insert(oItem, myConnection, myTransaction);
                }
                else
                {
                    i = oDL.Update(oItem, myConnection, myTransaction);
                }
            }
            catch (Exception e)
            {
                i = 0;
                throw new Exception(e.Message);
            }
            return i;
        }
		//public bool IsDuplicate(string sPVPMasterName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sPVPMasterName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sPVPMasterName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sPVPMasterName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}


        public int GetUpdateTerritoryWisePVPMaster(string sTerritoryID, string sRMGDDBID, int nMonth, int nYear, int nVersion)
        {
            DLPVPMaster oDL = new DLPVPMaster();
            int nAuthenTicket = 0;
            try
            {
                nAuthenTicket = oDL.GetUpdateTerritoryWisePVPMaster(sTerritoryID, sRMGDDBID, nMonth, nYear, nVersion);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nAuthenTicket;
        }

        public int GetMaxPVPVersion(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sTerritoryID)
        {
            int nMaxPVPVersion;
            DLPVPMaster oDL = new DLPVPMaster();
            try
            {
                nMaxPVPVersion = oDL.GetMaxPVPVersion(oSqlConnection, oSqlTransaction, sTerritoryID);
                return nMaxPVPVersion;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public int GetMaxPVPVersion(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nMaxPVPVersion;
            DLPVPMaster oDL = new DLPVPMaster();
            try
            {
                nMaxPVPVersion = oDL.GetMaxPVPVersion(oSqlConnection, oSqlTransaction);
                return nMaxPVPVersion;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public bool IsDuplicate(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, int nMonth, int nYear, string sTerritoryID)
        {            
            DLPVPMaster oDL = new DLPVPMaster();
            try
            {
                return oDL.IsDuplicate(oSqlConnection, oSqlTransaction, nMonth, nYear, sTerritoryID);                
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public int InsertPVPCommandInfo(string sTerritoryID, int nStatus, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nResult;
            DLPVPMaster oDL = new DLPVPMaster();
            try
            {
                nResult = oDL.InsertPVPCommandInfo(sTerritoryID, nStatus, oSqlConnection, oSqlTransaction);
                return nResult;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }


		}
	}
