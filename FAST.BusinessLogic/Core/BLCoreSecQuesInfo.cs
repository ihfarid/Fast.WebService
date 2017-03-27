using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core;
using FAST.Core.DataAccess;

namespace FAST.BusinessLogic
{
	public partial class BLSecQuesInfo
	{
        private SecQuesInfo ReaderToObject(IDataReader oReader)
        {
            SecQuesInfo oItem = new SecQuesInfo();
            oItem.ID.SetID(oReader["SecQuesID"]);
            oItem.SecQues = oReader["SecQues"].ToString();
            oItem.Version = Convert.ToInt32(oReader["Version"]);
            oItem.ActionType = Convert.ToInt32(oReader["ActionType"]);
            oItem.EntryDate = Convert.ToDateTime(oReader["EntryDate"]);
            oItem.LastUpdateDate = Convert.ToDateTime(oReader["LastUpdateDate"]);
            return oItem;
        }

        public SecQuesInfo GetSecQuesInfoInfo(DataRow oRow)
        {
            SecQuesInfo oItem = new SecQuesInfo();
            try
            {
                oItem.ID.SetID(oRow["SecQuesID"]);
                oItem.SecQues = oRow["SecQues"].ToString();
                oItem.Version = Convert.ToInt32(oRow["Version"]);
                oItem.ActionType = Convert.ToInt32(oRow["ActionType"]);
                oItem.EntryDate = Convert.ToDateTime(oRow["EntryDate"]);
                oItem.LastUpdateDate = Convert.ToDateTime(oRow["LastUpdateDate"]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

		private SecQuesInfos ReaderToObjects(IDataReader oReader)
		{
			SecQuesInfos oItems;
			SecQuesInfo oItem;
            try
            {
                oItems = new SecQuesInfos();
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
		public SecQuesInfos GetSecQuesInfos()
		{
			SecQuesInfos oSecQuesInfos;
			DLSecQuesInfo oDL = new DLSecQuesInfo();
			try
			{
				oSecQuesInfos = ReaderToObjects(oDL.GetSecQuesInfos());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oSecQuesInfos;
		}
		public SecQuesInfo GetSecQuesInfo(int nID)
		{
			SecQuesInfo oSecQuesInfo = new SecQuesInfo();
			DLSecQuesInfo oDL = new DLSecQuesInfo();
			IDataReader oReader = null;
			try
			{
				oReader = oDL.GetSecQuesInfo(nID);
				if (oReader.Read())
				{
					oSecQuesInfo = ReaderToObject(oReader);
				}
				oReader.Close();
			}
            catch (Exception ex)
            {
                oReader.Close();
                throw new Exception(ex.Message);
            }
			return oSecQuesInfo;
		}

        public SecQuesInfos GetSecQuesInfos(string sConnectionString)
        {
            DataTable oTable = new DataTable();
            SecQuesInfo oItem = new SecQuesInfo();
            SecQuesInfos oItems = new SecQuesInfos();
            try
            {
                oTable = GetSecQuesInfoInfo(sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new SecQuesInfo();
                        oItem = GetSecQuesInfoInfo(oRow);
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
