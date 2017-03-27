using System;
using System.Data;
using System.Collections;
using FAST.BusinessObjects;
using FAST.DataLogic;

namespace FAST.BusinessLogic
{
	public partial class BLCommandInfo
	{
        private CommandInfo ReaderToObject(IDataReader oReader)
        {
            CommandInfo oItem = new CommandInfo();
            oItem.ID.SetID(oReader["CommandID"]);
            oItem.CommandID = Convert.ToInt32(oReader["CommandID"]);
            oItem.TerritoryID = oReader["TerritoryID"].ToString();
            oItem.TableName = oReader["TableName"].ToString();
            oItem.Description = oReader["Description"].ToString();
            oItem.IsExcute = Convert.ToBoolean(oReader["IsExcute"]);
            oItem.Version = Convert.ToInt32(oReader["Version"]);
            if (!oReader["EntryDateTime"].Equals(DBNull.Value))
            {
                oItem.EntryDateTime = Convert.ToDateTime(oReader["EntryDateTime"]);
            }
            if (!oReader["ExecutedDateTime"].Equals(DBNull.Value))
            {
                oItem.ExecutedDateTime = Convert.ToDateTime(oReader["ExecutedDateTime"]);
            }
            return oItem;
        }
		
		private CommandInfos ReaderToObjects(IDataReader oReader)
		{
			CommandInfos oItems;
			CommandInfo oItem;
			oItems = new CommandInfos();
			if (oReader.IsClosed) return oItems;
			while (oReader.Read())
			{
				oItem = ReaderToObject(oReader);
				oItems.Add(oItem);
			}
			oReader.Close();
			return oItems;
		}
		public CommandInfos GetCommandInfos()
		{
			CommandInfos oCommandInfos;
			DLCommandInfo oDL = new DLCommandInfo();
			try
			{
				oCommandInfos = ReaderToObjects(oDL.GetCommandInfos());
			}
			catch (Exception err)
			{
				throw new Exception(err.Message);
			}
			return oCommandInfos;
		}
		public CommandInfo GetCommandInfo(int nID)
		{
			CommandInfo oCommandInfo = new CommandInfo();
			DLCommandInfo oDL = new DLCommandInfo();
			IDataReader oReader;
			try
			{
				oReader = oDL.GetCommandInfo(nID);
				if (oReader.Read())
				{
					oCommandInfo = ReaderToObject(oReader);
				}
				oReader.Close();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
			return oCommandInfo;
		}

        public CommandInfo GetCommandInfo(DataRow oRow)
        {
            DataTable oTable = new DataTable();
            CommandInfo oItem = new CommandInfo();
            try
            {               
                oItem.ID.SetID(oRow["CommandID"]);
                oItem.CommandID = Convert.ToInt32(oRow["CommandID"]);
                oItem.TerritoryID = oRow["TerritoryID"].ToString();
                oItem.TableName = oRow["TableName"].ToString();
                oItem.Description = oRow["Description"].ToString();
                oItem.IsExcute = Convert.ToBoolean(oRow["IsExcute"]);
                oItem.Version = Convert.ToInt32(oRow["Version"]);
                if (!oRow["EntryDateTime"].Equals(DBNull.Value))
                {
                    oItem.EntryDateTime = Convert.ToDateTime(oRow["EntryDateTime"]);
                }
                if (!oRow["ExecutedDateTime"].Equals(DBNull.Value))
                {
                    oItem.ExecutedDateTime = Convert.ToDateTime(oRow["ExecutedDateTime"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public CommandInfo GetCommandInfo(int nID, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            CommandInfo oItem = new CommandInfo();
            try
            {
                oTable = GetCommand(nID, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    DataRow oRow = oTable.Rows[0];
                    oItem = GetCommandInfo(oRow);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItem;
        }

        public CommandInfos GetCommandInfos(string sTerritoryID, string sConnectionString)
        {
            DataTable oTable = new DataTable();
            CommandInfo oItem = new CommandInfo();
            CommandInfos oItems = new CommandInfos();
            try
            {
                oTable = GetCommand(sTerritoryID, sConnectionString);
                if (oTable.Rows.Count > 0)
                {
                    foreach (DataRow oRow in oTable.Rows)
                    {
                        oItem = new CommandInfo();
                        oItem = GetCommandInfo(oRow);
                        oItems.Add(oItem);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return oItems;
        }       
	}
}
