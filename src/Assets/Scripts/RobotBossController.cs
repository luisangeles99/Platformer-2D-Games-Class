using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBossController : MonoBehaviour
{
    public static RobotBossController instance;

    public Transform robot;
    public Animator anim;
    public Transform reference;
    public GameObject barrier;
    public GameObject plat;


    public enum states { attacking, hurt, moving, dying, dead};
    public states currentState;


    //movement
    public float moveSpeed;
    public Transform leftPoint, rightPoint;
    private bool moveRight;
    private bool isMoving;


    //attacks
    public GameObject attack;
    public float timeToAttack;
    private float counterAttack;
    private bool isAttacking;
    public bool attackable;

    //robot recibe daño
    public float hurt;
    private float hurtCounter;
    public bool isDead;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentState = states.moving;
        moveRight = true;
        

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isAttacking", isAttacking);
        switch (currentState) {
            case states.attacking:
                attackable = true;
                counterAttack -= Time.deltaTime;
                if (counterAttack<=0) {
                    counterAttack = timeToAttack;
                    
                    StartCoroutine(shoot());
                }
                break;
            case states.moving:
                
                if (moveRight)
                {
                    robot.position +=new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
                    if (robot.position.x > rightPoint.position.x) {
                        robot.localScale = new Vector3(-1f, 1f, 1f);
                        reference.transform.Rotate(0f, -180f, 0f);
                        moveRight = false;
                        currentState = states.attacking;
                        counterAttack = timeToAttack;
                        isMoving = false;
                    }
                }
                else {
                    robot.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
                    if (robot.position.x < leftPoint.position.x)
                    {
                        robot.localScale = new Vector3(1f, 1f, 1f);
                        reference.transform.Rotate(0f, 180f, 0f);
                        moveRight = true;
                        currentState = states.attacking;
                        counterAttack = timeToAttack;
                        isMoving = false;
                    }
                }
                break;
            case states.hurt:
                if (hurtCounter>0) {
                    hurtCounter -= Time.deltaTime;
                    if (hurtCounter <= 0) {
                        currentState = states.moving;
                        isMoving = true;
                    }
                }
                break;
            case states.dying:
                currentState = states.dead;
                break;
            case states.dead:
                anim.SetBool("isDead", isDead);
                isDead = true;
                break;

        }
    }
    public void hit() {
        currentState = states.hurt;
        hurtCounter = hurt;
        anim.SetTrigger("Hit");
        attackable = false;
    }

    public void die() {
        currentState = states.dying;
        anim.SetTrigger("Dies");
        barrier.SetActive(false);
        plat.SetActive(true);
    }

    IEnumerator shoot() {
        isAttacking = true;
        yield return new WaitForSeconds(.75f);
        Instantiate(attack, reference.position, reference.rotation);
        isAttacking = false;

    }
    
}
