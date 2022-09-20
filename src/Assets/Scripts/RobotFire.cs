using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFire : MonoBehaviour
{
    public float Speed = 20.0f;
    public Rigidbody2D rb;
    public float lifetime = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * Speed;
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            Player.player.dmgReceived(25);
            Destroy(gameObject);
        }
    }
}
