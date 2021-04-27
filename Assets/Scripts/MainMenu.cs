using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public void playGameNow()
    {
        SceneManager.LoadScene("GameScene");
    
    }

    public void tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

   
}
