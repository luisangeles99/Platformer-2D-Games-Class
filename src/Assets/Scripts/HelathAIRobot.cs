using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelathAIRobot : MonoBehaviour
{
    public static HelathAIRobot instance;

    public Health healthBar;
    public int maxHP = 1000;
    public int currentHP;
    public GameObject Padre;

    //collectibles drops
    public GameObject collectible;
    public float probDrop = 50f;

    //explosion efecto
    public GameObject explosion;
    public Transform reference;

    //tiempo para volver a recibir daño
    public float timeTodmg = 5.0f;
    private float counterdmg=0f;

    

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentHP = maxHP;
        healthBar.maxHealth(maxHP);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void dmgReceived() {
        StartCoroutine(Explosion());
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "FireBall" && RobotBossController.instance.attackable)
        {
      
            Destroy(other.gameObject);
            StartCoroutine(Explosion());
            healthBar.SetHealth(currentHP);
            AudioManager.audioM.playSfx(2);
            
            if (currentHP <= 0)
            {
                RobotBossController.instance.die();
                //float drop = Random.Range(0f, 100f); variables por si no se quiere que siempre suelte algo
                //if (drop <= probDrop)
                Instantiate(collectible, other.transform.position, other.transform.rotation);

            }
        }
        if (other.gameObject.tag == "Player" && !RobotBossController.instance.isDead)
            Player.player.dmgReceived(20);

    }
    

    IEnumerator Explosion()
    {
        var expl = Instantiate(explosion, reference.position, reference.rotation);
        currentHP -= 100;
        RobotBossController.instance.hit();
        yield return new WaitForSeconds(1.0f);
        Destroy(expl);
        yield return new WaitForSeconds(5.0f);
    }
}
