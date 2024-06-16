using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class DistanceWeaponStats : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetFirePoint(Transform firePoint)
    {
        this.firePoint = firePoint;
    }

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);
        bullet.GetComponent<PlayerOwner>().playerOwner = gameObject.GetComponent<PlayerOwner>().playerOwner;
    }
}
