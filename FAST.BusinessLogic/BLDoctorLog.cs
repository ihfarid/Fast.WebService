using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;
using System.Threading;

namespace FAST.BusinessLogic
{
	public partial class BLDoctorLog
	{
		//public bool Validate(DoctorLog oItem)
		//{
			//DLDoctorLog oDL = new DLDoctorLog();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.DoctorLogName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.DoctorLogName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(DoctorLog oItem)
		{
			DLDoctorLog oDL = new DLDoctorLog();
			//if (!Validate(oItem))
			//{
				//throw new Exception("DoctorLog with the same Name already exist");
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
			DLDoctorLog oDL = new DLDoctorLog();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public DataTable GetDocotorLogInfoForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DLDoctorLog oDL = new DLDoctorLog();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetDocotorLogInfoForRM(sTerritoryID, nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public DataTable GetDoctorLogInfo(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DLDoctorLog oDL = new DLDoctorLog();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetDoctorLogInfo(sTerritoryID, nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public int GetDMRVersion(string sTerritoryID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            DLDoctorLog oDL = new DLDoctorLog();
            int oCount;

            try
            {
                oCount = oDL.GetDMRVersion(sTerritoryID, oSqlConnection, oSqlTransaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oCount;
        }

        public int GetDMRAction(string sTerritoryID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            DLDoctorLog oDL = new DLDoctorLog();
            int oCount;

            try
            {
                oCount = oDL.GetDMRAction(sTerritoryID, oSqlConnection, oSqlTransaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oCount;
        }

        public DataTable GetDocotorLogInfo(int nDoctorLogID, string sConnectionString)
        {
            DLDoctorLog oDL = new DLDoctorLog();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetDocotorLogInfo(nDoctorLogID, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public int GetMaxDoctorLogVersion(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nMaxDoctorLogVersion;
            DLDoctorLog oDL = new DLDoctorLog();
            try
            {
                nMaxDoctorLogVersion = oDL.GetMaxDoctorLogVersion(oSqlConnection, oSqlTransaction);
                return nMaxDoctorLogVersion;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public int Save(DoctorLog oItem, SqlConnection myConnection, SqlTransaction myTransaction)
        {
            DLDoctorLog oDL = new DLDoctorLog();
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

		//public bool IsDuplicate(string sDoctorLogName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sDoctorLogName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sDoctorLogName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sDoctorLogName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
