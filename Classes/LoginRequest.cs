using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace requester_rebase.Classes
{
    class LoginRequest
    {
        public string email { get; set; }
        public string pass { get; set; }
        public string hwCode { get; set; }
        public object captcha { get; set; }
    }

    public class TokenResponse
    {
        public int err;
        public object errmsg;
        public TokenResponseData data;
    }

    public class TokenResponseData
    {
        public string aid;
        public string lang;
        public string region;
        public string gameVersion;
        public List<object> dataCenters;
        public string ipRegion;
        public string token_type;
        public int expires_in;
        public string access_token;
        public string refresh_token;
    }

    public class TarkovResponseRoot
    {
        public int err { get; set; }
        public object errmsg { get; set; }
        public object data { get; set; }
    }

    public class selectProfileResponse
    {
        public int err { get; set; }
        public object errmsg { get; set; }
        public selectProfileResponseData data { get; set; }
    }

    public class Notifier
    {
        public string server { get; set; }
        public string channel_id { get; set; }
        public string url { get; set; }
    }

    public class selectProfileResponseData
    {
        public string status { get; set; }
        public Notifier notifier { get; set; }
        public string notifierServer { get; set; }
    }
}
