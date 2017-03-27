using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;

namespace FAST.BusinessLogic
{
	public partial class BLDistrict
	{
		private District ReaderToObject(IDataReader oReader)
		{
			District oItem = new District();
			oItem.ID.SetID(oReader["DistID"]);
oItem.DistName = oReader["DistName"].ToString();
oItem.Action =Convert.ToInt32( oReader["Action"]);
oItem.Version =Convert.ToInt32( oReader["Version"]);
			return oItem;
		}
		private Districts ReaderToObjects(IDataReader oReader)
		{
			Districts oItems;
			District oItem;
			oItems = new Districts();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
			return oItems;
		}
		public Districts GetDistricts()
		{
			Districts oDistricts;
			DLDistrict oDL = new DLDistrict();
			try
			{
				oDistricts = ReaderToObjects(oDL.GetDistricts());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oDistricts;
		}
		public District GetDistrict(int nID)
		{
			District oDistrict = new District();
			DLDistrict oDL = new DLDistrict();
			IDataReader oReader;
			try
			{
				oReader = oDL.GetDistrict(nID);
				if (oReader.Read())
				{
					oDistrict = ReaderToObject(oReader);
				}
				oReader.Close();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oDistrict;
		}

        public District GetDistrictInfo(DataRow oRow)
        {
            DataTable oTable = new DataTable();
            District oItem = new District();
            try
            {
                oItem.ID.SetID(oRow["DistID"]);
                oItem.DistID = Convert.ToInt32(oRow["DistID"]);
                oItem.DistName = oRow["DistName"].ToString();
                oItem.Action = Convert.ToInt32(oRow["Action"]);
                oItem.Version = Convert.ToInt32(oRow["Version"]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public Districts GetDistrictInfosForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            District oItem = new District();
            Districts oItems = new Districts();
            try
            {
                oTable = GetDistrictInfoForRM(sTerritoryID, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new District();
                        oItem = GetDistrictInfo(oRow);
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
