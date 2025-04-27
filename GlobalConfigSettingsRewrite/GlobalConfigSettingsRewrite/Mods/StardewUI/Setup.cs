using GlobalConfigSettingsRewrite.ViewModels;
using StardewModdingAPI;
using StardewUI.Framework;

namespace GlobalConfigSettingsRewrite.Mods.StardewUI;

public static class Setup
{
    public static IViewEngine? GetApi(IModHelper helper)
    {
        try
        {
            var api = helper.ModRegistry.GetApi<IViewEngine>("focustense.StardewUI");
            if (api is null)
            {
                Mod.Logger.Log("Couldn't get StardewUI API.", LogLevel.Error);
            }

            return api;
        }
        catch (Exception ex)
        {
            Mod.Logger.Log($"Failed to get StardewUI API: {ex}", LogLevel.Error);
            return null;
        }
    }

    public static void Register(string uniqueId, IViewEngine api)
    {
        Api.ViewsPrefix = $"Mods/{uniqueId}/Views";
        api.RegisterViews(Api.ViewsPrefix, "assets/views");
#if DEBUG
        api.EnableHotReloadingWithSourceSync();
#endif
        api.PreloadAssets();
        api.PreloadModels(typeof(SettingsViewModel));
    }
}