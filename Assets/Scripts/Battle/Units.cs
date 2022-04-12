using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Units : MonoBehaviour
{

    


    public string unitName;

    public int level;

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

        defense += Random.Range(3, 5);
        magicDefense += Random.Range(3, 5);

        speedMod += Random.Range(.1f, .5f);

        ++level;
    }

    public void PostBattleStats(int HP, int MP)
    {
        currentHP = HP;
        currentMP = MP;

    }

}
