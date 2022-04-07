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
    public Slider speedSlider;
    public Slider mpSlider;

    private int speedMod;


    private void Start()
    {
        speedSlider.value = 0;
    }
   
       

    

    public void SetHUD(Units unit)
    {
        //nameText.text = unit.unitName;
        //levelText.text = "lvl "+ unit.level;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
        mpSlider.maxValue = unit.maxMP;
        mpSlider.value = unit.currentMP;
        speedSlider.maxValue = unit.speedReq;
        speedMod = unit.speedMod;


    }

    
    public void SpeedChange(float time)
    {
        if (speedSlider.value != speedSlider.maxValue)
        {
            speedSlider.value += (time * speedMod * 1);
        }
        
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }


    public void SetMP(int mp)
    {
        mpSlider.value = mp;
    }



}
