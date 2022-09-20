using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectileScript : MonoBehaviour
{
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootingStartPosition;
    [SerializeField] private int playerCurrentHealthPoints = 2;
    private int playerHealth;
    private int enemyHealth;
    private bool playerHit;
    private bool enemyHit;
    // public int  enemyCurrentHealthPoints = 2;
    

    // [HideInInspector] public HealthPointsScript _healthPointsScript;
    // private static HealthPointsScript _healthPoints;
    // private int _playerCurrentHp = _healthPoints.playerCurrentHealthPoints;
    // private int _enemyCurrentHp  = _healthPoints.enemyCurrentHealthPoints;

    private void Start()
    {
        int currentHealthPoints = playerCurrentHealthPoints;
        playerHealth = currentHealthPoints;
        enemyHealth  = currentHealthPoints;
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
                playerHit = true;
                hit.collider.GetComponent<ShootProjectileScript>().TakeDamage(1, playerHit);
                Debug.Log("Player has " + playerHealth + " hp left!");
            }
            else if (hit.collider.CompareTag("Enemy"))
            {
                enemyHit = false;
                Debug.Log("enemy1"); //went through
                hit.collider.GetComponent<ShootProjectileScript>().TakeDamage(1, enemyHit);
                Debug.Log("Enemy has " + enemyHealth + " hp left!"); //still enemyHealth = 2 ???????
                Debug.Log("enemy3");
            }
            else
            {
                Debug.Log("Haha!!!!");
            }
        }
    }
    public void TakeDamage(int damage, bool hit)
    {
        if (playerHealth == 1 && hit == true)
        {
            playerHealth -= damage;
            //currentHealthPoints = playerHealth; //Error
        }
        else if (enemyHealth == 1 && hit == false)
        {
            enemyHealth -= damage;
            playerCurrentHealthPoints = enemyHealth;
            Debug.Log("enemy4");
        }
        if (playerHealth == 2 && hit == true)
        {
            playerHealth -= damage;
            playerCurrentHealthPoints = playerHealth;
        }
        else if (enemyHealth == 2 && hit == false)
        {
            enemyHealth = enemyHealth - damage;
            playerCurrentHealthPoints = enemyHealth;
            Debug.Log("enemy2"); //went through
        }

        if (playerHealth <= 0 && hit == true)
        {
            Debug.Log("You are already dead: " + playerHealth);
            Destroy(gameObject);
        }
        else if (enemyHealth <= 0 && hit == false)
        {
            Debug.Log("You are already dead: " + enemyHealth);
            Destroy(gameObject);
        }
    }
}

