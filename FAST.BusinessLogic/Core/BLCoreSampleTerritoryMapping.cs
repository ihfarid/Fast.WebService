using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;

namespace FAST.BusinessLogic
{
	public partial class BLSampleTerritoryMapping
	{
		private SampleTerritoryMapping ReaderToObject(IDataReader oReader)
		{
			SampleTerritoryMapping oItem = new SampleTerritoryMapping();
            oItem.ID.SetID(oReader["SampleTerritoryMapID"]);
            oItem.SampleTerritoryMapID = Convert.ToInt32(oReader["SampleTerritoryMapID"]);
            if (!oReader["SampleID"].Equals(DBNull.Value))
            {
                oItem.SampleID = Convert.ToInt32(oReader["SampleID"]);
            }
			if (!oReader["TerritoryCode"].Equals(DBNull.Value))
			{
				oItem.TerritoryCode = oReader["TerritoryCode"].ToString();
			}
			if (!oReader["BrandName"].Equals(DBNull.Value))
			{
				oItem.BrandName = oReader["BrandName"].ToString();
			}
			if (!oReader["SampleName"].Equals(DBNull.Value))
			{
				oItem.SampleName = oReader["SampleName"].ToString();
			}
            if (!oReader["Month"].Equals(DBNull.Value))
            {
                oItem.Month = Convert.ToInt32(oReader["Month"]);
            }
            if (!oReader["Year"].Equals(DBNull.Value))
            {
                oItem.Year = Convert.ToInt32(oReader["Year"]);
            }
			if (!oReader["Version"].Equals(DBNull.Value))
			{
				oItem.Version =Convert.ToInt32( oReader["Version"]);
			}
			if (!oReader["Action"].Equals(DBNull.Value))
			{
                oItem.Action = Convert.ToInt32(oReader["Action"]);
			}
			return oItem;
		}
		private SampleTerritoryMappings ReaderToObjects(IDataReader oReader)
		{
			SampleTerritoryMappings oItems;
			SampleTerritoryMapping oItem;
			oItems = new SampleTerritoryMappings();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
			return oItems;
		}
		public SampleTerritoryMappings GetSampleTerritoryMappings()
		{
			SampleTerritoryMappings oSampleTerritoryMappings;
			DLSampleTerritoryMapping oDL = new DLSampleTerritoryMapping();
			try
			{
				oSampleTerritoryMappings = ReaderToObjects(oDL.GetSampleTerritoryMappings());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oSampleTerritoryMappings;
		}
		public SampleTerritoryMapping GetSampleTerritoryMapping(int nID)
		{
			SampleTerritoryMapping oSampleTerritoryMapping = new SampleTerritoryMapping();
			DLSampleTerritoryMapping oDL = new DLSampleTerritoryMapping();
			IDataReader oReader;
			try
			{
				oReader = oDL.GetSampleTerritoryMapping(nID);
				if (oReader.Read())
				{
					oSampleTerritoryMapping = ReaderToObject(oReader);
				}
				oReader.Close();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oSampleTerritoryMapping;
		}

        public SampleTerritoryMapping GetSampleTerritoryMapping(DataRow oRow)
        {
            SampleTerritoryMapping oItem = new SampleTerritoryMapping();
            try
            {
                oItem.ID.SetID(oRow["SampleTerritoryMapID"]);
                oItem.SampleTerritoryMapID = Convert.ToInt32(oRow["SampleTerritoryMapID"]);
                if (!oRow["SampleID"].Equals(DBNull.Value))
                {
                    oItem.SampleID = Convert.ToInt32(oRow["SampleID"]);
                }
                if (!oRow["TerritoryCode"].Equals(DBNull.Value))
                {
                    oItem.TerritoryCode = oRow["TerritoryCode"].ToString().ToUpper();
                }
                if (!oRow["BrandName"].Equals(DBNull.Value))
                {
                    oItem.BrandName = oRow["BrandName"].ToString();
                }
                if (!oRow["SampleName"].Equals(DBNull.Value))
                {
                    oItem.SampleName = oRow["SampleName"].ToString();
                }
                if (!oRow["Month"].Equals(DBNull.Value))
                {
                    oItem.Month = Convert.ToInt32(oRow["Month"]);
                }
                if (!oRow["Year"].Equals(DBNull.Value))
                {
                    oItem.Year = Convert.ToInt32(oRow["Year"]);
                }
                if (!oRow["Version"].Equals(DBNull.Value))
                {
                    oItem.Version = Convert.ToInt32(oRow["Version"]);
                }
                if (!oRow["Action"].Equals(DBNull.Value))
                {
                    oItem.Action = Convert.ToInt32(oRow["Action"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public SampleTerritoryMapping GetSampleTerritoryMapping(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            SampleTerritoryMapping oItem = new SampleTerritoryMapping();
            try
            {
                oTable = GetSampleTerritoryMappingInfo(sTerritoryID, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem = GetSampleTerritoryMapping(oRow);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public SampleTerritoryMappings GetSampleTerritoryMappings(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            SampleTerritoryMapping oItem = new SampleTerritoryMapping();
            SampleTerritoryMappings oItems = new SampleTerritoryMappings();
            try
            {
                oTable = GetSampleTerritoryMappingInfo(sTerritoryID, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new SampleTerritoryMapping();
                        oItem = GetSampleTerritoryMapping(oRow);
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

        public SampleTerritoryMapping GetSampleTerritoryMappingForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            SampleTerritoryMapping oItem = new SampleTerritoryMapping();
            try
            {
                oTable = GetSampleTerritoryMappingInfoForRM(sTerritoryID, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem = GetSampleTerritoryMapping(oRow);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public SampleTerritoryMappings GetSampleTerritoryMappingsForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            SampleTerritoryMapping oItem = new SampleTerritoryMapping();
            SampleTerritoryMappings oItems = new SampleTerritoryMappings();
            try
            {
                oTable = GetSampleTerritoryMappingInfoForRM(sTerritoryID, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new SampleTerritoryMapping();
                        oItem = GetSampleTerritoryMapping(oRow);
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
