using GenericModConfigMenu;
using GlobalConfigSettingsRewrite.Utilities;
using Microsoft.Xna.Framework.Input;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace GlobalConfigSettingsRewrite;

internal sealed class Mod : StardewModdingAPI.Mod
{
    private IGenericModConfigMenuApi? ConfigMenu { get; set; }
    public static Config Config { get; set; } = null!;
    public static IMonitor Logger { get; set; } = null!;
    private static bool SaveCreated { get; set; }

    public override void Entry(IModHelper helper)
    {
        Logger = Monitor;
        I18n.Init(helper.Translation);
        Config = Helper.ReadConfig<Config>();
        helper.Events.GameLoop.GameLaunched += OnGameLaunched;
        helper.Events.Content.LocaleChanged += OnLocaleChanged;
        helper.Events.GameLoop.SaveCreated += OnSaveCreated;
        helper.Events.GameLoop.SaveLoaded += OnSaveLoaded;
    }

    private void OnGameLaunched(object? sender, GameLaunchedEventArgs e)
    {
        ConfigMenu = GMCM.GetApi(Helper);
        if (ConfigMenu is null)
        {
            return;
        }

        ConfigMenu.Register(ModManifest,
            () => Config = new Config(),
            () => Helper.WriteConfig(Config));
        GMCM.AddOptions(ConfigMenu, ModManifest);
    }

    private void OnLocaleChanged(object? sender, LocaleChangedEventArgs e)
    {
        if (ConfigMenu is null)
        {
            return;
        }

        ConfigMenu.Unregister(ModManifest);
        ConfigMenu.Register(ModManifest,
            () => Config = new Config(),
            () => Helper.WriteConfig(Config));
        GMCM.AddOptions(ConfigMenu, ModManifest);
    }

    private void OnSaveCreated(object? sender, SaveCreatedEventArgs e)
    {
        SaveCreated = true;
    }

    private void OnSaveLoaded(object? sender, SaveLoadedEventArgs e)
    {
        if (SaveCreated && Config.ApplyOnCreation)
        {
            SaveCreated = false;
            ApplySettings();
        }
        else if (Config.ApplyOnLoad)
        {
            ApplySettings();
        }
    }

    private static void ApplySettings()
    {
        if (Constants.SaveFolderName is not null && Config.UseWhitelist && !Config.Whitelist.Contains(Constants.SaveFolderName))
        {
            return;
        }
        if (Constants.SaveFolderName is not null && Config.UseBlacklist && Config.Blacklist.Contains(Constants.SaveFolderName))
        {
            return;
        }

        ApplyGeneral();
        ApplySound();
        ApplyGraphics();
        ApplyControls();
    }

    private static void ApplyGeneral()
    {
        Game1.options.changeCheckBoxOption(Options.toggleAutoRun, Config.AutoRun);
        Game1.options.changeCheckBoxOption(Options.showPortraitsToggle, Config.ShowPortraits);
        Game1.options.changeCheckBoxOption(Options.showMerchantPortraitsToggle, Config.ShowMerchantPortraits);
        Game1.options.changeCheckBoxOption(Options.alwaysShowToolHitLocationToggle, Config.AlwaysShowToolHitLocation);
        Game1.options.changeCheckBoxOption(Options.hideToolHitLocationWhenInMotionToggle, Config.HideToolHitLocationWhenInMotion);
        Game1.options.changeDropDownOption(Options.gamepadModeSelect, Config.GamepadMode switch
        {
            Options.GamepadModes.Auto => "auto",
            Options.GamepadModes.ForceOn => "force_on",
            Options.GamepadModes.ForceOff => "force_off",
            _ => "auto"
        });
        Game1.options.changeDropDownOption(Options.stowingModeSelect, Config.StowingMode switch
        {
            Options.ItemStowingModes.Off => "off",
            Options.ItemStowingModes.GamepadOnly => "gamepad",
            Options.ItemStowingModes.Both => "both",
            _ => "off"
        });
        Game1.options.changeDropDownOption(Options.slingshotModeSelect, Config.UseLegacySlingshotFiring ? "legacy" : "");
        Game1.options.changeCheckBoxOption(Options.toggleShowPlacementTileGamepad, Config.ShowPlacementTileForGamepad);
        Game1.options.changeCheckBoxOption(Options.pauseWhenUnfocused, Config.PauseWhenOutOfFocus);
        Game1.options.changeCheckBoxOption(Options.toggleSnappyMenus, Config.SnappyMenus);
        Game1.options.changeCheckBoxOption(Options.toggleShowAdvancedCraftingInformation, Config.ShowAdvancedCraftingInformation);
    }

