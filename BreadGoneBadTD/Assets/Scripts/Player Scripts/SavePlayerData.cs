using UnityEngine;

[CreateAssetMenu(fileName = "SavePlayerData", menuName = "ScriptableObjects/SavePlayerData")]
public class SavePlayerData : ScriptableObject
{
    [SerializeField] public int attackDamage;
    [SerializeField] public int movementSpeed;
}