using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GameNetcodeStuff;
using Mono.CompilerServices.SymbolWriter;

namespace Coroner {
    class AdvancedDeathTracker {
        public const int PLAYER_CAUSE_OF_DEATH_DROPSHIP = 300;

        private static readonly Dictionary<int, AdvancedCauseOfDeath> PlayerCauseOfDeath = new Dictionary<int, AdvancedCauseOfDeath>();

        public static void ClearDeathTracker() {
            PlayerCauseOfDeath.Clear();
        }

        public static void SetCauseOfDeath(int playerIndex, AdvancedCauseOfDeath causeOfDeath, bool broadcast = true) {
            PlayerCauseOfDeath[playerIndex] = causeOfDeath;
            if (broadcast) DeathBroadcaster.BroadcastCauseOfDeath(playerIndex, causeOfDeath);
        }

        public static void SetCauseOfDeath(int playerIndex, CauseOfDeath causeOfDeath, bool broadcast = true) {
            SetCauseOfDeath(playerIndex, ConvertCauseOfDeath(causeOfDeath), broadcast);
        }

        public static void SetCauseOfDeath(PlayerControllerB playerController, CauseOfDeath causeOfDeath, bool broadcast = true) {
            SetCauseOfDeath((int)playerController.playerClientId, ConvertCauseOfDeath(causeOfDeath), broadcast);
        }

        public static void SetCauseOfDeath(PlayerControllerB playerController, AdvancedCauseOfDeath causeOfDeath, bool broadcast = true) {
            SetCauseOfDeath((int)playerController.playerClientId, causeOfDeath, broadcast);
        }

        public static AdvancedCauseOfDeath GetCauseOfDeath(int playerIndex) {
            PlayerControllerB playerController = StartOfRound.Instance.allPlayerScripts[playerIndex];

            return GetCauseOfDeath(playerController);
        }

        public static AdvancedCauseOfDeath GetCauseOfDeath(PlayerControllerB playerController) {
            if (!PlayerCauseOfDeath.ContainsKey((int)playerController.playerClientId)) {
                Plugin.Instance.PluginLogger.LogInfo($"Player {playerController.playerClientId} has no custom cause of death stored! Using fallback...");
                return GuessCauseOfDeath(playerController);
            } else {
                Plugin.Instance.PluginLogger.LogInfo($"Player {playerController.playerClientId} has custom cause of death stored! {PlayerCauseOfDeath[(int)playerController.playerClientId]}");
                return PlayerCauseOfDeath[(int)playerController.playerClientId];
            }
        }

        public static AdvancedCauseOfDeath GuessCauseOfDeath(PlayerControllerB playerController) {
            if (playerController.isPlayerDead) {
                if (IsHoldingJetpack(playerController)) {
                    if (playerController.causeOfDeath == CauseOfDeath.Gravity) {
                        return AdvancedCauseOfDeath.Jetpack_Gravity;
                    } else if (playerController.causeOfDeath == CauseOfDeath.Blast) {
                        return AdvancedCauseOfDeath.Jetpack_Blast;
                    }
                }

                return ConvertCauseOfDeath(playerController.causeOfDeath);
            } else {
                return AdvancedCauseOfDeath.Unknown;
            }
        }

        public static bool IsHoldingJetpack(PlayerControllerB playerController) {
            var heldObjectServer = playerController.currentlyHeldObjectServer;
            if (heldObjectServer == null) return false;
            var heldObjectGameObject = heldObjectServer.gameObject;
            if (heldObjectGameObject == null) return false;
            var heldObject = heldObjectGameObject.GetComponent<GrabbableObject>();
            if (heldObject == null) return false;

            if (heldObject is JetpackItem) {
                return true;
            } else {
                return false;
            }
        }

