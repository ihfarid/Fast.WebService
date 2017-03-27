using System;
using System.Collections;
using FAST.Core.BusinessObject;
namespace FAST.BusinessObjects
{
	[Serializable]
	public class Reason : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
		private int _nReasonID;
		public int ReasonID
		{
			get
			{
				return _nReasonID;
			}
			set
			{
				_nReasonID = value;
			}
		}

		private string _sReasonDescription;
		public string ReasonDescription
		{
			get
			{
				return _sReasonDescription;
			}
			set
			{
				_sReasonDescription = value;
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
		public Reason()
		{
			_bIsDisposed=false;
			_nReasonID = 0;
			_sReasonDescription = "";
			_nVersion = 0;
			_nAction = 0;
		}
		~Reason()
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
	public class Reasons : CollectionBase,IEnumerable
	{
		public Reasons()
		{
			InnerList.Clear();		}
		public void Add(Reason oItem)
		{
			InnerList.Add(oItem);
		}
		public Reason this[int i]
		{
			 get { return (Reason)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			Reason oItem = new Reason();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (Reason)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public Reason GetReason(int nID)
		{
			Reason oItem = new Reason();
			foreach (Reason oReason in this)
			{
				if (oReason.ID.ToInt32 == nID)
				{
					oItem = oReason;
					break;
				}
			}
			return oItem;
		}
	}
}
