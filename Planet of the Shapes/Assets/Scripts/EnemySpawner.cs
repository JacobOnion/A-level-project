using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] waves;
    public DoorSpawn doorSpawn;
    public GameObject currentWave;
    private int wavesCompleted;
    private bool disabled;

    /*private void Awake()
    {
        if (disabled == false)
        {
            gameObject.SetActive(false); //disables this script during level generation to prevent null reference exception errors
        }
    }*/
    void Start()
    {
        bool sorted = false; //Sorts the array of waves to ensure they are spawned in the correct order
        GameObject temp;
        while (sorted == false)
        {
            sorted = true;
            for (int i = 0; i < waves.Length-1; i++)
            {
               if (int.Parse(waves[i].name) > int.Parse(waves[i+1].name))
                {
                    temp = waves[i];
                    waves[i] = waves[i+1];
                    waves[i+1] = temp;
                    sorted = false;
                }
            }
        }
    }

    /*void OnDisable()
    {
        disabled = true;
    }*/

    void Update()
    {
        if (doorSpawn != null) //validation needed in case the room with this instance of doorSpawn is destroyed
        {
            if (doorSpawn.RoomEntered) //no enemies will spawn unless the player enters the room
            {
                if (wavesCompleted == waves.Length)
                {
                    if (currentWave.transform.childCount == 0) //checks if all enemies are dead
                    {
                        doorSpawn.RoomComplete();
                        Destroy(gameObject);
                    }
                }
                else if (currentWave.transform.childCount == 0)
                {
                    currentWave = Instantiate(waves[wavesCompleted], transform.position, Quaternion.identity);//creates the next wave of enemies
                    wavesCompleted += 1;
                }
            }
        }
    }

}
