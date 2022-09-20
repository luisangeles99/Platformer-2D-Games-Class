using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPText : MonoBehaviour
{
    private int currentHP;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = Player.player.maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        currentHP = Player.player.currentHP;
        Text hp = GetComponent<Text>();
        if (currentHP <= 0) {
            hp.text = "HP: " + 0; 
        }else
            hp.text = "HP: " + currentHP;
    }
}
