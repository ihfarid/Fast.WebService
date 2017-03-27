using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.BusinessLogic
{
	public partial class BLBrandTerritoryMapping
	{
		//public bool Validate(BrandTerritoryMapping oItem)
		//{
			//DLBrandTerritoryMapping oDL = new DLBrandTerritoryMapping();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.BrandTerritoryMappingName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.BrandTerritoryMappingName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(BrandTerritoryMapping oItem)
		{
			DLBrandTerritoryMapping oDL = new DLBrandTerritoryMapping();
			//if (!Validate(oItem))
			//{
				//throw new Exception("BrandTerritoryMapping with the same Name already exist");
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
			DLBrandTerritoryMapping oDL = new DLBrandTerritoryMapping();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public BrandTerritoryMappings GetBrandTerritoryMapping(String sTerritoryID, int nMaxVersion)
        {
            BrandTerritoryMappings oBrandTerritoryMappings;
            DLBrandTerritoryMapping oDL = new DLBrandTerritoryMapping();
            try
            {
                oBrandTerritoryMappings = ReaderToObjects(oDL.GetBrandTerritoryMapping(sTerritoryID, nMaxVersion));
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return oBrandTerritoryMappings;
        }

        public DataTable GetBrandTerritoryMappingInfo(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DLBrandTerritoryMapping oDL = new DLBrandTerritoryMapping();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetBrandTerritoryMappingInfo(sTerritoryID, nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public BrandTerritoryMappings GetBrandTerritoryMappingForRM(String sTerritoryID, int nMaxVersion)
        {
            BrandTerritoryMappings oBrandTerritoryMappings;
            DLBrandTerritoryMapping oDL = new DLBrandTerritoryMapping();
            try
            {
                oBrandTerritoryMappings = ReaderToObjects(oDL.GetBrandTerritoryMappingForRM(sTerritoryID, nMaxVersion));
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return oBrandTerritoryMappings;
        }

        public DataTable GetBrandTerritoryMappingInfoForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DLBrandTerritoryMapping oDL = new DLBrandTerritoryMapping();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetBrandTerritoryMappingInfoForRM(sTerritoryID, nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public string GetBrandName(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, int nBrandID)
        {
            string sBrandName;
            DLBrandTerritoryMapping oDL = new DLBrandTerritoryMapping();
            try
            {
                sBrandName = oDL.GetBrandName(oSqlConnection, oSqlTransaction, nBrandID);
                return sBrandName;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }
		//public bool IsDuplicate(string sBrandTerritoryMappingName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sBrandTerritoryMappingName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sBrandTerritoryMappingName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sBrandTerritoryMappingName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
