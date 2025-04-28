using PropertyChanged.SourceGenerator;
using StardewValley;

namespace GlobalConfigSettingsRewrite.ViewModels.Settings;

public partial class GeneralSettings : ViewModelBase
{
    [Notify] private bool _autoRun;
    [Notify] private bool _showPortraits;
    [Notify] private bool _showMerchantPortraits;
    [Notify] private bool _alwaysShowToolHitLocation;
    [Notify] private bool _hideToolHitLocationWhenInMotion;
    [Notify] private Options.GamepadModes _gamepadMode;
    [Notify] private Options.ItemStowingModes _stowingMode;
    [Notify] private bool _useLegacySlingshotFiring;
    [Notify] private bool _showPlacementTileForGamepad;
    [Notify] private bool _pauseWhenOutOfFocus;
    [Notify] private bool _snappyMenus;
    [Notify] private bool _showAdvancedCraftingInformation;

    public Func<Options.GamepadModes, string> GamepadModeFormat { get; set; } = GamepadModesToString;
    public Func<Options.ItemStowingModes, string> StowingModeFormat { get; set; } = ItemStowingModesToString;
    public Func<bool, string> SlingshotFireModeFormat { get; set; } = arg => arg ? I18n.Game_Option_SlingshotFireMode_Pull() : I18n.Game_Option_SlingshotFireMode_Hold();

    public Options.GamepadModes[] GamepadModes { get; set; } = Enum.GetValues<Options.GamepadModes>();
    public Options.ItemStowingModes[] StowingModes { get; set; } = Enum.GetValues<Options.ItemStowingModes>();
    public bool[] SlingshotFireModes { get; set; } = { false, true };

    public GeneralSettings(Config config)
    {
        AutoRun = config.AutoRun;
        ShowPortraits = config.ShowPortraits;
        ShowMerchantPortraits = config.ShowMerchantPortraits;
        AlwaysShowToolHitLocation = config.AlwaysShowToolHitLocation;
        HideToolHitLocationWhenInMotion = config.HideToolHitLocationWhenInMotion;
        GamepadMode = config.GamepadMode;
        StowingMode = config.StowingMode;
        UseLegacySlingshotFiring = config.UseLegacySlingshotFiring;
        ShowPlacementTileForGamepad = config.ShowPlacementTileForGamepad;
        PauseWhenOutOfFocus = config.PauseWhenOutOfFocus;
        SnappyMenus = config.SnappyMenus;
        ShowAdvancedCraftingInformation = config.ShowAdvancedCraftingInformation;
    }

    public void Save()
    {
        Mod.Config.AutoRun = AutoRun;
        Mod.Config.ShowPortraits = ShowPortraits;
        Mod.Config.ShowMerchantPortraits = ShowMerchantPortraits;
        Mod.Config.AlwaysShowToolHitLocation = AlwaysShowToolHitLocation;
        Mod.Config.HideToolHitLocationWhenInMotion = HideToolHitLocationWhenInMotion;
        Mod.Config.GamepadMode = GamepadMode;
        Mod.Config.StowingMode = StowingMode;
        Mod.Config.UseLegacySlingshotFiring = UseLegacySlingshotFiring;
        Mod.Config.ShowPlacementTileForGamepad = ShowPlacementTileForGamepad;
        Mod.Config.PauseWhenOutOfFocus = PauseWhenOutOfFocus;
        Mod.Config.SnappyMenus = SnappyMenus;
        Mod.Config.ShowAdvancedCraftingInformation = ShowAdvancedCraftingInformation;
    }

    private static string GamepadModesToString(Options.GamepadModes arg)
    {
        return arg switch
        {
            Options.GamepadModes.Auto => I18n.Game_Option_GamepadMode_Auto(),
            Options.GamepadModes.ForceOn => I18n.Game_Option_GamepadMode_ForceOn(),
            Options.GamepadModes.ForceOff => I18n.Game_Option_GamepadMode_ForceOff(),
            _ => I18n.Other_Unknown()
        };
    }

    private static string ItemStowingModesToString(Options.ItemStowingModes arg)
    {
        return arg switch
        {
            Options.ItemStowingModes.Off => I18n.Game_Option_ItemStowing_Off(),
            Options.ItemStowingModes.GamepadOnly => I18n.Game_Option_ItemStowing_Gamepad(),
            Options.ItemStowingModes.Both => I18n.Game_Option_ItemStowing_On(),
            _ => I18n.Other_Unknown()
        };
    }
}