using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text gameOverText;
    public Text scoreText;
    [HideInInspector]
    public int score;
    int RandomScore;
    [HideInInspector]
    public int bestScore;

    private void Start()
    {
        score = 0;
        if(PlayerPrefs.HasKey("BestScore"))
        {
            bestScore = PlayerPrefs.GetInt("BestScore");
        }
        RandomScore = Random.Range(1, 3);
        GetComponent<TapToPlay>().ButtonPlay.onClick.AddListener(Go);
    }

    private void Update()
    {
        scoreText.text = score.ToString() + "m";
        RandomScore = Random.Range(1, 3);
    }

    void ScorePlusPlus()
    {
        if(GetComponent<Live>().lives == 1)
        {
            Invoke("ScorePlusPlus", 1);
            score += RandomScore;
        }
        else if(GetComponent<Live>().lives == 0)
        {
            score += 0;
            Invoke("ScorePlusPlus", 1);
        }
    }

    void Go()
    {
        Invoke("ScorePlusPlus", 1);
    }
}
