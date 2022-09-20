using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemsText : MonoBehaviour
{
    private int gems;
    // Start is called before the first frame update
    void Start()
    {
        gems = LevelManager.instance.gemsCollected;
    }

    // Update is called once per frame
    void Update()
    {
        gems = LevelManager.instance.gemsCollected;
        Text amount = GetComponent<Text>();
        if (gems <= 0)
        {
			amount.text = "0";
        }
        else
            amount.text = ""+gems;
    }
}
