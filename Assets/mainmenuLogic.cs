using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenuLogic : MonoBehaviour
{
    public Sprite[] carsprites;
    public Sprite currentCar;
    public TMP_Text displayHighScoreText;
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
        if (!PlayerPrefs.HasKey("highscore"))
        {
            displayHighScoreText.text = "0";

        }
        else
        {
            displayHighScoreText.text = PlayerPrefs.GetInt("highscore").ToString();
        }

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

   }