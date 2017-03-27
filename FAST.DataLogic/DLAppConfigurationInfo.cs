using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
	public partial class DLAppConfigurationInfo: DAAccess
	{
        public DataTable GetAppConfigInfo()
        {

            string sSQL = "";
            DataTable oTable = new DataTable();
            try
            {
                sSQL = SQL.MakeSQL("SELECT TOP 1 a.AppConfigID, b.StartDate, b.EndDate, a.SmsNo, b.Month, b.Year, a.DCREntryHours, a.DCRApprovalHours, a.Version, a.Action"
                + " FROM [AppConfigurationInfo] a INNER JOIN [PVPMonthCycle] b ON a.CycleID = b.CycleID ");
                oTable = FillDataTable(sSQL, "SFRegInfo");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public DataTable GetAppConfigInfo(string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                sSQL = SQL.MakeSQL("SELECT TOP 1 a.AppConfigID, b.StartDate, b.EndDate, a.SmsNo, b.Month, b.Year, a.DCREntryHours, a.DCRApprovalHours, c.IsLocked, a.Version, a.Action"
                + " FROM [AppConfigurationInfo] a INNER JOIN [PVPMonthCycle] b ON a.CycleID = b.CycleID");
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public DataTable GetAppConfigInfoForRM(string sTerritoryID, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                sSQL = SQL.MakeSQL("SELECT a.AppConfigID, a.PVPStartDate, a.PVPEndDate, a.SmsNo, b.Month, b.Year, a.DCREntryHours, a.DCRApprovalHours, c.IsLocked, a.Version, a.Action"
                + " FROM [AppConfigurationInfo] a INNER JOIN [PVPMonthCycle] b ON a.CycleID = b.CycleID INNER JOIN [TerritoryDMRMapping] c ON c.TerritoryID=a.TerritoryID WHERE a.TerritoryID=%s", sTerritoryID);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }



        public DataTable GetAppConfigInfo(string sTerritoryID, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                sSQL = SQL.MakeSQL("SELECT a.AppConfigID, a.PVPStartDate, a.PVPEndDate, a.SmsNo, b.Month, b.Year,c.TargetDoctor,a.DCREntryHours, a.DCRApprovalHours, d.IsLocked, a.Version, a.Action,e.IsSwajanStatus,e.IsProfile,"
                                    + "e.IsRoute,e.IsSession,e.IsDocTypeId,e.IsCallFrequency,e.IsProd1,e.IsProd2,e.IsProd3,e.IsProd4,e.IsProd5,e.IsProd6,e.IsProd7,e.IsProd8 FROM [AppConfigurationInfo] a INNER JOIN [PVPMonthCycle] b ON "
                                    + "a.CycleID = b.CycleID INNER JOIN [TerritoryDMRMapping] d ON d.TerritoryID=a.TerritoryID INNER JOIN [TerrWiseTargetDoc] c ON c.Territory=d.[TerritoryID] INNER JOIN [TerrWiseConfiguration] e ON e.[TerritoryID]=d.[TerritoryID] Where a.TerritoryID=%s", sTerritoryID);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public IDataReader GetAppConfigurationInfo()
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                sSQL = SQL.MakeSQL("SELECT * FROM [AppConfigurationInfo]");
                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }

        public DataTable GetAppConfigurationInfo(string sTerritoryID, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                sSQL = SQL.MakeSQL("SELECT * FROM [AppConfigurationInfo] WHERE TerritoryID=%s", sTerritoryID);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }
		//public bool IsDuplicate(string sAppConfigurationInfoName)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [AppConfigurationInfo] WHERE AppConfigurationInfoName=%s ", sAppConfigurationInfoName);
				//oCount = ExecuteScalar(sSQL);
				//if (Convert.ToInt32(oCount) > 0)
				//{
					//return true;
					//}
				//else
				//{
					//return false;
				//}
			//}
			//catch (Exception e)
				//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sAppConfigurationInfoName, int nID)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [AppConfigurationInfo] WHERE AppConfigurationInfoName=%s AND AppConfigID!= %n ", sAppConfigurationInfoName, nID);
				//oCount = ExecuteScalar(sSQL);
				//if (Convert.ToInt32(oCount) > 0)
				//{
					//return true;
				//}
				//else
				//{
					//return false;
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public IDataReader GetAppConfigurationInfo(string sAppConfigurationInfoName)
		//{
			//string sSQL = "";
			//IDataReader oReader;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT * FROM [AppConfigurationInfo] WHERE [AppConfigurationInfoName]=%s ", sAppConfigurationInfoName);
				//oReader = ExecuteReader(sSQL);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
			//return oReader;
		//}
	}
}
