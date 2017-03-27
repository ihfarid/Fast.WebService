using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;

namespace FAST.BusinessLogic
{
	public partial class BLUpazilla
	{
		//public bool Validate(Upazilla oItem)
		//{
			//DLUpazilla oDL = new DLUpazilla();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.UpazillaName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.UpazillaName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(Upazilla oItem)
		{
			DLUpazilla oDL = new DLUpazilla();
			//if (!Validate(oItem))
			//{
				//throw new Exception("Upazilla with the same Name already exist");
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
			DLUpazilla oDL = new DLUpazilla();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public DataTable GetUpazillaInfoForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DLUpazilla oDL = new DLUpazilla();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetUpazillaInfoForRM(sTerritoryID, nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }


        public DataTable GetUpazillaInfo(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DLUpazilla oDL = new DLUpazilla();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetUpazillaInfo(sTerritoryID, nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

		//public bool IsDuplicate(string sUpazillaName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sUpazillaName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sUpazillaName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sUpazillaName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
