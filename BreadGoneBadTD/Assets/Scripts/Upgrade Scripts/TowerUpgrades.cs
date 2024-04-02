using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrades : UpgradesBase<TowerData>
{
    [SerializeField]
    private List<UpgradeTier<TowerData>> upgrades = new();

    public override List<UpgradeTier<TowerData>> GetTiers()
    {
        return this.upgrades;
    }
}
