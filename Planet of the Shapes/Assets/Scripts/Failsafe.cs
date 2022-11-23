using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Failsafe : MonoBehaviour
{
    //destroys the parent gameobject of the spawnpoint if it is on top of another spawnpoint,
    //to prevent walls generating on top of existing rooms.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("spawn"))
        {
            if (other.gameObject.GetComponent<spawn>().spawned == true)
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
