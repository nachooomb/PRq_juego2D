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

    public GameObject AudioMixer_1;
    AudioSource _SourceAudioMixer_1;

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

        
 
        _SourceAudioMixer_1 = AudioMixer_1.GetComponent<AudioSource>();
        _SourceAudioMixer_1.clip = BandaSonora;
        _SourceAudioMixer_1.loop = true;
        _SourceAudioMixer_1.Play();
        _SourceAudioMixer_1.volume = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Metodo para hacer sonar clips de audio
    public void _sfx_PlayOnce(AudioClip sfx_Clip){
        _audioSource.PlayOneShot(sfx_Clip);
    }
}
