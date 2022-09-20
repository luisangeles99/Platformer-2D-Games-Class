using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesText : MonoBehaviour
{
    private int currentLives;

    // Start is called before the first frame update
    void Start()
    {
        currentLives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        currentLives = 3-LevelManager.instance.amountDeath;
        Text lives = GetComponent<Text>();
        if (currentLives <= 0)
        {
            lives.text = "Lives: " + 0;
        }
        else
            lives.text = "Lives: " + currentLives;
    }
}
