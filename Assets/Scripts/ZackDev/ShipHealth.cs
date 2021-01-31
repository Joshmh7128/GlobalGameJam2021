using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipHealth : MonoBehaviour
{
    public int currentHealth = 5;
    public int maxHealth = 5;

    public Image[] hearts;

    public void Heal(int healing)
    {
        if (currentHealth == maxHealth & maxHealth < 10)
        {
            maxHealth += 1;
        }

        currentHealth += healing;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateHealth();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        UpdateHealth();
    }

    private void UpdateHealth()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i <= currentHealth - 1)
            {
                hearts[i].enabled = true;
                hearts[i].color = Color.red;
            }
            else if (i <= maxHealth - 1)
            {
                hearts[i].enabled = true;
                hearts[i].color = Color.gray;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
