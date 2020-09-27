﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenusManager : MonoBehaviour
{
    public static MenusManager sharedInstance { get; private set; }

    public GameObject mainMenu;
    public GameObject dieScreen;
    public GameObject wannaLeaveScreen;

    private Vector3 wannaLeaveScreenScale;
    public Button dieScreenPlayAgain;
    public Button dieScreenGoToMenu;
    public Image dieScreenDarkBackgroundAlpha;
    public RectTransform dieScreenDarkBackgroundSize;
    public TMP_Text dieScreenYouDieTitle;

    [HideInInspector] public int leaveHashCode;
    [HideInInspector] public int dieHashCode;

    private void Awake()
    {
        if (sharedInstance == null)
            sharedInstance = this;

        leaveHashCode = Animator.StringToHash("Leaving");
        dieHashCode = Animator.StringToHash("DeadMenu");
        wannaLeaveScreenScale = wannaLeaveScreen.GetComponent<RectTransform>().localScale;
    }

    private void Start()
    {
        dieScreen.gameObject.SetActive(false);
        wannaLeaveScreen.gameObject.SetActive(false);
    }

    public void ResetWannaLeaveScreenScale()
    {
        wannaLeaveScreenScale = new Vector3(0.001f, 0.001f, 1.0f);
    }

    public void ResetDieScreenValues()
    {
        ColorBlock cb = dieScreenPlayAgain.colors;
        cb.normalColor = new Color (1.0f, 1.0f, 1.0f, 0.0f);
        dieScreenPlayAgain.colors = cb;

        cb = dieScreenPlayAgain.colors;
        cb.normalColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        dieScreenGoToMenu.colors = cb;

        dieScreenDarkBackgroundAlpha.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        dieScreenDarkBackgroundSize.sizeDelta = new Vector2(1920, 0);
        dieScreenYouDieTitle.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }
}