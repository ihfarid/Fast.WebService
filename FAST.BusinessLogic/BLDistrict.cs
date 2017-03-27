using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;

namespace FAST.BusinessLogic
{
	public partial class BLDistrict
	{
		//public bool Validate(District oItem)
		//{
			//DLDistrict oDL = new DLDistrict();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.DistrictName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.DistrictName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(District oItem)
		{
			DLDistrict oDL = new DLDistrict();
			//if (!Validate(oItem))
			//{
				//throw new Exception("District with the same Name already exist");
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
			DLDistrict oDL = new DLDistrict();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public DataTable GetDistrictInfoForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DLDistrict oDL = new DLDistrict();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetDistrictInfoForRM(sTerritoryID, nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public DataTable GetDistrictInfo(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DLDistrict oDL = new DLDistrict();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetDistrictInfo(sTerritoryID,nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

		//public bool IsDuplicate(string sDistrictName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sDistrictName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sDistrictName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sDistrictName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
