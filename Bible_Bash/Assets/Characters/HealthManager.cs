using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public float MaxHealth = 100;
    public float CurrentHealth = 100;

    public Healthbar Healthbar;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            Die();
        }
        Healthbar.UpdateHealth(CurrentHealth, MaxHealth);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
