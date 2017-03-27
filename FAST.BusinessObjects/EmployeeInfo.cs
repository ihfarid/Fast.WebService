using System;
using System.Collections;
using FAST.Core.BusinessObject;

namespace FAST.BusinessObjects
{
	[Serializable]
	public class EmployeeInfo : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;


		private string _sEmpCode;
		public string EmpCode
		{
			get
			{
				return _sEmpCode;
			}
			set
			{
				_sEmpCode = value;
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

		private int _nTerritoryID;
		public int TerritoryID
		{
			get
			{
				return _nTerritoryID;
			}
			set
			{
				_nTerritoryID = value;
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

        private string _sBU;
        public string BU
        {
            get
            {
                return _sBU;
            }
            set
            {
                _sBU = value;
            }
        }

		#endregion
		#region Constructor & Destructor
		public EmployeeInfo()
		{
			_bIsDisposed=false;
			_sEmpCode = "";
			_sName = "";
			_sGDDBID = "";
			_nTerritoryID = 0;
			_sMobileNo = "";
			_dBeginningDate = DateTime.Today;
			_dEndDate = DateTime.Today;
			_bIsActive = false;
            _sBU = null;
		}
		~EmployeeInfo()
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
	public class EmployeeInfos : CollectionBase,IEnumerable
	{
		public EmployeeInfos()
		{
			InnerList.Clear();		}
		public void Add(EmployeeInfo oItem)
		{
			InnerList.Add(oItem);
		}
		public EmployeeInfo this[int i]
		{
			 get { return (EmployeeInfo)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			EmployeeInfo oItem = new EmployeeInfo();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (EmployeeInfo)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public EmployeeInfo GetEmployeeInfo(int nID)
		{
			EmployeeInfo oItem = new EmployeeInfo();
			foreach (EmployeeInfo oEmployeeInfo in this)
			{
				if (oEmployeeInfo.ID.ToInt32 == nID)
				{
					oItem = oEmployeeInfo;
					break;
				}
			}
			return oItem;
		}
	}
}
