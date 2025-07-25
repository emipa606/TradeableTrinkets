﻿using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace CM_Tradeable_Trinkets;

[HarmonyPatch(typeof(RecipeWorkerCounter), nameof(RecipeWorkerCounter.CountValidThings), typeof(List<Thing>),
    typeof(Bill_Production), typeof(ThingDef))]
public static class RecipeWorkerCounter_CountValidThings
{
    public static bool Prefix(RecipeWorkerCounter __instance, List<Thing> things, Bill_Production bill,
        ThingDef def, ref int __result)
    {
        // In the base game, this is only called when "Look Everywhere" is specified, and it doesn't include stack count so lets just completely override it to be correct
        var num = 0;
        foreach (var thing in things)
        {
            if (!__instance.CountValidThing(thing, bill, def))
            {
                continue;
            }

            var innerIfMinified = thing.GetInnerIfMinified();
            num += innerIfMinified.stackCount;
        }

        __result = num;

        return false;
    }
}