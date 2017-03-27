using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core.DataAccess;

namespace FAST.DataLogic
{
	public partial class DLUpazilla: DAAccess
	{
		public void Insert(Upazilla oItem)
		{
			string sSQL = "";
			try
			{
				oItem.ID.SetID(GeneratePrimaryKey("[Upazilla]", "UID"));
				sSQL = SQL.MakeSQL("INSERT INTO [Upazilla](UID, UName, DistID, Action, Version) "
				+ " VALUES(%n, %s, %n, %n, %n) "
				, oItem.ID.ToInt32, oItem.UName,oItem.DistID,oItem.Action,oItem.Version);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(Upazilla oItem)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("UPDATE [Upazilla] SET , UName = %s, DistID = %n, Action = %n, Version = %n WHERE [UID]=%n"
				,oItem.UName,oItem.DistID,oItem.Action,oItem.Version, oItem.ID.ToInt32);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nUpazillaID)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("DELETE FROM [Upazilla] WHERE [UID]=%n"
				, nUpazillaID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetUpazilla(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [Upazilla] WHERE UID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetUpazillas()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [Upazilla] ");
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
