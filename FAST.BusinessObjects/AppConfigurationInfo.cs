using System;
using System.Collections;
using FAST.Core.BusinessObject;
namespace FAST.BusinessObjects
{
	[Serializable]
	public class AppConfigurationInfo : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
		private int _nAppConfigID;
		public int AppConfigID
		{
			get
			{
				return _nAppConfigID;
			}
			set
			{
				_nAppConfigID = value;
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

		private int _nCycleID;
		public int CycleID
		{
			get
			{
				return _nCycleID;
			}
			set
			{
				_nCycleID = value;
			}
		}

		private string _sSmsNo;
		public string SmsNo
		{
			get
			{
				return _sSmsNo;
			}
			set
			{
				_sSmsNo = value;
			}
		}

        private DateTime _dPVPStartDate;
        public DateTime PVPStartDate
        {
            get
            {
                return _dPVPStartDate;
            }
            set
            {
                _dPVPStartDate = value;
            }
        }

        private DateTime _dPVPEndDate;
        public DateTime PVPEndDate
        {
            get
            {
                return _dPVPEndDate;
            }
            set
            {
                _dPVPEndDate = value;
            }
        }

        private int _nDCREntryHours;
        public int DCREntryHours
		{
			get
			{
                return _nDCREntryHours;
			}
			set
			{
                _nDCREntryHours = value;
			}
		}

        private int _nDCRApprovalHours;
        public int DCRApprovalHours
        {
            get
            {
                return _nDCRApprovalHours;
            }
            set
            {
                _nDCRApprovalHours = value;
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

		#endregion
		#region Constructor & Destructor
		public AppConfigurationInfo()
		{
			_bIsDisposed=false;
			_nAppConfigID = 0;
            _sTerritoryID = "";
            _nCycleID = 0;
			_sSmsNo = null;
            _dPVPStartDate = DateTime.Today;
            _dPVPEndDate = DateTime.Today;
            _nDCREntryHours = 0;
            _nDCRApprovalHours = 0;
			_nVersion = 0;
			_nAction = 0;
		}
		~AppConfigurationInfo()
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
	public class AppConfigurationInfos : CollectionBase,IEnumerable
	{
		public AppConfigurationInfos()
		{
			InnerList.Clear();		}
		public void Add(AppConfigurationInfo oItem)
		{
			InnerList.Add(oItem);
		}
		public AppConfigurationInfo this[int i]
		{
			 get { return (AppConfigurationInfo)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			AppConfigurationInfo oItem = new AppConfigurationInfo();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (AppConfigurationInfo)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public AppConfigurationInfo GetAppConfigurationInfo(int nID)
		{
			AppConfigurationInfo oItem = new AppConfigurationInfo();
			foreach (AppConfigurationInfo oAppConfigurationInfo in this)
			{
				if (oAppConfigurationInfo.ID.ToInt32 == nID)
				{
					oItem = oAppConfigurationInfo;
					break;
				}
			}
			return oItem;
		}
	}
}
