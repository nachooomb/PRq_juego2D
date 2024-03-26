using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour : MonoBehaviour
{
    public float bulletSpeed = 2.0f;

    bool faceRigthFire;
    GameObject personaje;

    // Start is called before the first frame update
    void Start()
    {
        personaje = GameObject.Find("Personaje");
        faceRigthFire = personaje.GetComponent<MovPersonaje>().faceRigth;
    }

    // Update is called once per frame
    void Update()
    {

        if (faceRigthFire == true){
            transform.Translate(Time.deltaTime*bulletSpeed , 0, 0);
        } else {
            transform.Translate(Time.deltaTime*bulletSpeed*-1 , 0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D col){

        Debug.Log(col.gameObject.name);

    }
}
