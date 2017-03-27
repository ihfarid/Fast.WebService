using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.BusinessLogic
{
	public partial class BLDoctorTerritoryMapping
	{
		//public bool Validate(DoctorTerritoryMapping oItem)
		//{
			//DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.DoctorTerritoryMappingName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.DoctorTerritoryMappingName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(DoctorTerritoryMapping oItem)
		{
			DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
			//if (!Validate(oItem))
			//{
				//throw new Exception("DoctorTerritoryMapping with the same Name already exist");
			//}
			try
			{
				DAAccess.BeginTran();
				if (oItem.IsNew)
				{
					oDL.Insert(oItem);
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
			DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public DataTable GetDoctorDetail(string sTerritoryID, int nMaxVersion)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetDoctorDetail(sTerritoryID, nMaxVersion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public DataTable GetDoctorDetail(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetDoctorDetail(sTerritoryID, nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public DataTable GetDoctorDetailForRM(string sTerritoryID, int nMaxVersion)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetDoctorDetailForRM(sTerritoryID, nMaxVersion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public DataTable GetDoctorDetailForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetDoctorDetailForRM(sTerritoryID, nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public DataTable GetRouteInfo(string sTerritoryID, int nMaxVersion)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetRouteInfo(sTerritoryID, nMaxVersion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public DataTable GetRouteInfo(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetRouteInfo(sTerritoryID, nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public DataTable GetRouteInfoForRM(string sTerritoryID, int nMaxVersion)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetRouteInfoForRM(sTerritoryID, nMaxVersion);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public DataTable GetRouteInfoForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetRouteInfoForRM(sTerritoryID, nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public DataTable GetProductInfoForRM(int nMaxVersion, string sLine, string sConnectionString)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetProductInfoForRM(nMaxVersion, sLine, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public int AddLog(int nDoctorID, string sTerritoryID, int nStatus, string sReason, int nType, String sGDDBID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nResult;
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            try
            {
                nResult = oDL.AddLog(nDoctorID, sTerritoryID, nStatus, sReason, nType, sGDDBID, oSqlConnection, oSqlTransaction);
                return nResult;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public string UpdateMappingBySF(int nDocID, string sBMDCCode, int nSalutationID, int nSpecialtyID1, int nSpecialtyID2, int nDegreeID1, int nDegreeID2,
          string sInstitute, string sAddress1, string sAddress2, string sAddress3, int nDistrictID, string sDocName, int nUpazillaID, DateTime dBirthDay,
          int nStatus, DateTime dMrgday, string sMobileNo, string sEmail, string sTerritoryID, int nType, int nDocTypeID, int nMapAddress, int nMapSpeciality,
          int nMapDegree, int nProd1, int nProd2, int nProd3, int nProd4, int nProd5, int nProd6, int nProd7, int nProd8, int nProfileID, int nRouteID, int nSessionID, int nCallFre,
          int nSwajanStatus, string sCardAttachement, int nPstStpCng, string sGDDBID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sResult;
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            try
            {
                sResult = oDL.UpdateMappingBySF(nDocID,sBMDCCode,nSalutationID,  nSpecialtyID1, nSpecialtyID2, nDegreeID1, nDegreeID2,sInstitute,
                      sAddress1, sAddress2, sAddress3, nDistrictID, sDocName, nUpazillaID, dBirthDay, nStatus, dMrgday, sMobileNo, sEmail, sTerritoryID,
                      nType, nDocTypeID, nMapAddress, nMapSpeciality, nMapDegree, nProd1, nProd2, nProd3, nProd4, nProd5, nProd6, nProd7, nProd8, nProfileID, nRouteID, nSessionID,
                      nCallFre, nSwajanStatus,sCardAttachement, nPstStpCng, sGDDBID, oSqlConnection, oSqlTransaction);
                return sResult;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }


        public string AddNewDoctor(string sBMDCCode, string sTerritoryID, string sDocName, int nSwajanStatus, int nDocTypeID,
                    int nSalutationID, int nSpecialtyID1, int nSpecialtyID2, int nDegreeID1, int nDegreeID2, int nProfileID,
                    int nProd1, int nProd2, int nProd3, int nProd4, int nProd5, int nProd6, int nProd7, int nProd8, int nCallFre, string sInstitute,
                    string sAddress1, string sAddress2, string sAddress3, int nDistrictID, int nUpazillaID, int nRouteID,
                    int nSessionID, DateTime dBirthDay, DateTime dMrgday, string sMobileNo, string sEmail, string sCardAttachement,
                    int nStatus, int nType, int nMapAddress, int nMapSpeciality, int nMapDegree, int nPstStpCng, string sGDDBID, 
            SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sResult;
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            try
            {
                sResult = oDL.AddNewDoctor(sBMDCCode,sTerritoryID,sDocName,nSwajanStatus,nDocTypeID,nSalutationID,nSpecialtyID1,
                    nSpecialtyID2, nDegreeID1, nDegreeID2, nProfileID, nProd1, nProd2, nProd3, nProd4, nProd5, nProd6, nProd7, nProd8, nCallFre, sInstitute,
                    sAddress1, sAddress2, sAddress3, nDistrictID, nUpazillaID, nRouteID, nSessionID, dBirthDay, dMrgday, sMobileNo, sEmail,
                    sCardAttachement, nStatus, nType, nMapAddress, nMapSpeciality, nMapDegree, nPstStpCng,sGDDBID,oSqlConnection, oSqlTransaction);
                return sResult;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }


        public string AddExistingDoctor(int nDocID, string sTerritoryID, int nDocTypeID, int nSwajanStatus, int nProfileID,
                int nProd1, int nProd2, int nProd3, int nProd4, int nProd5, int nProd6, int nProd7, int nProd8, int nCallFre, int nRouteID, int nStatus,
                int nType, int sSessionID, int nMapAddress, int nMapSpeciality, int nMapDegree, int nPstStpCng, string sGDDBID,
                SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            string sResult;
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            try
            {
                sResult = oDL.AddExistingDoctor(nDocID,sTerritoryID,nDocTypeID,nSwajanStatus,nProfileID,nProd1,nProd2,nProd3,nProd4,
                    nProd5, nProd6, nProd7, nProd8, nCallFre, nRouteID, nStatus, nType, sSessionID, nMapAddress, nMapSpeciality, nMapDegree, nPstStpCng,
                    sGDDBID,oSqlConnection, oSqlTransaction);
                return sResult;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }



        public DataTable GetTerritoryDisUpaWiseAllDoctorListForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetTerritoryDisUpaWiseAllDoctorListForRM(sTerritoryID, nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public DataTable GetColumnInfo(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetColumnInfo(sTerritoryID, nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public int RouteUpdate(string sTerritoryID, string sNewRouteName, string sOldRouteName, int nStatus, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nResult;
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            try
            {
                nResult = oDL.RouteUpdate(sTerritoryID, sNewRouteName, sOldRouteName, nStatus, oSqlConnection, oSqlTransaction);
                return nResult;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public int RouteAdd(string sTerritoryID, string sRouteName, int nVersion, int nAction, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nResult;
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            try
            {
                nResult = oDL.RouteAdd(sTerritoryID, sRouteName, nVersion, nAction, oSqlConnection, oSqlTransaction);
                return nResult;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public int CheckRoute(string sTerritoryID, string sRouteName, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nResult;
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            try
            {
                nResult = oDL.CheckRoute(sTerritoryID, sRouteName, oSqlConnection, oSqlTransaction);
                return nResult;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public int GetDMRLock(string sTerritoryID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            int oCount;

            try
            {
                oCount = oDL.GetDMRLock(sTerritoryID, oSqlConnection, oSqlTransaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oCount;
        }

        public int GetDocCountFrRoute(string sTerritoryID, string sRouteName, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            int oCount;

            try
            {
                oCount = oDL.GetDocCountFrRoute(sTerritoryID, sRouteName, oSqlConnection, oSqlTransaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oCount;
        }

        public int GetMaxRouteVersion(string sTerritoryID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            int nVersion;

            try
            {
                nVersion = oDL.GetMaxRouteVersion(sTerritoryID, oSqlConnection, oSqlTransaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return nVersion;
        }

        public string GetLine(string sTerritoryID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            string oCount;

            try
            {
                oCount = oDL.GetLine(sTerritoryID, oSqlConnection, oSqlTransaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oCount;
        }

        public int GetTotalDoctor(string sTerritoryID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            int oCount;

            try
            {
                oCount = oDL.GetTotalDoctor(sTerritoryID, oSqlConnection, oSqlTransaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oCount;
        }

        public int GetDocCountPending(string sTerritoryID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            int oCount;

            try
            {
                oCount = oDL.GetDocCountPending(sTerritoryID, oSqlConnection, oSqlTransaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oCount;
        }

        public int GetDocCount(string sTerritoryID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            int oCount;

            try
            {
                oCount = oDL.GetDocCount(sTerritoryID, oSqlConnection, oSqlTransaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oCount;
        }


        public int GetRMPending(string sTerritoryID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            int oCount;

            try
            {
                oCount = oDL.GetRMPending(sTerritoryID, oSqlConnection, oSqlTransaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oCount;
        }


        public int GetSFEPending(string sTerritoryID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            int oCount;

            try
            {
                oCount = oDL.GetSFEPending(sTerritoryID, oSqlConnection, oSqlTransaction);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oCount;
        }


        public DataTable GetTerritoryDisUpaWiseAllDoctorList(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetTerritoryDisUpaWiseAllDoctorList(sTerritoryID, nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }


        public DataTable GetProductInfo(string sLineID, int nMaxVersion, string sConnectionString)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetProductInfo(sLineID,nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public DataTable GetDocTerrMappingInfo(int nDoctorID, string sTerritoryID, string sConnectionString)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetDocTerrMappingInfo(nDoctorID, sTerritoryID, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public int GetMaxDoctorVersion(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nMaxDoctorVersion;
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            try
            {
                nMaxDoctorVersion = oDL.GetMaxDoctorVersion(oSqlConnection, oSqlTransaction);
                return nMaxDoctorVersion;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public int Save(DoctorTerritoryMapping oItem, SqlConnection myConnection, SqlTransaction myTransaction)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
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

        public DataTable GetCompanyRxByQty(string sFrPID, string sConnectionString)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetCompanyRxByQty(sFrPID, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public DataTable GetCompanyRxByValue(string sFrPID, string sConnectionString)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetCompanyRxByValue(sFrPID, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public DataTable GetMoleculeRxList(string sFrPID, string sConnectionString)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetMoleculeRxList(sFrPID, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public int UpdateDoctorInfo(int nDocID, string sBMDCCode, string sDocName, int nSalutationID, int nSpecialtyID1,
            int nSpecialtyID2, int nDegreeID1, int nDegreeID2, string sInstitute, string sAddress1, string sAddress2,
            string sAddress3, int nDistrictID, int nUpazillaID, DateTime dBirthDay, DateTime dMrgday,
            string sMobileNo, string sEmail, string sCardAttachement, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nResult=0;
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            try
            {
                nResult = oDL.UpdateDoctorInfo(nDocID, sBMDCCode, sDocName, nSalutationID, nSpecialtyID1,nSpecialtyID2, 
                    nDegreeID1, nDegreeID2, sInstitute, sAddress1, sAddress2,sAddress3, nDistrictID, nUpazillaID, dBirthDay,
                    dMrgday,sMobileNo, sEmail, sCardAttachement, oSqlConnection, oSqlTransaction);
                return nResult;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public int InsertDocInfoUpdateLogForRM(int nDocID, int nDoctorTerritoryMappingID, string sBMDCCode, string sDocName, int nSalutationID,
            int nSpecialtyID1, int nSpecialtyID2, int nDegreeID1, int nDegreeID2, string sInstitute, string sAddress1, string sAddress2,
            string sAddress3, int nDistrictID, int nUpazillaID, DateTime dBirthDay, DateTime dMrgday, string sMobileNo, string sEmail, string sCardAttachement,
            SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nResult=0;
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            try
            {
                nResult = oDL.InsertDocInfoUpdateLogForRM(nDocID, nDoctorTerritoryMappingID, sBMDCCode, sDocName, nSalutationID, nSpecialtyID1, nSpecialtyID2,
                    nDegreeID1, nDegreeID2, sInstitute, sAddress1, sAddress2, sAddress3, nDistrictID, nUpazillaID, dBirthDay,
                    dMrgday, sMobileNo, sEmail, sCardAttachement, oSqlConnection, oSqlTransaction);
                return nResult;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public int UpdateDoctorStatus(int nDoctorID, SqlConnection myConnection, SqlTransaction myTransaction)
        {
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            int i = 0;
            try
            {
                i = oDL.UpdateDoctorStatus(nDoctorID, myConnection, myTransaction);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return i;
        }

        public int InsertParameterLog(string sTerritoryID, string sParameters, string sError, SqlConnection oSqlConnection)
        {
            int nResult;
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            try
            {
                nResult = oDL.InsertParameterLog(sTerritoryID, sParameters, sError, oSqlConnection);
                return nResult;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

        public int InsertDMRCommandInfo(string sTerritoryID, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nResult;
            DLDoctorTerritoryMapping oDL = new DLDoctorTerritoryMapping();
            try
            {
                nResult = oDL.InsertDMRCommandInfo(sTerritoryID, oSqlConnection, oSqlTransaction);
                return nResult;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }
    
		//public bool IsDuplicate(string sDoctorTerritoryMappingName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sDoctorTerritoryMappingName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sDoctorTerritoryMappingName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sDoctorTerritoryMappingName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
