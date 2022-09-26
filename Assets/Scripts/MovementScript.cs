using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class MovementScript : MonoBehaviour
{

    [SerializeField] private float speed = 5f;
    [SerializeField] private PlayerTurn playerTurn;
    private CharacterController _characterController;
    // private CharacterController _characterController2;//
    private bool _groundedPlayer;
    private Vector3 _playerVelocity;
    private float _playerJump = 0.5f;
    private float _gravityValue = -9.82f;
    private GameObject _gameObject;
    
    // private Vector3 velocity;
    // private bool isGrounded = false;
    // [SerializeField]private Transform basePoint;
    // [SerializeField]private float baseRadius = 0.5f;
    // [SerializeField]private LayerMask layerMask;
    private float _xRotation = 0f;
    [SerializeField]private float mouseSensitivity;
    [SerializeField]private Transform mainCamera;

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
            Vector3 playerMove = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
            _characterController.Move(playerMove * (Time.deltaTime * speed));
            
            if (Input.GetButtonDown("Jump") && IsTouchingFloor())
            {
                _playerVelocity.y += Mathf.Sqrt(_playerJump * -3.0f * _gravityValue);
            }
            
            _playerVelocity.y += _gravityValue * Time.deltaTime;
            _characterController.Move(_playerVelocity * Time.deltaTime);
            
            FollowMouse();
        }
    }
    
    private bool IsTouchingFloor()
    {
        RaycastHit hit;
        bool result =  Physics.SphereCast(transform.position, 0.15f, -transform.up, out hit, 1f);
        return result;
    }

    private void FollowMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    
        _characterController.transform.Rotate(Vector3.up * mouseX);
    
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
    
        mainCamera.localRotation = Quaternion.Euler(mouseY, 0f, 0f);
    }

}
