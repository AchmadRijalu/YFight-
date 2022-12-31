using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
        if(currentHealth <= 0)
        {
            Debug.Log("dead");
            gameObject.SetActive(false);
        }
    }

    public void takeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Debug.Log("dead");
            SceneManager.LoadScene(4);
        }
    }
    public void takeHeal(float amount)
    {
        currentHealth += amount;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    public void InstantDeath()
    {
        currentHealth = 0;
        SceneManager.LoadScene(4);
        //if (currentHealth > maxHealth)
        //{
        //    currentHealth = maxHealth;
        //}
    }

}
