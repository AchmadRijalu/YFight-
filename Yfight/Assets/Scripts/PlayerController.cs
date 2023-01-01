using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed;
    public float jumpForce;
    public ForceMode forceMode = ForceMode.Impulse;


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
    public bool canDoubleJump;


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
            transform.localScale = new Vector2(-2,2);
        }
        else if (Input.GetKey(right))
        {
            rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);
            transform.localScale = new Vector2(2, 2);
        }
        else
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }

        if (Input.GetKeyDown(jump))
        {
            Debug.Log(jump + " pressed, then jump");
            if (isGrounded)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
            } else {
                if (canDoubleJump)
                {
                    rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
                    canDoubleJump = false;
                }
            }
        }

        /*if(isGrounded && !Input.GetKeyDown(jump))
        { 
            canDoubleJump = false;
        }*/

        if (Input.GetKeyDown(shoot))
        {
           GameObject bulletClone = (GameObject)Instantiate(bullet, throwPoint.position, throwPoint.rotation);
            bulletClone.transform.localScale = transform.localScale;

            
        } 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet"){
            Debug.Log("hit");
            var magnitude = 1800;
            // calculate force vector
            var force = transform.position - collision.transform.position;
            // normalize force vector to get direction only and trim magnitude
            force.Normalize();
            gameObject.GetComponent<Rigidbody2D>().AddForce(force * magnitude);
        }
        if (collision.gameObject.tag == "Hole")
        {

            PlayerHealth playerHealth = gameObject.GetComponentInChildren<PlayerHealth>();

            playerHealth.InstantDeath();

            Debug.Log("Dead");
        }


    }
    

}
