using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float currentHealth;
    public bool getDamage;
    public float damageAmount;
    private float maxHealth;

    public Image healthBar;

    public void Start() {
        getDamage = false;
        currentHealth = 100;
        maxHealth = 100;
    }

    public void Update() {
        if (getDamage) {
            if (currentHealth - damageAmount > 0.1f) {
            currentHealth -= damageAmount*100;
            healthBar.fillAmount -= damageAmount;
            getDamage = false;
            }
            else if (currentHealth - damageAmount <= 0.0f) {
                currentHealth = 0;
                getDamage = false;
            }
        }
    }
}