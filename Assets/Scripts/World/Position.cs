using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Position : MonoBehaviour
{
    public static Position positionUnits;

    
   
    
    public  Vector3 playerPosition;
    public Quaternion playerRot;
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

 


}
