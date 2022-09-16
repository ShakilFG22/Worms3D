using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
    //[SerializeField] private GameObject damageIndicatorPrefab;
    private bool _isTrue;

    public void Initialize()
    {
        _isTrue = true;
        rb.AddForce(transform.forward * 700f + transform.up * 300f);

    }
    void Update()
    {
        // if (_isTrue)
        // {
        //     transform.Translate(transform.forward * (speed * Time.deltaTime));
        // }
    }

    // private void OnCollisionEnter(Collision col)
    // {
    //     // GameObject colObject = col.gameObject;
    //     // Destroy(colObject);
    //     GameObject damageIndicator = Instantiate(damageIndicatorPrefab);
    //     damageIndicator.transform.position = transform.position;
    // }
    
}
