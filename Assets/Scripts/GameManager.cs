using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public float spawnSpeed = 2.0f;

    public Text scoreText;
    public Text highscoreText;
    public Text pressToPlayText;

    private int score;
    private int highscore;

    private bool gameStarted;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        // Get player's score when game starts
        highscore = SaveLoadManager.instance.Load();

        highscoreText.text = "Best: " + highscore.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameStarted)
        {
            Spawner.instance.StartSpawning(spawnSpeed);
            pressToPlayText.enabled = false;
            gameStarted = true;
        }
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();

        if (score > highscore)
            highscoreText.text = "Best: " + score.ToString();
    }

    public void OnDeath()
    {
        pressToPlayText.enabled = true;
        scoreText.text = "0";
        score = 0;

        Spawner.instance.StopSpawning();
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
            Destroy(g);

        if (score > highscore)
            SaveLoadManager.instance.Save(score);

        gameStarted = false;
    }
}
