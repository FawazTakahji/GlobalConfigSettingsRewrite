using PropertyChanged.SourceGenerator;
using StardewModdingAPI;

namespace GlobalConfigSettingsRewrite.ViewModels.Settings;

public partial class ControlsSettings : ViewModelBase
{
    [Notify] private bool _controllerRumble;
    [Notify] private bool _invertToolbarScrollDirection;
    [Notify] private SButton _checkDoAction;
    [Notify] private SButton _useTool;
    [Notify] private SButton _accessMenu;
    [Notify] private SButton _accessJournal;
    [Notify] private SButton _accessMap;
    [Notify] private SButton _moveUp;
    [Notify] private SButton _moveLeft;
    [Notify] private SButton _moveDown;
    [Notify] private SButton _moveRight;
    [Notify] private SButton _chatBox;
    [Notify] private SButton _emoteMenu;
    [Notify] private SButton _run;
    [Notify] private SButton _shiftToolbar;
    [Notify] private SButton _inventorySlot1;
    [Notify] private SButton _inventorySlot2;
    [Notify] private SButton _inventorySlot3;
    [Notify] private SButton _inventorySlot4;
    [Notify] private SButton _inventorySlot5;
    [Notify] private SButton _inventorySlot6;
    [Notify] private SButton _inventorySlot7;
    [Notify] private SButton _inventorySlot8;
    [Notify] private SButton _inventorySlot9;
    [Notify] private SButton _inventorySlot10;
    [Notify] private SButton _inventorySlot11;
    [Notify] private SButton _inventorySlot12;

    public ControlsSettings(Config config)
    {
        ControllerRumble = config.ControllerRumble;
        InvertToolbarScrollDirection = config.InvertToolbarScrollDirection;
        CheckDoAction = config.CheckDoAction;
        UseTool = config.UseTool;
        AccessMenu = config.AccessMenu;
        AccessJournal = config.AccessJournal;
        AccessMap = config.AccessMap;
        MoveUp = config.MoveUp;
        MoveLeft = config.MoveLeft;
        MoveDown = config.MoveDown;
        MoveRight = config.MoveRight;
        ChatBox = config.ChatBox;
        EmoteMenu = config.EmoteMenu;
        Run = config.Run;
        ShiftToolbar = config.ShiftToolbar;
        InventorySlot1 = config.InventorySlot1;
        InventorySlot2 = config.InventorySlot2;
        InventorySlot3 = config.InventorySlot3;
        InventorySlot4 = config.InventorySlot4;
        InventorySlot5 = config.InventorySlot5;
        InventorySlot6 = config.InventorySlot6;
        InventorySlot7 = config.InventorySlot7;
        InventorySlot8 = config.InventorySlot8;
        InventorySlot9 = config.InventorySlot9;
        InventorySlot10 = config.InventorySlot10;
        InventorySlot11 = config.InventorySlot11;
        InventorySlot12 = config.InventorySlot12;
    }

    public void Save()
    {
        Mod.Config.ControllerRumble = ControllerRumble;
        Mod.Config.InvertToolbarScrollDirection = InvertToolbarScrollDirection;
        Mod.Config.CheckDoAction = CheckDoAction;
        Mod.Config.UseTool = UseTool;
        Mod.Config.AccessMenu = AccessMenu;
        Mod.Config.AccessJournal = AccessJournal;
        Mod.Config.AccessMap = AccessMap;
        Mod.Config.MoveUp = MoveUp;
        Mod.Config.MoveLeft = MoveLeft;
        Mod.Config.MoveDown = MoveDown;
        Mod.Config.MoveRight = MoveRight;
        Mod.Config.ChatBox = ChatBox;
        Mod.Config.EmoteMenu = EmoteMenu;
        Mod.Config.Run = Run;
        Mod.Config.ShiftToolbar = ShiftToolbar;
        Mod.Config.InventorySlot1 = InventorySlot1;
        Mod.Config.InventorySlot2 = InventorySlot2;
        Mod.Config.InventorySlot3 = InventorySlot3;
        Mod.Config.InventorySlot4 = InventorySlot4;
        Mod.Config.InventorySlot5 = InventorySlot5;
        Mod.Config.InventorySlot6 = InventorySlot6;
        Mod.Config.InventorySlot7 = InventorySlot7;
        Mod.Config.InventorySlot8 = InventorySlot8;
        Mod.Config.InventorySlot9 = InventorySlot9;
        Mod.Config.InventorySlot10 = InventorySlot10;
        Mod.Config.InventorySlot11 = InventorySlot11;
        Mod.Config.InventorySlot12 = InventorySlot12;
    }
}