using System;
using System.Collections;
using FAST.Core.BusinessObject;
namespace FAST.BusinessObjects
{
	[Serializable]
	public class SampleInfo : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
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

		private string _sDescription;
		public string Description
		{
			get
			{
				return _sDescription;
			}
			set
			{
				_sDescription = value;
			}
		}

		private string _sLineID;
		public string LineID
		{
			get
			{
				return _sLineID;
			}
			set
			{
				_sLineID = value;
			}
		}

		private int _nQuantity;
		public int Quantity
		{
			get
			{
				return _nQuantity;
			}
			set
			{
				_nQuantity = value;
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

		private DateTime _dCreationDate;
		public DateTime CreationDate
		{
			get
			{
				return _dCreationDate;
			}
			set
			{
				_dCreationDate = value;
			}
		}

		private int _nCreatedBy;
		public int CreatedBy
		{
			get
			{
				return _nCreatedBy;
			}
			set
			{
				_nCreatedBy = value;
			}
		}

        private DateTime _dLastModifiedDate;
        public DateTime LastModifiedDate
        {
            get
            {
                return _dLastModifiedDate;
            }
            set
            {
                _dLastModifiedDate = value;
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
		public SampleInfo()
		{
			_bIsDisposed=false;
			_nSampleID = 0;
			_sDescription = "";
			_sLineID = "";
			_nQuantity = 0;
			_nMonth = 0;
			_nYear = 0;
			_dCreationDate = DateTime.Today;
			_nCreatedBy = 0;
            _dLastModifiedDate = DateTime.Today;
            _bIsActive = false;
		}
		~SampleInfo()
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
	public class SampleInfos : CollectionBase,IEnumerable
	{
		public SampleInfos()
		{
			InnerList.Clear();		}
		public void Add(SampleInfo oItem)
		{
			InnerList.Add(oItem);
		}
		public SampleInfo this[int i]
		{
			 get { return (SampleInfo)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			SampleInfo oItem = new SampleInfo();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (SampleInfo)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public SampleInfo GetSampleInfo(int nID)
		{
			SampleInfo oItem = new SampleInfo();
			foreach (SampleInfo oSampleInfo in this)
			{
				if (oSampleInfo.ID.ToInt32 == nID)
				{
					oItem = oSampleInfo;
					break;
				}
			}
			return oItem;
		}
	}
}
