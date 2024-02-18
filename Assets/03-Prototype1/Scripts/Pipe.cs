using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [Header("Set in Inspector")]

    //Speed of moving left
    public float speed = -1.0f;

    // Update is called once per frame
    void Update()
    {
        //Swipe left
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
    }
}
