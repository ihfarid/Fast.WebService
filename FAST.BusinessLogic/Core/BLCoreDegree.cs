using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;

namespace FAST.BusinessLogic
{
	public partial class BLDegree
	{
		private Degree ReaderToObject(IDataReader oReader)
		{
			Degree oItem = new Degree();
			oItem.ID.SetID(oReader["DegID"]);
oItem.DegCode = oReader["DegCode"].ToString();
oItem.DegName = oReader["DegName"].ToString();
oItem.Status =Convert.ToInt32( oReader["Status"]);
oItem.Action =Convert.ToInt32( oReader["Action"]);
oItem.Version =Convert.ToInt32( oReader["Version"]);
			return oItem;
		}
		private Degrees ReaderToObjects(IDataReader oReader)
		{
			Degrees oItems;
			Degree oItem;
			oItems = new Degrees();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
			return oItems;
		}
		public Degrees GetDegrees()
		{
			Degrees oDegrees;
			DLDegree oDL = new DLDegree();
			try
			{
				oDegrees = ReaderToObjects(oDL.GetDegrees());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oDegrees;
		}
		public Degree GetDegree(int nID)
		{
			Degree oDegree = new Degree();
			DLDegree oDL = new DLDegree();
			IDataReader oReader;
			try
			{
				oReader = oDL.GetDegree(nID);
				if (oReader.Read())
				{
					oDegree = ReaderToObject(oReader);
				}
				oReader.Close();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oDegree;
		}

        public Degree GetDegreeInfo(DataRow oRow)
        {
            DataTable oTable = new DataTable();
            Degree oItem = new Degree();
            try
            {
                oItem.ID.SetID(oRow["DegID"]);
                oItem.DegID = Convert.ToInt32(oRow["DegID"]);
                oItem.DegCode = oRow["DegCode"].ToString();
                oItem.DegName = oRow["DegName"].ToString();
                oItem.Status = Convert.ToInt32(oRow["Status"]);
                oItem.Action = Convert.ToInt32(oRow["Action"]);
                oItem.Version = Convert.ToInt32(oRow["Version"]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public Degrees GetDegreeInfos(int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            Degree oItem = new Degree();
            Degrees oItems = new Degrees();
            try
            {
                oTable = GetDegreeInfo(nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new Degree();
                        oItem = GetDegreeInfo(oRow);
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
