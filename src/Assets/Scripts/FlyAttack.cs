using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAttack : MonoBehaviour
{
    //puntos de recorrido
    public Transform[] references;
    public float speed;
    public int currRef;

    //para atacar al jugador
    public float distPlayer, chaseSpeed;
    private Vector3 attackPlayer;

    //tiempos para el ataque
    public float timeAttack;
    private float counter;

    //sprite
    public SpriteRenderer sr;

    //cant de ataque
    public int dmg;

   

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < references.Length; i++)
            references[i].parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter > 0)
        {
            counter -= Time.deltaTime;
        }
        else
        {
            if (Vector3.Distance(transform.position, Player.player.transform.position) > distPlayer)
            { //vuela en su rango

                attackPlayer = Vector3.zero;

                transform.position = Vector3.MoveTowards(transform.position, references[currRef].position, speed * Time.deltaTime);

                if (Vector3.Distance(transform.position, references[currRef].position) < .05f)
                {
                    currRef++;
                    if (currRef > references.Length - 1)
                    {
                        currRef = 0;
                    }
                }

                if (transform.position.x < references[currRef].position.x)
                {
                    sr.flipX = false;
                }
                else if (transform.position.x > references[currRef].position.x)
                    sr.flipX = true;
            }
            else //ataca
            {
                if (attackPlayer == Vector3.zero)
                {
                    attackPlayer = Player.player.transform.position;
                }
                if (transform.position.x < attackPlayer.x)
                {
                    sr.flipX = false;
                }
                else if (transform.position.x > attackPlayer.x)
                    sr.flipX = true;
                transform.position = Vector3.MoveTowards(transform.position, attackPlayer, chaseSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, attackPlayer) <= .1f)
                {
                    counter = timeAttack;
                    attackPlayer = Vector3.zero;
                }
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Player.player.dmgReceived(dmg);
    }
}
