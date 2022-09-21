using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedManager : MonoBehaviour
{
    private static TurnBasedManager _instance;
    [SerializeField] private PlayerTurn playerOne;
    [SerializeField] private PlayerTurn playerTwo;
    [SerializeField] private float timeBetweenTurns;
    
    private int _currentPlayerIndex;
    private bool _waitingForNextTurn;
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
        if (_waitingForNextTurn)
        {
            _turnDelay += Time.deltaTime;
            if (_turnDelay >= timeBetweenTurns)
            {
                _turnDelay = 0;
                _waitingForNextTurn = false;
                ChangeTurn();
            }
        }
    }

    public bool IsItPlayerTurn(int index)
    {
        if (_waitingForNextTurn)
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
        _waitingForNextTurn = true;
    }

    private void ChangeTurn()
    {
        if (_currentPlayerIndex == 1)
        {
            _currentPlayerIndex = 2;
        }
        else if (_currentPlayerIndex == 2)
        {
            _currentPlayerIndex = 1;
        }
    }
}