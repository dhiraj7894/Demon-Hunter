using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth playerHealth;
    public Slider HealthBar;
    public float maxHealth = 100;
    public float HealthGainSpeed = 2;
    public float TakeDamageByDemon = 3;
    private float currentHealth;
    private float currentHealthData;

    public GameObject healEffect;
    void Start()
    {
        playerHealth = this;
        currentHealth = maxHealth;
        currentHealthData = maxHealth;
        HealthBar.maxValue = maxHealth;

    }

    private void Update()
    {
        HealthBar.value = currentHealth;
        Heal();
        heathBarUpdater();

        ///Test
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
        ///
    }

    bool isHealthLow = false;
    void heathBarUpdater()
    {
        if (currentHealth != currentHealthData)
        {
            if (isHealthLow)
            {
                currentHealth += HealthGainSpeed;
            }
            if (!isHealthLow)
            {
                currentHealth -= HealthGainSpeed;
            }
        }

        if (currentHealth >= currentHealthData)
        {
            isHealthLow = false;
        }
        if (currentHealth <= currentHealthData)
        {
            isHealthLow = true;
        }

        

    }
    void Heal()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            healEffect.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            if (currentHealthData<maxHealth)
            {
                currentHealthData = maxHealth;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Black Demon Claw"))
        {
            TakeDamage(TakeDamageByDemon);
        }
    }
    private void TakeDamage(float damageAmount)
    {
        currentHealthData -= (int)damageAmount;
    }
}
