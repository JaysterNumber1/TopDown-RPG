using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOptions : MonoBehaviour
{
    [SerializeField]
    private Button inventoryButton;
    [SerializeField]
    private Button partyButton;
    [SerializeField]
    private Button saveButton;
    [SerializeField]
    private Image inventoryBackground;
    [SerializeField]
    private GameObject player;

    private void Start()
    {
        inventoryBackground.gameObject.SetActive(false);
    }


    public void OnInventoryClick()
    {
        inventoryButton.gameObject.SetActive(false);
        partyButton.gameObject.SetActive(false);
        saveButton.gameObject.SetActive(false);
        inventoryBackground.gameObject.SetActive(true);
    }
    public void OnBackClick()
    {

    }
    public void SetMenuButtons()
    {
        inventoryButton.gameObject.SetActive(true);
        partyButton.gameObject.SetActive(true);
        saveButton.gameObject.SetActive(true);
       
    }


}
