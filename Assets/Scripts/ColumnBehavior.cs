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
    public float columnPosY;

    public bool getSide;
    public bool hasSwiped;

    public GameOverScript GameOverScreen;

    private void Start()
    {
        ScoreScript.scoreVal = -1;
        getSide = false;
    }

    void Update()
    {
        columnPosX = GameObject.Find("Basic Column").transform.position.x;

        columnPosY = GameObject.Find("Basic Column").transform.position.y;

        swipe();

        updateScore(columnPosX);

        GameOver(columnPosY);
        
    }

    void updateScore(float x)
    {
        if (x > 0.004)
        {
            if (getSide)
            {
                incrementScore();
                hasSwiped = false;
            } else if (ScoreScript.scoreVal < 0) {
                incrementScore();
                hasSwiped = false;
            }

            getSide = false;

        } else if (x < 0.002)
        {
            if (!getSide)
            {
                hasSwiped = false;
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
        if (x < -2.0)
        {
            GameOverScreen.setup(ScoreScript.scoreVal);
            isGameOver = true;
        }
    }

    void swipe()
    {
        if (isGameOver == false && hasSwiped == false)
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
                if (startPos != endPos)
                {
                    hasSwiped = true;
                }
            }

        }

    }
    
}
