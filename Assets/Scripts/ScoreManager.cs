using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int currentScore = 0;

    private int scoreGoal = 0;

    public TextMeshProUGUI victoryMessage;

    public AudioSource audioSource;
    public AudioClip collectClip;
    private float collectVolume = 1f;

    private void Start()
    {
        scoreGoal = FindObjectsOfType<CoinScript>().Length;
        Debug.Log(scoreGoal);
    }

    private void Update()
    {
        if (currentScore == scoreGoal)
            victoryMessage.gameObject.SetActive(true);
    }
    
    public void Increment()
    {
        currentScore++;
        scoreText.text = "Score: " + currentScore;
        
        audioSource.PlayOneShot(collectClip, collectVolume);
    }
}
