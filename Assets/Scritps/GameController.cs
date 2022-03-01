using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController current;

    public int score;
    public float scorePerSecond;
    private float scoreUpdate;
    public int coins;
    public Text scoreText;
    public Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        current = this;
    }

    // Update is called once per frame
    void Update()
    {
        scoreUpdate += scorePerSecond * Time.deltaTime;
        score = (int)scoreUpdate;

        scoreText.text = score.ToString();
    }


    public void AddScore(int value)
    {
        scoreUpdate += value;
    }
}
