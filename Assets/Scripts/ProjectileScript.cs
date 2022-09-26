using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    public void Initialize()
    {
        // rb.AddForceAtPosition(transform.forward * 1000f, transform.forward, ForceMode.Acceleration);
        // rb.AddForce (transform.forward * 20, ForceMode.Impulse);
        // rb.AddForce(transform.position * 700 + transform.TransformDirection(Vector3.forward)); 
        rb.AddForce(transform.forward * 1000f + transform.forward * 300f); //Character controller radius 1.02
    }
}
// Vector3(0.125791773,0.125791773,0.125791773)//projectile scale