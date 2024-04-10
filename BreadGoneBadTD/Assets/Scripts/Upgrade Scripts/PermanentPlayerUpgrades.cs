using System.Collections.Generic;
using UnityEngine;

public class PermanentPlayerUpgrades : MonoBehaviour
{
    public List<SavePlayerData> GetBoughtUpgrades()
    {
        // Uncomment code below to test permanent upgrades
        // List<SavePlayerData> tempData = new()
        // {
        //     new SavePlayerData()
        //     {
        //         attackDamage = 0,
        //         movementSpeed = 2,
        //     },
        //     new SavePlayerData()
        //     {
        //         attackDamage = 100,
        //         movementSpeed = 0,
        //     },
        // };

        // return tempData;
        return PermanentPlayerUpgradesManager.GetBoughtUpgrades();
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
