using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //declaração de variáveis
    private float speed = 400;
    private float jumpForce = 12;
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
        if (GameController.current.playerIsAlive)
        {
            rig.velocity = new Vector2(speed * Time.deltaTime, rig.velocity.y);
        }

        //pulo do personagem
        if (Input.GetKey(KeyCode.Space) && isGrounded && GameController.current.playerIsAlive)
        {
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            animador.SetBool("isJumping", true);
        }

    }   

    void Update()
    {
        //ataque
        if (Input.GetKeyDown(KeyCode.X) && GameController.current.playerIsAlive)
        {
            Instantiate(bullet, point.transform.position, point.transform.rotation);
        }

        //game over
        if(GameController.current.playerIsAlive == false)
        {
            GameController.current.gameOverPanel.SetActive(true);
            speed = 0;
        }

        if(GameController.current.score >= 1000)
        {
            speed = 510;
        }

    }
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isGrounded = true;
            animador.SetBool("isJumping", false);
        }

        if(collision.gameObject.tag == "GameOver")
        {
            GameController.current.playerIsAlive = false;
        }
    }

    //adicionando e removendo vida em caso de colisão com inimigos e/ou power ups
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Life")
        {
            GameController.current.AddLife(1);
        }

        if(collision.gameObject.tag == "Enemy" && GameController.current.playerIsAlive)
        {
            GameController.current.RemoveLife(1);

        }

    }

}
