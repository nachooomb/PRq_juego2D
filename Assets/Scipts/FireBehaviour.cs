using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour : MonoBehaviour
{
    public float bulletSpeed = 2.0f;

    public float destroyDelay = 2.5f;
    bool faceRigthFire;
    GameObject personaje;

    private Rigidbody2D fireballRB;

    // inicializa rigidbody2D para poder utilizarlo cuando la funcion shootFireball se ejecuta 
    private void Awake()
    {
        fireballRB = GetComponent<Rigidbody2D>();  
    }

    // Start is called before the first frame update
    void Start()
    {
        personaje = GameObject.Find("Personaje");
        faceRigthFire = personaje.GetComponent<MovPersonaje>().faceRigth;

    }

    // Update is called once per frame
    void Update()
    {
        //fire ball shoot
        //Disparo el la direción en la que mira
            // if (faceRigthFire == true){
            //     transform.Translate(Time.deltaTime*bulletSpeed , 0, 0);
            // } else {
            //     transform.Translate(Time.deltaTime*bulletSpeed*-1 , 0, 0);
            // }
    }

    //disparo en la dirección del puntero
    public void shootFireball (Vector2 direction)
    {
        fireballRB.velocity = direction * bulletSpeed;
        Destroy(gameObject, destroyDelay);
    }
        
    void OnTriggerEnter2D(Collider2D col){

        Debug.Log(col.gameObject.name);
        if (col.gameObject.name == "enemigo_fantasma"){
            Destroy(gameObject);
        }
    }
}
