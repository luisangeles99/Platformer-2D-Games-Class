using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointsController : MonoBehaviour
{
    public static CheckpointsController instance;

    private Checkpoint[] checkpoints;

    public Vector3 spawn;

    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>();
        spawn = Player.player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DesactivarCPs() {
        for(int i = 0; i< checkpoints.Length; i++)
        {
            checkpoints[i].resetCp();
        }
    }

    public void setSpawnPos(Vector3 newSpawnPos) {
        spawn = newSpawnPos;
    }

    public void reloadScene() {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
