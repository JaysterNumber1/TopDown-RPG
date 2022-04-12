using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
   
    public IEnumerator LoadBattleScene()
    {
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("BattleScene");
        yield return new WaitUntil(() => SceneManager.GetActiveScene().isLoaded);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public IEnumerator LoadWorldScene()
    {
        //yield return new WaitForSeconds(2f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("WorldScene");
        
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
      
        
        

    }
}
