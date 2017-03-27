using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core.DataAccess;
using System.Data.SqlClient;
namespace FAST.DataLogic
{
    public partial class DLGimmickInfo : DAAccess
    {
        public void Insert(GimmickInfo oItem)
        {
            string sSQL = "";
            try
            {
                oItem.ID.SetID(GeneratePrimaryKey("[GimmickInfo]", "GimmickID"));
                sSQL = SQL.MakeSQL("INSERT INTO [GimmickInfo](GimmickID, Description, LineID, Quantity, Month, Year, CreationDate, CreatedBy) "
                + " VALUES(%n, %s, %s, %n, %n, %n, %d, %n) "
                , oItem.ID.ToInt32, oItem.Description, oItem.LineID, oItem.Quantity, oItem.Month, oItem.Year, oItem.CreationDate, oItem.CreatedBy);
                ExecuteNonQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Update(GimmickInfo oItem)
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL("UPDATE [GimmickInfo] SET  Description = %s, LineID = %s, Quantity = %n, Month = %n, Year = %n, CreationDate = %d, CreatedBy = %n WHERE [GimmickID]=%n"
                , oItem.Description, oItem.LineID, oItem.Quantity, oItem.Month, oItem.Year, oItem.CreationDate, oItem.CreatedBy, oItem.ID.ToInt32);
                ExecuteNonQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Delete(int nGimmickInfoID)
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL("DELETE FROM [GimmickInfo] WHERE [GimmickID]=%n"
                , nGimmickInfoID);
                ExecuteNonQuery(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public IDataReader GetGimmickInfo(int nID)
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                sSQL = SQL.MakeSQL("SELECT * FROM [GimmickInfo] WHERE GimmickID=%n", nID);
                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }
        public IDataReader GetGimmickInfos()
        {
            string sSQL = "";
            IDataReader oReader;
            try
            {
                sSQL = SQL.MakeSQL("SELECT * FROM [GimmickInfo] ");
                oReader = ExecuteReader(sSQL);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oReader;
        }

        public DataTable GetGimmickInfoTableByProduct(string sGimName, int nMonth, int nYear, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL(@"SELECT * FROM [GimmickInfo] WHERE [Description]=%s AND 
                               Month = %n  AND Year = %n AND IsActive = 1", sGimName, nMonth, nYear);
//                string sSQL = @"SELECT * FROM [GimmickInfo] WHERE [Description]=@sGimName AND 
//                               Month = @nMonth  AND Year = @nYear AND IsActive = 1";
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                //oSqlDataAdapter.SelectCommand.Parameters.Add("@sGimName", sGimName);
                //oSqlDataAdapter.SelectCommand.Parameters.Add("@nMonth", nMonth);
                //oSqlDataAdapter.SelectCommand.Parameters.Add("@nYear", nYear);
                oSqlDataAdapter.Fill(oTable);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;

        }

        public int GetGimmickID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sGimmikName, string sTerritoryName, string sBrandName, int nMonth, int nYear)
        {
            int nID = 0;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();

                sSQL = SQL.MakeSQL("SElECT GimmickID FROM [GimmickTerritoryMapping] WHERE GimmickName = %s AND " +
                                  " [TerritoryCode] = %s AND [BrandName] = (SELECT Distinct ProdCode FROM Product WHERE ProdName = %s) " +
                                  " AND [Month] = %n AND [Year] = %n", sGimmikName, sTerritoryName, sBrandName, nMonth, nYear);
                //sSQL = SQL.MakeSQL("SElECT GimmickID FROM [GimmickInfo] WHERE [Description]= %s AND " +
                //                   " LineID = (SELECT LineID FROM [Territory] WHERE [TerritoryID] = %s)" +
                //                   " AND [Month] = %n AND [Year] = %n", sGimmikName, sTerritoryName, nMonth, nYear);

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
