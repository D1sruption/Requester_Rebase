using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;
using ComponentAce.Compression.Libs.zlib;

namespace requester_rebase.Classes
{
    class CheckVersion
    {
        private MainForm mainForm;
        private CookieContainer Cookies = new CookieContainer();
        private JavaScriptSerializer Json = new JavaScriptSerializer();
        private Uri prod = new Uri("https://prod.escapefromtarkov.com");
        private Uri prod_01 = new Uri("https://prod-01.escapefromtarkov.com");
        private Uri prod_02 = new Uri("https://prod-02.escapefromtarkov.com");
        private Uri ragfair = new Uri("https://ragfair.escapefromtarkov.com");
        Versions versions;
        Utilities utilities;

        public string LauncherVersion;
        public string GameVersion;

        public CheckVersion(MainForm mainForm)
        {
            this.mainForm = mainForm;
            utilities = new Classes.Utilities(mainForm);
            versions = new Versions(mainForm);
        }

        public string checkLauncherVersion()
        {
            string data = ""; //EMPTY
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://launcher.escapefromtarkov.com/launcher/GetLauncherDistrib");
            Request.ContentType = "application/json";
            Request.Accept = "*/*";
            Request.Host = "launcher.escapefromtarkov.com";
            Request.Method = "POST";
            Request.UserAgent = $"BSG Launcher {versions.LauncherVersion}";

            byte[] CompressedRequest = SimpleZlib.CompressToBytes(Encoding.UTF8.GetBytes(data), 9);
            Stream RequestStream = Request.GetRequestStream();
            RequestStream.Write(CompressedRequest, 0, CompressedRequest.Length);
            RequestStream.Flush();

            Stream CompressedResponseStream = Request.GetResponse().GetResponseStream();
            byte[] CompressedResponseData = utilities.ReadToEnd(CompressedResponseStream);
            string DecompressedResponseData = SimpleZlib.Decompress(CompressedResponseData, null);
            CheckLauncherVersionRequest Return = Json.Deserialize<CheckLauncherVersionRequest>(DecompressedResponseData);

            if(Return.data.Version != versions.LauncherVersion)
            {
                //mainForm.AddLog("Launcher Version Does not match! Disabling until updated....");
                versions.LauncherVersion = Return.data.Version;

                return Return.data.Version;
            }

            return Return.data.Version;
        }

        public string checkGameVersion()
        {
            string data = ""; //EMPTY
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://launcher.escapefromtarkov.com/launcher/GetPatchList");
            Request.ContentType = "application/json";
            Request.Accept = "*/*";
            Request.Host = "launcher.escapefromtarkov.com";
            Request.Method = "POST";
            Request.UserAgent = $"BSG Launcher {versions.LauncherVersion}";

            byte[] CompressedRequest = SimpleZlib.CompressToBytes(Encoding.UTF8.GetBytes(data), 9);
            Stream RequestStream = Request.GetRequestStream();
            RequestStream.Write(CompressedRequest, 0, CompressedRequest.Length);
            RequestStream.Flush();

            Stream CompressedResponseStream = Request.GetResponse().GetResponseStream();
            byte[] CompressedResponseData = utilities.ReadToEnd(CompressedResponseStream);
            string DecompressedResponseData = SimpleZlib.Decompress(CompressedResponseData, null);
            var Return = Json.Deserialize<CheckGameVersionRequest>(DecompressedResponseData);

            if (Return.data.First().Version != versions.GameVersion)
            {
                //mainForm.AddLog("Game Version Does not match! Disabling until updated....");
                versions.LauncherVersion = Return.data.First().Version;

                return Return.data.First().Version;
            }

            return Return.data.First().Version;
        }
    }
}
