using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;

namespace FAST.BusinessLogic
{
	public partial class BLDoctorUpdateRequest
	{
		private DoctorUpdateRequest ReaderToObject(IDataReader oReader)
		{
            DoctorUpdateRequest oItem = new DoctorUpdateRequest();
            oItem.ID.SetID(oReader["DoctorUpdateRequestID"]);
            if (!oReader["DoctorID"].Equals(DBNull.Value))
            {
                oItem.DoctorID = Convert.ToInt32(oReader["DoctorID"]);
            }
            if (!oReader["TerritoryID"].Equals(DBNull.Value))
            {
                oItem.TerritoryID = oReader["TerritoryID"].ToString();
            }
            if (!oReader["DoctorTypeID"].Equals(DBNull.Value))
            {
                oItem.DoctorTypeID = Convert.ToInt32(oReader["DoctorTypeID"]);
            }
            if (!oReader["Code"].Equals(DBNull.Value))
            {
                oItem.Code = oReader["Code"].ToString();
            }
            if (!oReader["SwajanStatus"].Equals(DBNull.Value))
            {
                oItem.SwajanStatus = Convert.ToInt32(oReader["SwajanStatus"]);
            }
            if (!oReader["BMDCCode"].Equals(DBNull.Value))
            {
                oItem.BMDCCode = oReader["BMDCCode"].ToString();
            }
            oItem.DocName = oReader["DocName"].ToString();
            if (!oReader["SalutationID"].Equals(DBNull.Value))
            {
                oItem.SalutationID = Convert.ToInt32(oReader["SalutationID"]);
            }
            if (!oReader["SpecialtyID1"].Equals(DBNull.Value))
            {
                oItem.SpecialtyID1 = Convert.ToInt32(oReader["SpecialtyID1"]);
            }
            if (!oReader["SpecialtyID2"].Equals(DBNull.Value))
            {
                oItem.SpecialtyID2 = Convert.ToInt32(oReader["SpecialtyID2"]);
            }
            if (!oReader["DegreeID1"].Equals(DBNull.Value))
            {
                oItem.DegreeID1 = Convert.ToInt32(oReader["DegreeID1"]);
            }
            if (!oReader["DegreeID2"].Equals(DBNull.Value))
            {
                oItem.DegreeID2 = Convert.ToInt32(oReader["DegreeID2"]);
            }
            if (!oReader["Institute"].Equals(DBNull.Value))
            {
                oItem.Institute = oReader["Institute"].ToString();
            }
            if (!oReader["Address1"].Equals(DBNull.Value))
            {
                oItem.Address1 = oReader["Address1"].ToString();
            }
            if (!oReader["Address2"].Equals(DBNull.Value))
            {
                oItem.Address2 = oReader["Address2"].ToString();
            }
            if (!oReader["Address3"].Equals(DBNull.Value))
            {
                oItem.Address3 = oReader["Address3"].ToString();
            }
            if (!oReader["DistrictID"].Equals(DBNull.Value))
            {
                oItem.DistrictID = Convert.ToInt32(oReader["DistrictID"]);
            }
            if (!oReader["UpazillaID"].Equals(DBNull.Value))
            {
                oItem.UpazillaID = Convert.ToInt32(oReader["UpazillaID"]);
            }
            if (!oReader["BirthDay"].Equals(DBNull.Value))
            {
                oItem.BirthDay = Convert.ToDateTime(oReader["BirthDay"]);
            }
            if (!oReader["Mrgday"].Equals(DBNull.Value))
            {
                oItem.Mrgday = Convert.ToDateTime(oReader["Mrgday"]);
            }
            if (!oReader["UpdateStatus"].Equals(DBNull.Value))
            {
                oItem.UpdateStatus = Convert.ToInt32(oReader["UpdateStatus"]);
            }
            oItem.MobileNo = oReader["MobileNo"].ToString();
            if (!oReader["Email"].Equals(DBNull.Value))
            {
                oItem.Email = oReader["Email"].ToString();
            }
            if (!oReader["MapAddress"].Equals(DBNull.Value))
            {
                oItem.MapAddress = Convert.ToInt32(oReader["MapAddress"]);
            }
            if (!oReader["MapSpeciality"].Equals(DBNull.Value))
            {
                oItem.MapSpeciality = Convert.ToInt32(oReader["MapSpeciality"]);
            }
            if (!oReader["MapDegree"].Equals(DBNull.Value))
            {
                oItem.MapDegree = Convert.ToInt32(oReader["MapDegree"]);
            }
            if (!oReader["Product1"].Equals(DBNull.Value))
            {
                oItem.Product1 = Convert.ToInt32(oReader["Product1"].ToString());
            }
            if (!oReader["Product2"].Equals(DBNull.Value))
            {
                oItem.Product2 = Convert.ToInt32(oReader["Product2"].ToString());
            }
            if (!oReader["Product3"].Equals(DBNull.Value))
            {
                oItem.Product3 = Convert.ToInt32(oReader["Product3"].ToString());
            }
            if (!oReader["Product4"].Equals(DBNull.Value))
            {
                oItem.Product4 = Convert.ToInt32(oReader["Product4"].ToString());
            }
            if (!oReader["Product5"].Equals(DBNull.Value))
            {
                oItem.Product5 = Convert.ToInt32(oReader["Product5"].ToString());
            }
            if (!oReader["Product6"].Equals(DBNull.Value))
            {
                oItem.Product6 = Convert.ToInt32(oReader["Product6"].ToString());
            }
            if (!oReader["Product7"].Equals(DBNull.Value))
            {
                oItem.Product7 = Convert.ToInt32(oReader["Product7"].ToString());
            }
            if (!oReader["Product8"].Equals(DBNull.Value))
            {
                oItem.Product8 = Convert.ToInt32(oReader["Product8"].ToString());
            }
            if (!oReader["Profile"].Equals(DBNull.Value))
            {
                oItem.Profile = Convert.ToInt32(oReader["Profile"].ToString());
            }
            if (!oReader["Session"].Equals(DBNull.Value))
            {
                oItem.Session = Convert.ToInt32(oReader["Session"].ToString());
            }
            if (!oReader["Route"].Equals(DBNull.Value))
            {
                oItem.Route = Convert.ToInt32(oReader["Route"].ToString());
            }
            if (!oReader["CallFrequency"].Equals(DBNull.Value))
            {
                oItem.CallFrequency = Convert.ToInt32(oReader["CallFrequency"]);
            }

            if (!oReader["PostStepChange"].Equals(DBNull.Value))
            {
                oItem.PostStepChange = Convert.ToInt32(oReader["PostStepChange"]);
            }

            oItem.CardAttachement = oReader["CardAttachement"].ToString();
            if (!oReader["Action"].Equals(DBNull.Value))
            {
                oItem.Action = Convert.ToInt32(oReader["Action"]);
            }
            if (!oReader["Version"].Equals(DBNull.Value))
            {
                oItem.Version = Convert.ToInt32(oReader["Version"]);
            }
			return oItem;
		}
		private DoctorUpdateRequests ReaderToObjects(IDataReader oReader)
		{
			DoctorUpdateRequests oItems;
			DoctorUpdateRequest oItem;
			oItems = new DoctorUpdateRequests();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
			return oItems;
		}
		public DoctorUpdateRequests GetDoctorUpdateRequests()
		{
			DoctorUpdateRequests oDoctorUpdateRequests;
			DLDoctorUpdateRequest oDL = new DLDoctorUpdateRequest();
			try
			{
				oDoctorUpdateRequests = ReaderToObjects(oDL.GetDoctorUpdateRequests());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oDoctorUpdateRequests;
		}
		public DoctorUpdateRequest GetDoctorUpdateRequest(int nID)
		{
			DoctorUpdateRequest oDoctorUpdateRequest = new DoctorUpdateRequest();
			DLDoctorUpdateRequest oDL = new DLDoctorUpdateRequest();
			IDataReader oReader;
			try
			{
				oReader = oDL.GetDoctorUpdateRequest(nID);
				if (oReader.Read())
				{
					oDoctorUpdateRequest = ReaderToObject(oReader);
				}
				oReader.Close();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oDoctorUpdateRequest;
		}

        public DoctorUpdateRequest GetDoctorUpdateRequestInfo(DataRow oRow)
        {
            DataTable oTable = new DataTable();
            DoctorUpdateRequest oItem = new DoctorUpdateRequest();
            try
            {
                oItem.ID.SetID(oRow["DoctorUpdateRequestID"]);
                oItem.DoctorUpdateRequestID = Convert.ToInt32(oRow["DoctorUpdateRequestID"]);
                if (!oRow["DoctorID"].Equals(DBNull.Value))
                {
                    oItem.DoctorID = Convert.ToInt32(oRow["DoctorID"]);
                }
                if (!oRow["TerritoryID"].Equals(DBNull.Value))
                {
                    oItem.TerritoryID = oRow["TerritoryID"].ToString();
                }
                if (!oRow["DoctorTypeID"].Equals(DBNull.Value))
                {
                    oItem.DoctorTypeID = Convert.ToInt32(oRow["DoctorTypeID"]);
                }
                if (!oRow["Code"].Equals(DBNull.Value))
                {
                    oItem.Code = oRow["Code"].ToString();
                }
                if (!oRow["SwajanStatus"].Equals(DBNull.Value))
                {
                    oItem.SwajanStatus = Convert.ToInt32(oRow["SwajanStatus"]);
                }
                if (!oRow["BMDCCode"].Equals(DBNull.Value))
                {
                    oItem.BMDCCode = oRow["BMDCCode"].ToString();
                }
                oItem.DocName = oRow["DocName"].ToString();
                if (!oRow["SalutationID"].Equals(DBNull.Value))
                {
                    oItem.SalutationID = Convert.ToInt32(oRow["SalutationID"]);
                }
                if (!oRow["SpecialtyID1"].Equals(DBNull.Value))
                {
                    oItem.SpecialtyID1 = Convert.ToInt32(oRow["SpecialtyID1"]);
                }
                if (!oRow["SpecialtyID2"].Equals(DBNull.Value))
                {
                    oItem.SpecialtyID2 = Convert.ToInt32(oRow["SpecialtyID2"]);
                }
                if (!oRow["DegreeID1"].Equals(DBNull.Value))
                {
                    oItem.DegreeID1 = Convert.ToInt32(oRow["DegreeID1"]);
                }
                if (!oRow["DegreeID2"].Equals(DBNull.Value))
                {
                    oItem.DegreeID2 = Convert.ToInt32(oRow["DegreeID2"]);
                }
                if (!oRow["Institute"].Equals(DBNull.Value))
                {
                    oItem.Institute = oRow["Institute"].ToString();
                }
                if (!oRow["Address1"].Equals(DBNull.Value))
                {
                    oItem.Address1 = oRow["Address1"].ToString();
                }
                if (!oRow["Address2"].Equals(DBNull.Value))
                {
                    oItem.Address2 = oRow["Address2"].ToString();
                }
                if (!oRow["Address3"].Equals(DBNull.Value))
                {
                    oItem.Address3 = oRow["Address3"].ToString();
                }
                if (!oRow["DistrictID"].Equals(DBNull.Value))
                {
                    oItem.DistrictID = Convert.ToInt32(oRow["DistrictID"]);
                }
                if (!oRow["UpazillaID"].Equals(DBNull.Value))
                {
                    oItem.UpazillaID = Convert.ToInt32(oRow["UpazillaID"]);
                }
                if (!oRow["BirthDay"].Equals(DBNull.Value))
                {
                    oItem.BirthDay = Convert.ToDateTime(oRow["BirthDay"]);
                }
                if (!oRow["Mrgday"].Equals(DBNull.Value))
                {
                    oItem.Mrgday = Convert.ToDateTime(oRow["Mrgday"]);
                }
                if (!oRow["UpdateStatus"].Equals(DBNull.Value))
                {
                    oItem.UpdateStatus = Convert.ToInt32(oRow["UpdateStatus"]);
                }
                oItem.MobileNo = oRow["MobileNo"].ToString();
                if (!oRow["Email"].Equals(DBNull.Value))
                {
                    oItem.Email = oRow["Email"].ToString();
                }
                if (!oRow["MapAddress"].Equals(DBNull.Value))
                {
                    oItem.MapAddress = Convert.ToInt32(oRow["MapAddress"]);
                }
                if (!oRow["MapSpeciality"].Equals(DBNull.Value))
                {
                    oItem.MapSpeciality = Convert.ToInt32(oRow["MapSpeciality"]);
                }
                if (!oRow["MapDegree"].Equals(DBNull.Value))
                {
                    oItem.MapDegree = Convert.ToInt32(oRow["MapDegree"]);
                }
                if (!oRow["Product1"].Equals(DBNull.Value))
                {
                    oItem.Product1 = Convert.ToInt32(oRow["Product1"].ToString());
                }
                if (!oRow["Product2"].Equals(DBNull.Value))
                {
                    oItem.Product2 = Convert.ToInt32(oRow["Product2"].ToString());
                }
                if (!oRow["Product3"].Equals(DBNull.Value))
                {
                    oItem.Product3 = Convert.ToInt32(oRow["Product3"].ToString());
                }
                if (!oRow["Product4"].Equals(DBNull.Value))
                {
                    oItem.Product4 = Convert.ToInt32(oRow["Product4"].ToString());
                }
                if (!oRow["Product5"].Equals(DBNull.Value))
                {
                    oItem.Product5 = Convert.ToInt32(oRow["Product5"].ToString());
                }
                if (!oRow["Product6"].Equals(DBNull.Value))
                {
                    oItem.Product6 = Convert.ToInt32(oRow["Product6"].ToString());
                }
                if (!oRow["Product7"].Equals(DBNull.Value))
                {
                    oItem.Product7 = Convert.ToInt32(oRow["Product7"].ToString());
                }
                if (!oRow["Product8"].Equals(DBNull.Value))
                {
                    oItem.Product8 = Convert.ToInt32(oRow["Product8"].ToString());
                }
                if (!oRow["Profile"].Equals(DBNull.Value))
                {
                    oItem.Profile = Convert.ToInt32(oRow["Profile"].ToString());
                }
                if (!oRow["Session"].Equals(DBNull.Value))
                {
                    oItem.Session = Convert.ToInt32(oRow["Session"].ToString());
                }
                if (!oRow["Route"].Equals(DBNull.Value))
                {
                    oItem.Route = Convert.ToInt32(oRow["Route"].ToString());
                }
                if (!oRow["CallFrequency"].Equals(DBNull.Value))
                {
                    oItem.CallFrequency = Convert.ToInt32(oRow["CallFrequency"]);
                }

                if (!oRow["PostStepChange"].Equals(DBNull.Value))
                {
                    oItem.CallFrequency = Convert.ToInt32(oRow["PostStepChange"]);
                }
                oItem.CardAttachement = oRow["CardAttachement"].ToString();
                if (!oRow["Action"].Equals(DBNull.Value))
                {
                    oItem.Action = Convert.ToInt32(oRow["Action"]);
                }
                if (!oRow["Version"].Equals(DBNull.Value))
                {
                    oItem.Version = Convert.ToInt32(oRow["Version"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public DoctorUpdateRequests GetDoctorUpdateRequestInfosForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            DoctorUpdateRequest oItem = new DoctorUpdateRequest();
            DoctorUpdateRequests oItems = new DoctorUpdateRequests();
            try
            {
                oTable = GetDoctorUpdateRequestInfoForRM(sTerritoryID, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new DoctorUpdateRequest();
                        oItem = GetDoctorUpdateRequestInfo(oRow);
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

        public DoctorUpdateRequest GetDoctorUpdateReqInfo(int nDoctorUpdateReqID, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            DoctorUpdateRequest oItem = new DoctorUpdateRequest();
            try
            {
                oTable = GetDoctorUpdateRequestInfo(nDoctorUpdateReqID, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem = GetDoctorUpdateRequestInfo(oRow);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }
	}
}
