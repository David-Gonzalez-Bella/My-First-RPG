using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum gameState { mainMenu, inGame }

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance { get; private set; }
    public Transform proyectilesContiner;

    public gameState currentGameState;

    public Vector2 playerSpawnPoint;
    public GameObject player { get; private set; }

    private void Awake()
    {
        if (sharedInstance == null)
            sharedInstance = this;
        currentGameState = gameState.mainMenu;
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = playerSpawnPoint;
    }

    public void StartGame()
    {
        currentGameState = gameState.inGame;
        GameObject.Find("MainMenu").SetActive(false);
    }
}
