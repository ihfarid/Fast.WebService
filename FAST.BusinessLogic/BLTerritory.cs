using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.BusinessLogic
{
	public partial class BLTerritory
	{
        public int GetTerritoryID(string sTerritoryID)
        {
            Int32 nTerritoryID;
            DLTerritory oDLTerritory = new DLTerritory();
            try
            {
                nTerritoryID = oDLTerritory.GetTerritoryID(sTerritoryID);
                return nTerritoryID;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }
        
        //public bool Validate(Territory oItem)
		//{
			//DLTerritory oDL = new DLTerritory();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.TerritoryName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.TerritoryName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(Territory oItem)
		{
			DLTerritory oDL = new DLTerritory();
			//if (!Validate(oItem))
			//{
				//throw new Exception("Territory with the same Name already exist");
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
			DLTerritory oDL = new DLTerritory();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public int GetTerritoryID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sTerritoryID)
        {
            int nTerritoryID;
            DLTerritory oDL = new DLTerritory();
            try
            {
                nTerritoryID = oDL.GetTerritoryID(oSqlConnection, oSqlTransaction, sTerritoryID);
                return nTerritoryID;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public int GetUserTypeID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sTerritoryID)
        {
            int nWorkAreaID;
            DLTerritory oDL = new DLTerritory();
            try
            {
                nWorkAreaID = oDL.GetUserTypeID(oSqlConnection, oSqlTransaction, sTerritoryID);
                return nWorkAreaID;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public DataTable GetTerritoryInfo(int nID, string sConnectionString)
        {
            DLTerritory oDL = new DLTerritory();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetTerritory(nID, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

		//public bool IsDuplicate(string sTerritoryName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sTerritoryName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sTerritoryName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sTerritoryName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
