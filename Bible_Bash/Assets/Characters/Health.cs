using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public float MaxHealth = 100;
    private float CurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {
            Die();
        }
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
