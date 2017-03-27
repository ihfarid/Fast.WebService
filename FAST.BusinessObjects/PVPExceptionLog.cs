using System;
using System.Collections;
using FAST.Core.BusinessObject;
namespace FAST.BusinessObjects
{
	[Serializable]
	public class PVPExceptionLog : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
		private int _nExceptionID;
		public int ExceptionID
		{
			get
			{
				return _nExceptionID;
			}
			set
			{
				_nExceptionID = value;
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

		private string _sPVPDetail;
		public string PVPDetail
		{
			get
			{
				return _sPVPDetail;
			}
			set
			{
				_sPVPDetail = value;
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

		private string _sExceptionDetail;
		public string ExceptionDetail
		{
			get
			{
				return _sExceptionDetail;
			}
			set
			{
				_sExceptionDetail = value;
			}
		}

		private DateTime _dExceptionDateTime;
		public DateTime ExceptionDateTime
		{
			get
			{
				return _dExceptionDateTime;
			}
			set
			{
				_dExceptionDateTime = value;
			}
		}

		#endregion
		#region Constructor & Destructor
		public PVPExceptionLog()
		{
			_bIsDisposed=false;
			_nExceptionID = 0;
			_sTerritoryID = "";
			_sGDDBID = "";
			_sPVPDetail = "";
			_nNoOfPlannedDay = 0;
			_sExceptionDetail = "";
			_dExceptionDateTime = DateTime.Today;
		}
		~PVPExceptionLog()
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
	public class PVPExceptionLogs : CollectionBase,IEnumerable
	{
		public PVPExceptionLogs()
		{
			InnerList.Clear();		}
		public void Add(PVPExceptionLog oItem)
		{
			InnerList.Add(oItem);
		}
		public PVPExceptionLog this[int i]
		{
			 get { return (PVPExceptionLog)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			PVPExceptionLog oItem = new PVPExceptionLog();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (PVPExceptionLog)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public PVPExceptionLog GetPVPExceptionLog(int nID)
		{
			PVPExceptionLog oItem = new PVPExceptionLog();
			foreach (PVPExceptionLog oPVPExceptionLog in this)
			{
				if (oPVPExceptionLog.ID.ToInt32 == nID)
				{
					oItem = oPVPExceptionLog;
					break;
				}
			}
			return oItem;
		}
	}
}
