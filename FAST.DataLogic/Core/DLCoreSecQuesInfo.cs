using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core;
using FAST.Core.DataAccess;

namespace FAST.DataLogic
{
	public partial class DLSecQuesInfo: DAAccess
	{
		public void Insert(SecQuesInfo oItem)
		{
			string sSQL = "";
			try
			{
                oItem.ID.SetID(GeneratePrimaryKey("[OrderCollectionSystem].[dbo].[SecQuesInfo]", "SecQuesID"));
                sSQL = SQL.MakeSQL("INSERT INTO [OrderCollectionSystem].[dbo].[SecQuesInfo](SecQuesID, SecQues, Version, ActionType, EntryDate, LastUpdateDate) "
				+ " VALUES(%n, %s, %n, %n, %d, %d) "
				, oItem.ID.ToInt32, oItem.SecQues,oItem.Version,oItem.ActionType,oItem.EntryDate,oItem.LastUpdateDate);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(SecQuesInfo oItem)
		{
			string sSQL = "";
			try
			{
                sSQL = SQL.MakeSQL("UPDATE [OrderCollectionSystem].[dbo].[SecQuesInfo] SET , SecQues = %s, Version = %n, ActionType = %n, EntryDate = %d, LastUpdateDate = %d WHERE [SecQuesID]=%n"
				,oItem.SecQues,oItem.Version,oItem.ActionType,oItem.EntryDate,oItem.LastUpdateDate, oItem.ID.ToInt32);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nSecQuesInfoID)
		{
			string sSQL = "";
			try
			{
                sSQL = SQL.MakeSQL("DELETE FROM [OrderCollectionSystem].[dbo].[SecQuesInfo] WHERE [SecQuesID]=%n"
				, nSecQuesInfoID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetSecQuesInfo(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
                sSQL = SQL.MakeSQL("SELECT * FROM [OrderCollectionSystem].[dbo].[SecQuesInfo] WHERE SecQuesID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetSecQuesInfos()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
                sSQL = SQL.MakeSQL("SELECT * FROM [OrderCollectionSystem].[dbo].[SecQuesInfo] ");
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
