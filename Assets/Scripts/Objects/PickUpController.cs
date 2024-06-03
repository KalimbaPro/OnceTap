using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using StarterAssets;

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

    public void Pickup(GameObject target)
    {
        if (target.GetComponent<WeaponHolder>().pickUpController) {
            target.GetComponent<WeaponHolder>().pickUpController = null;
            transform.SetParent(target.transform);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            GetComponent<SphereCollider>().enabled = false; // Désactiver le collider pour éviter d'autres triggers
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<Rigidbody>().isKinematic = true; // Désactiver la physique
            WeaponHolder weaponHolder = target.GetComponent<WeaponHolder>();
            if (weaponHolder.currentWeapon == null)
            {
                target.GetComponent<WeaponHolder>().currentWeapon = gameObject;
                gameObject.GetComponent<MeleeWeaponStats>().CanBreakThings = true;
            }
            else
            {
                Destroy(target.GetComponent<WeaponHolder>().currentWeapon);
                target.GetComponent<WeaponHolder>().currentWeapon = gameObject;
                gameObject.GetComponent<MeleeWeaponStats>().CanBreakThings = true;
            }
        }
    }

}
