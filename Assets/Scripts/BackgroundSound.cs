using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSound : MonoBehaviour
{
    void Awake()
    {
        int numOfSessions = FindObjectsOfType<BackgroundSound>().Length;

        if (numOfSessions > 1)
        {
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(transform.gameObject);
        }
    }
}
