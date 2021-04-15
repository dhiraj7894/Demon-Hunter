using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth playerHealth;
    public Slider HealthBar;
    public float maxHealth = 100;
    public float currentHealth;

    void Start()
    {
        playerHealth = this;
        currentHealth = maxHealth;
        HealthBar.maxValue = maxHealth;
    }

    private void Update()
    {
        HealthBar.value = currentHealth;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Black Demon Claw"))
        {
            TakeDamage(5);
        }
    }
    private void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
    }
}
