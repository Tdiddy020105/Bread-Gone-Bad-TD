using System.Collections.Generic;
using UnityEngine;

public class PermanentPlayerUpgrades : MonoBehaviour
{
    public List<SavePlayerData> GetBoughtUpgrades()
    {
        return PermanentPlayerUpgradesManager.GetBoughtUpgrades();
    }
}
