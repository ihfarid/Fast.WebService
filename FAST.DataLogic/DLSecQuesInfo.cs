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
	public partial class DLSecQuesInfo: DAAccess
	{
        public int GetSecQuesID(string sSQ)
        {
            string sQuery;
            object oSecQuesID;
            int nSecQuesID;
            try
            {
                sQuery = SQL.MakeSQL(@"SELECT SecQuesID FROM [OrderCollectionSystem].[dbo].[SecQuesInfo] WHERE SecQues=%s", sSQ);
                oSecQuesID = ExecuteScalar(sQuery);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return nSecQuesID = Convert.ToInt32(oSecQuesID);
        }

        public DataTable GetSecQuesList()
        {

            string sSQL = "";
            DataTable oTable = new DataTable();
            try
            {
                sSQL = SQL.MakeSQL(@"SELECT * FROM [OrderCollectionSystem].[dbo].[SecQuesInfo] ORDER BY SecQues");
                oTable = FillDataTable(sSQL, "SecQuesInfo");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public DataTable GetSecQuesInfoInfo(string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                sSQL = SQL.MakeSQL(@"SELECT * FROM [OrderCollectionSystem].[dbo].[SecQuesInfo] WHERE ActionType !=%n ORDER BY SecQues", 3);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public int GetSQID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sSecQues)
        {
            int nSQID;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SELECT SecQuesID FROM [OrderCollectionSystem].[dbo].[SecQuesInfo] WHERE SecQues=%s", sSecQues);
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nSQID = 0;
                }
                else
                {
                    nSQID = Convert.ToInt32(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nSQID;
        }
        
        //public bool IsDuplicate(string sSecQuesInfoName)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [SecQuesInfo] WHERE SecQuesInfoName=%s ", sSecQuesInfoName);
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
		//public bool IsDuplicate(string sSecQuesInfoName, int nID)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [SecQuesInfo] WHERE SecQuesInfoName=%s AND SecQuesID!= %n ", sSecQuesInfoName, nID);
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
		//public IDataReader GetSecQuesInfo(string sSecQuesInfoName)
		//{
			//string sSQL = "";
			//IDataReader oReader;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT * FROM [SecQuesInfo] WHERE [SecQuesInfoName]=%s ", sSecQuesInfoName);
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
