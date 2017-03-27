using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;

namespace FAST.BusinessLogic
{
	public partial class BLPVPDetail
	{
		private PVPDetail ReaderToObject(IDataReader oReader)
		{
			PVPDetail oItem = new PVPDetail();
			oItem.ID.SetID(oReader["DetailID"]);
            oItem.DetailID = Convert.ToInt32(oReader["DetailID"]);
			if (!oReader["PvpID"].Equals(DBNull.Value))
			{
				oItem.PvpID =Convert.ToInt32( oReader["PvpID"]);
			}
			if (!oReader["DoctorID"].Equals(DBNull.Value))
			{
				oItem.DoctorID =Convert.ToInt32( oReader["DoctorID"]);
			}
			if (!oReader["TerritoryID"].Equals(DBNull.Value))
			{
				oItem.TerritoryID = oReader["TerritoryID"].ToString();
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
			if (!oReader["Brand1"].Equals(DBNull.Value))
			{
				oItem.Brand1 =Convert.ToInt32( oReader["Brand1"]);
			}
			if (!oReader["Brand2"].Equals(DBNull.Value))
			{
				oItem.Brand2 =Convert.ToInt32( oReader["Brand2"]);
			}
			if (!oReader["Brand3"].Equals(DBNull.Value))
			{
				oItem.Brand3 =Convert.ToInt32( oReader["Brand3"]);
			}
			if (!oReader["Brand4"].Equals(DBNull.Value))
			{
				oItem.Brand4 =Convert.ToInt32( oReader["Brand4"]);
			}
			if (!oReader["Brand5"].Equals(DBNull.Value))
			{
				oItem.Brand5 =Convert.ToInt32( oReader["Brand5"]);
			}
			if (!oReader["Brand6"].Equals(DBNull.Value))
			{
				oItem.Brand6 =Convert.ToInt32( oReader["Brand6"]);
			}
            if (!oReader["Brand7"].Equals(DBNull.Value))
            {
                oItem.Brand7 = Convert.ToInt32(oReader["Brand7"]);
            }
            if (!oReader["Brand8"].Equals(DBNull.Value))
            {
                oItem.Brand8 = Convert.ToInt32(oReader["Brand8"]);
            }
			if (!oReader["Session"].Equals(DBNull.Value))
			{
				oItem.Session = oReader["Session"].ToString();
			}
			if (!oReader["IsHoliday"].Equals(DBNull.Value))
			{
				oItem.IsHoliday =Convert.ToBoolean( oReader["IsHoliday"]);
			}
			if (!oReader["DoctorProfile"].Equals(DBNull.Value))
			{
				oItem.DoctorProfile = oReader["DoctorProfile"].ToString();
			}
			if (!oReader["CreatedBy"].Equals(DBNull.Value))
			{
				oItem.CreatedBy = oReader["CreatedBy"].ToString();
			}
			if (!oReader["CreationDate"].Equals(DBNull.Value))
			{
				oItem.CreationDate =Convert.ToDateTime( oReader["CreationDate"]);
			}
			return oItem;
		}
		private PVPDetails ReaderToObjects(IDataReader oReader)
		{
			PVPDetails oItems;
			PVPDetail oItem;
			oItems = new PVPDetails();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
			return oItems;
		}
		public PVPDetails GetPVPDetails()
		{
			PVPDetails oPVPDetails;
			DLPVPDetail oDL = new DLPVPDetail();
			try
			{
				oPVPDetails = ReaderToObjects(oDL.GetPVPDetails());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oPVPDetails;
		}
		public PVPDetail GetPVPDetail(int nID)
		{
			PVPDetail oPVPDetail = new PVPDetail();
			DLPVPDetail oDL = new DLPVPDetail();
			IDataReader oReader;
			try
			{
				oReader = oDL.GetPVPDetail(nID);
				if (oReader.Read())
				{
					oPVPDetail = ReaderToObject(oReader);
				}
				oReader.Close();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oPVPDetail;
		}

        public PVPDetail GetPVPDetail(DataRow oRow)
        {
            DataTable oTable = new DataTable();
            PVPDetail oItem = new PVPDetail();
            try
            {
                oItem.ID.SetID(oRow["DetailID"]);
                oItem.DetailID = Convert.ToInt32(oRow["DetailID"]);
                if (!oRow["PvpID"].Equals(DBNull.Value))
                {
                    oItem.PvpID = Convert.ToInt32(oRow["PvpID"]);
                }
                if (!oRow["DoctorID"].Equals(DBNull.Value))
                {
                    oItem.DoctorID = Convert.ToInt32(oRow["DoctorID"]);
                }
                if (!oRow["TerritoryID"].Equals(DBNull.Value))
                {
                    oItem.TerritoryID = oRow["TerritoryID"].ToString().ToUpper();
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
                if (!oRow["Brand1"].Equals(DBNull.Value))
                {
                    oItem.Brand1 = Convert.ToInt32(oRow["Brand1"]);
                }
                if (!oRow["Brand2"].Equals(DBNull.Value))
                {
                    oItem.Brand2 = Convert.ToInt32(oRow["Brand2"]);
                }
                if (!oRow["Brand3"].Equals(DBNull.Value))
                {
                    oItem.Brand3 = Convert.ToInt32(oRow["Brand3"]);
                }
                if (!oRow["Brand4"].Equals(DBNull.Value))
                {
                    oItem.Brand4 = Convert.ToInt32(oRow["Brand4"]);
                }
                if (!oRow["Brand5"].Equals(DBNull.Value))
                {
                    oItem.Brand5 = Convert.ToInt32(oRow["Brand5"]);
                }
                if (!oRow["Brand6"].Equals(DBNull.Value))
                {
                    oItem.Brand6 = Convert.ToInt32(oRow["Brand6"]);
                }
                if (!oRow["Brand7"].Equals(DBNull.Value))
                {
                    oItem.Brand7 = Convert.ToInt32(oRow["Brand7"]);
                }
                if (!oRow["Brand8"].Equals(DBNull.Value))
                {
                    oItem.Brand8 = Convert.ToInt32(oRow["Brand8"]);
                }
                if (!oRow["Session"].Equals(DBNull.Value))
                {
                    oItem.Session = oRow["Session"].ToString();
                }
                if (!oRow["IsHoliday"].Equals(DBNull.Value))
                {
                    oItem.IsHoliday = Convert.ToBoolean(oRow["IsHoliday"]);
                }
                if (!oRow["DoctorProfile"].Equals(DBNull.Value))
                {
                    oItem.DoctorProfile = oRow["DoctorProfile"].ToString();
                }
                if (!oRow["CreatedBy"].Equals(DBNull.Value))
                {
                    oItem.CreatedBy = oRow["CreatedBy"].ToString();
                }
                if (!oRow["CreationDate"].Equals(DBNull.Value))
                {
                    oItem.CreationDate = Convert.ToDateTime(oRow["CreationDate"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public PVPDetail GetPVPDetail(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nPreviousMonthDay, int nPreviousMonth, int nPreviousYear, int nNextMonth, int nNextYear, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            PVPDetail oItem = new PVPDetail();
            try
            {
                oTable = GetPVPDetailInfo(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonthDay, nPreviousMonth, nPreviousYear, nNextMonth, nNextYear, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem = GetPVPDetail(oRow);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public PVPDetails GetPVPDetails(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nPreviousMonthDay, int nPreviousMonth, int nPreviousYear, int nNextMonth, int nNextYear, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            PVPDetail oItem = new PVPDetail();
            PVPDetails oItems = new PVPDetails();
            try
            {
                oTable = GetPVPDetailInfo(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonthDay, nPreviousMonth, nPreviousYear, nNextMonth, nNextYear, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new PVPDetail();
                        oItem = GetPVPDetail(oRow);
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

        public PVPDetail GetPVPDetailForRM(string sTerritoryID, int nMonth, int nYear, int nPreMonth, int nPreYear, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            PVPDetail oItem = new PVPDetail();
            try
            {
                oTable = GetPVPDetailInfoForRM(sTerritoryID, nMonth, nYear, nPreMonth, nPreYear, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem = GetPVPDetail(oRow);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public PVPDetails GetPVPDetailsForRM(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nNextMonth, int nNextYear, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            PVPDetail oItem = new PVPDetail();
            PVPDetails oItems = new PVPDetails();
            try
            {
                oTable = GetPVPDetailInfoForRM(sTerritoryID, nCurrentMonth, nCurrentYear, nNextMonth, nNextYear, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new PVPDetail();
                        oItem = GetPVPDetail(oRow);
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
