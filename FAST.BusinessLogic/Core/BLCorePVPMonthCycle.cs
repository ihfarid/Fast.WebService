using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;

namespace FAST.BusinessLogic
{
	public partial class BLPVPMonthCycle
	{
		private PVPMonthCycle ReaderToObject(IDataReader oReader)
		{
			PVPMonthCycle oItem = new PVPMonthCycle();
			oItem.ID.SetID(oReader["CycleID"]);
oItem.StartDate =Convert.ToDateTime( oReader["StartDate"]);
oItem.EndDate =Convert.ToDateTime( oReader["EndDate"]);
oItem.Month =Convert.ToInt32( oReader["Month"]);
oItem.Year =Convert.ToInt32( oReader["Year"]);
oItem.IsActive =Convert.ToBoolean( oReader["IsActive"]);
			return oItem;
		}
		private PVPMonthCycles ReaderToObjects(IDataReader oReader)
		{
			PVPMonthCycles oItems;
			PVPMonthCycle oItem;
			oItems = new PVPMonthCycles();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
			return oItems;
		}
		public PVPMonthCycles GetPVPMonthCycles()
		{
			PVPMonthCycles oPVPMonthCycles;
			DLPVPMonthCycle oDL = new DLPVPMonthCycle();
			try
			{
				oPVPMonthCycles = ReaderToObjects(oDL.GetPVPMonthCycles());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oPVPMonthCycles;
		}
		public PVPMonthCycle GetPVPMonthCycle(int nID)
		{
			PVPMonthCycle oPVPMonthCycle = new PVPMonthCycle();
			DLPVPMonthCycle oDL = new DLPVPMonthCycle();
			IDataReader oReader;
			try
			{
				oReader = oDL.GetPVPMonthCycle(nID);
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

        public PVPMonthCycle GetPVPMonthCycle(string sConnectionString)
        {

            DLPVPMonthCycle oDL = new DLPVPMonthCycle();
            DataTable oTable = new DataTable();
            PVPMonthCycle oItem = new PVPMonthCycle();
            try
            {
                oTable = GetActivePVPMonthCycle(sConnectionString);

                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem.ID.SetID(oRow["CycleID"]);
                    oItem.StartDate = Convert.ToDateTime(oRow["StartDate"]);
                    oItem.EndDate = Convert.ToDateTime(oRow["EndDate"]);
                    oItem.Month = Convert.ToInt32(oRow["Month"]);
                    oItem.Year = Convert.ToInt32(oRow["Year"]);
                    oItem.IsActive = Convert.ToBoolean(oRow["IsActive"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }
	}
}
