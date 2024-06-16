using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using StarterAssets;
using Unity.Netcode;
using System;

public class PickUpController : MonoBehaviour
{
    //public ProjectileGun gunScript;

    private bool _canPickup = false;
    public bool _doesExpired = true;
    private void Start()
    {
        StartCoroutine(DespawnWeaponRoutine(gameObject, 90f));
    }

    private void LateUpdate()
    {
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("WeaponHolder"))
        {
            _canPickup = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("WeaponHolder"))
        {
            _canPickup = false;
        }
    }

    public void Pickup(GameObject target)
    {
        if (target.GetComponent<WeaponHolder>().pickUpController)
        {
            target.GetComponent<WeaponHolder>().pickUpController = null;
            transform.SetParent(target.transform);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            GetComponent<SphereCollider>().enabled = false;
            if (target.GetComponent<WeaponHolder>().weaponMode == WeaponHolder.WeaponMode.Melee && GetComponent<MeleeWeaponStats>() != null)
            {
                GetComponent<MeleeWeaponStats>().SetphysicHitBox(false);
            }
            else if (GetComponent<DistanceWeaponStats>() != null)
                GetComponent<DistanceWeaponStats>().SetFirePoint(target.GetComponent<WeaponHolder>().firePoint);
            GetComponent<Rigidbody>().isKinematic = true;
            WeaponHolder weaponHolder = target.GetComponent<WeaponHolder>();
            // _doesExpired = false;
            if (weaponHolder.currentWeapon == null)
            {
                target.GetComponent<WeaponHolder>().currentWeapon = gameObject;
                GetComponent<PlayerOwner>().playerOwner = target.GetComponent<PlayerOwner>().playerOwner;
                if (GetComponent<MeleeWeaponStats>() != null)
                    GetComponent<MeleeWeaponStats>().hitBox.GetComponent<PlayerOwner>().playerOwner = target.GetComponent<PlayerOwner>().playerOwner;
                else if (GetComponent<DistanceWeaponStats>() != null)
                    GetComponent<DistanceWeaponStats>().GetComponent<PlayerOwner>().playerOwner = target.GetComponent<PlayerOwner>().playerOwner;
            }
            else
            {
                Destroy(target.GetComponent<WeaponHolder>().currentWeapon);
                target.GetComponent<WeaponHolder>().currentWeapon = gameObject;
                GetComponent<PlayerOwner>().playerOwner = target.GetComponent<PlayerOwner>().playerOwner;
                if (GetComponent<MeleeWeaponStats>() != null)
                    GetComponent<MeleeWeaponStats>().hitBox.GetComponent<PlayerOwner>().playerOwner = target.GetComponent<PlayerOwner>().playerOwner;
                else
                    GetComponent<DistanceWeaponStats>().GetComponent<PlayerOwner>().playerOwner = target.GetComponent<PlayerOwner>().playerOwner;
            }
        }
    }

    public bool GetCanPickup()
    {
        return _canPickup;
    }

    private IEnumerator DespawnWeaponRoutine(GameObject weapon, float time)
    {
        yield return new WaitForSeconds(time);
        if (weapon != null)
        {
            Destroy(weapon);
        }
    }
}
