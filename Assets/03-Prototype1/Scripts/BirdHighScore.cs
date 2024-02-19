using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class BirdHighScore : MonoBehaviour
{
   static public int birdScore = 10;

    void Awake()
    {
        //If the PlayerPrefs BirdHighScore already exists, read it
        if (PlayerPrefs.HasKey("BirdHighScore"))
        {
            birdScore = PlayerPrefs.GetInt("BirdHighScore");
        }
        //Assign the high score to BirdHighScore
        PlayerPrefs.SetInt("BirdHighScore", birdScore);
    }

    void Update()
    {
        Text brdgt = this.GetComponent<Text>();
        brdgt.text = "High Score: " + birdScore;
        //Update the PlayerPrefs HighScore if necessary
        if (birdScore > PlayerPrefs.GetInt("BirdHighScore"))
        {
            PlayerPrefs.SetInt("BirdHighScore", birdScore);
        }
    }
}