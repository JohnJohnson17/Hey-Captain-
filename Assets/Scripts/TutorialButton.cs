using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialButton : MonoBehaviour
{
    public void goMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
