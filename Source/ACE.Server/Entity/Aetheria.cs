using System;
using System.Collections.Generic;

using ACE.Common;
using ACE.Entity.Enum;
using ACE.Entity.Enum.Properties;
using ACE.Server.Entity.Actions;
using ACE.Server.Network.GameEvent.Events;
using ACE.Server.Network.GameMessages.Messages;
using ACE.Server.WorldObjects;

namespace ACE.Server.Entity
{
    public enum Sigil
    {
        /// <summary>
        /// Increased damage resistance rating
        /// </summary>
        Defense,

        /// <summary>
        /// Increased damage rating
        /// </summary>
        Destruction,

        /// <summary>
        /// Increased critical damage rating
        /// </summary>
        Fury,

        /// <summary>
        /// Increased healing rating
        /// </summary>
        Growth,

        /// <summary>
        /// Vital regeneration spells
        /// </summary>
        Vigor,
    }

    public enum AetheriaColor
    {
        Blue,
        Yellow,
        Red
    };

    public class Aetheria
    {
        // https://asheron.fandom.com/wiki/Aetheria

        public const uint AetheriaBlue = 42635;
        public const uint AetheriaBlueDefDestruction = 9042635;
        public const uint AetheriaBlueDefAffliction = 9142635;
        public const uint AetheriaBlueDefProtection = 9242635;
        public const uint AetheriaBlueDefFestering = 9342635;
        public const uint AetheriaBlueDefRegeneration = 9442635;
        public const uint AetheriaBlueDesDestruction = 8042635;
        public const uint AetheriaBlueDesAffliction = 8142635;
        public const uint AetheriaBlueDesProtection = 8242635;
        public const uint AetheriaBlueDesFestering = 8342635;
        public const uint AetheriaBlueDesRegeneration = 8442635;
        public const uint AetheriaBlueFurDesrtuction = 7042635;
        public const uint AetheriaBlueFurAffliction = 7142635;
        public const uint AetheriaBlueFurProtection = 7242635;
        public const uint AetheriaBlueFurFestering = 7342635;
        public const uint AetheriaBlueFurRegeneration = 7442635;
        public const uint AetheriaBlueGroDesrtuction = 6042635;
        public const uint AetheriaBlueGroAffliction = 6142635;
        public const uint AetheriaBlueGroProtection = 6242635;
        public const uint AetheriaBlueGroFestering = 6342635;
        public const uint AetheriaBlueGroRegeneration = 6442635;
        public const uint AetheriaBlueVigDesrtuction = 5042635;
        public const uint AetheriaBlueVigAffliction = 5142635;
        public const uint AetheriaBlueVigProtection = 5242635;
        public const uint AetheriaBlueVigFestering = 5342635;
        public const uint AetheriaBlueVigRegeneration = 5442635;
        public const uint AetheriaRed = 42636;
        public const uint AetheriaRedDefDestruction = 9042636;
        public const uint AetheriaRedDefAffliction = 9142636;
        public const uint AetheriaRedDefProtection = 9242636;
        public const uint AetheriaRedDefFestering = 9342636;
        public const uint AetheriaRedDefRegeneration = 9442636;
        public const uint AetheriaRedDesDestruction = 8042636;
        public const uint AetheriaRedDesAffliction = 8142636;
        public const uint AetheriaRedDesProtection = 8242636;
        public const uint AetheriaRedDesFestering = 8342636;
        public const uint AetheriaRedDesRegeneration = 8442636;
        public const uint AetheriaRedFurDesrtuction = 7042636;
        public const uint AetheriaRedFurAffliction = 7142636;
        public const uint AetheriaRedFurProtection = 7242636;
        public const uint AetheriaRedFurFestering = 7342636;
        public const uint AetheriaRedFurRegeneration = 7442636;
        public const uint AetheriaRedGroDesrtuction = 6042636;
        public const uint AetheriaRedGroAffliction = 6142636;
        public const uint AetheriaRedGroProtection = 6242636;
        public const uint AetheriaRedGroFestering = 6342636;
        public const uint AetheriaRedGroRegeneration = 6442636;
        public const uint AetheriaRedVigDesrtuction = 5042636;
        public const uint AetheriaRedVigAffliction = 5142636;
        public const uint AetheriaRedVigProtection = 5242636;
        public const uint AetheriaRedVigFestering = 5342636;
        public const uint AetheriaRedVigRegeneration = 5442636;
        public const uint AetheriaYellow = 42637;
        public const uint AetheriaYellowDefDestruction = 9042637;
        public const uint AetheriaYellowDefAffliction = 9142637;
        public const uint AetheriaYellowDefProtection = 9242637;
        public const uint AetheriaYellowDefFestering = 9342637;
        public const uint AetheriaYellowDefRegeneration = 9442637;
        public const uint AetheriaYellowDesDestruction = 8042637;
        public const uint AetheriaYellowDesAffliction = 8142637;
        public const uint AetheriaYellowDesProtection = 8242637;
        public const uint AetheriaYellowDesFestering = 8342637;
        public const uint AetheriaYellowDesRegeneration = 8442637;
        public const uint AetheriaYellowFurDesrtuction = 7042637;
        public const uint AetheriaYellowFurAffliction = 7142637;
        public const uint AetheriaYellowFurProtection = 7242637;
        public const uint AetheriaYellowFurFestering = 7342637;
        public const uint AetheriaYellowFurRegeneration = 7442637;
        public const uint AetheriaYellowGroDesrtuction = 6042637;
        public const uint AetheriaYellowGroAffliction = 6142637;
        public const uint AetheriaYellowGroProtection = 6242637;
        public const uint AetheriaYellowGroFestering = 6342637;
        public const uint AetheriaYellowGroRegeneration = 6442637;
        public const uint AetheriaYellowVigDesrtuction = 5042637;
        public const uint AetheriaYellowVigAffliction = 5142637;
        public const uint AetheriaYellowVigProtection = 5242637;
        public const uint AetheriaYellowVigFestering = 5342637;
        public const uint AetheriaYellowVigRegeneration = 5442637;


