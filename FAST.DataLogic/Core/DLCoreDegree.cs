using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core.DataAccess;

namespace FAST.DataLogic
{
	public partial class DLDegree: DAAccess
	{
		public void Insert(Degree oItem)
		{
			string sSQL = "";
			try
			{
				oItem.ID.SetID(GeneratePrimaryKey("[Degree]", "DegID"));
				sSQL = SQL.MakeSQL("INSERT INTO [Degree](DegID, DegCode, DegName, Status, Action, Version) "
				+ " VALUES(%n, %s, %s, %n, %n, %n) "
				, oItem.ID.ToInt32, oItem.DegCode,oItem.DegName,oItem.Status,oItem.Action,oItem.Version);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(Degree oItem)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("UPDATE [Degree] SET , DegCode = %s, DegName = %s, Status = %n, Action = %n, Version = %n WHERE [DegID]=%n"
				,oItem.DegCode,oItem.DegName,oItem.Status,oItem.Action,oItem.Version, oItem.ID.ToInt32);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nDegreeID)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("DELETE FROM [Degree] WHERE [DegID]=%n"
				, nDegreeID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetDegree(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [Degree] WHERE DegID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetDegrees()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [Degree] ");
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
