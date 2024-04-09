public class PermanentTowerUpgradesManager : UpgradeManagerBase<TowerData>
{
    // All logic is handled within the "UpgradeManagerBase" class...
    protected override string SerializationKey()
    {
        return "permanent-tower-upgrades";
    }
}
