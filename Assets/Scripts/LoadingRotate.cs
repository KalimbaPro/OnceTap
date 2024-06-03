using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingRotate : MonoBehaviour
{
    public float Speed = 10f;
    public bool Invert = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(new(0, 0, Speed * Time.deltaTime * (Invert ? 1 : -1)));
    }
}
