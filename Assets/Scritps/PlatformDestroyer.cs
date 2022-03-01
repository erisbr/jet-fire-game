using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    private Transform backPoint;


    private void Start()
    {
        backPoint = GameObject.Find("backPoint").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < backPoint.transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
