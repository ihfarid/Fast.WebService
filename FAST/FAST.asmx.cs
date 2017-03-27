using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using FAST.BusinessLogic;
using FAST.Core.DataAccess;
using FAST.BusinessObjects;
using System.Globalization;
using System.Data.SqlClient;
using System.Xml;
using System.Web.Script.Serialization;
using System.Web.Services.Protocols;
using System.IO;
using System.Collections.Specialized;
using System.Configuration;
using Directory = Lucene.Net.Store.Directory;
using Version = Lucene.Net.Util.Version;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Documents;
using Lucene.Net.Analysis;
using System.Diagnostics;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;

namespace FAST
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FAST : System.Web.Services.WebService
    {
        // Creates a TextInfo based on the "en-US" culture.
        TextInfo txtInfo = new CultureInfo("en-US", false).TextInfo;
        String sException = "";

        public class DoctorDetail
        {
            public string sTerritoryID;
            public int nDoctorID;
            public string sDoctorName;
            public string sSalutation;
            public string sSpecialty1;
            public string sSpecialty2;
            public string sDegree1;
            public string sDegree2;
            public string sInstitute;
            public string sAddress1;
            public string sAddress2;
            public string sAddress3;
            public string sDistrict;
            public string sUpazilla;
            public string sBirthDay;
            public string sMarriageday;
            public string sEmail;
            public string sMobileNo;
            public int nDoctorType;
            public int nSwajanStatus;
            public string sProfileCode;
            public string sProfileName;
            public string sProduct1;
            public string sProduct2;
            public string sProduct3;
            public string sProduct4;
            public string sProduct5;
            public string sProduct6;
            public string sProduct7;
            public string sProduct8;
            public int nCallFreq;
            public string sRoute;
            public string sSession;
            public int nStatus;
            public int nSpecialtyNo;
            public int nDegreeNo;
            public int nAddressNo;
            public string sCardAttachment;
            public string sCreateDate;
            public string sLastUpdateDate;
            public int nVersion;
            public int nActionType;
            public string sBMDCCode;
            public string sPostStepChange;
        }

        public class RouteInfo
        {
            public string sTerritoryID;
            public int nRouteID;
            public string sRouteName;
            public int nVersion;
            public int nActionType;
        }

        //public class SecQuesInfo
        //{
        //    public string sSecQues;
        //    public DateTime dEntryDate;
        //    public DateTime dLastUpdateDate;
        //    public int nIsActive;
        //}

        public class UserLoginInfo
        {
            public string sGDDBID;
            public string sEmpCode;
            public string sName;
            public string sTerritoryID;
            public string sSecQues;
            public string sSecQuesAns;
            public string sPassword;
            public string sMobile;
            public DateTime dEntryDate;
            public DateTime dLastUpdateDate;
            public int nVersion;
            public int nCommandVersion;
            public int nAppConfigVersion;
            public int nDoctorVersion;
            public int nDoctorReqVersion;
            public int nDoctorLogVersion;
            public int nRouteVersion;
            public int nDegreeVersion;
            public int nSpecialtyVersion;
            public int nSalutationVersion;
            public int nDistrictVersion;
            public int nUpazillaVersion;
            public int nLineSpeProductVersion;
            public int nGimmickVersion;
            public int nSampleVersion;
            public int nHolidayVersion;
            public int nBrandVersion;
            public int nReasonVersion;
            public int nPVPVersion;
            public int nPVPWorkingDayVersion;
            public int nDCRVersion;
            public int nAppVersion;
            public int nNoOfTargetDoctor;
            public int nUserType;
            public int nIsActive;
        }

        public class AppConfigInfo
        {
            public int nAppConfigID;
            public string sPVPStartDate;
            public string sPVPEndDate;
            public string sSMSSendNo;
            public int nMonth;
            public int nYear;
            public int nDCREntryHours;
            public int nDCRApprovalHours;
            public int nIsDMRLock;
            public int nTotalDoctor;
            public int nVersion;
            public int nAction;
            public int nIsSwajanStatus;
            public int nIsProfile;
            public int nIsRoute;
            public int nIsSession;
            public int nIsDocType;
            public int nIsCallFrequency;
            public int nIsProd1;
            public int nIsProd2;
            public int nIsProd3;
            public int nIsProd4;
            public int nIsProd5;
            public int nIsProd6;
            public int nIsProd7;
            public int nIsProd8;
        }

        public class PVPDetailInfo
        {
            public string sPvpID;
            public string sTerritoryID;
            public string sDoctorID;
            public int nDay;
            public int nMonth;
            public int nYear;
            public string sBrand1;
            public string sBrand2;
            public string sBrand3;
            public string sBrand4;
            public string sBrand5;
            public string sBrand6;
            public string sBrand7;
            public string sBrand8;
            public string sSession;
            public int nIsHoliday;
            public string sDoctorProfile;
            public string sCreationDate;
        }

        public class DCRInfo
        {
            public int nDcrID;
            public int nPvpDetailID;
            public int nDoctorID;
            public string sTerritoryID;
            public int nDay;
            public int nMonth;
            public int nYear;
            public int nStatus;
            public string sVisitDateTime;
            public int nIsVisited;
            public int nIsAvailable;
            public int nIsAccompanyByRM_RM;
            public int nIsAccompanyByRM_SF;
            public string sReminderNextCall;
            public int nNotAvailableReasonID;
            public string sNotAvailableReason;
            public int nIsNewVisit;
            public string sSession;
            public string sBrand1;
            public string sBrand1Gimmick1;
            public string sBrand1Gimmick2;
            public string sBrand1Gimmick3;
            public string sBrand1Sample1;
            public string sBrand1Sample2;
            public string sBrand1Sample3;
            public int nBrand1Gimmick1Qty;
            public int nBrand1Gimmick2Qty;
            public int nBrand1Gimmick3Qty;
            public int nBrand1Sample1Qty;
            public int nBrand1Sample2Qty;
            public int nBrand1Sample3Qty;
            public string sBrand2;
            public string sBrand2Gimmick1;
            public string sBrand2Gimmick2;
            public string sBrand2Gimmick3;
            public string sBrand2Sample1;
            public string sBrand2Sample2;
            public string sBrand2Sample3;
            public int nBrand2Gimmick1Qty;
            public int nBrand2Gimmick2Qty;
            public int nBrand2Gimmick3Qty;
            public int nBrand2Sample1Qty;
            public int nBrand2Sample2Qty;
            public int nBrand2Sample3Qty;
            public string sBrand3;
            public string sBrand3Gimmick1;
            public string sBrand3Gimmick2;
            public string sBrand3Gimmick3;
            public string sBrand3Sample1;
            public string sBrand3Sample2;
            public string sBrand3Sample3;
            public int nBrand3Gimmick1Qty;
            public int nBrand3Gimmick2Qty;
            public int nBrand3Gimmick3Qty;
            public int nBrand3Sample1Qty;
            public int nBrand3Sample2Qty;
            public int nBrand3Sample3Qty;
            public string sBrand4;
            public string sBrand4Gimmick1;
            public string sBrand4Gimmick2;
            public string sBrand4Gimmick3;
            public string sBrand4Sample1;
            public string sBrand4Sample2;
            public string sBrand4Sample3;
            public int nBrand4Gimmick1Qty;
            public int nBrand4Gimmick2Qty;
            public int nBrand4Gimmick3Qty;
            public int nBrand4Sample1Qty;
            public int nBrand4Sample2Qty;
            public int nBrand4Sample3Qty;
            public string sBrand5;
            public string sBrand5Gimmick1;
            public string sBrand5Gimmick2;
            public string sBrand5Gimmick3;
            public string sBrand5Sample1;
            public string sBrand5Sample2;
            public string sBrand5Sample3;
            public int nBrand5Gimmick1Qty;
            public int nBrand5Gimmick2Qty;
            public int nBrand5Gimmick3Qty;
            public int nBrand5Sample1Qty;
            public int nBrand5Sample2Qty;
            public int nBrand5Sample3Qty;
            public string sBrand6;
            public string sBrand6Gimmick1;
            public string sBrand6Gimmick2;
            public string sBrand6Gimmick3;
            public string sBrand6Sample1;
            public string sBrand6Sample2;
            public string sBrand6Sample3;
            public int nBrand6Gimmick1Qty;
            public int nBrand6Gimmick2Qty;
            public int nBrand6Gimmick3Qty;
            public int nBrand6Sample1Qty;
            public int nBrand6Sample2Qty;
            public int nBrand6Sample3Qty;
            public string sBrand7;
            public string sBrand7Gimmick1;
            public string sBrand7Gimmick2;
            public string sBrand7Gimmick3;
            public string sBrand7Sample1;
            public string sBrand7Sample2;
            public string sBrand7Sample3;
            public int nBrand7Gimmick1Qty;
            public int nBrand7Gimmick2Qty;
            public int nBrand7Gimmick3Qty;
            public int nBrand7Sample1Qty;
            public int nBrand7Sample2Qty;
            public int nBrand7Sample3Qty;
            public string sBrand8;
            public string sBrand8Gimmick1;
            public string sBrand8Gimmick2;
            public string sBrand8Gimmick3;
            public string sBrand8Sample1;
            public string sBrand8Sample2;
            public string sBrand8Sample3;
            public int nBrand8Gimmick1Qty;
            public int nBrand8Gimmick2Qty;
            public int nBrand8Gimmick3Qty;
            public int nBrand8Sample1Qty;
            public int nBrand8Sample2Qty;
            public int nBrand8Sample3Qty;
            public string sSubmitDateTime;
            public string sApprovedDateTime;
            public int nSubmittedBy;
            public int nApprovedBy;
            public int nAction;
            public int nVersion;
            public string sSMSDCRNo;
            public int nIsSendSMS;
            public string sRejectReason;
        }

        public class LineSpecialityProduct
        {
            public string sLineID;
            public string sSPDesc;
            public string sProdName;
            public int nPriority;
            public int nRankWithin;
            public int nVersion;
            public int nActionType;
        }

        public class DoctorUpdateReq
        {
            public int nDoctorUpdateRequestID;
            public string sTerritoryID;
            public int nDoctorID;
            public string sCode;
            public string sBMDCCode;
            public string sDoctorName;
            public string sSalutation;
            public string sSpecialty1;
            public string sSpecialty2;
            public string sDegree1;
            public string sDegree2;
            public string sInstitute;
            public string sAddress1;
            public string sAddress2;
            public string sAddress3;
            public string sDistrict;
            public string sUpazilla;
            public string sBirthDay;
            public string sMarriageday;
            public string sEmail;
            public string sMobileNo;
            public int nDoctorType;
            public int nSwajanStatus;
            public string sProfileCode;
            public string sProfileName;
            public int nSpecialtyNo;
            public int nDegreeNo;
            public int nAddressNo;
            public string sProduct1;
            public string sProduct2;
            public string sProduct3;
            public string sProduct4;
            public string sProduct5;
            public string sProduct6;
            public string sProduct7;
            public string sProduct8;
            public int nCallFreq;
            public string sRoute;
            public string sSession;
            public int nStatus;
            public string sCreateDate;
            public string sLastUpdateDate;
            public int nVersion;
            public int nActionType;
            public int nRefNo;
            public int nCreatedBy;
            public int nModifiedBy;
            public string sCardAttachement;
            public string sPostStepChange;
        }

        public class SearchResults1
        {
            public int ID { get; set; }
            public string Code { get; set; }
            public string BMDCCode { get; set; }
            public string DocName { get; set; }
            public string Salutation { get; set; }
            public string Speciality1 { get; set; }
            public string Speciality2 { get; set; }
            public string Degree1 { get; set; }
            public string Degree2 { get; set; }
            public string Institute { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string Address3 { get; set; }
            public string District { get; set; }
            public string Upzila { get; set; }
            public string FRPDoctorID { get; set; }
            public string DOB { get; set; }
            public string DOM { get; set; }
            public string Status { get; set; }
            public string RefNo { get; set; }
            public string MobileNo { get; set; }
            public string Email { get; set; }
            public string CardAttachment { get; set; }

        }

        public class SearchResults
        {
            public int ID { get; set; }
            public string Code { get; set; }
            public string BMDCCode { get; set; }
            public string DocName { get; set; }
            public string Salutation { get; set; }
            public string Speciality1 { get; set; }
            public string Speciality2 { get; set; }
            public string Degree1 { get; set; }
            public string Degree2 { get; set; }
            public string Institute { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string Address3 { get; set; }
            public string District { get; set; }
            public string Upzila { get; set; }
            public string FRPDoctorID { get; set; }
            public string DOB { get; set; }
            public string DOM { get; set; }
            public string Status { get; set; }
            public string RefNo { get; set; }
            public string MobileNo { get; set; }
            public string Email { get; set; }
            public string CardAttachment { get; set; }

        }
        
        public class Salutation
        {
            public int nSalID;
            public string sSalCode;
            public string sSalDesc;
            public int nStatus;
            public int nVersion;
            public int nActionType;
        }

        public class Speciality
        {
            public int nSpID;
            public string sSpCode;
            public string sSpDesc;
            public int nStatus;
            public int nVersion;
            public int nActionType;
        }

        public class Degree
        {
            public int nDegID;
            public string sDegCode;
            public string sDegName;
            public int nStatus;
            public int nVersion;
            public int nActionType;
        }

        public class District2
        {
            public int nDistID;
            public string sDistName;
            public int nVersion;
            public int nActionType;
        }

        public class Upazilla
        {
            public int nUID;
            public string sUName;
            public string sDistName;
            public int nVersion;
            public int nActionType;
        }

        public class Upazilla2
        {
            public int nUID;
            public string sUName;
            public string sDistName;
            public int nVersion;
            public int nActionType;
        }
        //public class BrandMappingInfo
        //{
        //    public int nDcrID;
        //    public int nPvpDetailID;
        //    public int nDoctorID;
        //    public string sTerritoryID;
        //    public int nDay;
        //    public int nMonth;
        //    public int nYear;
        //    public int nStatus;
        //    public string sVisitDateTime;
        //    public int nIsVisited;
        //    public int nIsAvailable;
        //    public int nIsAccompanyByRM_RM;
        //    public int nIsAccompanyByRM_SF;
        //    public string sReminderNextCall;
        //    public int nNotAvailableReasonID;
        //    public string sNotAvailableReason;
        //    public int nIsNewVisit;
        //    public string sSession;
        //    public string sBrand1;
        //    public string sBrand1Gimmick1;
        //    public string sBrand1Gimmick2;
        //    public string sBrand1Gimmick3;
        //    public string sBrand1Sample1;
        //    public string sBrand1Sample2;
        //    public string sBrand1Sample3;
        //    public int nBrand1Gimmick1Qty;
        //    public int nBrand1Gimmick2Qty;
        //    public int nBrand1Gimmick3Qty;
        //    public int nBrand1Sample1Qty;
        //    public int nBrand1Sample2Qty;
        //    public int nBrand1Sample3Qty;
        //    public string sBrand2;
        //    public string sBrand2Gimmick1;
        //    public string sBrand2Gimmick2;
        //    public string sBrand2Gimmick3;
        //    public string sBrand2Sample1;
        //    public string sBrand2Sample2;
        //    public string sBrand2Sample3;
        //    public int nBrand2Gimmick1Qty;
        //    public int nBrand2Gimmick2Qty;
        //    public int nBrand2Gimmick3Qty;
        //    public int nBrand2Sample1Qty;
        //    public int nBrand2Sample2Qty;
        //    public int nBrand2Sample3Qty;
        //    public string sBrand3;
        //    public string sBrand3Gimmick1;
        //    public string sBrand3Gimmick2;
        //    public string sBrand3Gimmick3;
        //    public string sBrand3Sample1;
        //    public string sBrand3Sample2;
        //    public string sBrand3Sample3;
        //    public int nBrand3Gimmick1Qty;
        //    public int nBrand3Gimmick2Qty;
        //    public int nBrand3Gimmick3Qty;
        //    public int nBrand3Sample1Qty;
        //    public int nBrand3Sample2Qty;
        //    public int nBrand3Sample3Qty;
        //    public string sBrand4;
        //    public string sBrand4Gimmick1;
        //    public string sBrand4Gimmick2;
        //    public string sBrand4Gimmick3;
        //    public string sBrand4Sample1;
        //    public string sBrand4Sample2;
        //    public string sBrand4Sample3;
        //    public int nBrand4Gimmick1Qty;
        //    public int nBrand4Gimmick2Qty;
        //    public int nBrand4Gimmick3Qty;
        //    public int nBrand4Sample1Qty;
        //    public int nBrand4Sample2Qty;
        //    public int nBrand4Sample3Qty;
        //    public string sBrand5;
        //    public string sBrand5Gimmick1;
        //    public string sBrand5Gimmick2;
        //    public string sBrand5Gimmick3;
        //    public string sBrand5Sample1;
        //    public string sBrand5Sample2;
        //    public string sBrand5Sample3;
        //    public int nBrand5Gimmick1Qty;
        //    public int nBrand5Gimmick2Qty;
        //    public int nBrand5Gimmick3Qty;
        //    public int nBrand5Sample1Qty;
        //    public int nBrand5Sample2Qty;
        //    public int nBrand5Sample3Qty;
        //    public string sBrand6;
        //    public string sBrand6Gimmick1;
        //    public string sBrand6Gimmick2;
        //    public string sBrand6Gimmick3;
        //    public string sBrand6Sample1;
        //    public string sBrand6Sample2;
        //    public string sBrand6Sample3;
        //    public int nBrand6Gimmick1Qty;
        //    public int nBrand6Gimmick2Qty;
        //    public int nBrand6Gimmick3Qty;
        //    public int nBrand6Sample1Qty;
        //    public int nBrand6Sample2Qty;
        //    public int nBrand6Sample3Qty;
        //    public string sSubmitDateTime;
        //    public string sApprovedDateTime;
        //    public int nSubmittedBy;
        //    public int nApprovedBy;
        //    public int nAction;
        //    public int nVersion;
        //    public string sSMSDCRNo;
        //    public int nIsSendSMS;
        //    public string sRejectReason;
        //}

        //public class DCRInfo
        //{
        //    public int nDcrID;
        //    public int nPvpDetailID;
        //    public int nDoctorID;
        //    public string sTerritoryID;
        //    public int nDay;
        //    public int nMonth;
        //    public int nYear;
        //    public int nStatus;
        //    public string sVisitDateTime;
        //    public int nIsVisited;
        //    public int nIsAvailable;
        //    public int nIsAccompanyByRM_RM;
        //    public int nIsAccompanyByRM_SF;
        //    public string sReminderNextCall;
        //    public int nNotAvailableReasonID;
        //    public string sNotAvailableReason;
        //    public int nIsNewVisit;
        //    public string sSession;
        //    public int nBrand1;
        //    public int nBrand1Gimmick1;
        //    public int nBrand1Gimmick2;
        //    public int nBrand1Gimmick3;
        //    public int nBrand1Sample1;
        //    public int nBrand1Sample2;
        //    public int nBrand1Sample3;
        //    public int nBrand1Gimmick1Qty;
        //    public int nBrand1Gimmick2Qty;
        //    public int nBrand1Gimmick3Qty;
        //    public int nBrand1Sample1Qty;
        //    public int nBrand1Sample2Qty;
        //    public int nBrand1Sample3Qty;
        //    public int nBrand2;
        //    public int nBrand2Gimmick1;
        //    public int nBrand2Gimmick2;
        //    public int nBrand2Gimmick3;
        //    public int nBrand2Sample1;
        //    public int nBrand2Sample2;
        //    public int nBrand2Sample3;
        //    public int nBrand2Gimmick1Qty;
        //    public int nBrand2Gimmick2Qty;
        //    public int nBrand2Gimmick3Qty;
        //    public int nBrand2Sample1Qty;
        //    public int nBrand2Sample2Qty;
        //    public int nBrand2Sample3Qty;
        //    public int nBrand3;
        //    public int nBrand3Gimmick1;
        //    public int nBrand3Gimmick2;
        //    public int nBrand3Gimmick3;
        //    public int nBrand3Sample1;
        //    public int nBrand3Sample2;
        //    public int nBrand3Sample3;
        //    public int nBrand3Gimmick1Qty;
        //    public int nBrand3Gimmick2Qty;
        //    public int nBrand3Gimmick3Qty;
        //    public int nBrand3Sample1Qty;
        //    public int nBrand3Sample2Qty;
        //    public int nBrand3Sample3Qty;
        //    public int nBrand4;
        //    public int nBrand4Gimmick1;
        //    public int nBrand4Gimmick2;
        //    public int nBrand4Gimmick3;
        //    public int nBrand4Sample1;
        //    public int nBrand4Sample2;
        //    public int nBrand4Sample3;
        //    public int nBrand4Gimmick1Qty;
        //    public int nBrand4Gimmick2Qty;
        //    public int nBrand4Gimmick3Qty;
        //    public int nBrand4Sample1Qty;
        //    public int nBrand4Sample2Qty;
        //    public int nBrand4Sample3Qty;
        //    public int nBrand5;
        //    public int nBrand5Gimmick1;
        //    public int nBrand5Gimmick2;
        //    public int nBrand5Gimmick3;
        //    public int nBrand5Sample1;
        //    public int nBrand5Sample2;
        //    public int nBrand5Sample3;
        //    public int nBrand5Gimmick1Qty;
        //    public int nBrand5Gimmick2Qty;
        //    public int nBrand5Gimmick3Qty;
        //    public int nBrand5Sample1Qty;
        //    public int nBrand5Sample2Qty;
        //    public int nBrand5Sample3Qty;
        //    public int nBrand6;
        //    public int nBrand6Gimmick1;
        //    public int nBrand6Gimmick2;
        //    public int nBrand6Gimmick3;
        //    public int nBrand6Sample1;
        //    public int nBrand6Sample2;
        //    public int nBrand6Sample3;
        //    public int nBrand6Gimmick1Qty;
        //    public int nBrand6Gimmick2Qty;
        //    public int nBrand6Gimmick3Qty;
        //    public int nBrand6Sample1Qty;
        //    public int nBrand6Sample2Qty;
        //    public int nBrand6Sample3Qty;
        //    public string sSubmitDateTime;
        //    public string sApprovedDateTime;
        //    public int nSubmittedBy;
        //    public int nApprovedBy;
        //    public int nAction;
        //    public int nVersion;
        //    public string sSMSDCRNo;
        //    public int nIsSendSMS;
        //    public string sRejectReason;
        //}

        public class DoctorLog2
        {
            public string sDoctorLogID;
            public string sDoctorUpdateReqID;
            public string sDoctorTerritoryMappingID;
            public string sDoctorID;
            public string sTransferReason;
            public string sCreationDate;
            public int nStatus;
            public int nType;
            public int nVersion;
            public int nActionType;
        }

        public class Line_Speciality_Product
        {
            public string sLineID;
            public string sSPID;
            public string sProdName;
            public int nPriority;
            public int nRankWithin;
            public int nVersion;
            public int nActionType;
        }

        public class CompanyRxByQty
        {
            public string sBase;
            public string sShare;
            public string sRank;
            public string sComp1;
            public string sComp2;
            public string sComp3;
            public string sComp4;
            public string sComp5;
            public string sComp6;
            public string sComp7;
            public string sComp8;
            public string sValue1;
            public string sValue2;
            public string sValue3;
            public string sValue4;
            public string sValue5;
            public string sValue6;
            public string sValue7;
            public string sValue8;
        }
        
        public class CompanyRxByValue
        {
            public string sBase;
            public string sShare;
            public string sRank;
            public string sComp1;
            public string sComp2;
            public string sComp3;
            public string sComp4;
            public string sComp5;
            public string sComp6;
            public string sComp7;
            public string sComp8;
            public string sValue1;
            public string sValue2;
            public string sValue3;
            public string sValue4;
            public string sValue5;
            public string sValue6;
            public string sValue7;
            public string sValue8;
        }
        
        public class CompanyMoleculeShare
        {
            public string sMolecule;
            public string sRx;
        }

        List<DoctorDetail> oDoctorDetailList;
        List<RouteInfo> oRouteInfoList;
        List<SecQuesInfo> oSecQuesInfoList;
        List<UserLoginInfo> oUserLoginInfoList;
        List<AppConfigInfo> oAppConfigInfoList;
        List<PVPDetailInfo> oPVPDetailInfoList;
        List<DCRInfo> oDCRInfoList;
        List<LineSpecialityProduct> oLineSpecialityProductList;
        List<DoctorUpdateReq> oDoctorUpdateReqList;
        List<Salutation> oSalutationInfo;
        List<Speciality> oSpecialityInfo;
        List<Degree> oDegreeInfo;
        List<District2> oDistrictInfo2;
        List<Upazilla> oUpazillaInfo;
        List<Upazilla2> oUpazillaInfo2;
        List<DoctorLog2> oDoctorLogList;
        List<Line_Speciality_Product> oLineSpecialityProductList1;
        List<CompanyRxByQty> oCompanyRxByQtyList;
        List<CompanyRxByValue> oCompanyRxByValueList;
        List<CompanyMoleculeShare> oCompanyMoleculeShareList;
        
        [WebMethod(Description = "Method to Get CompanyMoleculeShare")]
        public List<CompanyMoleculeShare> GetCompanyMoleculeShareList(string sFrPID)
        {
            oCompanyMoleculeShareList = new List<CompanyMoleculeShare> { };
            DataTable oTable = new DataTable();
            BLDoctorTerritoryMapping oBL = new BLDoctorTerritoryMapping();

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    oTable = oBL.GetMoleculeRxList(sFrPID, connectionString);
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        CompanyMoleculeShare oCompanyRx = new CompanyMoleculeShare();
                        oCompanyRx.sMolecule = oRow["Molecule"].ToString();
                        oCompanyRx.sRx = oRow["Rx"].ToString();

                        oCompanyMoleculeShareList.Add(oCompanyRx);
                    }
                    myTransaction.Commit();
                }

                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }

                return oCompanyMoleculeShareList;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Get CompanyRxByQty")]
        public List<CompanyRxByQty> GetCompanyRxByQtyList(string sFrPID)
        {
            oCompanyRxByQtyList = new List<CompanyRxByQty> { };
            DataTable oTable = new DataTable();
            BLDoctorTerritoryMapping oBL = new BLDoctorTerritoryMapping();

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    oTable = oBL.GetCompanyRxByQty(sFrPID, connectionString);
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        CompanyRxByQty oCompanyRxByQty = new CompanyRxByQty();
                        oCompanyRxByQty.sBase = oRow["Base"].ToString();
                        oCompanyRxByQty.sShare = oRow["SandozShare"].ToString();
                        oCompanyRxByQty.sRank = oRow["SandozRank"].ToString();
                        oCompanyRxByQty.sComp1 = oRow["Company1"].ToString();
                        oCompanyRxByQty.sComp2 = oRow["Company2"].ToString();
                        oCompanyRxByQty.sComp3 = oRow["Company3"].ToString();
                        oCompanyRxByQty.sComp4 = oRow["Company4"].ToString();
                        oCompanyRxByQty.sComp5 = oRow["Company5"].ToString();
                        oCompanyRxByQty.sComp6 = oRow["Company6"].ToString();
                        oCompanyRxByQty.sComp7 = oRow["Company7"].ToString();
                        oCompanyRxByQty.sComp8 = oRow["Company8"].ToString();
                        oCompanyRxByQty.sValue1 = oRow["Company1Share"].ToString();
                        oCompanyRxByQty.sValue2 = oRow["Company2Share"].ToString();
                        oCompanyRxByQty.sValue3 = oRow["Company3Share"].ToString();
                        oCompanyRxByQty.sValue4 = oRow["Company4Share"].ToString();
                        oCompanyRxByQty.sValue5 = oRow["Company5Share"].ToString();
                        oCompanyRxByQty.sValue6 = oRow["Company6Share"].ToString();
                        oCompanyRxByQty.sValue7 = oRow["Company7Share"].ToString();
                        oCompanyRxByQty.sValue8 = oRow["Company8Share"].ToString();

                        oCompanyRxByQtyList.Add(oCompanyRxByQty);
                    }
                    myTransaction.Commit();
                }

                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }

                return oCompanyRxByQtyList;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        [WebMethod(Description = "Method to Get CompanyRxByValue")]
        public List<CompanyRxByValue> GetCompanyRxByValueList(string sFrPID)
        {
            oCompanyRxByValueList = new List<CompanyRxByValue> { };
            DataTable oTable = new DataTable();
            BLDoctorTerritoryMapping oBL = new BLDoctorTerritoryMapping();

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    oTable = oBL.GetCompanyRxByValue(sFrPID, connectionString);
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        CompanyRxByValue oCompanyRxByValue = new CompanyRxByValue();
                        oCompanyRxByValue.sBase = oRow["Base"].ToString();
                        oCompanyRxByValue.sShare = oRow["SandozShare"].ToString();
                        oCompanyRxByValue.sRank = oRow["SandozRank"].ToString();
                        oCompanyRxByValue.sComp1 = oRow["Company1"].ToString();
                        oCompanyRxByValue.sComp2 = oRow["Company2"].ToString();
                        oCompanyRxByValue.sComp3 = oRow["Company3"].ToString();
                        oCompanyRxByValue.sComp4 = oRow["Company4"].ToString();
                        oCompanyRxByValue.sComp5 = oRow["Company5"].ToString();
                        oCompanyRxByValue.sComp6 = oRow["Company6"].ToString();
                        oCompanyRxByValue.sComp7 = oRow["Company7"].ToString();
                        oCompanyRxByValue.sComp8 = oRow["Company8"].ToString();
                        oCompanyRxByValue.sValue1 = oRow["Company1Share"].ToString();
                        oCompanyRxByValue.sValue2 = oRow["Company2Share"].ToString();
                        oCompanyRxByValue.sValue3 = oRow["Company3Share"].ToString();
                        oCompanyRxByValue.sValue4 = oRow["Company4Share"].ToString();
                        oCompanyRxByValue.sValue5 = oRow["Company5Share"].ToString();
                        oCompanyRxByValue.sValue6 = oRow["Company6Share"].ToString();
                        oCompanyRxByValue.sValue7 = oRow["Company7Share"].ToString();
                        oCompanyRxByValue.sValue8 = oRow["Company8Share"].ToString();

                        oCompanyRxByValueList.Add(oCompanyRxByValue);
                    }
                    myTransaction.Commit();
                }

                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }

                return oCompanyRxByValueList;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        [WebMethod(Description = "Method to Get DoctorLogInfo")]
        public List<DoctorLog2> GetDoctorLog(string sTerritoryID, int nMaxVersion)
        {
            oDoctorLogList = new List<DoctorLog2> { };
            DataTable oTable = new DataTable();
            BLDoctorLog oBL = new BLDoctorLog();

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    oTable = oBL.GetDoctorLogInfo(sTerritoryID, nMaxVersion, connectionString);
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        DoctorLog2 oDoctorLog = new DoctorLog2();
                        oDoctorLog.sDoctorLogID = oRow["DoctorLogID"].ToString();
                        oDoctorLog.sDoctorTerritoryMappingID = oRow["DoctorTerritoryMappingID"].ToString();
                        oDoctorLog.sDoctorUpdateReqID = oRow["DoctorUpdateReqID"].ToString();
                        oDoctorLog.sDoctorID = oRow["DocID"].ToString();
                        oDoctorLog.sTransferReason = oRow["TransferReason"].ToString();
                        oDoctorLog.sCreationDate = oRow["CreationDate"].ToString();
                        oDoctorLog.nStatus = Convert.ToInt32(oRow["Status"].ToString());
                        oDoctorLog.nType = Convert.ToInt32(oRow["Type"].ToString());
                        oDoctorLog.nVersion = Convert.ToInt32(oRow["Version"].ToString());
                        oDoctorLog.nActionType = Convert.ToInt32(oRow["Action"].ToString());

                        oDoctorLogList.Add(oDoctorLog);
                    }
                    myTransaction.Commit();
                }

                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }

                return oDoctorLogList;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Get LineSpecialityProduct")]
        public List<Line_Speciality_Product> GetLineSpecialityProduct(string sTerritoryID, int nMaxVersion)
        {
            oLineSpecialityProductList1 = new List<Line_Speciality_Product> { };
            DataTable oTable = new DataTable();
            BLDoctorTerritoryMapping oBL = new BLDoctorTerritoryMapping();

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    string sLineID;

                    sLineID = oBL.GetLine(sTerritoryID, myConnection, myTransaction);

                    oTable = oBL.GetProductInfo(sLineID, nMaxVersion, connectionString);

                    foreach (DataRow oRow in oTable.Rows)
                    {
                        Line_Speciality_Product oLineSpecialityProduct = new Line_Speciality_Product();
                        oLineSpecialityProduct.sLineID = oRow["LineID"].ToString();
                        oLineSpecialityProduct.sSPID = oRow["SpCode"].ToString();
                        oLineSpecialityProduct.sProdName = oRow["ProdName"].ToString();
                        oLineSpecialityProduct.nRankWithin = Convert.ToInt32(oRow["Priority"].ToString());
                        oLineSpecialityProduct.nPriority = Convert.ToInt32(oRow["RankWithin"].ToString());
                        oLineSpecialityProduct.nVersion = Convert.ToInt32(oRow["Version"].ToString());
                        oLineSpecialityProduct.nActionType = Convert.ToInt32(oRow["Action"].ToString());

                        oLineSpecialityProductList1.Add(oLineSpecialityProduct);
                    }
                    myTransaction.Commit();
                }

                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }

                return oLineSpecialityProductList1;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Update Route")]
        public string UpdateRoute(string sTerritoryID, string sNewRouteName, string sOldRouteName, int nStatus)
        {
            BLDoctorTerritoryMapping oBL = new BLDoctorTerritoryMapping();
            UserInfo oUserInfo = new UserInfo();
            BLUserInfo oBLUserInfo = new BLUserInfo();
            BLEmployeeInfo oBLEmployeeInfo = new BLEmployeeInfo();
            string sRMTerritoryID;
            //int nAuthenTicket = 0;
            string sAuthenTicket = "0";
            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    int nCount = oBL.GetDocCountFrRoute(sTerritoryID, sOldRouteName, myConnection, myTransaction);
                    if (nStatus == 0)
                    {
                        //if (nCount <= 0)
                        //{
                            if (sNewRouteName != "")
                            {
                                oBL.RouteUpdate(sTerritoryID, sNewRouteName, sOldRouteName, nStatus, myConnection, myTransaction);
                                myTransaction.Commit();

                                sRMTerritoryID = sTerritoryID.Substring(0, 6);

                                string sGDDBID = oBLEmployeeInfo.GetGDDBIDByTerritoryID(myConnection, myTransaction, sRMTerritoryID);
                                oUserInfo = oBLUserInfo.GetUserInfo(sGDDBID, connectionString);
                                oUserInfo.Version = oUserInfo.Version + 1;
                                oUserInfo.RouteVersion = oUserInfo.RouteVersion + 1;
                                oUserInfo.LastUpdateDate = DateTime.Now;
                                oBLUserInfo.Save(oUserInfo, myConnection, myTransaction);

                                sAuthenTicket = "1";
                            }

                        //}
                    }
                    else
                    {
                        if (sNewRouteName != "")
                        {
                            oBL.RouteUpdate(sTerritoryID, sNewRouteName, sOldRouteName, nStatus, myConnection, myTransaction);
                            myTransaction.Commit();

                            sRMTerritoryID = sTerritoryID.Substring(0, 6);

                            string sGDDBID = oBLEmployeeInfo.GetGDDBIDByTerritoryID(myConnection, myTransaction, sRMTerritoryID);
                            oUserInfo = oBLUserInfo.GetUserInfo(sGDDBID, connectionString);
                            oUserInfo.Version = oUserInfo.Version + 1;
                            oUserInfo.RouteVersion = oUserInfo.RouteVersion + 1;
                            oUserInfo.LastUpdateDate = DateTime.Now;
                            oBLUserInfo.Save(oUserInfo, myConnection, myTransaction);

                            sAuthenTicket = "1";
                        }
                    }
                }
                catch (Exception e)
                {
                    sAuthenTicket = e.Message.ToString();
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }

                //return nAuthenTicket;
            }

            //catch (Exception ex)
            //{
            //    return nAuthenTicket;
            //    throw new Exception(ex.Message);
            //}


            catch (Exception ex)
            {
                if (ex is SqlException)
                    sAuthenTicket = "Cannot connect to database.";
                else
                    sAuthenTicket = ex.Message.ToString();
                //throw new Exception(ex.Message);
            }

            return sAuthenTicket;

        }

        [WebMethod(Description = "Method to Add Route")]
        public string AddRoute(string sTerritoryID, string sRouteName, int nVersion, int nAction)
        {
            BLDoctorTerritoryMapping oBL = new BLDoctorTerritoryMapping();
            UserInfo oUserInfo = new UserInfo();
            BLUserInfo oBLUserInfo = new BLUserInfo();
            BLEmployeeInfo oBLEmployeeInfo = new BLEmployeeInfo();
            int nAuthenTicket = 0;
           // int nIsValid = 0;
            string sRMTerritoryID;
            string sAuthenTicket = "0";

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    int Version = oBL.GetMaxRouteVersion(sTerritoryID, myConnection, myTransaction);
                    if (sRouteName != "")
                    {
                        //nIsValid = oBL.CheckRoute(sTerritoryID, sRouteName, myConnection, myTransaction);

                        //if (nIsValid == 0)
                        //{
                            nAuthenTicket = oBL.RouteAdd(sTerritoryID, sRouteName, Version + 1, nAction, myConnection, myTransaction);

                            sRMTerritoryID = sTerritoryID.Substring(0, 6);

                            string sGDDBID = oBLEmployeeInfo.GetGDDBIDByTerritoryID(myConnection, myTransaction, sRMTerritoryID);
                            oUserInfo = oBLUserInfo.GetUserInfo(sGDDBID, connectionString);
                            oUserInfo.Version = oUserInfo.Version + 1;
                            oUserInfo.RouteVersion = oUserInfo.RouteVersion + 1;
                            oUserInfo.LastUpdateDate = DateTime.Now;
                            oBLUserInfo.Save(oUserInfo, myConnection, myTransaction);

                            sAuthenTicket = "1;" + nAuthenTicket.ToString();

                        //}
                        //else
                        //{
                        //    nAuthenTicket = 0;
                        //}
                    }
                    myTransaction.Commit();
                }
                catch (Exception e)
                {
                    sAuthenTicket =  e.Message.ToString();
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }

                //return nAuthenTicket;
            }

            //catch (Exception ex)
            //{
            //    return nAuthenTicket;
            //    throw new Exception(ex.Message);
            //}

            catch (Exception ex)
            {
                if (ex is SqlException)
                    sAuthenTicket = "Cannot connect to database.";
                else
                    sAuthenTicket = ex.Message.ToString();
                //throw new Exception(ex.Message);
            }

            return sAuthenTicket;
        }
        
        [WebMethod(Description = "Method to Get DistrictInfo")]
        public List<District2> GetDistrictInfo(string sTerritoryID, int nMaxVersion)
        {
            oDistrictInfo2 = new List<District2> { };
            DataTable oTable = new DataTable();
            BLDistrict oBL = new BLDistrict();

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    oTable = oBL.GetDistrictInfo(sTerritoryID, nMaxVersion, connectionString);
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        District2 oDistrict = new District2();
                        oDistrict.nDistID = Convert.ToInt32(oRow["DistID"].ToString());
                        oDistrict.sDistName = txtInfo.ToTitleCase(oRow["DistName"].ToString());
                        oDistrict.nVersion = Convert.ToInt32(oRow["Version"].ToString());
                        oDistrict.nActionType = Convert.ToInt32(oRow["Action"].ToString());

                        oDistrictInfo2.Add(oDistrict);
                    }
                    myTransaction.Commit();
                }

                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }

                return oDistrictInfo2;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Get UpazillaInfo")]
        public List<Upazilla2> GetUpazillaInfo(string sTerritoryID, int nMaxVersion)
        {
            oUpazillaInfo2 = new List<Upazilla2> { };
            DataTable oTable = new DataTable();
            BLUpazilla oBL = new BLUpazilla();

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    oTable = oBL.GetUpazillaInfo(sTerritoryID, nMaxVersion, connectionString);
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        Upazilla2 oUpazilla = new Upazilla2();
                        oUpazilla.nUID = Convert.ToInt32(oRow["UID"].ToString());
                        oUpazilla.sUName = txtInfo.ToTitleCase(oRow["UName"].ToString());
                        oUpazilla.sDistName = txtInfo.ToTitleCase(oRow["DistID"].ToString());
                        oUpazilla.nVersion = Convert.ToInt32(oRow["Version"].ToString());
                        oUpazilla.nActionType = Convert.ToInt32(oRow["Action"].ToString());

                        oUpazillaInfo2.Add(oUpazilla);
                    }
                    myTransaction.Commit();
                }

                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }

                return oUpazillaInfo2;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Add Transfer Log")]
        public string AddTransferLog(int nDoctorID, string sTerritoryID, int nStatus, string sReason, int nType, string sGDDBID)
        {
            BLDoctorTerritoryMapping oBL = new BLDoctorTerritoryMapping();
            string sAuthenTicket = "0";
            int nAuthenTicket = 0;

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    if(nDoctorID !=0 && sTerritoryID !="")
                        nAuthenTicket = oBL.AddLog(nDoctorID, sTerritoryID, nStatus, sReason, nType, sGDDBID, myConnection, myTransaction);

                    sAuthenTicket = "1;" + nAuthenTicket.ToString();

                    myTransaction.Commit();
                    //nAuthenTicket = 1;
                }
                catch (Exception e)
                {
                    sAuthenTicket = e.Message.ToString();
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }

                //return nAuthenTicket;
            }

            //catch (Exception ex)
            //{
            //    //return nAuthenTicket;
            //    throw new Exception(ex.Message);
            //}

            catch (Exception ex)
            {
                if (ex is SqlException)
                    sAuthenTicket = "Cannot connect to database.";
                else
                    sAuthenTicket = ex.Message.ToString();
                //throw new Exception(ex.Message);
            }

            return sAuthenTicket;
        }
        
        [WebMethod(Description = "Method to Get DoctorDetail")]
        public List<DoctorDetail> GetDoctorDetail(string sTerritoryID, int nMaxVersion)
        {
            oDoctorDetailList = new List<DoctorDetail> { };
            DataTable oTable = new DataTable();
            BLDoctorTerritoryMapping oBL = new BLDoctorTerritoryMapping();

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    oTable = oBL.GetDoctorDetail(sTerritoryID, nMaxVersion, connectionString);
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        DoctorDetail oDoctorDetail = new DoctorDetail();
                        oDoctorDetail.sTerritoryID = oRow["TerritoryID"].ToString().ToUpper();
                        oDoctorDetail.nDoctorID = Convert.ToInt32(oRow["ID"].ToString());
                        oDoctorDetail.sDoctorName = txtInfo.ToTitleCase(oRow["DocName"].ToString());
                        oDoctorDetail.sSalutation = oRow["SalDesc"].ToString();
                        oDoctorDetail.sSpecialty1 = oRow["spName1"].ToString();
                        oDoctorDetail.sSpecialty2 = oRow["spName2"].ToString();
                        oDoctorDetail.sDegree1 = oRow["degName1"].ToString();
                        oDoctorDetail.sDegree2 = oRow["degName2"].ToString();
                        oDoctorDetail.sInstitute = txtInfo.ToTitleCase(oRow["Institute"].ToString());
                        oDoctorDetail.sAddress1 = txtInfo.ToTitleCase(oRow["Address1"].ToString());
                        oDoctorDetail.sAddress2 = txtInfo.ToTitleCase(oRow["Address2"].ToString());
                        oDoctorDetail.sAddress3 = txtInfo.ToTitleCase(oRow["Address3"].ToString());
                        oDoctorDetail.sDistrict = oRow["DistName"].ToString();
                        oDoctorDetail.sUpazilla = oRow["UName"].ToString();
                        oDoctorDetail.sBirthDay = Convert.ToDateTime(oRow["BirthDay"].ToString()).ToString("dd MMM yyyy");
                        oDoctorDetail.sMarriageday = Convert.ToDateTime(oRow["Mrgday"].ToString()).ToString("dd MMM yyyy");
                        oDoctorDetail.sEmail = oRow["Email"].ToString();
                        oDoctorDetail.sMobileNo = oRow["MobileNo"].ToString();
                        oDoctorDetail.nDoctorType = Convert.ToInt32(oRow["DocTypeID"].ToString());
                        oDoctorDetail.nSwajanStatus = Convert.ToInt32(oRow["SwajanStatus"].ToString());
                        oDoctorDetail.sProfileCode = oRow["PCode"].ToString();
                        oDoctorDetail.sProfileName = oRow["PName"].ToString();
                        oDoctorDetail.sProduct1 = oRow["Product1"].ToString();
                        oDoctorDetail.sProduct2 = oRow["Product2"].ToString();
                        oDoctorDetail.sProduct3 = oRow["Product3"].ToString();
                        oDoctorDetail.sProduct4 = oRow["Product4"].ToString();
                        oDoctorDetail.sProduct5 = oRow["Product5"].ToString();
                        oDoctorDetail.sProduct6 = oRow["Product6"].ToString();
                        oDoctorDetail.sProduct7= oRow["Product7"].ToString();
                        oDoctorDetail.sProduct8= oRow["Product8"].ToString();
                        oDoctorDetail.nCallFreq = Convert.ToInt32(oRow["CallFre"].ToString());
                        oDoctorDetail.sRoute = txtInfo.ToTitleCase(oRow["RName"].ToString().Trim());
                        oDoctorDetail.sSession = oRow["SessName"].ToString();
                        oDoctorDetail.nStatus = Convert.ToInt32(oRow["Status"].ToString());
                        oDoctorDetail.nAddressNo = Convert.ToInt32(oRow["Address"].ToString());
                        oDoctorDetail.nSpecialtyNo = Convert.ToInt32(oRow["Speciality"].ToString());
                        oDoctorDetail.nDegreeNo = Convert.ToInt32(oRow["Degree"].ToString());
                        oDoctorDetail.sCardAttachment = oRow["CardAttachement"].ToString();
                        oDoctorDetail.sCreateDate = Convert.ToDateTime(oRow["CreateDatetime"].ToString()).ToString("dd MMM yyyy HH:mm:ss");
                        oDoctorDetail.sLastUpdateDate = Convert.ToDateTime(oRow["ModifyDatetime"].ToString()).ToString("dd MMM yyyy HH:mm:ss");
                        oDoctorDetail.nVersion = Convert.ToInt32(oRow["Version"].ToString());
                        oDoctorDetail.nActionType = Convert.ToInt32(oRow["Action"].ToString());
                        oDoctorDetail.sBMDCCode = oRow["BMDCCode"].ToString();
                        oDoctorDetail.sPostStepChange = oRow["PostStpCngName"].ToString();

                        oDoctorDetailList.Add(oDoctorDetail);
                    }
                    myTransaction.Commit();
                }
                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }

                return oDoctorDetailList;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Get RouteInfo")]
        public List<RouteInfo> GetRouteInfo(string sTerritoryID, int nMaxVersion)
        {
            oRouteInfoList = new List<RouteInfo> { };
            DataTable oTable = new DataTable();
            BLDoctorTerritoryMapping oBL = new BLDoctorTerritoryMapping();

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    oTable = oBL.GetRouteInfo(sTerritoryID, nMaxVersion, connectionString);
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        RouteInfo oRouteInfo = new RouteInfo();
                        oRouteInfo.sTerritoryID = oRow["TerrID"].ToString().ToUpper();
                        oRouteInfo.nRouteID = Convert.ToInt32(oRow["RID"].ToString());
                        oRouteInfo.sRouteName = txtInfo.ToTitleCase(oRow["RName"].ToString().Trim());
                        oRouteInfo.nVersion = Convert.ToInt32(oRow["Version"].ToString());
                        oRouteInfo.nActionType = Convert.ToInt32(oRow["Action"].ToString());

                        oRouteInfoList.Add(oRouteInfo);
                    }
                    myTransaction.Commit();
                }

                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }

                return oRouteInfoList;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //[WebMethod(Description = "Method to Get UserInfo")]
        //public List<UserLoginInfo> GetActiveUserInfo(string sGDDBID)
        //{
        //    oUserLoginInfoList = new List<UserLoginInfo> { };
        //    UserInfo oUserInfo = new UserInfo();
        //    UserLoginInfo oUserLoginInfo = new UserLoginInfo();
        //    EmployeeInfo oEmployeeInfo = new EmployeeInfo();
        //    BLEmployeeInfo oBLEmployeeInfo = new BLEmployeeInfo();
        //    SFRegiInfo oSFRegiInfo = new SFRegiInfo();
        //    Territory oTerritory = new Territory();
        //    BLUserInfo oBLUserInfo = new BLUserInfo();
        //    BLSFRegiInfo oBL = new BLSFRegiInfo();
        //    BLTerritory oBLTerritory = new BLTerritory();
        //    DataTable oTable = new DataTable();

        //    try
        //    {
        //        //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
        //        NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
        //        string connectionString = oValues["ConnectionString2"].ToString();
        //        //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

        //        SqlConnection myConnection = new SqlConnection(connectionString);
        //        myConnection.Open();
        //        // Start transaction.
        //        SqlTransaction myTransaction = myConnection.BeginTransaction();
        //        // Assign command in the current transaction.
        //        SqlCommand myCommand = new SqlCommand();
        //        myCommand.Transaction = myTransaction;

        //        try
        //        {
        //            oUserInfo = oBLUserInfo.GetUserInfo(sGDDBID, connectionString);
        //            if (oUserInfo.IsNew)
        //            {
        //                oEmployeeInfo = oBLEmployeeInfo.GetEmployeeInfo(sGDDBID, connectionString);
        //                if (oEmployeeInfo.IsNew)
        //                {
        //                    oUserLoginInfo.sGDDBID = "Invalid GDDBID";
        //                    oUserLoginInfo.sEmpCode = "";
        //                    oUserLoginInfo.sName = "";
        //                    oUserLoginInfo.sTerritoryID = "";
        //                    oUserLoginInfo.sSecQues = "";
        //                    oUserLoginInfo.sSecQuesAns = "";
        //                    oUserLoginInfo.sPassword = "";
        //                    oUserLoginInfo.sMobile = "";
        //                    oUserLoginInfo.dEntryDate = DateTime.Now;
        //                    oUserLoginInfo.dLastUpdateDate = DateTime.Now;
        //                    oUserLoginInfo.nVersion = 0;
        //                    oUserLoginInfo.nCommandVersion = 0;
        //                    oUserLoginInfo.nAppConfigVersion = 0;
        //                    oUserLoginInfo.nDoctorVersion = 0;
        //                    oUserLoginInfo.nDoctorReqVersion = 0;
        //                    oUserLoginInfo.nDoctorLogVersion = 0;
        //                    oUserLoginInfo.nRouteVersion = 0;
        //                    oUserLoginInfo.nDegreeVersion = 0;
        //                    oUserLoginInfo.nSpecialtyVersion = 0;
        //                    oUserLoginInfo.nSalutationVersion = 0;
        //                    oUserLoginInfo.nDistrictVersion = 0;
        //                    oUserLoginInfo.nUpazillaVersion = 0;
        //                    oUserLoginInfo.nLineSpeProductVersion = 0;
        //                    oUserLoginInfo.nGimmickVersion = 0;
        //                    oUserLoginInfo.nSampleVersion = 0;
        //                    oUserLoginInfo.nHolidayVersion = 0;
        //                    oUserLoginInfo.nBrandVersion = 0;
        //                    oUserLoginInfo.nReasonVersion = 0;
        //                    oUserLoginInfo.nPVPVersion = 0;
        //                    oUserLoginInfo.nPVPWorkingDayVersion = 0;
        //                    oUserLoginInfo.nDCRVersion = 0;
        //                    oUserLoginInfo.nAppVersion = 0;
        //                    oUserLoginInfo.nNoOfTargetDoctor = 0;
        //                    oUserLoginInfo.nIsActive = 0;
        //                    oUserLoginInfoList.Add(oUserLoginInfo);
        //                }
        //                else
        //                {
        //                    oSFRegiInfo = oBL.GetSFInfo(sGDDBID, connectionString);
        //                    if (oSFRegiInfo.IsNew)
        //                    {
        //                        oUserLoginInfo.sGDDBID = oEmployeeInfo.GDDBID;
        //                        oUserLoginInfo.sEmpCode = oEmployeeInfo.EmpCode;
        //                        oUserLoginInfo.sName = "";
        //                        oTerritory = oBLTerritory.GetTerritory(oEmployeeInfo.TerritoryID, connectionString);
        //                        oUserLoginInfo.sTerritoryID = oTerritory.TerritoryCode.ToUpper();
        //                        oUserLoginInfo.sSecQues = "";
        //                        oUserLoginInfo.sSecQuesAns = "";
        //                        oUserLoginInfo.sPassword = "";
        //                        oUserLoginInfo.sMobile = "";
        //                        oUserLoginInfo.dEntryDate = DateTime.Now;
        //                        oUserLoginInfo.dLastUpdateDate = DateTime.Now;
        //                        oUserLoginInfo.nVersion = 1;
        //                        oUserLoginInfo.nCommandVersion = 1;
        //                        oUserLoginInfo.nAppConfigVersion = 1;
        //                        oUserLoginInfo.nDoctorVersion = 1;
        //                        oUserLoginInfo.nDoctorReqVersion = 1;
        //                        oUserLoginInfo.nDoctorLogVersion = 1;
        //                        oUserLoginInfo.nRouteVersion = 1;
        //                        oUserLoginInfo.nDegreeVersion = 1;
        //                        oUserLoginInfo.nSpecialtyVersion = 1;
        //                        oUserLoginInfo.nSalutationVersion = 1;
        //                        oUserLoginInfo.nDistrictVersion = 1;
        //                        oUserLoginInfo.nUpazillaVersion = 1;
        //                        oUserLoginInfo.nLineSpeProductVersion = 1;
        //                        oUserLoginInfo.nGimmickVersion = 1;
        //                        oUserLoginInfo.nSampleVersion = 1;
        //                        oUserLoginInfo.nHolidayVersion = 1;
        //                        oUserLoginInfo.nBrandVersion = 1;
        //                        oUserLoginInfo.nReasonVersion = 1;
        //                        oUserLoginInfo.nPVPVersion = 1;
        //                        oUserLoginInfo.nPVPWorkingDayVersion = 1;
        //                        oUserLoginInfo.nDCRVersion = 1;
        //                        oUserLoginInfo.nAppVersion = 1;
        //                        oUserLoginInfo.nNoOfTargetDoctor = oBLUserInfo.GetNoOfTargetDoctor(myConnection, myTransaction, oTerritory.TerritoryCode);
        //                        oUserLoginInfo.nIsActive = 1;
        //                        oUserLoginInfoList.Add(oUserLoginInfo);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                oTable = oBL.GetActiveSFRegInfo(sGDDBID, connectionString);
        //                foreach (DataRow oRow in oTable.Rows)
        //                {
        //                    oUserLoginInfo.sGDDBID = oRow["GDDBID"].ToString();
        //                    oUserLoginInfo.sEmpCode = oRow["EmpCode"].ToString();
        //                    oUserLoginInfo.sName = oRow["Name"].ToString();
        //                    oUserLoginInfo.sTerritoryID = oRow["TerritoryCode"].ToString().ToUpper();
        //                    oUserLoginInfo.sSecQues = oRow["SecQues"].ToString();
        //                    oUserLoginInfo.sSecQuesAns = oRow["SecQuesAns"].ToString();
        //                    oUserLoginInfo.sPassword = DAAccess.Decrypt(oRow["Password"].ToString());
        //                    oUserLoginInfo.sMobile = oRow["Mobile"].ToString();
        //                    oUserLoginInfo.dEntryDate = Convert.ToDateTime(oRow["EntryDate"]);
        //                    oUserLoginInfo.dLastUpdateDate = Convert.ToDateTime(oRow["LastUpdateDate"]);
        //                    oUserLoginInfo.nVersion = Convert.ToInt32(oRow["Version"]);
        //                    oUserLoginInfo.nCommandVersion = Convert.ToInt32(oRow["CommandVersion"]);
        //                    oUserLoginInfo.nAppConfigVersion = Convert.ToInt32(oRow["AppConfigVersion"]);
        //                    oUserLoginInfo.nDoctorVersion = Convert.ToInt32(oRow["DoctorVersion"]);
        //                    oUserLoginInfo.nDoctorReqVersion = Convert.ToInt32(oRow["DoctorReqVersion"]);
        //                    oUserLoginInfo.nDoctorLogVersion = Convert.ToInt32(oRow["DoctorLogVersion"]);
        //                    oUserLoginInfo.nRouteVersion = Convert.ToInt32(oRow["RouteVersion"]);
        //                    oUserLoginInfo.nDegreeVersion = Convert.ToInt32(oRow["DegreeVersion"]);
        //                    oUserLoginInfo.nSpecialtyVersion = Convert.ToInt32(oRow["SpecialtyVersion"]);
        //                    oUserLoginInfo.nSalutationVersion = Convert.ToInt32(oRow["SalutationVersion"]);
        //                    oUserLoginInfo.nDistrictVersion = Convert.ToInt32(oRow["DistrictVersion"]);
        //                    oUserLoginInfo.nUpazillaVersion = Convert.ToInt32(oRow["UpazillaVersion"]);
        //                    oUserLoginInfo.nLineSpeProductVersion = Convert.ToInt32(oRow["LineSpeProductVersion"]);
        //                    oUserLoginInfo.nGimmickVersion = Convert.ToInt32(oRow["GimmickVersion"]);
        //                    oUserLoginInfo.nSampleVersion = Convert.ToInt32(oRow["SampleVersion"]);
        //                    oUserLoginInfo.nHolidayVersion = Convert.ToInt32(oRow["HolidayVersion"]);
        //                    oUserLoginInfo.nBrandVersion = Convert.ToInt32(oRow["BrandVersion"]);
        //                    oUserLoginInfo.nReasonVersion = Convert.ToInt32(oRow["ReasonVersion"]);
        //                    oUserLoginInfo.nPVPVersion = Convert.ToInt32(oRow["PVPVersion"]);
        //                    oUserLoginInfo.nPVPWorkingDayVersion = Convert.ToInt32(oRow["PVPWorkingDayVersion"]);
        //                    oUserLoginInfo.nDCRVersion = Convert.ToInt32(oRow["DCRVersion"]);
        //                    oUserLoginInfo.nAppVersion = Convert.ToInt32(oRow["AppVersion"]);
        //                    oUserLoginInfo.nNoOfTargetDoctor = Convert.ToInt32(oRow["NoOfTargetDoctor"]);
        //                    oUserLoginInfo.nIsActive = Convert.ToInt32(oRow["IsActive"]);
        //                    oUserLoginInfoList.Add(oUserLoginInfo);
        //                }

        //            }
        //            myTransaction.Commit();
        //        }
        //        catch (Exception e)
        //        {
        //            myTransaction.Rollback();
        //        }
        //        finally
        //        {
        //            myConnection.Close();
        //        }
        //        return oUserLoginInfoList;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        [WebMethod(Description = "Method to Get UserInfo")]
        public List<UserLoginInfo> GetActiveUserInfo(string sGDDBID)
        {
            oUserLoginInfoList = new List<UserLoginInfo> { };
            UserInfo oUserInfo = new UserInfo();
            UserLoginInfo oUserLoginInfo = new UserLoginInfo();
            EmployeeInfo oEmployeeInfo = new EmployeeInfo();
            EmployeeInfos oEmployeeInfos = new EmployeeInfos();
            BLEmployeeInfo oBLEmployeeInfo = new BLEmployeeInfo();
            SFRegiInfo oSFRegiInfo = new SFRegiInfo();
            Territory oTerritory = new Territory();
            BLUserInfo oBLUserInfo = new BLUserInfo();
            BLSFRegiInfo oBL = new BLSFRegiInfo();
            BLTerritory oBLTerritory = new BLTerritory();
            DataTable oTable = new DataTable();

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    //oEmployeeInfo = oBLEmployeeInfo.GetEmployeeInfo(sGDDBID, connectionString);

                    oEmployeeInfos = oBLEmployeeInfo.GetEmployeeInfos(sGDDBID, connectionString);

                    foreach (EmployeeInfo oEmpInfo in oEmployeeInfos)
                    {
                        oEmployeeInfo = new EmployeeInfo();
                        oEmployeeInfo = oEmpInfo;
                        if (oEmployeeInfo.IsActive)
                            break;
                    }

                    if (!oEmployeeInfo.IsActive)
                    {
                        if (oEmployeeInfo.IsNew)
                            oUserLoginInfo.sGDDBID = "Invalid GDDBID.";
                        else
                            oUserLoginInfo.sGDDBID = "Inactive Employee.";
                        oUserLoginInfo.sEmpCode = "";
                        oUserLoginInfo.sName = "";
                        oUserLoginInfo.sTerritoryID = "";
                        oUserLoginInfo.sSecQues = "";
                        oUserLoginInfo.sSecQuesAns = "";
                        oUserLoginInfo.sPassword = "";
                        oUserLoginInfo.sMobile = "";
                        oUserLoginInfo.dEntryDate = DateTime.Now;
                        oUserLoginInfo.dLastUpdateDate = DateTime.Now;
                        oUserLoginInfo.nVersion = 0;
                        oUserLoginInfo.nCommandVersion = 0;
                        oUserLoginInfo.nAppConfigVersion = 0;
                        oUserLoginInfo.nDoctorVersion = 0;
                        oUserLoginInfo.nDoctorReqVersion = 0;
                        oUserLoginInfo.nDoctorLogVersion = 0;
                        oUserLoginInfo.nRouteVersion = 0;
                        oUserLoginInfo.nDegreeVersion = 0;
                        oUserLoginInfo.nSpecialtyVersion = 0;
                        oUserLoginInfo.nSalutationVersion = 0;
                        oUserLoginInfo.nDistrictVersion = 0;
                        oUserLoginInfo.nUpazillaVersion = 0;
                        oUserLoginInfo.nLineSpeProductVersion = 0;
                        oUserLoginInfo.nGimmickVersion = 0;
                        oUserLoginInfo.nSampleVersion = 0;
                        oUserLoginInfo.nHolidayVersion = 0;
                        oUserLoginInfo.nBrandVersion = 0;
                        oUserLoginInfo.nReasonVersion = 0;
                        oUserLoginInfo.nPVPVersion = 0;
                        oUserLoginInfo.nPVPWorkingDayVersion = 0;
                        oUserLoginInfo.nDCRVersion = 0;
                        oUserLoginInfo.nAppVersion = 0;
                        oUserLoginInfo.nNoOfTargetDoctor = 0;
                        oUserLoginInfo.nUserType = 0;
                        oUserLoginInfo.nIsActive = 0;
                        oUserLoginInfoList.Add(oUserLoginInfo);
                    }
                    else
                    {
                        oSFRegiInfo = oBL.GetSFInfo(sGDDBID, connectionString);
                        if (oSFRegiInfo.IsNew)
                        {
                            oUserLoginInfo.sGDDBID = oEmployeeInfo.GDDBID.ToUpper();
                            oUserLoginInfo.sEmpCode = oEmployeeInfo.EmpCode;
                            oUserLoginInfo.sName = "";
                            oTerritory = oBLTerritory.GetTerritory(oEmployeeInfo.TerritoryID, connectionString);
                            oUserLoginInfo.sTerritoryID = oTerritory.TerritoryCode.ToUpper();
                            oUserLoginInfo.sSecQues = "";
                            oUserLoginInfo.sSecQuesAns = "";
                            oUserLoginInfo.sPassword = "";
                            oUserLoginInfo.sMobile = "";
                            oUserLoginInfo.dEntryDate = DateTime.Now;
                            oUserLoginInfo.dLastUpdateDate = DateTime.Now;
                            oUserLoginInfo.nVersion = 1;
                            oUserLoginInfo.nCommandVersion = 1;
                            oUserLoginInfo.nAppConfigVersion = 1;
                            oUserLoginInfo.nDoctorVersion = 1;
                            oUserLoginInfo.nDoctorReqVersion = 1;
                            oUserLoginInfo.nDoctorLogVersion = 1;
                            oUserLoginInfo.nRouteVersion = 1;
                            oUserLoginInfo.nDegreeVersion = 1;
                            oUserLoginInfo.nSpecialtyVersion = 1;
                            oUserLoginInfo.nSalutationVersion = 1;
                            oUserLoginInfo.nDistrictVersion = 1;
                            oUserLoginInfo.nUpazillaVersion = 1;
                            oUserLoginInfo.nLineSpeProductVersion = 1;
                            oUserLoginInfo.nGimmickVersion = 1;
                            oUserLoginInfo.nSampleVersion = 1;
                            oUserLoginInfo.nHolidayVersion = 1;
                            oUserLoginInfo.nBrandVersion = 1;
                            oUserLoginInfo.nReasonVersion = 1;
                            oUserLoginInfo.nPVPVersion = 1;
                            oUserLoginInfo.nPVPWorkingDayVersion = 1;
                            oUserLoginInfo.nDCRVersion = 1;
                            oUserLoginInfo.nAppVersion = 1;
                            oUserLoginInfo.nNoOfTargetDoctor = oBLUserInfo.GetNoOfTargetDoctor(myConnection, myTransaction, oTerritory.TerritoryCode);
                            oUserLoginInfo.nUserType = oTerritory.WorkAreaID;
                            oUserLoginInfo.nIsActive = 1;
                            oUserLoginInfoList.Add(oUserLoginInfo);
                        }
                        else
                        {
                            oTable = oBL.GetActiveSFRegInfo(sGDDBID, connectionString);
                            foreach (DataRow oRow in oTable.Rows)
                            {
                                oUserLoginInfo.sGDDBID = oRow["GDDBID"].ToString().ToUpper();
                                oUserLoginInfo.sEmpCode = oRow["EmpCode"].ToString();
                                oUserLoginInfo.sName = oRow["Name"].ToString();
                                oUserLoginInfo.sTerritoryID = oRow["TerritoryCode"].ToString().ToUpper();
                                oUserLoginInfo.sSecQues = oRow["SecQues"].ToString();
                                oUserLoginInfo.sSecQuesAns = oRow["SecQuesAns"].ToString();
                                oUserLoginInfo.sPassword = DAAccess.Decrypt(oRow["Password"].ToString());
                                oUserLoginInfo.sMobile = oRow["Mobile"].ToString();
                                oUserLoginInfo.dEntryDate = Convert.ToDateTime(oRow["EntryDate"]);
                                oUserLoginInfo.dLastUpdateDate = Convert.ToDateTime(oRow["LastUpdateDate"]);
                                oUserLoginInfo.nVersion = Convert.ToInt32(oRow["Version"]);
                                oUserLoginInfo.nCommandVersion = Convert.ToInt32(oRow["CommandVersion"]);
                                oUserLoginInfo.nAppConfigVersion = Convert.ToInt32(oRow["AppConfigVersion"]);
                                oUserLoginInfo.nDoctorVersion = Convert.ToInt32(oRow["DoctorVersion"]);
                                oUserLoginInfo.nDoctorReqVersion = Convert.ToInt32(oRow["DoctorReqVersion"]);
                                oUserLoginInfo.nDoctorLogVersion = Convert.ToInt32(oRow["DoctorLogVersion"]);
                                oUserLoginInfo.nRouteVersion = Convert.ToInt32(oRow["RouteVersion"]);
                                oUserLoginInfo.nDegreeVersion = Convert.ToInt32(oRow["DegreeVersion"]);
                                oUserLoginInfo.nSpecialtyVersion = Convert.ToInt32(oRow["SpecialtyVersion"]);
                                oUserLoginInfo.nSalutationVersion = Convert.ToInt32(oRow["SalutationVersion"]);
                                oUserLoginInfo.nDistrictVersion = Convert.ToInt32(oRow["DistrictVersion"]);
                                oUserLoginInfo.nUpazillaVersion = Convert.ToInt32(oRow["UpazillaVersion"]);
                                oUserLoginInfo.nLineSpeProductVersion = Convert.ToInt32(oRow["LineSpeProductVersion"]);
                                oUserLoginInfo.nGimmickVersion = Convert.ToInt32(oRow["GimmickVersion"]);
                                oUserLoginInfo.nSampleVersion = Convert.ToInt32(oRow["SampleVersion"]);
                                oUserLoginInfo.nHolidayVersion = Convert.ToInt32(oRow["HolidayVersion"]);
                                oUserLoginInfo.nBrandVersion = Convert.ToInt32(oRow["BrandVersion"]);
                                oUserLoginInfo.nReasonVersion = Convert.ToInt32(oRow["ReasonVersion"]);
                                oUserLoginInfo.nPVPVersion = Convert.ToInt32(oRow["PVPVersion"]);
                                oUserLoginInfo.nPVPWorkingDayVersion = Convert.ToInt32(oRow["PVPWorkingDayVersion"]);
                                oUserLoginInfo.nDCRVersion = Convert.ToInt32(oRow["DCRVersion"]);
                                oUserLoginInfo.nAppVersion = Convert.ToInt32(oRow["AppVersion"]);
                                oUserLoginInfo.nNoOfTargetDoctor = Convert.ToInt32(oRow["NoOfTargetDoctor"]);
                                oUserLoginInfo.nUserType = Convert.ToInt32(oRow["UserType"]);
                                oUserLoginInfo.nIsActive = Convert.ToInt32(oRow["IsActive"]);
                                oUserLoginInfoList.Add(oUserLoginInfo);
                            }

                            if (oTable.Rows.Count == 0)
                            {
                                oUserLoginInfo.sGDDBID = "User Information is not available in FAST CAR.";
                                oUserLoginInfo.sEmpCode = "";
                                oUserLoginInfo.sName = "";
                                oUserLoginInfo.sTerritoryID = "";
                                oUserLoginInfo.sSecQues = "";
                                oUserLoginInfo.sSecQuesAns = "";
                                oUserLoginInfo.sPassword = "";
                                oUserLoginInfo.sMobile = "";
                                oUserLoginInfo.dEntryDate = DateTime.Now;
                                oUserLoginInfo.dLastUpdateDate = DateTime.Now;
                                oUserLoginInfo.nIsActive = -1;
                                oUserLoginInfoList.Add(oUserLoginInfo);
                            }

                        }
                    }

                    myTransaction.Commit();
                }
                catch (Exception e)
                {
                    oUserLoginInfo.sGDDBID = e.Message.ToString();
                    oUserLoginInfo.sEmpCode = "";
                    oUserLoginInfo.sName = "";
                    oUserLoginInfo.sTerritoryID = "";
                    oUserLoginInfo.sSecQues = "";
                    oUserLoginInfo.sSecQuesAns = "";
                    oUserLoginInfo.sPassword = "";
                    oUserLoginInfo.sMobile = "";
                    oUserLoginInfo.dEntryDate = DateTime.Now;
                    oUserLoginInfo.dLastUpdateDate = DateTime.Now;
                    oUserLoginInfo.nIsActive = -1;
                    oUserLoginInfoList.Add(oUserLoginInfo);
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
            }
            catch (Exception ex)
            {
                oUserLoginInfo.sGDDBID = ex.Message.ToString();
                oUserLoginInfo.sEmpCode = "";
                oUserLoginInfo.sName = "";
                oUserLoginInfo.sTerritoryID = "";
                oUserLoginInfo.sSecQues = "";
                oUserLoginInfo.sSecQuesAns = "";
                oUserLoginInfo.sPassword = "";
                oUserLoginInfo.sMobile = "";
                oUserLoginInfo.dEntryDate = DateTime.Now;
                oUserLoginInfo.dLastUpdateDate = DateTime.Now;
                oUserLoginInfo.nIsActive = -1;
                oUserLoginInfoList.Add(oUserLoginInfo);
                //throw new Exception(ex.Message);
            }

            return oUserLoginInfoList;
        }

        //[WebMethod(Description = "Method to Get UserInfo")]
        //public List<UserLoginInfo> GetActiveUserInfo(string sGDDBID)
        //{
        //    try
        //    {
        //        oUserLoginInfoList = new List<UserLoginInfo> { };
        //        UserInfo oUserInfo = new UserInfo();
        //        UserLoginInfo oUserLoginInfo = new UserLoginInfo();
        //        EmployeeInfo oEmployeeInfo = new EmployeeInfo();
        //        BLEmployeeInfo oBLEmployeeInfo = new BLEmployeeInfo();
        //        SFRegiInfo oSFRegiInfo = new SFRegiInfo();
        //        Territory oTerritory = new Territory();
        //        BLUserInfo oBLUserInfo = new BLUserInfo();
        //        BLSFRegiInfo oBL = new BLSFRegiInfo();
        //        BLTerritory oBLTerritory = new BLTerritory();
        //        DataTable oTable = new DataTable();

        //            oUserInfo = oBLUserInfo.GetActiveUserInfoByGDDBID(sGDDBID);
        //            if (oUserInfo.IsNew)
        //            {
        //                oEmployeeInfo = oBLEmployeeInfo.GetActiveEmployeeInfoByGDDBID(sGDDBID);
        //                if (oEmployeeInfo.IsNew)
        //                {
        //                    oUserLoginInfo.sGDDBID = "Invalid GDDBID";
        //                    oUserLoginInfo.sEmpCode = "";
        //                    oUserLoginInfo.sName = "";
        //                    oUserLoginInfo.sTerritoryID = "";
        //                    oUserLoginInfo.sSecQues = "";
        //                    oUserLoginInfo.sSecQuesAns = "";
        //                    oUserLoginInfo.sPassword = "";
        //                    oUserLoginInfo.sMobile = "";
        //                    oUserLoginInfo.dEntryDate = DateTime.Now;
        //                    oUserLoginInfo.dLastUpdateDate = DateTime.Now;
        //                    oUserLoginInfo.nVersion = 0;
        //                    oUserLoginInfo.nCommandVersion = 0;
        //                    oUserLoginInfo.nAppConfigVersion = 0;
        //                    oUserLoginInfo.nDoctorVersion = 0;
        //                    oUserLoginInfo.nRouteVersion = 0;
        //                    oUserLoginInfo.nGimmickVersion = 0;
        //                    oUserLoginInfo.nSampleVersion = 0;
        //                    oUserLoginInfo.nHolidayVersion = 0;
        //                    oUserLoginInfo.nBrandVersion = 0;
        //                    oUserLoginInfo.nReasonVersion = 0;
        //                    oUserLoginInfo.nPVPVersion = 0;
        //                    oUserLoginInfo.nDCRVersion = 0;
        //                    oUserLoginInfo.nAppVersion = 0;
        //                    oUserLoginInfo.nNoOfTargetDoctor = 0;
        //                    oUserLoginInfo.nIsActive = 0;
        //                    oUserLoginInfoList.Add(oUserLoginInfo);
        //                }
        //                else
        //                {
        //                    oSFRegiInfo = oBL.GetActiveSFInfoByGDDBID(sGDDBID);
        //                    if (oSFRegiInfo.IsNew)
        //                    {
        //                        oUserLoginInfo.sGDDBID = oEmployeeInfo.GDDBID;
        //                        oUserLoginInfo.sEmpCode = oEmployeeInfo.EmpCode;
        //                        oUserLoginInfo.sName = "";
        //                        oTerritory = oBLTerritory.GetTerritory(oEmployeeInfo.TerritoryID);
        //                        oUserLoginInfo.sTerritoryID = oTerritory.TerritoryCode;
        //                        oUserLoginInfo.sSecQues = "";
        //                        oUserLoginInfo.sSecQuesAns = "";
        //                        oUserLoginInfo.sPassword = "";
        //                        oUserLoginInfo.sMobile = "";
        //                        oUserLoginInfo.dEntryDate = DateTime.Now;
        //                        oUserLoginInfo.dLastUpdateDate = DateTime.Now;
        //                        oUserLoginInfo.nVersion = 1;
        //                        oUserLoginInfo.nCommandVersion = 1;
        //                        oUserLoginInfo.nAppConfigVersion = 1;
        //                        oUserLoginInfo.nDoctorVersion = 1;
        //                        oUserLoginInfo.nRouteVersion = 1;
        //                        oUserLoginInfo.nGimmickVersion = 1;
        //                        oUserLoginInfo.nSampleVersion = 1;
        //                        oUserLoginInfo.nHolidayVersion = 1;
        //                        oUserLoginInfo.nBrandVersion = 1;
        //                        oUserLoginInfo.nReasonVersion = 1;
        //                        oUserLoginInfo.nPVPVersion = 1;
        //                        oUserLoginInfo.nDCRVersion = 1;
        //                        oUserLoginInfo.nAppVersion = 1;
        //                        oUserLoginInfo.nNoOfTargetDoctor = oBLUserInfo.GetNoOfTargetDoctor(oTerritory.TerritoryCode);
        //                        oUserLoginInfo.nIsActive = 1;
        //                        oUserLoginInfoList.Add(oUserLoginInfo);
        //                    }
        //                }

        //            }
        //            else
        //            {
        //                oTable = oBL.GetActiveSFRegInfo(sGDDBID);
        //                foreach (DataRow oRow in oTable.Rows)
        //                {
        //                    oUserLoginInfo.sGDDBID = oRow["GDDBID"].ToString();
        //                    oUserLoginInfo.sEmpCode = oRow["EmpCode"].ToString();
        //                    oUserLoginInfo.sName = oRow["Name"].ToString();
        //                    oUserLoginInfo.sTerritoryID = oRow["TerritoryCode"].ToString();
        //                    oUserLoginInfo.sSecQues = oRow["SecQues"].ToString();
        //                    oUserLoginInfo.sSecQuesAns = oRow["SecQuesAns"].ToString();
        //                    oUserLoginInfo.sPassword = DAAccess.Decrypt(oRow["Password"].ToString());
        //                    oUserLoginInfo.sMobile = oRow["Mobile"].ToString();
        //                    oUserLoginInfo.dEntryDate = Convert.ToDateTime(oRow["EntryDate"]);
        //                    oUserLoginInfo.dLastUpdateDate = Convert.ToDateTime(oRow["LastUpdateDate"]);
        //                    oUserLoginInfo.nVersion = Convert.ToInt32(oRow["Version"]);
        //                    oUserLoginInfo.nCommandVersion = Convert.ToInt32(oRow["CommandVersion"]);
        //                    oUserLoginInfo.nAppConfigVersion = Convert.ToInt32(oRow["AppConfigVersion"]);
        //                    oUserLoginInfo.nDoctorVersion = Convert.ToInt32(oRow["DoctorVersion"]);
        //                    oUserLoginInfo.nRouteVersion = Convert.ToInt32(oRow["RouteVersion"]);
        //                    oUserLoginInfo.nGimmickVersion = Convert.ToInt32(oRow["GimmickVersion"]);
        //                    oUserLoginInfo.nSampleVersion = Convert.ToInt32(oRow["SampleVersion"]);
        //                    oUserLoginInfo.nHolidayVersion = Convert.ToInt32(oRow["HolidayVersion"]);
        //                    oUserLoginInfo.nBrandVersion = Convert.ToInt32(oRow["BrandVersion"]);
        //                    oUserLoginInfo.nReasonVersion = Convert.ToInt32(oRow["ReasonVersion"]);
        //                    oUserLoginInfo.nPVPVersion = Convert.ToInt32(oRow["PVPVersion"]);
        //                    oUserLoginInfo.nDCRVersion = Convert.ToInt32(oRow["DCRVersion"]);
        //                    oUserLoginInfo.nAppVersion = Convert.ToInt32(oRow["AppVersion"]);
        //                    oUserLoginInfo.nNoOfTargetDoctor = Convert.ToInt32(oRow["NoOfTargetDoctor"]);
        //                    oUserLoginInfo.nIsActive = Convert.ToInt32(oRow["IsActive"]);
        //                    oUserLoginInfoList.Add(oUserLoginInfo);
        //                }

        //            }
        //        return oUserLoginInfoList;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        [WebMethod(Description = "Method to SecQuesList")]
        public SecQuesInfos GetAllSecQuesInfo()
        {
            //oSecQuesInfoList = new List<SecQuesInfo> { };
            SecQuesInfo oSecQuesInfo = new SecQuesInfo();
            SecQuesInfos oSecQuesInfos = new SecQuesInfos();
            BLSecQuesInfo oBL = new BLSecQuesInfo();

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    oSecQuesInfos = oBL.GetSecQuesInfos(connectionString);
                    myTransaction.Commit();
                }
                catch (Exception e)
                {
                    oSecQuesInfo.SecQues = e.Message.ToString();
                    oSecQuesInfo.ActionType = -1;
                    oSecQuesInfos.Add(oSecQuesInfo);
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
            }

            catch (Exception ex)
            {
                oSecQuesInfo.SecQues = ex.Message.ToString();
                oSecQuesInfo.ActionType = -1;
                oSecQuesInfos.Add(oSecQuesInfo);
                //throw new Exception(ex.Message);
            }

            return oSecQuesInfos;
        }

        [WebMethod(Description = "Method to Get UserManagementInfo")]
        public UserManagementInfos GetUserManagementInfo()
        {
            UserManagementInfo oUserManagementInfo = new UserManagementInfo();
            UserManagementInfos oUserManagementInfos = new UserManagementInfos();
            BLUserManagementInfo oBL = new BLUserManagementInfo();
            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    oUserManagementInfos = oBL.GetUserManagementInfos(connectionString);
                    myTransaction.Commit();
                }
                catch (Exception e)
                {
                    oUserManagementInfo.MinimumPasswordLength = -1;
                    oUserManagementInfos.Add(oUserManagementInfo);
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }               
            }

            catch (Exception ex)
            {
                oUserManagementInfo.MinimumPasswordLength = -1;
                oUserManagementInfos.Add(oUserManagementInfo);
                //throw new Exception(ex.Message);
            }

            return oUserManagementInfos;
        }

        //[WebMethod(Description = "Method to Save SFInfo For Registration")]
        //public int SaveSFInfoForReg(string sGDDBID, string sEmpCode, string sTerritoryID, string sSQ, string sSQA, string sPassword, string sMobileNo)
        //{
        //    //int nAuthenTicket = 0;
        //    //try
        //    //{
        //    //    SFRegiInfo oSFRegInfo = new SFRegiInfo();
        //    //    UserInfo oUserInfo = new UserInfo();
        //    //    BLSFRegiInfo oBL = new BLSFRegiInfo();
        //    //    BLUserInfo oBLUserInfo = new BLUserInfo();
        //    //    BLSecQuesInfo oBLSecuQues = new BLSecQuesInfo();
        //    //    BLEmployeeInfo oBLEmployeeInfo = new BLEmployeeInfo();
        //    //    BLTerritory oBLTerritory = new BLTerritory();

        //    //    int nSecQuesID = oBLSecuQues.GetSecQuesID(sSQ);
        //    //    int nEmployeeID = oBLEmployeeInfo.GetEmployeeID(sEmpCode);
        //    //    int nTerritoryID = oBLTerritory.GetTerritoryID(sTerritoryID);

        //    //    oSFRegInfo.GDDBID = sGDDBID;
        //    //    oSFRegInfo.EmployeeID = nEmployeeID;
        //    //    oSFRegInfo.TerritoryID = nTerritoryID;
        //    //    oSFRegInfo.SecQuesID = nSecQuesID;
        //    //    oSFRegInfo.SecQuesAns = sSQA;
        //    //    oSFRegInfo.PassWord = DAAccess.Encrypt(sPassword);
        //    //    oSFRegInfo.Message = "";
        //    //    oSFRegInfo.Mobile = sMobileNo;
        //    //    oSFRegInfo.EntryDate = DateTime.Now;
        //    //    oSFRegInfo.LastUpdateDate = DateTime.Now;
        //    //    oSFRegInfo.Version = 1;
        //    //    oSFRegInfo.CommandVersion = 1;
        //    //    oSFRegInfo.CustomerVersion = 1;
        //    //    oSFRegInfo.ProductVersion = 1;
        //    //    oSFRegInfo.ProductBarVersion = 1;
        //    //    oSFRegInfo.OrderVersion = 1;
        //    //    oSFRegInfo.AppConfigVersion = 1;
        //    //    oSFRegInfo.SalesReportVersion = 1;
        //    //    oSFRegInfo.AppVersion = 1;
        //    //    oSFRegInfo.IsActive = true;

        //    //    oUserInfo.GDDBID = sGDDBID;
        //    //    oUserInfo.Version = 1;
        //    //    oUserInfo.CommandVersion = 1;
        //    //    oUserInfo.AppConfigVersion = 1;
        //    //    oUserInfo.DoctorVersion = 1;
        //    //    oUserInfo.RouteVersion = 1;
        //    //    oUserInfo.GimmickVersion = 1;
        //    //    oUserInfo.SampleVersion = 1;
        //    //    oUserInfo.HolidayVersion = 1;
        //    //    oUserInfo.BrandVersion = 1;
        //    //    oUserInfo.ReasonVersion = 1;
        //    //    oUserInfo.PVPVersion = 1;
        //    //    oUserInfo.DCRVersion = 1;
        //    //    oUserInfo.AppVersion = 1;
        //    //    oUserInfo.NoOfTargetDoctor = oBLUserInfo.GetNoOfTargetDoctor(sTerritoryID);
        //    //    oUserInfo.EntryDate = DateTime.Now;
        //    //    oUserInfo.LastUpdateDate = DateTime.Now;
        //    //    oUserInfo.IsActive = true;

        //    //    nAuthenTicket = oBLUserInfo.SaveSFRegInfo(oSFRegInfo, oUserInfo);
        //    //    return nAuthenTicket;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    return nAuthenTicket;
        //    //    throw new Exception(ex.Message);
        //    //}

        //    int nAuthenTicket = 0;

        //    try
        //    {
        //        //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
        //        NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
        //        string connectionString = oValues["ConnectionString2"].ToString();
        //        //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

        //        SqlConnection myConnection = new SqlConnection(connectionString);
        //        myConnection.Open();
        //        // Start transaction.
        //        SqlTransaction myTransaction = myConnection.BeginTransaction();
        //        // Assign command in the current transaction.
        //        SqlCommand myCommand = new SqlCommand();
        //        myCommand.Transaction = myTransaction;
        //        try
        //        {

        //            SFRegiInfo oSFRegInfo = new SFRegiInfo();
        //            UserInfo oUserInfo = new UserInfo();

        //            SqlCommand cmd1 = new SqlCommand();
        //            cmd1.CommandText = @"SELECT SecQuesID FROM [OrderCollectionSystem].[dbo].[SecQuesInfo] WHERE SecQues= '" + sSQ + "'";
        //            cmd1.Connection = myConnection;
        //            cmd1.Transaction = myTransaction;
        //            object o1 = cmd1.ExecuteScalar();
        //            int nSecQuesID = Convert.ToInt32(o1);


        //            SqlCommand cmd2 = new SqlCommand();
        //            cmd2.CommandText = @"SELECT EmployeeID FROM [OrderCollectionSystem].[dbo].[EmployeeInfo] WHERE EmpCode= '" + sEmpCode + "'";
        //            cmd2.Connection = myConnection;
        //            cmd2.Transaction = myTransaction;
        //            object o2 = cmd2.ExecuteScalar();
        //            int nEmployeeID = Convert.ToInt32(o2);


        //            SqlCommand cmd3 = new SqlCommand();
        //            cmd3.CommandText = @"SELECT TerritoryID FROM [OrderCollectionSystem].[dbo].[Territory] WHERE TerritoryCode= '" + sTerritoryID + "'";
        //            cmd3.Connection = myConnection;
        //            cmd3.Transaction = myTransaction;
        //            object o3 = cmd3.ExecuteScalar();
        //            int nTerritoryID = Convert.ToInt32(o3);

        //            //DataTable otblSF = new DataTable();
        //            //string sActiveSF = "SELECT * FROM [GXBDDA-S3017].[OrderCollectionSystem_Test].[dbo].[SFRegiInfo] WHERE GDDBID=@sGDDBID";
        //            //SqlDataAdapter Sfda = new SqlDataAdapter(sActiveSF, connectionString);
        //            //Sfda.SelectCommand.Parameters.Add("@sGDDBID", sGDDBID);
        //            //Sfda.Fill(otblSF);

        //            string sSQL = "";

        //            SqlCommand cmd4 = new SqlCommand();
        //            cmd4.CommandText = @"SElECT MAX(SFRegiID)+ 1 AS NewSFRegiID FROM [OrderCollectionSystem].[dbo].[SFRegiInfo]";
        //            cmd4.Connection = myConnection;
        //            cmd4.Transaction = myTransaction;
        //            object o4 = cmd4.ExecuteScalar();
        //            int nSFID;

        //            if (o4 == DBNull.Value)
        //            {
        //                nSFID = 1;
        //            }
        //            else if (Convert.ToInt32(o4) == -1)
        //            {
        //                nSFID = 1;
        //            }
        //            else
        //            {
        //                nSFID = Convert.ToInt32(o4);
        //            }
        //            oSFRegInfo.ID.SetID(nSFID);
        //            oSFRegInfo.GDDBID = sGDDBID;
        //            oSFRegInfo.EmployeeID = nEmployeeID;
        //            oSFRegInfo.TerritoryID = nTerritoryID;
        //            oSFRegInfo.SecQuesID = nSecQuesID;
        //            oSFRegInfo.SecQuesAns = sSQA;
        //            oSFRegInfo.PassWord = DAAccess.Encrypt(sPassword);
        //            oSFRegInfo.Message = "";
        //            oSFRegInfo.Mobile = sMobileNo;
        //            oSFRegInfo.EntryDate = DateTime.Now;
        //            oSFRegInfo.LastUpdateDate = DateTime.Now;
        //            oSFRegInfo.Version = 1;
        //            oSFRegInfo.CommandVersion = 1;
        //            SqlCommand cmd5 = new SqlCommand();
        //            cmd5.CommandText = @"SELECT MAX(Version) FROM [OrderCollectionSystem].[dbo].[TerritoryWiseCustInfo] WHERE TerritoryID='" + sTerritoryID + "'";
        //            cmd5.Connection = myConnection;
        //            cmd5.Transaction = myTransaction;
        //            object o5 = cmd5.ExecuteScalar();
        //            int nMaxCustomerVersion = 0;
        //            if (o5 == DBNull.Value)
        //            {
        //                nMaxCustomerVersion = 1;
        //            }
        //            else
        //            {
        //                nMaxCustomerVersion = Convert.ToInt32(o5);
        //            }
        //            oSFRegInfo.CustomerVersion = nMaxCustomerVersion;
        //            SqlCommand cmd6 = new SqlCommand();
        //            cmd6.CommandText = @"SELECT MAX(Version) FROM [OrderCollectionSystem].[dbo].[TerritoryWiseProductInfo] WHERE TerritoryID='" + sTerritoryID + "'";
        //            cmd6.Connection = myConnection;
        //            cmd6.Transaction = myTransaction;
        //            object o6 = cmd6.ExecuteScalar();
        //            int nMaxProductVersion = 0;
        //            if (o6 == DBNull.Value)
        //            {
        //                nMaxProductVersion = 1;
        //            }
        //            else
        //            {
        //                nMaxProductVersion = Convert.ToInt32(o6);
        //            }
        //            oSFRegInfo.ProductVersion = nMaxProductVersion;

        //            oSFRegInfo.ProductBarVersion = 1;
        //            oSFRegInfo.OrderVersion = 1;
        //            oSFRegInfo.AppConfigVersion = 1;
        //            oSFRegInfo.SalesReportVersion = 1;
        //            oSFRegInfo.AppVersion = 1;
        //            oSFRegInfo.IsActive = true;

        //            SqlCommand cmd7 = new SqlCommand();
        //            cmd7.CommandText = "SElECT MAX(UserID)+ 1 AS NewUserID FROM [UserInfo]";
        //            cmd7.Connection = myConnection;
        //            cmd7.Transaction = myTransaction;
        //            object o7 = cmd7.ExecuteScalar();
        //            int nUserID = 0;

        //            if (o4 == DBNull.Value)
        //            {
        //                nSFID = 1;
        //            }
        //            else if (Convert.ToInt32(o7) == -1)
        //            {
        //                nUserID = 1;
        //            }
        //            else
        //            {
        //                nUserID = Convert.ToInt32(o7);
        //            }
        //            oUserInfo.ID.SetID(nUserID);
        //            oUserInfo.GDDBID = sGDDBID;
        //            oUserInfo.Version = 1;
        //            oUserInfo.CommandVersion = 1;
        //            oUserInfo.AppConfigVersion = 1;
        //            oUserInfo.DoctorVersion = 1;
        //            oUserInfo.RouteVersion = 1;
        //            oUserInfo.GimmickVersion = 1;
        //            oUserInfo.SampleVersion = 1;
        //            oUserInfo.HolidayVersion = 1;
        //            oUserInfo.BrandVersion = 1;
        //            oUserInfo.ReasonVersion = 1;
        //            oUserInfo.PVPVersion = 1;
        //            oUserInfo.DCRVersion = 1;
        //            oUserInfo.AppVersion = 1;
        //            SqlCommand cmd8 = new SqlCommand();
        //            cmd8.CommandText = "SELECT MinTargetDoctor FROM [TerrWiseTargetDoc] WHERE Territory='" + sTerritoryID + "'";
        //            cmd8.Connection = myConnection;
        //            cmd8.Transaction = myTransaction;
        //            object o8 = cmd8.ExecuteScalar();
        //            int nNoOfTargetDoctor = 0;
        //            if (o8 == DBNull.Value)
        //            {
        //                nNoOfTargetDoctor = 1;
        //            }
        //            else
        //            {
        //                nNoOfTargetDoctor = Convert.ToInt32(o8);
        //            }
        //            oUserInfo.NoOfTargetDoctor = nNoOfTargetDoctor;
        //            oUserInfo.EntryDate = DateTime.Now;
        //            oUserInfo.LastUpdateDate = DateTime.Now;
        //            oUserInfo.IsActive = true;

        //            //                        DataTable oTable;
        //            //    SqlParameter[] oParameters = new SqlParameter[7];
        //            //    try
        //            //    {
        //            //        oParameters[0] = new SqlParameter("@GDDBID", oItem.GDDBID);
        //            //        oParameters[1] = new SqlParameter("@EmployeeID", oItem.EmployeeID);
        //            //        oParameters[2] = new SqlParameter("@TerritoryID", oItem.TerritoryID);
        //            //        oParameters[3] = new SqlParameter("@SecQuesID", oItem.SecQuesID);
        //            //        oParameters[4] = new SqlParameter("@SecQuesAns", oItem.SecQuesAns);
        //            //        oParameters[5] = new SqlParameter("@PassWord", oItem.PassWord);
        //            //        oParameters[6] = new SqlParameter("@Mobile", oItem.Mobile);
        //            //        oTable = FillDataTable("SFInfoForReg", "[FAST].[dbo].[spSFRegistration]", oParameters);
        //            //    }

        //            //    catch (Exception e)
        //            //    {
        //            //        throw new Exception(e.Message);
        //            //    }
        //            //    return oTable;
        //            //}

        //            int result = 0;
        //            SqlCommand scCommand = new SqlCommand("spSFRegistration", myConnection, myTransaction);
        //            scCommand.CommandType = CommandType.StoredProcedure;
        //            scCommand.Parameters.Add("@GDDBID", SqlDbType.VarChar, 50).Value = sGDDBID;
        //            scCommand.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = nEmployeeID;
        //            scCommand.Parameters.Add("@TerritoryID ", SqlDbType.Int).Value = nTerritoryID;
        //            scCommand.Parameters.Add("@SecQuesID", SqlDbType.Int).Value = nSecQuesID;
        //            scCommand.Parameters.Add("@SecQuesAns", SqlDbType.VarChar, 50).Value = sSQA;
        //            scCommand.Parameters.Add("@PassWord", SqlDbType.VarChar, 400).Value = DAAccess.Encrypt(sPassword);
        //            scCommand.Parameters.Add("@Mobile", SqlDbType.VarChar, 50).Value = sMobileNo;
        //            scCommand.Parameters.Add("@CustomerVersion", SqlDbType.Int).Value = nMaxCustomerVersion;
        //            scCommand.Parameters.Add("@ProductVersion", SqlDbType.Int).Value = nMaxProductVersion;
        //            scCommand.Parameters.Add("@result", SqlDbType.Int, 50).Direction = ParameterDirection.Output;
        //            try
        //            {
        //                //if (scCommand.Connection.State == ConnectionState.Closed)
        //                //{
        //                //    scCommand.Connection.Open();
        //                //}
        //                // SqlCommand cmd = new SqlCommand(your_sqlText, your_sqlcon, your_sqlTrans);

        //                //cmd.ExecuteNonQuery(); 
        //                scCommand.ExecuteNonQuery();
        //                result = Convert.ToInt32(scCommand.Parameters["@result"].Value);
        //            }
        //            catch (Exception)
        //            {

        //            }
        //            finally
        //            {
        //                //scCommand.Connection.Close();
        //                //Response.Write(result);
        //            }

        //            //    sSQL = SQL.MakeSQL("INSERT INTO [SFRegiInfo](SFRegiID, GDDBID, EmployeeID, TerritoryID, SecQuesID, SecQuesAns, PassWord, Message, Mobile, EntryDate, LastUpdateDate, Version, CommandVersion, CustomerVersion, ProductVersion, ProductBarVersion, OrderVersion, AppConfigVersion, SalesReportVersion, AppVersion, IsActive) "
        //            //+ " VALUES(%n, %s, %n, %n, %n, %s, %s, %s, %s, %D, %D, %n, %n, %n, %n, %n, %n, %n, %n, %n, %b) "
        //            //, oSFRegInfo.ID.ToInt32, oSFRegInfo.GDDBID, oSFRegInfo.EmployeeID, oSFRegInfo.TerritoryID, oSFRegInfo.SecQuesID, oSFRegInfo.SecQuesAns,
        //            //oSFRegInfo.PassWord, oSFRegInfo.Message, oSFRegInfo.Mobile, oSFRegInfo.EntryDate, oSFRegInfo.LastUpdateDate, oSFRegInfo.Version,
        //            //oSFRegInfo.CommandVersion, oSFRegInfo.CustomerVersion, oSFRegInfo.ProductVersion, oSFRegInfo.ProductBarVersion, oSFRegInfo.OrderVersion,
        //            //oSFRegInfo.AppConfigVersion, oSFRegInfo.SalesReportVersion, oSFRegInfo.AppVersion, oSFRegInfo.IsActive);

        //            sSQL = SQL.MakeSQL("INSERT INTO [UserInfo](UserID, GDDBID, Version, CommandVersion, AppConfigVersion, DoctorVersion, RouteVersion, GimmickVersion, SampleVersion, HolidayVersion, BrandVersion, ReasonVersion, PVPVersion, DCRVersion, AppVersion, NoOfTargetDoctor, EntryDate, LastUpdateDate, IsActive) "
        //                + " VALUES(%n, %s, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %D, %D, %b) "
        //                , oUserInfo.ID.ToInt32, oUserInfo.GDDBID, oUserInfo.Version, oUserInfo.CommandVersion, oUserInfo.AppConfigVersion, oUserInfo.DoctorVersion, oUserInfo.RouteVersion, oUserInfo.GimmickVersion, oUserInfo.SampleVersion, oUserInfo.HolidayVersion, oUserInfo.BrandVersion, oUserInfo.ReasonVersion, oUserInfo.PVPVersion, oUserInfo.DCRVersion, oUserInfo.AppVersion, oUserInfo.NoOfTargetDoctor, oUserInfo.EntryDate, oUserInfo.LastUpdateDate, oUserInfo.IsActive);


        //            SqlDataAdapter InvAdapter = new SqlDataAdapter();
        //            SqlCommand InvCommand = new SqlCommand();
        //            InvCommand = new SqlCommand(sSQL, myConnection);
        //            InvCommand.Transaction = myTransaction;
        //            InvAdapter.InsertCommand = InvCommand;

        //            if (result == 1)
        //            {
        //                InvCommand.ExecuteNonQuery();
        //                nAuthenTicket = 1;
        //            }
        //            //return nAuthenTicket;

        //            // …………………….
        //            // Database operations

        //            // ……………………
        //            myTransaction.Commit();


        //        }
        //        catch (Exception e)
        //        {
        //            myTransaction.Rollback();
        //        }
        //        finally
        //        {
        //            myConnection.Close();
        //        }

        //        return nAuthenTicket;

        //    }
        //    catch (Exception ex)
        //    {
        //        return nAuthenTicket;
        //        throw new Exception(ex.Message);
        //    }
        //}

        [WebMethod(Description = "Method to Save SFInfo For Registration")]
        public string SaveSFInfoForReg(string sGDDBID, string sEmpCode, string sTerritoryID, string sSQ, string sSQA, string sPassword, string sMobileNo)
        {
            SFRegiInfo oSFRegInfo = new SFRegiInfo();
            SecQuesInfo oSecQuesInfo = new SecQuesInfo();
            UserInfo oUserInfo = new UserInfo();
            EmployeeInfo oEmployeeInfo = new EmployeeInfo();
            EmployeeInfos oEmployeeInfos = new EmployeeInfos();
            BLSecQuesInfo oBLSecQuesInfo = new BLSecQuesInfo();
            BLEmployeeInfo oBLEmployeeInfo = new BLEmployeeInfo();
            BLTerritory oBLTerritory = new BLTerritory();
            BLSFRegiInfo oBLSFRegiInfo = new BLSFRegiInfo();
            BLUserInfo oBLUserInfo = new BLUserInfo();
            string sAuthenTicket = "";

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;
                try
                {
                    int nSecQuesID = oBLSecQuesInfo.GetSQID(myConnection, myTransaction, sSQ);
                    //int nEmployeeID = oBLEmployeeInfo.GetEmployeeID(myConnection, myTransaction, sEmpCode);
                    //oEmployeeInfo = oBLEmployeeInfo.GetEmployeeInfo(sGDDBID, connectionString);
                    oEmployeeInfos = oBLEmployeeInfo.GetEmployeeInfos(sGDDBID, connectionString);
                    foreach (EmployeeInfo oEmpInfo in oEmployeeInfos)
                    {
                        oEmployeeInfo = new EmployeeInfo();
                        oEmployeeInfo = oEmpInfo;
                        if (oEmployeeInfo.IsActive)
                            break;
                    }

                    int nTerritoryID = oBLTerritory.GetTerritoryID(myConnection, myTransaction, sTerritoryID);

                    oSFRegInfo = oBLSFRegiInfo.GetSFInfo(sGDDBID, connectionString);
                    oUserInfo = oBLUserInfo.GetUserInfo(sGDDBID, connectionString);

                    if (oSFRegInfo.IsNew)
                    {
                        oSFRegInfo.GDDBID = sGDDBID;
                        oSFRegInfo.EmployeeID = oEmployeeInfo.ID.ToInt32; //oBLEmployeeInfo.GetEmployeeID(myConnection, myTransaction, sEmpCode);
                        oSFRegInfo.TerritoryID = nTerritoryID; //oBLTerritory.GetTerritoryID(myConnection, myTransaction, sTerritoryID);
                        oSFRegInfo.SecQuesID = nSecQuesID; //oBLSecQuesInfo.GetSQID(myConnection, myTransaction, sSQ);
                        oSFRegInfo.SecQuesAns = sSQA;
                        oSFRegInfo.PassWord = DAAccess.Encrypt(sPassword);
                        oSFRegInfo.Message = "";
                        oSFRegInfo.Mobile = sMobileNo;
                        oSFRegInfo.EntryDate = DateTime.Now;
                        oSFRegInfo.LastUpdateDate = DateTime.Now;
                        oSFRegInfo.Version = 1;
                        oSFRegInfo.CommandVersion = 1;
                        oSFRegInfo.CustomerVersion = 1;
                        oSFRegInfo.ProductVersion = 1;
                        oSFRegInfo.ProductBarVersion = 1;
                        oSFRegInfo.OrderVersion = 1;
                        oSFRegInfo.AppConfigVersion = 1;
                        oSFRegInfo.SalesReportVersion = 1;
                        oSFRegInfo.AppVersion = 1;
                        oSFRegInfo.BU = oEmployeeInfo.BU;
                        oSFRegInfo.IsActive = true;
                        oBLSFRegiInfo.Save(oSFRegInfo, myConnection, myTransaction);

                        oUserInfo.GDDBID = sGDDBID;
                        oUserInfo.Version = 1;
                        oUserInfo.CommandVersion = 1;
                        oUserInfo.AppConfigVersion = 1;
                        oUserInfo.DoctorVersion = 1;
                        oUserInfo.DoctorReqVersion = 1;
                        oUserInfo.DoctorLogVersion = 1;
                        oUserInfo.RouteVersion = 1;
                        oUserInfo.DegreeVersion = 1;
                        oUserInfo.SpecialtyVersion = 1;
                        oUserInfo.SalutationVersion = 1;
                        oUserInfo.DistrictVersion = 1;
                        oUserInfo.UpazillaVersion = 1;
                        oUserInfo.LineSpeProductVersion = 1;
                        oUserInfo.GimmickVersion = 1;
                        oUserInfo.SampleVersion = 1;
                        oUserInfo.HolidayVersion = 1;
                        oUserInfo.BrandVersion = 1;
                        oUserInfo.ReasonVersion = 1;
                        oUserInfo.PVPVersion = 1;
                        oUserInfo.PVPWorkingDayVersion = 1;
                        oUserInfo.DCRVersion = 1;
                        oUserInfo.AppVersion = 1;
                        oUserInfo.NoOfTargetDoctor = oBLUserInfo.GetNoOfTargetDoctor(myConnection, myTransaction, sTerritoryID);
                        oUserInfo.EntryDate = DateTime.Now;
                        oUserInfo.LastUpdateDate = DateTime.Now;
                        oUserInfo.UserType = oBLTerritory.GetUserTypeID(myConnection, myTransaction, sTerritoryID);
                        oUserInfo.IsActive = true;
                        oBLUserInfo.Save(oUserInfo, myConnection, myTransaction);
                    }
                    else
                    {
                        oSFRegInfo.SecQuesID = nSecQuesID;
                        oSFRegInfo.SecQuesAns = sSQA;
                        oSFRegInfo.PassWord = DAAccess.Encrypt(sPassword);
                        oSFRegInfo.LastUpdateDate = DateTime.Now;
                        oSFRegInfo.IsActive = true;
                        oBLSFRegiInfo.Save(oSFRegInfo, myConnection, myTransaction);

                        oUserInfo.IsActive = true;
                        oUserInfo.LastUpdateDate = DateTime.Now;
                        oBLUserInfo.Save(oUserInfo, myConnection, myTransaction);
                    }
                    sAuthenTicket = "1";
                    //return nAuthenTicket;

                    // …………………….
                    // Database operations

                    // ……………………
                    myTransaction.Commit();


                }
                catch (Exception e)
                {
                    sAuthenTicket = e.Message.ToString();
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                    sAuthenTicket = "Cannot connect to database.";
                else
                    sAuthenTicket = ex.Message.ToString();
                //throw new Exception(ex.Message);
            }

            return sAuthenTicket;
        }

        //[WebMethod(Description = "Method to Update SF Password")]
        //public bool UpdateSFPassword(string sGDDBID, string sPassword)
        //{
        //    try
        //    {
        //        BLSFRegiInfo oBL = new BLSFRegiInfo();
        //        return oBL.SFPasswordUpdate(sGDDBID, DAAccess.Encrypt(sPassword));
        //    }

        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);

        //    }
        //}

        [WebMethod(Description = "Method to Update SF Password")]
        public string UpdateSFPassword(string sGDDBID, string sPassword)
        {
            SFRegiInfo oSFRegiInfo = new SFRegiInfo();
            BLSFRegiInfo oBLSFRegiInfo = new BLSFRegiInfo();
            string sAuthenTicket = "";
            try
            {
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();

                SqlConnection oConnection = new SqlConnection(connectionString);
                oConnection.Open();

                SqlDataAdapter oAdapter = new SqlDataAdapter();
                SqlCommand oCommand = new SqlCommand();

                SqlTransaction myTransaction = oConnection.BeginTransaction();
                oCommand.Transaction = myTransaction;

                try
                {
                    oSFRegiInfo = oBLSFRegiInfo.GetSFInfo(sGDDBID, connectionString);
                    oSFRegiInfo.PassWord = DAAccess.Encrypt(sPassword);
                    oSFRegiInfo.LastUpdateDate = DateTime.Now;
                    oBLSFRegiInfo.Save(oSFRegiInfo, oConnection, myTransaction);
                    sAuthenTicket = "1";
                    myTransaction.Commit();
                }

                catch (Exception ex)
                {
                    sAuthenTicket = ex.Message.ToString();
                    myTransaction.Rollback();
                }

                finally
                {
                    oConnection.Close();
                }                
            }

            catch (Exception ex)
            {
                if (ex is SqlException)
                    sAuthenTicket = "Cannot connect to database.";
                else
                    sAuthenTicket = ex.Message.ToString();
                //throw new Exception(ex.Message);
            }

            return sAuthenTicket;
        }

        [WebMethod(Description = "Method to Get SampleTerritoryMapping")]
        public SampleTerritoryMappings GetSampleTerritoryMapping(String sTerritoryID, int nMaxVersion)
        {
            SampleTerritoryMappings oSampleTerritoryMappings = new SampleTerritoryMappings();
            BLSampleTerritoryMapping oBL = new BLSampleTerritoryMapping();
            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    //oSampleTerritoryMappings = oBL.GetSampleTerritoryMapping(sTerritoryID, nMaxVersion);
                    oSampleTerritoryMappings = oBL.GetSampleTerritoryMappings(sTerritoryID, nMaxVersion, connectionString);
                    myTransaction.Commit();
                }
                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
                return oSampleTerritoryMappings;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Get GimmickTerritoryMapping")]
        public GimmickTerritoryMappings GetGimmickTerritoryMapping(String sTerritoryID, int nMaxVersion)
        {
            GimmickTerritoryMappings oGimmickTerritoryMappings = new GimmickTerritoryMappings();
            BLGimmickTerritoryMapping oBL = new BLGimmickTerritoryMapping();
            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    //oGimmickTerritoryMappings = oBL.GetGimmickTerritoryMapping(sTerritoryID, nMaxVersion);
                    oGimmickTerritoryMappings = oBL.GetGimmickTerritoryMappings(sTerritoryID, nMaxVersion, connectionString);
                    myTransaction.Commit();
                }
                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
                return oGimmickTerritoryMappings;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Sync CommandInfo")]
        public CommandInfos GetCommandInfos(string sTerritoryID)
        {
            CommandInfos oCommandInfos = new CommandInfos();
            BLCommandInfo oBL = new BLCommandInfo();

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    oCommandInfos = oBL.GetCommandInfos(sTerritoryID, connectionString);
                    myTransaction.Commit();
                }
                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
                return oCommandInfos;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        //[WebMethod(Description = "Method to Sync CommandInfo")]
        //public CommandInfos GetCommandInfos(string sTerritoryID)
        //{
        //    try
        //    {
        //        CommandInfos oCommandInfos = new CommandInfos();
        //        BLCommandInfo oBL = new BLCommandInfo();
        //        oCommandInfos = oBL.GetCommandInfos(sTerritoryID);
        //        return oCommandInfos;
        //    }

        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        [WebMethod(Description = "Method to Update Command Execution StatusInfo")]
        public int UpdateCommandExeStatus(int nCommandID)
        {
            CommandInfo oCommandInfo = new CommandInfo();
            BLCommandInfo oBL = new BLCommandInfo();
            int nAuthenTicket = 0;
            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    oCommandInfo = oBL.GetCommandInfo(nCommandID, connectionString);
                    oCommandInfo.IsExcute = true;
                    oCommandInfo.ExecutedDateTime = DateTime.Now;
                    oBL.Save(oCommandInfo, myConnection, myTransaction);
                    myTransaction.Commit();
                    nAuthenTicket = 1;
                }
                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }

                return nAuthenTicket;
            }

            catch (Exception ex)
            {
                return nAuthenTicket;
                throw new Exception(ex.Message);
            }
        }

        //[WebMethod(Description = "Method to Update Command Execution StatusInfo")]
        //public int UpdateCommandExeStatus(int nCommandID)
        //{
        //    try
        //    {
        //        CommandInfo oCommandInfo = new CommandInfo();
        //        BLCommandInfo oBL = new BLCommandInfo();
        //        oCommandInfo = oBL.GetCommandInfo(nCommandID);

        //        oCommandInfo.IsExcute = true;
        //        oBL.Save(oCommandInfo);
        //        return 1;
        //    }

        //    catch (Exception ex)
        //    {
        //        return 0;
        //        throw new Exception(ex.Message);
        //    }
        //}

        [WebMethod(Description = "Method to Get App Updated Version URL")]
        public string GetAppUpdatedVersionURL()
        {
            BLAppVersionInfo oBL = new BLAppVersionInfo();
            string sAppURL = "";
            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    sAppURL = oBL.GetAppUpdatedVersionURL(myConnection, myTransaction);
                    myTransaction.Commit();
                }
                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
                return sAppURL;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //[WebMethod(Description = "Method to Get  AppUpdatedVersionURLForRM")]
        //public string GetRMAppUpdatedVersionURL()
        //{
        //    BLAppVersionInfo oBL = new BLAppVersionInfo();
        //    string sAppURL = "";
        //    try
        //    {
        //        //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
        //        NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
        //        string connectionString = oValues["ConnectionString2"].ToString();
        //        //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

        //        SqlConnection myConnection = new SqlConnection(connectionString);
        //        myConnection.Open();
        //        // Start transaction.
        //        SqlTransaction myTransaction = myConnection.BeginTransaction();
        //        // Assign command in the current transaction.
        //        SqlCommand myCommand = new SqlCommand();
        //        myCommand.Transaction = myTransaction;
        //        try
        //        {
        //            sAppURL = oBL.GetRMAppUpdatedVersionURL(myConnection, myTransaction);
        //            myTransaction.Commit();
        //        }
        //        catch (Exception e)
        //        {
        //            myTransaction.Rollback();
        //        }
        //        finally
        //        {
        //            myConnection.Close();
        //        }
        //        return sAppURL;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        [WebMethod(Description = "Method to Get  AppUpdatedVersionURLForRM")]
        public string GetAppUpdatedVersionURLForRM()
        {
            BLAppVersionInfo oBL = new BLAppVersionInfo();
            string sAppURL = "";
            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;
                try
                {
                    sAppURL = oBL.GetAppUpdatedVersionURLForRM(myConnection, myTransaction);
                    myTransaction.Commit();
                }
                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
                return sAppURL;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Sync App Status")]
        public int SaveAppStatusInfo(string sTerritoryID, int nAppVersion, string sStorageSpace, string sUsedSpace, string sFreeSpace,
                                        string sVideoData, string sMusicData, string sInternetAvailable, string sDataConnection,
                                        string sWiFiConnection, string sGPS, string sLatitude, string sLongitude)
        {

            AppStatusDetail oAppStatus = new AppStatusDetail();
            BLAppStatusDetail oBLAppStatus = new BLAppStatusDetail();
            int nAuthenTicket = 0;
            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    oAppStatus.TerritoryID = sTerritoryID;
                    oAppStatus.AppVersion = nAppVersion;
                    oAppStatus.StorageSpace = sStorageSpace;
                    oAppStatus.UsedSpace = sUsedSpace;
                    oAppStatus.FreeSpace = sFreeSpace;
                    oAppStatus.VideoData = sVideoData;
                    oAppStatus.MusicData = sMusicData;
                    oAppStatus.InternetAvailable = sInternetAvailable;
                    oAppStatus.DataConnection = sDataConnection;
                    oAppStatus.WiFiConnection = sWiFiConnection;
                    oAppStatus.GPS = sGPS;
                    oAppStatus.Latitude = Convert.ToDouble(sLatitude);
                    oAppStatus.Longitude = Convert.ToDouble(sLongitude);
                    oAppStatus.LastUpdatedDate = DateTime.Now;
                    oBLAppStatus.Save(oAppStatus, myConnection, myTransaction);
                    myTransaction.Commit();
                    nAuthenTicket = 1;
                }
                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
                return nAuthenTicket;
            }

            catch (Exception ex)
            {
                return nAuthenTicket;
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Sync AppConfigurationInfo")]
        public List<AppConfigInfo> GetAppConfigurationInfo(string sTerritoryID)
        {
            oAppConfigInfoList = new List<AppConfigInfo> { };
            AppConfigInfo oAppConfigInfo = new AppConfigInfo();
            BLAppConfigurationInfo oBL = new BLAppConfigurationInfo();
            DataTable oTable = new DataTable();
            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;
                try
                {
                    oTable = oBL.GetAppConfigInfo(sTerritoryID, connectionString);
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oAppConfigInfo.nAppConfigID = Convert.ToInt32(oRow["AppConfigID"].ToString());
                        oAppConfigInfo.sPVPStartDate = Convert.ToDateTime(oRow["PVPStartDate"].ToString()).ToString("dd MMM yyyy");
                        oAppConfigInfo.sPVPEndDate = Convert.ToDateTime(oRow["PVPEndDate"].ToString()).ToString("dd MMM yyyy");
                        oAppConfigInfo.sSMSSendNo = oRow["SmsNo"].ToString();
                        oAppConfigInfo.nMonth = Convert.ToInt32(oRow["Month"].ToString());
                        oAppConfigInfo.nYear = Convert.ToInt32(oRow["Year"].ToString());
                        oAppConfigInfo.nDCREntryHours = Convert.ToInt32(oRow["DCREntryHours"].ToString());
                        oAppConfigInfo.nDCRApprovalHours = Convert.ToInt32(oRow["DCRApprovalHours"].ToString());
                        oAppConfigInfo.nIsDMRLock = Convert.ToInt32(oRow["IsLocked"].ToString());
                        oAppConfigInfo.nTotalDoctor = Convert.ToInt32(oRow["TargetDoctor"].ToString());
                        oAppConfigInfo.nVersion = Convert.ToInt32(oRow["Version"].ToString());
                        oAppConfigInfo.nAction = Convert.ToInt32(oRow["Action"].ToString());
                        oAppConfigInfo.nIsSwajanStatus = Convert.ToInt32(oRow["IsSwajanStatus"].ToString());
                        oAppConfigInfo.nIsProfile = Convert.ToInt32(oRow["IsProfile"].ToString());
                        oAppConfigInfo.nIsRoute = Convert.ToInt32(oRow["IsRoute"].ToString());
                        oAppConfigInfo.nIsSession = Convert.ToInt32(oRow["IsSession"].ToString());
                        oAppConfigInfo.nIsCallFrequency = Convert.ToInt32(oRow["IsCallFrequency"].ToString());
                        oAppConfigInfo.nIsDocType = Convert.ToInt32(oRow["IsDocTypeId"].ToString());
                        oAppConfigInfo.nIsProd1 = Convert.ToInt32(oRow["IsProd1"].ToString());
                        oAppConfigInfo.nIsProd2 = Convert.ToInt32(oRow["IsProd2"].ToString());
                        oAppConfigInfo.nIsProd3 = Convert.ToInt32(oRow["IsProd3"].ToString());
                        oAppConfigInfo.nIsProd4 = Convert.ToInt32(oRow["IsProd4"].ToString());
                        oAppConfigInfo.nIsProd5 = Convert.ToInt32(oRow["IsProd5"].ToString());
                        oAppConfigInfo.nIsProd6 = Convert.ToInt32(oRow["IsProd6"].ToString());
                        oAppConfigInfo.nIsProd7 = Convert.ToInt32(oRow["IsProd7"].ToString());
                        oAppConfigInfo.nIsProd8 = Convert.ToInt32(oRow["IsProd8"].ToString());

                        oAppConfigInfoList.Add(oAppConfigInfo);
                    }

                    myTransaction.Commit();
                }
                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
                return oAppConfigInfoList;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        [WebMethod(Description = "Method to Sync AppConfigurationInfoForRM")]
        public List<AppConfigInfo> GetAppConfigurationInfoForRM(string sTerritoryID)
        {
            oAppConfigInfoList = new List<AppConfigInfo> { };
            AppConfigInfo oAppConfigInfo = new AppConfigInfo();
            BLAppConfigurationInfo oBL = new BLAppConfigurationInfo();
            DataTable oTable = new DataTable();
            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;
                try
                {
                    oTable = oBL.GetAppConfigInfoForRM(sTerritoryID, connectionString);
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oAppConfigInfo.nAppConfigID = Convert.ToInt32(oRow["AppConfigID"].ToString());
                        oAppConfigInfo.sPVPStartDate = Convert.ToDateTime(oRow["PVPStartDate"].ToString()).ToString("dd MMM yyyy");
                        oAppConfigInfo.sPVPEndDate = Convert.ToDateTime(oRow["PVPEndDate"].ToString()).ToString("dd MMM yyyy");
                        oAppConfigInfo.sSMSSendNo = oRow["SmsNo"].ToString();
                        oAppConfigInfo.nMonth = Convert.ToInt32(oRow["Month"].ToString());
                        oAppConfigInfo.nYear = Convert.ToInt32(oRow["Year"].ToString());
                        oAppConfigInfo.nDCREntryHours = Convert.ToInt32(oRow["DCREntryHours"].ToString());
                        oAppConfigInfo.nDCRApprovalHours = Convert.ToInt32(oRow["DCRApprovalHours"].ToString());
                        oAppConfigInfo.nIsDMRLock = Convert.ToInt32(oRow["IsLocked"].ToString());
                        oAppConfigInfo.nVersion = Convert.ToInt32(oRow["Version"].ToString());
                        oAppConfigInfo.nAction = Convert.ToInt32(oRow["Action"].ToString());
                        oAppConfigInfoList.Add(oAppConfigInfo);
                    }

                    myTransaction.Commit();
                }
                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
                return oAppConfigInfoList;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        [WebMethod(Description = "Method to Get NationalHoliday")]
        public NationalHolidays GetNationalHolidays(int nMaxVersion)
        {
            NationalHolidays oNationalHolidays = new NationalHolidays();
            BLNationalHoliday oBL = new BLNationalHoliday();
            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;
                try
                {
                    oNationalHolidays = oBL.GetNationalHolidays(nMaxVersion, connectionString);
                    myTransaction.Commit();
                }
                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
                return oNationalHolidays;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Get BrandTerritoryMapping")]
        public BrandTerritoryMappings GetBrandTerritoryMapping(String sTerritoryID, int nMaxVersion)
        {
            BrandTerritoryMappings oBrandTerritoryMappings = new BrandTerritoryMappings();
            BLBrandTerritoryMapping oBL = new BLBrandTerritoryMapping();

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;
                try
                {
                    oBrandTerritoryMappings = oBL.GetBrandTerritoryMappings(sTerritoryID, nMaxVersion, connectionString);
                    myTransaction.Commit();
                }
                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
                return oBrandTerritoryMappings;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Get Reason")]
        public Reasons GetReason(int nMaxVersion)
        {
            Reasons oReasons = new Reasons();
            BLReason oBL = new BLReason();
            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;
                try
                {
                    oReasons = oBL.GetReasons(nMaxVersion, connectionString);
                    myTransaction.Commit();
                }
                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
                return oReasons;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ////[WebMethod(Description = "Method to Save PVP")]
        ////public int SavePVP(string sPVP, string sGDDBID, string sTerritoryID, int nNoOfPlannedDay)
        ////{
        ////    int nAuthenTicket = 0;
        ////    try
        ////    {
        ////        PVPDetail oPVPDetail = new PVPDetail();
        ////        PVPMaster oPVPMaster = new PVPMaster();
        ////        Product oProduct = new Product();
        ////        PVPMonthCycle oPVPMonthCycle = new PVPMonthCycle();
        ////        BLPVPDetail oBLPVPDetail = new BLPVPDetail();
        ////        BLPVPMaster oBLPVPMaster = new BLPVPMaster();
        ////        BLProduct oBLProduct = new BLProduct();
        ////        BLPVPMonthCycle oBLPVPMonthCycle = new BLPVPMonthCycle();

        ////        oPVPMonthCycle = oBLPVPMonthCycle.GetActivePVPMonthCycle();
        ////        int nMonth = oPVPMonthCycle.Month;
        ////        int nYear = oPVPMonthCycle.Year;

        ////        string[] sDetail = sPVP.Split(';');

        ////        oPVPMaster.TerritoryID = sTerritoryID;
        ////        oPVPMaster.Month = nMonth;
        ////        oPVPMaster.Year = nYear;
        ////        oPVPMaster.Status = PVPStatus.Submit;
        ////        oPVPMaster.SubmitDate = DateTime.Now;
        ////        oPVPMaster.ApprovedDate = Convert.ToDateTime("31 Dec 9999");
        ////        oPVPMaster.SubmittedBy = sGDDBID;
        ////        oPVPMaster.ApprovedBy = "";
        ////        oPVPMaster.NoOfPlannedDay = nNoOfPlannedDay;
        ////        oPVPMaster.Version = oBLPVPMaster.GetTerritoryWiseMaxVersion(sTerritoryID);
        ////        oPVPMaster.Action = 1;
        ////        oBLPVPMaster.Save(oPVPMaster);

        ////        for (int i = 0; i < sDetail.Length - 1; i++)
        ////        {
        ////            string[] sPVPDetail = sDetail[i].Split(',');
        ////            oPVPDetail = new PVPDetail();
        ////            oPVPDetail.PvpID = oPVPMaster.ID.ToInt32;
        ////            string sDoctorID = sPVPDetail[0];
        ////            if (sDoctorID != "")
        ////                oPVPDetail.DoctorID = Convert.ToInt32(sPVPDetail[0]);
        ////            else
        ////                oPVPDetail.DoctorID = null;
        ////            oPVPDetail.TerritoryID = sTerritoryID;
        ////            oPVPDetail.Day = Convert.ToInt32(sPVPDetail[1]);
        ////            oPVPDetail.Month = nMonth;
        ////            oPVPDetail.Year = nYear;
        ////            string sBrand1 = sPVPDetail[2];
        ////            if (sBrand1 != "")
        ////                oPVPDetail.Brand1 = oBLProduct.GetProductID(sPVPDetail[2]);
        ////            else
        ////                oPVPDetail.Brand1 = null;
        ////            string sBrand2 = sPVPDetail[3];
        ////            if (sBrand2 != "")
        ////                oPVPDetail.Brand2 = oBLProduct.GetProductID(sPVPDetail[3]);
        ////            else
        ////                oPVPDetail.Brand2 = null;
        ////            string sBrand3 = sPVPDetail[4];
        ////            if (sBrand3 != "")
        ////                oPVPDetail.Brand3 = oBLProduct.GetProductID(sPVPDetail[4]);
        ////            else
        ////                oPVPDetail.Brand3 = null;
        ////            string sBrand4 = sPVPDetail[5];
        ////            if (sBrand4 != "")
        ////                oPVPDetail.Brand4 = oBLProduct.GetProductID(sPVPDetail[5]);
        ////            else
        ////                oPVPDetail.Brand4 = null;
        ////            string sBrand5 = sPVPDetail[6];
        ////            if (sBrand5 != "")
        ////                oPVPDetail.Brand5 = oBLProduct.GetProductID(sPVPDetail[6]);
        ////            else
        ////                oPVPDetail.Brand5 = null;
        ////            string sBrand6 = sPVPDetail[7];
        ////            if (sBrand6 != "")
        ////                oPVPDetail.Brand6 = oBLProduct.GetProductID(sPVPDetail[7]);
        ////            else
        ////                oPVPDetail.Brand6 = null;
        ////            string sSession = sPVPDetail[8];
        ////            if (sSession != "")
        ////                oPVPDetail.Session = sPVPDetail[8];
        ////            else
        ////                oPVPDetail.Session = null;
        ////            oPVPDetail.IsHoliday = Convert.ToBoolean(Convert.ToInt32(sPVPDetail[9]));
        ////            string sDoctorProfile = sPVPDetail[10];
        ////            if (sDoctorProfile != "")
        ////                oPVPDetail.DoctorProfile = sPVPDetail[10];
        ////            else
        ////                oPVPDetail.DoctorProfile = null;
        ////            oPVPDetail.CreatedBy = sGDDBID;
        ////            oPVPDetail.CreationDate = Convert.ToDateTime(sPVPDetail[11]);
        ////            oBLPVPDetail.Save(oPVPDetail);
        ////        }
        ////        nAuthenTicket = 1;

        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        throw new Exception(ex.Message);
        ////    }
        ////    return nAuthenTicket;
        ////}

        //[WebMethod(Description = "Method to Save PVP")]
        //public int SavePVP(string sPVP, string sGDDBID, string sTerritoryID, int nNoOfPlannedDay)
        //{
        //    PVPDetail oPVPDetail = new PVPDetail();
        //    PVPMaster oPVPMaster = new PVPMaster();
        //    Product oProduct = new Product();
        //    PVPMonthCycle oPVPMonthCycle = new PVPMonthCycle();
        //    BLPVPDetail oBLPVPDetail = new BLPVPDetail();
        //    BLPVPMaster oBLPVPMaster = new BLPVPMaster();
        //    BLProduct oBLProduct = new BLProduct();
        //    BLPVPMonthCycle oBLPVPMonthCycle = new BLPVPMonthCycle();
        //    int nAuthenTicket = 0;

        //    try
        //    {
        //        //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
        //        NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
        //        string connectionString = oValues["ConnectionString2"].ToString();
        //        SqlConnection myConnection = new SqlConnection(connectionString);
        //        myConnection.Open();
        //        // Start transaction.
        //        SqlTransaction myTransaction = myConnection.BeginTransaction();
        //        // Assign command in the current transaction.
        //        SqlCommand myCommand = new SqlCommand();
        //        myCommand.Transaction = myTransaction;
        //        try
        //        {
        //            // …………………….
        //            // Database operations
        //            DataTable otblPVPMonthCycle = new DataTable();
        //            string sPVPMonthCycle = "SELECT * FROM [PVPMonthCycle] WHERE IsActive=1";
        //            SqlDataAdapter Sfda = new SqlDataAdapter(sPVPMonthCycle, connectionString);
        //            Sfda.Fill(otblPVPMonthCycle);

        //            int nMonth = Convert.ToInt32(otblPVPMonthCycle.Rows[0]["Month"]);
        //            int nYear = Convert.ToInt32(otblPVPMonthCycle.Rows[0]["Year"]);

        //            string[] sDetail = sPVP.Split(';');
        //            oPVPMaster = new PVPMaster();

        //            for (int i = 0; i < sDetail.Length - 1; i++)
        //            {
        //                string[] sPVPDetail = sDetail[i].Split(',');
        //                oPVPDetail = new PVPDetail();
        //                string sDoctorID = sPVPDetail[0];
        //                if (sDoctorID != "")
        //                    oPVPDetail.DoctorID = Convert.ToInt32(sPVPDetail[0]);
        //                else
        //                    oPVPDetail.DoctorID = null;
        //                oPVPDetail.TerritoryID = sTerritoryID;
        //                oPVPDetail.Day = Convert.ToInt32(sPVPDetail[1]);
        //                oPVPDetail.Month = nMonth;
        //                oPVPDetail.Year = nYear;
        //                string sBrand1 = sPVPDetail[2];
        //                if (sBrand1 != "")
        //                {
        //                    //oPVPDetail.Brand1 = oBLProduct.GetProductID(sPVPDetail[2], sTerritoryID);
        //                    SqlCommand cmd1 = new SqlCommand();
        //                    cmd1.CommandText = "SELECT a.[ProdID] FROM [Product] a INNER JOIN [Territory] b ON a.Line=b.LineID WHERE a.ProdCode='" + sPVPDetail[2] + "'" + " and b.TerritoryID='" + sTerritoryID + "'";
        //                    cmd1.Connection = myConnection;
        //                    cmd1.Transaction = myTransaction;
        //                    object oBrand1 = cmd1.ExecuteScalar();
        //                    int nBrand1 = 0;
        //                    if (oBrand1 == DBNull.Value)
        //                    {
        //                        nBrand1 = 1;
        //                    }
        //                    else
        //                    {
        //                        nBrand1 = Convert.ToInt32(oBrand1);
        //                    }
        //                    oPVPDetail.Brand1 = nBrand1;
        //                }
        //                else
        //                    oPVPDetail.Brand1 = null;
        //                string sBrand2 = sPVPDetail[3];
        //                if (sBrand2 != "")
        //                {
        //                    //oPVPDetail.Brand2 = oBLProduct.GetProductID(sPVPDetail[3], sTerritoryID);
        //                    SqlCommand cmd2 = new SqlCommand();
        //                    cmd2.CommandText = "SELECT a.[ProdID] FROM [Product] a INNER JOIN [Territory] b ON a.Line=b.LineID WHERE a.ProdCode='" + sPVPDetail[3] + "'" + " and b.TerritoryID='" + sTerritoryID + "'";
        //                    cmd2.Connection = myConnection;
        //                    cmd2.Transaction = myTransaction;
        //                    object oBrand2 = cmd2.ExecuteScalar();
        //                    int nBrand2 = 0;
        //                    if (oBrand2 == DBNull.Value)
        //                    {
        //                        nBrand2 = 1;
        //                    }
        //                    else
        //                    {
        //                        nBrand2 = Convert.ToInt32(oBrand2);
        //                    }
        //                    oPVPDetail.Brand2 = nBrand2;
        //                }
        //                else
        //                    oPVPDetail.Brand2 = null;
        //                string sBrand3 = sPVPDetail[4];
        //                if (sBrand3 != "")
        //                {
        //                    //oPVPDetail.Brand3 = oBLProduct.GetProductID(sPVPDetail[4], sTerritoryID);
        //                    SqlCommand cmd3 = new SqlCommand();
        //                    cmd3.CommandText = "SELECT a.[ProdID] FROM [Product] a INNER JOIN [Territory] b ON a.Line=b.LineID WHERE a.ProdCode='" + sPVPDetail[4] + "'" + " and b.TerritoryID='" + sTerritoryID + "'";
        //                    cmd3.Connection = myConnection;
        //                    cmd3.Transaction = myTransaction;
        //                    object oBrand3 = cmd3.ExecuteScalar();
        //                    int nBrand3 = 0;
        //                    if (oBrand3 == DBNull.Value)
        //                    {
        //                        nBrand3 = 1;
        //                    }
        //                    else
        //                    {
        //                        nBrand3 = Convert.ToInt32(oBrand3);
        //                    }
        //                    oPVPDetail.Brand3 = nBrand3;
        //                }
        //                else
        //                    oPVPDetail.Brand3 = null;
        //                string sBrand4 = sPVPDetail[5];
        //                if (sBrand4 != "")
        //                {
        //                    //oPVPDetail.Brand4 = oBLProduct.GetProductID(sPVPDetail[5], sTerritoryID);
        //                    SqlCommand cmd4 = new SqlCommand();
        //                    cmd4.CommandText = "SELECT a.[ProdID] FROM [Product] a INNER JOIN [Territory] b ON a.Line=b.LineID WHERE a.ProdCode='" + sPVPDetail[5] + "'" + " and b.TerritoryID='" + sTerritoryID + "'";
        //                    cmd4.Connection = myConnection;
        //                    cmd4.Transaction = myTransaction;
        //                    object oBrand4 = cmd4.ExecuteScalar();
        //                    int nBrand4 = 0;
        //                    if (oBrand4 == DBNull.Value)
        //                    {
        //                        nBrand4 = 1;
        //                    }
        //                    else
        //                    {
        //                        nBrand4 = Convert.ToInt32(oBrand4);
        //                    }
        //                    oPVPDetail.Brand4 = nBrand4;
        //                }
        //                else
        //                    oPVPDetail.Brand4 = null;
        //                string sBrand5 = sPVPDetail[6];
        //                if (sBrand5 != "")
        //                {
        //                    //oPVPDetail.Brand5 = oBLProduct.GetProductID(sPVPDetail[6], sTerritoryID);
        //                    SqlCommand cmd5 = new SqlCommand();
        //                    cmd5.CommandText = "SELECT a.[ProdID] FROM [Product] a INNER JOIN [Territory] b ON a.Line=b.LineID WHERE a.ProdCode='" + sPVPDetail[6] + "'" + " and b.TerritoryID='" + sTerritoryID + "'";
        //                    cmd5.Connection = myConnection;
        //                    cmd5.Transaction = myTransaction;
        //                    object oBrand5 = cmd5.ExecuteScalar();
        //                    int nBrand5 = 0;
        //                    if (oBrand5 == DBNull.Value)
        //                    {
        //                        nBrand5 = 1;
        //                    }
        //                    else
        //                    {
        //                        nBrand5 = Convert.ToInt32(oBrand5);
        //                    }
        //                    oPVPDetail.Brand5 = nBrand5;
        //                }
        //                else
        //                    oPVPDetail.Brand5 = null;
        //                string sBrand6 = sPVPDetail[7];
        //                if (sBrand6 != "")
        //                {
        //                    //oPVPDetail.Brand6 = oBLProduct.GetProductID(sPVPDetail[7], sTerritoryID);
        //                    SqlCommand cmd6 = new SqlCommand();
        //                    cmd6.CommandText = "SELECT a.[ProdID] FROM [Product] a INNER JOIN [Territory] b ON a.Line=b.LineID WHERE a.ProdCode='" + sPVPDetail[7] + "'" + " and b.TerritoryID='" + sTerritoryID + "'";
        //                    cmd6.Connection = myConnection;
        //                    cmd6.Transaction = myTransaction;
        //                    object oBrand6 = cmd6.ExecuteScalar();
        //                    int nBrand6 = 0;
        //                    if (oBrand6 == DBNull.Value)
        //                    {
        //                        nBrand6 = 1;
        //                    }
        //                    else
        //                    {
        //                        nBrand6 = Convert.ToInt32(oBrand6);
        //                    }
        //                    oPVPDetail.Brand6 = nBrand6;
        //                }
        //                else
        //                    oPVPDetail.Brand6 = null;
        //                string sSession = sPVPDetail[8];
        //                if (sSession != "")
        //                    oPVPDetail.Session = sPVPDetail[8];
        //                else
        //                    oPVPDetail.Session = null;
        //                oPVPDetail.IsHoliday = Convert.ToBoolean(Convert.ToInt32(sPVPDetail[9]));
        //                string sDoctorProfile = sPVPDetail[10];
        //                if (sDoctorProfile != "")
        //                    oPVPDetail.DoctorProfile = sPVPDetail[10];
        //                else
        //                    oPVPDetail.DoctorProfile = null;
        //                oPVPDetail.CreatedBy = sGDDBID;
        //                oPVPDetail.CreationDate = Convert.ToDateTime(sPVPDetail[11]);
        //                oPVPMaster.TransactionDetail.Add(oPVPDetail);
        //            }

        //            SqlCommand cmd7 = new SqlCommand();
        //            cmd7.CommandText = "SELECT MAX(PvpID)+ 1 AS PvpID FROM PVPMaster";
        //            cmd7.Connection = myConnection;
        //            cmd7.Transaction = myTransaction;
        //            object oPVPMasterID = cmd7.ExecuteScalar();
        //            int nPVPMasterID = 0;
        //            if (oPVPMasterID == DBNull.Value)
        //            {
        //                nPVPMasterID = 1;
        //            }
        //            else
        //            {
        //                nPVPMasterID = Convert.ToInt32(oPVPMasterID);
        //            }

        //            SqlCommand cmd8 = new SqlCommand();
        //            cmd8.CommandText = "SELECT MAX(Version)+ 1 AS Version FROM PVPMaster WHERE TerritoryID Like '" + sTerritoryID.Substring(0, 6) + "%'";
        //            cmd8.Connection = myConnection;
        //            cmd8.Transaction = myTransaction;
        //            object oMaxVersion = cmd8.ExecuteScalar();
        //            int nMaxVersion = 0;
        //            if (oMaxVersion == DBNull.Value)
        //            {
        //                nMaxVersion = 1;
        //            }
        //            else
        //            {
        //                nMaxVersion = Convert.ToInt32(oMaxVersion);
        //            }

        //            oPVPMaster.ID.SetID(nPVPMasterID);
        //            oPVPMaster.TerritoryID = sTerritoryID;
        //            oPVPMaster.Month = nMonth;
        //            oPVPMaster.Year = nYear;
        //            oPVPMaster.Status = PVPStatus.Submit;
        //            oPVPMaster.SubmitDate = DateTime.Now;
        //            oPVPMaster.ApprovedDate = Convert.ToDateTime("31 Dec 9999");
        //            oPVPMaster.SubmittedBy = sGDDBID;
        //            oPVPMaster.ApprovedBy = "";
        //            oPVPMaster.NoOfPlannedDay = nNoOfPlannedDay;
        //            oPVPMaster.Version = nMaxVersion;
        //            oPVPMaster.Action = 1;

        //            SqlCommand cmd15 = new SqlCommand();
        //            cmd15.CommandText = "SELECT COUNT(*) FROM [PVPMaster] WHERE Month=" + nMonth + " AND Year=" + nYear + " AND TerritoryID='" + sTerritoryID + "'";
        //            cmd15.Connection = myConnection;
        //            cmd15.Transaction = myTransaction;
        //            object oCount = cmd15.ExecuteScalar();
        //            int nCount = 0;
        //            if (oCount == DBNull.Value)
        //            {
        //                nCount = 0;
        //            }
        //            else
        //            {
        //                nCount = Convert.ToInt32(oCount);
        //            }

        //            if(nCount==0)
        //            {
        //            string sSQL = SQL.MakeSQL("INSERT INTO [PVPMaster](PvpID, TerritoryID, Month, Year, Status, SubmitDate, ApprovedDate, SubmittedBy, ApprovedBy, NoOfPlannedDay, Version, Action) "
        //                + " VALUES(%n, %s, %n, %n, %n, %D, %D, %s, %s, %n, %n, %n) "
        //                , oPVPMaster.ID.ToInt32, oPVPMaster.TerritoryID, oPVPMaster.Month, oPVPMaster.Year, oPVPMaster.Status, oPVPMaster.SubmitDate, oPVPMaster.ApprovedDate, oPVPMaster.SubmittedBy, oPVPMaster.ApprovedBy, oPVPMaster.NoOfPlannedDay, oPVPMaster.Version, oPVPMaster.Action);

        //            SqlDataAdapter oAdapter = new SqlDataAdapter();
        //            SqlCommand cmd9 = new SqlCommand();
        //            cmd9 = new SqlCommand(sSQL, myConnection);
        //            cmd9.Transaction = myTransaction;
        //            oAdapter.InsertCommand = cmd9;
        //            cmd9.ExecuteNonQuery();

        //            foreach (PVPDetail oDetail in oPVPMaster.TransactionDetail)
        //            {
        //                oDetail.PvpID = oPVPMaster.ID.ToInt32;
        //                SqlCommand cmd10 = new SqlCommand();
        //                string sDetailID = "SELECT MAX(DetailID)+ 1 AS DetailID FROM PVPDetail";
        //                cmd10 = new SqlCommand(sDetailID, myConnection);
        //                cmd10.Transaction = myTransaction;
        //                object oDetailID = cmd10.ExecuteScalar();
        //                int nDetailID = 0;
        //                if (oDetailID == DBNull.Value)
        //                {
        //                    nDetailID = 1;
        //                }
        //                else
        //                {
        //                    nDetailID = Convert.ToInt32(oDetailID);
        //                }
        //                oDetail.ID.SetID(nDetailID);
        //                string sSQL1 = SQL.MakeSQL("INSERT INTO [PVPDetail](DetailID, PvpID, DoctorID, TerritoryID, Day, Month, Year, Brand1, Brand2, Brand3, Brand4, Brand5, Brand6, Session, IsHoliday, DoctorProfile, CreatedBy, CreationDate) "
        //                               + " VALUES(%n, %n, %n, %s, %n, %n, %n, %n, %n, %n, %n, %n, %n, %s, %b, %s, %s, %D) "
        //                               , oDetail.ID.ToInt32, oDetail.PvpID, oDetail.DoctorID, oDetail.TerritoryID, oDetail.Day, oDetail.Month, oDetail.Year, oDetail.Brand1, oDetail.Brand2, oDetail.Brand3, oDetail.Brand4, oDetail.Brand5, oDetail.Brand6, oDetail.Session, oDetail.IsHoliday, oDetail.DoctorProfile, oDetail.CreatedBy, oDetail.CreationDate);

        //                SqlDataAdapter oAdapter2 = new SqlDataAdapter();
        //                SqlCommand cmd11 = new SqlCommand();
        //                cmd11 = new SqlCommand(sSQL1, myConnection);
        //                cmd11.Transaction = myTransaction;
        //                oAdapter2.InsertCommand = cmd11;
        //                cmd11.ExecuteNonQuery();
        //            }

        //            //DataTable otblUserInfo = new DataTable();
        //            //string sUserInfo = "SELECT * FROM [UserInfo] WHERE GDDBID='" + sGDDBID + "' and IsActive=1";
        //            //SqlDataAdapter Sfda2 = new SqlDataAdapter(sUserInfo, connectionString);
        //            //Sfda2.Fill(otblUserInfo);

        //            //string sSQL2 = SQL.MakeSQL("UPDATE [UserInfo] SET Version=%n, PVPVersion=%n WHERE GDDBID=%s"
        //            //    , Convert.ToInt32(otblUserInfo.Rows[0]["Version"].ToString()) + 1, Convert.ToInt32(otblUserInfo.Rows[0]["PVPVersion"].ToString()) + 1, sGDDBID);

        //            //SqlDataAdapter oAdapter3 = new SqlDataAdapter();
        //            //SqlCommand cmd12 = new SqlCommand();
        //            //cmd12 = new SqlCommand(sSQL2, myConnection);
        //            //cmd12.Transaction = myTransaction;
        //            //oAdapter3.UpdateCommand = cmd12;
        //            //cmd12.ExecuteNonQuery();

        //            //SqlCommand cmd13 = new SqlCommand();
        //            //cmd13.CommandText = "SELECT TerritoryID FROM [GXBDDA-S3017].[OrderCollectionSystem_Test].[dbo].[Territory] WHERE TerritoryCode='" + sTerritoryID.Substring(0,5) + "'";
        //            //cmd13.Connection = myConnection;
        //            //cmd13.Transaction = myTransaction;
        //            //object oTerrID = cmd13.ExecuteScalar();
        //            //int nTerrID = 0;
        //            //if (oTerrID == DBNull.Value)
        //            //{
        //            //    nTerrID = 0;
        //            //}
        //            //else
        //            //{
        //            //    nTerrID = Convert.ToInt32(oTerrID);
        //            //}

        //            SqlCommand cmd13 = new SqlCommand();
        //            cmd13.CommandText = @"SELECT GDDBID FROM [OrderCollectionSystem].[dbo].[EmployeeInfo] a INNER JOIN [OrderCollectionSystem].[dbo].[Territory] b ON a.TerritoryID=b.TerritoryID WHERE b.TerritoryCode='" + sTerritoryID.Substring(0, 6) + "'";
        //            cmd13.Connection = myConnection;
        //            cmd13.Transaction = myTransaction;
        //            object oGDDBID = cmd13.ExecuteScalar();
        //            string sRMGDDBID = "";
        //            if (oGDDBID == DBNull.Value)
        //            {
        //                sRMGDDBID = "";
        //            }
        //            else
        //            {
        //                sRMGDDBID = Convert.ToString(oGDDBID);
        //            }

        //            DataTable otblRMUserInfo = new DataTable();
        //            string sRMUserInfo = "SELECT * FROM [UserInfo] WHERE GDDBID='" + sRMGDDBID + "' and IsActive=1";
        //            SqlDataAdapter Sfda3 = new SqlDataAdapter(sRMUserInfo, connectionString);
        //            Sfda3.Fill(otblRMUserInfo);

        //            string sSQL3 = SQL.MakeSQL("UPDATE [UserInfo] SET Version=%n, PVPVersion=%n WHERE GDDBID=%s"
        //                , Convert.ToInt32(otblRMUserInfo.Rows[0]["Version"].ToString()) + 1, Convert.ToInt32(otblRMUserInfo.Rows[0]["PVPVersion"].ToString()) + 1, sRMGDDBID);

        //            SqlDataAdapter oAdapter4 = new SqlDataAdapter();
        //            SqlCommand cmd14 = new SqlCommand();
        //            cmd14 = new SqlCommand(sSQL3, myConnection);
        //            cmd14.Transaction = myTransaction;
        //            oAdapter4.UpdateCommand = cmd14;
        //            cmd14.ExecuteNonQuery();

        //            nAuthenTicket = oPVPMaster.ID.ToInt32;
        //        }

        //            myTransaction.Commit();

        //        }
        //        catch (Exception e)
        //        {
        //            myTransaction.Rollback();
        //        }
        //        finally
        //        {
        //            myConnection.Close();
        //        }

        //        return nAuthenTicket;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //[WebMethod(Description = "Method to Save PVP")]
        //public int SavePVP(string sPVP, string sGDDBID, string sTerritoryID, int nNoOfPlannedDay)
        //{
        //    int nAuthenTicket = 0;
        //    try
        //    {
        //        PVPDetail oPVPDetail = new PVPDetail();
        //        PVPMaster oPVPMaster = new PVPMaster();
        //        Product oProduct = new Product();
        //        PVPMonthCycle oPVPMonthCycle = new PVPMonthCycle();
        //        BLPVPDetail oBLPVPDetail = new BLPVPDetail();
        //        BLPVPMaster oBLPVPMaster = new BLPVPMaster();
        //        BLProduct oBLProduct = new BLProduct();
        //        BLPVPMonthCycle oBLPVPMonthCycle = new BLPVPMonthCycle();

        //        oPVPMonthCycle = oBLPVPMonthCycle.GetActivePVPMonthCycle();
        //        int nMonth = oPVPMonthCycle.Month;
        //        int nYear = oPVPMonthCycle.Year;

        //        string[] sDetail = sPVP.Split(';');

        //        oPVPMaster.TerritoryID = sTerritoryID;
        //        oPVPMaster.Month = nMonth;
        //        oPVPMaster.Year = nYear;
        //        oPVPMaster.Status = PVPStatus.Submit;
        //        oPVPMaster.SubmitDate = DateTime.Now;
        //        oPVPMaster.ApprovedDate = Convert.ToDateTime("31 Dec 9999");
        //        oPVPMaster.SubmittedBy = sGDDBID;
        //        oPVPMaster.ApprovedBy = "";
        //        oPVPMaster.NoOfPlannedDay = nNoOfPlannedDay;
        //        oPVPMaster.Version = oBLPVPMaster.GetTerritoryWiseMaxVersion(sTerritoryID);
        //        oPVPMaster.Action = 1;
        //        oBLPVPMaster.Save(oPVPMaster);

        //        for (int i = 0; i < sDetail.Length - 1; i++)
        //        {
        //            string[] sPVPDetail = sDetail[i].Split(',');
        //            oPVPDetail = new PVPDetail();
        //            oPVPDetail.PvpID = oPVPMaster.ID.ToInt32;
        //            string sDoctorID = sPVPDetail[0];
        //            if (sDoctorID != "")
        //                oPVPDetail.DoctorID = Convert.ToInt32(sPVPDetail[0]);
        //            else
        //                oPVPDetail.DoctorID = null;
        //            oPVPDetail.TerritoryID = sTerritoryID;
        //            oPVPDetail.Day = Convert.ToInt32(sPVPDetail[1]);
        //            oPVPDetail.Month = nMonth;
        //            oPVPDetail.Year = nYear;
        //            string sBrand1 = sPVPDetail[2];
        //            if (sBrand1 != "")
        //                oPVPDetail.Brand1 = oBLProduct.GetProductID(sPVPDetail[2]);
        //            else
        //                oPVPDetail.Brand1 = null;
        //            string sBrand2 = sPVPDetail[3];
        //            if (sBrand2 != "")
        //                oPVPDetail.Brand2 = oBLProduct.GetProductID(sPVPDetail[3]);
        //            else
        //                oPVPDetail.Brand2 = null;
        //            string sBrand3 = sPVPDetail[4];
        //            if (sBrand3 != "")
        //                oPVPDetail.Brand3 = oBLProduct.GetProductID(sPVPDetail[4]);
        //            else
        //                oPVPDetail.Brand3 = null;
        //            string sBrand4 = sPVPDetail[5];
        //            if (sBrand4 != "")
        //                oPVPDetail.Brand4 = oBLProduct.GetProductID(sPVPDetail[5]);
        //            else
        //                oPVPDetail.Brand4 = null;
        //            string sBrand5 = sPVPDetail[6];
        //            if (sBrand5 != "")
        //                oPVPDetail.Brand5 = oBLProduct.GetProductID(sPVPDetail[6]);
        //            else
        //                oPVPDetail.Brand5 = null;
        //            string sBrand6 = sPVPDetail[7];
        //            if (sBrand6 != "")
        //                oPVPDetail.Brand6 = oBLProduct.GetProductID(sPVPDetail[7]);
        //            else
        //                oPVPDetail.Brand6 = null;
        //            string sSession = sPVPDetail[8];
        //            if (sSession != "")
        //                oPVPDetail.Session = sPVPDetail[8];
        //            else
        //                oPVPDetail.Session = null;
        //            oPVPDetail.IsHoliday = Convert.ToBoolean(Convert.ToInt32(sPVPDetail[9]));
        //            string sDoctorProfile = sPVPDetail[10];
        //            if (sDoctorProfile != "")
        //                oPVPDetail.DoctorProfile = sPVPDetail[10];
        //            else
        //                oPVPDetail.DoctorProfile = null;
        //            oPVPDetail.CreatedBy = sGDDBID;
        //            oPVPDetail.CreationDate = Convert.ToDateTime(sPVPDetail[11]);
        //            oBLPVPDetail.Save(oPVPDetail);
        //        }
        //        nAuthenTicket = 1;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return nAuthenTicket;
        //}

        [WebMethod(Description = "Method to Submit PVP")]
        public string SubmitPVP(string sPVP, string sGDDBID, string sTerritoryID, int nNoOfPlannedDay)
        {
            PVPDetail oPVPDetail = new PVPDetail();
            PVPMaster oPVPMaster = new PVPMaster();
            Product oProduct = new Product();
            UserInfo oUserInfo = new UserInfo();
            PVPMonthCycle oPVPMonthCycle = new PVPMonthCycle();
            CommandInfo oCommandInfo = new CommandInfo();
            AppConfigurationInfo oAppConfigInfo = new AppConfigurationInfo();
            BLPVPDetail oBLPVPDetail = new BLPVPDetail();
            BLPVPMaster oBLPVPMaster = new BLPVPMaster();
            PVPExceptionLog oPVPExceptionLog = new PVPExceptionLog();
            BLProduct oBLProduct = new BLProduct();
            BLPVPMonthCycle oBLPVPMonthCycle = new BLPVPMonthCycle();
            BLUserInfo oBLUserInfo = new BLUserInfo();
            BLEmployeeInfo oBLEmployeeInfo = new BLEmployeeInfo();
            BLCommandInfo oBLCommandInfo = new BLCommandInfo();
            BLPVPExceptionLog oBLPVPExceptionLog = new BLPVPExceptionLog();
            BLAppConfigurationInfo oBLAppConfig = new BLAppConfigurationInfo();
            string sAuthenTicket = "";

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;
                try
                {
                    // …………………….
                    // Database operations
                    oPVPMonthCycle = oBLPVPMonthCycle.GetPVPMonthCycle(connectionString);
                    oAppConfigInfo = oBLAppConfig.GetAppConfigurationInfo(sTerritoryID, connectionString);
                    int nMonth = oPVPMonthCycle.Month;
                    int nYear = oPVPMonthCycle.Year;
                    DateTime dPVPEndDate = oAppConfigInfo.PVPEndDate;
                    DateTime dCurrentDate = DateTime.Now.Date;

                    bool bIsPVPOpen = false;
                    if (dCurrentDate <= dPVPEndDate)
                        bIsPVPOpen = true;
                    //if (!bIsPVPOpen)
                    //{
                    //    //string sPVPEndDate = dCurrentDate.ToString("dd MMM yyyy");
                    //    //bIsPVPOpen = oBLCommandInfo.IsPVPTimeExtend(myConnection, myTransaction, sTerritoryID, sPVPEndDate);
                    //    string sPVPEndDate = oBLCommandInfo.GetPVPEndDate(myConnection, myTransaction, sTerritoryID);
                    //    if (sPVPEndDate != "")
                    //        dPVPEndDate = Convert.ToDateTime(sPVPEndDate);
                    //    if (dCurrentDate <= dPVPEndDate)
                    //        bIsPVPOpen = true;
                    //}

                    if (bIsPVPOpen)
                    {
                        //int nMaxPVPVersion = oBLPVPMaster.GetMaxPVPVersion(myConnection, myTransaction, sTerritoryID);
                        int nMaxPVPVersion = oBLPVPMaster.GetMaxPVPVersion(myConnection, myTransaction);
                        oPVPMaster = oBLPVPMaster.GetPVPMasterInfo(sTerritoryID, nMonth, nYear, connectionString);
                        if (oPVPMaster.IsNew)
                        {
                            oPVPMaster.TerritoryID = sTerritoryID;
                            oPVPMaster.Month = nMonth;
                            oPVPMaster.Year = nYear;
                            oPVPMaster.Status = PVPStatus.Submit;
                            oPVPMaster.SubmitDate = DateTime.Now;
                            oPVPMaster.ApprovedDate = Convert.ToDateTime("31 Dec 9999");
                            oPVPMaster.SubmittedBy = sGDDBID;
                            oPVPMaster.ApprovedBy = "";
                            oPVPMaster.NoOfPlannedDay = nNoOfPlannedDay;
                            oPVPMaster.Version = nMaxPVPVersion;
                            oPVPMaster.Action = 1;
                            oBLPVPMaster.Save(oPVPMaster, myConnection, myTransaction);
                        }
                        else
                        {
                            oPVPMaster.Status = PVPStatus.Submit;
                            oPVPMaster.SubmitDate = DateTime.Now;
                            oPVPMaster.ApprovedDate = Convert.ToDateTime("31 Dec 9999");
                            oPVPMaster.SubmittedBy = sGDDBID;
                            oPVPMaster.ApprovedBy = "";
                            oPVPMaster.NoOfPlannedDay = nNoOfPlannedDay;
                            oPVPMaster.Version = nMaxPVPVersion;
                            oPVPMaster.Action = 2;
                            oBLPVPMaster.Save(oPVPMaster, myConnection, myTransaction);
                            oBLPVPDetail.Delete(oPVPMaster.ID.ToInt32, myConnection, myTransaction);
                        }

                        string[] sDetail = sPVP.Split(';');
                        //oPVPMaster = new PVPMaster();

                        for (int i = 0; i < sDetail.Length - 1; i++)
                        {
                            string[] sPVPDetail = sDetail[i].Split(',');
                            oPVPDetail = new PVPDetail();

                            string sDoctorID = sPVPDetail[0];
                            if (sDoctorID != "" & sDoctorID != "anyType{}")
                                oPVPDetail.DoctorID = Convert.ToInt32(sPVPDetail[0]);
                            else
                                oPVPDetail.DoctorID = null;

                            oPVPDetail.TerritoryID = sTerritoryID;
                            oPVPDetail.Day = Convert.ToInt32(sPVPDetail[1]);
                            oPVPDetail.Month = nMonth;
                            oPVPDetail.Year = nYear;

                            string sBrand1 = sPVPDetail[2];
                            if (sBrand1 != "" & sBrand1 != "anyType{}")
                                oPVPDetail.Brand1 = oBLProduct.GetBrandID(sPVPDetail[2], sTerritoryID, myConnection, myTransaction);
                            else
                                oPVPDetail.Brand1 = null;
                            string sBrand2 = sPVPDetail[3];
                            if (sBrand2 != "" & sBrand2 != "anyType{}")
                                oPVPDetail.Brand2 = oBLProduct.GetBrandID(sPVPDetail[3], sTerritoryID, myConnection, myTransaction);
                            else
                                oPVPDetail.Brand2 = null;
                            string sBrand3 = sPVPDetail[4];
                            if (sBrand3 != "" & sBrand3 != "anyType{}")
                                oPVPDetail.Brand3 = oBLProduct.GetBrandID(sPVPDetail[4], sTerritoryID, myConnection, myTransaction);
                            else
                                oPVPDetail.Brand3 = null;
                            string sBrand4 = sPVPDetail[5];
                            if (sBrand4 != "" & sBrand4 != "anyType{}")
                                oPVPDetail.Brand4 = oBLProduct.GetBrandID(sPVPDetail[5], sTerritoryID, myConnection, myTransaction);
                            else
                                oPVPDetail.Brand4 = null;
                            string sBrand5 = sPVPDetail[6];
                            if (sBrand5 != "" & sBrand5 != "anyType{}")
                                oPVPDetail.Brand5 = oBLProduct.GetBrandID(sPVPDetail[6], sTerritoryID, myConnection, myTransaction);
                            else
                                oPVPDetail.Brand5 = null;
                            string sBrand6 = sPVPDetail[7];
                            if (sBrand6 != "" & sBrand6 != "anyType{}")
                                oPVPDetail.Brand6 = oBLProduct.GetBrandID(sPVPDetail[7], sTerritoryID, myConnection, myTransaction);
                            else
                                oPVPDetail.Brand6 = null;
                            string sBrand7 = sPVPDetail[8];
                            if (sBrand7 != "" & sBrand7 != "anyType{}")
                                oPVPDetail.Brand7 = oBLProduct.GetBrandID(sPVPDetail[8], sTerritoryID, myConnection, myTransaction);
                            else
                                oPVPDetail.Brand7 = null;
                            string sBrand8 = sPVPDetail[9];
                            if (sBrand8 != "" & sBrand8 != "anyType{}")
                                oPVPDetail.Brand8 = oBLProduct.GetBrandID(sPVPDetail[9], sTerritoryID, myConnection, myTransaction);
                            else
                                oPVPDetail.Brand8 = null;

                            string sSession = sPVPDetail[10];
                            if (sSession != "" & sSession != "anyType{}")
                                oPVPDetail.Session = sPVPDetail[10];
                            else
                                oPVPDetail.Session = null;

                            oPVPDetail.IsHoliday = Convert.ToBoolean(Convert.ToInt32(sPVPDetail[11]));

                            string sDoctorProfile = sPVPDetail[12];
                            if (sDoctorProfile != "" & sDoctorProfile != "anyType{}")
                                oPVPDetail.DoctorProfile = sPVPDetail[12];
                            else
                                oPVPDetail.DoctorProfile = null;

                            oPVPDetail.CreatedBy = sGDDBID;
                            oPVPDetail.CreationDate = Convert.ToDateTime(sPVPDetail[13]);
                            oPVPMaster.TransactionDetail.Add(oPVPDetail);
                        }

                        foreach (PVPDetail oDetail in oPVPMaster.TransactionDetail)
                        {
                            oDetail.PvpID = oPVPMaster.ID.ToInt32;
                            oBLPVPDetail.Save(oDetail, myConnection, myTransaction);
                        }

                        string sRMGDDBID = oBLEmployeeInfo.GetGDDBIDByTerritoryID(myConnection, myTransaction, sTerritoryID.Substring(0, 6));
                        oUserInfo = new UserInfo();
                        oUserInfo = oBLUserInfo.GetUserInfo(sRMGDDBID, connectionString);
                        oUserInfo.Version = oUserInfo.Version + 1;
                        oUserInfo.PVPVersion = oUserInfo.PVPVersion + 1;
                        oUserInfo.LastUpdateDate = DateTime.Now;
                        oBLUserInfo.Save(oUserInfo, myConnection, myTransaction);

                        oBLPVPMaster.InsertPVPCommandInfo(sTerritoryID, 2, myConnection, myTransaction);

                        sAuthenTicket = "1;" + oPVPMaster.ID.ToInt32.ToString();
                    }
                    else
                    {
                        sAuthenTicket = "-1";
                    }
                    myTransaction.Commit();

                }
                catch (Exception e)
                {
                    sAuthenTicket = e.Message.ToString();
                    myTransaction.Rollback();
                    oPVPExceptionLog.TerritoryID = sTerritoryID;
                    oPVPExceptionLog.GDDBID = sGDDBID;
                    oPVPExceptionLog.PVPDetail = sPVP;
                    oPVPExceptionLog.NoOfPlannedDay = nNoOfPlannedDay;
                    oPVPExceptionLog.ExceptionDetail = e.Message.ToString();
                    oPVPExceptionLog.ExceptionDateTime = DateTime.Now;
                    oBLPVPExceptionLog.Save(oPVPExceptionLog, myConnection, myTransaction);
                }
                finally
                {
                    myConnection.Close();
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                    sAuthenTicket = "Cannot connect to database.";
                else
                    sAuthenTicket = ex.Message.ToString();
                //throw new Exception(ex.Message);
            }

            return sAuthenTicket;
        }

        //[WebMethod(Description = "Method to Save PVP")]
        //public int SavePVP(string sPVP, string sGDDBID, string sTerritoryID, int nNoOfPlannedDay)
        //{
        //    PVPDetail oPVPDetail = new PVPDetail();
        //    PVPMaster oPVPMaster = new PVPMaster();
        //    Product oProduct = new Product();
        //    UserInfo oUserInfo = new UserInfo();
        //    PVPMonthCycle oPVPMonthCycle = new PVPMonthCycle();
        //    CommandInfo oCommandInfo = new CommandInfo();
        //    BLPVPDetail oBLPVPDetail = new BLPVPDetail();
        //    BLPVPMaster oBLPVPMaster = new BLPVPMaster();
        //    BLProduct oBLProduct = new BLProduct();
        //    BLPVPMonthCycle oBLPVPMonthCycle = new BLPVPMonthCycle();
        //    BLUserInfo oBLUserInfo = new BLUserInfo();
        //    BLEmployeeInfo oBLEmployeeInfo = new BLEmployeeInfo();
        //    BLCommandInfo oBLCommandInfo = new BLCommandInfo();
        //    int nAuthenTicket = 0;

        //    try
        //    {
        //        //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
        //        NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
        //        string connectionString = oValues["ConnectionString2"].ToString();
        //        SqlConnection myConnection = new SqlConnection(connectionString);
        //        myConnection.Open();
        //        // Start transaction.
        //        SqlTransaction myTransaction = myConnection.BeginTransaction();
        //        // Assign command in the current transaction.
        //        SqlCommand myCommand = new SqlCommand();
        //        myCommand.Transaction = myTransaction;
        //        try
        //        {
        //            // …………………….
        //            // Database operations
        //            oPVPMonthCycle = oBLPVPMonthCycle.GetPVPMonthCycle(connectionString);
        //            int nMonth = oPVPMonthCycle.Month;
        //            int nYear = oPVPMonthCycle.Year;
        //            DateTime dPVPEndDate = oPVPMonthCycle.EndDate;
        //            DateTime dCurrentDate = DateTime.Now.Date;

        //            bool bIsPVPOpen = false;
        //            if (dCurrentDate <= dPVPEndDate)
        //                bIsPVPOpen = true;
        //            if (!bIsPVPOpen)
        //            {
        //                //string sPVPEndDate = dCurrentDate.ToString("dd MMM yyyy");
        //                //bIsPVPOpen = oBLCommandInfo.IsPVPTimeExtend(myConnection, myTransaction, sTerritoryID, sPVPEndDate);
        //                string sPVPEndDate = oBLCommandInfo.GetPVPEndDate(myConnection, myTransaction, sTerritoryID);
        //                if (sPVPEndDate != "")
        //                    dPVPEndDate = Convert.ToDateTime(sPVPEndDate);
        //                if (dCurrentDate <= dPVPEndDate)
        //                    bIsPVPOpen = true;
        //            }

        //            if (bIsPVPOpen)
        //            {
        //                string[] sDetail = sPVP.Split(';');
        //                oPVPMaster = new PVPMaster();

        //                for (int i = 0; i < sDetail.Length - 1; i++)
        //                {
        //                    string[] sPVPDetail = sDetail[i].Split(',');
        //                    oPVPDetail = new PVPDetail();

        //                    string sDoctorID = sPVPDetail[0];
        //                    if (sDoctorID != "")
        //                        oPVPDetail.DoctorID = Convert.ToInt32(sPVPDetail[0]);
        //                    else
        //                        oPVPDetail.DoctorID = null;

        //                    oPVPDetail.TerritoryID = sTerritoryID;
        //                    oPVPDetail.Day = Convert.ToInt32(sPVPDetail[1]);
        //                    oPVPDetail.Month = nMonth;
        //                    oPVPDetail.Year = nYear;

        //                    string sBrand1 = sPVPDetail[2];
        //                    if (sBrand1 != "")
        //                        oPVPDetail.Brand1 = oBLProduct.GetBrandID(sPVPDetail[2], sTerritoryID, myConnection, myTransaction);
        //                    else
        //                        oPVPDetail.Brand1 = null;
        //                    string sBrand2 = sPVPDetail[3];
        //                    if (sBrand2 != "")
        //                        oPVPDetail.Brand2 = oBLProduct.GetBrandID(sPVPDetail[3], sTerritoryID, myConnection, myTransaction);
        //                    else
        //                        oPVPDetail.Brand2 = null;
        //                    string sBrand3 = sPVPDetail[4];
        //                    if (sBrand3 != "")
        //                        oPVPDetail.Brand3 = oBLProduct.GetBrandID(sPVPDetail[4], sTerritoryID, myConnection, myTransaction);
        //                    else
        //                        oPVPDetail.Brand3 = null;
        //                    string sBrand4 = sPVPDetail[5];
        //                    if (sBrand4 != "")
        //                        oPVPDetail.Brand4 = oBLProduct.GetBrandID(sPVPDetail[5], sTerritoryID, myConnection, myTransaction);
        //                    else
        //                        oPVPDetail.Brand4 = null;
        //                    string sBrand5 = sPVPDetail[6];
        //                    if (sBrand5 != "")
        //                        oPVPDetail.Brand5 = oBLProduct.GetBrandID(sPVPDetail[6], sTerritoryID, myConnection, myTransaction);
        //                    else
        //                        oPVPDetail.Brand5 = null;
        //                    string sBrand6 = sPVPDetail[7];
        //                    if (sBrand6 != "")
        //                        oPVPDetail.Brand6 = oBLProduct.GetBrandID(sPVPDetail[7], sTerritoryID, myConnection, myTransaction);
        //                    else
        //                        oPVPDetail.Brand6 = null;

        //                    string sSession = sPVPDetail[8];
        //                    if (sSession != "")
        //                        oPVPDetail.Session = sPVPDetail[8];
        //                    else
        //                        oPVPDetail.Session = null;

        //                    oPVPDetail.IsHoliday = Convert.ToBoolean(Convert.ToInt32(sPVPDetail[9]));

        //                    string sDoctorProfile = sPVPDetail[10];
        //                    if (sDoctorProfile != "")
        //                        oPVPDetail.DoctorProfile = sPVPDetail[10];
        //                    else
        //                        oPVPDetail.DoctorProfile = null;

        //                    oPVPDetail.CreatedBy = sGDDBID;
        //                    oPVPDetail.CreationDate = Convert.ToDateTime(sPVPDetail[11]);
        //                    oPVPMaster.TransactionDetail.Add(oPVPDetail);
        //                }

        //                //int nMaxPVPVersion = oBLPVPMaster.GetMaxPVPVersion(myConnection, myTransaction, sTerritoryID);
        //                int nMaxPVPVersion = oBLPVPMaster.GetMaxPVPVersion(myConnection, myTransaction);
        //                oPVPMaster.TerritoryID = sTerritoryID;
        //                oPVPMaster.Month = nMonth;
        //                oPVPMaster.Year = nYear;
        //                oPVPMaster.Status = PVPStatus.Submit;
        //                oPVPMaster.SubmitDate = DateTime.Now;
        //                oPVPMaster.ApprovedDate = Convert.ToDateTime("31 Dec 9999");
        //                oPVPMaster.SubmittedBy = sGDDBID;
        //                oPVPMaster.ApprovedBy = "";
        //                oPVPMaster.NoOfPlannedDay = nNoOfPlannedDay;
        //                oPVPMaster.Version = nMaxPVPVersion;
        //                oPVPMaster.Action = 1;

        //                if (!oBLPVPMaster.IsDuplicate(myConnection, myTransaction, nMonth, nYear, sTerritoryID))
        //                {
        //                    oBLPVPMaster.Save(oPVPMaster, myConnection, myTransaction);

        //                    foreach (PVPDetail oDetail in oPVPMaster.TransactionDetail)
        //                    {
        //                        oDetail.PvpID = oPVPMaster.ID.ToInt32;
        //                        oBLPVPDetail.Save(oDetail, myConnection, myTransaction);
        //                    }

        //                    string sRMGDDBID = oBLEmployeeInfo.GetGDDBIDByTerritoryID(myConnection, myTransaction, sTerritoryID.Substring(0, 6));
        //                    oUserInfo = new UserInfo();
        //                    oUserInfo = oBLUserInfo.GetUserInfo(sRMGDDBID, connectionString);
        //                    oUserInfo.Version = oUserInfo.Version + 1;
        //                    oUserInfo.PVPVersion = oUserInfo.PVPVersion + 1;
        //                    oBLUserInfo.Save(oUserInfo, myConnection, myTransaction);

        //                    nAuthenTicket = oPVPMaster.ID.ToInt32;
        //                }
        //                else
        //                {

        //                    //oCommandInfo = new CommandInfo();
        //                    //oCommandInfo.TerritoryID = sTerritoryID;
        //                    //oCommandInfo.TableName = "SecondTimePVP";
        //                    //oCommandInfo.Description = "Delete from PVPMasterInfo";
        //                    //oCommandInfo.IsExcute = false;
        //                    //oCommandInfo.Version = 1;
        //                    //oBLCommandInfo = new BLCommandInfo();
        //                    //oBLCommandInfo.Save(oCommandInfo, myConnection, myTransaction);

        //                    //oCommandInfo = new CommandInfo();
        //                    //oCommandInfo.TerritoryID = sTerritoryID;
        //                    //oCommandInfo.TableName = "SecondTimePVP";
        //                    //oCommandInfo.Description = "Delete from PVPDetailInfo";
        //                    //oCommandInfo.IsExcute = false;
        //                    //oCommandInfo.Version = 1;
        //                    //oBLCommandInfo = new BLCommandInfo();
        //                    //oBLCommandInfo.Save(oCommandInfo, myConnection, myTransaction);

        //                    //string sSFGDDBID = oBLEmployeeInfo.GetGDDBIDByTerritoryID(myConnection, myTransaction, sTerritoryID);
        //                    //oUserInfo = new UserInfo();
        //                    //oUserInfo = oBLUserInfo.GetUserInfo(sSFGDDBID, connectionString);
        //                    //oUserInfo.Version = oUserInfo.Version + 1;
        //                    //oUserInfo.CommandVersion = oUserInfo.CommandVersion + 1;
        //                    //oUserInfo.PVPVersion = oUserInfo.PVPVersion + 1;
        //                    //oBLUserInfo.Save(oUserInfo, myConnection, myTransaction);

        //                    //oCommandInfo = new CommandInfo();
        //                    //oCommandInfo.TerritoryID = sTerritoryID.Substring(0, 6);
        //                    //oCommandInfo.TableName = "SecondTimePVP";
        //                    //oCommandInfo.Description = "Delete from PVPMasterInfo";
        //                    //oCommandInfo.IsExcute = false;
        //                    //oCommandInfo.Version = 1;
        //                    //oBLCommandInfo = new BLCommandInfo();
        //                    //oBLCommandInfo.Save(oCommandInfo, myConnection, myTransaction);

        //                    //oCommandInfo = new CommandInfo();
        //                    //oCommandInfo.TerritoryID = sTerritoryID.Substring(0, 6);
        //                    //oCommandInfo.TableName = "SecondTimePVP";
        //                    //oCommandInfo.Description = "Delete from PVPDetailInfo";
        //                    //oCommandInfo.IsExcute = false;
        //                    //oCommandInfo.Version = 1;
        //                    //oBLCommandInfo = new BLCommandInfo();
        //                    //oBLCommandInfo.Save(oCommandInfo, myConnection, myTransaction);

        //                    //string sRMGDDBID = oBLEmployeeInfo.GetGDDBIDByTerritoryID(myConnection, myTransaction, sTerritoryID.Substring(0,6));
        //                    //oUserInfo = new UserInfo();
        //                    //oUserInfo = oBLUserInfo.GetUserInfo(sRMGDDBID, connectionString);
        //                    //oUserInfo.Version = oUserInfo.Version + 1;
        //                    //oUserInfo.CommandVersion = oUserInfo.CommandVersion + 1;
        //                    //oUserInfo.PVPVersion = oUserInfo.PVPVersion + 1;
        //                    //oBLUserInfo.Save(oUserInfo, myConnection, myTransaction);

        //                    oBLCommandInfo.InsertCommandInfo(sTerritoryID, myConnection, myTransaction);

        //                    oPVPMaster = new PVPMaster();
        //                    oPVPMaster = oBLPVPMaster.GetPVPMasterInfo(sTerritoryID, nMonth, nYear, connectionString);
        //                    nAuthenTicket = oPVPMaster.ID.ToInt32;
        //                }
        //            }
        //            myTransaction.Commit();

        //        }
        //        catch (Exception e)
        //        {
        //            myTransaction.Rollback();
        //        }
        //        finally
        //        {
        //            myConnection.Close();
        //        }

        //        return nAuthenTicket;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //[WebMethod(Description = "Method to ReSubmit PVP")]
        //public int ReSubmitPVP(string sPVP, string sGDDBID, string sTerritoryID, int nNoOfPlannedDay)
        //{
        //    PVPDetail oPVPDetail = new PVPDetail();
        //    PVPMaster oPVPMaster = new PVPMaster();
        //    Product oProduct = new Product();
        //    PVPMonthCycle oPVPMonthCycle = new PVPMonthCycle();
        //    BLPVPDetail oBLPVPDetail = new BLPVPDetail();
        //    BLPVPMaster oBLPVPMaster = new BLPVPMaster();
        //    BLProduct oBLProduct = new BLProduct();
        //    BLPVPMonthCycle oBLPVPMonthCycle = new BLPVPMonthCycle();
        //    int nAuthenTicket = 0;

        //    try
        //    {
        //        //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
        //        NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
        //        string connectionString = oValues["ConnectionString2"].ToString();

        //        SqlConnection myConnection = new SqlConnection(connectionString);
        //        myConnection.Open();
        //        // Start transaction.
        //        SqlTransaction myTransaction = myConnection.BeginTransaction();
        //        // Assign command in the current transaction.
        //        SqlCommand myCommand = new SqlCommand();
        //        myCommand.Transaction = myTransaction;
        //        try
        //        {
        //            // …………………….
        //            // Database operations
        //            DataTable otblPVPMonthCycle = new DataTable();

        //            string sPVPMonthCycle = "SELECT * FROM [PVPMonthCycle] WHERE IsActive=1";
        //            SqlDataAdapter Sfda = new SqlDataAdapter(sPVPMonthCycle, connectionString);
        //            Sfda.Fill(otblPVPMonthCycle);

        //            int nMonth = Convert.ToInt32(otblPVPMonthCycle.Rows[0]["Month"]);
        //            int nYear = Convert.ToInt32(otblPVPMonthCycle.Rows[0]["Year"]);

        //            string[] sDetail = sPVP.Split(';');
        //            oPVPMaster = new PVPMaster();

        //            for (int i = 0; i < sDetail.Length - 1; i++)
        //            {
        //                string[] sPVPDetail = sDetail[i].Split(',');
        //                oPVPDetail = new PVPDetail();
        //                string sDoctorID = sPVPDetail[0];
        //                if (sDoctorID != "" & sDoctorID != "anyType{}")
        //                    oPVPDetail.DoctorID = Convert.ToInt32(sPVPDetail[0]);
        //                else
        //                    oPVPDetail.DoctorID = null;
        //                oPVPDetail.TerritoryID = sTerritoryID;
        //                oPVPDetail.Day = Convert.ToInt32(sPVPDetail[1]);
        //                oPVPDetail.Month = nMonth;
        //                oPVPDetail.Year = nYear;
        //                string sBrand1 = sPVPDetail[2];
        //                if (sBrand1 != "" & sBrand1 != "anyType{}")
        //                {
        //                    //oPVPDetail.Brand1 = oBLProduct.GetProductID(sPVPDetail[2], sTerritoryID);
        //                    SqlCommand cmd1 = new SqlCommand();
        //                    cmd1.CommandText = "SELECT a.[ProdID] FROM [Product] a INNER JOIN [Territory] b ON a.Line=b.LineID WHERE a.ProdCode='" + sPVPDetail[2] + "'" + " and b.TerritoryID='" + sTerritoryID + "'";
        //                    cmd1.Connection = myConnection;
        //                    cmd1.Transaction = myTransaction;
        //                    object oBrand1 = cmd1.ExecuteScalar();
        //                    int nBrand1 = 0;
        //                    if (oBrand1 == DBNull.Value)
        //                    {
        //                        nBrand1 = 1;
        //                    }
        //                    else
        //                    {
        //                        nBrand1 = Convert.ToInt32(oBrand1);
        //                    }
        //                    oPVPDetail.Brand1 = nBrand1;
        //                }
        //                else
        //                    oPVPDetail.Brand1 = null;
        //                string sBrand2 = sPVPDetail[3];
        //                if (sBrand2 != "" & sBrand2 != "anyType{}")
        //                {
        //                    //oPVPDetail.Brand2 = oBLProduct.GetProductID(sPVPDetail[3], sTerritoryID);
        //                    SqlCommand cmd2 = new SqlCommand();
        //                    cmd2.CommandText = "SELECT a.[ProdID] FROM [Product] a INNER JOIN [Territory] b ON a.Line=b.LineID WHERE a.ProdCode='" + sPVPDetail[3] + "'" + " and b.TerritoryID='" + sTerritoryID + "'";
        //                    cmd2.Connection = myConnection;
        //                    cmd2.Transaction = myTransaction;
        //                    object oBrand2 = cmd2.ExecuteScalar();
        //                    int nBrand2 = 0;
        //                    if (oBrand2 == DBNull.Value)
        //                    {
        //                        nBrand2 = 1;
        //                    }
        //                    else
        //                    {
        //                        nBrand2 = Convert.ToInt32(oBrand2);
        //                    }
        //                    oPVPDetail.Brand2 = nBrand2;
        //                }
        //                else
        //                    oPVPDetail.Brand2 = null;
        //                string sBrand3 = sPVPDetail[4];
        //                if (sBrand3 != "" & sBrand3 != "anyType{}")
        //                {
        //                    //oPVPDetail.Brand3 = oBLProduct.GetProductID(sPVPDetail[4], sTerritoryID);
        //                    SqlCommand cmd3 = new SqlCommand();
        //                    cmd3.CommandText = "SELECT a.[ProdID] FROM [Product] a INNER JOIN [Territory] b ON a.Line=b.LineID WHERE a.ProdCode='" + sPVPDetail[4] + "'" + " and b.TerritoryID='" + sTerritoryID + "'";
        //                    cmd3.Connection = myConnection;
        //                    cmd3.Transaction = myTransaction;
        //                    object oBrand3 = cmd3.ExecuteScalar();
        //                    int nBrand3 = 0;
        //                    if (oBrand3 == DBNull.Value)
        //                    {
        //                        nBrand3 = 1;
        //                    }
        //                    else
        //                    {
        //                        nBrand3 = Convert.ToInt32(oBrand3);
        //                    }
        //                    oPVPDetail.Brand3 = nBrand3;
        //                }
        //                else
        //                    oPVPDetail.Brand3 = null;
        //                string sBrand4 = sPVPDetail[5];
        //                if (sBrand4 != "" & sBrand4 != "anyType{}")
        //                {
        //                    //oPVPDetail.Brand4 = oBLProduct.GetProductID(sPVPDetail[5], sTerritoryID);
        //                    SqlCommand cmd4 = new SqlCommand();
        //                    cmd4.CommandText = "SELECT a.[ProdID] FROM [Product] a INNER JOIN [Territory] b ON a.Line=b.LineID WHERE a.ProdCode='" + sPVPDetail[5] + "'" + " and b.TerritoryID='" + sTerritoryID + "'";
        //                    cmd4.Connection = myConnection;
        //                    cmd4.Transaction = myTransaction;
        //                    object oBrand4 = cmd4.ExecuteScalar();
        //                    int nBrand4 = 0;
        //                    if (oBrand4 == DBNull.Value)
        //                    {
        //                        nBrand4 = 1;
        //                    }
        //                    else
        //                    {
        //                        nBrand4 = Convert.ToInt32(oBrand4);
        //                    }
        //                    oPVPDetail.Brand4 = nBrand4;
        //                }
        //                else
        //                    oPVPDetail.Brand4 = null;
        //                string sBrand5 = sPVPDetail[6];
        //                if (sBrand5 != "" & sBrand5 != "anyType{}")
        //                {
        //                    //oPVPDetail.Brand5 = oBLProduct.GetProductID(sPVPDetail[6], sTerritoryID);
        //                    SqlCommand cmd5 = new SqlCommand();
        //                    cmd5.CommandText = "SELECT a.[ProdID] FROM [Product] a INNER JOIN [Territory] b ON a.Line=b.LineID WHERE a.ProdCode='" + sPVPDetail[6] + "'" + " and b.TerritoryID='" + sTerritoryID + "'";
        //                    cmd5.Connection = myConnection;
        //                    cmd5.Transaction = myTransaction;
        //                    object oBrand5 = cmd5.ExecuteScalar();
        //                    int nBrand5 = 0;
        //                    if (oBrand5 == DBNull.Value)
        //                    {
        //                        nBrand5 = 1;
        //                    }
        //                    else
        //                    {
        //                        nBrand5 = Convert.ToInt32(oBrand5);
        //                    }
        //                    oPVPDetail.Brand5 = nBrand5;
        //                }
        //                else
        //                    oPVPDetail.Brand5 = null;
        //                string sBrand6 = sPVPDetail[7];
        //                if (sBrand6 != "" & sBrand6 != "anyType{}")
        //                {
        //                    //oPVPDetail.Brand6 = oBLProduct.GetProductID(sPVPDetail[7], sTerritoryID);
        //                    SqlCommand cmd6 = new SqlCommand();
        //                    cmd6.CommandText = "SELECT a.[ProdID] FROM [Product] a INNER JOIN [Territory] b ON a.Line=b.LineID WHERE a.ProdCode='" + sPVPDetail[7] + "'" + " and b.TerritoryID='" + sTerritoryID + "'";
        //                    cmd6.Connection = myConnection;
        //                    cmd6.Transaction = myTransaction;
        //                    object oBrand6 = cmd6.ExecuteScalar();
        //                    int nBrand6 = 0;
        //                    if (oBrand6 == DBNull.Value)
        //                    {
        //                        nBrand6 = 1;
        //                    }
        //                    else
        //                    {
        //                        nBrand6 = Convert.ToInt32(oBrand6);
        //                    }
        //                    oPVPDetail.Brand6 = nBrand6;
        //                }
        //                else
        //                    oPVPDetail.Brand6 = null;
        //                string sSession = sPVPDetail[8];
        //                if (sSession != "" & sSession != "anyType{}")
        //                    oPVPDetail.Session = sPVPDetail[8];
        //                else
        //                    oPVPDetail.Session = null;
        //                oPVPDetail.IsHoliday = Convert.ToBoolean(Convert.ToInt32(sPVPDetail[9]));
        //                string sDoctorProfile = sPVPDetail[10];
        //                if (sDoctorProfile != "" & sDoctorProfile != "anyType{}")
        //                    oPVPDetail.DoctorProfile = sPVPDetail[10];
        //                else
        //                    oPVPDetail.DoctorProfile = null;
        //                oPVPDetail.CreatedBy = sGDDBID;
        //                oPVPDetail.CreationDate = Convert.ToDateTime(sPVPDetail[11]);
        //                oPVPMaster.TransactionDetail.Add(oPVPDetail);
        //            }

        //            SqlCommand cmd7 = new SqlCommand();
        //            cmd7.CommandText = "SELECT MAX(PvpID) AS PvpID FROM PVPMaster WHERE TerritoryID='" + sTerritoryID + "'";
        //            cmd7.Connection = myConnection;
        //            cmd7.Transaction = myTransaction;
        //            object oPVPMasterID = cmd7.ExecuteScalar();
        //            int nPVPMasterID = 0;
        //            if (oPVPMasterID == DBNull.Value)
        //            {
        //                nPVPMasterID = 1;
        //            }
        //            else
        //            {
        //                nPVPMasterID = Convert.ToInt32(oPVPMasterID);
        //            }

        //            SqlCommand cmd8 = new SqlCommand();
        //            cmd8.CommandText = "SELECT MAX(Version)+ 1 AS Version FROM PVPMaster WHERE TerritoryID Like '" + sTerritoryID.Substring(0, 6) + "%'";
        //            cmd8.Connection = myConnection;
        //            cmd8.Transaction = myTransaction;
        //            object oMaxVersion = cmd8.ExecuteScalar();
        //            int nMaxVersion = 0;
        //            if (oMaxVersion == DBNull.Value)
        //            {
        //                nMaxVersion = 1;
        //            }
        //            else
        //            {
        //                nMaxVersion = Convert.ToInt32(oMaxVersion);
        //            }

        //            oPVPMaster.ID.SetID(nPVPMasterID);
        //            oPVPMaster.TerritoryID = sTerritoryID;
        //            oPVPMaster.Month = nMonth;
        //            oPVPMaster.Year = nYear;
        //            oPVPMaster.Status = PVPStatus.Submit;
        //            oPVPMaster.SubmitDate = DateTime.Now;
        //            oPVPMaster.ApprovedDate = Convert.ToDateTime("31 Dec 9999");
        //            oPVPMaster.SubmittedBy = sGDDBID;
        //            oPVPMaster.ApprovedBy = "";
        //            oPVPMaster.NoOfPlannedDay = nNoOfPlannedDay;
        //            oPVPMaster.Version = nMaxVersion;
        //            oPVPMaster.Action = 2;

        //            string sSQL = SQL.MakeSQL("UPDATE [PVPMaster] SET TerritoryID = %s, Month = %n, Year = %n, Status = %n, SubmitDate = %D, ApprovedDate = %D, SubmittedBy = %s, ApprovedBy = %s, NoOfPlannedDay = %n, Version = %n, Action = %n WHERE [PvpID]=%n"
        //                , oPVPMaster.TerritoryID, oPVPMaster.Month, oPVPMaster.Year, oPVPMaster.Status, oPVPMaster.SubmitDate, oPVPMaster.ApprovedDate, oPVPMaster.SubmittedBy, oPVPMaster.ApprovedBy, oPVPMaster.NoOfPlannedDay, oPVPMaster.Version, oPVPMaster.Action, oPVPMaster.ID.ToInt32);


        //            SqlDataAdapter oAdapter = new SqlDataAdapter();
        //            SqlCommand cmd9 = new SqlCommand();
        //            cmd9 = new SqlCommand(sSQL, myConnection);
        //            cmd9.Transaction = myTransaction;
        //            oAdapter.UpdateCommand = cmd9;
        //            cmd9.ExecuteNonQuery();

        //            string sSQL1 = SQL.MakeSQL("DELETE FROM [PVPDetail] WHERE [PvpID]=%n", nPVPMasterID);

        //            SqlDataAdapter oAdapter2 = new SqlDataAdapter();
        //            SqlCommand cmd10 = new SqlCommand();
        //            cmd10 = new SqlCommand(sSQL1, myConnection);
        //            cmd10.Transaction = myTransaction;
        //            oAdapter2.InsertCommand = cmd10;
        //            cmd10.ExecuteNonQuery();

        //            foreach (PVPDetail oDetail in oPVPMaster.TransactionDetail)
        //            {
        //                oDetail.PvpID = oPVPMaster.ID.ToInt32;
        //                SqlCommand cmd11 = new SqlCommand();
        //                string sDetailID = "SELECT MAX(DetailID)+ 1 AS DetailID FROM PVPDetail";
        //                cmd11 = new SqlCommand(sDetailID, myConnection);
        //                cmd11.Transaction = myTransaction;
        //                object oDetailID = cmd11.ExecuteScalar();
        //                int nDetailID = 0;
        //                if (oDetailID == DBNull.Value)
        //                {
        //                    nDetailID = 1;
        //                }
        //                else
        //                {
        //                    nDetailID = Convert.ToInt32(oDetailID);
        //                }
        //                oDetail.ID.SetID(nDetailID);
        //                string sSQL2 = SQL.MakeSQL("INSERT INTO [PVPDetail](DetailID, PvpID, DoctorID, TerritoryID, Day, Month, Year, Brand1, Brand2, Brand3, Brand4, Brand5, Brand6, Session, IsHoliday, DoctorProfile, CreatedBy, CreationDate) "
        //                               + " VALUES(%n, %n, %n, %s, %n, %n, %n, %n, %n, %n, %n, %n, %n, %s, %b, %s, %s, %D) "
        //                               , oDetail.ID.ToInt32, oDetail.PvpID, oDetail.DoctorID, oDetail.TerritoryID, oDetail.Day, oDetail.Month, oDetail.Year, oDetail.Brand1, oDetail.Brand2, oDetail.Brand3, oDetail.Brand4, oDetail.Brand5, oDetail.Brand6, oDetail.Session, oDetail.IsHoliday, oDetail.DoctorProfile, oDetail.CreatedBy, oDetail.CreationDate);

        //                SqlDataAdapter oAdapter3 = new SqlDataAdapter();
        //                SqlCommand cmd12 = new SqlCommand();
        //                cmd12 = new SqlCommand(sSQL2, myConnection);
        //                cmd12.Transaction = myTransaction;
        //                oAdapter3.InsertCommand = cmd12;
        //                cmd12.ExecuteNonQuery();
        //            }

        //            //DataTable otblUserInfo = new DataTable();
        //            //string sUserInfo = "SELECT * FROM [UserInfo] WHERE GDDBID='" + sGDDBID + "' and IsActive=1";
        //            //SqlDataAdapter Sfda2 = new SqlDataAdapter(sUserInfo, connectionString);
        //            //Sfda2.Fill(otblUserInfo);

        //            //string sSQL3 = SQL.MakeSQL("UPDATE [UserInfo] SET Version=%n, PVPVersion=%n WHERE GDDBID=%s"
        //            //    , Convert.ToInt32(otblUserInfo.Rows[0]["Version"].ToString()) + 1, Convert.ToInt32(otblUserInfo.Rows[0]["PVPVersion"].ToString()) + 1, sGDDBID);

        //            //SqlDataAdapter oAdapter4 = new SqlDataAdapter();
        //            //SqlCommand cmd13 = new SqlCommand();
        //            //cmd13 = new SqlCommand(sSQL3, myConnection);
        //            //cmd13.Transaction = myTransaction;
        //            //oAdapter4.UpdateCommand = cmd13;
        //            //cmd13.ExecuteNonQuery();

        //            //SqlCommand cmd13 = new SqlCommand();
        //            //cmd13.CommandText = "SELECT TerritoryID FROM [GXBDDA-S3017].[OrderCollectionSystem_Test].[dbo].[Territory] WHERE TerritoryCode='" + sTerritoryID.Substring(0,5) + "'";
        //            //cmd13.Connection = myConnection;
        //            //cmd13.Transaction = myTransaction;
        //            //object oTerrID = cmd13.ExecuteScalar();
        //            //int nTerrID = 0;
        //            //if (oTerrID == DBNull.Value)
        //            //{
        //            //    nTerrID = 0;
        //            //}
        //            //else
        //            //{
        //            //    nTerrID = Convert.ToInt32(oTerrID);
        //            //}

        //            SqlCommand cmd14 = new SqlCommand();
        //            cmd14.CommandText = @"SELECT GDDBID FROM [OrderCollectionSystem].[dbo].[EmployeeInfo] a INNER JOIN [OrderCollectionSystem].[dbo].[Territory] b ON a.TerritoryID=b.TerritoryID WHERE b.TerritoryCode='" + sTerritoryID.Substring(0, 6) + "'";
        //            cmd14.Connection = myConnection;
        //            cmd14.Transaction = myTransaction;
        //            object oGDDBID = cmd14.ExecuteScalar();
        //            string sRMGDDBID = "";
        //            if (oGDDBID == DBNull.Value)
        //            {
        //                sRMGDDBID = "";
        //            }
        //            else
        //            {
        //                sRMGDDBID = Convert.ToString(oGDDBID);
        //            }

        //            DataTable otblRMUserInfo = new DataTable();
        //            string sRMUserInfo = "SELECT * FROM [UserInfo] WHERE GDDBID='" + sRMGDDBID + "' and IsActive=1";
        //            SqlDataAdapter Sfda3 = new SqlDataAdapter(sRMUserInfo, connectionString);
        //            Sfda3.Fill(otblRMUserInfo);

        //            string sSQL4 = SQL.MakeSQL("UPDATE [UserInfo] SET Version=%n, PVPVersion=%n WHERE GDDBID=%s"
        //                , Convert.ToInt32(otblRMUserInfo.Rows[0]["Version"].ToString()) + 1, Convert.ToInt32(otblRMUserInfo.Rows[0]["PVPVersion"].ToString()) + 1, sRMGDDBID);

        //            SqlDataAdapter oAdapter5 = new SqlDataAdapter();
        //            SqlCommand cmd15 = new SqlCommand();
        //            cmd15 = new SqlCommand(sSQL4, myConnection);
        //            cmd15.Transaction = myTransaction;
        //            oAdapter5.UpdateCommand = cmd15;
        //            cmd15.ExecuteNonQuery();

        //            nAuthenTicket = oPVPMaster.ID.ToInt32;

        //            myTransaction.Commit();

        //        }
        //        catch (Exception e)
        //        {
        //            myTransaction.Rollback();
        //        }
        //        finally
        //        {
        //            myConnection.Close();
        //        }

        //        return nAuthenTicket;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //[WebMethod(Description = "Method to ReSubmit PVP")]
        //public int ReSubmitPVP(string sPVP, string sGDDBID, string sTerritoryID, int nNoOfPlannedDay)
        //{
        //    PVPDetail oPVPDetail = new PVPDetail();
        //    PVPMaster oPVPMaster = new PVPMaster();
        //    Product oProduct = new Product();
        //    UserInfo oUserInfo = new UserInfo();
        //    PVPMonthCycle oPVPMonthCycle = new PVPMonthCycle();
        //    BLPVPDetail oBLPVPDetail = new BLPVPDetail();
        //    BLPVPMaster oBLPVPMaster = new BLPVPMaster();
        //    BLProduct oBLProduct = new BLProduct();
        //    BLPVPMonthCycle oBLPVPMonthCycle = new BLPVPMonthCycle();
        //    BLUserInfo oBLUserInfo = new BLUserInfo();
        //    BLEmployeeInfo oBLEmployeeInfo = new BLEmployeeInfo();
        //    BLCommandInfo oBLCommandInfo = new BLCommandInfo();
        //    int nAuthenTicket = 0;

        //    try
        //    {
        //        //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
        //        NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
        //        string connectionString = oValues["ConnectionString2"].ToString();

        //        SqlConnection myConnection = new SqlConnection(connectionString);
        //        myConnection.Open();
        //        // Start transaction.
        //        SqlTransaction myTransaction = myConnection.BeginTransaction();
        //        // Assign command in the current transaction.
        //        SqlCommand myCommand = new SqlCommand();
        //        myCommand.Transaction = myTransaction;
        //        try
        //        {
        //            // …………………….
        //            // Database operations
        //            oPVPMonthCycle = oBLPVPMonthCycle.GetPVPMonthCycle(connectionString);
        //            int nMonth = oPVPMonthCycle.Month;
        //            int nYear = oPVPMonthCycle.Year;
        //            DateTime dPVPEndDate = oPVPMonthCycle.EndDate;
        //            DateTime dCurrentDate = DateTime.Now.Date;

        //            bool bIsPVPOpen = false;
        //            if (dCurrentDate <= dPVPEndDate)
        //                bIsPVPOpen = true;
        //            if (!bIsPVPOpen)
        //            {
        //                //string sPVPEndDate = dCurrentDate.ToString("dd MMM yyyy");
        //                //bIsPVPOpen = oBLCommandInfo.IsPVPTimeExtend(myConnection, myTransaction, sTerritoryID, sPVPEndDate);
        //                string sPVPEndDate = oBLCommandInfo.GetPVPEndDate(myConnection, myTransaction, sTerritoryID);
        //                if (sPVPEndDate != "")
        //                    dPVPEndDate = Convert.ToDateTime(sPVPEndDate);
        //                if (dCurrentDate <= dPVPEndDate)
        //                    bIsPVPOpen = true;
        //            }

        //            if (bIsPVPOpen)
        //            {
        //                //int nMaxPVPVersion = oBLPVPMaster.GetMaxPVPVersion(myConnection, myTransaction, sTerritoryID);
        //                int nMaxPVPVersion = oBLPVPMaster.GetMaxPVPVersion(myConnection, myTransaction);
        //                oPVPMaster = new PVPMaster();
        //                oPVPMaster = oBLPVPMaster.GetPVPMasterInfo(sTerritoryID, nMonth, nYear, connectionString);
        //                oPVPMaster.Status = PVPStatus.Submit;
        //                oPVPMaster.SubmitDate = DateTime.Now;
        //                oPVPMaster.ApprovedDate = Convert.ToDateTime("31 Dec 9999");
        //                oPVPMaster.SubmittedBy = sGDDBID;
        //                oPVPMaster.ApprovedBy = "";
        //                oPVPMaster.NoOfPlannedDay = nNoOfPlannedDay;
        //                oPVPMaster.Version = nMaxPVPVersion;
        //                oPVPMaster.Action = 2;
        //                oBLPVPMaster.Save(oPVPMaster, myConnection, myTransaction);

        //                oBLPVPDetail.Delete(oPVPMaster.ID.ToInt32, myConnection, myTransaction);

        //                string[] sDetail = sPVP.Split(';');
        //                for (int i = 0; i < sDetail.Length - 1; i++)
        //                {
        //                    string[] sPVPDetail = sDetail[i].Split(',');
        //                    oPVPDetail = new PVPDetail();

        //                    string sDoctorID = sPVPDetail[0];
        //                    if (sDoctorID != "" & sDoctorID != "anyType{}")
        //                        oPVPDetail.DoctorID = Convert.ToInt32(sPVPDetail[0]);
        //                    else
        //                        oPVPDetail.DoctorID = null;

        //                    oPVPDetail.TerritoryID = sTerritoryID;
        //                    oPVPDetail.Day = Convert.ToInt32(sPVPDetail[1]);
        //                    oPVPDetail.Month = nMonth;
        //                    oPVPDetail.Year = nYear;

        //                    string sBrand1 = sPVPDetail[2];
        //                    if (sBrand1 != "" & sBrand1 != "anyType{}")
        //                        oPVPDetail.Brand1 = oBLProduct.GetBrandID(sPVPDetail[2], sTerritoryID, myConnection, myTransaction);
        //                    else
        //                        oPVPDetail.Brand1 = null;
        //                    string sBrand2 = sPVPDetail[3];
        //                    if (sBrand2 != "" & sBrand2 != "anyType{}")
        //                        oPVPDetail.Brand2 = oBLProduct.GetBrandID(sPVPDetail[3], sTerritoryID, myConnection, myTransaction);
        //                    else
        //                        oPVPDetail.Brand2 = null;
        //                    string sBrand3 = sPVPDetail[4];
        //                    if (sBrand3 != "" & sBrand3 != "anyType{}")
        //                        oPVPDetail.Brand3 = oBLProduct.GetBrandID(sPVPDetail[4], sTerritoryID, myConnection, myTransaction);
        //                    else
        //                        oPVPDetail.Brand3 = null;
        //                    string sBrand4 = sPVPDetail[5];
        //                    if (sBrand4 != "" & sBrand4 != "anyType{}")
        //                        oPVPDetail.Brand4 = oBLProduct.GetBrandID(sPVPDetail[5], sTerritoryID, myConnection, myTransaction);
        //                    else
        //                        oPVPDetail.Brand4 = null;
        //                    string sBrand5 = sPVPDetail[6];
        //                    if (sBrand5 != "" & sBrand5 != "anyType{}")
        //                        oPVPDetail.Brand5 = oBLProduct.GetBrandID(sPVPDetail[6], sTerritoryID, myConnection, myTransaction);
        //                    else
        //                        oPVPDetail.Brand5 = null;
        //                    string sBrand6 = sPVPDetail[7];
        //                    if (sBrand6 != "" & sBrand6 != "anyType{}")
        //                        oPVPDetail.Brand6 = oBLProduct.GetBrandID(sPVPDetail[7], sTerritoryID, myConnection, myTransaction);
        //                    else
        //                        oPVPDetail.Brand6 = null;

        //                    string sSession = sPVPDetail[8];
        //                    if (sSession != "" & sSession != "anyType{}")
        //                        oPVPDetail.Session = sPVPDetail[8];
        //                    else
        //                        oPVPDetail.Session = null;

        //                    oPVPDetail.IsHoliday = Convert.ToBoolean(Convert.ToInt32(sPVPDetail[9]));

        //                    string sDoctorProfile = sPVPDetail[10];
        //                    if (sDoctorProfile != "" & sDoctorProfile != "anyType{}")
        //                        oPVPDetail.DoctorProfile = sPVPDetail[10];
        //                    else
        //                        oPVPDetail.DoctorProfile = null;
        //                    oPVPDetail.CreatedBy = sGDDBID;

        //                    oPVPDetail.CreationDate = Convert.ToDateTime(sPVPDetail[11]);
        //                    oPVPMaster.TransactionDetail.Add(oPVPDetail);
        //                }

        //                foreach (PVPDetail oDetail in oPVPMaster.TransactionDetail)
        //                {
        //                    oDetail.PvpID = oPVPMaster.ID.ToInt32;
        //                    oBLPVPDetail.Save(oDetail, myConnection, myTransaction);
        //                }

        //                string sRMGDDBID = oBLEmployeeInfo.GetGDDBIDByTerritoryID(myConnection, myTransaction, sTerritoryID.Substring(0, 6));
        //                oUserInfo = new UserInfo();
        //                oUserInfo = oBLUserInfo.GetUserInfo(sRMGDDBID, connectionString);
        //                oUserInfo.Version = oUserInfo.Version + 1;
        //                oUserInfo.PVPVersion = oUserInfo.PVPVersion + 1;
        //                oBLUserInfo.Save(oUserInfo, myConnection, myTransaction);

        //                nAuthenTicket = oPVPMaster.ID.ToInt32;
        //            }

        //            myTransaction.Commit();

        //        }
        //        catch (Exception e)
        //        {
        //            myTransaction.Rollback();
        //        }
        //        finally
        //        {
        //            myConnection.Close();
        //        }

        //        return nAuthenTicket;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        [WebMethod(Description = "Method to Get PVPMasterInfo")]
        public PVPMasters GetPVPMasterInfo(string sTerritoryID, int nMaxVersion)
        {
            PVPMasters oPVPMasters = new PVPMasters();
            BLPVPMaster oBL = new BLPVPMaster();

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;
                try
                {
                    DateTime dCurrentDate = DateTime.Now;
                    int nCurrentMonth = dCurrentDate.Month;
                    int nCurrentYear = dCurrentDate.Year;
                    DateTime dPreviousDate = DateTime.Now.AddMonths(-1);
                    int nPreviousMonth = dPreviousDate.Month;
                    int nPreviousYear = dPreviousDate.Year;
                    DateTime dNextDate = DateTime.Now.AddMonths(1);
                    int nNextMonth = dNextDate.Month;
                    int nNextYear = dNextDate.Year;
                    //int nPreviousMonthDay = DateTime.DaysInMonth(nPreviousYear, nPreviousMonth) - 4;
                    //oPVPMasters = oBL.GetPVPMasterInfo(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonth, nPreviousYear, nNextMonth, nNextYear, nMaxVersion);
                    oPVPMasters = oBL.GetPVPMasters(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonth, nPreviousYear, nNextMonth, nNextYear, nMaxVersion, connectionString);
                    myTransaction.Commit();
                }
                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
                return oPVPMasters;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Get PVPDetailInfo")]
        public List<PVPDetailInfo> GetPVPDetailInfo(string sTerritoryID, int nMaxVersion)
        {
            oPVPDetailInfoList = new List<PVPDetailInfo> { };
            PVPDetailInfo oPVPDetailInfo = new PVPDetailInfo();
            PVPDetails oPVPDetails = new PVPDetails();
            AppConfigurationInfo oAppConfigInfo = new AppConfigurationInfo();
            BLPVPDetail oBL = new BLPVPDetail();
            BLProduct oBLProduct = new BLProduct();
            BLAppConfigurationInfo oBLAppConfig = new BLAppConfigurationInfo();

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    DateTime dCurrentDate = DateTime.Now;
                    int nCurrentMonth = dCurrentDate.Month;
                    int nCurrentYear = dCurrentDate.Year;
                    DateTime dPreviousDate = DateTime.Now.AddMonths(-1);
                    int nPreviousMonth = dPreviousDate.Month;
                    int nPreviousYear = dPreviousDate.Year;
                    DateTime dNextDate = DateTime.Now.AddMonths(1);
                    int nNextMonth = dNextDate.Month;
                    int nNextYear = dNextDate.Year;
                    //oAppConfigInfo = oBLAppConfig.GetAppConfigurationInfo();
                    oAppConfigInfo = oBLAppConfig.GetAppConfigurationInfo(sTerritoryID, connectionString);
                    int nDCREntryHours = oAppConfigInfo.DCREntryHours;
                    int nPreviousDCREntryDay = nDCREntryHours / 24;
                    int nPreviousMonthDay = DateTime.DaysInMonth(nPreviousYear, nPreviousMonth) - nPreviousDCREntryDay;
                    //oPVPDetails = oBL.GetPVPDetailInfo(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonthDay, nPreviousMonth, nPreviousYear, nNextMonth, nNextYear, nMaxVersion);
                    oPVPDetails = oBL.GetPVPDetails(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonthDay, nPreviousMonth, nPreviousYear, nNextMonth, nNextYear, nMaxVersion, connectionString);

                    foreach (PVPDetail oPVPDetail in oPVPDetails)
                    {
                        oPVPDetailInfo = new PVPDetailInfo();
                        oPVPDetailInfo.sPvpID = oPVPDetail.PvpID.ToString();
                        oPVPDetailInfo.sTerritoryID = oPVPDetail.TerritoryID;
                        oPVPDetailInfo.sDoctorID = oPVPDetail.DoctorID.ToString();
                        oPVPDetailInfo.nDay = oPVPDetail.Day;
                        oPVPDetailInfo.nMonth = oPVPDetail.Month;
                        oPVPDetailInfo.nYear = oPVPDetail.Year;
                        if (oPVPDetail.Session == null)
                            oPVPDetailInfo.sSession = "";
                        else
                            oPVPDetailInfo.sSession = oPVPDetail.Session;
                        oPVPDetailInfo.nIsHoliday = Convert.ToInt32(oPVPDetail.IsHoliday);
                        if (oPVPDetail.DoctorProfile == null)
                            oPVPDetailInfo.sDoctorProfile = "";
                        else
                            oPVPDetailInfo.sDoctorProfile = oPVPDetail.DoctorProfile;
                        oPVPDetailInfo.sCreationDate = oPVPDetail.CreationDate.ToString("dd MMM yyyy HH:mm:ss");
                        if (oPVPDetail.Brand1 == null)
                            oPVPDetailInfo.sBrand1 = "";
                        else
                            oPVPDetailInfo.sBrand1 = oBLProduct.GetProductCode((int)oPVPDetail.Brand1);
                        if (oPVPDetail.Brand2 == null)
                            oPVPDetailInfo.sBrand2 = "";
                        else
                            oPVPDetailInfo.sBrand2 = oBLProduct.GetProductCode((int)oPVPDetail.Brand2);
                        if (oPVPDetail.Brand3 == null)
                            oPVPDetailInfo.sBrand3 = "";
                        else
                            oPVPDetailInfo.sBrand3 = oBLProduct.GetProductCode((int)oPVPDetail.Brand3);
                        if (oPVPDetail.Brand4 == null)
                            oPVPDetailInfo.sBrand4 = "";
                        else
                            oPVPDetailInfo.sBrand4 = oBLProduct.GetProductCode((int)oPVPDetail.Brand4);
                        if (oPVPDetail.Brand5 == null)
                            oPVPDetailInfo.sBrand5 = "";
                        else
                            oPVPDetailInfo.sBrand5 = oBLProduct.GetProductCode((int)oPVPDetail.Brand5);
                        if (oPVPDetail.Brand6 == null)
                            oPVPDetailInfo.sBrand6 = "";
                        else
                            oPVPDetailInfo.sBrand6 = oBLProduct.GetProductCode((int)oPVPDetail.Brand6);
                        if (oPVPDetail.Brand7 == null)
                            oPVPDetailInfo.sBrand7 = "";
                        else
                            oPVPDetailInfo.sBrand7 = oBLProduct.GetProductCode((int)oPVPDetail.Brand7);
                        if (oPVPDetail.Brand8 == null)
                            oPVPDetailInfo.sBrand8 = "";
                        else
                            oPVPDetailInfo.sBrand8 = oBLProduct.GetProductCode((int)oPVPDetail.Brand8);
                        oPVPDetailInfoList.Add(oPVPDetailInfo);
                    }
                    myTransaction.Commit();
                }
                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
                return oPVPDetailInfoList;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //public PVPDetails GetPVPDetailInfo(string sTerritoryID, int nMaxVersion)
        //{
        //    try
        //    {
        //        PVPDetails oPVPDetails = new PVPDetails();
        //        BLPVPDetail oBL = new BLPVPDetail();
        //        DateTime dCurrentDate = DateTime.Now;
        //        int nCurrentMonth = dCurrentDate.Month;
        //        int nCurrentYear = dCurrentDate.Year;
        //        DateTime dPreviousDate = DateTime.Now.AddMonths(-1);
        //        int nPreviousMonth = dPreviousDate.Month;
        //        int nPreviousYear = dPreviousDate.Year;
        //        DateTime dNextDate = DateTime.Now.AddMonths(1);
        //        int nNextMonth = dNextDate.Month;
        //        int nNextYear = dNextDate.Year;
        //        int nPreviousMonthDay = DateTime.DaysInMonth(nPreviousYear, nPreviousMonth) - 4;
        //        oPVPDetails = oBL.GetPVPDetailInfo(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonthDay, nPreviousMonth, nPreviousYear, nNextMonth, nNextYear, nMaxVersion);
        //        return oPVPDetails;
        //    }

        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //[WebMethod(Description = "Method to Get Encrypt Password")]
        //public void Password(string abc)
        //{
        //    string def = DAAccess.Encrypt(abc);
        //}

        [WebMethod(Description = "Method to Insert New DCR")]
        public string InsertDCRForSFNewVisit(int nDoctorID, string sTerritoryID, int nDay, int nMonth, int nYear, int nStatus, string sVisitDateTime, int nIsVisited,
                             int nIsAvailable, int nIsAccompanyByRM_SF, string sRemForNotCall, int nNotAvailableReasonID,
                             string sNotAvailableReason, int nIsNewVisit, string sSession, string sBrand1, string sBrand2, string sBrand3, string sBrand4,
                             string sBrand5, string sBrand6, string sBrand7, string sBrand8, string sSubmitDateTime, string sSubmittedBy)
        {

            DCR oDCR = new DCR();
            UserInfo oUserInfo = new UserInfo();
            AppConfigurationInfo oAppConfigInfo = new AppConfigurationInfo();
            BLDCR oBLDCR = new BLDCR();
            BLUserInfo oBLUserInfo = new BLUserInfo();
            BLEmployeeInfo oBLEmployeeInfo = new BLEmployeeInfo();
            BLAppConfigurationInfo oBLAppConfig = new BLAppConfigurationInfo();
            BLCommandInfo oBLCommandInfo = new BLCommandInfo();
            string sDCRID = "";

            try
            {
                //string sconnectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string sconnectionString = oValues["ConnectionString2"].ToString();

                SqlConnection oConnection = new SqlConnection(sconnectionString);
                oConnection.Open();
                //Start transaction.
                SqlTransaction oTransaction = oConnection.BeginTransaction();
                //Assign command in the current transaction.
                SqlCommand oCommand = new SqlCommand();
                oCommand.Transaction = oTransaction;

                try
                {
                    oAppConfigInfo = oBLAppConfig.GetAppConfigurationInfo(sTerritoryID, sconnectionString);
                    int nDCREntryHours = oAppConfigInfo.DCREntryHours;
                    DateTime dDCRDate = new DateTime(nYear, nMonth, nDay);
                    dDCRDate = dDCRDate.AddHours(nDCREntryHours);
                    DateTime dCurrentDate = DateTime.Now;

                    bool bIsDCROpen = false;
                    if (dCurrentDate <= dDCRDate)
                        bIsDCROpen = true;
                    //if (!bIsDCROpen)
                    //{
                    //    nDCREntryHours = oBLCommandInfo.GetDCREntryHours(oConnection, oTransaction, sTerritoryID);
                    //    dDCRDate = new DateTime(nYear, nMonth, nDay);
                    //    dDCRDate = dDCRDate.AddHours(nDCREntryHours);
                    //    if (dCurrentDate <= dDCRDate)
                    //        bIsDCROpen = true;
                    //}

                    if (bIsDCROpen)
                    {
                        if (sSubmittedBy != "")
                        {
                            int nUserID = 0;
                            nUserID = oBLUserInfo.GetActiveUserIDBYGDDBID(oConnection, oTransaction, sSubmittedBy);
                            if (nUserID > 0)
                            {
                                DataTable oTable = new DataTable();
                                oTable = oBLDCR.GetDCRTableByDoctorIDTerritoryIDDayMonthYear(nDoctorID, sTerritoryID, nDay,
                                nMonth, nYear, sSession, sconnectionString);

                                if (oTable.Rows.Count == 0)
                                {
                                    oDCR = new DCR();
                                    oDCR.PvpDetailID = null;
                                    oDCR.DoctorID = nDoctorID;
                                    oDCR.TerritoryID = sTerritoryID;
                                    oDCR.Day = nDay;
                                    oDCR.Month = nMonth;
                                    oDCR.Year = nYear;
                                    oDCR.Status = nStatus;
                                    oDCR.Session = sSession;
                                    oDCR.VisitDateTime = Convert.ToDateTime(sVisitDateTime);
                                    oDCR.IsVisited = Convert.ToBoolean(nIsVisited);
                                    oDCR.IsAvailable = Convert.ToBoolean(nIsAvailable);
                                    oDCR.IsAccompanyByRM_SF = Convert.ToBoolean(nIsAccompanyByRM_SF);
                                    oDCR.ReminderNextCall = sRemForNotCall;
                                    oDCR.IsNewVisit = Convert.ToBoolean(nIsNewVisit);
                                    oDCR.Session = sSession;
                                    oDCR.IsAccompanyByRM_RM = false;

                                    oDCR.SubmittedBy = nUserID;
                                    oDCR.SubmitDateTime = Convert.ToDateTime(sSubmitDateTime);


                                    oDCR.Action = 1;
                                }
                                else
                                {

                                    oDCR = oBLDCR.GetDCR(nDoctorID, sTerritoryID, nDay, nMonth, nYear, sSession, sconnectionString);

                                    oDCR.DoctorID = nDoctorID;
                                    oDCR.TerritoryID = sTerritoryID;
                                    oDCR.Day = nDay;
                                    oDCR.Month = nMonth;
                                    oDCR.Year = nYear;
                                    oDCR.Status = nStatus;
                                    oDCR.VisitDateTime = Convert.ToDateTime(sVisitDateTime);
                                    oDCR.IsVisited = Convert.ToBoolean(nIsVisited);
                                    oDCR.IsAvailable = Convert.ToBoolean(nIsAvailable);
                                    oDCR.IsAccompanyByRM_SF = Convert.ToBoolean(nIsAccompanyByRM_SF);
                                    if (sRemForNotCall != "")
                                        oDCR.ReminderNextCall = sRemForNotCall;
                                    else
                                        oDCR.ReminderNextCall = null;
                                    oDCR.NotAvailableReasonID = nNotAvailableReasonID;
                                    oDCR.NotAvailableReason = sNotAvailableReason;
                                    oDCR.RejectReason = null;
                                    oDCR.Session = sSession;

                                    oDCR.SubmittedBy = nUserID;
                                    oDCR.SubmitDateTime = Convert.ToDateTime(sSubmitDateTime);

                                    oDCR.Action = 2;
                                }
                                //oDCR.Version = oBLDCR.GetDCRNewVersion(oConnection, oTransaction, sTerritoryID);
                                oDCR.Version = oBLDCR.GetDCRNewVersion(oConnection, oTransaction);
                                if (sBrand1.Trim() != "B1")
                                {
                                    GetBrandDetail(1, sBrand1, oDCR, sTerritoryID, nMonth, nYear, oConnection, oTransaction);
                                }
                                if (sBrand2.Trim() != "B2")
                                {
                                    GetBrandDetail(2, sBrand2, oDCR, sTerritoryID, nMonth, nYear, oConnection, oTransaction);
                                }
                                if (sBrand3.Trim() != "B3")
                                {
                                    GetBrandDetail(3, sBrand3, oDCR, sTerritoryID, nMonth, nYear, oConnection, oTransaction);
                                }
                                if (sBrand4.Trim() != "B4")
                                {
                                    GetBrandDetail(4, sBrand4, oDCR, sTerritoryID, nMonth, nYear, oConnection, oTransaction);
                                }
                                if (sBrand5.Trim() != "B5")
                                {
                                    GetBrandDetail(5, sBrand5, oDCR, sTerritoryID, nMonth, nYear, oConnection, oTransaction);
                                }
                                if (sBrand6.Trim() != "B6")
                                {
                                    GetBrandDetail(6, sBrand6, oDCR, sTerritoryID, nMonth, nYear, oConnection, oTransaction);
                                }
                                if (sBrand7.Trim() != "B7")
                                {
                                    GetBrandDetail(7, sBrand7, oDCR, sTerritoryID, nMonth, nYear, oConnection, oTransaction);
                                }
                                if (sBrand8.Trim() != "B8")
                                {
                                    GetBrandDetail(8, sBrand8, oDCR, sTerritoryID, nMonth, nYear, oConnection, oTransaction);
                                }
                                oBLDCR.Save(oDCR, oConnection, oTransaction);

                                string sRMGDDBID = oBLEmployeeInfo.GetGDDBIDByTerritoryID(oConnection, oTransaction, sTerritoryID.Substring(0, 6));

                                oUserInfo = new UserInfo();
                                oUserInfo = oBLUserInfo.GetUserInfo(sRMGDDBID, sconnectionString);
                                oUserInfo.Version = oUserInfo.Version + 1;
                                oUserInfo.DCRVersion = oUserInfo.DCRVersion + 1;
                                oUserInfo.LastUpdateDate = DateTime.Now;
                                oBLUserInfo.Save(oUserInfo, oConnection, oTransaction);
                                //sDCRID = oDCR.ID.ToInt32.ToString();
                                sDCRID = "1;" + oDCR.ID.ToInt32.ToString();

                                // ……………………
                            }
                        }
                    }
                    else
                    {
                        sDCRID = "-1";
                    }
                    oTransaction.Commit();
                }
                catch (Exception e)
                {
                    sDCRID = e.Message.ToString();
                    oTransaction.Rollback();
                }
                finally
                {
                    oConnection.Close();
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                    sDCRID = "Cannot connect to database.";
                else
                    sDCRID = ex.Message.ToString();
                //throw new Exception(ex.Message);
            }

            return sDCRID;
        }

        [WebMethod(Description = "Method to Update DCR")]
        public string UpdateSFDCR(int nDoctorID, string sTerritoryID, int nDay, int nMonth, int nYear, int nStatus, string sVisitDateTime, int nIsVisited,
                             int nIsAvailable, int nIsAccompanyByRM_SF, string sRemForNotCall, int nNotAvailableReasonID,
                             string sNotAvailableReason, int nIsNewVisit, string sSession, string sBrand1, string sBrand2, string sBrand3, string sBrand4,
                             string sBrand5, string sBrand6, string sBrand7, string sBrand8, string sSubmitDateTime, string sSubmittedBy)
        {
            DCR oDCR = new DCR();
            UserInfo oUserInfo = new UserInfo();
            AppConfigurationInfo oAppConfigInfo = new AppConfigurationInfo();
            BLDCR oBLDCR = new BLDCR();
            BLUserInfo oBLUserInfo = new BLUserInfo();
            BLEmployeeInfo oBLEmployeeInfo = new BLEmployeeInfo();
            BLAppConfigurationInfo oBLAppConfig = new BLAppConfigurationInfo();
            BLCommandInfo oBLCommandInfo = new BLCommandInfo();
            string sUpdateDCR = "";

            try
            {
                //string sconnectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string sconnectionString = oValues["ConnectionString2"].ToString();

                SqlConnection oConnection = new SqlConnection(sconnectionString);
                oConnection.Open();
                //Start transaction.
                SqlTransaction oTransaction = oConnection.BeginTransaction();
                //Assign command in the current transaction.
                SqlCommand oCommand = new SqlCommand();
                oCommand.Transaction = oTransaction;

                try
                {
                    oAppConfigInfo = oBLAppConfig.GetAppConfigurationInfo(sTerritoryID, sconnectionString);
                    int nDCREntryHours = oAppConfigInfo.DCREntryHours;
                    DateTime dDCRDate = new DateTime(nYear, nMonth, nDay);
                    dDCRDate = dDCRDate.AddHours(nDCREntryHours);
                    DateTime dCurrentDate = DateTime.Now;

                    bool bIsDCROpen = false;
                    if (dCurrentDate <= dDCRDate)
                        bIsDCROpen = true;
                    //if (!bIsDCROpen)
                    //{
                    //    nDCREntryHours = oBLCommandInfo.GetDCREntryHours(oConnection, oTransaction, sTerritoryID);
                    //    dDCRDate = new DateTime(nYear, nMonth, nDay);
                    //    dDCRDate = dDCRDate.AddHours(nDCREntryHours);
                    //    if (dCurrentDate <= dDCRDate)
                    //        bIsDCROpen = true;
                    //}

                    if (bIsDCROpen)
                    {
                        if (sSubmittedBy != "")
                        {
                            int nUserID = 0;
                            nUserID = oBLUserInfo.GetActiveUserIDBYGDDBID(oConnection, oTransaction, sSubmittedBy);
                            if (nUserID > 0)
                            {
                                DataTable oTable = new DataTable();
                                oTable = oBLDCR.GetDCRTableByDoctorIDTerritoryIDDayMonthYear(nDoctorID, sTerritoryID, nDay,
                                nMonth, nYear, sSession, sconnectionString);

                                if (oTable.Rows.Count == 0)
                                {
                                    oDCR = new DCR();
                                    oDCR.PvpDetailID = null;
                                    oDCR.DoctorID = nDoctorID;
                                    oDCR.TerritoryID = sTerritoryID;
                                    oDCR.Day = nDay;
                                    oDCR.Month = nMonth;
                                    oDCR.Year = nYear;
                                    oDCR.Status = nStatus;
                                    oDCR.Session = sSession;
                                    oDCR.VisitDateTime = Convert.ToDateTime(sVisitDateTime);
                                    oDCR.IsVisited = Convert.ToBoolean(nIsVisited);
                                    oDCR.IsAvailable = Convert.ToBoolean(nIsAvailable);
                                    oDCR.IsAccompanyByRM_SF = Convert.ToBoolean(nIsAccompanyByRM_SF);
                                    oDCR.ReminderNextCall = sRemForNotCall;
                                    oDCR.IsNewVisit = Convert.ToBoolean(nIsNewVisit);
                                    oDCR.Session = sSession;
                                    oDCR.IsAccompanyByRM_RM = false;

                                    oDCR.SubmittedBy = nUserID;
                                    oDCR.SubmitDateTime = Convert.ToDateTime(sSubmitDateTime);

                                    oDCR.Action = 1;
                                }
                                else
                                {

                                    oDCR = oBLDCR.GetDCR(nDoctorID, sTerritoryID, nDay, nMonth, nYear, sSession, sconnectionString);

                                    oDCR.DoctorID = nDoctorID;
                                    oDCR.TerritoryID = sTerritoryID;
                                    oDCR.Day = nDay;
                                    oDCR.Month = nMonth;
                                    oDCR.Year = nYear;
                                    oDCR.Status = nStatus;
                                    oDCR.VisitDateTime = Convert.ToDateTime(sVisitDateTime);
                                    oDCR.IsVisited = Convert.ToBoolean(nIsVisited);
                                    oDCR.IsAvailable = Convert.ToBoolean(nIsAvailable);
                                    oDCR.IsAccompanyByRM_SF = Convert.ToBoolean(nIsAccompanyByRM_SF);
                                    if (sRemForNotCall != "")
                                        oDCR.ReminderNextCall = sRemForNotCall;
                                    else
                                        oDCR.ReminderNextCall = null;
                                    oDCR.NotAvailableReasonID = nNotAvailableReasonID;
                                    oDCR.NotAvailableReason = sNotAvailableReason;
                                    oDCR.RejectReason = null;
                                    oDCR.Session = sSession;

                                    oDCR.SubmittedBy = nUserID;
                                    oDCR.SubmitDateTime = Convert.ToDateTime(sSubmitDateTime);

                                    oDCR.Action = 2;
                                }
                                //oDCR.Version = oBLDCR.GetDCRNewVersion(oConnection, oTransaction, sTerritoryID);
                                oDCR.Version = oBLDCR.GetDCRNewVersion(oConnection, oTransaction);
                                if (sBrand1.Trim() != "B1")
                                {
                                    GetBrandDetail(1, sBrand1, oDCR, sTerritoryID, nMonth, nYear, oConnection, oTransaction);
                                }
                                if (sBrand2.Trim() != "B2")
                                {
                                    GetBrandDetail(2, sBrand2, oDCR, sTerritoryID, nMonth, nYear, oConnection, oTransaction);
                                }
                                if (sBrand3.Trim() != "B3")
                                {
                                    GetBrandDetail(3, sBrand3, oDCR, sTerritoryID, nMonth, nYear, oConnection, oTransaction);
                                }

                                if (sBrand4.Trim() != "B4")
                                {
                                    GetBrandDetail(4, sBrand4, oDCR, sTerritoryID, nMonth, nYear, oConnection, oTransaction);
                                }
                                if (sBrand5.Trim() != "B5")
                                {
                                    GetBrandDetail(5, sBrand5, oDCR, sTerritoryID, nMonth, nYear, oConnection, oTransaction);
                                }
                                if (sBrand6.Trim() != "B6")
                                {
                                    GetBrandDetail(6, sBrand6, oDCR, sTerritoryID, nMonth, nYear, oConnection, oTransaction);
                                }
                                if (sBrand7.Trim() != "B7")
                                {
                                    GetBrandDetail(7, sBrand7, oDCR, sTerritoryID, nMonth, nYear, oConnection, oTransaction);
                                }
                                if (sBrand8.Trim() != "B8")
                                {
                                    GetBrandDetail(8, sBrand8, oDCR, sTerritoryID, nMonth, nYear, oConnection, oTransaction);
                                }

                                oBLDCR.Save(oDCR, oConnection, oTransaction);

                                string sRMGDDBID = oBLEmployeeInfo.GetGDDBIDByTerritoryID(oConnection, oTransaction, oDCR.TerritoryID.Substring(0, 6));

                                oUserInfo = new UserInfo();
                                oUserInfo = oBLUserInfo.GetUserInfo(sRMGDDBID, sconnectionString);

                                oUserInfo.Version = oUserInfo.Version + 1;
                                oUserInfo.DCRVersion = oUserInfo.DCRVersion + 1;
                                oUserInfo.LastUpdateDate = DateTime.Now;
                                oBLUserInfo.Save(oUserInfo, oConnection, oTransaction);
                                sUpdateDCR = "1";

                            }
                        }
                    }
                    else
                    {
                        sUpdateDCR = "-1";
                    }
                    // ……………………
                    oTransaction.Commit();
                }
                catch (Exception e)
                {
                    sUpdateDCR = e.Message.ToString();
                    oTransaction.Rollback();
                }
                finally
                {
                    oConnection.Close();
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                    sUpdateDCR = "Cannot connect to database.";
                else
                    sUpdateDCR = ex.Message.ToString();
                //throw new Exception(ex.Message);
            }

            return sUpdateDCR;
        }

        [WebMethod(Description = "Method to Update NotAvailableDoctorStatus")]
        public string UpdateDCRNotAvailableDoctorStatus(int nDoctorID, string sTerritoryID, int nDay, int nMonth, int nYear, int nStatus,
                             int nIsAvailable, int nNotAvailableReasonID, string sNotAvailableReason, string sSubmitDateTime, string sSubmittedBy)
        {

            DCR oDCR = new DCR();
            UserInfo oUserInfo = new UserInfo();
            AppConfigurationInfo oAppConfigInfo = new AppConfigurationInfo();
            BLDCR oBLDCR = new BLDCR();
            BLUserInfo oBLUserInfo = new BLUserInfo();
            BLEmployeeInfo oBLEmployeeInfo = new BLEmployeeInfo();
            BLAppConfigurationInfo oBLAppConfig = new BLAppConfigurationInfo();
            BLCommandInfo oBLCommandInfo = new BLCommandInfo();
            string sUpNotAvilableStatus = "";

            try
            {
                //string sconnectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string sconnectionString = oValues["ConnectionString2"].ToString();

                SqlConnection oConnection = new SqlConnection(sconnectionString);
                oConnection.Open();
                //Start transaction.
                SqlTransaction oTransaction = oConnection.BeginTransaction();
                //Assign command in the current transaction.
                SqlCommand oCommand = new SqlCommand();
                oCommand.Transaction = oTransaction;

                int nAction = 0;
                try
                {
                    oAppConfigInfo = oBLAppConfig.GetAppConfigurationInfo(sTerritoryID, sconnectionString);
                    int nDCREntryHours = oAppConfigInfo.DCREntryHours;
                    DateTime dDCRDate = new DateTime(nYear, nMonth, nDay);
                    dDCRDate = dDCRDate.AddHours(nDCREntryHours);
                    DateTime dCurrentDate = DateTime.Now;

                    bool bIsDCROpen = false;
                    if (dCurrentDate <= dDCRDate)
                        bIsDCROpen = true;
                    //if (!bIsDCROpen)
                    //{
                    //    nDCREntryHours = oBLCommandInfo.GetDCREntryHours(oConnection, oTransaction, sTerritoryID);
                    //    dDCRDate = new DateTime(nYear, nMonth, nDay);
                    //    dDCRDate = dDCRDate.AddHours(nDCREntryHours);
                    //    if (dCurrentDate <= dDCRDate)
                    //        bIsDCROpen = true;
                    //}

                    if (bIsDCROpen)
                    {
                        if (sSubmittedBy != "")
                        {
                            int nUserID = 0;
                            nUserID = oBLUserInfo.GetActiveUserIDBYGDDBID(oConnection, oTransaction, sSubmittedBy);

                            if (nUserID > 0)
                            {
                                //if (nIsAvailable == 0)
                                //{
                                //    nAction = 1;
                                //}
                                //else
                                //{
                                //    nAction = 2;
                                //}
                                nAction = 2;

                                //int nVersion = oBLDCR.GetDCRNewVersion(oConnection, oTransaction, sTerritoryID);
                                int nVersion = oBLDCR.GetDCRNewVersion(oConnection, oTransaction);

                                oBLDCR.UpdateDCRDoctotNotAvailableStatus(nDoctorID, sTerritoryID, nDay, nMonth, nYear, nStatus, nIsAvailable,
                                                               nNotAvailableReasonID, sNotAvailableReason, sSubmitDateTime, nUserID,
                                                               nAction, nVersion, oConnection, oTransaction);

                                string sRMGDDBID = oBLEmployeeInfo.GetGDDBIDByTerritoryID(oConnection, oTransaction, sTerritoryID.Substring(0, 6));

                                oUserInfo = new UserInfo();
                                oUserInfo = oBLUserInfo.GetUserInfo(sRMGDDBID, sconnectionString);
                                oUserInfo.Version = oUserInfo.Version + 1;
                                oUserInfo.DCRVersion = oUserInfo.DCRVersion + 1;
                                oUserInfo.LastUpdateDate = DateTime.Now;
                                oBLUserInfo.Save(oUserInfo, oConnection, oTransaction);

                                sUpNotAvilableStatus = "1";

                            }
                            // ……………………
                        }
                    }
                    else
                    {
                        sUpNotAvilableStatus = "-1";
                    }
                    oTransaction.Commit();
                }
                catch (Exception e)
                {
                    sUpNotAvilableStatus = e.Message.ToString();
                    oTransaction.Rollback();
                }
                finally
                {
                    oConnection.Close();
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                    sUpNotAvilableStatus = "Cannot connect to database.";
                else
                    sUpNotAvilableStatus = ex.Message.ToString();
                //throw new Exception(ex.Message);
            }

            return sUpNotAvilableStatus;
        }

        //[WebMethod(Description = "Send SMS DCRInfo")]
        //public int SendDCRUsingSMS()
        //{
        //    try
        //    {
        //        FileStream READER = null;
        //        string path = "";
        //        DCR oDCR = new DCR();
        //        BLDCR oBLDCR = new BLDCR();
        //        BLUserInfo oBLUserInfo = new BLUserInfo();
        //        //string sconnectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
        //        NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
        //        string sconnectionString = oValues["ConnectionString2"].ToString();

        //        SqlConnection oConnection = new SqlConnection(sconnectionString);
        //        oConnection.Open();
        //        //Start transaction.
        //        SqlTransaction oTransaction = oConnection.BeginTransaction();
        //        //Assign command in the current transaction.
        //        SqlCommand oCommand = new SqlCommand();
        //        oCommand.Transaction = oTransaction;
        //        int nUpdateDCR = 0;
        //        try
        //        {
        //            var files = Directory.GetFiles(@"D:\SMS\TestSMS\Inbox\", "*.xml");
        //            // var files = Directory.GetFiles(@"C:\TestSMS\Processed\", "*.xml");

        //            foreach (var f in files)
        //            {
        //                #region Read XmlFile
        //                path = f.ToString();// The Path to the .Xml file //

        //                READER = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite); //Set up the filestream (READER) //

        //                System.Xml.XmlDocument CompSpecs = new System.Xml.XmlDocument();// Set up the XmlDocument (CompSpecs) //

        //                CompSpecs.Load(READER); //Load the data from the file into the XmlDocument (CompSpecs) //

        //                System.Xml.XmlNodeList NodeList = CompSpecs.GetElementsByTagName("Message"); // Create a list of the nodes in the xml file //
        //                foreach (XmlNode node in NodeList)
        //                {
        //                    nUpdateDCR = 1;
        //                    string[] sRealSMS;
        //                    string[] sArray;
        //                    string[] sNewItem;
        //                    string[] sNewArray;
        //                    string sCustOrderTypeInfo = "";
        //                    string sOrderInfo = "";
        //                    int nOrderType = 0;
        //                    XmlElement companyElement = (XmlElement)node;

        //                    string sIE = companyElement.GetElementsByTagName("date")[0].InnerText;
        //                    string sFF = companyElement.GetElementsByTagName("originator")[0].InnerText;
        //                    string sGC = companyElement.GetElementsByTagName("messageBody")[0].InnerText;
        //                    string sMobNo = sFF.Remove(0, 3);
        //                    sRealSMS = sGC.Split(',');
        //                    int n = sRealSMS.Count();
        //                    string sFirstItem = sRealSMS.First().ToString();
        //                    string sLastItem = sRealSMS.Last().ToString();
        //                    bool b = sGC.Contains("|");
        //                    if (sFirstItem == "0" && sLastItem == "1")
        //                    {
        //                        sArray = sGC.Split('|');

        //                        sCustOrderTypeInfo = sArray[0].ToString();
        //                        sOrderInfo = sArray[1].ToString();

        //                        sNewArray = sCustOrderTypeInfo.Split(',');

        //                        string sCustID = sNewArray[2].ToString();
        //                        string SMSID = sNewArray[5].ToString();
        //                        string sOrderType = sNewArray[3].ToString();
        //                        string sOrderBy = sNewArray[4].ToString();
        //                        // oSFRegiInfo = new SFRegiInfo();
        //                        //oSFRegiInfo = oBLSFRegiInfo.GetSFInfoByGDDBID(sOrderBy);

        //                        #region SEND ORDER
        //                        //if (sSubmittedBy != "")
        //                        //{
        //                        //    int nUserID = 0;
        //                        //    nUserID = oBLUserInfo.GetActiveUserIDBYGDDBID(oConnection, oTransaction, sSubmittedBy);
        //                        //    if (nUserID > 0)
        //                        //    {
        //                        //        oDCR = oBLDCR.GetDCR(nDCRID, nDoctorID, sTerritoryID, nDay, nMonth, nYear, sconnectionString);

        //                        //        oDCR.DoctorID = nDoctorID;
        //                        //        oDCR.TerritoryID = sTerritoryID;
        //                        //        oDCR.Day = nDay;
        //                        //        oDCR.Month = nMonth;
        //                        //        oDCR.Year = nYear;
        //                        //        oDCR.Status = nStatus;
        //                        //        oDCR.VisitDateTime = Convert.ToDateTime(sVisitDateTime);
        //                        //        oDCR.IsVisited = Convert.ToBoolean(nIsVisited);
        //                        //        oDCR.IsAvailable = Convert.ToBoolean(nIsAvailable);
        //                        //        oDCR.IsAccompanyByRM_SF = Convert.ToBoolean(nIsAccompanyByRM_SF);
        //                        //        oDCR.ReminderNextCall = sReasonForNotCall;
        //                        //        oDCR.NotAvailableReasonID = nNotAvailableReasonID;
        //                        //        oDCR.NotAvailableReason = sNotAvailableReason;
        //                        //        oDCR.IsNewVisit = Convert.ToBoolean(nIsNewVisit);
        //                        //        oDCR.Session = sSession;

        //                        //        oDCR.SubmittedBy = nUserID;
        //                        //        oDCR.SubmitDateTime = Convert.ToDateTime(sSubmitDateTime);


        //                        //        oDCR.Action = 2;

        //                        //        oDCR.Version = oBLDCR.GetDCRNewVersion(oConnection, oTransaction);
        //                        //        if (sBrand1 != "")
        //                        //        {
        //                        //            GetBrandDetail(1, sBrand1, oDCR, oConnection, oTransaction);
        //                        //        }
        //                        //        if (sBrand2 != "")
        //                        //        {
        //                        //            GetBrandDetail(2, sBrand2, oDCR, oConnection, oTransaction);
        //                        //        }
        //                        //        if (sBrand3 != "")
        //                        //        {
        //                        //            GetBrandDetail(3, sBrand3, oDCR, oConnection, oTransaction);
        //                        //        }

        //                        //        if (sBrand4 != "")
        //                        //        {
        //                        //            GetBrandDetail(4, sBrand4, oDCR, oConnection, oTransaction);
        //                        //        }
        //                        //        if (sBrand5 != "")
        //                        //        {
        //                        //            GetBrandDetail(5, sBrand5, oDCR, oConnection, oTransaction);
        //                        //        }
        //                        //        if (sBrand6 != "")
        //                        //        {
        //                        //            GetBrandDetail(6, sBrand6, oDCR, oConnection, oTransaction);
        //                        //        }

        //                        //        nUpdateDCR = oBLDCR.Save(oDCR, oConnection, oTransaction);



        //                        //        // ……………………
        //                        //        oTransaction.Commit();
        //                        //    }
        //                        //}

        //                        READER.Close();
        //                        READER = null;
        //                        System.IO.File.Delete(path);
        //                        #endregion
        //                    }
        //                }
        //                #endregion
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            oTransaction.Rollback();
        //        }
        //        finally
        //        {
        //            oConnection.Close();
        //        }

        //        return nUpdateDCR;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    //SFRegiInfo oSFRegiInfo = new SFRegiInfo();
        //    //BLSFRegiInfo oBLSFRegiInfo = new BLSFRegiInfo();
        //    //OrderInfo oOrderInfo = new OrderInfo();
        //    //BLOrderInfo oBLOrderInfo = new BLOrderInfo();
        //    //OrderDetailInfo oOrderDetailInfo = new OrderDetailInfo();
        //    //Customers oCustomers = new Customers();
        //    //BLCustomers oBLCustomers = new BLCustomers();
        //    //ProductInfo oProductInfo = new ProductInfo();
        //    //BLProductInfo oBLProductInfo = new BLProductInfo();

        //    //double nTotalAmt;
        //    //string sOrderNo = "";
        //    //string sMsg = "";
        //    //FileStream READER = null;
        //    //string path = "";
        //    //try
        //    //{

        //    //    var files = Directory.GetFiles(@"D:\SMS\TestSMS\Inbox\", "*.xml");
        //    //    // var files = Directory.GetFiles(@"C:\TestSMS\Processed\", "*.xml");

        //    //    foreach (var f in files)
        //    //    {
        //    //        #region Read XmlFile
        //    //        path = f.ToString();// The Path to the .Xml file //

        //    //        READER = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite); //Set up the filestream (READER) //

        //    //        System.Xml.XmlDocument CompSpecs = new System.Xml.XmlDocument();// Set up the XmlDocument (CompSpecs) //

        //    //        CompSpecs.Load(READER); //Load the data from the file into the XmlDocument (CompSpecs) //

        //    //        System.Xml.XmlNodeList NodeList = CompSpecs.GetElementsByTagName("Message"); // Create a list of the nodes in the xml file //
        //    //        foreach (XmlNode node in NodeList)
        //    //        {
        //    //            string[] sRealSMS;
        //    //            string[] sArray;
        //    //            string[] sNewItem;
        //    //            string[] sNewArray;
        //    //            string sCustOrderTypeInfo = "";
        //    //            string sOrderInfo = "";
        //    //            int nOrderType = 0;
        //    //            XmlElement companyElement = (XmlElement)node;

        //    //            string sIE = companyElement.GetElementsByTagName("date")[0].InnerText;
        //    //            string sFF = companyElement.GetElementsByTagName("originator")[0].InnerText;
        //    //            string sGC = companyElement.GetElementsByTagName("messageBody")[0].InnerText;
        //    //            string sMobNo = sFF.Remove(0, 3);
        //    //            sRealSMS = sGC.Split(',');
        //    //            int n = sRealSMS.Count();
        //    //            string sFirstItem = sRealSMS.First().ToString();
        //    //            string sLastItem = sRealSMS.Last().ToString();
        //    //            bool b = sGC.Contains("|");
        //    //            if (sFirstItem == "0" && sLastItem == "1")
        //    //            {
        //    //                sArray = sGC.Split('|');

        //    //                sCustOrderTypeInfo = sArray[0].ToString();
        //    //                sOrderInfo = sArray[1].ToString();

        //    //                sNewArray = sCustOrderTypeInfo.Split(',');

        //    //                string sCustID = sNewArray[2].ToString();
        //    //                string SMSID = sNewArray[5].ToString();
        //    //                string sOrderType = sNewArray[3].ToString();
        //    //                string sOrderBy = sNewArray[4].ToString();
        //    //                oSFRegiInfo = new SFRegiInfo();
        //    //                oSFRegiInfo = oBLSFRegiInfo.GetSFInfoByGDDBID(sOrderBy);

        //    //                #region SEND ORDER
        //    //                if (oSFRegiInfo.IsActive == true)
        //    //                {
        //    //                    oOrderInfo = new OrderInfo();
        //    //                    nTotalAmt = 0;
        //    //                    //sArray = sGC.Split('|');

        //    //                    //sCustOrderTypeInfo = sArray[0].ToString();
        //    //                    //sOrderInfo = sArray[1].ToString();

        //    //                    //sNewArray = sCustOrderTypeInfo.Split(',');

        //    //                    //string sCustID = sNewArray[2].ToString();
        //    //                    //string SMSID = sNewArray[5].ToString();
        //    //                    //string sOrderType = sNewArray[3].ToString();
        //    //                    //string sOrderBy = sNewArray[4].ToString();
        //    //                    if (sOrderType == "C")
        //    //                    {
        //    //                        nOrderType = 1;
        //    //                    }
        //    //                    if (sOrderType == "K")
        //    //                    {
        //    //                        nOrderType = 2;
        //    //                    }


        //    //                    sNewItem = sOrderInfo.Split(';');
        //    //                    foreach (string sItemName in sNewItem)
        //    //                    {
        //    //                        sNewItem = sItemName.Split(',');
        //    //                        if (sNewItem.GetValue(0).ToString() != "")
        //    //                        {

        //    //                            string sPID = sNewItem.GetValue(0).ToString();
        //    //                            string sPQty = sNewItem.GetValue(1).ToString();
        //    //                            oProductInfo = oBLProductInfo.GetProductInfoByProductCode(sPID);
        //    //                            oOrderDetailInfo = new OrderDetailInfo();
        //    //                            oOrderDetailInfo.ProductID = oProductInfo.ID.ToInt32;
        //    //                            oOrderDetailInfo.Qty = Convert.ToInt32(sPQty);
        //    //                            oOrderDetailInfo.OrginalQty = Convert.ToInt32(sPQty);
        //    //                            oOrderDetailInfo.ModifiedQty = Convert.ToInt32(sPQty);
        //    //                            oOrderDetailInfo.Amt = (oProductInfo.TP + oProductInfo.Vat) * oOrderDetailInfo.Qty;
        //    //                            nTotalAmt += oOrderDetailInfo.Amt;
        //    //                            oOrderDetailInfo.EntryDate = DateTime.Now;
        //    //                            oOrderDetailInfo.LastModifiedDate = DateTime.Now;
        //    //                            oOrderInfo.TransactionDetail.Add(oOrderDetailInfo);

        //    //                        }
        //    //                    }

        //    //                    oCustomers = oBLCustomers.GetCustomersByCustCode(sCustID);


        //    //                    oOrderInfo.SMSOrderNo = SMSID;
        //    //                    oOrderInfo.OrderDate = DateTime.Now;
        //    //                    if (!oCustomers.IsNew)
        //    //                    {
        //    //                        oOrderInfo.CustomerID = oCustomers.ID.ToInt32;
        //    //                        oOrderInfo.IsInValidCustomer = false;
        //    //                        oOrderInfo.InvalidCustID = "";
        //    //                    }
        //    //                    else
        //    //                    {
        //    //                        oOrderInfo.CustomerID = null;
        //    //                        oOrderInfo.IsInValidCustomer = true;
        //    //                        oOrderInfo.InvalidCustID = sCustID;
        //    //                    }
        //    //                    oOrderInfo.TotalAmt = nTotalAmt;

        //    //                    if (nOrderType == 1)
        //    //                    {
        //    //                        oOrderInfo.OrderType = OrderType.Cash;
        //    //                    }
        //    //                    else
        //    //                    {
        //    //                        oOrderInfo.OrderType = OrderType.Credit;
        //    //                    }
        //    //                    oOrderInfo.OrderStatus = OrderStatus.NBL;
        //    //                    oOrderInfo.OrderSubmitDate = DateTime.Now;
        //    //                    oOrderInfo.ZPBLSubmitDate = Convert.ToDateTime("31 Dec 9999");
        //    //                    oOrderInfo.SentToInvoicingDate = Convert.ToDateTime("31 Dec 9999");
        //    //                    oOrderInfo.InvoicingDate = Convert.ToDateTime("31 Dec 9999");
        //    //                    oOrderInfo.ZPBLSubmitDate = Convert.ToDateTime("31 Dec 9999");
        //    //                    oOrderInfo.OrderBy = oSFRegiInfo.GDDBID;
        //    //                    oOrderInfo.IsSendSMS = true;
        //    //                    oOrderInfo.EntryDate = DateTime.Now;
        //    //                    oOrderInfo.LastModifiedDate = DateTime.Now;
        //    //                    oBLOrderInfo.SaveOrderInfo(oOrderInfo);
        //    //                    sOrderNo = oOrderInfo.OrderNo;
        //    //                    if (sOrderNo != "")
        //    //                    {
        //    //                        sMsg = "SMS Order Update";
        //    //                    }

        //    //                }
        //    //                else
        //    //                {
        //    //                    sMsg = "";
        //    //                }

        //    //                #endregion




        //    //            }
        //    //            READER.Close();
        //    //            READER = null;
        //    //            System.IO.File.Delete(path);
        //    //        }

        //    //        #endregion

        //    //    }


        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    READER.Close();
        //    //    READER = null;
        //    //    System.IO.File.Delete(path);
        //    //    throw new Exception(ex.Message + "; Detail message: " + ex.InnerException.Message + "; Source: " + ex.Source);

        //    //}
        //    //return sMsg;


        //}

        public void GetBrandDetail(int nDetailNo, string sBrand, DCR oDCR, string sTerritoryID, int nMonth, int nYear, SqlConnection oSqlConnection, SqlTransaction oSqlTransaction)
        {
            BLProduct oBLProduct = new BLProduct();
            BLGimmickInfo oBLGimmickInfo = new BLGimmickInfo();
            BLSampleInfo oBLSampleInfo = new BLSampleInfo();
            try
            {
                //sBrand = "B1=0;B1G1=2;B1G2=2;B1G3=2;B1S1=2;B1S2=2;B1S3=2;";
                string[] sNewItem;
                sNewItem = sBrand.Split(';');

                string sBrandInfo = sNewItem[0];
                string sGim1Info = sNewItem[1];
                string sGim2Info = sNewItem[2];
                string sGim3Info = sNewItem[3];
                string sSample1Info = sNewItem[4];
                string sSample2Info = sNewItem[5];
                string sSample3Info = sNewItem[6];

                string[] sBrandDetailInfo = sBrandInfo.Split('=');
                string[] sGim1DetailInfo = sGim1Info.Split('=');
                string[] sGim2DetailInfo = sGim2Info.Split('=');
                string[] sGim3DetailInfo = sGim3Info.Split('=');
                string[] sSample1DetailInfo = sSample1Info.Split('=');
                string[] sSample2DetailInfo = sSample2Info.Split('=');
                string[] sSample3DetailInfo = sSample3Info.Split('=');

                string sBrandName = "";
                string sGimmick1Name = "";
                string sGimmick2Name = "";
                string sGimmick3Name = "";
                string sSample1Name = "";
                string sSample2Name = "";
                string sSample3Name = "";


                int nBrandID = 0;
                int nGimmick1ID = 0;
                int nGimmick2ID = 0;
                int nGimmick3ID = 0;
                int nSample1ID = 0;
                int nSample2ID = 0;
                int nSample3ID = 0;
                int nGimmick1Qty = 0;
                int nGimmick2Qty = 0;
                int nGimmick3Qty = 0;
                int nSample1Qty = 0;
                int nSample2Qty = 0;
                int nSample3Qty = 0;

                if (!sBrandDetailInfo.GetValue(0).ToString().Equals("B" + "nDetailNo"))
                {

                    if (sBrandDetailInfo.GetValue(0).ToString() != "")
                    {

                        sBrandName = sBrandDetailInfo.GetValue(0).ToString();
                        nBrandID = oBLProduct.GetBrandID(oSqlConnection, oSqlTransaction, sBrandName, sTerritoryID);
                    }
                    if (!sGim1DetailInfo.GetValue(0).ToString().Trim().Equals("G1"))
                    {

                        sGimmick1Name = sGim1DetailInfo.GetValue(0).ToString();
                        nGimmick1Qty = Convert.ToInt32(sGim1DetailInfo.GetValue(1).ToString());
                        nGimmick1ID = oBLGimmickInfo.GetGimmickID(oSqlConnection, oSqlTransaction, sGimmick1Name, sTerritoryID, sBrandName, nMonth, nYear);
                    }
                    if (!sGim2DetailInfo.GetValue(0).ToString().Trim().Equals("G2"))
                    {
                        sGimmick2Name = sGim2DetailInfo.GetValue(0).ToString();
                        nGimmick2Qty = Convert.ToInt32(sGim2DetailInfo.GetValue(1).ToString());
                        nGimmick2ID = oBLGimmickInfo.GetGimmickID(oSqlConnection, oSqlTransaction, sGimmick1Name, sTerritoryID, sBrandName, nMonth, nYear);
                    }
                    if (!sGim3DetailInfo.GetValue(0).ToString().Trim().Equals("G3"))
                    {
                        sGimmick3Name = sGim3DetailInfo.GetValue(0).ToString();
                        nGimmick3Qty = Convert.ToInt32(sGim3DetailInfo.GetValue(1).ToString());
                        nGimmick3ID = oBLGimmickInfo.GetGimmickID(oSqlConnection, oSqlTransaction, sGimmick1Name, sTerritoryID, sBrandName, nMonth, nYear);
                    }
                    if (!sSample1DetailInfo.GetValue(0).ToString().Trim().Equals("S1"))
                    {
                        sSample1Name = sSample1DetailInfo.GetValue(0).ToString();
                        nSample1Qty = Convert.ToInt32(sSample1DetailInfo.GetValue(1).ToString());
                        nSample1ID = oBLSampleInfo.GetSampleID(oSqlConnection, oSqlTransaction, sSample1Name, sTerritoryID, sBrandName, nMonth, nYear);
                    }
                    if (!sSample2DetailInfo.GetValue(0).ToString().Trim().Equals("S2"))
                    {
                        sSample2Name = sSample2DetailInfo.GetValue(0).ToString();
                        nSample2Qty = Convert.ToInt32(sSample2DetailInfo.GetValue(1).ToString());
                        nSample2ID = oBLSampleInfo.GetSampleID(oSqlConnection, oSqlTransaction, sSample1Name, sTerritoryID, sBrandName, nMonth, nYear);
                    }
                    if (!sSample3DetailInfo.GetValue(0).ToString().Trim().Equals("S3"))
                    {
                        sSample3Name = sSample3DetailInfo.GetValue(0).ToString();
                        nSample3Qty = Convert.ToInt32(sSample3DetailInfo.GetValue(1).ToString());
                        nSample3ID = oBLSampleInfo.GetSampleID(oSqlConnection, oSqlTransaction, sSample1Name, sTerritoryID, sBrandName, nMonth, nYear);
                    }
                }


                if (nDetailNo == 1)
                {
                    if (nBrandID != 0)
                    {
                        oDCR.Brand1 = nBrandID;
                    }

                    if (nGimmick1ID != 0)
                    {
                        oDCR.Brand1Gimmick1 = nGimmick1ID;
                    }
                    if (nGimmick2ID != 0)
                    {
                        oDCR.Brand1Gimmick2 = nGimmick2ID;
                    }
                    if (nGimmick3ID != 0)
                    {
                        oDCR.Brand1Gimmick3 = nGimmick3ID;
                    }
                    if (nSample1ID != 0)
                    {
                        oDCR.Brand1Sample1 = nSample1ID;
                    }
                    if (nSample2ID != 0)
                    {
                        oDCR.Brand1Sample2 = nSample2ID;
                    }
                    if (nSample3ID != 0)
                    {
                        oDCR.Brand1Sample3 = nSample3ID;
                    }
                    if (nGimmick1ID != 0 && nGimmick1Qty != 0)
                    {
                        oDCR.Brand1Gimmick1Qty = nGimmick1Qty;
                    }
                    if (nGimmick2ID != 0 && nGimmick2Qty != 0)
                    {
                        oDCR.Brand1Gimmick2Qty = nGimmick2Qty;
                    }
                    if (nGimmick3ID != 0 && nGimmick3Qty != 0)
                    {
                        oDCR.Brand1Gimmick3Qty = nGimmick3Qty;
                    }
                    if (nSample1ID != 0 && nSample1Qty != 0)
                    {
                        oDCR.Brand1Sample1Qty = nSample1Qty;
                    }
                    if (nSample2ID != 0 && nSample2Qty != 0)
                    {
                        oDCR.Brand1Sample2Qty = nSample2Qty;
                    }
                    if (nSample3ID != 0 && nSample3Qty != 0)
                    {
                        oDCR.Brand1Sample3Qty = nSample3Qty;
                    }


                }

                if (nDetailNo == 2)
                {
                    if (nBrandID != 0)
                    {
                        oDCR.Brand2 = nBrandID;
                    }

                    if (nGimmick1ID != 0)
                    {
                        oDCR.Brand2Gimmick1 = nGimmick1ID;
                    }
                    if (nGimmick2ID != 0)
                    {
                        oDCR.Brand2Gimmick2 = nGimmick2ID;
                    }
                    if (nGimmick3ID != 0)
                    {
                        oDCR.Brand2Gimmick3 = nGimmick3ID;
                    }
                    if (nSample1ID != 0)
                    {
                        oDCR.Brand2Sample1 = nSample1ID;
                    }
                    if (nSample2ID != 0)
                    {
                        oDCR.Brand2Sample2 = nSample2ID;
                    }
                    if (nSample3ID != 0)
                    {
                        oDCR.Brand2Sample3 = nSample3ID;
                    }
                    if (nGimmick1ID != 0 && nGimmick1Qty != 0)
                    {
                        oDCR.Brand2Gimmick1Qty = nGimmick1Qty;
                    }
                    if (nGimmick2ID != 0 && nGimmick2Qty != 0)
                    {
                        oDCR.Brand2Gimmick2Qty = nGimmick2Qty;
                    }
                    if (nGimmick3ID != 0 && nGimmick3Qty != 0)
                    {
                        oDCR.Brand2Gimmick3Qty = nGimmick3Qty;
                    }
                    if (nSample1ID != 0 && nSample1Qty != 0)
                    {
                        oDCR.Brand2Sample1Qty = nSample1Qty;
                    }
                    if (nSample2ID != 0 && nSample2Qty != 0)
                    {
                        oDCR.Brand2Sample2Qty = nSample2Qty;
                    }
                    if (nSample3ID != 0 && nSample3Qty != 0)
                    {
                        oDCR.Brand2Sample3Qty = nSample3Qty;
                    }

                }
                if (nDetailNo == 3)
                {
                    if (nBrandID != 0)
                    {
                        oDCR.Brand3 = nBrandID;
                    }

                    if (nGimmick1ID != 0)
                    {
                        oDCR.Brand3Gimmick1 = nGimmick1ID;
                    }
                    if (nGimmick2ID != 0)
                    {
                        oDCR.Brand3Gimmick2 = nGimmick2ID;
                    }
                    if (nGimmick3ID != 0)
                    {
                        oDCR.Brand3Gimmick3 = nGimmick3ID;
                    }
                    if (nSample1ID != 0)
                    {
                        oDCR.Brand3Sample1 = nSample1ID;
                    }
                    if (nSample2ID != 0)
                    {
                        oDCR.Brand3Sample2 = nSample2ID;
                    }
                    if (nSample3ID != 0)
                    {
                        oDCR.Brand3Sample3 = nSample3ID;
                    }
                    if (nGimmick1ID != 0 && nGimmick1Qty != 0)
                    {
                        oDCR.Brand3Gimmick1Qty = nGimmick1Qty;
                    }
                    if (nGimmick2ID != 0 && nGimmick2Qty != 0)
                    {
                        oDCR.Brand3Gimmick2Qty = nGimmick2Qty;
                    }
                    if (nGimmick3ID != 0 && nGimmick3Qty != 0)
                    {
                        oDCR.Brand3Gimmick3Qty = nGimmick3Qty;
                    }
                    if (nSample1ID != 0 && nSample1Qty != 0)
                    {
                        oDCR.Brand3Sample1Qty = nSample1Qty;
                    }
                    if (nSample2ID != 0 && nSample2Qty != 0)
                    {
                        oDCR.Brand3Sample2Qty = nSample2Qty;
                    }
                    if (nSample3ID != 0 && nSample3Qty != 0)
                    {
                        oDCR.Brand3Sample3Qty = nSample3Qty;
                    }
                }
                if (nDetailNo == 4)
                {
                    if (nBrandID != 0)
                    {
                        oDCR.Brand4 = nBrandID;
                    }

                    if (nGimmick1ID != 0)
                    {
                        oDCR.Brand4Gimmick1 = nGimmick1ID;
                    }
                    if (nGimmick2ID != 0)
                    {
                        oDCR.Brand4Gimmick2 = nGimmick2ID;
                    }
                    if (nGimmick3ID != 0)
                    {
                        oDCR.Brand4Gimmick3 = nGimmick3ID;
                    }
                    if (nSample1ID != 0)
                    {
                        oDCR.Brand4Sample1 = nSample1ID;
                    }
                    if (nSample2ID != 0)
                    {
                        oDCR.Brand4Sample2 = nSample2ID;
                    }
                    if (nSample3ID != 0)
                    {
                        oDCR.Brand4Sample3 = nSample3ID;
                    }
                    if (nGimmick1ID != 0 && nGimmick1Qty != 0)
                    {
                        oDCR.Brand4Gimmick1Qty = nGimmick1Qty;
                    }
                    if (nGimmick2ID != 0 && nGimmick2Qty != 0)
                    {
                        oDCR.Brand4Gimmick2Qty = nGimmick2Qty;
                    }
                    if (nGimmick3ID != 0 && nGimmick3Qty != 0)
                    {
                        oDCR.Brand4Gimmick3Qty = nGimmick3Qty;
                    }
                    if (nSample1ID != 0 && nSample1Qty != 0)
                    {
                        oDCR.Brand4Sample1Qty = nSample1Qty;
                    }
                    if (nSample2ID != 0 && nSample2Qty != 0)
                    {
                        oDCR.Brand4Sample2Qty = nSample2Qty;
                    }
                    if (nSample3ID != 0 && nSample3Qty != 0)
                    {
                        oDCR.Brand4Sample3Qty = nSample3Qty;
                    }
                }
                if (nDetailNo == 5)
                {
                    if (nBrandID != 0)
                    {
                        oDCR.Brand5 = nBrandID;
                    }

                    if (nGimmick1ID != 0)
                    {
                        oDCR.Brand5Gimmick1 = nGimmick1ID;
                    }
                    if (nGimmick2ID != 0)
                    {
                        oDCR.Brand5Gimmick2 = nGimmick2ID;
                    }
                    if (nGimmick3ID != 0)
                    {
                        oDCR.Brand5Gimmick3 = nGimmick3ID;
                    }
                    if (nSample1ID != 0)
                    {
                        oDCR.Brand5Sample1 = nSample1ID;
                    }
                    if (nSample2ID != 0)
                    {
                        oDCR.Brand5Sample2 = nSample2ID;
                    }
                    if (nSample3ID != 0)
                    {
                        oDCR.Brand5Sample3 = nSample3ID;
                    }
                    if (nGimmick1ID != 0 && nGimmick1Qty != 0)
                    {
                        oDCR.Brand5Gimmick1Qty = nGimmick1Qty;
                    }
                    if (nGimmick2ID != 0 && nGimmick2Qty != 0)
                    {
                        oDCR.Brand5Gimmick2Qty = nGimmick2Qty;
                    }
                    if (nGimmick3ID != 0 && nGimmick3Qty != 0)
                    {
                        oDCR.Brand5Gimmick3Qty = nGimmick3Qty;
                    }
                    if (nSample1ID != 0 && nSample1Qty != 0)
                    {
                        oDCR.Brand5Sample1Qty = nSample1Qty;
                    }
                    if (nSample2ID != 0 && nSample2Qty != 0)
                    {
                        oDCR.Brand5Sample2Qty = nSample2Qty;
                    }
                    if (nSample3ID != 0 && nSample3Qty != 0)
                    {
                        oDCR.Brand5Sample3Qty = nSample3Qty;
                    }
                }
                if (nDetailNo == 6)
                {
                    if (nBrandID != 0)
                    {
                        oDCR.Brand6 = nBrandID;
                    }

                    if (nGimmick1ID != 0)
                    {
                        oDCR.Brand6Gimmick1 = nGimmick1ID;
                    }
                    if (nGimmick2ID != 0)
                    {
                        oDCR.Brand6Gimmick2 = nGimmick2ID;
                    }
                    if (nGimmick3ID != 0)
                    {
                        oDCR.Brand6Gimmick3 = nGimmick3ID;
                    }
                    if (nSample1ID != 0)
                    {
                        oDCR.Brand6Sample1 = nSample1ID;
                    }
                    if (nSample2ID != 0)
                    {
                        oDCR.Brand6Sample2 = nSample2ID;
                    }
                    if (nSample3ID != 0)
                    {
                        oDCR.Brand6Sample3 = nSample3ID;
                    }
                    if (nGimmick1ID != 0 && nGimmick1Qty != 0)
                    {
                        oDCR.Brand6Gimmick1Qty = nGimmick1Qty;
                    }
                    if (nGimmick2ID != 0 && nGimmick2Qty != 0)
                    {
                        oDCR.Brand6Gimmick2Qty = nGimmick2Qty;
                    }
                    if (nGimmick3ID != 0 && nGimmick3Qty != 0)
                    {
                        oDCR.Brand6Gimmick3Qty = nGimmick3Qty;
                    }
                    if (nSample1ID != 0 && nSample1Qty != 0)
                    {
                        oDCR.Brand6Sample1Qty = nSample1Qty;
                    }
                    if (nSample2ID != 0 && nSample2Qty != 0)
                    {
                        oDCR.Brand6Sample2Qty = nSample2Qty;
                    }
                    if (nSample3ID != 0 && nSample3Qty != 0)
                    {
                        oDCR.Brand6Sample3Qty = nSample3Qty;
                    }
                }
                if (nDetailNo == 7)
                {
                    if (nBrandID != 0)
                    {
                        oDCR.Brand7 = nBrandID;
                    }

                    if (nGimmick1ID != 0)
                    {
                        oDCR.Brand7Gimmick1 = nGimmick1ID;
                    }
                    if (nGimmick2ID != 0)
                    {
                        oDCR.Brand7Gimmick2 = nGimmick2ID;
                    }
                    if (nGimmick3ID != 0)
                    {
                        oDCR.Brand7Gimmick3 = nGimmick3ID;
                    }
                    if (nSample1ID != 0)
                    {
                        oDCR.Brand7Sample1 = nSample1ID;
                    }
                    if (nSample2ID != 0)
                    {
                        oDCR.Brand7Sample2 = nSample2ID;
                    }
                    if (nSample3ID != 0)
                    {
                        oDCR.Brand7Sample3 = nSample3ID;
                    }
                    if (nGimmick1ID != 0 && nGimmick1Qty != 0)
                    {
                        oDCR.Brand7Gimmick1Qty = nGimmick1Qty;
                    }
                    if (nGimmick2ID != 0 && nGimmick2Qty != 0)
                    {
                        oDCR.Brand7Gimmick2Qty = nGimmick2Qty;
                    }
                    if (nGimmick3ID != 0 && nGimmick3Qty != 0)
                    {
                        oDCR.Brand7Gimmick3Qty = nGimmick3Qty;
                    }
                    if (nSample1ID != 0 && nSample1Qty != 0)
                    {
                        oDCR.Brand7Sample1Qty = nSample1Qty;
                    }
                    if (nSample2ID != 0 && nSample2Qty != 0)
                    {
                        oDCR.Brand7Sample2Qty = nSample2Qty;
                    }
                    if (nSample3ID != 0 && nSample3Qty != 0)
                    {
                        oDCR.Brand7Sample3Qty = nSample3Qty;
                    }
                }
                if (nDetailNo == 8)
                {
                    if (nBrandID != 0)
                    {
                        oDCR.Brand8 = nBrandID;
                    }

                    if (nGimmick1ID != 0)
                    {
                        oDCR.Brand8Gimmick1 = nGimmick1ID;
                    }
                    if (nGimmick2ID != 0)
                    {
                        oDCR.Brand8Gimmick2 = nGimmick2ID;
                    }
                    if (nGimmick3ID != 0)
                    {
                        oDCR.Brand8Gimmick3 = nGimmick3ID;
                    }
                    if (nSample1ID != 0)
                    {
                        oDCR.Brand8Sample1 = nSample1ID;
                    }
                    if (nSample2ID != 0)
                    {
                        oDCR.Brand8Sample2 = nSample2ID;
                    }
                    if (nSample3ID != 0)
                    {
                        oDCR.Brand8Sample3 = nSample3ID;
                    }
                    if (nGimmick1ID != 0 && nGimmick1Qty != 0)
                    {
                        oDCR.Brand8Gimmick1Qty = nGimmick1Qty;
                    }
                    if (nGimmick2ID != 0 && nGimmick2Qty != 0)
                    {
                        oDCR.Brand8Gimmick2Qty = nGimmick2Qty;
                    }
                    if (nGimmick3ID != 0 && nGimmick3Qty != 0)
                    {
                        oDCR.Brand8Gimmick3Qty = nGimmick3Qty;
                    }
                    if (nSample1ID != 0 && nSample1Qty != 0)
                    {
                        oDCR.Brand8Sample1Qty = nSample1Qty;
                    }
                    if (nSample2ID != 0 && nSample2Qty != 0)
                    {
                        oDCR.Brand8Sample2Qty = nSample2Qty;
                    }
                    if (nSample3ID != 0 && nSample3Qty != 0)
                    {
                        oDCR.Brand8Sample3Qty = nSample3Qty;
                    }
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        //[WebMethod(Description = "Method to Get DCRInfo")]
        //public DCRs GetDCRInfo(string sTerritoryID, int nMaxVersion)
        //{
        //    DCRs oDCRs = new DCRs();
        //    AppConfigurationInfo oAppConfigInfo = new AppConfigurationInfo();
        //    BLDCR oBL = new BLDCR();
        //    BLAppConfigurationInfo oBLAppConfig = new BLAppConfigurationInfo();

        //    try
        //    {
        //        //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
        //        NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
        //        string connectionString = oValues["ConnectionString2"].ToString();
        //        //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

        //        SqlConnection myConnection = new SqlConnection(connectionString);
        //        myConnection.Open();
        //        // Start transaction.
        //        SqlTransaction myTransaction = myConnection.BeginTransaction();
        //        // Assign command in the current transaction.
        //        SqlCommand myCommand = new SqlCommand();
        //        myCommand.Transaction = myTransaction;

        //        try
        //        {
        //            DateTime dCurrentDate = DateTime.Now;
        //            int nCurrentMonth = dCurrentDate.Month;
        //            int nCurrentYear = dCurrentDate.Year;
        //            //oAppConfigInfo = oBLAppConfig.GetAppConfigurationInfo();
        //            oAppConfigInfo = oBLAppConfig.GetAppConfigurationInfo(connectionString);
        //            int nDCREntryHours = oAppConfigInfo.DCREntryHours;
        //            int nPreviousDCREntryDay = nDCREntryHours / 24;
        //            DateTime dPreviousDate = DateTime.Now.AddMonths(-1);
        //            int nPreviousMonth = dPreviousDate.Month;
        //            int nPreviousYear = dPreviousDate.Year;
        //            //DateTime dNextDate = DateTime.Now.AddMonths(1);
        //            //int nNextMonth = dNextDate.Month;
        //            //int nNextYear = dNextDate.Year;
        //            int nPreviousMonthDay = DateTime.DaysInMonth(nPreviousYear, nPreviousMonth) - nPreviousDCREntryDay;
        //            //oDCRs = oBL.GetDCRInfo(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonth, nPreviousYear, nPreviousMonthDay, nMaxVersion);
        //            oDCRs = oBL.GetDCRs(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonth, nPreviousYear, nPreviousMonthDay, nMaxVersion, connectionString);
        //            myTransaction.Commit();  
        //        }                                  
        //        catch (Exception e)
        //        {
        //            myTransaction.Rollback();
        //        }
        //        finally
        //        {
        //            myConnection.Close();
        //        }
        //        return oDCRs;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        [WebMethod(Description = "Method to Get DCRInfo")]
        public List<DCRInfo> GetDCRInfo(string sTerritoryID, int nMaxVersion)
        {
            oDCRInfoList = new List<DCRInfo> { };
            DCRs oDCRs = new DCRs();
            AppConfigurationInfo oAppConfigInfo = new AppConfigurationInfo();
            BLDCR oBL = new BLDCR();
            BLAppConfigurationInfo oBLAppConfig = new BLAppConfigurationInfo();
            BLBrandTerritoryMapping oBLBrand = new BLBrandTerritoryMapping();
            BLGimmickTerritoryMapping oBLGimmick = new BLGimmickTerritoryMapping();
            BLSampleTerritoryMapping oBLSample = new BLSampleTerritoryMapping();
            DataTable oTable = new DataTable();
            DCRInfo oDCRInfo = new DCRInfo();
            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;
                try
                {


                    DateTime dCurrentDate = DateTime.Now;
                    int nCurrentMonth = dCurrentDate.Month;
                    int nCurrentYear = dCurrentDate.Year;
                    //oAppConfigInfo = oBLAppConfig.GetAppConfigurationInfo();
                    oAppConfigInfo = oBLAppConfig.GetAppConfigurationInfo(sTerritoryID, connectionString);
                    int nDCREntryHours = oAppConfigInfo.DCREntryHours;
                    int nPreviousDCREntryDay = nDCREntryHours / 24;
                    DateTime dPreviousDate = DateTime.Now.AddMonths(-1);
                    int nPreviousMonth = dPreviousDate.Month;
                    int nPreviousYear = dPreviousDate.Year;
                    //DateTime dNextDate = DateTime.Now.AddMonths(1);
                    //int nNextMonth = dNextDate.Month;
                    //int nNextYear = dNextDate.Year;
                    int nPreviousMonthDay = DateTime.DaysInMonth(nPreviousYear, nPreviousMonth) - nPreviousDCREntryDay;
                    //oDCRs = oBL.GetDCRInfo(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonth, nPreviousYear, nPreviousMonthDay, nMaxVersion);
                    //oDCRs = oBL.GetDCRs(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonth, nPreviousYear, nPreviousMonthDay, nMaxVersion, connectionString);
                    oTable = oBL.GetDCRInfo(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonth, nPreviousYear, nPreviousMonthDay, nMaxVersion, connectionString);

                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oDCRInfo = new DCRInfo();
                        oDCRInfo.nDcrID = Convert.ToInt32(oRow["DcrID"].ToString());
                        oDCRInfo.nPvpDetailID = oRow["PvpDetailID"].ToString() == "" ? 0 : Convert.ToInt32(oRow["PvpDetailID"].ToString());
                        oDCRInfo.nDoctorID = Convert.ToInt32(oRow["DoctorID"].ToString());
                        oDCRInfo.sTerritoryID = oRow["TerritoryID"].ToString().ToUpper();
                        oDCRInfo.nDay = Convert.ToInt32(oRow["Day"].ToString());
                        oDCRInfo.nMonth = Convert.ToInt32(oRow["Month"].ToString());
                        oDCRInfo.nYear = Convert.ToInt32(oRow["Year"].ToString());
                        oDCRInfo.nStatus = Convert.ToInt32(oRow["Status"].ToString());
                        oDCRInfo.sVisitDateTime = Convert.ToDateTime(oRow["VisitDateTime"].ToString()).ToString("dd MMM yyyy HH:mm:ss");
                        oDCRInfo.nIsVisited = Convert.ToInt32(oRow["IsVisited"].ToString());
                        oDCRInfo.nIsAvailable = Convert.ToInt32(oRow["IsAvailable"].ToString());
                        oDCRInfo.nIsAccompanyByRM_RM = Convert.ToInt32(oRow["IsAccompanyByRM_RM"].ToString());
                        oDCRInfo.nIsAccompanyByRM_SF = Convert.ToInt32(oRow["IsAccompanyByRM_SF"].ToString());
                        oDCRInfo.sReminderNextCall = oRow["ReminderNextCall"].ToString();
                        oDCRInfo.nNotAvailableReasonID = Convert.ToInt32(oRow["NotAvailableReasonID"].ToString());
                        oDCRInfo.sNotAvailableReason = oRow["NotAvailableReason"].ToString();
                        oDCRInfo.nIsNewVisit = Convert.ToInt32(oRow["IsNewVisit"].ToString());
                        oDCRInfo.sSession = oRow["Session"].ToString();

                        oDCRInfo.sBrand1 = oRow["Brand1"].ToString() == "" ? "" : oBLBrand.GetBrandName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand1"].ToString()));
                        oDCRInfo.sBrand1Gimmick1 = oRow["Brand1Gimmick1"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand1Gimmick1"].ToString()));
                        oDCRInfo.sBrand1Gimmick2 = oRow["Brand1Gimmick2"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand1Gimmick2"].ToString()));
                        oDCRInfo.sBrand1Gimmick3 = oRow["Brand1Gimmick3"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand1Gimmick3"].ToString()));
                        oDCRInfo.sBrand1Sample1 = oRow["Brand1Sample1"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand1Sample1"].ToString()));
                        oDCRInfo.sBrand1Sample2 = oRow["Brand1Sample2"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand1Sample2"].ToString()));
                        oDCRInfo.sBrand1Sample3 = oRow["Brand1Sample3"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand1Sample3"].ToString()));
                        oDCRInfo.nBrand1Gimmick1Qty = oRow["Brand1Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Gimmick1Qty"].ToString());
                        oDCRInfo.nBrand1Gimmick2Qty = oRow["Brand1Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Gimmick2Qty"].ToString());
                        oDCRInfo.nBrand1Gimmick3Qty = oRow["Brand1Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Gimmick3Qty"].ToString());
                        oDCRInfo.nBrand1Sample1Qty = oRow["Brand1Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Sample1Qty"].ToString());
                        oDCRInfo.nBrand1Sample2Qty = oRow["Brand1Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Sample2Qty"].ToString());
                        oDCRInfo.nBrand1Sample3Qty = oRow["Brand1Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Sample3Qty"].ToString());

                        oDCRInfo.sBrand2 = oRow["Brand2"].ToString() == "" ? "" : oBLBrand.GetBrandName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand2"].ToString()));
                        oDCRInfo.sBrand2Gimmick1 = oRow["Brand2Gimmick1"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand2Gimmick1"].ToString()));
                        oDCRInfo.sBrand2Gimmick2 = oRow["Brand2Gimmick2"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand2Gimmick2"].ToString()));
                        oDCRInfo.sBrand2Gimmick3 = oRow["Brand2Gimmick3"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand2Gimmick3"].ToString()));
                        oDCRInfo.sBrand2Sample1 = oRow["Brand2Sample1"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand2Sample1"].ToString()));
                        oDCRInfo.sBrand2Sample2 = oRow["Brand2Sample2"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand2Sample2"].ToString()));
                        oDCRInfo.sBrand2Sample3 = oRow["Brand2Sample3"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand2Sample3"].ToString()));
                        oDCRInfo.nBrand2Gimmick1Qty = oRow["Brand2Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Gimmick1Qty"].ToString());
                        oDCRInfo.nBrand2Gimmick2Qty = oRow["Brand2Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Gimmick2Qty"].ToString());
                        oDCRInfo.nBrand2Gimmick3Qty = oRow["Brand2Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Gimmick3Qty"].ToString());
                        oDCRInfo.nBrand2Sample1Qty = oRow["Brand2Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Sample1Qty"].ToString());
                        oDCRInfo.nBrand2Sample2Qty = oRow["Brand2Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Sample2Qty"].ToString());
                        oDCRInfo.nBrand2Sample3Qty = oRow["Brand2Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Sample3Qty"].ToString());

                        oDCRInfo.sBrand3 = oRow["Brand3"].ToString() == "" ? "" : oBLBrand.GetBrandName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand3"].ToString()));
                        oDCRInfo.sBrand3Gimmick1 = oRow["Brand3Gimmick1"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand3Gimmick1"].ToString()));
                        oDCRInfo.sBrand3Gimmick2 = oRow["Brand3Gimmick2"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand3Gimmick2"].ToString()));
                        oDCRInfo.sBrand3Gimmick3 = oRow["Brand3Gimmick3"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand3Gimmick3"].ToString()));
                        oDCRInfo.sBrand3Sample1 = oRow["Brand3Sample1"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand3Sample1"].ToString()));
                        oDCRInfo.sBrand3Sample2 = oRow["Brand3Sample2"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand3Sample2"].ToString()));
                        oDCRInfo.sBrand3Sample3 = oRow["Brand3Sample3"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand3Sample3"].ToString()));
                        oDCRInfo.nBrand3Gimmick1Qty = oRow["Brand3Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Gimmick1Qty"].ToString());
                        oDCRInfo.nBrand3Gimmick2Qty = oRow["Brand3Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Gimmick2Qty"].ToString());
                        oDCRInfo.nBrand3Gimmick3Qty = oRow["Brand3Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Gimmick3Qty"].ToString());
                        oDCRInfo.nBrand3Sample1Qty = oRow["Brand3Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Sample1Qty"].ToString());
                        oDCRInfo.nBrand3Sample2Qty = oRow["Brand3Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Sample2Qty"].ToString());
                        oDCRInfo.nBrand3Sample3Qty = oRow["Brand3Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Sample3Qty"].ToString());

                        oDCRInfo.sBrand4 = oRow["Brand4"].ToString() == "" ? "" : oBLBrand.GetBrandName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand4"].ToString()));
                        oDCRInfo.sBrand4Gimmick1 = oRow["Brand4Gimmick1"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand4Gimmick1"].ToString()));
                        oDCRInfo.sBrand4Gimmick2 = oRow["Brand4Gimmick2"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand4Gimmick2"].ToString()));
                        oDCRInfo.sBrand4Gimmick3 = oRow["Brand4Gimmick3"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand4Gimmick3"].ToString()));
                        oDCRInfo.sBrand4Sample1 = oRow["Brand4Sample1"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand4Sample1"].ToString()));
                        oDCRInfo.sBrand4Sample2 = oRow["Brand4Sample2"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand4Sample2"].ToString()));
                        oDCRInfo.sBrand4Sample3 = oRow["Brand4Sample3"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand4Sample3"].ToString()));
                        oDCRInfo.nBrand4Gimmick1Qty = oRow["Brand4Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Gimmick1Qty"].ToString());
                        oDCRInfo.nBrand4Gimmick2Qty = oRow["Brand4Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Gimmick2Qty"].ToString());
                        oDCRInfo.nBrand4Gimmick3Qty = oRow["Brand4Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Gimmick3Qty"].ToString());
                        oDCRInfo.nBrand4Sample1Qty = oRow["Brand4Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Sample1Qty"].ToString());
                        oDCRInfo.nBrand4Sample2Qty = oRow["Brand4Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Sample2Qty"].ToString());
                        oDCRInfo.nBrand4Sample3Qty = oRow["Brand4Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Sample3Qty"].ToString());

                        oDCRInfo.sBrand5 = oRow["Brand5"].ToString() == "" ? "" : oBLBrand.GetBrandName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand5"].ToString()));
                        oDCRInfo.sBrand5Gimmick1 = oRow["Brand5Gimmick1"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand5Gimmick1"].ToString()));
                        oDCRInfo.sBrand5Gimmick2 = oRow["Brand5Gimmick2"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand5Gimmick2"].ToString()));
                        oDCRInfo.sBrand5Gimmick3 = oRow["Brand5Gimmick3"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand5Gimmick3"].ToString()));
                        oDCRInfo.sBrand5Sample1 = oRow["Brand5Sample1"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand5Sample1"].ToString()));
                        oDCRInfo.sBrand5Sample2 = oRow["Brand5Sample2"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand5Sample2"].ToString()));
                        oDCRInfo.sBrand5Sample3 = oRow["Brand5Sample3"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand5Sample3"].ToString()));
                        oDCRInfo.nBrand5Gimmick1Qty = oRow["Brand5Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Gimmick1Qty"].ToString());
                        oDCRInfo.nBrand5Gimmick2Qty = oRow["Brand5Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Gimmick2Qty"].ToString());
                        oDCRInfo.nBrand5Gimmick3Qty = oRow["Brand5Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Gimmick3Qty"].ToString());
                        oDCRInfo.nBrand5Sample1Qty = oRow["Brand5Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Sample1Qty"].ToString());
                        oDCRInfo.nBrand5Sample2Qty = oRow["Brand5Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Sample2Qty"].ToString());
                        oDCRInfo.nBrand5Sample3Qty = oRow["Brand5Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Sample3Qty"].ToString());

                        oDCRInfo.sBrand6 = oRow["Brand6"].ToString() == "" ? "" : oBLBrand.GetBrandName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand6"].ToString()));
                        oDCRInfo.sBrand6Gimmick1 = oRow["Brand6Gimmick1"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand6Gimmick1"].ToString()));
                        oDCRInfo.sBrand6Gimmick2 = oRow["Brand6Gimmick2"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand6Gimmick2"].ToString()));
                        oDCRInfo.sBrand6Gimmick3 = oRow["Brand6Gimmick3"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand6Gimmick3"].ToString()));
                        oDCRInfo.sBrand6Sample1 = oRow["Brand6Sample1"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand6Sample1"].ToString()));
                        oDCRInfo.sBrand6Sample2 = oRow["Brand6Sample2"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand6Sample2"].ToString()));
                        oDCRInfo.sBrand6Sample3 = oRow["Brand6Sample3"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand6Sample3"].ToString()));
                        oDCRInfo.nBrand6Gimmick1Qty = oRow["Brand6Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Gimmick1Qty"].ToString());
                        oDCRInfo.nBrand6Gimmick2Qty = oRow["Brand6Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Gimmick2Qty"].ToString());
                        oDCRInfo.nBrand6Gimmick3Qty = oRow["Brand6Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Gimmick3Qty"].ToString());
                        oDCRInfo.nBrand6Sample1Qty = oRow["Brand6Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Sample1Qty"].ToString());
                        oDCRInfo.nBrand6Sample2Qty = oRow["Brand6Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Sample2Qty"].ToString());
                        oDCRInfo.nBrand6Sample3Qty = oRow["Brand6Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Sample3Qty"].ToString());

                        oDCRInfo.sBrand7 = oRow["Brand7"].ToString() == "" ? "" : oBLBrand.GetBrandName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand7"].ToString()));
                        oDCRInfo.sBrand7Gimmick1 = oRow["Brand7Gimmick1"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand7Gimmick1"].ToString()));
                        oDCRInfo.sBrand7Gimmick2 = oRow["Brand7Gimmick2"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand7Gimmick2"].ToString()));
                        oDCRInfo.sBrand7Gimmick3 = oRow["Brand7Gimmick3"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand7Gimmick3"].ToString()));
                        oDCRInfo.sBrand7Sample1 = oRow["Brand7Sample1"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand7Sample1"].ToString()));
                        oDCRInfo.sBrand7Sample2 = oRow["Brand7Sample2"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand7Sample2"].ToString()));
                        oDCRInfo.sBrand7Sample3 = oRow["Brand7Sample3"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand7Sample3"].ToString()));
                        oDCRInfo.nBrand7Gimmick1Qty = oRow["Brand7Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand7Gimmick1Qty"].ToString());
                        oDCRInfo.nBrand7Gimmick2Qty = oRow["Brand7Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand7Gimmick2Qty"].ToString());
                        oDCRInfo.nBrand7Gimmick3Qty = oRow["Brand7Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand7Gimmick3Qty"].ToString());
                        oDCRInfo.nBrand7Sample1Qty = oRow["Brand7Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand7Sample1Qty"].ToString());
                        oDCRInfo.nBrand7Sample2Qty = oRow["Brand7Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand7Sample2Qty"].ToString());
                        oDCRInfo.nBrand7Sample3Qty = oRow["Brand7Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand7Sample3Qty"].ToString());

                        oDCRInfo.sBrand8 = oRow["Brand8"].ToString() == "" ? "" : oBLBrand.GetBrandName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand8"].ToString()));
                        oDCRInfo.sBrand8Gimmick1 = oRow["Brand8Gimmick1"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand8Gimmick1"].ToString()));
                        oDCRInfo.sBrand8Gimmick2 = oRow["Brand8Gimmick2"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand8Gimmick2"].ToString()));
                        oDCRInfo.sBrand8Gimmick3 = oRow["Brand8Gimmick3"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand8Gimmick3"].ToString()));
                        oDCRInfo.sBrand8Sample1 = oRow["Brand8Sample1"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand8Sample1"].ToString()));
                        oDCRInfo.sBrand8Sample2 = oRow["Brand8Sample2"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand8Sample2"].ToString()));
                        oDCRInfo.sBrand8Sample3 = oRow["Brand8Sample3"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand8Sample3"].ToString()));
                        oDCRInfo.nBrand8Gimmick1Qty = oRow["Brand8Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand8Gimmick1Qty"].ToString());
                        oDCRInfo.nBrand8Gimmick2Qty = oRow["Brand8Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand8Gimmick2Qty"].ToString());
                        oDCRInfo.nBrand8Gimmick3Qty = oRow["Brand8Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand8Gimmick3Qty"].ToString());
                        oDCRInfo.nBrand8Sample1Qty = oRow["Brand8Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand8Sample1Qty"].ToString());
                        oDCRInfo.nBrand8Sample2Qty = oRow["Brand8Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand8Sample2Qty"].ToString());
                        oDCRInfo.nBrand8Sample3Qty = oRow["Brand8Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand8Sample3Qty"].ToString());
                        
                        //oDCRInfo.nBrand1 = oRow["Brand1"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1"].ToString());
                        //oDCRInfo.nBrand1Gimmick1 = oRow["Brand1Gimmick1"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Gimmick1"].ToString());
                        //oDCRInfo.nBrand1Gimmick2 = oRow["Brand1Gimmick2"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Gimmick2"].ToString());
                        //oDCRInfo.nBrand1Gimmick3 = oRow["Brand1Gimmick3"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Gimmick3"].ToString());
                        //oDCRInfo.nBrand1Sample1 = oRow["Brand1Sample1"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Sample1"].ToString());
                        //oDCRInfo.nBrand1Sample2 = oRow["Brand1Sample2"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Sample2"].ToString());
                        //oDCRInfo.nBrand1Sample3 = oRow["Brand1Sample3"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Sample3"].ToString());
                        //oDCRInfo.nBrand1Gimmick1Qty = oRow["Brand1Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Gimmick1Qty"].ToString());
                        //oDCRInfo.nBrand1Gimmick2Qty = oRow["Brand1Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Gimmick2Qty"].ToString());
                        //oDCRInfo.nBrand1Gimmick3Qty = oRow["Brand1Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Gimmick3Qty"].ToString());
                        //oDCRInfo.nBrand1Sample1Qty = oRow["Brand1Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Sample1Qty"].ToString());
                        //oDCRInfo.nBrand1Sample2Qty = oRow["Brand1Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Sample2Qty"].ToString());
                        //oDCRInfo.nBrand1Sample3Qty = oRow["Brand1Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Sample3Qty"].ToString());

                        //oDCRInfo.nBrand2 = oRow["Brand2"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2"].ToString());
                        //oDCRInfo.nBrand2Gimmick1 = oRow["Brand2Gimmick1"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Gimmick1"].ToString());
                        //oDCRInfo.nBrand2Gimmick2 = oRow["Brand2Gimmick2"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Gimmick2"].ToString());
                        //oDCRInfo.nBrand2Gimmick3 = oRow["Brand2Gimmick3"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Gimmick3"].ToString());
                        //oDCRInfo.nBrand2Sample1 = oRow["Brand2Sample1"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Sample1"].ToString());
                        //oDCRInfo.nBrand2Sample2 = oRow["Brand2Sample2"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Sample2"].ToString());
                        //oDCRInfo.nBrand2Sample3 = oRow["Brand2Sample3"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Sample3"].ToString());
                        //oDCRInfo.nBrand2Gimmick1Qty = oRow["Brand2Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Gimmick1Qty"].ToString());
                        //oDCRInfo.nBrand2Gimmick2Qty = oRow["Brand2Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Gimmick2Qty"].ToString());
                        //oDCRInfo.nBrand2Gimmick3Qty = oRow["Brand2Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Gimmick3Qty"].ToString());
                        //oDCRInfo.nBrand2Sample1Qty = oRow["Brand2Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Sample1Qty"].ToString());
                        //oDCRInfo.nBrand2Sample2Qty = oRow["Brand2Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Sample2Qty"].ToString());
                        //oDCRInfo.nBrand2Sample3Qty = oRow["Brand2Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Sample3Qty"].ToString());

                        //oDCRInfo.nBrand3 = oRow["Brand3"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3"].ToString());
                        //oDCRInfo.nBrand3Gimmick1 = oRow["Brand3Gimmick1"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Gimmick1"].ToString());
                        //oDCRInfo.nBrand3Gimmick2 = oRow["Brand3Gimmick2"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Gimmick2"].ToString());
                        //oDCRInfo.nBrand3Gimmick3 = oRow["Brand3Gimmick3"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Gimmick3"].ToString());
                        //oDCRInfo.nBrand3Sample1 = oRow["Brand3Sample1"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Sample1"].ToString());
                        //oDCRInfo.nBrand3Sample2 = oRow["Brand3Sample2"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Sample2"].ToString());
                        //oDCRInfo.nBrand3Sample3 = oRow["Brand3Sample3"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Sample3"].ToString());
                        //oDCRInfo.nBrand3Gimmick1Qty = oRow["Brand3Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Gimmick1Qty"].ToString());
                        //oDCRInfo.nBrand3Gimmick2Qty = oRow["Brand3Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Gimmick2Qty"].ToString());
                        //oDCRInfo.nBrand3Gimmick3Qty = oRow["Brand3Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Gimmick3Qty"].ToString());
                        //oDCRInfo.nBrand3Sample1Qty = oRow["Brand3Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Sample1Qty"].ToString());
                        //oDCRInfo.nBrand3Sample2Qty = oRow["Brand3Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Sample2Qty"].ToString());
                        //oDCRInfo.nBrand3Sample3Qty = oRow["Brand3Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Sample3Qty"].ToString());

                        //oDCRInfo.nBrand4 = oRow["Brand4"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4"].ToString());
                        //oDCRInfo.nBrand4Gimmick1 = oRow["Brand4Gimmick1"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Gimmick1"].ToString());
                        //oDCRInfo.nBrand4Gimmick2 = oRow["Brand4Gimmick2"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Gimmick2"].ToString());
                        //oDCRInfo.nBrand4Gimmick3 = oRow["Brand4Gimmick3"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Gimmick3"].ToString());
                        //oDCRInfo.nBrand4Sample1 = oRow["Brand4Sample1"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Sample1"].ToString());
                        //oDCRInfo.nBrand4Sample2 = oRow["Brand4Sample2"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Sample2"].ToString());
                        //oDCRInfo.nBrand4Sample3 = oRow["Brand4Sample3"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Sample3"].ToString());
                        //oDCRInfo.nBrand4Gimmick1Qty = oRow["Brand4Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Gimmick1Qty"].ToString());
                        //oDCRInfo.nBrand4Gimmick2Qty = oRow["Brand4Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Gimmick2Qty"].ToString());
                        //oDCRInfo.nBrand4Gimmick3Qty = oRow["Brand4Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Gimmick3Qty"].ToString());
                        //oDCRInfo.nBrand4Sample1Qty = oRow["Brand4Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Sample1Qty"].ToString());
                        //oDCRInfo.nBrand4Sample2Qty = oRow["Brand4Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Sample2Qty"].ToString());
                        //oDCRInfo.nBrand4Sample3Qty = oRow["Brand4Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Sample3Qty"].ToString());

                        //oDCRInfo.nBrand5 = oRow["Brand5"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5"].ToString());
                        //oDCRInfo.nBrand5Gimmick1 = oRow["Brand5Gimmick1"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Gimmick1"].ToString());
                        //oDCRInfo.nBrand5Gimmick2 = oRow["Brand5Gimmick2"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Gimmick2"].ToString());
                        //oDCRInfo.nBrand5Gimmick3 = oRow["Brand5Gimmick3"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Gimmick3"].ToString());
                        //oDCRInfo.nBrand5Sample1 = oRow["Brand5Sample1"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Sample1"].ToString());
                        //oDCRInfo.nBrand5Sample2 = oRow["Brand5Sample2"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Sample2"].ToString());
                        //oDCRInfo.nBrand5Sample3 = oRow["Brand5Sample3"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Sample3"].ToString());
                        //oDCRInfo.nBrand5Gimmick1Qty = oRow["Brand5Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Gimmick1Qty"].ToString());
                        //oDCRInfo.nBrand5Gimmick2Qty = oRow["Brand5Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Gimmick2Qty"].ToString());
                        //oDCRInfo.nBrand5Gimmick3Qty = oRow["Brand5Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Gimmick3Qty"].ToString());
                        //oDCRInfo.nBrand5Sample1Qty = oRow["Brand5Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Sample1Qty"].ToString());
                        //oDCRInfo.nBrand5Sample2Qty = oRow["Brand5Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Sample2Qty"].ToString());
                        //oDCRInfo.nBrand5Sample3Qty = oRow["Brand5Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Sample3Qty"].ToString());

                        //oDCRInfo.nBrand6 = oRow["Brand6"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6"].ToString());
                        //oDCRInfo.nBrand6Gimmick1 = oRow["Brand6Gimmick1"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Gimmick1"].ToString());
                        //oDCRInfo.nBrand6Gimmick2 = oRow["Brand6Gimmick2"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Gimmick2"].ToString());
                        //oDCRInfo.nBrand6Gimmick3 = oRow["Brand6Gimmick3"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Gimmick3"].ToString());
                        //oDCRInfo.nBrand6Sample1 = oRow["Brand6Sample1"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Sample1"].ToString());
                        //oDCRInfo.nBrand6Sample2 = oRow["Brand6Sample2"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Sample2"].ToString());
                        //oDCRInfo.nBrand6Sample3 = oRow["Brand6Sample3"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Sample3"].ToString());
                        //oDCRInfo.nBrand6Gimmick1Qty = oRow["Brand6Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Gimmick1Qty"].ToString());
                        //oDCRInfo.nBrand6Gimmick2Qty = oRow["Brand6Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Gimmick2Qty"].ToString());
                        //oDCRInfo.nBrand6Gimmick3Qty = oRow["Brand6Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Gimmick3Qty"].ToString());
                        //oDCRInfo.nBrand6Sample1Qty = oRow["Brand6Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Sample1Qty"].ToString());
                        //oDCRInfo.nBrand6Sample2Qty = oRow["Brand6Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Sample2Qty"].ToString());
                        //oDCRInfo.nBrand6Sample3Qty = oRow["Brand6Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Sample3Qty"].ToString());
                        
                        oDCRInfo.sSubmitDateTime = Convert.ToDateTime(oRow["SubmitDateTime"].ToString()).ToString("dd MMM yyyy HH:mm:ss");
                        oDCRInfo.sApprovedDateTime = Convert.ToDateTime(oRow["ApprovedDateTime"].ToString()).ToString("dd MMM yyyy HH:mm:ss");
                        oDCRInfo.nSubmittedBy = Convert.ToInt32(oRow["SubmittedBy"].ToString());
                        oDCRInfo.nApprovedBy = Convert.ToInt32(oRow["ApprovedBy"].ToString());
                        oDCRInfo.nAction = Convert.ToInt32(oRow["Action"].ToString());
                        oDCRInfo.nVersion = Convert.ToInt32(oRow["Version"].ToString());
                        oDCRInfo.sSMSDCRNo = oRow["SMSDCRNo"].ToString();
                        oDCRInfo.nIsSendSMS = Convert.ToInt32(oRow["IsSendSMS"].ToString());
                        oDCRInfo.sRejectReason = oRow["RejectReason"].ToString();

                        oDCRInfoList.Add(oDCRInfo);
                    }

                    myTransaction.Commit();
                }

                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
                return oDCRInfoList;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Get DoctorDetailForRM")]
        public List<DoctorDetail> GetDoctorDetailForRM(string sTerritoryID, int nMaxVersion)
        {
            oDoctorDetailList = new List<DoctorDetail> { };
            DataTable oTable = new DataTable();
            BLDoctorTerritoryMapping oBL = new BLDoctorTerritoryMapping();
            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    oTable = oBL.GetDoctorDetailForRM(sTerritoryID, nMaxVersion, connectionString);
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        DoctorDetail oDoctorDetail = new DoctorDetail();
                        oDoctorDetail.sTerritoryID = oRow["TerritoryID"].ToString().ToUpper();
                        oDoctorDetail.nDoctorID = Convert.ToInt32(oRow["ID"].ToString());
                        oDoctorDetail.sDoctorName = txtInfo.ToTitleCase(oRow["DocName"].ToString());
                        oDoctorDetail.sBMDCCode = oRow["BMDCCode"].ToString();
                        oDoctorDetail.sSalutation = oRow["SalDesc"].ToString();
                        oDoctorDetail.sSpecialty1 = oRow["spName1"].ToString();
                        oDoctorDetail.sSpecialty2 = oRow["spName2"].ToString();
                        oDoctorDetail.sDegree1 = oRow["degName1"].ToString();
                        oDoctorDetail.sDegree2 = oRow["degName2"].ToString();
                        oDoctorDetail.sInstitute = txtInfo.ToTitleCase(oRow["Institute"].ToString());
                        oDoctorDetail.sAddress1 = txtInfo.ToTitleCase(oRow["Address1"].ToString());
                        oDoctorDetail.sAddress2 = txtInfo.ToTitleCase(oRow["Address2"].ToString());
                        oDoctorDetail.sAddress3 = txtInfo.ToTitleCase(oRow["Address3"].ToString());
                        oDoctorDetail.sDistrict = oRow["DistName"].ToString();
                        oDoctorDetail.sUpazilla = oRow["UName"].ToString();
                        oDoctorDetail.sBirthDay = Convert.ToDateTime(oRow["BirthDay"].ToString()).ToString("dd MMM yyyy");
                        oDoctorDetail.sMarriageday = Convert.ToDateTime(oRow["Mrgday"].ToString()).ToString("dd MMM yyyy");
                        oDoctorDetail.sEmail = oRow["Email"].ToString();
                        oDoctorDetail.sMobileNo = oRow["MobileNo"].ToString();
                        oDoctorDetail.nDoctorType = Convert.ToInt32(oRow["DocTypeID"].ToString());
                        oDoctorDetail.nSwajanStatus = Convert.ToInt32(oRow["SwajanStatus"].ToString());
                        oDoctorDetail.sProfileCode = oRow["PCode"].ToString();
                        oDoctorDetail.sProfileName = oRow["PName"].ToString();
                        oDoctorDetail.sProduct1 = oRow["Product1"].ToString();
                        oDoctorDetail.sProduct2 = oRow["Product2"].ToString();
                        oDoctorDetail.sProduct3 = oRow["Product3"].ToString();
                        oDoctorDetail.sProduct4 = oRow["Product4"].ToString();
                        oDoctorDetail.sProduct5 = oRow["Product5"].ToString();
                        oDoctorDetail.sProduct6 = oRow["Product6"].ToString();
                        oDoctorDetail.sProduct7 = oRow["Product7"].ToString();
                        oDoctorDetail.sProduct8 = oRow["Product8"].ToString();
                        oDoctorDetail.nCallFreq = Convert.ToInt32(oRow["CallFre"].ToString());
                        oDoctorDetail.sRoute = txtInfo.ToTitleCase(oRow["RName"].ToString().Trim());
                        oDoctorDetail.sSession = oRow["SessName"].ToString();
                        oDoctorDetail.nStatus = Convert.ToInt32(oRow["Status"].ToString());
                        oDoctorDetail.nAddressNo = Convert.ToInt32(oRow["Address"].ToString());
                        oDoctorDetail.nSpecialtyNo = Convert.ToInt32(oRow["Speciality"].ToString());
                        oDoctorDetail.nDegreeNo = Convert.ToInt32(oRow["Degree"].ToString());
                        oDoctorDetail.sCardAttachment = oRow["CardAttachement"].ToString();
                        oDoctorDetail.sCreateDate = Convert.ToDateTime(oRow["CreateDatetime"].ToString()).ToString("dd MMM yyyy HH:mm:ss");
                        oDoctorDetail.sLastUpdateDate = Convert.ToDateTime(oRow["ModifyDatetime"].ToString()).ToString("dd MMM yyyy HH:mm:ss");
                        oDoctorDetail.nVersion = Convert.ToInt32(oRow["Version"].ToString());
                        oDoctorDetail.nActionType = Convert.ToInt32(oRow["Action"].ToString());
                        oDoctorDetail.sPostStepChange = oRow["PostStpCngName"].ToString();

                        oDoctorDetailList.Add(oDoctorDetail);
                    }
                    myTransaction.Commit();
                }

                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
                return oDoctorDetailList;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Get RouteInfoForRM")]
        public List<RouteInfo> GetRouteInfoForRM(string sTerritoryID, int nMaxVersion)
        {
            oRouteInfoList = new List<RouteInfo> { };
            DataTable oTable = new DataTable();
            BLDoctorTerritoryMapping oBL = new BLDoctorTerritoryMapping();

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    oTable = oBL.GetRouteInfoForRM(sTerritoryID, nMaxVersion, connectionString);
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        RouteInfo oRouteInfo = new RouteInfo();
                        oRouteInfo.sTerritoryID = oRow["TerrID"].ToString().ToUpper();
                        oRouteInfo.nRouteID = Convert.ToInt32(oRow["RID"].ToString());
                        oRouteInfo.sRouteName = txtInfo.ToTitleCase(oRow["RName"].ToString().Trim());
                        oRouteInfo.nVersion = Convert.ToInt32(oRow["Version"].ToString());
                        oRouteInfo.nActionType = Convert.ToInt32(oRow["Action"].ToString());
                        oRouteInfoList.Add(oRouteInfo);
                    }
                    myTransaction.Commit();
                }

                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
                return oRouteInfoList;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Get SampleTerritoryMappingForRM")]
        public SampleTerritoryMappings GetSampleTerritoryMappingForRM(String sTerritoryID, int nMaxVersion)
        {
            SampleTerritoryMappings oSampleTerritoryMappings = new SampleTerritoryMappings();
            BLSampleTerritoryMapping oBL = new BLSampleTerritoryMapping();
            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    oSampleTerritoryMappings = oBL.GetSampleTerritoryMappingsForRM(sTerritoryID, nMaxVersion, connectionString);
                    myTransaction.Commit();
                }

                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
                return oSampleTerritoryMappings;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Get GimmickTerritoryMappingForRM")]
        public GimmickTerritoryMappings GetGimmickTerritoryMappingForRM(String sTerritoryID, int nMaxVersion)
        {
            GimmickTerritoryMappings oGimmickTerritoryMappings = new GimmickTerritoryMappings();
            BLGimmickTerritoryMapping oBL = new BLGimmickTerritoryMapping();
            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    oGimmickTerritoryMappings = oBL.GetGimmickTerritoryMappingsForRM(sTerritoryID, nMaxVersion, connectionString);
                    myTransaction.Commit();
                }

                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
                return oGimmickTerritoryMappings;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Get BrandTerritoryMappingForRM")]
        public BrandTerritoryMappings GetBrandTerritoryMappingForRM(String sTerritoryID, int nMaxVersion)
        {
            BrandTerritoryMappings oBrandTerritoryMappings = new BrandTerritoryMappings();
            BLBrandTerritoryMapping oBL = new BLBrandTerritoryMapping();

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;
                try
                {
                    oBrandTerritoryMappings = oBL.GetBrandTerritoryMappingsForRM(sTerritoryID, nMaxVersion, connectionString);
                    myTransaction.Commit();
                }
                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
                return oBrandTerritoryMappings;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Get PVPMasterInfoForRM")]
        public PVPMasters GetPVPMasterInfoForRM(string sTerritoryID, int nMaxVersion)
        {
            PVPMasters oPVPMasters = new PVPMasters();
            BLPVPMaster oBL = new BLPVPMaster();
            PVPMonthCycle oPVPMonthCycle = new PVPMonthCycle();
            BLPVPMonthCycle oBLPVPMonthCycle = new BLPVPMonthCycle();
            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;
                try
                {
                    oPVPMonthCycle = oBLPVPMonthCycle.GetPVPMonthCycle(connectionString);
                    int nMonth = oPVPMonthCycle.Month;
                    int nYear = oPVPMonthCycle.Year;
                    string sPVPMonthCycleDateTime = nYear + "-" + nMonth + "-15";
                    DateTime dDateTime = DateTime.Now;
                    dDateTime = Convert.ToDateTime(sPVPMonthCycleDateTime);
                    int nNextMonth = dDateTime.Month;
                    int nNextYear = dDateTime.Year;
                    dDateTime = dDateTime.AddMonths(-1);
                    int nCurrentMonth = dDateTime.Month;
                    int nCurrentYear = dDateTime.Year;

                    //oPVPMasters = oBL.GetPVPMasterInfoForRM(sTerritoryID, nMonth, nYear, nPreMonth, nPreYear, nMaxVersion);
                    oPVPMasters = oBL.GetPVPMastersForRM(sTerritoryID, nNextMonth, nNextYear, nCurrentMonth, nCurrentYear, nMaxVersion, connectionString);

                    myTransaction.Commit();
                }
                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
                return oPVPMasters;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Get PVPDetailInfoForRM")]
        public List<PVPDetailInfo> GetPVPDetailInfoForRM(string sTerritoryID, int nMaxVersion)
        {
            oPVPDetailInfoList = new List<PVPDetailInfo> { };
            PVPDetailInfo oPVPDetailInfo = new PVPDetailInfo();
            PVPDetails oPVPDetails = new PVPDetails();
            BLPVPDetail oBL = new BLPVPDetail();
            BLProduct oBLProduct = new BLProduct();
            PVPMonthCycle oPVPMonthCycle = new PVPMonthCycle();
            BLPVPMonthCycle oBLPVPMonthCycle = new BLPVPMonthCycle();

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;
                try
                {
                    oPVPMonthCycle = oBLPVPMonthCycle.GetPVPMonthCycle(connectionString);
                    int nMonth = oPVPMonthCycle.Month;
                    int nYear = oPVPMonthCycle.Year;
                    string sPVPMonthCycleDateTime = nYear + "-" + nMonth + "-15";
                    DateTime dDateTime = DateTime.Now;
                    dDateTime = Convert.ToDateTime(sPVPMonthCycleDateTime);
                    int nNextMonth = dDateTime.Month;
                    int nNextYear = dDateTime.Year;
                    dDateTime = dDateTime.AddMonths(-1);
                    int nCurrentMonth = dDateTime.Month;
                    int nCurrentYear = dDateTime.Year;

                    //oPVPDetails = oBL.GetPVPDetailInfoForRM(sTerritoryID, nMonth, nYear, nPreMonth, nPreYear, nMaxVersion);
                    oPVPDetails = oBL.GetPVPDetailsForRM(sTerritoryID, nCurrentMonth, nCurrentYear, nNextMonth, nNextYear, nMaxVersion, connectionString);

                    foreach (PVPDetail oPVPDetail in oPVPDetails)
                    {
                        oPVPDetailInfo = new PVPDetailInfo();
                        oPVPDetailInfo.sPvpID = oPVPDetail.PvpID.ToString();
                        oPVPDetailInfo.sTerritoryID = oPVPDetail.TerritoryID;
                        oPVPDetailInfo.sDoctorID = oPVPDetail.DoctorID.ToString();
                        oPVPDetailInfo.nDay = oPVPDetail.Day;
                        oPVPDetailInfo.nMonth = oPVPDetail.Month;
                        oPVPDetailInfo.nYear = oPVPDetail.Year;
                        if (oPVPDetail.Session == null)
                            oPVPDetailInfo.sSession = "";
                        else
                            oPVPDetailInfo.sSession = oPVPDetail.Session;
                        oPVPDetailInfo.nIsHoliday = Convert.ToInt32(oPVPDetail.IsHoliday);
                        if (oPVPDetail.DoctorProfile == null)
                            oPVPDetailInfo.sDoctorProfile = "";
                        else
                            oPVPDetailInfo.sDoctorProfile = oPVPDetail.DoctorProfile;
                        oPVPDetailInfo.sCreationDate = oPVPDetail.CreationDate.ToString("dd MMM yyyy HH:mm:ss");
                        if (oPVPDetail.Brand1 == null)
                            oPVPDetailInfo.sBrand1 = "";
                        else
                            oPVPDetailInfo.sBrand1 = oBLProduct.GetProductCode((int)oPVPDetail.Brand1);
                        if (oPVPDetail.Brand2 == null)
                            oPVPDetailInfo.sBrand2 = "";
                        else
                            oPVPDetailInfo.sBrand2 = oBLProduct.GetProductCode((int)oPVPDetail.Brand2);
                        if (oPVPDetail.Brand3 == null)
                            oPVPDetailInfo.sBrand3 = "";
                        else
                            oPVPDetailInfo.sBrand3 = oBLProduct.GetProductCode((int)oPVPDetail.Brand3);
                        if (oPVPDetail.Brand4 == null)
                            oPVPDetailInfo.sBrand4 = "";
                        else
                            oPVPDetailInfo.sBrand4 = oBLProduct.GetProductCode((int)oPVPDetail.Brand4);
                        if (oPVPDetail.Brand5 == null)
                            oPVPDetailInfo.sBrand5 = "";
                        else
                            oPVPDetailInfo.sBrand5 = oBLProduct.GetProductCode((int)oPVPDetail.Brand5);
                        if (oPVPDetail.Brand6 == null)
                            oPVPDetailInfo.sBrand6 = "";
                        else
                            oPVPDetailInfo.sBrand6 = oBLProduct.GetProductCode((int)oPVPDetail.Brand6);
                         if (oPVPDetail.Brand7 == null)
                            oPVPDetailInfo.sBrand7 = "";
                        else
                            oPVPDetailInfo.sBrand7 = oBLProduct.GetProductCode((int)oPVPDetail.Brand7);
                        if (oPVPDetail.Brand8 == null)
                            oPVPDetailInfo.sBrand8 = "";
                        else
                            oPVPDetailInfo.sBrand8 = oBLProduct.GetProductCode((int)oPVPDetail.Brand8);
                        
                        oPVPDetailInfoList.Add(oPVPDetailInfo);
                    }
                    myTransaction.Commit();
                }

                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
                return oPVPDetailInfoList;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Get DCRInfoForRM")]
        public List<DCRInfo> GetDCRInfoForRM(string sTerritoryID, int nMaxVersion)
        {
            oDCRInfoList = new List<DCRInfo> { };
            DCRs oDCRs = new DCRs();
            AppConfigurationInfo oAppConfigInfo = new AppConfigurationInfo();
            BLDCR oBL = new BLDCR();
            BLAppConfigurationInfo oBLAppConfig = new BLAppConfigurationInfo();
            BLBrandTerritoryMapping oBLBrand = new BLBrandTerritoryMapping();
            BLGimmickTerritoryMapping oBLGimmick = new BLGimmickTerritoryMapping();
            BLSampleTerritoryMapping oBLSample = new BLSampleTerritoryMapping();
            DataTable oTable = new DataTable();
            DCRInfo oDCRInfo = new DCRInfo();
            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;
                try
                {

                    DateTime dCurrentDate = DateTime.Now;
                    int nCurrentMonth = dCurrentDate.Month;
                    int nCurrentYear = dCurrentDate.Year;
                    //oAppConfigInfo = oBLAppConfig.GetAppConfigurationInfo();
                    oAppConfigInfo = oBLAppConfig.GetAppConfigurationInfo(sTerritoryID, connectionString);
                    int nDCRApprovalHours = oAppConfigInfo.DCRApprovalHours;
                    int nPreviousDCREntryDay = nDCRApprovalHours / 24;
                    DateTime dPreviousDate = DateTime.Now.AddMonths(-1);
                    int nPreviousMonth = dPreviousDate.Month;
                    int nPreviousYear = dPreviousDate.Year;
                    int nPreviousMonthDay = DateTime.DaysInMonth(nPreviousYear, nPreviousMonth) - nPreviousDCREntryDay;
                    //oDCRs = oBL.GetDCRInfoForRM(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonth, nPreviousYear, nPreviousMonthDay, nMaxVersion);
                    //oDCRs = oBL.GetDCRsForRM(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonth, nPreviousYear, nPreviousMonthDay, nMaxVersion, connectionString);
                    oTable = oBL.GetDCRInfoForRM(sTerritoryID, nCurrentMonth, nCurrentYear, nPreviousMonth, nPreviousYear, nPreviousMonthDay, nMaxVersion, connectionString);


                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oDCRInfo = new DCRInfo();
                        oDCRInfo.nDcrID = Convert.ToInt32(oRow["DcrID"].ToString());
                        oDCRInfo.nPvpDetailID = oRow["PvpDetailID"].ToString() == "" ? 0 : Convert.ToInt32(oRow["PvpDetailID"].ToString());
                        oDCRInfo.nDoctorID = Convert.ToInt32(oRow["DoctorID"].ToString());
                        oDCRInfo.sTerritoryID = oRow["TerritoryID"].ToString().ToUpper();
                        oDCRInfo.nDay = Convert.ToInt32(oRow["Day"].ToString());
                        oDCRInfo.nMonth = Convert.ToInt32(oRow["Month"].ToString());
                        oDCRInfo.nYear = Convert.ToInt32(oRow["Year"].ToString());
                        oDCRInfo.nStatus = Convert.ToInt32(oRow["Status"].ToString());
                        oDCRInfo.sVisitDateTime = Convert.ToDateTime(oRow["VisitDateTime"].ToString()).ToString("dd MMM yyyy HH:mm:ss");
                        oDCRInfo.nIsVisited = Convert.ToInt32(oRow["IsVisited"].ToString());
                        oDCRInfo.nIsAvailable = Convert.ToInt32(oRow["IsAvailable"].ToString());
                        oDCRInfo.nIsAccompanyByRM_RM = Convert.ToInt32(oRow["IsAccompanyByRM_RM"].ToString());
                        oDCRInfo.nIsAccompanyByRM_SF = Convert.ToInt32(oRow["IsAccompanyByRM_SF"].ToString());
                        oDCRInfo.sReminderNextCall = oRow["ReminderNextCall"].ToString();
                        oDCRInfo.nNotAvailableReasonID = Convert.ToInt32(oRow["NotAvailableReasonID"].ToString());
                        oDCRInfo.sNotAvailableReason = oRow["NotAvailableReason"].ToString();
                        oDCRInfo.nIsNewVisit = Convert.ToInt32(oRow["IsNewVisit"].ToString());
                        oDCRInfo.sSession = oRow["Session"].ToString();

                        oDCRInfo.sBrand1 = oRow["Brand1"].ToString() == "" ? "" : oBLBrand.GetBrandName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand1"].ToString()));
                        oDCRInfo.sBrand1Gimmick1 = oRow["Brand1Gimmick1"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand1Gimmick1"].ToString()));
                        oDCRInfo.sBrand1Gimmick2 = oRow["Brand1Gimmick2"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand1Gimmick2"].ToString()));
                        oDCRInfo.sBrand1Gimmick3 = oRow["Brand1Gimmick3"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand1Gimmick3"].ToString()));
                        oDCRInfo.sBrand1Sample1 = oRow["Brand1Sample1"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand1Sample1"].ToString()));
                        oDCRInfo.sBrand1Sample2 = oRow["Brand1Sample2"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand1Sample2"].ToString()));
                        oDCRInfo.sBrand1Sample3 = oRow["Brand1Sample3"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand1Sample3"].ToString()));
                        oDCRInfo.nBrand1Gimmick1Qty = oRow["Brand1Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Gimmick1Qty"].ToString());
                        oDCRInfo.nBrand1Gimmick2Qty = oRow["Brand1Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Gimmick2Qty"].ToString());
                        oDCRInfo.nBrand1Gimmick3Qty = oRow["Brand1Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Gimmick3Qty"].ToString());
                        oDCRInfo.nBrand1Sample1Qty = oRow["Brand1Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Sample1Qty"].ToString());
                        oDCRInfo.nBrand1Sample2Qty = oRow["Brand1Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Sample2Qty"].ToString());
                        oDCRInfo.nBrand1Sample3Qty = oRow["Brand1Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Sample3Qty"].ToString());

                        oDCRInfo.sBrand2 = oRow["Brand2"].ToString() == "" ? "" : oBLBrand.GetBrandName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand2"].ToString()));
                        oDCRInfo.sBrand2Gimmick1 = oRow["Brand2Gimmick1"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand2Gimmick1"].ToString()));
                        oDCRInfo.sBrand2Gimmick2 = oRow["Brand2Gimmick2"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand2Gimmick2"].ToString()));
                        oDCRInfo.sBrand2Gimmick3 = oRow["Brand2Gimmick3"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand2Gimmick3"].ToString()));
                        oDCRInfo.sBrand2Sample1 = oRow["Brand2Sample1"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand2Sample1"].ToString()));
                        oDCRInfo.sBrand2Sample2 = oRow["Brand2Sample2"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand2Sample2"].ToString()));
                        oDCRInfo.sBrand2Sample3 = oRow["Brand2Sample3"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand2Sample3"].ToString()));
                        oDCRInfo.nBrand2Gimmick1Qty = oRow["Brand2Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Gimmick1Qty"].ToString());
                        oDCRInfo.nBrand2Gimmick2Qty = oRow["Brand2Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Gimmick2Qty"].ToString());
                        oDCRInfo.nBrand2Gimmick3Qty = oRow["Brand2Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Gimmick3Qty"].ToString());
                        oDCRInfo.nBrand2Sample1Qty = oRow["Brand2Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Sample1Qty"].ToString());
                        oDCRInfo.nBrand2Sample2Qty = oRow["Brand2Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Sample2Qty"].ToString());
                        oDCRInfo.nBrand2Sample3Qty = oRow["Brand2Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Sample3Qty"].ToString());

                        oDCRInfo.sBrand3 = oRow["Brand3"].ToString() == "" ? "" : oBLBrand.GetBrandName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand3"].ToString()));
                        oDCRInfo.sBrand3Gimmick1 = oRow["Brand3Gimmick1"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand3Gimmick1"].ToString()));
                        oDCRInfo.sBrand3Gimmick2 = oRow["Brand3Gimmick2"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand3Gimmick2"].ToString()));
                        oDCRInfo.sBrand3Gimmick3 = oRow["Brand3Gimmick3"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand3Gimmick3"].ToString()));
                        oDCRInfo.sBrand3Sample1 = oRow["Brand3Sample1"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand3Sample1"].ToString()));
                        oDCRInfo.sBrand3Sample2 = oRow["Brand3Sample2"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand3Sample2"].ToString()));
                        oDCRInfo.sBrand3Sample3 = oRow["Brand3Sample3"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand3Sample3"].ToString()));
                        oDCRInfo.nBrand3Gimmick1Qty = oRow["Brand3Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Gimmick1Qty"].ToString());
                        oDCRInfo.nBrand3Gimmick2Qty = oRow["Brand3Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Gimmick2Qty"].ToString());
                        oDCRInfo.nBrand3Gimmick3Qty = oRow["Brand3Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Gimmick3Qty"].ToString());
                        oDCRInfo.nBrand3Sample1Qty = oRow["Brand3Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Sample1Qty"].ToString());
                        oDCRInfo.nBrand3Sample2Qty = oRow["Brand3Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Sample2Qty"].ToString());
                        oDCRInfo.nBrand3Sample3Qty = oRow["Brand3Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Sample3Qty"].ToString());

                        oDCRInfo.sBrand4 = oRow["Brand4"].ToString() == "" ? "" : oBLBrand.GetBrandName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand4"].ToString()));
                        oDCRInfo.sBrand4Gimmick1 = oRow["Brand4Gimmick1"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand4Gimmick1"].ToString()));
                        oDCRInfo.sBrand4Gimmick2 = oRow["Brand4Gimmick2"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand4Gimmick2"].ToString()));
                        oDCRInfo.sBrand4Gimmick3 = oRow["Brand4Gimmick3"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand4Gimmick3"].ToString()));
                        oDCRInfo.sBrand4Sample1 = oRow["Brand4Sample1"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand4Sample1"].ToString()));
                        oDCRInfo.sBrand4Sample2 = oRow["Brand4Sample2"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand4Sample2"].ToString()));
                        oDCRInfo.sBrand4Sample3 = oRow["Brand4Sample3"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand4Sample3"].ToString()));
                        oDCRInfo.nBrand4Gimmick1Qty = oRow["Brand4Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Gimmick1Qty"].ToString());
                        oDCRInfo.nBrand4Gimmick2Qty = oRow["Brand4Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Gimmick2Qty"].ToString());
                        oDCRInfo.nBrand4Gimmick3Qty = oRow["Brand4Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Gimmick3Qty"].ToString());
                        oDCRInfo.nBrand4Sample1Qty = oRow["Brand4Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Sample1Qty"].ToString());
                        oDCRInfo.nBrand4Sample2Qty = oRow["Brand4Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Sample2Qty"].ToString());
                        oDCRInfo.nBrand4Sample3Qty = oRow["Brand4Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Sample3Qty"].ToString());

                        oDCRInfo.sBrand5 = oRow["Brand5"].ToString() == "" ? "" : oBLBrand.GetBrandName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand5"].ToString()));
                        oDCRInfo.sBrand5Gimmick1 = oRow["Brand5Gimmick1"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand5Gimmick1"].ToString()));
                        oDCRInfo.sBrand5Gimmick2 = oRow["Brand5Gimmick2"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand5Gimmick2"].ToString()));
                        oDCRInfo.sBrand5Gimmick3 = oRow["Brand5Gimmick3"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand5Gimmick3"].ToString()));
                        oDCRInfo.sBrand5Sample1 = oRow["Brand5Sample1"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand5Sample1"].ToString()));
                        oDCRInfo.sBrand5Sample2 = oRow["Brand5Sample2"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand5Sample2"].ToString()));
                        oDCRInfo.sBrand5Sample3 = oRow["Brand5Sample3"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand5Sample3"].ToString()));
                        oDCRInfo.nBrand5Gimmick1Qty = oRow["Brand5Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Gimmick1Qty"].ToString());
                        oDCRInfo.nBrand5Gimmick2Qty = oRow["Brand5Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Gimmick2Qty"].ToString());
                        oDCRInfo.nBrand5Gimmick3Qty = oRow["Brand5Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Gimmick3Qty"].ToString());
                        oDCRInfo.nBrand5Sample1Qty = oRow["Brand5Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Sample1Qty"].ToString());
                        oDCRInfo.nBrand5Sample2Qty = oRow["Brand5Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Sample2Qty"].ToString());
                        oDCRInfo.nBrand5Sample3Qty = oRow["Brand5Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Sample3Qty"].ToString());

                        oDCRInfo.sBrand6 = oRow["Brand6"].ToString() == "" ? "" : oBLBrand.GetBrandName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand6"].ToString()));
                        oDCRInfo.sBrand6Gimmick1 = oRow["Brand6Gimmick1"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand6Gimmick1"].ToString()));
                        oDCRInfo.sBrand6Gimmick2 = oRow["Brand6Gimmick2"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand6Gimmick2"].ToString()));
                        oDCRInfo.sBrand6Gimmick3 = oRow["Brand6Gimmick3"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand6Gimmick3"].ToString()));
                        oDCRInfo.sBrand6Sample1 = oRow["Brand6Sample1"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand6Sample1"].ToString()));
                        oDCRInfo.sBrand6Sample2 = oRow["Brand6Sample2"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand6Sample2"].ToString()));
                        oDCRInfo.sBrand6Sample3 = oRow["Brand6Sample3"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand6Sample3"].ToString()));
                        oDCRInfo.nBrand6Gimmick1Qty = oRow["Brand6Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Gimmick1Qty"].ToString());
                        oDCRInfo.nBrand6Gimmick2Qty = oRow["Brand6Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Gimmick2Qty"].ToString());
                        oDCRInfo.nBrand6Gimmick3Qty = oRow["Brand6Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Gimmick3Qty"].ToString());
                        oDCRInfo.nBrand6Sample1Qty = oRow["Brand6Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Sample1Qty"].ToString());
                        oDCRInfo.nBrand6Sample2Qty = oRow["Brand6Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Sample2Qty"].ToString());
                        oDCRInfo.nBrand6Sample3Qty = oRow["Brand6Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Sample3Qty"].ToString());

                        oDCRInfo.sBrand7 = oRow["Brand7"].ToString() == "" ? "" : oBLBrand.GetBrandName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand7"].ToString()));
                        oDCRInfo.sBrand7Gimmick1 = oRow["Brand7Gimmick1"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand7Gimmick1"].ToString()));
                        oDCRInfo.sBrand7Gimmick2 = oRow["Brand7Gimmick2"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand7Gimmick2"].ToString()));
                        oDCRInfo.sBrand7Gimmick3 = oRow["Brand7Gimmick3"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand7Gimmick3"].ToString()));
                        oDCRInfo.sBrand7Sample1 = oRow["Brand7Sample1"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand7Sample1"].ToString()));
                        oDCRInfo.sBrand7Sample2 = oRow["Brand7Sample2"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand7Sample2"].ToString()));
                        oDCRInfo.sBrand7Sample3 = oRow["Brand7Sample3"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand7Sample3"].ToString()));
                        oDCRInfo.nBrand7Gimmick1Qty = oRow["Brand7Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand7Gimmick1Qty"].ToString());
                        oDCRInfo.nBrand7Gimmick2Qty = oRow["Brand7Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand7Gimmick2Qty"].ToString());
                        oDCRInfo.nBrand7Gimmick3Qty = oRow["Brand7Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand7Gimmick3Qty"].ToString());
                        oDCRInfo.nBrand7Sample1Qty = oRow["Brand7Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand7Sample1Qty"].ToString());
                        oDCRInfo.nBrand7Sample2Qty = oRow["Brand7Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand7Sample2Qty"].ToString());
                        oDCRInfo.nBrand7Sample3Qty = oRow["Brand7Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand7Sample3Qty"].ToString());

                        oDCRInfo.sBrand8 = oRow["Brand8"].ToString() == "" ? "" : oBLBrand.GetBrandName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand8"].ToString()));
                        oDCRInfo.sBrand8Gimmick1 = oRow["Brand8Gimmick1"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand8Gimmick1"].ToString()));
                        oDCRInfo.sBrand8Gimmick2 = oRow["Brand8Gimmick2"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand8Gimmick2"].ToString()));
                        oDCRInfo.sBrand8Gimmick3 = oRow["Brand8Gimmick3"].ToString() == "" ? "" : oBLGimmick.GetGimmickName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand8Gimmick3"].ToString()));
                        oDCRInfo.sBrand8Sample1 = oRow["Brand8Sample1"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand8Sample1"].ToString()));
                        oDCRInfo.sBrand8Sample2 = oRow["Brand8Sample2"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand8Sample2"].ToString()));
                        oDCRInfo.sBrand8Sample3 = oRow["Brand8Sample3"].ToString() == "" ? "" : oBLSample.GetSampleName(myConnection, myTransaction, Convert.ToInt32(oRow["Brand8Sample3"].ToString()));
                        oDCRInfo.nBrand8Gimmick1Qty = oRow["Brand8Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand8Gimmick1Qty"].ToString());
                        oDCRInfo.nBrand8Gimmick2Qty = oRow["Brand8Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand8Gimmick2Qty"].ToString());
                        oDCRInfo.nBrand8Gimmick3Qty = oRow["Brand8Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand8Gimmick3Qty"].ToString());
                        oDCRInfo.nBrand8Sample1Qty = oRow["Brand8Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand8Sample1Qty"].ToString());
                        oDCRInfo.nBrand8Sample2Qty = oRow["Brand8Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand8Sample2Qty"].ToString());
                        oDCRInfo.nBrand8Sample3Qty = oRow["Brand8Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand8Sample3Qty"].ToString());

                        //oDCRInfo.nBrand1 = oRow["Brand1"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1"].ToString());
                        //oDCRInfo.nBrand1Gimmick1 = oRow["Brand1Gimmick1"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Gimmick1"].ToString());
                        //oDCRInfo.nBrand1Gimmick2 = oRow["Brand1Gimmick2"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Gimmick2"].ToString());
                        //oDCRInfo.nBrand1Gimmick3 = oRow["Brand1Gimmick3"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Gimmick3"].ToString());
                        //oDCRInfo.nBrand1Sample1 = oRow["Brand1Sample1"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Sample1"].ToString());
                        //oDCRInfo.nBrand1Sample2 = oRow["Brand1Sample2"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Sample2"].ToString());
                        //oDCRInfo.nBrand1Sample3 = oRow["Brand1Sample3"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Sample3"].ToString());
                        //oDCRInfo.nBrand1Gimmick1Qty = oRow["Brand1Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Gimmick1Qty"].ToString());
                        //oDCRInfo.nBrand1Gimmick2Qty = oRow["Brand1Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Gimmick2Qty"].ToString());
                        //oDCRInfo.nBrand1Gimmick3Qty = oRow["Brand1Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Gimmick3Qty"].ToString());
                        //oDCRInfo.nBrand1Sample1Qty = oRow["Brand1Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Sample1Qty"].ToString());
                        //oDCRInfo.nBrand1Sample2Qty = oRow["Brand1Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Sample2Qty"].ToString());
                        //oDCRInfo.nBrand1Sample3Qty = oRow["Brand1Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand1Sample3Qty"].ToString());

                        //oDCRInfo.nBrand2 = oRow["Brand2"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2"].ToString());
                        //oDCRInfo.nBrand2Gimmick1 = oRow["Brand2Gimmick1"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Gimmick1"].ToString());
                        //oDCRInfo.nBrand2Gimmick2 = oRow["Brand2Gimmick2"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Gimmick2"].ToString());
                        //oDCRInfo.nBrand2Gimmick3 = oRow["Brand2Gimmick3"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Gimmick3"].ToString());
                        //oDCRInfo.nBrand2Sample1 = oRow["Brand2Sample1"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Sample1"].ToString());
                        //oDCRInfo.nBrand2Sample2 = oRow["Brand2Sample2"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Sample2"].ToString());
                        //oDCRInfo.nBrand2Sample3 = oRow["Brand2Sample3"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Sample3"].ToString());
                        //oDCRInfo.nBrand2Gimmick1Qty = oRow["Brand2Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Gimmick1Qty"].ToString());
                        //oDCRInfo.nBrand2Gimmick2Qty = oRow["Brand2Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Gimmick2Qty"].ToString());
                        //oDCRInfo.nBrand2Gimmick3Qty = oRow["Brand2Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Gimmick3Qty"].ToString());
                        //oDCRInfo.nBrand2Sample1Qty = oRow["Brand2Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Sample1Qty"].ToString());
                        //oDCRInfo.nBrand2Sample2Qty = oRow["Brand2Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Sample2Qty"].ToString());
                        //oDCRInfo.nBrand2Sample3Qty = oRow["Brand2Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand2Sample3Qty"].ToString());

                        //oDCRInfo.nBrand3 = oRow["Brand3"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3"].ToString());
                        //oDCRInfo.nBrand3Gimmick1 = oRow["Brand3Gimmick1"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Gimmick1"].ToString());
                        //oDCRInfo.nBrand3Gimmick2 = oRow["Brand3Gimmick2"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Gimmick2"].ToString());
                        //oDCRInfo.nBrand3Gimmick3 = oRow["Brand3Gimmick3"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Gimmick3"].ToString());
                        //oDCRInfo.nBrand3Sample1 = oRow["Brand3Sample1"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Sample1"].ToString());
                        //oDCRInfo.nBrand3Sample2 = oRow["Brand3Sample2"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Sample2"].ToString());
                        //oDCRInfo.nBrand3Sample3 = oRow["Brand3Sample3"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Sample3"].ToString());
                        //oDCRInfo.nBrand3Gimmick1Qty = oRow["Brand3Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Gimmick1Qty"].ToString());
                        //oDCRInfo.nBrand3Gimmick2Qty = oRow["Brand3Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Gimmick2Qty"].ToString());
                        //oDCRInfo.nBrand3Gimmick3Qty = oRow["Brand3Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Gimmick3Qty"].ToString());
                        //oDCRInfo.nBrand3Sample1Qty = oRow["Brand3Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Sample1Qty"].ToString());
                        //oDCRInfo.nBrand3Sample2Qty = oRow["Brand3Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Sample2Qty"].ToString());
                        //oDCRInfo.nBrand3Sample3Qty = oRow["Brand3Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand3Sample3Qty"].ToString());

                        //oDCRInfo.nBrand4 = oRow["Brand4"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4"].ToString());
                        //oDCRInfo.nBrand4Gimmick1 = oRow["Brand4Gimmick1"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Gimmick1"].ToString());
                        //oDCRInfo.nBrand4Gimmick2 = oRow["Brand4Gimmick2"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Gimmick2"].ToString());
                        //oDCRInfo.nBrand4Gimmick3 = oRow["Brand4Gimmick3"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Gimmick3"].ToString());
                        //oDCRInfo.nBrand4Sample1 = oRow["Brand4Sample1"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Sample1"].ToString());
                        //oDCRInfo.nBrand4Sample2 = oRow["Brand4Sample2"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Sample2"].ToString());
                        //oDCRInfo.nBrand4Sample3 = oRow["Brand4Sample3"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Sample3"].ToString());
                        //oDCRInfo.nBrand4Gimmick1Qty = oRow["Brand4Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Gimmick1Qty"].ToString());
                        //oDCRInfo.nBrand4Gimmick2Qty = oRow["Brand4Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Gimmick2Qty"].ToString());
                        //oDCRInfo.nBrand4Gimmick3Qty = oRow["Brand4Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Gimmick3Qty"].ToString());
                        //oDCRInfo.nBrand4Sample1Qty = oRow["Brand4Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Sample1Qty"].ToString());
                        //oDCRInfo.nBrand4Sample2Qty = oRow["Brand4Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Sample2Qty"].ToString());
                        //oDCRInfo.nBrand4Sample3Qty = oRow["Brand4Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand4Sample3Qty"].ToString());

                        //oDCRInfo.nBrand5 = oRow["Brand5"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5"].ToString());
                        //oDCRInfo.nBrand5Gimmick1 = oRow["Brand5Gimmick1"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Gimmick1"].ToString());
                        //oDCRInfo.nBrand5Gimmick2 = oRow["Brand5Gimmick2"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Gimmick2"].ToString());
                        //oDCRInfo.nBrand5Gimmick3 = oRow["Brand5Gimmick3"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Gimmick3"].ToString());
                        //oDCRInfo.nBrand5Sample1 = oRow["Brand5Sample1"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Sample1"].ToString());
                        //oDCRInfo.nBrand5Sample2 = oRow["Brand5Sample2"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Sample2"].ToString());
                        //oDCRInfo.nBrand5Sample3 = oRow["Brand5Sample3"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Sample3"].ToString());
                        //oDCRInfo.nBrand5Gimmick1Qty = oRow["Brand5Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Gimmick1Qty"].ToString());
                        //oDCRInfo.nBrand5Gimmick2Qty = oRow["Brand5Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Gimmick2Qty"].ToString());
                        //oDCRInfo.nBrand5Gimmick3Qty = oRow["Brand5Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Gimmick3Qty"].ToString());
                        //oDCRInfo.nBrand5Sample1Qty = oRow["Brand5Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Sample1Qty"].ToString());
                        //oDCRInfo.nBrand5Sample2Qty = oRow["Brand5Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Sample2Qty"].ToString());
                        //oDCRInfo.nBrand5Sample3Qty = oRow["Brand5Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand5Sample3Qty"].ToString());

                        //oDCRInfo.nBrand6 = oRow["Brand6"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6"].ToString());
                        //oDCRInfo.nBrand6Gimmick1 = oRow["Brand6Gimmick1"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Gimmick1"].ToString());
                        //oDCRInfo.nBrand6Gimmick2 = oRow["Brand6Gimmick2"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Gimmick2"].ToString());
                        //oDCRInfo.nBrand6Gimmick3 = oRow["Brand6Gimmick3"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Gimmick3"].ToString());
                        //oDCRInfo.nBrand6Sample1 = oRow["Brand6Sample1"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Sample1"].ToString());
                        //oDCRInfo.nBrand6Sample2 = oRow["Brand6Sample2"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Sample2"].ToString());
                        //oDCRInfo.nBrand6Sample3 = oRow["Brand6Sample3"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Sample3"].ToString());
                        //oDCRInfo.nBrand6Gimmick1Qty = oRow["Brand6Gimmick1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Gimmick1Qty"].ToString());
                        //oDCRInfo.nBrand6Gimmick2Qty = oRow["Brand6Gimmick2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Gimmick2Qty"].ToString());
                        //oDCRInfo.nBrand6Gimmick3Qty = oRow["Brand6Gimmick3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Gimmick3Qty"].ToString());
                        //oDCRInfo.nBrand6Sample1Qty = oRow["Brand6Sample1Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Sample1Qty"].ToString());
                        //oDCRInfo.nBrand6Sample2Qty = oRow["Brand6Sample2Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Sample2Qty"].ToString());
                        //oDCRInfo.nBrand6Sample3Qty = oRow["Brand6Sample3Qty"].ToString() == "" ? 0 : Convert.ToInt32(oRow["Brand6Sample3Qty"].ToString());
                        
                        oDCRInfo.sSubmitDateTime = Convert.ToDateTime(oRow["SubmitDateTime"].ToString()).ToString("dd MMM yyyy HH:mm:ss");
                        oDCRInfo.sApprovedDateTime = Convert.ToDateTime(oRow["ApprovedDateTime"].ToString()).ToString("dd MMM yyyy HH:mm:ss");
                        oDCRInfo.nSubmittedBy = Convert.ToInt32(oRow["SubmittedBy"].ToString());
                        oDCRInfo.nApprovedBy = Convert.ToInt32(oRow["ApprovedBy"].ToString());
                        oDCRInfo.nAction = Convert.ToInt32(oRow["Action"].ToString());
                        oDCRInfo.nVersion = Convert.ToInt32(oRow["Version"].ToString());
                        oDCRInfo.sSMSDCRNo = oRow["SMSDCRNo"].ToString();
                        oDCRInfo.nIsSendSMS = Convert.ToInt32(oRow["IsSendSMS"].ToString());
                        oDCRInfo.sRejectReason = oRow["RejectReason"].ToString();

                        oDCRInfoList.Add(oDCRInfo);
                    }

                    myTransaction.Commit();
                }

                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
                return oDCRInfoList;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //[WebMethod(Description = "Method to Update RejectedTerritoryWise PVPMaster1")]
        //public int GetRejectedTerritoryWisePVPMasterRM1(string sTerritoryID)
        //{
        //    BLPVPMaster oBL = new BLPVPMaster();
        //    int nAuthenTicket = 0;
        //    try
        //    {
        //        PVPMonthCycle oPVPMonthCycle = new PVPMonthCycle();
        //        BLPVPMonthCycle oBLPVPMonthCycle = new BLPVPMonthCycle();
        //        UserInfo oUserInfo = new UserInfo();
        //        BLUserInfo oBLUserInfo = new BLUserInfo();
        //        oPVPMonthCycle = oBLPVPMonthCycle.GetActivePVPMonthCycle();
        //        int nMonth = oPVPMonthCycle.Month;
        //        int nYear = oPVPMonthCycle.Year;
        //        int nVersion = oBL.GetTerritoryWiseMaxVersion(sTerritoryID);
        //        string sRMGDDBID = oBL.GetRMGDDBID(sTerritoryID);
        //        oBL.GetUpdateTerritoryWisePVPMaster(sTerritoryID, sRMGDDBID, nMonth, nYear, nVersion);
        //        oUserInfo = oBLUserInfo.GetActiveUserInfoByTerritoryID(sTerritoryID);
        //        oUserInfo.Version = oUserInfo.Version + 1;
        //        oUserInfo.PVPVersion = oUserInfo.PVPVersion + 1;
        //        oBLUserInfo.Save(oUserInfo);
        //        nAuthenTicket = 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return nAuthenTicket;
        //}

        //[WebMethod(Description = "Method to Update RejectedTerritoryWise PVPMaster")]
        //public int GetRejectedTerritoryWisePVPMasterRM(string sTerritoryID)
        //{
        //    PVPMonthCycle oPVPMonthCycle = new PVPMonthCycle();
        //    BLPVPMonthCycle oBLPVPMonthCycle = new BLPVPMonthCycle();
        //    int nAuthenTicket = 0;

        //    try
        //    {
        //        //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
        //        NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
        //        string connectionString = oValues["ConnectionString2"].ToString();

        //        SqlConnection myConnection = new SqlConnection(connectionString);
        //        myConnection.Open();
        //        // Start transaction.
        //        SqlTransaction myTransaction = myConnection.BeginTransaction();
        //        // Assign command in the current transaction.
        //        SqlCommand myCommand = new SqlCommand();
        //        myCommand.Transaction = myTransaction;
        //        try
        //        {
        //            // …………………….
        //            // Database operations
        //            DataTable otblPVPMonthCycle = new DataTable();
        //            string sPVPMonthCycle = "SELECT * FROM [PVPMonthCycle] WHERE IsActive=1";
        //            SqlDataAdapter Sfda = new SqlDataAdapter(sPVPMonthCycle, connectionString);
        //            Sfda.Fill(otblPVPMonthCycle);

        //            int nMonth = Convert.ToInt32(otblPVPMonthCycle.Rows[0]["Month"]);
        //            int nYear = Convert.ToInt32(otblPVPMonthCycle.Rows[0]["Year"]);

        //            SqlCommand cmd1 = new SqlCommand();
        //            cmd1.CommandText = "SELECT MAX(Version)+ 1 AS Version FROM PVPMaster WHERE TerritoryID Like '" + sTerritoryID.Substring(0, 6) + "%'";
        //            cmd1.Connection = myConnection;
        //            cmd1.Transaction = myTransaction;
        //            object oMaxVersion = cmd1.ExecuteScalar();
        //            int nMaxVersion = 0;
        //            if (oMaxVersion == DBNull.Value)
        //            {
        //                nMaxVersion = 1;
        //            }
        //            else
        //            {
        //                nMaxVersion = Convert.ToInt32(oMaxVersion);
        //            }

        //            SqlCommand cmd2 = new SqlCommand();
        //            cmd2.CommandText = @"SELECT GDDBID FROM [OrderCollectionSystem].[dbo].[EmployeeInfo] a INNER JOIN [OrderCollectionSystem].[dbo].[Territory] b ON a.TerritoryID=b.TerritoryID WHERE b.TerritoryCode='" + sTerritoryID.Substring(0, 6) + "'";
        //            cmd2.Connection = myConnection;
        //            cmd2.Transaction = myTransaction;
        //            object oGDDBID = cmd2.ExecuteScalar();
        //            string sRMGDDBID = "";
        //            if (oGDDBID == DBNull.Value)
        //            {
        //                sRMGDDBID = "";
        //            }
        //            else
        //            {
        //                sRMGDDBID = Convert.ToString(oGDDBID);
        //            }

        //            string sSQL = SQL.MakeSQL("Update [PVPMaster] set [Status]=4, ApprovedDate=%D, ApprovedBy=%s, [Version]=%n, [Action]=2 where TerritoryID=%s and Month=%n and Year=%n", DateTime.Now, sRMGDDBID, nMaxVersion, sTerritoryID, nMonth, nYear);

        //            SqlDataAdapter oAdapter1 = new SqlDataAdapter();
        //            SqlCommand cmd3 = new SqlCommand();
        //            cmd3 = new SqlCommand(sSQL, myConnection);
        //            cmd3.Transaction = myTransaction;
        //            oAdapter1.UpdateCommand = cmd3;
        //            cmd3.ExecuteNonQuery();


        //            SqlCommand cmd4 = new SqlCommand();
        //            cmd4.CommandText = @"SELECT GDDBID FROM [OrderCollectionSystem].[dbo].[EmployeeInfo] a INNER JOIN [OrderCollectionSystem].[dbo].[Territory] b ON a.TerritoryID=b.TerritoryID WHERE b.TerritoryCode='" + sTerritoryID + "'";
        //            cmd4.Connection = myConnection;
        //            cmd4.Transaction = myTransaction;
        //            object oSFGDDBID = cmd4.ExecuteScalar();
        //            string sSFGDDBID = "";
        //            if (oSFGDDBID == DBNull.Value)
        //            {
        //                sSFGDDBID = "";
        //            }
        //            else
        //            {
        //                sSFGDDBID = Convert.ToString(oSFGDDBID);
        //            }

        //            DataTable otblUserInfo = new DataTable();
        //            string sSFUserInfo = "SELECT * FROM [UserInfo] WHERE GDDBID='" + sSFGDDBID + "' and IsActive=1";
        //            SqlDataAdapter Sfda3 = new SqlDataAdapter(sSFUserInfo, connectionString);
        //            Sfda3.Fill(otblUserInfo);

        //            string sSQL1 = SQL.MakeSQL("UPDATE [UserInfo] SET Version=%n, PVPVersion=%n"
        //                , Convert.ToInt32(otblUserInfo.Rows[0]["Version"].ToString()) + 1, Convert.ToInt32(otblUserInfo.Rows[0]["PVPVersion"].ToString()) + 1, sSFGDDBID);

        //            SqlDataAdapter oAdapter2 = new SqlDataAdapter();
        //            SqlCommand cmd5 = new SqlCommand();
        //            cmd5 = new SqlCommand(sSQL1, myConnection);
        //            cmd5.Transaction = myTransaction;
        //            oAdapter2.UpdateCommand = cmd5;
        //            cmd5.ExecuteNonQuery();

        //            nAuthenTicket = 1;

        //            myTransaction.Commit();
        //        }
        //        catch (Exception e)
        //        {
        //            myTransaction.Rollback();
        //        }
        //        finally
        //        {
        //            myConnection.Close();
        //        }

        //        return nAuthenTicket;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        [WebMethod(Description = "Method to Reject PVP")]
        public string RejectPVP(string sTerritoryID, string sApprovedBy)
        {
            PVPMonthCycle oPVPMonthCycle = new PVPMonthCycle();
            UserInfo oUserInfo = new UserInfo();
            PVPMaster oPVPMaster = new PVPMaster();
            AppConfigurationInfo oAppConfigInfo = new AppConfigurationInfo();
            BLPVPMonthCycle oBLPVPMonthCycle = new BLPVPMonthCycle();
            BLPVPMaster oBLPVPMaster = new BLPVPMaster();
            BLUserInfo oBLUserInfo = new BLUserInfo();
            BLEmployeeInfo oBLEmployeeInfo = new BLEmployeeInfo();
            BLCommandInfo oBLCommandInfo = new BLCommandInfo();
            BLAppConfigurationInfo oBLAppConfig = new BLAppConfigurationInfo();

            string sAuthenTicket = "";

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;
                try
                {
                    // …………………….
                    // Database operations
                    oPVPMonthCycle = oBLPVPMonthCycle.GetPVPMonthCycle(connectionString);
                    oAppConfigInfo = oBLAppConfig.GetAppConfigurationInfo(sTerritoryID.Substring(0, 6), connectionString);
                    int nMonth = oPVPMonthCycle.Month;
                    int nYear = oPVPMonthCycle.Year;
                    DateTime dPVPEndDate = oAppConfigInfo.PVPEndDate;
                    DateTime dCurrentDate = DateTime.Now.Date;
                    bool bIsPVPOpen = false;
                    if (dCurrentDate <= dPVPEndDate)
                        bIsPVPOpen = true;
                    //if (!bIsPVPOpen)
                    //{
                    //    //string sPVPEndDate = dCurrentDate.ToString("dd MMM yyyy");
                    //    //bIsPVPOpen = oBLCommandInfo.IsPVPTimeExtend(myConnection, myTransaction, sTerritoryID.Substring(0,6), sPVPEndDate);
                    //    string sPVPEndDate = oBLCommandInfo.GetPVPEndDate(myConnection, myTransaction, sTerritoryID.Substring(0, 6));
                    //    if (sPVPEndDate != "")
                    //        dPVPEndDate = Convert.ToDateTime(sPVPEndDate);
                    //    if (dCurrentDate <= dPVPEndDate)
                    //        bIsPVPOpen = true;
                    //}

                    if (bIsPVPOpen)
                    {
                        //string sRMGDDBID = oBLEmployeeInfo.GetGDDBIDByTerritoryID(myConnection, myTransaction, sTerritoryID.Substring(0, 6));

                        //int nMaxPVPVersion = oBLPVPMaster.GetMaxPVPVersion(myConnection, myTransaction, sTerritoryID);
                        int nMaxPVPVersion = oBLPVPMaster.GetMaxPVPVersion(myConnection, myTransaction);
                        oPVPMaster = oBLPVPMaster.GetPVPMasterInfo(sTerritoryID, nMonth, nYear, connectionString);
                        oPVPMaster.Status = PVPStatus.Rejected;
                        oPVPMaster.ApprovedDate = DateTime.Now;
                        oPVPMaster.ApprovedBy = sApprovedBy;
                        oPVPMaster.Version = nMaxPVPVersion;
                        oPVPMaster.Action = 2;
                        oBLPVPMaster.Save(oPVPMaster, myConnection, myTransaction);

                        string sSFGDDBID = oBLEmployeeInfo.GetGDDBIDByTerritoryID(myConnection, myTransaction, sTerritoryID);
                        oUserInfo = new UserInfo();
                        oUserInfo = oBLUserInfo.GetUserInfo(sSFGDDBID, connectionString);
                        oUserInfo.Version = oUserInfo.Version + 1;
                        oUserInfo.PVPVersion = oUserInfo.PVPVersion + 1;
                        oUserInfo.LastUpdateDate = DateTime.Now;
                        oBLUserInfo.Save(oUserInfo, myConnection, myTransaction);

                        oBLPVPMaster.InsertPVPCommandInfo(sTerritoryID, 4, myConnection, myTransaction);

                        sAuthenTicket = "1";
                    }
                    else
                    {
                        sAuthenTicket = "-1";
                    }

                    myTransaction.Commit();
                }
                catch (Exception e)
                {
                    sAuthenTicket = e.Message.ToString();
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                    sAuthenTicket = "Cannot connect to database.";
                else
                    sAuthenTicket = ex.Message.ToString();
                //throw new Exception(ex.Message);
            }

            return sAuthenTicket;
        }

        //[WebMethod(Description = "Method to GetRejectedTerritoryWisePVPMasterRM")]
        //public int GetRejectedTerritoryWisePVPMasterRM(string sTerritoryID)
        //{
        //    PVPMonthCycle oPVPMonthCycle = new PVPMonthCycle();
        //    UserInfo oUserInfo = new UserInfo();
        //    PVPMaster oPVPMaster = new PVPMaster();
        //    BLPVPMonthCycle oBLPVPMonthCycle = new BLPVPMonthCycle();
        //    BLPVPMaster oBLPVPMaster = new BLPVPMaster();
        //    BLUserInfo oBLUserInfo = new BLUserInfo();
        //    BLEmployeeInfo oBLEmployeeInfo = new BLEmployeeInfo();
        //    BLCommandInfo oBLCommandInfo = new BLCommandInfo();
        //    int nAuthenTicket = 0;

        //    try
        //    {
        //        //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
        //        NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
        //        string connectionString = oValues["ConnectionString2"].ToString();

        //        SqlConnection myConnection = new SqlConnection(connectionString);
        //        myConnection.Open();
        //        // Start transaction.
        //        SqlTransaction myTransaction = myConnection.BeginTransaction();
        //        // Assign command in the current transaction.
        //        SqlCommand myCommand = new SqlCommand();
        //        myCommand.Transaction = myTransaction;
        //        try
        //        {
        //            // …………………….
        //            // Database operations
        //            oPVPMonthCycle = oBLPVPMonthCycle.GetPVPMonthCycle(connectionString);
        //            int nMonth = oPVPMonthCycle.Month;
        //            int nYear = oPVPMonthCycle.Year;
        //            DateTime dPVPEndDate = oPVPMonthCycle.EndDate;
        //            DateTime dCurrentDate = DateTime.Now.Date;
        //            bool bIsPVPOpen = false;
        //            if (dCurrentDate <= dPVPEndDate)
        //                bIsPVPOpen = true;
        //            if (!bIsPVPOpen)
        //            {
        //                //string sPVPEndDate = dCurrentDate.ToString("dd MMM yyyy");
        //                //bIsPVPOpen = oBLCommandInfo.IsPVPTimeExtend(myConnection, myTransaction, sTerritoryID.Substring(0,6), sPVPEndDate);
        //                string sPVPEndDate = oBLCommandInfo.GetPVPEndDate(myConnection, myTransaction, sTerritoryID.Substring(0, 6));
        //                if (sPVPEndDate != "")
        //                    dPVPEndDate = Convert.ToDateTime(sPVPEndDate);
        //                if (dCurrentDate <= dPVPEndDate)
        //                    bIsPVPOpen = true;
        //            }

        //            if (bIsPVPOpen)
        //            {
        //                string sRMGDDBID = oBLEmployeeInfo.GetGDDBIDByTerritoryID(myConnection, myTransaction, sTerritoryID.Substring(0, 6));

        //                //int nMaxPVPVersion = oBLPVPMaster.GetMaxPVPVersion(myConnection, myTransaction, sTerritoryID);
        //                int nMaxPVPVersion = oBLPVPMaster.GetMaxPVPVersion(myConnection, myTransaction);
        //                oPVPMaster = oBLPVPMaster.GetPVPMasterInfo(sTerritoryID, nMonth, nYear, connectionString);
        //                oPVPMaster.Status = PVPStatus.Rejected;
        //                oPVPMaster.ApprovedDate = DateTime.Now;
        //                oPVPMaster.ApprovedBy = sRMGDDBID;
        //                oPVPMaster.Version = nMaxPVPVersion;
        //                oPVPMaster.Action = 2;
        //                oBLPVPMaster.Save(oPVPMaster, myConnection, myTransaction);

        //                string sSFGDDBID = oBLEmployeeInfo.GetGDDBIDByTerritoryID(myConnection, myTransaction, sTerritoryID);
        //                oUserInfo = new UserInfo();
        //                oUserInfo = oBLUserInfo.GetUserInfo(sSFGDDBID, connectionString);
        //                oUserInfo.Version = oUserInfo.Version + 1;
        //                oUserInfo.PVPVersion = oUserInfo.PVPVersion + 1;
        //                oBLUserInfo.Save(oUserInfo, myConnection, myTransaction);

        //                nAuthenTicket = 1;
        //            }
        //            else
        //            {
        //                nAuthenTicket = -1;
        //            }

        //            myTransaction.Commit();
        //        }
        //        catch (Exception e)
        //        {
        //            myTransaction.Rollback();
        //        }
        //        finally
        //        {
        //            myConnection.Close();
        //        }

        //        return nAuthenTicket;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        [WebMethod(Description = "Method to Approve PVP")]
        public string ApprovePVP(string sTerritoryID, string sApprovedBy)
        {
            PVPDetail oPVPDetail = new PVPDetail();
            PVPMaster oPVPMaster = new PVPMaster();
            PVPMonthCycle oPVPMonthCycle = new PVPMonthCycle();
            DCR oDCR = new DCR();
            UserInfo oUserInfo = new UserInfo();
            EmployeeInfo oEmployeeInfo = new EmployeeInfo();
            AppConfigurationInfo oAppConfigInfo = new AppConfigurationInfo();
            BLDCR oBLDCR = new BLDCR();
            BLUserInfo oBLUserInfo = new BLUserInfo();
            BLEmployeeInfo oBLEmployeeInfo = new BLEmployeeInfo();
            BLPVPMaster oBLPVPMaster = new BLPVPMaster();
            BLPVPDetail oBLPVPDetail = new BLPVPDetail();
            BLPVPMonthCycle oBLPVPMonthCycle = new BLPVPMonthCycle();
            BLCommandInfo oBLCommandInfo = new BLCommandInfo();
            BLAppConfigurationInfo oBLAppConfig = new BLAppConfigurationInfo();

            string sAuthenticket = "";
            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();

                // SqlConnection myConnection = new SqlConnection(connectionString);
                SqlConnection oConnection = new SqlConnection(connectionString);
                oConnection.Open();

                DataSet oPvpDetail = new DataSet();
                SqlDataAdapter oAdapter = new SqlDataAdapter();
                SqlCommand oCommand = new SqlCommand();

                //oConnection.ConnectionString = connectionString;
                SqlTransaction myTransaction = oConnection.BeginTransaction();
                oCommand.Transaction = myTransaction;
                //oCommand.CommandTimeout = 0;

                try
                {
                    oPVPMonthCycle = oBLPVPMonthCycle.GetPVPMonthCycle(connectionString);
                    oAppConfigInfo = oBLAppConfig.GetAppConfigurationInfo(sTerritoryID.Substring(0, 6), connectionString);
                    int nMonth = oPVPMonthCycle.Month;
                    int nYear = oPVPMonthCycle.Year;
                    DateTime dPVPEndDate = oAppConfigInfo.PVPEndDate;
                    DateTime dCurrentDate = DateTime.Now.Date;

                    bool bIsPVPOpen = false;
                    if (dCurrentDate <= dPVPEndDate)
                        bIsPVPOpen = true;
                    //if (!bIsPVPOpen)
                    //{
                    //    //string sPVPEndDate = dCurrentDate.ToString("dd MMM yyyy");
                    //    //bIsPVPOpen = oBLCommandInfo.IsPVPTimeExtend(oConnection, myTransaction, sTerritoryID.Substring(0,6), sPVPEndDate);
                    //    string sPVPEndDate = oBLCommandInfo.GetPVPEndDate(oConnection, myTransaction, sTerritoryID.Substring(0, 6));
                    //    if (sPVPEndDate != "")
                    //    {
                    //        dPVPEndDate = Convert.ToDateTime(sPVPEndDate);
                    //    }
                    //    if (dCurrentDate <= dPVPEndDate)
                    //        bIsPVPOpen = true;
                    //}

                    if (bIsPVPOpen)
                    {
                        DataTable dtPVPDetail = new DataTable();
                        dtPVPDetail = oBLPVPDetail.GetPVPDetailInfo(sTerritoryID, nMonth, nYear, connectionString);

                        //int nMaxDCRVersion = oBLDCR.GetDCRNewVersion(oConnection, myTransaction, sTerritoryID);
                        int nMaxDCRVersion = oBLDCR.GetDCRNewVersion(oConnection, myTransaction);

                        for (int i = 0; i < dtPVPDetail.Rows.Count; i++)
                        {

                            //int nMaxDCRID = oBLDCR.GetDCRID(oConnection, myTransaction);

                            //oDCR.ID.SetID(nMaxDCRID);
                            oDCR = new DCR();
                            oDCR.PvpDetailID = Convert.ToInt32(dtPVPDetail.Rows[i]["DetailID"].ToString());
                            oDCR.DoctorID = Convert.ToInt32(dtPVPDetail.Rows[i]["DoctorID"].ToString());
                            oDCR.TerritoryID = dtPVPDetail.Rows[i]["TerritoryID"].ToString();
                            oDCR.Day = Convert.ToInt32(dtPVPDetail.Rows[i]["Day"].ToString());
                            oDCR.Month = Convert.ToInt32(dtPVPDetail.Rows[i]["Month"].ToString());
                            oDCR.Year = Convert.ToInt32(dtPVPDetail.Rows[i]["Year"].ToString());
                            oDCR.IsVisited = false;
                            oDCR.IsAvailable = true;
                            oDCR.Session = dtPVPDetail.Rows[i]["Session"].ToString();
                            oDCR.Version = nMaxDCRVersion;
                            oDCR.Action = 1;
                            oDCR.Status = 1;

                            if (oDCR.Session == "Both")
                            {
                                oDCR.Session = "Morning";
                                oBLDCR.Save(oDCR, oConnection, myTransaction);

                                oDCR = new DCR();
                                oDCR.PvpDetailID = Convert.ToInt32(dtPVPDetail.Rows[i]["DetailID"].ToString());
                                oDCR.DoctorID = Convert.ToInt32(dtPVPDetail.Rows[i]["DoctorID"].ToString());
                                oDCR.TerritoryID = dtPVPDetail.Rows[i]["TerritoryID"].ToString();
                                oDCR.Day = Convert.ToInt32(dtPVPDetail.Rows[i]["Day"].ToString());
                                oDCR.Month = Convert.ToInt32(dtPVPDetail.Rows[i]["Month"].ToString());
                                oDCR.Year = Convert.ToInt32(dtPVPDetail.Rows[i]["Year"].ToString());
                                oDCR.IsVisited = false;
                                oDCR.IsAvailable = true;
                                oDCR.Session = "Evening";
                                oDCR.Version = nMaxDCRVersion;
                                oDCR.Action = 1;
                                oDCR.Status = 1;
                                //nMaxDCRID = oBLDCR.GetDCRID(oConnection, myTransaction);
                                //oDCR.ID.SetID(nMaxDCRID);
                                oBLDCR.Save(oDCR, oConnection, myTransaction);
                            }

                            else
                            {
                                oBLDCR.Save(oDCR, oConnection, myTransaction);
                            }
                        }

                        string sSFGDDBID = oBLEmployeeInfo.GetGDDBIDByTerritoryID(oConnection, myTransaction, sTerritoryID);
                        oUserInfo = new UserInfo();
                        oUserInfo = oBLUserInfo.GetUserInfo(sSFGDDBID, connectionString);
                        oUserInfo.Version = oUserInfo.Version + 1;
                        oUserInfo.PVPVersion = oUserInfo.PVPVersion + 1;
                        oUserInfo.DCRVersion = oUserInfo.DCRVersion + 1;
                        oUserInfo.LastUpdateDate = DateTime.Now;
                        oBLUserInfo.Save(oUserInfo, oConnection, myTransaction);

                        //string sRMGDDBID = oBLEmployeeInfo.GetGDDBIDByTerritoryID(oConnection, myTransaction, sTerritoryID.Substring(0, 6));
                        oBLUserInfo.UpdateRMUserInfo(sApprovedBy, oConnection, myTransaction);
                        //oUserInfo = new UserInfo();
                        //oUserInfo = oBLUserInfo.GetUserInfo(sRMGDDBID, connectionString);
                        //oUserInfo.Version = oUserInfo.Version + 1;
                        //oUserInfo.DCRVersion = oUserInfo.DCRVersion + 1;
                        //oBLUserInfo.Save(oUserInfo, oConnection, myTransaction);

                        //int nMaxPVPVersion = oBLPVPMaster.GetMaxPVPVersion(oConnection, myTransaction, sTerritoryID);
                        int nMaxPVPVersion = oBLPVPMaster.GetMaxPVPVersion(oConnection, myTransaction);
                        oPVPMaster = oBLPVPMaster.GetPVPMasterInfo(sTerritoryID, nMonth, nYear, connectionString);
                        oPVPMaster.Status = PVPStatus.Approved;
                        oPVPMaster.ApprovedDate = DateTime.Now;
                        oPVPMaster.ApprovedBy = sApprovedBy;
                        oPVPMaster.Version = nMaxPVPVersion;
                        oPVPMaster.Action = 2;
                        oBLPVPMaster.Save(oPVPMaster, oConnection, myTransaction);

                        oBLPVPMaster.InsertPVPCommandInfo(sTerritoryID, 3, oConnection, myTransaction);

                        sAuthenticket = "1";
                    }
                    else
                    {
                        sAuthenticket = "-1";
                    }
                    myTransaction.Commit();
                }

                catch (Exception e)
                {
                    sAuthenticket = e.Message.ToString();
                    myTransaction.Rollback();
                }
                finally
                {
                    oConnection.Close();
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                    sAuthenticket = "Cannot connect to database.";
                else
                    sAuthenticket = ex.Message.ToString();
                //throw new Exception(ex.Message);
            }
            return sAuthenticket;
        }

        //[WebMethod(Description = "Method to InsertDCRData")]
        //public int InsertDCRData(string sTerritoryID)
        //{
        //    PVPDetail oPVPDetail = new PVPDetail();
        //    PVPMaster oPVPMaster = new PVPMaster();
        //    PVPMonthCycle oPVPMonthCycle = new PVPMonthCycle();
        //    DCR oDCR = new DCR();
        //    UserInfo oUserInfo = new UserInfo();
        //    EmployeeInfo oEmployeeInfo = new EmployeeInfo();
        //    BLDCR oBLDCR = new BLDCR();
        //    BLUserInfo oBLUserInfo = new BLUserInfo();
        //    BLEmployeeInfo oBLEmployeeInfo = new BLEmployeeInfo();
        //    BLPVPMaster oBLPVPMaster = new BLPVPMaster();
        //    BLPVPDetail oBLPVPDetail = new BLPVPDetail();
        //    BLPVPMonthCycle oBLPVPMonthCycle = new BLPVPMonthCycle();
        //    BLCommandInfo oBLCommandInfo = new BLCommandInfo();

        //    int nAuthenticket = 0;
        //    try
        //    {

        //        //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
        //        NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
        //        string connectionString = oValues["ConnectionString2"].ToString();

        //        // SqlConnection myConnection = new SqlConnection(connectionString);
        //        SqlConnection oConnection = new SqlConnection(connectionString);
        //        oConnection.Open();

        //        DataSet oPvpDetail = new DataSet();
        //        SqlDataAdapter oAdapter = new SqlDataAdapter();
        //        SqlCommand oCommand = new SqlCommand();

        //        //oConnection.ConnectionString = connectionString;
        //        SqlTransaction myTransaction = oConnection.BeginTransaction();
        //        oCommand.Transaction = myTransaction;
        //        //oCommand.CommandTimeout = 0;

        //        try
        //        {
        //            oPVPMonthCycle = oBLPVPMonthCycle.GetPVPMonthCycle(connectionString);
        //            int nMonth = oPVPMonthCycle.Month;
        //            int nYear = oPVPMonthCycle.Year;
        //            DateTime dPVPEndDate = oPVPMonthCycle.EndDate;
        //            DateTime dCurrentDate = DateTime.Now.Date;

        //            bool bIsPVPOpen = false;
        //            if (dCurrentDate <= dPVPEndDate)
        //                bIsPVPOpen = true;
        //            if (!bIsPVPOpen)
        //            {
        //                //string sPVPEndDate = dCurrentDate.ToString("dd MMM yyyy");
        //                //bIsPVPOpen = oBLCommandInfo.IsPVPTimeExtend(oConnection, myTransaction, sTerritoryID.Substring(0,6), sPVPEndDate);
        //                string sPVPEndDate = oBLCommandInfo.GetPVPEndDate(oConnection, myTransaction, sTerritoryID.Substring(0, 6));
        //                if (sPVPEndDate != "")
        //                    dPVPEndDate = Convert.ToDateTime(sPVPEndDate);
        //                if (dCurrentDate <= dPVPEndDate)
        //                    bIsPVPOpen = true;
        //            }

        //            if (bIsPVPOpen)
        //            {
        //                DataTable dtPVPDetail = new DataTable();
        //                dtPVPDetail = oBLPVPDetail.GetPVPDetailInfo(sTerritoryID, nMonth, nYear, connectionString);

        //                //int nMaxDCRVersion = oBLDCR.GetDCRNewVersion(oConnection, myTransaction, sTerritoryID);
        //                int nMaxDCRVersion = oBLDCR.GetDCRNewVersion(oConnection, myTransaction);

        //                for (int i = 0; i < dtPVPDetail.Rows.Count; i++)
        //                {

        //                    //int nMaxDCRID = oBLDCR.GetDCRID(oConnection, myTransaction);

        //                    //oDCR.ID.SetID(nMaxDCRID);
        //                    oDCR = new DCR();
        //                    oDCR.PvpDetailID = Convert.ToInt32(dtPVPDetail.Rows[i]["DetailID"].ToString());
        //                    oDCR.DoctorID = Convert.ToInt32(dtPVPDetail.Rows[i]["DoctorID"].ToString());
        //                    oDCR.TerritoryID = dtPVPDetail.Rows[i]["TerritoryID"].ToString();
        //                    oDCR.Day = Convert.ToInt32(dtPVPDetail.Rows[i]["Day"].ToString());
        //                    oDCR.Month = Convert.ToInt32(dtPVPDetail.Rows[i]["Month"].ToString());
        //                    oDCR.Year = Convert.ToInt32(dtPVPDetail.Rows[i]["Year"].ToString());
        //                    oDCR.IsVisited = false;
        //                    oDCR.IsAvailable = true;
        //                    oDCR.Session = dtPVPDetail.Rows[i]["Session"].ToString();
        //                    oDCR.Version = nMaxDCRVersion;
        //                    oDCR.Action = 1;
        //                    oDCR.Status = 1;

        //                    if (oDCR.Session == "Both")
        //                    {
        //                        oDCR.Session = "Morning";
        //                        oBLDCR.Save(oDCR, oConnection, myTransaction);

        //                        oDCR = new DCR();
        //                        oDCR.PvpDetailID = Convert.ToInt32(dtPVPDetail.Rows[i]["DetailID"].ToString());
        //                        oDCR.DoctorID = Convert.ToInt32(dtPVPDetail.Rows[i]["DoctorID"].ToString());
        //                        oDCR.TerritoryID = dtPVPDetail.Rows[i]["TerritoryID"].ToString();
        //                        oDCR.Day = Convert.ToInt32(dtPVPDetail.Rows[i]["Day"].ToString());
        //                        oDCR.Month = Convert.ToInt32(dtPVPDetail.Rows[i]["Month"].ToString());
        //                        oDCR.Year = Convert.ToInt32(dtPVPDetail.Rows[i]["Year"].ToString());
        //                        oDCR.IsVisited = false;
        //                        oDCR.IsAvailable = true;
        //                        oDCR.Session = "Evening";
        //                        oDCR.Version = nMaxDCRVersion;
        //                        oDCR.Action = 1;
        //                        oDCR.Status = 1;
        //                        //nMaxDCRID = oBLDCR.GetDCRID(oConnection, myTransaction);
        //                        //oDCR.ID.SetID(nMaxDCRID);
        //                        oBLDCR.Save(oDCR, oConnection, myTransaction);
        //                    }

        //                    else
        //                    {
        //                        oBLDCR.Save(oDCR, oConnection, myTransaction);
        //                    }
        //                }

        //                string sSFGDDBID = oBLEmployeeInfo.GetGDDBIDByTerritoryID(oConnection, myTransaction, sTerritoryID);
        //                oUserInfo = new UserInfo();
        //                oUserInfo = oBLUserInfo.GetUserInfo(sSFGDDBID, connectionString);
        //                oUserInfo.Version = oUserInfo.Version + 1;
        //                oUserInfo.PVPVersion = oUserInfo.PVPVersion + 1;
        //                oUserInfo.DCRVersion = oUserInfo.DCRVersion + 1;
        //                oBLUserInfo.Save(oUserInfo, oConnection, myTransaction);

        //                string sRMGDDBID = oBLEmployeeInfo.GetGDDBIDByTerritoryID(oConnection, myTransaction, sTerritoryID.Substring(0, 6));
        //                oBLUserInfo.UpdateRMUserInfo(sRMGDDBID, oConnection, myTransaction);
        //                //oUserInfo = new UserInfo();
        //                //oUserInfo = oBLUserInfo.GetUserInfo(sRMGDDBID, connectionString);
        //                //oUserInfo.Version = oUserInfo.Version + 1;
        //                //oUserInfo.DCRVersion = oUserInfo.DCRVersion + 1;
        //                //oBLUserInfo.Save(oUserInfo, oConnection, myTransaction);

        //                //int nMaxPVPVersion = oBLPVPMaster.GetMaxPVPVersion(oConnection, myTransaction, sTerritoryID);
        //                int nMaxPVPVersion = oBLPVPMaster.GetMaxPVPVersion(oConnection, myTransaction);
        //                oPVPMaster = oBLPVPMaster.GetPVPMasterInfo(sTerritoryID, nMonth, nYear, connectionString);
        //                oPVPMaster.Status = PVPStatus.Approved;
        //                oPVPMaster.ApprovedDate = DateTime.Now;
        //                oPVPMaster.ApprovedBy = sRMGDDBID;
        //                oPVPMaster.Version = nMaxPVPVersion;
        //                oPVPMaster.Action = 2;
        //                oBLPVPMaster.Save(oPVPMaster, oConnection, myTransaction);

        //                nAuthenticket++;
        //            }
        //            else
        //            {
        //                nAuthenticket = -1;
        //            }
        //            myTransaction.Commit();
        //        }

        //        catch (Exception e)
        //        {
        //            myTransaction.Rollback();
        //        }
        //        finally
        //        {
        //            oConnection.Close();
        //        }

        //        return nAuthenticket;
        //    }

        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //}

        [WebMethod(Description = "Method to Update DCRStatusByRM")]
        public string UpdateDCRStatusByRM(int nDCRID, int nIsAccompanyByRM_RM, string sRejectReason, int nDCRStatus, string sApprovedBy)
        {

            DCR oDCR = new DCR();
            UserInfo oUserInfo = new UserInfo();
            EmployeeInfo oEmployeeInfo = new EmployeeInfo();
            AppConfigurationInfo oAppConfigInfo = new AppConfigurationInfo();
            BLDCR oBLDCR = new BLDCR();
            BLUserInfo oBLUserInfo = new BLUserInfo();
            BLEmployeeInfo oBLEmployeeInfo = new BLEmployeeInfo();
            BLAppConfigurationInfo oBLAppConfig = new BLAppConfigurationInfo();
            BLCommandInfo oBLCommandInfo = new BLCommandInfo();
            string sUpdateDCR = "";

            try
            {
                //string sconnectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string sconnectionString = oValues["ConnectionString2"].ToString();

                SqlConnection oConnection = new SqlConnection(sconnectionString);
                oConnection.Open();
                //Start transaction.
                SqlTransaction oTransaction = oConnection.BeginTransaction();
                //Assign command in the current transaction.
                SqlCommand oCommand = new SqlCommand();
                oCommand.Transaction = oTransaction;

                try
                {
                    int nUserID = 0;
                    nUserID = oBLUserInfo.GetActiveUserIDBYGDDBID(oConnection, oTransaction, sApprovedBy);
                    if (nUserID > 0)
                    {
                        oDCR = new DCR();
                        oDCR = oBLDCR.GetDCR(nDCRID, sconnectionString);

                        oAppConfigInfo = oBLAppConfig.GetAppConfigurationInfo(oDCR.TerritoryID.Substring(0,6), sconnectionString);
                        int nDCREntryHours = oAppConfigInfo.DCRApprovalHours;
                        DateTime dDCRDate = new DateTime(oDCR.Year, oDCR.Month, oDCR.Day);
                        dDCRDate = dDCRDate.AddHours(nDCREntryHours);
                        DateTime dCurrentDate = DateTime.Now;

                        bool bIsDCROpen = false;
                        if (dCurrentDate <= dDCRDate)
                            bIsDCROpen = true;
                        //if (!bIsDCROpen)
                        //{
                        //    nDCREntryHours = oBLCommandInfo.GetDCREntryHours(oConnection, oTransaction, oDCR.TerritoryID.Substring(0, 6));
                        //    dDCRDate = new DateTime(oDCR.Year, oDCR.Month, oDCR.Day);
                        //    dDCRDate = dDCRDate.AddHours(nDCREntryHours);
                        //    if (dCurrentDate <= dDCRDate)
                        //        bIsDCROpen = true;
                        //}

                        if (bIsDCROpen)
                        {

                            oDCR.Status = nDCRStatus;
                            oDCR.IsAccompanyByRM_RM = Convert.ToBoolean(nIsAccompanyByRM_RM);
                            if (nDCRStatus == 5)
                                oDCR.RejectReason = sRejectReason;
                            oDCR.ApprovedBy = nUserID;
                            oDCR.ApprovedDateTime = DateTime.Now;
                            //oDCR.Version = oBLDCR.GetDCRNewVersion(oConnection, oTransaction, oDCR.TerritoryID);
                            oDCR.Version = oBLDCR.GetDCRNewVersion(oConnection, oTransaction);
                            oDCR.Action = 2;
                            oBLDCR.Save(oDCR, oConnection, oTransaction);

                            //oUserInfo = new UserInfo();
                            //oUserInfo = oBLUserInfo.GetUserInfo(sApprovedBy, sconnectionString);

                            //oUserInfo.Version = oUserInfo.Version + 1;
                            //oUserInfo.PVPVersion = oUserInfo.PVPVersion + 1;
                            //int nRMAuthenticket = oBLUserInfo.Save(oUserInfo, oConnection, oTransaction);

                            string sSFGDDBID = oBLEmployeeInfo.GetGDDBIDByTerritoryID(oConnection, oTransaction, oDCR.TerritoryID);

                            oUserInfo = new UserInfo();
                            oUserInfo = oBLUserInfo.GetUserInfo(sSFGDDBID, sconnectionString);
                            oUserInfo.Version = oUserInfo.Version + 1;
                            oUserInfo.DCRVersion = oUserInfo.DCRVersion + 1;
                            oUserInfo.LastUpdateDate = DateTime.Now;
                            int nSFAuthenticket = oBLUserInfo.Save(oUserInfo, oConnection, oTransaction);

                            sUpdateDCR = "1";
                        }
                        else
                        {
                            sUpdateDCR = "-1";
                            DCRLateApprovalLog oDCRLateApprovalLog = new DCRLateApprovalLog();
                            BLDCRLateApprovalLog oBLDCRLateApprovalLog = new BLDCRLateApprovalLog();
                            oDCRLateApprovalLog.RegionID = oDCR.TerritoryID.Substring(0,6);
                            oDCRLateApprovalLog.TerritoryID = oDCR.TerritoryID;
                            oDCRLateApprovalLog.DCRDetail = oDCR.ID.ToInt32.ToString();
                            oDCRLateApprovalLog.Day = oDCR.Day;
                            oDCRLateApprovalLog.Month = oDCR.Month;
                            oDCRLateApprovalLog.Year = oDCR.Year;                    
                            oDCRLateApprovalLog.ApprovedDateTime = DateTime.Now;
                            oDCRLateApprovalLog.ApprovedBy = sApprovedBy;
                            oBLDCRLateApprovalLog.Save(oDCRLateApprovalLog, oConnection, oTransaction);
                        }
                        // ……………………
                        oTransaction.Commit();
                    }
                }
                catch (Exception e)
                {
                    sUpdateDCR = e.Message.ToString();
                    oTransaction.Rollback();
                    //sUpdateDCR = "0";
                }
                finally
                {
                    oConnection.Close();
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                    sUpdateDCR = "Cannot connect to database.";
                else
                    sUpdateDCR = ex.Message.ToString();
                //throw new Exception(ex.Message);
            }

            return sUpdateDCR;
        }

        //[WebMethod(Description = "Method to Insert Data in DCR")]
        //public  void GetInsertTerritoryWiseDCRRM(string sTerritoryID)
        //{
        //    BLDCR oBL = new BLDCR();
        //    try
        //    {
        //     oBL.GetTerritoryWisePVPDetail(sTerritoryID);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //[WebMethod(Description = "Method to Insert DCR Data")]
        //public int InsertDCRData(string sTerritoryID)
        //{
        //    PVPDetail oPVPDetail = new PVPDetail();
        //    PVPMaster oPVPMaster = new PVPMaster();
        //    PVPMonthCycle oPVPMonthCycle = new PVPMonthCycle();
        //    DCR oDCR = new DCR();
        //    UserInfo oUserInfo = new UserInfo();
        //    EmployeeInfo oEmployeeInfo = new EmployeeInfo();
        //    BLDCR oBLDCR = new BLDCR();
        //    BLUserInfo oBLUserInfo = new BLUserInfo();
        //    BLEmployeeInfo oBLEmployeeInfo = new BLEmployeeInfo();
        //    BLPVPMaster oBLPVPMaster = new BLPVPMaster();
        //    BLPVPDetail oBLPVPDetail = new BLPVPDetail();
        //    BLPVPMonthCycle oBLPVPMonthCycle = new BLPVPMonthCycle();

        //    int nAuthenticket = 0;
        //    try
        //    {

        //        //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
        //        NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
        //        string connectionString = oValues["ConnectionString2"].ToString();

        //        // SqlConnection myConnection = new SqlConnection(connectionString);
        //        SqlConnection oConnection = new SqlConnection(connectionString);
        //        oConnection.Open();

        //        DataSet oPvpDetail = new DataSet();
        //        SqlDataAdapter oAdapter = new SqlDataAdapter();
        //        SqlCommand oCommand = new SqlCommand();

        //        //oConnection.ConnectionString = connectionString;
        //        SqlTransaction myTransaction = oConnection.BeginTransaction();
        //        oCommand.Transaction = myTransaction;
        //        oCommand.CommandTimeout = 0;

        //        DataTable otblPVPMonthCycle = new DataTable();
        //        string sPVPMonthCycle = "SELECT * FROM [PVPMonthCycle] WHERE IsActive=1";
        //        SqlDataAdapter Sfda = new SqlDataAdapter(sPVPMonthCycle, connectionString);
        //        Sfda.Fill(otblPVPMonthCycle);
        //        int nMonth = Convert.ToInt32(otblPVPMonthCycle.Rows[0]["Month"]);
        //        int nYear = Convert.ToInt32(otblPVPMonthCycle.Rows[0]["Year"]);

        //        oAdapter = new SqlDataAdapter(oCommand);
        //        oPvpDetail.Reset();
        //        oCommand.CommandType = CommandType.Text;
        //        oCommand.Connection = oConnection;
        //        oCommand.CommandText = "Select * FROM [PVPDetail] where month=" + nMonth + " and year=" + nYear + " and IsHoliday=0 and TerritoryID= '" + sTerritoryID + "'";
        //        oAdapter.Fill(oPvpDetail);

        //        DataTable dtPVPDetail = new DataTable();
        //        dtPVPDetail = oPvpDetail.Tables[0];

        //        SqlCommand cmd6 = new SqlCommand();
        //        cmd6.CommandText = "SELECT MAX(Version)+1 AS Version FROM [DCR] where TerritoryID like '" + sTerritoryID.Substring(0, 6) + "%'";
        //        cmd6.Connection = oConnection;
        //        cmd6.Transaction = myTransaction;
        //        object oversion = cmd6.ExecuteScalar();
        //        int nVersion = 0;
        //        if (oversion == DBNull.Value)
        //        {
        //            nVersion = 1;
        //        }
        //        else
        //        {
        //            nVersion = Convert.ToInt32(oversion);
        //        }

        //        int nMaxDCRVersion = oBLDCR.GetDCRNewVersion(oConnection, myTransaction, sTerritoryID);

        //        string sql = "";
        //        for (int i = 0; i < dtPVPDetail.Rows.Count; i++)
        //        {

        //            SqlCommand cmd7 = new SqlCommand();
        //            cmd7.CommandText = "SELECT MAX(DcrID)+ 1 AS DcrID FROM [DCR]";
        //            cmd7.Connection = oConnection;
        //            cmd7.Transaction = myTransaction;
        //            object oDCRID = cmd7.ExecuteScalar();
        //            int noDCRID = 0;
        //            if (oDCRID == DBNull.Value)
        //            {
        //                noDCRID = 1;
        //            }
        //            else
        //            {
        //                noDCRID = Convert.ToInt32(oDCRID);
        //            }

        //            int nMaxDCRID = oBLDCR.GetDCRID(oConnection, myTransaction);

        //            //oDcr.DcrID. = noDCRID;
        //            oDCR.ID.SetID(nMaxDCRID);
        //            oDCR.PvpDetailID = Convert.ToInt32(dtPVPDetail.Rows[i]["DetailID"].ToString());
        //            oDCR.DoctorID = Convert.ToInt32(dtPVPDetail.Rows[i]["DoctorID"].ToString());
        //            oDCR.TerritoryID = dtPVPDetail.Rows[i]["TerritoryID"].ToString();
        //            oDCR.Day = Convert.ToInt32(dtPVPDetail.Rows[i]["Day"].ToString());
        //            oDCR.Month = Convert.ToInt32(dtPVPDetail.Rows[i]["Month"].ToString());
        //            oDCR.Year = Convert.ToInt32(dtPVPDetail.Rows[i]["Year"].ToString());
        //            oDCR.IsVisited = false;
        //            oDCR.IsAvailable = true;
        //            oDCR.Session = dtPVPDetail.Rows[i]["Session"].ToString();
        //            //oDcr.Brand1 = Convert.ToInt32(dt.Rows[i]["Brand1"].ToString());
        //            //oDcr.Brand2 = Convert.ToInt32(dt.Rows[i]["Brand2"].ToString());
        //            //oDcr.Brand3 = Convert.ToInt32(dt.Rows[i]["Brand3"].ToString());
        //            //oDcr.Brand4 = Convert.ToInt32(dt.Rows[i]["Brand4"].ToString());
        //            //oDcr.Brand5 = Convert.ToInt32(dt.Rows[i]["Brand5"].ToString());
        //            //oDcr.Brand6 = Convert.ToInt32(dt.Rows[i]["Brand6"].ToString());
        //            oDCR.Version = nMaxDCRVersion;
        //            oDCR.Action = 1;
        //            oDCR.Status = 1;

        //            if (oDCR.Session == "Both")
        //            {
        //                oDCR.Session = "Morning";

        //                sql = SQL.MakeSQL("INSERT INTO [DCR](DcrID, PvpDetailID, DoctorID, TerritoryID, Day, Month, Year, Status, VisitDateTime, IsVisited, IsAvailable, IsAccompanyByRM_RM, IsAccompanyByRM_SF, ReminderNextCall, NotAvailableReasonID, NotAvailableReason, IsNewVisit, Session, Brand1, Brand1Gimmick1, Brand1Gimmick2, Brand1Gimmick3, Brand1Sample1, Brand1Sample2, Brand1Sample3, Brand1Gimmick1Qty, Brand1Gimmick2Qty, Brand1Gimmick3Qty, Brand1Sample1Qty, Brand1Sample2Qty, Brand1Sample3Qty, Brand2, Brand2Gimmick1, Brand2Gimmick2, Brand2Gimmick3, Brand2Sample1, Brand2Sample2, Brand2Sample3, Brand2Gimmick1Qty, Brand2Gimmick2Qty, Brand2Gimmick3Qty, Brand2Sample1Qty, Brand2Sample2Qty, Brand2Sample3Qty, Brand3, Brand3Gimmick1, Brand3Gimmick2, Brand3Gimmick3, Brand3Sample1, Brand3Sample2, Brand3Sample3, Brand3Gimmick1Qty, Brand3Gimmick2Qty, Brand3Gimmick3Qty, Brand3Sample1Qty, Brand3Sample2Qty, Brand3Sample3Qty, Brand4, Brand4Gimmick1, Brand4Gimmick2, Brand4Gimmick3, Brand4Sample1, Brand4Sample2, Brand4Sample3, Brand4Gimmick1Qty, Brand4Gimmick2Qty, Brand4Gimmick3Qty, Brand4Sample1Qty, Brand4Sample2Qty, Brand4Sample3Qty, Brand5, Brand5Gimmick1, Brand5Gimmick2, Brand5Gimmick3, Brand5Sample1, Brand5Sample2, Brand5Sample3, Brand5Gimmick1Qty, Brand5Gimmick2Qty, Brand5Gimmick3Qty, Brand5Sample1Qty, Brand5Sample2Qty, Brand5Sample3Qty, Brand6, Brand6Gimmick1, Brand6Gimmick2, Brand6Gimmick3, Brand6Sample1, Brand6Sample2, Brand6Sample3, Brand6Gimmick1Qty, Brand6Gimmick2Qty, Brand6Gimmick3Qty, Brand6Sample1Qty, Brand6Sample2Qty, Brand6Sample3Qty, SubmitDateTime, ApprovedDateTime, SubmittedBy, ApprovedBy, Action, Version,SMSDCRNo,IsSendSMS,RejectReason) "
        //                + " VALUES(%n, %n, %n, %s, %n, %n, %n, %n, %D, %b, %b, %b, %b, %s, %n, %s, %b, %s, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n,%n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n,%n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n,%n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %D, %D, %n, %n, %n, %n,%s,%b,%s) "
        //                  , oDCR.ID.ToInt32, oDCR.PvpDetailID, oDCR.DoctorID, oDCR.TerritoryID, oDCR.Day, oDCR.Month, oDCR.Year, oDCR.Status, oDCR.VisitDateTime, oDCR.IsVisited, oDCR.IsAvailable, oDCR.IsAccompanyByRM_RM, oDCR.IsAccompanyByRM_SF, oDCR.ReminderNextCall, oDCR.NotAvailableReasonID, oDCR.NotAvailableReason, oDCR.IsNewVisit, oDCR.Session
        //                  , oDCR.Brand1, oDCR.Brand1Gimmick1, oDCR.Brand1Gimmick2, oDCR.Brand1Gimmick3, oDCR.Brand1Sample1, oDCR.Brand1Sample2, oDCR.Brand1Sample3, oDCR.Brand1Gimmick1Qty, oDCR.Brand1Gimmick2Qty, oDCR.Brand1Gimmick3Qty, oDCR.Brand1Sample1Qty, oDCR.Brand1Sample2Qty, oDCR.Brand1Sample3Qty, oDCR.Brand2,
        //                  oDCR.Brand2Gimmick1, oDCR.Brand2Gimmick2, oDCR.Brand2Gimmick3, oDCR.Brand2Sample1, oDCR.Brand2Sample2, oDCR.Brand2Sample3, oDCR.Brand2Gimmick1Qty, oDCR.Brand2Gimmick2Qty, oDCR.Brand2Gimmick3Qty, oDCR.Brand2Sample1Qty, oDCR.Brand2Sample2Qty, oDCR.Brand2Sample3Qty, oDCR.Brand3,
        //                  oDCR.Brand3Gimmick1, oDCR.Brand3Gimmick2, oDCR.Brand3Gimmick3, oDCR.Brand3Sample1, oDCR.Brand3Sample2, oDCR.Brand3Sample3, oDCR.Brand3Gimmick1Qty, oDCR.Brand3Gimmick2Qty, oDCR.Brand3Gimmick3Qty, oDCR.Brand3Sample1Qty, oDCR.Brand3Sample2Qty, oDCR.Brand3Sample3Qty, oDCR.Brand4,
        //                  oDCR.Brand4Gimmick1, oDCR.Brand4Gimmick2, oDCR.Brand4Gimmick3, oDCR.Brand4Sample1, oDCR.Brand4Sample2, oDCR.Brand4Sample3, oDCR.Brand4Gimmick1Qty, oDCR.Brand4Gimmick2Qty, oDCR.Brand4Gimmick3Qty, oDCR.Brand4Sample1Qty, oDCR.Brand4Sample2Qty, oDCR.Brand4Sample3Qty, oDCR.Brand5,
        //                   oDCR.Brand5Gimmick1, oDCR.Brand5Gimmick2, oDCR.Brand5Gimmick3, oDCR.Brand5Sample1, oDCR.Brand5Sample2, oDCR.Brand5Sample3, oDCR.Brand5Gimmick1Qty, oDCR.Brand5Gimmick2Qty, oDCR.Brand5Gimmick3Qty, oDCR.Brand5Sample1Qty, oDCR.Brand5Sample2Qty, oDCR.Brand5Sample3Qty, oDCR.Brand6,
        //                   oDCR.Brand6Gimmick1, oDCR.Brand6Gimmick2, oDCR.Brand6Gimmick3, oDCR.Brand6Sample1, oDCR.Brand6Sample2, oDCR.Brand6Sample3, oDCR.Brand6Gimmick1Qty, oDCR.Brand6Gimmick2Qty, oDCR.Brand6Gimmick3Qty, oDCR.Brand6Sample1Qty, oDCR.Brand6Sample2Qty, oDCR.Brand6Sample3Qty, oDCR.SubmitDateTime, oDCR.ApprovedDateTime, oDCR.SubmittedBy, oDCR.ApprovedBy, oDCR.Action, oDCR.Version, oDCR.SMSDCRNo, oDCR.IsSendSMS, oDCR.RejectReason);
        //                SqlDataAdapter oAdapter0 = new SqlDataAdapter();
        //                SqlCommand cmd8 = new SqlCommand();
        //                cmd8 = new SqlCommand(sql, oConnection);
        //                cmd8.Transaction = myTransaction;
        //                oAdapter0.InsertCommand = cmd8;
        //                cmd8.ExecuteNonQuery();

        //                oDCR.Session = "Evening";

        //                SqlCommand cmd13 = new SqlCommand();
        //                cmd13.CommandText = "SELECT MAX(DcrID)+ 1 AS DcrID FROM [DCR]";
        //                cmd13.Connection = oConnection;
        //                cmd13.Transaction = myTransaction;
        //                object oDCRID1 = cmd13.ExecuteScalar();
        //                int noDCRID1 = 0;
        //                if (oDCRID1 == DBNull.Value)
        //                {
        //                    noDCRID1 = 1;
        //                }
        //                else
        //                {
        //                    noDCRID1 = Convert.ToInt32(oDCRID1);
        //                }

        //                oDCR.ID.SetID(nMaxDCRID);
        //                sql = SQL.MakeSQL("INSERT INTO [DCR](DcrID, PvpDetailID, DoctorID, TerritoryID, Day, Month, Year, Status, VisitDateTime, IsVisited, IsAvailable, IsAccompanyByRM_RM, IsAccompanyByRM_SF, ReminderNextCall, NotAvailableReasonID, NotAvailableReason, IsNewVisit, Session, Brand1, Brand1Gimmick1, Brand1Gimmick2, Brand1Gimmick3, Brand1Sample1, Brand1Sample2, Brand1Sample3, Brand1Gimmick1Qty, Brand1Gimmick2Qty, Brand1Gimmick3Qty, Brand1Sample1Qty, Brand1Sample2Qty, Brand1Sample3Qty, Brand2, Brand2Gimmick1, Brand2Gimmick2, Brand2Gimmick3, Brand2Sample1, Brand2Sample2, Brand2Sample3, Brand2Gimmick1Qty, Brand2Gimmick2Qty, Brand2Gimmick3Qty, Brand2Sample1Qty, Brand2Sample2Qty, Brand2Sample3Qty, Brand3, Brand3Gimmick1, Brand3Gimmick2, Brand3Gimmick3, Brand3Sample1, Brand3Sample2, Brand3Sample3, Brand3Gimmick1Qty, Brand3Gimmick2Qty, Brand3Gimmick3Qty, Brand3Sample1Qty, Brand3Sample2Qty, Brand3Sample3Qty, Brand4, Brand4Gimmick1, Brand4Gimmick2, Brand4Gimmick3, Brand4Sample1, Brand4Sample2, Brand4Sample3, Brand4Gimmick1Qty, Brand4Gimmick2Qty, Brand4Gimmick3Qty, Brand4Sample1Qty, Brand4Sample2Qty, Brand4Sample3Qty, Brand5, Brand5Gimmick1, Brand5Gimmick2, Brand5Gimmick3, Brand5Sample1, Brand5Sample2, Brand5Sample3, Brand5Gimmick1Qty, Brand5Gimmick2Qty, Brand5Gimmick3Qty, Brand5Sample1Qty, Brand5Sample2Qty, Brand5Sample3Qty, Brand6, Brand6Gimmick1, Brand6Gimmick2, Brand6Gimmick3, Brand6Sample1, Brand6Sample2, Brand6Sample3, Brand6Gimmick1Qty, Brand6Gimmick2Qty, Brand6Gimmick3Qty, Brand6Sample1Qty, Brand6Sample2Qty, Brand6Sample3Qty, SubmitDateTime, ApprovedDateTime, SubmittedBy, ApprovedBy, Action, Version,SMSDCRNo,IsSendSMS,RejectReason) "
        //             + " VALUES(%n, %n, %n, %s, %n, %n, %n, %n, %D, %b, %b, %b, %b, %s, %n, %s, %b, %s, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n,%n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n,%n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n,%n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %D, %D, %n, %n, %n, %n,%s,%b,%s) "
        //               , oDCR.ID.ToInt32, oDCR.PvpDetailID, oDCR.DoctorID, oDCR.TerritoryID, oDCR.Day, oDCR.Month, oDCR.Year, oDCR.Status, oDCR.VisitDateTime, oDCR.IsVisited, oDCR.IsAvailable, oDCR.IsAccompanyByRM_RM, oDCR.IsAccompanyByRM_SF, oDCR.ReminderNextCall, oDCR.NotAvailableReasonID, oDCR.NotAvailableReason, oDCR.IsNewVisit, oDCR.Session
        //               , oDCR.Brand1, oDCR.Brand1Gimmick1, oDCR.Brand1Gimmick2, oDCR.Brand1Gimmick3, oDCR.Brand1Sample1, oDCR.Brand1Sample2, oDCR.Brand1Sample3, oDCR.Brand1Gimmick1Qty, oDCR.Brand1Gimmick2Qty, oDCR.Brand1Gimmick3Qty, oDCR.Brand1Sample1Qty, oDCR.Brand1Sample2Qty, oDCR.Brand1Sample3Qty, oDCR.Brand2,
        //               oDCR.Brand2Gimmick1, oDCR.Brand2Gimmick2, oDCR.Brand2Gimmick3, oDCR.Brand2Sample1, oDCR.Brand2Sample2, oDCR.Brand2Sample3, oDCR.Brand2Gimmick1Qty, oDCR.Brand2Gimmick2Qty, oDCR.Brand2Gimmick3Qty, oDCR.Brand2Sample1Qty, oDCR.Brand2Sample2Qty, oDCR.Brand2Sample3Qty, oDCR.Brand3,
        //               oDCR.Brand3Gimmick1, oDCR.Brand3Gimmick2, oDCR.Brand3Gimmick3, oDCR.Brand3Sample1, oDCR.Brand3Sample2, oDCR.Brand3Sample3, oDCR.Brand3Gimmick1Qty, oDCR.Brand3Gimmick2Qty, oDCR.Brand3Gimmick3Qty, oDCR.Brand3Sample1Qty, oDCR.Brand3Sample2Qty, oDCR.Brand3Sample3Qty, oDCR.Brand4,
        //               oDCR.Brand4Gimmick1, oDCR.Brand4Gimmick2, oDCR.Brand4Gimmick3, oDCR.Brand4Sample1, oDCR.Brand4Sample2, oDCR.Brand4Sample3, oDCR.Brand4Gimmick1Qty, oDCR.Brand4Gimmick2Qty, oDCR.Brand4Gimmick3Qty, oDCR.Brand4Sample1Qty, oDCR.Brand4Sample2Qty, oDCR.Brand4Sample3Qty, oDCR.Brand5,
        //                oDCR.Brand5Gimmick1, oDCR.Brand5Gimmick2, oDCR.Brand5Gimmick3, oDCR.Brand5Sample1, oDCR.Brand5Sample2, oDCR.Brand5Sample3, oDCR.Brand5Gimmick1Qty, oDCR.Brand5Gimmick2Qty, oDCR.Brand5Gimmick3Qty, oDCR.Brand5Sample1Qty, oDCR.Brand5Sample2Qty, oDCR.Brand5Sample3Qty, oDCR.Brand6,
        //                oDCR.Brand6Gimmick1, oDCR.Brand6Gimmick2, oDCR.Brand6Gimmick3, oDCR.Brand6Sample1, oDCR.Brand6Sample2, oDCR.Brand6Sample3, oDCR.Brand6Gimmick1Qty, oDCR.Brand6Gimmick2Qty, oDCR.Brand6Gimmick3Qty, oDCR.Brand6Sample1Qty, oDCR.Brand6Sample2Qty, oDCR.Brand6Sample3Qty, oDCR.SubmitDateTime, oDCR.ApprovedDateTime, oDCR.SubmittedBy, oDCR.ApprovedBy, oDCR.Action, oDCR.Version, oDCR.SMSDCRNo, oDCR.IsSendSMS, oDCR.RejectReason);
        //                SqlDataAdapter oAdapter2 = new SqlDataAdapter();
        //                SqlCommand cmd10 = new SqlCommand();
        //                cmd10 = new SqlCommand(sql, oConnection);
        //                cmd10.Transaction = myTransaction;
        //                oAdapter2.InsertCommand = cmd10;
        //                cmd10.ExecuteNonQuery();
        //            }

        //            else
        //            {                        
        //                sql = "";
        //                sql = SQL.MakeSQL("INSERT INTO [DCR](DcrID, PvpDetailID, DoctorID, TerritoryID, Day, Month, Year, Status, VisitDateTime, IsVisited, IsAvailable, IsAccompanyByRM_RM, IsAccompanyByRM_SF, ReminderNextCall, NotAvailableReasonID, NotAvailableReason, IsNewVisit, Session, Brand1, Brand1Gimmick1, Brand1Gimmick2, Brand1Gimmick3, Brand1Sample1, Brand1Sample2, Brand1Sample3, Brand1Gimmick1Qty, Brand1Gimmick2Qty, Brand1Gimmick3Qty, Brand1Sample1Qty, Brand1Sample2Qty, Brand1Sample3Qty, Brand2, Brand2Gimmick1, Brand2Gimmick2, Brand2Gimmick3, Brand2Sample1, Brand2Sample2, Brand2Sample3, Brand2Gimmick1Qty, Brand2Gimmick2Qty, Brand2Gimmick3Qty, Brand2Sample1Qty, Brand2Sample2Qty, Brand2Sample3Qty, Brand3, Brand3Gimmick1, Brand3Gimmick2, Brand3Gimmick3, Brand3Sample1, Brand3Sample2, Brand3Sample3, Brand3Gimmick1Qty, Brand3Gimmick2Qty, Brand3Gimmick3Qty, Brand3Sample1Qty, Brand3Sample2Qty, Brand3Sample3Qty, Brand4, Brand4Gimmick1, Brand4Gimmick2, Brand4Gimmick3, Brand4Sample1, Brand4Sample2, Brand4Sample3, Brand4Gimmick1Qty, Brand4Gimmick2Qty, Brand4Gimmick3Qty, Brand4Sample1Qty, Brand4Sample2Qty, Brand4Sample3Qty, Brand5, Brand5Gimmick1, Brand5Gimmick2, Brand5Gimmick3, Brand5Sample1, Brand5Sample2, Brand5Sample3, Brand5Gimmick1Qty, Brand5Gimmick2Qty, Brand5Gimmick3Qty, Brand5Sample1Qty, Brand5Sample2Qty, Brand5Sample3Qty, Brand6, Brand6Gimmick1, Brand6Gimmick2, Brand6Gimmick3, Brand6Sample1, Brand6Sample2, Brand6Sample3, Brand6Gimmick1Qty, Brand6Gimmick2Qty, Brand6Gimmick3Qty, Brand6Sample1Qty, Brand6Sample2Qty, Brand6Sample3Qty, SubmitDateTime, ApprovedDateTime, SubmittedBy, ApprovedBy, Action, Version,SMSDCRNo,IsSendSMS,RejectReason) "
        //                 + " VALUES(%n, %n, %n, %s, %n, %n, %n, %n, %D, %b, %b, %b, %b, %s, %n, %s, %b, %s, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n,%n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n,%n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n,%n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %n, %D, %D, %n, %n, %n, %n,%s,%b,%s) "
        //                   , oDCR.ID.ToInt32, oDCR.PvpDetailID, oDCR.DoctorID, oDCR.TerritoryID, oDCR.Day, oDCR.Month, oDCR.Year, oDCR.Status, oDCR.VisitDateTime, oDCR.IsVisited, oDCR.IsAvailable, oDCR.IsAccompanyByRM_RM, oDCR.IsAccompanyByRM_SF, oDCR.ReminderNextCall, oDCR.NotAvailableReasonID, oDCR.NotAvailableReason, oDCR.IsNewVisit, oDCR.Session
        //                   , oDCR.Brand1, oDCR.Brand1Gimmick1, oDCR.Brand1Gimmick2, oDCR.Brand1Gimmick3, oDCR.Brand1Sample1, oDCR.Brand1Sample2, oDCR.Brand1Sample3, oDCR.Brand1Gimmick1Qty, oDCR.Brand1Gimmick2Qty, oDCR.Brand1Gimmick3Qty, oDCR.Brand1Sample1Qty, oDCR.Brand1Sample2Qty, oDCR.Brand1Sample3Qty, oDCR.Brand2,
        //                   oDCR.Brand2Gimmick1, oDCR.Brand2Gimmick2, oDCR.Brand2Gimmick3, oDCR.Brand2Sample1, oDCR.Brand2Sample2, oDCR.Brand2Sample3, oDCR.Brand2Gimmick1Qty, oDCR.Brand2Gimmick2Qty, oDCR.Brand2Gimmick3Qty, oDCR.Brand2Sample1Qty, oDCR.Brand2Sample2Qty, oDCR.Brand2Sample3Qty, oDCR.Brand3,
        //                   oDCR.Brand3Gimmick1, oDCR.Brand3Gimmick2, oDCR.Brand3Gimmick3, oDCR.Brand3Sample1, oDCR.Brand3Sample2, oDCR.Brand3Sample3, oDCR.Brand3Gimmick1Qty, oDCR.Brand3Gimmick2Qty, oDCR.Brand3Gimmick3Qty, oDCR.Brand3Sample1Qty, oDCR.Brand3Sample2Qty, oDCR.Brand3Sample3Qty, oDCR.Brand4,
        //                   oDCR.Brand4Gimmick1, oDCR.Brand4Gimmick2, oDCR.Brand4Gimmick3, oDCR.Brand4Sample1, oDCR.Brand4Sample2, oDCR.Brand4Sample3, oDCR.Brand4Gimmick1Qty, oDCR.Brand4Gimmick2Qty, oDCR.Brand4Gimmick3Qty, oDCR.Brand4Sample1Qty, oDCR.Brand4Sample2Qty, oDCR.Brand4Sample3Qty, oDCR.Brand5,
        //                    oDCR.Brand5Gimmick1, oDCR.Brand5Gimmick2, oDCR.Brand5Gimmick3, oDCR.Brand5Sample1, oDCR.Brand5Sample2, oDCR.Brand5Sample3, oDCR.Brand5Gimmick1Qty, oDCR.Brand5Gimmick2Qty, oDCR.Brand5Gimmick3Qty, oDCR.Brand5Sample1Qty, oDCR.Brand5Sample2Qty, oDCR.Brand5Sample3Qty, oDCR.Brand6,
        //                    oDCR.Brand6Gimmick1, oDCR.Brand6Gimmick2, oDCR.Brand6Gimmick3, oDCR.Brand6Sample1, oDCR.Brand6Sample2, oDCR.Brand6Sample3, oDCR.Brand6Gimmick1Qty, oDCR.Brand6Gimmick2Qty, oDCR.Brand6Gimmick3Qty, oDCR.Brand6Sample1Qty, oDCR.Brand6Sample2Qty, oDCR.Brand6Sample3Qty, oDCR.SubmitDateTime, oDCR.ApprovedDateTime, oDCR.SubmittedBy, oDCR.ApprovedBy, oDCR.Action, oDCR.Version, oDCR.SMSDCRNo, oDCR.IsSendSMS, oDCR.RejectReason);
        //                SqlDataAdapter oAdapter1 = new SqlDataAdapter();
        //                SqlCommand cmd9 = new SqlCommand();
        //                cmd9 = new SqlCommand(sql, oConnection);
        //                cmd9.Transaction = myTransaction;
        //                oAdapter1.InsertCommand = cmd9;
        //                cmd9.ExecuteNonQuery();
        //            }
        //        }

        //        SqlCommand cmd12 = new SqlCommand();
        //        cmd12.CommandText = "SELECT MAX(Version)+ 1 AS Version FROM [PVPMaster] where TerritoryID like '" + sTerritoryID.Substring(0, 6) + "%'";
        //        cmd12.Connection = oConnection;
        //        cmd12.Transaction = myTransaction;
        //        object oMaxVersion = cmd12.ExecuteScalar();
        //        int nMaxVersion = 0;
        //        if (oMaxVersion == DBNull.Value)
        //        {
        //            nMaxVersion = 1;
        //        }
        //        else
        //        {
        //            nMaxVersion = Convert.ToInt32(oMaxVersion);
        //        }

        //        SqlCommand cmd16 = new SqlCommand();
        //        cmd16.CommandText = @"SELECT GDDBID FROM [OrderCollectionSystem].[dbo].[EmployeeInfo] a INNER JOIN [OrderCollectionSystem].[dbo].[Territory] b ON a.TerritoryID=b.TerritoryID WHERE b.TerritoryCode='" + sTerritoryID.Substring(0, 6) + "'";
        //        cmd16.Connection = oConnection;
        //        cmd16.Transaction = myTransaction;
        //        object oRMGDDBID = cmd16.ExecuteScalar();
        //        string sRMGDDBID = "";
        //        if (oRMGDDBID == DBNull.Value)
        //        {
        //            sRMGDDBID = "";
        //        }
        //        else
        //        {
        //            sRMGDDBID = Convert.ToString(oRMGDDBID);
        //        }

        //        DataTable otblRMInfo = new DataTable();
        //        string sRMInfo = "SELECT * FROM [UserInfo] WHERE GDDBID='" + sRMGDDBID + "' and IsActive=1";
        //        SqlDataAdapter Sfda4 = new SqlDataAdapter(sRMInfo, connectionString);
        //        Sfda4.Fill(otblRMInfo);

        //        string sSQL4 = SQL.MakeSQL("UPDATE [UserInfo] SET Version=%n, DCRVersion=%n WHERE GDDBID=%s"
        //            , Convert.ToInt32(otblRMInfo.Rows[0]["Version"].ToString()) + 1,
        //            Convert.ToInt32(otblRMInfo.Rows[0]["DCRVersion"].ToString()) + 1, sRMGDDBID);

        //        SqlDataAdapter oAdapter5 = new SqlDataAdapter();
        //        SqlCommand cmd17 = new SqlCommand();
        //        cmd17 = new SqlCommand(sSQL4, oConnection);
        //        cmd17.Transaction = myTransaction;
        //        oAdapter5.UpdateCommand = cmd17;
        //        cmd17.ExecuteNonQuery();

        //        string sSQL = SQL.MakeSQL("Update [PVPMaster] set [Status]=3, ApprovedDate=%D, ApprovedBy=%s, [Version]=%n, [Action]=2 where TerritoryID=%s and Month=%n and Year=%n", DateTime.Now, sRMGDDBID, nMaxPVPVersion, sTerritoryID, nMonth, nYear);
        //        SqlDataAdapter oAdapter3 = new SqlDataAdapter();
        //        SqlCommand cmd11 = new SqlCommand();
        //        cmd11 = new SqlCommand(sSQL, oConnection);
        //        cmd11.Transaction = myTransaction;
        //        oAdapter3.InsertCommand = cmd11;
        //        cmd11.ExecuteNonQuery();

        //        SqlCommand cmd15 = new SqlCommand();
        //        cmd15.CommandText = @"SELECT GDDBID FROM [OrderCollectionSystem].[dbo].[EmployeeInfo] a INNER JOIN [OrderCollectionSystem].[dbo].[Territory] b ON a.TerritoryID=b.TerritoryID WHERE b.TerritoryCode='" + sTerritoryID + "'";
        //        cmd15.Connection = oConnection;
        //        cmd15.Transaction = myTransaction;
        //        object oGDDBID = cmd15.ExecuteScalar();
        //        string sSFGDDBID = "";
        //        if (oGDDBID == DBNull.Value)
        //        {
        //            sSFGDDBID = "";
        //        }
        //        else
        //        {
        //            sSFGDDBID = Convert.ToString(oGDDBID);
        //        }

        //        DataTable otblUserInfo = new DataTable();
        //        string sSFUserInfo = "SELECT * FROM [UserInfo] WHERE GDDBID='" + sSFGDDBID + "' and IsActive=1";
        //        SqlDataAdapter Sfda3 = new SqlDataAdapter(sSFUserInfo, connectionString);
        //        Sfda3.Fill(otblUserInfo);

        //        string sSQL3 = SQL.MakeSQL("UPDATE [UserInfo] SET Version=%n, PVPVersion=%n, DCRVersion=%n WHERE GDDBID=%s"
        //            , Convert.ToInt32(otblUserInfo.Rows[0]["Version"].ToString()) + 1, Convert.ToInt32(otblUserInfo.Rows[0]["PVPVersion"].ToString()) + 1,
        //            Convert.ToInt32(otblUserInfo.Rows[0]["DCRVersion"].ToString()) + 1, sSFGDDBID);

        //        SqlDataAdapter oAdapter4 = new SqlDataAdapter();
        //        SqlCommand cmd14 = new SqlCommand();
        //        cmd14 = new SqlCommand(sSQL3, oConnection);
        //        cmd14.Transaction = myTransaction;
        //        oAdapter4.UpdateCommand = cmd14;
        //        cmd14.ExecuteNonQuery();

        //        nAuthenticket++;

        //        myTransaction.Commit();
        //        oConnection.Close();

        //        if (nAuthenticket != 0)
        //        {
        //            nAuthenticket = 1;
        //        }
        //        return nAuthenticket;
        //    }

        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }

        //}

        [WebMethod(Description = "Method to Update DCRApproveByRM")]
        public string DCRApprovalByRM(string sDCRApprovalDetails, string sApprovedBy)
        {

            DCR oDCR = new DCR();
            UserInfo oUserInfo = new UserInfo();
            EmployeeInfo oEmployeeInfo = new EmployeeInfo();
            AppConfigurationInfo oAppConfigInfo = new AppConfigurationInfo();
            BLDCR oBLDCR = new BLDCR();
            BLUserInfo oBLUserInfo = new BLUserInfo();
            BLEmployeeInfo oBLEmployeeInfo = new BLEmployeeInfo();
            BLAppConfigurationInfo oBLAppConfig = new BLAppConfigurationInfo();
            BLCommandInfo oBLCommandInfo = new BLCommandInfo();
            string sUpdateDCR = "";

            try
            {

                //string sconnectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string sconnectionString = oValues["ConnectionString2"].ToString();
                //string sconnectionString = "Data Source=gxbdda-s3020\\sqlserver;User ID=sa;Password=tamamyl;Initial Catalog=FAST;";

                SqlConnection oConnection = new SqlConnection(sconnectionString);
                oConnection.Open();
                //Start transaction.
                SqlTransaction oTransaction = oConnection.BeginTransaction();
                //Assign command in the current transaction.
                SqlCommand oCommand = new SqlCommand();
                oCommand.Transaction = oTransaction;
                bool bIsDCROpen = false;

                try
                {
                    int nUserID = 0;
                    nUserID = oBLUserInfo.GetActiveUserIDBYGDDBID(oConnection, oTransaction, sApprovedBy);
                    if (nUserID > 0)
                    {
                        string[] sArray;
                        string[] sNewItem;
                        //sDCRApprovalDetails = "6335,1,test1,4;6337,1,test2,4;6340,1,test3,4;6341,1,test4,4;6343,1,test5,4;";
                        sArray = sDCRApprovalDetails.Split(';');

                        foreach (string sItemName in sArray)
                        {
                            sNewItem = sItemName.Split(',');

                            //int nDCRID, int nIsAccompanyByRM_RM, string sRejectReason, int nDCRStatus,
                            int nLength = sNewItem.Length;
                            if (nLength != 1)
                            {
                                int nDCRID = Convert.ToInt32(sNewItem.GetValue(0));
                                int nIsAccompanyByRM_RM = Convert.ToInt32(sNewItem.GetValue(1));
                                string sRejectReason = sNewItem.GetValue(2).ToString();
                                int nDCRStatus = Convert.ToInt32(sNewItem.GetValue(3));

                                oDCR = new DCR();
                                oDCR = oBLDCR.GetDCR(nDCRID, sconnectionString);

                                oAppConfigInfo = oBLAppConfig.GetAppConfigurationInfo(oDCR.TerritoryID.Substring(0, 6), sconnectionString);
                                int nDCREntryHours = oAppConfigInfo.DCRApprovalHours;
                                DateTime dDCRDate = new DateTime(oDCR.Year, oDCR.Month, oDCR.Day);
                                dDCRDate = dDCRDate.AddHours(nDCREntryHours);
                                DateTime dCurrentDate = DateTime.Now;
                                
                                if (dCurrentDate <= dDCRDate)
                                    bIsDCROpen = true;
                                //if (!bIsDCROpen)
                                //{
                                //    nDCREntryHours = oBLCommandInfo.GetDCREntryHours(oConnection, oTransaction, oDCR.TerritoryID.Substring(0, 6));
                                //    dDCRDate = new DateTime(oDCR.Year, oDCR.Month, oDCR.Day);
                                //    dDCRDate = dDCRDate.AddHours(nDCREntryHours);
                                //    if (dCurrentDate <= dDCRDate)
                                //        bIsDCROpen = true;
                                //}

                                if (bIsDCROpen)
                                {
                                    oDCR.Status = nDCRStatus;
                                    oDCR.IsAccompanyByRM_RM = Convert.ToBoolean(nIsAccompanyByRM_RM);
                                    if (nDCRStatus == 5)
                                        oDCR.RejectReason = sRejectReason;
                                    oDCR.ApprovedBy = nUserID;
                                    oDCR.ApprovedDateTime = DateTime.Now;
                                    //oDCR.Version = oBLDCR.GetDCRNewVersion(oConnection, oTransaction, oDCR.TerritoryID);
                                    oDCR.Version = oBLDCR.GetDCRNewVersion(oConnection, oTransaction);
                                    oDCR.Action = 2;
                                    oBLDCR.Save(oDCR, oConnection, oTransaction);

                                    //string sSFGDDBID = oBLEmployeeInfo.GetGDDBIDByTerritoryID(oConnection, oTransaction, oDCR.TerritoryID);

                                    //oUserInfo = new UserInfo();
                                    //oUserInfo = oBLUserInfo.GetUserInfo(sSFGDDBID, sconnectionString);
                                    //oUserInfo.Version = oUserInfo.Version + 1;
                                    //oUserInfo.DCRVersion = oUserInfo.DCRVersion + 1;
                                    //int nSFAuthenticket = oBLUserInfo.Save(oUserInfo, oConnection, oTransaction);

                                    //sUpdateDCR = "1";
                                }
                                else
                                {
                                    sUpdateDCR = "-1";
                                    break;
                                }

                            }
                        }

                        //oUserInfo = new UserInfo();
                        //oUserInfo = oBLUserInfo.GetUserInfo(sApprovedBy, sconnectionString);

                        //oUserInfo.Version = oUserInfo.Version + 1;
                        //oUserInfo.PVPVersion = oUserInfo.PVPVersion + 1;
                        //int nRMAuthenticket = oBLUserInfo.Save(oUserInfo, oConnection, oTransaction);

                        //DCR Approve

                        if (bIsDCROpen)
                        {
                            string sSFGDDBID = oBLEmployeeInfo.GetGDDBIDByTerritoryID(oConnection, oTransaction, oDCR.TerritoryID);

                            oUserInfo = new UserInfo();
                            oUserInfo = oBLUserInfo.GetUserInfo(sSFGDDBID, sconnectionString);
                            oUserInfo.Version = oUserInfo.Version + 1;
                            oUserInfo.DCRVersion = oUserInfo.DCRVersion + 1;
                            int nSFAuthenticket = oBLUserInfo.Save(oUserInfo, oConnection, oTransaction);

                            sUpdateDCR = "1";
                        }
                        else
                        {
                            DCRLateApprovalLog oDCRLateApprovalLog = new DCRLateApprovalLog();
                            BLDCRLateApprovalLog oBLDCRLateApprovalLog = new BLDCRLateApprovalLog();
                            oDCRLateApprovalLog.RegionID = oDCR.TerritoryID.Substring(0, 6);
                            oDCRLateApprovalLog.TerritoryID = oDCR.TerritoryID;
                            oDCRLateApprovalLog.DCRDetail = sDCRApprovalDetails;
                            oDCRLateApprovalLog.Day = oDCR.Day;
                            oDCRLateApprovalLog.Month = oDCR.Month;
                            oDCRLateApprovalLog.Year = oDCR.Year;
                            oDCRLateApprovalLog.ApprovedDateTime = DateTime.Now;
                            oDCRLateApprovalLog.ApprovedBy = sApprovedBy;
                            oBLDCRLateApprovalLog.Save(oDCRLateApprovalLog, oConnection, oTransaction);
                        }


                        //else
                        //{
                        //    nUpdateDCR = 0;
                        //}

                        // ……………………
                        oTransaction.Commit();
                    }
                }
                catch (Exception e)
                {
                    sUpdateDCR = e.Message.ToString();
                    oTransaction.Rollback();
                    //sUpdateDCR = "0";
                }
                finally
                {
                    oConnection.Close();
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                    sUpdateDCR = "Cannot connect to database.";
                else
                    sUpdateDCR = ex.Message.ToString();
                //throw new Exception(ex.Message);
            }

            return sUpdateDCR;
        }

        [WebMethod(Description = "Method to Get PVPWorkingDay")]
        public PVPWorkingDays GetPVPWorkingDay(int nMaxVersion)
        {
            PVPWorkingDays oPVPWorkingDays = new PVPWorkingDays();
            BLPVPWorkingDay oBL = new BLPVPWorkingDay();
            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;
                try
                {
                    oPVPWorkingDays = oBL.GetPVPWorkingDays(nMaxVersion, connectionString);
                    myTransaction.Commit();
                }
                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
                return oPVPWorkingDays;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Get SalutationInfo")]
        public Salutations GetSalutationInfo(int nMaxVersion)
        {
            Salutations oSalutations = new Salutations();
            BLSalutation oBL = new BLSalutation();

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    oSalutations = oBL.GetSalutationInfos(nMaxVersion, connectionString);
                    myTransaction.Commit();
                }

                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }

                return oSalutations;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Get SpecialityInfo")]
        public Specialtys GetSpecialityInfo(int nMaxVersion)
        {
            Specialtys oSpecialtys = new Specialtys();
            BLSpecialty oBL = new BLSpecialty();

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    oSpecialtys = oBL.GetSpecialityInfos(nMaxVersion, connectionString);
                    myTransaction.Commit();
                }

                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }

                return oSpecialtys;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Get DegreeInfo")]
        public Degrees GetDegreeInfo(int nMaxVersion)
        {
            Degrees oDegrees = new Degrees();
            BLDegree oBL = new BLDegree();

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    oDegrees = oBL.GetDegreeInfos(nMaxVersion, connectionString);
                    myTransaction.Commit();
                }

                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }

                return oDegrees;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Get DistrictInfoForRM")]
        public Districts GetDistrictInfoForRM(string sTerritoryID, int nMaxVersion)
        {
            Districts oDistricts = new Districts();
            BLDistrict oBL = new BLDistrict();

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    oDistricts = oBL.GetDistrictInfosForRM(sTerritoryID, nMaxVersion, connectionString);
                    myTransaction.Commit();
                }

                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }

                return oDistricts;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //[WebMethod(Description = "Method to Get UpazillaInfoForRM")]
        //public Upazillas GetUpazillaInfoForRM(string sTerritoryID, int nMaxVersion)
        //{
        //    Upazillas oUpazillas = new Upazillas();
        //    BLUpazilla oBL = new BLUpazilla();

        //    try
        //    {
        //        //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
        //        NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
        //        string connectionString = oValues["ConnectionString2"].ToString();
        //        //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

        //        SqlConnection myConnection = new SqlConnection(connectionString);
        //        myConnection.Open();
        //        // Start transaction.
        //        SqlTransaction myTransaction = myConnection.BeginTransaction();
        //        // Assign command in the current transaction.
        //        SqlCommand myCommand = new SqlCommand();
        //        myCommand.Transaction = myTransaction;

        //        try
        //        {
        //            oUpazillas = oBL.GetUpazillaInfosForRM(sTerritoryID, nMaxVersion, connectionString);
        //            myTransaction.Commit();
        //        }

        //        catch (Exception e)
        //        {
        //            myTransaction.Rollback();
        //        }
        //        finally
        //        {
        //            myConnection.Close();
        //        }

        //        return oUpazillas;
        //    }

        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        [WebMethod(Description = "Method to Get UpazillaInfoForRM")]
        public List<Upazilla> GetUpazillaInfoForRM(string sTerritoryID, int nMaxVersion)
        {
            oUpazillaInfo = new List<Upazilla> { };
            DataTable oTable = new DataTable();
            BLUpazilla oBL = new BLUpazilla();

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    oTable = oBL.GetUpazillaInfoForRM(sTerritoryID, nMaxVersion, connectionString);
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        Upazilla oUpazilla = new Upazilla();
                        oUpazilla.nUID = Convert.ToInt32(oRow["UpazillaID"].ToString());
                        oUpazilla.sUName = txtInfo.ToTitleCase(oRow["UName"].ToString());
                        oUpazilla.sDistName = txtInfo.ToTitleCase(oRow["DistName"].ToString());
                        oUpazilla.nVersion = Convert.ToInt32(oRow["Version"].ToString());
                        oUpazilla.nActionType = Convert.ToInt32(oRow["Action"].ToString());

                        oUpazillaInfo.Add(oUpazilla);
                    }
                    myTransaction.Commit();
                }

                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }

                return oUpazillaInfo;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Get DocotorLogInfoForRM")]
        public DoctorLogs GetDocotorLogInfoForRM(string sTerritoryID, int nMaxVersion)
        {
            DoctorLogs oDoctorLogs = new DoctorLogs();
            BLDoctorLog oBL = new BLDoctorLog();

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    oDoctorLogs = oBL.GetDocotorLogInfosForRM(sTerritoryID, nMaxVersion, connectionString);
                    myTransaction.Commit();
                }

                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }

                return oDoctorLogs;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //[WebMethod(Description = "Method to Get DoctorUpdateRequestInfo")]
        //public DoctorUpdateRequests GetDoctorUpdateRequestInfoForRM2(string sTerritoryID, int nMaxVersion)
        //{
        //    DoctorUpdateRequests oDoctorUpdateRequests = new DoctorUpdateRequests();
        //    BLDoctorUpdateRequest oBL = new BLDoctorUpdateRequest();

        //    try
        //    {
        //        //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
        //        NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
        //        string connectionString = oValues["ConnectionString2"].ToString();
        //        //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

        //        SqlConnection myConnection = new SqlConnection(connectionString);
        //        myConnection.Open();
        //        // Start transaction.
        //        SqlTransaction myTransaction = myConnection.BeginTransaction();
        //        // Assign command in the current transaction.
        //        SqlCommand myCommand = new SqlCommand();
        //        myCommand.Transaction = myTransaction;

        //        try
        //        {
        //            oDoctorUpdateRequests = oBL.GetDoctorUpdateRequestInfosForRM(sTerritoryID, nMaxVersion, connectionString);
        //            myTransaction.Commit();
        //        }

        //        catch (Exception e)
        //        {
        //            myTransaction.Rollback();
        //        }
        //        finally
        //        {
        //            myConnection.Close();
        //        }

        //        return oDoctorUpdateRequests;
        //    }

        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        [WebMethod(Description = "Method to Get DoctorUpdateRequestInfoForRM")]
        public List<DoctorUpdateReq> GetDoctorUpdateRequestInfoForRM(string sTerritoryID, int nMaxVersion)
        {
            oDoctorUpdateReqList = new List<DoctorUpdateReq> { };
            DataTable oTable = new DataTable();
            BLDoctorUpdateRequest oBL = new BLDoctorUpdateRequest();

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    oTable = oBL.GetDoctorUpdateRequestInfoForRM(sTerritoryID, nMaxVersion, connectionString);
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        DoctorUpdateReq oDoctorUpdateReq = new DoctorUpdateReq();
                        oDoctorUpdateReq.nDoctorUpdateRequestID = Convert.ToInt32(oRow["DoctorUpdateRequestID"].ToString());
                        oDoctorUpdateReq.sTerritoryID = oRow["TerritoryID"].ToString().ToUpper();
                        oDoctorUpdateReq.nDoctorID = Convert.ToInt32(oRow["DoctorID"].ToString());
                        oDoctorUpdateReq.sBMDCCode = oRow["BMDCCode"].ToString();
                        oDoctorUpdateReq.sCode = oRow["Code"].ToString();
                        oDoctorUpdateReq.sDoctorName = txtInfo.ToTitleCase(oRow["DocName"].ToString());
                        oDoctorUpdateReq.sSalutation = oRow["SalDesc"].ToString();
                        oDoctorUpdateReq.sSpecialty1 = oRow["spName1"].ToString();
                        oDoctorUpdateReq.sSpecialty2 = oRow["spName2"].ToString();
                        oDoctorUpdateReq.sDegree1 = oRow["degName1"].ToString();
                        oDoctorUpdateReq.sDegree2 = oRow["degName2"].ToString();
                        oDoctorUpdateReq.sInstitute = txtInfo.ToTitleCase(oRow["Institute"].ToString());
                        oDoctorUpdateReq.sAddress1 = txtInfo.ToTitleCase(oRow["Address1"].ToString());
                        oDoctorUpdateReq.sAddress2 = txtInfo.ToTitleCase(oRow["Address2"].ToString());
                        oDoctorUpdateReq.sAddress3 = txtInfo.ToTitleCase(oRow["Address3"].ToString());
                        oDoctorUpdateReq.sDistrict = oRow["DistName"].ToString();
                        oDoctorUpdateReq.sUpazilla = oRow["UName"].ToString();
                        oDoctorUpdateReq.sBirthDay = Convert.ToDateTime(oRow["BirthDay"].ToString()).ToString("dd MMM yyyy");
                        oDoctorUpdateReq.sMarriageday = Convert.ToDateTime(oRow["Mrgday"].ToString()).ToString("dd MMM yyyy");
                        oDoctorUpdateReq.sEmail = oRow["Email"].ToString();
                        oDoctorUpdateReq.sMobileNo = oRow["MobileNo"].ToString();
                        oDoctorUpdateReq.nAddressNo = Convert.ToInt32(oRow["MapAddress"].ToString());
                        oDoctorUpdateReq.nDegreeNo = Convert.ToInt32(oRow["MapDegree"].ToString());
                        oDoctorUpdateReq.nSpecialtyNo = Convert.ToInt32(oRow["MapSpeciality"].ToString());
                        oDoctorUpdateReq.nDoctorType = Convert.ToInt32(oRow["DoctorTypeID"].ToString());
                        oDoctorUpdateReq.nSwajanStatus = Convert.ToInt32(oRow["SwajanStatus"].ToString());
                        oDoctorUpdateReq.sProfileCode = oRow["PCode"].ToString();
                        oDoctorUpdateReq.sProfileName = oRow["PName"].ToString();
                        oDoctorUpdateReq.sProduct1 = oRow["Prod1"].ToString();
                        oDoctorUpdateReq.sProduct2 = oRow["Prod2"].ToString();
                        oDoctorUpdateReq.sProduct3 = oRow["Prod3"].ToString();
                        oDoctorUpdateReq.sProduct4 = oRow["Prod4"].ToString();
                        oDoctorUpdateReq.sProduct5 = oRow["Prod5"].ToString();
                        oDoctorUpdateReq.sProduct6 = oRow["Prod6"].ToString();
                        oDoctorUpdateReq.sProduct7 = oRow["Prod7"].ToString();
                        oDoctorUpdateReq.sProduct8 = oRow["Prod8"].ToString();
                        oDoctorUpdateReq.nCallFreq = Convert.ToInt32(oRow["CallFrequency"].ToString());
                        oDoctorUpdateReq.sRoute = txtInfo.ToTitleCase(oRow["RName"].ToString().Trim());
                        oDoctorUpdateReq.sSession = oRow["SessName"].ToString();
                        oDoctorUpdateReq.nStatus = Convert.ToInt32(oRow["UpdateStatus"].ToString());
                        oDoctorUpdateReq.sCreateDate = "";// Convert.ToDateTime(oRow["CreateDate"].ToString()).ToString("dd MMM yyyy HH:mm:ss");
                        oDoctorUpdateReq.sLastUpdateDate = "";// Convert.ToDateTime(oRow["ModifyDate"].ToString()).ToString("dd MMM yyyy HH:mm:ss");
                        oDoctorUpdateReq.nVersion = Convert.ToInt32(oRow["Version"].ToString());
                        oDoctorUpdateReq.nActionType = Convert.ToInt32(oRow["Action"].ToString());
                        oDoctorUpdateReq.nRefNo = 1; //Convert.ToInt32(oRow["RefNo"].ToString());
                        oDoctorUpdateReq.nCreatedBy = 1; //Convert.ToInt32(oRow["CreatedBy"].ToString());
                        oDoctorUpdateReq.nModifiedBy = 1; // Convert.ToInt32(oRow["ModifiedBy"].ToString());
                        oDoctorUpdateReq.sCardAttachement = oRow["CardAttachement"].ToString();
                        oDoctorUpdateReq.sPostStepChange = oRow["PostStpCngName"].ToString();

                        oDoctorUpdateReqList.Add(oDoctorUpdateReq);
                    }
                    myTransaction.Commit();
                }
                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }

                return oDoctorUpdateReqList;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to Get LineSpecialityProductForRM")]
        public List<LineSpecialityProduct> GetLineSpecialityProductForRM(int nMaxVersion, string sLine)
        {
            oLineSpecialityProductList = new List<LineSpecialityProduct> { };
            DataTable oTable = new DataTable();
            BLDoctorTerritoryMapping oBL = new BLDoctorTerritoryMapping();

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();
                //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;

                try
                {
                    oTable = oBL.GetProductInfoForRM(nMaxVersion, sLine, connectionString);
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        LineSpecialityProduct oLineSpecialityProduct = new LineSpecialityProduct();
                        oLineSpecialityProduct.sLineID = oRow["LineID"].ToString().ToUpper();
                        oLineSpecialityProduct.sSPDesc = oRow["SpCode"].ToString();
                        oLineSpecialityProduct.sProdName = oRow["ProdName"].ToString();
                        oLineSpecialityProduct.nRankWithin = Convert.ToInt32(oRow["Priority"].ToString());
                        oLineSpecialityProduct.nPriority = Convert.ToInt32(oRow["RankWithin"].ToString());
                        oLineSpecialityProduct.nVersion = Convert.ToInt32(oRow["Version"].ToString());
                        oLineSpecialityProduct.nActionType = Convert.ToInt32(oRow["Action"].ToString());

                        oLineSpecialityProductList.Add(oLineSpecialityProduct);
                    }
                    myTransaction.Commit();
                }

                catch (Exception e)
                {
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }

                return oLineSpecialityProductList;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [WebMethod(Description = "Method to GetAdvanceDoctorSearchListForRM")]
        public List<SearchResults> GetAdvanceDoctorSearchListForRM(string sTerritoryID, string sDocName, string sFRPDoctorID, string sAddress, string sDegree, string sSpeciality, string sDistrict,
             string sUpzila, string sInstitute)
        {
            //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
            NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
            string connectionString = oValues["ConnectionString2"].ToString();
            //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            // Start transaction.
            SqlTransaction myTransaction = myConnection.BeginTransaction();
            // Assign command in the current transaction.
            SqlCommand myCommand = new SqlCommand();
            myCommand.Transaction = myTransaction;
            var Doctors = new List<SearchResults>();
            try
            {
                BuildIndexForRM(sTerritoryID, connectionString);
                int count;
                //var Doctors = new List<SearchResults>();
                string s = "";
                var products = Search(sDocName, sFRPDoctorID, sAddress, sDegree, sSpeciality, sDistrict, sUpzila, sInstitute, 999999999, out count);

                foreach (SearchResults oItem in products)
                {

                    Doctors.Add(oItem);
                }
                myTransaction.Commit();
            }
            catch (Exception e)
            {
                myTransaction.Rollback();
            }
            finally
            {
                myConnection.Close();
            }

            return Doctors;
        }

        public void BuildIndexForRM(string sTerritoryID, string sConnectionString)
        {
            var sampleProducts = GetDoctorListForRM(sTerritoryID, sConnectionString);

            using (var directory = GetDirectory())
            using (var analyzer = GetAnalyzer())
            using (var writer = new IndexWriter(directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                writer.DeleteAll();
                foreach (var SearchResults in sampleProducts)
                {
                    var document = MapProduct(SearchResults);
                    writer.AddDocument(document);
                }
            }
        }

        public List<SearchResults> GetDoctorListForRM(string sTerritoryID, string sConnectionString)
        {

            DataTable oTable = new DataTable();
            BLDoctorTerritoryMapping oBL = new BLDoctorTerritoryMapping();
            var products = new List<SearchResults>();
            try
            {

                int nMaxVersion = 0;
                oTable = oBL.GetTerritoryDisUpaWiseAllDoctorListForRM(sTerritoryID, nMaxVersion, sConnectionString);

                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow dr in oTable.Rows)
                    {

                        var product = new SearchResults
                        {
                            ID = Convert.ToInt32(dr["ID"].ToString()),
                            Code = dr["Code"].ToString(),
                            BMDCCode = dr["BMDCCode"].ToString(),
                            DocName = dr["DocName"].ToString(),
                            Salutation = dr["SalCode"].ToString(),
                            Speciality1 = dr["SP1"].ToString(),
                            Speciality2 = dr["SP2"].ToString(),
                            Degree1 = dr["Deg1"].ToString(),
                            Degree2 = dr["Deg2"].ToString(),
                            Institute = dr["Institute"].ToString(),
                            Address1 = dr["Address1"].ToString(),
                            Address2 = dr["Address2"].ToString(),
                            Address3 = dr["Address3"].ToString(),
                            District = dr["DistName"].ToString(),
                            Upzila = dr["UName"].ToString(),
                            FRPDoctorID = dr["4PDoctorID"].ToString(),
                            DOB = Convert.ToDateTime(dr["BirthDay"].ToString()).ToString("dd MMM yyyy"),
                            DOM = Convert.ToDateTime(dr["Mrgday"].ToString()).ToString("dd MMM yyyy"),
                            Status = dr["Status"].ToString(),
                            RefNo = dr["RefNo"].ToString(),
                            MobileNo = dr["MobileNo"].ToString(),
                            Email = dr["Email"].ToString(),
                            CardAttachment = dr["CardAttachement"].ToString(),
                        };
                        products.Add(product);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        static Document MapProduct(SearchResults oSearchResults)
        {
            var document = new Document();
            document.Add(new NumericField("ID", Field.Store.YES, true).SetIntValue(oSearchResults.ID));
            // document.Add(new Field("ID", oSearchResults.ID, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Code", oSearchResults.Code, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("BMDCCode", oSearchResults.BMDCCode, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("DocName", oSearchResults.DocName, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Salutation", oSearchResults.Salutation, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Speciality1", oSearchResults.Speciality1, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Speciality2", oSearchResults.Speciality2, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Degree1", oSearchResults.Degree1, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Degree2", oSearchResults.Degree1, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Institute", oSearchResults.Institute, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Address1", oSearchResults.Address1, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Address2", oSearchResults.Address2, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Address3", oSearchResults.Address3, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("District", oSearchResults.District, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Upzila", oSearchResults.Upzila, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("FRPDoctorID", oSearchResults.FRPDoctorID, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("DOB", oSearchResults.DOB, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("DOM", oSearchResults.DOM, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Status", oSearchResults.Status, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("RefNo", oSearchResults.RefNo, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("MobileNo", oSearchResults.MobileNo, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Email", oSearchResults.Email, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("CardAttachment", oSearchResults.CardAttachment, Field.Store.YES, Field.Index.ANALYZED));

            return document;
        }

        static List<SearchResults> Search(string sDocName, string sFRPDoctorID, string sAddress, string sDegree, string sSpeciality, string sDistrict,
            string sUpzila, string sInstitute, int limit, out int count)
        {
            using (var directory = GetDirectory())
            using (var searcher = new IndexSearcher(directory))
            {
                var query = GetFinalQuery(sDocName, sFRPDoctorID, sAddress, sDegree, sSpeciality, sDistrict, sUpzila, sInstitute);
                //var query = fparseQuery("nurul");
                var sort = GetSort();
                var filter = GetFilter();

                var docs = searcher.Search(query, filter, limit, sort);
                count = docs.TotalHits;

                var products = new List<SearchResults>();
                foreach (var scoreDoc in docs.ScoreDocs)
                {
                    var doc = searcher.Doc(scoreDoc.Doc);
                    var product = new SearchResults
                    {
                        ID = Convert.ToInt32(doc.Get("ID")),
                        Code = doc.Get("Code"),
                        BMDCCode = doc.Get("BMDCCode"),
                        DocName = doc.Get("DocName"),
                        Salutation = doc.Get("Salutation"),
                        Speciality1 = doc.Get("Speciality1"),
                        Speciality2 = doc.Get("Speciality2"),
                        Degree1 = doc.Get("Degree1"),
                        Degree2 = doc.Get("Degree2"),
                        Institute = doc.Get("Institute"),
                        Address1 = doc.Get("Address1"),
                        Address2 = doc.Get("Address2"),
                        Address3 = doc.Get("Address3"),
                        District = doc.Get("District"),
                        Upzila = doc.Get("Upzila"),
                        FRPDoctorID = doc.Get("FRPDoctorID"),
                        DOB = doc.Get("DOB"),
                        DOM = doc.Get("DOM"),
                        Status = doc.Get("Status"),
                        RefNo = doc.Get("RefNo"),
                        MobileNo = doc.Get("MobileNo"),
                        Email = doc.Get("Email"),
                        CardAttachment = doc.Get("CardAttachment"),

                    };
                    products.Add(product);
                }

                return products;
            }
        }

        static Directory GetDirectory()
        {
            return new SimpleFSDirectory(new DirectoryInfo(@"C:\SampleIndex"));
            //return new SimpleFSDirectory(new DirectoryInfo(@"D:\SampleIndex"));
        }

        static Query GetFinalQuery(string sDocName, string sFRPDoctorID, string sAddress, string sDegree, string sSpeciality, string sDistrict, string sUpzila, string sInstitute)
        {
            var finalQuery = new BooleanQuery();
            string[] searchfields = new string[] { "DocName", "FRPDoctorID", "Address1", "Address2", "Address3",
                "Degree1","Degree2","Speciality1", "Speciality2", "District", "Upzila", "Institute" };
            string[] terms = new string[] { sDocName.ToLower(), sFRPDoctorID.ToLower(), sAddress.ToLower(), sAddress.ToLower(), sAddress.ToLower(),
                sDegree.ToLower(),  sDegree.ToLower(),sSpeciality.ToLower(),sSpeciality.ToLower(), sDistrict.ToLower(), sUpzila.ToLower(), sInstitute.ToLower() };



            //var input = "This is a test";

            //var fieldName = "yourField";
            //var minimumSimilarity = 0.5f;
            //var prefixLength = 3;
            //var query = new BooleanQuery();

            //var segments = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            //foreach (var segment in segments)
            //{
            //    var term = new Term(fieldName, segment);
            //    var fuzzyQuery = new FuzzyQuery(term, minimumSimilarity, prefixLength);
            //    query.Add(fuzzyQuery, BooleanClause.Occur.SHOULD);
            //}

            const float MIN_SIMILARITY = 0.5f;
            const int PREFIX_LENGTH = 3;

            using (var analyzer = GetAnalyzer())
            {
                var parser = new MultiFieldQueryParser(Lucene.Net.Util.Version.LUCENE_29, searchfields, new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29));

                foreach (string term in terms)
                {
                    if (term != "")
                    {

                        // Create a subquery where the term must match at least one of the fields
                        var subquery = new BooleanQuery();
                        foreach (string field in searchfields)
                        {
                            if (Array.IndexOf(terms, term) == Array.IndexOf(searchfields, field))
                            {
                                var segments = term.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                                foreach (var segment in segments)
                                {
                                    var queryTerm = new Term(field, segment);
                                    var fuzzyQuery = new FuzzyQuery(queryTerm, MIN_SIMILARITY, PREFIX_LENGTH);
                                    subquery.Add(fuzzyQuery, Occur.SHOULD);
                                }
                                //var queryTerm = new Term(field, term);
                                //var fuzzyQuery = new FuzzyQuery(queryTerm, MIN_SIMILARITY, PREFIX_LENGTH);
                                //subquery.Add(fuzzyQuery, Occur.MUST);

                                break;
                            }
                        }


                        // Add the subquery to the final query, but make at least one subquery match must be found
                        finalQuery.Add(subquery, Occur.MUST);
                    }

                }

            }

            return finalQuery;
        }

        static Analyzer GetAnalyzer()
        {
            return new StandardAnalyzer(Version.LUCENE_30);
        }

        static Sort GetSort()
        {
            var fields = new[] 
            { 
                new SortField("DocName", SortField.STRING), 
                SortField.FIELD_SCORE 
            };
            return new Sort(fields); // sort by brand, then by score 
        }

        static Filter GetFilter()
        {
            return NumericRangeFilter.NewIntRange("ID", 1, 999999999, true, false); // [2; 5) range 

        }

        private static FuzzyQuery fparseQuery(string searchQuery)
        {

            var query = new FuzzyQuery(new Term("DocName", searchQuery), 0.5f);
            return query;
        }

        [WebMethod(Description = "UploadPicture")]
        public string UploadPicture(string sImageByte, string sDocName)
        {
            string sfilePath = "";
            try
            {
                string s = "";
                try
                {
                    s = FixBase64ForImage(sImageByte);
                }
                catch (Exception ex)
                {
                    sException = "Line1: " + ex.Message.ToString();
                    throw new Exception(ex.Message);
                }
                //int mod4 = s.Length % 4;
                //if (mod4 > 0)
                //{
                //    s += new string('=', 4 - mod4);
                //}
                byte[] bytes;
                try
                {
                    bytes = Convert.FromBase64String(s);
                }
                catch (Exception ex)
                {
                    sException = sException+ " Line2: " + ex.Message.ToString();
                    throw new Exception(ex.Message);
                }

                Image result = null;
                ImageFormat format = ImageFormat.Jpeg;

                try
                {
                    result = new Bitmap(new MemoryStream(bytes));
                }
                catch (Exception ex)
                {
                    sException = sException+ " Line3: " + ex.Message.ToString();
                    throw new Exception(ex.Message);
                }

                try
                {
                    using (Image imageToExport = result)
                    {
                        //NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                        //string sDMRCardAttachement = oValues["DMRCardAttachement"].ToString();
                        //sfilePath = string.Format(sDMRCardAttachement + sDocName + "_" + DateTime.Now.ToString("ddMMMyyyyhhmmss") + ".{0}", format.ToString());
                        sfilePath = string.Format(@"\\gxbdda-S3033\DMRCardAttachement\" + sDocName + "_" + DateTime.Now.ToString("ddMMMyyyyhhmmss") + ".{0}", format.ToString());
                        //sfilePath = string.Format(@"\\gxbdda-S3011\DMRCardAttachement\" + sDocName + "_" + DateTime.Now.ToString("ddMMMyyyyhhmmss") + ".{0}", format.ToString());
                        //sfilePath = string.Format(@"\\gxbdda-S3020\DMR\CardAttachement\" + docname + ".{0}", format.ToString());
                        imageToExport.Save(sfilePath, ImageFormat.Jpeg);
                        //result.Save(sfilePath, ImageFormat.Jpeg);
                        //string filePath = string.Format(@"\gxbdda-S3020\DMR\CardAttachement\");
                        // SaveJpeg(filePath, imageToExport,1);
                        //string filePath = string.Format(@"\gxbdda-S3020\DMR\CardAttachement\" + docname + ".{0}", format.ToString());
                        //imageToExport.Save(filePath, format);
                    }

                        //using (var m = new MemoryStream())
                        //{
                        //    result.Save(m, format);

                        //    var img = Image.FromStream(m);

                        //    TEST
                        //    img.Save(sfilePath);
                        //    var bytes = PhotoEditor.ConvertImageToByteArray(img);


                        //    return img;
                        //}
                }
                catch (Exception ex)
                {
                    sException = sException + " Line4: " + ex.Message.ToString() + sfilePath;
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
                return sfilePath;
        }

        //public static void SaveJpeg(string path, Image img, int quality)
            //{
            //    EncoderParameter qualityParam
            //    = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

            //    ImageCodecInfo jpegCodec
            //    = GetEncoderInfo(@"image/jpeg");

            //    EncoderParameters encoderParams
            //    = new EncoderParameters(1);

            //    encoderParams.Param[0] = qualityParam;

            //    System.IO.MemoryStream mss = new System.IO.MemoryStream();

            //    System.IO.FileStream fs
            //    = new System.IO.FileStream(path, System.IO.FileMode.Create
            //    , System.IO.FileAccess.ReadWrite);

            //    img.Save(mss, jpegCodec, encoderParams);
            //    byte[] matriz = mss.ToArray();
            //    fs.Write(matriz, 0, matriz.Length);

            //    mss.Close();
            //    fs.Close();
            //}
        //public string UploadPicturePath(string base64String, string docname)
        //{
        //    string sfilePath = "";
        //    try
        //    {



        //       //// string imag = base64String.Substring(1, base64String.Length - 4);
        //       //// imag = imag.Replace(@"\","");
        //       //// int c = imag.Length % 4;
        //       //// if ((c) != 0)
        //       ////     imag = imag.PadRight(imag.Length + 4 - imag.Length % 4, '=');
        //       ////byte[] bytes = Convert.FromBase64String(imag);
        //       // //using (System.IO.MemoryStream vstream = new System.IO.MemoryStream(converted)) {
        //       // //    return Image.FromStream(vstream);
        //       // //}




        //       // string sdummyData = base64String.Substring(1, base64String.Length - 4);
        //       // sdummyData = sdummyData.Trim().Replace("_", "+");
        //       // sdummyData = sdummyData.Trim().Replace("_", "/");
        //       // if (sdummyData.Length % 4 > 0)
        //       //     sdummyData = sdummyData.PadRight(sdummyData.Length + 4 - sdummyData.Length % 4, '=');
        //       // byte[] bytes = Convert.FromBase64String(sdummyData);
            

        //        // converted = converted.Replace(@"\/", "/");
        //        //byte[] bytes = Convert.FromBase64String(base64String);

        //        //byte[] bytes = Convert2ByteArray(base64String);

        //        string s = base64String.Substring(1, base64String.Length - 4);
        //        s = FixBase64ForImage(s);
        //        s = s.PadRight(s.Length + 4 - s.Length % 4, '=');
        //        byte[] bytes = Convert.FromBase64String(s);
        //        Image result = null;
        //        ImageFormat format = ImageFormat.Png;

        //        result = new Bitmap(new MemoryStream(bytes));

        //        using (Image imageToExport = result)
        //        {
                  
        //             sfilePath = string.Format(@"\\gxbdda-S3020\DMR\CardAttachement\" + docname + ".{0}", format.ToString());
        //             imageToExport.Save(sfilePath, format);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return sfilePath;
        //}

        private string FixBase64ForImage(string Image)
        {
            System.Text.StringBuilder sbText = new System.Text.StringBuilder(Image, Image.Length);

            sbText.Replace("\r\n", String.Empty);

            sbText.Replace(" ", String.Empty);

            sbText.Replace('-', '+');

            sbText.Replace('_', '/');
            sbText.Replace('.', ' ');

            sbText.Replace(@"\/", "/");

            return sbText.ToString();
        }

        public void BuildIndex(string sTerritoryID, string sConnectionString)
        {
            var sampleProducts = GetDoctorList(sTerritoryID, sConnectionString);

            using (var directory = GetDirectory())
            using (var analyzer = GetAnalyzer())
            using (var writer = new IndexWriter(directory, analyzer, IndexWriter.MaxFieldLength.UNLIMITED))
            {
                writer.DeleteAll();
                foreach (var SearchResults in sampleProducts)
                {
                    var document = MapProduct1(SearchResults);
                    writer.AddDocument(document);
                }
            }
        }

        static List<SearchResults> Search1(string sDocName, string sFRPDoctorID, string sAddress, string sDegree, string sSpeciality, string sDistrict,
         string sUpzila, string sInstitute, int limit, out int count)
        {
            using (var directory = GetDirectory())
            using (var searcher = new IndexSearcher(directory))
            {
                var query = GetFinalQuery(sDocName, sFRPDoctorID, sAddress, sDegree, sSpeciality, sDistrict, sUpzila, sInstitute);
                //var query = fparseQuery("nurul");
                var sort = GetSort();
                var filter = GetFilter();

                var docs = searcher.Search(query, filter, limit, sort);
                count = docs.TotalHits;

                var products = new List<SearchResults>();
                foreach (var scoreDoc in docs.ScoreDocs)
                {
                    var doc = searcher.Doc(scoreDoc.Doc);
                    var product = new SearchResults
                    {
                        ID = Convert.ToInt32(doc.Get("ID")),
                        Code = doc.Get("Code"),
                        BMDCCode = doc.Get("BMDCCode"),
                        DocName = doc.Get("DocName"),
                        Salutation = doc.Get("Salutation"),
                        Speciality1 = doc.Get("Speciality1"),
                        Speciality2 = doc.Get("Speciality2"),
                        Degree1 = doc.Get("Degree1"),
                        Degree2 = doc.Get("Degree2"),
                        Institute = doc.Get("Institute"),
                        Address1 = doc.Get("Address1"),
                        Address2 = doc.Get("Address2"),
                        Address3 = doc.Get("Address3"),
                        District = doc.Get("District"),
                        Upzila = doc.Get("Upzila"),
                        FRPDoctorID = doc.Get("FRPDoctorID"),
                        DOB = doc.Get("DOB"),
                        DOM = doc.Get("DOM"),
                        Status = doc.Get("Status"),
                        RefNo = doc.Get("RefNo"),
                        MobileNo = doc.Get("MobileNo"),
                        Email = doc.Get("Email"),
                        CardAttachment = doc.Get("CardAttachment"),

                    };
                    products.Add(product);
                }

                return products;
            }
        }

        static Document MapProduct1(SearchResults1 oSearchResults)
        {
            var document = new Document();
            document.Add(new NumericField("ID", Field.Store.YES, true).SetIntValue(oSearchResults.ID));
            // document.Add(new Field("ID", oSearchResults.ID, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Code", oSearchResults.Code, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("BMDCCode", oSearchResults.BMDCCode, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("DocName", oSearchResults.DocName, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Salutation", oSearchResults.Salutation, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Speciality1", oSearchResults.Speciality1, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Speciality2", oSearchResults.Speciality2, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Degree1", oSearchResults.Degree1, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Degree2", oSearchResults.Degree2, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Institute", oSearchResults.Institute, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Address1", oSearchResults.Address1, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Address2", oSearchResults.Address2, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Address3", oSearchResults.Address3, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("District", oSearchResults.District, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Upzila", oSearchResults.Upzila, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("FRPDoctorID", oSearchResults.FRPDoctorID, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("DOB", oSearchResults.DOB, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("DOM", oSearchResults.DOM, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Status", oSearchResults.Status, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("RefNo", oSearchResults.RefNo, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("MobileNo", oSearchResults.MobileNo, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("Email", oSearchResults.Email, Field.Store.YES, Field.Index.ANALYZED));
            document.Add(new Field("CardAttachment", oSearchResults.CardAttachment, Field.Store.YES, Field.Index.ANALYZED));


            return document;
        }

        [WebMethod(Description = "Method to GetAdvanceDoctorSearchList")]
        public List<SearchResults1> GetAdvanceDoctorSearchList(string sTerritoryID, string sDocName, string sFRPDoctorID, string sAddress, string sDegree, string sSpeciality, string sDistrict,
             string sUpzila, string sInstitute)
        {
            //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
            NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
            string connectionString = oValues["ConnectionString2"].ToString();
            //string connectionString = "Data Source=GXBDDA-S3017;User ID=adm_smart;Password=smartsmart;Initial Catalog=OrderCollectionSystem_Test;";

            SqlConnection myConnection = new SqlConnection(connectionString);
            myConnection.Open();
            // Start transaction.
            SqlTransaction myTransaction = myConnection.BeginTransaction();
            // Assign command in the current transaction.
            SqlCommand myCommand = new SqlCommand();
            myCommand.Transaction = myTransaction;
            var Doctors = new List<SearchResults1>();
            var FDoctors = new List<SearchResults1>();
            var ODoctors = new List<SearchResults1>();
            try
            {
                BuildIndex(sTerritoryID, connectionString);
                int count;
                //var Doctors = new List<SearchResults>();
                string s = "";
                var products = SearchforSF(sDocName, sFRPDoctorID, sAddress, sDegree, sSpeciality, sDistrict, sUpzila, sInstitute, 999999999, out count);
               // string[] arr = { "One", "Two", "Three" };
                //var target = "One";
                //var results = Array.FindAll(arr, x => x.Equals(target));

                foreach (SearchResults1 oItem in products)
                {

                    string[] arr = oItem.DocName.ToLower().Split(' ');
                    var results = Array.FindAll(arr, x => x.Equals(sDocName.ToLower()));
                    string sgetName = results.FirstOrDefault();
                    if (sgetName!=null)
                    {
                       
                        FDoctors.Add(oItem);
                    }
                   
                    else
                    {
                        ODoctors.Add(oItem);
                    }
                    //Doctors.Add(oItem);
                }

                FDoctors.AddRange(ODoctors);
               
                myTransaction.Commit();
            }
            catch (Exception e)
            {
                myTransaction.Rollback();
            }
            finally
            {
                myConnection.Close();
            }

            //return Doctors;
            return FDoctors;
        }

        bool IsSimpleMatch(string input, string pattern)
        {

            bool match = false;
            if (input.Length == pattern.Length)
            {
                match = true;
                for (int i = 0; i < input.Length; i++)
                    if (pattern[i] != '?' && input[i] != pattern[i])
                    {
                        match = false;
                        break;
                    }
            }
            return match;
        }

        public  int LevenshteinDistance(String s0, String s1)
        {
            int len0 = s0.Length + 1;
            int len1 = s1.Length + 1;

            // the array of distances                                                       
            int[] cost = new int[len0];
            int[] newcost = new int[len0];

            // initial cost of skipping prefix in String s0                                 
            for (int i = 0; i < len0; i++) cost[i] = i;

            // dynamically computing the array of distances                                  

            // transformation cost for each letter in s1                                    
            for (int j = 1; j < len1; j++)
            {
                // initial cost of skipping prefix in String s1                             
                newcost[0] = j;

                // transformation cost for each letter in s0                                
                for (int i = 1; i < len0; i++)
                {
                //    cost = (t.Substring(j - 1, 1) ==
                //s.Substring(i - 1, 1) ? 0 : 1);
                    // matching current letters in both strings                             
                    int match = (s0.ElementAt(i - 1) == s1.ElementAt(j - 1)) ? 0 : 1;
                    
                    // computing cost for each transformation                               
                    int cost_replace = cost[i - 1] + match;
                    int cost_insert = cost[i] + 1;
                    int cost_delete = newcost[i - 1] + 1;

                    // keep minimum cost                                                    
                    newcost[i] = Math.Min(Math.Min(cost_insert, cost_delete), cost_replace);
                }

                // swap cost/newcost arrays                                                 
                int[] swap = cost; cost = newcost; newcost = swap;
            }

            // the distance is the cost for transforming all letters in both strings        
            return cost[len0 - 1];
        }
        
        static List<SearchResults1> SearchforSF(string sDocName, string sFRPDoctorID, string sAddress, string sDegree, string sSpeciality, string sDistrict,
            string sUpzila, string sInstitute, int limit, out int count)
        {
            using (var directory = GetDirectory())
            using (var searcher = new IndexSearcher(directory))
            {
                var query = GetFinalQuery(sDocName, sFRPDoctorID, sAddress, sDegree, sSpeciality, sDistrict, sUpzila, sInstitute);
                //var query = fparseQuery("nurul");
                var sort = GetSort();
                var filter = GetFilter();

                var docs = searcher.Search(query, filter, limit, sort);
                count = docs.TotalHits;

                var products = new List<SearchResults1>();
                foreach (var scoreDoc in docs.ScoreDocs)
                {
                    var doc = searcher.Doc(scoreDoc.Doc);
                    var product = new SearchResults1
                    {
                        ID = Convert.ToInt32(doc.Get("ID")),
                        Code = doc.Get("Code"),
                        BMDCCode = doc.Get("BMDCCode"),
                        DocName = doc.Get("DocName"),
                        Salutation = doc.Get("Salutation"),
                        Speciality1 = doc.Get("Speciality1"),
                        Speciality2 = doc.Get("Speciality2"),
                        Degree1 = doc.Get("Degree1"),
                        Degree2 = doc.Get("Degree2"),
                        Institute = doc.Get("Institute"),
                        Address1 = doc.Get("Address1"),
                        Address2 = doc.Get("Address2"),
                        Address3 = doc.Get("Address3"),
                        District = doc.Get("District"),
                        Upzila = doc.Get("Upzila"),
                        FRPDoctorID = doc.Get("FRPDoctorID"),
                        DOB = doc.Get("DOB"),
                        DOM = doc.Get("DOM"),
                        Status = doc.Get("Status"),
                        RefNo = doc.Get("RefNo"),
                        MobileNo = doc.Get("MobileNo"),
                        Email = doc.Get("Email"),
                        CardAttachment = doc.Get("CardAttachment"),

                    };
                    products.Add(product);
                }

                return products;
            }
        }

        public List<SearchResults1> GetDoctorList(string sTerritoryID, string sConnectionString)
        {

            DataTable oTable = new DataTable();
            BLDoctorTerritoryMapping oBL = new BLDoctorTerritoryMapping();
            var products = new List<SearchResults1>();
            try
            {

                int nMaxVersion = 0;
                oTable = oBL.GetTerritoryDisUpaWiseAllDoctorList(sTerritoryID, nMaxVersion, sConnectionString);

                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow dr in oTable.Rows)
                    {

                        var product = new SearchResults1
                        {
                            ID = Convert.ToInt32(dr["ID"].ToString()),
                            Code = dr["Code"].ToString(),
                            BMDCCode = dr["BMDCCode"].ToString(),
                            DocName = dr["DocName"].ToString(),
                            Salutation = dr["SalCode"].ToString(),
                            Speciality1 = dr["SP1"].ToString(),
                            Speciality2 = dr["SP2"].ToString(),
                            Degree1 = dr["Deg1"].ToString(),
                            Degree2 = dr["Deg2"].ToString(),
                            Institute = dr["Institute"].ToString(),
                            Address1 = dr["Address1"].ToString(),
                            Address2 = dr["Address2"].ToString(),
                            Address3 = dr["Address3"].ToString(),
                            District = dr["DistName"].ToString(),
                            Upzila = dr["UName"].ToString(),
                            FRPDoctorID = dr["4PDoctorID"].ToString(),
                            DOB = Convert.ToDateTime(dr["BirthDay"].ToString()).ToString("dd MMM yyyy"),
                            DOM = Convert.ToDateTime(dr["Mrgday"].ToString()).ToString("dd MMM yyyy"),
                            Status = dr["Status"].ToString(),
                            RefNo = dr["RefNo"].ToString(),
                            MobileNo = dr["MobileNo"].ToString(),
                            Email = dr["Email"].ToString(),
                            CardAttachment = dr["CardAttachement"].ToString(),




                        };
                        products.Add(product);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        [WebMethod(Description = "DownLoadPicture")]
        public string DownLoadPicture(string sfilePath)
        {
            string sBS = "";
            try
            {

                if (sfilePath != "")
                {
                    using (Image image = Image.FromFile(sfilePath))
                    {
                       //Image newimage = resizeImage(image, new Size(480, 640));
                        using (MemoryStream m = new MemoryStream())
                        {
                           
                            image.Save(m, image.RawFormat);
                            byte[] imageBytes = m.ToArray();

                            // Convert byte[] to Base64 String
                            string base64String = Convert.ToBase64String(imageBytes,0,imageBytes.Length,Base64FormattingOptions.InsertLineBreaks);
                            int n = base64String.Length;
                            sBS = base64String;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return sBS;
        }
        
        private static Image resizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }
        //[WebMethod(Description = "Method to ApproveReject DMR Request")]
        //public int ApproveRejectDMRRequest(int nDoctorLogID, int nStatus)
        //{
        //    DoctorLog oDoctorLog = new DoctorLog();
        //    DoctorTerritoryMapping oDocTerrMapping = new DoctorTerritoryMapping();
        //    UserInfo oUserInfo = new UserInfo();
        //    BLDoctorLog oBLDoctorLog = new BLDoctorLog();
        //    BLDoctorTerritoryMapping oBLDocTerrMapping = new BLDoctorTerritoryMapping();
        //    BLUserInfo oBLUserInfo = new BLUserInfo();
        //    BLEmployeeInfo oBLEmployeeInfo = new BLEmployeeInfo();
        //    int nAuthenTicket = 0;

        //    try
        //    {
        //        //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
        //        NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
        //        string connectionString = oValues["ConnectionString2"].ToString();

        //        SqlConnection myConnection = new SqlConnection(connectionString);
        //        myConnection.Open();
        //        // Start transaction.
        //        SqlTransaction myTransaction = myConnection.BeginTransaction();
        //        // Assign command in the current transaction.
        //        SqlCommand myCommand = new SqlCommand();
        //        myCommand.Transaction = myTransaction;
        //        try
        //        {
        //            // …………………….
        //            // Database operations
        //            oDoctorLog = oBLDoctorLog.GetDocotorLog(nDoctorLogID, connectionString);
        //            oDocTerrMapping = oBLDocTerrMapping.GetDocTerrMapping(oDoctorLog.DocID, oDoctorLog.TerritoryID, connectionString);

        //            if (nStatus == 2)
        //            {
        //                oDoctorLog.Status = nStatus;
        //                if (oDoctorLog.Type == 3)
        //                {
        //                    oDocTerrMapping.DocTypeID = 2;
        //                }
        //                else if (oDoctorLog.Type == 4)
        //                {
        //                    oDocTerrMapping.DocTypeID = 1;
        //                }
        //                else if (oDoctorLog.Type == 5)
        //                {
        //                    oDocTerrMapping.Status = nStatus;
        //                }
        //            }
        //            else if (nStatus == 3)
        //            {
        //                oDoctorLog.Status = nStatus;
        //                if (oDoctorLog.Type == 5)
        //                {
        //                    oDocTerrMapping.Status = nStatus;
        //                }
        //            }
        //            else if (nStatus == 4)
        //            {
        //                oDoctorLog.Status = nStatus;
        //                oDocTerrMapping.Status = nStatus;
        //            }

        //            if (nStatus == 2 || nStatus == 4 || (nStatus == 3 & oDoctorLog.Type == 5))
        //            {
        //                int nMaxDoctorLogVersion = oBLDoctorLog.GetMaxDoctorLogVersion(myConnection, myTransaction);
        //                oDoctorLog.Version = nMaxDoctorLogVersion;
        //                oDoctorLog.Action = 2;
        //                oDoctorLog.ModifiedDate = DateTime.Now;
        //                oBLDoctorLog.Save(oDoctorLog, myConnection, myTransaction);
        //            }

        //            int nMaxDoctorVersion = oBLDocTerrMapping.GetMaxDoctorVersion(myConnection, myTransaction);
        //            oDocTerrMapping.Version = nMaxDoctorVersion;
        //            oDocTerrMapping.Action = 2;
        //            oDocTerrMapping.ModifyDatetime = DateTime.Now;
        //            oBLDocTerrMapping.Save(oDocTerrMapping, myConnection, myTransaction);

        //            string sGDDBID = oBLEmployeeInfo.GetGDDBIDByTerritoryID(myConnection, myTransaction, oDoctorLog.TerritoryID);
        //            oUserInfo = oBLUserInfo.GetUserInfo(sGDDBID, connectionString);
        //            oUserInfo.Version = oUserInfo.Version + 1;
        //            oUserInfo.DoctorLogVersion = oUserInfo.DoctorLogVersion + 1;
        //            oUserInfo.DoctorVersion = oUserInfo.DoctorVersion + 1;
        //            oUserInfo.LastUpdateDate = DateTime.Now;
        //            oBLUserInfo.Save(oUserInfo, myConnection, myTransaction);

        //            nAuthenTicket = 1;
        //            myTransaction.Commit();
        //        }
        //        catch (Exception e)
        //        {
        //            myTransaction.Rollback();
        //        }
        //        finally
        //        {
        //            myConnection.Close();
        //        }

        //        return nAuthenTicket;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        [WebMethod(Description = "Method to ApproveReject DMR Request")]
        public string ApproveRejectDMRRequest(int nDoctorLogID, int nStatus, string sDocName, string sBMDCCode, int nMapAddress,
             string sAddress1, string sAddress2, string sAddress3, string sInstitute, int nDistrictID, int nUpazillaID,
            int nMapDegree, int nDegreeID1, int nDegreeID2, int nSalutationID, int nMapSpeciality, int nSpecialtyID1,
            int nSpecialtyID2, string sEmail, string sMobileNo, string sBirthDay, string sMrgday, string sCardAttachement,
            int nProfile, int nSwajanStatus, int nDoctorTypeID, int nRoute, int nSession, int nProd1, int nProd2, int nProd3,
            int nProd4, int nProd5, int nProd6, int nProd7, int nProd8, int nCallFre, int nPstStpCng, string sApprovedBy)
        {
            DoctorLog oDoctorLog = new DoctorLog();
            DoctorTerritoryMapping oDocTerrMapping = new DoctorTerritoryMapping();
            UserInfo oUserInfo = new UserInfo();
            DoctorUpdateRequest oDoctorUpdateRequest = new DoctorUpdateRequest();
            DoctorUpdateRequestLogForRM oDoctorUpdateReqForRM = new DoctorUpdateRequestLogForRM();
            BLDoctorLog oBLDoctorLog = new BLDoctorLog();
            BLDoctorTerritoryMapping oBLDocTerrMapping = new BLDoctorTerritoryMapping();
            BLUserInfo oBLUserInfo = new BLUserInfo();
            BLEmployeeInfo oBLEmployeeInfo = new BLEmployeeInfo();
            BLDoctorUpdateRequest oBLDoctorUpdateReq = new BLDoctorUpdateRequest();
            BLDoctorUpdateRequestLogForRM oBLDoctorUpdateReqForRM = new BLDoctorUpdateRequestLogForRM();
            string sAuthenTicket = "";

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();

                SqlConnection myConnection = new SqlConnection(connectionString);
                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;
                try
                {
                    // …………………….
                    // Database operations

                    int nUserID = 0;
                    nUserID = oBLUserInfo.GetActiveUserIDBYGDDBID(myConnection, myTransaction, sApprovedBy);
                    if (nUserID > 0)
                    {
                        oDoctorLog = oBLDoctorLog.GetDocotorLog(nDoctorLogID, connectionString);
                        oDocTerrMapping = oBLDocTerrMapping.GetDocTerrMapping(oDoctorLog.DocID, oDoctorLog.TerritoryID, connectionString);
                        int nMaxDoctorVersion = oBLDocTerrMapping.GetMaxDoctorVersion(myConnection, myTransaction);

                        if (oDoctorLog.Type == 2 & nStatus == 5 & (nDistrictID == 0 || nUpazillaID == 0 || nDegreeID1 == 0 || nSalutationID == 0 || nSpecialtyID1 == 0 ||
                            nProd1 == 0 || nProd2 == 0 || nProd3 == 0 || nProd4 == 0 || nProd5 == 0 || nProd6 == 0 || nProd7 == 0 || nProd8 == 0 || nRoute == 0 || nProfile == 0 || nPstStpCng == 0))
                            sAuthenTicket = "Require information are empty.";
                        else
                        {
                            if (nStatus == 2 || nStatus == 5)
                            {
                                oDoctorLog.Status = nStatus;
                                if (oDoctorLog.Type == 1 || oDoctorLog.Type == 5)
                                {
                                    oDocTerrMapping.Status = nStatus;
                                }

                                //oDocTerrMapping.DocTypeID = nDoctorTypeID;
                                //oDocTerrMapping.Address = nMapAddress;
                                //oDocTerrMapping.Speciality = nMapSpeciality;
                                //oDocTerrMapping.Degree = nMapDegree;
                                //oDocTerrMapping.SwajanStatus = nSwajanStatus;
                                //oDocTerrMapping.ProfileID = nProfile;
                                //oDocTerrMapping.Prod1 = nProd1;
                                //oDocTerrMapping.Prod2 = nProd2;
                                //oDocTerrMapping.Prod3 = nProd3;
                                //oDocTerrMapping.Prod4 = nProd4;
                                //oDocTerrMapping.Prod5 = nProd5;
                                //oDocTerrMapping.Prod6 = nProd6;
                                //oDocTerrMapping.CallFre = nCallFre;
                                //oDocTerrMapping.RouteID = nRoute;
                                //oDocTerrMapping.SessionID = nSession;
                                //oDocTerrMapping.Status = nStatus;

                                //oBLDocTerrMapping.UpdateDoctorInfo(oDoctorLog.DocID, sBMDCCode, sDocName,nSalutationID, nSpecialtyID1,
                                //    nSpecialtyID2, nDegreeID1, nDegreeID2, sInstitute, sAddress1, sAddress2, sAddress3, nDistrictID, 
                                //    nUpazillaID, Convert.ToDateTime(sBirthDay), Convert.ToDateTime(sMrgday), sMobileNo, sEmail, 
                                //    sCardAttachement, myConnection, myTransaction);

                                //if (oDoctorLog.Type == 1)
                                //{
                                //    oBLDocTerrMapping.InsertDocInfoUpdateLogForRM(oDoctorLog.DocID, oDocTerrMapping.ID.ToInt32, sBMDCCode, sDocName,
                                //        nSalutationID, nSpecialtyID1, nSpecialtyID2, nDegreeID1, nDegreeID2, sInstitute, sAddress1, sAddress2, sAddress3,
                                //        nDistrictID, nUpazillaID, Convert.ToDateTime(sBirthDay), Convert.ToDateTime(sMrgday), sMobileNo, sEmail,   
                                //        sCardAttachement, myConnection, myTransaction);
                                //}

                                else if (oDoctorLog.Type == 2)
                                {
                                    int nMaxDoctorUpdateReqVersion = oBLDoctorUpdateReq.GetMaxDoctorUpdateReqVersion(myConnection, myTransaction);
                                    oDoctorUpdateRequest = oBLDoctorUpdateReq.GetDoctorUpdateReqInfo((int)oDoctorLog.DoctorUpdateReqID, connectionString);
                                    oDoctorUpdateRequest.UpdateStatus = nStatus;
                                    oDoctorUpdateRequest.Version = nMaxDoctorUpdateReqVersion;
                                    oDoctorUpdateRequest.Action = 2;
                                    oBLDoctorUpdateReq.Save(oDoctorUpdateRequest, myConnection, myTransaction);

                                    oDoctorUpdateReqForRM.DoctorUpdateRequestID = (int)oDoctorLog.DoctorUpdateReqID;                                    
                                    oDoctorUpdateReqForRM.DoctorID = oDoctorLog.DocID;
                                    oDoctorUpdateReqForRM.TerritoryID = oDoctorLog.TerritoryID;
                                    oDoctorUpdateReqForRM.DoctorTypeID = nDoctorTypeID;
                                    oDoctorUpdateReqForRM.SwajanStatus = nSwajanStatus;
                                    oDoctorUpdateReqForRM.BMDCCode = sBMDCCode;
                                    oDoctorUpdateReqForRM.DocName = sDocName;
                                    oDoctorUpdateReqForRM.SalutationID = nSalutationID;
                                    oDoctorUpdateReqForRM.SpecialtyID1 = nSpecialtyID1;
                                    oDoctorUpdateReqForRM.SpecialtyID2 = nSpecialtyID2;
                                    oDoctorUpdateReqForRM.DegreeID1 = nDegreeID1;
                                    oDoctorUpdateReqForRM.DegreeID2 = nDegreeID2;
                                    oDoctorUpdateReqForRM.Institute = sInstitute;
                                    oDoctorUpdateReqForRM.Address1 = sAddress1;
                                    oDoctorUpdateReqForRM.Address2 = sAddress2;
                                    oDoctorUpdateReqForRM.Address3 = sAddress3;
                                    oDoctorUpdateReqForRM.DistrictID = nDistrictID;
                                    oDoctorUpdateReqForRM.UpazillaID = nUpazillaID;
                                    oDoctorUpdateReqForRM.BirthDay = Convert.ToDateTime(sBirthDay);
                                    oDoctorUpdateReqForRM.Mrgday = Convert.ToDateTime(sMrgday);
                                    oDoctorUpdateReqForRM.MobileNo = sMobileNo;
                                    oDoctorUpdateReqForRM.Email = sEmail;
                                    oDoctorUpdateReqForRM.MapAddress = nMapAddress;
                                    oDoctorUpdateReqForRM.MapSpeciality = nMapSpeciality;
                                    oDoctorUpdateReqForRM.MapDegree = nMapDegree;
                                    oDoctorUpdateReqForRM.Product1 = nProd1;
                                    oDoctorUpdateReqForRM.Product2 = nProd2;
                                    oDoctorUpdateReqForRM.Product3 = nProd3;
                                    oDoctorUpdateReqForRM.Product4 = nProd4;
                                    oDoctorUpdateReqForRM.Product5 = nProd5;
                                    oDoctorUpdateReqForRM.Product6 = nProd6;
                                    oDoctorUpdateReqForRM.Product7 = nProd7;
                                    oDoctorUpdateReqForRM.Product8 = nProd8;
                                    oDoctorUpdateReqForRM.Profile = nProfile;
                                    oDoctorUpdateReqForRM.Session = nSession;
                                    oDoctorUpdateReqForRM.Route = nRoute;
                                    oDoctorUpdateReqForRM.CallFrequency = nCallFre;
                                    oDoctorUpdateReqForRM.PostStepChange = nPstStpCng;
                                    if (sCardAttachement != "")
                                        oDoctorUpdateReqForRM.CardAttachement = UploadPicture(sCardAttachement, sDocName);
                                    else
                                        oDoctorUpdateReqForRM.CardAttachement = "";
                                    oBLDoctorUpdateReqForRM.Save(oDoctorUpdateReqForRM, myConnection, myTransaction);
                                }
                                else if (oDoctorLog.Type == 3)
                                {
                                    oDocTerrMapping.DocTypeID = 2;
                                }
                                else if (oDoctorLog.Type == 4)
                                {
                                    oDocTerrMapping.DocTypeID = 1;
                                }
                                //else if (oDoctorLog.Type == 5)
                                //{
                                //    oDocTerrMapping.Status = nStatus;
                                //    oBLDocTerrMapping.UpdateDoctorStatus(oDoctorLog.DocID, myConnection, myTransaction);
                                //}
                                if (oDoctorLog.Type != 2)
                                {
                                    oDocTerrMapping.ModifyDatetime = DateTime.Now;
                                    oDocTerrMapping.Version = nMaxDoctorVersion;
                                    oDocTerrMapping.Action = 2;
                                    oBLDocTerrMapping.Save(oDocTerrMapping, myConnection, myTransaction);
                                }
                            }
                            else if (nStatus == 3)
                            {
                                oDoctorLog.Status = nStatus;
                                if (oDoctorLog.Type == 1 || oDoctorLog.Type == 5)
                                {
                                    oDocTerrMapping.Status = nStatus;
                                    oDocTerrMapping.Version = nMaxDoctorVersion;
                                    oDocTerrMapping.Action = 2;
                                    oDocTerrMapping.ModifyDatetime = DateTime.Now;
                                    oBLDocTerrMapping.Save(oDocTerrMapping, myConnection, myTransaction);
                                }
                                else if (oDoctorLog.Type == 2)
                                {
                                    int nMaxDoctorUpdateReqVersion = oBLDoctorUpdateReq.GetMaxDoctorUpdateReqVersion(myConnection, myTransaction);
                                    oDoctorUpdateRequest = oBLDoctorUpdateReq.GetDoctorUpdateReqInfo((int)oDoctorLog.DoctorUpdateReqID, connectionString);
                                    oDoctorUpdateRequest.UpdateStatus = nStatus;
                                    oDoctorUpdateRequest.Version = nMaxDoctorUpdateReqVersion;
                                    oDoctorUpdateRequest.Action = 2;
                                    oBLDoctorUpdateReq.Save(oDoctorUpdateRequest, myConnection, myTransaction);
                                }
                            }
                            else if (nStatus == 4)
                            {
                                oDoctorLog.Status = nStatus;
                                oDocTerrMapping.Status = nStatus;
                                oDocTerrMapping.ModifyDatetime = DateTime.Now;
                                oDocTerrMapping.Version = nMaxDoctorVersion;
                                oDocTerrMapping.Action = 2;
                                oBLDocTerrMapping.Save(oDocTerrMapping, myConnection, myTransaction);
                            }

                            int nMaxDoctorLogVersion = oBLDoctorLog.GetMaxDoctorLogVersion(myConnection, myTransaction);
                            oDoctorLog.ModifiedByRM = nUserID;
                            oDoctorLog.ModifiedDateRM = DateTime.Now;
                            oDoctorLog.Version = nMaxDoctorLogVersion;
                            oDoctorLog.Action = 2;
                            oBLDoctorLog.Save(oDoctorLog, myConnection, myTransaction);

                            string sGDDBID = oBLEmployeeInfo.GetGDDBIDByTerritoryID(myConnection, myTransaction, oDoctorLog.TerritoryID);
                            oUserInfo = oBLUserInfo.GetUserInfo(sGDDBID, connectionString);
                            oUserInfo.Version = oUserInfo.Version + 1;
                            oUserInfo.DoctorLogVersion = oUserInfo.DoctorLogVersion + 1;
                            if (oDoctorLog.Type != 2)
                                oUserInfo.DoctorVersion = oUserInfo.DoctorVersion + 1;
                            oUserInfo.LastUpdateDate = DateTime.Now;
                            oBLUserInfo.Save(oUserInfo, myConnection, myTransaction);

                            oBLDocTerrMapping.InsertDMRCommandInfo(oDoctorLog.TerritoryID, myConnection, myTransaction);

                            sAuthenTicket = "1";
                        }
                    }
                    myTransaction.Commit();
                }
                catch (Exception e)
                {
                    sAuthenTicket = e.Message.ToString();
                    myTransaction.Rollback();
                }
                finally
                {
                    myConnection.Close();
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                    sAuthenTicket = "Cannot connect to database.";
                else
                    sAuthenTicket = ex.Message.ToString();
                //throw new Exception(ex.Message);
            }

            return sAuthenTicket;
        }
        
        [WebMethod(Description = "Method to save DMR Request")]
        public string SaveDMRRequest(int nDocID, string sBMDCCode, int nSalutationID, int nSpecialtyID1, int nSpecialtyID2, int nDegreeID1, int nDegreeID2,
          string sInstitute, string sAddress1, string sAddress2, string sAddress3, int nDistrictID, string sDocName, int nUpazillaID, string sBirthDay,
          int nStatus, string sMrgday, string sMobileNo, string sEmail, string sTerritoryID, int nType, int nDocTypeID, int nMapAddress, int nMapSpeciality,
          int nMapDegree, int nProd1, int nProd2, int nProd3, int nProd4, int nProd5, int nProd6, int nProd7, int nProd8, int nProfileID, int nRouteID, int nSessionID, int nCallFre,
          int nSwajanStatus, string sCardAttachement, int nPstStpCng, string sGDDBID)
        {
            DoctorTerritoryMapping oDocTerrMapping = new DoctorTerritoryMapping();
            BLDoctorTerritoryMapping oBLDocTerrMapping = new BLDoctorTerritoryMapping();
            string sAuthenTicket = "0";

            try
            {
                //string connectionString = "Data Source=GXBDDA-S3010\\FAST;User ID=sa;Password=Tamamyl1;Initial Catalog=FAST;";
                NameValueCollection oValues = (NameValueCollection)ConfigurationSettings.GetConfig("appSettings");
                string connectionString = oValues["ConnectionString2"].ToString();

                SqlConnection myConnection = new SqlConnection(connectionString);

                myConnection.Open();
                string sValue1 = "sBMDCCode=" + sBMDCCode + " || sTerritoryID=" + sTerritoryID + " || sDocName=" + sDocName + " || nSwajanStatus=" + nSwajanStatus + " || nDocTypeID=" + nDocTypeID + " || nSalutationID=" + nSalutationID + " || nSpecialtyID1=" + nSpecialtyID1 +
                " || nSpecialtyID2=" + nSpecialtyID2 + " || nDegreeID1=" + nDegreeID1 + " || nDegreeID2=" + nDegreeID2 + " || nProfileID=" + nProfileID + " || nProd1=" + nProd1 + " || nProd2=" + nProd2 + " || nProd3=" + nProd3 + " || nProd4=" + nProd4 + " || nProd5=" + nProd5 +
                " || nProd6=" + nProd6 + " || nProd7=" + nProd7 + " || nProd8=" + nProd8 + " || nCallFre=" + nCallFre + " || sInstitute=" + sInstitute + " || sAddress1=" + sAddress1 + " || sAddress2=" + sAddress2 + " || sAddress3=" + sAddress3 + " || nDistrictID=" + nDistrictID + " || nUpazillaID=" + nUpazillaID +
                " || nRouteID=" + nRouteID + " || nSessionID=" + nSessionID + " || sBirthDay=" + Convert.ToDateTime(sBirthDay) + " || sMrgday=" + Convert.ToDateTime(sMrgday) + " || sMobileNo=" + sMobileNo + " || sEmail=" + sEmail + " || sCardAttachement=" + sCardAttachement +
                " || nStatus=" + nStatus + " || nType=" + nType + " || nMapAddress=" + nMapAddress + " || nMapSpeciality=" + nMapSpeciality + " || nMapDegree=" + nMapDegree;

                oBLDocTerrMapping.InsertParameterLog(sTerritoryID, sValue1, sException, myConnection);
                myConnection.Close();

                myConnection.Open();
                // Start transaction.
                SqlTransaction myTransaction = myConnection.BeginTransaction();
                // Assign command in the current transaction.
                SqlCommand myCommand = new SqlCommand();
                myCommand.Transaction = myTransaction;
                try
                {

                    int nTotalDoctor = oBLDocTerrMapping.GetTotalDoctor(sTerritoryID, myConnection, myTransaction);
                    int nDocCount = oBLDocTerrMapping.GetDocCount(sTerritoryID, myConnection, myTransaction);
                    int nDocPending = oBLDocTerrMapping.GetDocCountPending(sTerritoryID, myConnection, myTransaction);

                    int nCount = nTotalDoctor - (nDocCount + nDocPending);


                    if (sTerritoryID != "" && nProd1 != 0 && nRouteID != 0 && nProfileID != 0 && nDocTypeID != 0 && nPstStpCng != 0)
                    {
                        string sImgLoc = "";
                        try
                        {
                            if (sCardAttachement != "")
                            {
                                sImgLoc = UploadPicture(sCardAttachement, sDocName);
                            }
                        }
                        catch (Exception ex)
                        {
                            sException = sException + " Line5: " + ex.Message.ToString();
                            throw new Exception(ex.Message);
                        }

                        if (nType == 2)
                        {
                            sAuthenTicket = oBLDocTerrMapping.UpdateMappingBySF(nDocID, sBMDCCode, nSalutationID, nSpecialtyID1, nSpecialtyID2, nDegreeID1, nDegreeID2, sInstitute,
                                  sAddress1, sAddress2, sAddress3, nDistrictID, sDocName, nUpazillaID, Convert.ToDateTime(sBirthDay), nStatus, Convert.ToDateTime(sMrgday),
                                  sMobileNo, sEmail, sTerritoryID, nType, nDocTypeID, nMapAddress, nMapSpeciality, nMapDegree, nProd1, nProd2, nProd3, nProd4, nProd5,
                                  nProd6, nProd7, nProd8, nProfileID, nRouteID, nSessionID, nCallFre, nSwajanStatus, sImgLoc, nPstStpCng, sGDDBID, myConnection, myTransaction);
                            sAuthenTicket = "1; ;" + sAuthenTicket;
                        }

                        else if (nType == 5)
                        {
                            if (nCount > 0 || nDocTypeID == 2)
                            {
                                sAuthenTicket = oBLDocTerrMapping.AddNewDoctor(sBMDCCode, sTerritoryID, sDocName, nSwajanStatus, nDocTypeID, nSalutationID, nSpecialtyID1,
                                       nSpecialtyID2, nDegreeID1, nDegreeID2, nProfileID, nProd1, nProd2, nProd3, nProd4, nProd5, nProd6, nProd7, nProd8, nCallFre, sInstitute,
                                       sAddress1, sAddress2, sAddress3, nDistrictID, nUpazillaID, nRouteID, nSessionID, Convert.ToDateTime(sBirthDay), Convert.ToDateTime(sMrgday),
                                       sMobileNo, sEmail, sImgLoc, nStatus, nType, nMapAddress, nMapSpeciality, nMapDegree, nPstStpCng, sGDDBID, myConnection, myTransaction);
                                sAuthenTicket = "1;" + sAuthenTicket;
                            }
                        }

                        else if (nType == 1)
                        {
                            if (nCount > 0 || nDocTypeID == 2)
                            {
                                sAuthenTicket = oBLDocTerrMapping.AddExistingDoctor(nDocID, sTerritoryID, nDocTypeID, nSwajanStatus, nProfileID, nProd1, nProd2, nProd3, nProd4,
                                      nProd5, nProd6, nProd7, nProd8, nCallFre, nRouteID, nStatus, nType, nSessionID, nMapAddress, nMapSpeciality, nMapDegree, nPstStpCng, sGDDBID, myConnection, myTransaction);

                                if (sAuthenTicket == "")
                                {
                                    sAuthenTicket = "This doctor already added in your territory.";
                                }
                                else
                                {
                                    sAuthenTicket = "1; ;" + sAuthenTicket;
                                }
                            }
                        }

                    }
                    else
                    {
                        sAuthenTicket = "Input fields are providing 0.";
                    }

                    myTransaction.Commit();
                }
                catch (Exception e)
                {
                    sAuthenTicket = e.Message.ToString();
                    myTransaction.Rollback();

                    string sValue2 = "sBMDCCode=" + sBMDCCode + " || sTerritoryID=" + sTerritoryID + " || sDocName=" + sDocName + " || nSwajanStatus=" + nSwajanStatus + " || nDocTypeID=" + nDocTypeID + " || nSalutationID=" + nSalutationID + " || nSpecialtyID1=" + nSpecialtyID1 +
                    " || nSpecialtyID2=" + nSpecialtyID2 + " || nDegreeID1=" + nDegreeID1 + " || nDegreeID2=" + nDegreeID2 + " || nProfileID=" + nProfileID + " || nProd1=" + nProd1 + " || nProd2=" + nProd2 + " || nProd3=" + nProd3 + " || nProd4=" + nProd4 + " || nProd5=" + nProd5 +
                    " || nProd6=" + nProd6 + " || nProd7=" + nProd7 + " || nProd8=" + nProd8 + " || nCallFre=" + nCallFre + " || sInstitute=" + sInstitute + " || sAddress1=" + sAddress1 + " || sAddress2=" + sAddress2 + " || sAddress3=" + sAddress3 + " || nDistrictID=" + nDistrictID + " || nUpazillaID=" + nUpazillaID +
                    " || nRouteID=" + nRouteID + " || nSessionID=" + nSessionID + " || sBirthDay=" + Convert.ToDateTime(sBirthDay) + " || sMrgday=" + Convert.ToDateTime(sMrgday) + " || sMobileNo=" + sMobileNo + " || sEmail=" + sEmail + " || sCardAttachement=" + sCardAttachement +
                    " || nStatus=" + nStatus + " || nType=" + nType + " || nMapAddress=" + nMapAddress + " || nMapSpeciality=" + nMapSpeciality + " || nMapDegree=" + nMapDegree;

                    oBLDocTerrMapping.InsertParameterLog(sTerritoryID, sValue2, sException, myConnection);
                }
                finally
                {
                    myConnection.Close();
                }
               
            }

            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}


            catch (Exception ex)
            {
                if (ex is SqlException)
                    sAuthenTicket = "Cannot connect to database.";
                else
                    sAuthenTicket = ex.Message.ToString();
                //throw new Exception(ex.Message);
            }

            return sAuthenTicket;

        }
        
    }
}





