using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units : MonoBehaviour
{
    public string unitName;

    public int level;

    public int strength;
    public int defense;

    public int maxHP;
    public int currentHP;

    public int maxMP;
    public int currentMP;

    public int speedReq;
    public int speedMod=1;

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



}
