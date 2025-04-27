using PropertyChanged.SourceGenerator;
using StardewModdingAPI;
using StardewValley;

namespace GlobalConfigSettingsRewrite.ViewModels;

public partial class SettingsViewModel : ViewModelBase
{
    public Action? Close;
    [Notify] private ModSettings _modSettings;
    [Notify] private GeneralSettings _general;

    public SettingsViewModel()
    {
        ModSettings = new(Mod.Config);
        General = new(Mod.Config);
    }

    public void Reset()
    {
        Config config = new Config();
        ModSettings = new(config);
        General = new(config);
    }

    public void Cancel()
    {
        Close?.Invoke();
    }

    public void Save()
    {
        ModSettings.Save();
        General.Save();

        try
        {
            Mod.Helper.WriteConfig(Mod.Config);
        }
        catch (Exception ex)
        {
            Mod.Logger.Log($"Failed to save config: {ex}", LogLevel.Error);
        }

        Close?.Invoke();
    }
}

public partial class ModSettings : ViewModelBase
{
    [Notify] private bool _applyOnCreation;
    [Notify] private bool _applyOnLoad;
    [Notify] private bool _useWhitelist;
    [Notify] private string[] _whitelist;
    [Notify] private bool _useBlacklist;
    [Notify] private string[] _blacklist;

    public ModSettings(Config config)
    {
        ApplyOnCreation = config.ApplyOnCreation;
        ApplyOnLoad = config.ApplyOnLoad;
        UseWhitelist = config.UseWhitelist;
        Whitelist = config.Whitelist;
        UseBlacklist = config.UseBlacklist;
        Blacklist = config.Blacklist;
    }

    public void Save()
    {
        Mod.Config.ApplyOnCreation = ApplyOnCreation;
        Mod.Config.ApplyOnLoad = ApplyOnLoad;
        Mod.Config.UseWhitelist = UseWhitelist;
        Mod.Config.Whitelist = Whitelist;
        Mod.Config.UseBlacklist = UseBlacklist;
        Mod.Config.Blacklist = Blacklist;
    }
}

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
}