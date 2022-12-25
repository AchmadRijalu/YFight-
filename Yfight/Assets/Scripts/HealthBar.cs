using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
 
    public Image fillImage;
    public PlayerHealth playerHealth;
    public void SetHealth(int health)
    {
        slider.value = health;
    }

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float fillValue = playerHealth.currentHealth / playerHealth.maxHealth;
        
        slider.value = fillValue;
       
    }
}
