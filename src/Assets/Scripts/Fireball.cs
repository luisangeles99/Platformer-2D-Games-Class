using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float Speed = 20.0f;
    public Rigidbody2D rb;
    public float lifetime = .1f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * Speed;
        Destroy(gameObject, lifetime); //para que el objeto se destruya desoués de cierto tiempo
    }

    // Update is called once per frame
    
}
