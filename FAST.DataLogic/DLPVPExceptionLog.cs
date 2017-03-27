using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;

namespace FAST.DataLogic
{
	public partial class DLPVPExceptionLog: DAAccess
	{
		//public bool IsDuplicate(string sPVPExceptionLogName)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [PVPExceptionLog] WHERE PVPExceptionLogName=%s ", sPVPExceptionLogName);
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
		//public bool IsDuplicate(string sPVPExceptionLogName, int nID)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [PVPExceptionLog] WHERE PVPExceptionLogName=%s AND ExceptionID!= %n ", sPVPExceptionLogName, nID);
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
		//public IDataReader GetPVPExceptionLog(string sPVPExceptionLogName)
		//{
			//string sSQL = "";
			//IDataReader oReader;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT * FROM [PVPExceptionLog] WHERE [PVPExceptionLogName]=%s ", sPVPExceptionLogName);
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
