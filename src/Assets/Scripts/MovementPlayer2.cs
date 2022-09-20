using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MovementPlayer2 : MonoBehaviour
{
    public Health healthBar;

    public float speed = 7.0f;
    public int maxHP = 100;
    public int currentHP;
    private bool lookingLeft = false;
    private int auxL = 0;
    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            print("HIT");
            HP--;
        }
        if (other.gameObject.tag == "BossShot")
        {
            HP--;
        }
    }*/


    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        healthBar.maxHealth(maxHP);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            lookingLeft = true;
            if (auxL == 0)
            {
                Flip();
            }

        }
        if (Input.GetKey(KeyCode.L))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            lookingLeft = false;
            if (auxL == 1)
            {
                Flip();
            }


        }
        if (Input.GetKey(KeyCode.I))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.K))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "FireBall")
        {
            currentHP -= 25;
            healthBar.SetHealth(currentHP);
            Debug.Log("hit detected p2 and fireball");
            Destroy(other.gameObject);
            healthBar.SetHealth(currentHP);
            if (currentHP <= 0) {
                Destroy(this.gameObject);
            }
        }
    }
}