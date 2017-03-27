using System;
using System.Collections;
using FAST.Core.BusinessObject;
namespace FAST.BusinessObjects
{
	[Serializable]
	public class UserManagementInfo : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;


		private int _nMinimumPasswordLength;
		public int MinimumPasswordLength
		{
			get
			{
				return _nMinimumPasswordLength;
			}
			set
			{
				_nMinimumPasswordLength = value;
			}
		}

		private bool _bIsCapitalLetter;
		public bool IsCapitalLetter
		{
			get
			{
				return _bIsCapitalLetter;
			}
			set
			{
				_bIsCapitalLetter = value;
			}
		}

		private bool _bIsLowerLetter;
		public bool IsLowerLetter
		{
			get
			{
				return _bIsLowerLetter;
			}
			set
			{
				_bIsLowerLetter = value;
			}
		}

		private bool _bIsNumericNumber;
		public bool IsNumericNumber
		{
			get
			{
				return _bIsNumericNumber;
			}
			set
			{
				_bIsNumericNumber = value;
			}
		}

		private bool _bIsSpecialChar;
		public bool IsSpecialChar
		{
			get
			{
				return _bIsSpecialChar;
			}
			set
			{
				_bIsSpecialChar = value;
			}
		}

		private int _nMinimumPasswordAge;
		public int MinimumPasswordAge
		{
			get
			{
				return _nMinimumPasswordAge;
			}
			set
			{
				_nMinimumPasswordAge = value;
			}
		}

		#endregion
		#region Constructor & Destructor
		public UserManagementInfo()
		{
			_bIsDisposed=false;
			_nMinimumPasswordLength = 0;
			_bIsCapitalLetter = false;
			_bIsLowerLetter = false;
			_bIsNumericNumber = false;
			_bIsSpecialChar = false;
			_nMinimumPasswordAge = 0;
		}
		~UserManagementInfo()
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
	public class UserManagementInfos : CollectionBase,IEnumerable
	{
		public UserManagementInfos()
		{
			InnerList.Clear();		}
		public void Add(UserManagementInfo oItem)
		{
			InnerList.Add(oItem);
		}
		public UserManagementInfo this[int i]
		{
			 get { return (UserManagementInfo)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			UserManagementInfo oItem = new UserManagementInfo();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (UserManagementInfo)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public UserManagementInfo GetUserManagementInfo(int nID)
		{
			UserManagementInfo oItem = new UserManagementInfo();
			foreach (UserManagementInfo oUserManagementInfo in this)
			{
				if (oUserManagementInfo.ID.ToInt32 == nID)
				{
					oItem = oUserManagementInfo;
					break;
				}
			}
			return oItem;
		}
	}
}
