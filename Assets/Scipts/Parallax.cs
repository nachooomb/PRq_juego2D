using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    GameObject personaje;

    public float parallaxSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        personaje = GameObject.Find ("Personaje") ;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(Camera.main.transform.position.x*parallaxSpeed, 0, 0); 
    }
}
