using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectileScript : MonoBehaviour
{
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootingStartPosition;
    [SerializeField] private int playerCurrentHealthPoints;
    public TurnBasedManager thirdCamera;
    private int _playerHealth;
    private int _enemyHealth;
    private bool _hasHit;
    private const int HealthPointDownByOne = 1;
    private void Start()
    {
        _playerHealth = playerCurrentHealthPoints;
        _enemyHealth  = playerCurrentHealthPoints;
    }
    private void Update()
    {
        bool isPlayerTurn = playerTurn.IsPlayerTurn();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isPlayerTurn)
            {
                TurnBasedManager.GetInstance().TriggerChangeTurn();
                GameObject newProjectile = Instantiate(projectilePrefab);
                newProjectile.transform.position = shootingStartPosition.position;
                newProjectile.transform.localRotation = shootingStartPosition.rotation;
                newProjectile.GetComponent<ProjectileScript>().Initialize();
                DealDamage();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            _playerHealth = 0;
            _enemyHealth = 0;
            Destroy(gameObject);
            TurnBasedManager.GetInstance().ChangeToThirdCamera();
        }
    }
    // private void OnTriggerEnter()
    // {
    //     if (gameObject.CompareTag("Enemy"))
    //     {
    //         Debug.Log("Hit target");
    //     }
    // }
    private void DealDamage()
    {
        Ray rayFrom = new Ray(transform.position, transform.forward); //Without the projectile it can still hit the target
        RaycastHit hit = default;
        if (Physics.Raycast(rayFrom, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Player"))
            {
                _hasHit = true;
                hit.collider.GetComponent<ShootProjectileScript>().TakeDamage(HealthPointDownByOne, _hasHit);
                _playerHealth -= HealthPointDownByOne;
                Debug.Log("Player has " + _playerHealth + " hp left!");
            }
            else if (hit.collider.CompareTag("Enemy"))
            {
                _hasHit = false;
                hit.collider.GetComponent<ShootProjectileScript>().TakeDamage(HealthPointDownByOne, _hasHit);
                _enemyHealth -= HealthPointDownByOne;
                Debug.Log("Enemy has " + _enemyHealth + " hp left!");
            }
            else
            {
                Debug.Log("Haha missed!!!!");
            }
        }
    }

    public void TakeDamage(int damage, bool hit)
    {
        if (hit == true)
        {
            _playerHealth -= damage;
            playerCurrentHealthPoints = _playerHealth;
        }
        else if (hit == false)
        {
            _enemyHealth -= damage;
            playerCurrentHealthPoints = _enemyHealth;
        }
        if (_playerHealth <= 0 && hit == true)
        {
            Debug.Log("You are already dead: " + _playerHealth);
            Destroy(gameObject);
        }
        else if (_enemyHealth <= 0 && hit == false)
        {
            Debug.Log("You are already dead: " + _enemyHealth);
            Destroy(gameObject);
        }
    }
}