        public const uint AetheriaManaStone = 42645;

        public static Dictionary<AetheriaColor, Dictionary<Sigil, uint>> Icons;

        static Aetheria()
        {
            Icons = new Dictionary<AetheriaColor, Dictionary<Sigil, uint>>();

            Icons.Add(AetheriaColor.Blue,   new Dictionary<Sigil, uint>());
            Icons.Add(AetheriaColor.Yellow, new Dictionary<Sigil, uint>());
            Icons.Add(AetheriaColor.Red,    new Dictionary<Sigil, uint>());

            Icons[AetheriaColor.Blue].Add(Sigil.Defense,     0x06006BF2);
            Icons[AetheriaColor.Blue].Add(Sigil.Destruction, 0x06006BFE);
            Icons[AetheriaColor.Blue].Add(Sigil.Fury,        0x06006BFF);
            Icons[AetheriaColor.Blue].Add(Sigil.Growth,      0x06006C00);
            Icons[AetheriaColor.Blue].Add(Sigil.Vigor,       0x06006C01);

            Icons[AetheriaColor.Yellow].Add(Sigil.Defense,     0x06006C06);
            Icons[AetheriaColor.Yellow].Add(Sigil.Destruction, 0x06006C07);
            Icons[AetheriaColor.Yellow].Add(Sigil.Fury,        0x06006BF3);
            Icons[AetheriaColor.Yellow].Add(Sigil.Growth,      0x06006C08);
            Icons[AetheriaColor.Yellow].Add(Sigil.Vigor,       0x06006BFD);

            Icons[AetheriaColor.Red].Add(Sigil.Defense,     0x06006C02);
            Icons[AetheriaColor.Red].Add(Sigil.Destruction, 0x06006C03);
            Icons[AetheriaColor.Red].Add(Sigil.Fury,        0x06006C04);
            Icons[AetheriaColor.Red].Add(Sigil.Growth,      0x06006BF4);
            Icons[AetheriaColor.Red].Add(Sigil.Vigor,       0x06006C05);
        }


