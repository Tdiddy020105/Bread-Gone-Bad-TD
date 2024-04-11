using System.Collections.Generic;

public class PermanentPlayerUpgradesManager : PermanentUpgradeManagerBase<PlayerData, SavePlayerData>
{
    // All logic is handled within the "UpgradeManagerBase" class...
    protected override string SerializationKey()
    {
        return "permanent-player-upgrades";
    }

    public static List<SavePlayerData> GetAll()
    {
        return GetBoughtUpgrades("permanent-player-upgrades");
    }

    protected override SavePlayerData upgradeSettingsToSaveState(PlayerData playerData)
    {
        SavePlayerData savePlayerData = new SavePlayerData();

        savePlayerData.name = playerData.name;
        savePlayerData.attackDamage = playerData.attackDamage;
        savePlayerData.movementSpeed = playerData.movementSpeed;

        return savePlayerData;
    }
}
