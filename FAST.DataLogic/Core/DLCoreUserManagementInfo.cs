using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
	public partial class DLUserManagementInfo: DAAccess
	{
		public void Insert(UserManagementInfo oItem)
		{
			string sSQL = "";
			try
			{
                oItem.ID.SetID(GeneratePrimaryKey("[OrderCollectionSystem].[dbo].[UserManagementInfo]", "UserManagementID"));
                sSQL = SQL.MakeSQL("INSERT INTO [OrderCollectionSystem].[dbo].[UserManagementInfo](UserManagementID, MinimumPasswordLength, IsCapitalLetter, IsLowerLetter, IsNumericNumber, IsSpecialChar, MinimumPasswordAge) "
				+ " VALUES(%n, %n, %b, %b, %b, %b, %n) "
				, oItem.ID.ToInt32, oItem.MinimumPasswordLength,oItem.IsCapitalLetter,oItem.IsLowerLetter,oItem.IsNumericNumber,oItem.IsSpecialChar,oItem.MinimumPasswordAge);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Update(UserManagementInfo oItem)
		{
			string sSQL = "";
			try
			{
                sSQL = SQL.MakeSQL("UPDATE [OrderCollectionSystem].[dbo].[UserManagementInfo] SET MinimumPasswordLength = %n, IsCapitalLetter = %b, IsLowerLetter = %b, IsNumericNumber = %b, IsSpecialChar = %b, MinimumPasswordAge = %n WHERE [UserManagementID]=%n"
				,oItem.MinimumPasswordLength,oItem.IsCapitalLetter,oItem.IsLowerLetter,oItem.IsNumericNumber,oItem.IsSpecialChar,oItem.MinimumPasswordAge, oItem.ID.ToInt32);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nUserManagementInfoID)
		{
			string sSQL = "";
			try
			{
                sSQL = SQL.MakeSQL("DELETE FROM [OrderCollectionSystem].[dbo].[UserManagementInfo] WHERE [UserManagementID]=%n"
				, nUserManagementInfoID);
				ExecuteNonQuery(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		public IDataReader GetUserManagementInfo(int nID)
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
                sSQL = SQL.MakeSQL("SELECT * FROM [OrderCollectionSystem].[dbo].[UserManagementInfo] WHERE UserManagementID=%n", nID);
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}
		public IDataReader GetUserManagementInfos()
		{
			string sSQL = "";
			IDataReader oReader;
			try
			{
                sSQL = SQL.MakeSQL("SELECT * FROM [OrderCollectionSystem].[dbo].[UserManagementInfo]");
				oReader = ExecuteReader(sSQL);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oReader;
		}

	}
}
