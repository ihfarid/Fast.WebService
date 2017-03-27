using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core.DataAccess;

namespace FAST.DataLogic
{
	public partial class DLSampleTerritoryMapping: DAAccess
	{
		public void Insert(SampleTerritoryMapping oItem)
		{
			string sSQL = "";
			try
			{
                oItem.ID.SetID(GeneratePrimaryKey("[SampleTerritoryMapping]", "SampleTerritoryMapID"));
                sSQL = SQL.MakeSQL("INSERT INTO [SampleTerritoryMapping](SampleTerritoryMapID, SampleID, TerritoryCode, BrandName, SampleName, Month, Year, Version, Action) "
                + " VALUES(%n, %n, %s, %s, %s, %n, %n, %n, %n) "
                , oItem.ID.ToInt32, oItem.SampleID, oItem.TerritoryCode, oItem.BrandName, oItem.SampleName, oItem.Month, oItem.Year, oItem.Version, oItem.Action);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(SampleTerritoryMapping oItem)
		{
			string sSQL = "";
			try
			{
                sSQL = SQL.MakeSQL("UPDATE [SampleTerritoryMapping] SET SampleID = %n, TerritoryCode = %s, BrandName = %s, SampleName = %s, Month = %n, Year = %n, Version = %n, Action = %n WHERE [SampleTerritoryMapID]=%n"
                , oItem.SampleID, oItem.TerritoryCode, oItem.BrandName, oItem.SampleName, oItem.Month, oItem.Year, oItem.Version, oItem.Action, oItem.ID.ToInt32);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nSampleTerritoryMappingID)
		{
			string sSQL = "";
			try
			{
                sSQL = SQL.MakeSQL("DELETE FROM [SampleTerritoryMapping] WHERE [SampleTerritoryMapID]=%n"
				, nSampleTerritoryMappingID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetSampleTerritoryMapping(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
                sSQL = SQL.MakeSQL("SELECT * FROM [SampleTerritoryMapping] WHERE SampleTerritoryMapID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetSampleTerritoryMappings()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [SampleTerritoryMapping] ");
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
