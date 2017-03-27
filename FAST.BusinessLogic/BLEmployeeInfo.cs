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
	public partial class BLEmployeeInfo
	{
        public EmployeeInfo GetEmployeeInfo(string sEmpCode)
        {
            EmployeeInfo oEmployeeInfo = new EmployeeInfo();
            DLEmployeeInfo oDL = new DLEmployeeInfo();
            IDataReader oReader;
            try
            {
                oReader = oDL.GetEmployeeInfo(sEmpCode);
                try
                {
                    if (oReader.Read())
                    {
                        oEmployeeInfo = ReaderToObject(oReader);
                    }
                    oReader.Close();
                }
                catch (Exception ex)
                {
                    oReader.Close();
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oEmployeeInfo;
        }        

        public int GetEmployeeID(string sEmpCode)
        {
            Int32 nEmployeeID;
            DLEmployeeInfo oDLEmployeeInfo = new DLEmployeeInfo();
            try
            {
                nEmployeeID = oDLEmployeeInfo.GetEmployeeID(sEmpCode);
                return nEmployeeID;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public bool IsActiveEmployee(string sGDDBID)
        {
            DLEmployeeInfo oDL = new DLEmployeeInfo();
            try
            {
                return oDL.IsActiveEmployee(sGDDBID);
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public EmployeeInfo GetActiveEmployeeInfoByGDDBID(string sGDDBID)
        {
            EmployeeInfo oEmployeeInfo = new EmployeeInfo();
            DLEmployeeInfo oDL = new DLEmployeeInfo();
            IDataReader oReader;
            try
            {
                oReader = oDL.GetActiveEmployeeInfoByGDDBID(sGDDBID);
                try
                {
                    if (oReader.Read())
                    {
                        oEmployeeInfo = ReaderToObject(oReader);
                    }
                    oReader.Close();
                }
                catch (Exception ex)
                {
                    oReader.Close();
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oEmployeeInfo;
        }

        public DataTable GetActiveEmployeeInfo(string sGDDBID, string sConnectionString)
        {
            DLEmployeeInfo oDL = new DLEmployeeInfo();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetActiveEmployeeInfoByGDDBID(sGDDBID, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public int GetEmployeeID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sEmpCode)
        {
            int nEmployeeID;
            DLEmployeeInfo oDL = new DLEmployeeInfo();
            try
            {
                nEmployeeID = oDL.GetEmployeeID(oSqlConnection, oSqlTransaction, sEmpCode);
                return nEmployeeID;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        //public bool Validate(EmployeeInfo oItem)
		//{
			//DLEmployeeInfo oDL = new DLEmployeeInfo();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.EmployeeInfoName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.EmployeeInfoName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(EmployeeInfo oItem)
		{
			DLEmployeeInfo oDL = new DLEmployeeInfo();
			//if (!Validate(oItem))
			//{
				//throw new Exception("EmployeeInfo with the same Name already exist");
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
			DLEmployeeInfo oDL = new DLEmployeeInfo();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		//public bool IsDuplicate(string sEmployeeInfoName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sEmployeeInfoName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sEmployeeInfoName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sEmployeeInfoName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
