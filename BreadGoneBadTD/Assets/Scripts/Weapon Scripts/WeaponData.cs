using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MeleeWeapon", menuName = "ScriptableObjects/WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public int damage;
    public float attackRate;
    public float range;
    public GameObject attackAreaPrefab;
    public Sprite weaponImage;
    public AnimationClip appearanceAnimation;
    // Add more properties as needed
}

