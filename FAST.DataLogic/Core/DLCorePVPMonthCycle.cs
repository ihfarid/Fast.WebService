using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core.DataAccess;

namespace FAST.DataLogic
{
	public partial class DLPVPMonthCycle: DAAccess
	{
		public void Insert(PVPMonthCycle oItem)
		{
			string sSQL = "";
			try
			{
				oItem.ID.SetID(GeneratePrimaryKey("[PVPMonthCycle]", "CycleID"));
				sSQL = SQL.MakeSQL("INSERT INTO [PVPMonthCycle](CycleID, StartDate, EndDate, Month, Year, IsActive) "
				+ " VALUES(%n, %d, %d, %n, %n, %b) "
				, oItem.ID.ToInt32, oItem.StartDate,oItem.EndDate,oItem.Month,oItem.Year,oItem.IsActive);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(PVPMonthCycle oItem)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("UPDATE [PVPMonthCycle] SET StartDate = %d, EndDate = %d, Month = %n, Year = %n, IsActive = %b WHERE [CycleID]=%n"
				,oItem.StartDate,oItem.EndDate,oItem.Month,oItem.Year,oItem.IsActive, oItem.ID.ToInt32);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nPVPMonthCycleID)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("DELETE FROM [PVPMonthCycle] WHERE [CycleID]=%n"
				, nPVPMonthCycleID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetPVPMonthCycle(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [PVPMonthCycle] WHERE CycleID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetPVPMonthCycles()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [PVPMonthCycle] ");
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
