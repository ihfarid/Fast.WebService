using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core.DataAccess;
using FAST.Core;

using System.Data.SqlClient;

namespace FAST.DataLogic
{
    public partial class DLDCR : DAAccess
    {

        public void Insert(DCR oItem)
        {
            string sSQL = "";
            try
            {
                oItem.ID.SetID(GeneratePrimaryKey("[DCR]", "DcrID"));
                sSQL = SQL.MakeSQL("INSERT INTO [DCR](DcrID, PvpDetailID, DoctorID, TerritoryID, Day, Month, Year, Status, VisitDateTime, IsVisited, IsAvailable, IsAccompanyByRM_RM, IsAccompanyByRM_SF, ReminderNextCall, NotAvailableReasonID, NotAvailableReason, IsNewVisit, Session, Brand1, Brand1Gimmick1, Brand1Gimmick2, Brand1Gimmick3, Brand1Sample1, Brand1Sample2, Brand1Sample3, Brand1Gimmick1Qty, Brand1Gimmick2Qty, Brand1Gimmick3Qty, Brand1Sample1Qty, Brand1Sample2Qty, Brand1Sample3Qty, Brand2, Brand2Gimmick1, Brand2Gimmick2, Brand2Gimmick3, Brand2Sample1, Brand2Sample2, Brand2Sample3, Brand2Gimmick1Qty, Brand2Gimmick2Qty, Brand2Gimmick3Qty, Brand2Sample1Qty, Brand2Sample2Qty, Brand2Sample3Qty, Brand3, Brand3Gimmick1, Brand3Gimmick2, Brand3Gimmick3, Brand3Sample1, Brand3Sample2, Brand3Sample3, Brand3Gimmick1Qty, Brand3Gimmick2Qty, Brand3Gimmick3Qty, Brand3Sample1Qty, Brand3Sample2Qty, Brand3Sample3Qty, Brand4, Brand4Gimmick1, Brand4Gimmick2, Brand4Gimmick3, Brand4Sample1, Brand4Sample2, Brand4Sample3, Brand4Gimmick1Qty, Brand4Gimmick2Qty, Brand4Gimmick3Qty, Brand4Sample1Qty, Brand4Sample2Qty, Brand4Sample3Qty, Brand5, Brand5Gimmick1, Brand5Gimmick2, Brand5Gimmick3, Brand5Sample1, Brand5Sample2, Brand5Sample3, Brand5Gimmick1Qty, Brand5Gimmick2Qty, Brand5Gimmick3Qty, Brand5Sample1Qty, Brand5Sample2Qty, Brand5Sample3Qty, Brand6, Brand6Gimmick1, Brand6Gimmick2, Brand6Gimmick3, Brand6Sample1, Brand6Sample2, Brand6Sample3, Brand6Gimmick1Qty, Brand6Gimmick2Qty, Brand6Gimmick3Qty, Brand6Sample1Qty, Brand6Sample2Qty, Brand6Sample3Qty, Brand7, Brand7Gimmick1, Brand7Gimmick2, Brand7Gimmick3, Brand7Sample1, Brand7Sample2, Brand7Sample3, Brand7Gimmick1Qty, Brand7Gimmick2Qty, Brand7Gimmick3Qty, Brand7Sample1Qty, Brand7Sample2Qty, Brand7Sample3Qty, Brand8, Brand8Gimmick1, Brand8Gimmick2, Brand8Gimmick3, Brand8Sample1, Brand8Sample2, Brand8Sample3, Brand8Gimmick1Qty, Brand8Gimmick2Qty, Brand8Gimmick3Qty, Brand8Sample1Qty, Brand8Sample2Qty, Brand8Sample3Qty, SubmitDateTime, ApprovedDateTime, SubmittedBy, ApprovedBy, Action, Version,SMSDCRNo,IsSendSMS,RejectReason) "
                + " VALUES(%n, %n, %n, %n, %n, %n, %n, %n, %d, %b, %b, %b, %b, %s, %n, %s, %b, %s, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n,%n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n,%n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %D, %D, %n, %n, %n, %n,%s,%b,%s) "
                , oItem.ID.ToInt32, oItem.PvpDetailID, oItem.DoctorID, oItem.TerritoryID, oItem.Day, oItem.Month, oItem.Year, oItem.Status, oItem.VisitDateTime, oItem.IsVisited, oItem.IsAvailable, oItem.IsAccompanyByRM_RM, oItem.IsAccompanyByRM_SF, oItem.ReminderNextCall, oItem.NotAvailableReasonID, oItem.NotAvailableReason, oItem.IsNewVisit, oItem.Session, oItem.Brand1, oItem.Brand1Gimmick1, oItem.Brand1Gimmick2, oItem.Brand1Gimmick3, oItem.Brand1Sample1, oItem.Brand1Sample2, oItem.Brand1Sample3, oItem.Brand1Gimmick1Qty, oItem.Brand1Gimmick2Qty, oItem.Brand1Gimmick3Qty, oItem.Brand1Sample1Qty, oItem.Brand1Sample2Qty, oItem.Brand1Sample3Qty, oItem.Brand2, oItem.Brand2Gimmick1, oItem.Brand2Gimmick2, oItem.Brand2Gimmick3, oItem.Brand2Sample1, oItem.Brand2Sample2, oItem.Brand2Sample3, oItem.Brand2Gimmick1Qty, oItem.Brand2Gimmick2Qty, oItem.Brand2Gimmick3Qty, oItem.Brand2Sample1Qty, oItem.Brand2Sample2Qty, oItem.Brand2Sample3Qty, oItem.Brand3, oItem.Brand3Gimmick1, oItem.Brand3Gimmick2, oItem.Brand3Gimmick3, oItem.Brand3Sample1, oItem.Brand3Sample2, oItem.Brand3Sample3, oItem.Brand3Gimmick1Qty, oItem.Brand3Gimmick2Qty, oItem.Brand3Gimmick3Qty, oItem.Brand3Sample1Qty, oItem.Brand3Sample2Qty, oItem.Brand3Sample3Qty, oItem.Brand4, oItem.Brand4Gimmick1, oItem.Brand4Gimmick2, oItem.Brand4Gimmick3, oItem.Brand4Sample1, oItem.Brand4Sample2, oItem.Brand4Sample3, oItem.Brand4Gimmick1Qty, oItem.Brand4Gimmick2Qty, oItem.Brand4Gimmick3Qty, oItem.Brand4Sample1Qty, oItem.Brand4Sample2Qty, oItem.Brand4Sample3Qty, oItem.Brand5, oItem.Brand5Gimmick1, oItem.Brand5Gimmick2, oItem.Brand5Gimmick3, oItem.Brand5Sample1, oItem.Brand5Sample2, oItem.Brand5Sample3, oItem.Brand5Gimmick1Qty, oItem.Brand5Gimmick2Qty, oItem.Brand5Gimmick3Qty, oItem.Brand5Sample1Qty, oItem.Brand5Sample2Qty, oItem.Brand5Sample3Qty, oItem.Brand6, oItem.Brand6Gimmick1, oItem.Brand6Gimmick2, oItem.Brand6Gimmick3, oItem.Brand6Sample1, oItem.Brand6Sample2, oItem.Brand6Sample3, oItem.Brand6Gimmick1Qty, oItem.Brand6Gimmick2Qty, oItem.Brand6Gimmick3Qty, oItem.Brand6Sample1Qty, oItem.Brand6Sample2Qty, oItem.Brand6Sample3Qty, oItem.Brand7, oItem.Brand7Gimmick1, oItem.Brand7Gimmick2, oItem.Brand7Gimmick3, oItem.Brand7Sample1, oItem.Brand7Sample2, oItem.Brand7Sample3, oItem.Brand7Gimmick1Qty, oItem.Brand7Gimmick2Qty, oItem.Brand7Gimmick3Qty, oItem.Brand7Sample1Qty, oItem.Brand7Sample2Qty, oItem.Brand7Sample3Qty, oItem.Brand8, oItem.Brand8Gimmick1, oItem.Brand8Gimmick2, oItem.Brand8Gimmick3, oItem.Brand8Sample1, oItem.Brand8Sample2, oItem.Brand8Sample3, oItem.Brand8Gimmick1Qty, oItem.Brand8Gimmick2Qty, oItem.Brand8Gimmick3Qty, oItem.Brand8Sample1Qty, oItem.Brand8Sample2Qty, oItem.Brand8Sample3Qty, oItem.SubmitDateTime, oItem.ApprovedDateTime, oItem.SubmittedBy, oItem.ApprovedBy, oItem.Action, oItem.Version, oItem.SMSDCRNo, oItem.IsSendSMS, oItem.RejectReason);
                ExecuteNonQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Update(DCR oItem)
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL("UPDATE [DCR] SET  PvpDetailID = %n, DoctorID = %n, TerritoryID = %n, Day = %n, Month = %n, Year = %n, Status = %n, VisitDateTime = %d, IsVisited = %b, IsAvailable = %b, IsAccompanyByRM_RM = %b, IsAccompanyByRM_SF = %b, ReasonForNotCall = %s, NotAvailableReasonID = %n, NotAvailableReason = %s, IsNewVisit = %b, Session = %s, Brand1 = %n, Brand1Gimmick1 = %n, Brand1Gimmick2 = %n, Brand1Gimmick3 = %n, Brand1Sample1 = %n, Brand1Sample2 = %n, Brand1Sample3 = %n, Brand1Gimmick1Qty = %n, Brand1Gimmick2Qty = %n, Brand1Gimmick3Qty = %n, Brand1Sample1Qty = %n, Brand1Sample2Qty = %n, Brand1Sample3Qty = %n, Brand2 = %n, Brand2Gimmick1 = %n, Brand2Gimmick2 = %n, Brand2Gimmick3 = %n, Brand2Sample1 = %n, Brand2Sample2 = %n, Brand2Sample3 = %n, Brand2Gimmick1Qty = %n, Brand2Gimmick2Qty = %n, Brand2Gimmick3Qty = %n, Brand2Sample1Qty = %n, Brand2Sample2Qty = %n, Brand2Sample3Qty = %n, Brand3 = %n, Brand3Gimmick1 = %n, Brand3Gimmick2 = %n, Brand3Gimmick3 = %n, Brand3Sample1 = %n, Brand3Sample2 = %n, Brand3Sample3 = %n, Brand3Gimmick1Qty = %n, Brand3Gimmick2Qty = %n, Brand3Gimmick3Qty = %n, Brand3Sample1Qty = %n, Brand3Sample2Qty = %n, Brand3Sample3Qty = %n, Brand4 = %n, Brand4Gimmick1 = %n, Brand4Gimmick2 = %n, Brand4Gimmick3 = %n, Brand4Sample1 = %n, Brand4Sample2 = %n, Brand4Sample3 = %n, Brand4Gimmick1Qty = %n, Brand4Gimmick2Qty = %n, Brand4Gimmick3Qty = %n, Brand4Sample1Qty = %n, Brand4Sample2Qty = %n, Brand4Sample3Qty = %n, Brand5 = %n, Brand5Gimmick1 = %n, Brand5Gimmick2 = %n, Brand5Gimmick3 = %n, Brand5Sample1 = %n, Brand5Sample2 = %n, Brand5Sample3 = %n, Brand5Gimmick1Qty = %n, Brand5Gimmick2Qty = %n, Brand5Gimmick3Qty = %n, Brand5Sample1Qty = %n, Brand5Sample2Qty = %n, Brand5Sample3Qty = %n, Brand6 = %n, Brand6Gimmick1 = %n, Brand6Gimmick2 = %n, Brand6Gimmick3 = %n, Brand6Sample1 = %n, Brand6Sample2 = %n, Brand6Sample3 = %n, Brand6Gimmick1Qty = %n, Brand6Gimmick2Qty = %n, Brand6Gimmick3Qty = %n, Brand6Sample1Qty = %n, Brand6Sample2Qty = %n, Brand6Sample3Qty = %n,Brand7 = %n, Brand7Gimmick1 = %n, Brand7Gimmick2 = %n, Brand7Gimmick3 = %n, Brand7Sample1 = %n, Brand7Sample2 = %n, Brand7Sample3 = %n, Brand7Gimmick1Qty = %n, Brand7Gimmick2Qty = %n, Brand7Gimmick3Qty = %n, Brand7Sample1Qty = %n, Brand7Sample2Qty = %n, Brand7Sample3Qty = %n,Brand8 = %n, Brand8Gimmick1 = %n, Brand8Gimmick2 = %n, Brand8Gimmick3 = %n, Brand8Sample1 = %n, Brand8Sample2 = %n, Brand8Sample3 = %n, Brand8Gimmick1Qty = %n, Brand8Gimmick2Qty = %n, Brand8Gimmick3Qty = %n, Brand8Sample1Qty = %n, Brand8Sample2Qty = %n, Brand8Sample3Qty = %n, SubmitDateTime = %d, ApprovedDateTime = %d, SubmittedBy = %n, ApprovedBy = %n, Action = %n, Version = %n,SMSDCRNo=%s,IsSendSMS =%b,RejectReason=%s WHERE [DcrID]=%n"
                , oItem.PvpDetailID, oItem.DoctorID, oItem.TerritoryID, oItem.Day, oItem.Month, oItem.Year, oItem.Status, oItem.VisitDateTime, oItem.IsVisited, oItem.IsAvailable, oItem.IsAccompanyByRM_RM, oItem.IsAccompanyByRM_SF, oItem.ReminderNextCall, oItem.NotAvailableReasonID, oItem.NotAvailableReason, oItem.IsNewVisit, oItem.Session, oItem.Brand1, oItem.Brand1Gimmick1, oItem.Brand1Gimmick2, oItem.Brand1Gimmick3, oItem.Brand1Sample1, oItem.Brand1Sample2, oItem.Brand1Sample3, oItem.Brand1Gimmick1Qty, oItem.Brand1Gimmick2Qty, oItem.Brand1Gimmick3Qty, oItem.Brand1Sample1Qty, oItem.Brand1Sample2Qty, oItem.Brand1Sample3Qty, oItem.Brand2, oItem.Brand2Gimmick1, oItem.Brand2Gimmick2, oItem.Brand2Gimmick3, oItem.Brand2Sample1, oItem.Brand2Sample2, oItem.Brand2Sample3, oItem.Brand2Gimmick1Qty, oItem.Brand2Gimmick2Qty, oItem.Brand2Gimmick3Qty, oItem.Brand2Sample1Qty, oItem.Brand2Sample2Qty, oItem.Brand2Sample3Qty, oItem.Brand3, oItem.Brand3Gimmick1, oItem.Brand3Gimmick2, oItem.Brand3Gimmick3, oItem.Brand3Sample1, oItem.Brand3Sample2, oItem.Brand3Sample3, oItem.Brand3Gimmick1Qty, oItem.Brand3Gimmick2Qty, oItem.Brand3Gimmick3Qty, oItem.Brand3Sample1Qty, oItem.Brand3Sample2Qty, oItem.Brand3Sample3Qty, oItem.Brand4, oItem.Brand4Gimmick1, oItem.Brand4Gimmick2, oItem.Brand4Gimmick3, oItem.Brand4Sample1, oItem.Brand4Sample2, oItem.Brand4Sample3, oItem.Brand4Gimmick1Qty, oItem.Brand4Gimmick2Qty, oItem.Brand4Gimmick3Qty, oItem.Brand4Sample1Qty, oItem.Brand4Sample2Qty, oItem.Brand4Sample3Qty, oItem.Brand5, oItem.Brand5Gimmick1, oItem.Brand5Gimmick2, oItem.Brand5Gimmick3, oItem.Brand5Sample1, oItem.Brand5Sample2, oItem.Brand5Sample3, oItem.Brand5Gimmick1Qty, oItem.Brand5Gimmick2Qty, oItem.Brand5Gimmick3Qty, oItem.Brand5Sample1Qty, oItem.Brand5Sample2Qty, oItem.Brand5Sample3Qty, oItem.Brand6, oItem.Brand6Gimmick1, oItem.Brand6Gimmick2, oItem.Brand6Gimmick3, oItem.Brand6Sample1, oItem.Brand6Sample2, oItem.Brand6Sample3, oItem.Brand6Gimmick1Qty, oItem.Brand6Gimmick2Qty, oItem.Brand6Gimmick3Qty, oItem.Brand6Sample1Qty, oItem.Brand6Sample2Qty, oItem.Brand6Sample3Qty, oItem.Brand7, oItem.Brand7Gimmick1, oItem.Brand7Gimmick2, oItem.Brand7Gimmick3, oItem.Brand7Sample1, oItem.Brand7Sample2, oItem.Brand7Sample3, oItem.Brand7Gimmick1Qty, oItem.Brand7Gimmick2Qty, oItem.Brand7Gimmick3Qty, oItem.Brand7Sample1Qty, oItem.Brand7Sample2Qty, oItem.Brand7Sample3Qty, oItem.Brand8, oItem.Brand8Gimmick1, oItem.Brand8Gimmick2, oItem.Brand8Gimmick3, oItem.Brand8Sample1, oItem.Brand8Sample2, oItem.Brand8Sample3, oItem.Brand8Gimmick1Qty, oItem.Brand8Gimmick2Qty, oItem.Brand8Gimmick3Qty, oItem.Brand8Sample1Qty, oItem.Brand8Sample2Qty, oItem.Brand8Sample3Qty, oItem.SubmitDateTime, oItem.ApprovedDateTime, oItem.SubmittedBy, oItem.ApprovedBy, oItem.Action, oItem.Version, oItem.SMSDCRNo, oItem.IsSendSMS, oItem.RejectReason, oItem.ID.ToInt32);
                ExecuteNonQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Delete(int nDCRID)
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL("DELETE FROM [DCR] WHERE [DcrID]=%n"
                , nDCRID);
                ExecuteNonQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public IDataReader GetDCR(int nID)
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                sSQL = SQL.MakeSQL("SELECT * FROM [DCR] WHERE DcrID=%n", nID);
                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }
        public IDataReader GetDCRs()
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                sSQL = SQL.MakeSQL("SELECT * FROM [DCR] ");
                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }

