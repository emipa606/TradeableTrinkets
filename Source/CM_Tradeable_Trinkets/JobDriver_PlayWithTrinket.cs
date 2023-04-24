using System.Collections.Generic;
using RimWorld;
using Verse;
using Verse.AI;

namespace CM_Tradeable_Trinkets;

public class JobDriver_PlayWithTrinket : JobDriver
{
    protected Thing Trinket => job.GetTarget(TargetIndex.A).Thing;

    public override bool TryMakePreToilReservations(bool errorOnFailed)
    {
        return pawn.Reserve(Trinket, job, 1, -1, null, errorOnFailed);
    }

    protected override IEnumerable<Toil> MakeNewToils()
    {
        var joyGainFactor = Trinket.GetStatValue(StatDefOf.JoyGainFactor);

        //Log.Message(string.Format("JobDriver_PlayWithTrinket.MakeNewToils: {0} playing with {1}, joyGainFactor: {2}", pawn, Trinket, joyGainFactor));

        var reserveTrinket = Toils_Reserve.Reserve(TargetIndex.A);
        yield return reserveTrinket;
        yield return Toils_Goto.GotoThing(TargetIndex.A, PathEndMode.ClosestTouch)
            .FailOnDespawnedNullOrForbidden(TargetIndex.A).FailOnSomeonePhysicallyInteracting(TargetIndex.A);
        yield return Toils_Haul.StartCarryThing(TargetIndex.A, false, true)
            .FailOnDestroyedNullOrForbidden(TargetIndex.A);

        var toil = new Toil
        {
            tickAction = delegate
            {
                if (pawn.IsHashIntervalTick(60))
                {
                    var socialTarget = FindClosePawn();
                    if (socialTarget != null)
                    {
                        pawn.rotationTracker.FaceCell(socialTarget.Position);
                    }
                }

                pawn.GainComfortFromCellIfPossible();

                JoyUtility.JoyTickCheckEnd(pawn, JoyTickFullJoyAction.EndJob, joyGainFactor);
            },
            socialMode = RandomSocialMode.SuperActive,
            defaultCompleteMode = ToilCompleteMode.Delay,
            defaultDuration = job.def.joyDuration,
            handlingFacing = true
        };
        yield return toil;
    }

    private Pawn FindClosePawn()
    {
        var position = pawn.Position;
        for (var i = 0; i < 24; i++)
        {
            var intVec = position + GenRadial.RadialPattern[i];
            if (!intVec.InBounds(Map))
            {
                continue;
            }

            var thing = intVec.GetThingList(Map).Find(x => x is Pawn);
            if (thing != null && thing != pawn && GenSight.LineOfSight(position, intVec, Map))
            {
                return (Pawn)thing;
            }
        }

        return null;
    }
}