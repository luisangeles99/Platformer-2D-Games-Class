using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public SpriteRenderer SR;
    public Sprite cpon, cpoff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CheckpointsController.instance.DesactivarCPs();    
            SR.sprite = cpon;
            CheckpointsController.instance.setSpawnPos(transform.position);
        }
    }
    public void resetCp() {
        SR.sprite = cpoff;
    }
}
