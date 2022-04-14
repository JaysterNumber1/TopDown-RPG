using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneChanger : MonoBehaviour
{
    public Image loading;
    [SerializeField]
    private float loadingTime;

    private void Awake()
    {
        
        loading.enabled = false;
    }
    public IEnumerator LoadBattleScene()
    {
        loading.enabled = true;
        AsyncOperation Load = SceneManager.LoadSceneAsync("BattleScene");
        
        /*while (!asyncLoad.isDone)
        {
            yield return null;
        }*/
        //yield return new WaitUntil(() => SceneManager.GetActiveScene().isLoaded);
        yield return new WaitUntil(() => SceneManager.GetActiveScene().isLoaded);
        //yield return new WaitForSeconds(loadingTime);
        loading.enabled = false;

    }

    public IEnumerator LoadWorldScene()
    {
        loading.enabled = true;

        //yield return new WaitForSeconds(2f);
        AsyncOperation Load = SceneManager.LoadSceneAsync("WorldScene");

        /*while (!asyncLoad.isDone)
        {
            yield return null;
        }*/

        
        yield return new WaitUntil(() => SceneManager.GetActiveScene().isLoaded);
        //yield return new WaitForSeconds(loadingTime);
        loading.enabled = false;
        

    }
}
