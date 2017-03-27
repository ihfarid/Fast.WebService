using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core.DataAccess;
using System.Data.SqlClient;

namespace FAST.DataLogic
{
	public partial class DLDoctorUpdateRequest: DAAccess
	{
		//public bool IsDuplicate(string sDoctorUpdateRequestName)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [DoctorUpdateRequest] WHERE DoctorUpdateRequestName=%s ", sDoctorUpdateRequestName);
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
		//public bool IsDuplicate(string sDoctorUpdateRequestName, int nID)
		//{
			//string sSQL = "";
			//object oCount;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT COUNT(*) FROM [DoctorUpdateRequest] WHERE DoctorUpdateRequestName=%s AND DoctorUpdateRequestID!= %n ", sDoctorUpdateRequestName, nID);
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
		//public IDataReader GetDoctorUpdateRequest(string sDoctorUpdateRequestName)
		//{
			//string sSQL = "";
			//IDataReader oReader;
			//try
			//{
				//sSQL = SQL.MakeSQL("SELECT * FROM [DoctorUpdateRequest] WHERE [DoctorUpdateRequestName]=%s ", sDoctorUpdateRequestName);
				//oReader = ExecuteReader(sSQL);
			//}
			//catch (Exception e)
			//{
				//throw new Exception(e.Message);
			//}
			//return oReader;
		//}

        public DataTable GetDoctorUpdateRequestInfoForRM(string sTerritoryID, int nMaxVersion, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                string sSQL1 = SQL.MakeSQL("SELECT a.*,p.PostStpCngName, b.SalDesc, c1.SpCode spName1, c2.SpCode spName2, d1.DegName degName1, d2.DegName degName2, e.DistName, f.UName,"
                    + " i1.ProdCode+'-'+i1.ProdName Prod1, i2.ProdCode+'-'+i2.ProdName Prod2,"
                    + " i3.ProdCode+'-'+i3.ProdName Prod3, i4.ProdCode+'-'+i4.ProdName Prod4,"
                    + " i5.ProdCode+'-'+i5.ProdName Prod5, i6.ProdCode+'-'+i6.ProdName Prod6,"
                    + " i7.ProdCode+'-'+i7.ProdName Prod7, i8.ProdCode+'-'+i8.ProdName Prod8,"
                    + " h.Code PCode, h.Name PName, g.RName, k.SessName from [DoctorUpdateRequest] a"
                    + " INNER JOIN [Salutation] b ON a.SalutationID=b.SalID LEFT JOIN Specialty c1"
                + " on a.SpecialtyID1 = c1.SpID LEFT JOIN Specialty c2"
                + " on a.SpecialtyID2 = c2.SpID LEFT JOIN Degree d1 ON a.DegreeID1= d1.DegID LEFT JOIN Degree d2 ON a.DegreeID2= d2.DegID"
                + " INNER JOIN District e ON a.DistrictID=e.DistID INNER JOIN Upazilla f ON a.UpazillaID=f.UID"
                + " INNER JOIN Product i1 ON a.Product1=i1.ProdID INNER JOIN Product i2 ON a.Product2=i2.ProdID"
                + " INNER JOIN Product i3 ON a.Product3=i3.ProdID INNER JOIN Product i4 ON a.Product4=i4.ProdID"
                + " INNER JOIN Product i5 ON a.Product5=i5.ProdID INNER JOIN Product i6 ON a.Product6=i6.ProdID"
                + " LEFT JOIN Product i7 ON a.Product7=i7.ProdID LEFT JOIN Product i8 ON a.Product8=i8.ProdID"
                + " INNER JOIN Route g ON a.Route=g.RID and g.TerrID=a.TerritoryID INNER JOIN Profile h ON a.Profile=h.ID"
                + " INNER JOIN VisitSession k on a.Session=k.SessID LEFT JOIN PostStepChange p ON a.PostStepChange = p.PostStpCngID INNER JOIN DoctorLog l on"
                + " l.DoctorUpdateReqID=a.DoctorUpdateRequestID where a.Version > %n and a.UpdateStatus !=%n and"
                + " l.Status=%n and l.Type=%n and l.DoctorUpdateReqID Is Not NULL", nMaxVersion, 2, 1, 2);
                string sSQL2 = " and l.TerritoryID like '" + sTerritoryID + "%' ORDER BY a.TerritoryID";
                sSQL = sSQL1 + sSQL2;
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public DataTable GetDoctorUpdateRequestInfo(int nDoctorUpdateReqID, string sConnectionString)
        {
            string sSQL = "";
            DataTable oTable = new DataTable();

            try
            {
                sSQL = SQL.MakeSQL("SELECT * FROM [DoctorUpdateRequest] WHERE DoctorUpdateRequestID=%n", nDoctorUpdateReqID);
                SqlDataAdapter oSqlDataAdapter = new SqlDataAdapter(sSQL, sConnectionString);
                oSqlDataAdapter.Fill(oTable);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return oTable;
        }

        public int GetMaxDoctorUpdateReqVersion(SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            int nMaxDoctorUpdateReqVersion;
            try
            {
                string sSQL = "";
                SqlCommand cmd = new SqlCommand();
                sSQL = SQL.MakeSQL("SELECT MAX(Version)+ 1 Version FROM [DoctorUpdateRequest]");
                cmd.CommandText = sSQL;
                cmd.Connection = oSqlConnection;
                cmd.Transaction = oSqlTransaction;
                object o = cmd.ExecuteScalar();

                if (o == DBNull.Value)
                {
                    nMaxDoctorUpdateReqVersion = 1;
                }
                else
                {
                    nMaxDoctorUpdateReqVersion = Convert.ToInt32(o);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return nMaxDoctorUpdateReqVersion;
        }

	}
}
