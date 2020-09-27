using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitions : MonoBehaviour
{
    public static Transitions sharedInstance { get; private set; }

    private Animator anim;
    private Canvas canvas;
    private int toGameTriggerHash;
    private int toMainMenuTriggerHash;

    private void Awake()
    {
        if (sharedInstance != null)
            sharedInstance = this;

        anim = GetComponentInChildren<Animator>();
        canvas = GetComponent<Canvas>();
    }

    private void Start()
    {
        EndFadeTransition();
        toGameTriggerHash = Animator.StringToHash("TransitionToGame");
        toMainMenuTriggerHash = Animator.StringToHash("TransitionToMainMenu");
    }

    public void TransitionToGame()
    {
        PrepareTransition();
        anim.SetTrigger(toGameTriggerHash);
    }

    public void TransitionToMainMenu()
    {
        PrepareTransition();
        anim.SetTrigger(toMainMenuTriggerHash);
    }

    private void PrepareTransition()
    {
        canvas.enabled = true;
        canvas.sortingOrder = 3;
    }

    public void GoToGame()
    {
        GameManager.sharedInstance.StartGame();
    }

    public void GoToMainMenu()
    {
        GameManager.sharedInstance.ShowMainMenu();
    }

    public void EndFadeTransition()
    {
        canvas.sortingOrder = 0;
        canvas.enabled = false;
    }

}
