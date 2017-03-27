using System;
using System.Collections;
using FAST.Core.BusinessObject; 
namespace FAST.BusinessObjects
{
	[Serializable]
	public class Specialty : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
		private int _nSpID;
		public int SpID
		{
			get
			{
				return _nSpID;
			}
			set
			{
				_nSpID = value;
			}
		}

		private string _sSpCode;
		public string SpCode
		{
			get
			{
				return _sSpCode;
			}
			set
			{
				_sSpCode = value;
			}
		}

		private string _sSpDesc;
		public string SpDesc
		{
			get
			{
				return _sSpDesc;
			}
			set
			{
				_sSpDesc = value;
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
		public Specialty()
		{
			_bIsDisposed=false;
			_nSpID = 0;
			_sSpCode = "";
			_sSpDesc = "";
			_nStatus = 0;
			_nAction = 0;
			_nVersion = 0;
		}
		~Specialty()
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
	public class Specialtys : CollectionBase,IEnumerable
	{
		public Specialtys()
		{
			InnerList.Clear();		}
		public void Add(Specialty oItem)
		{
			InnerList.Add(oItem);
		}
		public Specialty this[int i]
		{
			 get { return (Specialty)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			Specialty oItem = new Specialty();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (Specialty)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public Specialty GetSpecialty(int nID)
		{
			Specialty oItem = new Specialty();
			foreach (Specialty oSpecialty in this)
			{
				if (oSpecialty.ID.ToInt32 == nID)
				{
					oItem = oSpecialty;
					break;
				}
			}
			return oItem;
		}
	}
}
