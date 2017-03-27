using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core.DataAccess;

namespace FAST.DataLogic
{
	public partial class DLAppConfigurationInfo: DAAccess
	{
		public void Insert(AppConfigurationInfo oItem)
		{
			string sSQL = "";
			try
			{
				oItem.ID.SetID(GeneratePrimaryKey("[AppConfigurationInfo]", "AppConfigID"));
                sSQL = SQL.MakeSQL("INSERT INTO [AppConfigurationInfo](AppConfigID, TerritoryID, CycleID, SmsNo, PVPStartDate, PVPEndDate, DCREntryHours, DCRApprovalHours, Version, Action) "
                + " VALUES(%n, %s, %n, %s, %D, %D, %n, %n, %n, %n) "
                , oItem.ID.ToInt32, oItem.TerritoryID, oItem.CycleID, oItem.SmsNo, oItem.PVPStartDate, oItem.PVPEndDate, oItem.DCREntryHours, oItem.DCRApprovalHours, oItem.Version, oItem.Action);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(AppConfigurationInfo oItem)
		{
			string sSQL = "";
			try
			{
                sSQL = SQL.MakeSQL("UPDATE [AppConfigurationInfo] SET TerritoryID = %s, CycleID = %n, SmsNo = %s, PVPStartDate = %D, PVPEndDate = %D, DCREntryHours = %n, DCRApprovalHours = %n, Version = %n, Action = %n WHERE [AppConfigID]=%n"
                , oItem.TerritoryID, oItem.CycleID, oItem.SmsNo, oItem.PVPStartDate, oItem.PVPEndDate, oItem.DCREntryHours, oItem.DCRApprovalHours, oItem.Version, oItem.Action, oItem.ID.ToInt32);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nAppConfigurationInfoID)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("DELETE FROM [AppConfigurationInfo] WHERE [AppConfigID]=%n"
				, nAppConfigurationInfoID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetAppConfigurationInfo(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [AppConfigurationInfo] WHERE AppConfigID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetAppConfigurationInfos()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [AppConfigurationInfo] ");
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
