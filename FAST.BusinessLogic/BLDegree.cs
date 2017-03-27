using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;

namespace FAST.BusinessLogic
{
	public partial class BLDegree
	{
		//public bool Validate(Degree oItem)
		//{
			//DLDegree oDL = new DLDegree();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.DegreeName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.DegreeName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(Degree oItem)
		{
			DLDegree oDL = new DLDegree();
			//if (!Validate(oItem))
			//{
				//throw new Exception("Degree with the same Name already exist");
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
			DLDegree oDL = new DLDegree();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public DataTable GetDegreeInfo(int nMaxVersion, string sConnectionString)
        {
            DLDegree oDL = new DLDegree();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetDegreeInfo(nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }
		//public bool IsDuplicate(string sDegreeName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sDegreeName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sDegreeName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sDegreeName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
