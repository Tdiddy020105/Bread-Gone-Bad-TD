using System.Collections.Generic;
using UnityEngine;

public interface ITieredUpgrades<T> where T : ScriptableObject
{
    public bool AllTiersUnlocked();
    public List<T> GetUnlockedTiers();
    public List<Upgrade<T>> GetTiers();
}
