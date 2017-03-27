using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.BusinessObjects;
using FAST.Core;
using FAST.Core.DataAccess;

namespace FAST.DataLogic
{
	public partial class DLSampleInfo: DAAccess
	{
		//public bool IsDuplicate(string sSampleInfoName)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [SampleInfo] WHERE SampleInfoName=%s ", sSampleInfoName);
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
		//public bool IsDuplicate(string sSampleInfoName, int nID)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [SampleInfo] WHERE SampleInfoName=%s AND SampleID!= %n ", sSampleInfoName, nID);
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
		//public IDataReader GetSampleInfo(string sSampleInfoName)
		//{
			//string sSQL = "";
			//IDataReader oReader;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT * FROM [SampleInfo] WHERE [SampleInfoName]=%s ", sSampleInfoName);
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
