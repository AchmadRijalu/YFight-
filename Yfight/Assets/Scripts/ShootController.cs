using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    // Start is called before the first frame update

    public float bulletSpeed;

    private Rigidbody2D rigidBody;

    public GameObject bulletEffect;

    public PlayerHealth playerHealth1;
    public PlayerHealth playerHealth2;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector2(bulletSpeed * transform.localScale.x, 0);

    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(bulletEffect, transform.position, transform.rotation);
        Destroy(gameObject);

       
        
    
        if (collision.gameObject.tag == "Player2")
        {
            var health = collision.GetComponent<PlayerHealth>();
            health.takeDamage(1);
            Debug.Log("hit player 2");
        }
        if (collision.gameObject.tag == "Player1")
        {
            var health = collision.GetComponent<PlayerHealth>();
            health.takeDamage(1);
            Debug.Log("hit player 2");
        }
        Destroy(bulletEffect);
    }
}
