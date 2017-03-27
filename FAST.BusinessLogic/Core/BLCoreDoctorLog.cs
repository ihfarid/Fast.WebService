using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;

namespace FAST.BusinessLogic
{
	public partial class BLDoctorLog
	{
        private DoctorLog ReaderToObject(IDataReader oReader)
        {
            DoctorLog oItem = new DoctorLog();
            oItem.ID.SetID(oReader["DoctorLogID"]);
            if (!oReader["DoctorUpdateReqID"].Equals(DBNull.Value))
            {
                oItem.DoctorUpdateReqID = Convert.ToInt32(oReader["DoctorUpdateReqID"]);
            }
            if (!oReader["DoctorTerritoryMappingID"].Equals(DBNull.Value))
            {
                oItem.DoctorTerritoryMappingID = Convert.ToInt32(oReader["DoctorTerritoryMappingID"]);
            }
            oItem.DocID = Convert.ToInt32(oReader["DocID"]);
            oItem.TerritoryID = oReader["TerritoryID"].ToString();
            if (!oReader["TransferReason"].Equals(DBNull.Value))
            {
                oItem.TransferReason = oReader["TransferReason"].ToString();
            }
            if (!oReader["Status"].Equals(DBNull.Value))
            {
                oItem.Status = Convert.ToInt32(oReader["Status"]);
            }
            if (!oReader["Type"].Equals(DBNull.Value))
            {
                oItem.Type = Convert.ToInt32(oReader["Type"]);
            }
            if (!oReader["CreationDate"].Equals(DBNull.Value))
            {
                oItem.CreationDate = Convert.ToDateTime(oReader["CreationDate"]);
            }
            if (!oReader["CreatedBy"].Equals(DBNull.Value))
            {
                oItem.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
            }
            if (!oReader["ModifiedDateRM"].Equals(DBNull.Value))
            {
                oItem.ModifiedDateRM = Convert.ToDateTime(oReader["ModifiedDateRM"]);
            }
            if (!oReader["ModifiedByRM"].Equals(DBNull.Value))
            {
                oItem.ModifiedByRM = Convert.ToInt32(oReader["ModifiedByRM"]);
            }
            if (!oReader["ModifiedDateSFE"].Equals(DBNull.Value))
            {
                oItem.ModifiedDateSFE = Convert.ToDateTime(oReader["ModifiedDateSFE"]);
            }
            if (!oReader["ModifiedBySFE"].Equals(DBNull.Value))
            {
                oItem.ModifiedBySFE = Convert.ToInt32(oReader["ModifiedBySFE"]);
            }
            if (!oReader["Action"].Equals(DBNull.Value))
            {
                oItem.Action = Convert.ToInt32(oReader["Action"]);
            }
            if (!oReader["Version"].Equals(DBNull.Value))
            {
                oItem.Version = Convert.ToInt32(oReader["Version"]);
            }
            return oItem;
        }
		
