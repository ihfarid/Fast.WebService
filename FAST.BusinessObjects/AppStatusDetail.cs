using System;
using System.Collections;
using FAST.Core.BusinessObject;
namespace FAST.BusinessObjects
{
	[Serializable]
	public class AppStatusDetail : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
		private int _nAppStatusID;
		public int AppStatusID
		{
			get
			{
				return _nAppStatusID;
			}
			set
			{
				_nAppStatusID = value;
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

        private int _nAppVersion;
        public int AppVersion
        {
            get
            {
                return _nAppVersion;
            }
            set
            {
                _nAppVersion = value;
            }
        }

		private string _sStorageSpace;
		public string StorageSpace
		{
			get
			{
				return _sStorageSpace;
			}
			set
			{
				_sStorageSpace = value;
			}
		}

		private string _sUsedSpace;
		public string UsedSpace
		{
			get
			{
				return _sUsedSpace;
			}
			set
			{
				_sUsedSpace = value;
			}
		}

		private string _sFreeSpace;
		public string FreeSpace
		{
			get
			{
				return _sFreeSpace;
			}
			set
			{
				_sFreeSpace = value;
			}
		}

		private string _sVideoData;
		public string VideoData
		{
			get
			{
				return _sVideoData;
			}
			set
			{
				_sVideoData = value;
			}
		}

		private string _sMusicData;
		public string MusicData
		{
			get
			{
				return _sMusicData;
			}
			set
			{
				_sMusicData = value;
			}
		}

		private string _sInternetAvailable;
		public string InternetAvailable
		{
			get
			{
				return _sInternetAvailable;
			}
			set
			{
				_sInternetAvailable = value;
			}
		}

		private string _sDataConnection;
		public string DataConnection
		{
			get
			{
				return _sDataConnection;
			}
			set
			{
				_sDataConnection = value;
			}
		}

		private string _sWiFiConnection;
		public string WiFiConnection
		{
			get
			{
				return _sWiFiConnection;
			}
			set
			{
				_sWiFiConnection = value;
			}
		}

		private string _sGPS;
		public string GPS
		{
			get
			{
				return _sGPS;
			}
			set
			{
				_sGPS = value;
			}
		}

		private double _nLatitude;
		public double Latitude
		{
			get
			{
				return _nLatitude;
			}
			set
			{
				_nLatitude = value;
			}
		}

		private double _nLongitude;
		public double Longitude
		{
			get
			{
				return _nLongitude;
			}
			set
			{
				_nLongitude = value;
			}
		}

		private DateTime _dLastUpdatedDate;
		public DateTime LastUpdatedDate
		{
			get
			{
				return _dLastUpdatedDate;
			}
			set
			{
				_dLastUpdatedDate = value;
			}
		}

		#endregion
		#region Constructor & Destructor
		public AppStatusDetail()
		{
			_bIsDisposed=false;
			_nAppStatusID = 0;
			_sTerritoryID = "";
            _nAppVersion = 0;
			_sStorageSpace = "";
			_sUsedSpace = "";
			_sFreeSpace = "";
			_sVideoData = "";
			_sMusicData = "";
			_sInternetAvailable = "";
			_sDataConnection = "";
			_sWiFiConnection = "";
			_sGPS = "";
			_nLatitude = 0;
			_nLongitude = 0;
			_dLastUpdatedDate = DateTime.Today;
		}
		~AppStatusDetail()
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
	public class AppStatusDetails : CollectionBase,IEnumerable
	{
		public AppStatusDetails()
		{
			InnerList.Clear();		}
		public void Add(AppStatusDetail oItem)
		{
            InnerList.Add(oItem);
		}
		public AppStatusDetail this[int i]
		{
			 get { return (AppStatusDetail)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			AppStatusDetail oItem = new AppStatusDetail();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (AppStatusDetail)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public AppStatusDetail GetAppStatusDetail(int nID)
		{
			AppStatusDetail oItem = new AppStatusDetail();
			foreach (AppStatusDetail oAppStatusDetail in this)
			{
				if (oAppStatusDetail.ID.ToInt32 == nID)
				{
					oItem = oAppStatusDetail;
					break;
				}
			}
			return oItem;
		}
	}
}