        public int GetDCRID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nID = 0;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SElECT MAX(DcrID)+ 1 AS NewDCRID FROM DCR");
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nID = 1;
                }
                else
                {
                    nID = Convert.ToInt32(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nID;
        }


        public int GetDCRNewVersion(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sTerritoryID)
        {
            int nID = 0;
            string sSQL = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SElECT MAX(Version)+ 1 AS NewVersion FROM DCR");
                sSQL = sSQL + " WHERE TerritoryID like '" + sTerritoryID.Substring(0, 6) + "%'";
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nID = 1;
                }
                else
                {
                    nID = Convert.ToInt32(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nID;
        }

        public int GetDCRNewVersion(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nID = 0;
            string sSQL = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SElECT MAX(Version)+ 1 AS NewVersion FROM DCR");
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nID = 1;
                }
                else
                {
                    nID = Convert.ToInt32(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nID;
        }

        public DataTable GetDCRTableByDoctorIDTerritoryIDDayMonthYear(int nDoctorID, string sTerritory, int nDay,
            int nMonth, int nYear, string sSession, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                sSQL = SQL.MakeSQL(@"SELECT * FROM [DCR] WHERE 
                              DoctorID = %n AND TerritoryID = %s AND [Day] = %n AND
                              [Month] = %n  AND [Year] = %n AND [Session] =%s",
                               nDoctorID, sTerritory, nDay, nMonth, nYear, sSession);
                //                sSQL = @"SELECT * FROM [DCR] WHERE 
                //                              DoctorID = @nDoctorID AND TerritoryID = @sTerritory AND [Day] = @nDay AND
                //                              [Month] = @nMonth  AND [Year] = @nYear AND [Session] =@sSession";
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                //oSqlDataAdapter.SelectCommand.Parameters.Add("@nDoctorID", nDoctorID);
                //oSqlDataAdapter.SelectCommand.Parameters.Add("@sTerritory", sTerritory);
                //oSqlDataAdapter.SelectCommand.Parameters.Add("@nDay", nDay);
                //oSqlDataAdapter.SelectCommand.Parameters.Add("@nMonth", nMonth);
                //oSqlDataAdapter.SelectCommand.Parameters.Add("@nYear", nYear);
                //oSqlDataAdapter.SelectCommand.Parameters.Add("@sSession", sSession);
                oSqlDataAdapter.Fill(oTable);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public DataTable GetDCRDetailByDCRID(int nDCRID, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                sSQL = SQL.MakeSQL(@"SELECT * FROM [DCR] WHERE 
                              DcrID = %n",
                               nDCRID);
                //                sSQL = @"SELECT * FROM [DCR] WHERE 
                //                              DoctorID = @nDoctorID AND TerritoryID = @sTerritory AND [Day] = @nDay AND
                //                              [Month] = @nMonth  AND [Year] = @nYear AND [Session] =@sSession";
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                //oSqlDataAdapter.SelectCommand.Parameters.Add("@nDoctorID", nDoctorID);
                //oSqlDataAdapter.SelectCommand.Parameters.Add("@sTerritory", sTerritory);
                //oSqlDataAdapter.SelectCommand.Parameters.Add("@nDay", nDay);
                //oSqlDataAdapter.SelectCommand.Parameters.Add("@nMonth", nMonth);
                //oSqlDataAdapter.SelectCommand.Parameters.Add("@nYear", nYear);
                //oSqlDataAdapter.SelectCommand.Parameters.Add("@sSession", sSession);
                oSqlDataAdapter.Fill(oTable);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }


        public int InsertDCR(DCR oItem, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                int nDCRID = GetDCRID(oSqlConnection, oSqlTransaction);
                oItem.ID.SetID(nDCRID);
                sSQL = SQL.MakeSQL(@"INSERT INTO [DCR](DcrID, PvpDetailID, DoctorID, TerritoryID, Day, Month, Year, Status, VisitDateTime, IsVisited,
                 IsAvailable, IsAccompanyByRM_RM, IsAccompanyByRM_SF, ReminderNextCall, NotAvailableReasonID, NotAvailableReason, IsNewVisit, Session,
                Brand1, Brand1Gimmick1, Brand1Gimmick2, Brand1Gimmick3, Brand1Sample1, Brand1Sample2, Brand1Sample3, Brand1Gimmick1Qty, Brand1Gimmick2Qty,
                Brand1Gimmick3Qty, Brand1Sample1Qty, Brand1Sample2Qty, Brand1Sample3Qty, Brand2, Brand2Gimmick1, Brand2Gimmick2, Brand2Gimmick3, Brand2Sample1,
                Brand2Sample2, Brand2Sample3, Brand2Gimmick1Qty, Brand2Gimmick2Qty, Brand2Gimmick3Qty, Brand2Sample1Qty, Brand2Sample2Qty, Brand2Sample3Qty,
                Brand3, Brand3Gimmick1, Brand3Gimmick2, Brand3Gimmick3, Brand3Sample1, Brand3Sample2, Brand3Sample3, Brand3Gimmick1Qty, Brand3Gimmick2Qty, 
                Brand3Gimmick3Qty, Brand3Sample1Qty, Brand3Sample2Qty, Brand3Sample3Qty, Brand4, Brand4Gimmick1, Brand4Gimmick2, Brand4Gimmick3, Brand4Sample1,
                Brand4Sample2, Brand4Sample3, Brand4Gimmick1Qty, Brand4Gimmick2Qty, Brand4Gimmick3Qty, Brand4Sample1Qty, Brand4Sample2Qty, Brand4Sample3Qty,
                Brand5, Brand5Gimmick1, Brand5Gimmick2, Brand5Gimmick3, Brand5Sample1, Brand5Sample2, Brand5Sample3, Brand5Gimmick1Qty, Brand5Gimmick2Qty,
                Brand5Gimmick3Qty, Brand5Sample1Qty, Brand5Sample2Qty, Brand5Sample3Qty, Brand6, Brand6Gimmick1, Brand6Gimmick2, Brand6Gimmick3, Brand6Sample1, 
                Brand6Sample2, Brand6Sample3, Brand6Gimmick1Qty, Brand6Gimmick2Qty, Brand6Gimmick3Qty, Brand6Sample1Qty, Brand6Sample2Qty, Brand6Sample3Qty,
                Brand7, Brand7Gimmick1, Brand7Gimmick2, Brand7Gimmick3, Brand7Sample1, Brand7Sample2, Brand7Sample3, Brand7Gimmick1Qty, Brand7Gimmick2Qty, Brand7Gimmick3Qty, 
                Brand7Sample1Qty, Brand7Sample2Qty, Brand7Sample3Qty, Brand8, Brand8Gimmick1, Brand8Gimmick2, Brand8Gimmick3, Brand8Sample1, Brand8Sample2, Brand8Sample3, 
                Brand8Gimmick1Qty, Brand8Gimmick2Qty, Brand8Gimmick3Qty, Brand8Sample1Qty, Brand8Sample2Qty, Brand8Sample3Qty,
                SubmitDateTime, ApprovedDateTime, SubmittedBy, ApprovedBy, Action, Version,SMSDCRNo,IsSendSMS,RejectReason) 
                VALUES(%n, %n, %n, %s, %n, %n, %n, %n, %D, %b, %b, %b, %b, %s, %n, %s, %b, %s,
                %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n,
                %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n,
                %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n,
                %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n,%n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n,
                %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n,%D, %D, %n, %n, %n, %n,%s,%b,%s) "
               , oItem.ID.ToInt32, null, oItem.DoctorID, oItem.TerritoryID, oItem.Day, oItem.Month, oItem.Year, oItem.Status, oItem.VisitDateTime,
               oItem.IsVisited, oItem.IsAvailable, oItem.IsAccompanyByRM_RM, oItem.IsAccompanyByRM_SF, oItem.ReminderNextCall, oItem.NotAvailableReasonID,
               oItem.NotAvailableReason, oItem.IsNewVisit, oItem.Session, oItem.Brand1, oItem.Brand1Gimmick1, oItem.Brand1Gimmick2,
               oItem.Brand1Gimmick3, oItem.Brand1Sample1, oItem.Brand1Sample2, oItem.Brand1Sample3, oItem.Brand1Gimmick1Qty,
               oItem.Brand1Gimmick2Qty, oItem.Brand1Gimmick3Qty, oItem.Brand1Sample1Qty, oItem.Brand1Sample2Qty,
               oItem.Brand1Sample3Qty, oItem.Brand2, oItem.Brand2Gimmick1, oItem.Brand2Gimmick2,
               oItem.Brand2Gimmick3, oItem.Brand2Sample1, oItem.Brand2Sample2, oItem.Brand2Sample3, oItem.Brand2Gimmick1Qty,
               oItem.Brand2Gimmick2Qty, oItem.Brand2Gimmick3Qty, oItem.Brand2Sample1Qty, oItem.Brand2Sample2Qty,
               oItem.Brand2Sample3Qty, oItem.Brand3, oItem.Brand3Gimmick1, oItem.Brand3Gimmick2, oItem.Brand3Gimmick3,
               oItem.Brand3Sample1, oItem.Brand3Sample2, oItem.Brand3Sample3, oItem.Brand3Gimmick1Qty, oItem.Brand3Gimmick2Qty,
               oItem.Brand3Gimmick3Qty, oItem.Brand3Sample1Qty, oItem.Brand3Sample2Qty, oItem.Brand3Sample3Qty, oItem.Brand4,
               oItem.Brand4Gimmick1, oItem.Brand4Gimmick2, oItem.Brand4Gimmick3, oItem.Brand4Sample1, oItem.Brand4Sample2, oItem.Brand4Sample3,
               oItem.Brand4Gimmick1Qty, oItem.Brand4Gimmick2Qty, oItem.Brand4Gimmick3Qty, oItem.Brand4Sample1Qty, oItem.Brand4Sample2Qty,
               oItem.Brand4Sample3Qty, oItem.Brand5, oItem.Brand5Gimmick1, oItem.Brand5Gimmick2, oItem.Brand5Gimmick3, oItem.Brand5Sample1,
               oItem.Brand5Sample2, oItem.Brand5Sample3, oItem.Brand5Gimmick1Qty, oItem.Brand5Gimmick2Qty, oItem.Brand5Gimmick3Qty, oItem.Brand5Sample1Qty,
               oItem.Brand5Sample2Qty, oItem.Brand5Sample3Qty, oItem.Brand6, oItem.Brand6Gimmick1, oItem.Brand6Gimmick2, oItem.Brand6Gimmick3,
               oItem.Brand6Sample1, oItem.Brand6Sample2, oItem.Brand6Sample3, oItem.Brand6Gimmick1Qty, oItem.Brand6Gimmick2Qty,
               oItem.Brand6Gimmick3Qty, oItem.Brand6Sample1Qty, oItem.Brand6Sample2Qty, oItem.Brand6Sample3Qty,
               oItem.Brand7, oItem.Brand7Gimmick1, oItem.Brand7Gimmick2, oItem.Brand7Gimmick3, oItem.Brand7Sample1, oItem.Brand7Sample2, oItem.Brand7Sample3,
               oItem.Brand7Gimmick1Qty, oItem.Brand7Gimmick2Qty, oItem.Brand7Gimmick3Qty, oItem.Brand7Sample1Qty, oItem.Brand7Sample2Qty, oItem.Brand7Sample3Qty,
               oItem.Brand8, oItem.Brand8Gimmick1, oItem.Brand8Gimmick2, oItem.Brand8Gimmick3, oItem.Brand8Sample1, oItem.Brand8Sample2, oItem.Brand8Sample3,
               oItem.Brand8Gimmick1Qty, oItem.Brand8Gimmick2Qty, oItem.Brand8Gimmick3Qty, oItem.Brand8Sample1Qty, oItem.Brand8Sample2Qty, oItem.Brand8Sample3Qty,
               oItem.SubmitDateTime, oItem.ApprovedDateTime,
               oItem.SubmittedBy, oItem.ApprovedBy, oItem.Action, oItem.Version, oItem.SMSDCRNo, oItem.IsSendSMS, oItem.RejectReason);
                SqlDataAdapter InvAdapter = new SqlDataAdapter();
                SqlCommand InvCommand = new SqlCommand();
                InvCommand = new SqlCommand(sSQL, oSqlConnection);
                InvCommand.Transaction = oSqlTransaction;
                InvAdapter.InsertCommand = InvCommand;
                int i = InvCommand.ExecuteNonQuery();
                return i;
                //ExecuteNonQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int InsertDCRForNewVisit(DCR oItem, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                int nDCRID = GetDCRID(oSqlConnection, oSqlTransaction);
                oItem.ID.SetID(nDCRID);
                sSQL = SQL.MakeSQL(@"INSERT INTO [DCR](DcrID, PvpDetailID, DoctorID, TerritoryID, Day, Month, Year, Status, VisitDateTime, IsVisited,
                 IsAvailable, IsAccompanyByRM_RM, IsAccompanyByRM_SF, ReminderNextCall, NotAvailableReasonID, NotAvailableReason, IsNewVisit, Session,
                Brand1, Brand1Gimmick1, Brand1Gimmick2, Brand1Gimmick3, Brand1Sample1, Brand1Sample2, Brand1Sample3, Brand1Gimmick1Qty, Brand1Gimmick2Qty,
                Brand1Gimmick3Qty, Brand1Sample1Qty, Brand1Sample2Qty, Brand1Sample3Qty, Brand2, Brand2Gimmick1, Brand2Gimmick2, Brand2Gimmick3, Brand2Sample1,
                Brand2Sample2, Brand2Sample3, Brand2Gimmick1Qty, Brand2Gimmick2Qty, Brand2Gimmick3Qty, Brand2Sample1Qty, Brand2Sample2Qty, Brand2Sample3Qty,
                Brand3, Brand3Gimmick1, Brand3Gimmick2, Brand3Gimmick3, Brand3Sample1, Brand3Sample2, Brand3Sample3, Brand3Gimmick1Qty, Brand3Gimmick2Qty, 
                Brand3Gimmick3Qty, Brand3Sample1Qty, Brand3Sample2Qty, Brand3Sample3Qty, Brand4, Brand4Gimmick1, Brand4Gimmick2, Brand4Gimmick3, Brand4Sample1,
                Brand4Sample2, Brand4Sample3, Brand4Gimmick1Qty, Brand4Gimmick2Qty, Brand4Gimmick3Qty, Brand4Sample1Qty, Brand4Sample2Qty, Brand4Sample3Qty,
                Brand5, Brand5Gimmick1, Brand5Gimmick2, Brand5Gimmick3, Brand5Sample1, Brand5Sample2, Brand5Sample3, Brand5Gimmick1Qty, Brand5Gimmick2Qty,
                Brand5Gimmick3Qty, Brand5Sample1Qty, Brand5Sample2Qty, Brand5Sample3Qty, Brand6, Brand6Gimmick1, Brand6Gimmick2, Brand6Gimmick3, Brand6Sample1, 
                Brand6Sample2, Brand6Sample3, Brand6Gimmick1Qty, Brand6Gimmick2Qty, Brand6Gimmick3Qty, Brand6Sample1Qty, Brand6Sample2Qty, Brand6Sample3Qty,
                Brand7, Brand7Gimmick1, Brand7Gimmick2, Brand7Gimmick3, Brand7Sample1, Brand7Sample2, Brand7Sample3, Brand7Gimmick1Qty, Brand7Gimmick2Qty, 
                Brand7Gimmick3Qty, Brand7Sample1Qty, Brand7Sample2Qty, Brand7Sample3Qty, Brand8, Brand8Gimmick1, Brand8Gimmick2, Brand8Gimmick3, Brand8Sample1, 
                Brand8Sample2, Brand8Sample3, Brand8Gimmick1Qty, Brand8Gimmick2Qty, Brand8Gimmick3Qty, Brand8Sample1Qty, Brand8Sample2Qty, Brand8Sample3Qty,
                SubmitDateTime, ApprovedDateTime, SubmittedBy, ApprovedBy, Action, Version,SMSDCRNo,IsSendSMS,RejectReason) 
                VALUES(%n, %n, %n, %s, %n, %n, %n, %n, %D, %b, %b, %b, %b, %s, %n, %s, %b, %s,
                %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n,
                %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n,
                %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n,
                %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n,%n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n,%D, %D, %n, %n, %n, %n,%s,%b,%s) "
               , oItem.ID.ToInt32, oItem.PvpDetailID, oItem.DoctorID, oItem.TerritoryID, oItem.Day, oItem.Month, oItem.Year, oItem.Status, oItem.VisitDateTime,
               oItem.IsVisited, oItem.IsAvailable, oItem.IsAccompanyByRM_RM, oItem.IsAccompanyByRM_SF, oItem.ReminderNextCall, oItem.NotAvailableReasonID,
               oItem.NotAvailableReason, oItem.IsNewVisit, oItem.Session, oItem.Brand1, oItem.Brand1Gimmick1, oItem.Brand1Gimmick2,
               oItem.Brand1Gimmick3, oItem.Brand1Sample1, oItem.Brand1Sample2, oItem.Brand1Sample3, oItem.Brand1Gimmick1Qty,
               oItem.Brand1Gimmick2Qty, oItem.Brand1Gimmick3Qty, oItem.Brand1Sample1Qty, oItem.Brand1Sample2Qty,
               oItem.Brand1Sample3Qty, oItem.Brand2, oItem.Brand2Gimmick1, oItem.Brand2Gimmick2,
               oItem.Brand2Gimmick3, oItem.Brand2Sample1, oItem.Brand2Sample2, oItem.Brand2Sample3, oItem.Brand2Gimmick1Qty,
               oItem.Brand2Gimmick2Qty, oItem.Brand2Gimmick3Qty, oItem.Brand2Sample1Qty, oItem.Brand2Sample2Qty,
               oItem.Brand2Sample3Qty, oItem.Brand3, oItem.Brand3Gimmick1, oItem.Brand3Gimmick2, oItem.Brand3Gimmick3,
               oItem.Brand3Sample1, oItem.Brand3Sample2, oItem.Brand3Sample3, oItem.Brand3Gimmick1Qty, oItem.Brand3Gimmick2Qty,
               oItem.Brand3Gimmick3Qty, oItem.Brand3Sample1Qty, oItem.Brand3Sample2Qty, oItem.Brand3Sample3Qty, oItem.Brand4,
               oItem.Brand4Gimmick1, oItem.Brand4Gimmick2, oItem.Brand4Gimmick3, oItem.Brand4Sample1, oItem.Brand4Sample2, oItem.Brand4Sample3,
               oItem.Brand4Gimmick1Qty, oItem.Brand4Gimmick2Qty, oItem.Brand4Gimmick3Qty, oItem.Brand4Sample1Qty, oItem.Brand4Sample2Qty,
               oItem.Brand4Sample3Qty, oItem.Brand5, oItem.Brand5Gimmick1, oItem.Brand5Gimmick2, oItem.Brand5Gimmick3, oItem.Brand5Sample1,
               oItem.Brand5Sample2, oItem.Brand5Sample3, oItem.Brand5Gimmick1Qty, oItem.Brand5Gimmick2Qty, oItem.Brand5Gimmick3Qty, oItem.Brand5Sample1Qty,
               oItem.Brand5Sample2Qty, oItem.Brand5Sample3Qty, oItem.Brand6, oItem.Brand6Gimmick1, oItem.Brand6Gimmick2, oItem.Brand6Gimmick3,
               oItem.Brand6Sample1, oItem.Brand6Sample2, oItem.Brand6Sample3, oItem.Brand6Gimmick1Qty, oItem.Brand6Gimmick2Qty,
               oItem.Brand6Gimmick3Qty, oItem.Brand6Sample1Qty, oItem.Brand6Sample2Qty, oItem.Brand6Sample3Qty,
               oItem.Brand7, oItem.Brand7Gimmick1, oItem.Brand7Gimmick2, oItem.Brand7Gimmick3, oItem.Brand7Sample1, oItem.Brand7Sample2, oItem.Brand7Sample3,
               oItem.Brand7Gimmick1Qty, oItem.Brand7Gimmick2Qty, oItem.Brand7Gimmick3Qty, oItem.Brand7Sample1Qty, oItem.Brand7Sample2Qty, oItem.Brand7Sample3Qty,
               oItem.Brand8, oItem.Brand8Gimmick1, oItem.Brand8Gimmick2, oItem.Brand8Gimmick3, oItem.Brand8Sample1, oItem.Brand8Sample2, oItem.Brand8Sample3,
               oItem.Brand8Gimmick1Qty, oItem.Brand8Gimmick2Qty, oItem.Brand8Gimmick3Qty, oItem.Brand8Sample1Qty, oItem.Brand8Sample2Qty, oItem.Brand8Sample3Qty,
               oItem.SubmitDateTime, oItem.ApprovedDateTime,
               oItem.SubmittedBy, oItem.ApprovedBy, oItem.Action, oItem.Version, oItem.SMSDCRNo, oItem.IsSendSMS, oItem.RejectReason);
                SqlDataAdapter InvAdapter = new SqlDataAdapter();
                SqlCommand InvCommand = new SqlCommand();
                InvCommand = new SqlCommand(sSQL, oSqlConnection);
                InvCommand.Transaction = oSqlTransaction;
                InvAdapter.InsertCommand = InvCommand;
                int i = InvCommand.ExecuteNonQuery();
                return i;
                //ExecuteNonQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public int UpdateDCR(DCR oItem, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL(@"UPDATE [DCR] SET  PvpDetailID = %n, DoctorID = %n, TerritoryID = %s, Day = %n, Month = %n, Year = %n, Status = %n, 
                                    VisitDateTime = %D, IsVisited = %b, IsAvailable = %b, IsAccompanyByRM_RM = %b, IsAccompanyByRM_SF = %b, ReminderNextCall = %s,
                                    NotAvailableReasonID = %n, NotAvailableReason = %s, IsNewVisit = %b, Session = %s, Brand1 = %n, Brand1Gimmick1 = %n, 
                                    Brand1Gimmick2 = %n, Brand1Gimmick3 = %n, Brand1Sample1 = %n, Brand1Sample2 = %n, Brand1Sample3 = %n, Brand1Gimmick1Qty = %n, 
                                    Brand1Gimmick2Qty = %n, Brand1Gimmick3Qty = %n, Brand1Sample1Qty = %n, Brand1Sample2Qty = %n, Brand1Sample3Qty = %n,
                                    Brand2 = %n, Brand2Gimmick1 = %n, Brand2Gimmick2 = %n, Brand2Gimmick3 = %n, Brand2Sample1 = %n, Brand2Sample2 = %n, 
                                    Brand2Sample3 = %n, Brand2Gimmick1Qty = %n, Brand2Gimmick2Qty = %n, Brand2Gimmick3Qty = %n, Brand2Sample1Qty = %n, 
                                    Brand2Sample2Qty = %n, Brand2Sample3Qty = %n, Brand3 = %n, Brand3Gimmick1 = %n, Brand3Gimmick2 = %n, Brand3Gimmick3 = %n,
                                    Brand3Sample1 = %n, Brand3Sample2 = %n, Brand3Sample3 = %n, Brand3Gimmick1Qty = %n, Brand3Gimmick2Qty = %n,
                                    Brand3Gimmick3Qty = %n, Brand3Sample1Qty = %n, Brand3Sample2Qty = %n, Brand3Sample3Qty = %n, Brand4 = %n, Brand4Gimmick1 = %n,
                                    Brand4Gimmick2 = %n, Brand4Gimmick3 = %n, Brand4Sample1 = %n, Brand4Sample2 = %n, Brand4Sample3 = %n, Brand4Gimmick1Qty = %n,
                                    Brand4Gimmick2Qty = %n, Brand4Gimmick3Qty = %n, Brand4Sample1Qty = %n, Brand4Sample2Qty = %n, Brand4Sample3Qty = %n,
                                    Brand5 = %n, Brand5Gimmick1 = %n, Brand5Gimmick2 = %n, Brand5Gimmick3 = %n, Brand5Sample1 = %n, Brand5Sample2 = %n,
                                    Brand5Sample3 = %n, Brand5Gimmick1Qty = %n, Brand5Gimmick2Qty = %n, Brand5Gimmick3Qty = %n, Brand5Sample1Qty = %n,
                                    Brand5Sample2Qty = %n, Brand5Sample3Qty = %n, Brand6 = %n, Brand6Gimmick1 = %n, Brand6Gimmick2 = %n, Brand6Gimmick3 = %n,
                                    Brand6Sample1 = %n, Brand6Sample2 = %n, Brand6Sample3 = %n, Brand6Gimmick1Qty = %n, Brand6Gimmick2Qty = %n,
                                    Brand6Gimmick3Qty = %n, Brand6Sample1Qty = %n, Brand6Sample2Qty = %n, Brand6Sample3Qty = %n, Brand7 = %n, Brand7Gimmick1 = %n, 
                                    Brand7Gimmick2 = %n, Brand7Gimmick3 = %n, Brand7Sample1 = %n, Brand7Sample2 = %n, Brand7Sample3 = %n, Brand7Gimmick1Qty = %n, 
                                    Brand7Gimmick2Qty = %n, Brand7Gimmick3Qty = %n, Brand7Sample1Qty = %n, Brand7Sample2Qty = %n, Brand7Sample3Qty = %n,
                                    Brand8 = %n, Brand8Gimmick1 = %n, Brand8Gimmick2 = %n, Brand8Gimmick3 = %n, Brand8Sample1 = %n, Brand8Sample2 = %n, Brand8Sample3 = %n, 
                                    Brand8Gimmick1Qty = %n, Brand8Gimmick2Qty = %n, Brand8Gimmick3Qty = %n, Brand8Sample1Qty = %n, Brand8Sample2Qty = %n, Brand8Sample3Qty = %n,
                                    SubmitDateTime = %D,ApprovedDateTime = %D, SubmittedBy = %n, ApprovedBy = %n, Action = %n, Version = %n,SMSDCRNo=%s,IsSendSMS =%b,RejectReason=%s WHERE [DcrID]=%n"
                , oItem.PvpDetailID, oItem.DoctorID, oItem.TerritoryID, oItem.Day, oItem.Month, oItem.Year, oItem.Status, oItem.VisitDateTime,
                oItem.IsVisited, oItem.IsAvailable, oItem.IsAccompanyByRM_RM, oItem.IsAccompanyByRM_SF, oItem.ReminderNextCall, oItem.NotAvailableReasonID,
                oItem.NotAvailableReason, oItem.IsNewVisit, oItem.Session, oItem.Brand1, oItem.Brand1Gimmick1, oItem.Brand1Gimmick2, oItem.Brand1Gimmick3,
                oItem.Brand1Sample1, oItem.Brand1Sample2, oItem.Brand1Sample3, oItem.Brand1Gimmick1Qty, oItem.Brand1Gimmick2Qty, oItem.Brand1Gimmick3Qty,
                oItem.Brand1Sample1Qty, oItem.Brand1Sample2Qty, oItem.Brand1Sample3Qty, oItem.Brand2, oItem.Brand2Gimmick1, oItem.Brand2Gimmick2,
                oItem.Brand2Gimmick3, oItem.Brand2Sample1, oItem.Brand2Sample2, oItem.Brand2Sample3, oItem.Brand2Gimmick1Qty, oItem.Brand2Gimmick2Qty,
                oItem.Brand2Gimmick3Qty, oItem.Brand2Sample1Qty, oItem.Brand2Sample2Qty, oItem.Brand2Sample3Qty, oItem.Brand3, oItem.Brand3Gimmick1,
                oItem.Brand3Gimmick2, oItem.Brand3Gimmick3, oItem.Brand3Sample1, oItem.Brand3Sample2, oItem.Brand3Sample3, oItem.Brand3Gimmick1Qty,
                oItem.Brand3Gimmick2Qty, oItem.Brand3Gimmick3Qty, oItem.Brand3Sample1Qty, oItem.Brand3Sample2Qty, oItem.Brand3Sample3Qty, oItem.Brand4,
                oItem.Brand4Gimmick1, oItem.Brand4Gimmick2, oItem.Brand4Gimmick3, oItem.Brand4Sample1, oItem.Brand4Sample2, oItem.Brand4Sample3,
                oItem.Brand4Gimmick1Qty, oItem.Brand4Gimmick2Qty, oItem.Brand4Gimmick3Qty, oItem.Brand4Sample1Qty, oItem.Brand4Sample2Qty, oItem.Brand4Sample3Qty,
                oItem.Brand5, oItem.Brand5Gimmick1, oItem.Brand5Gimmick2, oItem.Brand5Gimmick3, oItem.Brand5Sample1, oItem.Brand5Sample2, oItem.Brand5Sample3,
                oItem.Brand5Gimmick1Qty, oItem.Brand5Gimmick2Qty, oItem.Brand5Gimmick3Qty, oItem.Brand5Sample1Qty, oItem.Brand5Sample2Qty, oItem.Brand5Sample3Qty,
                oItem.Brand6, oItem.Brand6Gimmick1, oItem.Brand6Gimmick2, oItem.Brand6Gimmick3, oItem.Brand6Sample1, oItem.Brand6Sample2, oItem.Brand6Sample3,
                oItem.Brand6Gimmick1Qty, oItem.Brand6Gimmick2Qty, oItem.Brand6Gimmick3Qty, oItem.Brand6Sample1Qty, oItem.Brand6Sample2Qty, oItem.Brand6Sample3Qty,
                oItem.Brand7, oItem.Brand7Gimmick1, oItem.Brand7Gimmick2, oItem.Brand7Gimmick3, oItem.Brand7Sample1, oItem.Brand7Sample2, oItem.Brand7Sample3, 
                oItem.Brand7Gimmick1Qty, oItem.Brand7Gimmick2Qty, oItem.Brand7Gimmick3Qty, oItem.Brand7Sample1Qty, oItem.Brand7Sample2Qty, oItem.Brand7Sample3Qty, 
                oItem.Brand8, oItem.Brand8Gimmick1, oItem.Brand8Gimmick2, oItem.Brand8Gimmick3, oItem.Brand8Sample1, oItem.Brand8Sample2, oItem.Brand8Sample3, 
                oItem.Brand8Gimmick1Qty, oItem.Brand8Gimmick2Qty, oItem.Brand8Gimmick3Qty, oItem.Brand8Sample1Qty, oItem.Brand8Sample2Qty, oItem.Brand8Sample3Qty,
                oItem.SubmitDateTime, oItem.ApprovedDateTime, oItem.SubmittedBy, oItem.ApprovedBy, oItem.Action, oItem.Version, oItem.SMSDCRNo, oItem.IsSendSMS,
                oItem.RejectReason, oItem.ID.ToInt32);
                //ExecuteNonQuery(sSQL);
                SqlDataAdapter InvAdapter = new SqlDataAdapter();
                SqlCommand InvCommand = new SqlCommand();
                InvCommand = new SqlCommand(sSQL, oSqlConnection);
                InvCommand.Transaction = oSqlTransaction;
                InvAdapter.UpdateCommand = InvCommand;
                int i = InvCommand.ExecuteNonQuery();
                return i;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int UpdateDCRDoctotNotAvailableStatus(int nDoctorID, string sTerritoryID, int nDay, int nMonth, int nYear, int nStatus,
                             int nIsAvailable, int nNotAvailableReasonID, string sNotAvailableReason, string sSubmitDateTime, int nSubmittedBy,
            int nAction, int nVersion, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL(@"UPDATE [DCR] SET  Status = %n,IsAvailable = %b, NotAvailableReasonID = %n, NotAvailableReason = %s, SubmitDateTime = %D,
                                    SubmittedBy = %n,Action = %n, Version = %n WHERE [DoctorID]=%n AND TerritoryID = %s AND Day = %n AND Month = %n AND Year = %n"
                , nStatus, nIsAvailable, nNotAvailableReasonID, sNotAvailableReason, sSubmitDateTime, nSubmittedBy, nAction, nVersion, nDoctorID, sTerritoryID, nDay, nMonth, nYear);

                SqlDataAdapter InvAdapter = new SqlDataAdapter();
                SqlCommand InvCommand = new SqlCommand();
                InvCommand = new SqlCommand(sSQL, oSqlConnection);
                InvCommand.Transaction = oSqlTransaction;
                InvAdapter.UpdateCommand = InvCommand;
                int i = InvCommand.ExecuteNonQuery();
                return i;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
