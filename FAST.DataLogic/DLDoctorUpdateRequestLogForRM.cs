using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;

namespace FAST.DataLogic
{
	public partial class DLDoctorUpdateRequestLogForRM: DAAccess
	{
		//public bool IsDuplicate(string sDoctorUpdateRequestLogForRMName)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [DoctorUpdateRequestLogForRM] WHERE DoctorUpdateRequestLogForRMName=%s ", sDoctorUpdateRequestLogForRMName);
				//oCount = ExecuteScalar(sSQL);
				//if (Convert.ToInt32(oCount) > 0)
				//{
					//return true;
					//}
				//else
				//{
					//return false;
				//}
			//}
			//catch (Exception e)
				//{
				//throw new Exception(e.Message);
			//}
		//}
		//public bool IsDuplicate(string sDoctorUpdateRequestLogForRMName, int nID)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [DoctorUpdateRequestLogForRM] WHERE DoctorUpdateRequestLogForRMName=%s AND DoctorUpdateRequestID!= %n ", sDoctorUpdateRequestLogForRMName, nID);
				//oCount = ExecuteScalar(sSQL);
				//if (Convert.ToInt32(oCount) > 0)
				//{
					//return true;
				//}
				//else
				//{
					//return false;
				//}
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
		//}
		//public IDataReader GetDoctorUpdateRequestLogForRM(string sDoctorUpdateRequestLogForRMName)
		//{
			//string sSQL = "";
			//IDataReader oReader;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT * FROM [DoctorUpdateRequestLogForRM] WHERE [DoctorUpdateRequestLogForRMName]=%s ", sDoctorUpdateRequestLogForRMName);
				//oReader = ExecuteReader(sSQL);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
			//return oReader;
		//}
	}
}
