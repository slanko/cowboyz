using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flingScript : MonoBehaviour
{
    AudioSource soundz;
    Rigidbody rb;
    public float flingForce = 5;
    public bool PlaySounds = true;
    // Start is called before the first frame update
    void Start()
    {
        if(PlaySounds == true)
        {
            soundz = GetComponent<AudioSource>();
        }
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * flingForce, ForceMode.Impulse);
        rb.AddTorque(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(PlaySounds == true)
        {
            soundz.volume = collision.relativeVelocity.magnitude * 0.3f;
            soundz.Play();
        }
    }
}
