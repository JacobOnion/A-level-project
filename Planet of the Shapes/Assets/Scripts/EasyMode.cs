using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EasyMode : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
