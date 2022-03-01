using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public float initialTime;
    public float minTime;
    public float maxTime;

    private float timeControl;

    public List<GameObject> enemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeControl += Time.deltaTime;

        if(timeControl>= initialTime)
        {
            Instantiate(enemies[Random.Range(0, enemies.Count)], transform.position + new Vector3(0, Random.Range(0f,4f), 0), transform.rotation);
     
            initialTime = Random.Range(minTime, maxTime);
            timeControl = 0;
        }
    }
}
