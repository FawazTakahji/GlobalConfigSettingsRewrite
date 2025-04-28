namespace GlobalConfigSettingsRewrite.Models;

public class SaveData
{
    private readonly string? _farmerName;
    private readonly string? _farmName;
    public readonly string FolderName;
    public string DisplayName => (_farmName is not null && _farmerName is not null) ? $"{_farmerName} | {_farmName} Farm" : FolderName;

    public SaveData(string folderName, string? farmerName = null, string? farmName = null)
    {
        FolderName = folderName;
        _farmerName = farmerName;
        _farmName = farmName;
    }

    public SaveData(SaveInfo info)
    {
        FolderName = info.FolderName;
        _farmerName = info.FarmerName;
        _farmName = info.FarmName;
    }
}