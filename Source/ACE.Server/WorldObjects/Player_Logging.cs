using System;
using System.Linq;
using ACE.Server.Network;
using log4net;

namespace ACE.Server.WorldObjects
{
    partial class Player
    {
        private static readonly ILog tracker = LogManager.GetLogger(System.Reflection.Assembly.GetEntryAssembly(), "PlayerTracker");

        //TODO: Implement HWID
        /// <summary>
        /// Unique identifier for the connected player.
        /// </summary>
        public string ClientID => (Session?.EndPoint?.Address?.ToString()) ?? "UNKNOWN";

        public void Trace(TracedEntry item)
        { 
            if (Server.Managers.PropertyManager.GetBool("player_trace").Item)
            {
                string configname = "player_trace";
                switch (item.GetType().Name)
                {
                    case "PlayerDeathEntry":
                        configname = "player_trace_death";
                        break;
                    case "PlayerTeleportEntry":
                        configname = "player_trace_teleport";
                        break;
                    case "PlayerQuestEntry":
                        configname = "player_trace_quest";
                        break;
                    case "PlayerXPRewardEntry":
                        configname = "player_trace_xp";
                        break;
                    case "PlayerLuminanceRewardEntry":
                        configname = "player_trace_lum";
                        break;
                    case "PlayerItemRewardEntry":
                        configname = "player_trace_item_reward";
                        break;
                    case "PlayerItemGiveEntry":
                        configname = "player_trace_item_give";
                        break;
                    default:
                        break;
                }

                if (Server.Managers.PropertyManager.GetBool(configname).Item)
                    tracker.Info($"{TracedEntry.Annotate("CLID", ClientID)} {TracedEntry.Annotate("TRACE", item.GetType().Name)} {item}");
            }
        }
    }

    public abstract class TracedEntry
    {
        public override string ToString() => "";
        public static string Annotate(string name, object value) => $"{{{{{name}:{value}}}}}";
        protected string W(string name, object value) => Annotate(name, value);
    }

    public class PlayerDeathEntry : TracedEntry
    {
        public string NameKilled { get; set; }

        public uint GuidKilledBy { get; set; }
        public string NameKilledBy { get; set; }

        public string Landblock { get; set; }
        public int TotalDeaths { get; set; }

        public override string ToString() =>
            $"{W("CHAR", NameKilled)}; killed by {NameKilledBy} ({GuidKilledBy}); at {Landblock}; Total Deaths: {TotalDeaths}.";
    }

    public class PlayerTeleportEntry : TracedEntry
    {
        public string PlayerName { get; set; }
        public string LandblockFrom { get; set; }
        public string LandblockTo { get; set; }
        public string FullDestination { get; set; }
        public TeleportType TeleportType { get; set; }

        public override string ToString() => 
            $"{W("CHAR", PlayerName)} Type: {TeleportType} {W("LBPORTFROM", LandblockFrom)} {W("LBPORTTO", LandblockTo)} {FullDestination}";
    }

    public enum TeleportType
    {
        Unknown,
        Portal,
        RecallCast,
        RecallCommand,
        Death,
        Trap,
        Other,
        HouseBoot,
        Admin,
        Gem,
        Emote
    }

    public class PlayerQuestEntry : TracedEntry
    {
        public string PlayerName { get; set; }
        public string Landblock { get; set; }
        public string QuestName { get; set; }
        public int NumTimesCompleted { get; set; }

        public override string ToString() => 
            $"{W("CHAR", PlayerName)} {W("LBQUEST", Landblock)} {W("QUEST", QuestName)} NumTimesCompleted: {NumTimesCompleted}";
    }

    public enum QuestStampOperation
    {
        Unknown,
        Stamp,
        Erase
    }

    public class PlayerXPRewardEntry : TracedEntry
    {
        public string PlayerName { get; set; }
        public long Amount { get; set; }
        public ACE.Entity.Enum.XpType XpType { get; set; }

        public override string ToString() => $"{W("CHAR", PlayerName)} ({PlayerName} earned {XpType} XP {Amount}";
    }

    public class PlayerLuminanceRewardEntry : TracedEntry
    {
        public string PlayerName { get; set; }
        public long Amount { get; set; }
        public ACE.Entity.Enum.XpType XpType { get; set; }

        public override string ToString() => $"{W("CHAR", PlayerName)} ({PlayerName} earned {XpType} LUM {Amount}";
    }

    public class PlayerItemRewardEntry : TracedEntry
    {
        public string PlayerName { get; set; }
        public string PlayerClient { get; set; }
        public uint WeenieID { get; set; }
        public string ItemName { get; set; }
        public string ItemGuid { get; set; }
        public uint NPCWeenie { get; set; }
        public string NPCName { get; set; }

        public override string ToString() =>
            $"{W("CHAR", PlayerName)} {W("CLIENT", PlayerClient)} NPC:{W("WEENIE", NPCWeenie)} Item:{W("WEENIE", WeenieID.ToString())} {W("GUID", ItemGuid)} -->> {NPCName} gives {ItemName} to {PlayerName}";
    }

    public class PlayerItemGiveEntry : TracedEntry
    {
        public string PlayerName { get; set; }
        public string PlayerClient { get; set; }
        public uint WeenieID { get; set; }
        public string ItemName { get; set; }
        public string ItemGuid { get; set; }
        public string GivenTo { get; set; }
        public string GivenToClient { get; set; }

        public override string ToString() =>
            $"{W("CHAR", PlayerName)} {W("CLIENT", PlayerClient)} Item:{W("WEENIE", WeenieID)} {W("GUID", ItemGuid.ToString())} GivenTo:{W("CLIENT", GivenToClient)}{W("CHAR",GivenTo)} -->> {PlayerName} gives {ItemName} to {GivenTo}";
    }
}
