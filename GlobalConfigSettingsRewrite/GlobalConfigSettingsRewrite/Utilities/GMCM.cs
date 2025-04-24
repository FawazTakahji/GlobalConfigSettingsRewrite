using GenericModConfigMenu;
using StardewModdingAPI;
using StardewValley;

namespace GlobalConfigSettingsRewrite.Utilities;

public static class GMCM
{
    public static IGenericModConfigMenuApi? GetApi(IModHelper helper)
    {
        try
        {
            var api = helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");
            if (api is null)
            {
                Mod.Logger.Log("Couldn't get GMCM API.", LogLevel.Error);
            }

            return api;
        }
        catch (Exception ex)
        {
            Mod.Logger.Log($"Failed to get GMCM API: {ex}", LogLevel.Error);
            return null;
        }
    }

    public static void AddOptions(IGenericModConfigMenuApi api, IManifest manifest)
    {
        AddModOptions(api, manifest);
        AddGeneralOptions(api, manifest);
        AddSoundOptions(api, manifest);
        AddGraphicsOptions(api, manifest);
        AddControlsOptions(api, manifest);
    }

    private static void AddModOptions(IGenericModConfigMenuApi api, IManifest manifest)
    {
        api.AddSectionTitle(manifest, I18n.Title_ModSettings);

        api.AddBoolOption(
            manifest,
            () => Mod.Config.ApplyOnCreation,
            value => Mod.Config.ApplyOnCreation = value,
            I18n.Setting_ApplyOnCreation,
            I18n.Setting_ApplyOnCreation_Tooltip);

        api.AddBoolOption(
            manifest,
            () => Mod.Config.ApplyOnLoad,
            value => Mod.Config.ApplyOnLoad = value,
            I18n.Setting_ApplyOnLoad,
            I18n.Setting_ApplyOnLoad_Tooltip);

        api.AddSectionTitle(manifest, I18n.Title_Filters);
        api.AddParagraph(manifest, I18n.Paragraph_Filters);

        api.AddBoolOption(
            manifest,
            () => Mod.Config.UseWhitelist,
            value => Mod.Config.UseWhitelist = value,
            I18n.Setting_Whitelist);
        api.AddTextOption(
            manifest,
            () => string.Join(",", Mod.Config.Whitelist),
            value => Mod.Config.Whitelist = value.Split(','),
            () => "");
        api.AddParagraph(manifest, I18n.Setting_Whitelist_Tooltip);

        api.AddBoolOption(
            manifest,
            () => Mod.Config.UseBlacklist,
            value => Mod.Config.UseBlacklist = value,
            I18n.Setting_Blacklist);
        api.AddTextOption(
            manifest,
            () => string.Join(",", Mod.Config.Blacklist),
            value => Mod.Config.Blacklist = value.Split(','),
            () => "");
        api.AddParagraph(manifest, I18n.Setting_Blacklist_Tooltip);
    }

