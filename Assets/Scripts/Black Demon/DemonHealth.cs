using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemonHealth : MonoBehaviour
{
    private DemonController demonCon;
    [SerializeField] private Slider healthBar;
    public int TakeDamageByPlayer = 10;

    void Start()
    {
        demonCon = GetComponent<DemonController>();
        healthBar.gameObject.SetActive(false);
        healthBar.maxValue = demonCon.maxHealth;
    }

    private void Update()
    {
        healthBar.value = demonCon.CurrentHealth;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Sword"))
        {
            healthBar.gameObject.SetActive(true);
            demonCon.takeDamage(TakeDamageByPlayer);
        }
    }

}
