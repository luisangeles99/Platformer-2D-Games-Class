using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFire : MonoBehaviour
{
    public Transform sword;
    public GameObject firePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !PauseMenu.Paused) {
            LanzarFuego();
        }
    }

    void LanzarFuego() {
        Instantiate(firePrefab, sword.position, sword.rotation);
    }
}
