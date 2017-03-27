using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core.DataAccess;

namespace FAST.DataLogic
{
	public partial class DLAppVersionInfo: DAAccess
	{
		public void Insert(AppVersionInfo oItem)
		{
			string sSQL = "";
			try
			{
				oItem.ID.SetID(GeneratePrimaryKey("[AppVersionInfo]", "VersionNo"));
                sSQL = SQL.MakeSQL("INSERT INTO [AppVersionInfo](VersionNo, AppURL, AppType, ReleaseDate) "
                + " VALUES(%n, %s,  %s, %d) "
				, oItem.ID.ToInt32, oItem.AppURL,oItem.ReleaseDate);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(AppVersionInfo oItem)
		{
			string sSQL = "";
			try
			{
                sSQL = SQL.MakeSQL("UPDATE [AppVersionInfo] SET , AppURL = %s, AppType = %s, ReleaseDate = %d WHERE [VersionNo]=%n"
				,oItem.AppURL,oItem.ReleaseDate, oItem.ID.ToInt32);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nAppVersionInfoID)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("DELETE FROM [AppVersionInfo] WHERE [VersionNo]=%n"
				, nAppVersionInfoID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetAppVersionInfo(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [AppVersionInfo] WHERE VersionNo=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetAppVersionInfos()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [AppVersionInfo] ");
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
	}
}
