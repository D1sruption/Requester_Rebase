using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using ComponentAce.Compression.Libs.zlib;

namespace requester_rebase.Automation
{
    class Inbox
    {
        private MainForm mainForm;
        private CookieContainer Cookies = new CookieContainer();
        private JavaScriptSerializer Json = new JavaScriptSerializer();
        private Uri prod = new Uri("https://prod.escapefromtarkov.com");
        private Uri prod_01 = new Uri("https://prod-01.escapefromtarkov.com");
        private Uri prod_02 = new Uri("https://prod-02.escapefromtarkov.com");
        private Uri ragfair = new Uri("https://ragfair.escapefromtarkov.com");
        Versions versions;
        Classes.Utilities utilities;

        public Inbox(MainForm mainForm)
        {
            this.mainForm = mainForm;
            utilities = new Classes.Utilities(mainForm);
            versions = new Versions(mainForm);
        }

        public void getInboxId()
        {
            string Data = "{\"limit\":10,\"offset\":0}";
            Cookies.SetCookies(prod, "PHPSESSID=" + mainForm.txtSessionID.Text.Replace("PHPSESSID=", ""));
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://prod.escapefromtarkov.com/client/mail/dialog/list");
            Request.ContentType = "application/json";
            Request.Accept = "*/*";
            Request.CookieContainer = Cookies;
            Request.Host = "prod.escapefromtarkov.com";
            Request.Method = "POST";
            Request.UserAgent = versions.UnityPlayerVersion;
            Request.Headers.Add("X-Unity-Version", versions.XUnityVersion);
            Request.Headers.Add("App-Version", versions.AppVersion);
            Request.KeepAlive = true;

            //AddLog(Data);

            byte[] CompressedRequest = SimpleZlib.CompressToBytes(Encoding.UTF8.GetBytes(Data), 9);
            Stream RequestStream = Request.GetRequestStream();
            RequestStream.Write(CompressedRequest, 0, CompressedRequest.Length);
            RequestStream.Flush();

            Stream CompressedResponseStream = Request.GetResponse().GetResponseStream();
            byte[] CompressedResponseData = utilities.ReadToEnd(CompressedResponseStream);
            string DecompressedResponseData = SimpleZlib.Decompress(CompressedResponseData, null);

            Classes.Inbox Return = Json.Deserialize<Classes.Inbox>(DecompressedResponseData);

            //mainForm.AddLog(Json.Serialize(Return));

            if (!(Return.data is Classes.InboxData))
            {
                mainForm.AddLog("No messages in inbox!");
            }

            foreach (Classes.InboxData msg in Return.data)
            {
                if (msg.type == 4 && msg.message.systemData != null)
                {
                    string uid = msg.message.uid;
                    string buyerNickname = msg.message.systemData.buyerNickname;
                    string soldItem = msg.message.systemData.soldItem;
                    int itemCount = msg.message.systemData.itemCount;

                    mainForm.AddLog("===========INBOX DATA===========");
                    mainForm.AddLog($"UID: {uid}");
                    mainForm.AddLog($"Nickname: {buyerNickname}");
                    mainForm.AddLog($"Item Sold(ID): {soldItem}");
                    mainForm.AddLog($"Count: {itemCount.ToString()}");
                    mainForm.AddLog("================================");

                    //get attachments
                    if (uid != null || uid != "")
                    {
                        getMailboxAttachments(uid);
                    }
                }

                if (msg.message.systemData == null)
                {
                    mainForm.AddLog("systemData is NULL....skipping");
                }
            }
        }

