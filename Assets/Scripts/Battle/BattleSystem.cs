using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public enum BattleState {START, PLAYERTURN, ENEMYTURN, ATTACKING, WAITING, WON, LOST }

public class BattleSystem : MonoBehaviour
{

   

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public GameObject[] prefabs;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Units playerUnit;
    Units enemyUnit;

    private bool attacking;
    private SceneChanger sceneChanger;
    private XpSystem xpSystem;
    public GameObject handle;

    //private IEnumerator playerAttack;
    //private IEnumerator playerMagicAttack;

    



    public TextMeshProUGUI dialogueText;

    public BattleState state;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    private int damage;

    // Start is called before the first frame update
    void Start()
    {
        //playerAttack = PlayerAttack();
        //playerMagicAttack = PlayerMagicAttack();
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        handle = GameObject.FindGameObjectWithTag("PlayerTracker");
        sceneChanger = handle.GetComponent<SceneChanger>();
        xpSystem = handle.GetComponent<XpSystem>();
        
    }

    IEnumerator SetupBattle() 
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit =  playerGO.GetComponent<Units>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Units>();

        dialogueText.text = "A wild " + enemyUnit.unitName + " appears!";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

       

        yield return new WaitForSeconds(2f);

        state = BattleState.WAITING;
        

    }

    private void Update()
    {
        if (state!=BattleState.ATTACKING&&state!=BattleState.WON&&state!=BattleState.LOST&&state!=BattleState.START){
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
        dialogueText.text = playerUnit.unitName + " used Magic!";
       



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

        yield return new WaitUntil(() => state == BattleState.ENEMYTURN);


        state = BattleState.ATTACKING;

       

        dialogueText.text = enemyUnit.unitName + " attacks!";

            if (enemyUnit.strength - playerUnit.defense >= 1)
            {
                damage = enemyUnit.strength - playerUnit.defense;
            }
            else
            {
                damage = 1;
            }

            bool isDead = playerUnit.TakeDamage(damage);

            playerHUD.SetHP(playerUnit.currentHP);
          
           



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
            
           
                playerUnit.currentXP = playerPrefab.GetComponent<Units>().GainXP(enemyUnit.currentXP);
                xpSystem.SetExperience(enemyUnit.currentXP);
               
                Debug.Log(playerUnit.currentXP);
                if (XpSystem.XpNeededToLvl(playerUnit.level) <= playerUnit.currentXP)
                {
                    Debug.Log(playerUnit.currentXP);
                    LevelUp();

                    //xpSystem.LevelUp();

                }
            
             
           
            ChangeHPAndMP();
            StartCoroutine(sceneChanger.LoadWorldScene());

        } else if(state == BattleState.LOST)
        {
            
            dialogueText.text = "You Lost";
        }
        else
        {
            state = BattleState.WAITING;
        }
               
    }

    private void ChangeHPAndMP()
    {
        playerPrefab.GetComponent<Units>().PostBattleStats(playerUnit.currentHP, playerUnit.currentMP);
    }

    private void LevelUp()
    {
       

        //int changeStrength =Random.Range(3, 5);
        //int changeMagicStrength =Random.Range(3, 5);

        //int changeDefense =Random.Range(3, 5);
        //int changeMagicDefense=Random.Range(3, 5);

        //float changeSpeedMod =Random.Range(.1f, .5f);

        playerPrefab.GetComponent<Units>().LevelUp();
        
        
    }

    IEnumerator PlayerTurn()
    {yield return new WaitForSeconds(0f);
        dialogueText.text = "Choose your move:";
        
        state = BattleState.PLAYERTURN;
    }
    IEnumerator EnemyTurn()
    {   
        state = BattleState.ENEMYTURN;
        dialogueText.text = "Enemy's move:";
        Debug.Log("enemy attakcs!");

        enemyHUD.speedSlider.value = enemyHUD.speedSlider.minValue;
        StartCoroutine(EnemyAttack());

        yield return new WaitForSeconds(0f);
    }

    public void OnPhysicalButton()
    {
        
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        playerHUD.speedSlider.value = playerHUD.speedSlider.minValue;
        StartCoroutine(PlayerAttack());
        playerHUD.hideAttackButtons();

    }

    public void OnMagicButton()
    {
        
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
       if (playerUnit.currentMP >= playerUnit.mpCost)
        {

            playerHUD.speedSlider.value = playerHUD.speedSlider.minValue;
            playerHUD.hideAttackButtons();
            StartCoroutine(PlayerMagicAttack());
        }
        
        
        

        
    }
    public void OnAttackButton() 
    {
        playerHUD.setAttackButtons();
    }

    public void OnItemButton()
    {

    }

    public void OnAttackBackButton()
    {
        playerHUD.hideAttackButtons();
    }

    

}