    private static void AddGeneralOptions(IGenericModConfigMenuApi api, IManifest manifest)
    {
        api.AddSectionTitle(manifest, I18n.Game_Title_General);

        api.AddBoolOption(
            manifest,
            () => Mod.Config.AutoRun,
            value => Mod.Config.AutoRun = value,
            I18n.Game_Option_AutoRun);

        api.AddBoolOption(
            manifest,
            () => Mod.Config.ShowPortraits,
            value => Mod.Config.ShowPortraits = value,
            I18n.Game_Option_ShowPortraits);

        api.AddBoolOption(
            manifest,
            () => Mod.Config.ShowMerchantPortraits,
            value => Mod.Config.ShowMerchantPortraits = value,
            I18n.Game_Option_ShowMerchantPortraits);

        api.AddBoolOption(
            manifest,
            () => Mod.Config.AlwaysShowToolHitLocation,
            value => Mod.Config.AlwaysShowToolHitLocation = value,
            I18n.Game_Option_AlwaysShowToolHitLocation);

        api.AddBoolOption(
            manifest,
            () => Mod.Config.HideToolHitLocationWhenInMotion,
            value => Mod.Config.HideToolHitLocationWhenInMotion = value,
            I18n.Game_Option_HideToolHitLocationWhenMoving);

        api.AddTextOption(
            manifest,
            () => GamepadModeToString(Mod.Config.GamepadMode),
            value => Mod.Config.GamepadMode = StringToGamepadMode(value),
            I18n.Game_Option_GamepadMode,
            allowedValues: new []
            {
                I18n.Game_Option_GamepadMode_Auto(),
                I18n.Game_Option_GamepadMode_ForceOn(),
                I18n.Game_Option_GamepadMode_ForceOff()
            });

        api.AddTextOption(
            manifest,
            () => ItemStowingModeToString(Mod.Config.StowingMode),
            value => Mod.Config.StowingMode = StringToItemStowingMode(value),
            I18n.Game_Option_ItemStowing,
            allowedValues: new []
            {
                I18n.Game_Option_ItemStowing_Off(),
                I18n.Game_Option_ItemStowing_Gamepad(),
                I18n.Game_Option_ItemStowing_On()
            });

        api.AddTextOption(
            manifest,
            () => SlingshotFireModeToString(Mod.Config.UseLegacySlingshotFiring),
            value => Mod.Config.UseLegacySlingshotFiring = StringToSlingshotFireMode(value),
            I18n.Game_Option_SlingshotFireMode,
            allowedValues: new []
            {
                I18n.Game_Option_SlingshotFireMode_Hold(),
                I18n.Game_Option_SlingshotFireMode_Pull()
            });

        api.AddBoolOption(
            manifest,
            () => Mod.Config.ShowPlacementTileForGamepad,
            value => Mod.Config.ShowPlacementTileForGamepad = value,
            I18n.Game_Option_ControllerPlacementTileIndicator);

        api.AddBoolOption(
            manifest,
            () => Mod.Config.PauseWhenOutOfFocus,
            value => Mod.Config.PauseWhenOutOfFocus = value,
            I18n.Game_Option_PauseWhenGameWindowIsInactive);

        api.AddBoolOption(
            manifest,
            () => Mod.Config.SnappyMenus,
            value => Mod.Config.SnappyMenus = value,
            I18n.Game_Option_UseControllerStyleMenus);

        api.AddBoolOption(
            manifest,
            () => Mod.Config.ShowAdvancedCraftingInformation,
            value => Mod.Config.ShowAdvancedCraftingInformation = value,
            I18n.Game_Option_ShowAdvancedCraftingInformation);
    }

    private static void AddSoundOptions(IGenericModConfigMenuApi api, IManifest manifest)
    {
        api.AddSectionTitle(manifest, I18n.Game_Title_Sound);

        api.AddNumberOption(
            manifest,
            () => Mod.Config.MusicVolume,
            value => Mod.Config.MusicVolume = value,
            I18n.Game_Option_MusicVolume,
            min: 0,
            max: 100);

        api.AddNumberOption(
            manifest,
            () => Mod.Config.SoundVolume,
            value => Mod.Config.SoundVolume = value,
            I18n.Game_Option_SoundVolume,
            min: 0,
            max: 100);

        api.AddNumberOption(
            manifest,
            () => Mod.Config.AmbientVolume,
            value => Mod.Config.AmbientVolume = value,
            I18n.Game_Option_AmbientVolume,
            min: 0,
            max: 100);

        api.AddNumberOption(
            manifest,
            () => Mod.Config.FootstepVolume,
            value => Mod.Config.FootstepVolume = value,
            I18n.Game_Option_FootstepVolume,
            min: 0,
            max: 100);

        api.AddTextOption(
            manifest,
            () => FishingBiteSoundToString(Mod.Config.FishingBiteSound),
            value => Mod.Config.FishingBiteSound = StringToFishingBiteSound(value),
            I18n.Game_Option_FishingBiteSound,
            allowedValues: new[]
            {
                I18n.Game_Option_FishingBiteSound_Default(),
                "1",
                "2",
                "3",
                "4"
            });

        api.AddBoolOption(
            manifest,
            () => Mod.Config.DialogueTypingSound,
            value => Mod.Config.DialogueTypingSound = value,
            I18n.Game_Option_DialogueTypingSound);

        api.AddBoolOption(
            manifest,
            () => Mod.Config.MuteAnimalSounds,
            value => Mod.Config.MuteAnimalSounds = value,
            I18n.Game_Option_MuteAnimalSounds);
    }

