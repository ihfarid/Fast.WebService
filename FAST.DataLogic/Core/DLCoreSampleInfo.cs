using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core;
using FAST.Core.DataAccess;
using System.Data.SqlClient;
namespace FAST.DataLogic
{
    public partial class DLSampleInfo : DAAccess
    {
        public void Insert(SampleInfo oItem)
        {
            string sSQL = "";
            try
            {
                oItem.ID.SetID(GeneratePrimaryKey("[SampleInfo]", "SampleID"));
                sSQL = SQL.MakeSQL("INSERT INTO [SampleInfo](SampleID, Description, LineID, Quantity, Month, Year, CreationDate, CreatedBy) "
                + " VALUES(%n, %s, %s, %n, %n, %n, %d, %n) "
                , oItem.ID.ToInt32, oItem.Description, oItem.LineID, oItem.Quantity, oItem.Month, oItem.Year, oItem.CreationDate, oItem.CreatedBy);
                ExecuteNonQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Update(SampleInfo oItem)
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL("UPDATE [SampleInfo] SET  Description = %s, LineID = %s, Quantity = %n, Month = %n, Year = %n, CreationDate = %d, CreatedBy = %n WHERE [SampleID]=%n"
                , oItem.Description, oItem.LineID, oItem.Quantity, oItem.Month, oItem.Year, oItem.CreationDate, oItem.CreatedBy, oItem.ID.ToInt32);
                ExecuteNonQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Delete(int nSampleInfoID)
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL("DELETE FROM [SampleInfo] WHERE [SampleID]=%n"
                , nSampleInfoID);
                ExecuteNonQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public IDataReader GetSampleInfo(int nID)
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                sSQL = SQL.MakeSQL("SELECT * FROM [SampleInfo] WHERE SampleID=%n", nID);
                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }
        public IDataReader GetSampleInfos()
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                sSQL = SQL.MakeSQL("SELECT * FROM [SampleInfo] ");
                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }

        public DataTable GetSampleInfoTableByProduct(string sSapleName, int nMonth, int nYear, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL(@"SELECT * FROM [SampleInfo] WHERE [Description]= %s AND 
                               Month = %nh  AND Year = %n AND IsActive = 1", sSapleName, nMonth, nYear);

//                string sSQL = @"SELECT * FROM [SampleInfo] WHERE [Description]= @sSapleName AND 
//                               Month = @nMonth  AND Year = @nYear AND IsActive = 1";
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
               // oSqlDataAdapter.SelectCommand.Parameters.Add("@sSapleName", sSapleName);
               // oSqlDataAdapter.SelectCommand.Parameters.Add("@nMonth", nMonth);
                //oSqlDataAdapter.SelectCommand.Parameters.Add("@nYear", nYear);
                oSqlDataAdapter.Fill(oTable);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;

        }

        public int GetSampleID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sSampleName, string sTerritoryName, string sBrandName, int nMonth, int nYear)
        {
            int nID = 0;
            string sSQL = "";
            try
            {
                SqlCommand cmd = new SqlCommand();
                //sSQL = SQL.MakeSQL("SElECT SampleID FROM [SampleInfo] WHERE [Description]= %s AND " +
                //                  "LineID = (SELECT LineID FROM [Territory] WHERE [TerritoryID] = %s)" +
                //                  " AND [Month] = %n AND [Year] = %n", sSampleName, sTerritoryName, nMonth, nYear);
                sSQL = SQL.MakeSQL("SElECT SampleID FROM [SampleTerritoryMapping] WHERE SampleName = %s AND " +
                                 " [TerritoryCode] = %s AND [BrandName] = (SELECT Distinct ProdCode FROM Product WHERE ProdName = %s) " +
                                 " AND [Month] = %n AND [Year] = %n", sSampleName, sTerritoryName, sBrandName, nMonth, nYear);

                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nID = 0;
                }
                else
                {
                    nID = Convert.ToInt32(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nID;
        }
    }
}
