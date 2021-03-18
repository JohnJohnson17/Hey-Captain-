using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    public TMP_Text pointsText;

    public void setup (int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score + " POINTS";
    }

    public void restartButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void menuButton()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
