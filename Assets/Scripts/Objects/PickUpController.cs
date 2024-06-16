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

    public bool _doesExpired = true;
    private void Start()
    {
        StartCoroutine(DespawnWeaponRoutine(gameObject, 90f));
    }

    public void Pickup(GameObject target)
    {
        if (target.GetComponent<WeaponHolder>().pickUpController != null) {
            transform.SetParent(target.transform);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            GetComponent<SphereCollider>().enabled = false;
            if (target.GetComponent<WeaponHolder>().weaponMode == WeaponHolder.WeaponMode.Melee)
                GetComponent<MeleeWeaponStats>().SetphysicHitBox(false);
            GetComponent<Rigidbody>().isKinematic = true;
            WeaponHolder weaponHolder = target.GetComponent<WeaponHolder>();
            // _doesExpired = false;
            if (weaponHolder.currentWeapon == null)
            {
                target.GetComponent<WeaponHolder>().currentWeapon = gameObject;
                GetComponent<PlayerOwner>().playerOwner = target.GetComponent<PlayerOwner>().playerOwner;
                GetComponent<MeleeWeaponStats>().hitBox.GetComponent<PlayerOwner>().playerOwner = target.GetComponent<PlayerOwner>().playerOwner;
            }
            else
            {
                Destroy(target.GetComponent<WeaponHolder>().currentWeapon);
                target.GetComponent<WeaponHolder>().currentWeapon = gameObject;
                GetComponent<PlayerOwner>().playerOwner = target.GetComponent<PlayerOwner>().playerOwner;
                GetComponent<MeleeWeaponStats>().hitBox.GetComponent<PlayerOwner>().playerOwner = target.GetComponent<PlayerOwner>().playerOwner;
            }
            target.GetComponent<WeaponHolder>().pickUpController = null;
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
