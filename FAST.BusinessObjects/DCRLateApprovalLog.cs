using System;
using System.Collections;
using FAST.Core.BusinessObject;

namespace FAST.BusinessObjects
{
	[Serializable]
	public class DCRLateApprovalLog : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
		private int _nLogID;
		public int LogID
		{
			get
			{
				return _nLogID;
			}
			set
			{
				_nLogID = value;
			}
		}

		private string _sRegionID;
		public string RegionID
		{
			get
			{
				return _sRegionID;
			}
			set
			{
				_sRegionID = value;
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

		private string _sDCRDetail;
		public string DCRDetail
		{
			get
			{
				return _sDCRDetail;
			}
			set
			{
				_sDCRDetail = value;
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

		#endregion
		#region Constructor & Destructor
		public DCRLateApprovalLog()
		{
			_bIsDisposed=false;
			_nLogID = 0;
			_sRegionID = "";
			_sTerritoryID = "";
			_sDCRDetail = "";
			_nDay = 0;
			_nMonth = 0;
			_nYear = 0;
			_dApprovedDateTime = DateTime.Today;
			_sApprovedBy = "";
		}
		~DCRLateApprovalLog()
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
	public class DCRLateApprovalLogs : CollectionBase,IEnumerable
	{
		public DCRLateApprovalLogs()
		{
			InnerList.Clear();		}
		public void Add(DCRLateApprovalLog oItem)
		{
			InnerList.Add(oItem);
		}
		public DCRLateApprovalLog this[int i]
		{
			 get { return (DCRLateApprovalLog)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			DCRLateApprovalLog oItem = new DCRLateApprovalLog();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (DCRLateApprovalLog)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public DCRLateApprovalLog GetDCRLateApprovalLog(int nID)
		{
			DCRLateApprovalLog oItem = new DCRLateApprovalLog();
			foreach (DCRLateApprovalLog oDCRLateApprovalLog in this)
			{
				if (oDCRLateApprovalLog.ID.ToInt32 == nID)
				{
					oItem = oDCRLateApprovalLog;
					break;
				}
			}
			return oItem;
		}
	}
}
