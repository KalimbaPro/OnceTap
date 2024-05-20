using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    private MeleeWeaponStats meleeWeaponStats;
    private DistanceWeaponStats distanceWeaponStats;

    private int previousChildCount;

    public PickUpController pickUpController;

    public GameObject currentWeapon;

    public GameObject weaponToPickup;
    public enum WeaponMode {
        Distance,
        Melee,
    };

    public WeaponMode weaponMode;

    void Start()
    {
        currentWeapon = null;
        pickUpController = null;
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

    public void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("Weapon") && target.GetType().Name == "SphereCollider")
        {
            pickUpController = target.GetComponent<PickUpController>();
        }
    }

    public void OnTriggerExit(Collider target)
    {
        if (target.CompareTag("Weapon") && target.GetType().Name == "SphereCollider")
        {
            pickUpController = null;
        }
    }
    public void PickUp()
    {
        if (pickUpController)
        {
            pickUpController.Pickup(gameObject);
        }
    }
}
