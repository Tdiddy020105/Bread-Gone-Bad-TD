using UnityEngine;

public enum TowerAttackType
{
    [InspectorName("First target inside the range")]
    TARGET_FIRST_IN_RANGE = 0,

    [InspectorName("All targets inside the range")]
    TARGET_ALL_IN_RANGE = 1,
}

[CreateAssetMenu(fileName = "TowerData", menuName = "ScriptableObjects/TowerData")]
public class TowerData : ScriptableObject
{
    [SerializeField] public int attackDamage;
    [SerializeField] public Vector2 attackRange;
    [SerializeField] public TowerAttackType attackType;
    [SerializeField] public int price;

    [SerializeField] public int secondsBetweenAttacks;

    [SerializeField] public Sprite sprite;
    [SerializeField] public string description = "";
}