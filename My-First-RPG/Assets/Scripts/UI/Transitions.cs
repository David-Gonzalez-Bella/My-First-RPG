using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitions : MonoBehaviour
{
    public static Transitions sharedInstance { get; private set; }

    private Animator anim;
    private Canvas canvas;
    private int fadeTriggerHash;

    private void Awake()
    {
        if (sharedInstance != null)
            sharedInstance = this;

        anim = GetComponentInChildren<Animator>();
        canvas = GetComponent<Canvas>();
    }

    private void Start()
    {
        fadeTriggerHash = Animator.StringToHash("Transition");
    }

    public void FadeTransition()
    {
        canvas.enabled = true;
        canvas.sortingOrder = 3;
        anim.SetTrigger(fadeTriggerHash);
    }

    public void GoToGame()
    {
        GameManager.sharedInstance.StartGame();
    }

    public void EndFadeTransition()
    {
        canvas.sortingOrder = 0;
        canvas.enabled = false;
    }

}
