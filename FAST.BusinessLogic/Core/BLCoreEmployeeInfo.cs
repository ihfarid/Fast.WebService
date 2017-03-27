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
	public partial class BLEmployeeInfo
	{
        private EmployeeInfo ReaderToObject(IDataReader oReader)
        {
            EmployeeInfo oItem = new EmployeeInfo();
            oItem.ID.SetID(oReader["EmployeeID"]);
            oItem.EmpCode = oReader["EmpCode"].ToString();
            oItem.Name = oReader["Name"].ToString();
            oItem.GDDBID = oReader["GDDBID"].ToString();
            oItem.TerritoryID = Convert.ToInt32(oReader["TerritoryID"]);
            oItem.MobileNo = oReader["MobileNo"].ToString();
            oItem.BeginningDate = Convert.ToDateTime(oReader["BeginningDate"]);
            oItem.EndDate = Convert.ToDateTime(oReader["EndDate"]);
            oItem.IsActive = Convert.ToBoolean(oReader["IsActive"]);
            if (!oReader["BU"].Equals(DBNull.Value))
            {
                oItem.BU = oReader["BU"].ToString();
            }
            return oItem;
        }
		
		private EmployeeInfos ReaderToObjects(IDataReader oReader)
		{
			EmployeeInfos oItems;
			EmployeeInfo oItem;
            try
            {
                oItems = new EmployeeInfos();
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
		public EmployeeInfos GetEmployeeInfos()
		{
			EmployeeInfos oEmployeeInfos;
			DLEmployeeInfo oDL = new DLEmployeeInfo();
			try
			{
				oEmployeeInfos = ReaderToObjects(oDL.GetEmployeeInfos());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oEmployeeInfos;
		}
		public EmployeeInfo GetEmployeeInfo(int nID)
		{
			EmployeeInfo oEmployeeInfo = new EmployeeInfo();
			DLEmployeeInfo oDL = new DLEmployeeInfo();
			IDataReader oReader = null;
			try
			{
				oReader = oDL.GetEmployeeInfo(nID);
				if (oReader.Read())
				{
					oEmployeeInfo = ReaderToObject(oReader);
				}
				oReader.Close();
			}
            catch (Exception ex)
            {
                oReader.Close();
                throw new Exception(ex.Message);
            }
			return oEmployeeInfo;
		}

        public string GetGDDBIDByTerritoryID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sTerritoryID)
        {
            string sGDDBID;
            DLEmployeeInfo oDL = new DLEmployeeInfo();
            try
            {
                sGDDBID = oDL.GetGDDBIDByTerritoryID(oSqlConnection, oSqlTransaction, sTerritoryID);
                return sGDDBID;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public EmployeeInfo GetEmployeeInfo(string sGDDBID, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            EmployeeInfo oItem = new EmployeeInfo();
            try
            {
                oTable = GetActiveEmployeeInfo(sGDDBID, sConnectionString);

                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem.ID.SetID(oRow["EmployeeID"]);
                    oItem.EmpCode = oRow["EmpCode"].ToString();
                    oItem.Name = oRow["Name"].ToString();
                    oItem.GDDBID = oRow["GDDBID"].ToString();
                    oItem.TerritoryID = Convert.ToInt32(oRow["TerritoryID"]);
                    oItem.MobileNo = oRow["MobileNo"].ToString();
                    oItem.BeginningDate = Convert.ToDateTime(oRow["BeginningDate"]);
                    oItem.EndDate = Convert.ToDateTime(oRow["EndDate"]);
                    oItem.IsActive = Convert.ToBoolean(oRow["IsActive"]);
                    if (!oRow["BU"].Equals(DBNull.Value))
                    {
                        oItem.BU = oRow["BU"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public EmployeeInfo GetEmployeeInfo(DataRow oRow)
        {
            DataTable oTable = new DataTable();
            EmployeeInfo oItem = new EmployeeInfo();
            try
            {
                oItem.ID.SetID(oRow["EmployeeID"]);
                oItem.EmpCode = oRow["EmpCode"].ToString();
                oItem.Name = oRow["Name"].ToString();
                oItem.GDDBID = oRow["GDDBID"].ToString();
                oItem.TerritoryID = Convert.ToInt32(oRow["TerritoryID"]);
                if (!oRow["MobileNo"].Equals(DBNull.Value))
                {
                    oItem.MobileNo = oRow["MobileNo"].ToString();
                }
                oItem.BeginningDate = Convert.ToDateTime(oRow["BeginningDate"]);
                oItem.EndDate = Convert.ToDateTime(oRow["EndDate"]);
                oItem.IsActive = Convert.ToBoolean(oRow["IsActive"]);
                if (!oRow["BU"].Equals(DBNull.Value))
                {
                    oItem.BU = oRow["BU"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }


        public EmployeeInfos GetEmployeeInfos(string sGDDBID, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            EmployeeInfo oItem = new EmployeeInfo();
            EmployeeInfos oItems = new EmployeeInfos();
            try
            {
                oTable = GetActiveEmployeeInfo(sGDDBID, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new EmployeeInfo();
                        oItem = GetEmployeeInfo(oRow);
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
