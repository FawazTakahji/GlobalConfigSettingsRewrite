using System.Reflection;
using GenericModConfigMenu;
using HarmonyLib;
using StardewModdingAPI;

namespace GlobalConfigSettingsRewrite.Mods.GMCM.Patches;

public static class Patcher
{
    public static void Patch(string uniqueId, IGenericModConfigMenuApi api)
    {
        MethodInfo? openModMenuMethod;
        MethodInfo? openModMenuNewMethod;

        try
        {
            Assembly assembly = new Traverse(api).Field("__Target").GetValue().GetType().Assembly;
            Type modType = assembly.GetTypes().First(type => typeof(StardewModdingAPI.Mod).IsAssignableFrom(type));
            openModMenuMethod = AccessTools.Method(modType, "OpenModMenu");
            openModMenuNewMethod = AccessTools.Method(modType, "OpenModMenuNew");
        }
        catch (Exception ex)
        {
            Mod.Logger.Log(
                $"An error occurred while trying to retrieve GMCM methods: {ex}",
                LogLevel.Warn);
            return;
        }

        Harmony harmony = new($"{uniqueId}-GMCM");
        if (openModMenuMethod is not null)
        {
            harmony.Patch(
                openModMenuMethod,
                prefix: new(typeof(OpenModMenu), nameof(OpenModMenu.Prefix)));
            Mod.Logger.Log("Patched GMCM OpenModMenu.", LogLevel.Info);
        }

        if (openModMenuNewMethod is not null)
        {
            harmony.Patch(
                openModMenuNewMethod,
                prefix: new(typeof(OpenModMenu), nameof(OpenModMenu.Prefix)));
            Mod.Logger.Log("Patched GMCM OpenModMenuNew.", LogLevel.Info);
        }
    }
}