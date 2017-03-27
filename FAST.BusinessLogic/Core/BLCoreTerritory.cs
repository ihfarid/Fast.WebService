using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core;
using FAST.Core.DataAccess;

namespace FAST.BusinessLogic
{
	public partial class BLTerritory
	{
        private Territory ReaderToObject(IDataReader oReader)
        {
            Territory oItem = new Territory();
            oItem.ID.SetID(oReader["TerritoryID"]);
            oItem.TerritoryCode = oReader["TerritoryCode"].ToString();
            oItem.TerritoryName = oReader["TerritoryName"].ToString();
            if (!oReader["ParentID"].Equals(DBNull.Value))
            {
                oItem.ParentID = Convert.ToInt32(oReader["ParentID"]);
            }
            oItem.WorkAreaID = Convert.ToInt32(oReader["WorkAreaID"]);
            if (!oReader["MobileNo"].Equals(DBNull.Value))
            {
                oItem.MobileNo = oReader["MobileNo"].ToString();
            }
            oItem.BeginningDate = Convert.ToDateTime(oReader["BeginningDate"]);
            oItem.EndDate = Convert.ToDateTime(oReader["EndDate"]);
            oItem.IsActive = Convert.ToBoolean(oReader["IsActive"]);
            return oItem;
        }
		
		private Territorys ReaderToObjects(IDataReader oReader)
		{
			Territorys oItems;
			Territory oItem;
            try
            {
                oItems = new Territorys();
                if (oReader.IsClosed) return oItems;
                while (oReader.Read())
                {
                    oItem = ReaderToObject(oReader);
                    oItems.Add(oItem);
                }
                oReader.Close();
            }
            catch (Exception ex)
            {
                oReader.Close();
                throw new Exception(ex.Message);
            }
			return oItems;
		}
		public Territorys GetTerritorys()
		{
			Territorys oTerritorys;
			DLTerritory oDL = new DLTerritory();
			try
			{
				oTerritorys = ReaderToObjects(oDL.GetTerritorys());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oTerritorys;
		}
		public Territory GetTerritory(int nID)
		{
			Territory oTerritory = new Territory();
			DLTerritory oDL = new DLTerritory();
			IDataReader oReader = null;
			try
			{
				oReader = oDL.GetTerritory(nID);
				if (oReader.Read())
				{
					oTerritory = ReaderToObject(oReader);
				}
				oReader.Close();
			}
            catch (Exception ex)
            {
                oReader.Close();
                throw new Exception(ex.Message);
            }
			return oTerritory;
		}

        public Territory GetTerritory(int nID, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            Territory oItem = new Territory();
            try
            {
                oTable = GetTerritoryInfo(nID, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem.ID.SetID(oRow["TerritoryID"]);
                    oItem.TerritoryCode = oRow["TerritoryCode"].ToString();
                    oItem.TerritoryName = oRow["TerritoryName"].ToString();
                    if (!oRow["ParentID"].Equals(DBNull.Value))
                    {
                        oItem.ParentID = Convert.ToInt32(oRow["ParentID"]);
                    }
                    oItem.WorkAreaID = Convert.ToInt32(oRow["WorkAreaID"]);
                    if (!oRow["MobileNo"].Equals(DBNull.Value))
                    {
                        oItem.MobileNo = oRow["MobileNo"].ToString();
                    }
                    oItem.BeginningDate = Convert.ToDateTime(oRow["BeginningDate"]);
                    oItem.EndDate = Convert.ToDateTime(oRow["EndDate"]);
                    oItem.IsActive = Convert.ToBoolean(oRow["IsActive"]);
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
