using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{

    private Rigidbody2D rigidBody;

    public GameObject Meteor;
    public GameObject MeteorEffect;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(MeteorEffect, transform.position, transform.rotation);
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
        Destroy(gameObject);
        Destroy(MeteorEffect);
    }
}
