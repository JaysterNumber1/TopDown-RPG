using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomEncounters : MonoBehaviour
{

    private PlayerLocomotion loco;


    [SerializeField]
    private int minSteps = 5;
    [SerializeField]
    private float timeToCheck=1;
    [SerializeField]
    private float defaultTimeToCheck = 1;
    [SerializeField]
    private float time;
    [SerializeField]
    private float timeBetweenChecks=1;
    [SerializeField]
    private int minChance = 0;
    [SerializeField]
    private int maxChance = 100;
    [SerializeField]
    private float defaultThreshold = 1f;
    [SerializeField]
    private float threshold = 1f;
    [SerializeField]
    private float threshMod = 1f;
    [SerializeField]
    private float value;





    // Start is called before the first frame update
    void Start()
    {

        loco = GetComponent<PlayerLocomotion>();

    }

    // Update is called once per frame
    void Update()
    {
        



    }

    public bool HandleEncounters(float delta)
    {
        if (loco.isMoving)
        {
            time += 1 * delta;
        }
       
            value = Random.Range(minChance, maxChance);
       

        if (minSteps<=loco.stepCounter && value <= threshold&&loco.isMoving&&time >= timeToCheck)
        {
            time = 0;
            timeToCheck = defaultTimeToCheck;
            threshold = defaultThreshold;
            value = 0;
            loco.stepCounter = 0;
            return true;
        }

        else
        {
            if (loco.isMoving&&time>=timeToCheck)
            {
                timeToCheck += timeBetweenChecks;
                threshold += threshMod;
            }
            
            return false;
        }
    }

    
}
