using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.BusinessLogic
{
    public partial class BLGimmickInfo
    {
        private GimmickInfo ReaderToObject(IDataReader oReader)
        {
            GimmickInfo oItem = new GimmickInfo();
            oItem.ID.SetID(oReader["GimmickID"]);
            oItem.Description = oReader["Description"].ToString();
            oItem.LineID = oReader["LineID"].ToString();
            oItem.Quantity = Convert.ToInt32(oReader["Quantity"]);
            oItem.Month = Convert.ToInt32(oReader["Month"]);
            oItem.Year = Convert.ToInt32(oReader["Year"]);
            oItem.CreationDate = Convert.ToDateTime(oReader["CreationDate"]);
            oItem.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
            return oItem;
        }
        private GimmickInfos ReaderToObjects(IDataReader oReader)
        {
            GimmickInfos oItems;
            GimmickInfo oItem;
            oItems = new GimmickInfos();
            if (oReader.IsClosed) return oItems;
            while (oReader.Read())
            {
                oItem = ReaderToObject(oReader);
                oItems.Add(oItem);
            }
            oReader.Close();
            return oItems;
        }
        public GimmickInfos GetGimmickInfos()
        {
            GimmickInfos oGimmickInfos;
            DLGimmickInfo oDL = new DLGimmickInfo();
            try
            {
                oGimmickInfos = ReaderToObjects(oDL.GetGimmickInfos());
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return oGimmickInfos;
        }
        public GimmickInfo GetGimmickInfo(int nID)
        {
            GimmickInfo oGimmickInfo = new GimmickInfo();
            DLGimmickInfo oDL = new DLGimmickInfo();
            IDataReader oReader;
            try
            {
                oReader = oDL.GetGimmickInfo(nID);
                if (oReader.Read())
                {
                    oGimmickInfo = ReaderToObject(oReader);
                }
                oReader.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oGimmickInfo;
        }

        public DataTable GetGimmickInfoTableByProduct(string sGimName, int nMonth, int nYear, string sConnectionString)
        {

            DataTable oTable = new DataTable();
            DLGimmickInfo oDL = new DLGimmickInfo();
            try
            {
                oTable = oDL.GetGimmickInfoTableByProduct(sGimName, nMonth, nYear, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }



        public int GetGimmickID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sGimmick1Name, string sTerritoryName, string sBrandName, int nMonth, int nYear)
        {
            Int32 nMaxSMSOrderID;
            DLGimmickInfo oDL = new DLGimmickInfo();
            try
            {
                nMaxSMSOrderID = oDL.GetGimmickID(oSqlConnection, oSqlTransaction, sGimmick1Name, sTerritoryName, sBrandName, nMonth, nYear);
                return nMaxSMSOrderID;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }
    }
}
