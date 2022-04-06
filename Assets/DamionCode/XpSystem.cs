using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpSystem : MonoBehaviour
{

    public int level;
    public float currentExp;
    public float requiredXp;

    private float lerpTimer;
    private float delayTimer;

    public Image xpBarFront;
    public Image xpBarBack;

    // Start is called before the first frame update
    void Start()
    {
        xpBarFront.fillAmount = currentExp / requiredXp;
        xpBarBack.fillAmount = currentExp / requiredXp;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateXpUi();
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            GainExperienceFlatRate(20);
        }
    }

    public void UpdateXpUi()
    {
        float xpFraction = currentExp / requiredXp;
        float FXP = xpBarFront.fillAmount;
        if (FXP < xpFraction)
        {
            delayTimer += Time.deltaTime;
            xpBarBack.fillAmount = xpFraction;
            if(delayTimer > 3)
            {
                lerpTimer += Time.deltaTime;
                float percentComplete = lerpTimer / 4;
                xpBarFront.fillAmount = Mathf.Lerp(FXP, xpBarBack.fillAmount, percentComplete);
            }
        }
    }

    public void GainExperienceFlatRate(float xpGained)
    {
        currentExp += xpGained;
        lerpTimer = 0f;
    }
}
