using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;

namespace FAST.BusinessLogic
{
	public partial class BLNationalHoliday
	{
		//public bool Validate(NationalHoliday oItem)
		//{
			//DLNationalHoliday oDL = new DLNationalHoliday();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.NationalHolidayName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.NationalHolidayName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(NationalHoliday oItem)
		{
			DLNationalHoliday oDL = new DLNationalHoliday();
			//if (!Validate(oItem))
			//{
				//throw new Exception("NationalHoliday with the same Name already exist");
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
			DLNationalHoliday oDL = new DLNationalHoliday();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}


        public NationalHolidays GetNationalHolidays(int nMaxVersion)
        {
            NationalHolidays oNationalHoliday;
            DLNationalHoliday oDL = new DLNationalHoliday();
            try
            {
                oNationalHoliday = ReaderToObjects(oDL.GetNationalHolidays(nMaxVersion));
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return oNationalHoliday;
        }

        public DataTable GetNationalHolidayInfo(int nMaxVersion, string sConnectionString)
        {
            DLNationalHoliday oDL = new DLNationalHoliday();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetNationalHolidayInfo(nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }
		//public bool IsDuplicate(string sNationalHolidayName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sNationalHolidayName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sNationalHolidayName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sNationalHolidayName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
