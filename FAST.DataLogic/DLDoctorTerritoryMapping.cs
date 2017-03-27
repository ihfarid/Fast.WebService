using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
	public partial class DLDoctorTerritoryMapping: DAAccess
	{

        public DataTable GetDoctorDetail(string sTerritoryID, int nMaxVersion)
        {

            string sSQL = "";
            DataTable oTable = new DataTable();
            try
            {
                sSQL = SQL.MakeSQL("SELECT g.TerritoryID, a.ID, a.DocName, b.SalDesc, c.SpDesc, d.DegName, a.Institute, a.Address,"
                + " e.DistName, f.UName, a.BirthDay, a.Mrgday, a.Email, a.MobileNo, g.DocTypeID, g.SwajanStatus,"
                + " h.Code PCode, h.Name PName, i1.ProdCode+'-'+i1.ProdName Product1, i2.ProdCode+'-'+i2.ProdName Product2,"
                + " i3.ProdCode+'-'+i3.ProdName Product3, i4.ProdCode+'-'+i4.ProdName Product4, i5.ProdCode+'-'+i5.ProdName Product5,"
                + " i6.ProdCode+'-'+i6.ProdName Product6, i7.ProdCode+'-'+i7.ProdName Product7, i8.ProdCode+'-'+i8.ProdName Product8, g.CallFre, j.RName, k.SessName, g.Status, g.CreateDatetime,"
                + " g.ModifyDatetime, g.Version, g.Action  from [doctor] a INNER JOIN [Salutation] b ON a.SalutationID=b.SalID"
                + " INNER JOIN Specialty c on a.SpecialtyID = c.SpID INNER JOIN Degree d ON a.DegreeID= d.DegID INNER JOIN"
                + " District e ON a.DistrictID=e.DistID INNER JOIN Upazilla f ON a.UpazillaID=f.UID INNER JOIN"
                + " DoctorTerritoryMapping g ON a.ID=g.DoctorID INNER JOIN Profile h ON g.ProfileID=h.ID INNER JOIN Product i1"
                + " ON g.Prod1=i1.ProdID INNER JOIN Product i2 ON g.Prod2=i2.ProdID INNER JOIN Product i3 ON g.Prod3=i3.ProdID"
                + " INNER JOIN Product i4 ON g.Prod4=i4.ProdID INNER JOIN Product i5 ON g.Prod5=i5.ProdID INNER JOIN Product i6"
                + " ON g.Prod6=i6.ProdID INNER JOIN Product i7 ON g.Prod7=i7.ProdID INNER JOIN Product i8 ON g.Prod8=i8.ProdID INNER JOIN Route j ON g.RouteID=j.RID INNER JOIN VisitSession k on g.SessionID=k.SessID"
                + " where g.TerritoryID=j.TerrID and g.TerritoryID = %s and g.Prod1 !=0 and g.Prod2 !=0 and g.Prod3 !=0 and g.Prod4 !=0 and g.Prod5 !=0"
                + " and g.Prod6 !=0 and g.RouteID !=0  and (g.Status=%n OR g.Status=%n) and g.Version > %n", sTerritoryID, 2, 4, nMaxVersion);
                oTable = FillDataTable(sSQL, "CustomerList");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public DataTable GetDoctorDetail(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                sSQL = SQL.MakeSQL("SELECT g.TerritoryID, a.BMDCCode,p.PostStpCngName, a.ID, a.DocName, b.SalDesc,g.Address,g.Speciality,g.Degree,c1.SpCode spName1, c2.SpCode spName2, d1.DegName degName1, d2.DegName degName2, a.Institute, a.Address1,a.Address2, a.Address3,"
                + " e.DistName, f.UName, a.BirthDay, a.Mrgday, a.Email, a.MobileNo, g.DocTypeID, g.SwajanStatus,"
                + " h.Code PCode, h.Name PName, i1.ProdCode+'-'+i1.ProdName Product1, i2.ProdCode+'-'+i2.ProdName Product2,"
                + " i3.ProdCode+'-'+i3.ProdName Product3, i4.ProdCode+'-'+i4.ProdName Product4, i5.ProdCode+'-'+i5.ProdName Product5,"
                + " i6.ProdCode+'-'+i6.ProdName Product6,i7.ProdCode+'-'+i7.ProdName Product7,i8.ProdCode+'-'+i8.ProdName Product8, g.CallFre, j.RName, k.SessName, g.Status, g.CreateDatetime,"
                + " g.ModifyDatetime, a.CardAttachement, g.Version, g.Action  from [doctor] a INNER JOIN [Salutation] b ON a.SalutationID=b.SalID"
                + " INNER JOIN Specialty c1 on a.SpecialtyID1 = c1.SpID LEFT outer JOIN Specialty c2 on a.SpecialtyID2 = c2.SpID INNER JOIN Degree d1"
                + " ON a.DegreeID1= d1.DegID LEFT outer JOIN Degree d2 ON a.DegreeID2= d2.DegID  INNER JOIN"
                + " District e ON a.DistrictID=e.DistID INNER JOIN Upazilla f ON a.UpazillaID=f.UID INNER JOIN"
                + " DoctorTerritoryMapping g ON a.ID=g.DoctorID INNER JOIN Profile h ON g.ProfileID=h.ID LEFT JOIN Product i1"
                + " ON g.Prod1=i1.ProdID LEFT JOIN Product i2 ON g.Prod2=i2.ProdID LEFT JOIN Product i3 ON g.Prod3=i3.ProdID"
                + " LEFT JOIN Product i4 ON g.Prod4=i4.ProdID LEFT JOIN Product i5 ON g.Prod5=i5.ProdID LEFT JOIN Product i6"
                + " ON g.Prod6=i6.ProdID LEFT JOIN Product i7 ON g.Prod7=i7.ProdID LEFT JOIN Product i8 ON g.Prod8=i8.ProdID  LEFT JOIN PostStepChange p ON g.PostStepChange = p.PostStpCngID INNER JOIN Route j ON g.RouteID=j.RID INNER JOIN VisitSession k on g.SessionID=k.SessID"
                + " where g.TerritoryID=j.TerrID and g.TerritoryID = %s and"
                + " g.Version > %n", sTerritoryID, nMaxVersion);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public DataTable GetDoctorDetailForRM(string sTerritoryID, int nMaxVersion)
        {

            string sSQL = "";
            DataTable oTable = new DataTable();
            try
            {
                string sSQL1 = SQL.MakeSQL("SELECT g.TerritoryID, a.ID, a.DocName, b.SalDesc, c.SpDesc, d.DegName, a.Institute, a.Address,"
                + " e.DistName, f.UName, a.BirthDay, a.Mrgday, a.Email, a.MobileNo, g.DocTypeID, g.SwajanStatus,"
                + " h.Code PCode, h.Name PName, i1.ProdCode+'-'+i1.ProdName Product1, i2.ProdCode+'-'+i2.ProdName Product2,"
                + " i3.ProdCode+'-'+i3.ProdName Product3, i4.ProdCode+'-'+i4.ProdName Product4, i5.ProdCode+'-'+i5.ProdName Product5,"
                + " i6.ProdCode+'-'+i6.ProdName Product6,i7.ProdCode+'-'+i7.ProdName Product7,i8.ProdCode+'-'+i8.ProdName Product8, g.CallFre, j.RName, k.SessName, g.Status, g.CreateDatetime,"
                + " g.ModifyDatetime, g.Version, g.Action  from [doctor] a INNER JOIN [Salutation] b ON a.SalutationID=b.SalID"
                + " INNER JOIN Specialty c on a.SpecialtyID = c.SpID INNER JOIN Degree d ON a.DegreeID= d.DegID INNER JOIN"
                + " District e ON a.DistrictID=e.DistID INNER JOIN Upazilla f ON a.UpazillaID=f.UID INNER JOIN"
                + " DoctorTerritoryMapping g ON a.ID=g.DoctorID INNER JOIN Profile h ON g.ProfileID=h.ID INNER JOIN Product i1"
                + " ON g.Prod1=i1.ProdID INNER JOIN Product i2 ON g.Prod2=i2.ProdID INNER JOIN Product i3 ON g.Prod3=i3.ProdID"
                + " INNER JOIN Product i4 ON g.Prod4=i4.ProdID INNER JOIN Product i5 ON g.Prod5=i5.ProdID INNER JOIN Product i6"
                + " ON g.Prod6=i6.ProdID INNER JOIN Product i7 ON g.Prod7=i7.ProdID INNER JOIN Product i8 ON g.Prod8=i8.ProdID INNER JOIN Route j ON g.RouteID=j.RID INNER JOIN VisitSession k on g.SessionID=k.SessID"
                + " where g.TerritoryID=j.TerrID and g.Prod1 !=0 and g.Prod2 !=0 and g.Prod3 !=0 and g.Prod4 !=0 and g.Prod5 !=0"
                + " and g.Prod6 !=0 and g.RouteID !=0 and (g.Status=%n OR g.Status=%n) and g.Version > %n", 2, 4, nMaxVersion);
                string sSQL2 = " and g.TerritoryID like '" + sTerritoryID + "%' ORDER BY g.TerritoryID";                
                sSQL = sSQL1 + sSQL2;
                oTable = FillDataTable(sSQL, "CustomerList");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public DataTable GetDoctorDetailForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                string sSQL1 = SQL.MakeSQL("SELECT g.TerritoryID, a.ID, a.DocName, a.BMDCCode,p.PostStpCngName, b.SalDesc,g.Address,g.Speciality,g.Degree,c1.SpCode spName1, c2.SpCode spName2, d1.DegName degName1, d2.DegName degName2, a.Institute, a.Address1,a.Address2, a.Address3,"
                + " e.DistName, f.UName, a.BirthDay, a.Mrgday, a.Email, a.MobileNo, g.DocTypeID, g.SwajanStatus,"
                + " h.Code PCode, h.Name PName, i1.ProdCode+'-'+i1.ProdName Product1, i2.ProdCode+'-'+i2.ProdName Product2,"
                + " i3.ProdCode+'-'+i3.ProdName Product3, i4.ProdCode+'-'+i4.ProdName Product4, i5.ProdCode+'-'+i5.ProdName Product5,"
                + " i6.ProdCode+'-'+i6.ProdName Product6, i7.ProdCode+'-'+i7.ProdName Product7, i8.ProdCode+'-'+i8.ProdName Product8, g.CallFre, j.RName, k.SessName, g.Status, g.CreateDatetime,"
                + " g.ModifyDatetime, a.CardAttachement, g.Version, g.Action  from [doctor] a INNER JOIN [Salutation] b ON a.SalutationID=b.SalID"
                + " INNER JOIN Specialty c1 on a.SpecialtyID1 = c1.SpID LEFT outer JOIN Specialty c2 on a.SpecialtyID2 = c2.SpID INNER JOIN Degree d1"
                + " ON a.DegreeID1= d1.DegID LEFT outer JOIN Degree d2 ON a.DegreeID2= d2.DegID  INNER JOIN"
                + " District e ON a.DistrictID=e.DistID INNER JOIN Upazilla f ON a.UpazillaID=f.UID INNER JOIN"
                + " DoctorTerritoryMapping g ON a.ID=g.DoctorID INNER JOIN Profile h ON g.ProfileID=h.ID LEFT JOIN Product i1"
                + " ON g.Prod1=i1.ProdID LEFT JOIN Product i2 ON g.Prod2=i2.ProdID LEFT JOIN Product i3 ON g.Prod3=i3.ProdID"
                + " LEFT JOIN Product i4 ON g.Prod4=i4.ProdID LEFT JOIN Product i5 ON g.Prod5=i5.ProdID LEFT JOIN Product i6"
                + " ON g.Prod6=i6.ProdID LEFT JOIN Product i7 ON g.Prod7=i7.ProdID LEFT JOIN Product i8 ON g.Prod8=i8.ProdID INNER JOIN Route j ON g.RouteID=j.RID LEFT JOIN PostStepChange p ON g.PostStepChange = p.PostStpCngID INNER JOIN VisitSession k on g.SessionID=k.SessID"
                + "  where g.TerritoryID=j.TerrID and g.Version > %n", nMaxVersion);
                string sSQL2 = " and g.TerritoryID like '" + sTerritoryID + "%' ORDER BY g.TerritoryID";
                sSQL = sSQL1 + sSQL2;
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        //public DataTable GetDoctorDetailForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        //{
        //    string sSQL = "";
        //    DataTable oTable = new DataTable();

        //    try
        //    {
        //        string sSQL1 = SQL.MakeSQL("SELECT g.TerritoryID, a.ID, a.DocName, a.BMDCCode,p.PostStpCngName, b.SalDesc,g.Address,g.Speciality,g.Degree,c1.SpCode spName1, c2.SpCode spName2, d1.DegName degName1, d2.DegName degName2, a.Institute, a.Address1,a.Address2, a.Address3,"
        //        + " e.DistName, f.UName, a.BirthDay, a.Mrgday, a.Email, a.MobileNo, g.DocTypeID, g.SwajanStatus,"
        //        + " h.Code PCode, h.Name PName, i1.ProdCode+'-'+i1.ProdName Product1, i2.ProdCode+'-'+i2.ProdName Product2,"
        //        + " i3.ProdCode+'-'+i3.ProdName Product3, i4.ProdCode+'-'+i4.ProdName Product4, i5.ProdCode+'-'+i5.ProdName Product5,"
        //        + " i6.ProdCode+'-'+i6.ProdName Product6, g.CallFre, j.RName, k.SessName, g.Status, g.CreateDatetime,"
        //        + " g.ModifyDatetime, a.CardAttachement, g.Version, g.Action  from [doctor] a INNER JOIN [Salutation] b ON a.SalutationID=b.SalID"
        //        + " INNER JOIN Specialty c1 on a.SpecialtyID1 = c1.SpID LEFT outer JOIN Specialty c2 on a.SpecialtyID2 = c2.SpID INNER JOIN Degree d1"
        //        + " ON a.DegreeID1= d1.DegID LEFT outer JOIN Degree d2 ON a.DegreeID2= d2.DegID  INNER JOIN"
        //        + " District e ON a.DistrictID=e.DistID INNER JOIN Upazilla f ON a.UpazillaID=f.UID INNER JOIN"
        //        + " DoctorTerritoryMapping g ON a.ID=g.DoctorID INNER JOIN Profile h ON g.ProfileID=h.ID INNER JOIN Product i1"
        //        + " ON g.Prod1=i1.ProdID INNER JOIN Product i2 ON g.Prod2=i2.ProdID INNER JOIN Product i3 ON g.Prod3=i3.ProdID"
        //        + " INNER JOIN Product i4 ON g.Prod4=i4.ProdID INNER JOIN Product i5 ON g.Prod5=i5.ProdID INNER JOIN Product i6"
        //        + " ON g.Prod6=i6.ProdID INNER JOIN Route j ON g.RouteID=j.RID LEFT JOIN PostStepChange p ON g.PostStepChange = p.PostStpCngID INNER JOIN VisitSession k on g.SessionID=k.SessID"
        //        + "  where g.TerritoryID=j.TerrID and g.Prod1 !=0 and g.Prod2 !=0 and g.Prod3 !=0 and g.Prod4 !=0 and g.Prod5 !=0"
        //        + " and g.Prod6 !=0 and g.RouteID !=0  and g.Version > %n", nMaxVersion);
        //        string sSQL2 = " and g.TerritoryID like '" + sTerritoryID + "%' ORDER BY g.TerritoryID";
        //        sSQL = sSQL1 + sSQL2;
        //        SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
        //        oSqlDataAdapter.Fill(oTable);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //    return oTable;
        //}

        public DataTable GetRouteInfo(string sTerritoryID, int nMaxVersion)
        {

            string sSQL = "";
            DataTable oTable = new DataTable();
            try
            {
                sSQL = SQL.MakeSQL("SELECT TerrID, RID, RName, Version, Action FROM [Route] WHERE TerrID =%s and RID !=%n and Status=%n and Version > %n ORDER BY RID", sTerritoryID, 0, 1, nMaxVersion);
                oTable = FillDataTable(sSQL, "CustomerList");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }


        public DataTable GetTerritoryDisUpaWiseAllDoctorList(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                sSQL = SQL.MakeSQL(@"SELECT * FROM DMRDoctorMasterData WHERE UpazillaID IN
                     (SELECT UpazillaID FROM TerrLocationMapping WHERE Territory = %s) 
                     AND DistrictID IN(SELECT DistrictID FROM TerrLocationMapping WHERE Territory = %s)
                     AND ID NOT IN(SELECT DoctorID FROM DoctorTerritoryMapping WHERE TerritoryID = %s AND Status = 2) ORDER BY DocName", sTerritoryID, sTerritoryID, sTerritoryID);
                // sSQL = SQL.MakeSQL("SELECT  a.ID, a.DocName, a.Address "
                //+" from [doctor] a", 2, 4, nMaxVersion);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }


        public DataTable GetCompanyRxByQty(string sFrPID, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                sSQL = SQL.MakeSQL(@"SELECT * FROM [DoctorCompanyRxShare] WHERE ShareCategory = 'Qty' AND PhyID = %s", sFrPID);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }


        public DataTable GetCompanyRxByValue(string sFrPID, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                sSQL = SQL.MakeSQL(@"SELECT * FROM [DoctorCompanyRxShare] WHERE ShareCategory = 'VALUE' AND PhyID = %s", sFrPID);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }


        public DataTable GetMoleculeRxList(string sFrPID, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                sSQL = SQL.MakeSQL(@"SELECT [PHY_ID],[Molecule],(([MoleculeCount]/[TotalCount])*100) as Rx FROM [DoctorMoleculeRxShare] WHERE [PHY_ID] =  %s", sFrPID);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }


        public DataTable GetProductInfo(string sLineID, int nMaxVersion, string sConnectionString)
        {

            string sSQL = "";
            DataTable oTable = new DataTable();
            try
            {
                sSQL = SQL.MakeSQL("SELECT l.LineID,s.SpCode,p.ProdName,l.Priority,l.RankWithin,l.Action,l.Version FROM [Line_Specialty_Product] l, Product p, Specialty s WHERE l.LineID=%s AND s.SpID = l.SPID AND l.ProdID = p.ProdID and l.Version > %n", sLineID, nMaxVersion);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
                //oTable = FillDataTable(sSQL, "DoctorLogList");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public DataTable GetRouteInfo(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                sSQL = SQL.MakeSQL("SELECT TerrID, RID, RName, Version, Action FROM [Route] WHERE TerrID =%s and RID !=%n and Status=%n and Version > %n ORDER BY RID", sTerritoryID, 0, 1, nMaxVersion);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public DataTable GetRouteInfoForRM(string sTerritoryID, int nMaxVersion)
        {

            string sSQL = "";
            DataTable oTable = new DataTable();
            try
            {
                string sSQL1 = SQL.MakeSQL("SELECT TerrID, RID, RName, Version, Action FROM [Route] WHERE Status=%n and RID !=%n and Version > %n", 1, 0, nMaxVersion);
                string sSQL2 = " and TerrID like '" + sTerritoryID + "%' ORDER BY TerrID";                
                sSQL = sSQL1 + sSQL2;
                oTable = FillDataTable(sSQL, "CustomerList");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public DataTable GetRouteInfoForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                string sSQL1 = SQL.MakeSQL("SELECT TerrID, RID, RName, Version, Action FROM [Route] WHERE Status=%n and RID !=%n and Version > %n", 1, 0, nMaxVersion);
                string sSQL2 = " and TerrID like '" + sTerritoryID + "%' ORDER BY TerrID";
                sSQL = sSQL1 + sSQL2;
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public DataTable GetProductInfoForRM(int nMaxVersion, string sLine, string sConnectionString)
        {

            string sSQL = "";
            DataTable oTable = new DataTable();
            try
            {
                sSQL = SQL.MakeSQL(@"SELECT l.LineID,s.SpCode,p.ProdName,l.Priority,l.RankWithin,l.Action,l.Version 
                FROM [Line_Specialty_Product] l INNER JOIN Product p ON l.ProdID = p.ProdID INNER JOIN Specialty s 
                ON s.SpID = l.SPID Where l.Version > %n and l.LineID=%s", nMaxVersion, sLine);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public int AddLog(int nDoctorID, string sTerritoryID, int nStatus, string sReason, int nType, String sGDDBID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nResult = 0;

            try
            {
                SqlCommand oSqlCommand = new SqlCommand("spAddLog", oSqlConnection, oSqlTransaction);
                oSqlCommand.CommandType = CommandType.StoredProcedure;
                oSqlCommand.Parameters.Add("@DoctorID", SqlDbType.Int, 50).Value = nDoctorID;
                oSqlCommand.Parameters.Add("@TerritoryID", SqlDbType.VarChar, 50).Value = sTerritoryID;
                oSqlCommand.Parameters.Add("@Status", SqlDbType.Int, 50).Value = nStatus;
                oSqlCommand.Parameters.Add("@Reason", SqlDbType.VarChar, 50).Value = sReason;
                oSqlCommand.Parameters.Add("@Type", SqlDbType.Int, 50).Value = nType;
                oSqlCommand.Parameters.Add("@GDDBID", SqlDbType.VarChar, 50).Value = sGDDBID;
                oSqlCommand.Parameters.Add("@result", SqlDbType.Int, 50).Direction = ParameterDirection.Output;
                oSqlCommand.ExecuteNonQuery();
                nResult = Convert.ToInt32(oSqlCommand.Parameters["@result"].Value);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nResult;
        }

        public DataTable GetTerritoryDisUpaWiseAllDoctorListForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
               
                sSQL = "SELECT * FROM DMRDoctorMasterData WHERE UpazillaID IN (SELECT UpazillaID FROM TerrLocationMapping WHERE Territory Like '"
                + sTerritoryID + "%') AND DistrictID IN (SELECT DistrictID FROM TerrLocationMapping WHERE "
                + " Territory like '" + sTerritoryID + "%') AND ID NOT IN (SELECT DoctorID FROM DoctorTerritoryMapping WHERE "
                + " TerritoryID like '" + sTerritoryID + "%' and Status=2)";
                sSQL = SQL.MakeSQL(sSQL);
                 SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public int RouteUpdate(string sTerritoryID, string sNewRouteName, string sOldRouteName, int nStatus, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            int i;

            try
            {
                DateTime sModifiedDate = DateTime.Now;
                sSQL = SQL.MakeSQL("UPDATE Route SET RName = %s, Status =%n, ModifiedDate = %d WHERE TerrID = %s AND RName = %s", sNewRouteName, nStatus, sModifiedDate, sTerritoryID, sOldRouteName);
                SqlDataAdapter InvAdapter = new SqlDataAdapter();
                SqlCommand InvCommand = new SqlCommand();
                InvCommand = new SqlCommand(sSQL, oSqlConnection);
                InvCommand.Transaction = oSqlTransaction;
                InvAdapter.UpdateCommand = InvCommand;
                i = InvCommand.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return i;
        }

        public int CheckRoute(string sTerritoryID, string sRouteName, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            int i;
            int nIsValid;

            try
            {
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("Select max(RID) FROM Route WHERE RName = %s and TerrID = %s AND Status = 1", sRouteName, sTerritoryID);
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nIsValid = 0;
                }
                else
                {
                    nIsValid = 1;
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nIsValid;
        }

        public int RouteAdd(string sTerritoryID, string sRouteName, int nVersion, int nAction, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            string sSQL1 = "";
            int i;
            int nRouteID;

            try
            {
                DateTime sCreateDate = DateTime.Now;
                DateTime sModifiedDate = DateTime.Now;
                sSQL = SQL.MakeSQL("INSERT INTO Route (TerrID,RName,Status,Version,Action,CreateDate,ModifiedDate) values(%s,%s,1,%n,%n,%d,%d)", sTerritoryID, sRouteName, nVersion, nAction, sCreateDate, sModifiedDate);
                SqlDataAdapter InvAdapter = new SqlDataAdapter();
                SqlCommand InvCommand = new SqlCommand();
                InvCommand = new SqlCommand(sSQL, oSqlConnection);
                InvCommand.Transaction = oSqlTransaction;
                InvAdapter.UpdateCommand = InvCommand;
                i = InvCommand.ExecuteNonQuery();


                SqlCommand cmd = new SqlCommand();
                sSQL1 = SQL.MakeSQL("SELECT Max(RID) FROM [dbo].[Route] where [TerrID]=%s and RName = %s", sTerritoryID, sRouteName);
                cmd.CommandText = sSQL1;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nRouteID = 0;
                }
                else
                {
                    nRouteID = Convert.ToInt32(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nRouteID;
        }

        public string UpdateMappingBySF(int nDocID, string sBMDCCode, int nSalutationID, int nSpecialtyID1, int nSpecialtyID2, int nDegreeID1, int nDegreeID2,
          string sInstitute, string sAddress1, string sAddress2,string sAddress3, int nDistrictID, string sDocName, int nUpazillaID, DateTime dBirthDay,
          int nStatus, DateTime dMrgday, string sMobileNo, string sEmail, string sTerritoryID, int nType, int nDocTypeID, int nMapAddress, int nMapSpeciality,
          int nMapDegree, int nProd1, int nProd2, int nProd3, int nProd4, int nProd5, int nProd6, int nProd7, int nProd8, int nProfileID, int nRouteID, int nSessionID, int nCallFre,
          int nSwajanStatus, string sCardAttachement, int nPstStpCng, string sGDDBID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)

        {
            string sResult = "";

            try
            {
                SqlCommand oSqlCommand = new SqlCommand("spUpdateDoctorFrSF", oSqlConnection, oSqlTransaction);
                oSqlCommand.CommandType = CommandType.StoredProcedure;
                oSqlCommand.Parameters.Add("@DocID", SqlDbType.Int, 50).Value = nDocID;
                oSqlCommand.Parameters.Add("@BMDCCode", SqlDbType.VarChar, 50).Value = sBMDCCode;
                oSqlCommand.Parameters.Add("@SalutationID", SqlDbType.Int, 50).Value = nSalutationID;
                oSqlCommand.Parameters.Add("@SpecialtyID1", SqlDbType.Int, 50).Value = nSpecialtyID1;
                oSqlCommand.Parameters.Add("@SpecialtyID2", SqlDbType.Int, 50).Value = nSpecialtyID2;
                oSqlCommand.Parameters.Add("@DegreeID1", SqlDbType.Int, 50).Value = nDegreeID1;
                oSqlCommand.Parameters.Add("@DegreeID2", SqlDbType.Int, 50).Value = nDegreeID2;
                oSqlCommand.Parameters.Add("@Institute", SqlDbType.VarChar, 200).Value = sInstitute;
                oSqlCommand.Parameters.Add("@Address1", SqlDbType.VarChar, 200).Value = sAddress1;
                oSqlCommand.Parameters.Add("@Address2", SqlDbType.VarChar, 200).Value = sAddress2;
                oSqlCommand.Parameters.Add("@Address3", SqlDbType.VarChar, 200).Value = sAddress3;
                oSqlCommand.Parameters.Add("@DistrictID", SqlDbType.Int, 50).Value = nDistrictID;
                oSqlCommand.Parameters.Add("@DocName", SqlDbType.VarChar, 50).Value = sDocName;
                oSqlCommand.Parameters.Add("@UpazillaID", SqlDbType.Int, 50).Value = nUpazillaID;
                oSqlCommand.Parameters.Add("@BirthDay", SqlDbType.DateTime, 50).Value = dBirthDay;
                oSqlCommand.Parameters.Add("@Mrgday ", SqlDbType.DateTime, 50).Value = dMrgday;
                oSqlCommand.Parameters.Add("@Status", SqlDbType.Int, 50).Value = nStatus;
                oSqlCommand.Parameters.Add("@MobileNo", SqlDbType.VarChar, 50).Value = sMobileNo;
                oSqlCommand.Parameters.Add("@Email", SqlDbType.VarChar, 100).Value = sEmail;
                oSqlCommand.Parameters.Add("@TerritoryID", SqlDbType.VarChar, 50).Value = sTerritoryID;
                oSqlCommand.Parameters.Add("@Type", SqlDbType.Int, 50).Value = nType;
                oSqlCommand.Parameters.Add("@DocTypeID", SqlDbType.Int, 50).Value = nDocTypeID;
                oSqlCommand.Parameters.Add("@Prod1", SqlDbType.Int, 50).Value = nProd1;
                oSqlCommand.Parameters.Add("@Prod2", SqlDbType.Int, 50).Value = nProd2;
                oSqlCommand.Parameters.Add("@Prod3", SqlDbType.Int, 50).Value = nProd3;
                oSqlCommand.Parameters.Add("@Prod4", SqlDbType.Int, 50).Value = nProd4;
                oSqlCommand.Parameters.Add("@Prod5", SqlDbType.Int, 50).Value = nProd5;
                oSqlCommand.Parameters.Add("@Prod6", SqlDbType.Int, 50).Value = nProd6;
                oSqlCommand.Parameters.Add("@Prod7", SqlDbType.Int, 50).Value = nProd7;
                oSqlCommand.Parameters.Add("@Prod8", SqlDbType.Int, 50).Value = nProd8;
                oSqlCommand.Parameters.Add("@Profile", SqlDbType.Int, 50).Value = nProfileID;
                oSqlCommand.Parameters.Add("@Route", SqlDbType.Int, 50).Value = nRouteID;
                oSqlCommand.Parameters.Add("@Session", SqlDbType.Int, 50).Value = nSessionID;
                oSqlCommand.Parameters.Add("@CallFre", SqlDbType.Int, 50).Value = nCallFre;
                oSqlCommand.Parameters.Add("@SwajanStatus", SqlDbType.Int, 50).Value = nSwajanStatus;
                oSqlCommand.Parameters.Add("@CardAttachement", SqlDbType.VarChar, 500).Value = sCardAttachement;
                oSqlCommand.Parameters.Add("@MapAddress", SqlDbType.Int, 50).Value = nMapAddress;
                oSqlCommand.Parameters.Add("@MapSpeciality", SqlDbType.Int, 50).Value = nMapSpeciality;
                oSqlCommand.Parameters.Add("@MapDegree", SqlDbType.Int, 50).Value = nMapDegree;
                oSqlCommand.Parameters.Add("@PSCstatusID", SqlDbType.Int, 50).Value = nPstStpCng;
                oSqlCommand.Parameters.Add("@GDDBID", SqlDbType.VarChar, 100).Value = sGDDBID;
                oSqlCommand.Parameters.Add("@result", SqlDbType.Int, 50).Direction = ParameterDirection.Output;
                oSqlCommand.ExecuteNonQuery();
                sResult = oSqlCommand.Parameters["@result"].Value.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return sResult;
        }


        public string AddNewDoctor(string sBMDCCode, string sTerritoryID, string sDocName, int nSwajanStatus, int nDocTypeID,
                    int nSalutationID, int nSpecialtyID1, int nSpecialtyID2, int nDegreeID1, int nDegreeID2, int nProfileID,
                    int nProd1, int nProd2, int nProd3, int nProd4, int nProd5, int nProd6, int nProd7, int nProd8, int nCallFre, string sInstitute, 
                    string sAddress1, string sAddress2, string sAddress3, int nDistrictID, int nUpazillaID,int nRouteID, 
                    int nSessionID, DateTime dBirthDay, DateTime dMrgday, string sMobileNo, string sEmail, string sCardAttachement,
                    int nStatus, int nType, int nMapAddress, int nMapSpeciality, int nMapDegree, int nPstStpCng, string sGDDBID,
                    SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sResult = "";
            SqlParameter[] oParameters = new SqlParameter[40]; 
            DataTable oTable;


            try
            {
                SqlCommand oSqlCommand = new SqlCommand("spAddNewDoctor", oSqlConnection, oSqlTransaction);


                oSqlCommand.CommandType = CommandType.StoredProcedure;

                 oParameters[0] = new SqlParameter("@BMDCCode", sBMDCCode);
                 oParameters[1] = new SqlParameter("@SalutationID", nSalutationID);
                 oParameters[2] = new SqlParameter("@SpecialtyID1", nSpecialtyID1);
                 oParameters[3] = new SqlParameter("@SpecialtyID2", nSpecialtyID2);
                 oParameters[4] = new SqlParameter("@DegreeID1", nDegreeID1);
                 oParameters[5] = new SqlParameter("@DegreeID2", nDegreeID2);
                 oParameters[6] = new SqlParameter("@Institute", sInstitute);
                 oParameters[7] = new SqlParameter("@Address1", sAddress1);
                 oParameters[8] = new SqlParameter("@Address2", sAddress2);
                 oParameters[9] = new SqlParameter("@Address3", sAddress3);
                 oParameters[10] = new SqlParameter("@DistrictID", nDistrictID);
                 oParameters[11] = new SqlParameter("@DocName", sDocName);
                 oParameters[12] = new SqlParameter("@UpazillaID", nUpazillaID);
                 oParameters[13] = new SqlParameter("@BirthDay", dBirthDay);
                 oParameters[14] = new SqlParameter("@Mrgday", dMrgday);
                 oParameters[15] = new SqlParameter("@Status", nStatus);
                 oParameters[16] = new SqlParameter("@MobileNo", sMobileNo);
                 oParameters[17] = new SqlParameter("@Email", sEmail);
                 oParameters[18] = new SqlParameter("@TerritoryID", sTerritoryID);
                 oParameters[19] = new SqlParameter("@Type", nType);
                 oParameters[20] = new SqlParameter("@DocTypeID", nDocTypeID);
                 oParameters[21] = new SqlParameter("@Prod1", nProd1);
                 oParameters[22] = new SqlParameter("@Prod2", nProd2);
                 oParameters[23] = new SqlParameter("@Prod3", nProd3);
                 oParameters[24] = new SqlParameter("@Prod4", nProd4);
                 oParameters[25] = new SqlParameter("@Prod5", nProd5);
                 oParameters[26] = new SqlParameter("@Prod6", nProd6);
                 oParameters[27] = new SqlParameter("@Prod7", nProd7);
                 oParameters[28] = new SqlParameter("@Prod8", nProd8);
                 oParameters[29] = new SqlParameter("@ProfileID", nProfileID);
                 oParameters[30] = new SqlParameter("@RouteID", nRouteID);
                 oParameters[31] = new SqlParameter("@SessionID", nSessionID);
                 oParameters[32] = new SqlParameter("@CallFre", nCallFre);
                 oParameters[33] = new SqlParameter("@SwajanStatus", nSwajanStatus);
                 oParameters[34] = new SqlParameter("@CardAttachement", sCardAttachement);
                 oParameters[35] = new SqlParameter("@MapAddress", nMapAddress);
                 oParameters[36] = new SqlParameter("@MapSpeciality", nMapSpeciality);
                 oParameters[37] = new SqlParameter("@MapDegree", nMapDegree);
                 oParameters[38] = new SqlParameter("@PSCstatusID", nPstStpCng);
                 oParameters[39] = new SqlParameter("@GDDBID", sGDDBID);


                //oSqlCommand.Parameters.Add("@BMDCCode", SqlDbType.VarChar, 50).Value = sBMDCCode;
                //oSqlCommand.Parameters.Add("@SalutationID", SqlDbType.Int, 50).Value = nSalutationID;
                //oSqlCommand.Parameters.Add("@SpecialtyID1", SqlDbType.Int, 50).Value = nSpecialtyID1;
                //oSqlCommand.Parameters.Add("@SpecialtyID2", SqlDbType.Int, 50).Value = nSpecialtyID2;
                //oSqlCommand.Parameters.Add("@DegreeID1", SqlDbType.Int, 50).Value = nDegreeID1;
                //oSqlCommand.Parameters.Add("@DegreeID2", SqlDbType.Int, 50).Value = nDegreeID2;
                //oSqlCommand.Parameters.Add("@Institute", SqlDbType.VarChar, 50).Value = sInstitute;
                //oSqlCommand.Parameters.Add("@Address1", SqlDbType.VarChar, 50).Value = sAddress1;
                //oSqlCommand.Parameters.Add("@Address2", SqlDbType.VarChar, 50).Value = sAddress2;
                //oSqlCommand.Parameters.Add("@Address3", SqlDbType.VarChar, 50).Value = sAddress3;
                //oSqlCommand.Parameters.Add("@DistrictID", SqlDbType.Int, 50).Value = nDistrictID;
                //oSqlCommand.Parameters.Add("@DocName", SqlDbType.VarChar, 50).Value = sDocName;
                //oSqlCommand.Parameters.Add("@UpazillaID", SqlDbType.Int, 50).Value = nUpazillaID;
                //oSqlCommand.Parameters.Add("@BirthDay", SqlDbType.DateTime, 50).Value = dBirthDay;
                //oSqlCommand.Parameters.Add("@Mrgday ", SqlDbType.DateTime, 50).Value = dMrgday;
                //oSqlCommand.Parameters.Add("@Status", SqlDbType.Int, 50).Value = nStatus;
                //oSqlCommand.Parameters.Add("@MobileNo", SqlDbType.VarChar, 50).Value = sMobileNo;
                //oSqlCommand.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = sEmail;
                //oSqlCommand.Parameters.Add("@TerritoryID", SqlDbType.VarChar, 50).Value = sTerritoryID;
                //oSqlCommand.Parameters.Add("@Type", SqlDbType.Int, 50).Value = nType;
                //oSqlCommand.Parameters.Add("@DocTypeID", SqlDbType.Int, 50).Value = nDocTypeID;
                //oSqlCommand.Parameters.Add("@Prod1", SqlDbType.Int, 50).Value = nProd1;
                //oSqlCommand.Parameters.Add("@Prod2", SqlDbType.Int, 50).Value = nProd2;
                //oSqlCommand.Parameters.Add("@Prod3", SqlDbType.Int, 50).Value = nProd3;
                //oSqlCommand.Parameters.Add("@Prod4", SqlDbType.Int, 50).Value = nProd4;
                //oSqlCommand.Parameters.Add("@Prod5", SqlDbType.Int, 50).Value = nProd5;
                //oSqlCommand.Parameters.Add("@Prod6", SqlDbType.Int, 50).Value = nProd6;
                //oSqlCommand.Parameters.Add("@ProfileID", SqlDbType.Int, 50).Value = nProfileID;
                //oSqlCommand.Parameters.Add("@RouteID", SqlDbType.Int, 50).Value = nRouteID;
                //oSqlCommand.Parameters.Add("@SessionID", SqlDbType.Int, 50).Value = nSessionID;
                //oSqlCommand.Parameters.Add("@CallFre", SqlDbType.Int, 50).Value = nCallFre;
                //oSqlCommand.Parameters.Add("@SwajanStatus", SqlDbType.Int, 50).Value = nSwajanStatus;
                //oSqlCommand.Parameters.Add("@CardAttachement", SqlDbType.VarChar, 50).Value = sCardAttachement;
                //oSqlCommand.Parameters.Add("@MapAddress", SqlDbType.Int, 50).Value = nMapAddress;
                //oSqlCommand.Parameters.Add("@MapSpeciality", SqlDbType.Int, 50).Value = nMapSpeciality;
                //oSqlCommand.Parameters.Add("@MapDegree", SqlDbType.Int, 50).Value = nMapDegree;
               // oSqlCommand.Parameters.Add("@result2", SqlDbType.Int, 50).Direction = ParameterDirection.Output;
              //  oSqlCommand.ExecuteNonQuery();
              oTable =  FillDataTable("tABLE", "spAddNewDoctor",oParameters);
              sResult = oTable.Rows[0][0].ToString();

              //sResult = "0";

              if (sResult == "0")
              {
                  sResult = "";
              }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return sResult;
        }

        public string AddExistingDoctor(int nDocID, string sTerritoryID, int nDocTypeID, int nSwajanStatus, int nProfileID,
        int nProd1, int nProd2, int nProd3, int nProd4, int nProd5, int nProd6, int nProd7, int nProd8, int nCallFre, int nRouteID,
        int nStatus, int nType, int nSessionID, int nMapAddress, int nMapSpeciality, int nMapDegree, int nPstStpCng, string sGDDBID,
        SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sResult = "";

            try
            {
                SqlCommand oSqlCommand = new SqlCommand("spAddDoctor", oSqlConnection, oSqlTransaction);
                oSqlCommand.CommandType = CommandType.StoredProcedure;
                oSqlCommand.Parameters.Add("@DoctorID", SqlDbType.Int, 50).Value = nDocID;
                oSqlCommand.Parameters.Add("@Status", SqlDbType.Int, 50).Value = nStatus;
                oSqlCommand.Parameters.Add("@TerritoryID", SqlDbType.VarChar, 50).Value = sTerritoryID;
                oSqlCommand.Parameters.Add("@Type", SqlDbType.Int, 50).Value = nType;
                oSqlCommand.Parameters.Add("@DocTypeID", SqlDbType.Int, 50).Value = nDocTypeID;
                oSqlCommand.Parameters.Add("@Prod1", SqlDbType.Int, 50).Value = nProd1;
                oSqlCommand.Parameters.Add("@Prod2", SqlDbType.Int, 50).Value = nProd2;
                oSqlCommand.Parameters.Add("@Prod3", SqlDbType.Int, 50).Value = nProd3;
                oSqlCommand.Parameters.Add("@Prod4", SqlDbType.Int, 50).Value = nProd4;
                oSqlCommand.Parameters.Add("@Prod5", SqlDbType.Int, 50).Value = nProd5;
                oSqlCommand.Parameters.Add("@Prod6", SqlDbType.Int, 50).Value = nProd6;
                oSqlCommand.Parameters.Add("@Prod7", SqlDbType.Int, 50).Value = nProd7;
                oSqlCommand.Parameters.Add("@Prod8", SqlDbType.Int, 50).Value = nProd8;
                oSqlCommand.Parameters.Add("@ProfileID", SqlDbType.Int, 50).Value = nProfileID;
                oSqlCommand.Parameters.Add("@RouteID", SqlDbType.Int, 50).Value = nRouteID;
                oSqlCommand.Parameters.Add("@SessionID", SqlDbType.Int, 50).Value = nSessionID;
                oSqlCommand.Parameters.Add("@CallFre", SqlDbType.Int, 50).Value = nCallFre;
                oSqlCommand.Parameters.Add("@SwajanStatus", SqlDbType.Int, 50).Value = nSwajanStatus;
                oSqlCommand.Parameters.Add("@MapAddress", SqlDbType.Int, 50).Value = nMapAddress;
                oSqlCommand.Parameters.Add("@MapSpeciality", SqlDbType.Int, 50).Value = nMapSpeciality;
                oSqlCommand.Parameters.Add("@MapDegree", SqlDbType.Int, 50).Value = nMapDegree;
                oSqlCommand.Parameters.Add("@PSCstatusID", SqlDbType.Int, 50).Value = nPstStpCng;
                oSqlCommand.Parameters.Add("@GDDBID", SqlDbType.VarChar, 100).Value = sGDDBID;
                oSqlCommand.Parameters.Add("@result", SqlDbType.Int, 50).Direction = ParameterDirection.Output;
                oSqlCommand.ExecuteNonQuery();
                sResult = oSqlCommand.Parameters["@result"].Value.ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return sResult;
        }
        
        public DataTable GetColumnInfo(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {

            string sSQL = "";
            DataTable oTable = new DataTable();
            try
            {
                sSQL = SQL.MakeSQL("SELECT * FROM TerrWiseConfiguration WHERE TerritoryID =  %s and Status = 1 and Version > %n", sTerritoryID, nMaxVersion);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
                //oTable = FillDataTable(sSQL, "DoctorLogList");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public int GetDMRLock(string sTerritoryID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            int nLock;
            try
            {
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL(@"SELECT IsLocked FROM TerritoryDMRMapping WHERE TerritoryID = %s", sTerritoryID);
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nLock = 0;
                }
                else
                {
                    nLock = Convert.ToInt32(o);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nLock;
        }

        public int GetDocCountFrRoute(string sTerritoryID, string sRouteName, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            int nCount;
            try
            {
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL(@"SELECT Count(g.DoctorID) from DoctorTerritoryMapping g 
                                   INNER JOIN Route j ON g.RouteID=j.RID where g.TerritoryID=j.TerrID and g.TerritoryID = %s 
                                   AND g.Status IN (1,2,5) and j.RName =  %s", sTerritoryID, sRouteName);
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nCount = 0;
                }
                else
                {
                    nCount = Convert.ToInt32(o);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nCount;
        }

        public int GetDocCount(string sTerritoryID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            int nCount;
            try
            {
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL(@"Select COUNT(DoctorID) FROM DoctorTerritoryMapping WHERE DocTypeID = 1 AND Status = 2 AND TerritoryID = %s", sTerritoryID);
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nCount = 0;
                }
                else
                {
                    nCount = Convert.ToInt32(o);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nCount;
        }


        public int GetDocCountPending(string sTerritoryID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            int nCount;
            try
            {
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL(@"Select COUNT(DocID) FROM DoctorLog WHERE Type IN (1,5) AND Status IN (1,5) AND TerritoryID = %s", sTerritoryID);
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nCount = 0;
                }
                else
                {
                    nCount = Convert.ToInt32(o);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nCount;
        }



        public int GetMaxRouteVersion(string sTerritoryID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            int nVersion;
            try
            {
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL(@"SELECT Max(Version)+1 FROm Route WHERE TerrID = %s", sTerritoryID);
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nVersion = 0;
                }
                else
                {
                    nVersion = Convert.ToInt32(o);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nVersion;
        }


        public string GetLine(string sTerritoryID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            string sLine;
            try
            {
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL(@"Select LineID FROM Territory WHERE TerritoryID = %s", sTerritoryID);
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    sLine = "";
                }
                else
                {
                    sLine = Convert.ToString(o);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return sLine;
        }

        public int GetTotalDoctor(string sTerritoryID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            int nCount;

            try
            {
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL(@"SELECT TargetDoctor FROM TerrWiseTargetDoc where Territory= %s", sTerritoryID);
                //RemainingTargrtDoctor = ExecuteScalar(sSQL);
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nCount = 0;
                }
                else
                {
                    nCount = Convert.ToInt32(o);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nCount;
        }

        public int GetRMPending(string sTerritoryID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            int nLock;
            try
            {
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL(@"Select COUNT(DocID) FROM DoctorLog WHERE Status = 1 AND TerritoryID = %s", sTerritoryID);
                //oLock = ExecuteScalar(sSQL);
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nLock = 0;
                }
                else
                {
                    nLock = Convert.ToInt32(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nLock;
        }

        public int GetSFEPending(string sTerritoryID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            int nLock;
            try
            {
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL(@"Select COUNT(DocID) FROM DoctorLog WHERE Status = 5 AND TerritoryID = %s", sTerritoryID);
                //oLock = ExecuteScalar(sSQL);

                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nLock = 0;
                }
                else
                {
                    nLock = Convert.ToInt32(o);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nLock;
        }

        public DataTable GetDocTerrMappingInfo(int nDoctorID, string sTerritoryID, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                sSQL = SQL.MakeSQL("SELECT * FROM [DoctorTerritoryMapping] WHERE DoctorID=%n and TerritoryID=%s", nDoctorID, sTerritoryID);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public int GetMaxDoctorVersion(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nMaxDoctorVersion;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SELECT MAX(Version)+ 1 Version FROM [DoctorTerritoryMapping]");
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nMaxDoctorVersion = 1;
                }
                else
                {
                    nMaxDoctorVersion = Convert.ToInt32(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nMaxDoctorVersion;
        }

        public int UpdateDoctorInfo(int nDocID, string sBMDCCode, string sDocName,int nSalutationID, int nSpecialtyID1,
            int nSpecialtyID2, int nDegreeID1, int nDegreeID2, string sInstitute, string sAddress1, string sAddress2,
            string sAddress3, int nDistrictID, int nUpazillaID, DateTime dBirthDay, DateTime dMrgday,
            string sMobileNo, string sEmail, string sCardAttachement, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nResult = 0;

            try
            {
                SqlCommand oSqlCommand = new SqlCommand("spUpdateDoctorInfo", oSqlConnection, oSqlTransaction);
                oSqlCommand.CommandType = CommandType.StoredProcedure;
                oSqlCommand.Parameters.Add("@DocID", SqlDbType.Int, 50).Value = nDocID;
                oSqlCommand.Parameters.Add("@BMDCCode", SqlDbType.VarChar, 50).Value = sBMDCCode;
                oSqlCommand.Parameters.Add("@DocName", SqlDbType.VarChar, 150).Value = sDocName;
                oSqlCommand.Parameters.Add("@SalutationID", SqlDbType.Int, 50).Value = nSalutationID;
                oSqlCommand.Parameters.Add("@SpecialtyID1", SqlDbType.Int, 50).Value = nSpecialtyID1;
                oSqlCommand.Parameters.Add("@SpecialtyID2", SqlDbType.Int, 50).Value = nSpecialtyID2;
                oSqlCommand.Parameters.Add("@DegreeID1", SqlDbType.Int, 50).Value = nDegreeID1;
                oSqlCommand.Parameters.Add("@DegreeID2", SqlDbType.Int, 50).Value = nDegreeID2;
                oSqlCommand.Parameters.Add("@Institute", SqlDbType.VarChar, 100).Value = sInstitute;
                oSqlCommand.Parameters.Add("@Address1", SqlDbType.VarChar, 500).Value = sAddress1;
                oSqlCommand.Parameters.Add("@Address2", SqlDbType.VarChar, 500).Value = sAddress2;
                oSqlCommand.Parameters.Add("@Address3", SqlDbType.VarChar, 500).Value = sAddress3;
                oSqlCommand.Parameters.Add("@DistrictID", SqlDbType.Int, 50).Value = nDistrictID;
                oSqlCommand.Parameters.Add("@UpazillaID", SqlDbType.Int, 50).Value = nUpazillaID;
                oSqlCommand.Parameters.Add("@BirthDay", SqlDbType.DateTime, 50).Value = dBirthDay;
                oSqlCommand.Parameters.Add("@Mrgday", SqlDbType.DateTime, 50).Value = dMrgday;
                oSqlCommand.Parameters.Add("@MobileNo", SqlDbType.VarChar, 50).Value = sMobileNo;
                oSqlCommand.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = sEmail;
                oSqlCommand.Parameters.Add("@CardAttachement", SqlDbType.VarChar, 500).Value = sCardAttachement;
                oSqlCommand.Parameters.Add("@result", SqlDbType.Int, 50).Direction = ParameterDirection.Output;
                oSqlCommand.ExecuteNonQuery();
                nResult = Convert.ToInt32(oSqlCommand.Parameters["@result"].Value);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nResult;
        }

        public int InsertDocInfoUpdateLogForRM(int nDocID, int nDoctorTerritoryMappingID, string sBMDCCode, string sDocName, int nSalutationID,
            int nSpecialtyID1, int nSpecialtyID2, int nDegreeID1, int nDegreeID2, string sInstitute, string sAddress1, string sAddress2, 
            string sAddress3, int nDistrictID, int nUpazillaID, DateTime dBirthDay, DateTime dMrgday, string sMobileNo, string sEmail, string sCardAttachement,
            SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nResult = 0;

            try
            {
                SqlCommand oSqlCommand = new SqlCommand("spInsertDocInfoUpdateLogForRM", oSqlConnection, oSqlTransaction);
                oSqlCommand.CommandType = CommandType.StoredProcedure;
                oSqlCommand.Parameters.Add("@DocID", SqlDbType.Int, 50).Value = nDocID;
                oSqlCommand.Parameters.Add("@DoctorTerritoryMappingID", SqlDbType.Int, 50).Value = nDoctorTerritoryMappingID;
                oSqlCommand.Parameters.Add("@BMDCCode", SqlDbType.VarChar, 50).Value = sBMDCCode;
                oSqlCommand.Parameters.Add("@DocName", SqlDbType.VarChar, 150).Value = sDocName;
                oSqlCommand.Parameters.Add("@SalutationID", SqlDbType.Int, 50).Value = nSalutationID;
                oSqlCommand.Parameters.Add("@SpecialtyID1", SqlDbType.Int, 50).Value = nSpecialtyID1;
                oSqlCommand.Parameters.Add("@SpecialtyID2", SqlDbType.Int, 50).Value = nSpecialtyID2;
                oSqlCommand.Parameters.Add("@DegreeID1", SqlDbType.Int, 50).Value = nDegreeID1;
                oSqlCommand.Parameters.Add("@DegreeID2", SqlDbType.Int, 50).Value = nDegreeID2;
                oSqlCommand.Parameters.Add("@Institute", SqlDbType.VarChar, 100).Value = sInstitute;
                oSqlCommand.Parameters.Add("@Address1", SqlDbType.VarChar, 500).Value = sAddress1;
                oSqlCommand.Parameters.Add("@Address2", SqlDbType.VarChar, 500).Value = sAddress2;
                oSqlCommand.Parameters.Add("@Address3", SqlDbType.VarChar, 500).Value = sAddress3;
                oSqlCommand.Parameters.Add("@DistrictID", SqlDbType.Int, 50).Value = nDistrictID;
                oSqlCommand.Parameters.Add("@UpazillaID", SqlDbType.Int, 50).Value = nUpazillaID;
                oSqlCommand.Parameters.Add("@BirthDay", SqlDbType.DateTime, 50).Value = dBirthDay;
                oSqlCommand.Parameters.Add("@Mrgday", SqlDbType.DateTime, 50).Value = dMrgday;
                oSqlCommand.Parameters.Add("@MobileNo", SqlDbType.VarChar, 50).Value = sMobileNo;
                oSqlCommand.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = sEmail;
                oSqlCommand.Parameters.Add("@CardAttachement", SqlDbType.VarChar, 500).Value = sCardAttachement;
                oSqlCommand.Parameters.Add("@result", SqlDbType.Int, 50).Direction = ParameterDirection.Output;
                oSqlCommand.ExecuteNonQuery();
                nResult = Convert.ToInt32(oSqlCommand.Parameters["@result"].Value);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nResult;
        }

        public int InsertParameterLog(string sTerritoryID, string sParameters, string sError, SqlConnection oSqlConnection)
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL("INSERT INTO [DMRExpectionLog](TerritoryID, Parameter, Exception, CreatedDateTime) "
                 + " VALUES(%s, %s, %s, %D) "
                 , sTerritoryID, sParameters, sError, DateTime.Now);
                SqlDataAdapter InvAdapter = new SqlDataAdapter();
                SqlCommand InvCommand = new SqlCommand();
                InvCommand = new SqlCommand(sSQL, oSqlConnection);
                //InvCommand.Transaction = oSqlTransaction;
                InvAdapter.InsertCommand = InvCommand;
                int i = InvCommand.ExecuteNonQuery();
                return i;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int InsertDMRCommandInfo(string sTerritoryID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nResult = 0;

            try
            {
                SqlCommand oSqlCommand = new SqlCommand("spInsertDMRCommmandInfo2", oSqlConnection, oSqlTransaction);
                oSqlCommand.CommandType = CommandType.StoredProcedure;
                oSqlCommand.Parameters.Add("@TerritoryID", SqlDbType.VarChar, 50).Value = sTerritoryID;
                oSqlCommand.Parameters.Add("@result", SqlDbType.Int, 50).Direction = ParameterDirection.Output;
                oSqlCommand.ExecuteNonQuery();
                nResult = Convert.ToInt32(oSqlCommand.Parameters["@result"].Value);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nResult;
        }


        //public bool IsDuplicate(string sDoctorTerritoryMappingName)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [DoctorTerritoryMapping] WHERE DoctorTerritoryMappingName=%s ", sDoctorTerritoryMappingName);
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
		//public bool IsDuplicate(string sDoctorTerritoryMappingName, int nID)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [DoctorTerritoryMapping] WHERE DoctorTerritoryMappingName=%s AND TerrWiseDocID!= %n ", sDoctorTerritoryMappingName, nID);
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
		//public IDataReader GetDoctorTerritoryMapping(string sDoctorTerritoryMappingName)
		//{
			//string sSQL = "";
			//IDataReader oReader;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT * FROM [DoctorTerritoryMapping] WHERE [DoctorTerritoryMappingName]=%s ", sDoctorTerritoryMappingName);
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
