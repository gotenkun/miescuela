using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
/// <summary>
/// Summary description for ProcessingStatus
/// </summary>
namespace MedikAdmin
{
    public class ProcessingStatus
    {
        private static Hashtable Status = new Hashtable();
        public ProcessingStatus()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        static public object getValue(Guid ItemId)
        {
            return Status[ItemId];
        }
        static public void add(Guid ItemId, object oStatus)
        {
            //make sure that oStatus contains only the values 0 through 100 or -1
            Status[ItemId] = oStatus;
        }
        static public void update(Guid ItemId, object oStatus)
        {
            //make sure that oStatus contains only the values 0 through 100 or -1
            Status[ItemId] = oStatus;
        }
        static public void remove(Guid ItemId)
        {
            Status.Remove(ItemId);
        }
        static public bool Contains(Guid ItemId)
        {
            return Status.Contains(ItemId);
        }
    }
}