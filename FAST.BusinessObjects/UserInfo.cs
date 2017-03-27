using System;
using System.Collections;
using FAST.Core.BusinessObject;
namespace FAST.BusinessObjects
{
	[Serializable]
	public class UserInfo : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
		private int _nUserID;
		public int UserID
		{
			get
			{
				return _nUserID;
			}
			set
			{
				_nUserID = value;
			}
		}

		private string _sGDDBID;
		public string GDDBID
		{
			get
			{
				return _sGDDBID;
			}
			set
			{
				_sGDDBID = value;
			}
		}

		private int _nVersion;
		public int Version
		{
			get
			{
				return _nVersion;
			}
			set
			{
				_nVersion = value;
			}
		}

		private int _nCommandVersion;
		public int CommandVersion
		{
			get
			{
				return _nCommandVersion;
			}
			set
			{
				_nCommandVersion = value;
			}
		}

		private int _nAppConfigVersion;
		public int AppConfigVersion
		{
			get
			{
				return _nAppConfigVersion;
			}
			set
			{
				_nAppConfigVersion = value;
			}
		}

		private int _nDoctorVersion;
		public int DoctorVersion
		{
			get
			{
				return _nDoctorVersion;
			}
			set
			{
				_nDoctorVersion = value;
			}
		}

		private int _nDoctorReqVersion;
		public int DoctorReqVersion
		{
			get
			{
				return _nDoctorReqVersion;
			}
			set
			{
				_nDoctorReqVersion = value;
			}
		}

		private int _nDoctorLogVersion;
		public int DoctorLogVersion
		{
			get
			{
				return _nDoctorLogVersion;
			}
			set
			{
				_nDoctorLogVersion = value;
			}
		}

		private int _nRouteVersion;
		public int RouteVersion
		{
			get
			{
				return _nRouteVersion;
			}
			set
			{
				_nRouteVersion = value;
			}
		}

		private int _nDegreeVersion;
		public int DegreeVersion
		{
			get
			{
				return _nDegreeVersion;
			}
			set
			{
				_nDegreeVersion = value;
			}
		}

		private int _nSpecialtyVersion;
		public int SpecialtyVersion
		{
			get
			{
				return _nSpecialtyVersion;
			}
			set
			{
				_nSpecialtyVersion = value;
			}
		}

		private int _nSalutationVersion;
		public int SalutationVersion
		{
			get
			{
				return _nSalutationVersion;
			}
			set
			{
				_nSalutationVersion = value;
			}
		}

		private int _nDistrictVersion;
		public int DistrictVersion
		{
			get
			{
				return _nDistrictVersion;
			}
			set
			{
				_nDistrictVersion = value;
			}
		}

		private int _nUpazillaVersion;
		public int UpazillaVersion
		{
			get
			{
				return _nUpazillaVersion;
			}
			set
			{
				_nUpazillaVersion = value;
			}
		}

		private int _nLineSpeProductVersion;
		public int LineSpeProductVersion
		{
			get
			{
				return _nLineSpeProductVersion;
			}
			set
			{
				_nLineSpeProductVersion = value;
			}
		}

		private int _nGimmickVersion;
		public int GimmickVersion
		{
			get
			{
				return _nGimmickVersion;
			}
			set
			{
				_nGimmickVersion = value;
			}
		}

		private int _nSampleVersion;
		public int SampleVersion
		{
			get
			{
				return _nSampleVersion;
			}
			set
			{
				_nSampleVersion = value;
			}
		}

		private int _nHolidayVersion;
		public int HolidayVersion
		{
			get
			{
				return _nHolidayVersion;
			}
			set
			{
				_nHolidayVersion = value;
			}
		}

		private int _nBrandVersion;
		public int BrandVersion
		{
			get
			{
				return _nBrandVersion;
			}
			set
			{
				_nBrandVersion = value;
			}
		}

		private int _nReasonVersion;
		public int ReasonVersion
		{
			get
			{
				return _nReasonVersion;
			}
			set
			{
				_nReasonVersion = value;
			}
		}

