using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovPersonaje : MonoBehaviour
{
    public float speed = 1f;
    public float JumpMultiplier = 4f;

    bool AbleToJump = false;

    Rigidbody2D rb2D;

    SpriteRenderer sp2D;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = this.GetComponent<Rigidbody2D>();
        sp2D = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //MOVIMIENTO
        float mov = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //transform.position = new Vector3 (transform.position.x + mov, transform.position.y, transform.position.z);
        transform.Translate(mov, 0, 0);

        if (Input.GetKeyDown(KeyCode.LeftShift)){
            speed = 3f;
        } else if (Input.GetKeyUp(KeyCode.LeftShift)){
            speed = 1f;
        }

        if (Input.GetKeyDown(KeyCode.A)){
            sp2D.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.D)){
            sp2D.flipX = false;
        }


        //SALTO   


        //rayo para comprobar si el personaje toca el suelo 
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);
        
        //Debug.DrawRay(transform.position, Vector2.down, Color.magenta);
        // Debug.Log(hit.collider.name);

        if (hit) {
            if (hit.collider.name == "Grid"){
                AbleToJump = true;
            } else {
                AbleToJump = false;
            }
        } else {
            AbleToJump = false;
        }

        //salto si puedo saltar es true y pulso la tecla espacio
        if (Input.GetKeyDown(KeyCode.Space) && AbleToJump==true){
            rb2D.AddForce(new Vector2(0,JumpMultiplier), ForceMode2D.Impulse );
        }



    }
}
