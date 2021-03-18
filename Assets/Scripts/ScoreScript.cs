using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public static int scoreVal;
    public static int personalRecord = 0;

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
        if (x > personalRecord)
        {
            personalRecord = x;
        }
    }
}
