using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using FAST.Core;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
    public partial class DLPVPMaster : DAAccess
    {
        public int GetTerritoryWiseMaxVersion(string sTerritoryID)
        {
            string sQuery;
            object oMaxVersion;
            int nMaxVersion;
            try
            {
                sQuery = SQL.MakeSQL("SELECT MAX(Version)+1 FROM [PVPMaster]");
                sQuery = sQuery + " WHERE TerritoryID like '" + sTerritoryID.Substring(0, 6) + "%'";
                oMaxVersion = ExecuteScalar(sQuery);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            if (oMaxVersion == DBNull.Value)
                oMaxVersion = 1;
            return nMaxVersion = Convert.ToInt32(oMaxVersion);
        }

        public IDataReader GetPVPMasterInfo(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nPreviousMonth, int nPreviousYear, int nNextMonth, int nNextYear, int nMaxVersion)
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                sSQL = SQL.MakeSQL("SELECT * FROM [PVPMaster] WHERE TerritoryID=%s and Month=%n and Year=%n and Version>%n UNION "
                + " SELECT * FROM [PVPMaster] WHERE TerritoryID=%s and Month=%n and Year=%n and Version>%n UNION "
                + " SELECT * FROM [PVPMaster] WHERE TerritoryID=%s and Month=%n and Year=%n and Version>%n", sTerritoryID, nCurrentMonth,
                nCurrentYear, nMaxVersion, sTerritoryID, nPreviousMonth, nPreviousYear, nMaxVersion, sTerritoryID, nNextMonth, nNextYear, nMaxVersion);
                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }

        public DataTable GetPVPMasterInfo(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nPreviousMonth, int nPreviousYear, int nNextMonth, int nNextYear, int nMaxVersion, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                sSQL = SQL.MakeSQL("SELECT * FROM [PVPMaster] WHERE TerritoryID=%s and Month=%n and Year=%n and Version>%n UNION "
                + " SELECT * FROM [PVPMaster] WHERE TerritoryID=%s and Month=%n and Year=%n and Version>%n UNION "
                + " SELECT * FROM [PVPMaster] WHERE TerritoryID=%s and Month=%n and Year=%n and Version>%n", sTerritoryID, nCurrentMonth,
                nCurrentYear, nMaxVersion, sTerritoryID, nPreviousMonth, nPreviousYear, nMaxVersion, sTerritoryID, nNextMonth, nNextYear, nMaxVersion);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public IDataReader GetPVPMasterInfoForRM(string sTerritoryID, int nMonth, int nYear, int nPreMonth, int  nPreYear, int nMaxVersion)
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                string sSQL1 = SQL.MakeSQL("SELECT * FROM [PVPMaster] WHERE Month=%n and Year=%n and (Status=%n OR Status=%n) and Version>%n",
                    nMonth, nYear, 2, 3, nMaxVersion);
                sSQL1 = sSQL1 + " AND TerritoryID like '" + sTerritoryID + "%'";
                string sSQL2 = SQL.MakeSQL("SELECT * FROM [PVPMaster] WHERE Month=%n and Year=%n and Status=%n",
                    nPreMonth, nPreYear, 3);
                sSQL2 = " UNION " + sSQL2 + " AND TerritoryID like '" + sTerritoryID + "%'";
                if (nMaxVersion == 0)
                    sSQL = sSQL1 + sSQL2;
                else
                    sSQL = sSQL1;

                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }

        public DataTable GetPVPMasterInfoForRM(string sTerritoryID, int nNextMonth, int nNextYear, int nCurrentMonth, int nCurrentYear, int nMaxVersion, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                string sSQL1 = SQL.MakeSQL("SELECT * FROM [PVPMaster] WHERE Month=%n and Year=%n and Version>%n",
                nCurrentMonth, nCurrentYear, nMaxVersion);
                sSQL1 = sSQL1 + " AND TerritoryID like '" + sTerritoryID + "%' UNION ";
                string sSQL2 = SQL.MakeSQL("SELECT * FROM [PVPMaster] WHERE Month=%n and Year=%n and Version>%n",
                    nNextMonth, nNextYear, nMaxVersion);
                sSQL2 = sSQL2 + " AND TerritoryID like '" + sTerritoryID + "%'";
                if (nMaxVersion == 0)
                    sSQL = sSQL1 + sSQL2;
                else
                    sSQL = sSQL2;
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }        

        public string GetRMGDDBID(string sTerritoryID)
        {
            string sQuery;
            object oRMGDDBID;
            string sRMGDDBID;
            try
            {
                sQuery = SQL.MakeSQL(@"SELECT GDDBID FROM [OrderCollectionSystem].[dbo].[EmployeeInfo] a INNER JOIN [OrderCollectionSystem].[dbo].[Territory] b ON a.TerritoryID=b.TerritoryID WHERE b.TerritoryCode=%s", sTerritoryID.Substring(0, 6));
                oRMGDDBID = ExecuteScalar(sQuery);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return sRMGDDBID = Convert.ToString(oRMGDDBID);
        }

        public DataTable GetPVPMasterInfo(string sTerritoryID, int nMonth, int nYear, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                sSQL = SQL.MakeSQL("SELECT * FROM [PVPMaster] WHERE TerritoryID = %s and Month=%n and Year=%n", sTerritoryID, nMonth, nYear);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        //public bool IsDuplicate(string sPVPMasterName)
        //{
        //    string sSQL = "";
        //    object oCount;
        //    try
        //    {
        //        sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [PVPMaster] WHERE PVPMasterName=%s ", sPVPMasterName);
        //        oCount = ExecuteScalar(sSQL);
        //        if (Convert.ToInt32(oCount) > 0)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        public bool IsDuplicate(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, int nMonth, int nYear, string sTerritoryID)
        {
           
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [PVPMaster] WHERE Month=%n AND Year=%n AND TerritoryID=%s", nMonth, nYear, sTerritoryID);
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object oCount = cmd.ExecuteScalar();

                //if (o == DBNull.Value)
                //{
                //    nCount = 0;
                //}
                //else
                //{
                //    nCount = Convert.ToInt32(o);
                //}

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

        //public bool IsDuplicate(string sPVPMasterName, int nID)
        //{
        //string sSQL = "";
        //object oCount;
        //try
        //{
        //sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [PVPMaster] WHERE PVPMasterName=%s AND PvpID!= %n ", sPVPMasterName, nID);
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
        //public IDataReader GetPVPMaster(string sPVPMasterName)
        //{
        //string sSQL = "";
        //IDataReader oReader;
        //try
        //{
        //sSQL = SQL.MakeSQL("SELECT * FROM [PVPMaster] WHERE [PVPMasterName]=%s ", sPVPMasterName);
        //oReader = ExecuteReader(sSQL);
        //}
        //catch (Exception e)
        //{
        //throw new Exception(e.Message);
        //}
        //return oReader;
        //}


        // public DataTable GetUpdateTerritoryWisePVPMaster(String sTerritoryID, int nVersion)

        public int GetUpdateTerritoryWisePVPMaster(string sTerritoryID, string sRMGDDBID, int nMonth, int nYear, int nVersion)
        {
            string sSQL = "";
            int nAuthenTicket = 0;
            try
            {
                sSQL = SQL.MakeSQL("Update [PVPMaster] set [Status]=4, ApprovedDate=%D, ApprovedBy=%s, [Version]=%n, [Action]=2 where TerritoryID=%s and Month=%n and Year=%n", DateTime.Now, sRMGDDBID, nVersion, sTerritoryID, nMonth, nYear);
                ExecuteNonQuery(sSQL);
                nAuthenTicket = 1;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nAuthenTicket;
        }

        public int GetMaxPVPVersion(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sTerritoryID)
        {
            int nMaxPVPVersion;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SELECT MAX(Version)+ 1 Version FROM [PVPMaster]");
                sSQL = sSQL + " WHERE TerritoryID like '" + sTerritoryID.Substring(0, 6) + "%'";
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nMaxPVPVersion = 1;
                }
                else
                {
                    nMaxPVPVersion = Convert.ToInt32(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nMaxPVPVersion;
        }

        public int GetMaxPVPVersion(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nMaxPVPVersion;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SELECT MAX(Version)+ 1 Version FROM [PVPMaster]");
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nMaxPVPVersion = 1;
                }
                else
                {
                    nMaxPVPVersion = Convert.ToInt32(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nMaxPVPVersion;
        }

        public int InsertPVPCommandInfo(string sTerritoryID, int nStatus, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nResult = 0;

            try
            {
                SqlCommand oSqlCommand = new SqlCommand("spInsertPVPCommmandInfo", oSqlConnection, oSqlTransaction);
                oSqlCommand.CommandType = CommandType.StoredProcedure;
                oSqlCommand.Parameters.Add("@TerritoryID", SqlDbType.VarChar, 50).Value = sTerritoryID;
                oSqlCommand.Parameters.Add("@PVPStatus", SqlDbType.Int, 50).Value = nStatus;
                oSqlCommand.Parameters.Add("@result", SqlDbType.Int, 50).Direction = ParameterDirection.Output;
                oSqlCommand.ExecuteNonQuery();
                nResult = Convert.ToInt32(oSqlCommand.Parameters["@result"].Value);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nResult;
        }
    }
}
