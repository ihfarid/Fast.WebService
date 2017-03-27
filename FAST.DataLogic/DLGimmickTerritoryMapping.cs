using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
	public partial class DLGimmickTerritoryMapping: DAAccess
	{
        public IDataReader GetGimmickTerritoryMapping(string sTerritoryID, int nMaxVersion)
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                if(nMaxVersion == 0)
                    sSQL = SQL.MakeSQL("SELECT * FROM [GimmickTerritoryMapping] WHERE TerritoryCode=%s and Version>%n and Action !=%n", sTerritoryID, nMaxVersion, 3);
                else
                    sSQL = SQL.MakeSQL("SELECT * FROM [GimmickTerritoryMapping] WHERE TerritoryCode=%s and Version>%n", sTerritoryID, nMaxVersion);
                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }

        public DataTable GetGimmickTerritoryMappingInfo(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();
            try
            {
                if (nMaxVersion == 0)
                    sSQL = SQL.MakeSQL("SELECT * FROM [GimmickTerritoryMapping] WHERE TerritoryCode=%s and Version>%n and Action !=%n", sTerritoryID, nMaxVersion, 3);
                else
                    sSQL = SQL.MakeSQL("SELECT * FROM [GimmickTerritoryMapping] WHERE TerritoryCode=%s and Version>%n", sTerritoryID, nMaxVersion);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public IDataReader GetGimmickTerritoryMappingForRM(String sTerritoryID, int nMaxVersion)
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                string sSQL1 = "";
                string sSQL2 = "";
                if (nMaxVersion == 0)
                {
                    sSQL1 = SQL.MakeSQL("SELECT * FROM [GimmickTerritoryMapping] WHERE Version>%n and Action !=%n", nMaxVersion, 3);
                    sSQL2 = " AND TerritoryCode like '" + sTerritoryID + "%' ORDER BY TerritoryCode";
                }
                else
                {
                    sSQL1 = SQL.MakeSQL("SELECT * FROM [GimmickTerritoryMapping] WHERE Version>%n", nMaxVersion);
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

        public DataTable GetGimmickTerritoryMappingInfoForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();
            try
            {
                string sSQL1 = "";
                string sSQL2 = "";
                if (nMaxVersion == 0)
                {
                    sSQL1 = SQL.MakeSQL("SELECT * FROM [GimmickTerritoryMapping] WHERE Version>%n and Action !=%n", nMaxVersion, 3);
                    sSQL2 = " AND TerritoryCode like '" + sTerritoryID + "%' ORDER BY TerritoryCode";
                }
                else
                {
                    sSQL1 = SQL.MakeSQL("SELECT * FROM [GimmickTerritoryMapping] WHERE Version>%n", nMaxVersion);
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

        public string GetGimmickName(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, int nGimmickID)
        {
            string sGimmickName = "";
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SElECT [Description] FROM [GimmickInfo] WHERE  [GimmickID]=%n", nGimmickID);
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    sGimmickName = "";
                }
                else
                {
                    sGimmickName = Convert.ToString(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return sGimmickName;
        }
		//public bool IsDuplicate(string sGimmickTerritoryMappingName)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [GimmickTerritoryMapping] WHERE GimmickTerritoryMappingName=%s ", sGimmickTerritoryMappingName);
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
		//public bool IsDuplicate(string sGimmickTerritoryMappingName, int nID)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [GimmickTerritoryMapping] WHERE GimmickTerritoryMappingName=%s AND GimmickID!= %n ", sGimmickTerritoryMappingName, nID);
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
		//public IDataReader GetGimmickTerritoryMapping(string sGimmickTerritoryMappingName)
		//{
			//string sSQL = "";
			//IDataReader oReader;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT * FROM [GimmickTerritoryMapping] WHERE [GimmickTerritoryMappingName]=%s ", sGimmickTerritoryMappingName);
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
