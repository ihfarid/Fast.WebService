using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core.DataAccess;

namespace FAST.DataLogic
{
	public partial class DLNationalHoliday: DAAccess
	{
		public void Insert(NationalHoliday oItem)
		{
			string sSQL = "";
			try
			{
				oItem.ID.SetID(GeneratePrimaryKey("[NationalHoliday]", "HolidayID"));
				sSQL = SQL.MakeSQL("INSERT INTO [NationalHoliday](HolidayID, Name, Day, Month, Year, Version, Action) "
				+ " VALUES(%n, %s, %n, %n, %n, %n, %n) "
				, oItem.ID.ToInt32, oItem.Name,oItem.Day,oItem.Month,oItem.Year,oItem.Version,oItem.Action);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(NationalHoliday oItem)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("UPDATE [NationalHoliday] SET , Name = %s, Day = %n, Month = %n, Year = %n, Version = %n, Action = %n WHERE [HolidayID]=%n"
				,oItem.Name,oItem.Day,oItem.Month,oItem.Year,oItem.Version,oItem.Action, oItem.ID.ToInt32);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nNationalHolidayID)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("DELETE FROM [NationalHoliday] WHERE [HolidayID]=%n"
				, nNationalHolidayID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetNationalHoliday(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [NationalHoliday] WHERE HolidayID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetNationalHolidays()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [NationalHoliday] ");
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
