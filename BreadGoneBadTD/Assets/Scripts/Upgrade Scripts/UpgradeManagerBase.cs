using System.Collections.Generic;
using UnityEngine;

/// <typeparam name="T">The ScriptableObject that holds the settings</typeparam>
/// <typeparam name="U">The save state equivalent of T</typeparam>
public abstract class UpgradeManagerBase<T, U> : MonoBehaviour where T : ScriptableObject
{
    public bool Buy(Upgrade<T> upgrade, GameObject obj)
    {
        if (CurrencyManager.Instance.GetCurrencyAmount(CurrencyType.PERMANENT) < upgrade.unlockCurrencyAmount)
        {
            return false;
        }

        CurrencyManager.Instance.Spend(upgrade.unlockCurrencyAmount, CurrencyType.PERMANENT);

        List<U> boughtUpgrades = GetBoughtUpgrades();
        U saveState = this.upgradeSettingsToSaveState(upgrade.settings);

        boughtUpgrades.Add(saveState);
        this.SerializeUpgrades(boughtUpgrades);
        obj.SetActive(false);

        return true;
    }

    public static List<U> GetBoughtUpgrades()
    {
        // TODO: Deserialize bought upgrades and return them in this list...
        SaveStateSerializer saveStateSerializer = new SaveStateSerializer();
        // Possible fetch from List<U> necessary before this properly works
        Upgrade<T> data = saveStateSerializer.FileToJSON<Upgrade<T>>("upgrade");
        return new List<U>();
    }

    protected abstract string SerializationKey();

    protected abstract U upgradeSettingsToSaveState(T settings);

    private void SerializeUpgrades(List<U> upgrades)
    {
        SaveStateSerializer saveStateSerializer = new SaveStateSerializer();
        // TODO: Serialize upgrades here...
        // Note: Use the this.SerializationKey() to access a unique key for the save file.
        string upgradeKey = this.SerializationKey();
        // Error because list needs to be split apart first
        // bool serialized = saveStateSerializer.JSONToFile<Upgrade<T>>(upgradeKey, upgrades);
    }
}
