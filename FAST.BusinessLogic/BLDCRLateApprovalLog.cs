using System;
using System.Data;
using System.Collections; 
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient; 

namespace FAST.BusinessLogic
{
	public partial class BLDCRLateApprovalLog
	{
		//public bool Validate(DCRLateApprovalLog oItem)
		//{
			//DLDCRLateApprovalLog oDL = new DLDCRLateApprovalLog();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.DCRLateApprovalLogName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.DCRLateApprovalLogName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(DCRLateApprovalLog oItem)
		{
			DLDCRLateApprovalLog oDL = new DLDCRLateApprovalLog();
			//if (!Validate(oItem))
			//{
				//throw new Exception("DCRLateApprovalLog with the same Name already exist");
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
			DLDCRLateApprovalLog oDL = new DLDCRLateApprovalLog();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
        public int Save(DCRLateApprovalLog oItem, SqlConnection myConnection, SqlTransaction myTransaction)
        {
            DLDCRLateApprovalLog oDL = new DLDCRLateApprovalLog();
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
		//public bool IsDuplicate(string sDCRLateApprovalLogName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sDCRLateApprovalLogName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sDCRLateApprovalLogName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sDCRLateApprovalLogName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
