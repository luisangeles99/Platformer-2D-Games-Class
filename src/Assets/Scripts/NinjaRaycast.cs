using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaRaycast : MonoBehaviour
{
    public Transform referenceNinja;
    public int damage = 10;
    public LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //StartCoroutine(Disparar());
            Disparar();
            Debug.Log("Disparo con Space");
        }
    }

    void Disparar() {

        RaycastHit2D hit = Physics2D.Raycast(referenceNinja.position, referenceNinja.right);

        if (hit)
        { //modificar para campaña
            Debug.Log("Daño a player con space");
            Player player = hit.transform.GetComponent<Player>();
            if (player != null)
            {
                player.dmgReceived(damage);
            }
            line.enabled = true;
            line.SetPosition(0, referenceNinja.position);
            line.SetPosition(1, hit.point);
            

        }
        else {
            line.enabled = true;
            line.SetPosition(0, referenceNinja.position);
            line.SetPosition(1, referenceNinja.position + referenceNinja.right *100);
        }

        /*
        line.enabled = true;

        yield return 1;

        line.enabled = false;*/
    }
}
