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
        if (inventoryPanel.activeInHierarchy)
        {
            ClearInventory();
            FillInventory();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    public void FillInventory()
    {
        WeaponManager weaponManagerScript = FindObjectOfType<WeaponManager>();
        List<GameObject> weapons = weaponManagerScript.GetAllWeapons();
        foreach(GameObject w in weapons)
        {
            Button button = Instantiate(weaponButton, inventoryPanel.transform);
            button.onClick.AddListener(() => weaponManagerScript.ChangeWeapon(w.GetComponent<WeaponDamage>().index));
            button.image.sprite = w.GetComponent<SpriteRenderer>().sprite;

        }

    }

    public void ClearInventory()
    {
        foreach (Transform item in inventoryPanel.transform)
        {
            Destroy(item.gameObject);
        }
    }
}
