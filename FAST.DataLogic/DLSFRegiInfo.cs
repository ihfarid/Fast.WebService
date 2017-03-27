using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
    public partial class DLSFRegiInfo : DAAccess
    {
        public bool IsDuplicate(string sGDDBID)
        {
            string sSQL = "";
            object oCount;
            try
            {
                sSQL = SQL.MakeSQL(@"SELECT COUNT(*) FROM [OrderCollectionSystem].[dbo].[SFRegiInfo] WHERE GDDBID=%s", sGDDBID);
                oCount = ExecuteScalar(sSQL);
                if (Convert.ToInt32(oCount) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IDataReader GetActiveSFInfoByGDDBID(string sGDDBID)
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                sSQL = SQL.MakeSQL(@"SELECT * FROM [OrderCollectionSystem].[dbo].[SFRegiInfo] WHERE GDDBID=%s", sGDDBID);
                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }

        public IDataReader GetSFInfoByGDDBID(string sGDDBID)
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                sSQL = SQL.MakeSQL(@"SELECT * FROM [OrderCollectionSystem].[dbo].[SFRegiInfo] WHERE GDDBID=%s", sGDDBID);
                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }

        public IDataReader GetSFInfoByMobileNo(string sMobNo)
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                sSQL = SQL.MakeSQL(@"SELECT * FROM [OrderCollectionSystem].[dbo].[SFRegiInfo] WHERE Mobile=%s", sMobNo);
                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }


        public DataTable GetActiveSFRegInfo(string sGDDBID)
        {

            string sSQL = "";
            DataTable oTable = new DataTable();
            try
            {
                sSQL = SQL.MakeSQL("SELECT a.GDDBID, b.EmpCode, b.Name, d.TerritoryCode, a.SecQuesAns, a.PassWord,"
                + " a.Mobile, a.EntryDate, a.LastUpdateDate, e.Version,e.CommandVersion,e.AppConfigVersion,e.DoctorVersion,e.RouteVersion,"
                + " e.GimmickVersion, e.SampleVersion, e.HolidayVersion, e.BrandVersion, e.ReasonVersion, e.PVPVersion, e.PVPWorkingDayVersion, e.DCRVersion,"
                + " e.AppVersion,e.NoOfTargetDoctor,e.IsActive, c.SecQues, e.UserType FROM [OrderCollectionSystem].[dbo].[SFRegiInfo] a INNER JOIN"
                + " [OrderCollectionSystem].[dbo].[EmployeeInfo] b ON a.EmployeeID = b.EmployeeID INNER JOIN"
                + " [OrderCollectionSystem].[dbo].[SecQuesInfo] c ON a.SecQuesID=c.SecQuesID INNER JOIN"
                + " [OrderCollectionSystem].[dbo].[Territory] d ON a.TerritoryID=d.TerritoryID"
                + " INNER JOIN [UserInfo] e ON a.GDDBID=e.GDDBID WHERE a.GDDBID=%s", sGDDBID);
                oTable = FillDataTable(sSQL, "SFRegInfo");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public DataTable GetActiveSFRegInfo(string sGDDBID, string sConnectionString)
        {

            string sSQL = "";
            DataTable oTable = new DataTable();
            try
            {
                sSQL = SQL.MakeSQL("SELECT a.GDDBID, b.EmpCode, b.Name, d.TerritoryCode, a.SecQuesAns, a.PassWord,"
                + " a.Mobile, a.EntryDate, a.LastUpdateDate, e.Version,e.CommandVersion,e.AppConfigVersion,e.DoctorVersion,e.DoctorReqVersion,e.DoctorLogVersion,e.RouteVersion,"
                + " e.DegreeVersion,e.SpecialtyVersion,e.SalutationVersion,e.DistrictVersion,e.UpazillaVersion,e.LineSpeProductVersion,e.GimmickVersion, e.SampleVersion, e.HolidayVersion, e.BrandVersion, e.ReasonVersion, e.PVPVersion, e.PVPWorkingDayVersion, e.DCRVersion,"
                + " e.AppVersion,e.NoOfTargetDoctor,e.IsActive, c.SecQues, e.UserType FROM [OrderCollectionSystem].[dbo].[SFRegiInfo] a INNER JOIN"
                + " [OrderCollectionSystem].[dbo].[EmployeeInfo] b ON a.EmployeeID = b.EmployeeID INNER JOIN"
                + " [OrderCollectionSystem].[dbo].[SecQuesInfo] c ON a.SecQuesID=c.SecQuesID INNER JOIN"
                + " [OrderCollectionSystem].[dbo].[Territory] d ON a.TerritoryID=d.TerritoryID"
                + " INNER JOIN [UserInfo] e ON a.GDDBID=e.GDDBID WHERE a.GDDBID=%s", sGDDBID);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public DataTable SaveSFInfoForReg(SFRegiInfo oItem)
        {
            DataTable oTable;
            SqlParameter[] oParameters = new SqlParameter[7];
            try
            {
                oParameters[0] = new SqlParameter("@GDDBID", oItem.GDDBID);
                oParameters[1] = new SqlParameter("@EmployeeID", oItem.EmployeeID);
                oParameters[2] = new SqlParameter("@TerritoryID", oItem.TerritoryID);
                oParameters[3] = new SqlParameter("@SecQuesID", oItem.SecQuesID);
                oParameters[4] = new SqlParameter("@SecQuesAns", oItem.SecQuesAns);
                oParameters[5] = new SqlParameter("@PassWord", oItem.PassWord);
                oParameters[6] = new SqlParameter("@Mobile", oItem.Mobile);
                oTable = FillDataTable("SFInfoForReg", "[FAST].[dbo].[spSFRegistration]", oParameters);
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public DataTable SFPasswordUpdate(string sGDDBID, string sPassword)
        {
            DataTable oTable;
            SqlParameter[] oParameters = new SqlParameter[2];
            try
            {
                oParameters[0] = new SqlParameter("@GDDBID", sGDDBID);
                oParameters[1] = new SqlParameter("@NewPassword", sPassword);
                oTable = FillDataTable("SFPasswordUpdate", "[FAST].[dbo].[spSFPasswordUpdate]", oParameters);
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }        

        public int GetCustomerVersion(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sTerritoryID)
        {
            int nMaxCustomerVersion;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SELECT MAX(Version) FROM [OrderCollectionSystem].[dbo].[TerritoryWiseCustInfo] WHERE TerritoryID=%s", sTerritoryID);
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nMaxCustomerVersion = 1;
                }
                else
                {
                    nMaxCustomerVersion = Convert.ToInt32(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nMaxCustomerVersion;
        }

        public int GetProductVersion(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sTerritoryID)
        {
            int nMaxProductVersion;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SELECT MAX(Version) FROM [OrderCollectionSystem].[dbo].[TerritoryWiseProductInfo] WHERE TerritoryID=%s", sTerritoryID);
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nMaxProductVersion = 1;
                }
                else
                {
                    nMaxProductVersion = Convert.ToInt32(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nMaxProductVersion;
        }

        public DataTable GetSFInfoByGDDBID(string sGDDBID, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                sSQL = SQL.MakeSQL(@"SELECT * FROM [OrderCollectionSystem].[dbo].[SFRegiInfo] WHERE GDDBID = %s", sGDDBID);
                //sSQL = SQL.MakeSQL(@"SELECT * FROM [SFRegiInfo] WHERE GDDBID = %s and IsActive=%n", sGDDBID, 1);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        //public bool IsDuplicate(string sSFRegiInfoName)
        //{
        //string sSQL = "";
        //object oCount;
        //try
        //{
        //sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [SFRegiInfo] WHERE SFRegiInfoName=%s ", sSFRegiInfoName);
        //oCount = ExecuteScalar(sSQL);
        //if (Convert.ToInt32(oCount) > 0)
        //{
        //return true;
        //}
        //else
        //{
        //return false;
        //}
        //}
        //catch (Exception e)
        //{
        //throw new Exception(e.Message);
        //}
        //}
        //public bool IsDuplicate(string sSFRegiInfoName, int nID)
        //{
        //string sSQL = "";
        //object oCount;
        //try
        //{
        //sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [SFRegiInfo] WHERE SFRegiInfoName=%s AND SFRegiID!= %n ", sSFRegiInfoName, nID);
        //oCount = ExecuteScalar(sSQL);
        //if (Convert.ToInt32(oCount) > 0)
        //{
        //return true;
        //}
        //else
        //{
        //return false;
        //}
        //}
        //catch (Exception e)
        //{
        //throw new Exception(e.Message);
        //}
        //}
        //public IDataReader GetSFRegiInfo(string sSFRegiInfoName)
        //{
        //string sSQL = "";
        //IDataReader oReader;
        //try
        //{
        //sSQL = SQL.MakeSQL("SELECT * FROM [SFRegiInfo] WHERE [SFRegiInfoName]=%s ", sSFRegiInfoName);
        //oReader = ExecuteReader(sSQL);
        //}
        //catch (Exception e)
        //{
        //throw new Exception(e.Message);
        //}
        //return oReader;
        //}


    }
}
