using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float waitToRespawn=3.0f;

    public int gemsCollected;
    public int amountDeath = 0;
    //siguiente nivel a cargar
    public string levelLoad;
    //para mostrar mensajes de ui
    public GameObject fadeUI, CompleteLevel, levelFailed;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void respawnPlayer() {
        if (amountDeath < 3)
        {
            StartCoroutine(Respawn());
            amountDeath++;
        }
        else
            StartCoroutine(restartLevel());
    }

    private IEnumerator Respawn() {
        Player.player.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitToRespawn);
        Player.player.gameObject.SetActive(true);
        Player.player.transform.position = CheckpointsController.instance.spawn;
        Player.player.currentHP = Player.player.maxHP;
        Player.player.healthBar.SetHealth(Player.player.currentHP);
    }

    public void levelEnd() {
        StartCoroutine(endLevel());
    }

    private IEnumerator endLevel() {
        fadeUI.SetActive(true);
        CompleteLevel.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(levelLoad);
    }

    private IEnumerator restartLevel() {
        levelFailed.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        CheckpointsController.instance.reloadScene();
    }
}
