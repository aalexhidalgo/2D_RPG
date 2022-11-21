using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    //Player and enemy blink
    private bool isBlinking;
    [SerializeField] private float blinkingDuration;
    private float blinkingCounter;
    private SpriteRenderer _characterRenderer;

    public int expWhenDefeated;

    void Start()
    {
        _characterRenderer = GetComponent<SpriteRenderer>();
        UpdateMaxHealth(maxHealth);
    }

    void Update()
    {
        if (isBlinking)
        {
            blinkingCounter -= Time.deltaTime;

            if (blinkingCounter > blinkingDuration * 0.8)
            {
                ToggleColor(false);
            }
            else if (blinkingCounter > blinkingDuration * 0.6)
            {
                ToggleColor(true);
            }
            else if (blinkingCounter > blinkingDuration * 0.4)
            {
                ToggleColor(false);

            }
            else if (blinkingCounter > blinkingDuration * 0.2)
            {
                ToggleColor(true);
            }
            else if (blinkingCounter > 0)
            {
                ToggleColor(false);
            }
            else
            {
                ToggleColor(true);
                isBlinking = false;
                GetComponent<BoxCollider2D>().enabled = true;
                GetComponent<PlayerController>().canMove = true;
            }
        }
    }

    public void DamageCharacter(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            if (gameObject.tag.Equals("Enemy"))
            {
                GameObject.Find("Player").GetComponent<CharacterStats>().AddExperience(expWhenDefeated);
            }
            gameObject.SetActive(false);
        }

        //The player is the only one who can blinks
        if (blinkingDuration > 0)
        {
            isBlinking = true;
            blinkingCounter = blinkingDuration;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<PlayerController>().canMove = false;
        }
    }

    public void UpdateMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = maxHealth;
    }

    private void ToggleColor(bool isVisible)
    {
        Color color = _characterRenderer.color;
        color = new Color(color.r, color.g, color.b, isVisible ? 1 : 0); /*If isVisible is true the alpha will get all the value (255), 
        if it's false the alpha won't get any value (0)*/
        _characterRenderer.color = color;
    }
}
