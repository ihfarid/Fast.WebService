using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.BusinessLogic
{
	public partial class BLSampleTerritoryMapping
	{
		//public bool Validate(SampleTerritoryMapping oItem)
		//{
			//DLSampleTerritoryMapping oDL = new DLSampleTerritoryMapping();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.SampleTerritoryMappingName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.SampleTerritoryMappingName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(SampleTerritoryMapping oItem)
		{
			DLSampleTerritoryMapping oDL = new DLSampleTerritoryMapping();
			//if (!Validate(oItem))
			//{
				//throw new Exception("SampleTerritoryMapping with the same Name already exist");
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
			DLSampleTerritoryMapping oDL = new DLSampleTerritoryMapping();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public SampleTerritoryMappings GetSampleTerritoryMapping(String sTerritoryID, int nMaxVersion)
        {
            SampleTerritoryMappings oSampleTerritoryMappings;
            DLSampleTerritoryMapping oDL = new DLSampleTerritoryMapping();
            try
            {
                oSampleTerritoryMappings = ReaderToObjects(oDL.GetSampleTerritoryMapping(sTerritoryID, nMaxVersion));
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return oSampleTerritoryMappings;
        }

        public DataTable GetSampleTerritoryMappingInfo(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DLSampleTerritoryMapping oDL = new DLSampleTerritoryMapping();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetSampleTerritoryMappingInfo(sTerritoryID, nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public SampleTerritoryMappings GetSampleTerritoryMappingForRM(String sTerritoryID, int nMaxVersion)
        {
            SampleTerritoryMappings oSampleTerritoryMappings;
            DLSampleTerritoryMapping oDL = new DLSampleTerritoryMapping();
            try
            {
                oSampleTerritoryMappings = ReaderToObjects(oDL.GetSampleTerritoryMappingForRM(sTerritoryID, nMaxVersion));
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return oSampleTerritoryMappings;
        }

        public DataTable GetSampleTerritoryMappingInfoForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DLSampleTerritoryMapping oDL = new DLSampleTerritoryMapping();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetSampleTerritoryMappingInfoForRM(sTerritoryID, nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public string GetSampleName(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, int nSampleID)
        {
            string sSampleName;
            DLSampleTerritoryMapping oDL = new DLSampleTerritoryMapping();
            try
            {
                sSampleName = oDL.GetSampleName(oSqlConnection, oSqlTransaction, nSampleID);
                return sSampleName;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }
		//public bool IsDuplicate(string sSampleTerritoryMappingName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sSampleTerritoryMappingName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sSampleTerritoryMappingName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sSampleTerritoryMappingName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
