using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public enum BattleState {START, PLAYERTURN, ENEMYTURN, ATTACKING, WAITING, WON, LOST }

public class BattleSystem : MonoBehaviour
{
   

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Units playerUnit;
    Units enemyUnit;

    private bool attacking;



    public TextMeshProUGUI dialogueText;

    public BattleState state;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

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
        enemyHUD.SetHUD(enemyUnit);

        state = BattleState.WAITING;
        
    }

    private void Update()
    {
        if (state != BattleState.ATTACKING){
            playerHUD.SpeedChange(Time.deltaTime);
            enemyHUD.SpeedChange(Time.deltaTime);
            if (playerHUD.speedSlider.value == playerHUD.speedSlider.maxValue)
            {
                PlayerTurn();
            }
            if (enemyHUD.speedSlider.value == enemyHUD.speedSlider.maxValue)
            {
                //enemyTurn();
            }
        }
        
    }

    IEnumerator PlayerAttack()
    {
        enemyUnit.TakeDamage(playerUnit.strength);

        yield return new WaitForSeconds(0f);

    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose your move:";
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerAttack());

    }




}