        public void getMailboxAttachments(string dialogId)
        {
            string Data = "{\"dialogId\":\"" + dialogId + "\"}";

            Cookies.SetCookies(prod, "PHPSESSID=" + mainForm.txtSessionID.Text.Replace("PHPSESSID=", ""));
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://prod.escapefromtarkov.com/client/mail/dialog/getAllAttachments");
            Request.ContentType = "application/json";
            Request.Accept = "*/*";
            Request.CookieContainer = Cookies;
            Request.Host = "prod.escapefromtarkov.com";
            Request.Method = "POST";
            Request.UserAgent = versions.UnityPlayerVersion;
            Request.Headers.Add("X-Unity-Version", versions.XUnityVersion);
            Request.Headers.Add("App-Version", versions.AppVersion);
            Request.KeepAlive = true;

            byte[] CompressedRequest = SimpleZlib.CompressToBytes(Encoding.UTF8.GetBytes(Data), 9);
            Stream RequestStream = Request.GetRequestStream();
            RequestStream.Write(CompressedRequest, 0, CompressedRequest.Length);
            RequestStream.Flush();

            Stream CompressedResponseStream = Request.GetResponse().GetResponseStream();
            byte[] CompressedResponseData = utilities.ReadToEnd(CompressedResponseStream);
            string DecompressedResponseData = SimpleZlib.Decompress(CompressedResponseData, null);

            Classes.InboxAttachments Return = Json.Deserialize<Classes.InboxAttachments>(DecompressedResponseData);

            foreach (Classes.AttachmentMessage msg in Return.data.messages)
            {
                string buyerNickname = msg.systemData.buyerNickname;
                string soldItem = msg.systemData.soldItem;
                int itemCount = msg.systemData.itemCount;

                mainForm.AddLog("===========INBOX ATTACHMENT DATA===========");
                mainForm.AddLog($"{buyerNickname} purchased {itemCount.ToString()} of {soldItem}");

                foreach (Classes.AttachmentInfo items in msg.items.data)
                {
                    string id = items._id;
                    string tpl = items._tpl;
                    int count = items.upd.StackObjectsCount;

                    mainForm.AddLog($"Item: {id} sold for {count.ToString()}");
                    mainForm.AddLog("===========================================");

                    moveMailboxAttachmentsToInventory(id, msg._id);
                }
            }
        }

        public void moveMailboxAttachmentsToInventory(string itemId, string messageId)
        {
            Classes.InboxAttachmentMove root = new Classes.InboxAttachmentMove();

            root.data = new List<Classes.AttachmentMoveData>();
            root.data.Add(new Classes.AttachmentMoveData());
            root.tm = 2;

            root.data.First().Action = "Move";
            root.data.First().item = itemId;

            Classes.To to = new Classes.To();
            to.id = "5df78c2987ba573dcd7dc11d"; //ID for stash???
            to.container = "hideout";

            Classes.Location location = new Classes.Location();
            location.x = 0;
            location.y = 0;
            location.r = "Horizontal";

            Classes.FromOwner fromOwner = new Classes.FromOwner();
            fromOwner.id = messageId;
            fromOwner.type = "Mail";

            root.data.First().to = to;
            root.data.First().to.location = location;
            root.data.First().fromOwner = fromOwner;

            string json = Json.Serialize(root);

            mainForm.AddLog(json);

            string Data = json;

            Cookies.SetCookies(prod, "PHPSESSID=" + mainForm.txtSessionID.Text.Replace("PHPSESSID=", ""));
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://prod.escapefromtarkov.com/client/game/profile/items/moving");
            Request.ContentType = "application/json";
            Request.Accept = "*/*";
            Request.CookieContainer = Cookies;
            Request.Host = "prod.escapefromtarkov.com";
            Request.Method = "POST";
            Request.UserAgent = versions.UnityPlayerVersion;
            Request.Headers.Add("X-Unity-Version", versions.XUnityVersion);
            Request.Headers.Add("App-Version", versions.AppVersion);
            Request.KeepAlive = true;

            byte[] CompressedRequest = SimpleZlib.CompressToBytes(Encoding.UTF8.GetBytes(Data), 9);
            Stream RequestStream = Request.GetRequestStream();
            RequestStream.Write(CompressedRequest, 0, CompressedRequest.Length);
            RequestStream.Flush();

            Stream CompressedResponseStream = Request.GetResponse().GetResponseStream();
            byte[] CompressedResponseData = utilities.ReadToEnd(CompressedResponseStream);
            string DecompressedResponseData = SimpleZlib.Decompress(CompressedResponseData, null);

            mainForm.AddLog(DecompressedResponseData);

        }
    }
}
