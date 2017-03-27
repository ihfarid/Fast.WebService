using System;
using System.Collections;
using FAST.Core.BusinessObject;
namespace FAST.BusinessObjects
{
	[Serializable]
	public class BrandTerritoryMapping : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
		private int _nBrandTerritoryMappingID;
		public int BrandTerritoryMappingID
		{
			get
			{
				return _nBrandTerritoryMappingID;
			}
			set
			{
				_nBrandTerritoryMappingID = value;
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

        private string _sLine;
        public string Line
        {
            get
            {
                return _sLine;
            }
            set
            {
                _sLine = value;
            }
        }

        private int _nBrandID;
        public int BrandID
        {
            get
            {
                return _nBrandID;
            }
            set
            {
                _nBrandID = value;
            }
        }

		private string _sBrandCode;
		public string BrandCode
		{
			get
			{
				return _sBrandCode;
			}
			set
			{
				_sBrandCode = value;
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

        private string _sNoOfGuidedDr;
        public string NoOfGuidedDr
        {
            get
            {
                return _sNoOfGuidedDr;
            }
            set
            {
                _sNoOfGuidedDr = value;
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
		public BrandTerritoryMapping()
		{
			_bIsDisposed=false;
			_nBrandTerritoryMappingID = 0;
			_sTerritoryID = "";
            _sLine = "";
            _nBrandID = 0;
			_sBrandCode = "";
			_sBrandName = "";
            _sNoOfGuidedDr = null;
			_nVersion = 0;
			_nAction = 0;
		}
		~BrandTerritoryMapping()
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
	public class BrandTerritoryMappings : CollectionBase,IEnumerable
	{
		public BrandTerritoryMappings()
		{
			InnerList.Clear();		}
		public void Add(BrandTerritoryMapping oItem)
		{
			InnerList.Add(oItem);
		}
		public BrandTerritoryMapping this[int i]
		{
			 get { return (BrandTerritoryMapping)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			BrandTerritoryMapping oItem = new BrandTerritoryMapping();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (BrandTerritoryMapping)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public BrandTerritoryMapping GetBrandTerritoryMapping(int nID)
		{
			BrandTerritoryMapping oItem = new BrandTerritoryMapping();
			foreach (BrandTerritoryMapping oBrandTerritoryMapping in this)
			{
				if (oBrandTerritoryMapping.ID.ToInt32 == nID)
				{
					oItem = oBrandTerritoryMapping;
					break;
				}
			}
			return oItem;
		}
	}
}
