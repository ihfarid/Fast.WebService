using System;
using System.Collections;
using FAST.Core.BusinessObject;
namespace FAST.BusinessObjects
{
	[Serializable]
	public class PVPWorkingDay : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
		private int _nMonthID;
		public int MonthID
		{
			get
			{
				return _nMonthID;
			}
			set
			{
				_nMonthID = value;
			}
		}

		private int _nNoOfWorkingDay;
		public int NoOfWorkingDay
		{
			get
			{
				return _nNoOfWorkingDay;
			}
			set
			{
				_nNoOfWorkingDay = value;
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
		public PVPWorkingDay()
		{
			_bIsDisposed=false;
			_nMonthID = 0;
			_nNoOfWorkingDay = 0;
			_nMonth = 0;
			_nYear = 0;
			_nVersion = 0;
			_nAction = 0;
		}
		~PVPWorkingDay()
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
	public class PVPWorkingDays : CollectionBase,IEnumerable
	{
		public PVPWorkingDays()
		{
			InnerList.Clear();		}
		public void Add(PVPWorkingDay oItem)
		{
			InnerList.Add(oItem);
		}
		public PVPWorkingDay this[int i]
		{
			 get { return (PVPWorkingDay)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			PVPWorkingDay oItem = new PVPWorkingDay();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (PVPWorkingDay)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public PVPWorkingDay GetPVPWorkingDay(int nID)
		{
			PVPWorkingDay oItem = new PVPWorkingDay();
			foreach (PVPWorkingDay oPVPWorkingDay in this)
			{
				if (oPVPWorkingDay.ID.ToInt32 == nID)
				{
					oItem = oPVPWorkingDay;
					break;
				}
			}
			return oItem;
		}
	}
}
