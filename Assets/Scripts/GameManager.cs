using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    const string PLAYER_PREF_HIGHSCORE = "Highscore";

    [Header("Score Elements")]
    public int score;
    public TMPro.TextMeshProUGUI scoreText;
    public int highScore = 0;
    public TMPro.TextMeshProUGUI highScoreText;

    private void Awake()
    {
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

    private void UpdateHighscore()
    {
        this.highScore = PlayerPrefs.GetInt(PLAYER_PREF_HIGHSCORE);
        this.highScoreText.text = "Highscore: " + this.highScore.ToString();
    }
}
