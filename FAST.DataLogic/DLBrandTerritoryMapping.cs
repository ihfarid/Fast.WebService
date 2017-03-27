using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
	public partial class DLBrandTerritoryMapping: DAAccess
	{
        public IDataReader GetBrandTerritoryMapping(String sTerritoryID, int nMaxVersion)
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                if (nMaxVersion == 0)
                    sSQL = SQL.MakeSQL("SELECT * FROM [BrandTerritoryMapping] WHERE TerritoryID=%s and Version>%n and Action !=%n", sTerritoryID, nMaxVersion, 3);
                else
                    sSQL = SQL.MakeSQL("SELECT * FROM [BrandTerritoryMapping] WHERE TerritoryID=%s and Version>%n", sTerritoryID, nMaxVersion);
                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }

        public DataTable GetBrandTerritoryMappingInfo(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();
            try
            {
                if (nMaxVersion == 0)
                    sSQL = SQL.MakeSQL("SELECT * FROM [BrandTerritoryMapping] WHERE TerritoryID=%s and Version>%n and Action !=%n", sTerritoryID, nMaxVersion, 3);
                else
                    sSQL = SQL.MakeSQL("SELECT * FROM [BrandTerritoryMapping] WHERE TerritoryID=%s and Version>%n", sTerritoryID, nMaxVersion);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public IDataReader GetBrandTerritoryMappingForRM(String sTerritoryID, int nMaxVersion)
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                string sSQL1 = "";
                string sSQL2 = "";
                if (nMaxVersion == 0)
                {
                    sSQL1 = SQL.MakeSQL("SELECT * FROM [BrandTerritoryMapping] WHERE Version>%n and Action !=%n", nMaxVersion, 3);
                    sSQL2 = " AND TerritoryID like '" + sTerritoryID + "%' ORDER BY TerritoryID";
                }
                else
                {
                    sSQL1 = SQL.MakeSQL("SELECT * FROM [BrandTerritoryMapping] WHERE Version>%n", nMaxVersion);
                    sSQL2 = " AND TerritoryID like '" + sTerritoryID + "%' ORDER BY TerritoryID";
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

        public DataTable GetBrandTerritoryMappingInfoForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();
            try
            {
                string sSQL1 = "";
                string sSQL2 = "";
                if (nMaxVersion == 0)
                {
                    sSQL1 = SQL.MakeSQL("SELECT * FROM [BrandTerritoryMapping] WHERE Version>%n and Action !=%n", nMaxVersion, 3);
                    sSQL2 = " AND TerritoryID like '" + sTerritoryID + "%' ORDER BY TerritoryID";
                }
                else
                {
                    sSQL1 = SQL.MakeSQL("SELECT * FROM [BrandTerritoryMapping] WHERE Version>%n", nMaxVersion);
                    sSQL2 = " AND TerritoryID like '" + sTerritoryID + "%' ORDER BY TerritoryID";
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

        public string GetBrandName(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, int nBrandID)
        {
            string sBrandName = "";
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SElECT [ProdName] FROM [Product] WHERE  [ProdID]=%n", nBrandID);
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    sBrandName = "";
                }
                else
                {
                    sBrandName = Convert.ToString(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return sBrandName;
        }
		//public bool IsDuplicate(string sBrandTerritoryMappingName)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [BrandTerritoryMapping] WHERE BrandTerritoryMappingName=%s ", sBrandTerritoryMappingName);
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
		//public bool IsDuplicate(string sBrandTerritoryMappingName, int nID)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [BrandTerritoryMapping] WHERE BrandTerritoryMappingName=%s AND BrandTerritoryMappingID!= %n ", sBrandTerritoryMappingName, nID);
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
		//public IDataReader GetBrandTerritoryMapping(string sBrandTerritoryMappingName)
		//{
			//string sSQL = "";
			//IDataReader oReader;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT * FROM [BrandTerritoryMapping] WHERE [BrandTerritoryMappingName]=%s ", sBrandTerritoryMappingName);
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
