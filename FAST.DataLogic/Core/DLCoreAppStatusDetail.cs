using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core.DataAccess;
using System.Data.SqlClient;
namespace FAST.DataLogic
{
	public partial class DLAppStatusDetail: DAAccess
	{
		public void Insert(AppStatusDetail oItem)
		{
			string sSQL = "";
			try
			{
				oItem.ID.SetID(GeneratePrimaryKey("[AppStatusDetail]", "AppStatusID"));
                sSQL = SQL.MakeSQL("INSERT INTO [AppStatusDetail](AppStatusID, TerritoryID, AppVersion, StorageSpace, UsedSpace, FreeSpace, VideoData, MusicData, InternetAvailable, DataConnection, WiFiConnection, GPS, Latitude, Longitude, LastUpdatedDate) "
                + " VALUES(%n, %s, %n, %s, %s, %s, %s, %s, %s, %s, %s, %s, %n, %n, %D) "
                , oItem.ID.ToInt32, oItem.TerritoryID, oItem.AppVersion, oItem.StorageSpace, oItem.UsedSpace, oItem.FreeSpace, oItem.VideoData, oItem.MusicData, oItem.InternetAvailable, oItem.DataConnection, oItem.WiFiConnection, oItem.GPS, oItem.Latitude, oItem.Longitude, oItem.LastUpdatedDate);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(AppStatusDetail oItem)
		{
			string sSQL = "";
			try
			{
                sSQL = SQL.MakeSQL("UPDATE [AppStatusDetail] SET TerritoryID = %s, AppVersion = %n, StorageSpace = %s, UsedSpace = %s, FreeSpace = %s, VideoData = %s, MusicData = %s, InternetAvailable = %s, DataConnection = %s, WiFiConnection = %s, GPS = %s, Latitude = %n, Longitude = %n, LastUpdatedDate = %D WHERE [AppStatusID]=%n"
                , oItem.TerritoryID, oItem.AppVersion, oItem.StorageSpace, oItem.UsedSpace, oItem.FreeSpace, oItem.VideoData, oItem.MusicData, oItem.InternetAvailable, oItem.DataConnection, oItem.WiFiConnection, oItem.GPS, oItem.Latitude, oItem.Longitude, oItem.LastUpdatedDate, oItem.ID.ToInt32);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nAppStatusDetailID)
		{
			string sSQL = "";
			try
			{
				sSQL = SQL.MakeSQL("DELETE FROM [AppStatusDetail] WHERE [AppStatusID]=%n"
				, nAppStatusDetailID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetAppStatusDetail(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [AppStatusDetail] WHERE AppStatusID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetAppStatusDetails()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
				sSQL = SQL.MakeSQL("SELECT * FROM [AppStatusDetail] ");
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}

        public int GetAppStatusID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nID = 0;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SElECT MAX(AppStatusID)+ 1 AppStatusID FROM AppStatusDetail");
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nID = 1;
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

        public int Insert(AppStatusDetail oItem, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                int nAppStatusID = GetAppStatusID(oSqlConnection, oSqlTransaction);
                oItem.ID.SetID(nAppStatusID);
                sSQL = SQL.MakeSQL("INSERT INTO [AppStatusDetail](AppStatusID, TerritoryID, AppVersion, StorageSpace, UsedSpace, FreeSpace, VideoData, MusicData, InternetAvailable, DataConnection, WiFiConnection, GPS, Latitude, Longitude, LastUpdatedDate) "
                + " VALUES(%n, %s, %n, %s, %s, %s, %s, %s, %s, %s, %s, %s, %n, %n, %D) "
                , oItem.ID.ToInt32, oItem.TerritoryID, oItem.AppVersion, oItem.StorageSpace, oItem.UsedSpace, oItem.FreeSpace, oItem.VideoData, oItem.MusicData, oItem.InternetAvailable, oItem.DataConnection, oItem.WiFiConnection, oItem.GPS, oItem.Latitude, oItem.Longitude, oItem.LastUpdatedDate);
                SqlDataAdapter InvAdapter = new SqlDataAdapter();
                SqlCommand InvCommand = new SqlCommand();
                InvCommand = new SqlCommand(sSQL, oSqlConnection);
                InvCommand.Transaction = oSqlTransaction;
                InvAdapter.InsertCommand = InvCommand;
                int i = InvCommand.ExecuteNonQuery();
                return i;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int Update(AppStatusDetail oItem, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sSQL = "";
            try
            {
                sSQL = SQL.MakeSQL("UPDATE [AppStatusDetail] SET TerritoryID = %s, AppVersion= %n, StorageSpace = %s, UsedSpace = %s, FreeSpace = %s, VideoData = %s, MusicData = %s, InternetAvailable = %s, DataConnection = %s, WiFiConnection = %s, GPS = %s, Latitude = %n, Longitude = %n, LastUpdatedDate = %D WHERE [AppStatusID]=%n"
                , oItem.TerritoryID, oItem.AppVersion, oItem.StorageSpace, oItem.UsedSpace, oItem.FreeSpace, oItem.VideoData, oItem.MusicData, oItem.InternetAvailable, oItem.DataConnection, oItem.WiFiConnection, oItem.GPS, oItem.Latitude, oItem.Longitude, oItem.LastUpdatedDate, oItem.ID.ToInt32);
                SqlDataAdapter InvAdapter = new SqlDataAdapter();
                SqlCommand InvCommand = new SqlCommand();
                InvCommand = new SqlCommand(sSQL, oSqlConnection);
                InvCommand.Transaction = oSqlTransaction;
                InvAdapter.UpdateCommand = InvCommand;
                int i = InvCommand.ExecuteNonQuery();
                return i;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
	}
}
