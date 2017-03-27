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
	public partial class DLTerritory: DAAccess
	{
        public int GetTerritoryID(string sTerritoryCode)
        {
            string sQuery;
            object oTerritoryID;
            int nTerritoryID;
            try
            {
                sQuery = SQL.MakeSQL(@"SELECT TerritoryID FROM [OrderCollectionSystem].[dbo].[Territory] WHERE TerritoryCode=%s", sTerritoryCode);
                oTerritoryID = ExecuteScalar(sQuery);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return nTerritoryID = Convert.ToInt32(oTerritoryID);
        }

        public int GetTerritoryID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sTerritoryID)
        {
            int nTerritoryID;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SELECT TerritoryID FROM [OrderCollectionSystem].[dbo].[Territory] WHERE TerritoryCode=%s", sTerritoryID);
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nTerritoryID = 0;
                }
                else
                {
                    nTerritoryID = Convert.ToInt32(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nTerritoryID;
        }

        public int GetUserTypeID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sTerritoryID)
        {
            int nWorkAreaID;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SELECT WorkAreaID FROM [OrderCollectionSystem].[dbo].[Territory] WHERE TerritoryCode=%s", sTerritoryID);
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nWorkAreaID = 0;
                }
                else
                {
                    nWorkAreaID = Convert.ToInt32(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nWorkAreaID;
        }

        public DataTable GetTerritory(int nID, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();
            try
            {
                sSQL = SQL.MakeSQL("SELECT * FROM [OrderCollectionSystem].[dbo].[Territory] WHERE TerritoryID=%n", nID);
                //sSQL = SQL.MakeSQL("SELECT * FROM [TempTerritory] WHERE TerritoryID=%n", nID);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }
        
        //public bool IsDuplicate(string sTerritoryName)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [Territory] WHERE TerritoryName=%s ", sTerritoryName);
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
		//public bool IsDuplicate(string sTerritoryName, int nID)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [Territory] WHERE TerritoryName=%s AND TerritoryID!= %n ", sTerritoryName, nID);
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
		//public IDataReader GetTerritory(string sTerritoryName)
		//{
			//string sSQL = "";
			//IDataReader oReader;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT * FROM [Territory] WHERE [TerritoryName]=%s ", sTerritoryName);
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
