using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public bool MainMenuUp = true;
    public static bool SoundIsOn = true;
    public static bool MusicIsOn = true;

    public GameObject pauseMenuUI;
    public GameObject mainMenuUI;
    public GameObject pauseButton;
    public GameObject score;
    public GameObject music;
    public GameObject tapButtons;
    public GameObject soundOff;
    public GameObject musicOff;

    public GameObject musicManager;

    void Start()
    {
        Time.timeScale = 0f;

        if (!SoundIsOn) soundOff.SetActive(true);
        if (!MusicIsOn)
        {
            musicOff.SetActive(true);
            musicManager.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Play()
    {
        mainMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        pauseButton.SetActive(true);
        score.SetActive(true);
        soundOff.SetActive(false);
        musicOff.SetActive(false);

        MainMenuUp = false;

        //AdManager.Instance.ShowBanner();

        Time.timeScale = 1f;
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        musicManager.SetActive(true);

        tapButtons.SetActive(true);
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        musicManager.SetActive(false);

        tapButtons.SetActive(false);
    }
    public void LoadMenu()
    {
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        pauseMenuUI.SetActive(false);
        score.SetActive(false);
        mainMenuUI.SetActive(true);
        MainMenuUp = true;
        GameManager.instance.RestartGame();
    }
    public void SoundToggle()
    {
        if (SoundIsOn)
        {
            SoundIsOn = false;
            soundOff.SetActive(true);
        }
        else
        {
            SoundIsOn = true;
            soundOff.SetActive(false);
        }
    }
    public void MusicToggle()
    {
        if (MusicIsOn)
        {
            MusicIsOn = false;
            musicOff.SetActive(true);
            musicManager.SetActive(false);
        }
        else
        {
            MusicIsOn = true;
            musicOff.SetActive(false);
            musicManager.SetActive(true);
        }
    }
    public void Rate()
    {
        Application.OpenURL("https://play.google.com/store/search?q=pub%3Acontrolmech&c=apps");
    }
    public void Git()
    {

    }
}
