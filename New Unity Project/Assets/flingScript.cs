using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flingScript : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        rb.AddTorque(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
