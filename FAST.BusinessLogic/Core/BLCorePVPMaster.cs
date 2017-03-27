using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;

namespace FAST.BusinessLogic
{
	public partial class BLPVPMaster
	{
        private PVPMaster ReaderToObject(IDataReader oReader)
        {
            PVPMaster oItem = new PVPMaster();
            oItem.ID.SetID(oReader["PvpID"]);
            oItem.PvpID = Convert.ToInt32(oReader["PvpID"]);
            oItem.TerritoryID = oReader["TerritoryID"].ToString();
            oItem.Month = Convert.ToInt32(oReader["Month"]);
            oItem.Year = Convert.ToInt32(oReader["Year"]);
            oItem.Status = (PVPStatus)Convert.ToInt32(oReader["Status"]);
            oItem.SubmitDate = Convert.ToDateTime(oReader["SubmitDate"]);
            oItem.ApprovedDate = Convert.ToDateTime(oReader["ApprovedDate"]);
            oItem.SubmittedBy = oReader["SubmittedBy"].ToString();
            oItem.ApprovedBy = oReader["ApprovedBy"].ToString();
            oItem.NoOfPlannedDay = Convert.ToInt32(oReader["NoOfPlannedDay"]);
            oItem.Version = Convert.ToInt32(oReader["Version"]);
            oItem.Action = Convert.ToInt32(oReader["Action"]);
            return oItem;
        }
		
		private PVPMasters ReaderToObjects(IDataReader oReader)
		{
			PVPMasters oItems;
			PVPMaster oItem;
			oItems = new PVPMasters();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
			return oItems;
		}
		public PVPMasters GetPVPMasters()
		{
			PVPMasters oPVPMasters;
			DLPVPMaster oDL = new DLPVPMaster();
			try
			{
				oPVPMasters = ReaderToObjects(oDL.GetPVPMasters());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oPVPMasters;
		}
		public PVPMaster GetPVPMaster(int nID)
		{
			PVPMaster oPVPMaster = new PVPMaster();
			DLPVPMaster oDL = new DLPVPMaster();
			IDataReader oReader;
			try
			{
				oReader = oDL.GetPVPMaster(nID);
				if (oReader.Read())
				{
					oPVPMaster = ReaderToObject(oReader);
				}
				oReader.Close();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oPVPMaster;
		}

        public PVPMaster GetPVPMasterInfo(string sTerritoryID, int nMonth, int nYear, string sConnectionString)
        {

            DLPVPMaster oDL = new DLPVPMaster();
            DataTable oTable = new DataTable();
            PVPMaster oItem = new PVPMaster();
            try
            {
                oTable = GetPVPMasterInfoByTerritoryID(sTerritoryID, nMonth, nYear, sConnectionString);

                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem.ID.SetID(oRow["PvpID"]);
                    oItem.TerritoryID = oRow["TerritoryID"].ToString();
                    oItem.Month = Convert.ToInt32(oRow["Month"]);
                    oItem.Year = Convert.ToInt32(oRow["Year"]);
                    oItem.Status = (PVPStatus)Convert.ToInt32(oRow["Status"]);
                    oItem.SubmitDate = Convert.ToDateTime(oRow["SubmitDate"]);
                    oItem.ApprovedDate = Convert.ToDateTime(oRow["ApprovedDate"]);
                    oItem.SubmittedBy = oRow["SubmittedBy"].ToString();
                    oItem.ApprovedBy = oRow["ApprovedBy"].ToString();
                    oItem.NoOfPlannedDay = Convert.ToInt32(oRow["NoOfPlannedDay"]);
                    oItem.Version = Convert.ToInt32(oRow["Version"]);
                    oItem.Action = Convert.ToInt32(oRow["Action"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public PVPMaster GetPVPMaster(DataRow oRow)
        {
            DataTable oTable = new DataTable();
            PVPMaster oItem = new PVPMaster();
            try
            {
                oItem.ID.SetID(oRow["PvpID"]);
                oItem.PvpID = Convert.ToInt32(oRow["PvpID"]);
                oItem.TerritoryID = oRow["TerritoryID"].ToString().ToUpper();
                oItem.Month = Convert.ToInt32(oRow["Month"]);
                oItem.Year = Convert.ToInt32(oRow["Year"]);
                oItem.Status = (PVPStatus)Convert.ToInt32(oRow["Status"]);
                oItem.SubmitDate = Convert.ToDateTime(oRow["SubmitDate"]);
                oItem.ApprovedDate = Convert.ToDateTime(oRow["ApprovedDate"]);
                oItem.SubmittedBy = oRow["SubmittedBy"].ToString();
                oItem.ApprovedBy = oRow["ApprovedBy"].ToString();
                oItem.NoOfPlannedDay = Convert.ToInt32(oRow["NoOfPlannedDay"]);
                oItem.Version = Convert.ToInt32(oRow["Version"]);
                oItem.Action = Convert.ToInt32(oRow["Action"]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public PVPMaster GetPVPMaster(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nPreviousMonth, int nPreviousYear, int nNextMonth, int nNextYear, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            PVPMaster oItem = new PVPMaster();
            try
            {
                oTable = GetPVPMasterInfo(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonth, nPreviousYear, nNextMonth, nNextYear, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem = GetPVPMaster(oRow);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public PVPMasters GetPVPMasters(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nPreviousMonth, int nPreviousYear, int nNextMonth, int nNextYear, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            PVPMaster oItem = new PVPMaster();
            PVPMasters oItems = new PVPMasters();
            try
            {
                oTable = GetPVPMasterInfo(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonth, nPreviousYear, nNextMonth, nNextYear, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new PVPMaster();
                        oItem = GetPVPMaster(oRow);
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

        public PVPMaster GetPVPMasterForRM(string sTerritoryID, int nMonth, int nYear, int nPreMonth, int nPreYear, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            PVPMaster oItem = new PVPMaster();
            try
            {
                oTable = GetPVPMasterInfoForRM(sTerritoryID, nMonth, nYear, nPreMonth, nPreYear, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem = GetPVPMaster(oRow);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public PVPMasters GetPVPMastersForRM(string sTerritoryID, int nNextMonth, int nNextYear, int nCurrentMonth, int nCurrentYear, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            PVPMaster oItem = new PVPMaster();
            PVPMasters oItems = new PVPMasters();
            try
            {
                oTable = GetPVPMasterInfoForRM(sTerritoryID, nNextMonth, nNextYear, nCurrentMonth, nCurrentYear, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new PVPMaster();
                        oItem = GetPVPMaster(oRow);
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
