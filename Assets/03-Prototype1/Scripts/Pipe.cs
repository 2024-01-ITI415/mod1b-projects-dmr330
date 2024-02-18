using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Pipe : MonoBehaviour
{
    [Header("Set in Inspector")]

    //Speed of moving left
    public float speed = -1.0f;

    //Left edge of screen
    public float leftEdge = -10f;

    //Pipe X Spawn
    public float pipeSpawnX = 16f;

    //Parameters for random generation
    public float pipeMinY = -10f;
    public float pipeMaxY = 10f;

    void Start()
    {
        //Override the pipe's loaction to a random value
        Vector3 randY = new Vector3(pipeSpawnX, Random.Range(pipeMinY, pipeMaxY), 0);
        this.gameObject.transform.position = randY;
    }
    // Update is called once per frame
    void Update()
    {
        //Swipe Left
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < leftEdge)
        {
            Destroy(this.gameObject);
        }
    }
}
