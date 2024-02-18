using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappySphere : MonoBehaviour
{
    public float sphereGravity = -10.0f;
    // Start is called before the first frame update
    void Start()
    {
        if(!(Input.GetKeyDown(KeyCode.Space)))
        {
            sphereGravity = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
