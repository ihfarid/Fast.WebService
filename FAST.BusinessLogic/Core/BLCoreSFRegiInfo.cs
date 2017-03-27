using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core;
using FAST.Core.DataAccess;

namespace FAST.BusinessLogic
{
	public partial class BLSFRegiInfo
	{
        private SFRegiInfo ReaderToObject(IDataReader oReader)
        {

            SFRegiInfo oItem = new SFRegiInfo();
            oItem.ID.SetID(oReader["SFRegiID"]);
            oItem.GDDBID = oReader["GDDBID"].ToString();
            oItem.EmployeeID = Convert.ToInt32(oReader["EmployeeID"]);
            oItem.TerritoryID = Convert.ToInt32(oReader["TerritoryID"]);
            oItem.SecQuesID = Convert.ToInt32(oReader["SecQuesID"]);
            oItem.SecQuesAns = oReader["SecQuesAns"].ToString();
            oItem.PassWord = DAAccess.Decrypt(oReader["PassWord"].ToString());
            oItem.Message = oReader["Message"].ToString();
            oItem.Mobile = oReader["Mobile"].ToString();
            oItem.EntryDate = Convert.ToDateTime(oReader["EntryDate"]);
            oItem.LastUpdateDate = Convert.ToDateTime(oReader["LastUpdateDate"]);
            oItem.Version = Convert.ToInt32(oReader["Version"]);
            oItem.CommandVersion = Convert.ToInt32(oReader["CommandVersion"]);
            oItem.CustomerVersion = Convert.ToInt32(oReader["CustomerVersion"]);
            oItem.ProductVersion = Convert.ToInt32(oReader["ProductVersion"]);
            oItem.ProductBarVersion = Convert.ToInt32(oReader["ProductBarVersion"]);
            oItem.OrderVersion = Convert.ToInt32(oReader["OrderVersion"]);
            oItem.AppConfigVersion = Convert.ToInt32(oReader["AppConfigVersion"]);
            oItem.SalesReportVersion = Convert.ToInt32(oReader["SalesReportVersion"]);
            oItem.AppVersion = Convert.ToInt32(oReader["AppVersion"]);
            if (!oReader["BU"].Equals(DBNull.Value))
            {
                oItem.BU = oReader["BU"].ToString();
            }
            oItem.IsActive = Convert.ToBoolean(oReader["IsActive"]);
            return oItem;
        }
		
		private SFRegiInfos ReaderToObjects(IDataReader oReader)
		{
            SFRegiInfos oItems;
            SFRegiInfo oItem;
             try
                {
			
			oItems = new SFRegiInfos();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
                }
             catch (Exception ex)
             {
                 oReader.Close();
                 throw new Exception(ex.Message);
             }
			return oItems;

		}
		public SFRegiInfos GetSFRegiInfos()
		{
			SFRegiInfos oSFRegiInfos;
			DLSFRegiInfo oDL = new DLSFRegiInfo();
			try
			{
				oSFRegiInfos = ReaderToObjects(oDL.GetSFRegiInfos());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oSFRegiInfos;
		}
		public SFRegiInfo GetSFRegiInfo(int nID)
		{
			SFRegiInfo oSFRegiInfo = new SFRegiInfo();
			DLSFRegiInfo oDL = new DLSFRegiInfo();
			IDataReader oReader = null ;
			try
			{
                
				oReader = oDL.GetSFRegiInfo(nID);
				if (oReader.Read())
				{
					oSFRegiInfo = ReaderToObject(oReader);
				}
				oReader.Close();
			}
			catch (Exception e)
			{
                oReader.Close();

				throw new Exception(e.Message);
			}
			return oSFRegiInfo;
		}

        public SFRegiInfo GetSFInfo(string sGDDBID, string sConnectionString)
        {

            DataTable oTable = new DataTable();
            SFRegiInfo oItem = new SFRegiInfo();
            try
            {
                oTable = GetSFInfoByGDDBID(sGDDBID, sConnectionString);

                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem.ID.SetID(oRow["SFRegiID"]);
                    oItem.GDDBID = oRow["GDDBID"].ToString();
                    oItem.EmployeeID = Convert.ToInt32(oRow["EmployeeID"]);
                    oItem.TerritoryID = Convert.ToInt32(oRow["TerritoryID"]);
                    oItem.SecQuesID = Convert.ToInt32(oRow["SecQuesID"]);
                    oItem.SecQuesAns = oRow["SecQuesAns"].ToString();
                    oItem.PassWord = DAAccess.Decrypt(oRow["PassWord"].ToString());
                    oItem.Message = oRow["Message"].ToString();
                    oItem.Mobile = oRow["Mobile"].ToString();
                    oItem.EntryDate = Convert.ToDateTime(oRow["EntryDate"]);
                    oItem.LastUpdateDate = Convert.ToDateTime(oRow["LastUpdateDate"]);
                    oItem.Version = Convert.ToInt32(oRow["Version"]);
                    oItem.CommandVersion = Convert.ToInt32(oRow["CommandVersion"]);
                    oItem.CustomerVersion = Convert.ToInt32(oRow["CustomerVersion"]);
                    oItem.ProductVersion = Convert.ToInt32(oRow["ProductVersion"]);
                    oItem.ProductBarVersion = Convert.ToInt32(oRow["ProductBarVersion"]);
                    oItem.OrderVersion = Convert.ToInt32(oRow["OrderVersion"]);
                    oItem.AppConfigVersion = Convert.ToInt32(oRow["AppConfigVersion"]);
                    oItem.SalesReportVersion = Convert.ToInt32(oRow["SalesReportVersion"]);
                    oItem.AppVersion = Convert.ToInt32(oRow["AppVersion"]);
                    if (!oRow["BU"].Equals(DBNull.Value))
                    {
                        oItem.BU = oRow["BU"].ToString();
                    }
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
