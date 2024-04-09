using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrades : TieredUpgradesBase<WeaponData>
{
    [SerializeField]
    private List<Upgrade<WeaponData>> upgrades = new();

    public override List<Upgrade<WeaponData>> GetTiers()
    {
        return this.upgrades;
    }
}
