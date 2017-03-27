using System;
using System.Collections;
using FAST.Core.BusinessObject;
namespace FAST.BusinessObjects
{
	[Serializable]
	public class District : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
		private int _nDistID;
		public int DistID
		{
			get
			{
				return _nDistID;
			}
			set
			{
				_nDistID = value;
			}
		}

		private string _sDistName;
		public string DistName
		{
			get
			{
				return _sDistName;
			}
			set
			{
				_sDistName = value;
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

		#endregion
		#region Constructor & Destructor
		public District()
		{
			_bIsDisposed=false;
			_nDistID = 0;
			_sDistName = "";
			_nAction = 0;
			_nVersion = 0;
		}
		~District()
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
	public class Districts : CollectionBase,IEnumerable
	{
		public Districts()
		{
			InnerList.Clear();		}
		public void Add(District oItem)
		{
			InnerList.Add(oItem);
		}
		public District this[int i]
		{
			 get { return (District)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			District oItem = new District();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (District)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public District GetDistrict(int nID)
		{
			District oItem = new District();
			foreach (District oDistrict in this)
			{
				if (oDistrict.ID.ToInt32 == nID)
				{
					oItem = oDistrict;
					break;
				}
			}
			return oItem;
		}
	}
}
