using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int currentScore = 0;

    // Start is called before the first frame update
    public void Increment()
    {
        currentScore++;
        scoreText.text = currentScore.ToString();
    }

}
