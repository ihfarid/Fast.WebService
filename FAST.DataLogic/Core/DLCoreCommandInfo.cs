using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
	public partial class DLCommandInfo: DAAccess
	{
		public void Insert(CommandInfo oItem)
		{
			string sSQL = "";
			try
			{
				oItem.ID.SetID(GeneratePrimaryKey("[CommandInfo]", "CommandID"));
                sSQL = SQL.MakeSQL("INSERT INTO [CommandInfo](CommandID, TerritoryID, TableName, Description, IsExcute, Version, EntryDateTime, ExecutedDateTime) "
				+ " VALUES(%n, %s, %s, %s, %b, %n, %D, %D) "
                , oItem.ID.ToInt32, oItem.TerritoryID, oItem.TableName, oItem.Description, oItem.IsExcute, oItem.Version, oItem.EntryDateTime, oItem.ExecutedDateTime);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(CommandInfo oItem)
		{
			string sSQL = "";
			try
			{
                sSQL = SQL.MakeSQL("UPDATE [CommandInfo] SET TerritoryID = %s, TableName = %s, Description = %s, IsExcute = %b, Version = %n, EntryDateTime = %D, ExecutedDateTime = %D  WHERE [CommandID]=%n"
                , oItem.TerritoryID, oItem.TableName, oItem.Description, oItem.IsExcute, oItem.Version, oItem.EntryDateTime, oItem.ExecutedDateTime, oItem.ID.ToInt32);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nCommandInfoID)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("DELETE FROM [CommandInfo] WHERE [CommandID]=%n"
				, nCommandInfoID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetCommandInfo(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [CommandInfo] WHERE CommandID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetCommandInfos()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [CommandInfo] ");
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}

        public int GetCommandID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nID = 0;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SElECT MAX(CommandID)+ 1 CommandID FROM CommandInfo");
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nID = 1;
                }
                else
                {
                    nID = Convert.ToInt32(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nID;
        }

        public int Insert(CommandInfo oItem, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                int nCommandID = GetCommandID(oSqlConnection, oSqlTransaction);
                //oItem.ID.SetID(nCommandID);
                //sSQL = SQL.MakeSQL("INSERT INTO [CommandInfo](CommandID, TerritoryID, TableName, Description, IsExcute, Version) "
                //+ " VALUES(%n, %s, %s, %s, %b, %n) "
                //, oItem.ID.ToInt32, oItem.TerritoryID, oItem.TableName, oItem.Description, oItem.IsExcute, oItem.Version);
                sSQL = SQL.MakeSQL("INSERT INTO [CommandInfo](TerritoryID, TableName, Description, IsExcute, Version, EntryDateTime, ExecutedDateTime) "
                + " VALUES(%s, %s, %s, %b, %n, %D, %D) "
                , oItem.TerritoryID, oItem.TableName, oItem.Description, oItem.IsExcute, oItem.Version, oItem.EntryDateTime, oItem.ExecutedDateTime);
                SqlDataAdapter InvAdapter = new SqlDataAdapter();
                SqlCommand InvCommand = new SqlCommand();
                InvCommand = new SqlCommand(sSQL, oSqlConnection);
                InvCommand.Transaction = oSqlTransaction;
                InvAdapter.InsertCommand = InvCommand;
                int i = InvCommand.ExecuteNonQuery();
                return i;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int Update(CommandInfo oItem, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL("UPDATE [CommandInfo] SET TerritoryID = %s, TableName = %s, Description = %s, IsExcute = %b, Version = %n, EntryDateTime = %D, ExecutedDateTime = %D WHERE [CommandID]=%n"
                , oItem.TerritoryID, oItem.TableName, oItem.Description, oItem.IsExcute, oItem.Version, oItem.EntryDateTime, oItem.ExecutedDateTime, oItem.ID.ToInt32);
                SqlDataAdapter InvAdapter = new SqlDataAdapter();
                SqlCommand InvCommand = new SqlCommand();
                InvCommand = new SqlCommand(sSQL, oSqlConnection);
                InvCommand.Transaction = oSqlTransaction;
                InvAdapter.UpdateCommand = InvCommand;
                int i = InvCommand.ExecuteNonQuery();
                return i;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
	}
}
