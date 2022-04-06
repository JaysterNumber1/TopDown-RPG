using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public enum BattleState {START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    private float time = Time.deltaTime;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Units playerUnit;
    Units enemyUnit;

    public TextMeshProUGUI dialogueText;

    public BattleState state;

    public BattleHUD playerHUD;
    //public BattleHUD enemyHUD;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    void SetupBattle() 
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit =  playerGO.GetComponent<Units>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Units>();

        dialogueText.text = "A wild " + enemyUnit.unitName + " appears!";

        playerHUD.SetHUD(playerUnit);
        //enemyHUD.SetHUD(enemyUnit);
    }

    private void Update()
    {
        BattleHUD.SpeedChange(time);
        
    }


}