        public static bool IsAetheria(uint wcid)
        {
            return wcid == 9042635 || wcid == 9142635 || wcid == 9242635 || wcid == 9342635 || wcid == 9442635 || wcid == 8042635 || wcid == 8142635 || wcid == 8242635 || wcid == 8342635 || wcid == 8442635 || wcid == 7042635 || wcid == 7142635 || wcid == 7242635 || wcid == 7342635 || wcid == 7442635 || wcid == 6042635 || wcid == 6142635 || wcid == 6242635 || wcid == 6342635 || wcid == 6442635 || wcid == 5042635 || wcid == 5142635 || wcid == 5242635 || wcid == 5342635 || wcid == 5442635 || wcid == 9042636 || wcid == 9142636 || wcid == 9242636 || wcid == 9342636 || wcid == 9442636 || wcid == 8042636 || wcid == 8142636 || wcid == 8242636 || wcid == 8342636 || wcid == 8442636 || wcid == 7042636 || wcid == 7142636 || wcid == 7242636 || wcid == 7342636 || wcid == 7442636 || wcid == 6042636 || wcid == 6142636 || wcid == 6242636 || wcid == 6342636 || wcid == 6442636 || wcid == 5042636 || wcid == 5142636 || wcid == 5242636 || wcid == 5342636 || wcid == 5442636 || wcid == 9042637 || wcid == 9142637 || wcid == 9242637 || wcid == 9342637 || wcid == 9442637 || wcid == 8042637 || wcid == 8142637 || wcid == 8242637 || wcid == 8342637 || wcid == 8442637 || wcid == 7042637 || wcid == 7142637 || wcid == 7242637 || wcid == 7342637 || wcid == 7442637 || wcid == 6042637 || wcid == 6142637 || wcid == 6242637 || wcid == 6342637 || wcid == 6442637 || wcid == 5042637 || wcid == 5142637 || wcid == 5242637 || wcid == 5342637 || wcid == 5442637;
        }

