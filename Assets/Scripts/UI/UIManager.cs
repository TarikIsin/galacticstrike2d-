using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject pausePanel;
    public GameObject GameOverPanel;
    public GameObject FinishPanel;

    bool gamesPaused = false;


    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            PauseStateChange();
        }
    }

    private void PauseStateChange()
    {
        gamesPaused = !gamesPaused;

        if (gamesPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
             pausePanel.SetActive(false);
             Time.timeScale = 1f;
        }
    }

    public void OpenPausePanel()
    {
        if (!gamesPaused)
        {
            PauseStateChange();
        }
    }

    public void ClosePausePanel()
    {
        if (gamesPaused)
        {
            PauseStateChange();
        }
    }

    public void OpenGameOverPanel()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        SoundManager.Instance.PlayMouseClick();
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenFinishPanel()
    {
        FinishPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void MainMenu()
    {
        SoundManager.Instance.PlayMouseClick();
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
        
}
