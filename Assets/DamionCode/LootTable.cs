using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LootTable : ScriptableObject
{
    [Serializable]
    public class Drop
    {
        public Item drop;
        public int probability;
    }

    public List<Drop> table;

    public Item GetDrop()
    {
        int roll = UnityEngine.Random.Range(0, 100);

        for (int i = 0; i < table.Count; i++)
        {
            roll -= table[i].probability;

            if (roll < 0)
            {
                return table[i].drop;
            }
        }


        return table[0].drop;
    }
}
