using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CloudBehavior : MonoBehaviour
{
    public SpriteRenderer cloudOne;
    public SpriteRenderer cloudTwo;
    public SpriteRenderer cloudThree;

    public TMP_Text cloudText;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void setup()
    {
        anim.SetTrigger("startClouds");
        Debug.Log("Animation called");
        anim.SetTrigger("endClouds");
    }

    public void cloudsGameOver()
    {
        gameObject.SetActive(false);
    }
}
