using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
	public partial class DLUpazilla: DAAccess
	{
		//public bool IsDuplicate(string sUpazillaName)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [Upazilla] WHERE UpazillaName=%s ", sUpazillaName);
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
		//public bool IsDuplicate(string sUpazillaName, int nID)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [Upazilla] WHERE UpazillaName=%s AND UID!= %n ", sUpazillaName, nID);
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
		//public IDataReader GetUpazilla(string sUpazillaName)
		//{
			//string sSQL = "";
			//IDataReader oReader;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT * FROM [Upazilla] WHERE [UpazillaName]=%s ", sUpazillaName);
				//oReader = ExecuteReader(sSQL);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
			//return oReader;
		//}

        public DataTable GetUpazillaInfoForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                if (nMaxVersion == 0)
                {
                    sSQL = SQL.MakeSQL(@"SELECT distinct a.UpazillaID, u.UName, dis.DistName, u.Action,u.Version
                FROM [TerrLocationMapping] a INNER JOIN [dbo].Upazilla u ON a.[UpazillaID]=u.UID
                INNER JOIN [dbo].District dis ON dis.DistID = u.DistID WHERE u.Version>%n and u.Action !=%n", nMaxVersion, 3);
                    sSQL = sSQL + " and a.[Territory] like '" + sTerritoryID + "%'";
                }
                else
                {
                    sSQL = SQL.MakeSQL(@"SELECT distinct a.UpazillaID, u.UName, dis.DistName, u.Action,u.Version
                FROM [TerrLocationMapping] a INNER JOIN [dbo].Upazilla u ON a.[UpazillaID]=u.UID
                INNER JOIN [dbo].District dis ON dis.DistID = u.DistID WHERE u.Version>%n", nMaxVersion);
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

        public DataTable GetUpazillaInfo(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                if (nMaxVersion == 0)
                {
                    sSQL = SQL.MakeSQL(@"SELECT distinct a.UpazillaID UID, u.UName UName, dis.DistName DistID,u.Action,u.Version
                FROM [TerrLocationMapping] a INNER JOIN [dbo].Upazilla u ON a.[UpazillaID]=u.UID
                INNER JOIN [dbo].District dis ON dis.DistID = u.DistID WHERE u.Version>%n and u.Action !=%n", nMaxVersion, 3);
                    sSQL = sSQL + " and a.[Territory] = '" + sTerritoryID + "'";
                }
                else
                {
                    sSQL = SQL.MakeSQL(@"SELECT distinct a.UpazillaID UID, u.UName UName, dis.DistName DistID,u.Action,u.Version
                FROM [TerrLocationMapping] a INNER JOIN [dbo].Upazilla u ON a.[UpazillaID]=u.UID
                INNER JOIN [dbo].District dis ON dis.DistID = u.DistID WHERE u.Version>%n", nMaxVersion);
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
