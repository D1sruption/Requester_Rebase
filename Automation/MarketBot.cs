using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;
using ComponentAce.Compression.Libs.zlib;
using System.Threading;

namespace requester_rebase.Automation
{
    class MarketBot
    {
        //IMPORTANT TEMPLATE IDs:
        //5c12688486f77426843c7d32 = Paracord
        //57347ca924597744596b4e71 = Graphics Card
        //5a1eaa87fcdbcb001865f75e = Reap-IR thermal
        //initialize them here:

        public static string paracordId = "5c12688486f77426843c7d32";
        public static string gfxcardId = "57347ca924597744596b4e71";
        public static string thermalscopeId = "5a1eaa87fcdbcb001865f75e";

        private MainForm mainForm;
        private CookieContainer Cookies = new CookieContainer();
        private JavaScriptSerializer Json = new JavaScriptSerializer();
        private Uri prod = new Uri("http://prod.escapefromtarkov.com");
        private Uri prod_02 = new Uri("http://prod-02.escapefromtarkov.com");
        private Uri ragfair = new Uri("https://ragfair.escapefromtarkov.com");
        Versions versions;
        Classes.Utilities utilities;

        public string itemId = "";
        public List<string> cardsList = new List<string>();
        public int marketMin = 0;
        public int marketAvg = 0;
        public int marketMax = 0;
        public int marketFirst10Avg = 0;
        public string BestOfferID = "";
        public int BestOfferCost = 0;
        public int totalMoneyInInventory = 0;
        public int numberPurchased = 0;
        public int MoneyStacksInInventory = 0;
        public List<string> roublesIDList = new List<string>();
        public List<int> roublesCountList = new List<int>();


        public MarketBot(MainForm mainForm)
        {
            this.mainForm = mainForm;
            utilities = new Classes.Utilities(mainForm);
            versions = new Versions(mainForm);
        }

        public void QueryInventory()
        {
            string Data = "";
            Cookies.SetCookies(prod, "PHPSESSID=" + mainForm.txtSessionID.Text.Replace("PHPSESSID=", ""));
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://prod.escapefromtarkov.com/client/game/profile/list");
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

            Classes.Market Return = Json.Deserialize<Classes.Market>(DecompressedResponseData);

            int labsCardCount = 0;

            foreach (Classes.ProfileInfo CurrentProfile in Return.data)
            {
                //mainForm.AddLog("Profile ID: " + CurrentProfile._id);
                foreach (Classes.Item CurrentItem in CurrentProfile.Inventory.items)
                {
                    if (CurrentItem._tpl == "5c94bbff86f7747ee735c08f") //template id of labs key card
                    {
                        itemId = CurrentItem._id;
                        labsCardCount++;
                        cardsList.Add(CurrentItem._id);

                        //mainForm.AddLog("Total Labs Cards In Inventory: " + labsCardCount);
                    }
                    //@HERE TO ADD ITEMS
                    /*
                    else if (CurrentItem._tpl == "5c0530ee86f774697952d952")
                    {
                        AddLog("=========================================");
                        AddLog("User has LedX with item id: " + CurrentItem._id + " At Location: " + CurrentItem.slotId);
                        AddLog("=========================================");
                        ledxCount++;

                        AddLog("Total Ledx In Inventory: " + ledxCount);
                    }
                    */
                    //@END
                }
            }

            mainForm.AddLog("=========================================");
            mainForm.AddLog($"User has {labsCardCount.ToString()} total labs cards in inventory");
            mainForm.AddLog("=========================================");
        }

