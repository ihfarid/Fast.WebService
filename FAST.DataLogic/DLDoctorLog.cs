using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
	public partial class DLDoctorLog: DAAccess
	{
		//public bool IsDuplicate(string sDoctorLogName)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [DoctorLog] WHERE DoctorLogName=%s ", sDoctorLogName);
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
		//public bool IsDuplicate(string sDoctorLogName, int nID)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [DoctorLog] WHERE DoctorLogName=%s AND DoctorLogID!= %n ", sDoctorLogName, nID);
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
		//public IDataReader GetDoctorLog(string sDoctorLogName)
		//{
			//string sSQL = "";
			//IDataReader oReader;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT * FROM [DoctorLog] WHERE [DoctorLogName]=%s ", sDoctorLogName);
				//oReader = ExecuteReader(sSQL);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
			//return oReader;
		//}

        public DataTable GetDocotorLogInfo(int nDoctorLogID, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                sSQL = SQL.MakeSQL("SELECT * FROM [DoctorLog] WHERE DoctorLogID=%n", nDoctorLogID);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public DataTable GetDocotorLogInfoForRM(String sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                if (nMaxVersion == 0)
                {
                    sSQL = SQL.MakeSQL("SELECT * FROM [DoctorLog] WHERE Version>%n and Action !=%n and (Status =%n OR Status=%n)", nMaxVersion, 3, 1, 3);
                    sSQL = sSQL + " and TerritoryID like '" + sTerritoryID + "%'";
                }
                else
                {
                    sSQL = SQL.MakeSQL("SELECT * FROM [DoctorLog] WHERE Version>%n and (Status =%n OR Status=%n)", nMaxVersion, 1, 3);
                    sSQL = sSQL + " and TerritoryID like '" + sTerritoryID + "%'";
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

        public DataTable GetDoctorLogInfo(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {

            string sSQL = "";
            DataTable oTable = new DataTable();
            try
            {
                sSQL = SQL.MakeSQL("SELECT DoctorLogID,DoctorUpdateReqID,DoctorTerritoryMappingID,DocID,TransferReason,Status,Type,case when year(CreationDate)=9999 then '' else CONVERT(varchar(20),CreationDate,106) end as CreationDate,Action,Version FROM DoctorLog WHERE CreationDate between DATEADD(d,-30,GETDATE()) and GETDATE() and TerritoryID = %s and Version > %n", sTerritoryID, nMaxVersion);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
                //oTable = FillDataTable(sSQL, "DoctorLogList");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public int GetDMRVersion(string sTerritoryID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            int nLock;
            try
            {
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL(@"SELECT MAX(Version) FROM DoctorLog WHERE TerritoryID = %s", sTerritoryID);
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nLock = 0;
                }
                else
                {
                    nLock = Convert.ToInt32(o);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nLock;
        }

        public int GetDMRAction(string sTerritoryID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            int nLock;
            try
            {
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL(@"SELECT MAX(Action) FROM DoctorLog WHERE TerritoryID = %s", sTerritoryID);
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nLock = 0;
                }
                else
                {
                    nLock = Convert.ToInt32(o);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nLock;
        }

        public int GetMaxDoctorLogVersion(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nMaxDoctorLogVersion;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SELECT MAX(Version)+ 1 Version FROM [DoctorLog]");
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nMaxDoctorLogVersion = 1;
                }
                else
                {
                    nMaxDoctorLogVersion = Convert.ToInt32(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nMaxDoctorLogVersion;
        }
	}
}
