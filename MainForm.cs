using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using System.Threading;
using System.Diagnostics;
using System.Security.Cryptography;
using ComponentAce.Compression.Libs.zlib;

namespace requester_rebase
{
    public partial class MainForm : Form
    {
        //IMPORTANT TEMPLATE IDs:
        //5c12688486f77426843c7d32 = Paracord | 200000 tax of 1 cord is 18679
        //57347ca924597744596b4e71 = Graphics Card | 315000 tax of 1 card is 21302
        //5a1eaa87fcdbcb001865f75e = Reap-IR thermal | 225000 tax of 1 thermal is 10989
        //59faff1d86f7746c51718c9c = Bitcoin | 155000 tax of 1 BTC is 9250
        //initialize them here:

        public static string paracordId = "5c12688486f77426843c7d32";
        public static string gfxcardId = "57347ca924597744596b4e71";
        public static string thermalscopeId = "5a1eaa87fcdbcb001865f75e";
        public static string bitcoin = "59faff1d86f7746c51718c9c";
        public string checkedItem;

        //initialize defaults
        public static Random randomizeID = new Random();
        public string PHPSESSID;
        Classes.Login login;
        Classes.Utilities utilities;
        Versions versions;
        Automation.MarketBot marketBot;
        Automation.Inbox inbox;
        Classes.CheckVersion checkVersion;
        private static string uid = "5df78c2987ba573dcd7dc077";

        public MainForm()
        {
            InitializeComponent();
            marketBot = new Automation.MarketBot(this);
            checkVersion = new Classes.CheckVersion(this);
        }

