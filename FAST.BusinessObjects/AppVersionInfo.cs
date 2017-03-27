using System;
using System.Collections;
using FAST.Core.BusinessObject;
namespace FAST.BusinessObjects
{
	[Serializable]
	public class AppVersionInfo : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
		private int _nVersionNo;
		public int VersionNo
		{
			get
			{
				return _nVersionNo;
			}
			set
			{
				_nVersionNo = value;
			}
		}

		private string _sAppURL;
		public string AppURL
		{
			get
			{
				return _sAppURL;
			}
			set
			{
				_sAppURL = value;
			}
		}

        private string _sAppType;
        public string AppType
		{
			get
			{
                return _sAppType;
			}
			set
			{
                _sAppType = value;
			}
		}

		private DateTime _dReleaseDate;
		public DateTime ReleaseDate
		{
			get
			{
				return _dReleaseDate;
			}
			set
			{
				_dReleaseDate = value;
			}
		}

		#endregion
		#region Constructor & Destructor
		public AppVersionInfo()
		{
			_bIsDisposed=false;
			_nVersionNo = 0;
			_sAppURL = "";
            _sAppType = "";
			_dReleaseDate = DateTime.Today;
		}
		~AppVersionInfo()
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
	public class AppVersionInfos : CollectionBase,IEnumerable
	{
		public AppVersionInfos()
		{
			InnerList.Clear();		}
		public void Add(AppVersionInfo oItem)
		{
			InnerList.Add(oItem);
		}
		public AppVersionInfo this[int i]
		{
			 get { return (AppVersionInfo)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			AppVersionInfo oItem = new AppVersionInfo();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (AppVersionInfo)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public AppVersionInfo GetAppVersionInfo(int nID)
		{
			AppVersionInfo oItem = new AppVersionInfo();
			foreach (AppVersionInfo oAppVersionInfo in this)
			{
				if (oAppVersionInfo.ID.ToInt32 == nID)
				{
					oItem = oAppVersionInfo;
					break;
				}
			}
			return oItem;
		}
	}
}
