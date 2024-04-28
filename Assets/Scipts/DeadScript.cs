using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeadScript : MonoBehaviour
{

    public GameObject Fantasma;

    //AudioSource _audioSourceGhost;
    // Start is called before the first frame update

    void Start()
    {
        //_audioSourceGhost = Fantasma.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col){

        if(col.gameObject.name == "Personaje"){
            GameManager.vidas -= 1;
            col.gameObject.GetComponent<MovPersonaje>().GoToRespawn();
            AudioManager.Instance._sfx_PlayOnce(AudioManager.Instance.sfx_dead);

            // if(_audioSourceGhost.isPlaying == true ){
            //     _audioSourceGhost.Stop();
            // }
        }

    }
}
