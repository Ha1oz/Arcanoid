using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Text hgScoreText;
    private int score;

    

    [Header("Sound")]
    public Image soundImg;
    public Color[] soundColor;
    private bool isActive;


    private void Start() {
        if (PlayerPrefs.HasKey("HighScore")) {
            score = PlayerPrefs.GetInt("HighScore");
        }

        hgScoreText.text = "High Score: " + score.ToString();

        if (!PlayerPrefs.HasKey("Sound")) {
            isActive = true;
            return;
        }
        if (PlayerPrefs.GetString("Sound") == "Off") {

            AudioManager manager = FindObjectOfType<AudioManager>();

            AudioSource[] sources = manager.GetComponents<AudioSource>();

            foreach (var item in sources)
            {
                item.enabled = false;
            }
            soundImg.color = soundColor[0];
            isActive = false;
        }

        if (PlayerPrefs.GetString("Sound") == "On") {
            AudioManager manager = FindObjectOfType<AudioManager>();

            AudioSource[] sources = manager.GetComponents<AudioSource>();

            foreach (var item in sources)
            {
                item.enabled = true;
            }
            soundImg.color = soundColor[1];
            isActive = true;
        }

    }

    public void PlayGame() {
        SceneManager.LoadScene(1);
    }

    public void SoundMethod() {
        isActive = !isActive;
        AudioManager manager = FindObjectOfType<AudioManager>();

        AudioSource[] sources = manager.GetComponents<AudioSource>();

        foreach (var item in sources) {
            item.enabled = isActive;
        }

        if (!isActive)
        {
            PlayerPrefs.SetString("Sound", "Off");
            soundImg.color = soundColor[0];
        }
        else {
            PlayerPrefs.SetString("Sound", "On");
            soundImg.color = soundColor[1];
        }


    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void SwitchShip(int indexShip)
    {
        PlayerPrefs.SetInt("SpaceShip", indexShip);
    }

}
