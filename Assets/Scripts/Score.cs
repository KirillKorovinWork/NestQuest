using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Score : MonoBehaviour
{
    int totalCount = 0;
    public TextMeshProUGUI scoreText;
    public Lives lives;
    private void Start()
    {
        EggScore(0);
    }
    public void EggScore(int scoreAdd)
    {
        if (!lives.gameOver) 
        {
            //Debug.Log(totalCount);
            totalCount = totalCount + scoreAdd;
            scoreText.text = totalCount.ToString();
        }
    }
}
