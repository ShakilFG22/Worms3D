using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    public void Initialize()
    {
        rb.AddForce(transform.forward * 1300f);
    }
}
