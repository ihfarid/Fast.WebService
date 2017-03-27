using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;

namespace FAST.BusinessLogic
{
	public partial class BLSpecialty
	{
		//public bool Validate(Specialty oItem)
		//{
			//DLSpecialty oDL = new DLSpecialty();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.SpecialtyName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.SpecialtyName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(Specialty oItem)
		{
			DLSpecialty oDL = new DLSpecialty();
			//if (!Validate(oItem))
			//{
				//throw new Exception("Specialty with the same Name already exist");
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
			DLSpecialty oDL = new DLSpecialty();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public DataTable GetSpecialityInfo(int nMaxVersion, string sConnectionString)
        {
            DLSpecialty oDL = new DLSpecialty();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetSpecialityInfo(nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

		//public bool IsDuplicate(string sSpecialtyName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sSpecialtyName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sSpecialtyName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sSpecialtyName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
