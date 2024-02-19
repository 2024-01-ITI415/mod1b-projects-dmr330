using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.PlayerSettings;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("Set in Inspector")]

    public Text birdScoreGT;

    public Rigidbody rb;

    //Variables that let me adjust gravity and jump
    public float sphereGravity = -10.0f;
    public float jumpAmount = 10;

    //Turning off Unity's built-in gravity
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        //Find a reference to the Bird ScoreCounter GameObject
        GameObject birdScoreGO = GameObject.Find("BirdScoreCounter");
        //Get the Texxt Component of that GameObject
        birdScoreGT = birdScoreGO.GetComponent<Text>();
        //Set the starting number of points to 0
        birdScoreGT.text = "0";
    }

    void Update()
    {
        //If the user presses space, add a force upwards
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
        }
    }
    void FixedUpdate()
    {
        //Apply custom gravity to the sphere
        Vector3 gravity = sphereGravity * Vector3.up;
        rb.AddForce(gravity, ForceMode.Acceleration);
    }
    void OnCollisionEnter(Collision coll)
    {
        // Detect collision
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Pipe")
        {
            SceneManager.LoadScene("Main-FlappyBird");
        }

        //Do the same thing for the kill boxes but don't delete them
        if (collidedWith.tag == "KillBox")
        {
            SceneManager.LoadScene("Main-FlappyBird");
        }

        //Add a point when the bird passes a score trigger
        if (collidedWith.tag == "ScoreTrigger")
        {
            Destroy(collidedWith);
            //Parse the text of the birdScoreGT into an int
            int birdScore = int.Parse(birdScoreGT.text);
            //Add points for passing a pipe
            birdScore += 1;
            //Convert the score back to a string and display it
            birdScoreGT.text = birdScore.ToString();

            //Track the high score
            if (birdScore > BirdHighScore.birdScore)
            {
                BirdHighScore.birdScore = birdScore;
            }

        }
    }
}
