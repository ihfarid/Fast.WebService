using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;

namespace FAST.BusinessLogic
{
	public partial class BLUserManagementInfo
	{
        //public bool Validate(UserManagementInfo oItem)
		//{
			//DLUserManagementInfo oDL = new DLUserManagementInfo();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.UserManagementInfoName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.UserManagementInfoName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(UserManagementInfo oItem)
		{
			DLUserManagementInfo oDL = new DLUserManagementInfo();
			//if (!Validate(oItem))
			//{
				//throw new Exception("UserManagementInfo with the same Name already exist");
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
			DLUserManagementInfo oDL = new DLUserManagementInfo();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public DataTable GetUserManagement(string sConnectionString)
        {
            DLUserManagementInfo oDL = new DLUserManagementInfo();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetUserManagementInfo(sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

		//public bool IsDuplicate(string sUserManagementInfoName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sUserManagementInfoName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sUserManagementInfoName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sUserManagementInfoName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
