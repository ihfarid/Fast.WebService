using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
	public partial class DLEmployeeInfo: DAAccess
	{
		public void Insert(EmployeeInfo oItem)
		{
			string sSQL = "";
			try
			{
                oItem.ID.SetID(GeneratePrimaryKey("[OrderCollectionSystem].[dbo].[EmployeeInfo]", "EmployeeID"));
                sSQL = SQL.MakeSQL("INSERT INTO [OrderCollectionSystem].[dbo].[EmployeeInfo](EmployeeID, EmpCode, Name, GDDBID, TerritoryID, MobileNo, BeginningDate, EndDate, IsActive, BU) "
                + " VALUES(%n, %s, %s, %s, %n, %s, %d, %d, %b, %s) "
                , oItem.ID.ToInt32, oItem.EmpCode, oItem.Name, oItem.GDDBID, oItem.TerritoryID, oItem.MobileNo, oItem.BeginningDate, oItem.EndDate, oItem.IsActive, oItem.BU);
                ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(EmployeeInfo oItem)
		{
			string sSQL = "";
			try
			{
                sSQL = SQL.MakeSQL("UPDATE [OrderCollectionSystem].[dbo].[EmployeeInfo] SET EmpCode = %s, Name = %s, GDDBID = %s, TerritoryID = %n, MobileNo = %s, BeginningDate = %d, EndDate = %d, IsActive = %b, BU = %s WHERE [EmployeeID]=%n"
                , oItem.EmpCode, oItem.Name, oItem.GDDBID, oItem.TerritoryID, oItem.MobileNo, oItem.BeginningDate, oItem.EndDate, oItem.IsActive, oItem.BU, oItem.ID.ToInt32);
                ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nEmployeeInfoID)
		{
			string sSQL = "";
			try
			{
                sSQL = SQL.MakeSQL("DELETE FROM [OrderCollectionSystem].[dbo].[EmployeeInfo] WHERE [EmployeeID]=%n"
				, nEmployeeInfoID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetEmployeeInfo(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
                sSQL = SQL.MakeSQL("SELECT * FROM [OrderCollectionSystem].[dbo].[EmployeeInfo] WHERE EmployeeID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetEmployeeInfos()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
                sSQL = SQL.MakeSQL("SELECT * FROM [OrderCollectionSystem].[dbo].[EmployeeInfo] ");
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}

        public string GetGDDBIDByTerritoryID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sTerritoryID)
        {
            string sGDDBID = "";
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SElECT [GDDBID] FROM [OrderCollectionSystem].[dbo].[EmployeeInfo] a INNER JOIN [OrderCollectionSystem].[dbo].[Territory] b ON a.TerritoryID=b.TerritoryID WHERE b.TerritoryCode= %s and a.IsActive=%n", sTerritoryID, 1);
                //sSQL = SQL.MakeSQL("SElECT [GDDBID] FROM [EmployeeInfo] a INNER JOIN [TempTerritory] b ON a.TerritoryID=b.TerritoryID WHERE b.TerritoryCode= %s and a.IsActive=%n", sTerritoryID, 1);
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    sGDDBID = "";
                }
                else
                {
                    sGDDBID = Convert.ToString(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return sGDDBID;
        }
	}
}