        public void getMarketPrices(string templateId)
        {
            templateId = "5c94bbff86f7747ee735c08f"; //labs card template id

            string Data = "{\"templateId\":\"" + templateId + "\"}";
            Cookies.SetCookies(ragfair, "PHPSESSID=" + mainForm.txtSessionID.Text.Replace("PHPSESSID=", ""));
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://ragfair.escapefromtarkov.com/client/ragfair/itemMarketPrice");
            Request.ContentType = "application/json";
            Request.Accept = "*/*";
            Request.CookieContainer = Cookies;
            Request.Host = "ragfair.escapefromtarkov.com";
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

            Classes.GetMarketPricesResponse Return = Json.Deserialize<Classes.GetMarketPricesResponse>(DecompressedResponseData);

            mainForm.AddLog("=====================================");
            //mainForm.AddLog(Json.Serialize(Return));
            mainForm.AddLog($"Minimum: {Return.data.min} | Average: {Math.Round(Return.data.avg)} | Maximum: {Return.data.max}");
            mainForm.AddLog("=====================================");

            marketMin = Return.data.min;
            marketAvg = (int)Math.Round(Return.data.avg);
            marketMax = Return.data.max;
        }

        public bool QueryMarket(string templateId)
        {
            //{ "page":0,"limit":15,"sortType":5,"sortDirection":0,"currency":0,"priceFrom":0,"priceTo":0,"quantityFrom":0,"quantityTo":0,"conditionFrom":0,"conditionTo":100,"oneHourExpiration":false,"removeBartering":true,"offerOwnerType":0,"onlyFunctional":true,"updateOfferCount":true,"handbookId":"5c94bbff86f7747ee735c08f","linkedSearchId":"","neededSearchId":"","buildItems":{ },"buildCount":0,"tm":1}
            string data = "{\"page\":0,\"limit\":5,\"sortType\":5,\"sortDirection\":0,\"currency\":0,\"priceFrom\":0,\"priceTo\":0,\"quantityFrom\":0,\"quantityTo\":0,\"conditionFrom\":0,\"conditionTo\":100,\"oneHourExpiration\":false,\"removeBartering\":true,\"offerOwnerType\":0,\"onlyFunctional\":true,\"updateOfferCount\":true,\"handbookId\":\"" + templateId + "\",\"linkedSearchId\":\"\",\"neededSearchId\":\"\",\"buildItems\":{ },\"buildCount\":0,\"tm\":1}";
            string URL = "https://ragfair.escapefromtarkov.com/client/ragfair/find";

            Cookies.SetCookies(ragfair, "PHPSESSID=" + mainForm.txtSessionID.Text.Replace("PHPSESSID=", ""));
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(URL);
            Request.ContentType = "application/json";
            Request.Accept = "*/*";
            Request.CookieContainer = Cookies;
            Request.Host = "ragfair.escapefromtarkov.com";
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

            var Return = Json.Deserialize<Classes.RagfairOffersResponse>(DecompressedResponseData);

            int LowestCost = 1000000000;
            Classes.Offer BestOffer = new Classes.Offer();

            foreach (Classes.Offer CurrentOffer in Return.data.offers)
            {
                bool RubleOffer = false;
                int Costs = CurrentOffer.requirementsCost;
                string id = CurrentOffer._id;

                foreach (Classes.Requirement CurrentRequirement in CurrentOffer.requirements)
                {
                    if (CurrentRequirement._tpl == "5449016a4bdc2d6f028b456f")
                    {
                        RubleOffer = true;
                    }
                }

                if (RubleOffer == false)
                {
                    continue;
                }

                if (Costs < LowestCost)
                {
                    LowestCost = Costs;
                    BestOffer = CurrentOffer;
                }
            }

            BestOfferID = BestOffer._id;
            BestOfferCost = LowestCost;

            string MoneyID = GetMoneyStackID(BestOfferCost);
            string item = "";
            int itemLowestPrice = 0;

            if(templateId == "57347ca924597744596b4e71")
            {
                item = "Graphics Card";
                itemLowestPrice = getAvgOfFirst10OnMarket(templateId) - 40000;
            }
            else if(templateId == "5c12688486f77426843c7d32")
            {
                item = "Paracord";
                itemLowestPrice = getAvgOfFirst10OnMarket(templateId) - 40000;
            }
            else if(templateId == "59faff1d86f7746c51718c9c")
            {
                item = "Bitcoin";
                itemLowestPrice = getAvgOfFirst10OnMarket(templateId) - 40000;
            }
            else if(templateId == "5a1eaa87fcdbcb001865f75e")
            {
                item = "Reap-IR Thermal Scope";
                itemLowestPrice = getAvgOfFirst10OnMarket(templateId) - 40000;
            }


            while (true)
            {
                if (LowestCost > itemLowestPrice) //lowestCost > 150000 | //tax on 1 gfxcard is 21k
                {
                    //mainForm.AddLog($"No Suitable {item} Item! Skipping! Lowest Item Cost: {LowestCost.ToString()}");
                    return false;
                }

                if (totalMoneyInInventory < BestOfferCost)
                {
                    mainForm.AddLog("Buy failed due to not enough money in player inventory");
                    return false;
                }

                //this is where it actually buys the keycard
                int Result = BuyItem(MoneyID, templateId);
                if (Result == 0) //purchase successful
                {
                    numberPurchased++;

                    mainForm.statusNumPurchased.Text = "Number Purchased: " + numberPurchased.ToString();
                    mainForm.statusAverageCost.Text = "Average Cost: ##";

                    mainForm.AddLog("====================================");
                    mainForm.AddLog("Purchase Price: " + LowestCost.ToString());
                    mainForm.AddLog("Purchase Count: " + numberPurchased.ToString());
                    mainForm.AddLog("====================================");
                    System.Media.SystemSounds.Exclamation.Play();
                    return true;
                }
                else if (Result == 1)
                {
                    //mainForm.AddLog($"Buy failed with 1503: Offer not found! Cost was {LowestCost}");
                    return false;
                }
                else if (Result == 2)
                {
                    //mainForm.AddLog("Buy failed with 1512!");
                    return false;
                }
                else if (Result == 3)
                {
                    //mainForm.AddLog("Buy failed with 1510: Bad Loyalty level!");
                    return false;
                }
                else if (Result == 4)
                {
                    //mainForm.AddLog("Buy failed with Result 4!");
                    return false;
                }
                else
                    return false;
            }
        }