    private static void AddGraphicsOptions(IGenericModConfigMenuApi api, IManifest manifest)
    {
        api.AddSectionTitle(manifest, I18n.Game_Title_Graphics);

        api.AddTextOption(
            manifest,
            () => MenuBackgroundToString(Mod.Config.MenuBackgrounds),
            value => Mod.Config.MenuBackgrounds = StringToMenuBackground(value),
            I18n.Game_Option_MenuBackgrounds,
            allowedValues: new[]
            {
                I18n.Game_Option_MenuBackgrounds_Standard(),
                I18n.Game_Option_MenuBackgrounds_Graphical(),
                I18n.Game_Option_MenuBackgrounds_None()
            });

        api.AddBoolOption(
            manifest,
            () => Mod.Config.VSync,
            value => Mod.Config.VSync = value,
            I18n.Game_Option_Vsync);

        api.AddNumberOption(
            manifest,
            () => Mod.Config.UiScale,
            value => Mod.Config.UiScale = value,
            I18n.Game_Option_UiScale,
            min: 75,
            max: 150,
            interval: 5);

        api.AddBoolOption(
            manifest,
            () => Mod.Config.LockToolbar,
            value => Mod.Config.LockToolbar = value,
            I18n.Game_Option_LockToolbar);

        api.AddNumberOption(
            manifest,
            () => Mod.Config.ZoomLevel,
            value => Mod.Config.ZoomLevel = value,
            I18n.Game_Option_ZoomLevel,
            min: 75,
            max: 200,
            interval: 5);

        api.AddBoolOption(
            manifest,
            () => Mod.Config.ZoomButtons,
            value => Mod.Config.ZoomButtons = value,
            I18n.Game_Option_ZoomButtons);

        api.AddNumberOption(
            manifest,
            () => Mod.Config.SnowTransparency,
            value => Mod.Config.SnowTransparency = value,
            I18n.Game_Option_SnowTransparency,
            min: 0,
            max: 100);

        api.AddBoolOption(
            manifest,
            () => Mod.Config.ShowFlashEffects,
            value => Mod.Config.ShowFlashEffects = value,
            I18n.Game_Option_ShowFlashEffects);

        api.AddBoolOption(
            manifest,
            () => Mod.Config.UseHardwareCursor,
            value => Mod.Config.UseHardwareCursor = value,
            I18n.Game_Option_UseHardwareCursor);
    }

