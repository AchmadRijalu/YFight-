using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed;
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    //temporary not in used
    public KeyCode shoot;

    private Rigidbody2D rigidbody;

    //disable double jump
    public Transform groundCheckPoint;
    public bool isGrounded;
    public float groundCheckRadius;
    public LayerMask whatsIsGround;


    //shooting 
    public GameObject bullet;
    public Transform throwPoint;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatsIsGround);
        if (Input.GetKey(left))
        {
            rigidbody.velocity = new Vector2(-moveSpeed, rigidbody.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);
        }
        else
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        }
        if (Input.GetKeyDown(shoot))
        {
           GameObject bulletClone = (GameObject)Instantiate(bullet, throwPoint.position, throwPoint.rotation);
            bulletClone.transform.localScale = transform.localScale;

            
        }


        if (rigidbody.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(rigidbody.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

    }
}
