using System;
using System.Collections;
using FAST.Core.BusinessObject;
namespace FAST.BusinessObjects
{
	[Serializable]
	public class Upazilla : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
		private int _nUID;
		public int UID
		{
			get
			{
				return _nUID;
			}
			set
			{
				_nUID = value;
			}
		}

		private string _sUName;
		public string UName
		{
			get
			{
				return _sUName;
			}
			set
			{
				_sUName = value;
			}
		}

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
		public Upazilla()
		{
			_bIsDisposed=false;
			_nUID = 0;
			_sUName = "";
			_nDistID = 0;
			_nAction = 0;
			_nVersion = 0;
		}
		~Upazilla()
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
	public class Upazillas : CollectionBase,IEnumerable
	{
		public Upazillas()
		{
			InnerList.Clear();		}
		public void Add(Upazilla oItem)
		{
			InnerList.Add(oItem);
		}
		public Upazilla this[int i]
		{
			 get { return (Upazilla)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			Upazilla oItem = new Upazilla();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (Upazilla)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public Upazilla GetUpazilla(int nID)
		{
			Upazilla oItem = new Upazilla();
			foreach (Upazilla oUpazilla in this)
			{
				if (oUpazilla.ID.ToInt32 == nID)
				{
					oItem = oUpazilla;
					break;
				}
			}
			return oItem;
		}
	}
}
