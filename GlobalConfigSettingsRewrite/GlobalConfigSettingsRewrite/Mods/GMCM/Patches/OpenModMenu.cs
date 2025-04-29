using System.Reflection;
using GlobalConfigSettingsRewrite.ViewModels;
using HarmonyLib;
using StardewModdingAPI;
using StardewUI.Framework;
using StardewValley;
using StardewValley.Menus;

namespace GlobalConfigSettingsRewrite.Mods.GMCM.Patches;

public static class OpenModMenu
{
    delegate void OpenListMenuDelegate(int? listScrollRow);
    private static OpenListMenuDelegate? _openListMenu;

    public static bool Prefix(object __instance, IManifest mod, int? listScrollRow)
    {
        if (mod != Mod.Manifest || Api.ViewEngine is null)
        {
            return true;
        }
        if (_openListMenu is null)
        {
            MethodInfo? openListMethod = AccessTools.Method(__instance.GetType(), "OpenListMenu");
            _openListMenu = openListMethod.CreateDelegate<OpenListMenuDelegate>(__instance);
        }

        SettingsViewModel viewModel = new();
        IMenuController controller = Api.ViewEngine.CreateMenuControllerFromAsset($"{Api.ViewsPrefix}/SettingsView", viewModel);
        viewModel.Controller = controller;

        if (Game1.activeClickableMenu is TitleMenu titleMenu)
        {
            TitleMenu.subMenu = controller.Menu;
            titleMenu.titleInPosition = true;
            controller.CloseAction = () =>
            {
                controller.Menu.exitThisMenu(false);
                OpenSettingsMenu(() => _openListMenu(listScrollRow));
            };
        }
        else
        {
            Game1.activeClickableMenu = controller.Menu;
            controller.CloseAction = () => _openListMenu(listScrollRow);
        }

        return false;
    }

    public static async Task OpenSettingsMenu(Action openListMenu)
    {
        try
        {
            await Task.Delay(1);
            openListMenu.Invoke();
        }
        catch (Exception ex)
        {
            Mod.Logger.Log($"Failed to open gmcm menu: {ex}", LogLevel.Error);
        }
    }
}