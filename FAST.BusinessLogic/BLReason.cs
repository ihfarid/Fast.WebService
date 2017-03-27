using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;

namespace FAST.BusinessLogic
{
	public partial class BLReason
	{
		//public bool Validate(Reason oItem)
		//{
			//DLReason oDL = new DLReason();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.ReasonName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.ReasonName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(Reason oItem)
		{
			DLReason oDL = new DLReason();
			//if (!Validate(oItem))
			//{
				//throw new Exception("Reason with the same Name already exist");
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
			DLReason oDL = new DLReason();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public Reasons GetReasons(int nMaxVersion)
        {
            Reasons oReasons;
            DLReason oDL = new DLReason();
            try
            {
                oReasons = ReaderToObjects(oDL.GetReasons(nMaxVersion));
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return oReasons;
        }

        public DataTable GetReasonInfo(int nMaxVersion, string sConnectionString)
        {
            DLReason oDL = new DLReason();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetReasonInfo(nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

		//public bool IsDuplicate(string sReasonName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sReasonName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sReasonName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sReasonName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
