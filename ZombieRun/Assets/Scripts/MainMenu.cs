using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Text highScoreText;

    void Start () {
        highScoreText.text = "Highscore : " + ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
	}
	

    public void ToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
