using System;
using System.Collections;
using FAST.Core.BusinessObject;
namespace FAST.BusinessObjects
{
	[Serializable]
	public class PVPMonthCycle : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
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

		private DateTime _dStartDate;
		public DateTime StartDate
		{
			get
			{
				return _dStartDate;
			}
			set
			{
				_dStartDate = value;
			}
		}

		private DateTime _dEndDate;
		public DateTime EndDate
		{
			get
			{
				return _dEndDate;
			}
			set
			{
				_dEndDate = value;
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
		public PVPMonthCycle()
		{
			_bIsDisposed=false;
			_nCycleID = 0;
			_dStartDate = DateTime.Today;
			_dEndDate = DateTime.Today;
			_nMonth = 0;
			_nYear = 0;
			_bIsActive = false;
		}
		~PVPMonthCycle()
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
	public class PVPMonthCycles : CollectionBase,IEnumerable
	{
		public PVPMonthCycles()
		{
			InnerList.Clear();		}
		public void Add(PVPMonthCycle oItem)
		{
			InnerList.Add(oItem);
		}
		public PVPMonthCycle this[int i]
		{
			 get { return (PVPMonthCycle)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			PVPMonthCycle oItem = new PVPMonthCycle();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (PVPMonthCycle)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public PVPMonthCycle GetPVPMonthCycle(int nID)
		{
			PVPMonthCycle oItem = new PVPMonthCycle();
			foreach (PVPMonthCycle oPVPMonthCycle in this)
			{
				if (oPVPMonthCycle.ID.ToInt32 == nID)
				{
					oItem = oPVPMonthCycle;
					break;
				}
			}
			return oItem;
		}
	}
}
