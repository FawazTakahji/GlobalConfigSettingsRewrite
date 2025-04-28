using GlobalConfigSettingsRewrite.Models;
using GlobalConfigSettingsRewrite.Utilities;
using PropertyChanged.SourceGenerator;
using StardewModdingAPI;
using StardewUI.Framework;
using StardewValley.Extensions;

namespace GlobalConfigSettingsRewrite.ViewModels;

public partial class SaveListViewModel : ViewModelBase
{
    public IMenuController? Controller;
    private readonly Action<List<string>> _setList;
    private readonly List<SaveData> _saves;
    [Notify] private List<SaveData> _notSelectedSaves;
    [Notify] private List<SaveData> _selectedSaves;

    public SaveListViewModel(List<SaveData>? saves, string[] selectedSaves, Action<List<string>> setList)
    {
        if (saves is null)
        {
            try
            {
                _saves = Saves.GetSaves().Select(save => new SaveData(save)).ToList();
            }
            catch (Exception ex)
            {
                Mod.Logger.Log($"Failed to get saves: {ex}", LogLevel.Error);
                _saves = new List<SaveData>();
            }
        }
        else
        {
            _saves = saves.ToList();
        }
        _setList = setList;

        SelectedSaves = new List<SaveData>();
        foreach (string folderName in selectedSaves)
        {
            SaveData data = _saves.FirstOrDefault(save => save.FolderName.EqualsIgnoreCase(folderName)) ?? new(folderName);
            SelectedSaves.Add(data);
        }

        NotSelectedSaves = _saves.FindAll(save => !SelectedSaves.Any(s => s.FolderName.EqualsIgnoreCase(save.FolderName)));
    }

    public void AddSave(string folderName)
    {
        if (SelectedSaves.Any(save => save.FolderName.EqualsIgnoreCase(folderName)))
        {
            return;
        }

        SaveData appendSave = _saves.FirstOrDefault(save => save.FolderName.EqualsIgnoreCase(folderName)) ?? new(folderName);
        SelectedSaves = SelectedSaves.Append(appendSave).ToList();
        NotSelectedSaves = _saves.Where(save => !SelectedSaves.Any(s => s.FolderName.EqualsIgnoreCase(save.FolderName))).ToList();
    }

    public void RemoveSave(string folderName)
    {
        SelectedSaves = SelectedSaves.Where(s => !s.FolderName.EqualsIgnoreCase(folderName)).ToList();
        NotSelectedSaves = _saves.Where(s => !SelectedSaves.Any(s2 => s2.FolderName.EqualsIgnoreCase(s.FolderName))).ToList();
    }

    public void EditList(string action, string folderName)
    {
        switch (action)
        {
            case "Add":
                AddSave(folderName);
                break;
            case "Remove":
                RemoveSave(folderName);
                break;
        }
    }

    public void Cancel()
    {
        Controller?.Close();
    }

    public void Ok()
    {
        _setList(SelectedSaves.Select(s => s.FolderName).ToList());
        Controller?.Close();
    }
}