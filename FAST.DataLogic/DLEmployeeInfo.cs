using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
    public partial class DLEmployeeInfo : DAAccess
    {
        public IDataReader GetEmployeeInfo(string sEmpCode)
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                sSQL = SQL.MakeSQL(@"SELECT * FROM [OrderCollectionSystem].[dbo].[EmployeeInfo] WHERE [EmpCode]=%s", sEmpCode);
                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }

        public int GetEmployeeID(string sEmpCode)
        {
            string sQuery;
            object oEmployeeID;
            int nEmployeeID;
            try
            {
                sQuery = SQL.MakeSQL(@"SELECT EmployeeID FROM [OrderCollectionSystem].[dbo].[EmployeeInfo] WHERE EmpCode=%s", sEmpCode);
                oEmployeeID = ExecuteScalar(sQuery);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return nEmployeeID = Convert.ToInt32(oEmployeeID);
        }

        public bool IsActiveEmployee(string sGDDBID)
        {
            string sSQL = "";
            object oCount;
            try
            {
                sSQL = SQL.MakeSQL(@"SELECT COUNT(*) FROM [OrderCollectionSystem].[dbo].[EmployeeInfo] WHERE GDDBID=%s", sGDDBID);
                oCount = ExecuteScalar(sSQL);
                if (Convert.ToInt32(oCount) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IDataReader GetActiveEmployeeInfoByGDDBID(string sGDDBID)
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                sSQL = SQL.MakeSQL(@"SELECT * FROM [OrderCollectionSystem].[dbo].[EmployeeInfo] WHERE [GDDBID]=%s and IsActive=%n and BU='Sandoz'", sGDDBID, 1);
                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }

        public DataTable GetActiveEmployeeInfoByGDDBID(string sGDDBID, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                sSQL = SQL.MakeSQL(@"SELECT * FROM [OrderCollectionSystem].[dbo].[EmployeeInfo] WHERE [GDDBID]=%s and BU='Sandoz'", sGDDBID);
                //sSQL = SQL.MakeSQL(@"SELECT * FROM [EmployeeInfo] WHERE [GDDBID]=%s and IsActive=%n and BU='Sandoz'", sGDDBID, 1);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }


        public int GetEmployeeID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sEmpCode)
        {
            int nEmployeeID;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SELECT EmployeeID FROM [OrderCollectionSystem].[dbo].[EmployeeInfo] WHERE EmpCode=%s", sEmpCode);
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nEmployeeID = 0;
                }
                else
                {
                    nEmployeeID = Convert.ToInt32(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nEmployeeID;
        }

        //public bool IsDuplicate(string sEmployeeInfoName)
        //{
        //string sSQL = "";
        //object oCount;
        //try
        //{
        //sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [EmployeeInfo] WHERE EmployeeInfoName=%s ", sEmployeeInfoName);
        //oCount = ExecuteScalar(sSQL);
        //if (Convert.ToInt32(oCount) > 0)
        //{
        //return true;
        //}
        //else
        //{
        //return false;
        //}
        //}
        //catch (Exception e)
        //{
        //throw new Exception(e.Message);
        //}
        //}
        //public bool IsDuplicate(string sEmployeeInfoName, int nID)
        //{
        //string sSQL = "";
        //object oCount;
        //try
        //{
        //sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [EmployeeInfo] WHERE EmployeeInfoName=%s AND EmployeeID!= %n ", sEmployeeInfoName, nID);
        //oCount = ExecuteScalar(sSQL);
        //if (Convert.ToInt32(oCount) > 0)
        //{
        //return true;
        //}
        //else
        //{
        //return false;
        //}
        //}
        //catch (Exception e)
        //{
        //throw new Exception(e.Message);
        //}
        //}
        //public IDataReader GetEmployeeInfo(string sEmployeeInfoName)
        //{
        //string sSQL = "";
        //IDataReader oReader;
        //try
        //{
        //sSQL = SQL.MakeSQL("SELECT * FROM [EmployeeInfo] WHERE [EmployeeInfoName]=%s ", sEmployeeInfoName);
        //oReader = ExecuteReader(sSQL);
        //}
        //catch (Exception e)
        //{
        //throw new Exception(e.Message);
        //}
        //return oReader;
        //}
    }
}
