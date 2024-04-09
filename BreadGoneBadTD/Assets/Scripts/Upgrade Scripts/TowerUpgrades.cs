using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrades : TieredUpgradesBase<TowerData>
{
    [SerializeField]
    private List<Upgrade<TowerData>> upgrades = new();

    public override List<Upgrade<TowerData>> GetTiers()
    {
        return this.upgrades;
    }
}
