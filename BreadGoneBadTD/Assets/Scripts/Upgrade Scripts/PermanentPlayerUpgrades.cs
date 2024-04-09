using System.Collections.Generic;
using UnityEngine;

public class PermanentPlayerUpgrades : MonoBehaviour
{
    public List<System.Object> GetBoughtUpgrades()
    {
        return PermanentPlayerUpgradesManager.GetBoughtUpgrades();
    }
}
