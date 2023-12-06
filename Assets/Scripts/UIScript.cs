using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public PlayerController playerController;
    public Button GameOverRestart;
    public Button GameOverMenu;
    public Button WinRestart;
    public Button WinMenu;
    public Button Pause;
    public Button PauseRestart;
    public Button PauseResume;
    public Button PauseMenu;
    public GameObject GameOverUI;
    public GameObject PauseMenuUI;
    public GameObject WinUI;
    
    
    public void Start()
    {
        ResetUI();
        GameOverRestart.onClick.AddListener(GameOverRestartButton);
        GameOverMenu.onClick.AddListener(GameOverMenuButton);
        Pause.onClick.AddListener(PauseButton);
        WinRestart.onClick.AddListener(WinRestartButton);
        WinMenu.onClick.AddListener(WinMenuButton);
        PauseRestart.onClick.AddListener(PauseMenuUIRestartButton);
        PauseResume.onClick.AddListener(PauseMenuUIResumeButton);
        PauseMenu.onClick.AddListener(PauseMenuUIMenuButton);
    }
    

    public void ResetUI()
    {
        DisableGameOverUI();
        DisableWinUI();
    }
    
    public void EnableGameOverUI()
    {
        GameOverUI.SetActive(true);
    }
    public void DisableGameOverUI()
    {
        GameOverUI.SetActive(false);
    }

    
    public void EnableWinUI()
    {
        WinUI.SetActive(true);
    }
    public void DisableWinUI()
    {
        WinUI.SetActive(false);
    }

    public void EnablePauseMenuUI()
    {
        PauseMenuUI.SetActive(true);
    }
    public void DisablePauseMenuUI()
    {
        PauseMenuUI.SetActive(false);
    }

    private void PauseMenuUIRestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    private void PauseMenuUIResumeButton()
    {
        Time.timeScale = 1;
        DisablePauseMenuUI();
    }
    private void PauseMenuUIMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

    private void PauseButton()
    {
        Time.timeScale = 0;
        EnablePauseMenuUI();
    }
    private void GameOverRestartButton()
    {        
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        DisableGameOverUI();              
    }
    private void GameOverMenuButton()
    {
        Time.timeScale = 1;    
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
    
    private void WinRestartButton()
    {        
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        DisableWinUI();
    }
    private void WinMenuButton()
    {
        Time.timeScale = 1;        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
}
