using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
	public partial class DLProduct: DAAccess
	{
		public void Insert(Product oItem)
		{
			string sSQL = "";
			try
			{
				oItem.ID.SetID(GeneratePrimaryKey("[Product]", "ProdID"));
				sSQL = SQL.MakeSQL("INSERT INTO [Product](ProdID, ProdCode, ProdName, Line, Status) "
				+ " VALUES(%n, %n, %n, %n, %n) "
				, oItem.ID.ToInt32, oItem.ProdCode,oItem.ProdName,oItem.Line,oItem.Status);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(Product oItem)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("UPDATE [Product] SET ProdCode = %n, ProdName = %n, Line = %n, Status = %n WHERE [ProdID]=%n"
				,oItem.ProdCode,oItem.ProdName,oItem.Line,oItem.Status, oItem.ID.ToInt32);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nProductID)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("DELETE FROM [Product] WHERE [ProdID]=%n"
				, nProductID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetProduct(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [Product] WHERE ProdID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetProducts()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [Product] ");
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}

        public DataTable GetProductTableByProduct(string sProductName, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL("SELECT * FROM [Product] WHERE [ProductName]=%s", sProductName);
               // string sSQL = "SELECT * FROM [Product] WHERE [ProductName]=@sProductName";
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                //oSqlDataAdapter.SelectCommand.Parameters.Add("@sProductName", sProductName);
                oSqlDataAdapter.Fill(oTable);
                // return oTable;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;

        }

        public int GetBrandID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sProductName, string sTerritoryID)
        {
            int nID = 0;
            string sSQL = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL(@"SElECT ProdID FROM [Product] WHERE [ProdName]= %s AND " +
                                   " Line = (SELECT LineID FROM [Territory] WHERE [TerritoryID] = %s)", sProductName, sTerritoryID);

                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nID = 0;
                }
                else
                {
                    nID = Convert.ToInt32(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nID;
        }
	
    
    }
}
