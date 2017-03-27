using System;
using System.Collections;
using FAST.Core.BusinessObject;
namespace FAST.BusinessObjects
{
    //public enum LogStatus
    //{
    //    RM_Pending = 1,
    //    Approved,
    //    Rejected,
    //    Remove,
    //    SFE_Pending,
    //}

    //public enum LogType
    //{
    //    Add_Existing_Doctor = 1,
    //    Update_Doctor,
    //    T2NT,
    //    NT2T,
    //    Add_New_Doctor,
    //    Remove,
    //}

	[Serializable]
	public class DoctorLog : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
		private int _nDoctorLogID;
		public int DoctorLogID
		{
			get
			{
				return _nDoctorLogID;
			}
			set
			{
				_nDoctorLogID = value;
			}
		}

		private int? _nDoctorUpdateReqID;
		public int? DoctorUpdateReqID
		{
			get
			{
				return _nDoctorUpdateReqID;
			}
			set
			{
				_nDoctorUpdateReqID = value;
			}
		}

		private int? _nDoctorTerritoryMappingID;
		public int? DoctorTerritoryMappingID
		{
			get
			{
				return _nDoctorTerritoryMappingID;
			}
			set
			{
				_nDoctorTerritoryMappingID = value;
			}
		}

		private int _nDocID;
		public int DocID
		{
			get
			{
				return _nDocID;
			}
			set
			{
				_nDocID = value;
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

		private string _sTransferReason;
		public string TransferReason
		{
			get
			{
				return _sTransferReason;
			}
			set
			{
				_sTransferReason = value;
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

        private int _nType;
        public int Type
		{
			get
			{
				return _nType;
			}
			set
			{
				_nType = value;
			}
		}

		private DateTime? _dCreationDate;
		public DateTime? CreationDate
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

		private int? _nCreatedBy;
		public int? CreatedBy
		{
			get
			{
				return _nCreatedBy;
			}
			set
			{
				_nCreatedBy = value;
			}
		}

		private DateTime? _dModifiedDateRM;
		public DateTime? ModifiedDateRM
		{
			get
			{
				return _dModifiedDateRM;
			}
			set
			{
				_dModifiedDateRM = value;
			}
		}

		private int? _nModifiedByRM;
		public int? ModifiedByRM
		{
			get
			{
				return _nModifiedByRM;
			}
			set
			{
				_nModifiedByRM = value;
			}
		}

        private DateTime? _dModifiedDateSFE;
        public DateTime? ModifiedDateSFE
        {
            get
            {
                return _dModifiedDateSFE;
            }
            set
            {
                _dModifiedDateSFE = value;
            }
        }

        private int? _nModifiedBySFE;
        public int? ModifiedBySFE
        {
            get
            {
                return _nModifiedBySFE;
            }
            set
            {
                _nModifiedBySFE = value;
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
		public DoctorLog()
		{
			_bIsDisposed=false;
			_nDoctorLogID = 0;
			_nDoctorUpdateReqID = null;
			_nDoctorTerritoryMappingID = null;
			_nDocID = 0;
			_sTerritoryID = "";
			_sTransferReason = null;
            _nStatus = 0;
            _nType = 0;
			_dCreationDate = null;
			_nCreatedBy = null;
			_dModifiedDateRM = null;
			_nModifiedByRM = null;
            _dModifiedDateSFE = null;
            _nModifiedBySFE = null;
			_nAction = null;
			_nVersion = null;
		}
		~DoctorLog()
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
	public class DoctorLogs : CollectionBase,IEnumerable
	{
		public DoctorLogs()
		{
			InnerList.Clear();		}
		public void Add(DoctorLog oItem)
		{
			InnerList.Add(oItem);
		}
		public DoctorLog this[int i]
		{
			 get { return (DoctorLog)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			DoctorLog oItem = new DoctorLog();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (DoctorLog)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public DoctorLog GetDoctorLog(int nID)
		{
			DoctorLog oItem = new DoctorLog();
			foreach (DoctorLog oDoctorLog in this)
			{
				if (oDoctorLog.ID.ToInt32 == nID)
				{
					oItem = oDoctorLog;
					break;
				}
			}
			return oItem;
		}
	}
}
