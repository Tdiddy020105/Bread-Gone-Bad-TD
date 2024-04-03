using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class TieredUpgradesBase<T> : MonoBehaviour, ITieredUpgrades<T> where T : ScriptableObject
{
    protected int unlockedIndex = -1;

    /// <summary>
    /// Displays the amount of tiers that can still be unlocked.
    /// </summary>
    public int UnlockableTierAmount(int totalPlayerCurrency)
    {
        if (this.AllTiersUnlocked())
        {
            return 0;
        }

        // Calculate the range of unlockable tiers based on the total player currency amount
        int totalCurrencyNeeded = 0;
        int totalUnlockableTiers = 0;
        List<Upgrade<T>> tiers = this.GetTiers();

        for (int i = this.unlockedIndex + 1; i < tiers.Count; i += 1)
        {
            totalCurrencyNeeded += tiers[i].unlockCurrencyAmount;

            if (totalCurrencyNeeded > totalPlayerCurrency)
            {
                break;
            }

            totalUnlockableTiers += 1;
        }

        return totalUnlockableTiers;
    }

    public void UnlockFirstAvailableTier(int totalPlayerCurrency)
    {
        if (this.AllTiersUnlocked())
        {
            return;
        }

        List<Upgrade<T>> tiers = this.GetTiers();
        Upgrade<T> tierToUnlock = tiers[this.unlockedIndex + 1];

        if (totalPlayerCurrency < tierToUnlock.unlockCurrencyAmount)
        {
            return;
        }

        // TODO: Add currency spending (Make sure that the currency is spent after the next upgrade has been unlocked)
        // ...

        this.unlockedIndex += 1;
    }

    public bool AllTiersUnlocked()
    {
        return this.unlockedIndex == this.GetTiers().Count - 1;
    }

    public List<T> GetUnlockedTiers()
    {
        if (this.unlockedIndex < 0)
        {
            return new List<T>();
        }

        // Retrieves all unlocked tiers and filters out the "upgradeCurrencyAmount" parameter
        return this.GetTiers().GetRange(0, this.unlockedIndex + 1).Select((tier) => tier.settings).ToList();
    }

    abstract public List<Upgrade<T>> GetTiers();
}