    private static void AddControlsOptions(IGenericModConfigMenuApi api, IManifest manifest)
    {
        api.AddSectionTitle(manifest, I18n.Game_Title_Controls);

        api.AddBoolOption(
            manifest,
            () => Mod.Config.ControllerRumble,
            value => Mod.Config.ControllerRumble = value,
            I18n.Game_Option_ControllerRumble);

        api.AddBoolOption(
            manifest,
            () => Mod.Config.InvertToolbarScrollDirection,
            value => Mod.Config.InvertToolbarScrollDirection = value,
            I18n.Game_Option_InvertToolbarScrollDirection);

        api.AddKeybind(
            manifest,
            () => Mod.Config.CheckDoAction,
            value => Mod.Config.CheckDoAction = value,
            I18n.Game_Option_CheckDoAction);

        api.AddKeybind(
            manifest,
            () => Mod.Config.UseTool,
            value => Mod.Config.UseTool = value,
            I18n.Game_Option_UseTool);

        api.AddKeybind(
            manifest,
            () => Mod.Config.AccessMenu,
            value => Mod.Config.AccessMenu = value,
            I18n.Game_Option_AccessMenu);

        api.AddKeybind(
            manifest,
            () => Mod.Config.AccessJournal,
            value => Mod.Config.AccessJournal = value,
            I18n.Game_Option_AccessJournal);

        api.AddKeybind(
            manifest,
            () => Mod.Config.AccessMap,
            value => Mod.Config.AccessMap = value,
            I18n.Game_Option_AccessMap);

        api.AddKeybind(
            manifest,
            () => Mod.Config.MoveUp,
            value => Mod.Config.MoveUp = value,
            I18n.Game_Option_MoveUp);

        api.AddKeybind(
            manifest,
            () => Mod.Config.MoveLeft,
            value => Mod.Config.MoveLeft = value,
            I18n.Game_Option_MoveLeft);

        api.AddKeybind(
            manifest,
            () => Mod.Config.MoveDown,
            value => Mod.Config.MoveDown = value,
            I18n.Game_Option_MoveDown);

        api.AddKeybind(
            manifest,
            () => Mod.Config.MoveRight,
            value => Mod.Config.MoveRight = value,
            I18n.Game_Option_MoveRight);

        api.AddKeybind(
            manifest,
            () => Mod.Config.ChatBox,
            value => Mod.Config.ChatBox = value,
            I18n.Game_Option_ChatBox);

        api.AddKeybind(
            manifest,
            () => Mod.Config.EmoteMenu,
            value => Mod.Config.EmoteMenu = value,
            I18n.Game_Option_EmoteMenu);

        api.AddKeybind(
            manifest,
            () => Mod.Config.Run,
            value => Mod.Config.Run = value,
            I18n.Game_Option_Run);

        api.AddKeybind(
            manifest,
            () => Mod.Config.ShiftToolbar,
            value => Mod.Config.ShiftToolbar = value,
            I18n.Game_Option_ShiftToolbar);

        api.AddKeybind(
            manifest,
            () => Mod.Config.InventorySlot1,
            value => Mod.Config.InventorySlot1 = value,
            I18n.Game_Option_InventorySlot1);

        api.AddKeybind(
            manifest,
            () => Mod.Config.InventorySlot2,
            value => Mod.Config.InventorySlot2 = value,
            I18n.Game_Option_InventorySlot2);

        api.AddKeybind(
            manifest,
            () => Mod.Config.InventorySlot3,
            value => Mod.Config.InventorySlot3 = value,
            I18n.Game_Option_InventorySlot3);

        api.AddKeybind(
            manifest,
            () => Mod.Config.InventorySlot4,
            value => Mod.Config.InventorySlot4 = value,
            I18n.Game_Option_InventorySlot4);

        api.AddKeybind(
            manifest,
            () => Mod.Config.InventorySlot5,
            value => Mod.Config.InventorySlot5 = value,
            I18n.Game_Option_InventorySlot5);

        api.AddKeybind(
            manifest,
            () => Mod.Config.InventorySlot6,
            value => Mod.Config.InventorySlot6 = value,
            I18n.Game_Option_InventorySlot6);

        api.AddKeybind(
            manifest,
            () => Mod.Config.InventorySlot7,
            value => Mod.Config.InventorySlot7 = value,
            I18n.Game_Option_InventorySlot7);

        api.AddKeybind(
            manifest,
            () => Mod.Config.InventorySlot8,
            value => Mod.Config.InventorySlot8 = value,
            I18n.Game_Option_InventorySlot8);

        api.AddKeybind(
            manifest,
            () => Mod.Config.InventorySlot9,
            value => Mod.Config.InventorySlot9 = value,
            I18n.Game_Option_InventorySlot9);

        api.AddKeybind(
            manifest,
            () => Mod.Config.InventorySlot10,
            value => Mod.Config.InventorySlot10 = value,
            I18n.Game_Option_InventorySlot10);

        api.AddKeybind(
            manifest,
            () => Mod.Config.InventorySlot11,
            value => Mod.Config.InventorySlot11 = value,
            I18n.Game_Option_InventorySlot11);

        api.AddKeybind(
            manifest,
            () => Mod.Config.InventorySlot12,
            value => Mod.Config.InventorySlot12 = value,
            I18n.Game_Option_InventorySlot12);
    }

