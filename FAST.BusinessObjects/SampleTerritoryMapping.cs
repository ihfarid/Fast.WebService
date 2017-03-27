using System;
using System.Collections;
using FAST.Core.BusinessObject;
namespace FAST.BusinessObjects
{
	[Serializable]
	public class SampleTerritoryMapping : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
        private int _nSampleTerritoryMapID;
        public int SampleTerritoryMapID
		{
			get
			{
                return _nSampleTerritoryMapID;
			}
			set
			{
                _nSampleTerritoryMapID = value;
			}
		}

        private int _nSampleID;
        public int SampleID
        {
            get
            {
                return _nSampleID;
            }
            set
            {
                _nSampleID = value;
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

		private string _sSampleName;
		public string SampleName
		{
			get
			{
				return _sSampleName;
			}
			set
			{
				_sSampleName = value;
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

		private int? _nVersion;
		public int? Version
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

		private int? _nAction;
        public int? Action
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
		public SampleTerritoryMapping()
		{
			_bIsDisposed=false;
            _nSampleTerritoryMapID = 0;
            _nSampleID = 0;
			_sTerritoryCode = null;
			_sBrandName = null;
			_sSampleName = null;
            _nMonth = 0;
            _nYear = 0;
			_nVersion = null;
			_nAction = 0;
		}
		~SampleTerritoryMapping()
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
	public class SampleTerritoryMappings : CollectionBase,IEnumerable
	{
		public SampleTerritoryMappings()
		{
			InnerList.Clear();		}
		public void Add(SampleTerritoryMapping oItem)
		{
			InnerList.Add(oItem);
		}
		public SampleTerritoryMapping this[int i]
		{
			 get { return (SampleTerritoryMapping)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			SampleTerritoryMapping oItem = new SampleTerritoryMapping();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (SampleTerritoryMapping)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public SampleTerritoryMapping GetSampleTerritoryMapping(int nID)
		{
			SampleTerritoryMapping oItem = new SampleTerritoryMapping();
			foreach (SampleTerritoryMapping oSampleTerritoryMapping in this)
			{
				if (oSampleTerritoryMapping.ID.ToInt32 == nID)
				{
					oItem = oSampleTerritoryMapping;
					break;
				}
			}
			return oItem;
		}
	}
}
