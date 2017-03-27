using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
	public partial class DLPVPWorkingDay: DAAccess
	{
        public DataTable GetPVPWorkingDay(int nMaxVersion, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                if (nMaxVersion == 0)
                    sSQL = SQL.MakeSQL("SELECT * FROM [PVPWorkingDay] WHERE Version>%n and Action !=%n", nMaxVersion, 3);
                else
                    sSQL = SQL.MakeSQL("SELECT * FROM [PVPWorkingDay] WHERE Version>%n", nMaxVersion);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        //public bool IsDuplicate(string sPVPWorkingDayName)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [PVPWorkingDay] WHERE PVPWorkingDayName=%s ", sPVPWorkingDayName);
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
		//public bool IsDuplicate(string sPVPWorkingDayName, int nID)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [PVPWorkingDay] WHERE PVPWorkingDayName=%s AND MonthID!= %n ", sPVPWorkingDayName, nID);
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
		//public IDataReader GetPVPWorkingDay(string sPVPWorkingDayName)
		//{
			//string sSQL = "";
			//IDataReader oReader;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT * FROM [PVPWorkingDay] WHERE [PVPWorkingDayName]=%s ", sPVPWorkingDayName);
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
