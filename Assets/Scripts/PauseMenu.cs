using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField] private GameObject pauseMenuUI;
    // private GameObject _shootProjectileScript;

    // private void Start()
    // {
    //     _shootProjectileScript = new GameObject();
    //     _shootProjectileScript = GameObject.Find("ShootProjectileScript");
    // }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        GameObject varGameObject1 = GameObject.FindWithTag("Player");
        GameObject varGameObject2 = GameObject.FindWithTag("Enemy");
        varGameObject1.GetComponent<ShootProjectileScript>().enabled = true;
        varGameObject2.GetComponent<ShootProjectileScript>().enabled = true;
        varGameObject1.GetComponent<MovementScript>().enabled = true;
        varGameObject2.GetComponent<MovementScript>().enabled = true;
        // _shootProjectileScript.GetComponent<ShootProjectileScript>().enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        GameObject varGameObject1 = GameObject.FindWithTag("Player");
        GameObject varGameObject2 = GameObject.FindWithTag("Enemy");
        varGameObject1.GetComponent<ShootProjectileScript>().enabled = false;
        varGameObject2.GetComponent<ShootProjectileScript>().enabled = false;        
        varGameObject1.GetComponent<MovementScript>().enabled = false;
        varGameObject2.GetComponent<MovementScript>().enabled = false;
        
        // Component shootProjectileScript = GameObject.Find("ShootProjectileScript").GetComponent(typeof(ShootProjectileScript));
        // shootProjectileScript.GetComponent<ShootProjectileScript>().enabled = false;
        // _shootProjectileScript.GetComponent<ShootProjectileScript>().enabled = false;
        
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
    }
}
