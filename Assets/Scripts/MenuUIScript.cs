using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIScript : MonoBehaviour
{
    public Button MenuPlay;
    public Button MenuExit;
    public Button ExitUICross;
    public GameObject ExitUI;
    public GameObject MenuUI;

    private void Start()
    {
        MenuPlay.onClick.AddListener(PlayButton);
        MenuExit.onClick.AddListener(ExitButton);
        ExitUICross.onClick.AddListener(ExitUICrossButton);
    }

    private void EnableMenuUI()
    {
        MenuUI.SetActive(true);
    }
    private void DisableMenuUI()
    {
        MenuUI.SetActive(false);
    }
    private void EnableExitUI()
    {
        ExitUI.SetActive(true);
    }
    private void DisableExitUI()
    {
        ExitUI.SetActive(false);
    }

    private void PlayButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    private void ExitButton()
    {
        Time.timeScale = 1;
        EnableExitUI();
        DisableMenuUI();
    }
    private void ExitUICrossButton()
    {
        Time.timeScale = 1;
        DisableExitUI();
        EnableMenuUI();
    }
}
