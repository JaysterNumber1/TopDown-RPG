using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PositionAndUnits : MonoBehaviour
{
    public static PositionAndUnits positionUnits;

    
   
    
    public  Vector3 playerPosition;
    public Quaternion playerRot;
    static bool wasCalled = false;
    public GameObject defaultPlayer;
    public GameObject player;

    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("WorldScene"))
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            playerRot = GameObject.FindGameObjectWithTag("Player").transform.rotation;

        } else
        {
           
            this.transform.position = playerPosition;
            this.transform.rotation = playerRot;
        }
    }
    private void Awake()
    {



        
        SetDefaultPrefab(wasCalled);

        if (!positionUnits)
        {

            
           
            positionUnits = this;
            
            DontDestroyOnLoad(this);
        }
        else
        {


            Destroy(this.gameObject);


        }

        // GameObject.FindGameObjectWithTag("Player").transform.position = playerPosition;
        //positionUnits.transform.position = playerPosition;
// MovePlayer();
    }
        private void SetDefaultPrefab(bool called)
    {
        if (called)
        {
            return;
        }
        else
        {
            player.GetComponent<Units>().unitName = defaultPlayer.GetComponent<Units>().unitName;
            player.GetComponent<Units>().level = defaultPlayer.GetComponent<Units>().level;
            player.GetComponent<Units>().strength = defaultPlayer.GetComponent<Units>().strength;
            player.GetComponent<Units>().magicStrength = defaultPlayer.GetComponent<Units>().magicStrength;
            player.GetComponent<Units>().defense = defaultPlayer.GetComponent<Units>().defense;
            player.GetComponent<Units>().magicDefense = defaultPlayer.GetComponent<Units>().magicDefense;
            player.GetComponent<Units>().maxHP = defaultPlayer.GetComponent<Units>().maxHP;
            player.GetComponent<Units>().currentHP = defaultPlayer.GetComponent<Units>().currentHP;
            player.GetComponent<Units>().maxMP = defaultPlayer.GetComponent<Units>().maxMP;
            player.GetComponent<Units>().currentMP = defaultPlayer.GetComponent<Units>().currentMP;
            player.GetComponent<Units>().mpCost = defaultPlayer.GetComponent<Units>().mpCost;
            player.GetComponent<Units>().speedMod = defaultPlayer.GetComponent<Units>().speedMod;
            player.GetComponent<Units>().speedReq = defaultPlayer.GetComponent<Units>().speedReq;

            wasCalled = true;
            Debug.Log("Called!");
        }
    }
 


}
