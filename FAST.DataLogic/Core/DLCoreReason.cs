using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core.DataAccess;

namespace FAST.DataLogic
{
	public partial class DLReason: DAAccess
	{
		public void Insert(Reason oItem)
		{
			string sSQL = "";
			try
			{
				oItem.ID.SetID(GeneratePrimaryKey("[Reason]", "ReasonID"));
				sSQL = SQL.MakeSQL("INSERT INTO [Reason](ReasonID, ReasonDescription, Version, Action) "
				+ " VALUES(%n, %s, %n, %n) "
				, oItem.ID.ToInt32, oItem.ReasonDescription,oItem.Version,oItem.Action);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(Reason oItem)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("UPDATE [Reason] SET , ReasonDescription = %s, Version = %n, Action = %n WHERE [ReasonID]=%n"
				,oItem.ReasonDescription,oItem.Version,oItem.Action, oItem.ID.ToInt32);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nReasonID)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("DELETE FROM [Reason] WHERE [ReasonID]=%n"
				, nReasonID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetReason(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [Reason] WHERE ReasonID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetReasons()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [Reason] ");
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
