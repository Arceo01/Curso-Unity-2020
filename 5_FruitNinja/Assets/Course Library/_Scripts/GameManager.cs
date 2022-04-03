using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public List<GameObject> targetPrefabs;
    private float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
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
        while (true)
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
    }
}
