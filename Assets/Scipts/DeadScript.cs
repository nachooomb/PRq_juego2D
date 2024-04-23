using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeadScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col){

        if(col.gameObject.name == "Personaje"){
            GameManager.vidas -= 1;
            col.gameObject.GetComponent<MovPersonaje>().GoToRespawn();
            AudioManager.Instance._sfx_dead();
        }

    }
}
