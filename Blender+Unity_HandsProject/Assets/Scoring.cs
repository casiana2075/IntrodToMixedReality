using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;
    public int maxScore;

    public GameObject Score;
    public GameObject YouWonText;
    public GameObject NotBadText;
    public GameObject GoodHitText;
    public GameObject WowText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    public void AddScore(int newScore) 
    {
        score += newScore;    
    }

    public void UpdateScore() 
    {
        scoreText.text = "Score: " + score; 
    }
    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        if (score >= maxScore)
        {
            NotBadText.SetActive(false);
            GoodHitText.SetActive(false);
            WowText.SetActive(false);
            YouWonText.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
