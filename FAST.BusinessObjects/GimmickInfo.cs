using System;
using System.Collections;
using FAST.Core.BusinessObject;
namespace FAST.BusinessObjects
{
    [Serializable]
    public class GimmickInfo : BusinessObject, IDisposable
    {
        #region property
        private bool _bIsDisposed;
        private int _nGimmickID;
        public int GimmickID
        {
            get
            {
                return _nGimmickID;
            }
            set
            {
                _nGimmickID = value;
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

        private string _sLineID;
        public string LineID
        {
            get
            {
                return _sLineID;
            }
            set
            {
                _sLineID = value;
            }
        }

        private int _nQuantity;
        public int Quantity
        {
            get
            {
                return _nQuantity;
            }
            set
            {
                _nQuantity = value;
            }
        }

        private int _nMonth;
        public int Month
        {
            get
            {
                return _nMonth;
            }
            set
            {
                _nMonth = value;
            }
        }

        private int _nYear;
        public int Year
        {
            get
            {
                return _nYear;
            }
            set
            {
                _nYear = value;
            }
        }

        private DateTime _dCreationDate;
        public DateTime CreationDate
        {
            get
            {
                return _dCreationDate;
            }
            set
            {
                _dCreationDate = value;
            }
        }

        private int _nCreatedBy;
        public int CreatedBy
        {
            get
            {
                return _nCreatedBy;
            }
            set
            {
                _nCreatedBy = value;
            }
        }

        private DateTime _dLastModifiedDate;
        public DateTime LastModifiedDate
        {
            get
            {
                return _dLastModifiedDate;
            }
            set
            {
                _dLastModifiedDate = value;
            }
        }

        private bool _bIsActive;
        public bool IsActive
        {
            get
            {
                return _bIsActive;
            }
            set
            {
                _bIsActive = value;
            }
        }

        #endregion
        #region Constructor & Destructor
        public GimmickInfo()
        {
            _bIsDisposed = false;
            _nGimmickID = 0;
            _sDescription = "";
            _sLineID = "";
            _nQuantity = 0;
            _nMonth = 0;
            _nYear = 0;
            _dCreationDate = DateTime.Today;
            _nCreatedBy = 0;
            _dLastModifiedDate = DateTime.Today;
            _bIsActive = false;
        }
        ~GimmickInfo()
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
    public class GimmickInfos : CollectionBase, IEnumerable
    {
        public GimmickInfos()
        {
            InnerList.Clear();
        }
        public void Add(GimmickInfo oItem)
        {
            InnerList.Add(oItem);
        }
        public GimmickInfo this[int i]
        {
            get { return (GimmickInfo)InnerList[i]; }
        }
        public int GetIndex(int nID)
        {
            GimmickInfo oItem = new GimmickInfo();
            for (int i = 0; i < InnerList.Count; i++)
            {
                oItem = (GimmickInfo)InnerList[i];
                if (oItem.ID.ToInt32 == nID)
                {
                    return i;
                }
            }
            return -1;
        }
        public GimmickInfo GetGimmickInfo(int nID)
        {
            GimmickInfo oItem = new GimmickInfo();
            foreach (GimmickInfo oGimmickInfo in this)
            {
                if (oGimmickInfo.ID.ToInt32 == nID)
                {
                    oItem = oGimmickInfo;
                    break;
                }
            }
            return oItem;
        }
    }
}
