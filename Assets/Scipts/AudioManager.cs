using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioClip BandaSonora;
    public AudioClip sfx_button;
    public AudioClip sfx_coin;
    public AudioClip sfx_dead;
    public AudioClip sfx_fuego;
    public AudioClip sfx_ghost;

    AudioSource _audioSource;

    void Awake(){
        //Singleton
        if (Instance != null && Instance!= this){
            Destroy(this.gameObject);
        }else{
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        _audioSource.clip = BandaSonora;
        _audioSource.Play();
        _audioSource.volume = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void _sfx_dead(){
        _audioSource.PlayOneShot(sfx_dead);
    }
}
