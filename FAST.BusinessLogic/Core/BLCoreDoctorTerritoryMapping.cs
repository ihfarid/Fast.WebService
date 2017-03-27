using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;

namespace FAST.BusinessLogic
{
	public partial class BLDoctorTerritoryMapping
	{
        private DoctorTerritoryMapping ReaderToObject(IDataReader oReader)
        {
            DoctorTerritoryMapping oItem = new DoctorTerritoryMapping();
            oItem.ID.SetID(oReader["TerrWiseDocID"]);
            oItem.DoctorID = Convert.ToInt32(oReader["DoctorID"]);
            if (!oReader["Code"].Equals(DBNull.Value))
            {
                oItem.Code = oReader["Code"].ToString();
            }
            if (!oReader["TerritoryID"].Equals(DBNull.Value))
            {
                oItem.TerritoryID = oReader["TerritoryID"].ToString();
            }
            if (!oReader["DocTypeID"].Equals(DBNull.Value))
            {
                oItem.DocTypeID = Convert.ToInt32(oReader["DocTypeID"]);
            }
            if (!oReader["Address"].Equals(DBNull.Value))
            {
                oItem.Address = Convert.ToInt32(oReader["Address"]);
            }
            if (!oReader["Speciality"].Equals(DBNull.Value))
            {
                oItem.Speciality = Convert.ToInt32(oReader["Speciality"]);
            }
            if (!oReader["Degree"].Equals(DBNull.Value))
            {
                oItem.Degree = Convert.ToInt32(oReader["Degree"]);
            }
            if (!oReader["SwajanStatus"].Equals(DBNull.Value))
            {
                oItem.SwajanStatus = Convert.ToInt32(oReader["SwajanStatus"]);
            }
            if (!oReader["ProfileID"].Equals(DBNull.Value))
            {
                oItem.ProfileID = Convert.ToInt32(oReader["ProfileID"]);
            }
            if (!oReader["Prod1"].Equals(DBNull.Value))
            {
                oItem.Prod1 = Convert.ToInt32(oReader["Prod1"]);
            }
            if (!oReader["Prod2"].Equals(DBNull.Value))
            {
                oItem.Prod2 = Convert.ToInt32(oReader["Prod2"]);
            }
            if (!oReader["Prod3"].Equals(DBNull.Value))
            {
                oItem.Prod3 = Convert.ToInt32(oReader["Prod3"]);
            }
            if (!oReader["Prod4"].Equals(DBNull.Value))
            {
                oItem.Prod4 = Convert.ToInt32(oReader["Prod4"]);
            }
            if (!oReader["Prod5"].Equals(DBNull.Value))
            {
                oItem.Prod5 = Convert.ToInt32(oReader["Prod5"]);
            }
            if (!oReader["Prod6"].Equals(DBNull.Value))
            {
                oItem.Prod6 = Convert.ToInt32(oReader["Prod6"]);
            }
            if (!oReader["Prod7"].Equals(DBNull.Value))
            {
                oItem.Prod7 = Convert.ToInt32(oReader["Prod7"]);
            }
            if (!oReader["Prod8"].Equals(DBNull.Value))
            {
                oItem.Prod8 = Convert.ToInt32(oReader["Prod8"]);
            }
            if (!oReader["CallFre"].Equals(DBNull.Value))
            {
                oItem.CallFre = Convert.ToInt32(oReader["CallFre"]);
            }
            if (!oReader["RouteID"].Equals(DBNull.Value))
            {
                oItem.RouteID = Convert.ToInt32(oReader["RouteID"]);
            }
            if (!oReader["SessionID"].Equals(DBNull.Value))
            {
                oItem.SessionID = Convert.ToInt32(oReader["SessionID"]);
            }
            if (!oReader["CreateDatetime"].Equals(DBNull.Value))
            {
                oItem.CreateDatetime = Convert.ToDateTime(oReader["CreateDatetime"]);
            }
            if (!oReader["ModifyDatetime"].Equals(DBNull.Value))
            {
                oItem.ModifyDatetime = Convert.ToDateTime(oReader["ModifyDatetime"]);
            }
            if (!oReader["Status"].Equals(DBNull.Value))
            {
                oItem.Status = Convert.ToInt32(oReader["Status"]);
            }
            oItem.Version = Convert.ToInt32(oReader["Version"]);
            oItem.Action = Convert.ToInt32(oReader["Action"]);
            return oItem;
        }
		private DoctorTerritoryMappings ReaderToObjects(IDataReader oReader)
		{
			DoctorTerritoryMappings oItems;
			DoctorTerritoryMapping oItem;
			oItems = new DoctorTerritoryMappings();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
			return oItems;
		}
		public DoctorTerritoryMappings GetDoctorTerritoryMappings()
		{
			DoctorTerritoryMappings oDoctorTerritoryMappings;
			DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
			try
			{
				oDoctorTerritoryMappings = ReaderToObjects(oDL.GetDoctorTerritoryMappings());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oDoctorTerritoryMappings;
		}
		public DoctorTerritoryMapping GetDoctorTerritoryMapping(int nID)
		{
			DoctorTerritoryMapping oDoctorTerritoryMapping = new DoctorTerritoryMapping();
			DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
			IDataReader oReader;
			try
			{
				oReader = oDL.GetDoctorTerritoryMapping(nID);
				if (oReader.Read())
				{
					oDoctorTerritoryMapping = ReaderToObject(oReader);
				}
				oReader.Close();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oDoctorTerritoryMapping;
		}

        public DoctorTerritoryMapping GetDocTerrMapping(DataRow oRow)
        {
            DataTable oTable = new DataTable();
            DoctorTerritoryMapping oItem = new DoctorTerritoryMapping();
            try
            {
                oItem.ID.SetID(oRow["TerrWiseDocID"]);
                oItem.TerrWiseDocID = Convert.ToInt32(oRow["TerrWiseDocID"]);
                oItem.DoctorID = Convert.ToInt32(oRow["DoctorID"]);
                if (!oRow["Code"].Equals(DBNull.Value))
                {
                    oItem.Code = oRow["Code"].ToString();
                }
                if (!oRow["TerritoryID"].Equals(DBNull.Value))
                {
                    oItem.TerritoryID = oRow["TerritoryID"].ToString();
                }
                if (!oRow["DocTypeID"].Equals(DBNull.Value))
                {
                    oItem.DocTypeID = Convert.ToInt32(oRow["DocTypeID"]);
                }
                if (!oRow["Address"].Equals(DBNull.Value))
                {
                    oItem.Address = Convert.ToInt32(oRow["Address"]);
                }
                if (!oRow["Speciality"].Equals(DBNull.Value))
                {
                    oItem.Speciality = Convert.ToInt32(oRow["Speciality"]);
                }
                if (!oRow["Degree"].Equals(DBNull.Value))
                {
                    oItem.Degree = Convert.ToInt32(oRow["Degree"]);
                }
                if (!oRow["SwajanStatus"].Equals(DBNull.Value))
                {
                    oItem.SwajanStatus = Convert.ToInt32(oRow["SwajanStatus"]);
                }
                if (!oRow["ProfileID"].Equals(DBNull.Value))
                {
                    oItem.ProfileID = Convert.ToInt32(oRow["ProfileID"]);
                }
                if (!oRow["Prod1"].Equals(DBNull.Value))
                {
                    oItem.Prod1 = Convert.ToInt32(oRow["Prod1"]);
                }
                if (!oRow["Prod2"].Equals(DBNull.Value))
                {
                    oItem.Prod2 = Convert.ToInt32(oRow["Prod2"]);
                }
                if (!oRow["Prod3"].Equals(DBNull.Value))
                {
                    oItem.Prod3 = Convert.ToInt32(oRow["Prod3"]);
                }
                if (!oRow["Prod4"].Equals(DBNull.Value))
                {
                    oItem.Prod4 = Convert.ToInt32(oRow["Prod4"]);
                }
                if (!oRow["Prod5"].Equals(DBNull.Value))
                {
                    oItem.Prod5 = Convert.ToInt32(oRow["Prod5"]);
                }
                if (!oRow["Prod6"].Equals(DBNull.Value))
                {
                    oItem.Prod6 = Convert.ToInt32(oRow["Prod6"]);
                }
                if (!oRow["Prod7"].Equals(DBNull.Value))
                {
                    oItem.Prod7 = Convert.ToInt32(oRow["Prod7"]);
                }
                if (!oRow["Prod8"].Equals(DBNull.Value))
                {
                    oItem.Prod8 = Convert.ToInt32(oRow["Prod8"]);
                }
                if (!oRow["CallFre"].Equals(DBNull.Value))
                {
                    oItem.CallFre = Convert.ToInt32(oRow["CallFre"]);
                }
                if (!oRow["RouteID"].Equals(DBNull.Value))
                {
                    oItem.RouteID = Convert.ToInt32(oRow["RouteID"]);
                }
                if (!oRow["SessionID"].Equals(DBNull.Value))
                {
                    oItem.SessionID = Convert.ToInt32(oRow["SessionID"]);
                }
                if (!oRow["CreateDatetime"].Equals(DBNull.Value))
                {
                    oItem.CreateDatetime = Convert.ToDateTime(oRow["CreateDatetime"]);
                }
                if (!oRow["ModifyDatetime"].Equals(DBNull.Value))
                {
                    oItem.ModifyDatetime = Convert.ToDateTime(oRow["ModifyDatetime"]);
                }
                if (!oRow["Status"].Equals(DBNull.Value))
                {
                    oItem.Status = Convert.ToInt32(oRow["Status"]);
                }
                oItem.Version = Convert.ToInt32(oRow["Version"]);
                oItem.Action = Convert.ToInt32(oRow["Action"]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public DoctorTerritoryMapping GetDocTerrMapping(int nDoctorID, string sTerritoryID, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            DoctorTerritoryMapping oItem = new DoctorTerritoryMapping();
            try
            {
                oTable = GetDocTerrMappingInfo(nDoctorID, sTerritoryID, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem = GetDocTerrMapping(oRow);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public DoctorTerritoryMappings GetDocTerrMappings(int nDoctorID, string sTerritoryID, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            DoctorTerritoryMapping oItem = new DoctorTerritoryMapping();
            DoctorTerritoryMappings oItems = new DoctorTerritoryMappings();
            try
            {
                oTable = GetDocTerrMappingInfo(nDoctorID, sTerritoryID, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new DoctorTerritoryMapping();
                        oItem = GetDocTerrMapping(oRow);
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
