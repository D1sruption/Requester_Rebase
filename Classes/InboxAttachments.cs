using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace requester_rebase.Classes
{
    public class AttachmentInfo
    {
        public string _id { get; set; }
        public string _tpl { get; set; }
        public Upd upd { get; set; }
        public string parentId { get; set; }
        public string slotId { get; set; }
    }

    public class AttachmentItems
    {
        public string stash { get; set; }
        public List<AttachmentInfo> data { get; set; }
    }

    public class AttachmentMessage
    {
        public string _id { get; set; }
        public string uid { get; set; }
        public int type { get; set; }
        public double dt { get; set; }
        public string templateId { get; set; }
        public SystemData systemData { get; set; }
        public AttachmentItems items { get; set; }
        public int maxStorageTime { get; set; }
        public bool hasRewards { get; set; }
    }

    public class AttachmentMessages
    {
        public List<AttachmentMessage> messages { get; set; }
        public List<object> profiles { get; set; }
    }

    public class InboxAttachments
    {
        public int err { get; set; }
        public object errmsg { get; set; }
        public AttachmentMessages data { get; set; }
    }
}
