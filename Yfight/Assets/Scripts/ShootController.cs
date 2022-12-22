using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    // Start is called before the first frame update

    public float bulletSpeed;

    private Rigidbody2D rigidBody;

    public GameObject bulletEffect;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = new Vector2(bulletSpeed * transform.localScale.x, 0);

    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(bulletEffect, transform.position, transform.rotation);
        Destroy(bulletEffect);
    }
}
