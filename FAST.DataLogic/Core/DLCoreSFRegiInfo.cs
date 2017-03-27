using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
    public partial class DLSFRegiInfo : DAAccess
    {
        public void Insert(SFRegiInfo oItem)
        {
            string sSQL = "";
            try
            {
                oItem.ID.SetID(GeneratePrimaryKey("[OrderCollectionSystem].[dbo].[SFRegiInfo]", "SFRegiID"));
                sSQL = SQL.MakeSQL("INSERT INTO [OrderCollectionSystem].[dbo].[SFRegiInfo](SFRegiID, GDDBID, EmployeeID, TerritoryID, SecQuesID, SecQuesAns, PassWord, Message, Mobile, EntryDate, LastUpdateDate, Version, CommandVersion, CustomerVersion, ProductVersion, ProductBarVersion, OrderVersion, AppConfigVersion, SalesReportVersion, AppVersion, BU, IsActive) "
                + " VALUES(%n, %s, %n, %n, %n, %s, %s, %s, %s, %D, %D, %n, %n, %n, %n, %n, %n, %n, %n, %n, %s, %b) "
                , oItem.ID.ToInt32, oItem.GDDBID, oItem.EmployeeID, oItem.TerritoryID, oItem.SecQuesID, oItem.SecQuesAns, oItem.PassWord, oItem.Message, oItem.Mobile, oItem.EntryDate, oItem.LastUpdateDate, oItem.Version, oItem.CommandVersion, oItem.CustomerVersion, oItem.ProductVersion, oItem.ProductBarVersion, oItem.OrderVersion, oItem.AppConfigVersion, oItem.SalesReportVersion, oItem.AppVersion, oItem.BU, oItem.IsActive);
                ExecuteNonQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public void InsertDB(SFRegiInfo oItem)
        {
            string sSQL = "";
            try
            {
                oItem.ID.SetID(GeneratePrimaryKey("[OrderCollectionSystem].[dbo].[SFRegiInfo]", "SFRegiID"));
                sSQL = SQL.MakeSQL("EXEC spInsertData");
                ExecuteNonQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Update(SFRegiInfo oItem)
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL("UPDATE [OrderCollectionSystem].[dbo].[SFRegiInfo] SET GDDBID = %s, EmployeeID = %n, TerritoryID = %n, SecQuesID = %n, SecQuesAns = %s, PassWord = %s, Message = %s, Mobile = %s, EntryDate = %D, LastUpdateDate = %D, Version = %n, CommandVersion = %n, CustomerVersion = %n, ProductVersion = %n, ProductBarVersion = %n, OrderVersion = %n, AppConfigVersion = %n, SalesReportVersion = %n, AppVersion = %n, BU = %s, IsActive = %b WHERE [SFRegiID]=%n"
                , oItem.GDDBID, oItem.EmployeeID, oItem.TerritoryID, oItem.SecQuesID, oItem.SecQuesAns, oItem.PassWord, oItem.Message, oItem.Mobile, oItem.EntryDate, oItem.LastUpdateDate, oItem.Version, oItem.CommandVersion, oItem.CustomerVersion, oItem.ProductVersion, oItem.ProductBarVersion, oItem.OrderVersion, oItem.AppConfigVersion, oItem.SalesReportVersion, oItem.AppVersion, oItem.BU, oItem.IsActive, oItem.ID.ToInt32);
                ExecuteNonQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Delete(int nSFRegiInfoID)
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL("DELETE FROM [OrderCollectionSystem].[dbo].[SFRegiInfo] WHERE [SFRegiID]=%n"
                , nSFRegiInfoID);
                ExecuteNonQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public IDataReader GetSFRegiInfo(int nID)
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                sSQL = SQL.MakeSQL("SELECT * FROM [OrderCollectionSystem].[dbo].[SFRegiInfo] WHERE SFRegiID=%n", nID);
                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }
        public IDataReader GetSFRegiInfos()
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                sSQL = SQL.MakeSQL("SELECT * FROM [OrderCollectionSystem].[dbo].[SFRegiInfo] ");
                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }

        public void BeginDistributedTransaction()
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL("SET XACT_ABORT ON "
                + " BEGIN DISTRIBUTED TRANSACTION");
                ExecuteNonQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void EndDistributedTransaction()
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL("SET XACT_ABORT OFF "
                + " BEGIN DISTRIBUTED TRANSACTION");
                ExecuteNonQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int GetSFRegiID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nID;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SELECT MAX(SFRegiID)+ 1 SFRegiID FROM [OrderCollectionSystem].[dbo].[SFRegiInfo]");
                //sSQL = SQL.MakeSQL("SELECT MAX(SFRegiID)+ 1 SFRegiID FROM [SFRegiInfo]");
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

        public int Insert(SFRegiInfo oItem, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                int nSFRegiID = GetSFRegiID(oSqlConnection, oSqlTransaction);
                oItem.ID.SetID(nSFRegiID);
                sSQL = SQL.MakeSQL("INSERT INTO [OrderCollectionSystem].[dbo].[SFRegiInfo](SFRegiID, GDDBID, EmployeeID, TerritoryID, SecQuesID, SecQuesAns, PassWord, Message, Mobile, EntryDate, LastUpdateDate, Version, CommandVersion, CustomerVersion, ProductVersion, ProductBarVersion, OrderVersion, AppConfigVersion, SalesReportVersion, AppVersion, BU, IsActive) "
                + " VALUES(%n, %s, %n, %n, %n, %s, %s, %s, %s, %D, %D, %n, %n, %n, %n, %n, %n, %n, %n, %n, %s, %b) "
                , oItem.ID.ToInt32, oItem.GDDBID, oItem.EmployeeID, oItem.TerritoryID, oItem.SecQuesID, oItem.SecQuesAns, oItem.PassWord, oItem.Message, oItem.Mobile, oItem.EntryDate, oItem.LastUpdateDate, oItem.Version, oItem.CommandVersion, oItem.CustomerVersion, oItem.ProductVersion, oItem.ProductBarVersion, oItem.OrderVersion, oItem.AppConfigVersion, oItem.SalesReportVersion, oItem.AppVersion, oItem.BU, oItem.IsActive);
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

        public int Update(SFRegiInfo oItem, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL("UPDATE [OrderCollectionSystem].[dbo].[SFRegiInfo] SET GDDBID = %s, EmployeeID = %n, TerritoryID = %n, SecQuesID = %n, SecQuesAns = %s, PassWord = %s, Message = %s, Mobile = %s, EntryDate = %D, LastUpdateDate = %D, Version = %n, CommandVersion = %n, CustomerVersion = %n, ProductVersion = %n, ProductBarVersion = %n, OrderVersion = %n, AppConfigVersion = %n, SalesReportVersion = %n, AppVersion = %n, BU = %s, IsActive = %b WHERE [SFRegiID]=%n"
                , oItem.GDDBID, oItem.EmployeeID, oItem.TerritoryID, oItem.SecQuesID, oItem.SecQuesAns, oItem.PassWord, oItem.Message, oItem.Mobile, oItem.EntryDate, oItem.LastUpdateDate, oItem.Version, oItem.CommandVersion, oItem.CustomerVersion, oItem.ProductVersion, oItem.ProductBarVersion, oItem.OrderVersion, oItem.AppConfigVersion, oItem.SalesReportVersion, oItem.AppVersion, oItem.BU, oItem.IsActive, oItem.ID.ToInt32);
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
