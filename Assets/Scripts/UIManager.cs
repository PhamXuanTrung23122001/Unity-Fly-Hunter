using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameOverPanel;
    public void SetScoreText(string txt)
    {
        if (scoreText != null)
        {
            scoreText.text = txt;
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
    }
    public void showGameOverPanel(bool isShow)
    {
        if(gameOverPanel != null) 
            {
                gameOverPanel.SetActive(isShow);
            }
    }
}