        public string GetMoneyStackID(int RequiredAmount)
        {
            string Data = "";
            Cookies.SetCookies(prod, "PHPSESSID=" + mainForm.txtSessionID.Text.Replace("PHPSESSID=", ""));
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://prod.escapefromtarkov.com/client/game/profile/list");
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

            Classes.ProfileResponse Return = Json.Deserialize<Classes.ProfileResponse>(DecompressedResponseData);

            foreach (Classes.ProfileInfo CurrentProfile in Return.data)
            {
                foreach (Classes.Item CurrentItem in CurrentProfile.Inventory.items)
                {
                    if (CurrentItem._tpl == "5449016a4bdc2d6f028b456f" && CurrentItem.upd.StackObjectsCount >= RequiredAmount)
                    {
                        return CurrentItem._id;
                    }
                }
            }

            return string.Empty;
        }

        public int BuyItem(string MoneyID, string itemID)
        {
            //{ "data":[{"Action":"RagFairBuyOffer","offers":[{"id":"5e3d99471b6cb0400d76bf2bb","count":1,"items":[{"id":"5e28bddccaba737f866d1d3c","count":168888}]}]}],"tm":2}
            string data = "{\"data\":[{\"Action\":\"RagFairBuyOffer\",\"offers\":[{\"id\":\"" + BestOfferID + "\",\"count\":1,\"items\":[{\"id\":\"" + MoneyID + "\",\"count\":" + BestOfferCost.ToString() + "}]}]}],\"tm\":2}";
            string URL = "https://prod.escapefromtarkov.com/client/game/profile/items/moving";

            Cookies.SetCookies(prod, "PHPSESSID=" + mainForm.txtSessionID.Text.Replace("PHPSESSID=", ""));
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(URL);
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

            Classes.TarkovResponseRoot Return = Json.Deserialize<Classes.TarkovResponseRoot>(DecompressedResponseData);

            string returnErrorCode = DecompressedResponseData.ToString();

            if (Return.err == 0 && returnErrorCode.Contains("slotId"))
                return 0;
            else if (returnErrorCode.Contains("1503"))
                return 1;
            else if (returnErrorCode.Contains("1512"))
                return 2;
            else if (returnErrorCode.Contains("1510"))
                return 3;

            return 4;
        }

