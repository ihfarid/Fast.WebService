using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.BusinessLogic
{
	public partial class BLCommandInfo
	{
		//public bool Validate(CommandInfo oItem)
		//{
			//DLCommandInfo oDL = new DLCommandInfo();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.CommandInfoName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.CommandInfoName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(CommandInfo oItem)
		{
			DLCommandInfo oDL = new DLCommandInfo();
			//if (!Validate(oItem))
			//{
				//throw new Exception("CommandInfo with the same Name already exist");
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
			DLCommandInfo oDL = new DLCommandInfo();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public CommandInfos GetCommandInfos(string sTerritoryID)
        {
            CommandInfos oCommandInfos;
            DLCommandInfo oDL = new DLCommandInfo();
            try
            {
                oCommandInfos = ReaderToObjects(oDL.GetCommandInfos(sTerritoryID));
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return oCommandInfos;
        }

        public DataTable GetCommand(string sTerritoryID, string sConnectionString)
        {
            DLCommandInfo oDL = new DLCommandInfo();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetCommand(sTerritoryID, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public DataTable GetCommand(int nID, string sConnectionString)
        {
            DLCommandInfo oDL = new DLCommandInfo();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetCommand(nID, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public int Save(CommandInfo oItem, SqlConnection myConnection, SqlTransaction myTransaction)
        {
            DLCommandInfo oDL = new DLCommandInfo();
            int i = 0;
            try
            {
                if (oItem.IsNew)
                {
                    i = oDL.Insert(oItem, myConnection, myTransaction);
                }
                else
                {
                    i = oDL.Update(oItem, myConnection, myTransaction);
                }
            }
            catch (Exception e)
            {
                i = 0;
                throw new Exception(e.Message);
            }
            return i;
        }

        public bool IsPVPTimeExtend(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sTerritoryID, string sPVPEndDate)
        {
            DLCommandInfo oDL = new DLCommandInfo();
            try
            {
                return oDL.IsPVPTimeExtend(oSqlConnection, oSqlTransaction, sTerritoryID, sPVPEndDate);
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public string GetPVPEndDate(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sTerritoryID)
        {
            string sPVPEndDate;
            DLCommandInfo oDL = new DLCommandInfo();
            try
            {
                sPVPEndDate = oDL.GetPVPEndDate(oSqlConnection, oSqlTransaction, sTerritoryID);
                return sPVPEndDate;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public int GetDCREntryHours(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sTerritoryID)
        {
            int nDCREntryHours;
            DLCommandInfo oDL = new DLCommandInfo();
            try
            {
                nDCREntryHours = oDL.GetDCREntryHours(oSqlConnection, oSqlTransaction, sTerritoryID);
                return nDCREntryHours;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public int InsertCommandInfo(string sTerritoryID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nResult;
            DLCommandInfo oDL = new DLCommandInfo();
            try
            {
                nResult = oDL.InsertCommandInfo(sTerritoryID, oSqlConnection, oSqlTransaction);
                return nResult;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

		//public bool IsDuplicate(string sCommandInfoName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sCommandInfoName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sCommandInfoName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sCommandInfoName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
