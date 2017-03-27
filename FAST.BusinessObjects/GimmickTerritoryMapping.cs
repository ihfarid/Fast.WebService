using System;
using System.Collections;
using FAST.Core.BusinessObject;
namespace FAST.BusinessObjects
{
	[Serializable]
	public class GimmickTerritoryMapping : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
        private int _nGimmickTerritoryMapID;
        public int GimmickTerritoryMapID
		{
			get
			{
                return _nGimmickTerritoryMapID;
			}
			set
			{
                _nGimmickTerritoryMapID = value;
			}
		}

        private int _nGimmickID;
        public int GimmickID
        {
            get
            {
                return _nGimmickID;
            }
            set
            {
                _nGimmickID = value;
            }
        }

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

		private string _sBrandName;
		public string BrandName
		{
			get
			{
				return _sBrandName;
			}
			set
			{
				_sBrandName = value;
			}
		}

		private string _sGimmickName;
		public string GimmickName
		{
			get
			{
				return _sGimmickName;
			}
			set
			{
				_sGimmickName = value;
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
		public GimmickTerritoryMapping()
		{
			_bIsDisposed=false;
            _nGimmickTerritoryMapID = 0;
            _nGimmickID = 0;
			_sTerritoryCode = null;
			_sBrandName = null;
			_sGimmickName = null;
            _nMonth = 0;
            _nYear = 0;
			_nVersion = 0;
			_nAction = 0;
		}
		~GimmickTerritoryMapping()
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
	public class GimmickTerritoryMappings : CollectionBase,IEnumerable
	{
		public GimmickTerritoryMappings()
		{
			InnerList.Clear();		}
		public void Add(GimmickTerritoryMapping oItem)
		{
			InnerList.Add(oItem);
		}
		public GimmickTerritoryMapping this[int i]
		{
			 get { return (GimmickTerritoryMapping)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			GimmickTerritoryMapping oItem = new GimmickTerritoryMapping();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (GimmickTerritoryMapping)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public GimmickTerritoryMapping GetGimmickTerritoryMapping(int nID)
		{
			GimmickTerritoryMapping oItem = new GimmickTerritoryMapping();
			foreach (GimmickTerritoryMapping oGimmickTerritoryMapping in this)
			{
				if (oGimmickTerritoryMapping.ID.ToInt32 == nID)
				{
					oItem = oGimmickTerritoryMapping;
					break;
				}
			}
			return oItem;
		}
	}
}
