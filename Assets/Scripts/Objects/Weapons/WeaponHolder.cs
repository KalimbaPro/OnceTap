using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    private MeleeWeaponStats meleeWeaponStats;
    private DistanceWeaponStats distanceWeaponStats;

    private int previousChildCount;

    public PickUpController pickUpController;

    public GameObject currentWeapon;
    public float dropForce;

    public Transform dropPoint;

    public Transform firePoint;

    public enum WeaponMode
    {
        Distance,
        Melee,
    };

    public WeaponMode weaponMode;

    void Update()
    {

        if (transform.childCount != previousChildCount)
        {
            meleeWeaponStats = GetComponentInChildren<MeleeWeaponStats>();
            distanceWeaponStats = GetComponentInChildren<DistanceWeaponStats>();
            if (distanceWeaponStats != null)
            {
                weaponMode = WeaponMode.Distance;
                distanceWeaponStats.SetFirePoint(firePoint);
            }
            if (meleeWeaponStats != null)
                weaponMode = WeaponMode.Melee;
            previousChildCount = transform.childCount;
        }
    }

    public void TeleportWeapon()
    {
        if (this.currentWeapon != null) {
            this.currentWeapon.transform.position = transform.position;
            currentWeapon.transform.rotation = transform.rotation;
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
        if (pickUpController != null)
        {
            pickUpController.Pickup(gameObject);
        }
    }

    public void Drop()
    {
        if (currentWeapon != null)
        {
            currentWeapon.transform.SetParent(null);
            currentWeapon.GetComponent<SphereCollider>().enabled = true;
            currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
            currentWeapon.GetComponent<PickUpController>().RestartWeaponDespawn();
            if (weaponMode == WeaponMode.Melee) {
                currentWeapon.GetComponent<MeleeWeaponStats>().SetphysicHitBox(true);
            }
            currentWeapon.GetComponent<Rigidbody>().AddForce(dropPoint.transform.forward * dropForce, ForceMode.Impulse);
            currentWeapon = null;
            //TODO: distance weapon
            //else
            //currentWeapon.GetComponent<MeleeWeaponStats>().SetphysicHitBox(true);
        }
    }

    public void PlayMeleeWeaponSound()
    {
        meleeWeaponStats.PlaySound();
    }

    public void PlayDistanceWeaponSound()
    {
        distanceWeaponStats.PlaySound();
    }
}
