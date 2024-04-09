using System.Collections.Generic;
using UnityEngine;

public abstract class UpgradeManagerBase<T> : MonoBehaviour where T : ScriptableObject
{
    public bool Buy(Upgrade<T> upgrade)
    {
        if (CurrencyManager.Instance.GetCurrencyAmount(CurrencyType.PERMANENT) < upgrade.unlockCurrencyAmount)
        {
            Debug.Log("UPGRADE NIET GEKOOPT!!!");
            return false;
        }

        Debug.Log("UPGRADE GEKOOPT!!!");

        CurrencyManager.Instance.Spend(upgrade.unlockCurrencyAmount, CurrencyType.PERMANENT);

        List<Upgrade<T>> boughtUpgrades = GetBoughtUpgrades();
        boughtUpgrades.Add(upgrade);

        this.SerializeUpgrades(boughtUpgrades);

        return true;
    }

    public static List<Upgrade<T>> GetBoughtUpgrades()
    {
        // TODO: Deserialize bought upgrades and return them in this list...

        return new List<Upgrade<T>>();
    }

    protected abstract string SerializationKey();

    private void SerializeUpgrades(List<Upgrade<T>> upgrades)
    {
        // TODO: Serialize upgrades here...
        // Note: Use the this.SerializationKey() to access a unique key for the save file.
    }
}
