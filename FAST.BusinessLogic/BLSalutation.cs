using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;

namespace FAST.BusinessLogic
{
	public partial class BLSalutation
	{
		//public bool Validate(Salutation oItem)
		//{
			//DLSalutation oDL = new DLSalutation();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.SalutationName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.SalutationName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(Salutation oItem)
		{
			DLSalutation oDL = new DLSalutation();
			//if (!Validate(oItem))
			//{
				//throw new Exception("Salutation with the same Name already exist");
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
			DLSalutation oDL = new DLSalutation();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public DataTable GetSalutationInfo(int nMaxVersion, string sConnectionString)
        {
            DLSalutation oDL = new DLSalutation();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetSalutationInfo(nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }



		//public bool IsDuplicate(string sSalutationName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sSalutationName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sSalutationName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sSalutationName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
