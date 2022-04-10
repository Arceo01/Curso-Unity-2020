using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Target : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float upForceMin = 12;
    private float upForceMax = 18;
    private float torque = 10;
    private float xBounds = 4;
    private float yBounds = -5;
    private GameManager gameManager;
    public int pointValue;
    private int penalization = 10;
    public ParticleSystem explosionParticles;
    // Start is called before the first frame update
    void Start()
    {
        RandomSpawn();
        //gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void RandomSpawn()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(Randomforce(), ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(),RandomTorque(),
            RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }
    /// <summary>
    /// Generates a aleatory force betwen min and max values and apply it upwards
    /// </summary>
    /// <returns>Vector3</returns>
    private Vector3 Randomforce()
    {
        return Vector3.up * Random.Range(upForceMin, upForceMax);
    }
    /// <summary>
    /// Generates a aleatory value betwen min and max values
    /// </summary>
    /// <returns>Random value</returns>
    private float RandomTorque()
    {
        return Random.Range(-torque, torque);
    }
    /// <summary>
    /// Generates a random spawn position on x axis betwen 2 values and set the y axis to a previously stablished value
    /// </summary>
    /// <returns>Vector3</returns>
    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xBounds, xBounds), yBounds);
    }
    private void OnMouseOver()
    {
        if (gameManager.gameState == GameManager.GameState.inGame)
        {
            Destroy(gameObject);
            Instantiate(explosionParticles, transform.position, explosionParticles.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
        if (gameObject.CompareTag("Death"))
        {
            gameManager.GameOver();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kill Zone"))
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("Good") )
            {
                gameManager.UpdateScore(-penalization);
                gameManager.GameOver();

            }
        }

    }



}
