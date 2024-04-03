using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrades : UpgradesBase<WeaponData>
{
    [SerializeField]
    private List<UpgradeTier<WeaponData>> upgrades = new();

    public override List<UpgradeTier<WeaponData>> GetTiers()
    {
        return this.upgrades;
    }
}
