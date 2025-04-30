using LeFauxMods.Common.Integrations.IconicFramework;
using StardewModdingAPI;
using StardewValley;
using StardewValley.ItemTypeDefinitions;

namespace GlobalConfigSettingsRewrite.Mods.IconicFramework;

public static class Setup
{
    public static IIconicFrameworkApi? GetApi(IModHelper helper)
    {
        try
        {
            var api = helper.ModRegistry.GetApi<IIconicFrameworkApi>("furyx639.ToolbarIcons");
            if (api is null)
            {
                Mod.Logger.Log("Couldn't get the IconicFramework API.", LogLevel.Error);
            }

            return api;
        }
        catch (Exception ex)
        {
            Mod.Logger.Log($"Failed to get the IconicFramework API: {ex}", LogLevel.Error);
            return null;
        }
    }

    public static void Register(IIconicFrameworkApi api)
    {
        ParsedItemData itemData = ItemRegistry.GetDataOrErrorItem("(O)867");

        api.AddToolbarIcon(
            Mod.Manifest.UniqueID,
            itemData.GetTextureName(),
            itemData.GetSourceRect(),
            () => "Global Config Settings Rewrite",
            I18n.Other_OpenMenu);

        api.Subscribe(e =>
        {
            if (e.Id != Mod.Manifest.UniqueID)
            {
                return;
            }

            Mod.OpenMenu();
        });
    }
}