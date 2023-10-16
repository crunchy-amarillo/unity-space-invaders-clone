using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    const string PLAYER_PREF_HIGHSCORE = "Highscore";

    [Header("Game Settings")]
    public GameObject gamePanel;
    public TMPro.TextMeshProUGUI gameOverText;

    [Header("Score Elements")]
    public int score;
    public TMPro.TextMeshProUGUI scoreText;
    public int highScore = 0;
    public TMPro.TextMeshProUGUI highScoreText;
    public TMPro.TextMeshProUGUI globalHighScoreText;


    private void Awake()
    {
        Time.timeScale = 0;
        this.gamePanel.SetActive(true);
        this.gameOverText.enabled = false;

        UpdateHighscore();
    }

    public void IncreaseScore(int num)
    {
        this.score += num;
        this.scoreText.text = this.score.ToString();

        if (this.score > this.highScore)
        {
            PlayerPrefs.SetInt(PLAYER_PREF_HIGHSCORE, this.score);
            UpdateHighscore();
        }
    }

    public void StartGame()
    {
        this.gamePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void StopGame()
    {
        this.gameOverText.enabled = true;
        this.score = 0;
        this.scoreText.text = this.score.ToString();

        Time.timeScale = 0;
        this.gamePanel.SetActive(true);

        foreach (GameObject enemyClone in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemyClone);
        }
        foreach (GameObject bulletClone in GameObject.FindGameObjectsWithTag("Bullet"))
        {
            Destroy(bulletClone);
        }
    }

    public void ResetHighscore()
    {
        PlayerPrefs.SetInt(PLAYER_PREF_HIGHSCORE, 0);
        UpdateHighscore();
    }

    private void UpdateHighscore()
    {
        this.highScore = PlayerPrefs.GetInt(PLAYER_PREF_HIGHSCORE);
        this.globalHighScoreText.text = this.highScoreText.text = "Highscore: " + this.highScore.ToString();
    }
}
