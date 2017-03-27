using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.BusinessLogic
{
	public partial class BLDoctorUpdateRequest
	{
		//public bool Validate(DoctorUpdateRequest oItem)
		//{
			//DLDoctorUpdateRequest oDL = new DLDoctorUpdateRequest();
			//try
			//{
				//if (oItem.IsNew)
				//{
					//return !oDL.IsDuplicate(oItem.DoctorUpdateRequestName);
				//}
				//else
				//{
					//return !oDL.IsDuplicate(oItem.DoctorUpdateRequestName, oItem.ID.ToInt32);
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		public void Save(DoctorUpdateRequest oItem)
		{
			DLDoctorUpdateRequest oDL = new DLDoctorUpdateRequest();
			//if (!Validate(oItem))
			//{
				//throw new Exception("DoctorUpdateRequest with the same Name already exist");
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
			DLDoctorUpdateRequest oDL = new DLDoctorUpdateRequest();
			try
			{
				oDL.Delete(nID);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

        public DataTable GetDoctorUpdateRequestInfoForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            DLDoctorUpdateRequest oDL = new DLDoctorUpdateRequest();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetDoctorUpdateRequestInfoForRM(sTerritoryID, nMaxVersion, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public int Save(DoctorUpdateRequest oItem, SqlConnection myConnection, SqlTransaction myTransaction)
        {
            DLDoctorUpdateRequest oDL = new DLDoctorUpdateRequest();
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

        public DataTable GetDoctorUpdateRequestInfo(int nDoctorUpdateReqID, string sConnectionString)
        {
            DLDoctorUpdateRequest oDL = new DLDoctorUpdateRequest();
            DataTable oTable = new DataTable();
            try
            {
                oTable = oDL.GetDoctorUpdateRequestInfo(nDoctorUpdateReqID, sConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oTable;
        }

        public int GetMaxDoctorUpdateReqVersion(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nMaxDoctorUpdateReqVersion;
            DLDoctorUpdateRequest oDL = new DLDoctorUpdateRequest();
            try
            {
                nMaxDoctorUpdateReqVersion = oDL.GetMaxDoctorUpdateReqVersion(oSqlConnection, oSqlTransaction);
                return nMaxDoctorUpdateReqVersion;
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

		//public bool IsDuplicate(string sDoctorUpdateRequestName)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sDoctorUpdateRequestName);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sDoctorUpdateRequestName, int nID)
		//{
			//try
			//{
				//DLUser oDL = new DLUser();
				//return oDL.IsDuplicate(sDoctorUpdateRequestName, nID);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		}
	}
