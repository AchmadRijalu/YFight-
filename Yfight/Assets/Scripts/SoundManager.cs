using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SoundManager instance { get; private set; }
    private AudioSource sound;
    private AudioSource music;

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
        instance = this;


        //Keep this object even when we go to new scene
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //Destroy duplicate gameobjects
        else if (instance != null && instance != this)
            Destroy(gameObject);
    }
    public void PlaySound(AudioClip _sound)
    {
        sound.PlayOneShot(_sound);
    }
}
