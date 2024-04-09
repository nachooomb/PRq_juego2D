using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovPersonaje : MonoBehaviour
{
    public GameObject respawn;
    public float speed = 1f;

    public float speedMultiplier = 4f;
    public float jumpMultiplier = 4f;

    //fire ball shoot
    public GameObject fireBall;
    private Camera MainCamera; 
    //referencia al prefab del proyertil
    [SerializeField]private FireBehaviour fireballScript;


    public bool faceRigth = true;
    bool ableToJump = false;

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

        //fire ball shoot
        MainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        //MOVIMIENTO
        float mov = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        //transform.position = new Vector3 (transform.position.x + mov, transform.position.y, transform.position.z);
        transform.Translate(mov, 0, 0);

        if (Input.GetKeyDown(KeyCode.LeftShift)){
            speed = speedMultiplier;
            jumpMultiplier = 8f;
        } else if (Input.GetKeyUp(KeyCode.LeftShift)){
            speed = 1f;
            jumpMultiplier = 4f;
        }

        //Flip presonaje y control animacion Walking
        if (Input.GetKey(KeyCode.A) && mov < 0){
            sp2D.flipX = true;
            animationController.SetBool("activateWalking", true);
            faceRigth = false;
        }
        else if (Input.GetKey(KeyCode.D) && mov >= 0){
            sp2D.flipX = false;
            animationController.SetBool("activateWalking", true);
            faceRigth = true;
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
                ableToJump = true;
            } else {
                ableToJump = false;
            }
        } else {
            ableToJump = false;
        }

        //salto si puedo saltar es true y pulso la tecla espacio
        if (Input.GetKeyDown(KeyCode.Space) && ableToJump==true){
            rb2D.AddForce(new Vector2(0, jumpMultiplier), ForceMode2D.Impulse );
        }

        //fire ball shoot
        //disparar bolas de fuego rectas en la direción en la que mira el personaje
        if(Input.GetMouseButtonDown(0)){
            Instantiate(fireBall, transform.position, Quaternion.identity);
        }

        //disparar bolas de fuego desde el personaje hacia el cursor
        
        // creamos un vector2 para guardar la posición del ratón en la pantalla
        Vector2 mouseWorldPosition = MainCamera.ScreenToWorldPoint(Input.mousePosition);
        // creamos un vector2 para calcular la direción del proyectil. Restando 2 el vector anterior (la posición del ratón) y la posición de nuestro personaje
        Vector2 aimDirection = mouseWorldPosition - (Vector2)transform.position;

        if(Input.GetMouseButtonDown(1)){
            FireBehaviour projectile = Instantiate(fireballScript, transform.position, Quaternion.identity);
            projectile.shootFireball(aimDirection);
        }

    }

    public void GoToRespawn()
    {
        transform.position = respawn.transform.position;
    }
}
