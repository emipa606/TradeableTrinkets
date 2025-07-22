using System.Reflection;
using HarmonyLib;
using Verse;

namespace CM_Tradeable_Trinkets;

public class TrinketsMod : Mod
{
    public TrinketsMod(ModContentPack content) : base(content)
    {
        new Harmony("CM_Tradeable_Trinkets").PatchAll(Assembly.GetExecutingAssembly());
    }
}