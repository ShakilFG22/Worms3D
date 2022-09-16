using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private PlayerTurn playerTurn;
    private CharacterController _characterController;
    private bool _groundedPlayer;
    private Vector3 _playerVelocity;
    private float _playerJump = 0.5f;
    private float _gravityValue = -9.81f;
    
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (playerTurn.IsPlayerTurn())
        {
            _groundedPlayer = _characterController.isGrounded;
            if (_groundedPlayer && _playerVelocity.y < 0)
            {
                _playerVelocity.y = 0f;
            }
            
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _characterController.Move(move * (Time.deltaTime * speed));

            if (Input.GetButtonDown("Jump") && IsTouchingFloor())
            {
                _playerVelocity.y += Mathf.Sqrt(_playerJump * -3.0f * _gravityValue);
            }
            
            _playerVelocity.y += _gravityValue * Time.deltaTime;
            _characterController.Move(_playerVelocity * Time.deltaTime);
        }
    }
    
    private bool IsTouchingFloor()
    {
        RaycastHit hit;
        bool result =  Physics.SphereCast(transform.position, 0.15f, -transform.up, out hit, 1f);
        return result;
    }

    
}
