using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
	public partial class DLProduct: DAAccess
	{

        public int GetProductID(string sProductCode, string sTerritoryID)
        {
            string sQuery;
            object oProductID;
            int nProductID;
            try
            {
                sQuery = SQL.MakeSQL("SELECT a.[ProdID] FROM [Product] a INNER JOIN [Territory] b ON a.Line=b.LineID WHERE a.ProdCode=%s and b.TerritoryID=%s", sProductCode, sTerritoryID);
                oProductID = ExecuteScalar(sQuery);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return nProductID = Convert.ToInt32(oProductID);
        }

        public string GetProductCode(int nProductID)
        {
            string sQuery;
            object oProductID;
            string sProdID;
            try
            {
                sQuery = SQL.MakeSQL("SELECT ProdCode+'-'+ProdName FROM [Product] WHERE ProdID=%n", nProductID);
                oProductID = ExecuteScalar(sQuery);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return sProdID = Convert.ToString(oProductID);
        }

        public int GetBrandID(string sProductCode, string sTerritoryID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nBrandID = 0;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SELECT a.[ProdID] FROM [Product] a INNER JOIN [Territory] b ON a.Line=b.LineID WHERE a.ProdCode=%s and b.TerritoryID=%s", sProductCode, sTerritoryID);
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nBrandID = 1;
                }
                else
                {
                    nBrandID = Convert.ToInt32(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nBrandID;
        }

		//public bool IsDuplicate(string sProductName)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [Product] WHERE ProductName=%s ", sProductName);
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
		//public bool IsDuplicate(string sProductName, int nID)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [Product] WHERE ProductName=%s AND ProdID!= %n ", sProductName, nID);
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
        //public IDataReader GetProduct(string sProductName)
        //{
        //    string sSQL = "";
        //    IDataReader oReader;
        //    try
        //    {
        //        sSQL = SQL.MakeSQL("SELECT * FROM [Product] WHERE [ProductName]=%s ", sProductName);
        //        oReader = ExecuteReader(sSQL);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //    return oReader;
        //}

       
	}
}