        public static AetheriaColor? GetColor(uint wcid)
        {
            switch (wcid)
            {
                case AetheriaBlue:
                    return AetheriaColor.Blue;
                case AetheriaBlueDefDestruction:
                    return AetheriaColor.Blue;
                case AetheriaBlueDefAffliction:
                    return AetheriaColor.Blue;
                case AetheriaBlueDefProtection:
                    return AetheriaColor.Blue;
                case AetheriaBlueDefFestering:
                    return AetheriaColor.Blue;
                case AetheriaBlueDefRegeneration:
                    return AetheriaColor.Blue;
                case AetheriaBlueDesDestruction:
                    return AetheriaColor.Blue;
                case AetheriaBlueDesAffliction:
                    return AetheriaColor.Blue;
                case AetheriaBlueDesProtection:
                    return AetheriaColor.Blue;
                case AetheriaBlueDesFestering:
                    return AetheriaColor.Blue;
                case AetheriaBlueDesRegeneration:
                    return AetheriaColor.Blue;
                case AetheriaBlueFurDesrtuction:
                    return AetheriaColor.Blue;
                case AetheriaBlueFurAffliction:
                    return AetheriaColor.Blue;
                case AetheriaBlueFurProtection:
                    return AetheriaColor.Blue;
                case AetheriaBlueFurFestering:
                    return AetheriaColor.Blue;
                case AetheriaBlueFurRegeneration:
                    return AetheriaColor.Blue;
                case AetheriaBlueGroDesrtuction:
                    return AetheriaColor.Blue;
                case AetheriaBlueGroAffliction:
                    return AetheriaColor.Blue;
                case AetheriaBlueGroProtection:
                    return AetheriaColor.Blue;
                case AetheriaBlueGroFestering:
                    return AetheriaColor.Blue;
                case AetheriaBlueGroRegeneration:
                    return AetheriaColor.Blue;
                case AetheriaBlueVigDesrtuction:
                    return AetheriaColor.Blue;
                case AetheriaBlueVigAffliction:
                    return AetheriaColor.Blue;
                case AetheriaBlueVigProtection:
                    return AetheriaColor.Blue;
                case AetheriaBlueVigFestering:
                    return AetheriaColor.Blue;
                case AetheriaBlueVigRegeneration:
                    return AetheriaColor.Blue;
                case AetheriaYellow:
                    return AetheriaColor.Yellow;
                case AetheriaYellowDefDestruction:
                    return AetheriaColor.Yellow;
                case AetheriaYellowDefAffliction:
                    return AetheriaColor.Yellow;
                case AetheriaYellowDefProtection:
                    return AetheriaColor.Yellow;
                case AetheriaYellowDefFestering:
                    return AetheriaColor.Yellow;
                case AetheriaYellowDefRegeneration:
                    return AetheriaColor.Yellow;
                case AetheriaYellowDesDestruction:
                    return AetheriaColor.Yellow;
                case AetheriaYellowDesAffliction:
                    return AetheriaColor.Yellow;
                case AetheriaYellowDesProtection:
                    return AetheriaColor.Yellow;
                case AetheriaYellowDesFestering:
                    return AetheriaColor.Yellow;
                case AetheriaYellowDesRegeneration:
                    return AetheriaColor.Yellow;
                case AetheriaYellowFurDesrtuction:
                    return AetheriaColor.Yellow;
                case AetheriaYellowFurAffliction:
                    return AetheriaColor.Yellow;
                case AetheriaYellowFurProtection:
                    return AetheriaColor.Yellow;
                case AetheriaYellowFurFestering:
                    return AetheriaColor.Yellow;
                case AetheriaYellowFurRegeneration:
                    return AetheriaColor.Yellow;
                case AetheriaYellowGroDesrtuction:
                    return AetheriaColor.Yellow;
                case AetheriaYellowGroAffliction:
                    return AetheriaColor.Yellow;
                case AetheriaYellowGroProtection:
                    return AetheriaColor.Yellow;
                case AetheriaYellowGroFestering:
                    return AetheriaColor.Yellow;
                case AetheriaYellowGroRegeneration:
                    return AetheriaColor.Yellow;
                case AetheriaYellowVigDesrtuction:
                    return AetheriaColor.Yellow;
                case AetheriaYellowVigAffliction:
                    return AetheriaColor.Yellow;
                case AetheriaYellowVigProtection:
                    return AetheriaColor.Yellow;
                case AetheriaYellowVigFestering:
                    return AetheriaColor.Yellow;
                case AetheriaYellowVigRegeneration:
                    return AetheriaColor.Yellow;
                case AetheriaRed:
                    return AetheriaColor.Red;
                case AetheriaRedDefDestruction:
                    return AetheriaColor.Red;
                case AetheriaRedDefAffliction:
                    return AetheriaColor.Red;
                case AetheriaRedDefProtection:
                    return AetheriaColor.Red;
                case AetheriaRedDefFestering:
                    return AetheriaColor.Red;
                case AetheriaRedDefRegeneration:
                    return AetheriaColor.Red;
                case AetheriaRedDesDestruction:
                    return AetheriaColor.Red;
                case AetheriaRedDesAffliction:
                    return AetheriaColor.Red;
                case AetheriaRedDesProtection:
                    return AetheriaColor.Red;
                case AetheriaRedDesFestering:
                    return AetheriaColor.Red;
                case AetheriaRedDesRegeneration:
                    return AetheriaColor.Red;
                case AetheriaRedFurDesrtuction:
                    return AetheriaColor.Red;
                case AetheriaRedFurAffliction:
                    return AetheriaColor.Red;
                case AetheriaRedFurProtection:
                    return AetheriaColor.Red;
                case AetheriaRedFurFestering:
                    return AetheriaColor.Red;
                case AetheriaRedFurRegeneration:
                    return AetheriaColor.Red;
                case AetheriaRedGroDesrtuction:
                    return AetheriaColor.Red;
                case AetheriaRedGroAffliction:
                    return AetheriaColor.Red;
                case AetheriaRedGroProtection:
                    return AetheriaColor.Red;
                case AetheriaRedGroFestering:
                    return AetheriaColor.Red;
                case AetheriaRedGroRegeneration:
                    return AetheriaColor.Red;
                case AetheriaRedVigDesrtuction:
                    return AetheriaColor.Red;
                case AetheriaRedVigAffliction:
                    return AetheriaColor.Red;
                case AetheriaRedVigProtection:
                    return AetheriaColor.Red;
                case AetheriaRedVigFestering:
                    return AetheriaColor.Red;
                case AetheriaRedVigRegeneration:
                    return AetheriaColor.Red;
                case 1910505:
                    return AetheriaColor.Blue;
                case 1910506:
                    return AetheriaColor.Red;
                case 1910507:
                    return AetheriaColor.Yellow;
                default:
                    return null;
            }
        }