    private static void ApplySound()
    {
        Game1.options.changeSliderOption(Options.musicVolume, Config.MusicVolume);
        Game1.options.changeSliderOption(Options.soundVolume, Config.SoundVolume);
        Game1.options.changeSliderOption(Options.ambientVolume, Config.AmbientVolume);
        Game1.options.changeSliderOption(Options.footstepVolume, Config.FootstepVolume);
        Game1.options.changeDropDownOption(Options.biteChime, Config.FishingBiteSound.ToString());
        Game1.options.changeCheckBoxOption(Options.toggleDialogueTypingSounds, Config.DialogueTypingSound);
        Game1.options.changeCheckBoxOption(Options.toggleMuteAnimalSounds, Config.MuteAnimalSounds);
    }

    private static void ApplyGraphics()
    {
        Game1.options.setBackgroundMode(Config.MenuBackgrounds);
        Game1.options.changeDropDownOption(Options.menuBG, Config.MenuBackgrounds);
        Game1.options.changeCheckBoxOption(Options.toggleVsync, Config.VSync);
        Game1.options.changeDropDownOption(Options.uiScaleSlider, Config.UiScale.ToString());
        Game1.options.changeCheckBoxOption(Options.pinToolbar, Config.LockToolbar);
        Game1.options.changeDropDownOption(Options.zoom, Config.ZoomLevel.ToString());
        Game1.options.changeCheckBoxOption(Options.zoomButtonsToggle, Config.ZoomButtons);
        Game1.options.changeSliderOption(Options.snowTransparencyToggle, Config.SnowTransparency);
        Game1.options.changeCheckBoxOption(Options.screenFlashToggle, Config.ShowFlashEffects);
        Game1.options.changeCheckBoxOption(Options.toggleHardwareCursor, Config.UseHardwareCursor);
    }

    private static void ApplyControls()
    {
        Game1.options.changeCheckBoxOption(Options.toggleRumble, Config.ControllerRumble);
        Game1.options.changeCheckBoxOption(Options.invertScrollDirectionToggle, Config.InvertToolbarScrollDirection);

        ApplyInputListener(Options.input_actionButton, Config.CheckDoAction);
        ApplyInputListener(Options.input_useToolButton, Config.UseTool);
        ApplyInputListener(Options.input_menuButton, Config.AccessMenu);
        ApplyInputListener(Options.input_journalButton, Config.AccessJournal);
        ApplyInputListener(Options.input_mapButton, Config.AccessMap);
        ApplyInputListener(Options.input_moveUpButton, Config.MoveUp);
        ApplyInputListener(Options.input_moveLeftButton, Config.MoveLeft);
        ApplyInputListener(Options.input_moveDownButton, Config.MoveDown);
        ApplyInputListener(Options.input_moveRightButton, Config.MoveRight);
        ApplyInputListener(Options.input_chatButton, Config.ChatBox);
        ApplyInputListener(Options.input_emoteButton, Config.EmoteMenu);
        ApplyInputListener(Options.input_runButton, Config.Run);
        ApplyInputListener(Options.input_toolbarSwap, Config.ShiftToolbar);
        ApplyInputListener(Options.input_slot1, Config.InventorySlot1);
        ApplyInputListener(Options.input_slot2, Config.InventorySlot2);
        ApplyInputListener(Options.input_slot3, Config.InventorySlot3);
        ApplyInputListener(Options.input_slot4, Config.InventorySlot4);
        ApplyInputListener(Options.input_slot5, Config.InventorySlot5);
        ApplyInputListener(Options.input_slot6, Config.InventorySlot6);
        ApplyInputListener(Options.input_slot7, Config.InventorySlot7);
        ApplyInputListener(Options.input_slot8, Config.InventorySlot8);
        ApplyInputListener(Options.input_slot9, Config.InventorySlot9);
        ApplyInputListener(Options.input_slot10, Config.InventorySlot10);
        ApplyInputListener(Options.input_slot11, Config.InventorySlot11);
        ApplyInputListener(Options.input_slot12, Config.InventorySlot12);
    }

    private static void ApplyInputListener(int whichListener, SButton button)
    {
        if (button.TryGetKeyboard(out Keys key))
        {
            Game1.options.changeInputListenerValue(whichListener, key);
        }
    }
}