		private DoctorLogs ReaderToObjects(IDataReader oReader)
		{
			DoctorLogs oItems;
			DoctorLog oItem;
			oItems = new DoctorLogs();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
			return oItems;
		}
		public DoctorLogs GetDoctorLogs()
		{
			DoctorLogs oDoctorLogs;
			DLDoctorLog oDL = new DLDoctorLog();
			try
			{
				oDoctorLogs = ReaderToObjects(oDL.GetDoctorLogs());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oDoctorLogs;
		}
		public DoctorLog GetDoctorLog(int nID)
		{
			DoctorLog oDoctorLog = new DoctorLog();
			DLDoctorLog oDL = new DLDoctorLog();
			IDataReader oReader;
			try
			{
				oReader = oDL.GetDoctorLog(nID);
				if (oReader.Read())
				{
					oDoctorLog = ReaderToObject(oReader);
				}
				oReader.Close();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oDoctorLog;
		}

        public DoctorLog GetDocotorLog(DataRow oRow)
        {
            DataTable oTable = new DataTable();
            DoctorLog oItem = new DoctorLog();
            try
            {
                oItem.ID.SetID(oRow["DoctorLogID"]);
                oItem.DoctorLogID = Convert.ToInt32(oRow["DoctorLogID"]);
                if (!oRow["DoctorUpdateReqID"].Equals(DBNull.Value))
                {
                    oItem.DoctorUpdateReqID = Convert.ToInt32(oRow["DoctorUpdateReqID"]);
                }
                if (!oRow["DoctorTerritoryMappingID"].Equals(DBNull.Value))
                {
                    oItem.DoctorTerritoryMappingID = Convert.ToInt32(oRow["DoctorTerritoryMappingID"]);
                }
                oItem.DocID = Convert.ToInt32(oRow["DocID"]);
                oItem.TerritoryID = oRow["TerritoryID"].ToString();
                if (!oRow["TransferReason"].Equals(DBNull.Value))
                {
                    oItem.TransferReason = oRow["TransferReason"].ToString();
                }
                if (!oRow["Status"].Equals(DBNull.Value))
                {
                    oItem.Status = Convert.ToInt32(oRow["Status"]);
                }
                if (!oRow["Type"].Equals(DBNull.Value))
                {
                    oItem.Type = Convert.ToInt32(oRow["Type"]);
                }
                if (!oRow["CreationDate"].Equals(DBNull.Value))
                {
                    oItem.CreationDate = Convert.ToDateTime(oRow["CreationDate"]);
                }
                if (!oRow["CreatedBy"].Equals(DBNull.Value))
                {
                    oItem.CreatedBy = Convert.ToInt32(oRow["CreatedBy"]);
                }
                if (!oRow["ModifiedDateRM"].Equals(DBNull.Value))
                {
                    oItem.ModifiedDateRM = Convert.ToDateTime(oRow["ModifiedDateRM"]);
                }
                if (!oRow["ModifiedByRM"].Equals(DBNull.Value))
                {
                    oItem.ModifiedByRM = Convert.ToInt32(oRow["ModifiedByRM"]);
                }
                if (!oRow["ModifiedDateSFE"].Equals(DBNull.Value))
                {
                    oItem.ModifiedDateSFE = Convert.ToDateTime(oRow["ModifiedDateSFE"]);
                }
                if (!oRow["ModifiedBySFE"].Equals(DBNull.Value))
                {
                    oItem.ModifiedBySFE = Convert.ToInt32(oRow["ModifiedBySFE"]);
                }
                if (!oRow["Action"].Equals(DBNull.Value))
                {
                    oItem.Action = Convert.ToInt32(oRow["Action"]);
                }
                if (!oRow["Version"].Equals(DBNull.Value))
                {
                    oItem.Version = Convert.ToInt32(oRow["Version"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public DoctorLog GetDocotorLogTemp(DataRow oRow)
        {
            DataTable oTable = new DataTable();
            DoctorLog oItem = new DoctorLog();
            try
            {
                oItem.ID.SetID(oRow["DoctorLogID"]);
                oItem.DoctorLogID = Convert.ToInt32(oRow["DoctorLogID"]);
                if (!oRow["DoctorUpdateReqID"].Equals(DBNull.Value))
                {
                    oItem.DoctorTerritoryMappingID = Convert.ToInt32(oRow["DoctorUpdateReqID"]);
                }
                if (!oRow["DoctorTerritoryMappingID"].Equals(DBNull.Value))
                {
                    oItem.DoctorUpdateReqID = Convert.ToInt32(oRow["DoctorTerritoryMappingID"]);
                }
                oItem.DocID = Convert.ToInt32(oRow["DocID"]);
                oItem.TerritoryID = oRow["TerritoryID"].ToString();
                if (!oRow["TransferReason"].Equals(DBNull.Value))
                {
                    oItem.TransferReason = oRow["TransferReason"].ToString();
                }
                if (!oRow["Status"].Equals(DBNull.Value))
                {
                    oItem.Status = Convert.ToInt32(oRow["Status"]);
                }
                if (!oRow["Type"].Equals(DBNull.Value))
                {
                    oItem.Type = Convert.ToInt32(oRow["Type"]);
                }
                if (!oRow["CreationDate"].Equals(DBNull.Value))
                {
                    oItem.CreationDate = Convert.ToDateTime(oRow["CreationDate"]);
                }
                if (!oRow["CreatedBy"].Equals(DBNull.Value))
                {
                    oItem.CreatedBy = Convert.ToInt32(oRow["CreatedBy"]);
                }
                if (!oRow["ModifiedDate"].Equals(DBNull.Value))
                {
                    oItem.ModifiedDateRM = Convert.ToDateTime(oRow["ModifiedDate"]);
                }
                if (!oRow["ModifiedBy"].Equals(DBNull.Value))
                {
                    oItem.ModifiedByRM = Convert.ToInt32(oRow["ModifiedBy"]);
                }
                if (!oRow["Action"].Equals(DBNull.Value))
                {
                    oItem.Action = Convert.ToInt32(oRow["Action"]);
                }
                if (!oRow["Version"].Equals(DBNull.Value))
                {
                    oItem.Version = Convert.ToInt32(oRow["Version"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public DoctorLog GetDocotorLog(int nDoctorLogID, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            DoctorLog oItem = new DoctorLog();
            try
            {
                oTable = GetDocotorLogInfo(nDoctorLogID, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem = GetDocotorLog(oRow);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public DoctorLogs GetDocotorLogs(int nDoctorLogID, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            DoctorLog oItem = new DoctorLog();
            DoctorLogs oItems = new DoctorLogs();
            try
            {
                oTable = GetDocotorLogInfo(nDoctorLogID, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new DoctorLog();
                        oItem = GetDocotorLog(oRow);
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

        public DoctorLogs GetDocotorLogInfosForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            DoctorLog oItem = new DoctorLog();
            DoctorLogs oItems = new DoctorLogs();
            try
            {
                oTable = GetDocotorLogInfoForRM(sTerritoryID, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new DoctorLog();
                        oItem = GetDocotorLog(oRow);
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

        public DoctorLogs GetDocotorLogInfosForRMTemp(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            DoctorLog oItem = new DoctorLog();
            DoctorLogs oItems = new DoctorLogs();
            try
            {
                oTable = GetDocotorLogInfoForRM(sTerritoryID, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new DoctorLog();
                        oItem = GetDocotorLogTemp(oRow);
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
