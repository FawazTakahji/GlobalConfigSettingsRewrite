using PropertyChanged.SourceGenerator;

namespace GlobalConfigSettingsRewrite.ViewModels.Settings;

public partial class SoundSettings : ViewModelBase
{
    [Notify] private int _musicVolume;
    [Notify] private int _soundVolume;
    [Notify] private int _ambientVolume;
    [Notify] private int _footstepVolume;
    [Notify] private int _fishingBiteSound;
    [Notify] private bool _dialogueTypingSound;
    [Notify] private bool _muteAnimalSounds;

    public int[] FishingBiteSounds { get; } = { -1, 0, 1, 2, 3 };
    public Func<int, string> FishingBiteSoundFormat { get; } = value => value switch
    {
        -1 => I18n.Game_Option_FishingBiteSound_Default(),
        0 => "1",
        1 => "2",
        2 => "3",
        3 => "4",
        _ => I18n.Other_Unknown()
    };

    public SoundSettings(Config config)
    {
        MusicVolume = config.MusicVolume;
        SoundVolume = config.SoundVolume;
        AmbientVolume = config.AmbientVolume;
        FootstepVolume = config.FootstepVolume;
        FishingBiteSound = config.FishingBiteSound;
        DialogueTypingSound = config.DialogueTypingSound;
        MuteAnimalSounds = config.MuteAnimalSounds;
    }

    public void Save()
    {
        Mod.Config.MusicVolume = MusicVolume;
        Mod.Config.SoundVolume = SoundVolume;
        Mod.Config.AmbientVolume = AmbientVolume;
        Mod.Config.FootstepVolume = FootstepVolume;
        Mod.Config.FishingBiteSound = FishingBiteSound;
        Mod.Config.DialogueTypingSound = DialogueTypingSound;
        Mod.Config.MuteAnimalSounds = MuteAnimalSounds;
    }
}