using System;
using System.Collections;
using FAST.Core.BusinessObject;

namespace FAST.BusinessObjects
{
    //public enum StatusType
    //{
    //    RM_Pending = 1,
    //    Approved,
    //    Rejected,
    //    Remove,
    //    SFE_Pending,
    //}

	[Serializable]
	public class DoctorTerritoryMapping : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
		private int _nTerrWiseDocID;
		public int TerrWiseDocID
		{
			get
			{
				return _nTerrWiseDocID;
			}
			set
			{
				_nTerrWiseDocID = value;
			}
		}

		private int _nDoctorID;
		public int DoctorID
		{
			get
			{
				return _nDoctorID;
			}
			set
			{
				_nDoctorID = value;
			}
		}

		private string _sCode;
		public string Code
		{
			get
			{
				return _sCode;
			}
			set
			{
				_sCode = value;
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

		private int _nDocTypeID;
		public int DocTypeID
		{
			get
			{
				return _nDocTypeID;
			}
			set
			{
				_nDocTypeID = value;
			}
		}

        private int _nAddress;
        public int Address
        {
            get
            {
                return _nAddress;
            }
            set
            {
                _nAddress = value;
            }
        }

        private int _nSpeciality;
        public int Speciality
        {
            get
            {
                return _nSpeciality;
            }
            set
            {
                _nSpeciality = value;
            }
        }

        private int _nDegree;
        public int Degree
        {
            get
            {
                return _nDegree;
            }
            set
            {
                _nDegree = value;
            }
        }

		private int _nSwajanStatus;
		public int SwajanStatus
		{
			get
			{
				return _nSwajanStatus;
			}
			set
			{
				_nSwajanStatus = value;
			}
		}

		private int _nProfileID;
		public int ProfileID
		{
			get
			{
				return _nProfileID;
			}
			set
			{
				_nProfileID = value;
			}
		}

		private int _nProd1;
		public int Prod1
		{
			get
			{
				return _nProd1;
			}
			set
			{
				_nProd1 = value;
			}
		}

		private int _nProd2;
		public int Prod2
		{
			get
			{
				return _nProd2;
			}
			set
			{
				_nProd2 = value;
			}
		}

		private int _nProd3;
		public int Prod3
		{
			get
			{
				return _nProd3;
			}
			set
			{
				_nProd3 = value;
			}
		}

		private int _nProd4;
		public int Prod4
		{
			get
			{
				return _nProd4;
			}
			set
			{
				_nProd4 = value;
			}
		}

		private int _nProd5;
		public int Prod5
		{
			get
			{
				return _nProd5;
			}
			set
			{
				_nProd5 = value;
			}
		}

		private int _nProd6;
		public int Prod6
		{
			get
			{
				return _nProd6;
			}
			set
			{
				_nProd6 = value;
			}
		}

        private int _nProd7;
        public int Prod7
        {
            get
            {
                return _nProd7;
            }
            set
            {
                _nProd7 = value;
            }
        }

        private int _nProd8;
        public int Prod8
        {
            get
            {
                return _nProd8;
            }
            set
            {
                _nProd8 = value;
            }
        }

		private int _nCallFre;
		public int CallFre
		{
			get
			{
				return _nCallFre;
			}
			set
			{
				_nCallFre = value;
			}
		}

		private int _nRouteID;
		public int RouteID
		{
			get
			{
				return _nRouteID;
			}
			set
			{
				_nRouteID = value;
			}
		}

		private int _nSessionID;
		public int SessionID
		{
			get
			{
				return _nSessionID;
			}
			set
			{
				_nSessionID = value;
			}
		}

		private DateTime _dCreateDatetime;
		public DateTime CreateDatetime
		{
			get
			{
				return _dCreateDatetime;
			}
			set
			{
				_dCreateDatetime = value;
			}
		}

		private DateTime _dModifyDatetime;
		public DateTime ModifyDatetime
		{
			get
			{
				return _dModifyDatetime;
			}
			set
			{
				_dModifyDatetime = value;
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
		public DoctorTerritoryMapping()
		{
			_bIsDisposed=false;
			_nTerrWiseDocID = 0;
			_nDoctorID = 0;
			_sCode = null;
			_sTerritoryID = null;
			_nDocTypeID = 0;
            _nAddress = 0;
            _nSpeciality = 0;
            _nDegree = 0;
			_nSwajanStatus = 0;
			_nProfileID = 0;
			_nProd1 = 0;
			_nProd2 = 0;
			_nProd3 = 0;
			_nProd4 = 0;
			_nProd5 = 0;
			_nProd6 = 0;
            _nProd7 = 0;
            _nProd8 = 0;
			_nCallFre = 0;
			_nRouteID = 0;
			_nSessionID = 0;
            _dCreateDatetime = DateTime.Today; 
            _dModifyDatetime = DateTime.Today; 
			_nStatus = 0;
			_nVersion = 0;
			_nAction = 0;
		}
		~DoctorTerritoryMapping()
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
	public class DoctorTerritoryMappings : CollectionBase,IEnumerable
	{
		public DoctorTerritoryMappings()
		{
			InnerList.Clear();		}
		public void Add(DoctorTerritoryMapping oItem)
		{
			InnerList.Add(oItem);
		}
		public DoctorTerritoryMapping this[int i]
		{
			 get { return (DoctorTerritoryMapping)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			DoctorTerritoryMapping oItem = new DoctorTerritoryMapping();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (DoctorTerritoryMapping)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public DoctorTerritoryMapping GetDoctorTerritoryMapping(int nID)
		{
			DoctorTerritoryMapping oItem = new DoctorTerritoryMapping();
			foreach (DoctorTerritoryMapping oDoctorTerritoryMapping in this)
			{
				if (oDoctorTerritoryMapping.ID.ToInt32 == nID)
				{
					oItem = oDoctorTerritoryMapping;
					break;
				}
			}
			return oItem;
		}
	}
}
