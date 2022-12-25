using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 10;
    public float currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentHealth);
    }

    public void takeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Debug.Log("dead");
        }
    }
}
