public class CurrencyManager
{
    private static readonly CurrencyManager instance = new CurrencyManager();

    private int currencyAmount = 0;

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
        currencyAmount = 0;
    }

    public int GetCurrencyAmount()
    {
        return currencyAmount;
    }

    public void Earn(int income)
    {
        currencyAmount = currencyAmount + income;
    }

    public void Spend(int expenses)
    {
        currencyAmount = currencyAmount - expenses;
    }
}
