using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCoin : MonoBehaviour
{
    private int moeda;
    public Text contadorMoeda;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            moeda += 5;
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        contadorMoeda.text = "x " + moeda.ToString();
    }
}
