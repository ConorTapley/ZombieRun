using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score : MonoBehaviour {

    private float m_score = 0.0f;

    private int m_difficultyLevel = 1;
    private int m_maxDifficultyLevel = 10;
    private int m_scoreToNextLevel = 10;

    public TextMeshProUGUI scoreText;
	
	void Start () {
        
	}
	
	
	void Update () {

        if(m_score >= m_scoreToNextLevel)
        {
            LevelUp();
        }

        m_score += Time.deltaTime * m_difficultyLevel;
        scoreText.text = ((int)m_score).ToString();
	}


    void LevelUp()
    {
        if (m_difficultyLevel == m_maxDifficultyLevel) // stop increasing difficulty at level 10;
            return;

        m_scoreToNextLevel *= 2; // when your score = 10 difficulty increses, then 20, 40, 80 etc.
        m_difficultyLevel++;

        GetComponent<PlayerMotor>().SetSpeed(m_difficultyLevel * 20);
    }
}
