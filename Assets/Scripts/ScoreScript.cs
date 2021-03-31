using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static int scoreVal;

    TMP_Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TMP_Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreVal < 0)
        {
            score.text = "" + 0;
        } else
        {
            score.text = "" + scoreVal;
        }

        checkBest(scoreVal);
    }

    void checkBest(int x)
    {
        if (x > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", x);
        }
    }
}
