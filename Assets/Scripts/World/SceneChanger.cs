using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
   
    public IEnumerator LoadBattleScene()
    {
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("BattleScene");
        
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public IEnumerator LoadWorldScene()
    {
       
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("WorldScene");
        
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
      
        
        

    }
}
