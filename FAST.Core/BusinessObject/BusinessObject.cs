using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAST.Core.BusinessObject
{
    [Serializable]
    public class BusinessObject : MarshalByRefObject
    {
        #region Property
        private BusinessID _oID;

        public BusinessID ID
        {
            get
            {
                return _oID;
            }
            set
            {
                _oID = value;
            }
        }

        private bool _bNew;
        public bool IsNew
        {
            get
            {
                if (_oID == null)
                {
                    _bNew = true;
                }
                else
                {
                    if (_oID.ToInt32 <= 0)
                    {
                        _bNew = true;
                    }
                    else
                    {
                        _bNew = false;
                    }
                }
                return _bNew;
            }
        }
        #endregion

        public BusinessObject()
        {
            _oID = new BusinessID();
            _bNew = false;
        }
    }

    [Serializable]
    /// <summary>
    /// Summary description for ID.
    /// </summary>
    public class BusinessID : MarshalByRefObject, IDisposable
    {
        #region Properties
        private object _oID;
        public object ID
        {
            get
            {
                return _oID;
            }
        }
        public int ToInt32
        {
            get
            {
                return Convert.ToInt32(_oID);
            }
        }
        #endregion

        #region Constructor & Destructor
        public BusinessID()
        {
        }
        public void Dispose()
        {
            _oID = null;
        }
        #endregion

        public void SetID(object oID)
        {
            _oID = oID;
        }
    }
}
