using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Button weaponButton;

    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeInHierarchy); //If it's active it returns true and if it's false it returns false
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }
}
