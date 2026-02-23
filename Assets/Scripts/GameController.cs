using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject enemy;
    public float spawnTime;
    float m_spawnTime;
    int m_score;
    bool m_isGameOver;
    UIManager m_ui;

    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindAnyObjectByType<UIManager>();
        m_ui.SetScoreText("Score : " + m_score);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isGameOver)
        {
            m_spawnTime = 0;
            m_ui.showGameOverPanel(true);
            return;
        }


        m_spawnTime = m_spawnTime - Time.deltaTime;
        if(m_spawnTime <=0)
        {
            SpawnEnemy();
            m_spawnTime = spawnTime;
        }
    }

    public void SpawnEnemy()
    {
        float ranXpos = Random.Range(-7f, 7f);
        Vector2 spawnPos = new Vector2 (ranXpos, 7f);
        if(enemy != null )
        {
            Instantiate(enemy, spawnPos, Quaternion.identity);
        }
    }

    public void SetScore(int value)
    {
        m_score = value; 
    }
    public int GetScore()
    {
        return m_score;
    }
    public void ScoreIncreament()
    {
        m_score++;
        m_ui.SetScoreText("Score : " +  m_score);
    }
    public void SetGameOverState(bool state)
    {
        m_isGameOver = state;
    }
    public bool IsGameOver()
    {
        return m_isGameOver;
    }
    public void Replay()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
