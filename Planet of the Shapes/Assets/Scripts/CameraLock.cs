using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    private GameObject mainCamera;
    void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player")) //runs true when the player enters the room this script is attached to
        {
            mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -10f); //locks the camera to the room
        }
    }
}
