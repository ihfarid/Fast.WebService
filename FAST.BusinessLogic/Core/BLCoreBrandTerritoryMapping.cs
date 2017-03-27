using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;

namespace FAST.BusinessLogic
{
	public partial class BLBrandTerritoryMapping
	{
        private BrandTerritoryMapping ReaderToObject(IDataReader oReader)
        {
            BrandTerritoryMapping oItem = new BrandTerritoryMapping();
            oItem.ID.SetID(oReader["BrandTerritoryMappingID"]);
            oItem.BrandTerritoryMappingID = Convert.ToInt32(oReader["BrandTerritoryMappingID"].ToString());
            oItem.TerritoryID = oReader["TerritoryID"].ToString();
            oItem.Line = oReader["Line"].ToString();
            oItem.BrandID = Convert.ToInt32(oReader["BrandID"]);
            oItem.BrandCode = oReader["BrandCode"].ToString();
            oItem.BrandName = oReader["BrandName"].ToString();
            oItem.NoOfGuidedDr = oReader["NoOfGuidedDr"].ToString();
            oItem.Version = Convert.ToInt32(oReader["Version"]);
            oItem.Action = Convert.ToInt32(oReader["Action"]);
            return oItem;
        }
		private BrandTerritoryMappings ReaderToObjects(IDataReader oReader)
		{
			BrandTerritoryMappings oItems;
			BrandTerritoryMapping oItem;
			oItems = new BrandTerritoryMappings();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
			return oItems;
		}
		public BrandTerritoryMappings GetBrandTerritoryMappings()
		{
			BrandTerritoryMappings oBrandTerritoryMappings;
			DLBrandTerritoryMapping oDL = new DLBrandTerritoryMapping();
			try
			{
				oBrandTerritoryMappings = ReaderToObjects(oDL.GetBrandTerritoryMappings());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oBrandTerritoryMappings;
		}
		public BrandTerritoryMapping GetBrandTerritoryMapping(int nID)
		{
			BrandTerritoryMapping oBrandTerritoryMapping = new BrandTerritoryMapping();
			DLBrandTerritoryMapping oDL = new DLBrandTerritoryMapping();
			IDataReader oReader;
			try
			{
				oReader = oDL.GetBrandTerritoryMapping(nID);
				if (oReader.Read())
				{
					oBrandTerritoryMapping = ReaderToObject(oReader);
				}
				oReader.Close();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oBrandTerritoryMapping;
		}

        public BrandTerritoryMapping GetBrandTerritoryMapping(DataRow oRow)
        {
            BrandTerritoryMapping oItem = new BrandTerritoryMapping();
            try
            {
                oItem.ID.SetID(oRow["BrandTerritoryMappingID"]);
                oItem.BrandTerritoryMappingID = Convert.ToInt32(oRow["BrandTerritoryMappingID"].ToString());
                oItem.TerritoryID = oRow["TerritoryID"].ToString().ToUpper();
                oItem.Line = oRow["Line"].ToString().ToUpper();
                oItem.BrandID = Convert.ToInt32(oRow["BrandID"]);
                oItem.BrandCode = oRow["BrandCode"].ToString();
                oItem.BrandName = oRow["BrandName"].ToString();
                oItem.NoOfGuidedDr = oRow["NoOfGuidedDr"].ToString();
                oItem.Version = Convert.ToInt32(oRow["Version"]);
                oItem.Action = Convert.ToInt32(oRow["Action"]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public BrandTerritoryMapping GetBrandTerritoryMapping(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            BrandTerritoryMapping oItem = new BrandTerritoryMapping();
            try
            {
                oTable = GetBrandTerritoryMappingInfo(sTerritoryID, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem = GetBrandTerritoryMapping(oRow);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public BrandTerritoryMappings GetBrandTerritoryMappings(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            BrandTerritoryMapping oItem = new BrandTerritoryMapping();
            BrandTerritoryMappings oItems = new BrandTerritoryMappings();
            try
            {
                oTable = GetBrandTerritoryMappingInfo(sTerritoryID, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new BrandTerritoryMapping();
                        oItem = GetBrandTerritoryMapping(oRow);
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

        public BrandTerritoryMapping GetBrandTerritoryMappingForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            BrandTerritoryMapping oItem = new BrandTerritoryMapping();
            try
            {
                oTable = GetBrandTerritoryMappingInfoForRM(sTerritoryID, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem = GetBrandTerritoryMapping(oRow);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public BrandTerritoryMappings GetBrandTerritoryMappingsForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            BrandTerritoryMapping oItem = new BrandTerritoryMapping();
            BrandTerritoryMappings oItems = new BrandTerritoryMappings();
            try
            {
                oTable = GetBrandTerritoryMappingInfoForRM(sTerritoryID, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new BrandTerritoryMapping();
                        oItem = GetBrandTerritoryMapping(oRow);
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
