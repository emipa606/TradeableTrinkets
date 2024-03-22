using HarmonyLib;
using Verse;

namespace CM_Tradeable_Trinkets;

public class TrinketsMod : Mod
{
    public TrinketsMod(ModContentPack content) : base(content)
    {
        var harmony = new Harmony("CM_Tradeable_Trinkets");
        harmony.PatchAll();

        Instance = this;
    }

    public static TrinketsMod Instance { get; private set; }
}