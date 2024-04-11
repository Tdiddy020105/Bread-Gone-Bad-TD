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

        List<U> boughtUpgrades = GetBoughtUpgrades(this.SerializationKey());
        U saveState = this.upgradeSettingsToSaveState(upgrade.settings);

        boughtUpgrades.Add(saveState);
        bool serialization = this.SerializeUpgrades(boughtUpgrades, this.SerializationKey());
        if( serialization = true ){
            obj.SetActive(false);
            return true;
        }
        CurrencyManager.Instance.Earn(upgrade.UnlockCurrencyAmount, CurrencyType.PERMANENT);
        return false;

    }

    protected static List<U> GetBoughtUpgrades(string serializationKey)
    {
        // TODO: Deserialize bought upgrades and return them in this list...
        SaveStateSerializer saveStateSerializer = new SaveStateSerializer();
        List<U> data = saveStateSerializer.FileToJSON<List<U>>(serializationKey);

        if(data != null && data.Count > 0)
        {
            return data;
        }

        return new List<U>();
    }

    protected abstract string SerializationKey();

    protected abstract U upgradeSettingsToSaveState(T settings);

    private bool SerializeUpgrades(List<U> upgrades, string serializationKey)
    {
        SaveStateSerializer saveStateSerializer = new SaveStateSerializer();

        bool serialized = saveStateSerializer.JSONToFile<List<U>>(serializationKey, upgrades);
        return serialized;
    }
}
