using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;

namespace FAST.BusinessLogic
{
	public partial class BLPVPExceptionLog
	{
        private PVPExceptionLog ReaderToObject(IDataReader oReader)
        {
            PVPExceptionLog oItem = new PVPExceptionLog();
            oItem.ID.SetID(oReader["ExceptionID"]);
            oItem.TerritoryID = oReader["TerritoryID"].ToString();
            oItem.GDDBID = oReader["GDDBID"].ToString();
            oItem.PVPDetail = oReader["PVPDetail"].ToString();
            oItem.NoOfPlannedDay = Convert.ToInt32(oReader["NoOfPlannedDay"]);
            oItem.ExceptionDetail = oReader["ExceptionDetail"].ToString();
            oItem.ExceptionDateTime = Convert.ToDateTime(oReader["ExceptionDateTime"]);
            return oItem;
        }
		private PVPExceptionLogs ReaderToObjects(IDataReader oReader)
		{
			PVPExceptionLogs oItems;
			PVPExceptionLog oItem;
			oItems = new PVPExceptionLogs();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
			return oItems;
		}
		public PVPExceptionLogs GetPVPExceptionLogs()
		{
			PVPExceptionLogs oPVPExceptionLogs;
			DLPVPExceptionLog oDL = new DLPVPExceptionLog();
			try
			{
				oPVPExceptionLogs = ReaderToObjects(oDL.GetPVPExceptionLogs());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oPVPExceptionLogs;
		}
		public PVPExceptionLog GetPVPExceptionLog(int nID)
		{
			PVPExceptionLog oPVPExceptionLog = new PVPExceptionLog();
			DLPVPExceptionLog oDL = new DLPVPExceptionLog();
			IDataReader oReader;
			try
			{
				oReader = oDL.GetPVPExceptionLog(nID);
				if (oReader.Read())
				{
					oPVPExceptionLog = ReaderToObject(oReader);
				}
				oReader.Close();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oPVPExceptionLog;
		}
	}
}
