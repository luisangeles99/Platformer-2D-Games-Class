using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player player;

    //health variables
    public Health healthBar;
    public int maxHP = 100;
    public int currentHP;
    public float invincibleTime;
    private float invincibleCounter = 0f;

    //attack with fire and sword
    public Transform sword;
    public GameObject firePrefab;
    private bool isAttacking;
    public float nextFire = 1.5f;
    public float fireRate = .5f;

    //animator
    private Animator anim;
    
    


    private void Awake()
    {
        player = this;
    }

    void Start()
    {
        currentHP = maxHP;
        healthBar.maxHealth(maxHP);
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        //anim set bool for attack
        anim.SetBool("isAttacking", isAttacking);

        if (invincibleCounter > 0) {
            invincibleCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire1") && !PauseMenu.Paused && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            isAttacking = true;
            StartCoroutine(LanzarFuego());


        }

      
    }

    public void dmgReceived(int dmg) {
        if (invincibleCounter <= 0)
        {
            currentHP -= dmg;
            Debug.Log("Daño recibido");
            healthBar.SetHealth(currentHP);
            if (currentHP <= 0)
            {
                StartCoroutine(DieAnim());
                invincibleCounter = invincibleTime;

            }
            else
            {
                invincibleCounter = invincibleTime;
            }
            AudioManager.audioM.playSfx(0);
            Movement.playerMovement.knockBack();
        }
    }

	//healplayer
	public void healPlayer(int amount)
	{
		currentHP += amount;
		if (currentHP > maxHP)
			currentHP = maxHP;
        healthBar.SetHealth(currentHP);
	}

	IEnumerator LanzarFuego()
    {
        Instantiate(firePrefab, sword.position, sword.rotation);
        yield return new WaitForSeconds(.5f);
        isAttacking = false;
    }

    IEnumerator DieAnim() {
        anim.SetTrigger("Dies");
        yield return new WaitForSeconds(1.0f);
        LevelManager.instance.respawnPlayer();
    }

	

    
}
