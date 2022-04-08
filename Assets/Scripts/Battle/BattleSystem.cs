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

    private int damage;

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
        if (state!=BattleState.ATTACKING||state!=BattleState.WON||state!=BattleState.LOST){
            playerHUD.SpeedChange(Time.deltaTime);
            enemyHUD.SpeedChange(Time.deltaTime);
            if (playerHUD.speedSlider.value == playerHUD.speedSlider.maxValue)
            {
                StartCoroutine(PlayerTurn());
            }
            if (enemyHUD.speedSlider.value == enemyHUD.speedSlider.maxValue)
            {
                StartCoroutine(EnemyTurn());
            }
        }
        
    }

    IEnumerator PlayerAttack()
    {
        yield return new WaitUntil(() => state == BattleState.PLAYERTURN);

        state = BattleState.ATTACKING;
        if (playerUnit.strength - enemyUnit.defense >= 1)
        {
            damage = playerUnit.strength - enemyUnit.defense;
        }
        else
        {
            damage = 1;
        }

        bool isDead = enemyUnit.TakeDamage(damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = playerUnit.unitName+" attacked!";
        playerHUD.speedSlider.value = playerHUD.speedSlider.minValue;

       
      

        if (isDead)
        {
          state = BattleState.WON;
            Object.Destroy(enemyUnit);
            EndBattle();
        }
        else
        {
            state = BattleState.WAITING;
        }


    }
    IEnumerator PlayerMagicAttack()
    {
        Debug.Log("Magic ATTACK");
        yield return new WaitUntil(() => state == BattleState.PLAYERTURN);

        if (playerUnit.currentMP < playerUnit.mpCost)
        {
            yield break;
        }
        state = BattleState.ATTACKING;

        if (playerUnit.magicStrength - enemyUnit.magicDefense >= 1) 
        {
            damage = playerUnit.magicStrength - enemyUnit.magicDefense;
        } 
        else { 
            damage = 1; 
        }
        bool isDead = enemyUnit.TakeDamage(damage);
        playerUnit.currentMP -= playerUnit.mpCost;
        playerHUD.SetMP(playerUnit.currentMP);

        enemyHUD.SetHP(enemyUnit.currentHP);
        dialogueText.text = playerUnit.unitName + " attacked!";
        playerHUD.speedSlider.value = playerHUD.speedSlider.minValue;




        if (isDead)
        {
            state = BattleState.WON;
            Object.Destroy(enemyUnit);
            EndBattle();
        }
        else
        {
            state = BattleState.WAITING;
        }


    }

    IEnumerator EnemyAttack()
    {

        yield return new WaitUntil(()=>state == BattleState.ENEMYTURN);
       
       
            state = BattleState.ATTACKING;

            dialogueText.text = enemyUnit.unitName + " attacks!";

        if (playerUnit.strength - enemyUnit.defense >= 1)
        {
            damage = playerUnit.strength - enemyUnit.defense;
        }
        else
        {
            damage = 1;
        }

        bool isDead = playerUnit.TakeDamage(damage);

            playerHUD.SetHP(playerUnit.currentHP);
        Debug.Log(playerUnit.currentHP);
        enemyHUD.speedSlider.value = enemyHUD.speedSlider.minValue;

        
        if (isDead)
            {
                state = BattleState.LOST;
                EndBattle();
            }
            else
            {
                state = BattleState.WAITING;
            }
        }
    

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "You Win";

        } else if(state == BattleState.LOST)
        {
            
            dialogueText.text = "You Lost";
        }
        else
        {
            state = BattleState.WAITING;
        }
               
    }

    IEnumerator PlayerTurn()
    {yield return new WaitForSeconds(0f);
        dialogueText.text = "Choose your move:";
        
        state = BattleState.PLAYERTURN;
    }
    IEnumerator EnemyTurn()
    {yield return new WaitForSeconds(0f);
        dialogueText.text = "Enemy's move:";
        
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyAttack());
    }

    public void OnPhysicalButton()
    {
        
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        
        StartCoroutine(PlayerAttack());

    }

    public void OnMagicButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }


        StartCoroutine(PlayerMagicAttack());
    }




}
