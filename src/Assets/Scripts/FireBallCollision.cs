using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCollision : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        /*
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("hit detected by ball");
            Destroy(this.gameObject);
        }*/
    }
}
