using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
	public partial class DLSampleTerritoryMapping: DAAccess
	{
        public IDataReader GetSampleTerritoryMapping(String sTerritoryID, int nMaxVersion)
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                if (nMaxVersion == 0)
                    sSQL = SQL.MakeSQL("SELECT * FROM [SampleTerritoryMapping] WHERE TerritoryCode=%s and Version>%n and Action !=%n", sTerritoryID, nMaxVersion, 3);
                else
                    sSQL = SQL.MakeSQL("SELECT * FROM [SampleTerritoryMapping] WHERE TerritoryCode=%s and Version>%n", sTerritoryID, nMaxVersion);
                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }

        public DataTable GetSampleTerritoryMappingInfo(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();
            try
            {
                if (nMaxVersion == 0)
                    sSQL = SQL.MakeSQL("SELECT * FROM [SampleTerritoryMapping] WHERE TerritoryCode=%s and Version>%n and Action !=%n", sTerritoryID, nMaxVersion, 3);
                else
                    sSQL = SQL.MakeSQL("SELECT * FROM [SampleTerritoryMapping] WHERE TerritoryCode=%s and Version>%n", sTerritoryID, nMaxVersion);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public IDataReader GetSampleTerritoryMappingForRM(String sTerritoryID, int nMaxVersion)
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                string sSQL1 = "";
                string sSQL2 = "";
                if (nMaxVersion == 0)
                {
                    sSQL1 = SQL.MakeSQL("SELECT * FROM [SampleTerritoryMapping] WHERE Version>%n and Action !=%n", nMaxVersion, 3);
                    sSQL2 = " AND TerritoryCode like '" + sTerritoryID + "%' ORDER BY TerritoryCode";
                }
                else
                {
                    sSQL1 = SQL.MakeSQL("SELECT * FROM [SampleTerritoryMapping] WHERE Version>%n", nMaxVersion);
                    sSQL2 = " AND TerritoryCode like '" + sTerritoryID + "%' ORDER BY TerritoryCode";
                }
                sSQL = sSQL1 + sSQL2;
                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }

        public DataTable GetSampleTerritoryMappingInfoForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();
            try
            {
                string sSQL1 = "";
                string sSQL2 = "";
                if (nMaxVersion == 0)
                {
                    sSQL1 = SQL.MakeSQL("SELECT * FROM [SampleTerritoryMapping] WHERE Version>%n and Action !=%n", nMaxVersion, 3);
                    sSQL2 = " AND TerritoryCode like '" + sTerritoryID + "%' ORDER BY TerritoryCode";
                }
                else
                {
                    sSQL1 = SQL.MakeSQL("SELECT * FROM [SampleTerritoryMapping] WHERE Version>%n", nMaxVersion);
                    sSQL2 = " AND TerritoryCode like '" + sTerritoryID + "%' ORDER BY TerritoryCode";
                }
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

        public string GetSampleName(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, int nSampleID)
        {
            string sSampleName = "";
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SElECT [Description] FROM [SampleInfo] WHERE  [SampleID]=%n", nSampleID);
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    sSampleName = "";
                }
                else
                {
                    sSampleName = Convert.ToString(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return sSampleName;
        }
		//public bool IsDuplicate(string sSampleTerritoryMappingName)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [SampleTerritoryMapping] WHERE SampleTerritoryMappingName=%s ", sSampleTerritoryMappingName);
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
		//public bool IsDuplicate(string sSampleTerritoryMappingName, int nID)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [SampleTerritoryMapping] WHERE SampleTerritoryMappingName=%s AND SampleID!= %n ", sSampleTerritoryMappingName, nID);
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
		//public IDataReader GetSampleTerritoryMapping(string sSampleTerritoryMappingName)
		//{
			//string sSQL = "";
			//IDataReader oReader;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT * FROM [SampleTerritoryMapping] WHERE [SampleTerritoryMappingName]=%s ", sSampleTerritoryMappingName);
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
