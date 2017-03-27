using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.BusinessLogic
{
	public partial class BLProduct
	{
		//public bool Validate(Product oItem)
		//{
			//DLProduct oDL = new DLProduct();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.ProductName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.ProductName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(Product oItem)
		{
			DLProduct oDL = new DLProduct();
			//if (!Validate(oItem))
			//{
				//throw new Exception("Product with the same Name already exist");
			//}
			try
			{
				DAAccess.BeginTran();
				if (oItem.IsNew)
				{
					oDL.Insert(oItem);
				}
				else
				{
					oDL.Update(oItem);
				}
				DAAccess.CommitTran();
			}
			catch (Exception e)
			{
				DAAccess.RollBackTran();
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nID)
		{
			DLProduct oDL = new DLProduct();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public int GetProductID(string sProductCode, string sTerritoryID)
        {
            Int32 nProductID;
            DLProduct oDL = new DLProduct();
            try
            {
                nProductID = oDL.GetProductID(sProductCode, sTerritoryID);
                return nProductID;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public string GetProductCode(int nProductID)
        {
            string sProdID;
            DLProduct oDL = new DLProduct();
            try
            {
                sProdID = oDL.GetProductCode(nProductID);
                return sProdID;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public int GetBrandID(string sProductCode, string sTerritoryID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nBrandID;
            DLProduct oDL = new DLProduct();
            try
            {
                nBrandID = oDL.GetBrandID(sProductCode, sTerritoryID, oSqlConnection, oSqlTransaction);
                return nBrandID;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

		//public bool IsDuplicate(string sProductName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sProductName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sProductName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sProductName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
