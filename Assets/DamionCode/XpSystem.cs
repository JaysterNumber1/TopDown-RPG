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
    

    public static int XpNeededToLvl(int currentLevel)
    {
        if (currentLevel == 0)
            return 0;

        return (currentLevel * currentLevel + currentLevel) * 5;
    }

    public void SetExperience (float exp)
    {
        xp += exp;
        float xpNeeded = XpNeededToLvl(level);
        float previousXp = XpNeededToLvl(level - 1);

        if(xp >= xpNeeded)
        {
            LevelUp();
            xpNeeded = XpNeededToLvl(level);
            previousXp = XpNeededToLvl(level - 1);
        }

        xpBarFill.value = (xp - previousXp) / (xpNeeded - previousXp);

        if(xpBarFill.value == xpBarFill.minValue)
        {
            xpBarFill.value = 0;
        }
    }

    public void LevelUp()
    {
        level++;
        
    }

    private void Start()
    {
        level = player.GetComponent<Units>().level;
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("WorldScene"))
        {
            SetExperience(xp);
            
        }
    }
}
