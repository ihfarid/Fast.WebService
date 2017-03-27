using System;
using System.Collections;
using FAST.Core.BusinessObject;
namespace FAST.BusinessObjects
{
	[Serializable]
	public class Salutation : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
		private int _nSalID;
		public int SalID
		{
			get
			{
				return _nSalID;
			}
			set
			{
				_nSalID = value;
			}
		}

		private string _sSalCode;
		public string SalCode
		{
			get
			{
				return _sSalCode;
			}
			set
			{
				_sSalCode = value;
			}
		}

		private string _sSalDesc;
		public string SalDesc
		{
			get
			{
				return _sSalDesc;
			}
			set
			{
				_sSalDesc = value;
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
		public Salutation()
		{
			_bIsDisposed=false;
			_nSalID = 0;
			_sSalCode = "";
			_sSalDesc = "";
			_nStatus = 0;
			_nAction = 0;
			_nVersion = 0;
		}
		~Salutation()
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
	public class Salutations : CollectionBase,IEnumerable
	{
		public Salutations()
		{
			InnerList.Clear();		}
		public void Add(Salutation oItem)
		{
			InnerList.Add(oItem);
		}
		public Salutation this[int i]
		{
			 get { return (Salutation)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			Salutation oItem = new Salutation();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (Salutation)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public Salutation GetSalutation(int nID)
		{
			Salutation oItem = new Salutation();
			foreach (Salutation oSalutation in this)
			{
				if (oSalutation.ID.ToInt32 == nID)
				{
					oItem = oSalutation;
					break;
				}
			}
			return oItem;
		}
	}
}
