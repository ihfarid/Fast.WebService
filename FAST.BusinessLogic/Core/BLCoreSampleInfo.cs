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
    public partial class BLSampleInfo
    {
        private SampleInfo ReaderToObject(IDataReader oReader)
        {
            SampleInfo oItem = new SampleInfo();
            oItem.ID.SetID(oReader["SampleID"]);
            oItem.Description = oReader["Description"].ToString();
            oItem.LineID = oReader["LineID"].ToString();
            oItem.Quantity = Convert.ToInt32(oReader["Quantity"]);
            oItem.Month = Convert.ToInt32(oReader["Month"]);
            oItem.Year = Convert.ToInt32(oReader["Year"]);
            oItem.CreationDate = Convert.ToDateTime(oReader["CreationDate"]);
            oItem.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
            return oItem;
        }
        private SampleInfos ReaderToObjects(IDataReader oReader)
        {
            SampleInfos oItems;
            SampleInfo oItem;
            oItems = new SampleInfos();
            if (oReader.IsClosed) return oItems;
            while (oReader.Read())
            {
                oItem = ReaderToObject(oReader);
                oItems.Add(oItem);
            }
            oReader.Close();
            return oItems;
        }
        public SampleInfos GetSampleInfos()
        {
            SampleInfos oSampleInfos;
            DLSampleInfo oDL = new DLSampleInfo();
            try
            {
                oSampleInfos = ReaderToObjects(oDL.GetSampleInfos());
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            return oSampleInfos;
        }
        public SampleInfo GetSampleInfo(int nID)
        {
            SampleInfo oSampleInfo = new SampleInfo();
            DLSampleInfo oDL = new DLSampleInfo();
            IDataReader oReader;
            try
            {
                oReader = oDL.GetSampleInfo(nID);
                if (oReader.Read())
                {
                    oSampleInfo = ReaderToObject(oReader);
                }
                oReader.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oSampleInfo;
        }


        public DataTable GetSampleInfoTableByProduct(string sSapleName, int nMonth, int nYear, string sConnectionString)
        {
            DLSampleInfo oDL = new DLSampleInfo();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetSampleInfoTableByProduct(sSapleName, nMonth, nYear, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }



        public int GetSampleID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sSampleName, string sTerritoryName, string sBrandName, int nMonth, int nYear)
        {
            Int32 nMaxSMSOrderID;
            DLSampleInfo oDL = new DLSampleInfo();
            try
            {
                nMaxSMSOrderID = oDL.GetSampleID(oSqlConnection, oSqlTransaction, sSampleName, sTerritoryName, sBrandName, nMonth, nYear);
                return nMaxSMSOrderID;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }
    }
}
