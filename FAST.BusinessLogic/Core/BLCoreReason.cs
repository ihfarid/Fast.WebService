using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;

namespace FAST.BusinessLogic
{
	public partial class BLReason
	{
		private Reason ReaderToObject(IDataReader oReader)
		{
			Reason oItem = new Reason();
			oItem.ID.SetID(oReader["ReasonID"]);
            oItem.ReasonID = Convert.ToInt32(oReader["ReasonID"]);
oItem.ReasonDescription = oReader["ReasonDescription"].ToString();
oItem.Version =Convert.ToInt32( oReader["Version"]);
oItem.Action =Convert.ToInt32( oReader["Action"]);
			return oItem;
		}
		private Reasons ReaderToObjects(IDataReader oReader)
		{
			Reasons oItems;
			Reason oItem;
			oItems = new Reasons();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
			return oItems;
		}
		public Reasons GetReasons()
		{
			Reasons oReasons;
			DLReason oDL = new DLReason();
			try
			{
				oReasons = ReaderToObjects(oDL.GetReasons());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oReasons;
		}
		public Reason GetReason(int nID)
		{
			Reason oReason = new Reason();
			DLReason oDL = new DLReason();
			IDataReader oReader;
			try
			{
				oReader = oDL.GetReason(nID);
				if (oReader.Read())
				{
					oReason = ReaderToObject(oReader);
				}
				oReader.Close();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReason;
		}

        public Reason GetReason(DataRow oRow)
        {
            DataTable oTable = new DataTable();
            Reason oItem = new Reason();
            try
            {
                oItem.ID.SetID(oRow["ReasonID"]);
                oItem.ReasonID = Convert.ToInt32(oRow["ReasonID"]);
                oItem.ReasonDescription = oRow["ReasonDescription"].ToString();
                oItem.Version = Convert.ToInt32(oRow["Version"]);
                oItem.Action = Convert.ToInt32(oRow["Action"]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public Reason GetReason(int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            Reason oItem = new Reason();
            try
            {
                oTable = GetReasonInfo(nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem = GetReason(oRow);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public Reasons GetReasons(int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            Reason oItem = new Reason();
            Reasons oItems = new Reasons();
            try
            {
                oTable = GetReasonInfo(nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new Reason();
                        oItem = GetReason(oRow);
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
