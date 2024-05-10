using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceWeaponStats1 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    public Transform firePoint;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(firePoint.forward * bulletSpeed, ForceMode.Impulse);
    }
}
