using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace requester_rebase.Classes
{
    public class CheckLauncherVersionData
    {
        public string Version { get; set; }
        public string hash { get; set; }
        public string DownloadUri { get; set; }
    }

    public class CheckLauncherVersionRequest
    {
        public int err { get; set; }
        public object errmsg { get; set; }
        public CheckLauncherVersionData data { get; set; }
    }

    public class CheckGameVersionData
    {
        public string Version { get; set; }
        public string FromVersion { get; set; }
        public string Hash { get; set; }
        public string DownloadUri { get; set; }
        public bool FullConsistencyCheck { get; set; }
        public bool ClearCache { get; set; }
        public bool DeleteLocalIni { get; set; }
        public bool DeleteSharedIni { get; set; }
        public string TorrentUri { get; set; }
    }

    public class CheckGameVersionRequest
    {
        public int err { get; set; }
        public object errmsg { get; set; }
        public List<CheckGameVersionData> data { get; set; }
    }
}