        public static AdvancedCauseOfDeath ConvertCauseOfDeath(CauseOfDeath causeOfDeath) {
            switch (causeOfDeath) {
                case CauseOfDeath.Unknown:
                    return AdvancedCauseOfDeath.Unknown;
                case CauseOfDeath.Bludgeoning:
                    return AdvancedCauseOfDeath.Bludgeoning;
                case CauseOfDeath.Gravity:
                    return AdvancedCauseOfDeath.Gravity;
                case CauseOfDeath.Blast:
                    return AdvancedCauseOfDeath.Blast;
                case CauseOfDeath.Strangulation:
                    return AdvancedCauseOfDeath.Strangulation;
                case CauseOfDeath.Suffocation:
                    return AdvancedCauseOfDeath.Suffocation;
                case CauseOfDeath.Mauling:
                    return AdvancedCauseOfDeath.Mauling;
                case CauseOfDeath.Gunshots:
                    return AdvancedCauseOfDeath.Gunshots;
                case CauseOfDeath.Crushing:
                    return AdvancedCauseOfDeath.Crushing;
                case CauseOfDeath.Drowning:
                    return AdvancedCauseOfDeath.Drowning;
                case CauseOfDeath.Abandoned:
                    return AdvancedCauseOfDeath.Abandoned;
                case CauseOfDeath.Electrocution:
                    return AdvancedCauseOfDeath.Electrocution;
                default:
                    return AdvancedCauseOfDeath.Unknown;
            }
        }

        public static string StringifyCauseOfDeath(CauseOfDeath causeOfDeath) {
            return StringifyCauseOfDeath(ConvertCauseOfDeath(causeOfDeath));
        }

        public static string StringifyCauseOfDeath(AdvancedCauseOfDeath causeOfDeath) {
            switch (causeOfDeath) {
                case AdvancedCauseOfDeath.Bludgeoning:
                    return PickRandom(CauseOfDeathStrings.bldgnList);
                case AdvancedCauseOfDeath.Gravity:
                    return PickRandom(CauseOfDeathStrings.grvList);
                case AdvancedCauseOfDeath.Blast:
                    return PickRandom(CauseOfDeathStrings.blastList);
                case AdvancedCauseOfDeath.Strangulation:
                    return PickRandom(CauseOfDeathStrings.strngList);
                case AdvancedCauseOfDeath.Suffocation:
                    return PickRandom(CauseOfDeathStrings.suffList);
                case AdvancedCauseOfDeath.Mauling:
                    return PickRandom(CauseOfDeathStrings.maulList);
                case AdvancedCauseOfDeath.Gunshots:
                    return PickRandom(CauseOfDeathStrings.shotList);
                case AdvancedCauseOfDeath.Crushing:
                    return PickRandom(CauseOfDeathStrings.crshList);
                case AdvancedCauseOfDeath.Drowning:
                    return PickRandom(CauseOfDeathStrings.drownList);
                case AdvancedCauseOfDeath.Abandoned:
                    return PickRandom(CauseOfDeathStrings.abndnList);
                case AdvancedCauseOfDeath.Electrocution:
                    return PickRandom(CauseOfDeathStrings.elecList);

                case AdvancedCauseOfDeath.Enemy_Bracken:
                    return PickRandom(CauseOfDeathStrings.brcknList);
                case AdvancedCauseOfDeath.Enemy_EyelessDog:
                    return PickRandom(CauseOfDeathStrings.dogList);
                case AdvancedCauseOfDeath.Enemy_ForestGiant:
                    return PickRandom(CauseOfDeathStrings.giantList);
                case AdvancedCauseOfDeath.Enemy_CircuitBees:
                    return PickRandom(CauseOfDeathStrings.beeList);
                case AdvancedCauseOfDeath.Enemy_GhostGirl:
                    return PickRandom(CauseOfDeathStrings.ghostList);
                case AdvancedCauseOfDeath.Enemy_EarthLeviathan:
                    return PickRandom(CauseOfDeathStrings.lvthnList);
                case AdvancedCauseOfDeath.Enemy_BaboonHawk:
                    return PickRandom(CauseOfDeathStrings.hawkList);
                case AdvancedCauseOfDeath.Enemy_Jester:
                    return PickRandom(CauseOfDeathStrings.jstrList);
                case AdvancedCauseOfDeath.Enemy_SnareFlea:
                    return PickRandom(CauseOfDeathStrings.fleaList);
                case AdvancedCauseOfDeath.Enemy_Hygrodere:
                    return PickRandom(CauseOfDeathStrings.blobList);
                case AdvancedCauseOfDeath.Enemy_HoarderBug:
                    return PickRandom(CauseOfDeathStrings.hrdrList);
                case AdvancedCauseOfDeath.Enemy_SporeLizard:
                    return PickRandom(CauseOfDeathStrings.lzrdList);
                case AdvancedCauseOfDeath.Enemy_SandSpider:
                    return PickRandom(CauseOfDeathStrings.spdrList);

                case AdvancedCauseOfDeath.Jetpack_Gravity:
                    return PickRandom(CauseOfDeathStrings.jtpkGrvList);
                case AdvancedCauseOfDeath.Jetpack_Blast:
                    return PickRandom(CauseOfDeathStrings.jtpkBlstList);
                case AdvancedCauseOfDeath.Player_Murder:
                    return PickRandom(CauseOfDeathStrings.mrdrList);
                case AdvancedCauseOfDeath.Player_Quicksand:
                    return PickRandom(CauseOfDeathStrings.qksndList);
                case AdvancedCauseOfDeath.Player_DepositItemsDesk:
                    return PickRandom(CauseOfDeathStrings.deskList);
                case AdvancedCauseOfDeath.Player_Dropship:
                    return PickRandom(CauseOfDeathStrings.drpshpList);
                case AdvancedCauseOfDeath.Player_StunGrenade:
                    return PickRandom(CauseOfDeathStrings.grndList);

                case AdvancedCauseOfDeath.Unknown:
                    return PickRandom(CauseOfDeathStrings.unknwnList);
                default:
                    return PickRandom(CauseOfDeathStrings.unknwnList);
            }
        }

