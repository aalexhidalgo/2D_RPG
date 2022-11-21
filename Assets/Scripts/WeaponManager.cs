using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public int activeWeapon;
    private List<GameObject> weapons;

    void Start()
    {
        weapons = new List<GameObject>();
        foreach (Transform w in transform)
        {
            weapons.Add(w.gameObject);
        }

        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].SetActive(i == activeWeapon);
        }
    }

    public void ChangeWeapon (int newWeapon)
    {
        weapons[activeWeapon].SetActive(false);
        activeWeapon = newWeapon;
        weapons[activeWeapon].SetActive(true);
    }

    public List<GameObject> GetAllWeapons()
    {
        return weapons;
    }
}
