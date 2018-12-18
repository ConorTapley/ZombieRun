using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score : MonoBehaviour {

    private float m_score = 0.0f;

    private int m_difficultyLevel = 1;
    public int maxDifficultyLevel = 30;
    private int m_scoreToNextLevel = 10;
    private bool m_isDead = false;

    public TextMeshProUGUI scoreText;
    public DeathMenu deathMenu;

	void Update () {

        ///stop counting the score when the player dies
        if (m_isDead)
            return;

        //every time you get 10 score
        if(m_score >= m_scoreToNextLevel)
        {
            LevelUp();
        }

        
            m_score += Time.deltaTime * m_difficultyLevel;
            scoreText.text = ((int)m_score).ToString();
       
	}


    void LevelUp()
    {
        if (m_difficultyLevel == maxDifficultyLevel) // stop increasing difficulty at level;
            return;

        m_scoreToNextLevel *= 2; // when your score = 10 difficulty increses, then 20, 40, 80 etc.
        m_difficultyLevel++;

        GetComponent<PlayerMotor>().SetSpeed(m_difficultyLevel * 20);
    }


    public void OnDeath()
    {
        m_isDead = true;

        //if a new highscore is set update it
        if(PlayerPrefs.GetFloat("Highscore") < m_score)
            PlayerPrefs.SetFloat("Highscore", m_score);

        deathMenu.ToggleEndMenu(m_score); // show death menu
    }
}
