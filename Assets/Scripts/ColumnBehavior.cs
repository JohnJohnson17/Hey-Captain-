using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnBehavior : MonoBehaviour
{
    bool isGameOver = false;

    bool enableClouds = false;

    bool quit;

    int randClouds;

    public int CHANCE = 50;

    public int CLOUDSSTART = 1;

    Vector2 startPos, endPos, direction;
    float touchTimeStart, touchTimeFinish, timeInterval;

    [Range(0.05f, 1f)]
    public float throwForce = 0.3f;

    public float columnPosX;
    public float columnPosY;

    public bool getSide;
    public bool hasSwiped;

    public GameOverScript GameOverScreen;

    public CloudBehavior clouds;

    public PlayfabManager playfabManager;

    private void Start()
    {
        ScoreScript.scoreVal = -1;
        getSide = false;
        playfabManager.GetLeaderboard();
    }

    void Update()
    {
        columnPosX = GameObject.Find("Basic Column").transform.position.x;

        columnPosY = GameObject.Find("Basic Column").transform.position.y;

        swipe();

        updateScore(columnPosX);

        checkEnableClouds();

        checkClouds();

        if (isGameOver == false)
        {
            GameOver(columnPosY);
        }
        
    }

    void updateScore(float x)
    {
        if (x > 0.004)
        {
            if (getSide)
            {
                incrementScore();
                hasSwiped = false;

                if (enableClouds)
                {
                    setRandNum();

                }
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

                if (enableClouds)
                {
                    setRandNum();

                }

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
            clouds.cloudsGameOver();
            playfabManager.SendLeaderboard(ScoreScript.scoreVal);
            playfabManager.GetLeaderboard();
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
                    SoundManagerScript.playSound("Chop #1");
                    hasSwiped = true;
                }
            }

        }

    }

    //CLOUDS

    void doClouds()
    {
        enableClouds = false;
        setRandNum();
        clouds.setup();
        enableClouds = true;
    }

    void checkClouds()
    {

        if (randClouds == 1 && enableClouds == true)
        {
            doClouds();
        }
    }

    void checkEnableClouds()
    {
        if (ScoreScript.scoreVal == CLOUDSSTART)
        {
            enableClouds = true;
        }
    }

    void setRandNum()
    {
        randClouds = Random.Range(1, CHANCE);
    }
    
}
