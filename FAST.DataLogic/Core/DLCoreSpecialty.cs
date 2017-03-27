using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core.DataAccess;

namespace FAST.DataLogic
{
	public partial class DLSpecialty: DAAccess
	{
		public void Insert(Specialty oItem)
		{
			string sSQL = "";
			try
			{
				oItem.ID.SetID(GeneratePrimaryKey("[Specialty]", "SpID"));
				sSQL = SQL.MakeSQL("INSERT INTO [Specialty](SpID, SpCode, SpDesc, Status, Action, Version) "
				+ " VALUES(%n, %s, %s, %n, %n, %n) "
				, oItem.ID.ToInt32, oItem.SpCode,oItem.SpDesc,oItem.Status,oItem.Action,oItem.Version);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(Specialty oItem)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("UPDATE [Specialty] SET , SpCode = %s, SpDesc = %s, Status = %n, Action = %n, Version = %n WHERE [SpID]=%n"
				,oItem.SpCode,oItem.SpDesc,oItem.Status,oItem.Action,oItem.Version, oItem.ID.ToInt32);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nSpecialtyID)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("DELETE FROM [Specialty] WHERE [SpID]=%n"
				, nSpecialtyID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetSpecialty(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [Specialty] WHERE SpID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetSpecialtys()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [Specialty] ");
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
