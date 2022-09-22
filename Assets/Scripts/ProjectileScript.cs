using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    public void Initialize()
    {
        // rb.AddForceAtPosition(transform.forward * 1.7f, transform.position);
        // rb.AddForce (transform.forward * 20, ForceMode.Impulse);
        // rb.AddForce(transform.position * 700 + transform.TransformDirection(Vector3.forward)); //OG, need to be changed

        rb.AddForce(transform.forward * 700f + transform.up * 300f); //OG, need to be changed
    }
}
// Vector3(0.125791773,0.125791773,0.125791773)//projectile scale