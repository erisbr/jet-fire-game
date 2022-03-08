using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController current;

    public int score;
    private float scorePerSecond = 3;
    private float scoreUpdate;
    public Text scoreText;

    private int life = 3;
    public Text lifeText;

    public int highScore;
    public Text highScoreText;

    public bool playerIsAlive = true;
    public GameObject gameOverPanel;



    // Start is called before the first frame update
    void Start()
    {
        current = this;
        highScore = PlayerPrefs.GetInt("HighScore");
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

        highScoreText.text = "HighScore: " + highScore.ToString();

        if (life <= 0)
        {
            playerIsAlive = false;
        }

        HighScore();

        if(score >= 1500)
        {
            scorePerSecond = 5;
        }
    }


    //adiciona pontos
    public int AddScore(int value)
    {
        scoreUpdate += value;
        return score;
    }

    //adiciona vida
    public void AddLife(int value)
    {
        life += value;
    }

    //remove vida
    public void RemoveLife(int value)
    {
        life -= value;
    }

    //highscore
    public void HighScore()
    {
        if(score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore = score;
        }
    }


    public void GameOver()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    }

