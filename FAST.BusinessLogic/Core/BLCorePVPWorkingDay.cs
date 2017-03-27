using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;

namespace FAST.BusinessLogic
{
	public partial class BLPVPWorkingDay
	{
        private PVPWorkingDay ReaderToObject(IDataReader oReader)
        {
            PVPWorkingDay oItem = new PVPWorkingDay();
            oItem.ID.SetID(oReader["MonthID"]);
            oItem.NoOfWorkingDay = Convert.ToInt32(oReader["NoOfWorkingDay"]);
            oItem.Month = Convert.ToInt32(oReader["Month"]);
            oItem.Year = Convert.ToInt32(oReader["Year"]);
            oItem.Version = Convert.ToInt32(oReader["Version"]);
            oItem.Action = Convert.ToInt32(oReader["Action"]);
            return oItem;
        }

		private PVPWorkingDays ReaderToObjects(IDataReader oReader)
		{
			PVPWorkingDays oItems;
			PVPWorkingDay oItem;
			oItems = new PVPWorkingDays();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
			return oItems;
		}
		public PVPWorkingDays GetPVPWorkingDays()
		{
			PVPWorkingDays oPVPWorkingDays;
			DLPVPWorkingDay oDL = new DLPVPWorkingDay();
			try
			{
				oPVPWorkingDays = ReaderToObjects(oDL.GetPVPWorkingDays());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oPVPWorkingDays;
		}
		public PVPWorkingDay GetPVPWorkingDay(int nID)
		{
			PVPWorkingDay oPVPWorkingDay = new PVPWorkingDay();
			DLPVPWorkingDay oDL = new DLPVPWorkingDay();
			IDataReader oReader;
			try
			{
				oReader = oDL.GetPVPWorkingDay(nID);
				if (oReader.Read())
				{
					oPVPWorkingDay = ReaderToObject(oReader);
				}
				oReader.Close();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oPVPWorkingDay;
        }

        public PVPWorkingDay GetPVPWorkingDay(DataRow oRow)
        {
            DataTable oTable = new DataTable();
            PVPWorkingDay oItem = new PVPWorkingDay();
            try
            {
                oItem.ID.SetID(oRow["MonthID"]);
                oItem.MonthID = Convert.ToInt32(oRow["MonthID"]);
                oItem.NoOfWorkingDay = Convert.ToInt32(oRow["NoOfWorkingDay"]);
                oItem.Month = Convert.ToInt32(oRow["Month"]);
                oItem.Year = Convert.ToInt32(oRow["Year"]);
                oItem.Version = Convert.ToInt32(oRow["Version"]);
                oItem.Action = Convert.ToInt32(oRow["Action"]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public PVPWorkingDays GetPVPWorkingDays(int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            PVPWorkingDay oItem = new PVPWorkingDay();
            PVPWorkingDays oItems = new PVPWorkingDays();
            try
            {
                oTable = GetPVPWorkingDay(nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new PVPWorkingDay();
                        oItem = GetPVPWorkingDay(oRow);
                        oItems.Add(oItem);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItems;
        }
	}
}
