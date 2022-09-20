using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 4.0f;

    public Transform leftPoint, rightPoint;

    private bool movingRight;
    private bool touchesPlayer = false;
    

    public float moveTime, waitTime;
    private float moveCount, waitCount;

    public Rigidbody2D rb;

    public SpriteRenderer sr;

    //aminator
    public Animator anim;
    public bool isMoving;


    // Start is called before the first frame update
    void Start()
    {
        leftPoint.parent = null;
        rightPoint.parent = null;
        isMoving = false;
        movingRight = true;
        moveCount = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isMoving", isMoving);
        if (moveCount > 0) {
            
            moveCount -= Time.deltaTime;
            if (movingRight)
            {
                isMoving = true;
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
                sr.flipX = false;
                if (transform.position.x > rightPoint.position.x)
                    movingRight = false;
            }
            else
            {
                isMoving = true;
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
                sr.flipX = true;
                if (transform.position.x < leftPoint.position.x)
                    movingRight = true;
            }

            if (moveCount <= 0) {
                waitCount = Random.Range(waitTime*.75f,waitTime*1.4f);
            }

        }
        else if (waitCount > 0) {
            isMoving = false;
            waitCount -= Time.deltaTime;
            rb.velocity = new Vector2(0f, rb.velocity.y);
            if (waitCount <= 0) {
                
                moveCount = Random.Range(moveTime*.8f,moveTime*1.3f);
            }
        }
        if (touchesPlayer) {
            Player.player.dmgReceived(25);
            touchesPlayer = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            touchesPlayer = true;
    }
}
