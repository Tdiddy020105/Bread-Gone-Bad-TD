using System;
using UnityEngine;

[Serializable]
public class Upgrade<T> where T : ScriptableObject
{
    [SerializeField] public T settings;
    [SerializeField] public int unlockCurrencyAmount;
}
