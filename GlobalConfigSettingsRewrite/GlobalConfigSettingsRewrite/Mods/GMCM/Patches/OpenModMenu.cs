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
        controller.CloseAction = () => _openListMenu(listScrollRow);
        viewModel.Controller = controller;

        if (Game1.activeClickableMenu is TitleMenu titleMenu)
        {
            TitleMenu.subMenu = controller.Menu;
            titleMenu.titleInPosition = true;
        }
        else
        {
            Game1.activeClickableMenu = controller.Menu;
        }

        return false;
    }
}