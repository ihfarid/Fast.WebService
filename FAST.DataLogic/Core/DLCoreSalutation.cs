using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core.DataAccess;

namespace FAST.DataLogic
{
	public partial class DLSalutation: DAAccess
	{
		public void Insert(Salutation oItem)
		{
			string sSQL = "";
			try
			{
				oItem.ID.SetID(GeneratePrimaryKey("[Salutation]", "SalID"));
				sSQL = SQL.MakeSQL("INSERT INTO [Salutation](SalID, SalCode, SalDesc, Status, Action, Version) "
				+ " VALUES(%n, %s, %s, %n, %n, %n) "
				, oItem.ID.ToInt32, oItem.SalCode,oItem.SalDesc,oItem.Status,oItem.Action,oItem.Version);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(Salutation oItem)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("UPDATE [Salutation] SET , SalCode = %s, SalDesc = %s, Status = %n, Action = %n, Version = %n WHERE [SalID]=%n"
				,oItem.SalCode,oItem.SalDesc,oItem.Status,oItem.Action,oItem.Version, oItem.ID.ToInt32);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nSalutationID)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("DELETE FROM [Salutation] WHERE [SalID]=%n"
				, nSalutationID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetSalutation(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [Salutation] WHERE SalID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetSalutations()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [Salutation] ");
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
