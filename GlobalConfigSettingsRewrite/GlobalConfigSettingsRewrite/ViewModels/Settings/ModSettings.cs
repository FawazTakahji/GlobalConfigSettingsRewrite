using PropertyChanged.SourceGenerator;

namespace GlobalConfigSettingsRewrite.ViewModels.Settings;

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