using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    public void Initialize()
    {
        rb.AddForce(transform.forward * 1300f); //Character controller radius 1.02
    }
}
// Vector3(0.125791773,0.125791773,0.125791773)//projectile scale