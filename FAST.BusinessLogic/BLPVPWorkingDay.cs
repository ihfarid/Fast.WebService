using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;

namespace FAST.BusinessLogic
{
	public partial class BLPVPWorkingDay
	{
		//public bool Validate(PVPWorkingDay oItem)
		//{
			//DLPVPWorkingDay oDL = new DLPVPWorkingDay();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.PVPWorkingDayName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.PVPWorkingDayName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(PVPWorkingDay oItem)
		{
			DLPVPWorkingDay oDL = new DLPVPWorkingDay();
			//if (!Validate(oItem))
			//{
				//throw new Exception("PVPWorkingDay with the same Name already exist");
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
			DLPVPWorkingDay oDL = new DLPVPWorkingDay();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public DataTable GetPVPWorkingDay(int nMaxVersion, string sConnectionString)
        {
            DLPVPWorkingDay oDL = new DLPVPWorkingDay();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetPVPWorkingDay(nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

		//public bool IsDuplicate(string sPVPWorkingDayName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sPVPWorkingDayName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sPVPWorkingDayName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sPVPWorkingDayName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
