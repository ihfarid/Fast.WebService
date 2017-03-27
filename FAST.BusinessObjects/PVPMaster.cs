using System;
using System.Collections;
using FAST.Core.BusinessObject;
namespace FAST.BusinessObjects
{
    public enum PVPStatus
    {
        Pending_Submission = 1,
        Submit,
        Approved,
        Rejected,        
    }

	[Serializable]
	public class PVPMaster : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
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

        private PVPStatus _nStatus;
        public PVPStatus Status
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

		private DateTime _dSubmitDate;
		public DateTime SubmitDate
		{
			get
			{
				return _dSubmitDate;
			}
			set
			{
				_dSubmitDate = value;
			}
		}

		private DateTime _dApprovedDate;
		public DateTime ApprovedDate
		{
			get
			{
				return _dApprovedDate;
			}
			set
			{
				_dApprovedDate = value;
			}
		}

		private string _sSubmittedBy;
		public string SubmittedBy
		{
			get
			{
				return _sSubmittedBy;
			}
			set
			{
				_sSubmittedBy = value;
			}
		}

		private string _sApprovedBy;
		public string ApprovedBy
		{
			get
			{
				return _sApprovedBy;
			}
			set
			{
				_sApprovedBy = value;
			}
		}

		private int _nNoOfPlannedDay;
		public int NoOfPlannedDay
		{
			get
			{
				return _nNoOfPlannedDay;
			}
			set
			{
				_nNoOfPlannedDay = value;
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

        private PVPDetails _oDetails;
        public PVPDetails TransactionDetail
        {
            get
            {
                return _oDetails;
            }
            set
            {
                _oDetails = value;
            }
        }

		#endregion
		#region Constructor & Destructor
		public PVPMaster()
		{
			_bIsDisposed=false;
			_nPvpID = 0;
			_sTerritoryID = "";
			_nMonth = 0;
			_nYear = 0;
            _nStatus = PVPStatus.Pending_Submission;
			_dSubmitDate = DateTime.Today;
			_dApprovedDate = DateTime.Today;
			_sSubmittedBy = "";
			_sApprovedBy = "";
			_nNoOfPlannedDay = 0;
			_nVersion = 0;
			_nAction = 0;
            _oDetails = new PVPDetails();
		}
		~PVPMaster()
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
	public class PVPMasters : CollectionBase,IEnumerable
	{
		public PVPMasters()
		{
			InnerList.Clear();		}
		public void Add(PVPMaster oItem)
		{
			InnerList.Add(oItem);
		}
		public PVPMaster this[int i]
		{
			 get { return (PVPMaster)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			PVPMaster oItem = new PVPMaster();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (PVPMaster)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public PVPMaster GetPVPMaster(int nID)
		{
			PVPMaster oItem = new PVPMaster();
			foreach (PVPMaster oPVPMaster in this)
			{
				if (oPVPMaster.ID.ToInt32 == nID)
				{
					oItem = oPVPMaster;
					break;
				}
			}
			return oItem;
		}
	}
}
