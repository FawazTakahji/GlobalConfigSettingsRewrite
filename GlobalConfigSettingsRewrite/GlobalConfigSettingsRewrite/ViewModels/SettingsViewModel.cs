using GlobalConfigSettingsRewrite.Models;
using GlobalConfigSettingsRewrite.Mods;
using GlobalConfigSettingsRewrite.Utilities;
using GlobalConfigSettingsRewrite.ViewModels.Settings;
using PropertyChanged.SourceGenerator;
using StardewModdingAPI;
using StardewUI.Framework;
using StardewValley;
using StardewValley.Menus;

namespace GlobalConfigSettingsRewrite.ViewModels;

public partial class SettingsViewModel : ViewModelBase
{
    public IMenuController? Controller;
    private readonly List<SaveData>? _saves;
    [Notify] private ModSettings _modSettings;
    [Notify] private GeneralSettings _general;

    public SettingsViewModel()
    {
        ModSettings = new(Mod.Config);
        General = new(Mod.Config);

        try
        {
            _saves = Saves.GetSaves().Select(save => new SaveData(save)).ToList();
        }
        catch (Exception ex)
        {
            Mod.Logger.Log($"Failed to get saves: {ex}", LogLevel.Error);
            _saves = null;
        }
    }

    public void Reset()
    {
        Config config = new Config();
        ModSettings = new(config);
        General = new(config);
    }

    public void Cancel()
    {
        Controller?.Close();
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

        Controller?.Close();
    }

    public void OpenSaveList(string which)
    {
        if (Api.ViewEngine is null)
        {
            Mod.Logger.Log("View engine is null", LogLevel.Warn);
            return;
        }

        SaveListViewModel viewModel;
        switch (which)
        {
            case "Whitelist":
                viewModel = new(_saves, _modSettings.Whitelist, list =>
                {
                    _modSettings.Whitelist = list.ToArray();
                });
                break;
            case "Blacklist":
                viewModel = new(_saves, _modSettings.Blacklist, list =>
                {
                    _modSettings.Blacklist = list.ToArray();
                });
                break;
            default:
                return;
        }

        IMenuController controller = Api.ViewEngine.CreateMenuControllerFromAsset($"{Api.ViewsPrefix}/SaveListView", viewModel);
        viewModel.Controller = controller;
        if (Game1.activeClickableMenu is TitleMenu titleMenu && TitleMenu.subMenu == Controller?.Menu)
        {
            titleMenu.SetChildMenu(controller.Menu);
        }
        else
        {
            Controller?.Menu.SetChildMenu(controller.Menu);
        }
    }
}