using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lives : MonoBehaviour
{
    int lives = 3;
    public bool gameOver = false;
    public TextMeshProUGUI livesText;
    public GameObject gameOverImage;
    public GameObject restartButton;
    public GameObject menuButton;
    public GameObject leftButton;
    public GameObject rightButton;
    
  
    private void Start()
    {
        LivesCount(0);
    }
    public void LivesCount(int subLives) 
    {
        if(gameOver == false) 
        {
            lives -= subLives;
            livesText.text = lives.ToString();
            if(lives <= 0) 
            {
                leftButton.SetActive(false);
                rightButton.SetActive(false);
                gameOverImage.SetActive(true);
                restartButton.SetActive(true);
                menuButton.SetActive(true);
                gameOver = true;
            }
        }
    }
}
