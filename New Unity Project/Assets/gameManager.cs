﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{

    public bool P1Ready = false, P2Ready = false, bellsRung = false, P1Shot = false, P2Shot = false, gameStarted = false;
    public float bellCount = 0;
    int odds;
    public int oddsMin, oddsMax, oddsThreshold, randomTimeMin, randomTimeMax, randomTime;
    public GameObject menuObject;
    public AudioClip bellDing;
    Text menuText;
    AudioSource soundz;
    public AudioClip[] throwOffSounds;
    private AudioClip chosenSound;

    // Start is called before the first frame update
    void Start()
    {
        menuText = menuObject.GetComponent<Text>();
        soundz = GetComponent<AudioSource>();
        odds = Random.Range(oddsMin, oddsMax);
    }

    // Update is called once per frame
    void Update()
    {
        if (P1Ready == true && P2Ready == false)
        {
            menuText.color = Color.red;
        }
        if (P2Ready == true && P1Ready == false)
        {
            menuText.color = Color.blue;
        }
        if (P2Ready == false && P1Ready == false)
        {
            menuText.color = Color.black;
        }
        if (P2Ready == true && P1Ready == true)
        {
            menuText.color = Color.white;
            menuText.text = "";
            if(gameStarted == false)
            {
                ringBell();
                gameStarted = true;
            }
        }
        if(bellCount >= 3)
        {
            bellsRung = true;
        }

        if (P1Shot == true)
        {
            menuText.text = "player one wins!";
        }
        if (P2Shot == true)
        {
            menuText.text = "player two wins!";
        }

    }

    void ringBell()
    {
        if(bellCount <= 3)
        {
            randomTime = Random.Range(randomTimeMin, randomTimeMax);
            odds = Random.Range(oddsMin, oddsMax);
            if(odds > oddsThreshold)
            {
                soundz.PlayOneShot(bellDing);
                bellCount = bellCount + 1;
                if(bellCount < 3)
                {
                    Invoke("ringBell", randomTime);
                }
            }
            else
            {
                int index = Random.Range(0, throwOffSounds.Length);
                chosenSound = throwOffSounds[index];
                soundz.PlayOneShot(chosenSound);
                Invoke("ringBell", randomTime);
            }
        }
    }
}
