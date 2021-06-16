using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ComponentAce.Compression.Libs.zlib;
using System.Web.Script.Serialization;
using System.Net;
using System.IO;
using System.Threading;

namespace requester_rebase.Classes
{
    class Login
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

        public Login(MainForm mainForm)
        {
            this.mainForm = mainForm;
            utilities = new Utilities(mainForm);
            versions = new Versions(mainForm);
        }

        public bool sendLogin(string username, string password, string hwCode, string sessionID)
        {
            LoginRequest LoginRequestData = new LoginRequest();
            LoginRequestData.email = username;
            LoginRequestData.pass = password;
            LoginRequestData.hwCode = hwCode;
            LoginRequestData.captcha = "true";

            string Data = Json.Serialize(LoginRequestData);
            Cookies.SetCookies(prod, "PHPSESSID=" + sessionID);
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://launcher.escapefromtarkov.com/launcher/login"); //launcher/login
            Request.ContentType = "application/json";
            Request.Accept = "*/*";
            Request.CookieContainer = Cookies;
            Request.Host = "prod.escapefromtarkov.com";
            Request.Method = "POST";
            Request.UserAgent = $"BSG Launcher {versions.LauncherVersion}";
            Request.KeepAlive = true;

            byte[] CompressedRequest = SimpleZlib.CompressToBytes(Encoding.UTF8.GetBytes(Data), 9);
            Stream RequestStream = Request.GetRequestStream();
            RequestStream.Write(CompressedRequest, 0, CompressedRequest.Length);
            RequestStream.Flush();

            Stream CompressedResponseStream = Request.GetResponse().GetResponseStream();
            byte[] CompressedResponseData = utilities.ReadToEnd(CompressedResponseStream);
            string DecompressedResponseData = SimpleZlib.Decompress(CompressedResponseData, null);

            //AddLog(DecompressedResponseData);
            TokenResponse Return = Json.Deserialize<TokenResponse>(DecompressedResponseData);

            if (Return.err == 0)
            {
                mainForm.AddLog("Logged in successfully...getting session_token");
                mainForm.txtAccessToken.Text = Return.data.access_token;

                getSessionToken(Return.data.access_token);
                if(getSessionToken(Return.data.access_token))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                mainForm.AddLog("===============LOGIN OPERATION FAILED===============");
                mainForm.AddLog(DecompressedResponseData);
                mainForm.AddLog("====================================================");

                return false;
            }

        }

        public bool getSessionToken(string access_token)
        {
            GameStartRequest GameStartRequestData = new GameStartRequest();
            GameStartRequestData.version = new Version();

            GameStartRequestData.hwCode = mainForm.txtHWID.Text;
            GameStartRequestData.version.major = versions.GameVersion;
            GameStartRequestData.version.game = "live";
            GameStartRequestData.version.backend = "6";

            string Data = Json.Serialize(GameStartRequestData);
            Cookies.SetCookies(prod, "PHPSESSID=" + mainForm.txtSessionID.Text.Replace("PHPSESSID=", ""));
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://prod.escapefromtarkov.com/launcher/game/start");
            Request.ContentType = "application/json";
            Request.Accept = "*/*";
            Request.CookieContainer = Cookies;
            Request.Host = "prod.escapefromtarkov.com";
            Request.Method = "POST";
            Request.UserAgent = $"BSG Launcher {versions.LauncherVersion}";
            Request.PreAuthenticate = true;
            Request.Headers.Add("Authorization", access_token);
            Request.KeepAlive = true;

            byte[] CompressedRequest = SimpleZlib.CompressToBytes(Encoding.UTF8.GetBytes(Data), 9);
            Stream RequestStream = Request.GetRequestStream();
            RequestStream.Write(CompressedRequest, 0, CompressedRequest.Length);
            RequestStream.Flush();

            Stream CompressedResponseStream = Request.GetResponse().GetResponseStream();
            byte[] CompressedResponseData = utilities.ReadToEnd(CompressedResponseStream);
            string DecompressedResponseData = SimpleZlib.Decompress(CompressedResponseData, null);
            GetSessionResponse Return = Json.Deserialize<GetSessionResponse>(DecompressedResponseData);

            if (Return.err == 0)
            {
                //successful
                mainForm.AddLog("Token grabbed successfully...selecting profile");
                mainForm.txtSessionToken.Text = Return.data.session;
                mainForm.txtSessionID.Text = Return.data.session;
                System.Windows.Forms.Clipboard.SetText(Return.data.session);

                //select profile
                //Thread.Sleep(1000);
                if(selectProfile())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                mainForm.AddLog("===============SESSION TOKEN OPERATION FAILED===============");
                mainForm.AddLog(DecompressedResponseData);
                mainForm.AddLog("============================================================");

                return false;
            }


        }

        public bool selectProfile()
        {
            string uid = "5df78c2987ba573dcd7dc077"; //@TODO : possibly pass this as an arg??
            string data = "{\"uid\":\"" + uid + "\"}"; //NotAssassinNite
            Cookies.SetCookies(prod, "PHPSESSID=" + mainForm.txtSessionID.Text.Replace("PHPSESSID=", ""));
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://prod.escapefromtarkov.com/client/game/profile/select"); //client/game/profile/select
            Request.ContentType = "application/json";
            Request.Accept = "*/*";
            Request.CookieContainer = Cookies;
            Request.Host = "prod.escapefromtarkov.com";
            Request.Method = "POST";
            Request.UserAgent = versions.UnityPlayerVersion;
            Request.Headers.Add("X-Unity-Version", versions.XUnityVersion);
            Request.Headers.Add("App-Version", versions.AppVersion);
            Request.KeepAlive = true;

            byte[] CompressedRequest = SimpleZlib.CompressToBytes(Encoding.UTF8.GetBytes(data), 9);
            Stream RequestStream = Request.GetRequestStream();
            RequestStream.Write(CompressedRequest, 0, CompressedRequest.Length);
            RequestStream.Flush();

            Stream CompressedResponseStream = Request.GetResponse().GetResponseStream();
            byte[] CompressedResponseData = utilities.ReadToEnd(CompressedResponseStream);
            string DecompressedResponseData = SimpleZlib.Decompress(CompressedResponseData, null);
            selectProfileResponse Return = Json.Deserialize<selectProfileResponse>(DecompressedResponseData);

            if (Return.err == 0)
            {
                mainForm.AddLog($"Profile ID: {uid} selected successfully");

                return true;
            }
            else
            {
                mainForm.AddLog("===============SELECT PROFILE OPERATION FAILED===============");
                mainForm.AddLog(DecompressedResponseData);
                mainForm.AddLog("=============================================================");

                return false;
            }

        }
    }
}
