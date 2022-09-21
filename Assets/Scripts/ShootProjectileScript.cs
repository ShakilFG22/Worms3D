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
                newProjectile.GetComponent<ProjectileScript>().Initialize();
                DealDamage();
            }
        }
    }
    private void DealDamage()
    {
        Ray rayFrom = new Ray(transform.position, transform.forward);
        RaycastHit hit = default;
        if (Physics.Raycast(rayFrom, out hit, 250))
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
                // Debug.Log("enemy1"); //went through
                hit.collider.GetComponent<ShootProjectileScript>().TakeDamage(HealthPointDownByOne, _hasHit);
                _enemyHealth -= HealthPointDownByOne;
                Debug.Log("Enemy has " + _enemyHealth + " hp left!"); //still enemyHealth = 2 ???????
                // Debug.Log("enemy3");
            }
            else
            {
                Debug.Log("Haha!!!!");
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
            // Debug.Log("enemy2");
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