        public void AddLog(string Log)
        {
            txtLog.AppendText(DateTime.Now.ToString() + ": " + Log + "\n");
            File.AppendAllText("log.txt", DateTime.Now.ToString() + Log + "\n");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            login = new Classes.Login(this);
            
            if (txtSessionID.Text.Length == 0)
                AddLog("Invalid Session ID.");
            if (txtUsername.Text.Length == 0)
                AddLog("Invalid Username.");
            if (txtPassword.Text.Length == 0)
                AddLog("Invalid Password.");

            if (txtSessionID.Text.Length == 0 || txtUsername.Text.Length == 0 || txtPassword.Text.Length == 0)
                return;

            if(login.sendLogin(txtUsername.Text, txtPassword.Text, txtHWID.Text, txtSessionID.Text))
            {
                grbLogin.Enabled = false;
                btnLogin.Text = "Logged In";
            }
            
        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {
            txtLog.SelectionStart = txtLog.TextLength;
            txtLog.ScrollToCaret();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            checkedItem = "57347ca924597744596b4e71"; //gfx card
            utilities = new Classes.Utilities(this);
            versions = new Versions(this);
            PHPSESSID = utilities.RandomString(32);
            txtUsername.Text = "NotAssassinNite";
            txtPassword.Text = utilities.CalculateMD5Hash("drnm9qr7");
            txtHWID.Text = "#1-edde17c081b71782bb7658467b7e1699e1ac7cb3:1ff7d0c4414ad0ceda09011f1ed21fc5528d2922:1d43cc9d2fa1a6445da1990e72823c679959a23e-09b55fbb89fec743bc1c758e9c7d63c31646163b-0acfcae9cfb8b3b08299d2bf5368f8be23c1844b-0f503c52b46776b89146855c63b26b5f3c7489e7-9f8203df140f812c5d525777f76e0efd8dd0d20f-7296d4237ecba9f454ff79dd7275d456";

            File.WriteAllText("log.txt", String.Empty);

            AddLog($"Latest Launcher Version: {checkVersion.checkLauncherVersion()} | Current Launcher Version: {versions.LauncherVersion}");
            AddLog($"Latest Game Version: {checkVersion.checkGameVersion()} | Current Game Version: {versions.GameVersion}");

            string launcherVersion = checkVersion.checkLauncherVersion();
            string gameVersion = checkVersion.checkGameVersion();

            if (launcherVersion != versions.LauncherVersion || gameVersion != versions.GameVersion)
            {
                AddLog("Launcher version or Game version Does not match! Disabling until updated....");

                grbLogin.Enabled = false;
                grbTradeBot.Enabled = false;
            }

            txtSessionID.Text = PHPSESSID;

            AddLog($"Randomized Unique PHP Session ID: {PHPSESSID}");
        }

        private void btnDryRun_Click(object sender, EventArgs e)
        {
            //testing multithreading
            //possible algorithm:
            //(A)->QueryInventory->BuyKeyCards
            Thread t1 = new Thread(testAsync_A);
            Thread t2 = new Thread(testAsync_B);
            t2.Start();
            t1.Start();
        }

        public void testAsync_A()
        {
            if(InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    //put threaded code here i think
                    AddLog("Starting Async Threaded Operation t1...");

                    //marketBot = new Automation.MarketBot(this);

                    //marketBot.getMarketPrices();
                    marketBot.getTotalMoneyInInventory();

                    while (true) //i fucking hate this method of looping. try to fix this later...
                    {
                        //Random r = new Random();
                        //int rInt = r.Next(3000, 5000);

                        //AddLog("Calling Query Market...");
                        //marketBot.QueryMarket(gfxcardId);

                        //AddLog("Sleeping for " + TimeSpan.FromMilliseconds(rInt).TotalSeconds + " seconds");
                        //Thread.Sleep(1000);
                    }
                }));
            }
            else
            {
                //not sure what to put here
                AddLog("Also successfully invoked??");
            }
        }

        public void testAsync_B()
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    //put threaded code here i think
                    AddLog("Starting Async Threaded Operation t2...");

                    while (true) //i fucking hate this method of looping. try to fix this later...
                    {
                        //Random r = new Random();
                        //int rInt = r.Next(3000, 5000);

                        //AddLog("Calling Query Market...");
                        //marketBot.QueryMarket(paracordId);

                        //AddLog("Sleeping for " + TimeSpan.FromMilliseconds(rInt).TotalSeconds + " seconds");
                        //Thread.Sleep(rInt);
                    }
                }));
            }
            else
            {
                //not sure what to put here
                AddLog("Also successfully invoked??");
            }
        }

        private void RunBot()
        {
            for(int i = 0; i < 100; i++)
            {
                while (true)
                {
                    //if (marketBot.QueryMarket())
                    //{
                    //    AddLog("Number Purchased: " + marketBot.numberPurchased.ToString());
                    //    break;
                    //}
                }

               if (marketBot.numberPurchased == 10)
                {
                    marketBot.QueryInventory();
                    marketBot.getRoubles();
                    RunBot();
                }
            }
        }

        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }

        private void btnGetInbox_Click(object sender, EventArgs e)
        {
            inbox.getInboxId();
        }

        private void btnListCards_Click(object sender, EventArgs e)
        {
            marketBot.ListLabsCardsOnRagFair();
            //marketBot.listener();
        }

        private void btnLowPriceKillMode_Click(object sender, EventArgs e)
        {
            //query market every 3-5 seconds for:
            //1.) Mispriced Labs Cards(Cards < 140k || Cards < average price - 20k)
            //2.) Mispriced ???

            //marketBot.QueryInventory();
            marketBot.getTotalMoneyInInventory();

            while(true) //i fucking hate this method of looping. try to fix this later...
            {
                //Random r = new Random();
                //int rInt = r.Next(3000, 5000);

                //AddLog("Calling Query Market...");
                marketBot.QueryMarket(checkedItem);

                //AddLog("Sleeping for " + TimeSpan.FromMilliseconds(rInt).TotalSeconds + " seconds");
                //Thread.Sleep(rInt);
            }
            
        }

        private void radGFXCard_CheckedChanged(object sender, EventArgs e)
        {
            if(radGFXCard.Checked)
            {
                radParacord.Checked = false;
                radBTC.Checked = false;
                radReapIR.Checked = false;
                checkedItem = "57347ca924597744596b4e71"; //gfx card
            }
        }

        private void radParacord_CheckedChanged(object sender, EventArgs e)
        {
            if(radParacord.Checked)
            {
                radGFXCard.Checked = false;
                radBTC.Checked = false;
                radReapIR.Checked = false;
                checkedItem = "5c12688486f77426843c7d32"; //paracord
            }
        }

        private void radBTC_CheckedChanged(object sender, EventArgs e)
        {
            if(radBTC.Checked)
            {
                radGFXCard.Checked = false;
                radParacord.Checked = false;
                radReapIR.Checked = false;
                checkedItem = "59faff1d86f7746c51718c9c"; //bitcoin
            }
        }

        private void radReapIR_CheckedChanged(object sender, EventArgs e)
        {
            if (radReapIR.Checked)
            {
                radGFXCard.Checked = false;
                radParacord.Checked = false;
                radBTC.Checked = false;
                checkedItem = "5a1eaa87fcdbcb001865f75e"; //reap-ir
            }
        }
    }
}

public enum User
{
    Ignition
}
