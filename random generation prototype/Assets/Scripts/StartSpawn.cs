using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSpawn : MonoBehaviour
{
    //Destroys the spawnpoint on top of the gameobject before it can spawn another room.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("spawn"))
        {
            Destroy(other.gameObject);
        }
    }
}
