using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;

namespace FAST.BusinessLogic
{
	public partial class BLUpazilla
	{
		private Upazilla ReaderToObject(IDataReader oReader)
		{
			Upazilla oItem = new Upazilla();
			oItem.ID.SetID(oReader["UID"]);
oItem.UName = oReader["UName"].ToString();
oItem.DistID =Convert.ToInt32( oReader["DistID"]);
oItem.Action =Convert.ToInt32( oReader["Action"]);
oItem.Version =Convert.ToInt32( oReader["Version"]);
			return oItem;
		}
		private Upazillas ReaderToObjects(IDataReader oReader)
		{
			Upazillas oItems;
			Upazilla oItem;
			oItems = new Upazillas();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
			return oItems;
		}
		public Upazillas GetUpazillas()
		{
			Upazillas oUpazillas;
			DLUpazilla oDL = new DLUpazilla();
			try
			{
				oUpazillas = ReaderToObjects(oDL.GetUpazillas());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oUpazillas;
		}
		public Upazilla GetUpazilla(int nID)
		{
			Upazilla oUpazilla = new Upazilla();
			DLUpazilla oDL = new DLUpazilla();
			IDataReader oReader;
			try
			{
				oReader = oDL.GetUpazilla(nID);
				if (oReader.Read())
				{
					oUpazilla = ReaderToObject(oReader);
				}
				oReader.Close();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oUpazilla;
		}

        public Upazilla GetUpazillaInfo(DataRow oRow)
        {
            DataTable oTable = new DataTable();
            Upazilla oItem = new Upazilla();
            try
            {
                oItem.ID.SetID(oRow["UID"]);
                oItem.UID = Convert.ToInt32(oRow["UID"]);
                oItem.UName = oRow["UName"].ToString();
                oItem.DistID = Convert.ToInt32(oRow["DistID"]);
                oItem.Action = Convert.ToInt32(oRow["Action"]);
                oItem.Version = Convert.ToInt32(oRow["Version"]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public Upazillas GetUpazillaInfosForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            Upazilla oItem = new Upazilla();
            Upazillas oItems = new Upazillas();
            try
            {
                oTable = GetUpazillaInfoForRM(sTerritoryID, nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new Upazilla();
                        oItem = GetUpazillaInfo(oRow);
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
