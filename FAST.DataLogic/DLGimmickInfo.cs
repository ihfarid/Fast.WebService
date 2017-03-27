using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.BusinessObjects;
using FAST.Core;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
    public partial class DLGimmickInfo : DAAccess
    {
        //public bool IsDuplicate(string sGimmickInfoName)
        //{
        //string sSQL = "";
        //object oCount;
        //try
        //{
        //sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [GimmickInfo] WHERE GimmickInfoName=%s ", sGimmickInfoName);
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
        //public bool IsDuplicate(string sGimmickInfoName, int nID)
        //{
        //string sSQL = "";
        //object oCount;
        //try
        //{
        //sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [GimmickInfo] WHERE GimmickInfoName=%s AND GimmickID!= %n ", sGimmickInfoName, nID);
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
        //public IDataReader GetGimmickInfo(string sGimmickInfoName)
        //{
        //string sSQL = "";
        //IDataReader oReader;
        //try
        //{
        //sSQL = SQL.MakeSQL("SELECT * FROM [GimmickInfo] WHERE [GimmickInfoName]=%s ", sGimmickInfoName);
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
