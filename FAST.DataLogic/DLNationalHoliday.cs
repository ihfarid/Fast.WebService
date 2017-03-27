using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
	public partial class DLNationalHoliday: DAAccess
    {
        public IDataReader GetNationalHolidays(int nMaxVersion)
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                if (nMaxVersion == 0)
                    sSQL = SQL.MakeSQL("SELECT * FROM [NationalHoliday] WHERE Version>%n and Action !=%n", nMaxVersion, 3);
                else
                    sSQL = SQL.MakeSQL("SELECT * FROM [NationalHoliday] WHERE Version>%n", nMaxVersion);
                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }

        public DataTable GetNationalHolidayInfo(int nMaxVersion, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                if (nMaxVersion == 0)
                    sSQL = SQL.MakeSQL("SELECT * FROM [NationalHoliday] WHERE Version>%n and Action !=%n", nMaxVersion, 3);
                else
                    sSQL = SQL.MakeSQL("SELECT * FROM [NationalHoliday] WHERE Version>%n", nMaxVersion);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }
        //public bool IsDuplicate(string sNationalHolidayName)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [NationalHoliday] WHERE NationalHolidayName=%s ", sNationalHolidayName);
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
		//public bool IsDuplicate(string sNationalHolidayName, int nID)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [NationalHoliday] WHERE NationalHolidayName=%s AND HolidayID!= %n ", sNationalHolidayName, nID);
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
		//public IDataReader GetNationalHoliday(string sNationalHolidayName)
		//{
			//string sSQL = "";
			//IDataReader oReader;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT * FROM [NationalHoliday] WHERE [NationalHolidayName]=%s ", sNationalHolidayName);
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
