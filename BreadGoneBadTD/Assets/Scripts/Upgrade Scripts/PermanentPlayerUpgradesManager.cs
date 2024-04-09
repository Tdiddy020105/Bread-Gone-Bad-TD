// TODO: Change "TowerData" to "PlayerData"
public class PermanentPlayerUpgradesManager : UpgradeManagerBase<PlayerData>
{
    // All logic is handled within the "UpgradeManagerBase" class...
    protected override string SerializationKey()
    {
        return "permanent-player-upgrades";
    }
}
