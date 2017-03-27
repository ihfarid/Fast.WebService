using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using System.Data.SqlClient;

namespace FAST.BusinessLogic
{
	public partial class BLProduct
	{
		private Product ReaderToObject(IDataReader oReader)
		{
			Product oItem = new Product();
			oItem.ID.SetID(oReader["ProdID"]);
oItem.Status =Convert.ToInt32( oReader["Status"]);
			return oItem;
		}
		private Products ReaderToObjects(IDataReader oReader)
		{
			Products oItems;
			Product oItem;
			oItems = new Products();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
			return oItems;
		}
		public Products GetProducts()
		{
			Products oProducts;
			DLProduct oDL = new DLProduct();
			try
			{
				oProducts = ReaderToObjects(oDL.GetProducts());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oProducts;
		}
		public Product GetProduct(int nID)
		{
			Product oProduct = new Product();
			DLProduct oDL = new DLProduct();
			IDataReader oReader;
			try
			{
				oReader = oDL.GetProduct(nID);
				if (oReader.Read())
				{
					oProduct = ReaderToObject(oReader);
				}
				oReader.Close();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oProduct;
		}

        public DataTable GetProductTableByProduct(string sProductName, string sConnectionString)
        {

            DataTable oTable = new DataTable();
            DLProduct oDL = new DLProduct();
            try
            {
                oTable = oDL.GetProductTableByProduct(sProductName, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }



        public int GetBrandID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sSampleName, string sTerritoryID)
        {
            Int32 nBrandID;
            DLProduct oDL = new DLProduct();
            try
            {
                nBrandID = oDL.GetBrandID(oSqlConnection, oSqlTransaction, sSampleName, sTerritoryID);
                return nBrandID;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }
	}
}
