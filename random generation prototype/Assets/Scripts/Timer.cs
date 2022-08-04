using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float spawnTime;
    public float timeElapsed;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    // calculates the time the gameobject has been instantiated for
    void Update()
    {
        timeElapsed = Time.realtimeSinceStartup - spawnTime;
    }
}
