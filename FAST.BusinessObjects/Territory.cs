using System;
using System.Collections;
using FAST.Core.BusinessObject;
using FAST.Core;
namespace FAST.BusinessObjects
{
	[Serializable]
	public class Territory : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;


		private string _sTerritoryCode;
		public string TerritoryCode
		{
			get
			{
				return _sTerritoryCode;
			}
			set
			{
				_sTerritoryCode = value;
			}
		}

		private string _sTerritoryName;
		public string TerritoryName
		{
			get
			{
				return _sTerritoryName;
			}
			set
			{
				_sTerritoryName = value;
			}
		}

		private int? _nParentID;
		public int? ParentID
		{
			get
			{
				return _nParentID;
			}
			set
			{
				_nParentID = value;
			}
		}

		private int _nWorkAreaID;
		public int WorkAreaID
		{
			get
			{
				return _nWorkAreaID;
			}
			set
			{
				_nWorkAreaID = value;
			}
		}

		private string _sMobileNo;
		public string MobileNo
		{
			get
			{
				return _sMobileNo;
			}
			set
			{
				_sMobileNo = value;
			}
		}

		private DateTime _dBeginningDate;
		public DateTime BeginningDate
		{
			get
			{
				return _dBeginningDate;
			}
			set
			{
				_dBeginningDate = value;
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
		public Territory()
		{
			_bIsDisposed=false;
			_sTerritoryCode = "";
			_sTerritoryName = "";
			_nParentID = null;
			_nWorkAreaID = 0;
			_sMobileNo = "";
			_dBeginningDate = DateTime.Today;
			_dEndDate = DateTime.Today;
			_bIsActive = false;
		}
		~Territory()
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
	public class Territorys : CollectionBase,IEnumerable
	{
		public Territorys()
		{
			InnerList.Clear();		}
		public void Add(Territory oItem)
		{
			InnerList.Add(oItem);
		}
		public Territory this[int i]
		{
			 get { return (Territory)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			Territory oItem = new Territory();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (Territory)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public Territory GetTerritory(int nID)
		{
			Territory oItem = new Territory();
			foreach (Territory oTerritory in this)
			{
				if (oTerritory.ID.ToInt32 == nID)
				{
					oItem = oTerritory;
					break;
				}
			}
			return oItem;
		}
	}
}
