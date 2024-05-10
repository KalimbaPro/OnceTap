using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    private MeleeWeaponStats meleeWeaponStats;
    private DistanceWeaponStats distanceWeaponStats;
    private int previousChildCount;
    public enum WeaponMode {
        Distance,
        Melee,
    };

    public WeaponMode weaponMode;

    void Start()
    {

    }

    void Update()
    {
        if (transform.childCount != previousChildCount)
        {
            meleeWeaponStats = GetComponentInChildren<MeleeWeaponStats>();
            distanceWeaponStats = GetComponentInChildren<DistanceWeaponStats>();
            if (distanceWeaponStats != null) {
                weaponMode = WeaponMode.Distance;
                distanceWeaponStats.SetFirePoint();
            }
            if (meleeWeaponStats != null)
                weaponMode = WeaponMode.Melee;
            previousChildCount = transform.childCount;
        }
    }

    public WeaponMode GetWeaponMode()
    {
        return weaponMode;
    }

    public MeleeWeaponStats GetMeleeWeaponStats()
    {
        return meleeWeaponStats;
    }

    public DistanceWeaponStats GetDistanceWeaponStats()
    {
        return distanceWeaponStats;
    }
}
