using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;
using FAST.Core;
using FAST.Core.DataAccess;

namespace FAST.BusinessLogic
{
    public partial class BLGimmickInfo
    {
        //public bool Validate(GimmickInfo oItem)
        //{
        //DLGimmickInfo oDL = new DLGimmickInfo();
        //try
        //{
        //if (oItem.IsNew)
        //{
        //return !oDL.IsDuplicate(oItem.GimmickInfoName);
        //}
        //else
        //{
        //return !oDL.IsDuplicate(oItem.GimmickInfoName, oItem.ID.ToInt32);
        //}
        //}
        //catch (Exception e)
        //{
        //throw new Exception(e.Message);
        //}
        //}
        public void Save(GimmickInfo oItem)
        {
            DLGimmickInfo oDL = new DLGimmickInfo();
            //if (!Validate(oItem))
            //{
            //throw new Exception("GimmickInfo with the same Name already exist");
            //}
            try
            {
                DAAccess.BeginTran();
                if (oItem.IsNew)
                {
                    oDL.Insert(oItem);
                }
                else
                {
                    oDL.Update(oItem);
                }
                DAAccess.CommitTran();
            }
            catch (Exception e)
            {
                DAAccess.RollBackTran();
                throw new Exception(e.Message);
            }
        }
        public void Delete(int nID)
        {
            DLGimmickInfo oDL = new DLGimmickInfo();
            try
            {
                oDL.Delete(nID);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //public bool IsDuplicate(string sGimmickInfoName)
        //{
        //try
        //{
        //DLUser oDL = new DLUser();
        //return oDL.IsDuplicate(sGimmickInfoName);
        //}
        //catch (Exception e)
        //{
        //throw new Exception(e.Message);
        //}
        //}
        //public bool IsDuplicate(string sGimmickInfoName, int nID)
        //{
        //try
        //{
        //DLUser oDL = new DLUser();
        //return oDL.IsDuplicate(sGimmickInfoName, nID);
        //}
        //catch (Exception e)
        //{
        //throw new Exception(e.Message);
        //}
    }
}
