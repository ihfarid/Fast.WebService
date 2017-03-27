using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.BusinessLogic
{
	public partial class BLPVPExceptionLog
	{
		//public bool Validate(PVPExceptionLog oItem)
		//{
			//DLPVPExceptionLog oDL = new DLPVPExceptionLog();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.PVPExceptionLogName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.PVPExceptionLogName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(PVPExceptionLog oItem)
		{
			DLPVPExceptionLog oDL = new DLPVPExceptionLog();
			//if (!Validate(oItem))
			//{
				//throw new Exception("PVPExceptionLog with the same Name already exist");
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
			DLPVPExceptionLog oDL = new DLPVPExceptionLog();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public int Save(PVPExceptionLog oItem, SqlConnection myConnection, SqlTransaction myTransaction)
        {
            DLPVPExceptionLog oDL = new DLPVPExceptionLog();
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
		//public bool IsDuplicate(string sPVPExceptionLogName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sPVPExceptionLogName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sPVPExceptionLogName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sPVPExceptionLogName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
