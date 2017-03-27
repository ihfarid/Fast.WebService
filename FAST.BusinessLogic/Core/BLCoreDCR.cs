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
    public partial class BLDCR
    {
        private DCR ReaderToObject(IDataReader oReader)
        {
            DCR oItem = new DCR();
             oItem.ID.SetID(oReader["DcrID"]);
             oItem.DcrID = oItem.ID.ToInt32;
            if (!oReader["PvpDetailID"].Equals(DBNull.Value))
            {
                oItem.PvpDetailID = Convert.ToInt32(oReader["PvpDetailID"]);
            }
            if (!oReader["DoctorID"].Equals(DBNull.Value))
            {
                oItem.DoctorID = Convert.ToInt32(oReader["DoctorID"]);
            }
            if (!oReader["TerritoryID"].Equals(DBNull.Value))
            {
                oItem.TerritoryID = oReader["TerritoryID"].ToString();
            }
            if (!oReader["Day"].Equals(DBNull.Value))
            {
                oItem.Day = Convert.ToInt32(oReader["Day"]);
            }
            if (!oReader["Month"].Equals(DBNull.Value))
            {
                oItem.Month = Convert.ToInt32(oReader["Month"]);
            }
            if (!oReader["Year"].Equals(DBNull.Value))
            {
                oItem.Year = Convert.ToInt32(oReader["Year"]);
            }
            if (!oReader["Status"].Equals(DBNull.Value))
            {
                oItem.Status = Convert.ToInt32(oReader["Status"]);
            }
            if (!oReader["VisitDateTime"].Equals(DBNull.Value))
            {
                oItem.VisitDateTime = Convert.ToDateTime(oReader["VisitDateTime"]);
            }
            if (!oReader["IsVisited"].Equals(DBNull.Value))
            {
                oItem.IsVisited = Convert.ToBoolean(oReader["IsVisited"]);
            }
            if (!oReader["IsAvailable"].Equals(DBNull.Value))
            {
                oItem.IsAvailable = Convert.ToBoolean(oReader["IsAvailable"]);
            }
            if (!oReader["IsAccompanyByRM_RM"].Equals(DBNull.Value))
            {
                oItem.IsAccompanyByRM_RM = Convert.ToBoolean(oReader["IsAccompanyByRM_RM"]);
            }
            if (!oReader["IsAccompanyByRM_SF"].Equals(DBNull.Value))
            {
                oItem.IsAccompanyByRM_SF = Convert.ToBoolean(oReader["IsAccompanyByRM_SF"]);
            }
            if (!oReader["ReminderNextCall"].Equals(DBNull.Value))
            {
                oItem.ReminderNextCall = oReader["ReminderNextCall"].ToString();
            }
            if (!oReader["NotAvailableReasonID"].Equals(DBNull.Value))
            {
                oItem.NotAvailableReasonID = Convert.ToInt32(oReader["NotAvailableReasonID"]);
            }
            if (!oReader["NotAvailableReason"].Equals(DBNull.Value))
            {
                oItem.NotAvailableReason = oReader["NotAvailableReason"].ToString();
            }
            if (!oReader["IsNewVisit"].Equals(DBNull.Value))
            {
                oItem.IsNewVisit = Convert.ToBoolean(oReader["IsNewVisit"]);
            }
            if (!oReader["Session"].Equals(DBNull.Value))
            {
                oItem.Session = oReader["Session"].ToString();
            }
            if (!oReader["Brand1"].Equals(DBNull.Value))
            {
                oItem.Brand1 = Convert.ToInt32(oReader["Brand1"]);
            }
            if (!oReader["Brand1Gimmick1"].Equals(DBNull.Value))
            {
                oItem.Brand1Gimmick1 = Convert.ToInt32(oReader["Brand1Gimmick1"]);
            }
            if (!oReader["Brand1Gimmick2"].Equals(DBNull.Value))
            {
                oItem.Brand1Gimmick2 = Convert.ToInt32(oReader["Brand1Gimmick2"]);
            }
            if (!oReader["Brand1Gimmick3"].Equals(DBNull.Value))
            {
                oItem.Brand1Gimmick3 = Convert.ToInt32(oReader["Brand1Gimmick3"]);
            }
            if (!oReader["Brand1Sample1"].Equals(DBNull.Value))
            {
                oItem.Brand1Sample1 = Convert.ToInt32(oReader["Brand1Sample1"]);
            }
            if (!oReader["Brand1Sample2"].Equals(DBNull.Value))
            {
                oItem.Brand1Sample2 = Convert.ToInt32(oReader["Brand1Sample2"]);
            }
            if (!oReader["Brand1Sample3"].Equals(DBNull.Value))
            {
                oItem.Brand1Sample3 = Convert.ToInt32(oReader["Brand1Sample3"]);
            }
            if (!oReader["Brand1Gimmick1Qty"].Equals(DBNull.Value))
            {
                oItem.Brand1Gimmick1Qty = Convert.ToInt32(oReader["Brand1Gimmick1Qty"]);
            }
            if (!oReader["Brand1Gimmick2Qty"].Equals(DBNull.Value))
            {
                oItem.Brand1Gimmick2Qty = Convert.ToInt32(oReader["Brand1Gimmick2Qty"]);
            }
            if (!oReader["Brand1Gimmick3Qty"].Equals(DBNull.Value))
            {
                oItem.Brand1Gimmick3Qty = Convert.ToInt32(oReader["Brand1Gimmick3Qty"]);
            }
            if (!oReader["Brand1Sample1Qty"].Equals(DBNull.Value))
            {
                oItem.Brand1Sample1Qty = Convert.ToInt32(oReader["Brand1Sample1Qty"]);
            }
            if (!oReader["Brand1Sample2Qty"].Equals(DBNull.Value))
            {
                oItem.Brand1Sample2Qty = Convert.ToInt32(oReader["Brand1Sample2Qty"]);
            }
            if (!oReader["Brand1Sample3Qty"].Equals(DBNull.Value))
            {
                oItem.Brand1Sample3Qty = Convert.ToInt32(oReader["Brand1Sample3Qty"]);
            }
            if (!oReader["Brand2"].Equals(DBNull.Value))
            {
                oItem.Brand2 = Convert.ToInt32(oReader["Brand2"]);
            }
            if (!oReader["Brand2Gimmick1"].Equals(DBNull.Value))
            {
                oItem.Brand2Gimmick1 = Convert.ToInt32(oReader["Brand2Gimmick1"]);
            }
            if (!oReader["Brand2Gimmick2"].Equals(DBNull.Value))
            {
                oItem.Brand2Gimmick2 = Convert.ToInt32(oReader["Brand2Gimmick2"]);
            }
            if (!oReader["Brand2Gimmick3"].Equals(DBNull.Value))
            {
                oItem.Brand2Gimmick3 = Convert.ToInt32(oReader["Brand2Gimmick3"]);
            }
            if (!oReader["Brand2Sample1"].Equals(DBNull.Value))
            {
                oItem.Brand2Sample1 = Convert.ToInt32(oReader["Brand2Sample1"]);
            }
            if (!oReader["Brand2Sample2"].Equals(DBNull.Value))
            {
                oItem.Brand2Sample2 = Convert.ToInt32(oReader["Brand2Sample2"]);
            }
            if (!oReader["Brand2Sample3"].Equals(DBNull.Value))
            {
                oItem.Brand2Sample3 = Convert.ToInt32(oReader["Brand2Sample3"]);
            }
            if (!oReader["Brand2Gimmick1Qty"].Equals(DBNull.Value))
            {
                oItem.Brand2Gimmick1Qty = Convert.ToInt32(oReader["Brand2Gimmick1Qty"]);
            }
            if (!oReader["Brand2Gimmick2Qty"].Equals(DBNull.Value))
            {
                oItem.Brand2Gimmick2Qty = Convert.ToInt32(oReader["Brand2Gimmick2Qty"]);
            }
            if (!oReader["Brand2Gimmick3Qty"].Equals(DBNull.Value))
            {
                oItem.Brand2Gimmick3Qty = Convert.ToInt32(oReader["Brand2Gimmick3Qty"]);
            }
            if (!oReader["Brand2Sample1Qty"].Equals(DBNull.Value))
            {
                oItem.Brand2Sample1Qty = Convert.ToInt32(oReader["Brand2Sample1Qty"]);
            }
            if (!oReader["Brand2Sample2Qty"].Equals(DBNull.Value))
            {
                oItem.Brand2Sample2Qty = Convert.ToInt32(oReader["Brand2Sample2Qty"]);
            }
            if (!oReader["Brand2Sample3Qty"].Equals(DBNull.Value))
            {
                oItem.Brand2Sample3Qty = Convert.ToInt32(oReader["Brand2Sample3Qty"]);
            }
            if (!oReader["Brand3"].Equals(DBNull.Value))
            {
                oItem.Brand3 = Convert.ToInt32(oReader["Brand3"]);
            }
            if (!oReader["Brand3Gimmick1"].Equals(DBNull.Value))
            {
                oItem.Brand3Gimmick1 = Convert.ToInt32(oReader["Brand3Gimmick1"]);
            }
            if (!oReader["Brand3Gimmick2"].Equals(DBNull.Value))
            {
                oItem.Brand3Gimmick2 = Convert.ToInt32(oReader["Brand3Gimmick2"]);
            }
            if (!oReader["Brand3Gimmick3"].Equals(DBNull.Value))
            {
                oItem.Brand3Gimmick3 = Convert.ToInt32(oReader["Brand3Gimmick3"]);
            }
            if (!oReader["Brand3Sample1"].Equals(DBNull.Value))
            {
                oItem.Brand3Sample1 = Convert.ToInt32(oReader["Brand3Sample1"]);
            }
            if (!oReader["Brand3Sample2"].Equals(DBNull.Value))
            {
                oItem.Brand3Sample2 = Convert.ToInt32(oReader["Brand3Sample2"]);
            }
            if (!oReader["Brand3Sample3"].Equals(DBNull.Value))
            {
                oItem.Brand3Sample3 = Convert.ToInt32(oReader["Brand3Sample3"]);
            }
            if (!oReader["Brand3Gimmick1Qty"].Equals(DBNull.Value))
            {
                oItem.Brand3Gimmick1Qty = Convert.ToInt32(oReader["Brand3Gimmick1Qty"]);
            }
            if (!oReader["Brand3Gimmick2Qty"].Equals(DBNull.Value))
            {
                oItem.Brand3Gimmick2Qty = Convert.ToInt32(oReader["Brand3Gimmick2Qty"]);
            }
            if (!oReader["Brand3Gimmick3Qty"].Equals(DBNull.Value))
            {
                oItem.Brand3Gimmick3Qty = Convert.ToInt32(oReader["Brand3Gimmick3Qty"]);
            }
            if (!oReader["Brand3Sample1Qty"].Equals(DBNull.Value))
            {
                oItem.Brand3Sample1Qty = Convert.ToInt32(oReader["Brand3Sample1Qty"]);
            }
            if (!oReader["Brand3Sample2Qty"].Equals(DBNull.Value))
            {
                oItem.Brand3Sample2Qty = Convert.ToInt32(oReader["Brand3Sample2Qty"]);
            }
            if (!oReader["Brand3Sample3Qty"].Equals(DBNull.Value))
            {
                oItem.Brand3Sample3Qty = Convert.ToInt32(oReader["Brand3Sample3Qty"]);
            }
            if (!oReader["Brand4"].Equals(DBNull.Value))
            {
                oItem.Brand4 = Convert.ToInt32(oReader["Brand4"]);
            }
            if (!oReader["Brand4Gimmick1"].Equals(DBNull.Value))
            {
                oItem.Brand4Gimmick1 = Convert.ToInt32(oReader["Brand4Gimmick1"]);
            }
            if (!oReader["Brand4Gimmick2"].Equals(DBNull.Value))
            {
                oItem.Brand4Gimmick2 = Convert.ToInt32(oReader["Brand4Gimmick2"]);
            }
            if (!oReader["Brand4Gimmick3"].Equals(DBNull.Value))
            {
                oItem.Brand4Gimmick3 = Convert.ToInt32(oReader["Brand4Gimmick3"]);
            }
            if (!oReader["Brand4Sample1"].Equals(DBNull.Value))
            {
                oItem.Brand4Sample1 = Convert.ToInt32(oReader["Brand4Sample1"]);
            }
            if (!oReader["Brand4Sample2"].Equals(DBNull.Value))
            {
                oItem.Brand4Sample2 = Convert.ToInt32(oReader["Brand4Sample2"]);
            }
            if (!oReader["Brand4Sample3"].Equals(DBNull.Value))
            {
                oItem.Brand4Sample3 = Convert.ToInt32(oReader["Brand4Sample3"]);
            }
            if (!oReader["Brand4Gimmick1Qty"].Equals(DBNull.Value))
            {
                oItem.Brand4Gimmick1Qty = Convert.ToInt32(oReader["Brand4Gimmick1Qty"]);
            }
            if (!oReader["Brand4Gimmick2Qty"].Equals(DBNull.Value))
            {
                oItem.Brand4Gimmick2Qty = Convert.ToInt32(oReader["Brand4Gimmick2Qty"]);
            }
            if (!oReader["Brand4Gimmick3Qty"].Equals(DBNull.Value))
            {
                oItem.Brand4Gimmick3Qty = Convert.ToInt32(oReader["Brand4Gimmick3Qty"]);
            }
            if (!oReader["Brand4Sample1Qty"].Equals(DBNull.Value))
            {
                oItem.Brand4Sample1Qty = Convert.ToInt32(oReader["Brand4Sample1Qty"]);
            }
            if (!oReader["Brand4Sample2Qty"].Equals(DBNull.Value))
            {
                oItem.Brand4Sample2Qty = Convert.ToInt32(oReader["Brand4Sample2Qty"]);
            }
            if (!oReader["Brand4Sample3Qty"].Equals(DBNull.Value))
            {
                oItem.Brand4Sample3Qty = Convert.ToInt32(oReader["Brand4Sample3Qty"]);
            }
            if (!oReader["Brand5"].Equals(DBNull.Value))
            {
                oItem.Brand5 = Convert.ToInt32(oReader["Brand5"]);
            }
            if (!oReader["Brand5Gimmick1"].Equals(DBNull.Value))
            {
                oItem.Brand5Gimmick1 = Convert.ToInt32(oReader["Brand5Gimmick1"]);
            }
            if (!oReader["Brand5Gimmick2"].Equals(DBNull.Value))
            {
                oItem.Brand5Gimmick2 = Convert.ToInt32(oReader["Brand5Gimmick2"]);
            }
            if (!oReader["Brand5Gimmick3"].Equals(DBNull.Value))
            {
                oItem.Brand5Gimmick3 = Convert.ToInt32(oReader["Brand5Gimmick3"]);
            }
            if (!oReader["Brand5Sample1"].Equals(DBNull.Value))
            {
                oItem.Brand5Sample1 = Convert.ToInt32(oReader["Brand5Sample1"]);
            }
            if (!oReader["Brand5Sample2"].Equals(DBNull.Value))
            {
                oItem.Brand5Sample2 = Convert.ToInt32(oReader["Brand5Sample2"]);
            }
            if (!oReader["Brand5Sample3"].Equals(DBNull.Value))
            {
                oItem.Brand5Sample3 = Convert.ToInt32(oReader["Brand5Sample3"]);
            }
            if (!oReader["Brand5Gimmick1Qty"].Equals(DBNull.Value))
            {
                oItem.Brand5Gimmick1Qty = Convert.ToInt32(oReader["Brand5Gimmick1Qty"]);
            }
            if (!oReader["Brand5Gimmick2Qty"].Equals(DBNull.Value))
            {
                oItem.Brand5Gimmick2Qty = Convert.ToInt32(oReader["Brand5Gimmick2Qty"]);
            }
            if (!oReader["Brand5Gimmick3Qty"].Equals(DBNull.Value))
            {
                oItem.Brand5Gimmick3Qty = Convert.ToInt32(oReader["Brand5Gimmick3Qty"]);
            }
            if (!oReader["Brand5Sample1Qty"].Equals(DBNull.Value))
            {
                oItem.Brand5Sample1Qty = Convert.ToInt32(oReader["Brand5Sample1Qty"]);
            }
            if (!oReader["Brand5Sample2Qty"].Equals(DBNull.Value))
            {
                oItem.Brand5Sample2Qty = Convert.ToInt32(oReader["Brand5Sample2Qty"]);
            }
            if (!oReader["Brand5Sample3Qty"].Equals(DBNull.Value))
            {
                oItem.Brand5Sample3Qty = Convert.ToInt32(oReader["Brand5Sample3Qty"]);
            }
            if (!oReader["Brand6"].Equals(DBNull.Value))
            {
                oItem.Brand6 = Convert.ToInt32(oReader["Brand6"]);
            }
            if (!oReader["Brand6Gimmick1"].Equals(DBNull.Value))
            {
                oItem.Brand6Gimmick1 = Convert.ToInt32(oReader["Brand6Gimmick1"]);
            }
            if (!oReader["Brand6Gimmick2"].Equals(DBNull.Value))
            {
                oItem.Brand6Gimmick2 = Convert.ToInt32(oReader["Brand6Gimmick2"]);
            }
            if (!oReader["Brand6Gimmick3"].Equals(DBNull.Value))
            {
                oItem.Brand6Gimmick3 = Convert.ToInt32(oReader["Brand6Gimmick3"]);
            }
            if (!oReader["Brand6Sample1"].Equals(DBNull.Value))
            {
                oItem.Brand6Sample1 = Convert.ToInt32(oReader["Brand6Sample1"]);
            }
            if (!oReader["Brand6Sample2"].Equals(DBNull.Value))
            {
                oItem.Brand6Sample2 = Convert.ToInt32(oReader["Brand6Sample2"]);
            }
            if (!oReader["Brand6Sample3"].Equals(DBNull.Value))
            {
                oItem.Brand6Sample3 = Convert.ToInt32(oReader["Brand6Sample3"]);
            }
            if (!oReader["Brand6Gimmick1Qty"].Equals(DBNull.Value))
            {
                oItem.Brand6Gimmick1Qty = Convert.ToInt32(oReader["Brand6Gimmick1Qty"]);
            }
            if (!oReader["Brand6Gimmick2Qty"].Equals(DBNull.Value))
            {
                oItem.Brand6Gimmick2Qty = Convert.ToInt32(oReader["Brand6Gimmick2Qty"]);
            }
            if (!oReader["Brand6Gimmick3Qty"].Equals(DBNull.Value))
            {
                oItem.Brand6Gimmick3Qty = Convert.ToInt32(oReader["Brand6Gimmick3Qty"]);
            }
            if (!oReader["Brand6Sample1Qty"].Equals(DBNull.Value))
            {
                oItem.Brand6Sample1Qty = Convert.ToInt32(oReader["Brand6Sample1Qty"]);
            }
            if (!oReader["Brand6Sample2Qty"].Equals(DBNull.Value))
            {
                oItem.Brand6Sample2Qty = Convert.ToInt32(oReader["Brand6Sample2Qty"]);
            }
            if (!oReader["Brand6Sample3Qty"].Equals(DBNull.Value))
            {
                oItem.Brand6Sample3Qty = Convert.ToInt32(oReader["Brand6Sample3Qty"]);
            }
            if (!oReader["Brand7"].Equals(DBNull.Value))
            {
                oItem.Brand7 = Convert.ToInt32(oReader["Brand7"]);
            }
            if (!oReader["Brand7Gimmick1"].Equals(DBNull.Value))
            {
                oItem.Brand7Gimmick1 = Convert.ToInt32(oReader["Brand7Gimmick1"]);
            }
            if (!oReader["Brand7Gimmick2"].Equals(DBNull.Value))
            {
                oItem.Brand7Gimmick2 = Convert.ToInt32(oReader["Brand7Gimmick2"]);
            }
            if (!oReader["Brand7Gimmick3"].Equals(DBNull.Value))
            {
                oItem.Brand7Gimmick3 = Convert.ToInt32(oReader["Brand7Gimmick3"]);
            }
            if (!oReader["Brand7Sample1"].Equals(DBNull.Value))
            {
                oItem.Brand7Sample1 = Convert.ToInt32(oReader["Brand7Sample1"]);
            }
            if (!oReader["Brand7Sample2"].Equals(DBNull.Value))
            {
                oItem.Brand7Sample2 = Convert.ToInt32(oReader["Brand7Sample2"]);
            }
            if (!oReader["Brand7Sample3"].Equals(DBNull.Value))
            {
                oItem.Brand7Sample3 = Convert.ToInt32(oReader["Brand7Sample3"]);
            }
            if (!oReader["Brand7Gimmick1Qty"].Equals(DBNull.Value))
            {
                oItem.Brand7Gimmick1Qty = Convert.ToInt32(oReader["Brand7Gimmick1Qty"]);
            }
            if (!oReader["Brand7Gimmick2Qty"].Equals(DBNull.Value))
            {
                oItem.Brand7Gimmick2Qty = Convert.ToInt32(oReader["Brand7Gimmick2Qty"]);
            }
            if (!oReader["Brand7Gimmick3Qty"].Equals(DBNull.Value))
            {
                oItem.Brand7Gimmick3Qty = Convert.ToInt32(oReader["Brand7Gimmick3Qty"]);
            }
            if (!oReader["Brand7Sample1Qty"].Equals(DBNull.Value))
            {
                oItem.Brand7Sample1Qty = Convert.ToInt32(oReader["Brand7Sample1Qty"]);
            }
            if (!oReader["Brand7Sample2Qty"].Equals(DBNull.Value))
            {
                oItem.Brand7Sample2Qty = Convert.ToInt32(oReader["Brand7Sample2Qty"]);
            }
            if (!oReader["Brand7Sample3Qty"].Equals(DBNull.Value))
            {
                oItem.Brand7Sample3Qty = Convert.ToInt32(oReader["Brand7Sample3Qty"]);
            }
            if (!oReader["Brand8"].Equals(DBNull.Value))
            {
                oItem.Brand8 = Convert.ToInt32(oReader["Brand8"]);
            }
            if (!oReader["Brand8Gimmick1"].Equals(DBNull.Value))
            {
                oItem.Brand8Gimmick1 = Convert.ToInt32(oReader["Brand8Gimmick1"]);
            }
            if (!oReader["Brand8Gimmick2"].Equals(DBNull.Value))
            {
                oItem.Brand8Gimmick2 = Convert.ToInt32(oReader["Brand8Gimmick2"]);
            }
            if (!oReader["Brand8Gimmick3"].Equals(DBNull.Value))
            {
                oItem.Brand8Gimmick3 = Convert.ToInt32(oReader["Brand8Gimmick3"]);
            }
            if (!oReader["Brand8Sample1"].Equals(DBNull.Value))
            {
                oItem.Brand8Sample1 = Convert.ToInt32(oReader["Brand8Sample1"]);
            }
            if (!oReader["Brand8Sample2"].Equals(DBNull.Value))
            {
                oItem.Brand8Sample2 = Convert.ToInt32(oReader["Brand8Sample2"]);
            }
            if (!oReader["Brand8Sample3"].Equals(DBNull.Value))
            {
                oItem.Brand8Sample3 = Convert.ToInt32(oReader["Brand8Sample3"]);
            }
            if (!oReader["Brand8Gimmick1Qty"].Equals(DBNull.Value))
            {
                oItem.Brand8Gimmick1Qty = Convert.ToInt32(oReader["Brand8Gimmick1Qty"]);
            }
            if (!oReader["Brand8Gimmick2Qty"].Equals(DBNull.Value))
            {
                oItem.Brand8Gimmick2Qty = Convert.ToInt32(oReader["Brand8Gimmick2Qty"]);
            }
            if (!oReader["Brand8Gimmick3Qty"].Equals(DBNull.Value))
            {
                oItem.Brand8Gimmick3Qty = Convert.ToInt32(oReader["Brand8Gimmick3Qty"]);
            }
            if (!oReader["Brand8Sample1Qty"].Equals(DBNull.Value))
            {
                oItem.Brand8Sample1Qty = Convert.ToInt32(oReader["Brand8Sample1Qty"]);
            }
            if (!oReader["Brand8Sample2Qty"].Equals(DBNull.Value))
            {
                oItem.Brand8Sample2Qty = Convert.ToInt32(oReader["Brand8Sample2Qty"]);
            }
            if (!oReader["Brand8Sample3Qty"].Equals(DBNull.Value))
            {
                oItem.Brand8Sample3Qty = Convert.ToInt32(oReader["Brand8Sample3Qty"]);
            }
            if (!oReader["SubmitDateTime"].Equals(DBNull.Value))
            {
                oItem.SubmitDateTime = Convert.ToDateTime(oReader["SubmitDateTime"]);
            }
            if (!oReader["ApprovedDateTime"].Equals(DBNull.Value))
            {
                oItem.ApprovedDateTime = Convert.ToDateTime(oReader["ApprovedDateTime"]);
            }
            if (!oReader["SubmittedBy"].Equals(DBNull.Value))
            {
                oItem.SubmittedBy = Convert.ToInt32(oReader["SubmittedBy"]);
            }
            if (!oReader["ApprovedBy"].Equals(DBNull.Value))
            {
                oItem.ApprovedBy = Convert.ToInt32(oReader["ApprovedBy"]);
            }
            if (!oReader["Action"].Equals(DBNull.Value))
            {
                oItem.Action = Convert.ToInt32(oReader["Action"]);
            }
            if (!oReader["Version"].Equals(DBNull.Value))
            {
                oItem.Version = Convert.ToInt32(oReader["Version"]);
            }

            if (!oReader["SMSDCRNo"].Equals(DBNull.Value))
            {
                oItem.SMSDCRNo = (oReader["SMSDCRNo"]).ToString();
            }

            if (!oReader["IsSendSMS"].Equals(DBNull.Value))
            {
                oItem.IsSendSMS = Convert.ToBoolean(oReader["IsSendSMS"]);
            }
            if (!oReader["RejectReason"].Equals(DBNull.Value))
            {
                oItem.RejectReason = oReader["RejectReason"].ToString();
            }
            return oItem;
        }
        private DCRs ReaderToObjects(IDataReader oReader)
        {
            DCRs oItems;
            DCR oItem;
            oItems = new DCRs();
            if (oReader.IsClosed) return oItems;
            while (oReader.Read())
            {
                oItem = ReaderToObject(oReader);
                oItems.Add(oItem);
            }
            oReader.Close();
            return oItems;
        }
        public DCRs GetDCRs()
        {
            DCRs oDCRs;
            DLDCR oDL = new DLDCR();
            try
            {
                oDCRs = ReaderToObjects(oDL.GetDCRs());
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return oDCRs;
        }
        public DCR GetDCR(int nID)
        {
            DCR oDCR = new DCR();
            DLDCR oDL = new DLDCR();
            IDataReader oReader;
            try
            {
                oReader = oDL.GetDCR(nID);
                if (oReader.Read())
                {
                    oDCR = ReaderToObject(oReader);
                }
                oReader.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oDCR;
        }


        public DataTable GetDCRTableByDoctorIDTerritoryIDDayMonthYear(int nDoctorID, string sTerritory, int nDay,
            int nMonth, int nYear,string sSession, string sConnectionString)
        {
            DLDCR oDL = new DLDCR();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetDCRTableByDoctorIDTerritoryIDDayMonthYear(nDoctorID, sTerritory, nDay,
             nMonth, nYear,sSession, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public DataTable GetDCRDetailByDCRID(int nDCRID, string sConnectionString)
        {
            DLDCR oDL = new DLDCR();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetDCRDetailByDCRID(nDCRID, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }



        public int GetDCRID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            Int32 nMaxSMSOrderID;
            DLDCR oDL = new DLDCR();
            try
            {
                nMaxSMSOrderID = oDL.GetDCRID(oSqlConnection, oSqlTransaction);
                return nMaxSMSOrderID;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }


        public int GetDCRNewVersion(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sTerritoryID)
        {
            int nNewDCRVersion;
            DLDCR oDL = new DLDCR();
            try
            {
                nNewDCRVersion = oDL.GetDCRNewVersion(oSqlConnection, oSqlTransaction, sTerritoryID);
                return nNewDCRVersion;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public int GetDCRNewVersion(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nNewDCRVersion;
            DLDCR oDL = new DLDCR();
            try
            {
                nNewDCRVersion = oDL.GetDCRNewVersion(oSqlConnection, oSqlTransaction);
                return nNewDCRVersion;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public DCR GetDCR(int nDoctorID, string sTerritory, int nDay,
            int nMonth, int nYear,string sSession, string sConnectionString)
        {

            DLDCR oDL = new DLDCR();
            DataTable oTable = new DataTable();
            DCR oItem = new DCR();
            try
            {
                oTable = GetDCRTableByDoctorIDTerritoryIDDayMonthYear(nDoctorID, sTerritory, nDay,
                           nMonth, nYear,sSession, sConnectionString);


                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem.ID.SetID(oRow["DcrID"]);
                    oItem.DcrID = oItem.ID.ToInt32;
                    if (!oRow["PvpDetailID"].Equals(DBNull.Value))
                    {
                        oItem.PvpDetailID = Convert.ToInt32(oRow["PvpDetailID"]);
                    }
                    if (!oRow["DoctorID"].Equals(DBNull.Value))
                    {
                        oItem.DoctorID = Convert.ToInt32(oRow["DoctorID"]);
                    }
                    if (!oRow["TerritoryID"].Equals(DBNull.Value))
                    {
                        oItem.TerritoryID = (oRow["TerritoryID"]).ToString();
                    }
                    if (!oRow["Day"].Equals(DBNull.Value))
                    {
                        oItem.Day = Convert.ToInt32(oRow["Day"]);
                    }
                    if (!oRow["Month"].Equals(DBNull.Value))
                    {
                        oItem.Month = Convert.ToInt32(oRow["Month"]);
                    }
                    if (!oRow["Year"].Equals(DBNull.Value))
                    {
                        oItem.Year = Convert.ToInt32(oRow["Year"]);
                    }
                    if (!oRow["Status"].Equals(DBNull.Value))
                    {
                        oItem.Status = Convert.ToInt32(oRow["Status"]);
                    }
                    if (!oRow["VisitDateTime"].Equals(DBNull.Value))
                    {
                        oItem.VisitDateTime = Convert.ToDateTime(oRow["VisitDateTime"]);
                    }
                    if (!oRow["IsVisited"].Equals(DBNull.Value))
                    {
                        oItem.IsVisited = Convert.ToBoolean(oRow["IsVisited"]);
                    }
                    if (!oRow["IsAvailable"].Equals(DBNull.Value))
                    {
                        oItem.IsAvailable = Convert.ToBoolean(oRow["IsAvailable"]);
                    }
                    if (!oRow["IsAccompanyByRM_RM"].Equals(DBNull.Value))
                    {
                        oItem.IsAccompanyByRM_RM = Convert.ToBoolean(oRow["IsAccompanyByRM_RM"]);
                    }
                    if (!oRow["IsAccompanyByRM_SF"].Equals(DBNull.Value))
                    {
                        oItem.IsAccompanyByRM_SF = Convert.ToBoolean(oRow["IsAccompanyByRM_SF"]);
                    }
                    if (!oRow["ReminderNextCall"].Equals(DBNull.Value))
                    {
                        oItem.ReminderNextCall = oRow["ReminderNextCall"].ToString();
                    }
                    if (!oRow["NotAvailableReasonID"].Equals(DBNull.Value))
                    {
                        oItem.NotAvailableReasonID = Convert.ToInt32(oRow["NotAvailableReasonID"]);
                    }
                    if (!oRow["NotAvailableReason"].Equals(DBNull.Value))
                    {
                        oItem.NotAvailableReason = oRow["NotAvailableReason"].ToString();
                    }
                    if (!oRow["IsNewVisit"].Equals(DBNull.Value))
                    {
                        oItem.IsNewVisit = Convert.ToBoolean(oRow["IsNewVisit"]);
                    }
                    if (!oRow["Session"].Equals(DBNull.Value))
                    {
                        oItem.Session = oRow["Session"].ToString();
                    }
                    if (!oRow["Brand1"].Equals(DBNull.Value))
                    {
                        oItem.Brand1 = Convert.ToInt32(oRow["Brand1"]);
                    }
                    if (!oRow["Brand1Gimmick1"].Equals(DBNull.Value))
                    {
                        oItem.Brand1Gimmick1 = Convert.ToInt32(oRow["Brand1Gimmick1"]);
                    }
                    if (!oRow["Brand1Gimmick2"].Equals(DBNull.Value))
                    {
                        oItem.Brand1Gimmick2 = Convert.ToInt32(oRow["Brand1Gimmick2"]);
                    }
                    if (!oRow["Brand1Gimmick3"].Equals(DBNull.Value))
                    {
                        oItem.Brand1Gimmick3 = Convert.ToInt32(oRow["Brand1Gimmick3"]);
                    }
                    if (!oRow["Brand1Sample1"].Equals(DBNull.Value))
                    {
                        oItem.Brand1Sample1 = Convert.ToInt32(oRow["Brand1Sample1"]);
                    }
                    if (!oRow["Brand1Sample2"].Equals(DBNull.Value))
                    {
                        oItem.Brand1Sample2 = Convert.ToInt32(oRow["Brand1Sample2"]);
                    }
                    if (!oRow["Brand1Sample3"].Equals(DBNull.Value))
                    {
                        oItem.Brand1Sample3 = Convert.ToInt32(oRow["Brand1Sample3"]);
                    }
                    if (!oRow["Brand1Gimmick1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand1Gimmick1Qty = Convert.ToInt32(oRow["Brand1Gimmick1Qty"]);
                    }
                    if (!oRow["Brand1Gimmick2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand1Gimmick2Qty = Convert.ToInt32(oRow["Brand1Gimmick2Qty"]);
                    }
                    if (!oRow["Brand1Gimmick3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand1Gimmick3Qty = Convert.ToInt32(oRow["Brand1Gimmick3Qty"]);
                    }
                    if (!oRow["Brand1Sample1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand1Sample1Qty = Convert.ToInt32(oRow["Brand1Sample1Qty"]);
                    }
                    if (!oRow["Brand1Sample2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand1Sample2Qty = Convert.ToInt32(oRow["Brand1Sample2Qty"]);
                    }
                    if (!oRow["Brand1Sample3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand1Sample3Qty = Convert.ToInt32(oRow["Brand1Sample3Qty"]);
                    }
                    if (!oRow["Brand2"].Equals(DBNull.Value))
                    {
                        oItem.Brand2 = Convert.ToInt32(oRow["Brand2"]);
                    }
                    if (!oRow["Brand2Gimmick1"].Equals(DBNull.Value))
                    {
                        oItem.Brand2Gimmick1 = Convert.ToInt32(oRow["Brand2Gimmick1"]);
                    }
                    if (!oRow["Brand2Gimmick2"].Equals(DBNull.Value))
                    {
                        oItem.Brand2Gimmick2 = Convert.ToInt32(oRow["Brand2Gimmick2"]);
                    }
                    if (!oRow["Brand2Gimmick3"].Equals(DBNull.Value))
                    {
                        oItem.Brand2Gimmick3 = Convert.ToInt32(oRow["Brand2Gimmick3"]);
                    }
                    if (!oRow["Brand2Sample1"].Equals(DBNull.Value))
                    {
                        oItem.Brand2Sample1 = Convert.ToInt32(oRow["Brand2Sample1"]);
                    }
                    if (!oRow["Brand2Sample2"].Equals(DBNull.Value))
                    {
                        oItem.Brand2Sample2 = Convert.ToInt32(oRow["Brand2Sample2"]);
                    }
                    if (!oRow["Brand2Sample3"].Equals(DBNull.Value))
                    {
                        oItem.Brand2Sample3 = Convert.ToInt32(oRow["Brand2Sample3"]);
                    }
                    if (!oRow["Brand2Gimmick1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand2Gimmick1Qty = Convert.ToInt32(oRow["Brand2Gimmick1Qty"]);
                    }
                    if (!oRow["Brand2Gimmick2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand2Gimmick2Qty = Convert.ToInt32(oRow["Brand2Gimmick2Qty"]);
                    }
                    if (!oRow["Brand2Gimmick3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand2Gimmick3Qty = Convert.ToInt32(oRow["Brand2Gimmick3Qty"]);
                    }
                    if (!oRow["Brand2Sample1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand2Sample1Qty = Convert.ToInt32(oRow["Brand2Sample1Qty"]);
                    }
                    if (!oRow["Brand2Sample2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand2Sample2Qty = Convert.ToInt32(oRow["Brand2Sample2Qty"]);
                    }
                    if (!oRow["Brand2Sample3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand2Sample3Qty = Convert.ToInt32(oRow["Brand2Sample3Qty"]);
                    }
                    if (!oRow["Brand3"].Equals(DBNull.Value))
                    {
                        oItem.Brand3 = Convert.ToInt32(oRow["Brand3"]);
                    }
                    if (!oRow["Brand3Gimmick1"].Equals(DBNull.Value))
                    {
                        oItem.Brand3Gimmick1 = Convert.ToInt32(oRow["Brand3Gimmick1"]);
                    }
                    if (!oRow["Brand3Gimmick2"].Equals(DBNull.Value))
                    {
                        oItem.Brand3Gimmick2 = Convert.ToInt32(oRow["Brand3Gimmick2"]);
                    }
                    if (!oRow["Brand3Gimmick3"].Equals(DBNull.Value))
                    {
                        oItem.Brand3Gimmick3 = Convert.ToInt32(oRow["Brand3Gimmick3"]);
                    }
                    if (!oRow["Brand3Sample1"].Equals(DBNull.Value))
                    {
                        oItem.Brand3Sample1 = Convert.ToInt32(oRow["Brand3Sample1"]);
                    }
                    if (!oRow["Brand3Sample2"].Equals(DBNull.Value))
                    {
                        oItem.Brand3Sample2 = Convert.ToInt32(oRow["Brand3Sample2"]);
                    }
                    if (!oRow["Brand3Sample3"].Equals(DBNull.Value))
                    {
                        oItem.Brand3Sample3 = Convert.ToInt32(oRow["Brand3Sample3"]);
                    }
                    if (!oRow["Brand3Gimmick1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand3Gimmick1Qty = Convert.ToInt32(oRow["Brand3Gimmick1Qty"]);
                    }
                    if (!oRow["Brand3Gimmick2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand3Gimmick2Qty = Convert.ToInt32(oRow["Brand3Gimmick2Qty"]);
                    }
                    if (!oRow["Brand3Gimmick3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand3Gimmick3Qty = Convert.ToInt32(oRow["Brand3Gimmick3Qty"]);
                    }
                    if (!oRow["Brand3Sample1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand3Sample1Qty = Convert.ToInt32(oRow["Brand3Sample1Qty"]);
                    }
                    if (!oRow["Brand3Sample2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand3Sample2Qty = Convert.ToInt32(oRow["Brand3Sample2Qty"]);
                    }
                    if (!oRow["Brand3Sample3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand3Sample3Qty = Convert.ToInt32(oRow["Brand3Sample3Qty"]);
                    }
                    if (!oRow["Brand4"].Equals(DBNull.Value))
                    {
                        oItem.Brand4 = Convert.ToInt32(oRow["Brand4"]);
                    }
                    if (!oRow["Brand4Gimmick1"].Equals(DBNull.Value))
                    {
                        oItem.Brand4Gimmick1 = Convert.ToInt32(oRow["Brand4Gimmick1"]);
                    }
                    if (!oRow["Brand4Gimmick2"].Equals(DBNull.Value))
                    {
                        oItem.Brand4Gimmick2 = Convert.ToInt32(oRow["Brand4Gimmick2"]);
                    }
                    if (!oRow["Brand4Gimmick3"].Equals(DBNull.Value))
                    {
                        oItem.Brand4Gimmick3 = Convert.ToInt32(oRow["Brand4Gimmick3"]);
                    }
                    if (!oRow["Brand4Sample1"].Equals(DBNull.Value))
                    {
                        oItem.Brand4Sample1 = Convert.ToInt32(oRow["Brand4Sample1"]);
                    }
                    if (!oRow["Brand4Sample2"].Equals(DBNull.Value))
                    {
                        oItem.Brand4Sample2 = Convert.ToInt32(oRow["Brand4Sample2"]);
                    }
                    if (!oRow["Brand4Sample3"].Equals(DBNull.Value))
                    {
                        oItem.Brand4Sample3 = Convert.ToInt32(oRow["Brand4Sample3"]);
                    }
                    if (!oRow["Brand4Gimmick1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand4Gimmick1Qty = Convert.ToInt32(oRow["Brand4Gimmick1Qty"]);
                    }
                    if (!oRow["Brand4Gimmick2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand4Gimmick2Qty = Convert.ToInt32(oRow["Brand4Gimmick2Qty"]);
                    }
                    if (!oRow["Brand4Gimmick3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand4Gimmick3Qty = Convert.ToInt32(oRow["Brand4Gimmick3Qty"]);
                    }
                    if (!oRow["Brand4Sample1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand4Sample1Qty = Convert.ToInt32(oRow["Brand4Sample1Qty"]);
                    }
                    if (!oRow["Brand4Sample2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand4Sample2Qty = Convert.ToInt32(oRow["Brand4Sample2Qty"]);
                    }
                    if (!oRow["Brand4Sample3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand4Sample3Qty = Convert.ToInt32(oRow["Brand4Sample3Qty"]);
                    }
                    if (!oRow["Brand5"].Equals(DBNull.Value))
                    {
                        oItem.Brand5 = Convert.ToInt32(oRow["Brand5"]);
                    }
                    if (!oRow["Brand5Gimmick1"].Equals(DBNull.Value))
                    {
                        oItem.Brand5Gimmick1 = Convert.ToInt32(oRow["Brand5Gimmick1"]);
                    }
                    if (!oRow["Brand5Gimmick2"].Equals(DBNull.Value))
                    {
                        oItem.Brand5Gimmick2 = Convert.ToInt32(oRow["Brand5Gimmick2"]);
                    }
                    if (!oRow["Brand5Gimmick3"].Equals(DBNull.Value))
                    {
                        oItem.Brand5Gimmick3 = Convert.ToInt32(oRow["Brand5Gimmick3"]);
                    }
                    if (!oRow["Brand5Sample1"].Equals(DBNull.Value))
                    {
                        oItem.Brand5Sample1 = Convert.ToInt32(oRow["Brand5Sample1"]);
                    }
                    if (!oRow["Brand5Sample2"].Equals(DBNull.Value))
                    {
                        oItem.Brand5Sample2 = Convert.ToInt32(oRow["Brand5Sample2"]);
                    }
                    if (!oRow["Brand5Sample3"].Equals(DBNull.Value))
                    {
                        oItem.Brand5Sample3 = Convert.ToInt32(oRow["Brand5Sample3"]);
                    }
                    if (!oRow["Brand5Gimmick1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand5Gimmick1Qty = Convert.ToInt32(oRow["Brand5Gimmick1Qty"]);
                    }
                    if (!oRow["Brand5Gimmick2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand5Gimmick2Qty = Convert.ToInt32(oRow["Brand5Gimmick2Qty"]);
                    }
                    if (!oRow["Brand5Gimmick3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand5Gimmick3Qty = Convert.ToInt32(oRow["Brand5Gimmick3Qty"]);
                    }
                    if (!oRow["Brand5Sample1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand5Sample1Qty = Convert.ToInt32(oRow["Brand5Sample1Qty"]);
                    }
                    if (!oRow["Brand5Sample2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand5Sample2Qty = Convert.ToInt32(oRow["Brand5Sample2Qty"]);
                    }
                    if (!oRow["Brand5Sample3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand5Sample3Qty = Convert.ToInt32(oRow["Brand5Sample3Qty"]);
                    }
                    if (!oRow["Brand6"].Equals(DBNull.Value))
                    {
                        oItem.Brand6 = Convert.ToInt32(oRow["Brand6"]);
                    }
                    if (!oRow["Brand6Gimmick1"].Equals(DBNull.Value))
                    {
                        oItem.Brand6Gimmick1 = Convert.ToInt32(oRow["Brand6Gimmick1"]);
                    }
                    if (!oRow["Brand6Gimmick2"].Equals(DBNull.Value))
                    {
                        oItem.Brand6Gimmick2 = Convert.ToInt32(oRow["Brand6Gimmick2"]);
                    }
                    if (!oRow["Brand6Gimmick3"].Equals(DBNull.Value))
                    {
                        oItem.Brand6Gimmick3 = Convert.ToInt32(oRow["Brand6Gimmick3"]);
                    }
                    if (!oRow["Brand6Sample1"].Equals(DBNull.Value))
                    {
                        oItem.Brand6Sample1 = Convert.ToInt32(oRow["Brand6Sample1"]);
                    }
                    if (!oRow["Brand6Sample2"].Equals(DBNull.Value))
                    {
                        oItem.Brand6Sample2 = Convert.ToInt32(oRow["Brand6Sample2"]);
                    }
                    if (!oRow["Brand6Sample3"].Equals(DBNull.Value))
                    {
                        oItem.Brand6Sample3 = Convert.ToInt32(oRow["Brand6Sample3"]);
                    }
                    if (!oRow["Brand6Gimmick1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand6Gimmick1Qty = Convert.ToInt32(oRow["Brand6Gimmick1Qty"]);
                    }
                    if (!oRow["Brand6Gimmick2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand6Gimmick2Qty = Convert.ToInt32(oRow["Brand6Gimmick2Qty"]);
                    }
                    if (!oRow["Brand6Gimmick3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand6Gimmick3Qty = Convert.ToInt32(oRow["Brand6Gimmick3Qty"]);
                    }
                    if (!oRow["Brand6Sample1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand6Sample1Qty = Convert.ToInt32(oRow["Brand6Sample1Qty"]);
                    }
                    if (!oRow["Brand6Sample2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand6Sample2Qty = Convert.ToInt32(oRow["Brand6Sample2Qty"]);
                    }
                    if (!oRow["Brand6Sample3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand6Sample3Qty = Convert.ToInt32(oRow["Brand6Sample3Qty"]);
                    }
                    if (!oRow["Brand7"].Equals(DBNull.Value))
                    {
                        oItem.Brand7 = Convert.ToInt32(oRow["Brand7"]);
                    }
                    if (!oRow["Brand7Gimmick1"].Equals(DBNull.Value))
                    {
                        oItem.Brand7Gimmick1 = Convert.ToInt32(oRow["Brand7Gimmick1"]);
                    }
                    if (!oRow["Brand7Gimmick2"].Equals(DBNull.Value))
                    {
                        oItem.Brand7Gimmick2 = Convert.ToInt32(oRow["Brand7Gimmick2"]);
                    }
                    if (!oRow["Brand7Gimmick3"].Equals(DBNull.Value))
                    {
                        oItem.Brand7Gimmick3 = Convert.ToInt32(oRow["Brand7Gimmick3"]);
                    }
                    if (!oRow["Brand7Sample1"].Equals(DBNull.Value))
                    {
                        oItem.Brand7Sample1 = Convert.ToInt32(oRow["Brand7Sample1"]);
                    }
                    if (!oRow["Brand7Sample2"].Equals(DBNull.Value))
                    {
                        oItem.Brand7Sample2 = Convert.ToInt32(oRow["Brand7Sample2"]);
                    }
                    if (!oRow["Brand7Sample3"].Equals(DBNull.Value))
                    {
                        oItem.Brand7Sample3 = Convert.ToInt32(oRow["Brand7Sample3"]);
                    }
                    if (!oRow["Brand7Gimmick1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand7Gimmick1Qty = Convert.ToInt32(oRow["Brand7Gimmick1Qty"]);
                    }
                    if (!oRow["Brand7Gimmick2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand7Gimmick2Qty = Convert.ToInt32(oRow["Brand7Gimmick2Qty"]);
                    }
                    if (!oRow["Brand7Gimmick3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand7Gimmick3Qty = Convert.ToInt32(oRow["Brand7Gimmick3Qty"]);
                    }
                    if (!oRow["Brand7Sample1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand7Sample1Qty = Convert.ToInt32(oRow["Brand7Sample1Qty"]);
                    }
                    if (!oRow["Brand7Sample2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand7Sample2Qty = Convert.ToInt32(oRow["Brand7Sample2Qty"]);
                    }
                    if (!oRow["Brand7Sample3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand7Sample3Qty = Convert.ToInt32(oRow["Brand7Sample3Qty"]);
                    }
                    if (!oRow["Brand8"].Equals(DBNull.Value))
                    {
                        oItem.Brand8 = Convert.ToInt32(oRow["Brand8"]);
                    }
                    if (!oRow["Brand8Gimmick1"].Equals(DBNull.Value))
                    {
                        oItem.Brand8Gimmick1 = Convert.ToInt32(oRow["Brand8Gimmick1"]);
                    }
                    if (!oRow["Brand8Gimmick2"].Equals(DBNull.Value))
                    {
                        oItem.Brand8Gimmick2 = Convert.ToInt32(oRow["Brand8Gimmick2"]);
                    }
                    if (!oRow["Brand8Gimmick3"].Equals(DBNull.Value))
                    {
                        oItem.Brand8Gimmick3 = Convert.ToInt32(oRow["Brand8Gimmick3"]);
                    }
                    if (!oRow["Brand8Sample1"].Equals(DBNull.Value))
                    {
                        oItem.Brand8Sample1 = Convert.ToInt32(oRow["Brand8Sample1"]);
                    }
                    if (!oRow["Brand8Sample2"].Equals(DBNull.Value))
                    {
                        oItem.Brand8Sample2 = Convert.ToInt32(oRow["Brand8Sample2"]);
                    }
                    if (!oRow["Brand8Sample3"].Equals(DBNull.Value))
                    {
                        oItem.Brand8Sample3 = Convert.ToInt32(oRow["Brand8Sample3"]);
                    }
                    if (!oRow["Brand8Gimmick1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand8Gimmick1Qty = Convert.ToInt32(oRow["Brand8Gimmick1Qty"]);
                    }
                    if (!oRow["Brand8Gimmick2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand8Gimmick2Qty = Convert.ToInt32(oRow["Brand8Gimmick2Qty"]);
                    }
                    if (!oRow["Brand8Gimmick3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand8Gimmick3Qty = Convert.ToInt32(oRow["Brand8Gimmick3Qty"]);
                    }
                    if (!oRow["Brand8Sample1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand8Sample1Qty = Convert.ToInt32(oRow["Brand8Sample1Qty"]);
                    }
                    if (!oRow["Brand8Sample2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand8Sample2Qty = Convert.ToInt32(oRow["Brand8Sample2Qty"]);
                    }
                    if (!oRow["Brand8Sample3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand8Sample3Qty = Convert.ToInt32(oRow["Brand8Sample3Qty"]);
                    }
                    if (!oRow["SubmitDateTime"].Equals(DBNull.Value))
                    {
                        oItem.SubmitDateTime = Convert.ToDateTime(oRow["SubmitDateTime"]);
                    }
                    if (!oRow["ApprovedDateTime"].Equals(DBNull.Value))
                    {
                        oItem.ApprovedDateTime = Convert.ToDateTime(oRow["ApprovedDateTime"]);
                    }
                    if (!oRow["SubmittedBy"].Equals(DBNull.Value))
                    {
                        oItem.SubmittedBy = Convert.ToInt32(oRow["SubmittedBy"]);
                    }
                    if (!oRow["ApprovedBy"].Equals(DBNull.Value))
                    {
                        oItem.ApprovedBy = Convert.ToInt32(oRow["ApprovedBy"]);
                    }
                    if (!oRow["Action"].Equals(DBNull.Value))
                    {
                        oItem.Action = Convert.ToInt32(oRow["Action"]);
                    }
                    if (!oRow["Version"].Equals(DBNull.Value))
                    {
                        oItem.Version = Convert.ToInt32(oRow["Version"]);
                    }
                    if (!oRow["SMSDCRNo"].Equals(DBNull.Value))
                    {
                        oItem.SMSDCRNo = (oRow["SMSDCRNo"]).ToString();
                    }
                    if (!oRow["IsSendSMS"].Equals(DBNull.Value))
                    {
                        oItem.IsSendSMS = Convert.ToBoolean(oRow["IsSendSMS"]);
                    }
                    if (!oRow["RejectReason"].Equals(DBNull.Value))
                    {
                        oItem.RejectReason = oRow["RejectReason"].ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public DCR GetDCR(int nDCRID, string sConnectionString)
        {

            DLDCR oDL = new DLDCR();
            DataTable oTable = new DataTable();
            DCR oItem = new DCR();
            try
            {
                oTable = GetDCRDetailByDCRID(nDCRID, sConnectionString);


                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem.ID.SetID(oRow["DcrID"]);
                    if (!oRow["PvpDetailID"].Equals(DBNull.Value))
                    {
                        oItem.PvpDetailID = Convert.ToInt32(oRow["PvpDetailID"]);
                    }
                    if (!oRow["DoctorID"].Equals(DBNull.Value))
                    {
                        oItem.DoctorID = Convert.ToInt32(oRow["DoctorID"]);
                    }
                    if (!oRow["TerritoryID"].Equals(DBNull.Value))
                    {
                        oItem.TerritoryID = (oRow["TerritoryID"]).ToString();
                    }
                    if (!oRow["Day"].Equals(DBNull.Value))
                    {
                        oItem.Day = Convert.ToInt32(oRow["Day"]);
                    }
                    if (!oRow["Month"].Equals(DBNull.Value))
                    {
                        oItem.Month = Convert.ToInt32(oRow["Month"]);
                    }
                    if (!oRow["Year"].Equals(DBNull.Value))
                    {
                        oItem.Year = Convert.ToInt32(oRow["Year"]);
                    }
                    if (!oRow["Status"].Equals(DBNull.Value))
                    {
                        oItem.Status = Convert.ToInt32(oRow["Status"]);
                    }
                    if (!oRow["VisitDateTime"].Equals(DBNull.Value))
                    {
                        oItem.VisitDateTime = Convert.ToDateTime(oRow["VisitDateTime"]);
                    }
                    if (!oRow["IsVisited"].Equals(DBNull.Value))
                    {
                        oItem.IsVisited = Convert.ToBoolean(oRow["IsVisited"]);
                    }
                    if (!oRow["IsAvailable"].Equals(DBNull.Value))
                    {
                        oItem.IsAvailable = Convert.ToBoolean(oRow["IsAvailable"]);
                    }
                    if (!oRow["IsAccompanyByRM_RM"].Equals(DBNull.Value))
                    {
                        oItem.IsAccompanyByRM_RM = Convert.ToBoolean(oRow["IsAccompanyByRM_RM"]);
                    }
                    if (!oRow["IsAccompanyByRM_SF"].Equals(DBNull.Value))
                    {
                        oItem.IsAccompanyByRM_SF = Convert.ToBoolean(oRow["IsAccompanyByRM_SF"]);
                    }
                    if (!oRow["ReminderNextCall"].Equals(DBNull.Value))
                    {
                        oItem.ReminderNextCall = oRow["ReminderNextCall"].ToString();
                    }
                    if (!oRow["NotAvailableReasonID"].Equals(DBNull.Value))
                    {
                        oItem.NotAvailableReasonID = Convert.ToInt32(oRow["NotAvailableReasonID"]);
                    }
                    if (!oRow["NotAvailableReason"].Equals(DBNull.Value))
                    {
                        oItem.NotAvailableReason = oRow["NotAvailableReason"].ToString();
                    }
                    if (!oRow["IsNewVisit"].Equals(DBNull.Value))
                    {
                        oItem.IsNewVisit = Convert.ToBoolean(oRow["IsNewVisit"]);
                    }
                    if (!oRow["Session"].Equals(DBNull.Value))
                    {
                        oItem.Session = oRow["Session"].ToString();
                    }
                    if (!oRow["Brand1"].Equals(DBNull.Value))
                    {
                        oItem.Brand1 = Convert.ToInt32(oRow["Brand1"]);
                    }
                    if (!oRow["Brand1Gimmick1"].Equals(DBNull.Value))
                    {
                        oItem.Brand1Gimmick1 = Convert.ToInt32(oRow["Brand1Gimmick1"]);
                    }
                    if (!oRow["Brand1Gimmick2"].Equals(DBNull.Value))
                    {
                        oItem.Brand1Gimmick2 = Convert.ToInt32(oRow["Brand1Gimmick2"]);
                    }
                    if (!oRow["Brand1Gimmick3"].Equals(DBNull.Value))
                    {
                        oItem.Brand1Gimmick3 = Convert.ToInt32(oRow["Brand1Gimmick3"]);
                    }
                    if (!oRow["Brand1Sample1"].Equals(DBNull.Value))
                    {
                        oItem.Brand1Sample1 = Convert.ToInt32(oRow["Brand1Sample1"]);
                    }
                    if (!oRow["Brand1Sample2"].Equals(DBNull.Value))
                    {
                        oItem.Brand1Sample2 = Convert.ToInt32(oRow["Brand1Sample2"]);
                    }
                    if (!oRow["Brand1Sample3"].Equals(DBNull.Value))
                    {
                        oItem.Brand1Sample3 = Convert.ToInt32(oRow["Brand1Sample3"]);
                    }
                    if (!oRow["Brand1Gimmick1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand1Gimmick1Qty = Convert.ToInt32(oRow["Brand1Gimmick1Qty"]);
                    }
                    if (!oRow["Brand1Gimmick2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand1Gimmick2Qty = Convert.ToInt32(oRow["Brand1Gimmick2Qty"]);
                    }
                    if (!oRow["Brand1Gimmick3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand1Gimmick3Qty = Convert.ToInt32(oRow["Brand1Gimmick3Qty"]);
                    }
                    if (!oRow["Brand1Sample1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand1Sample1Qty = Convert.ToInt32(oRow["Brand1Sample1Qty"]);
                    }
                    if (!oRow["Brand1Sample2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand1Sample2Qty = Convert.ToInt32(oRow["Brand1Sample2Qty"]);
                    }
                    if (!oRow["Brand1Sample3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand1Sample3Qty = Convert.ToInt32(oRow["Brand1Sample3Qty"]);
                    }
                    if (!oRow["Brand2"].Equals(DBNull.Value))
                    {
                        oItem.Brand2 = Convert.ToInt32(oRow["Brand2"]);
                    }
                    if (!oRow["Brand2Gimmick1"].Equals(DBNull.Value))
                    {
                        oItem.Brand2Gimmick1 = Convert.ToInt32(oRow["Brand2Gimmick1"]);
                    }
                    if (!oRow["Brand2Gimmick2"].Equals(DBNull.Value))
                    {
                        oItem.Brand2Gimmick2 = Convert.ToInt32(oRow["Brand2Gimmick2"]);
                    }
                    if (!oRow["Brand2Gimmick3"].Equals(DBNull.Value))
                    {
                        oItem.Brand2Gimmick3 = Convert.ToInt32(oRow["Brand2Gimmick3"]);
                    }
                    if (!oRow["Brand2Sample1"].Equals(DBNull.Value))
                    {
                        oItem.Brand2Sample1 = Convert.ToInt32(oRow["Brand2Sample1"]);
                    }
                    if (!oRow["Brand2Sample2"].Equals(DBNull.Value))
                    {
                        oItem.Brand2Sample2 = Convert.ToInt32(oRow["Brand2Sample2"]);
                    }
                    if (!oRow["Brand2Sample3"].Equals(DBNull.Value))
                    {
                        oItem.Brand2Sample3 = Convert.ToInt32(oRow["Brand2Sample3"]);
                    }
                    if (!oRow["Brand2Gimmick1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand2Gimmick1Qty = Convert.ToInt32(oRow["Brand2Gimmick1Qty"]);
                    }
                    if (!oRow["Brand2Gimmick2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand2Gimmick2Qty = Convert.ToInt32(oRow["Brand2Gimmick2Qty"]);
                    }
                    if (!oRow["Brand2Gimmick3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand2Gimmick3Qty = Convert.ToInt32(oRow["Brand2Gimmick3Qty"]);
                    }
                    if (!oRow["Brand2Sample1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand2Sample1Qty = Convert.ToInt32(oRow["Brand2Sample1Qty"]);
                    }
                    if (!oRow["Brand2Sample2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand2Sample2Qty = Convert.ToInt32(oRow["Brand2Sample2Qty"]);
                    }
                    if (!oRow["Brand2Sample3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand2Sample3Qty = Convert.ToInt32(oRow["Brand2Sample3Qty"]);
                    }
                    if (!oRow["Brand3"].Equals(DBNull.Value))
                    {
                        oItem.Brand3 = Convert.ToInt32(oRow["Brand3"]);
                    }
                    if (!oRow["Brand3Gimmick1"].Equals(DBNull.Value))
                    {
                        oItem.Brand3Gimmick1 = Convert.ToInt32(oRow["Brand3Gimmick1"]);
                    }
                    if (!oRow["Brand3Gimmick2"].Equals(DBNull.Value))
                    {
                        oItem.Brand3Gimmick2 = Convert.ToInt32(oRow["Brand3Gimmick2"]);
                    }
                    if (!oRow["Brand3Gimmick3"].Equals(DBNull.Value))
                    {
                        oItem.Brand3Gimmick3 = Convert.ToInt32(oRow["Brand3Gimmick3"]);
                    }
                    if (!oRow["Brand3Sample1"].Equals(DBNull.Value))
                    {
                        oItem.Brand3Sample1 = Convert.ToInt32(oRow["Brand3Sample1"]);
                    }
                    if (!oRow["Brand3Sample2"].Equals(DBNull.Value))
                    {
                        oItem.Brand3Sample2 = Convert.ToInt32(oRow["Brand3Sample2"]);
                    }
                    if (!oRow["Brand3Sample3"].Equals(DBNull.Value))
                    {
                        oItem.Brand3Sample3 = Convert.ToInt32(oRow["Brand3Sample3"]);
                    }
                    if (!oRow["Brand3Gimmick1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand3Gimmick1Qty = Convert.ToInt32(oRow["Brand3Gimmick1Qty"]);
                    }
                    if (!oRow["Brand3Gimmick2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand3Gimmick2Qty = Convert.ToInt32(oRow["Brand3Gimmick2Qty"]);
                    }
                    if (!oRow["Brand3Gimmick3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand3Gimmick3Qty = Convert.ToInt32(oRow["Brand3Gimmick3Qty"]);
                    }
                    if (!oRow["Brand3Sample1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand3Sample1Qty = Convert.ToInt32(oRow["Brand3Sample1Qty"]);
                    }
                    if (!oRow["Brand3Sample2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand3Sample2Qty = Convert.ToInt32(oRow["Brand3Sample2Qty"]);
                    }
                    if (!oRow["Brand3Sample3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand3Sample3Qty = Convert.ToInt32(oRow["Brand3Sample3Qty"]);
                    }
                    if (!oRow["Brand4"].Equals(DBNull.Value))
                    {
                        oItem.Brand4 = Convert.ToInt32(oRow["Brand4"]);
                    }
                    if (!oRow["Brand4Gimmick1"].Equals(DBNull.Value))
                    {
                        oItem.Brand4Gimmick1 = Convert.ToInt32(oRow["Brand4Gimmick1"]);
                    }
                    if (!oRow["Brand4Gimmick2"].Equals(DBNull.Value))
                    {
                        oItem.Brand4Gimmick2 = Convert.ToInt32(oRow["Brand4Gimmick2"]);
                    }
                    if (!oRow["Brand4Gimmick3"].Equals(DBNull.Value))
                    {
                        oItem.Brand4Gimmick3 = Convert.ToInt32(oRow["Brand4Gimmick3"]);
                    }
                    if (!oRow["Brand4Sample1"].Equals(DBNull.Value))
                    {
                        oItem.Brand4Sample1 = Convert.ToInt32(oRow["Brand4Sample1"]);
                    }
                    if (!oRow["Brand4Sample2"].Equals(DBNull.Value))
                    {
                        oItem.Brand4Sample2 = Convert.ToInt32(oRow["Brand4Sample2"]);
                    }
                    if (!oRow["Brand4Sample3"].Equals(DBNull.Value))
                    {
                        oItem.Brand4Sample3 = Convert.ToInt32(oRow["Brand4Sample3"]);
                    }
                    if (!oRow["Brand4Gimmick1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand4Gimmick1Qty = Convert.ToInt32(oRow["Brand4Gimmick1Qty"]);
                    }
                    if (!oRow["Brand4Gimmick2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand4Gimmick2Qty = Convert.ToInt32(oRow["Brand4Gimmick2Qty"]);
                    }
                    if (!oRow["Brand4Gimmick3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand4Gimmick3Qty = Convert.ToInt32(oRow["Brand4Gimmick3Qty"]);
                    }
                    if (!oRow["Brand4Sample1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand4Sample1Qty = Convert.ToInt32(oRow["Brand4Sample1Qty"]);
                    }
                    if (!oRow["Brand4Sample2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand4Sample2Qty = Convert.ToInt32(oRow["Brand4Sample2Qty"]);
                    }
                    if (!oRow["Brand4Sample3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand4Sample3Qty = Convert.ToInt32(oRow["Brand4Sample3Qty"]);
                    }
                    if (!oRow["Brand5"].Equals(DBNull.Value))
                    {
                        oItem.Brand5 = Convert.ToInt32(oRow["Brand5"]);
                    }
                    if (!oRow["Brand5Gimmick1"].Equals(DBNull.Value))
                    {
                        oItem.Brand5Gimmick1 = Convert.ToInt32(oRow["Brand5Gimmick1"]);
                    }
                    if (!oRow["Brand5Gimmick2"].Equals(DBNull.Value))
                    {
                        oItem.Brand5Gimmick2 = Convert.ToInt32(oRow["Brand5Gimmick2"]);
                    }
                    if (!oRow["Brand5Gimmick3"].Equals(DBNull.Value))
                    {
                        oItem.Brand5Gimmick3 = Convert.ToInt32(oRow["Brand5Gimmick3"]);
                    }
                    if (!oRow["Brand5Sample1"].Equals(DBNull.Value))
                    {
                        oItem.Brand5Sample1 = Convert.ToInt32(oRow["Brand5Sample1"]);
                    }
                    if (!oRow["Brand5Sample2"].Equals(DBNull.Value))
                    {
                        oItem.Brand5Sample2 = Convert.ToInt32(oRow["Brand5Sample2"]);
                    }
                    if (!oRow["Brand5Sample3"].Equals(DBNull.Value))
                    {
                        oItem.Brand5Sample3 = Convert.ToInt32(oRow["Brand5Sample3"]);
                    }
                    if (!oRow["Brand5Gimmick1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand5Gimmick1Qty = Convert.ToInt32(oRow["Brand5Gimmick1Qty"]);
                    }
                    if (!oRow["Brand5Gimmick2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand5Gimmick2Qty = Convert.ToInt32(oRow["Brand5Gimmick2Qty"]);
                    }
                    if (!oRow["Brand5Gimmick3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand5Gimmick3Qty = Convert.ToInt32(oRow["Brand5Gimmick3Qty"]);
                    }
                    if (!oRow["Brand5Sample1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand5Sample1Qty = Convert.ToInt32(oRow["Brand5Sample1Qty"]);
                    }
                    if (!oRow["Brand5Sample2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand5Sample2Qty = Convert.ToInt32(oRow["Brand5Sample2Qty"]);
                    }
                    if (!oRow["Brand5Sample3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand5Sample3Qty = Convert.ToInt32(oRow["Brand5Sample3Qty"]);
                    }
                    if (!oRow["Brand6"].Equals(DBNull.Value))
                    {
                        oItem.Brand6 = Convert.ToInt32(oRow["Brand6"]);
                    }
                    if (!oRow["Brand6Gimmick1"].Equals(DBNull.Value))
                    {
                        oItem.Brand6Gimmick1 = Convert.ToInt32(oRow["Brand6Gimmick1"]);
                    }
                    if (!oRow["Brand6Gimmick2"].Equals(DBNull.Value))
                    {
                        oItem.Brand6Gimmick2 = Convert.ToInt32(oRow["Brand6Gimmick2"]);
                    }
                    if (!oRow["Brand6Gimmick3"].Equals(DBNull.Value))
                    {
                        oItem.Brand6Gimmick3 = Convert.ToInt32(oRow["Brand6Gimmick3"]);
                    }
                    if (!oRow["Brand6Sample1"].Equals(DBNull.Value))
                    {
                        oItem.Brand6Sample1 = Convert.ToInt32(oRow["Brand6Sample1"]);
                    }
                    if (!oRow["Brand6Sample2"].Equals(DBNull.Value))
                    {
                        oItem.Brand6Sample2 = Convert.ToInt32(oRow["Brand6Sample2"]);
                    }
                    if (!oRow["Brand6Sample3"].Equals(DBNull.Value))
                    {
                        oItem.Brand6Sample3 = Convert.ToInt32(oRow["Brand6Sample3"]);
                    }
                    if (!oRow["Brand6Gimmick1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand6Gimmick1Qty = Convert.ToInt32(oRow["Brand6Gimmick1Qty"]);
                    }
                    if (!oRow["Brand6Gimmick2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand6Gimmick2Qty = Convert.ToInt32(oRow["Brand6Gimmick2Qty"]);
                    }
                    if (!oRow["Brand6Gimmick3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand6Gimmick3Qty = Convert.ToInt32(oRow["Brand6Gimmick3Qty"]);
                    }
                    if (!oRow["Brand6Sample1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand6Sample1Qty = Convert.ToInt32(oRow["Brand6Sample1Qty"]);
                    }
                    if (!oRow["Brand6Sample2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand6Sample2Qty = Convert.ToInt32(oRow["Brand6Sample2Qty"]);
                    }
                    if (!oRow["Brand6Sample3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand6Sample3Qty = Convert.ToInt32(oRow["Brand6Sample3Qty"]);
                    }
                    if (!oRow["Brand7"].Equals(DBNull.Value))
                    {
                        oItem.Brand7 = Convert.ToInt32(oRow["Brand7"]);
                    }
                    if (!oRow["Brand7Gimmick1"].Equals(DBNull.Value))
                    {
                        oItem.Brand7Gimmick1 = Convert.ToInt32(oRow["Brand7Gimmick1"]);
                    }
                    if (!oRow["Brand7Gimmick2"].Equals(DBNull.Value))
                    {
                        oItem.Brand7Gimmick2 = Convert.ToInt32(oRow["Brand7Gimmick2"]);
                    }
                    if (!oRow["Brand7Gimmick3"].Equals(DBNull.Value))
                    {
                        oItem.Brand7Gimmick3 = Convert.ToInt32(oRow["Brand7Gimmick3"]);
                    }
                    if (!oRow["Brand7Sample1"].Equals(DBNull.Value))
                    {
                        oItem.Brand7Sample1 = Convert.ToInt32(oRow["Brand7Sample1"]);
                    }
                    if (!oRow["Brand7Sample2"].Equals(DBNull.Value))
                    {
                        oItem.Brand7Sample2 = Convert.ToInt32(oRow["Brand7Sample2"]);
                    }
                    if (!oRow["Brand7Sample3"].Equals(DBNull.Value))
                    {
                        oItem.Brand7Sample3 = Convert.ToInt32(oRow["Brand7Sample3"]);
                    }
                    if (!oRow["Brand7Gimmick1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand7Gimmick1Qty = Convert.ToInt32(oRow["Brand7Gimmick1Qty"]);
                    }
                    if (!oRow["Brand7Gimmick2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand7Gimmick2Qty = Convert.ToInt32(oRow["Brand7Gimmick2Qty"]);
                    }
                    if (!oRow["Brand7Gimmick3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand7Gimmick3Qty = Convert.ToInt32(oRow["Brand7Gimmick3Qty"]);
                    }
                    if (!oRow["Brand7Sample1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand7Sample1Qty = Convert.ToInt32(oRow["Brand7Sample1Qty"]);
                    }
                    if (!oRow["Brand7Sample2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand7Sample2Qty = Convert.ToInt32(oRow["Brand7Sample2Qty"]);
                    }
                    if (!oRow["Brand7Sample3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand7Sample3Qty = Convert.ToInt32(oRow["Brand7Sample3Qty"]);
                    }
                    if (!oRow["Brand8"].Equals(DBNull.Value))
                    {
                        oItem.Brand8 = Convert.ToInt32(oRow["Brand8"]);
                    }
                    if (!oRow["Brand8Gimmick1"].Equals(DBNull.Value))
                    {
                        oItem.Brand8Gimmick1 = Convert.ToInt32(oRow["Brand8Gimmick1"]);
                    }
                    if (!oRow["Brand8Gimmick2"].Equals(DBNull.Value))
                    {
                        oItem.Brand8Gimmick2 = Convert.ToInt32(oRow["Brand8Gimmick2"]);
                    }
                    if (!oRow["Brand8Gimmick3"].Equals(DBNull.Value))
                    {
                        oItem.Brand8Gimmick3 = Convert.ToInt32(oRow["Brand8Gimmick3"]);
                    }
                    if (!oRow["Brand8Sample1"].Equals(DBNull.Value))
                    {
                        oItem.Brand8Sample1 = Convert.ToInt32(oRow["Brand8Sample1"]);
                    }
                    if (!oRow["Brand8Sample2"].Equals(DBNull.Value))
                    {
                        oItem.Brand8Sample2 = Convert.ToInt32(oRow["Brand8Sample2"]);
                    }
                    if (!oRow["Brand8Sample3"].Equals(DBNull.Value))
                    {
                        oItem.Brand8Sample3 = Convert.ToInt32(oRow["Brand8Sample3"]);
                    }
                    if (!oRow["Brand8Gimmick1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand8Gimmick1Qty = Convert.ToInt32(oRow["Brand8Gimmick1Qty"]);
                    }
                    if (!oRow["Brand8Gimmick2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand8Gimmick2Qty = Convert.ToInt32(oRow["Brand8Gimmick2Qty"]);
                    }
                    if (!oRow["Brand8Gimmick3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand8Gimmick3Qty = Convert.ToInt32(oRow["Brand8Gimmick3Qty"]);
                    }
                    if (!oRow["Brand8Sample1Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand8Sample1Qty = Convert.ToInt32(oRow["Brand8Sample1Qty"]);
                    }
                    if (!oRow["Brand8Sample2Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand8Sample2Qty = Convert.ToInt32(oRow["Brand8Sample2Qty"]);
                    }
                    if (!oRow["Brand8Sample3Qty"].Equals(DBNull.Value))
                    {
                        oItem.Brand8Sample3Qty = Convert.ToInt32(oRow["Brand8Sample3Qty"]);
                    }
                    if (!oRow["SubmitDateTime"].Equals(DBNull.Value))
                    {
                        oItem.SubmitDateTime = Convert.ToDateTime(oRow["SubmitDateTime"]);
                    }
                    if (!oRow["ApprovedDateTime"].Equals(DBNull.Value))
                    {
                        oItem.ApprovedDateTime = Convert.ToDateTime(oRow["ApprovedDateTime"]);
                    }
                    if (!oRow["SubmittedBy"].Equals(DBNull.Value))
                    {
                        oItem.SubmittedBy = Convert.ToInt32(oRow["SubmittedBy"]);
                    }
                    if (!oRow["ApprovedBy"].Equals(DBNull.Value))
                    {
                        oItem.ApprovedBy = Convert.ToInt32(oRow["ApprovedBy"]);
                    }
                    if (!oRow["Action"].Equals(DBNull.Value))
                    {
                        oItem.Action = Convert.ToInt32(oRow["Action"]);
                    }
                    if (!oRow["Version"].Equals(DBNull.Value))
                    {
                        oItem.Version = Convert.ToInt32(oRow["Version"]);
                    }
                    if (!oRow["SMSDCRNo"].Equals(DBNull.Value))
                    {
                        oItem.SMSDCRNo = (oRow["SMSDCRNo"]).ToString();
                    }
                    if (!oRow["IsSendSMS"].Equals(DBNull.Value))
                    {
                        oItem.IsSendSMS = Convert.ToBoolean(oRow["IsSendSMS"]);
                    }
                    if (!oRow["RejectReason"].Equals(DBNull.Value))
                    {
                        oItem.RejectReason = oRow["RejectReason"].ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public DCR GetDCR(DataRow oRow)
        {
            DataTable oTable = new DataTable();
            DCR oItem = new DCR();
            try
            {
                oItem.ID.SetID(oRow["DcrID"]);
                oItem.DcrID = oItem.ID.ToInt32;
                if (!oRow["PvpDetailID"].Equals(DBNull.Value))
                {
                    oItem.PvpDetailID = Convert.ToInt32(oRow["PvpDetailID"]);
                }
                if (!oRow["DoctorID"].Equals(DBNull.Value))
                {
                    oItem.DoctorID = Convert.ToInt32(oRow["DoctorID"]);
                }
                if (!oRow["TerritoryID"].Equals(DBNull.Value))
                {
                    oItem.TerritoryID = oRow["TerritoryID"].ToString();
                }
                if (!oRow["Day"].Equals(DBNull.Value))
                {
                    oItem.Day = Convert.ToInt32(oRow["Day"]);
                }
                if (!oRow["Month"].Equals(DBNull.Value))
                {
                    oItem.Month = Convert.ToInt32(oRow["Month"]);
                }
                if (!oRow["Year"].Equals(DBNull.Value))
                {
                    oItem.Year = Convert.ToInt32(oRow["Year"]);
                }
                if (!oRow["Status"].Equals(DBNull.Value))
                {
                    oItem.Status = Convert.ToInt32(oRow["Status"]);
                }
                if (!oRow["VisitDateTime"].Equals(DBNull.Value))
                {
                    oItem.VisitDateTime = Convert.ToDateTime(oRow["VisitDateTime"]);
                }
                if (!oRow["IsVisited"].Equals(DBNull.Value))
                {
                    oItem.IsVisited = Convert.ToBoolean(oRow["IsVisited"]);
                }
                if (!oRow["IsAvailable"].Equals(DBNull.Value))
                {
                    oItem.IsAvailable = Convert.ToBoolean(oRow["IsAvailable"]);
                }
                if (!oRow["IsAccompanyByRM_RM"].Equals(DBNull.Value))
                {
                    oItem.IsAccompanyByRM_RM = Convert.ToBoolean(oRow["IsAccompanyByRM_RM"]);
                }
                if (!oRow["IsAccompanyByRM_SF"].Equals(DBNull.Value))
                {
                    oItem.IsAccompanyByRM_SF = Convert.ToBoolean(oRow["IsAccompanyByRM_SF"]);
                }
                if (!oRow["ReminderNextCall"].Equals(DBNull.Value))
                {
                    oItem.ReminderNextCall = oRow["ReminderNextCall"].ToString();
                }
                if (!oRow["NotAvailableReasonID"].Equals(DBNull.Value))
                {
                    oItem.NotAvailableReasonID = Convert.ToInt32(oRow["NotAvailableReasonID"]);
                }
                if (!oRow["NotAvailableReason"].Equals(DBNull.Value))
                {
                    oItem.NotAvailableReason = oRow["NotAvailableReason"].ToString();
                }
                if (!oRow["IsNewVisit"].Equals(DBNull.Value))
                {
                    oItem.IsNewVisit = Convert.ToBoolean(oRow["IsNewVisit"]);
                }
                if (!oRow["Session"].Equals(DBNull.Value))
                {
                    oItem.Session = oRow["Session"].ToString();
                }
                if (!oRow["Brand1"].Equals(DBNull.Value))
                {
                    oItem.Brand1 = Convert.ToInt32(oRow["Brand1"]);
                }
                if (!oRow["Brand1Gimmick1"].Equals(DBNull.Value))
                {
                    oItem.Brand1Gimmick1 = Convert.ToInt32(oRow["Brand1Gimmick1"]);
                }
                if (!oRow["Brand1Gimmick2"].Equals(DBNull.Value))
                {
                    oItem.Brand1Gimmick2 = Convert.ToInt32(oRow["Brand1Gimmick2"]);
                }
                if (!oRow["Brand1Gimmick3"].Equals(DBNull.Value))
                {
                    oItem.Brand1Gimmick3 = Convert.ToInt32(oRow["Brand1Gimmick3"]);
                }
                if (!oRow["Brand1Sample1"].Equals(DBNull.Value))
                {
                    oItem.Brand1Sample1 = Convert.ToInt32(oRow["Brand1Sample1"]);
                }
                if (!oRow["Brand1Sample2"].Equals(DBNull.Value))
                {
                    oItem.Brand1Sample2 = Convert.ToInt32(oRow["Brand1Sample2"]);
                }
                if (!oRow["Brand1Sample3"].Equals(DBNull.Value))
                {
                    oItem.Brand1Sample3 = Convert.ToInt32(oRow["Brand1Sample3"]);
                }
                if (!oRow["Brand1Gimmick1Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand1Gimmick1Qty = Convert.ToInt32(oRow["Brand1Gimmick1Qty"]);
                }
                if (!oRow["Brand1Gimmick2Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand1Gimmick2Qty = Convert.ToInt32(oRow["Brand1Gimmick2Qty"]);
                }
                if (!oRow["Brand1Gimmick3Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand1Gimmick3Qty = Convert.ToInt32(oRow["Brand1Gimmick3Qty"]);
                }
                if (!oRow["Brand1Sample1Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand1Sample1Qty = Convert.ToInt32(oRow["Brand1Sample1Qty"]);
                }
                if (!oRow["Brand1Sample2Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand1Sample2Qty = Convert.ToInt32(oRow["Brand1Sample2Qty"]);
                }
                if (!oRow["Brand1Sample3Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand1Sample3Qty = Convert.ToInt32(oRow["Brand1Sample3Qty"]);
                }
                if (!oRow["Brand2"].Equals(DBNull.Value))
                {
                    oItem.Brand2 = Convert.ToInt32(oRow["Brand2"]);
                }
                if (!oRow["Brand2Gimmick1"].Equals(DBNull.Value))
                {
                    oItem.Brand2Gimmick1 = Convert.ToInt32(oRow["Brand2Gimmick1"]);
                }
                if (!oRow["Brand2Gimmick2"].Equals(DBNull.Value))
                {
                    oItem.Brand2Gimmick2 = Convert.ToInt32(oRow["Brand2Gimmick2"]);
                }
                if (!oRow["Brand2Gimmick3"].Equals(DBNull.Value))
                {
                    oItem.Brand2Gimmick3 = Convert.ToInt32(oRow["Brand2Gimmick3"]);
                }
                if (!oRow["Brand2Sample1"].Equals(DBNull.Value))
                {
                    oItem.Brand2Sample1 = Convert.ToInt32(oRow["Brand2Sample1"]);
                }
                if (!oRow["Brand2Sample2"].Equals(DBNull.Value))
                {
                    oItem.Brand2Sample2 = Convert.ToInt32(oRow["Brand2Sample2"]);
                }
                if (!oRow["Brand2Sample3"].Equals(DBNull.Value))
                {
                    oItem.Brand2Sample3 = Convert.ToInt32(oRow["Brand2Sample3"]);
                }
                if (!oRow["Brand2Gimmick1Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand2Gimmick1Qty = Convert.ToInt32(oRow["Brand2Gimmick1Qty"]);
                }
                if (!oRow["Brand2Gimmick2Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand2Gimmick2Qty = Convert.ToInt32(oRow["Brand2Gimmick2Qty"]);
                }
                if (!oRow["Brand2Gimmick3Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand2Gimmick3Qty = Convert.ToInt32(oRow["Brand2Gimmick3Qty"]);
                }
                if (!oRow["Brand2Sample1Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand2Sample1Qty = Convert.ToInt32(oRow["Brand2Sample1Qty"]);
                }
                if (!oRow["Brand2Sample2Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand2Sample2Qty = Convert.ToInt32(oRow["Brand2Sample2Qty"]);
                }
                if (!oRow["Brand2Sample3Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand2Sample3Qty = Convert.ToInt32(oRow["Brand2Sample3Qty"]);
                }
                if (!oRow["Brand3"].Equals(DBNull.Value))
                {
                    oItem.Brand3 = Convert.ToInt32(oRow["Brand3"]);
                }
                if (!oRow["Brand3Gimmick1"].Equals(DBNull.Value))
                {
                    oItem.Brand3Gimmick1 = Convert.ToInt32(oRow["Brand3Gimmick1"]);
                }
                if (!oRow["Brand3Gimmick2"].Equals(DBNull.Value))
                {
                    oItem.Brand3Gimmick2 = Convert.ToInt32(oRow["Brand3Gimmick2"]);
                }
                if (!oRow["Brand3Gimmick3"].Equals(DBNull.Value))
                {
                    oItem.Brand3Gimmick3 = Convert.ToInt32(oRow["Brand3Gimmick3"]);
                }
                if (!oRow["Brand3Sample1"].Equals(DBNull.Value))
                {
                    oItem.Brand3Sample1 = Convert.ToInt32(oRow["Brand3Sample1"]);
                }
                if (!oRow["Brand3Sample2"].Equals(DBNull.Value))
                {
                    oItem.Brand3Sample2 = Convert.ToInt32(oRow["Brand3Sample2"]);
                }
                if (!oRow["Brand3Sample3"].Equals(DBNull.Value))
                {
                    oItem.Brand3Sample3 = Convert.ToInt32(oRow["Brand3Sample3"]);
                }
                if (!oRow["Brand3Gimmick1Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand3Gimmick1Qty = Convert.ToInt32(oRow["Brand3Gimmick1Qty"]);
                }
                if (!oRow["Brand3Gimmick2Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand3Gimmick2Qty = Convert.ToInt32(oRow["Brand3Gimmick2Qty"]);
                }
                if (!oRow["Brand3Gimmick3Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand3Gimmick3Qty = Convert.ToInt32(oRow["Brand3Gimmick3Qty"]);
                }
                if (!oRow["Brand3Sample1Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand3Sample1Qty = Convert.ToInt32(oRow["Brand3Sample1Qty"]);
                }
                if (!oRow["Brand3Sample2Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand3Sample2Qty = Convert.ToInt32(oRow["Brand3Sample2Qty"]);
                }
                if (!oRow["Brand3Sample3Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand3Sample3Qty = Convert.ToInt32(oRow["Brand3Sample3Qty"]);
                }
                if (!oRow["Brand4"].Equals(DBNull.Value))
                {
                    oItem.Brand4 = Convert.ToInt32(oRow["Brand4"]);
                }
                if (!oRow["Brand4Gimmick1"].Equals(DBNull.Value))
                {
                    oItem.Brand4Gimmick1 = Convert.ToInt32(oRow["Brand4Gimmick1"]);
                }
                if (!oRow["Brand4Gimmick2"].Equals(DBNull.Value))
                {
                    oItem.Brand4Gimmick2 = Convert.ToInt32(oRow["Brand4Gimmick2"]);
                }
                if (!oRow["Brand4Gimmick3"].Equals(DBNull.Value))
                {
                    oItem.Brand4Gimmick3 = Convert.ToInt32(oRow["Brand4Gimmick3"]);
                }
                if (!oRow["Brand4Sample1"].Equals(DBNull.Value))
                {
                    oItem.Brand4Sample1 = Convert.ToInt32(oRow["Brand4Sample1"]);
                }
                if (!oRow["Brand4Sample2"].Equals(DBNull.Value))
                {
                    oItem.Brand4Sample2 = Convert.ToInt32(oRow["Brand4Sample2"]);
                }
                if (!oRow["Brand4Sample3"].Equals(DBNull.Value))
                {
                    oItem.Brand4Sample3 = Convert.ToInt32(oRow["Brand4Sample3"]);
                }
                if (!oRow["Brand4Gimmick1Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand4Gimmick1Qty = Convert.ToInt32(oRow["Brand4Gimmick1Qty"]);
                }
                if (!oRow["Brand4Gimmick2Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand4Gimmick2Qty = Convert.ToInt32(oRow["Brand4Gimmick2Qty"]);
                }
                if (!oRow["Brand4Gimmick3Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand4Gimmick3Qty = Convert.ToInt32(oRow["Brand4Gimmick3Qty"]);
                }
                if (!oRow["Brand4Sample1Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand4Sample1Qty = Convert.ToInt32(oRow["Brand4Sample1Qty"]);
                }
                if (!oRow["Brand4Sample2Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand4Sample2Qty = Convert.ToInt32(oRow["Brand4Sample2Qty"]);
                }
                if (!oRow["Brand4Sample3Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand4Sample3Qty = Convert.ToInt32(oRow["Brand4Sample3Qty"]);
                }
                if (!oRow["Brand5"].Equals(DBNull.Value))
                {
                    oItem.Brand5 = Convert.ToInt32(oRow["Brand5"]);
                }
                if (!oRow["Brand5Gimmick1"].Equals(DBNull.Value))
                {
                    oItem.Brand5Gimmick1 = Convert.ToInt32(oRow["Brand5Gimmick1"]);
                }
                if (!oRow["Brand5Gimmick2"].Equals(DBNull.Value))
                {
                    oItem.Brand5Gimmick2 = Convert.ToInt32(oRow["Brand5Gimmick2"]);
                }
                if (!oRow["Brand5Gimmick3"].Equals(DBNull.Value))
                {
                    oItem.Brand5Gimmick3 = Convert.ToInt32(oRow["Brand5Gimmick3"]);
                }
                if (!oRow["Brand5Sample1"].Equals(DBNull.Value))
                {
                    oItem.Brand5Sample1 = Convert.ToInt32(oRow["Brand5Sample1"]);
                }
                if (!oRow["Brand5Sample2"].Equals(DBNull.Value))
                {
                    oItem.Brand5Sample2 = Convert.ToInt32(oRow["Brand5Sample2"]);
                }
                if (!oRow["Brand5Sample3"].Equals(DBNull.Value))
                {
                    oItem.Brand5Sample3 = Convert.ToInt32(oRow["Brand5Sample3"]);
                }
                if (!oRow["Brand5Gimmick1Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand5Gimmick1Qty = Convert.ToInt32(oRow["Brand5Gimmick1Qty"]);
                }
                if (!oRow["Brand5Gimmick2Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand5Gimmick2Qty = Convert.ToInt32(oRow["Brand5Gimmick2Qty"]);
                }
                if (!oRow["Brand5Gimmick3Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand5Gimmick3Qty = Convert.ToInt32(oRow["Brand5Gimmick3Qty"]);
                }
                if (!oRow["Brand5Sample1Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand5Sample1Qty = Convert.ToInt32(oRow["Brand5Sample1Qty"]);
                }
                if (!oRow["Brand5Sample2Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand5Sample2Qty = Convert.ToInt32(oRow["Brand5Sample2Qty"]);
                }
                if (!oRow["Brand5Sample3Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand5Sample3Qty = Convert.ToInt32(oRow["Brand5Sample3Qty"]);
                }
                if (!oRow["Brand6"].Equals(DBNull.Value))
                {
                    oItem.Brand6 = Convert.ToInt32(oRow["Brand6"]);
                }
                if (!oRow["Brand6Gimmick1"].Equals(DBNull.Value))
                {
                    oItem.Brand6Gimmick1 = Convert.ToInt32(oRow["Brand6Gimmick1"]);
                }
                if (!oRow["Brand6Gimmick2"].Equals(DBNull.Value))
                {
                    oItem.Brand6Gimmick2 = Convert.ToInt32(oRow["Brand6Gimmick2"]);
                }
                if (!oRow["Brand6Gimmick3"].Equals(DBNull.Value))
                {
                    oItem.Brand6Gimmick3 = Convert.ToInt32(oRow["Brand6Gimmick3"]);
                }
                if (!oRow["Brand6Sample1"].Equals(DBNull.Value))
                {
                    oItem.Brand6Sample1 = Convert.ToInt32(oRow["Brand6Sample1"]);
                }
                if (!oRow["Brand6Sample2"].Equals(DBNull.Value))
                {
                    oItem.Brand6Sample2 = Convert.ToInt32(oRow["Brand6Sample2"]);
                }
                if (!oRow["Brand6Sample3"].Equals(DBNull.Value))
                {
                    oItem.Brand6Sample3 = Convert.ToInt32(oRow["Brand6Sample3"]);
                }
                if (!oRow["Brand6Gimmick1Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand6Gimmick1Qty = Convert.ToInt32(oRow["Brand6Gimmick1Qty"]);
                }
                if (!oRow["Brand6Gimmick2Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand6Gimmick2Qty = Convert.ToInt32(oRow["Brand6Gimmick2Qty"]);
                }
                if (!oRow["Brand6Gimmick3Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand6Gimmick3Qty = Convert.ToInt32(oRow["Brand6Gimmick3Qty"]);
                }
                if (!oRow["Brand6Sample1Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand6Sample1Qty = Convert.ToInt32(oRow["Brand6Sample1Qty"]);
                }
                if (!oRow["Brand6Sample2Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand6Sample2Qty = Convert.ToInt32(oRow["Brand6Sample2Qty"]);
                }
                if (!oRow["Brand6Sample3Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand6Sample3Qty = Convert.ToInt32(oRow["Brand6Sample3Qty"]);
                }
                if (!oRow["Brand7"].Equals(DBNull.Value))
                {
                    oItem.Brand7 = Convert.ToInt32(oRow["Brand7"]);
                }
                if (!oRow["Brand7Gimmick1"].Equals(DBNull.Value))
                {
                    oItem.Brand7Gimmick1 = Convert.ToInt32(oRow["Brand7Gimmick1"]);
                }
                if (!oRow["Brand7Gimmick2"].Equals(DBNull.Value))
                {
                    oItem.Brand7Gimmick2 = Convert.ToInt32(oRow["Brand7Gimmick2"]);
                }
                if (!oRow["Brand7Gimmick3"].Equals(DBNull.Value))
                {
                    oItem.Brand7Gimmick3 = Convert.ToInt32(oRow["Brand7Gimmick3"]);
                }
                if (!oRow["Brand7Sample1"].Equals(DBNull.Value))
                {
                    oItem.Brand7Sample1 = Convert.ToInt32(oRow["Brand7Sample1"]);
                }
                if (!oRow["Brand7Sample2"].Equals(DBNull.Value))
                {
                    oItem.Brand7Sample2 = Convert.ToInt32(oRow["Brand7Sample2"]);
                }
                if (!oRow["Brand7Sample3"].Equals(DBNull.Value))
                {
                    oItem.Brand7Sample3 = Convert.ToInt32(oRow["Brand7Sample3"]);
                }
                if (!oRow["Brand7Gimmick1Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand7Gimmick1Qty = Convert.ToInt32(oRow["Brand7Gimmick1Qty"]);
                }
                if (!oRow["Brand7Gimmick2Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand7Gimmick2Qty = Convert.ToInt32(oRow["Brand7Gimmick2Qty"]);
                }
                if (!oRow["Brand7Gimmick3Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand7Gimmick3Qty = Convert.ToInt32(oRow["Brand7Gimmick3Qty"]);
                }
                if (!oRow["Brand7Sample1Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand7Sample1Qty = Convert.ToInt32(oRow["Brand7Sample1Qty"]);
                }
                if (!oRow["Brand7Sample2Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand7Sample2Qty = Convert.ToInt32(oRow["Brand7Sample2Qty"]);
                }
                if (!oRow["Brand7Sample3Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand7Sample3Qty = Convert.ToInt32(oRow["Brand7Sample3Qty"]);
                }
                if (!oRow["Brand8"].Equals(DBNull.Value))
                {
                    oItem.Brand8 = Convert.ToInt32(oRow["Brand8"]);
                }
                if (!oRow["Brand8Gimmick1"].Equals(DBNull.Value))
                {
                    oItem.Brand8Gimmick1 = Convert.ToInt32(oRow["Brand8Gimmick1"]);
                }
                if (!oRow["Brand8Gimmick2"].Equals(DBNull.Value))
                {
                    oItem.Brand8Gimmick2 = Convert.ToInt32(oRow["Brand8Gimmick2"]);
                }
                if (!oRow["Brand8Gimmick3"].Equals(DBNull.Value))
                {
                    oItem.Brand8Gimmick3 = Convert.ToInt32(oRow["Brand8Gimmick3"]);
                }
                if (!oRow["Brand8Sample1"].Equals(DBNull.Value))
                {
                    oItem.Brand8Sample1 = Convert.ToInt32(oRow["Brand8Sample1"]);
                }
                if (!oRow["Brand8Sample2"].Equals(DBNull.Value))
                {
                    oItem.Brand8Sample2 = Convert.ToInt32(oRow["Brand8Sample2"]);
                }
                if (!oRow["Brand8Sample3"].Equals(DBNull.Value))
                {
                    oItem.Brand8Sample3 = Convert.ToInt32(oRow["Brand8Sample3"]);
                }
                if (!oRow["Brand8Gimmick1Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand8Gimmick1Qty = Convert.ToInt32(oRow["Brand8Gimmick1Qty"]);
                }
                if (!oRow["Brand8Gimmick2Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand8Gimmick2Qty = Convert.ToInt32(oRow["Brand8Gimmick2Qty"]);
                }
                if (!oRow["Brand8Gimmick3Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand8Gimmick3Qty = Convert.ToInt32(oRow["Brand8Gimmick3Qty"]);
                }
                if (!oRow["Brand8Sample1Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand8Sample1Qty = Convert.ToInt32(oRow["Brand8Sample1Qty"]);
                }
                if (!oRow["Brand8Sample2Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand8Sample2Qty = Convert.ToInt32(oRow["Brand8Sample2Qty"]);
                }
                if (!oRow["Brand8Sample3Qty"].Equals(DBNull.Value))
                {
                    oItem.Brand8Sample3Qty = Convert.ToInt32(oRow["Brand8Sample3Qty"]);
                }
                if (!oRow["SubmitDateTime"].Equals(DBNull.Value))
                {
                    oItem.SubmitDateTime = Convert.ToDateTime(oRow["SubmitDateTime"]);
                }
                if (!oRow["ApprovedDateTime"].Equals(DBNull.Value))
                {
                    oItem.ApprovedDateTime = Convert.ToDateTime(oRow["ApprovedDateTime"]);
                }
                if (!oRow["SubmittedBy"].Equals(DBNull.Value))
                {
                    oItem.SubmittedBy = Convert.ToInt32(oRow["SubmittedBy"]);
                }
                if (!oRow["ApprovedBy"].Equals(DBNull.Value))
                {
                    oItem.ApprovedBy = Convert.ToInt32(oRow["ApprovedBy"]);
                }
                if (!oRow["Action"].Equals(DBNull.Value))
                {
                    oItem.Action = Convert.ToInt32(oRow["Action"]);
                }
                if (!oRow["Version"].Equals(DBNull.Value))
                {
                    oItem.Version = Convert.ToInt32(oRow["Version"]);
                }

                if (!oRow["SMSDCRNo"].Equals(DBNull.Value))
                {
                    oItem.SMSDCRNo = (oRow["SMSDCRNo"]).ToString();
                }

                if (!oRow["IsSendSMS"].Equals(DBNull.Value))
                {
                    oItem.IsSendSMS = Convert.ToBoolean(oRow["IsSendSMS"]);
                }
                if (!oRow["RejectReason"].Equals(DBNull.Value))
                {
                    oItem.RejectReason = oRow["RejectReason"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public DCR GetDCR(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nPreviousMonth, int nPreviousYear, int nPreviousMonthDay, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            DCR oItem = new DCR();
            try
            {
                oTable = GetDCRInfo(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonth, nPreviousYear, nPreviousMonthDay, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem = GetDCR(oRow);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public DCRs GetDCRs(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nPreviousMonth, int nPreviousYear, int nPreviousMonthDay, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            DCR oItem = new DCR();
            DCRs oItems = new DCRs();
            try
            {
                oTable = GetDCRInfo(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonth, nPreviousYear, nPreviousMonthDay, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new DCR();
                        oItem = GetDCR(oRow);
                        oItems.Add(oItem);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItems;
        }

        public DCR GetDCRForRM(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nPreviousMonth, int nPreviousYear, int nPreviousMonthDay, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            DCR oItem = new DCR();
            try
            {
                oTable = GetDCRInfoForRM(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonth, nPreviousYear, nPreviousMonthDay, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem = GetDCR(oRow);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public DCRs GetDCRsForRM(string sTerritoryID, int nCurrentMonth, int nCurrentYear, int nPreviousMonth, int nPreviousYear, int nPreviousMonthDay, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            DCR oItem = new DCR();
            DCRs oItems = new DCRs();
            try
            {
                oTable = GetDCRInfoForRM(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonth, nPreviousYear, nPreviousMonthDay, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new DCR();
                        oItem = GetDCR(oRow);
                        oItems.Add(oItem);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItems;
        }
    }
}
