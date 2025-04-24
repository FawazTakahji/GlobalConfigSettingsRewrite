using StardewModdingAPI;
using StardewValley;

namespace GlobalConfigSettingsRewrite;

public sealed class Config
{
    public bool ApplyOnCreation { get; set; } = true;
    public bool ApplyOnLoad { get; set; } = true;
    public bool UseWhitelist { get; set; } = false;
    public bool UseBlacklist { get; set; } = false;
    public string[] Whitelist { get; set; } = Array.Empty<string>();
    public string[] Blacklist { get; set; } = Array.Empty<string>();

    // General
    public bool AutoRun { get; set; } = true;
    public bool ShowPortraits { get; set; } = true;
    public bool ShowMerchantPortraits { get; set; } = true;
    public bool AlwaysShowToolHitLocation { get; set; } = false;
    public bool HideToolHitLocationWhenInMotion { get; set; } = true;
    public Options.GamepadModes GamepadMode { get; set; } = Options.GamepadModes.Auto;
    public Options.ItemStowingModes StowingMode { get; set; } = Options.ItemStowingModes.Off;
    public bool UseLegacySlingshotFiring { get; set; } = false;
    public bool ShowPlacementTileForGamepad { get; set; } = true;
    public bool PauseWhenOutOfFocus { get; set; } = true;
    public bool SnappyMenus { get; set; } = true;
    public bool ShowAdvancedCraftingInformation { get; set; } = false;

    // Sound
    public int MusicVolume { get; set; } = 75;
    public int SoundVolume { get; set; } = 100;
    public int AmbientVolume { get; set; } = 75;
    public int FootstepVolume { get; set; } = 90;
    // -1, 0, 1, 2, 3
    public int FishingBiteSound { get; set; } = -1;
    public bool DialogueTypingSound { get; set; } = true;
    public bool MuteAnimalSounds { get; set; } = false;

    // Graphics
    // Standard, Graphical, None
    public string MenuBackgrounds { get; set; } = "Standard";
    public bool VSync { get; set; } = true;
    // 75-150
    public int UiScale { get; set; } = 100;
    public bool LockToolbar { get; set; } = false;
    // 75-200
    public int ZoomLevel { get; set; } = 100;
    public bool ZoomButtons { get; set; } = false;
    // 0-100
    public int SnowTransparency { get; set; } = 100;
    public bool ShowFlashEffects { get; set; } = true;
    public bool UseHardwareCursor { get; set; } = false;

    // Controls
    public bool ControllerRumble { get; set; } = true;
    public bool InvertToolbarScrollDirection { get; set; } = false;
    public SButton CheckDoAction { get; set; } = SButton.X;
    public SButton UseTool { get; set; } = SButton.C;
    public SButton AccessMenu { get; set; } = SButton.E;
    public SButton AccessJournal { get; set; } = SButton.F;
    public SButton AccessMap { get; set; } = SButton.M;
    public SButton MoveUp { get; set; } = SButton.W;
    public SButton MoveLeft { get; set; } = SButton.A;
    public SButton MoveDown { get; set; } = SButton.S;
    public SButton MoveRight { get; set; } = SButton.D;
    public SButton ChatBox { get; set; } = SButton.T;
    public SButton EmoteMenu { get; set; } = SButton.Y;
    public SButton Run { get; set; } = SButton.LeftShift;
    public SButton ShiftToolbar { get; set; } = SButton.Tab;
    public SButton InventorySlot1 { get; set; } = SButton.D1;
    public SButton InventorySlot2 { get; set; } = SButton.D2;
    public SButton InventorySlot3 { get; set; } = SButton.D3;
    public SButton InventorySlot4 { get; set; } = SButton.D4;
    public SButton InventorySlot5 { get; set; } = SButton.D5;
    public SButton InventorySlot6 { get; set; } = SButton.D6;
    public SButton InventorySlot7 { get; set; } = SButton.D7;
    public SButton InventorySlot8 { get; set; } = SButton.D8;
    public SButton InventorySlot9 { get; set; } = SButton.D9;
    public SButton InventorySlot10 { get; set; } = SButton.D0;
    public SButton InventorySlot11 { get; set; } = SButton.OemMinus;
    public SButton InventorySlot12 { get; set; } = SButton.OemPlus;
}