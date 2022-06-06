using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using RimWorld.Planet;
using Verse;
using Verse.AI;
using Verse.Sound;

namespace TemplateProject
{
    [StaticConstructorOnStartup]
    static public class HarmonyPatches
    {
        public static Harmony harmonyInstance;


        static HarmonyPatches()
        {
            harmonyInstance = new Harmony("rimworld.rwmods.TemplateProject");
            harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        }

    }


    [HarmonyPatch(typeof(Type))]
    [HarmonyPatch("Function")]
    internal static class DrawStaticButton
    {
        public static bool Prefix(ref Letter __instance, float topY)
        {
            __instance.def.bounce = false;          // Never bounce
            __instance.def.flashInterval = 0.0f;    // No flashing
            return true; // Use old code
        }
    }

}
