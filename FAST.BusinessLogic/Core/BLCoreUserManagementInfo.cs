using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;

namespace FAST.BusinessLogic
{
	public partial class BLUserManagementInfo
	{
        private UserManagementInfo ReaderToObject(IDataReader oReader)
        {
            UserManagementInfo oItem = new UserManagementInfo();
            oItem.ID.SetID(oReader["UserManagementID"]);
            //oItem.UserManagementID = Convert.ToInt32(oReader["UserManagementID"]);
            oItem.MinimumPasswordLength = Convert.ToInt32(oReader["MinimumPasswordLength"]);
            oItem.IsCapitalLetter = Convert.ToBoolean(oReader["IsCapitalLetter"]);
            oItem.IsLowerLetter = Convert.ToBoolean(oReader["IsLowerLetter"]);
            oItem.IsNumericNumber = Convert.ToBoolean(oReader["IsNumericNumber"]);
            oItem.IsSpecialChar = Convert.ToBoolean(oReader["IsSpecialChar"]);
            oItem.MinimumPasswordAge = Convert.ToInt32(oReader["MinimumPasswordAge"]);
            return oItem;
        }
		
		private UserManagementInfos ReaderToObjects(IDataReader oReader)
		{
			UserManagementInfos oItems;
			UserManagementInfo oItem;
            try
            {
                oItems = new UserManagementInfos();
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
		public UserManagementInfos GetUserManagementInfos()
		{
			UserManagementInfos oUserManagementInfos;
			DLUserManagementInfo oDL = new DLUserManagementInfo();
			try
			{
				oUserManagementInfos = ReaderToObjects(oDL.GetUserManagementInfos());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oUserManagementInfos;
		}
		public UserManagementInfo GetUserManagementInfo(int nID)
		{
			UserManagementInfo oUserManagementInfo = new UserManagementInfo();
			DLUserManagementInfo oDL = new DLUserManagementInfo();
			IDataReader oReader = null;
			try
			{
				oReader = oDL.GetUserManagementInfo(nID);
				if (oReader.Read())
				{
					oUserManagementInfo = ReaderToObject(oReader);
				}
				oReader.Close();
			}
            catch (Exception ex)
            {
                oReader.Close();
                throw new Exception(ex.Message);
            }
			return oUserManagementInfo;
		}

        public UserManagementInfo GetUserManagementInfo(DataRow oRow)
        {
            UserManagementInfo oItem = new UserManagementInfo();
            try
            {
                oItem.ID.SetID(oRow["UserManagementID"]);
                //oItem.UserManagementID = Convert.ToInt32(oReader["UserManagementID"]);
                oItem.MinimumPasswordLength = Convert.ToInt32(oRow["MinimumPasswordLength"]);
                oItem.IsCapitalLetter = Convert.ToBoolean(oRow["IsCapitalLetter"]);
                oItem.IsLowerLetter = Convert.ToBoolean(oRow["IsLowerLetter"]);
                oItem.IsNumericNumber = Convert.ToBoolean(oRow["IsNumericNumber"]);
                oItem.IsSpecialChar = Convert.ToBoolean(oRow["IsSpecialChar"]);
                oItem.MinimumPasswordAge = Convert.ToInt32(oRow["MinimumPasswordAge"]);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public UserManagementInfo GetUserManagementInfo(string sConnectionString)
        {
            DataTable oTable = new DataTable();
            UserManagementInfo oItem = new UserManagementInfo();
            try
            {
                oTable = GetUserManagement(sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem = GetUserManagementInfo(oRow);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public UserManagementInfos GetUserManagementInfos(string sConnectionString)
        {
            DataTable oTable = new DataTable();
            UserManagementInfo oItem = new UserManagementInfo();
            UserManagementInfos oItems = new UserManagementInfos();
            try
            {
                oTable = GetUserManagement(sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new UserManagementInfo();
                        oItem = GetUserManagementInfo(oRow);
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
