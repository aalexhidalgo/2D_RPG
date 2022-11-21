using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int level;
    public int exp;
    [Tooltip("Experience required to level up")]
    public int[] expToLevelUp;

    [Tooltip("Max health per level")]
    public int[] maxHealthLevels;
    private HealthManager healthManagerScript;

    private void Start()
    {
        healthManagerScript = GetComponent<HealthManager>();
        Debug.Log(healthManagerScript);
        AddExperience(0);
    }

    public void AddExperience(int expToAdd)
    {
        exp += expToAdd;
        if (level >= expToLevelUp.Length){return;}
        if (exp >= expToLevelUp[level])
        {
            level++;
            exp -= expToLevelUp[level - 1];
            healthManagerScript.UpdateMaxHealth(maxHealthLevels[level]);
        }
    }
}
