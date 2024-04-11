using System.Collections.Generic;
using UnityEngine;

public class PermanentPlayerUpgrades : MonoBehaviour
{
    public List<SavePlayerData> GetBoughtUpgrades()
    {
        return PermanentPlayerUpgradesManager.GetAll();
    }

    public int GetExtraAttackDamage()
    {
        int total = 0;

        foreach (SavePlayerData data in this.GetBoughtUpgrades())
        {
            total += data.attackDamage;
        }

        return total;
    }

    public int GetExtraMovementSpeed()
    {
        int total = 0;

        foreach (SavePlayerData data in this.GetBoughtUpgrades())
        {
            total += data.movementSpeed;
        }

        return total;
    }
}
