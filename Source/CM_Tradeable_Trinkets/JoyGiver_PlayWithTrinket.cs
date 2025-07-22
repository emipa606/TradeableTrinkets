using System;
using System.Collections.Generic;
using RimWorld;
using Verse;
using Verse.AI;

namespace CM_Tradeable_Trinkets;

public class JoyGiver_PlayWithTrinket : JoyGiver
{
    private static readonly List<Thing> tmpCandidates = [];

    public override Job TryGiveJob(Pawn pawn)
    {
        return tryGiveJobInternal(pawn, null);
    }

    public override Job TryGiveJobInGatheringArea(Pawn pawn, IntVec3 gatheringSpot, float maxRadius = -1f)
    {
        return tryGiveJobInternal(pawn,
            x => !x.Spawned || GatheringsUtility.InGatheringArea(x.Position, gatheringSpot, pawn.Map) &&
                (maxRadius < 0f || x.Position.InHorDistOf(gatheringSpot, maxRadius)));
    }

    private Job tryGiveJobInternal(Pawn pawn, Predicate<Thing> extraValidator)
    {
        var thing = BestTrinket(pawn, extraValidator);
        return thing != null ? CreateJob(thing, pawn) : null;
    }

    protected virtual Thing BestTrinket(Pawn pawn, Predicate<Thing> extraValidator)
    {
        var innerContainer = pawn.inventory.innerContainer;
        foreach (var trinket in innerContainer)
        {
            if (SearchSetWouldInclude(trinket) && predicate(trinket))
            {
                return trinket;
            }
        }

        tmpCandidates.Clear();
        GetSearchSet(pawn, tmpCandidates);
        if (tmpCandidates.Count == 0)
        {
            return null;
        }

        var result = GenClosest.ClosestThing_Global_Reachable(pawn.Position, pawn.Map, tmpCandidates,
            PathEndMode.OnCell, TraverseParms.For(pawn), 9999f, predicate);
        tmpCandidates.Clear();
        return result;

        bool predicate(Thing t)
        {
            if (!t.Spawned)
            {
                return extraValidator == null || extraValidator(t);
            }

            if (!pawn.CanReserve(t))
            {
                return false;
            }

            if (t.IsForbidden(pawn))
            {
                return false;
            }

            if (!t.IsSociallyProper(pawn))
            {
                return false;
            }

            if (!t.IsPoliticallyProper(pawn))
            {
                return false;
            }

            return extraValidator == null || extraValidator(t);
        }
    }

    protected virtual bool SearchSetWouldInclude(Thing thing)
    {
        return def.thingDefs != null && def.thingDefs.Contains(thing.def);
    }

    protected virtual Job CreateJob(Thing trinket, Pawn pawn)
    {
        var job = JobMaker.MakeJob(TrinketsModDefOf.CM_Tradeable_Trinkets_Job_PlayWithTrinket, trinket);
        job.count = 1;
        return job;
    }
}