        public void getRoubles()
        {
            string Data = "";
            Cookies.SetCookies(prod, "PHPSESSID=" + mainForm.txtSessionID.Text.Replace("PHPSESSID=", ""));
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://prod.escapefromtarkov.com/client/game/profile/list");
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

            Classes.ProfileResponse Return = Json.Deserialize<Classes.ProfileResponse>(DecompressedResponseData);

            int totalMoneyStacks = 0;

            Dictionary<Classes.Item, Classes.MergedItem> RoubleList = new Dictionary<Classes.Item, Classes.MergedItem>();
            // The Item & IsMerged
            foreach (Classes.ProfileInfo CurrentProfile in Return.data)
            {
                foreach (Classes.Item CurrentItem in CurrentProfile.Inventory.items)
                {
                    if (CurrentItem._tpl == "5449016a4bdc2d6f028b456f" && CurrentItem.upd.StackObjectsCount != 500000)
                    {
                        roublesIDList.Add(CurrentItem._id);
                        roublesCountList.Add(CurrentItem.upd.StackObjectsCount);
                        totalMoneyInInventory += CurrentItem.upd.StackObjectsCount;
                        totalMoneyStacks++;
                        Classes.MergedItem MergedItem = new Classes.MergedItem(false);
                        RoubleList.Add(CurrentItem, MergedItem);
                    }
                    else if (CurrentItem._tpl == "5449016a4bdc2d6f028b456f" && CurrentItem.upd.StackObjectsCount == 500000)
                    {
                        totalMoneyStacks++;
                        totalMoneyInInventory += CurrentItem.upd.StackObjectsCount;
                    }
                }
            }

            /*
            AddLog("=========================================");
            AddLog("User has: " + totalMoneyInInventory.ToString() + " Roubles in their stash");
            AddLog("User has: " + totalMoneyStacks.ToString() + " total stacks of roubles in their stash");
            AddLog("=========================================");
            */
            mainForm.lblTotalMoneyInInventory.Text = "Total Money In Inventory:     " + totalMoneyInInventory.ToString();
            mainForm.lblTotalStacksInInventory.Text = "Total Stacks In Inventory:     " + totalMoneyStacks.ToString();

            foreach (KeyValuePair<Classes.Item, Classes.MergedItem> CurrentParent in RoubleList)
            {
                if (!CurrentParent.Value.IsMerged)
                    foreach (KeyValuePair<Classes.Item, Classes.MergedItem> CurrentChild in RoubleList)
                    {
                        if (CurrentParent.Key != CurrentChild.Key && !CurrentChild.Value.IsMerged && CurrentParent.Key.upd.StackObjectsCount + CurrentChild.Key.upd.StackObjectsCount <= 999999) //Was 999998
                        {
                            //MergeItems(CurrentParent, CurrentChild);
                            mainForm.AddLog("Merged Items of " + CurrentParent.Key.upd.StackObjectsCount.ToString() + " and " + CurrentChild.Key.upd.StackObjectsCount.ToString());
                            CurrentParent.Value.IsMerged = true;
                            CurrentChild.Value.IsMerged = true;
                            MergeRoubles(CurrentParent.Key._id, CurrentChild.Key._id);
                            break;
                        }
                    }
            }
        }

        public void MergeRoubles(string item1, string item2)
        {

            string Data = "{\"data\":[{\"Action\":\"Merge\",\"item\":\"" + item1 + "\",\"with\":\"" + item2 + "\"}],\"tm\":2}";
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

            //AddLog(Data);

            byte[] CompressedRequest = SimpleZlib.CompressToBytes(Encoding.UTF8.GetBytes(Data), 9);
            Stream RequestStream = Request.GetRequestStream();
            RequestStream.Write(CompressedRequest, 0, CompressedRequest.Length);
            RequestStream.Flush();

            Stream CompressedResponseStream = Request.GetResponse().GetResponseStream();
            byte[] CompressedResponseData = utilities.ReadToEnd(CompressedResponseStream);
            string DecompressedResponseData = SimpleZlib.Decompress(CompressedResponseData, null);

            mainForm.AddLog(DecompressedResponseData);
        }

