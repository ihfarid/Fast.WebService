using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace FAST.Core
{
    public class OCSWSMenu
    {
        private string _sCode;
        public string Code
        {
            get
            {
                return _sCode;
            }
            set
            {
                _sCode = value;
            }
        }
        private string _sCaption;
        public string Caption
        {
            get
            {
                return _sCaption;
            }
            set
            {
                _sCaption = "";
            }
        }
        private OCSWSMenuCollection _oMenuCollection;
        public OCSWSMenuCollection SubMenus
        {
            get
            {
                return _oMenuCollection;
            }
            set
            {
                _oMenuCollection = value;
            }
        }
        private int _nUserType;
        public int UserType
        {
            get
            {
                return _nUserType;
            }
            set
            {
                _nUserType = value;
            }
        }

        public OCSWSMenu()
        {
            _nUserType = 1;
            _sCaption = "";
            _sCode = "";
            _oMenuCollection = new OCSWSMenuCollection();
        }
        public OCSWSMenu(string sCode, string sCaption, int nUserType)
        {
            _sCaption = sCaption;
            _sCode = sCode;
            _nUserType = nUserType;
            _oMenuCollection = new OCSWSMenuCollection();
        }
    }
    public class OCSWSMenuCollection : CollectionBase
    {
        public OCSWSMenuCollection()
        {
            InnerList.Clear();
        }
        public void Add(OCSWSMenu oItem)
        {
            InnerList.Add(oItem);
        }
        public OCSWSMenu this[int i]
        {
            get { return (OCSWSMenu)InnerList[i]; }
        }
        public int GetIndex(string sCode)
        {
            OCSWSMenu oItem = new OCSWSMenu();
            for (int i = 0; i < InnerList.Count; i++)
            {
                oItem = (OCSWSMenu)InnerList[i];
                if (oItem.Code == sCode)
                {
                    return i;
                }
            }
            return -1;
        }
        public OCSWSMenu GetOCSWSMenu(string sCode)
        {
            OCSWSMenu oItem = new OCSWSMenu();
            foreach (OCSWSMenu oOCSWSMenu in this)
            {
                if (oOCSWSMenu.Code == sCode)
                {
                    oItem = oOCSWSMenu;
                    break;
                }
            }
            return oItem;
        }
        /*
         * ADMINISTRATOR=1,
            HEADOFMARKETING=2,
            PORTFOLIOMANAGER=3,
            MARKETINGSERVICE=4,
            SUPPLYCHAIN=5,
            REPORTVIEWER=6
        */
        public void CreateMenu()
        {
            OCSWSMenu oMenuItem = new OCSWSMenu();
            OCSWSMenu oProductMenu = new OCSWSMenu();
            OCSWSMenu oMappingItem = new OCSWSMenu();
            OCSWSMenu oMenuItem2 = new OCSWSMenu();

            InnerList.Clear();
            //#region For HOM
            //oMenuItem = new OCSWSMenu("FRM2.2.0", "Configuration", 2);
            //Add(oMenuItem);

            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM2.2.1", "System Parameter", 2));
            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM2.2.2", "Yearly Budget", 2));

            //oMenuItem = new OCSWSMenu("FRM2.3.0", "Portfolio", 2);
            //Add(oMenuItem);
            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM2.3.1", "Portfolio Assignment", 2));
            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM2.3.2", "Budget Transfer", 2));

            //oMenuItem = new OCSWSMenu("FRM2.4.0", "Report", 2);
            //Add(oMenuItem);
            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM2.4.1", "Doctor Commitments", 2));
            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM2.4.2", "Portfolio Budget History", 2));
            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM2.4.3", "Portfolio Details", 2));
            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM2.4.4", "Commitment Vs. Actual by MBCF", 2));
            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM2.4.5", "List of Marketing Budget Commitment", 2));
            ////oMenuItem.SubMenus.Add(new OCSWSMenu("FRM2.4.6", "Pivot Grid Test", 2)); // For Pivot Grid Testing
            //#endregion

            //#region for Portfolio Manager
            //oMenuItem = new OCSWSMenu("FRM3.2.0", "Budget Management",3);
            //Add(oMenuItem);

            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM3.2.1", "Budget Setup", 3));
            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM3.2.2", "Budget Reallocation", 3));
            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM3.2.3", "Month to Month Budget Reallocation", 3));

            //oMenuItem = new OCSWSMenu("FRM3.3.0", "Commitment", 3);
            //Add(oMenuItem);
            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM3.3.1", "Raise Commitment", 3));
            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM3.3.2", "Edit Commitment", 3));            

            //oMenuItem = new OCSWSMenu("FRM3.4.0", "Purchase", 3);
            //Add(oMenuItem);
            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM3.4.1", "Sample Purchase", 3));
            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM3.4.2", "Bulk Purchase", 3));
            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM3.4.3", "Bulk Item Allocation", 3));
            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM3.4.4", "Sample Product Allocation", 3));

            //oMenuItem = new OCSWSMenu("FRM3.5.0", "Portfolio", 3);
            //Add(oMenuItem);
            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM3.5.1", "Temporary Portfolio Assignment", 3));

            //oMenuItem = new OCSWSMenu("FRM3.6.0", "Report", 3);
            //Add(oMenuItem);
            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM3.6.1", "Doctor's Commitment", 3));
            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM3.6.2", "Portfolio Details", 3));
            //#endregion            

            //#region Marketing Service
            //oMenuItem = new OCSWSMenu("FRM4.2.0", "Commitment", 4);
            //Add(oMenuItem);
            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM4.2.1", "Approve/Reject Commitment", 4));
            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM4.2.2", "Actualize", 4));
            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM4.2.3", "Commitment Transfer", 4));

            //#endregion

            //#region Supply Chain Management
            //oMenuItem = new OCSWSMenu("FRM5.2.0", "Sample Product", 5);
            //Add(oMenuItem);
            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM5.2.1", "Sample Product List", 5));
            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM5.2.2", "Sample Product Price", 5));
            //#endregion


            //#region Data Entry Operator
            //oMenuItem = new OCSWSMenu("FRM3.1.0", "Expense", 1);
            //Add(oMenuItem);
            //oMenuItem.SubMenus.Add(new OCSWSMenu("FRM3.1.1", "Expense Entry", 1));       
            //#endregion







        }
    }
}
