using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Text pointsText;

    public void setup (int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score + " POINTS";
    }

    public void restartButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
