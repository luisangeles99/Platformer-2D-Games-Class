using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement playerMovement;

    public float speed = 7.0f;
    private bool lookingLeft = false;
    private int auxL = 0;
    public float jumpForce = 11;
    public Rigidbody2D player;

    
    //ground
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask ground;

    //doublejump
    private bool doubleJump;

    //for knockback of getting damage
    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    //aminator
    private Animator anim;
    public bool isMoving;

    private void Awake()
    {
        playerMovement = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (knockBackCounter <= 0)
        {
            //animation values for change
            anim.SetBool("isGrounded", isGrounded);
            //anim.SetBool("isAttacking", isAttacking); pensar si implementar aqui o en sword fire
            anim.SetBool("isMoving", isMoving);

            if (Input.GetKey(KeyCode.A))
            {
                isMoving = true;
                transform.position += Vector3.left * speed * Time.deltaTime;
                lookingLeft = true;
                if (auxL == 0)
                {
                    Flip();
                }

            }
            else if (Input.GetKey(KeyCode.D))
            {
                isMoving = true;
                transform.position += Vector3.right * speed * Time.deltaTime;
                lookingLeft = false;
                if (auxL == 1)
                {
                    Flip();
                }


            }
            else
                isMoving = false;

            //bool for knowing if player touching ground
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, .2f, ground);

            //jump controller
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (isGrounded)
                {
                    player.velocity = new Vector2(player.velocity.x, jumpForce);
                    doubleJump = true;
                }
                else if (doubleJump)
                {
                    player.velocity = new Vector2(player.velocity.x, jumpForce);
                    doubleJump = false;
                }
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
            }
        }
        else {
            knockBackCounter -= Time.deltaTime;
        }

        
    }

    void Flip()
    {
        if (lookingLeft && auxL == 0)
        {
            transform.Rotate(0f, 180f, 0f);
            auxL = 1;
        }
        else if (!lookingLeft && auxL == 1)
        {
            transform.Rotate(0f, -180f, 0f);
            auxL = 0;

        }
    }

    public void knockBack()
    {
        knockBackCounter = knockBackLength;
        player.velocity = new Vector2(0f, knockBackForce);
        if (!lookingLeft)
        {
            player.velocity = new Vector2(-knockBackForce, player.velocity.y);

        }
        else
            player.velocity = new Vector2(knockBackForce, player.velocity.y);

        anim.SetTrigger("Hit");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlat") {
            transform.parent = collision.transform;
        }
            
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlat")
            transform.parent = null;
    }

}
