// TODO: Change "TowerData" to "PlayerData"
public class PermanentPlayerUpgradesManager : UpgradeManagerBase<PlayerData, SavePlayerData>
{
    // All logic is handled within the "UpgradeManagerBase" class...
    protected override string SerializationKey()
    {
        return "permanent-player-upgrades";
    }

    protected override SavePlayerData upgradeSettingsToSaveState(PlayerData playerData)
    {
        SavePlayerData savePlayerData = new SavePlayerData();
        savePlayerData.attackDamage = playerData.attackDamage;
        savePlayerData.movementSpeed = playerData.movementSpeed;
        return savePlayerData;
    }

}
