using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core.DataAccess;

namespace FAST.DataLogic
{
	public partial class DLBrandTerritoryMapping: DAAccess
	{
		public void Insert(BrandTerritoryMapping oItem)
		{
			string sSQL = "";
			try
			{
				oItem.ID.SetID(GeneratePrimaryKey("[BrandTerritoryMapping]", "BrandTerritoryMappingID"));
                sSQL = SQL.MakeSQL("INSERT INTO [BrandTerritoryMapping](BrandTerritoryMappingID, TerritoryID, Line, BrandID, BrandCode, BrandName, NoOfGuidedDr, Version, Action) "
                + " VALUES(%n, %s, %s, %n, %s, %s, %s, %n, %n) "
                , oItem.ID.ToInt32, oItem.TerritoryID, oItem.Line, oItem.BrandID, oItem.BrandCode, oItem.BrandName, oItem.NoOfGuidedDr, oItem.Version, oItem.Action);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(BrandTerritoryMapping oItem)
		{
			string sSQL = "";
			try
			{
                sSQL = SQL.MakeSQL("UPDATE [BrandTerritoryMapping] SET TerritoryID = %s, Line = %s, BrandID = %n,  BrandCode = %s, BrandName = %s, NoOfGuidedDr = %s, Version = %n, Action = %n WHERE [BrandTerritoryMappingID]=%n"
                , oItem.TerritoryID, oItem.Line, oItem.BrandID, oItem.BrandCode, oItem.BrandName, oItem.NoOfGuidedDr, oItem.Version, oItem.Action, oItem.ID.ToInt32);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nBrandTerritoryMappingID)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("DELETE FROM [BrandTerritoryMapping] WHERE [BrandTerritoryMappingID]=%n"
				, nBrandTerritoryMappingID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetBrandTerritoryMapping(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [BrandTerritoryMapping] WHERE BrandTerritoryMappingID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetBrandTerritoryMappings()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [BrandTerritoryMapping] ");
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
