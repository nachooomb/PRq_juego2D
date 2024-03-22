using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovPersonaje : MonoBehaviour
{
    public GameObject respawn;
    public float speed = 1f;
    public float jumpMultiplier = 4f;

    public GameObject fireBall;

    bool AbleToJump = false;

    Rigidbody2D rb2D;

    SpriteRenderer sp2D;

    Animator animationController;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = this.GetComponent<Rigidbody2D>();
        sp2D = this.GetComponent<SpriteRenderer>();
        animationController = this.GetComponent<Animator>();

        //La posicion del personaje se ajusta a la posición del GAME OBJETS Respawn
        transform.position = respawn.transform.position;
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
            jumpMultiplier = 8f;
        } else if (Input.GetKeyUp(KeyCode.LeftShift)){
            speed = 1f;
            jumpMultiplier = 4f;
        }

        //Flip presonaje y control animacion Walking
        if (Input.GetKeyDown(KeyCode.A)){
            sp2D.flipX = true;
            animationController.SetBool("activateWalking", true);
        }
        if (Input.GetKeyDown(KeyCode.D)){
            sp2D.flipX = false;
            animationController.SetBool("activateWalking", true);
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            animationController.SetBool("activateWalking", false);
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
            rb2D.AddForce(new Vector2(0, jumpMultiplier), ForceMode2D.Impulse );
        }

        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(fireBall, transform.position, Quaternion.identity);
        }

    }

    public void GoToRespawn()
    {
        transform.position = respawn.transform.position;
    }
}
