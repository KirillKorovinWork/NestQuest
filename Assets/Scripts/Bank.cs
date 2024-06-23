using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    public GameManager gameManager;
    private int coins;
    public TextMeshProUGUI coinText;
    void Start()
    {
        CoinsScore(gameManager.playerCoins);
    }
    public void CoinsScore(int coinsAdd) 
    {
        gameManager.playerCoins = gameManager.playerCoins + coinsAdd;
        coinText.text = gameManager.playerCoins.ToString();
    }
    
}
