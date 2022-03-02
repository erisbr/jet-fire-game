using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController current;

    private int score;
    private float scorePerSecond = 3;
    private float scoreUpdate;

    public int coins;
    public Text scoreText;
    public Text coinText;

    private int life = 3;
    public Text lifeText;

    public bool playerIsAlive = true;
    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        current = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsAlive)
        {
            scoreUpdate += scorePerSecond * Time.deltaTime;
            score = (int)scoreUpdate;
        }

        scoreText.text = score.ToString();

        lifeText.text = "x " + life.ToString();

        if(life <=0)
        {
            playerIsAlive = false;
        }

    }


    public void AddScore(int value)
    {
        scoreUpdate += value;
    }

    public void AddLife(int value)
    {
        life += value;
    }

    public void RemoveLife(int value)
    {
        life -= value;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