		private int _nPVPVersion;
		public int PVPVersion
		{
			get
			{
				return _nPVPVersion;
			}
			set
			{
				_nPVPVersion = value;
			}
		}

		private int _nPVPWorkingDayVersion;
		public int PVPWorkingDayVersion
		{
			get
			{
				return _nPVPWorkingDayVersion;
			}
			set
			{
				_nPVPWorkingDayVersion = value;
			}
		}

		private int _nDCRVersion;
		public int DCRVersion
		{
			get
			{
				return _nDCRVersion;
			}
			set
			{
				_nDCRVersion = value;
			}
		}

		private int _nAppVersion;
		public int AppVersion
		{
			get
			{
				return _nAppVersion;
			}
			set
			{
				_nAppVersion = value;
			}
		}

		private int _nNoOfTargetDoctor;
		public int NoOfTargetDoctor
		{
			get
			{
				return _nNoOfTargetDoctor;
			}
			set
			{
				_nNoOfTargetDoctor = value;
			}
		}

		private DateTime _dEntryDate;
		public DateTime EntryDate
		{
			get
			{
				return _dEntryDate;
			}
			set
			{
				_dEntryDate = value;
			}
		}

		private DateTime _dLastUpdateDate;
		public DateTime LastUpdateDate
		{
			get
			{
				return _dLastUpdateDate;
			}
			set
			{
				_dLastUpdateDate = value;
			}
		}

        private int _nUserType;
        public int UserType
        {
            get
            {
                return _nUserType;
            }
            set
            {
                _nUserType = value;
            }
        }

		private bool _bIsActive;
		public bool IsActive
		{
			get
			{
				return _bIsActive;
			}
			set
			{
				_bIsActive = value;
			}
		}

		#endregion
		#region Constructor & Destructor
		public UserInfo()
		{
			_bIsDisposed=false;
			_nUserID = 0;
			_sGDDBID = "";
			_nVersion = 0;
			_nCommandVersion = 0;
			_nAppConfigVersion = 0;
			_nDoctorVersion = 0;
			_nDoctorReqVersion = 0;
			_nDoctorLogVersion = 0;
			_nRouteVersion = 0;
			_nDegreeVersion = 0;
			_nSpecialtyVersion = 0;
			_nSalutationVersion = 0;
			_nDistrictVersion = 0;
			_nUpazillaVersion = 0;
			_nLineSpeProductVersion = 0;
			_nGimmickVersion = 0;
			_nSampleVersion = 0;
			_nHolidayVersion = 0;
			_nBrandVersion = 0;
			_nReasonVersion = 0;
			_nPVPVersion = 0;
			_nPVPWorkingDayVersion = 0;
			_nDCRVersion = 0;
			_nAppVersion = 0;
			_nNoOfTargetDoctor = 0;
			_dEntryDate = DateTime.Today;
			_dLastUpdateDate = DateTime.Today;
            _nUserType = 0;
			_bIsActive = false;
		}
		~UserInfo()
		{
			Dispose(false);
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool bDisposing)
		{
			if (!_bIsDisposed)
			{
				if (bDisposing)
				{
				};
			}
			_bIsDisposed = true;
		}
		#endregion
	}
	[Serializable]
	public class UserInfos : CollectionBase,IEnumerable
	{
		public UserInfos()
		{
			InnerList.Clear();		}
		public void Add(UserInfo oItem)
		{
			InnerList.Add(oItem);
		}
		public UserInfo this[int i]
		{
			 get { return (UserInfo)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			UserInfo oItem = new UserInfo();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (UserInfo)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public UserInfo GetUserInfo(int nID)
		{
			UserInfo oItem = new UserInfo();
			foreach (UserInfo oUserInfo in this)
			{
				if (oUserInfo.ID.ToInt32 == nID)
				{
					oItem = oUserInfo;
					break;
				}
			}
			return oItem;
		}
	}
}
