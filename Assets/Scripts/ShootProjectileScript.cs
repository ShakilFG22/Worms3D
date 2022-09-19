using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectileScript : MonoBehaviour
{
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootingStartPosition;
    private HealthPointsScript _healthPointsScript;
    
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
                Debug.Log(_healthPointsScript + " hp left");
                hit.collider.GetComponent<HealthPointsScript>().TakeDamage(1);
            }
            else if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log(_healthPointsScript + " hp left");
                hit.collider.GetComponent<HealthPointsScript>().TakeDamage(1);
            }
            else
            {
                Debug.Log("Haha!!!!");
            }
        }
    }
    
    
    
    
    
    
    
    
    
}

