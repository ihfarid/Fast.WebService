using System;
using System.Data;
using System.Collections; 
using FAST.BusinessObjects;
using FAST.DataLogic; 

namespace FAST.BusinessLogic
{
	public partial class BLDCRLateApprovalLog
	{
        private DCRLateApprovalLog ReaderToObject(IDataReader oReader)
        {
            DCRLateApprovalLog oItem = new DCRLateApprovalLog();
            oItem.ID.SetID(oReader["LogID"]);
            oItem.RegionID = oReader["RegionID"].ToString();
            oItem.TerritoryID = oReader["TerritoryID"].ToString();
            oItem.DCRDetail = oReader["DCRDetail"].ToString();
            oItem.Day = Convert.ToInt32(oReader["Day"]);
            oItem.Month = Convert.ToInt32(oReader["Month"]);
            oItem.Year = Convert.ToInt32(oReader["Year"]);
            oItem.ApprovedDateTime = Convert.ToDateTime(oReader["ApprovedDateTime"]);
            oItem.ApprovedBy = oReader["ApprovedBy"].ToString();
            return oItem;
        }
		private DCRLateApprovalLogs ReaderToObjects(IDataReader oReader)
		{
			DCRLateApprovalLogs oItems;
			DCRLateApprovalLog oItem;
			oItems = new DCRLateApprovalLogs();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
			return oItems;
		}
		public DCRLateApprovalLogs GetDCRLateApprovalLogs()
		{
			DCRLateApprovalLogs oDCRLateApprovalLogs;
			DLDCRLateApprovalLog oDL = new DLDCRLateApprovalLog();
			try
			{
				oDCRLateApprovalLogs = ReaderToObjects(oDL.GetDCRLateApprovalLogs());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oDCRLateApprovalLogs;
		}
		public DCRLateApprovalLog GetDCRLateApprovalLog(int nID)
		{
			DCRLateApprovalLog oDCRLateApprovalLog = new DCRLateApprovalLog();
			DLDCRLateApprovalLog oDL = new DLDCRLateApprovalLog();
			IDataReader oReader;
			try
			{
				oReader = oDL.GetDCRLateApprovalLog(nID);
				if (oReader.Read())
				{
					oDCRLateApprovalLog = ReaderToObject(oReader);
				}
				oReader.Close();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oDCRLateApprovalLog;
		}
	}
}
