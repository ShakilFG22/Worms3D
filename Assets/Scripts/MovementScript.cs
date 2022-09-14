using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 10f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(-transform.right * (speed * Time.deltaTime * Input.GetAxis("Horizontal")));

        }

        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(-transform.forward * (speed * Time.deltaTime * Input.GetAxis("Vertical")));
        }
    }
}
