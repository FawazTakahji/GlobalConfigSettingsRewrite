using GenericModConfigMenu;
using LeFauxMods.Common.Integrations.IconicFramework;
using StardewUI.Framework;

namespace GlobalConfigSettingsRewrite.Mods;

public static class Api
{
    public static IGenericModConfigMenuApi? GMCM = null;

    public static IViewEngine? ViewEngine = null;
    public static string ViewsPrefix = "Mods/FawazT.GlobalConfigSettingsRewrite/Views";

    public static IIconicFrameworkApi? IconicFramework = null;
}