        internal static void SetCauseOfDeath(PlayerControllerB playerControllerB, object enemy_BaboonHawk)
        {
            throw new NotImplementedException();
        }

        public static string PickRandom(List<string> source)
        {
            Random r = new Random();
            var i = r.Next(source.Count);
            return source[i];
        }
    }

    enum AdvancedCauseOfDeath {
        // Basic causes of death
        Unknown,
        Bludgeoning,
        Gravity,
        Blast,
        Strangulation,
        Suffocation,
        Mauling,
        Gunshots,
        Crushing,
        Drowning,
        Abandoned,
        Electrocution,

        // Custom causes (enemies)
        Enemy_BaboonHawk, // Also known as BaboonBird
        Enemy_Bracken, // Also known as Flowerman
        Enemy_CircuitBees, // Also known as RedLocustBees
        Enemy_EarthLeviathan, // Also known as SandWorm
        Enemy_EyelessDog, // Also known as MouthDog
        Enemy_ForestGiant,
        Enemy_GhostGirl, // Also known as DressGirl
        Enemy_Jester,
        Enemy_SnareFlea, // Also known as Centipede
        Enemy_SporeLizard, // Also known as Puffer TODO: Implement this.
        Enemy_Hygrodere, // Also known as Blob TODO: Implement this.
        Enemy_SandSpider, // TODO: Implement this.
        Enemy_Thumper, // Also known as Crawler TODO: Implement this.
        Enemy_HoarderBug, // TODO: Implement this.

        // Custom causes (other)
        Jetpack_Gravity,
        Jetpack_Blast,
        Player_Quicksand,
        Player_Murder,
        Player_DepositItemsDesk,
        Player_Dropship,
        Player_StunGrenade, // TODO: Implement this.
    }
}