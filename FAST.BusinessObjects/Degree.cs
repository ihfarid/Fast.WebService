using System;
using System.Collections;
using FAST.Core.BusinessObject;
namespace FAST.BusinessObjects
{
	[Serializable]
	public class Degree : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
		private int _nDegID;
		public int DegID
		{
			get
			{
				return _nDegID;
			}
			set
			{
				_nDegID = value;
			}
		}

		private string _sDegCode;
		public string DegCode
		{
			get
			{
				return _sDegCode;
			}
			set
			{
				_sDegCode = value;
			}
		}

		private string _sDegName;
		public string DegName
		{
			get
			{
				return _sDegName;
			}
			set
			{
				_sDegName = value;
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
		public Degree()
		{
			_bIsDisposed=false;
			_nDegID = 0;
			_sDegCode = "";
			_sDegName = "";
			_nStatus = 0;
			_nAction = 0;
			_nVersion = 0;
		}
		~Degree()
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
	public class Degrees : CollectionBase,IEnumerable
	{
		public Degrees()
		{
			InnerList.Clear();		}
		public void Add(Degree oItem)
		{
			InnerList.Add(oItem);
		}
		public Degree this[int i]
		{
			 get { return (Degree)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			Degree oItem = new Degree();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (Degree)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public Degree GetDegree(int nID)
		{
			Degree oItem = new Degree();
			foreach (Degree oDegree in this)
			{
				if (oDegree.ID.ToInt32 == nID)
				{
					oItem = oDegree;
					break;
				}
			}
			return oItem;
		}
	}
}
