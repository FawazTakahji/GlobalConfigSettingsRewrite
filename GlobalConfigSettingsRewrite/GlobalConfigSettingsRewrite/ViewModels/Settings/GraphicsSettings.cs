using PropertyChanged.SourceGenerator;

namespace GlobalConfigSettingsRewrite.ViewModels.Settings;

public partial class GraphicsSettings : ViewModelBase
{
    [Notify] private string _menuBackgrounds;
    [Notify] private bool _vsync;
    [Notify] private int _uiScale;
    [Notify] private bool _lockToolbar;
    [Notify] private int _zoomLevel;
    [Notify] private bool _zoomButtons;
    [Notify] private int _snowTransparency;
    [Notify] private bool _showFlashEffects;
    [Notify] private bool _useHardwareCursor;

    public string[] Backgrounds { get; } = { "Standard", "Graphical", "None" };
    public Func<string, string> BackgroundFormat { get; } = arg => arg switch
    {
        "Standard" => I18n.Game_Option_MenuBackgrounds_Standard(),
        "Graphical" => I18n.Game_Option_MenuBackgrounds_Graphical(),
        "None" => I18n.Game_Option_MenuBackgrounds_None(),
        _ => I18n.Other_Unknown()
    };

    public GraphicsSettings(Config config)
    {
        MenuBackgrounds = config.MenuBackgrounds;
        Vsync = config.VSync;
        UiScale = config.UiScale;
        LockToolbar = config.LockToolbar;
        ZoomLevel = config.ZoomLevel;
        ZoomButtons = config.ZoomButtons;
        SnowTransparency = config.SnowTransparency;
        ShowFlashEffects = config.ShowFlashEffects;
        UseHardwareCursor = config.UseHardwareCursor;
    }

    public void Save()
    {
        Mod.Config.MenuBackgrounds = MenuBackgrounds;
        Mod.Config.VSync = Vsync;
        Mod.Config.UiScale = UiScale;
        Mod.Config.LockToolbar = LockToolbar;
        Mod.Config.ZoomLevel = ZoomLevel;
        Mod.Config.ZoomButtons = ZoomButtons;
        Mod.Config.SnowTransparency = SnowTransparency;
        Mod.Config.ShowFlashEffects = ShowFlashEffects;
        Mod.Config.UseHardwareCursor = UseHardwareCursor;
    }
}