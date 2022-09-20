using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    //tipos de items que se pueden recoger
    public bool isGem, isHealthPotion;

    private int healthPotion = 10;
    private bool isCollected;

	//particle System
	public ParticleSystem particlePick;
	public Transform reference;

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
        if (collision.tag == "Player" && !isCollected) {
            if (isGem) {
                LevelManager.instance.gemsCollected++;
                isCollected = true;
                Destroy(gameObject);
				pickEffect();
            }
            if (isHealthPotion) {
                if (Player.player.currentHP < Player.player.maxHP) {
                    Player.player.healPlayer(healthPotion);
                    isCollected = true;
                    Destroy(gameObject);
					pickEffect();
                }
                    
            }
        }
    }

	private void pickEffect() {
		Instantiate(particlePick, reference.position, reference.rotation);
	}
}
