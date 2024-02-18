using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappySphere : MonoBehaviour
{
    [Header("Set in Inspector")]

    //Prefab for instantiating pipes
    public GameObject pipePrefab;

    //Rate at which the pipes will be instantiated
    public float secondsBetweenPipes = 3f;

    void Start()
    {
        //Spawning pipes after a delay
        Invoke("SpawnPipe", 3f);
    }

    void SpawnPipe()
    {
        GameObject pipe = Instantiate<GameObject>(pipePrefab);
        Invoke("SpawnPipe", secondsBetweenPipes);
    }
}
