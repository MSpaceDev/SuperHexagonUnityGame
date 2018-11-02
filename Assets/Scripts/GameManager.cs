using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public float spawnSpeed = 2.0f;

    public Text scoreText;
    public Text highscoreText;
    public Text pressToPlayText;

    private int score;
    private int highscore;

    // Audio
    private AudioSource audioSource;
    public AudioClip[] audioClips;

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
        audioSource = GetComponent<AudioSource>();

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

        Spawner.instance.StopSpawning();
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Interactable"))
            Destroy(g);

        if (score > highscore)
            SaveLoadManager.instance.Save(score);

        score = 0;
        gameStarted = false;
    }

    public void PlaySound(int index)
    {
        audioSource.pitch = Random.Range(0.75f, 1.0f);
        audioSource.clip = audioClips[index];
        audioSource.PlayOneShot(audioSource.clip);
    }
}
