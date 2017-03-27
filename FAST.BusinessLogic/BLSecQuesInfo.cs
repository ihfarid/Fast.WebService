using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.BusinessLogic
{
	public partial class BLSecQuesInfo
	{
        public int GetSecQuesID(string sSQ)
        {
            Int32 nSecQuesID;
            DLSecQuesInfo oDLSecQuesInfo = new DLSecQuesInfo();
            try
            {
                nSecQuesID = oDLSecQuesInfo.GetSecQuesID(sSQ);
                return nSecQuesID;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public DataTable GetSecQuesList()
        {
            DLSecQuesInfo oDL = new DLSecQuesInfo();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetSecQuesList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }
        
        //public bool Validate(SecQuesInfo oItem)
		//{
			//DLSecQuesInfo oDL = new DLSecQuesInfo();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.SecQuesInfoName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.SecQuesInfoName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(SecQuesInfo oItem)
		{
			DLSecQuesInfo oDL = new DLSecQuesInfo();
			//if (!Validate(oItem))
			//{
				//throw new Exception("SecQuesInfo with the same Name already exist");
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
			DLSecQuesInfo oDL = new DLSecQuesInfo();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public int GetSQID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sSecQues)
        {
            int nSQID;
            DLSecQuesInfo oDL = new DLSecQuesInfo();
            try
            {
                nSQID = oDL.GetSQID(oSqlConnection, oSqlTransaction, sSecQues);
                return nSQID;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public DataTable GetSecQuesInfoInfo(string sConnectionString)
        {
            DLSecQuesInfo oDL = new DLSecQuesInfo();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetSecQuesInfoInfo(sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

		//public bool IsDuplicate(string sSecQuesInfoName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sSecQuesInfoName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sSecQuesInfoName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sSecQuesInfoName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
