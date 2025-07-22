using HarmonyLib;
using RimWorld;
using Verse;

namespace CM_Tradeable_Trinkets;

[HarmonyPatch(typeof(StatExtension), nameof(StatExtension.GetStatValue), MethodType.Normal)]
public static class StatExtension_GetStatValue
{
    public static void Postfix(Thing thing, StatDef stat, ref float __result)
    {
        // We'll just get an error if not in the play state
        if (Current.ProgramState != ProgramState.Playing)
        {
            return;
        }

        if (stat != StatDefOf.MarketValue && stat != StatDefOf.MarketValueIgnoreHp)
        {
            return;
        }

        if (thing is not Trinket || thing.Stuff == null || thing.def.costStuffCount <= 0)
        {
            return;
        }

        var stuffValue = thing.Stuff.BaseMarketValue;
        var valuePerStuff = __result / thing.def.costStuffCount;
        var newValue = stuffValue * valuePerStuff * thing.def.costStuffCount;

        __result = newValue;
    }
}