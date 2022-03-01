using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //declaração de variáveis
    public float speed;
    public float jumpForce;
    private bool isGrounded;

    private Rigidbody2D rig;
    private Animator animador;
    public GameObject bullet;
    public Transform point;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        animador = GetComponent<Animator>();
   
    }

    private void FixedUpdate()
    {
         //movimentação do personagem
        rig.velocity = new Vector2(speed * Time.deltaTime, rig.velocity.y);

        //pulo do personagem
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            animador.SetBool("isJumping", true);
       
        }

    }   

    void Update()
    {
        //ataque
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(bullet, point.transform.position, point.transform.rotation);
        }
    }
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isGrounded = true;
            animador.SetBool("isJumping", false);
        }
    }
}
