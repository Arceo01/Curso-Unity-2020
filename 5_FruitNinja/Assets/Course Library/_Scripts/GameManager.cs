using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        loading, inGame, gameOver
    }
    public GameState gameState;
    public TextMeshProUGUI gameOverText;
    public List<GameObject> targetPrefabs;
    private float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    public Button restartButton;
    private int _score;
    public GameObject titleScreen;
    private int score

    {
        set
        {
            _score = Mathf.Clamp(value, 0,9999);
        }
        get
        {
            return _score;
        }
    }
    private int numberOfLifes = 4;
    public List<GameObject> lives;

    private void Start()
    {
        ShowMaxScore();
    }
    /// <summary>
    /// Start the gameplay changing the value of the state of the game
    /// </summary>
    public void StartGame(int difficulty)
    {
        gameState = GameState.inGame;
        StartCoroutine(SpawnTarget());
        spawnRate /= difficulty;
        score = 0;
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        numberOfLifes -= difficulty;
        for (int i = 0; i < numberOfLifes; i++)
        {
            lives[i].SetActive(true);
        }

    }
    /// <summary>
    /// Spawns a random object from a list
    /// </summary>
    /// <returns></returns>
    /// <param name="difficulty">integer that defines the difficulty of the game</param>
    IEnumerator SpawnTarget()
    {
        while (gameState == GameState.inGame)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);
        }
    }
    /// <summary>
    /// Updates the score & show on screen
    /// </summary>
    /// <param name="scoreToAdd">Points to add to global puntuation</param>
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: \n" + score;
    }
    private const string MAX_SCORE = "Max_Score";

    public void ShowMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE,0);
        scoreText.text = "Max Score:\n" + maxScore;
    }
    private void SetMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE, 0);
        if (score > maxScore)
        {
            PlayerPrefs.SetInt(MAX_SCORE, score);
        }
    }
    public void GameOver()
    {
        numberOfLifes--;
        if(numberOfLifes>=0)
        {
            Image lifeImage = lives[numberOfLifes].GetComponent<Image>();
            var tempColor = lifeImage.color;
            tempColor.a = 0.3f;
            lifeImage.color = tempColor;
        }

        if(numberOfLifes<=0)
        {
            gameOverText.gameObject.SetActive(true);
            gameState = GameState.gameOver;
            restartButton.gameObject.SetActive(true);
            SetMaxScore();
        }

    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
