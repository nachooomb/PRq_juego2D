using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour : MonoBehaviour
{
    public float bulletSpeed = 2.0f;

    bool faceRigthFire;

    bool Clon = false;

    public Vector3 screenPosition;
    public Vector3 worldPosition;

    Vector3 CharPosition;

    Vector3 Click;

    GameObject personaje;

    Vector3 Rotation;

    // Start is called before the first frame update
    void Start()
    {
        personaje = GameObject.Find("Personaje");
        faceRigthFire = personaje.GetComponent<MovPersonaje>().faceRigth;
        CharPosition = personaje.transform.position;

        screenPosition = Input.mousePosition;
        screenPosition.z = Camera.main.nearClipPlane + 10;
        

        Click = Camera.main.ScreenToWorldPoint(screenPosition);
            Clon= true;
            this.name = "Fire clon";
            Debug.Log( Click);

        float rotZ = Mathf.Atan2(Click.y, Click.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

    }

    // Update is called once per frame
    void Update()
    {

        // if (faceRigthFire == true){
        //     transform.Translate(Time.deltaTime*bulletSpeed , 0, 0);
        // } else {
        //     transform.Translate(Time.deltaTime*bulletSpeed*-1 , 0, 0);
        // }




  

            //MiCubo=Instantiate(this.gameObject, Click, Quaternion.identity);


            transform.Translate(bulletSpeed*Time.deltaTime*-1, 0, 0 );

            if(transform.position.z >=50.0f){
                Destroy(this.gameObject);
            }

        
    }

    void OnTriggerEnter2D(Collider2D col){

        Debug.Log(col.gameObject.name);

    }
}
