using System.Reflection;
using UnityModManagerNet;
using Harmony12;

namespace TenderDoubleCapacity
{
    public class Main
    {
        static bool Load(UnityModManager.ModEntry modEntry)
        {
            var harmony = HarmonyInstance.Create(modEntry.Info.Id);
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            return true;
        }
    }

    [HarmonyPatch(typeof(TrainCar), "Awake")]
    class TrainCar_Awake_Patch
    {
        static void Prefix(TrainCar __instance)
        {
            if (__instance.carType == TrainCarType.Tender)
            {
                var sim = __instance.GetComponent<TenderSimulation>();

                if (sim)
                {
                    sim.tenderWater.max *= 2f;
                    sim.tenderWater.value *= 2f;
                    sim.tenderCoal.max *= 2f;
                    sim.tenderCoal.value *= 2f;
                }
            }
        }
    }
}