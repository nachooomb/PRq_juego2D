using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    Vector3 InitialPostion;

    GameObject personaje;
    public float AttackRange = 3.5f;

    public float GhostSpeedDelta= 3f;

    // Start is called before the first frame update
    void Start()
    {
        personaje = GameObject.Find("Personaje");

        InitialPostion = transform.position;


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
    }

        public void GoToRespawn()
    {
        transform.position = InitialPostion;
    }
}
