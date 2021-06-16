using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace requester_rebase.Classes
{
    public class SystemData
    {
        public string buyerNickname { get; set; }
        public string soldItem { get; set; }
        public int itemCount { get; set; }
    }

    public class Message
    {
        public int dt { get; set; }
        public int type { get; set; }
        public string text { get; set; }
        public string uid { get; set; }
        public string templateId { get; set; }
        public SystemData systemData { get; set; }
    }

    public class InboxData
    {
        public int type { get; set; }
        public Message message { get; set; }
        public int attachmentsNew { get; set; }
        public int @new { get; set; }
        public string _id { get; set; }
        public bool pinned { get; set; }
    }

    public class Inbox
    {
        public int err { get; set; }
        public object errmsg { get; set; }
        public List<InboxData> data { get; set; }
    }
}
