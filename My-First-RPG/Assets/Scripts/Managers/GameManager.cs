using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance { get; private set; }
    public Transform proyectilesContiner;

    public Vector2 playerSpawnPoint;
    public GameObject player { get; private set; }

    private void Awake()
    {
        if (sharedInstance == null)
            sharedInstance = this;
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = playerSpawnPoint;
    }
}
