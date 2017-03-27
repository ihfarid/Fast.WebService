using System;
using System.Collections;
using FAST.Core.BusinessObject;
using FAST.Core;
namespace FAST.BusinessObjects
{
	[Serializable]
	public class SecQuesInfo : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;


		private string _sSecQues;
		public string SecQues
		{
			get
			{
				return _sSecQues;
			}
			set
			{
				_sSecQues = value;
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

		private int _nActionType;
		public int ActionType
		{
			get
			{
				return _nActionType;
			}
			set
			{
				_nActionType = value;
			}
		}

		private DateTime _dEntryDate;
		public DateTime EntryDate
		{
			get
			{
				return _dEntryDate;
			}
			set
			{
				_dEntryDate = value;
			}
		}

		private DateTime _dLastUpdateDate;
		public DateTime LastUpdateDate
		{
			get
			{
				return _dLastUpdateDate;
			}
			set
			{
				_dLastUpdateDate = value;
			}
		}

		#endregion
		#region Constructor & Destructor
		public SecQuesInfo()
		{
			_bIsDisposed=false;
			_sSecQues = "";
			_nVersion = 0;
			_nActionType = 0;
			_dEntryDate = DateTime.Today;
			_dLastUpdateDate = DateTime.Today;
		}
		~SecQuesInfo()
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
	public class SecQuesInfos : CollectionBase,IEnumerable
	{
		public SecQuesInfos()
		{
			InnerList.Clear();		}
		public void Add(SecQuesInfo oItem)
		{
			InnerList.Add(oItem);
		}
		public SecQuesInfo this[int i]
		{
			 get { return (SecQuesInfo)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			SecQuesInfo oItem = new SecQuesInfo();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (SecQuesInfo)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public SecQuesInfo GetSecQuesInfo(int nID)
		{
			SecQuesInfo oItem = new SecQuesInfo();
			foreach (SecQuesInfo oSecQuesInfo in this)
			{
				if (oSecQuesInfo.ID.ToInt32 == nID)
				{
					oItem = oSecQuesInfo;
					break;
				}
			}
			return oItem;
		}
	}
}
