using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{

    //public TextMeshProUGUI nameText;
   // public TextMeshProUGUI levelText;
    public Slider hpSlider;
    //public Slider speedSlider;
    public Slider mpSlider;
    
    

    public void SetHUD(Units unit)
    {
        //nameText.text = unit.unitName;
        //levelText.text = "lvl "+ unit.level;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
        mpSlider.maxValue = unit.maxMP;
        mpSlider.value = unit.currentMP;

    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }

   

   /* public void SetSpeed(int speed)
    {
        speedSlider.value = speed;
    }*/

    public void SetMP(int mp)
    {
        mpSlider.value = mp;
    }



}