        public int getTotalMoneyInInventory()
        {
            //@TODO : Can combine this with other functions that call /profile/list

            totalMoneyInInventory = 0; //reset value so it doesnt double on each call

            string Data = "";
            Cookies.SetCookies(prod, "PHPSESSID=" + mainForm.txtSessionID.Text.Replace("PHPSESSID=", ""));
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://prod.escapefromtarkov.com/client/game/profile/list");
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

            Classes.ProfileResponse Return = Json.Deserialize<Classes.ProfileResponse>(DecompressedResponseData);

            int numStacks = 0;

            foreach (Classes.ProfileInfo CurrentProfile in Return.data)
            {
                foreach (Classes.Item CurrentItem in CurrentProfile.Inventory.items)
                {
                    if (CurrentItem._tpl == "5449016a4bdc2d6f028b456f")
                    {
                        totalMoneyInInventory += CurrentItem.upd.StackObjectsCount;
                        numStacks++;
                        MoneyStacksInInventory = numStacks;
                    }
                }
            }

            mainForm.AddLog("=========================================");
            mainForm.AddLog("User has: " + totalMoneyInInventory.ToString() + " Roubles in their stash in " + numStacks.ToString() + " Stacks");
            mainForm.AddLog("=========================================");

            return totalMoneyInInventory;
        }
        public void ListLabsCardsOnRagFair()
        {
            Classes.RagFairAddOfferRequest NewRequest = new Classes.RagFairAddOfferRequest();

            NewRequest.data = new List<Classes.RagFairAddOfferData>();
            NewRequest.data.Add(new Classes.RagFairAddOfferData());

            NewRequest.tm = 2;
            NewRequest.data.First().Action = "RagFairAddOffer";
            NewRequest.data.First().sellInOnePiece = false;

            Classes.RagFairAddOfferRequirement NewRequirement = new Classes.RagFairAddOfferRequirement();
            NewRequirement._tpl = "5449016a4bdc2d6f028b456f";
            //tax on 155000 is 6802
            //tax on 16000 is 7016
            NewRequirement.count = 155000; //price to sell for
            NewRequirement.level = 0;
            NewRequirement.side = 0;
            NewRequirement.onlyFunctional = false;

            NewRequest.data.First().requirements = new List<Classes.RagFairAddOfferRequirement>();
            NewRequest.data.First().requirements.Add(NewRequirement);

            NewRequest.data.First().items = new List<string>();
            foreach (string item in cardsList)
            {
                NewRequest.data.First().items.Add(item);
            }

            string json = Json.Serialize(NewRequest);
            //mainForm.AddLog("JSON:" + json);

            string URL = "https://prod.escapefromtarkov.com/client/game/profile/items/moving";

            Cookies.SetCookies(prod, "PHPSESSID=" + mainForm.txtSessionID.Text.Replace("PHPSESSID=", ""));
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(URL);
            Request.ContentType = "application/json";
            Request.Accept = "*/*";
            Request.CookieContainer = Cookies;
            Request.Host = "prod.escapefromtarkov.com";
            Request.Method = "POST";
            Request.UserAgent = versions.UnityPlayerVersion;
            Request.Headers.Add("X-Unity-Version", versions.XUnityVersion);
            Request.Headers.Add("App-Version", versions.AppVersion);
            Request.KeepAlive = true;

            byte[] CompressedRequest = SimpleZlib.CompressToBytes(Encoding.UTF8.GetBytes(json), 9);
            Stream RequestStream = Request.GetRequestStream();
            RequestStream.Write(CompressedRequest, 0, CompressedRequest.Length);
            RequestStream.Flush();

            Stream CompressedResponseStream = Request.GetResponse().GetResponseStream();
            byte[] CompressedResponseData = utilities.ReadToEnd(CompressedResponseStream);
            string DecompressedResponseData = SimpleZlib.Decompress(CompressedResponseData, null);

            try
            {
                Classes.ProfileResponse Return = Json.Deserialize<Classes.ProfileResponse>(DecompressedResponseData);

                mainForm.AddLog(DecompressedResponseData);

                cardsList.Clear();
            }
            catch
            {
                mainForm.AddLog("Received 1501 error! Sleeping for 60 seconds!");
                Thread.Sleep(60000);
            }

        }

