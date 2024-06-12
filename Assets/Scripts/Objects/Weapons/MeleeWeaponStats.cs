using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class MeleeWeaponStats : MonoBehaviour
{
    public bool CanBreakFloor;
    public bool CanBreakThings;
    public GameObject hitBox;
    public GameObject physicHitBox;
    public float projectionForce;

    public enum MeleeWeapons {
        Hammer,
        Sword,
        Mass,
        Fist,
    };

    public MeleeWeapons weaponType;
    // Start is called before the first frame update
    void Start()
    {
        SetphysicHitBox(true);
        SetHitBox(false);
    }

    public void SetphysicHitBox(bool setPhysicHitBox)
    {
        if (physicHitBox != null)
        {
            foreach (Collider collider in physicHitBox.GetComponents<Collider>())
            {
                collider.enabled = setPhysicHitBox;
            }
        }
    }

    public void SetHitBox(bool setHitbox)
    {
        if (hitBox != null)
        {
            foreach (Collider collider in hitBox.GetComponents<Collider>())
            {
                collider.enabled = setHitbox;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
