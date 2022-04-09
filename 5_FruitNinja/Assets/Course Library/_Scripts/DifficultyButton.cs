using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManager = FindObjectOfType<GameManager>();
    }

    void SetDifficulty()
    {
        Debug.Log("El boton " + gameObject.name + " ha sido pulsado");
        gameManager.StartGame();
    }

}
