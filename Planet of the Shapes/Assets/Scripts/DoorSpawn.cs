using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSpawn : MonoBehaviour
{
    private List<GameObject> doors = new List<GameObject>();
    private bool roomEntered;
    public bool RoomEntered //Declared as a property so it can only be editted inside this class
    {
        get { return roomEntered; }
        private set { roomEntered = value; }
    }

    void Start()
    {
        foreach(Transform child in gameObject.transform)
        {
            doors.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }
    }

    public void RoomComplete()
    {
        foreach (GameObject door in doors)
        {
            door.SetActive(false);
        }
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            foreach (GameObject door in doors)
            {
                door.SetActive(true);
            }
            roomEntered = true;
        }
    }
}
