using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneChanger : MonoBehaviour
{
    public Image loading;
    [SerializeField]
    private float loadingTime = 20f;

    private void Awake()
    {
        
        loading.enabled = false;
    }
    public IEnumerator LoadBattleScene()
    {
        EnableBlackScreen();

        AsyncOperation Load = SceneManager.LoadSceneAsync("BattleScene");

        /*while (!asyncLoad.isDone)
        {
            yield return null;
        }*/
        //yield return new WaitUntil(() => SceneManager.GetActiveScene().isLoaded);

        
        yield return new WaitUntil(() => SceneManager.GetActiveScene().isLoaded);


        Invoke("DisableBlackScreen", loadingTime);
    }

    public IEnumerator LoadWorldScene()
    {
        EnableBlackScreen();

        //yield return new WaitForSeconds(2f);
        AsyncOperation Load = SceneManager.LoadSceneAsync("WorldScene");

        /*while (!asyncLoad.isDone)
        {
            yield return null;
        }*/


        yield return new WaitUntil(() => SceneManager.GetActiveScene().isLoaded);

        Invoke("DisableBlackScreen", loadingTime);
        

    }

    private void DisableBlackScreen()
    {
        loading.enabled = false;
    }

    private void EnableBlackScreen()
    {
        loading.enabled = true;
    }
}
