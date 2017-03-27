using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;

namespace FAST.BusinessLogic
{
	public partial class BLSalutation
	{
		private Salutation ReaderToObject(IDataReader oReader)
		{
			Salutation oItem = new Salutation();
			oItem.ID.SetID(oReader["SalID"]);
oItem.SalCode = oReader["SalCode"].ToString();
oItem.SalDesc = oReader["SalDesc"].ToString();
oItem.Status =Convert.ToInt32( oReader["Status"]);
oItem.Action =Convert.ToInt32( oReader["Action"]);
oItem.Version =Convert.ToInt32( oReader["Version"]);
			return oItem;
		}
		private Salutations ReaderToObjects(IDataReader oReader)
		{
			Salutations oItems;
			Salutation oItem;
			oItems = new Salutations();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
			return oItems;
		}
		public Salutations GetSalutations()
		{
			Salutations oSalutations;
			DLSalutation oDL = new DLSalutation();
			try
			{
				oSalutations = ReaderToObjects(oDL.GetSalutations());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oSalutations;
		}
		public Salutation GetSalutation(int nID)
		{
			Salutation oSalutation = new Salutation();
			DLSalutation oDL = new DLSalutation();
			IDataReader oReader;
			try
			{
				oReader = oDL.GetSalutation(nID);
				if (oReader.Read())
				{
					oSalutation = ReaderToObject(oReader);
				}
				oReader.Close();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oSalutation;
		}

        public Salutation GetSalutationInfo(DataRow oRow)
        {
            DataTable oTable = new DataTable();
            Salutation oItem = new Salutation();
            try
            {
                oItem.ID.SetID(oRow["SalID"]);
                oItem.SalID = Convert.ToInt32(oRow["SalID"]);
                oItem.SalCode = oRow["SalCode"].ToString();
                oItem.SalDesc = oRow["SalDesc"].ToString();
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

        public Salutations GetSalutationInfos(int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            Salutation oItem = new Salutation();
            Salutations oItems = new Salutations();
            try
            {
                oTable = GetSalutationInfo(nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new Salutation();
                        oItem = GetSalutationInfo(oRow);
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
