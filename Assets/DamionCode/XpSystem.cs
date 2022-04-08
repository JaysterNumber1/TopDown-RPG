using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpSystem : MonoBehaviour
{

    public int level;
    public float currentExp;
    public float requiredEp;
    public float maxExp;

    public Image xpBarFront;
    public Image xpBarBack;

    // Start is called before the first frame update
    void Start()
    {
        xpBarFront.fillAmount = currentExp / maxExp;
        xpBarBack.fillAmount = currentExp / maxExp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GainExperienceFlatRate(float xpGained)
    {
        currentExp += xpGained;
    }
}
