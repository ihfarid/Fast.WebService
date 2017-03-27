using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.BusinessLogic
{
    public partial class BLDCR
    {
        //public bool Validate(DCR oItem)
        //{
        //DLDCR oDL = new DLDCR();
        //try
        //{
        //if (oItem.IsNew)
        //{
        //return !oDL.IsDuplicate(oItem.DCRName);
        //}
        //else
        //{
        //return !oDL.IsDuplicate(oItem.DCRName, oItem.ID.ToInt32);
        //}
        //}
        //catch (Exception e)
        //{
        //throw new Exception(e.Message);
        //}
        //}
        //public void Save(DCR oItem)
        //{
        //    DLDCR oDL = new DLDCR();
        //    //if (!Validate(oItem))
        //    //{
        //        //throw new Exception("DCR with the same Name already exist");
        //    //}
        //    try
        //    {
        //        DAAccess.BeginTran();
        //        if (oItem.IsNew)
        //        {
        //            oDL.Insert(oItem);
        //        }
        //        else
        //        {
        //            oDL.Update(oItem);
        //        }
        //        DAAccess.CommitTran();
        //    }
        //    catch (Exception e)
        //    {
        //        DAAccess.RollBackTran();
        //        throw new Exception(e.Message);
        //    }
        //}
        //public void Delete(int nID)
        //{
        //    DLDCR oDL = new DLDCR();
        //    try
        //    {
        //        oDL.Delete(nID);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}
        //public bool IsDuplicate(string sDCRName)
        //{
        //try
        //{
        //DLUser oDL = new DLUser();
        //return oDL.IsDuplicate(sDCRName);
        //}
        //catch (Exception e)
        //{
        //throw new Exception(e.Message);
        //}
        //}
        //public bool IsDuplicate(string sDCRName, int nID)
        //{
        //try
        //{
        //DLUser oDL = new DLUser();
        //return oDL.IsDuplicate(sDCRName, nID);
        //}
        //catch (Exception e)
        //{
        //throw new Exception(e.Message);
        //}

        public int Save(DCR oItem, SqlConnection myConnection, SqlTransaction myTransaction)
        {
            DLDCR oDL = new DLDCR();
            int i = 0;
            try
            {
                if (oItem.IsNew)
                {
                    i = oDL.InsertDCRForNewVisit(oItem, myConnection, myTransaction);
                }
                else
                {
                    i = oDL.UpdateDCR(oItem, myConnection, myTransaction);
                }
            }
            catch (Exception e)
            {
                i = -1;
                throw new Exception(e.Message);
            }
            return i;
        }

        public int UpdateDCRDoctotNotAvailableStatus(int nDoctorID, string sTerritoryID, int nDay, int nMonth, int nYear, int nStatus,
                             int nIsAvailable, int nNotAvailableReasonID, string sNotAvailableReason, string sSubmitDateTime, int nSubmittedBy,
            int nAction, int nVersion, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            DLDCR oDL = new DLDCR();
            int i = 0;
            try
            {
                i = oDL.UpdateDCRDoctotNotAvailableStatus(nDoctorID,sTerritoryID,nDay,nMonth,nYear,nStatus,nIsAvailable,
                                                           nNotAvailableReasonID, sNotAvailableReason, sSubmitDateTime, nSubmittedBy,
                                                           nAction, nVersion, oSqlConnection,  oSqlTransaction);
            }
            catch (Exception e)
            {
                i = 0;
                throw new Exception(e.Message);
            }
            return i;
        }


        public DCRs GetDCRInfo(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nPreviousMonth, int nPreviousYear, int nPreviousMonthDay, int nMaxVersion)
        {
            DCRs oDCRs;
            DLDCR oDL = new DLDCR();
            try
            {
                oDCRs = ReaderToObjects(oDL.GetDCRInfo(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonth, nPreviousYear, nPreviousMonthDay, nMaxVersion));
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return oDCRs;
        
        }

        public DataTable GetDCRInfo(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nPreviousMonth, int nPreviousYear, int nPreviousMonthDay, int nMaxVersion, string sConnectionString)
        {
            DLDCR oDL = new DLDCR();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetDCRInfo(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonth, nPreviousYear, nPreviousMonthDay, nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public DCRs GetDCRInfoForRM(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nPreviousMonth, int nPreviousYear, int nPreviousMonthDay, int nMaxVersion)
        {
            DCRs oDCRs;
            DLDCR oDL = new DLDCR();
            try
            {
                oDCRs = ReaderToObjects(oDL.GetDCRInfoForRM(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonth, nPreviousYear, nPreviousMonthDay, nMaxVersion));
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return oDCRs;
        }

        public DataTable GetDCRInfoForRM(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nPreviousMonth, int nPreviousYear, int nPreviousMonthDay, int nMaxVersion, string sConnectionString)
        {
            DLDCR oDL = new DLDCR();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetDCRInfoForRM(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonth, nPreviousYear, nPreviousMonthDay, nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }


        //public void GetTerritoryWisePVPDetail(String sTerritoryID)
        //{
        //    DLPVPDetail oDLPVPDetail= new DLPVPDetail();          
        
        //    try 
        //    {
        //       oDLPVPDetail.GetTerritoryWisePVPDetail(sTerritoryID);
        //    }
             
        //    catch (Exception err)
        //    {
        //        throw new Exception(err.Message);
        //    }

        
        //}


    }
}
