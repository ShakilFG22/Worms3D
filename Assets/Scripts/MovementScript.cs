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
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _characterController.Move(move * (Time.deltaTime * speed));
    }
}
