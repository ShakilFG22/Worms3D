using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// public enum BattleState {START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    // Unit playerUnit;
    // Unit enemyUnit;

    // public BattleState state;
    
    void Start()
    {
        // state = BattleState.START;
        SetupBattle();
    }

    void SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerGO.GetComponent<Unit>();
        
        GameObject enemyGo = Instantiate(enemyPrefab, enemyBattleStation);
        enemyGo.GetComponent<Unit>();

        // dialogueText.text = "A wild " + enemyUnit.unitName + " approaches";
    }
}
