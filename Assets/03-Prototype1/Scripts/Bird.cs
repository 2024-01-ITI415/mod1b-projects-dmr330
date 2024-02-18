using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.PlayerSettings;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("Set in Inspector")]

    public TextMeshProUGUI scoreGT;

    public Rigidbody rb;



    //Variables that let me adjust gravity and jump
    public float sphereGravity = -10.0f;
    public float jumpAmount = 10;

    //Turning off Unity's built-in gravity
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;


        // Find a reference to the ScoreCounter GameObject
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Get the Text Component of that GameObject
        scoreGT = scoreGO.GetComponent<TextMeshProUGUI>();
        // Set the starting number of points to 0
        scoreGT.text = "0";
    }

    private void Update()
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

        if (collidedWith.tag == "ScoreTrigger")
        {
            Destroy(collidedWith);
            // Parse the text of the scoreGT into an int
            int score = int.Parse(scoreGT.text);
            // Add points for catching the apple
            score += 1;
            // Convert the score back to a string and display it
            scoreGT.text = score.ToString();
        }
    }
}
