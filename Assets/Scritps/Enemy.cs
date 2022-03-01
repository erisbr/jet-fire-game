using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rig;

    private Transform backPoint;

    private Animator animador;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        backPoint = GameObject.Find("backPoint").GetComponent<Transform>();
        animador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rig.velocity = new Vector2(-speed, rig.velocity.y);

        
    }

    private void Update()
    {
        if (transform.position.x < backPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bala")
        {
            animador.SetTrigger("Destroy");
            GameController.current.AddScore(10);
            Destroy(gameObject, 0.5f);
        }
    }

    
}
