using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnBehavior : MonoBehaviour
{
    bool isGameOver = false;

    Vector2 startPos, endPos, direction;
    float touchTimeStart, touchTimeFinish, timeInterval;

    [Range(0.05f, 1f)]
    public float throwForce = 0.3f;

    public float columnPosX;

    public bool getSide;

    public GameOverScript GameOverScreen;

    private void Start()
    {
        ScoreScript.scoreVal = 0;
    }

    void Update()
    {
        columnPosX = GameObject.Find("Basic Column").transform.position.x;

        swipe();

        updateScore(columnPosX);

        GameOver(columnPosX);
        
    }

    void updateScore(float x)
    {
        if (x > 0.0)
        {
            if (getSide == true)
            {
                incrementScore();
            }

            getSide = false;

        }

        if (x < 0.0)
        {
            if (!getSide)
            {
                incrementScore();
            }

            getSide = true;
        }
    }

    void incrementScore()
    {
        ScoreScript.scoreVal += 1;
    }

    void GameOver(float x)
    {
        if (x > 1.2 || x < -1.2)
        {
            GameOverScreen.setup(ScoreScript.scoreVal);
            isGameOver = true;
        }
    }

    void swipe()
    {
        if (isGameOver == false)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                touchTimeStart = Time.time;
                startPos = Input.GetTouch(0).position;
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                touchTimeFinish = Time.time;
                timeInterval = touchTimeFinish - touchTimeStart;
                endPos = Input.GetTouch(0).position;
                direction = startPos - endPos;
                GetComponent<Rigidbody2D>().AddForce(-direction / timeInterval * throwForce);
            }
        }
    }
    
}
