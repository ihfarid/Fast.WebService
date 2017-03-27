using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
    public partial class DLDCR : DAAccess
    {
        //public bool IsDuplicate(string sDCRName)
        //{
        //string sSQL = "";
        //object oCount;
        //try
        //{
        //sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [DCR] WHERE DCRName=%s ", sDCRName);
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
        //public bool IsDuplicate(string sDCRName, int nID)
        //{
        //string sSQL = "";
        //object oCount;
        //try
        //{
        //sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [DCR] WHERE DCRName=%s AND DcrID!= %n ", sDCRName, nID);
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
        //public IDataReader GetDCR(string sDCRName)
        //{
        //string sSQL = "";
        //IDataReader oReader;
        //try
        //{
        //sSQL = SQL.MakeSQL("SELECT * FROM [DCR] WHERE [DCRName]=%s ", sDCRName);
        //oReader = ExecuteReader(sSQL);
        //}
        //catch (Exception e)
        //{
        //throw new Exception(e.Message);
        //}
        //return oReader;
        //}

        public IDataReader GetDCRInfo(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nPreviousMonth, int nPreviousYear, int nPreviousMonthDay, int nMaxVersion)
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                sSQL = SQL.MakeSQL("SELECT * FROM [DCR] WHERE TerritoryID=%s and Month=%n and Year=%n and Version>%n UNION "
                    + " SELECT * FROM [DCR] WHERE TerritoryID=%s and Month=%n and Year=%n and Day>%n and Version>%n", sTerritoryID, nCurrentMonth,
                nCurrentYear, nMaxVersion, sTerritoryID, nPreviousMonth,
                nPreviousYear, nPreviousMonthDay, nMaxVersion);
                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }

        public DataTable GetDCRInfo(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nPreviousMonth, int nPreviousYear, int nPreviousMonthDay, int nMaxVersion, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                sSQL = SQL.MakeSQL("SELECT * FROM [DCR] WHERE TerritoryID=%s and Month=%n and Year=%n and Version>%n UNION "
                    + " SELECT * FROM [DCR] WHERE TerritoryID=%s and Month=%n and Year=%n and Day>%n and Version>%n ORDER BY DCRID", sTerritoryID, nCurrentMonth,
                nCurrentYear, nMaxVersion, sTerritoryID, nPreviousMonth,
                nPreviousYear, nPreviousMonthDay, nMaxVersion);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public IDataReader GetDCRInfoForRM(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nPreviousMonth, int nPreviousYear, int nPreviousMonthDay, int nMaxVersion)
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                string sSQL1 = SQL.MakeSQL("SELECT * FROM [DCR] WHERE Month=%n and Year=%n and Version>%n", nCurrentMonth, nCurrentYear, nMaxVersion);
                sSQL1 = sSQL1 + " AND TerritoryID like '" + sTerritoryID + "%' UNION ";
                string sSQL2 = SQL.MakeSQL("SELECT * FROM [DCR] WHERE Month=%n and Year=%n and Day>%n and Version>%n", nPreviousMonth, nPreviousYear,
                nPreviousMonthDay, nMaxVersion);
                sSQL2 = sSQL2 + " AND TerritoryID like '" + sTerritoryID + "%'";
                sSQL = sSQL1 + sSQL2;
                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }

        public DataTable GetDCRInfoForRM(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nPreviousMonth, int nPreviousYear, int nPreviousMonthDay, int nMaxVersion, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                string sSQL1 = SQL.MakeSQL("SELECT * FROM [DCR] WHERE Month=%n and Year=%n and Version>%n", nCurrentMonth, nCurrentYear, nMaxVersion);
                sSQL1 = sSQL1 + " AND TerritoryID like '" + sTerritoryID + "%' UNION ";
                string sSQL2 = SQL.MakeSQL("SELECT * FROM [DCR] WHERE Month=%n and Year=%n and Day>%n and Version>%n", nPreviousMonth, nPreviousYear,
                nPreviousMonthDay, nMaxVersion);
                sSQL2 = sSQL2 + " AND TerritoryID like '" + sTerritoryID + "%' ORDER BY DCRID";
                sSQL = sSQL1 + sSQL2;
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }



    }
}
