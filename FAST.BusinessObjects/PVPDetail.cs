using System;
using System.Collections;
using FAST.Core.BusinessObject;
namespace FAST.BusinessObjects
{
	[Serializable]
	public class PVPDetail : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
		private int _nDetailID;
		public int DetailID
		{
			get
			{
				return _nDetailID;
			}
			set
			{
				_nDetailID = value;
			}
		}

		private int _nPvpID;
		public int PvpID
		{
			get
			{
				return _nPvpID;
			}
			set
			{
				_nPvpID = value;
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

		private int _nDay;
		public int Day
		{
			get
			{
				return _nDay;
			}
			set
			{
				_nDay = value;
			}
		}

		private int _nMonth;
		public int Month
		{
			get
			{
				return _nMonth;
			}
			set
			{
				_nMonth = value;
			}
		}

		private int _nYear;
		public int Year
		{
			get
			{
				return _nYear;
			}
			set
			{
				_nYear = value;
			}
		}

		private int? _nBrand1;
		public int? Brand1
		{
			get
			{
				return _nBrand1;
			}
			set
			{
				_nBrand1 = value;
			}
		}

		private int? _nBrand2;
		public int? Brand2
		{
			get
			{
				return _nBrand2;
			}
			set
			{
				_nBrand2 = value;
			}
		}

		private int? _nBrand3;
		public int? Brand3
		{
			get
			{
				return _nBrand3;
			}
			set
			{
				_nBrand3 = value;
			}
		}

		private int? _nBrand4;
		public int? Brand4
		{
			get
			{
				return _nBrand4;
			}
			set
			{
				_nBrand4 = value;
			}
		}

		private int? _nBrand5;
		public int? Brand5
		{
			get
			{
				return _nBrand5;
			}
			set
			{
				_nBrand5 = value;
			}
		}

        private int? _nBrand6;
        public int? Brand6
        {
            get
            {
                return _nBrand6;
            }
            set
            {
                _nBrand6 = value;
            }
        }

		private int? _nBrand7;
		public int? Brand7
		{
			get
			{
				return _nBrand7;
			}
			set
			{
				_nBrand7 = value;
			}
		}

        private int? _nBrand8;
        public int? Brand8
        {
            get
            {
                return _nBrand8;
            }
            set
            {
                _nBrand8 = value;
            }
        }

		private string _sSession;
		public string Session
		{
			get
			{
				return _sSession;
			}
			set
			{
				_sSession = value;
			}
		}

		private bool _bIsHoliday;
		public bool IsHoliday
		{
			get
			{
				return _bIsHoliday;
			}
			set
			{
				_bIsHoliday = value;
			}
		}

		private string _sDoctorProfile;
		public string DoctorProfile
		{
			get
			{
				return _sDoctorProfile;
			}
			set
			{
				_sDoctorProfile = value;
			}
		}

		private string _sCreatedBy;
		public string CreatedBy
		{
			get
			{
				return _sCreatedBy;
			}
			set
			{
				_sCreatedBy = value;
			}
		}

		private DateTime _dCreationDate;
		public DateTime CreationDate
		{
			get
			{
				return _dCreationDate;
			}
			set
			{
				_dCreationDate = value;
			}
		}

		#endregion
		#region Constructor & Destructor
		public PVPDetail()
		{
			_bIsDisposed=false;
			_nDetailID = 0;
			_nPvpID = 0;
			_nDoctorID = null;
			_sTerritoryID = null;
			_nDay = 0;
			_nMonth = 0;
			_nYear = 0;
            _nBrand1 = null;
            _nBrand2 = null;
            _nBrand3 = null;
            _nBrand4 = null;
            _nBrand5 = null;
            _nBrand6 = null;
            _nBrand7 = null;
            _nBrand8 = null;
			_sSession = null;
			_bIsHoliday = false;
			_sDoctorProfile = null;
			_sCreatedBy = null;
			_dCreationDate = DateTime.Now;
		}
		~PVPDetail()
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
	public class PVPDetails : CollectionBase,IEnumerable
	{
		public PVPDetails()
		{
			InnerList.Clear();		}
		public void Add(PVPDetail oItem)
		{
			InnerList.Add(oItem);
		}
		public PVPDetail this[int i]
		{
			 get { return (PVPDetail)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			PVPDetail oItem = new PVPDetail();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (PVPDetail)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public PVPDetail GetPVPDetail(int nID)
		{
			PVPDetail oItem = new PVPDetail();
			foreach (PVPDetail oPVPDetail in this)
			{
				if (oPVPDetail.ID.ToInt32 == nID)
				{
					oItem = oPVPDetail;
					break;
				}
			}
			return oItem;
		}
	}
}
