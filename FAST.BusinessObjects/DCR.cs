using System;
using System.Collections;
using FAST.Core.BusinessObject;
using FAST.Core;


namespace FAST.BusinessObjects
{
	[Serializable]
	public class DCR : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
        private int _nDcrID;
        public int DcrID
        {
            get
            {
                return _nDcrID;
            }
            set
            {
                _nDcrID = value;
            }
        }

		private int? _nPvpDetailID;
		public int? PvpDetailID
		{
			get
			{
				return _nPvpDetailID;
			}
			set
			{
				_nPvpDetailID = value;
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

		private int _nStatus;
		public int Status
		{
			get
			{
				return _nStatus;
			}
			set
			{
				_nStatus = value;
			}
		}

		private DateTime _dVisitDateTime;
		public DateTime VisitDateTime
		{
			get
			{
				return _dVisitDateTime;
			}
			set
			{
				_dVisitDateTime = value;
			}
		}

		private bool _bIsVisited;
		public bool IsVisited
		{
			get
			{
				return _bIsVisited;
			}
			set
			{
				_bIsVisited = value;
			}
		}

		private bool _bIsAvailable;
		public bool IsAvailable
		{
			get
			{
				return _bIsAvailable;
			}
			set
			{
				_bIsAvailable = value;
			}
		}

		private bool _bIsAccompanyByRM_RM;
		public bool IsAccompanyByRM_RM
		{
			get
			{
				return _bIsAccompanyByRM_RM;
			}
			set
			{
				_bIsAccompanyByRM_RM = value;
			}
		}

		private bool _bIsAccompanyByRM_SF;
		public bool IsAccompanyByRM_SF
		{
			get
			{
				return _bIsAccompanyByRM_SF;
			}
			set
			{
				_bIsAccompanyByRM_SF = value;
			}
		}

        private string _sReminderNextCall;
        public string ReminderNextCall
		{
			get
			{
                return _sReminderNextCall;
			}
			set
			{
                _sReminderNextCall = value;
			}
		}

		private int _nNotAvailableReasonID;
		public int NotAvailableReasonID
		{
			get
			{
				return _nNotAvailableReasonID;
			}
			set
			{
				_nNotAvailableReasonID = value;
			}
		}

		private string _sNotAvailableReason;
		public string NotAvailableReason
		{
			get
			{
				return _sNotAvailableReason;
			}
			set
			{
				_sNotAvailableReason = value;
			}
		}

		private bool _bIsNewVisit;
		public bool IsNewVisit
		{
			get
			{
				return _bIsNewVisit;
			}
			set
			{
				_bIsNewVisit = value;
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

        private int? _nBrand1Gimmick1;
        public int? Brand1Gimmick1
		{
			get
			{
				return _nBrand1Gimmick1;
			}
			set
			{
				_nBrand1Gimmick1 = value;
			}
		}

        private int? _nBrand1Gimmick2;
        public int? Brand1Gimmick2
		{
			get
			{
				return _nBrand1Gimmick2;
			}
			set
			{
				_nBrand1Gimmick2 = value;
			}
		}

        private int? _nBrand1Gimmick3;
        public int? Brand1Gimmick3
		{
			get
			{
				return _nBrand1Gimmick3;
			}
			set
			{
				_nBrand1Gimmick3 = value;
			}
		}

        private int? _nBrand1Sample1;
        public int? Brand1Sample1
		{
			get
			{
				return _nBrand1Sample1;
			}
			set
			{
				_nBrand1Sample1 = value;
			}
		}

        private int? _nBrand1Sample2;
        public int? Brand1Sample2
		{
			get
			{
				return _nBrand1Sample2;
			}
			set
			{
				_nBrand1Sample2 = value;
			}
		}

        private int? _nBrand1Sample3;
        public int? Brand1Sample3
		{
			get
			{
				return _nBrand1Sample3;
			}
			set
			{
				_nBrand1Sample3 = value;
			}
		}

        private int? _nBrand1Gimmick1Qty;
        public int? Brand1Gimmick1Qty
		{
			get
			{
				return _nBrand1Gimmick1Qty;
			}
			set
			{
				_nBrand1Gimmick1Qty = value;
			}
		}

        private int? _nBrand1Gimmick2Qty;
        public int? Brand1Gimmick2Qty
		{
			get
			{
				return _nBrand1Gimmick2Qty;
			}
			set
			{
				_nBrand1Gimmick2Qty = value;
			}
		}

        private int? _nBrand1Gimmick3Qty;
        public int? Brand1Gimmick3Qty
		{
			get
			{
				return _nBrand1Gimmick3Qty;
			}
			set
			{
				_nBrand1Gimmick3Qty = value;
			}
		}

        private int? _nBrand1Sample1Qty;
        public int? Brand1Sample1Qty
		{
			get
			{
				return _nBrand1Sample1Qty;
			}
			set
			{
				_nBrand1Sample1Qty = value;
			}
		}

        private int? _nBrand1Sample2Qty;
        public int? Brand1Sample2Qty
		{
			get
			{
				return _nBrand1Sample2Qty;
			}
			set
			{
				_nBrand1Sample2Qty = value;
			}
		}

        private int? _nBrand1Sample3Qty;
        public int? Brand1Sample3Qty
		{
			get
			{
				return _nBrand1Sample3Qty;
			}
			set
			{
				_nBrand1Sample3Qty = value;
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

        private int? _nBrand2Gimmick1;
        public int? Brand2Gimmick1
		{
			get
			{
				return _nBrand2Gimmick1;
			}
			set
			{
				_nBrand2Gimmick1 = value;
			}
		}

        private int? _nBrand2Gimmick2;
        public int? Brand2Gimmick2
		{
			get
			{
				return _nBrand2Gimmick2;
			}
			set
			{
				_nBrand2Gimmick2 = value;
			}
		}

        private int? _nBrand2Gimmick3;
        public int? Brand2Gimmick3
		{
			get
			{
				return _nBrand2Gimmick3;
			}
			set
			{
				_nBrand2Gimmick3 = value;
			}
		}

        private int? _nBrand2Sample1;
        public int? Brand2Sample1
		{
			get
			{
				return _nBrand2Sample1;
			}
			set
			{
				_nBrand2Sample1 = value;
			}
		}

        private int? _nBrand2Sample2;
        public int? Brand2Sample2
		{
			get
			{
				return _nBrand2Sample2;
			}
			set
			{
				_nBrand2Sample2 = value;
			}
		}

        private int? _nBrand2Sample3;
        public int? Brand2Sample3
		{
			get
			{
				return _nBrand2Sample3;
			}
			set
			{
				_nBrand2Sample3 = value;
			}
		}

        private int? _nBrand2Gimmick1Qty;
        public int? Brand2Gimmick1Qty
		{
			get
			{
				return _nBrand2Gimmick1Qty;
			}
			set
			{
				_nBrand2Gimmick1Qty = value;
			}
		}

        private int? _nBrand2Gimmick2Qty;
        public int? Brand2Gimmick2Qty
		{
			get
			{
				return _nBrand2Gimmick2Qty;
			}
			set
			{
				_nBrand2Gimmick2Qty = value;
			}
		}

        private int? _nBrand2Gimmick3Qty;
        public int? Brand2Gimmick3Qty
		{
			get
			{
				return _nBrand2Gimmick3Qty;
			}
			set
			{
				_nBrand2Gimmick3Qty = value;
			}
		}

        private int? _nBrand2Sample1Qty;
        public int? Brand2Sample1Qty
		{
			get
			{
				return _nBrand2Sample1Qty;
			}
			set
			{
				_nBrand2Sample1Qty = value;
			}
		}

        private int? _nBrand2Sample2Qty;
        public int? Brand2Sample2Qty
		{
			get
			{
				return _nBrand2Sample2Qty;
			}
			set
			{
				_nBrand2Sample2Qty = value;
			}
		}

        private int? _nBrand2Sample3Qty;
        public int? Brand2Sample3Qty
		{
			get
			{
				return _nBrand2Sample3Qty;
			}
			set
			{
				_nBrand2Sample3Qty = value;
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

        private int? _nBrand3Gimmick1;
        public int? Brand3Gimmick1
		{
			get
			{
				return _nBrand3Gimmick1;
			}
			set
			{
				_nBrand3Gimmick1 = value;
			}
		}

        private int? _nBrand3Gimmick2;
        public int? Brand3Gimmick2
		{
			get
			{
				return _nBrand3Gimmick2;
			}
			set
			{
				_nBrand3Gimmick2 = value;
			}
		}

        private int? _nBrand3Gimmick3;
        public int? Brand3Gimmick3
		{
			get
			{
				return _nBrand3Gimmick3;
			}
			set
			{
				_nBrand3Gimmick3 = value;
			}
		}

        private int? _nBrand3Sample1;
        public int? Brand3Sample1
		{
			get
			{
				return _nBrand3Sample1;
			}
			set
			{
				_nBrand3Sample1 = value;
			}
		}

        private int? _nBrand3Sample2;
        public int? Brand3Sample2
		{
			get
			{
				return _nBrand3Sample2;
			}
			set
			{
				_nBrand3Sample2 = value;
			}
		}

        private int? _nBrand3Sample3;
        public int? Brand3Sample3
		{
			get
			{
				return _nBrand3Sample3;
			}
			set
			{
				_nBrand3Sample3 = value;
			}
		}

        private int? _nBrand3Gimmick1Qty;
        public int? Brand3Gimmick1Qty
		{
			get
			{
				return _nBrand3Gimmick1Qty;
			}
			set
			{
				_nBrand3Gimmick1Qty = value;
			}
		}

        private int? _nBrand3Gimmick2Qty;
        public int? Brand3Gimmick2Qty
		{
			get
			{
				return _nBrand3Gimmick2Qty;
			}
			set
			{
				_nBrand3Gimmick2Qty = value;
			}
		}

        private int? _nBrand3Gimmick3Qty;
        public int? Brand3Gimmick3Qty
		{
			get
			{
				return _nBrand3Gimmick3Qty;
			}
			set
			{
				_nBrand3Gimmick3Qty = value;
			}
		}

        private int? _nBrand3Sample1Qty;
        public int? Brand3Sample1Qty
		{
			get
			{
				return _nBrand3Sample1Qty;
			}
			set
			{
				_nBrand3Sample1Qty = value;
			}
		}

        private int? _nBrand3Sample2Qty;
        public int? Brand3Sample2Qty
		{
			get
			{
				return _nBrand3Sample2Qty;
			}
			set
			{
				_nBrand3Sample2Qty = value;
			}
		}

        private int? _nBrand3Sample3Qty;
        public int? Brand3Sample3Qty
		{
			get
			{
				return _nBrand3Sample3Qty;
			}
			set
			{
				_nBrand3Sample3Qty = value;
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

        private int? _nBrand4Gimmick1;
        public int? Brand4Gimmick1
		{
			get
			{
				return _nBrand4Gimmick1;
			}
			set
			{
				_nBrand4Gimmick1 = value;
			}
		}

        private int? _nBrand4Gimmick2;
        public int? Brand4Gimmick2
		{
			get
			{
				return _nBrand4Gimmick2;
			}
			set
			{
				_nBrand4Gimmick2 = value;
			}
		}

        private int? _nBrand4Gimmick3;
        public int? Brand4Gimmick3
		{
			get
			{
				return _nBrand4Gimmick3;
			}
			set
			{
				_nBrand4Gimmick3 = value;
			}
		}

        private int? _nBrand4Sample1;
        public int? Brand4Sample1
		{
			get
			{
				return _nBrand4Sample1;
			}
			set
			{
				_nBrand4Sample1 = value;
			}
		}

        private int? _nBrand4Sample2;
        public int? Brand4Sample2
		{
			get
			{
				return _nBrand4Sample2;
			}
			set
			{
				_nBrand4Sample2 = value;
			}
		}

        private int? _nBrand4Sample3;
        public int? Brand4Sample3
		{
			get
			{
				return _nBrand4Sample3;
			}
			set
			{
				_nBrand4Sample3 = value;
			}
		}

        private int? _nBrand4Gimmick1Qty;
        public int? Brand4Gimmick1Qty
		{
			get
			{
				return _nBrand4Gimmick1Qty;
			}
			set
			{
				_nBrand4Gimmick1Qty = value;
			}
		}

        private int? _nBrand4Gimmick2Qty;
        public int? Brand4Gimmick2Qty
		{
			get
			{
				return _nBrand4Gimmick2Qty;
			}
			set
			{
				_nBrand4Gimmick2Qty = value;
			}
		}

        private int? _nBrand4Gimmick3Qty;
        public int? Brand4Gimmick3Qty
		{
			get
			{
				return _nBrand4Gimmick3Qty;
			}
			set
			{
				_nBrand4Gimmick3Qty = value;
			}
		}

        private int? _nBrand4Sample1Qty;
        public int? Brand4Sample1Qty
		{
			get
			{
				return _nBrand4Sample1Qty;
			}
			set
			{
				_nBrand4Sample1Qty = value;
			}
		}

        private int? _nBrand4Sample2Qty;
        public int? Brand4Sample2Qty
		{
			get
			{
				return _nBrand4Sample2Qty;
			}
			set
			{
				_nBrand4Sample2Qty = value;
			}
		}

        private int? _nBrand4Sample3Qty;
        public int? Brand4Sample3Qty
		{
			get
			{
				return _nBrand4Sample3Qty;
			}
			set
			{
				_nBrand4Sample3Qty = value;
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

        private int? _nBrand5Gimmick1;
        public int? Brand5Gimmick1
		{
			get
			{
				return _nBrand5Gimmick1;
			}
			set
			{
				_nBrand5Gimmick1 = value;
			}
		}

        private int? _nBrand5Gimmick2;
        public int? Brand5Gimmick2
		{
			get
			{
				return _nBrand5Gimmick2;
			}
			set
			{
				_nBrand5Gimmick2 = value;
			}
		}

        private int? _nBrand5Gimmick3;
        public int? Brand5Gimmick3
		{
			get
			{
				return _nBrand5Gimmick3;
			}
			set
			{
				_nBrand5Gimmick3 = value;
			}
		}

        private int? _nBrand5Sample1;
        public int? Brand5Sample1
		{
			get
			{
				return _nBrand5Sample1;
			}
			set
			{
				_nBrand5Sample1 = value;
			}
		}

        private int? _nBrand5Sample2;
        public int? Brand5Sample2
		{
			get
			{
				return _nBrand5Sample2;
			}
			set
			{
				_nBrand5Sample2 = value;
			}
		}

        private int? _nBrand5Sample3;
        public int? Brand5Sample3
		{
			get
			{
				return _nBrand5Sample3;
			}
			set
			{
				_nBrand5Sample3 = value;
			}
		}

		private int? _nBrand5Gimmick1Qty;
		public int? Brand5Gimmick1Qty
		{
			get
			{
				return _nBrand5Gimmick1Qty;
			}
			set
			{
				_nBrand5Gimmick1Qty = value;
			}
		}

        private int? _nBrand5Gimmick2Qty;
        public int? Brand5Gimmick2Qty
		{
			get
			{
				return _nBrand5Gimmick2Qty;
			}
			set
			{
				_nBrand5Gimmick2Qty = value;
			}
		}

        private int? _nBrand5Gimmick3Qty;
        public int? Brand5Gimmick3Qty
		{
			get
			{
				return _nBrand5Gimmick3Qty;
			}
			set
			{
				_nBrand5Gimmick3Qty = value;
			}
		}

        private int? _nBrand5Sample1Qty;
        public int? Brand5Sample1Qty
		{
			get
			{
				return _nBrand5Sample1Qty;
			}
			set
			{
				_nBrand5Sample1Qty = value;
			}
		}

        private int? _nBrand5Sample2Qty;
        public int? Brand5Sample2Qty
		{
			get
			{
				return _nBrand5Sample2Qty;
			}
			set
			{
				_nBrand5Sample2Qty = value;
			}
		}

        private int? _nBrand5Sample3Qty;
        public int? Brand5Sample3Qty
		{
			get
			{
				return _nBrand5Sample3Qty;
			}
			set
			{
				_nBrand5Sample3Qty = value;
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

        private int? _nBrand6Gimmick1;
        public int? Brand6Gimmick1
		{
			get
			{
				return _nBrand6Gimmick1;
			}
			set
			{
				_nBrand6Gimmick1 = value;
			}
		}

        private int? _nBrand6Gimmick2;
        public int? Brand6Gimmick2
		{
			get
			{
				return _nBrand6Gimmick2;
			}
			set
			{
				_nBrand6Gimmick2 = value;
			}
		}

        private int? _nBrand6Gimmick3;
        public int? Brand6Gimmick3
		{
			get
			{
				return _nBrand6Gimmick3;
			}
			set
			{
				_nBrand6Gimmick3 = value;
			}
		}

        private int? _nBrand6Sample1;
        public int? Brand6Sample1
		{
			get
			{
				return _nBrand6Sample1;
			}
			set
			{
				_nBrand6Sample1 = value;
			}
		}

        private int? _nBrand6Sample2;
        public int? Brand6Sample2
		{
			get
			{
				return _nBrand6Sample2;
			}
			set
			{
				_nBrand6Sample2 = value;
			}
		}

        private int? _nBrand6Sample3;
        public int? Brand6Sample3
		{
			get
			{
				return _nBrand6Sample3;
			}
			set
			{
				_nBrand6Sample3 = value;
			}
		}

		private int? _nBrand6Gimmick1Qty;
		public int? Brand6Gimmick1Qty
		{
			get
			{
				return _nBrand6Gimmick1Qty;
			}
			set
			{
				_nBrand6Gimmick1Qty = value;
			}
		}

        private int? _nBrand6Gimmick2Qty;
        public int? Brand6Gimmick2Qty
		{
			get
			{
				return _nBrand6Gimmick2Qty;
			}
			set
			{
				_nBrand6Gimmick2Qty = value;
			}
		}

        private int? _nBrand6Gimmick3Qty;
        public int? Brand6Gimmick3Qty
		{
			get
			{
				return _nBrand6Gimmick3Qty;
			}
			set
			{
				_nBrand6Gimmick3Qty = value;
			}
		}

        private int? _nBrand6Sample1Qty;
        public int? Brand6Sample1Qty
		{
			get
			{
				return _nBrand6Sample1Qty;
			}
			set
			{
				_nBrand6Sample1Qty = value;
			}
		}

        private int? _nBrand6Sample2Qty;
        public int? Brand6Sample2Qty
		{
			get
			{
				return _nBrand6Sample2Qty;
			}
			set
			{
				_nBrand6Sample2Qty = value;
			}
		}

        private int? _nBrand6Sample3Qty;
        public int? Brand6Sample3Qty
		{
			get
			{
				return _nBrand6Sample3Qty;
			}
			set
			{
				_nBrand6Sample3Qty = value;
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

        private int? _nBrand7Gimmick1;
        public int? Brand7Gimmick1
        {
            get
            {
                return _nBrand7Gimmick1;
            }
            set
            {
                _nBrand7Gimmick1 = value;
            }
        }

        private int? _nBrand7Gimmick2;
        public int? Brand7Gimmick2
        {
            get
            {
                return _nBrand7Gimmick2;
            }
            set
            {
                _nBrand7Gimmick2 = value;
            }
        }

        private int? _nBrand7Gimmick3;
        public int? Brand7Gimmick3
        {
            get
            {
                return _nBrand7Gimmick3;
            }
            set
            {
                _nBrand7Gimmick3 = value;
            }
        }

        private int? _nBrand7Sample1;
        public int? Brand7Sample1
        {
            get
            {
                return _nBrand7Sample1;
            }
            set
            {
                _nBrand7Sample1 = value;
            }
        }

        private int? _nBrand7Sample2;
        public int? Brand7Sample2
        {
            get
            {
                return _nBrand7Sample2;
            }
            set
            {
                _nBrand7Sample2 = value;
            }
        }

        private int? _nBrand7Sample3;
        public int? Brand7Sample3
        {
            get
            {
                return _nBrand7Sample3;
            }
            set
            {
                _nBrand7Sample3 = value;
            }
        }

        private int? _nBrand7Gimmick1Qty;
        public int? Brand7Gimmick1Qty
        {
            get
            {
                return _nBrand7Gimmick1Qty;
            }
            set
            {
                _nBrand7Gimmick1Qty = value;
            }
        }

        private int? _nBrand7Gimmick2Qty;
        public int? Brand7Gimmick2Qty
        {
            get
            {
                return _nBrand7Gimmick2Qty;
            }
            set
            {
                _nBrand7Gimmick2Qty = value;
            }
        }

        private int? _nBrand7Gimmick3Qty;
        public int? Brand7Gimmick3Qty
        {
            get
            {
                return _nBrand7Gimmick3Qty;
            }
            set
            {
                _nBrand7Gimmick3Qty = value;
            }
        }

        private int? _nBrand7Sample1Qty;
        public int? Brand7Sample1Qty
        {
            get
            {
                return _nBrand7Sample1Qty;
            }
            set
            {
                _nBrand7Sample1Qty = value;
            }
        }

        private int? _nBrand7Sample2Qty;
        public int? Brand7Sample2Qty
        {
            get
            {
                return _nBrand7Sample2Qty;
            }
            set
            {
                _nBrand7Sample2Qty = value;
            }
        }

        private int? _nBrand7Sample3Qty;
        public int? Brand7Sample3Qty
        {
            get
            {
                return _nBrand7Sample3Qty;
            }
            set
            {
                _nBrand7Sample3Qty = value;
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

        private int? _nBrand8Gimmick1;
        public int? Brand8Gimmick1
        {
            get
            {
                return _nBrand8Gimmick1;
            }
            set
            {
                _nBrand8Gimmick1 = value;
            }
        }

        private int? _nBrand8Gimmick2;
        public int? Brand8Gimmick2
        {
            get
            {
                return _nBrand8Gimmick2;
            }
            set
            {
                _nBrand8Gimmick2 = value;
            }
        }

        private int? _nBrand8Gimmick3;
        public int? Brand8Gimmick3
        {
            get
            {
                return _nBrand8Gimmick3;
            }
            set
            {
                _nBrand8Gimmick3 = value;
            }
        }

        private int? _nBrand8Sample1;
        public int? Brand8Sample1
        {
            get
            {
                return _nBrand8Sample1;
            }
            set
            {
                _nBrand8Sample1 = value;
            }
        }

        private int? _nBrand8Sample2;
        public int? Brand8Sample2
        {
            get
            {
                return _nBrand8Sample2;
            }
            set
            {
                _nBrand8Sample2 = value;
            }
        }

        private int? _nBrand8Sample3;
        public int? Brand8Sample3
        {
            get
            {
                return _nBrand8Sample3;
            }
            set
            {
                _nBrand8Sample3 = value;
            }
        }

        private int? _nBrand8Gimmick1Qty;
        public int? Brand8Gimmick1Qty
        {
            get
            {
                return _nBrand8Gimmick1Qty;
            }
            set
            {
                _nBrand8Gimmick1Qty = value;
            }
        }

        private int? _nBrand8Gimmick2Qty;
        public int? Brand8Gimmick2Qty
        {
            get
            {
                return _nBrand8Gimmick2Qty;
            }
            set
            {
                _nBrand8Gimmick2Qty = value;
            }
        }

        private int? _nBrand8Gimmick3Qty;
        public int? Brand8Gimmick3Qty
        {
            get
            {
                return _nBrand8Gimmick3Qty;
            }
            set
            {
                _nBrand8Gimmick3Qty = value;
            }
        }

        private int? _nBrand8Sample1Qty;
        public int? Brand8Sample1Qty
        {
            get
            {
                return _nBrand8Sample1Qty;
            }
            set
            {
                _nBrand8Sample1Qty = value;
            }
        }

        private int? _nBrand8Sample2Qty;
        public int? Brand8Sample2Qty
        {
            get
            {
                return _nBrand8Sample2Qty;
            }
            set
            {
                _nBrand8Sample2Qty = value;
            }
        }

        private int? _nBrand8Sample3Qty;
        public int? Brand8Sample3Qty
        {
            get
            {
                return _nBrand8Sample3Qty;
            }
            set
            {
                _nBrand8Sample3Qty = value;
            }
        }

		private DateTime _dSubmitDateTime;
		public DateTime SubmitDateTime
		{
			get
			{
				return _dSubmitDateTime;
			}
			set
			{
				_dSubmitDateTime = value;
			}
		}

		private DateTime _dApprovedDateTime;
		public DateTime ApprovedDateTime
		{
			get
			{
				return _dApprovedDateTime;
			}
			set
			{
				_dApprovedDateTime = value;
			}
		}

		private int _nSubmittedBy;
		public int SubmittedBy
		{
			get
			{
				return _nSubmittedBy;
			}
			set
			{
				_nSubmittedBy = value;
			}
		}

		private int _nApprovedBy;
		public int ApprovedBy
		{
			get
			{
				return _nApprovedBy;
			}
			set
			{
				_nApprovedBy = value;
			}
		}

		private int _nAction;
		public int Action
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

        private string _sSMSDCRNo;
        public string SMSDCRNo
        {
            get
            {
                return _sSMSDCRNo;
            }
            set
            {
                _sSMSDCRNo = value;
            }
        }

        private bool _bIsSendSMS;
        public bool IsSendSMS
        {
            get
            {
                return _bIsSendSMS;
            }
            set
            {
                _bIsSendSMS = value;
            }
        }

        private string _sRejectReason;
        public string RejectReason
        {
            get
            {
                return _sRejectReason;
            }
            set
            {
                _sRejectReason = value;
            }
        }


		#endregion
		#region Constructor & Destructor
		public DCR()
		{
			_bIsDisposed=false;
			_nDcrID = 0;
			_nPvpDetailID = null;
			_nDoctorID = null;
			_sTerritoryID = "";
			_nDay = 0;
			_nMonth = 0;
			_nYear = 0;
			_nStatus = 0;
            _dVisitDateTime = Global.MinimunDateTimeValue;
			_bIsVisited = false;
            _bIsAvailable = false;
            _bIsAccompanyByRM_RM = false;
            _bIsAccompanyByRM_SF = false;
            _sReminderNextCall = null;
			_nNotAvailableReasonID = 0;
            _sNotAvailableReason = null;
            _bIsNewVisit = false;
			_sSession = "";
			_nBrand1 = null;
            _nBrand1Gimmick1 = null;
            _nBrand1Gimmick2 = null;
            _nBrand1Gimmick3 = null;
            _nBrand1Sample1 = null;
            _nBrand1Sample2 = null;
            _nBrand1Sample3 = null;
            _nBrand1Gimmick1Qty = null;
            _nBrand1Gimmick2Qty = null;
            _nBrand1Gimmick3Qty = null;
            _nBrand1Sample1Qty = null;
            _nBrand1Sample2Qty = null;
            _nBrand1Sample3Qty = null;
            _nBrand2 = null;
            _nBrand2Gimmick1 = null;
            _nBrand2Gimmick2 = null;
            _nBrand2Gimmick3 = null;
            _nBrand2Sample1 = null;
            _nBrand2Sample2 = null;
            _nBrand2Sample3 = null;
            _nBrand2Gimmick1Qty = null;
            _nBrand2Gimmick2Qty = null;
            _nBrand2Gimmick3Qty = null;
            _nBrand2Sample1Qty = null;
            _nBrand2Sample2Qty = null;
            _nBrand2Sample3Qty = null;
            _nBrand3 = null;
            _nBrand3Gimmick1 = null;
            _nBrand3Gimmick2 = null;
            _nBrand3Gimmick3 = null;
            _nBrand3Sample1 = null;
            _nBrand3Sample2 = null;
            _nBrand3Sample3 = null;
            _nBrand3Gimmick1Qty = null;
            _nBrand3Gimmick2Qty = null;
            _nBrand3Gimmick3Qty = null;
            _nBrand3Sample1Qty = null;
            _nBrand3Sample2Qty = null;
            _nBrand3Sample3Qty = null;
            _nBrand4 = null;
            _nBrand4Gimmick1 = null;
            _nBrand4Gimmick2 = null;
            _nBrand4Gimmick3 = null;
            _nBrand4Sample1 = null;
            _nBrand4Sample2 = null;
            _nBrand4Sample3 = null;
            _nBrand4Gimmick1Qty = null;
            _nBrand4Gimmick2Qty = null;
            _nBrand4Gimmick3Qty = null;
            _nBrand4Sample1Qty = null;
            _nBrand4Sample2Qty = null;
            _nBrand4Sample3Qty = null;
            _nBrand5 = null;
            _nBrand5Gimmick1 = null;
            _nBrand5Gimmick2 = null;
            _nBrand5Gimmick3 = null;
            _nBrand5Sample1 = null;
            _nBrand5Sample2 = null;
            _nBrand5Sample3 = null;
            _nBrand5Gimmick1Qty = null;
            _nBrand5Gimmick2Qty = null;
            _nBrand5Gimmick3Qty = null;
            _nBrand5Sample1Qty = null;
            _nBrand5Sample2Qty = null;
            _nBrand5Sample3Qty = null;
            _nBrand6 = null;
            _nBrand6Gimmick1 = null;
            _nBrand6Gimmick2 = null;
            _nBrand6Gimmick3 = null;
            _nBrand6Sample1 = null;
            _nBrand6Sample2 = null;
            _nBrand6Sample3 = null;
            _nBrand6Gimmick1Qty = null;
            _nBrand6Gimmick2Qty = null;
            _nBrand6Gimmick3Qty = null;
            _nBrand6Sample1Qty = null;
            _nBrand6Sample2Qty = null;
            _nBrand6Sample3Qty = null;
            _nBrand7 = null;
            _nBrand7Gimmick1 = null;
            _nBrand7Gimmick2 = null;
            _nBrand7Gimmick3 = null;
            _nBrand7Sample1 = null;
            _nBrand7Sample2 = null;
            _nBrand7Sample3 = null;
            _nBrand7Gimmick1Qty = null;
            _nBrand7Gimmick2Qty = null;
            _nBrand7Gimmick3Qty = null;
            _nBrand7Sample1Qty = null;
            _nBrand7Sample2Qty = null;
            _nBrand7Sample3Qty = null;
            _nBrand8 = null;
            _nBrand8Gimmick1 = null;
            _nBrand8Gimmick2 = null;
            _nBrand8Gimmick3 = null;
            _nBrand8Sample1 = null;
            _nBrand8Sample2 = null;
            _nBrand8Sample3 = null;
            _nBrand8Gimmick1Qty = null;
            _nBrand8Gimmick2Qty = null;
            _nBrand8Gimmick3Qty = null;
            _nBrand8Sample1Qty = null;
            _nBrand8Sample2Qty = null;
            _nBrand8Sample3Qty = null;
            _dSubmitDateTime = Global.MinimunDateTimeValue;
            _dApprovedDateTime = Global.MinimunDateTimeValue;
			_nSubmittedBy = 0;
			_nApprovedBy = 0;
			_nAction = 0;
			_nVersion = 0;
            _sSMSDCRNo = null;
            _bIsSendSMS = false;
            _sRejectReason = null;
		}
		~DCR()
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
	public class DCRs : CollectionBase,IEnumerable
	{
		public DCRs()
		{
			InnerList.Clear();		}
		public void Add(DCR oItem)
		{
			InnerList.Add(oItem);
		}
		public DCR this[int i]
		{
			 get { return (DCR)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			DCR oItem = new DCR();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (DCR)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public DCR GetDCR(int nID)
		{
			DCR oItem = new DCR();
			foreach (DCR oDCR in this)
			{
				if (oDCR.ID.ToInt32 == nID)
				{
					oItem = oDCR;
					break;
				}
			}
			return oItem;
		}
	}
}
