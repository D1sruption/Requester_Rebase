using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace requester_rebase.Classes
{
    public class GameStartRequest
    {
        public Version version { get; set; }
        public string hwCode { get; set; }
    }

    public class Version
    {
        public string major { get; set; }
        public string game { get; set; }
        public string backend { get; set; }
    }

    public class GetSessionResponse
    {
        public int err { get; set; }
        public object errmsg { get; set; }
        public GetSessionResponseData data { get; set; }
    }

    public class GetSessionResponseData
    {
        public bool queued { get; set; }
        public string session { get; set; }
    }
}
