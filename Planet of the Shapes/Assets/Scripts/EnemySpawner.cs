using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] waves;
    public DoorSpawn doorSpawn;
    public GameObject currentWave;
    private int wavesCompleted;
    public bool finalRoom;
    public static int score;

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


    void Update()
    {
        if (doorSpawn != null) //validation needed in case the room with this instance of doorSpawn is destroyed
        {
            if (doorSpawn.RoomEntered) //no enemies will spawn unless the player enters the room
            {
                if (wavesCompleted == waves.Length && currentWave.transform.childCount == 0)
                {
                    doorSpawn.RoomComplete();
                    if (finalRoom == true)
                    {
                        score += 1;
                        RoomOrganiser.maxRooms += 2;
                        Invoke("newLevel", 1f);
                    }
                    else
                    {
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

    private void newLevel()
    {
        SceneManager.LoadScene("Gameplay");
    }

}
