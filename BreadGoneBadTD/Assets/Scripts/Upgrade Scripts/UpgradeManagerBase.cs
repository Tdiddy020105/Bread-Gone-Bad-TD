using System.Collections.Generic;
using UnityEngine;

public abstract class UpgradeManagerBase<T> where T : ScriptableObject
{
    public bool Buy(Upgrade<T> upgrade)
    {
        // TODO: Implement...

        return false;
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
