using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{ 
    
    public Transform point;
    public float minDistance;
    public float maxDistance;

    public GameObject[] platforms;
    public int platformSelector;
    public float[] platformWidiths;

    // Start is called before the first frame update
    void Start()
    {
        //platformWidith = platform.GetComponent<BoxCollider2D>().size.x;

        platformWidiths = new float[platforms.Length];

        for(int i = 0; i < platforms.Length; i++)
        {
            platformWidiths[i] = platforms[i].GetComponent<BoxCollider2D>().size.x;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < point.transform.position.x && GameController.current.playerIsAlive)
        {
            
            float distance = Random.Range(minDistance, maxDistance);
            platformSelector = Random.Range(0, platforms.Length);

            transform.position = new Vector3(transform.position.x + platformWidiths[platformSelector] + distance, transform.position.y, transform.position.z);
            Instantiate(platforms[platformSelector], transform.position, transform.rotation);
        }
    }
}
