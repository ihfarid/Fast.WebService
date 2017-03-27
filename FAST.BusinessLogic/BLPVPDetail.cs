using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.BusinessLogic
{
	public partial class BLPVPDetail
	{
		//public bool Validate(PVPDetail oItem)
		//{
			//DLPVPDetail oDL = new DLPVPDetail();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.PVPDetailName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.PVPDetailName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(PVPDetail oItem)
		{
			DLPVPDetail oDL = new DLPVPDetail();
			//if (!Validate(oItem))
			//{
				//throw new Exception("PVPDetail with the same Name already exist");
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
			DLPVPDetail oDL = new DLPVPDetail();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public PVPDetails GetPVPDetailInfo(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nPreviousMonthDay, int nPreviousMonth, int nPreviousYear, int nNextMonth, int nNextYear, int nMaxVersion)
        {
            PVPDetails oPVPDetails;
            DLPVPDetail oDL = new DLPVPDetail();
            try
            {
                oPVPDetails = ReaderToObjects(oDL.GetPVPDetailInfo(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonthDay, nPreviousMonth, nPreviousYear, nNextMonth, nNextYear, nMaxVersion));
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return oPVPDetails;
        }

        public DataTable GetPVPDetailInfo(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nPreviousMonthDay, int nPreviousMonth, int nPreviousYear, int nNextMonth, int nNextYear, int nMaxVersion, string sConnectionString)
        {
            DLPVPDetail oDL = new DLPVPDetail();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetPVPDetailInfo(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonthDay, nPreviousMonth, nPreviousYear, nNextMonth, nNextYear, nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public PVPDetails GetPVPDetailInfoForRM(string sTerritoryID, int nMonth, int nYear, int nPreMonth, int nPreYear, int nMaxVersion)
        {
            PVPDetails oPVPDetails;
            DLPVPDetail oDL = new DLPVPDetail();
            try
            {
                oPVPDetails = ReaderToObjects(oDL.GetPVPDetailInfoForRM(sTerritoryID, nMonth, nYear, nPreMonth, nPreYear, nMaxVersion));
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return oPVPDetails;
        }

        public DataTable GetPVPDetailInfoForRM(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nNextMonth, int nNextYear, int nMaxVersion, string sConnectionString)
        {
            DLPVPDetail oDL = new DLPVPDetail();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetPVPDetailInfoForRM(sTerritoryID, nCurrentMonth, nCurrentYear, nNextMonth, nNextYear, nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public DataTable GetPVPDetailInfo(string sTerritoryID, int nMonth, int nYear, string sConnectionString)
        {
            DLPVPDetail oDL = new DLPVPDetail();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetPVPDetailInfo(sTerritoryID, nMonth, nYear, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public int Save(PVPDetail oItem, SqlConnection myConnection, SqlTransaction myTransaction)
        {
            DLPVPDetail oDL = new DLPVPDetail();
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

        public int Delete(int nPVPID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            DLPVPDetail oDL = new DLPVPDetail();
            int i = 0;
            try
            {
                i = oDL.Delete(nPVPID, oSqlConnection, oSqlTransaction);
            }
            catch (Exception e)
            {
                i = 0;
                throw new Exception(e.Message);
            }
            return i;
        }

		//public bool IsDuplicate(string sPVPDetailName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sPVPDetailName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sPVPDetailName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sPVPDetailName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
