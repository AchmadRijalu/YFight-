using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHeal : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidBody;

    private Collider2D collider;
    public GameObject Meteor;
    [SerializeField] private AudioClip Healed;
    void Start()
    {
        
        collider = GetComponent<Collider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player2")
        {
            SoundManager.instance.PlaySound(Healed);
            collider.isTrigger = true;
            Destroy(gameObject);

            GameObject gameObjectp1 = GameObject.FindWithTag("Player2");
            PlayerHealth playerHealth = gameObjectp1.GetComponentInChildren<PlayerHealth>();

            playerHealth.takeHeal(1);

            Debug.Log("heal player 2");
        }
        if (collision.gameObject.tag == "Player1")
        {
            SoundManager.instance.PlaySound(Healed);
            collider.isTrigger = true;
            Destroy(gameObject);
            
            GameObject gameObjectp1 = GameObject.FindWithTag("Player1");
            PlayerHealth playerHealth = gameObjectp1.GetComponentInChildren<PlayerHealth>();
            
            playerHealth.takeHeal(1);
            Debug.Log("heal player 1");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player2")
        {
            SoundManager.instance.PlaySound(Healed);
            collider.isTrigger = true;
            Destroy(gameObject);

            GameObject gameObjectp1 = GameObject.FindWithTag("Player2");
            PlayerHealth playerHealth = gameObjectp1.GetComponentInChildren<PlayerHealth>();

            playerHealth.takeHeal(1);

            Debug.Log("heal player 2");
        }
        if (collision.gameObject.tag == "Player1")
        {
            SoundManager.instance.PlaySound(Healed);
            collider.isTrigger = true;
            Destroy(gameObject);

            GameObject gameObjectp1 = GameObject.FindWithTag("Player1");
            PlayerHealth playerHealth = gameObjectp1.GetComponentInChildren<PlayerHealth>();

            playerHealth.takeHeal(1);
            Debug.Log("heal player 1");
        }
        collider.isTrigger = false;
    }
}
