using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;

namespace FAST.BusinessLogic
{
	public partial class BLDoctorUpdateRequestLogForRM
	{
		private DoctorUpdateRequestLogForRM ReaderToObject(IDataReader oReader)
		{
			DoctorUpdateRequestLogForRM oItem = new DoctorUpdateRequestLogForRM();
			oItem.ID.SetID(oReader["DoctorUpdateRequestID"]);
			if (!oReader["DoctorID"].Equals(DBNull.Value))
			{
				oItem.DoctorID =Convert.ToInt32( oReader["DoctorID"]);
			}
			if (!oReader["TerritoryID"].Equals(DBNull.Value))
			{
				oItem.TerritoryID = oReader["TerritoryID"].ToString();
			}
			if (!oReader["DoctorTypeID"].Equals(DBNull.Value))
			{
				oItem.DoctorTypeID =Convert.ToInt32( oReader["DoctorTypeID"]);
			}
			if (!oReader["Code"].Equals(DBNull.Value))
			{
				oItem.Code = oReader["Code"].ToString();
			}
			if (!oReader["SwajanStatus"].Equals(DBNull.Value))
			{
				oItem.SwajanStatus =Convert.ToInt32( oReader["SwajanStatus"]);
			}
			if (!oReader["BMDCCode"].Equals(DBNull.Value))
			{
				oItem.BMDCCode = oReader["BMDCCode"].ToString();
			}
            oItem.DocName = oReader["DocName"].ToString();
			if (!oReader["SalutationID"].Equals(DBNull.Value))
			{
				oItem.SalutationID =Convert.ToInt32( oReader["SalutationID"]);
			}
			if (!oReader["SpecialtyID1"].Equals(DBNull.Value))
			{
				oItem.SpecialtyID1 =Convert.ToInt32( oReader["SpecialtyID1"]);
			}
			if (!oReader["SpecialtyID2"].Equals(DBNull.Value))
			{
				oItem.SpecialtyID2 =Convert.ToInt32( oReader["SpecialtyID2"]);
			}
			if (!oReader["DegreeID1"].Equals(DBNull.Value))
			{
				oItem.DegreeID1 =Convert.ToInt32( oReader["DegreeID1"]);
			}
			if (!oReader["DegreeID2"].Equals(DBNull.Value))
			{
				oItem.DegreeID2 =Convert.ToInt32( oReader["DegreeID2"]);
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
				oItem.DistrictID =Convert.ToInt32( oReader["DistrictID"]);
			}
			if (!oReader["UpazillaID"].Equals(DBNull.Value))
			{
				oItem.UpazillaID =Convert.ToInt32( oReader["UpazillaID"]);
			}
			if (!oReader["BirthDay"].Equals(DBNull.Value))
			{
				oItem.BirthDay =Convert.ToDateTime( oReader["BirthDay"]);
			}
			if (!oReader["Mrgday"].Equals(DBNull.Value))
			{
				oItem.Mrgday =Convert.ToDateTime( oReader["Mrgday"]);
			}
			if (!oReader["UpdateStatus"].Equals(DBNull.Value))
			{
				oItem.UpdateStatus =Convert.ToInt32( oReader["UpdateStatus"]);
			}
            oItem.MobileNo = oReader["MobileNo"].ToString();
			if (!oReader["Email"].Equals(DBNull.Value))
			{
				oItem.Email = oReader["Email"].ToString();
			}
			if (!oReader["MapAddress"].Equals(DBNull.Value))
			{
				oItem.MapAddress =Convert.ToInt32( oReader["MapAddress"]);
			}
			if (!oReader["MapSpeciality"].Equals(DBNull.Value))
			{
				oItem.MapSpeciality =Convert.ToInt32( oReader["MapSpeciality"]);
			}
			if (!oReader["MapDegree"].Equals(DBNull.Value))
			{
				oItem.MapDegree =Convert.ToInt32( oReader["MapDegree"]);
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
				oItem.CallFrequency =Convert.ToInt32( oReader["CallFrequency"]);
			}
            oItem.CardAttachement = oReader["CardAttachement"].ToString();
			if (!oReader["Action"].Equals(DBNull.Value))
			{
				oItem.Action =Convert.ToInt32( oReader["Action"]);
			}
			if (!oReader["Version"].Equals(DBNull.Value))
			{
				oItem.Version =Convert.ToInt32( oReader["Version"]);
			}

            if (!oReader["PostStepChange"].Equals(DBNull.Value))
            {
                oItem.PostStepChange = Convert.ToInt32(oReader["PostStepChange"]);
            }


			return oItem;
		}
		private DoctorUpdateRequestLogForRMs ReaderToObjects(IDataReader oReader)
		{
			DoctorUpdateRequestLogForRMs oItems;
			DoctorUpdateRequestLogForRM oItem;
			oItems = new DoctorUpdateRequestLogForRMs();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
			return oItems;
		}
		public DoctorUpdateRequestLogForRMs GetDoctorUpdateRequestLogForRMs()
		{
			DoctorUpdateRequestLogForRMs oDoctorUpdateRequestLogForRMs;
			DLDoctorUpdateRequestLogForRM oDL = new DLDoctorUpdateRequestLogForRM();
			try
			{
				oDoctorUpdateRequestLogForRMs = ReaderToObjects(oDL.GetDoctorUpdateRequestLogForRMs());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oDoctorUpdateRequestLogForRMs;
		}
		public DoctorUpdateRequestLogForRM GetDoctorUpdateRequestLogForRM(int nID)
		{
			DoctorUpdateRequestLogForRM oDoctorUpdateRequestLogForRM = new DoctorUpdateRequestLogForRM();
			DLDoctorUpdateRequestLogForRM oDL = new DLDoctorUpdateRequestLogForRM();
			IDataReader oReader;
			try
			{
				oReader = oDL.GetDoctorUpdateRequestLogForRM(nID);
				if (oReader.Read())
				{
					oDoctorUpdateRequestLogForRM = ReaderToObject(oReader);
				}
				oReader.Close();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oDoctorUpdateRequestLogForRM;
		}
	}
}
