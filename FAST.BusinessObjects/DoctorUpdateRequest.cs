using System;
using System.Collections;
using FAST.Core.BusinessObject;
namespace FAST.BusinessObjects
{
	[Serializable]
	public class DoctorUpdateRequest : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
		private int _nDoctorUpdateRequestID;
		public int DoctorUpdateRequestID
		{
			get
			{
				return _nDoctorUpdateRequestID;
			}
			set
			{
				_nDoctorUpdateRequestID = value;
			}
		}

		private int? _nDoctorID;
		public int? DoctorID
		{
			get
			{
				return _nDoctorID;
			}
			set
			{
				_nDoctorID = value;
			}
		}

		private string _sTerritoryID;
		public string TerritoryID
		{
			get
			{
				return _sTerritoryID;
			}
			set
			{
				_sTerritoryID = value;
			}
		}

		private int? _nDoctorTypeID;
		public int? DoctorTypeID
		{
			get
			{
				return _nDoctorTypeID;
			}
			set
			{
				_nDoctorTypeID = value;
			}
		}

		private string _sCode;
		public string Code
		{
			get
			{
				return _sCode;
			}
			set
			{
				_sCode = value;
			}
		}

		private int _nSwajanStatus;
		public int SwajanStatus
		{
			get
			{
				return _nSwajanStatus;
			}
			set
			{
				_nSwajanStatus = value;
			}
		}

		private string _sBMDCCode;
		public string BMDCCode
		{
			get
			{
				return _sBMDCCode;
			}
			set
			{
				_sBMDCCode = value;
			}
		}

		private string _sDocName;
		public string DocName
		{
			get
			{
				return _sDocName;
			}
			set
			{
				_sDocName = value;
			}
		}

		private int? _nSalutationID;
		public int? SalutationID
		{
			get
			{
				return _nSalutationID;
			}
			set
			{
				_nSalutationID = value;
			}
		}

		private int? _nSpecialtyID1;
		public int? SpecialtyID1
		{
			get
			{
				return _nSpecialtyID1;
			}
			set
			{
				_nSpecialtyID1 = value;
			}
		}

		private int? _nSpecialtyID2;
		public int? SpecialtyID2
		{
			get
			{
				return _nSpecialtyID2;
			}
			set
			{
				_nSpecialtyID2 = value;
			}
		}

		private int? _nDegreeID1;
		public int? DegreeID1
		{
			get
			{
				return _nDegreeID1;
			}
			set
			{
				_nDegreeID1 = value;
			}
		}

		private int? _nDegreeID2;
		public int? DegreeID2
		{
			get
			{
				return _nDegreeID2;
			}
			set
			{
				_nDegreeID2 = value;
			}
		}

		private string _sInstitute;
		public string Institute
		{
			get
			{
				return _sInstitute;
			}
			set
			{
				_sInstitute = value;
			}
		}

		private string _sAddress1;
		public string Address1
		{
			get
			{
				return _sAddress1;
			}
			set
			{
				_sAddress1 = value;
			}
		}

		private string _sAddress2;
		public string Address2
		{
			get
			{
				return _sAddress2;
			}
			set
			{
				_sAddress2 = value;
			}
		}

		private string _sAddress3;
		public string Address3
		{
			get
			{
				return _sAddress3;
			}
			set
			{
				_sAddress3 = value;
			}
		}

		private int _nDistrictID;
		public int DistrictID
		{
			get
			{
				return _nDistrictID;
			}
			set
			{
				_nDistrictID = value;
			}
		}

		private int _nUpazillaID;
		public int UpazillaID
		{
			get
			{
				return _nUpazillaID;
			}
			set
			{
				_nUpazillaID = value;
			}
		}

		private DateTime _dBirthDay;
		public DateTime BirthDay
		{
			get
			{
				return _dBirthDay;
			}
			set
			{
				_dBirthDay = value;
			}
		}

		private DateTime _dMrgday;
		public DateTime Mrgday
		{
			get
			{
				return _dMrgday;
			}
			set
			{
				_dMrgday = value;
			}
		}

		private int? _nUpdateStatus;
		public int? UpdateStatus
		{
			get
			{
				return _nUpdateStatus;
			}
			set
			{
				_nUpdateStatus = value;
			}
		}

        private int? _nPostStepChange;
        public int? PostStepChange
        {
            get
            {
                return _nPostStepChange;
            }
            set
            {
                _nPostStepChange = value;
            }
        }

		private string _sMobileNo;
		public string MobileNo
		{
			get
			{
				return _sMobileNo;
			}
			set
			{
				_sMobileNo = value;
			}
		}

		private string _sEmail;
		public string Email
		{
			get
			{
				return _sEmail;
			}
			set
			{
				_sEmail = value;
			}
		}

		private int _nMapAddress;
		public int MapAddress
		{
			get
			{
				return _nMapAddress;
			}
			set
			{
				_nMapAddress = value;
			}
		}

		private int _nMapSpeciality;
		public int MapSpeciality
		{
			get
			{
				return _nMapSpeciality;
			}
			set
			{
				_nMapSpeciality = value;
			}
		}

