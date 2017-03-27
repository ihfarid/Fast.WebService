using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;

namespace FAST.BusinessLogic
{
	public partial class BLNationalHoliday
	{
		private NationalHoliday ReaderToObject(IDataReader oReader)
		{
			NationalHoliday oItem = new NationalHoliday();
			oItem.ID.SetID(oReader["HolidayID"]);
            oItem.HolidayID = Convert.ToInt32(oReader["HolidayID"]);
			if (!oReader["Name"].Equals(DBNull.Value))
			{
				oItem.Name = oReader["Name"].ToString();
			}
			if (!oReader["Day"].Equals(DBNull.Value))
			{
				oItem.Day =Convert.ToInt32( oReader["Day"]);
			}
			if (!oReader["Month"].Equals(DBNull.Value))
			{
				oItem.Month =Convert.ToInt32( oReader["Month"]);
			}
			if (!oReader["Year"].Equals(DBNull.Value))
			{
				oItem.Year =Convert.ToInt32( oReader["Year"]);
			}
			if (!oReader["Version"].Equals(DBNull.Value))
			{
				oItem.Version =Convert.ToInt32( oReader["Version"]);
			}
			if (!oReader["Action"].Equals(DBNull.Value))
			{
                oItem.Action = Convert.ToInt32(oReader["Action"]);
			}
			return oItem;
		}
		private NationalHolidays ReaderToObjects(IDataReader oReader)
		{
			NationalHolidays oItems;
			NationalHoliday oItem;
			oItems = new NationalHolidays();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
			return oItems;
		}
		public NationalHolidays GetNationalHolidays()
		{
			NationalHolidays oNationalHolidays;
			DLNationalHoliday oDL = new DLNationalHoliday();
			try
			{
				oNationalHolidays = ReaderToObjects(oDL.GetNationalHolidays());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oNationalHolidays;
		}
		public NationalHoliday GetNationalHoliday(int nID)
		{
			NationalHoliday oNationalHoliday = new NationalHoliday();
			DLNationalHoliday oDL = new DLNationalHoliday();
			IDataReader oReader;
			try
			{
				oReader = oDL.GetNationalHoliday(nID);
				if (oReader.Read())
				{
					oNationalHoliday = ReaderToObject(oReader);
				}
				oReader.Close();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oNationalHoliday;
		}

        public NationalHoliday GetNationalHoliday(DataRow oRow)
        {
            DataTable oTable = new DataTable();
            NationalHoliday oItem = new NationalHoliday();
            try
            {
                oItem.ID.SetID(oRow["HolidayID"]);
                oItem.HolidayID = Convert.ToInt32(oRow["HolidayID"]);
                if (!oRow["Name"].Equals(DBNull.Value))
                {
                    oItem.Name = oRow["Name"].ToString();
                }
                if (!oRow["Day"].Equals(DBNull.Value))
                {
                    oItem.Day = Convert.ToInt32(oRow["Day"]);
                }
                if (!oRow["Month"].Equals(DBNull.Value))
                {
                    oItem.Month = Convert.ToInt32(oRow["Month"]);
                }
                if (!oRow["Year"].Equals(DBNull.Value))
                {
                    oItem.Year = Convert.ToInt32(oRow["Year"]);
                }
                if (!oRow["Version"].Equals(DBNull.Value))
                {
                    oItem.Version = Convert.ToInt32(oRow["Version"]);
                }
                if (!oRow["Action"].Equals(DBNull.Value))
                {
                    oItem.Action = Convert.ToInt32(oRow["Action"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public NationalHoliday GetNationalHoliday(int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            NationalHoliday oItem = new NationalHoliday();
            try
            {
                oTable = GetNationalHolidayInfo(nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem = GetNationalHoliday(oRow);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public NationalHolidays GetNationalHolidays(int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            NationalHoliday oItem = new NationalHoliday();
            NationalHolidays oItems = new NationalHolidays();
            try
            {
                oTable = GetNationalHolidayInfo(nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new NationalHoliday();
                        oItem = GetNationalHoliday(oRow);
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
