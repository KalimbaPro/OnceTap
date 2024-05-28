using Unity.Netcode;
using UnityEngine;

public class Break : MonoBehaviour
{
    public GameObject fractured;
    public float breakForce = 250;

    private GameObject player;
    private GameObject map;

    private void Start()
    {
        map = GameObject.FindGameObjectWithTag("Map");
    }

    // Update is called once per frame
    void Update()
    {
        getPlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon") && other.gameObject.GetComponent<MeleeWeaponStats>().CanBreakThings)
        {
            if (!this.CompareTag("Floor"))
            {
                BreakTheThing();
            }
            else if (other.gameObject.GetComponent<MeleeWeaponStats>().CanBreakFloor)
                BreakTheThing();
        }
    }

    private void getPlayer()
    {
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        //if (player)
        //{
        //    Debug.Log(player);
        //}
    }

    public void BreakTheThing()
    {
        GameObject frac = Instantiate(fractured, transform.position, transform.rotation);
        frac.transform.localScale = new Vector3(transform.localScale.x * map.transform.localScale.x,
            transform.localScale.y * map.transform.localScale.y,
            transform.localScale.z * map.transform.localScale.z);

        foreach (Rigidbody rb in frac.GetComponentsInChildren<Rigidbody>())
        {
            Vector3 force = (rb.transform.position - player.transform.position).normalized * breakForce;
            rb.AddForce(force);
        }

        Destroy(gameObject);
    }
}
