using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core.DataAccess;

namespace FAST.DataLogic
{
	public partial class DLGimmickTerritoryMapping: DAAccess
	{
		public void Insert(GimmickTerritoryMapping oItem)
		{
			string sSQL = "";
			try
			{
                oItem.ID.SetID(GeneratePrimaryKey("[GimmickTerritoryMapping]", "GimmickTerritoryMapID"));
                sSQL = SQL.MakeSQL("INSERT INTO [GimmickTerritoryMapping](GimmickTerritoryMapID, GimmickID, TerritoryCode, BrandName, GimmickName, Month, Year, Version, Action) "
                + " VALUES(%n, %n, %s, %s, %s, %n, %n, %n, %n) "
                , oItem.ID.ToInt32, oItem.GimmickID, oItem.TerritoryCode, oItem.BrandName, oItem.GimmickName, oItem.Month, oItem.Year, oItem.Version, oItem.Action);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(GimmickTerritoryMapping oItem)
		{
			string sSQL = "";
			try
			{
                sSQL = SQL.MakeSQL("UPDATE [GimmickTerritoryMapping] SET GimmickID = %n, TerritoryCode = %s, BrandName = %s, GimmickName = %s,  Month = %n, Year = %n, Version = %n, Action = %n WHERE [GimmickTerritoryMapID]=%n"
                , oItem.GimmickID, oItem.TerritoryCode, oItem.BrandName, oItem.GimmickName, oItem.Month, oItem.Year, oItem.Version, oItem.Action, oItem.ID.ToInt32);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nGimmickTerritoryMappingID)
		{
			string sSQL = "";
			try
			{
                sSQL = SQL.MakeSQL("DELETE FROM [GimmickTerritoryMapping] WHERE [GimmickTerritoryMapID]=%n"
				, nGimmickTerritoryMappingID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetGimmickTerritoryMapping(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
                sSQL = SQL.MakeSQL("SELECT * FROM [GimmickTerritoryMapping] WHERE GimmickTerritoryMapID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetGimmickTerritoryMappings()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [GimmickTerritoryMapping] ");
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
