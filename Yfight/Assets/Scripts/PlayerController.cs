using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed;
    public float jumpForce;
    public ForceMode forceMode = ForceMode.Impulse;
    [SerializeField] private AudioClip shooted;
    [SerializeField] private AudioClip hitted;

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


    //Animation
    public Animator anim;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }
    private void PlayerMovement()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatsIsGround);
        if (Input.GetKey(left))
        {
            rigidbody.velocity = new Vector2(-moveSpeed, rigidbody.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        else if (Input.GetKey(right))
        {
            rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);
            transform.localScale = new Vector2(1, 1);
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
            }
            else
            {
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

            SoundManager.instance.PlaySound(shooted);


        }

        if (rigidbody.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (rigidbody.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetFloat("Speed", Mathf.Abs(rigidbody.velocity.x));
        anim.SetBool("Grounded", isGrounded);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet"){
            SoundManager.instance.PlaySound(hitted);
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
