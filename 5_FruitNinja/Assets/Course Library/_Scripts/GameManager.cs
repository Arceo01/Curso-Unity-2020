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
        

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.inGame;
        StartCoroutine (SpawnTarget());
        score = 0;
        UpdateScore(0);
    }
    /// <summary>
    /// Spawns a random object from a list
    /// </summary>
    /// <returns></returns>
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

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        gameState = GameState.gameOver;
        restartButton.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