		private int _nMapDegree;
		public int MapDegree
		{
			get
			{
				return _nMapDegree;
			}
			set
			{
				_nMapDegree = value;
			}
		}

		private int _nProduct1;
		public int Product1
		{
			get
			{
				return _nProduct1;
			}
			set
			{
				_nProduct1 = value;
			}
		}

        private int _nProduct2;
        public int Product2
		{
			get
			{
				return _nProduct2;
			}
			set
			{
				_nProduct2 = value;
			}
		}

        private int _nProduct3;
        public int Product3
		{
			get
			{
				return _nProduct3;
			}
			set
			{
				_nProduct3 = value;
			}
		}

        private int _nProduct4;
        public int Product4
		{
			get
			{
				return _nProduct4;
			}
			set
			{
				_nProduct4 = value;
			}
		}

        private int _nProduct5;
        public int Product5
		{
			get
			{
				return _nProduct5;
			}
			set
			{
				_nProduct5 = value;
			}
		}

        private int _nProduct6;
        public int Product6
		{
			get
			{
				return _nProduct6;
			}
			set
			{
				_nProduct6 = value;
			}
		}

        private int _nProduct7;
        public int Product7
        {
            get
            {
                return _nProduct7;
            }
            set
            {
                _nProduct7 = value;
            }
        }

        private int _nProduct8;
        public int Product8
        {
            get
            {
                return _nProduct8;
            }
            set
            {
                _nProduct8 = value;
            }
        }

        private int _nProfile;
        public int Profile
		{
			get
			{
				return _nProfile;
			}
			set
			{
				_nProfile = value;
			}
		}

        private int _nSession;
        public int Session
		{
			get
			{
				return _nSession;
			}
			set
			{
				_nSession = value;
			}
		}

        private int _nRoute;
        public int Route
		{
			get
			{
				return _nRoute;
			}
			set
			{
				_nRoute = value;
			}
		}

		private int? _nCallFrequency;
		public int? CallFrequency
		{
			get
			{
				return _nCallFrequency;
			}
			set
			{
				_nCallFrequency = value;
			}
		}

		private string _sCardAttachement;
		public string CardAttachement
		{
			get
			{
				return _sCardAttachement;
			}
			set
			{
				_sCardAttachement = value;
			}
		}

		private int? _nAction;
		public int? Action
		{
			get
			{
				return _nAction;
			}
			set
			{
				_nAction = value;
			}
		}

		private int? _nVersion;
		public int? Version
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

		#endregion
		#region Constructor & Destructor
		public DoctorUpdateRequest()
		{
			_bIsDisposed=false;
			_nDoctorUpdateRequestID = 0;
			_nDoctorID = null;
			_sTerritoryID = null;
			_nDoctorTypeID = null;
			_sCode = null;
			_nSwajanStatus = 0;
			_sBMDCCode = null;
			_sDocName = "";
			_nSalutationID = null;
			_nSpecialtyID1 = null;
			_nSpecialtyID2 = null;
			_nDegreeID1 = null;
			_nDegreeID2 = null;
			_sInstitute = null;
			_sAddress1 = null;
			_sAddress2 = null;
			_sAddress3 = null;
			_nDistrictID = 0;
			_nUpazillaID = 0;
			_dBirthDay = DateTime.Now;
            _dMrgday = DateTime.Now;
			_nUpdateStatus = null;
			_sMobileNo = "";
			_sEmail = null;
			_nMapAddress = 0;
			_nMapSpeciality = 0;
			_nMapDegree = 0;
			_nProduct1 = 0;
			_nProduct2 = 0;
			_nProduct3 = 0;
			_nProduct4 = 0;
			_nProduct5 = 0;
			_nProduct6 = 0;
            _nProduct7 = 0;
            _nProduct8 = 0;
			_nProfile = 0;
			_nSession = 0;
			_nRoute = 0;
			_nCallFrequency = null;
			_sCardAttachement = "";
			_nAction = null;
			_nVersion = null;
            _nPostStepChange = 0;
		}
		~DoctorUpdateRequest()
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
	public class DoctorUpdateRequests : CollectionBase,IEnumerable
	{
		public DoctorUpdateRequests()
		{
			InnerList.Clear();		}
		public void Add(DoctorUpdateRequest oItem)
		{
			InnerList.Add(oItem);
		}
		public DoctorUpdateRequest this[int i]
		{
			 get { return (DoctorUpdateRequest)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			DoctorUpdateRequest oItem = new DoctorUpdateRequest();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (DoctorUpdateRequest)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public DoctorUpdateRequest GetDoctorUpdateRequest(int nID)
		{
			DoctorUpdateRequest oItem = new DoctorUpdateRequest();
			foreach (DoctorUpdateRequest oDoctorUpdateRequest in this)
			{
				if (oDoctorUpdateRequest.ID.ToInt32 == nID)
				{
					oItem = oDoctorUpdateRequest;
					break;
				}
			}
			return oItem;
		}
	}
}
