using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip chopOne, chopTwo, chopThree;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {

        chopOne = Resources.Load<AudioClip>("Chop #1");

        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void playSound(string clip)
    {
        switch (clip)
        {
            case "Chop #1":
                audioSrc.PlayOneShot(chopOne);
                break;
            case "Chop #2":
                audioSrc.PlayOneShot(chopTwo);
                break;
            case "Chop #3":
                audioSrc.PlayOneShot(chopThree);
                break;
        }
    }


}
