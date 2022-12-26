using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDoubleJump : MonoBehaviour
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
    private void OnTriggerEnter2D(Collider2D collision)
    {

        collision.isTrigger = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player2")
        {

            collider.isTrigger = true;
            Destroy(gameObject);

            Debug.Log("hit player 2");
        }
        if (collision.gameObject.tag == "Player1")
        {
            collider.isTrigger = true;
            Destroy(gameObject);

           

            
            Debug.Log("heal player 1");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
