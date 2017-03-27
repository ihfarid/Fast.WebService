using System;
using System.Collections;
using FAST.Core.BusinessObject;
using FAST.Core;
namespace FAST.BusinessObjects
{
	[Serializable]
	public class SFRegiInfo : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;

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

		private int _nEmployeeID;
		public int EmployeeID
		{
			get
			{
				return _nEmployeeID;
			}
			set
			{
				_nEmployeeID = value;
			}
		}

		private int _nTerritoryID;
		public int TerritoryID
		{
			get
			{
				return _nTerritoryID;
			}
			set
			{
				_nTerritoryID = value;
			}
		}

		private int _nSecQuesID;
		public int SecQuesID
		{
			get
			{
				return _nSecQuesID;
			}
			set
			{
				_nSecQuesID = value;
			}
		}

		private string _sSecQuesAns;
		public string SecQuesAns
		{
			get
			{
				return _sSecQuesAns;
			}
			set
			{
				_sSecQuesAns = value;
			}
		}

		private string _sPassWord;
		public string PassWord
		{
			get
			{
				return _sPassWord;
			}
			set
			{
				_sPassWord = value;
			}
		}

		private string _sMessage;
		public string Message
		{
			get
			{
				return _sMessage;
			}
			set
			{
				_sMessage = value;
			}
		}

		private string _sMobile;
		public string Mobile
		{
			get
			{
				return _sMobile;
			}
			set
			{
				_sMobile = value;
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

        private int _nCustomerVersion;
        public int CustomerVersion
        {
            get
            {
                return _nCustomerVersion;
            }
            set
            {
                _nCustomerVersion = value;
            }
        }

        private int _nProductVersion;
        public int ProductVersion
        {
            get
            {
                return _nProductVersion;
            }
            set
            {
                _nProductVersion = value;
            }
        }

        private int _nProductBarVersion;
        public int ProductBarVersion
        {
            get
            {
                return _nProductBarVersion;
            }
            set
            {
                _nProductBarVersion = value;
            }
        }

        private int _nOrderVersion;
        public int OrderVersion
        {
            get
            {
                return _nOrderVersion;
            }
            set
            {
                _nOrderVersion = value;
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
        
        private int _nSalesReportVersion;
        public int SalesReportVersion
        {
            get
            {
                return _nSalesReportVersion;
            }
            set
            {
                _nSalesReportVersion = value;
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

        private string _sBU;
        public string BU
        {
            get
            {
                return _sBU;
            }
            set
            {
                _sBU = value;
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
		public SFRegiInfo()
		{
			_bIsDisposed=false;
			_sGDDBID = "";
			_nEmployeeID = 0;
			_nTerritoryID = 0;
			_nSecQuesID = 0;
			_sSecQuesAns = "";
			_sPassWord = "";
			_sMessage = "";
			_sMobile = "";
			_dEntryDate = DateTime.Today;
			_dLastUpdateDate = DateTime.Today;
            _nVersion = 0;
            _nCommandVersion = 0;
            _nCustomerVersion = 0;
            _nProductVersion = 0;
            _nProductBarVersion = 0;
            _nOrderVersion = 0;
            _nAppConfigVersion = 0;
            _nSalesReportVersion = 0;
            _nAppVersion = 0;
            _sBU = null;
			_bIsActive = false;
		}
		~SFRegiInfo()
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
	public class SFRegiInfos : CollectionBase,IEnumerable
	{
		public SFRegiInfos()
		{
			InnerList.Clear();		}
		public void Add(SFRegiInfo oItem)
		{
			InnerList.Add(oItem);
		}
		public SFRegiInfo this[int i]
		{
			 get { return (SFRegiInfo)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			SFRegiInfo oItem = new SFRegiInfo();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (SFRegiInfo)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public SFRegiInfo GetSFRegiInfo(int nID)
		{
			SFRegiInfo oItem = new SFRegiInfo();
			foreach (SFRegiInfo oSFRegiInfo in this)
			{
				if (oSFRegiInfo.ID.ToInt32 == nID)
				{
					oItem = oSFRegiInfo;
					break;
				}
			}
			return oItem;
		}
	}
}