        /// <summary>
        /// The player uses an aetheria mana stone on a piece of coalesced aetheria
        /// </summary>
        public static void UseObjectOnTarget(Player player, WorldObject source, WorldObject target)
        {
            //Console.WriteLine($"Aetheria.UseObjectOnTarget({player.Name}, {source.Name}, {target.Name})");

            if (player.IsBusy)
            {
                player.SendUseDoneEvent(WeenieError.YoureTooBusy);
                return;
            }

            // verify use requirements
            var useError = VerifyUseRequirements(player, source, target);
            if (useError != WeenieError.None)
            {
                player.SendUseDoneEvent(useError);
                return;
            }

            var animTime = 0.0f;

            var actionChain = new ActionChain();

            player.IsBusy = true;

            // handle switching to peace mode
            if (player.CombatMode != CombatMode.NonCombat)
            {
                var stanceTime = player.SetCombatMode(CombatMode.NonCombat);
                actionChain.AddDelaySeconds(stanceTime);

                animTime += stanceTime;
            }

            // perform clapping motion
            animTime += player.EnqueueMotion(actionChain, MotionCommand.ClapHands);

            actionChain.AddAction(player, () =>
            {
                // re-verify
                var useError = VerifyUseRequirements(player, source, target);
                if (useError != WeenieError.None)
                {
                    player.SendUseDoneEvent(useError);
                    return;
                }

                ActivateSigil(player, source, target);
            });

            player.EnqueueMotion(actionChain, MotionCommand.Ready);

            actionChain.AddAction(player, () => player.IsBusy = false);

            actionChain.EnqueueChain();

            player.NextUseTime = DateTime.UtcNow.AddSeconds(animTime);
        }

        public static WeenieError VerifyUseRequirements(Player player, WorldObject source, WorldObject target)
        {
            if (source == target)
            {
                player.Session.Network.EnqueueSend(new GameEventCommunicationTransientString(player.Session, $"You can't use the {source.Name} on itself."));
                return WeenieError.YouDoNotPassCraftingRequirements;
            }

            // ensure both source and target are in player's inventory
            if (player.FindObject(source.Guid.Full, Player.SearchLocations.MyInventory) == null)
                return WeenieError.YouDoNotPassCraftingRequirements;

            if (player.FindObject(target.Guid.Full, Player.SearchLocations.MyInventory) == null)
                return WeenieError.YouDoNotPassCraftingRequirements;

            if (source.WeenieClassId != AetheriaManaStone ||
                !IsAetheria(target.WeenieClassId))

                return WeenieError.YouDoNotPassCraftingRequirements;

            if (target.Name != "Coalesced Aetheria")
            {
                player.Session.Network.EnqueueSend(new GameEventCommunicationTransientString(player.Session, $"You can't use the {source.Name} on {target.Name} because the sigil is already visible."));
                return WeenieError.YouDoNotPassCraftingRequirements;
            }

            return WeenieError.None;
        }

