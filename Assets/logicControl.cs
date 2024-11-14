using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class logicControl : MonoBehaviour
{
    public Sprite[] carsprites;
    public Sprite currentCar;
    public Text scoreText;
    public Text highScoreText;
    public TMP_Text displayScoreText;
    public bool isPlayerAlive;
    public int score;
    public int highscore;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("carSprite"))
        {
            ChangeCar(0);
        }
        else
        {
            loadcar();
        }
        score = 0;
        if (!PlayerPrefs.HasKey("highscore"))
        {
            saveHighScore(0);

        } 
        updateHighScore();

    }
    public void ChangeCar(int index)
    {
        saveCar(index);
        loadcar();
    }

    public void loadcar()
    {   
        currentCar = carsprites[PlayerPrefs.GetInt("carSprite")];
    }

    public void saveHighScore(int highscore)
    {
        Debug.Log($"Saving highscore: {highscore}");
        PlayerPrefs.SetInt("highscore",highscore);
        PlayerPrefs.Save();
    }

    public int gameSpeed()
    {
        if (score > 0)
        {
            return Mathf.FloorToInt(Mathf.Pow(score,1f/3f));
        }
        else
        {
            return 1;
        }
    }

    public void loadHighScore()
    {
        highscore = PlayerPrefs.GetInt("highscore");
    }
    public void saveCar(int index)
    {
        PlayerPrefs.SetInt("carSprite", index);
        PlayerPrefs.Save();
    }

    public void play()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }

    public void updateScore()
    {
        
        score++;
        scoreText.text = score.ToString();
        displayScoreText.text = scoreText.text;
    }

    public void updateHighScore()
    {
        loadHighScore();

        // Debugging to check if highscore is being updated and saved correctly
        Debug.Log($"Current score: {score}, Current highscore: {highscore}");

        if (score >= highscore)
        {
            highscore = score;
        }

        highScoreText.text = highscore.ToString();

        // Check if highscore is valid before saving
        Debug.Log($"Updated highscore: {highscore}");
        saveHighScore(highscore);
    }

}
