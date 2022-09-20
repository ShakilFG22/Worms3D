using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    // [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
    // private bool _isTrue;

    public void Initialize()
    {
        // _isTrue = true;
        rb.AddForce(transform.forward * 700f + transform.up * 300f);
    }
    void Update()
    {
    }


    
}
