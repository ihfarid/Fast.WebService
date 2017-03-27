using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
	public partial class DLDistrict: DAAccess
	{
		//public bool IsDuplicate(string sDistrictName)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [District] WHERE DistrictName=%s ", sDistrictName);
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
		//public bool IsDuplicate(string sDistrictName, int nID)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [District] WHERE DistrictName=%s AND DistID!= %n ", sDistrictName, nID);
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
		//public IDataReader GetDistrict(string sDistrictName)
		//{
			//string sSQL = "";
			//IDataReader oReader;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT * FROM [District] WHERE [DistrictName]=%s ", sDistrictName);
				//oReader = ExecuteReader(sSQL);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
			//return oReader;
		//}

        public DataTable GetDistrictInfoForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                if (nMaxVersion == 0)
                {
                    sSQL = SQL.MakeSQL(@"SELECT distinct a.DistrictID DistID,b.DistName,b.Action,b.Version
                        FROM [TerrLocationMapping] a INNER JOIN [District] b
                        ON a.[DistrictID]=b.DistID WHERE b.Version>%n and b.Action !=%n", nMaxVersion, 3);
                    sSQL = sSQL + " and a.[Territory] like '" + sTerritoryID + "%'";
                }
                else
                {
                    sSQL = SQL.MakeSQL(@"SELECT distinct a.DistrictID DistID,b.DistName,b.Action,b.Version
                        FROM [TerrLocationMapping] a INNER JOIN [District] b
                        ON a.[DistrictID]=b.DistID WHERE b.Version>%n", nMaxVersion);
                    sSQL = sSQL + " and a.[Territory] like '" + sTerritoryID + "%'";
                }
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public DataTable GetDistrictInfo(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                if (nMaxVersion == 0)
                {
                    sSQL = SQL.MakeSQL(@"SELECT distinct a.DistrictID DistID,b.DistName,b.Action,b.Version
                        FROM [TerrLocationMapping] a INNER JOIN [District] b
                        ON a.[DistrictID]=b.DistID WHERE b.Version>%n and b.Action !=%n", nMaxVersion, 3);
                    sSQL = sSQL + " and a.[Territory] = '" + sTerritoryID + "'";
                }
                else
                {
                    sSQL = SQL.MakeSQL(@"SELECT distinct a.DistrictID DistID,b.DistName,b.Action,b.Version
                        FROM [TerrLocationMapping] a INNER JOIN [District] b
                        ON a.[DistrictID]=b.DistID WHERE b.Version>%n", nMaxVersion);
                    sSQL = sSQL + " and a.[Territory] = '" + sTerritoryID + "'";
                }
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
