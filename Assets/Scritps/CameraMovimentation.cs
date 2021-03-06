using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovimentation : MonoBehaviour
{
    public float speed;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }
        // Update is called once per frame
        void Update()
        {

        if (GameController.current.playerIsAlive == true)
        {
            Vector3 newPosition = new Vector3(player.transform.position.x + 6.8f, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPosition, speed * Time.deltaTime);
        }
        }
    }

