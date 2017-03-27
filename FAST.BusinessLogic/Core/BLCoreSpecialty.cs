using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;

namespace FAST.BusinessLogic
{
	public partial class BLSpecialty
	{
		private Specialty ReaderToObject(IDataReader oReader)
		{
			Specialty oItem = new Specialty();
			oItem.ID.SetID(oReader["SpID"]);
oItem.SpCode = oReader["SpCode"].ToString();
oItem.SpDesc = oReader["SpDesc"].ToString();
oItem.Status =Convert.ToInt32( oReader["Status"]);
oItem.Action =Convert.ToInt32( oReader["Action"]);
oItem.Version =Convert.ToInt32( oReader["Version"]);
			return oItem;
		}
		private Specialtys ReaderToObjects(IDataReader oReader)
		{
			Specialtys oItems;
			Specialty oItem;
			oItems = new Specialtys();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
			return oItems;
		}
		public Specialtys GetSpecialtys()
		{
			Specialtys oSpecialtys;
			DLSpecialty oDL = new DLSpecialty();
			try
			{
				oSpecialtys = ReaderToObjects(oDL.GetSpecialtys());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oSpecialtys;
		}
		public Specialty GetSpecialty(int nID)
		{
			Specialty oSpecialty = new Specialty();
			DLSpecialty oDL = new DLSpecialty();
			IDataReader oReader;
			try
			{
				oReader = oDL.GetSpecialty(nID);
				if (oReader.Read())
				{
					oSpecialty = ReaderToObject(oReader);
				}
				oReader.Close();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oSpecialty;
		}

        public Specialty GetSpecialityInfo(DataRow oRow)
        {
            DataTable oTable = new DataTable();
            Specialty oItem = new Specialty();
            try
            {
                oItem.ID.SetID(oRow["SpID"]);
                oItem.SpID = Convert.ToInt32(oRow["SpID"]);
                oItem.SpCode = oRow["SpCode"].ToString();
                oItem.SpDesc = oRow["SpDesc"].ToString();
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

        public Specialtys GetSpecialityInfos(int nMaxVersion, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            Specialty oItem = new Specialty();
            Specialtys oItems = new Specialtys();
            try
            {
                oTable = GetSpecialityInfo(nMaxVersion, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new Specialty();
                        oItem = GetSpecialityInfo(oRow);
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
