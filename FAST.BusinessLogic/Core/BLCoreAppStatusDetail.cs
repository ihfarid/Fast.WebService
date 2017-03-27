using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;

namespace FAST.BusinessLogic
{
	public partial class BLAppStatusDetail
	{
        private AppStatusDetail ReaderToObject(IDataReader oReader)
        {
            AppStatusDetail oItem = new AppStatusDetail();
            oItem.ID.SetID(oReader["AppStatusID"]);
            oItem.TerritoryID = oReader["TerritoryID"].ToString();
            oItem.AppVersion = Convert.ToInt32(oReader["AppVersion"]);
            oItem.StorageSpace = oReader["StorageSpace"].ToString();
            oItem.UsedSpace = oReader["UsedSpace"].ToString();
            oItem.FreeSpace = oReader["FreeSpace"].ToString();
            oItem.VideoData = oReader["VideoData"].ToString();
            oItem.MusicData = oReader["MusicData"].ToString();
            oItem.InternetAvailable = oReader["InternetAvailable"].ToString();
            oItem.DataConnection = oReader["DataConnection"].ToString();
            oItem.WiFiConnection = oReader["WiFiConnection"].ToString();
            oItem.GPS = oReader["GPS"].ToString();
            oItem.Latitude = Convert.ToDouble(oReader["Latitude"]);
            oItem.Longitude = Convert.ToDouble(oReader["Longitude"]);
            oItem.LastUpdatedDate = Convert.ToDateTime(oReader["LastUpdatedDate"]);
            return oItem;
        }

		private AppStatusDetails ReaderToObjects(IDataReader oReader)
		{
			AppStatusDetails oItems;
			AppStatusDetail oItem;
			oItems = new AppStatusDetails();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
			return oItems;
		}
		public AppStatusDetails GetAppStatusDetails()
		{
			AppStatusDetails oAppStatusDetails;
			DLAppStatusDetail oDL = new DLAppStatusDetail();
			try
			{
				oAppStatusDetails = ReaderToObjects(oDL.GetAppStatusDetails());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oAppStatusDetails;
		}
		public AppStatusDetail GetAppStatusDetail(int nID)
		{
			AppStatusDetail oAppStatusDetail = new AppStatusDetail();
			DLAppStatusDetail oDL = new DLAppStatusDetail();
			IDataReader oReader;
			try
			{
				oReader = oDL.GetAppStatusDetail(nID);
				if (oReader.Read())
				{
					oAppStatusDetail = ReaderToObject(oReader);
				}
				oReader.Close();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oAppStatusDetail;
		}
	}
}