        public static void ActivateSigil(Player player, WorldObject source, WorldObject target)
        {
            // rng select a sigil / spell set
            var randSigil = (Sigil)ThreadSafeRandom.Next(0, 4);

            var equipmentSet = SigilToEquipmentSet[randSigil];
            target.SetProperty(PropertyInt.EquipmentSetId, (int)equipmentSet);

            // change icon
            var color = GetColor(target.WeenieClassId).Value;
            var icon = Icons[color][randSigil];
            target.SetProperty(PropertyDataId.Icon, icon);

            // rng select a surge spell
            var surgeSpell = (SpellId)ThreadSafeRandom.Next(5204, 5208);

            //target.Biota.GetOrAddKnownSpell((int)surgeSpell, target.BiotaDatabaseLock, target.BiotaPropertySpells, out _);

            target.SetProperty(PropertyDataId.ProcSpell, (uint)surgeSpell);
            //target.SetProperty(PropertyFloat.ProcSpellRate, 0.05f);   // proc rate for aetheria?

            if (SurgeTargetSelf[surgeSpell])
                target.SetProperty(PropertyBool.ProcSpellSelfTargeted, true);

            // set equip mask
            target.SetProperty(PropertyInt.ValidLocations, (int)ColorToMask[color]);

            // level?
            player.Session.Network.EnqueueSend(new GameMessageSystemChat("A sigil rises to the surface as you bathe the aetheria in mana.", ChatMessageType.Broadcast));

            player.UpdateProperty(target, PropertyString.Name, "Aetheria");
            player.UpdateProperty(target, PropertyString.LongDesc, "This aetheria's sigil now shows on the surface.");
            player.Session.Network.EnqueueSend(new GameMessageUpdateObject(target));

            player.SendUseDoneEvent();
        }

        public static Dictionary<Sigil, EquipmentSet> SigilToEquipmentSet = new Dictionary<Sigil, EquipmentSet>()
        {
            { Sigil.Defense, EquipmentSet.AetheriaDefense },
            { Sigil.Destruction, EquipmentSet.AetheriaDestruction },
            { Sigil.Fury, EquipmentSet.AetheriaFury },
            { Sigil.Growth, EquipmentSet.AetheriaGrowth },
            { Sigil.Vigor, EquipmentSet.AetheriaVigor }
        };

        public static Dictionary<AetheriaColor, EquipMask> ColorToMask = new Dictionary<AetheriaColor, EquipMask>()
        {
            { AetheriaColor.Blue, EquipMask.SigilOne },
            { AetheriaColor.Yellow, EquipMask.SigilTwo },
            { AetheriaColor.Red, EquipMask.SigilThree },
        };

        public static Dictionary<SpellId, bool> SurgeTargetSelf = new Dictionary<SpellId, bool>()
        {
            { SpellId.AetheriaProcDamageBoost,     true },
            { SpellId.AetheriaProcDamageOverTime,  false },
            { SpellId.AetheriaProcDamageReduction, true },
            { SpellId.AetheriaProcHealDebuff,      false },
            { SpellId.AetheriaProcHealthOverTime,  true },
        };

        public static float CalcProcRate(WorldObject aetheria, Creature wielder)
        {
            // ~1% base rate per level?
            var procRate = (aetheria.ItemLevel ?? 0) * 0.01f;

            if (wielder is Player player)
            {
                // +0.1% per luminance aug?
                var augBonus = player.LumAugSurgeChanceRating * 0.001f;
                procRate += augBonus;
            }

            // The proc rates depend on the attack type. Magic is best, then missile is slightly lower, then Melee is slightly lower than missile.
            switch (wielder.CombatMode)
            {
                case CombatMode.Magic:
                    procRate *= 2.0f;
                    break;

                case CombatMode.Missile:
                    procRate *= 1.5f;
                    break;
                case CombatMode.Melee:
                    procRate *= 1.2f;
                    break;
            }
            // It is unconfirmed, but believed, that the act of being hit or attacked increases the chances of a surge triggering.
            return procRate;
        }

        /// <summary>
        /// Returns TRUE if wo is AetheriaManaStone
        /// </summary>
        public static bool IsAetheriaManaStone(WorldObject wo)
        {
            return wo.WeenieClassId == AetheriaManaStone;
        }
    }
}
