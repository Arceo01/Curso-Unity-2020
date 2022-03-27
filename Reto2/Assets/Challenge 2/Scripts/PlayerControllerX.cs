using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float shootTimer = 0;
    private float spawnInterval = 1.5f;

    // Update is called once per frame
    void Update()
    {
        shootTimer = shootTimer + Time.deltaTime;
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && shootTimer >= spawnInterval)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            shootTimer = 0;
        }
    }
}
