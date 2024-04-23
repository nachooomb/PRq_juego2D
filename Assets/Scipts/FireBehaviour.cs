using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour : MonoBehaviour
{
    public float bulletSpeed = 2.0f;

    public float destroyDelay = 2.5f;
    bool faceRigthFire;
    GameObject personaje;
    private Camera mainCamera;
    float rotationZ;
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
        mainCamera = Camera.main;

        //position del ratón en pixels de la pantalla
        Vector2 mousePos = Input.mousePosition;
        //de pixel de la pantalla a unidades de unity
        Vector3 point = mainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, mainCamera.nearClipPlane));
        //direccion es el click menos la posicion del personaje (es el punto medio)
        Vector3 direction = point - personaje.transform.position;
        //la rotacion es el arcotangente traducida a grados
        rotationZ = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
        //aplico la rotacion al objeto... al moverse, lo hará en esa direccion
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
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

        //se mueve el objeto
        transform.Translate(bulletSpeed*Time.deltaTime, 0, 0);
        Destroy(gameObject, destroyDelay);
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
