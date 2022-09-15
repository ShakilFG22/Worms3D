using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private CharacterController _characterController;
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void SimpleMove(Vector3 move)
    {
        // Vector3 framerateIndependentMovement = move * Time.deltaTime;
        // handleMovement(framerateIndependentMovement);
    }
    
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _characterController.Move(move * (Time.deltaTime * speed));
        // if (charCon)
        // {
        //     handleMovement();
        //     charIsGrounded = charCon.isGrounded;
        // }
        
        
        // if (Input.GetAxis("Horizontal") != 0)
        // {
        //     transform.Translate(-transform.right * (speed * Time.deltaTime * Input.GetAxis("Horizontal")));
        // }
        // if (Input.GetAxis("Vertical") != 0)
        // {
        //     transform.Translate(-transform.forward * (speed * Time.deltaTime * Input.GetAxis("Vertical")));
        // }
    }

    // private void OnControllerColliderHit(ControllerColliderHit hit)
    // {
    //     Debug.Log("collided with the " + hit.gameObject.name);
    // }

    // void handleMovement()
    // {
    //     float vertical = Input.GetAxis("Vertical");
    //     float horizontal = Input.GetAxis("Horizontal");
    //
    //     currentMovement = new Vector3(-userInput.x, charIsGrounded ? 0.0f : -1.0f, userInput.z) * Time.deltaTime;
    //     charCon.Move(currentMovement);
    //
    // }
}
