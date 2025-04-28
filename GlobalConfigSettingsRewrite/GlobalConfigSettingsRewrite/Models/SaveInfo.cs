namespace GlobalConfigSettingsRewrite.Models;

public class SaveInfo
{
    public readonly string FarmerName;
    public readonly string FarmName;
    public readonly string FolderName;

    public SaveInfo(string farmerName, string farmName, string folderName)
    {
        FarmerName = farmerName;
        FarmName = farmName;
        FolderName = folderName;
    }
}