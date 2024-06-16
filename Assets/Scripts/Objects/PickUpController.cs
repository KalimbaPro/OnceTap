using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using StarterAssets;
using Unity.Netcode;
using System;
using System.Diagnostics;

public class PickUpController : MonoBehaviour
{
    //public ProjectileGun gunScript;

    public bool _doesExpired = true;

    private Coroutine _despawnWeaponCoroutine;

    public float _despawnTime;
    private void Start()
    {
        _despawnWeaponCoroutine = StartCoroutine(DespawnWeaponRoutine(gameObject, _despawnTime));
    }

    public void Pickup(GameObject target)
    {
        if (target.GetComponent<WeaponHolder>().pickUpController != null) {
            transform.SetParent(target.transform);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            GetComponent<SphereCollider>().enabled = false;
            StopWeaponDespawn();
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
                else if (GetComponent<DistanceWeaponStats>() != null)
                    GetComponent<DistanceWeaponStats>().GetComponent<PlayerOwner>().playerOwner = target.GetComponent<PlayerOwner>().playerOwner;
            }
            target.GetComponent<WeaponHolder>().pickUpController = null;
        }
    }

    public void StopWeaponDespawn()
    {
        if (_despawnWeaponCoroutine != null)
        {
            StopCoroutine(_despawnWeaponCoroutine);
            _despawnWeaponCoroutine = null;
        }

    }

    public void RestartWeaponDespawn()
    {
        if (_despawnWeaponCoroutine == null)
        {
            _despawnWeaponCoroutine = StartCoroutine(DespawnWeaponRoutine(gameObject, _despawnTime));
        }
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
