using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
	public partial class DLDoctorUpdateRequest: DAAccess
	{
		public void Insert(DoctorUpdateRequest oItem)
		{
			string sSQL = "";
			try
			{
				oItem.ID.SetID(GeneratePrimaryKey("[DoctorUpdateRequest]", "DoctorUpdateRequestID"));
                sSQL = SQL.MakeSQL("INSERT INTO [DoctorUpdateRequest](DoctorUpdateRequestID, DoctorID, TerritoryID, DoctorTypeID, Code, SwajanStatus, BMDCCode, DocName, SalutationID, SpecialtyID1, SpecialtyID2, DegreeID1, DegreeID2, Institute, Address1, Address2, Address3, DistrictID, UpazillaID, BirthDay, Mrgday, UpdateStatus, MobileNo, Email, MapAddress, MapSpeciality, MapDegree, Product1, Product2, Product3, Product4, Product5, Product6, Product7, Product8, Profile, Session, Route, CallFrequency, PostStepChange,CardAttachement, Action, Version) "
                + " VALUES(%n, %n, %s, %n, %s, %n, %s, %s, %n, %n, %n, %n, %n, %s, %s, %s, %s, %n, %n, %d, %d, %n, %s, %s, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %s, %n, %n) "
                , oItem.ID.ToInt32, oItem.DoctorID, oItem.TerritoryID, oItem.DoctorTypeID, oItem.Code, oItem.SwajanStatus, oItem.BMDCCode, oItem.DocName, oItem.SalutationID, oItem.SpecialtyID1, oItem.SpecialtyID2, oItem.DegreeID1, oItem.DegreeID2, oItem.Institute, oItem.Address1, oItem.Address2, oItem.Address3, oItem.DistrictID, oItem.UpazillaID, oItem.BirthDay, oItem.Mrgday, oItem.UpdateStatus, oItem.MobileNo, oItem.Email, oItem.MapAddress, oItem.MapSpeciality, oItem.MapDegree, oItem.Product1, oItem.Product2, oItem.Product3, oItem.Product4, oItem.Product5, oItem.Product6, oItem.Product7, oItem.Product8, oItem.Profile, oItem.Session, oItem.Route, oItem.CallFrequency, oItem.CardAttachement, oItem.PostStepChange, oItem.Action, oItem.Version);
                ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(DoctorUpdateRequest oItem)
		{
			string sSQL = "";
			try
			{
                sSQL = SQL.MakeSQL("UPDATE [DoctorUpdateRequest] SET DoctorID = %n, TerritoryID = %s, DoctorTypeID = %n, Code = %s, SwajanStatus = %n, BMDCCode = %s, DocName = %s, SalutationID = %n, SpecialtyID1 = %n, SpecialtyID2 = %n, DegreeID1 = %n, DegreeID2 = %n, Institute = %s, Address1 = %s, Address2 = %s, Address3 = %s, DistrictID = %n, UpazillaID = %n, BirthDay = %d, Mrgday = %d, UpdateStatus = %n, MobileNo = %s, Email = %s, MapAddress = %n, MapSpeciality = %n, MapDegree = %n, Product1 = %n, Product2 = %n, Product3 = %n, Product4 = %n, Product5 = %n, Product6 = %n,  Product7 = %n,  Product8 = %n, Profile = %n, Session = %n, Route = %n, CallFrequency = %n, PostStepChange = %n, CardAttachement = %s, Action = %n, Version = %n WHERE [DoctorUpdateRequestID]=%n"
                , oItem.DoctorID, oItem.TerritoryID, oItem.DoctorTypeID, oItem.Code, oItem.SwajanStatus, oItem.BMDCCode, oItem.DocName, oItem.SalutationID, oItem.SpecialtyID1, oItem.SpecialtyID2, oItem.DegreeID1, oItem.DegreeID2, oItem.Institute, oItem.Address1, oItem.Address2, oItem.Address3, oItem.DistrictID, oItem.UpazillaID, oItem.BirthDay, oItem.Mrgday, oItem.UpdateStatus, oItem.MobileNo, oItem.Email, oItem.MapAddress, oItem.MapSpeciality, oItem.MapDegree, oItem.Product1, oItem.Product2, oItem.Product3, oItem.Product4, oItem.Product5, oItem.Product6, oItem.Product7, oItem.Product8, oItem.Profile, oItem.Session, oItem.Route, oItem.CallFrequency, oItem.PostStepChange, oItem.CardAttachement, oItem.Action, oItem.Version, oItem.ID.ToInt32);
                ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nDoctorUpdateRequestID)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("DELETE FROM [DoctorUpdateRequest] WHERE [DoctorUpdateRequestID]=%n"
				, nDoctorUpdateRequestID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetDoctorUpdateRequest(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [DoctorUpdateRequest] WHERE DoctorUpdateRequestID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetDoctorUpdateRequests()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [DoctorUpdateRequest] ");
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}

        public int GetDoctorUpdateRequestID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nID = 0;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SElECT MAX(DoctorUpdateRequestID)+ 1 PvpID FROM DoctorUpdateRequest");
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

        public int Insert(DoctorUpdateRequest oItem, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                int nDoctorUpdateRequestID = GetDoctorUpdateRequestID(oSqlConnection, oSqlTransaction);
                //oItem.ID.SetID(nDoctorUpdateRequestID);
                sSQL = SQL.MakeSQL("INSERT INTO [DoctorUpdateRequest](DoctorUpdateRequestID, DoctorID, TerritoryID, DoctorTypeID, Code, SwajanStatus, BMDCCode, DocName, SalutationID, SpecialtyID1, SpecialtyID2, DegreeID1, DegreeID2, Institute, Address1, Address2, Address3, DistrictID, UpazillaID, BirthDay, Mrgday, UpdateStatus, MobileNo, Email, MapAddress, MapSpeciality, MapDegree, Product1, Product2, Product3, Product4, Product5, Product6, Product7, Product8, Profile, Session, Route, CallFrequency, PostStepChange,CardAttachement, Action, Version) "
                + " VALUES(%n, %n, %s, %n, %s, %n, %s, %s, %n, %n, %n, %n, %n, %s, %s, %s, %s, %n, %n, %d, %d, %n, %s, %s, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n,  %n, %n, %n, %n, %n, %n, %s, %n, %n) "
                , oItem.ID.ToInt32, oItem.DoctorID, oItem.TerritoryID, oItem.DoctorTypeID, oItem.Code, oItem.SwajanStatus, oItem.BMDCCode, oItem.DocName, oItem.SalutationID, oItem.SpecialtyID1, oItem.SpecialtyID2, oItem.DegreeID1, oItem.DegreeID2, oItem.Institute, oItem.Address1, oItem.Address2, oItem.Address3, oItem.DistrictID, oItem.UpazillaID, oItem.BirthDay, oItem.Mrgday, oItem.UpdateStatus, oItem.MobileNo, oItem.Email, oItem.MapAddress, oItem.MapSpeciality, oItem.MapDegree, oItem.Product1, oItem.Product2, oItem.Product3, oItem.Product4, oItem.Product5, oItem.Product6, oItem.Product7, oItem.Product8, oItem.Profile, oItem.Session, oItem.Route, oItem.CallFrequency, oItem.CardAttachement, oItem.PostStepChange, oItem.Action, oItem.Version);
                SqlDataAdapter InvAdapter = new SqlDataAdapter();
                SqlCommand InvCommand = new SqlCommand();
                InvCommand = new SqlCommand(sSQL, oSqlConnection);
                InvCommand.Transaction = oSqlTransaction;
                InvAdapter.InsertCommand = InvCommand;
                int i = InvCommand.ExecuteNonQuery();
                return i;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int Update(DoctorUpdateRequest oItem, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL("UPDATE [DoctorUpdateRequest] SET DoctorID = %n, TerritoryID = %s, DoctorTypeID = %n, Code = %s, SwajanStatus = %n, BMDCCode = %s, DocName = %s, SalutationID = %n, SpecialtyID1 = %n, SpecialtyID2 = %n, DegreeID1 = %n, DegreeID2 = %n, Institute = %s, Address1 = %s, Address2 = %s, Address3 = %s, DistrictID = %n, UpazillaID = %n, BirthDay = %d, Mrgday = %d, UpdateStatus = %n, MobileNo = %s, Email = %s, MapAddress = %n, MapSpeciality = %n, MapDegree = %n, Product1 = %n, Product2 = %n, Product3 = %n, Product4 = %n, Product5 = %n, Product6 = %n, Product7 = %n, Product8 = %n, Profile = %n, Session = %n, Route = %n, CallFrequency = %n, PostStepChange = %n, CardAttachement = %s, Action = %n, Version = %n WHERE [DoctorUpdateRequestID]=%n"
                , oItem.DoctorID, oItem.TerritoryID, oItem.DoctorTypeID, oItem.Code, oItem.SwajanStatus, oItem.BMDCCode, oItem.DocName, oItem.SalutationID, oItem.SpecialtyID1, oItem.SpecialtyID2, oItem.DegreeID1, oItem.DegreeID2, oItem.Institute, oItem.Address1, oItem.Address2, oItem.Address3, oItem.DistrictID, oItem.UpazillaID, oItem.BirthDay, oItem.Mrgday, oItem.UpdateStatus, oItem.MobileNo, oItem.Email, oItem.MapAddress, oItem.MapSpeciality, oItem.MapDegree, oItem.Product1, oItem.Product2, oItem.Product3, oItem.Product4, oItem.Product5, oItem.Product6, oItem.Product7, oItem.Product8, oItem.Profile, oItem.Session, oItem.Route, oItem.CallFrequency, oItem.PostStepChange, oItem.CardAttachement, oItem.Action, oItem.Version, oItem.ID.ToInt32);
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
