using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

    public TextMeshProUGUI scoreText;
    public Image backgroundImg;
    public bool isShown = false;

    private float m_transition = 0.0f; 

    void Start () {
        gameObject.SetActive(false); ////death menu turned off by default
	}
	
	
	void Update () {
        if (!isShown)
            return;

        m_transition += Time.deltaTime; // transition = fps
        backgroundImg.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, m_transition); // make the menu fade in by the speed of transition
    }

    public void ToggleEndMenu(float score)
    {
        gameObject.SetActive(true); 
        scoreText.text = ((int)score).ToString(); // display the score
        isShown = true; // display the death menu
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // restart button will restart the game scene
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu"); // menu button will take you to the menu scene
    }
}
