using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class XpSystem : MonoBehaviour
{
    /*
     * to place on to the player:
     * 
     * private GameObject player;
     * public float xpValue
     * 
     * in Update:
     * 
     * player.GetComponent<XpSystem>().SetExperience(xpValue)
     */
    public GameObject player;

    public int level;
    public float xp;
    public Slider xpBarFill;

    private float xpNeeded;
    private float previousXp;

    public static int XpNeededToLvl(int currentLevel)
    {
        if (currentLevel == 0)
            return 0;

        return (currentLevel);
    }

    public void SetExperience (float exp)
    {
        xp += exp;
        xpNeeded = XpNeededToLvl(level);
        //previousXp = XpNeededToLvl(level - 1);
       
        if (xp >= xpNeeded)
        {
            xpBarFill.value = xp - xpNeeded;

            ++level;
            xpNeeded = XpNeededToLvl(level);
            previousXp = XpNeededToLvl(level - 1);
            xpBarFill.maxValue = XpNeededToLvl(level);

        }
        else
        {

            xpBarFill.value = xp;

        }
        if(xpBarFill.value == xpBarFill.minValue)
        {
            xpBarFill.value = 0;
        }
    }

    public void LevelUp()
    {
        ++level;
        
    }

    private void Start()
    {
        level = player.GetComponent<Units>().level;
        xp = player.GetComponent<Units>().currentXP;
        xpBarFill.value = xp;
        xpBarFill.maxValue = XpNeededToLvl(level);
    }
}
