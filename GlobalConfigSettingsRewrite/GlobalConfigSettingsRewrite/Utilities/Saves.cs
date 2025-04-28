using GlobalConfigSettingsRewrite.Models;
using StardewModdingAPI;
using StardewValley;
using StardewValley.SaveSerialization;

namespace GlobalConfigSettingsRewrite.Utilities;

public static class Saves
{
    public static SaveInfo[] GetSaves()
    {
        if (!Directory.Exists(Constants.SavesPath))
        {
            return Array.Empty<SaveInfo>();
        }

        List<SaveInfo> info = new();

        string[] folders = Directory.GetDirectories(Constants.SavesPath);
        foreach (string saveFolder in folders)
        {
            string folderName = Path.GetFileName(saveFolder);

            try
            {
                string saveGameInfoPath = Path.Combine(saveFolder, "SaveGameInfo");
                if (File.Exists(saveGameInfoPath))
                {
                    Farmer farmer = GetFarmer(saveGameInfoPath);
                    info.Add(new SaveInfo(farmer.Name, farmer.farmName.Value, folderName));
                    continue;
                }
                string oldSaveGameInfoPath = Path.Combine(saveFolder, "SaveGameInfo_old");
                if (File.Exists(oldSaveGameInfoPath))
                {
                    Farmer farmer = GetFarmer(oldSaveGameInfoPath);
                    info.Add(new SaveInfo(farmer.Name, farmer.farmName.Value, folderName));
                    continue;
                }

                string savePath = Path.Combine(saveFolder, folderName);
                if (File.Exists(savePath))
                {
                    SaveGame saveGame = GetSaveGame(savePath);
                    info.Add(new SaveInfo(saveGame.player.Name, saveGame.player.farmName.Value, folderName));
                    continue;
                }
                string oldSavePath = Path.Combine(saveFolder, folderName + "_old");
                if (File.Exists(oldSavePath))
                {
                    SaveGame saveGame = GetSaveGame(oldSavePath);
                    info.Add(new SaveInfo(saveGame.player.Name, saveGame.player.farmName.Value, folderName));
                }
            }
            catch (Exception ex)
            {
                Mod.Logger.Log($"An error occurred while trying to read save info for {folderName}: {ex}", LogLevel.Warn);
            }
        }

        return info.ToArray();
    }

    public static Farmer GetFarmer(string filePath)
    {
        using FileStream stream = File.OpenRead(filePath);
        var farmer = SaveSerializer.Deserialize<Farmer>(stream);
        return farmer;
    }

    public static SaveGame GetSaveGame(string filePath)
    {
        using FileStream stream = File.OpenRead(filePath);
        var saveGame = SaveSerializer.Deserialize<SaveGame>(stream);
        return saveGame;
    }
}