using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace requester_rebase.Classes
{
    public class Location
    {
        public int x { get; set; }
        public int y { get; set; }
        public string r { get; set; }
        public bool isSearched { get; set; }
    }

    public class To
    {
        public string id { get; set; }
        public string container { get; set; }
        public Location location { get; set; }
    }

    public class FromOwner
    {
        public string id { get; set; }
        public string type { get; set; }
    }

    public class AttachmentMoveData
    {
        public string Action { get; set; }
        public string item { get; set; }
        public To to { get; set; }
        public FromOwner fromOwner { get; set; }
    }

    public class InboxAttachmentMove
    {
        public List<AttachmentMoveData> data { get; set; }
        public int tm { get; set; }
    }
}