    private static string GamepadModeToString(Options.GamepadModes mode)
    {
        return mode switch
        {
            Options.GamepadModes.Auto => I18n.Game_Option_GamepadMode_Auto(),
            Options.GamepadModes.ForceOn => I18n.Game_Option_GamepadMode_ForceOn(),
            Options.GamepadModes.ForceOff => I18n.Game_Option_GamepadMode_ForceOff(),
            _ => I18n.Other_Unknown()
        };
    }

    private static Options.GamepadModes StringToGamepadMode(string mode)
    {
        if (mode == I18n.Game_Option_GamepadMode_Auto())
        {
            return Options.GamepadModes.Auto;
        }

        if (mode == I18n.Game_Option_GamepadMode_ForceOn())
        {
            return Options.GamepadModes.ForceOn;
        }

        if (mode == I18n.Game_Option_GamepadMode_ForceOff())
        {
            return Options.GamepadModes.ForceOff;
        }

        return Options.GamepadModes.Auto;
    }

    private static string ItemStowingModeToString(Options.ItemStowingModes mode)
    {
        return mode switch
        {
            Options.ItemStowingModes.Off => I18n.Game_Option_ItemStowing_Off(),
            Options.ItemStowingModes.GamepadOnly => I18n.Game_Option_ItemStowing_Gamepad(),
            Options.ItemStowingModes.Both => I18n.Game_Option_ItemStowing_On(),
            _ => I18n.Other_Unknown()
        };
    }

    private static Options.ItemStowingModes StringToItemStowingMode(string mode)
    {
        if (mode == I18n.Game_Option_ItemStowing_Off())
        {
            return Options.ItemStowingModes.Off;
        }

        if (mode == I18n.Game_Option_ItemStowing_Gamepad())
        {
            return Options.ItemStowingModes.GamepadOnly;
        }

        if (mode == I18n.Game_Option_ItemStowing_On())
        {
            return Options.ItemStowingModes.Both;
        }

        return Options.ItemStowingModes.Off;
    }

    private static string SlingshotFireModeToString(bool mode)
    {
        return mode switch
        {
            true => I18n.Game_Option_SlingshotFireMode_Pull(),
            false => I18n.Game_Option_SlingshotFireMode_Hold()
        };
    }

    private static bool StringToSlingshotFireMode(string mode)
    {
        return mode == I18n.Game_Option_SlingshotFireMode_Pull();
    }

    private static string FishingBiteSoundToString(int sound)
    {
        return sound switch
        {
            -1 => I18n.Game_Option_FishingBiteSound_Default(),
            0 => "1",
            1 => "2",
            2 => "3",
            3 => "4",
            _ => I18n.Game_Option_FishingBiteSound_Default()
        };
    }

    private static int StringToFishingBiteSound(string sound)
    {
        return sound switch
        {
            "1" => 0,
            "2" => 1,
            "3" => 2,
            "4" => 3,
            _ => -1
        };
    }

    private static string MenuBackgroundToString(string background)
    {
        return background switch
        {
            "Standard" => I18n.Game_Option_MenuBackgrounds_Standard(),
            "Graphical" => I18n.Game_Option_MenuBackgrounds_Graphical(),
            "None" => I18n.Game_Option_MenuBackgrounds_None(),
            _ => I18n.Other_Unknown()
        };
    }

    private static string StringToMenuBackground(string background)
    {
        if (background == I18n.Game_Option_MenuBackgrounds_Standard())
        {
            return "Standard";
        }

        if (background == I18n.Game_Option_MenuBackgrounds_Graphical())
        {
            return "Graphical";
        }

        if (background == I18n.Game_Option_MenuBackgrounds_None())
        {
            return "None";
        }

        return "Standard";
    }
}