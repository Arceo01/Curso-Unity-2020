using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    private float floatForce = 40;
    private float downForce = 30;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;
    private Vector2 yBounds = new Vector2(2,13);
    private float restartDelay = 1.5f;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce);
        }
        if (transform.position.y < yBounds.x)
        {
            transform.localPosition = new Vector3(-3, yBounds.x, 0);
        }
        if (transform.position.y > yBounds.y)
        {
            transform.localPosition = new Vector3(-3, yBounds.y, 0);
            playerRb.AddForce(Vector3.down * downForce);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Destroy(other.gameObject);
            Physics.gravity /= gravityModifier;
            Invoke("Restart", restartDelay);

        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);


        }

    }
    private void Restart()
    {
        SceneManager.LoadSceneAsync(0);
    }

}
