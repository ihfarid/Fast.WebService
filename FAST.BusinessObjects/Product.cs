using System;
using System.Collections;
using FAST.Core.BusinessObject;
namespace FAST.BusinessObjects
{
	[Serializable]
	public class Product : BusinessObject, IDisposable
	{
		#region property
		private bool _bIsDisposed;
		private int _nProdID;
		public int ProdID
		{
			get
			{
				return _nProdID;
			}
			set
			{
				_nProdID = value;
			}
		}

		private string _sProdCode;
		public string ProdCode
		{
			get
			{
				return _sProdCode;
			}
			set
			{
				_sProdCode = value;
			}
		}

		private string _sProdName;
		public string ProdName
		{
			get
			{
				return _sProdName;
			}
			set
			{
				_sProdName = value;
			}
		}

		private string _sLine;
		public string Line
		{
			get
			{
				return _sLine;
			}
			set
			{
				_sLine = value;
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

		#endregion
		#region Constructor & Destructor
		public Product()
		{
			_bIsDisposed=false;
			_nProdID = 0;
			_sProdCode = "";
			_sProdName = "";
			_sLine = "";
			_nStatus = 0;
		}
		~Product()
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
	public class Products : CollectionBase,IEnumerable
	{
		public Products()
		{
			InnerList.Clear();		}
		public void Add(Product oItem)
		{
			InnerList.Add(oItem);
		}
		public Product this[int i]
		{
			 get { return (Product)InnerList[i]; }
		}
		public int GetIndex(int nID)
		{
			Product oItem = new Product();
			for (int i = 0; i < InnerList.Count; i++)
			{
				oItem = (Product)InnerList[i];
				if (oItem.ID.ToInt32 == nID)
				{
					return i;
				}
			}
			return -1;
		}
		public Product GetProduct(int nID)
		{
			Product oItem = new Product();
			foreach (Product oProduct in this)
			{
				if (oProduct.ID.ToInt32 == nID)
				{
					oItem = oProduct;
					break;
				}
			}
			return oItem;
		}
	}
}
