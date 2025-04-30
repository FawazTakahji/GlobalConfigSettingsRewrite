using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StarControl;
using StardewModdingAPI;
using StardewValley;
using StardewValley.ItemTypeDefinitions;

namespace GlobalConfigSettingsRewrite.Mods.StarControl;

public static class Setup
{
    public static IStarControlApi? GetApi(IModHelper helper)
    {
        try
        {
            var api = helper.ModRegistry.GetApi<IStarControlApi>("focustense.StarControl");
            if (api is null)
            {
                Mod.Logger.Log("Couldn't get the StarControl API.", LogLevel.Error);
            }

            return api;
        }
        catch (Exception ex)
        {
            Mod.Logger.Log($"Failed to get the StarControl API: {ex}", LogLevel.Error);
            return null;
        }
    }

    public static void Register(IStarControlApi api)
    {
        api.RegisterItems(
            Mod.Manifest,
            new []
            {
                new OpenMenuItem($"{Mod.Manifest.UniqueID}.OpenMenu")
            });
    }
}

internal class OpenMenuItem : IRadialMenuItem
{
    public string Id { get; }
    public string Title { get; } = "Global Config Settings Rewrite";
    public string Description => I18n.Other_OpenMenu();

    private readonly ParsedItemData _item = ItemRegistry.GetDataOrErrorItem("(O)867");
    public Texture2D? Texture => _item.GetTexture();
    public Rectangle? SourceRectangle => _item.GetSourceRect();

    public OpenMenuItem(string id)
    {
        Id = id;
    }

    public ItemActivationResult Activate(Farmer who, DelayedActions delayedActions, ItemActivationType activationType = ItemActivationType.Primary)
    {
        Mod.OpenMenu();
        return ItemActivationResult.Custom;
    }
}