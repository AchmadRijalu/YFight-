using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpShrink : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidBody;

    private Collider2D collider;
    public GameObject Meteor;
    void Start()
    {
        collider = GetComponent<Collider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player2")
        {

            collider.isTrigger = true;
            Destroy(gameObject);

            Debug.Log("Shrink player 2");
        }
        if (collision.gameObject.tag == "Player1")
        {
            collider.isTrigger = true;
            Destroy(gameObject);


            Debug.Log("Shrink player 1");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player2")
        {

            collider.isTrigger = true;
            Destroy(gameObject);

            Debug.Log("Shrink player 2");
        }
        if (collision.gameObject.tag == "Player1")
        {
            collider.isTrigger = true;
            Destroy(gameObject);


            Debug.Log("Shrink player 1");
        }
        collider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
