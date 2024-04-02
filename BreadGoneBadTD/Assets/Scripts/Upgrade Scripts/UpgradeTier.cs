using System;
using UnityEngine;

[Serializable]
public class UpgradeTier<T> where T : ScriptableObject
{
    [SerializeField] public T upgrade;
    [SerializeField] public int unlockCurrencyAmount;
}
