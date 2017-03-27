using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.BusinessLogic
{
	public partial class BLAppStatusDetail
	{
		//public bool Validate(AppStatusDetail oItem)
		//{
			//DLAppStatusDetail oDL = new DLAppStatusDetail();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.AppStatusDetailName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.AppStatusDetailName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(AppStatusDetail oItem)
		{
			DLAppStatusDetail oDL = new DLAppStatusDetail();
			//if (!Validate(oItem))
			//{
				//throw new Exception("AppStatusDetail with the same Name already exist");
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
			DLAppStatusDetail oDL = new DLAppStatusDetail();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public int Save(AppStatusDetail oItem, SqlConnection myConnection, SqlTransaction myTransaction)
        {
            DLAppStatusDetail oDL = new DLAppStatusDetail();
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
		//public bool IsDuplicate(string sAppStatusDetailName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sAppStatusDetailName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sAppStatusDetailName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sAppStatusDetailName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
