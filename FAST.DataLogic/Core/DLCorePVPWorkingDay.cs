using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core.DataAccess;

namespace FAST.DataLogic
{
	public partial class DLPVPWorkingDay: DAAccess
	{
		public void Insert(PVPWorkingDay oItem)
		{
			string sSQL = "";
			try
			{
				oItem.ID.SetID(GeneratePrimaryKey("[PVPWorkingDay]", "MonthID"));
				sSQL = SQL.MakeSQL("INSERT INTO [PVPWorkingDay](MonthID, NoOfWorkingDay, Month, Year, Version, Action) "
				+ " VALUES(%n, %n, %n, %n, %n, %n) "
				, oItem.ID.ToInt32, oItem.NoOfWorkingDay,oItem.Month,oItem.Year,oItem.Version,oItem.Action);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(PVPWorkingDay oItem)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("UPDATE [PVPWorkingDay] SET , NoOfWorkingDay = %n, Month = %n, Year = %n, Version = %n, Action = %n WHERE [MonthID]=%n"
				,oItem.NoOfWorkingDay,oItem.Month,oItem.Year,oItem.Version,oItem.Action, oItem.ID.ToInt32);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nPVPWorkingDayID)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("DELETE FROM [PVPWorkingDay] WHERE [MonthID]=%n"
				, nPVPWorkingDayID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetPVPWorkingDay(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [PVPWorkingDay] WHERE MonthID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetPVPWorkingDays()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [PVPWorkingDay] ");
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
