using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour{
    [SerializeField] private Text m_score;
    [SerializeField] private GameManager m_game;
    
    private void Update(){
        m_score.text = m_game.Score.ToString();
    }

    private void Reset(){
        m_score = GetComponent<Text>();
    }
}
