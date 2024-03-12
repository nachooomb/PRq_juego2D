using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovPersonaje : MonoBehaviour
{
    public float speed = 1f;
    public float JumpMultiplier = 2f;


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

        //SALTO   
        if (Input.GetKeyDown(KeyCode.Space)){
            rb2D.AddForce(new Vector2(0,JumpMultiplier), ForceMode2D.Impulse );
        }


        if (Input.GetKeyDown(KeyCode.A)){
            sp2D.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.D)){
            sp2D.flipX = false;
        }

    }
}
