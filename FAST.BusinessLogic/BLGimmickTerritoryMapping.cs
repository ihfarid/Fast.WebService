using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.BusinessLogic
{
	public partial class BLGimmickTerritoryMapping
	{
		//public bool Validate(GimmickTerritoryMapping oItem)
		//{
			//DLGimmickTerritoryMapping oDL = new DLGimmickTerritoryMapping();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.GimmickTerritoryMappingName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.GimmickTerritoryMappingName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(GimmickTerritoryMapping oItem)
		{
			DLGimmickTerritoryMapping oDL = new DLGimmickTerritoryMapping();
			//if (!Validate(oItem))
			//{
				//throw new Exception("GimmickTerritoryMapping with the same Name already exist");
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
			DLGimmickTerritoryMapping oDL = new DLGimmickTerritoryMapping();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public GimmickTerritoryMappings GetGimmickTerritoryMapping(String sTerritoryID, int nMaxVersion)
        {
            GimmickTerritoryMappings oGimmickTerritoryMappings;
            DLGimmickTerritoryMapping oDL = new DLGimmickTerritoryMapping();
            try
            {
                oGimmickTerritoryMappings = ReaderToObjects(oDL.GetGimmickTerritoryMapping(sTerritoryID, nMaxVersion));
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return oGimmickTerritoryMappings;
        }

        public DataTable GetGimmickTerritoryMappingInfo(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DLGimmickTerritoryMapping oDL = new DLGimmickTerritoryMapping();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetGimmickTerritoryMappingInfo(sTerritoryID, nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public GimmickTerritoryMappings GetGimmickTerritoryMappingForRM(String sTerritoryID, int nMaxVersion)
        {
            GimmickTerritoryMappings oGimmickTerritoryMappings;
            DLGimmickTerritoryMapping oDL = new DLGimmickTerritoryMapping();
            try
            {
                oGimmickTerritoryMappings = ReaderToObjects(oDL.GetGimmickTerritoryMappingForRM(sTerritoryID, nMaxVersion));
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return oGimmickTerritoryMappings;
        }

        public DataTable GetGimmickTerritoryMappingInfoForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DLGimmickTerritoryMapping oDL = new DLGimmickTerritoryMapping();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetGimmickTerritoryMappingInfoForRM(sTerritoryID, nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public string GetGimmickName(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, int nSampleID)
        {
            string sGimmickName;
            DLGimmickTerritoryMapping oDL = new DLGimmickTerritoryMapping();
            try
            {
                sGimmickName = oDL.GetGimmickName(oSqlConnection, oSqlTransaction, nSampleID);
                return sGimmickName;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }
		//public bool IsDuplicate(string sGimmickTerritoryMappingName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sGimmickTerritoryMappingName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sGimmickTerritoryMappingName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sGimmickTerritoryMappingName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
