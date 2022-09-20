using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour
{
    public Transform[] references;
    public float speed;
    public int currRef;

    public Transform platform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        platform.position = Vector3.MoveTowards(platform.position, references[currRef].position, speed * Time.deltaTime);

        if (Vector3.Distance(platform.position, references[currRef].position) < .05f) {
            currRef++;
            if (currRef > references.Length - 1) {
                currRef = 0;
            }
        }
    }
}
