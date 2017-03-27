using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;

namespace FAST.BusinessLogic
{
	public partial class BLAppVersionInfo
	{
		private AppVersionInfo ReaderToObject(IDataReader oReader)
		{
			AppVersionInfo oItem = new AppVersionInfo();
			oItem.ID.SetID(oReader["VersionNo"]);
oItem.AppURL = oReader["AppURL"].ToString();
oItem.AppType = oReader["AppType"].ToString();
oItem.ReleaseDate =Convert.ToDateTime( oReader["ReleaseDate"]);
			return oItem;
		}
		private AppVersionInfos ReaderToObjects(IDataReader oReader)
		{
			AppVersionInfos oItems;
			AppVersionInfo oItem;
			oItems = new AppVersionInfos();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
			return oItems;
		}
		public AppVersionInfos GetAppVersionInfos()
		{
			AppVersionInfos oAppVersionInfos;
			DLAppVersionInfo oDL = new DLAppVersionInfo();
			try
			{
				oAppVersionInfos = ReaderToObjects(oDL.GetAppVersionInfos());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oAppVersionInfos;
		}
		public AppVersionInfo GetAppVersionInfo(int nID)
		{
			AppVersionInfo oAppVersionInfo = new AppVersionInfo();
			DLAppVersionInfo oDL = new DLAppVersionInfo();
			IDataReader oReader;
			try
			{
				oReader = oDL.GetAppVersionInfo(nID);
				if (oReader.Read())
				{
					oAppVersionInfo = ReaderToObject(oReader);
				}
				oReader.Close();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oAppVersionInfo;
		}
	}
}
