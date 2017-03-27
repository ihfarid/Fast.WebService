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
	public partial class BLSFRegiInfo
	{

        public int AuthenticateUser(string sGDDBID, string sEmpCode, string sTerritory)
        {
            EmployeeInfo oEmployeeInfo = new EmployeeInfo();
            Territory oTerritory = new Territory();
            BLEmployeeInfo oBL = new BLEmployeeInfo();
            BLTerritory oBLTerritory = new BLTerritory();

            oEmployeeInfo = oBL.GetEmployeeInfo(sEmpCode);
            oTerritory = oBLTerritory.GetTerritory(oEmployeeInfo.TerritoryID);
            if (oEmployeeInfo.ID.ToInt32 == 0)
                return 1;
            else if (oEmployeeInfo.ID.ToInt32 != 0)
            {
                if (!oEmployeeInfo.IsActive)
                    return 2;

                if (oEmployeeInfo.GDDBID.ToUpper() != sGDDBID.ToUpper())
                    return 3;

                if (oTerritory.TerritoryCode.ToUpper() != sTerritory.ToUpper())
                    return 4;

                //if (oEmployeeInfo.MobileNo != sMobileNo)
                //    return 5;
            }

            return -1;
        }

        public bool IsDuplicate(string sGDDBID)
        {
            DLSFRegiInfo oDL = new DLSFRegiInfo();
            try
            {
                return oDL.IsDuplicate(sGDDBID);
            }

            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public SFRegiInfo GetActiveSFInfoByGDDBID(string sGDDBID)
        {
            SFRegiInfo oSFRegiInfo = new SFRegiInfo();
            DLSFRegiInfo oDL = new DLSFRegiInfo();
            IDataReader oReader;
            try
            {
                oReader = oDL.GetActiveSFInfoByGDDBID(sGDDBID);
                
                try
                {
                    if (oReader.Read())
                    {
                        oSFRegiInfo = ReaderToObject(oReader);
                    }

                    oReader.Close();
                }
                catch (Exception ex)
                {
                    oReader.Close();
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oSFRegiInfo;
        }

        public SFRegiInfo GetSFInfoByGDDBID(string sGDDBID)
        {
            SFRegiInfo oSFRegiInfo = new SFRegiInfo();
            DLSFRegiInfo oDL = new DLSFRegiInfo();
            IDataReader oReader = null;
            try
            {
                oReader = oDL.GetSFInfoByGDDBID(sGDDBID);
                
                try
                {
                    if (oReader.Read())
                    {
                        oSFRegiInfo = ReaderToObject(oReader);
                    }
                    
                    oReader.Close();
                }
                catch (Exception ex)
                {
                    oReader.Close();
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oSFRegiInfo;
        }

        public SFRegiInfo NewGetSFInfoByGDDBID(string sGDDBID)
        {
            SFRegiInfo oSFRegiInfo = new SFRegiInfo();
            DLSFRegiInfo oDL = new DLSFRegiInfo();
            IDataReader oReader = null;
            bool bNextResult = true;
            try
            {
                oReader = oDL.GetSFInfoByGDDBID(sGDDBID);

                try
                {
                    while (bNextResult == true)
                    {
                        if (oReader.Read())
                        {
                            oSFRegiInfo = ReaderToObject(oReader);
                        }
                        bNextResult = oReader.NextResult();
                    }

                    oReader.Close();
                    
                }
                catch (Exception ex)
                {
                    oReader.Close();
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oSFRegiInfo;
        }

        public SFRegiInfo GetSFInfoByMobileNo(string sMobNo)
        {
            SFRegiInfo oSFRegiInfo = new SFRegiInfo();
            DLSFRegiInfo oDL = new DLSFRegiInfo();
            IDataReader oReader;
            try
            {
                oReader = oDL.GetSFInfoByMobileNo(sMobNo);
                try
                {
                    if (oReader.Read())
                    {
                        oSFRegiInfo = ReaderToObject(oReader);
                    }

                    oReader.Close();
                }
                catch (Exception ex)
                {
                    oReader.Close();
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oSFRegiInfo;
        }
        public DataTable GetActiveSFRegInfo(string sGDDBID)
        {
            DLSFRegiInfo oDL = new DLSFRegiInfo();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetActiveSFRegInfo(sGDDBID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public DataTable GetActiveSFRegInfo(string sGDDBID, string sConnectionString)
        {
            DLSFRegiInfo oDL = new DLSFRegiInfo();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetActiveSFRegInfo(sGDDBID, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public bool SFPasswordUpdate(string sGDDBID, string sPassword)
        {
            bool bAuthenticket = false;
            DLSFRegiInfo oDL = new DLSFRegiInfo();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.SFPasswordUpdate(sGDDBID, sPassword);
                if (oTable.Rows.Count > 0)
                    bAuthenticket = true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return bAuthenticket;
        }

        public int Save(SFRegiInfo oItem, SqlConnection myConnection, SqlTransaction myTransaction)
        {
            DLSFRegiInfo oDL = new DLSFRegiInfo();
            int i = 0;
            try
            {
                if (oItem.IsNew)
                {
                    i = oDL.Insert(oItem, myConnection, myTransaction);
                }
                else
                {
                    i = oDL.Update(oItem, myConnection, myTransaction);
                }
            }
            catch (Exception e)
            {
                i = 0;
                throw new Exception(e.Message);
            }
            return i;
        }

        public DataTable GetSFInfoByGDDBID(string sGDDBID, string sConnectionString)
        {
            DLSFRegiInfo oDL = new DLSFRegiInfo();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetSFInfoByGDDBID(sGDDBID, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        //public bool Validate(SFRegiInfo oItem)
		//{
			//DLSFRegiInfo oDL = new DLSFRegiInfo();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.SFRegiInfoName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.SFRegiInfoName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(SFRegiInfo oItem)
		{
			DLSFRegiInfo oDL = new DLSFRegiInfo();
			//if (!Validate(oItem))
			//{
				//throw new Exception("SFRegiInfo with the same Name already exist");
			//}
			try
			{
				DAAccess.BeginTran();
				if (oItem.IsNew)
				{
                  //  oDL.BeginDistributedTransaction();
                    oDL.InsertDB(oItem);
                  //  oDL.EndDistributedTransaction();
				}
				else
				{
					oDL.Update(oItem);
				}
				DAAccess.CommitTran();
			}
			catch (Exception e)
			{
				DAAccess.RollBackTran();
				throw new Exception(e.Message);
			}
		}
		public void Delete(int nID)
		{
			DLSFRegiInfo oDL = new DLSFRegiInfo();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public int GetSFRegiID(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nMaxSFRegiID;
            DLSFRegiInfo oDL = new DLSFRegiInfo();
            try
            {
                nMaxSFRegiID = oDL.GetSFRegiID(oSqlConnection, oSqlTransaction);
                return nMaxSFRegiID;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public int GetCustomerVersion(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sTerritoryID)
        {
            int nMaxCustomerVersion;
            DLSFRegiInfo oDL = new DLSFRegiInfo();
            try
            {
                nMaxCustomerVersion = oDL.GetCustomerVersion(oSqlConnection, oSqlTransaction, sTerritoryID);
                return nMaxCustomerVersion;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public int GetProductVersion(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction, string sTerritoryID)
        {
            int nMaxProductVersion;
            DLSFRegiInfo oDL = new DLSFRegiInfo();
            try
            {
                nMaxProductVersion = oDL.GetProductVersion(oSqlConnection, oSqlTransaction, sTerritoryID);
                return nMaxProductVersion;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }
		
        //public bool IsDuplicate(string sSFRegiInfoName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sSFRegiInfoName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sSFRegiInfoName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sSFRegiInfoName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
