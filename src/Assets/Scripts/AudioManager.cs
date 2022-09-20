using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioM;

    public AudioSource[] soundEffects;

    public AudioSource bgm, levelEndMusic;

    private void Awake()
    {
        audioM = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSfx(int element) {
        soundEffects[element].Stop();
        soundEffects[element].Play();
    }
}
