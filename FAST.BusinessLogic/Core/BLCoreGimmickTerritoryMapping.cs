using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;

namespace FAST.BusinessLogic
{
	public partial class BLGimmickTerritoryMapping
	{
		private GimmickTerritoryMapping ReaderToObject(IDataReader oReader)
		{
			GimmickTerritoryMapping oItem = new GimmickTerritoryMapping();
            oItem.ID.SetID(oReader["GimmickTerritoryMapID"]);
            oItem.GimmickTerritoryMapID = Convert.ToInt32(oReader["GimmickTerritoryMapID"]);
            if (!oReader["GimmickID"].Equals(DBNull.Value))
			{
                oItem.GimmickID = Convert.ToInt32(oReader["GimmickID"]);
			}
            if (!oReader["TerritoryCode"].Equals(DBNull.Value))
            {
                oItem.TerritoryCode = oReader["TerritoryCode"].ToString();
            }
			if (!oReader["BrandName"].Equals(DBNull.Value))
			{
				oItem.BrandName = oReader["BrandName"].ToString();
			}
			if (!oReader["GimmickName"].Equals(DBNull.Value))
			{
				oItem.GimmickName = oReader["GimmickName"].ToString();
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
                oItem.Version = Convert.ToInt32(oReader["Version"]);
            }
            if (!oReader["Action"].Equals(DBNull.Value))
            {
                oItem.Action = Convert.ToInt32(oReader["Action"]);
            } 
			return oItem;
		}
		private GimmickTerritoryMappings ReaderToObjects(IDataReader oReader)
		{
			GimmickTerritoryMappings oItems;
			GimmickTerritoryMapping oItem;
			oItems = new GimmickTerritoryMappings();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
			return oItems;
		}
		public GimmickTerritoryMappings GetGimmickTerritoryMappings()
		{
			GimmickTerritoryMappings oGimmickTerritoryMappings;
			DLGimmickTerritoryMapping oDL = new DLGimmickTerritoryMapping();
			try
			{
				oGimmickTerritoryMappings = ReaderToObjects(oDL.GetGimmickTerritoryMappings());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oGimmickTerritoryMappings;
		}
		public GimmickTerritoryMapping GetGimmickTerritoryMapping(int nID)
		{
			GimmickTerritoryMapping oGimmickTerritoryMapping = new GimmickTerritoryMapping();
			DLGimmickTerritoryMapping oDL = new DLGimmickTerritoryMapping();
			IDataReader oReader;
			try
			{
				oReader = oDL.GetGimmickTerritoryMapping(nID);
				if (oReader.Read())
				{
					oGimmickTerritoryMapping = ReaderToObject(oReader);
				}
				oReader.Close();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oGimmickTerritoryMapping;
		}

        public GimmickTerritoryMapping GetGimmickTerritoryMapping(DataRow oRow)
        {
            GimmickTerritoryMapping oItem = new GimmickTerritoryMapping();
            try
            {
                oItem.ID.SetID(oRow["GimmickTerritoryMapID"]);
                oItem.GimmickTerritoryMapID = Convert.ToInt32(oRow["GimmickTerritoryMapID"]);
                if (!oRow["GimmickID"].Equals(DBNull.Value))
                {
                    oItem.GimmickID = Convert.ToInt32(oRow["GimmickID"]);
                }
                if (!oRow["TerritoryCode"].Equals(DBNull.Value))
                {
                    oItem.TerritoryCode = oRow["TerritoryCode"].ToString().ToUpper();
                }
                if (!oRow["BrandName"].Equals(DBNull.Value))
                {
                    oItem.BrandName = oRow["BrandName"].ToString();
                }
                if (!oRow["GimmickName"].Equals(DBNull.Value))
                {
                    oItem.GimmickName = oRow["GimmickName"].ToString();
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

        public GimmickTerritoryMapping GetGimmickTerritoryMapping(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            GimmickTerritoryMapping oItem = new GimmickTerritoryMapping();
            try
            {
                oTable = GetGimmickTerritoryMappingInfo(sTerritoryID, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem = GetGimmickTerritoryMapping(oRow);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public GimmickTerritoryMappings GetGimmickTerritoryMappings(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            GimmickTerritoryMapping oItem = new GimmickTerritoryMapping();
            GimmickTerritoryMappings oItems = new GimmickTerritoryMappings();
            try
            {
                oTable = GetGimmickTerritoryMappingInfo(sTerritoryID, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new GimmickTerritoryMapping();
                        oItem = GetGimmickTerritoryMapping(oRow);
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

        public GimmickTerritoryMapping GetGimmickTerritoryMappingForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            GimmickTerritoryMapping oItem = new GimmickTerritoryMapping();
            try
            {
                oTable = GetGimmickTerritoryMappingInfoForRM(sTerritoryID, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem = GetGimmickTerritoryMapping(oRow);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public GimmickTerritoryMappings GetGimmickTerritoryMappingsForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            GimmickTerritoryMapping oItem = new GimmickTerritoryMapping();
            GimmickTerritoryMappings oItems = new GimmickTerritoryMappings();
            try
            {
                oTable = GetGimmickTerritoryMappingInfoForRM(sTerritoryID, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new GimmickTerritoryMapping();
                        oItem = GetGimmickTerritoryMapping(oRow);
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
