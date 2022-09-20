using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBird : MonoBehaviour
{
    public Health healthBar;
    public int maxHP = 25;
    public int currentHP;

    //collectibles drops
    public GameObject collectible;
    public float probDrop = 100f;

    //particle System
    public ParticleSystem particleExplosion;
    public Transform reference;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        healthBar.maxHealth(maxHP);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "FireBall")
        {
            Explosion();
            currentHP -= 25;
            healthBar.SetHealth(currentHP);
            Debug.Log("hit detected p2 and fireball");
            Destroy(other.gameObject);
            healthBar.SetHealth(currentHP);
            AudioManager.audioM.playSfx(2);
            if (currentHP <= 0)
            {
                Destroy(gameObject);
                //float drop = Random.Range(0f, 100f); variables por si no se quiere que siempre suelte algo
                //if (drop <= probDrop)
                Instantiate(collectible, other.transform.position, other.transform.rotation);

            }
        }
    }

    private void Explosion()
    {
        Instantiate(particleExplosion, reference.position, reference.rotation);

    }
}
