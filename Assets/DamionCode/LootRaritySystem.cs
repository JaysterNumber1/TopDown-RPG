using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootRaritySystem : MonoBehaviour
{
    public int[] table =
    {
        60,
        30,
        10
    };

    public int total;
    public int randomNumber;
    void Start()
    {
        foreach(var item in table)
        {
            total += item;
        }

        randomNumber = Random.Range(0, total);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
