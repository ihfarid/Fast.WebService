using System;
using System.Collections;
using FAST.Core.BusinessObject;
namespace FAST.BusinessObjects
{
	[Serializable]
	public class CommandInfo : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
		private int _nCommandID;
		public int CommandID
		{
			get
			{
				return _nCommandID;
			}
			set
			{
				_nCommandID = value;
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

		private string _sTableName;
		public string TableName
		{
			get
			{
				return _sTableName;
			}
			set
			{
				_sTableName = value;
			}
		}

		private string _sDescription;
		public string Description
		{
			get
			{
				return _sDescription;
			}
			set
			{
				_sDescription = value;
			}
		}

		private bool _bIsExcute;
		public bool IsExcute
		{
			get
			{
				return _bIsExcute;
			}
			set
			{
				_bIsExcute = value;
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

        private DateTime _dEntryDateTime;
        public DateTime EntryDateTime
        {
            get
            {
                return _dEntryDateTime;
            }
            set
            {
                _dEntryDateTime = value;
            }
        }

        private DateTime _dExecutedDateTime;
        public DateTime ExecutedDateTime
        {
            get
            {
                return _dExecutedDateTime;
            }
            set
            {
                _dExecutedDateTime = value;
            }
        }

		#endregion
		#region Constructor & Destructor
		public CommandInfo()
		{
			_bIsDisposed=false;
			_nCommandID = 0;
			_sTerritoryID = "";
			_sTableName = "";
			_sDescription = "";
			_bIsExcute = false;
			_nVersion = 0;
            _dEntryDateTime = DateTime.Now;
            _dExecutedDateTime = DateTime.Now;
		}
		~CommandInfo()
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
	public class CommandInfos : CollectionBase,IEnumerable
	{
		public CommandInfos()
		{
			InnerList.Clear();		}
		public void Add(CommandInfo oItem)
		{
			InnerList.Add(oItem);
		}
		public CommandInfo this[int i]
		{
			 get { return (CommandInfo)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			CommandInfo oItem = new CommandInfo();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (CommandInfo)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public CommandInfo GetCommandInfo(int nID)
		{
			CommandInfo oItem = new CommandInfo();
			foreach (CommandInfo oCommandInfo in this)
			{
				if (oCommandInfo.ID.ToInt32 == nID)
				{
					oItem = oCommandInfo;
					break;
				}
			}
			return oItem;
		}
	}
}
