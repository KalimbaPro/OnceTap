using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using StarterAssets;
using Unity.Netcode;

public class PickUpController : MonoBehaviour
{
    //public ProjectileGun gunScript;

    private bool _canPickup = false;
    private void Start()
    {
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

    public void Drop(GameObject target)
    {
        WeaponHolder weaponHolder = target.GetComponent<WeaponHolder>();
        if (weaponHolder.currentWeapon != null)
        {
            transform.SetParent(null);
            GetComponent<Rigidbody>().AddForce(target.transform.forward, ForceMode.Impulse);
            GetComponent<Collider>().enabled = true;
            GetComponent<Rigidbody>().isKinematic = false;
            weaponHolder.currentWeapon = null;
        }
    }

    public void Pickup(GameObject target)
    {
        if (target.GetComponent<WeaponHolder>().pickUpController) {
            target.GetComponent<WeaponHolder>().pickUpController = null;
            transform.SetParent(target.transform);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            GetComponent<Collider>().enabled = false; // Désactiver le collider pour éviter d'autres triggers
            GetComponent<Rigidbody>().isKinematic = true; // Désactiver la physique
            WeaponHolder weaponHolder = target.GetComponent<WeaponHolder>();
            if (weaponHolder.currentWeapon == null)
                target.GetComponent<WeaponHolder>().currentWeapon = gameObject;
            else {
                Destroy(target.GetComponent<WeaponHolder>().currentWeapon);
                target.GetComponent<WeaponHolder>().currentWeapon = gameObject;
            }
        }
    }

}
