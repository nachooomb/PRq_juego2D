using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    Vector3 InitialPostion;

    GameObject personaje;
    public float AttackRange = 3.5f;

    public float GhostSpeedDelta= 3f;

    SpriteRenderer sp2D;


    // Start is called before the first frame update
    void Start()
    {
        personaje = GameObject.Find("Personaje");

        InitialPostion = transform.position;

        sp2D = this.GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //calcular distancia
        float GhostSpeed = GhostSpeedDelta * Time.deltaTime;
        
        float RealRange = Vector3.Distance(personaje.transform.position , this.transform.position);

        if (RealRange <= AttackRange){
            transform.position = Vector3.MoveTowards(transform.position, personaje.transform.position, GhostSpeed);

        }else {
            transform.position = Vector3.MoveTowards(transform.position, InitialPostion, GhostSpeed*1.5f);
        };

        if (personaje.transform.position.x <= transform.position.x){
            sp2D.flipX = false;
        } else {
            sp2D.flipX = true;
        }
        
    }

        public void GoToRespawn()
    {
        transform.position = InitialPostion;
    }
}
