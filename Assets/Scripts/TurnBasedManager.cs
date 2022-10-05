using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TurnBasedManager : MonoBehaviour
{
    private static TurnBasedManager _instance;
    [SerializeField] private PlayerTurn playerOne;
    [SerializeField] private PlayerTurn playerTwo;
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject enemyCamera;
    [SerializeField] private GameObject thirdCamera;
    [SerializeField] private float timeBetweenTurns;
    private int _currentPlayerIndex;
    private bool _isWaitingForNextTurn; 
    private float _turnDelay;
    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            _currentPlayerIndex = 1;
            playerOne.SetPlayerTurn(1);
            playerTwo.SetPlayerTurn(2);
        }
    }
    private void Update()
    {
        if (_isWaitingForNextTurn)
        {
            _turnDelay += Time.deltaTime;
            if (_turnDelay >= timeBetweenTurns)
            {
                _turnDelay = 0;
                _isWaitingForNextTurn = false;
                ChangeTurn();
            }
        }
    }

    public bool IsItPlayerTurn(int index)
    {
        if (_isWaitingForNextTurn)
        { 
            return false;
        }
        return index == _currentPlayerIndex;
    }

    public static TurnBasedManager GetInstance()
    {
        return _instance;
    }

    public void TriggerChangeTurn()
    {
        _isWaitingForNextTurn = true;
    }

    private void ChangeTurn()
    {
        if (_currentPlayerIndex == 1)
        {
            playerCamera.gameObject.SetActive(false);
            _currentPlayerIndex = 2;
            enemyCamera.gameObject.SetActive(true);
        }
        else if (_currentPlayerIndex == 2)
        {
            enemyCamera.gameObject.SetActive(false);
            _currentPlayerIndex = 1;
            playerCamera.gameObject.SetActive(true);
        }
    }

    public void ChangeToThirdCamera()
    {
        thirdCamera.gameObject.SetActive(true);
    }    
    public void ChangeScene3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        thirdCamera.gameObject.SetActive(true);
    }
}