        private int getAvgOfFirst10OnMarket(string templateId)
        {
            //{ "page":0,"limit":15,"sortType":5,"sortDirection":0,"currency":0,"priceFrom":0,"priceTo":0,"quantityFrom":0,"quantityTo":0,"conditionFrom":0,"conditionTo":100,"oneHourExpiration":false,"removeBartering":true,"offerOwnerType":0,"onlyFunctional":true,"updateOfferCount":true,"handbookId":"5c94bbff86f7747ee735c08f","linkedSearchId":"","neededSearchId":"","buildItems":{ },"buildCount":0,"tm":1}
            string data = "{\"page\":0,\"limit\":10,\"sortType\":5,\"sortDirection\":0,\"currency\":0,\"priceFrom\":0,\"priceTo\":0,\"quantityFrom\":0,\"quantityTo\":0,\"conditionFrom\":0,\"conditionTo\":100,\"oneHourExpiration\":false,\"removeBartering\":true,\"offerOwnerType\":0,\"onlyFunctional\":true,\"updateOfferCount\":true,\"handbookId\":\"" + templateId + "\",\"linkedSearchId\":\"\",\"neededSearchId\":\"\",\"buildItems\":{ },\"buildCount\":0,\"tm\":1}";
            string URL = "https://ragfair.escapefromtarkov.com/client/ragfair/find";

            Cookies.SetCookies(ragfair, "PHPSESSID=" + mainForm.txtSessionID.Text.Replace("PHPSESSID=", ""));
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(URL);
            Request.ContentType = "application/json";
            Request.Accept = "*/*";
            Request.CookieContainer = Cookies;
            Request.Host = "ragfair.escapefromtarkov.com";
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

            var Return = Json.Deserialize<Classes.RagfairOffersResponse>(DecompressedResponseData);

            int Costs;
            string id;
            int FinalAverage = 0;
            int CostsSum = 0;
            int IndexCount = 0;

            foreach (Classes.Offer CurrentOffer in Return.data.offers)
            {

                Costs = CurrentOffer.requirementsCost;
                id = CurrentOffer._id;

                //PurchaseLog.Items.Add(Costs);

                CostsSum += Costs;
                IndexCount++;
            }

            FinalAverage = CostsSum / IndexCount;
            marketFirst10Avg = FinalAverage;

            return marketFirst10Avg;
            //mainForm.AddLog("=====================================");
            //mainForm.AddLog($"Total Cost: {CostsSum} | Indicies: {IndexCount} | Avg: {FinalAverage}");
            //mainForm.AddLog("=====================================");
        }

        public void calculateTax(int cost, int qty)
        {
            //VO × Ti × 4PO + VR × Tr × 4PR × Q
            //VO is the total value of the offer, calculated by multiplying the base price of the item times the amount.
            //VR is the total value of the requirements, calculated by adding the product of each requirement base price by their amount.
            //PO is a modifier calculated as log10(VO / VR).
            //    If VO is less than VR then PO is also raised to the power of 1.08.
            //PR is a modifier calculated as log10(VR / VO).
            //If VO is greater or equal to VR then PR is also raised to the power of 1.08.
            //Q is the "quantity" factor which is either 1 when "Require for all items in offer" is checked or the amount of items being offered otherwise.
            //Ti and Tr are tax constants currently set to 0.025.

            int totalValue = cost * qty; //VO
            
        }

        
    }
}
