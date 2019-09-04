using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUMBLEWEED : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddTorque(transform.forward * 5, ForceMode.Acceleration);
    }
}
