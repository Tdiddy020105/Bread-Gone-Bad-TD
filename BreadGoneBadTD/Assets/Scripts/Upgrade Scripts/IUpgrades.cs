using System.Collections.Generic;

public interface IUpgrades<T>
{
    public bool AllTiersUnlocked();
    public List<T> GetUnlockedTiers();
}
