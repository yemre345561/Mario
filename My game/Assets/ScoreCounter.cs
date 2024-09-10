using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField]
    private int score;
    private Text scoreUiDisplay;

    void Start()
    {
        
        score = 0;
        scoreUiDisplay = gameObject.GetComponent<Text>();
        scoreUiDisplay.text = "SCORE: " + score.ToString();
    }

    public void ScoreUpdate()
    {
        score++;
        scoreUiDisplay.text = "SCORE: " + score.ToString();
        //Instance.CoinSFX();
    }
}

