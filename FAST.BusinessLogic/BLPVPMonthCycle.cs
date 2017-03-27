using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;

namespace FAST.BusinessLogic
{
	public partial class BLPVPMonthCycle
	{
		//public bool Validate(PVPMonthCycle oItem)
		//{
			//DLPVPMonthCycle oDL = new DLPVPMonthCycle();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.PVPMonthCycleName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.PVPMonthCycleName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(PVPMonthCycle oItem)
		{
			DLPVPMonthCycle oDL = new DLPVPMonthCycle();
			//if (!Validate(oItem))
			//{
				//throw new Exception("PVPMonthCycle with the same Name already exist");
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
			DLPVPMonthCycle oDL = new DLPVPMonthCycle();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public PVPMonthCycle GetActivePVPMonthCycle()
        {
            PVPMonthCycle oPVPMonthCycle = new PVPMonthCycle();
            DLPVPMonthCycle oDL = new DLPVPMonthCycle();
            IDataReader oReader;
            try
            {
                oReader = oDL.GetActivePVPMonthCycle();
                if (oReader.Read())
                {
                    oPVPMonthCycle = ReaderToObject(oReader);
                }
                oReader.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oPVPMonthCycle;
        }

        public DataTable GetActivePVPMonthCycle(string sConnectionString)
        {
            DLPVPMonthCycle oDL = new DLPVPMonthCycle();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetPVPMonthCycle(sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }
		//public bool IsDuplicate(string sPVPMonthCycleName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sPVPMonthCycleName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sPVPMonthCycleName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sPVPMonthCycleName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
