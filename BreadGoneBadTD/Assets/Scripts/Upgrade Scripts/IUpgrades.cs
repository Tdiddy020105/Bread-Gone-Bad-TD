using System.Collections.Generic;
using UnityEngine;

public interface IUpgrades<T> where T : ScriptableObject
{
    public bool AllTiersUnlocked();
    public List<T> GetUnlockedTiers();
    public List<UpgradeTier<T>> GetTiers();
}
