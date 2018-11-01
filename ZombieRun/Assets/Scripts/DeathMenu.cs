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
        gameObject.SetActive(false);
	}
	
	
	void Update () {
        if (!isShown)
            return;

        m_transition += Time.deltaTime;
        backgroundImg.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, m_transition);
    }

    public void ToggleEndMenu(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = ((int)score).ToString();
        isShown = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
