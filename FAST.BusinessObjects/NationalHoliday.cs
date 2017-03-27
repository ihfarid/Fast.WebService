using System;
using System.Collections;
using FAST.Core.BusinessObject;
namespace FAST.BusinessObjects
{
	[Serializable]
	public class NationalHoliday : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
		private int _nHolidayID;
		public int HolidayID
		{
			get
			{
				return _nHolidayID;
			}
			set
			{
				_nHolidayID = value;
			}
		}

		private string _sName;
		public string Name
		{
			get
			{
				return _sName;
			}
			set
			{
				_sName = value;
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
		public NationalHoliday()
		{
			_bIsDisposed=false;
			_nHolidayID = 0;
			_sName = null;
			_nDay = 0;
			_nMonth = 0;
			_nYear = 0;
			_nVersion = 0;
			_nAction = 0;
		}
		~NationalHoliday()
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
	public class NationalHolidays : CollectionBase,IEnumerable
	{
		public NationalHolidays()
		{
			InnerList.Clear();		}
		public void Add(NationalHoliday oItem)
		{
			InnerList.Add(oItem);
		}
		public NationalHoliday this[int i]
		{
			 get { return (NationalHoliday)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			NationalHoliday oItem = new NationalHoliday();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (NationalHoliday)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public NationalHoliday GetNationalHoliday(int nID)
		{
			NationalHoliday oItem = new NationalHoliday();
			foreach (NationalHoliday oNationalHoliday in this)
			{
				if (oNationalHoliday.ID.ToInt32 == nID)
				{
					oItem = oNationalHoliday;
					break;
				}
			}
			return oItem;
		}
	}
}
