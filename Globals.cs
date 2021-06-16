using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace requester_rebase
{
    public class Versions
    {
        private MainForm mainForm;
        private string gameversion = "0.12.3.5834"; //5834
        private string launcherversion = "0.9.3.1023"; //1023
        private string header_xunityversion = "2018.4.13f1";
        private string useragent_unityplayerversion = "UnityPlayer/2018.4.13f1 (UnityWebRequest/1.0, libcurl/7.52.0-DEV)";
        private string header_appversion = "EFT Client 0.12.3.5834";

        public Versions(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }

        public string GameVersion
        {
            get { return gameversion; }

            set { gameversion = value; }
        }

        public string LauncherVersion
        {
            get { return launcherversion; }

            set { launcherversion = value; }
        }

        public string XUnityVersion
        {
            get { return header_xunityversion; }

            set { header_xunityversion = value; }
        }

        public string UnityPlayerVersion
        {
            get { return useragent_unityplayerversion; }

            set { useragent_unityplayerversion = value; }
        }

        public string AppVersion
        {
            get { return header_appversion; }

            set { header_appversion = value; }
        }
    }
}
