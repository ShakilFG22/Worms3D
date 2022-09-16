using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    private int _playerIndex;

    public void SetPlayerTurn(int index)
    {
        _playerIndex = index;
    }
    
    public bool IsPlayerTurn()
    {
        return TurnBasedManager.GetInstance().IsItPlayerTurn(_playerIndex);
    }
}