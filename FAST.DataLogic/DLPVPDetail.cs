using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;


namespace FAST.DataLogic
{
	public partial class DLPVPDetail: DAAccess
	{

        public IDataReader GetPVPDetailInfo(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nPreviousMonthDay, int nPreviousMonth, int nPreviousYear, int nNextMonth, int nNextYear, int nMaxVersion)
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                sSQL = SQL.MakeSQL("SELECT a.* FROM [PVPDetail] a INNER JOIN [PVPMaster] b ON a.PvpID=b.PvpID WHERE b.TerritoryID=%s and b.Month=%n and b.Year=%n and b.Version>%n UNION "
                + " SELECT a.* FROM [PVPDetail] a INNER JOIN [PVPMaster] b ON a.PvpID=b.PvpID WHERE b.TerritoryID=%s and a.Day>%n and b.Month=%n and b.Year=%n and b.Version>%n UNION "
                + " SELECT a.* FROM [PVPDetail] a INNER JOIN [PVPMaster] b ON a.PvpID=b.PvpID WHERE b.TerritoryID=%s and b.Month=%n and b.Year=%n and b.Version>%n", sTerritoryID, nCurrentMonth,
                nCurrentYear, nMaxVersion, sTerritoryID, nPreviousMonthDay, nPreviousMonth, nPreviousYear, nMaxVersion, sTerritoryID, nNextMonth, nNextYear, nMaxVersion);
                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }

        public DataTable GetPVPDetailInfo(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nPreviousMonthDay, int nPreviousMonth, int nPreviousYear, int nNextMonth, int nNextYear, int nMaxVersion, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                sSQL = SQL.MakeSQL("SELECT a.* FROM [PVPDetail] a INNER JOIN [PVPMaster] b ON a.PvpID=b.PvpID WHERE b.TerritoryID=%s and b.Month=%n and b.Year=%n and b.Version>%n UNION "
                + " SELECT a.* FROM [PVPDetail] a INNER JOIN [PVPMaster] b ON a.PvpID=b.PvpID WHERE b.TerritoryID=%s and a.Day>%n and b.Month=%n and b.Year=%n and b.Version>%n UNION "
                + " SELECT a.* FROM [PVPDetail] a INNER JOIN [PVPMaster] b ON a.PvpID=b.PvpID WHERE b.TerritoryID=%s and b.Month=%n and b.Year=%n and b.Version>%n", sTerritoryID, nCurrentMonth,
                nCurrentYear, nMaxVersion, sTerritoryID, nPreviousMonthDay, nPreviousMonth, nPreviousYear, nMaxVersion, sTerritoryID, nNextMonth, nNextYear, nMaxVersion);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public IDataReader GetPVPDetailInfoForRM(string sTerritoryID, int nMonth, int nYear, int nPreMonth, int nPreYear, int nMaxVersion)
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                string sSQL1 = SQL.MakeSQL("SELECT a.* FROM [PVPDetail] a INNER JOIN [PVPMaster] b ON a.PvpID=b.PvpID WHERE b.Month=%n and b.Year=%n and b.Status=%n and b.Version>%n",
                    nMonth, nYear, 2, nMaxVersion);
                sSQL1 = sSQL1 + " AND b.TerritoryID like '" + sTerritoryID + "%'";
                string sSQL2 = SQL.MakeSQL("SELECT a.* FROM [PVPDetail] a INNER JOIN [PVPMaster] b ON a.PvpID=b.PvpID WHERE b.Month=%n and b.Year=%n and b.Status=%n and a.IsHoliday=%n",
                    nMonth, nYear, 3, 1);
                sSQL2 = " UNION " + sSQL2 + " AND b.TerritoryID like '" + sTerritoryID + "%'";
                string sSQL3 = SQL.MakeSQL("SELECT a.* FROM [PVPDetail] a INNER JOIN [PVPMaster] b ON a.PvpID=b.PvpID WHERE b.Month=%n and b.Year=%n and b.Status=%n and a.IsHoliday=%n",
                    nPreMonth, nPreYear, 3, 1);
                sSQL3 = " UNION " + sSQL3 + " AND b.TerritoryID like '" + sTerritoryID + "%'";
                if (nMaxVersion==0)
                    sSQL = sSQL1 + sSQL2 + sSQL3;
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

        public DataTable GetPVPDetailInfoForRM(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nNextMonth, int nNextYear, int nMaxVersion, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                string sSQL1 = SQL.MakeSQL("SELECT a.* FROM [PVPDetail] a INNER JOIN [PVPMaster] b ON a.PvpID=b.PvpID WHERE b.Month=%n and b.Year=%n and b.Version>%n",
                nCurrentMonth, nCurrentYear, nMaxVersion);
                sSQL1 = sSQL1 + " AND b.TerritoryID like '" + sTerritoryID + "%' UNION ";
                //string sSQL2 = SQL.MakeSQL("SELECT a.* FROM [PVPDetail] a INNER JOIN [PVPMaster] b ON a.PvpID=b.PvpID WHERE b.Month=%n and b.Year=%n and b.Status=%n and a.IsHoliday=%n",
                //    nCurrentMonth, nCurrentYear, 3, 1);
                //sSQL2 = " UNION " + sSQL2 + " AND b.TerritoryID like '" + sTerritoryID + "%'";
                string sSQL3 = SQL.MakeSQL("SELECT a.* FROM [PVPDetail] a INNER JOIN [PVPMaster] b ON a.PvpID=b.PvpID WHERE b.Month=%n and b.Year=%n and b.Version>%n",
                    nNextMonth, nNextYear, nMaxVersion);
                sSQL3 = sSQL3 + " AND b.TerritoryID like '" + sTerritoryID + "%'";
                if (nMaxVersion == 0)
                    //sSQL = sSQL1 + sSQL2 + sSQL3;
                    sSQL = sSQL1 + sSQL3;
                else
                    sSQL = sSQL3;
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public DataTable GetPVPDetailInfo(string sTerritoryID, int nMonth, int nYear, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                sSQL = SQL.MakeSQL("SELECT * FROM [PVPDetail] WHERE TerritoryID = %s and Month=%n and Year=%n and IsHoliday=0", sTerritoryID, nMonth, nYear);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }
		//public bool IsDuplicate(string sPVPDetailName)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [PVPDetail] WHERE PVPDetailName=%s ", sPVPDetailName);
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
		//public bool IsDuplicate(string sPVPDetailName, int nID)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [PVPDetail] WHERE PVPDetailName=%s AND DetailID!= %n ", sPVPDetailName, nID);
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
		//public IDataReader GetPVPDetail(string sPVPDetailName)
		//{
			//string sSQL = "";
			//IDataReader oReader;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT * FROM [PVPDetail] WHERE [PVPDetailName]=%s ", sPVPDetailName);
				//oReader = ExecuteReader(sSQL);
			//}
			//catch (Exception e)
			//{
            //throw new Exception(e.Message);
			//}
			//return oReader;
		//}


        //public IDataReader GetTerritoryWisePVPDetail(String sTerritoryID)
        //{
        //    string sSQL = "";
        //    IDataReader DetailList;
        //    try
        //    {
        //        sSQL = SQL.MakeSQL("Select * FROM [FAST].[dbo].[PVPDetail] where IsHoliday=0 and TerritoryID=%s", sTerritoryID);
        //        DetailList = ExecuteReader(sSQL);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }

        //    return DetailList;
        //}

	}
}
