using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Units : MonoBehaviour
{


    public GameObject playerPrefab;

    public string unitName;

    public int level;
    public int currentXP;

    public int strength;
    
    public int magicStrength;

    public int defense;
    public int magicDefense;

    public int maxHP;
    public int currentHP;

    public int maxMP;
    public int currentMP;
    public int mpCost;

    public int speedReq;
    public float speedMod=1f;


   

    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public void LevelUp()
    {
        
  

        strength += Random.Range(3, 5);
        magicStrength += Random.Range(3, 5);
        defense+= Random.Range(3, 5);

        magicDefense  += Random.Range(3, 5);
        maxHP += Random.Range(3, 5);
        maxMP += Random.Range(3, 5);

        speedMod += Random.Range(.1f, .5f);

        
        currentXP -= XpSystem.XpNeededToLvl(level);
        level++;

    }

    public int GainXP(int gainingXP)
    {
        return currentXP += gainingXP;
    }

    public void PostBattleStats(int HP, int MP)
    {
        currentHP = HP;
        currentMP = MP;

    }

}
