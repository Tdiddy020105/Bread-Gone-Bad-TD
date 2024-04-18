using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public enum CurrencyType
{
    IN_GAME = 0,
    PERMANENT = 1,
}

public class CurrencyManager
{
    private static readonly CurrencyManager instance = new CurrencyManager();

    private int currencyAmount = 100;
    private Dictionary<CurrencyType, int> currency = new();

    static CurrencyManager() { }
    private CurrencyManager() { }

    public static CurrencyManager Instance
    {
        get
        {
            return instance;
        }
    }

    public void Reset()
    {
        this.currency[CurrencyType.IN_GAME] = 100;  //Use this to set the beginning currency amount!
        this.currency[CurrencyType.PERMANENT] = this.GetPermanentCurrency();
    }

    public int GetCurrencyAmount(CurrencyType currencyType = CurrencyType.IN_GAME)
    {
        if (!this.currency.Keys.Contains(currencyType))
        {
            return 0;
        }

        return this.currency[currencyType];
    }

    public void Earn(int income, CurrencyType currencyType = CurrencyType.IN_GAME)
    {
        this.currency[currencyType] += income;

        this.SerializeCurrency(currencyType, this.currency[currencyType]);
    }

    public void Spend(int expenses, CurrencyType currencyType = CurrencyType.IN_GAME)
    {
        this.currency[currencyType] -= expenses;

        this.SerializeCurrency(currencyType, this.currency[currencyType]);
    }

    private void SerializeCurrency(CurrencyType currencyType, int amount)
    {
        switch (currencyType)
        {
            case CurrencyType.PERMANENT:
                SaveStateSerializer saveStateSerializer = new();
                saveStateSerializer.JSONToFile<PermanentCurrencySaveState>("permanent-currency", new PermanentCurrencySaveState(amount));
                break;
        }
    }

    private int GetPermanentCurrency()
    {
        SaveStateSerializer saveStateSerializer = new();
        PermanentCurrencySaveState permanentCurrency = saveStateSerializer.FileToJSON<PermanentCurrencySaveState>("permanent-currency");

        if (permanentCurrency != null)
        {
            return permanentCurrency.amount;
        }

        return 0;
    }

    public class PermanentCurrencySaveState
    {
        public int amount;

        public PermanentCurrencySaveState() {}

        public PermanentCurrencySaveState(int amount)
        {
            this.amount = amount;
        }
    }
}