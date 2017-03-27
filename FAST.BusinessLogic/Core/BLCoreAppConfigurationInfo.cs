using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;

namespace FAST.BusinessLogic
{
	public partial class BLAppConfigurationInfo
	{
        private AppConfigurationInfo ReaderToObject(IDataReader oReader)
        {
            AppConfigurationInfo oItem = new AppConfigurationInfo();
            oItem.ID.SetID(oReader["AppConfigID"]);
            if (!oReader["TerritoryID"].Equals(DBNull.Value))
            {
                oItem.TerritoryID = oReader["TerritoryID"].ToString();
            }
            if (!oReader["CycleID"].Equals(DBNull.Value))
            {
                oItem.CycleID = Convert.ToInt32(oReader["CycleID"]);
            }
            if (!oReader["SmsNo"].Equals(DBNull.Value))
            {
                oItem.SmsNo = oReader["SmsNo"].ToString();
            }
            oItem.PVPStartDate = Convert.ToDateTime(oReader["PVPStartDate"]);
            oItem.PVPEndDate = Convert.ToDateTime(oReader["PVPEndDate"]);
            if (!oReader["DCREntryHours"].Equals(DBNull.Value))
            {
                oItem.DCREntryHours = Convert.ToInt32(oReader["DCREntryHours"]);
            }
            if (!oReader["DCRApprovalHours"].Equals(DBNull.Value))
            {
                oItem.DCRApprovalHours = Convert.ToInt32(oReader["DCRApprovalHours"]);
            }
            if (!oReader["Version"].Equals(DBNull.Value))
            {
                oItem.Version = Convert.ToInt32(oReader["Version"]);
            }
            if (!oReader["Action"].Equals(DBNull.Value))
            {
                oItem.Action = Convert.ToInt32(oReader["Action"]);
            }
            return oItem;
        }
		private AppConfigurationInfos ReaderToObjects(IDataReader oReader)
		{
			AppConfigurationInfos oItems;
			AppConfigurationInfo oItem;
			oItems = new AppConfigurationInfos();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
			return oItems;
		}
		public AppConfigurationInfos GetAppConfigurationInfos()
		{
			AppConfigurationInfos oAppConfigurationInfos;
			DLAppConfigurationInfo oDL = new DLAppConfigurationInfo();
			try
			{
				oAppConfigurationInfos = ReaderToObjects(oDL.GetAppConfigurationInfos());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oAppConfigurationInfos;
		}
		public AppConfigurationInfo GetAppConfigurationInfo(int nID)
		{
			AppConfigurationInfo oAppConfigurationInfo = new AppConfigurationInfo();
			DLAppConfigurationInfo oDL = new DLAppConfigurationInfo();
			IDataReader oReader;
			try
			{
				oReader = oDL.GetAppConfigurationInfo(nID);
				if (oReader.Read())
				{
					oAppConfigurationInfo = ReaderToObject(oReader);
				}
				oReader.Close();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oAppConfigurationInfo;
		}

        public AppConfigurationInfo GetAppConfigurationInfo(DataRow oRow)
        {
            DataTable oTable = new DataTable();
            AppConfigurationInfo oItem = new AppConfigurationInfo();
            try
            {
                oItem.ID.SetID(oRow["AppConfigID"]);
                if (!oRow["TerritoryID"].Equals(DBNull.Value))
                {
                    oItem.TerritoryID = oRow["TerritoryID"].ToString();
                }
                if (!oRow["CycleID"].Equals(DBNull.Value))
                {
                    oItem.CycleID = Convert.ToInt32(oRow["CycleID"]);
                }
                if (!oRow["SmsNo"].Equals(DBNull.Value))
                {
                    oItem.SmsNo = oRow["SmsNo"].ToString();
                }
                oItem.PVPStartDate = Convert.ToDateTime(oRow["PVPStartDate"]);
                oItem.PVPEndDate = Convert.ToDateTime(oRow["PVPEndDate"]);
                if (!oRow["DCREntryHours"].Equals(DBNull.Value))
                {
                    oItem.DCREntryHours = Convert.ToInt32(oRow["DCREntryHours"]);
                }
                if (!oRow["DCRApprovalHours"].Equals(DBNull.Value))
                {
                    oItem.DCRApprovalHours = Convert.ToInt32(oRow["DCRApprovalHours"]);
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

        public AppConfigurationInfo GetAppConfigurationInfo(string sTerritoryID, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            AppConfigurationInfo oItem = new AppConfigurationInfo();
            try
            {
                oTable = GetAppConfiguration(sTerritoryID, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem = GetAppConfigurationInfo(oRow);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        //public AppConfigurationInfos GetAppConfigurationInfos(string sConnectionString)
        //{
        //    DataTable oTable = new DataTable();
        //    AppConfigurationInfo oItem = new AppConfigurationInfo();
        //    AppConfigurationInfos oItems = new AppConfigurationInfos();
        //    try
        //    {
        //        oTable = GetAppConfiguration(sConnectionString);
        //        if (oTable.Rows.Count > 0)
        //        {
        //            foreach (DataRow oRow in oTable.Rows)
        //            {
        //                oItem = new AppConfigurationInfo();
        //                oItem = GetAppConfigurationInfo(oRow);
        //                oItems.Add(oItem);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return oItems;
        //}  
	}
}
