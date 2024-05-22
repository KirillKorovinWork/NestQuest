using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class LevelManager : MonoBehaviour
{  
    public GameObject stopImage;
    public GameObject playImage;
    public GameObject gameOverImage;
    public GameObject restartButton;
    public GameObject menuButton;
    public TextMeshProUGUI gameOverText;
    bool isPause = true;

    private void Start()
    {
        Time.timeScale = 1;
    }
    void LoadCurrentScene() 
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Pause()
    {
        if (isPause)
        {
            // когда в меню покидаешь паузу и запускаешь рестарт время в игре не продолжается 
            Time.timeScale = 0;
            stopImage.SetActive(false);
            playImage.SetActive(true);
            restartButton.SetActive(true);
            menuButton.SetActive(true);
            //using gameover image like pause image
            gameOverImage.SetActive(true);
            gameOverText.text = "Pause";
            isPause = false;
        }
        else
        {
            Time.timeScale = 1;
            stopImage.SetActive(true);
            playImage.SetActive(false);
            restartButton.SetActive(false);
            menuButton.SetActive(false);
            //using gameover image like pause image
            gameOverImage.SetActive(false);
            gameOverText.text = "Game over";
            isPause = true;
        }
    }
}
