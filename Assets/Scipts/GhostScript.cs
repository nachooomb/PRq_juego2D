using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    Vector3 InitialPostion;

    GameObject personaje;
    public float AttackRange = 3.5f;

    public float GhostSpeedDelta= 2.5f;

    SpriteRenderer sp2D;

    AudioSource _audioSourceGhost;
 


    // Start is called before the first frame update
    void Start()
    {
        personaje = GameObject.Find("Personaje");

        InitialPostion = transform.position;

        sp2D = this.GetComponent<SpriteRenderer>();

        _audioSourceGhost = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        //calcular distancia
        float GhostSpeed = GhostSpeedDelta * Time.deltaTime;
        
        float RealRange = Vector3.Distance(personaje.transform.position , this.transform.position);

        if (RealRange <= AttackRange){
            transform.position = Vector3.MoveTowards(transform.position, personaje.transform.position, GhostSpeed);

            if(_audioSourceGhost.isPlaying == false){
                _audioSourceGhost.Play();
            }
        }else {
            transform.position = Vector3.MoveTowards(transform.position, InitialPostion, GhostSpeed*1.5f);
        
            if((transform.position == InitialPostion) && (_audioSourceGhost.isPlaying == true)){
                _audioSourceGhost.Stop();
            }
        };

        if (personaje.transform.position.x <= transform.position.x){
            sp2D.flipX = false;
            //_audioSourceGhost.pitch = 2f;
        } else {
            sp2D.flipX = true;
            //_audioSourceGhost.pitch = -2f;
        }
        
    }

        public void GoToRespawn()
    {
        transform.position = InitialPostion;
    }
}
