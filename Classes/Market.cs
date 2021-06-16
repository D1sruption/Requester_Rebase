using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace requester_rebase.Classes
{
    class Market
    {
        public int err { get; set; }
        public object errmsg { get; set; }
        public List<ProfileInfo> data { get; set; }
    }

    public class ProfileInfo
    {
        public string _id { get; set; }
        public int aid { get; set; }
        public string savage { get; set; }
        public object Info { get; set; }
        public object Customization { get; set; }
        public object Health { get; set; }
        public Inventory Inventory { get; set; }
        public object Skills { get; set; }
        public object Stats { get; set; }
        public object Encyclopedia { get; set; }
        public object ConditionCounters { get; set; }
        public object BackendCounters { get; set; }
        public List<object> InsuredItems { get; set; }
        public object Hideout { get; set; }
        public List<object> Bonuses { get; set; }
        public object Notes { get; set; }
        public List<object> Quests { get; set; }
        public object TraderStandings { get; set; }
        public object RagfairInfo { get; set; }
        public List<object> WishList { get; set; }
    }

    public class Inventory
    {
        public List<Item> items { get; set; }
        public string equipment { get; set; }
        public string stash { get; set; }
        public string questRaidItems { get; set; }
        public string questStashItems { get; set; }
        public FastPanel fastPanel { get; set; }
    }

    public class FastPanel
    {
    }

    public class RagfairOffersResponse
    {
        public int err { get; set; }
        public object errmsg { get; set; }
        public RagfairOffersInfo data { get; set; }
    }

    public class RagfairOffersInfo
    {
        public List<Offer> offers { get; set; }
        public int offersCount { get; set; }
        public string selectedCategory { get; set; }
    }

    public class Offer
    {
        public string _id { get; set; }
        public string intId { get; set; }
        public User user { get; set; }
        public string root { get; set; }
        public List<Item> items { get; set; }
        public int itemsCost { get; set; }
        public List<Requirement> requirements { get; set; }
        public int requirementsCost { get; set; }
        public int summaryCost { get; set; }
        public bool sellInOnePiece { get; set; }
        public int startTime { get; set; }
        public int endTime { get; set; }
        public int loyaltyLevel { get; set; }
    }

    public class Item
    {
        public string _id { get; set; }
        public string _tpl { get; set; }
        public string parentId { get; set; }
        public string slotId { get; set; }
        public Upd upd { get; set; }
        public object location { get; set; }
    }

    public class Requirement
    {
        public double count { get; set; }
        public string _tpl { get; set; }
    }

    public class Upd
    {
        public Key Key { get; set; }
        public int StackObjectsCount { get; set; }
    }

    public class Upd2
    {
        public int StackObjectsCount { get; set; }
    }

    public class Key
    {
        public int NumberOfUsages { get; set; }
    }

    class GetMarketPricesResponse
    {
        public int err { get; set; }
        public object errmsg { get; set; }
        public GetMarketPricesData data { get; set; }
    }

    public class GetMarketPricesData
    {
        public string templateId { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public double avg { get; set; }
    }

    public class ProfileResponse
    {
        public int err { get; set; }
        public object errmsg { get; set; }
        public List<ProfileInfo> data { get; set; }
    }

    class MergedItem
    {
        public MergedItem(bool Merged)
        {
            IsMerged = Merged;
            ;
        }
        public bool IsMerged { get; set; }
    }

    public class RagFairAddOfferRequest
    {
        public List<RagFairAddOfferData> data { get; set; }
        public int tm { get; set; }
    }

    public class RagFairAddOfferData
    {
        public string Action { get; set; }
        public bool sellInOnePiece { get; set; }
        public List<string> items { get; set; }
        public List<RagFairAddOfferRequirement> requirements { get; set; }
    }

    public class RagFairAddOfferRequirement
    {
        public string _tpl { get; set; }
        public double count { get; set; }
        public int level { get; set; }
        public int side { get; set; }
        public bool onlyFunctional { get; set; }
    }
}
