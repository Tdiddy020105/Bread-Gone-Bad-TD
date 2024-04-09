using System.Collections.Generic;
using System.Linq;

public enum CurrencyType
{
    IN_GAME = 0,
    PERMANENT = 1,
}

public class CurrencyManager
{
    private static readonly CurrencyManager instance = new CurrencyManager();

    private Dictionary<CurrencyType, int> currency = new();

    static CurrencyManager() {}
    private CurrencyManager() {}

    public static CurrencyManager Instance
    {
        get
        {
            return instance;
        }
    }

    public void Reset()
    {
        // Reset all currency that exists within the dictionary
        foreach (KeyValuePair<CurrencyType, int> entry in this.currency)
        {
            this.currency[entry.Key] = 0;
        }
    }

    public int GetCurrencyAmount(CurrencyType currencyType = CurrencyType.IN_GAME)
    {
        this.CreateInternalCurrencyIfNotExists(currencyType);

        return this.currency[currencyType];
    }

    public void Earn(int income, CurrencyType currencyType = CurrencyType.IN_GAME)
    {
        this.CreateInternalCurrencyIfNotExists(currencyType);
        this.currency[currencyType] += income;
    }

    public void Spend(int expenses, CurrencyType currencyType = CurrencyType.IN_GAME)
    {
        this.CreateInternalCurrencyIfNotExists(currencyType);
        this.currency[currencyType] -= expenses;
    }

    private void CreateInternalCurrencyIfNotExists(CurrencyType currencyType)
    {
        if (!this.currency.Keys.Contains(currencyType))
        {
            this.currency[currencyType] = 0;
        }
    }
}
