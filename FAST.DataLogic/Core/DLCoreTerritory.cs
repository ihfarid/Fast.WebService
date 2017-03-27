using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
	public partial class DLTerritory: DAAccess
	{
		public void Insert(Territory oItem)
		{
			string sSQL = "";
			try
			{
                oItem.ID.SetID(GeneratePrimaryKey("[OrderCollectionSystem].[dbo].[Territory]", "TerritoryID"));
                sSQL = SQL.MakeSQL(@"INSERT INTO [OrderCollectionSystem].[dbo].[Territory](TerritoryID, TerritoryCode, TerritoryName, ParentID, WorkAreaID, MobileNo, BeginningDate, EndDate, IsActive) "
				+ " VALUES(%n, %s, %s, %n, %n, %s, %d, %d, %b) "
				, oItem.ID.ToInt32, oItem.TerritoryCode,oItem.TerritoryName,oItem.ParentID,oItem.WorkAreaID,oItem.MobileNo,oItem.BeginningDate,oItem.EndDate,oItem.IsActive);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(Territory oItem)
		{
			string sSQL = "";
			try
			{
                sSQL = SQL.MakeSQL("UPDATE [OrderCollectionSystem].[dbo].[Territory] SET , TerritoryCode = %s, TerritoryName = %s, ParentID = %n, WorkAreaID = %n, MobileNo = %s, BeginningDate = %d, EndDate = %d, IsActive = %b WHERE [TerritoryID]=%n"
				,oItem.TerritoryCode,oItem.TerritoryName,oItem.ParentID,oItem.WorkAreaID,oItem.MobileNo,oItem.BeginningDate,oItem.EndDate,oItem.IsActive, oItem.ID.ToInt32);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nTerritoryID)
		{
			string sSQL = "";
			try
			{
                sSQL = SQL.MakeSQL("DELETE FROM [OrderCollectionSystem].[dbo].[Territory] WHERE [TerritoryID]=%n"
				, nTerritoryID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetTerritory(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
                sSQL = SQL.MakeSQL("SELECT * FROM [OrderCollectionSystem].[dbo].[Territory] WHERE TerritoryID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}

		public IDataReader GetTerritorys()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
                sSQL = SQL.MakeSQL("SELECT * FROM [OrderCollectionSystem].[dbo].[Territory]");
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
