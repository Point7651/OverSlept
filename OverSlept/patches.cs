using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverSlept
{
    [HarmonyPatch]
    internal class patches
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(Campfire), nameof(Campfire.CanSleepHereNow))]
        public static bool Campfire_CanSleepHereNow(ref bool __result)
        {
            __result = true;
            return false;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Campfire), nameof(Campfire.ShouldWakeUp))]
        public static bool Campfire_ShouldWakeUp(ref bool __result)
        {
            if (!OWInput.IsInputMode(InputMode.None) || (!OWInput.IsNewlyPressed(InputLibrary.interact) && !OWInput.IsNewlyPressed(InputLibrary.cancel) && !OWInput.IsNewlyPressed(InputLibrary.interactSecondary)))
            {
                __result = false;
                return false;
            }
            __result = true;
            return false;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(DreamCampfire), nameof(Campfire.CanSleepHereNow))]
        public static bool DreamCampfire_CanSleepHereNow(ref bool __result)
        {
            __result = true;
            return false;
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(DreamCampfire), nameof(Campfire.ShouldWakeUp))]
        public static bool DreamCampfire_ShouldWakeUp(ref bool __result)
        {
            if (!OWInput.IsInputMode(InputMode.None) || (!OWInput.IsNewlyPressed(InputLibrary.interact) && !OWInput.IsNewlyPressed(InputLibrary.cancel) && !OWInput.IsNewlyPressed(InputLibrary.interactSecondary)))
            {
                __result = false;
                return false;
            }
            __result = true;
            return false;
        }
    }
}
