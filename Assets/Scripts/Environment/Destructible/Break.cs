using MoreMountains.Feedbacks;
using System.Collections;
using Unity.Netcode;
using UnityEngine;

public class Break : MonoBehaviour
{
    public GameObject fractured;
    public float breakForce = 250;

    private GameObject player;
    private GameObject map;
    public MMF_Player MMFPlayer;

    private void Start()
    {
        map = GameObject.FindGameObjectWithTag("Map");
        MMFPlayer = GetComponent<MMF_Player>();
    }

    // Update is called once per frame
    void Update()
    {
        getPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Strike"))
        {
            BreakTheThing();
        }

        if (other.CompareTag("WeaponHitbox"))
        {
            if (other.GetComponentInParent<MeleeWeaponStats>().CanBreakThings)
            {
                if (!this.CompareTag("Floor"))
                {
                    BreakTheThing();
                }
            }
            if (this.CompareTag("Floor") && other.GetComponentInParent<MeleeWeaponStats>().CanBreakFloor)
                BreakTheThing();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Strike")) {
            BreakTheThing();
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Strike"))
        {
            BreakTheThing();
        }
    }

    private void getPlayer()
    {
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public void BreakTheThing()
    {
        GameObject frac = Instantiate(fractured, transform.position, transform.rotation);
        frac.GetComponent<Debris>().originalElement = gameObject;
        frac.transform.localScale = new Vector3(transform.localScale.x * map.transform.localScale.x,
            transform.localScale.y * map.transform.localScale.y,
            transform.localScale.z * map.transform.localScale.z);

        foreach (Rigidbody rb in frac.GetComponentsInChildren<Rigidbody>())
        {
            Vector3 force = (rb.transform.position - player.transform.position).normalized * breakForce;
            rb.AddForce(force);
        }

        gameObject.SetActive(false);
    }
}
