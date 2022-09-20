using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPointsScript : MonoBehaviour
{
    public int playerCurrentHealthPoints = 2;
    public int enemyCurrentHealthPoints = 2;
    // [HideInInspector]public int currentHealthPoints = 2;
    public static bool isPlayerDead = false;
    private ProjectileScript _projectileScript;

    private void Start()
    {
        
    }

    // public void TakeDamage(int damage)
    // {
    //     currentHealthPoints -= damage;
    //     Debug.Log(currentHealthPoints);
    //     
    //     if (currentHealthPoints <= 0 && isPlayerDead == false)
    //     {
    //         Debug.Log("You are already dead: " + currentHealthPoints);
    //         isPlayerDead = true;
    //         Destroy(gameObject);
    //     }
    // }
    
    void Update()
    {
        
    }

    // private void DealDamage()
    // {
    //     Ray rayFrom = new Ray(transform.position, transform.forward);
    //     RaycastHit hit = default;
    //     if (Physics.Raycast(rayFrom, out hit, Single.MaxValue))
    //     {
    //         if (hit.collider.CompareTag("Player"))
    //         {
    //             Debug.Log(currentHealthPoints + " hp left");
    //             hit.collider.GetComponent<HealthPointsScript>().TakeDamage(1);
    //         }
    //         else
    //         {
    //             Debug.Log("Haha");
    //         }
    //     }
    // }
    //
    
}
