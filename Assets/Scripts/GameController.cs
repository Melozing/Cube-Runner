using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject obstacle;

    public float spawnTime;

    float m_spawnTime;

    int m_score;

    bool m_isGameover;

    UIManager m_ui;


    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;   
        m_ui = FindAnyObjectByType<UIManager>();
        m_ui.SetScoreText("Score : " + m_score);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_isGameover)
        {
            m_spawnTime = 0;
            m_ui.ShowGameOverPanel(true);
            return;
        }

        m_spawnTime -= Time.deltaTime;

        if(m_spawnTime <= 0)
        {
            SpawnObstacle();
            m_spawnTime = spawnTime;
        }
    }

    public void SpawnObstacle()
    {
        float randYpos = Random.Range(-2.75f, -1.2f);

        Vector2 spawnPos = new Vector2(11, randYpos);

        if (obstacle)
        {
            Instantiate(obstacle, spawnPos, Quaternion.identity);
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

    public void ScoreIncrement()
    {
        if (m_isGameover)
            return;

        m_score++;
        m_ui.SetScoreText("Score : " + m_score);
    }

    public bool IsGameOver()
    {
        return m_isGameover;
    } 

    public void SetGameOverState(bool state)
    {
        m_isGameover = state;
    }

    public void Replay()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
