using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using AppsFlyerSDK;

public class LogicScript : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject startGameScreen;

    [ContextMenu("Increase Score")]


    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        Dictionary<string, string> eventValues = new Dictionary<string, string>();
        eventValues.Add(AFInAppEvents.CURRENCY, "USD");
        eventValues.Add(AFInAppEvents.REVENUE, "0.99");
        eventValues.Add("af_quantity", "1");
        AppsFlyer.sendEvent(AFInAppEvents.PURCHASE, eventValues);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } 
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
    
}
  