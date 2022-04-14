using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public int level = 1;
    public float xp { get; private set; }
    public Image xpBarFill;

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

        xpBarFill.fillAmount = (xp - previousXp) / (xpNeeded - previousXp);

        if(xpBarFill.fillAmount == 1)
        {
            xpBarFill.fillAmount = 0;
        }
    }

    public void LevelUp()
    {
        level++;
        
    }
}
