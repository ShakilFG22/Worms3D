using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeapon : MonoBehaviour
{
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform shootingStartPosition;

    private void Update()
    {
        bool IsPlayerTurn = playerTurn.IsPlayerTurn();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (IsPlayerTurn)
            {
                TurnBasedManager.GetInstance().TriggerChangeTurn();
                GameObject newProjectile = Instantiate(projectilePrefab);
                newProjectile.transform.position = shootingStartPosition.position;
                newProjectile.GetComponent<ProjectileScript>().Initialize();
            }
        }
    }
}