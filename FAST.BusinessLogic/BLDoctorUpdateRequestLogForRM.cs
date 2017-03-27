using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.BusinessLogic
{
	public partial class BLDoctorUpdateRequestLogForRM
	{
		//public bool Validate(DoctorUpdateRequestLogForRM oItem)
		//{
			//DLDoctorUpdateRequestLogForRM oDL = new DLDoctorUpdateRequestLogForRM();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.DoctorUpdateRequestLogForRMName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.DoctorUpdateRequestLogForRMName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(DoctorUpdateRequestLogForRM oItem)
		{
			DLDoctorUpdateRequestLogForRM oDL = new DLDoctorUpdateRequestLogForRM();
			//if (!Validate(oItem))
			//{
				//throw new Exception("DoctorUpdateRequestLogForRM with the same Name already exist");
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
			DLDoctorUpdateRequestLogForRM oDL = new DLDoctorUpdateRequestLogForRM();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public int Save(DoctorUpdateRequestLogForRM oItem, SqlConnection myConnection, SqlTransaction myTransaction)
        {
            DLDoctorUpdateRequestLogForRM oDL = new DLDoctorUpdateRequestLogForRM();
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

		//public bool IsDuplicate(string sDoctorUpdateRequestLogForRMName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sDoctorUpdateRequestLogForRMName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sDoctorUpdateRequestLogForRMName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sDoctorUpdateRequestLogForRMName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
