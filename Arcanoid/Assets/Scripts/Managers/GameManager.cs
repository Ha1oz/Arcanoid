using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : SingleTone<GameManager>
{ 
    public Text scoreText;

    private int score;

    public Image[] playerHPImage;
    private int indexImage=4;

    [Header("Pause")]

    public Image pauseImg;
    public Sprite[] pauseSprts;
    private bool isPause = false;
    public GameObject panel;
    //----------------------------------------------------------------

    public void PauseMethod() {
        isPause = !isPause;
        panel.SetActive(isPause);
        if (isPause)
        {
            pauseImg.sprite = pauseSprts[1];
            Time.timeScale = 0;
            
            //панель паузы
        }
        else
        {
            pauseImg.sprite = pauseSprts[0];
            Time.timeScale = 1;
            
        }
    }


    public void UpdateScore(int addScore) {
        score += addScore;
        scoreText.text = "Score: " + score.ToString();

        if (score % 100 == 0) {
            FindObjectOfType<Generator>().CreateBoss();
        }
    }

    public void UpdateHPBar()
    {
        playerHPImage[indexImage].enabled = false;
        indexImage--;
    }

    public void GameOver() {
        AudioManager.Instance.PlaySFX(1);

        if (!PlayerPrefs.HasKey("HighScore")) {
            PlayerPrefs.SetInt("HighScore", score);
        }

        if (PlayerPrefs.GetInt("HighScore") < score) {
            PlayerPrefs.SetInt("HighScore", score);
        }

        SceneManager.LoadScene(0);
    }

    public void ChangeLvl(int idLvl) {
        SceneManager.LoadScene(idLvl);
        //bug
        Time.timeScale = 1f;

        if (PlayerPrefs.GetInt("HighScore") < score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

}
